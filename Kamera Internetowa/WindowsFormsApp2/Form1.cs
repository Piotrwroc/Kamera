using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
using Accord.Video.FFMPEG;


namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        int contrast, brightness, saturation, sensitivity =5;
        FilterInfoCollection videoDevices;
        VideoCaptureDevice camera;
        int framesCounter, trueWidth, trueHeight;
        private Bitmap oldFrame = null; // Poprzednia klatka
        private Bitmap oldFrame2 = null; // Klatka sprzed dwóch iteracji
        private Bitmap oldFrame3 = null; // Klatka sprzed trzech iteracji
        private Bitmap oldFrame4 = null; // Klatka sprzed czterech iteracji
        private VideoFileWriter videoWriter; // Odpowiada za zapis klatek wideo
        private bool isRecording = false;   // Flaga oznaczająca, czy trwa nagrywanie



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            camera_box.BackColor = Color.Black;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    comboBox1.Items.Add(videoDevices[i].Name);              
                }
            }
            else
            {
                MessageBox.Show("Brak dostępnych kamer.");
                this.Close();
            }

        }

        private void GetCameraInfo()
        {
            try
            {
                // Pobieramy dostępne rozdzielczości i właściwości
                Console.WriteLine("\nDostępne rozdzielczości:");
                foreach (VideoCapabilities capability in camera.VideoCapabilities)
                {
                    Console.WriteLine($"  - Rozdzielczość: {capability.FrameSize.Width}x{capability.FrameSize.Height}, FPS: {capability.AverageFrameRate}");
                }

                Console.WriteLine("\nDostępne właściwości wyjścia wideo:");
                foreach (VideoCapabilities capability in camera.SnapshotCapabilities)
                {
                    Console.WriteLine($"  - Rozdzielczość zdjęcia: {capability.FrameSize.Width}x{capability.FrameSize.Height}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Camera_FrameUpdate(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            framesCounter++;

            //Bitmap scaledFrame = ScaleImageToFitPictureBox((Bitmap)eventArgs.Frame.Clone());

            //BrightnessCorrection br = new BrightnessCorrection(brightness);
            //scaledFrame = br.Apply((Bitmap)scaledFrame.Clone());
            //ContrastCorrection cr = new ContrastCorrection(contrast);
            //scaledFrame = cr.Apply((Bitmap)scaledFrame.Clone());
            //SaturationCorrection sr = new SaturationCorrection(saturation);
            //scaledFrame = sr.Apply((Bitmap)scaledFrame.Clone());
            Bitmap scaledFrame = (Bitmap)eventArgs.Frame.Clone();
            if (isRecording)
            {
                
                videoWriter.WriteVideoFrame(scaledFrame);

            }
            camera_box.Image = scaledFrame;
            if (oldFrame != null && oldFrame2 != null && framesCounter == 50)
            {

                oldFrame3 = oldFrame;
                oldFrame4 = oldFrame2;

                motion();
                framesCounter = 0;
                oldFrame2 = oldFrame;
            }
            oldFrame = scaledFrame;
            if (oldFrame2 == null) oldFrame2 = oldFrame;
        }

        private void motion()
        {
            if (oldFrame3 == null || oldFrame4 == null)
            {
                Console.WriteLine("Brak klatek do analizy.");
                return;
            }

            // Upewniamy się, że obrazy mają takie same wymiary
            if (oldFrame3.Width != oldFrame4.Width || oldFrame3.Height != oldFrame4.Height)
            {
                Console.WriteLine("Klatki mają różne wymiary.");
                return;
            }

            BitmapData data1 = oldFrame3.LockBits(new Rectangle(0, 0, oldFrame3.Width, oldFrame3.Height),
                                                  ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData data2 = oldFrame4.LockBits(new Rectangle(0, 0, oldFrame4.Width, oldFrame4.Height),
                                                  ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int count = 0;
            int width = oldFrame3.Width;
            int height = oldFrame3.Height;

            unsafe
            {
                byte* ptr1 = (byte*)data1.Scan0;
                byte* ptr2 = (byte*)data2.Scan0;

                int stride = data1.Stride;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int index = y * stride + x * 3;

                        // Pobieranie wartości RGB (Format24bppRgb - 3 bajty na piksel)
                        byte b1 = ptr1[index];
                        byte g1 = ptr1[index + 1];
                        byte r1 = ptr1[index + 2];

                        byte b2 = ptr2[index];
                        byte g2 = ptr2[index + 1];
                        byte r2 = ptr2[index + 2];

                        // Porównanie pikseli (R, G, B)
                        int diff = 0;
                        if (Math.Abs(r1 - r2) > 20) diff++;
                        if (Math.Abs(g1 - g2) > 20) diff++;
                        if (Math.Abs(b1 - b2) > 20) diff++;

                        // Liczymy, jeśli różnica jest istotna (np. 2 lub więcej składniki się różnią)
                        if (diff > 1) count++;
                    }
                }
            }

            // Odblokowanie pamięci obrazów
            oldFrame3.UnlockBits(data1);
            oldFrame4.UnlockBits(data2);

            // Wykrycie ruchu, jeśli zmienione piksele przekroczą pewien próg
            double changeRatio = (double)count / (width * height);
            Console.WriteLine($"Zmiana: {changeRatio:P2} ({count} pikseli zmienionych)");

            if (changeRatio > (float)sensitivity/100) 
            {
                //Console.WriteLine("Wykryto ruch!");
                if (ruch_label.InvokeRequired)
                {
                    ruch_label.Invoke(new MethodInvoker(delegate { ruch_label.Text= "Wykryto ruch!"; }));
                }
            }
            else
            {
                //Console.WriteLine("Brak ruchu.");
                if (ruch_label.InvokeRequired)
                {
                    ruch_label.Invoke(new MethodInvoker(delegate { ruch_label.Text = "Brak ruchu."; }));
                }
            }
        }


        private Bitmap ScaleImageToFitPictureBox(Bitmap original)
        {
            int pictureBoxWidth = camera_box.Width;
            int pictureBoxHeight = camera_box.Height;

            float scaleFactor = Math.Min((float)pictureBoxWidth / original.Width,
            (float)pictureBoxHeight / original.Height);

            int newWidth = (int)(original.Width * scaleFactor);
            int newHeight = (int)(original.Height * scaleFactor);
            trueWidth = newWidth;
            if (trueWidth % 2 != 0)
            {
                trueWidth--;
            }
            trueHeight = newHeight;
            if (trueHeight % 2 != 0)
            {
                trueHeight--;
            }

            Bitmap scaledImage = new Bitmap(trueWidth, trueHeight);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.DrawImage(original, 0, 0, trueWidth, trueHeight);
            }
            return scaledImage;
        }

        private void turn_on_Click(object sender, EventArgs e)
        {
            if (videoDevices.Count == 0) return;
            camera = new VideoCaptureDevice(videoDevices[0].MonikerString);
            camera.NewFrame += Camera_FrameUpdate;
            camera.VideoResolution = camera.VideoCapabilities.FirstOrDefault(c => c.FrameSize.Width == 640 && c.FrameSize.Height==480);
            camera.Start();
            info_text_box.Text = "";
            GetCameraInfo();
        }



        private void take_picture_Click(object sender, EventArgs e)
        {
            try
            {
            if (!camera.IsRunning) return;
                
                camera.Stop();
                Bitmap picture = (Bitmap)camera_box.Image;
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "BMP Files (*.bmp)|*.bmp";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picture.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                }
                camera.Start();
            }
            catch (Exception)
            {

                info_text_box.Text = "Brak wlaczonej kamery";
            }
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void record_video_Click(object sender, EventArgs e)
        {
            try
            {

            if (!camera.IsRunning) return;
            if (!isRecording)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "AVI Files (*.avi)|*.avi";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
            
{
                    videoWriter = new VideoFileWriter();
                    //videoWriter.Open(saveFileDialog.FileName, trueWidth, trueHeight, 13, VideoCodec.Default);
                    videoWriter.Open(saveFileDialog.FileName, 640, 480, 30, VideoCodec.Default);
                    isRecording = true;
                    info_text_box.Text = "Rozpoczęto nagrywanie";
                }
            }
            else
            {
                if (videoWriter != null)
                {
                    videoWriter.Close();
                    isRecording = false;
                    info_text_box.Text = "Zakończono nagrywanie";
                }
            }
            }
            catch (Exception)
            {

                info_text_box.Text = "Brak wlaczonej kamery";
     
            }
        }


        private void turn_off_Click(object sender, EventArgs e)
        {
            if (camera.IsRunning)
            {
                camera.Stop();
                camera = null;
            }
            Bitmap scaledImage = new Bitmap(trueWidth, trueHeight);
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.DrawImage(scaledImage, 0, 0, trueWidth, trueHeight);
            }
            camera_box.Image = scaledImage;
            info_text_box.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sensivity_bar_Scroll(object sender, EventArgs e)
        {
            sensitivity = sensivity_bar.Value;
            sensitivity_label.Text = "Czułość: " + sensitivity;
        }

        private void brightness_Scroll(object sender, EventArgs e)
        {
            brightness = brightness_bar.Value;
            brightness_label.Text = "Jasność: " + brightness;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void saturation_Scroll(object sender, EventArgs e)
        {
            saturation = saturation_bar.Value;
            saturation_label.Text = "Nasycenie: " + saturation;
        }

        private void contrast_Scroll(object sender, EventArgs e)
        {
            contrast = contrast_bar.Value;
            contrast_label.Text = "Kontrast: " + contrast;
        }
    }
}
