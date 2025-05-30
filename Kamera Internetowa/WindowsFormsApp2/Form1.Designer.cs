namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.turn_on = new System.Windows.Forms.Button();
            this.turn_off = new System.Windows.Forms.Button();
            this.take_picture = new System.Windows.Forms.Button();
            this.record_video_start = new System.Windows.Forms.Button();
            this.contrast_bar = new System.Windows.Forms.TrackBar();
            this.saturation_bar = new System.Windows.Forms.TrackBar();
            this.brightness_bar = new System.Windows.Forms.TrackBar();
            this.contrast_label = new System.Windows.Forms.Label();
            this.brightness_label = new System.Windows.Forms.Label();
            this.saturation_label = new System.Windows.Forms.Label();
            this.camera_box = new System.Windows.Forms.PictureBox();
            this.info_text_box = new System.Windows.Forms.RichTextBox();
            this.sensivity_bar = new System.Windows.Forms.TrackBar();
            this.sensitivity_label = new System.Windows.Forms.Label();
            this.ruch_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contrast_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensivity_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(59, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wybór kamery";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // turn_on
            // 
            this.turn_on.Location = new System.Drawing.Point(59, 153);
            this.turn_on.Name = "turn_on";
            this.turn_on.Size = new System.Drawing.Size(116, 36);
            this.turn_on.TabIndex = 2;
            this.turn_on.Text = "Włącz";
            this.turn_on.UseVisualStyleBackColor = true;
            this.turn_on.Click += new System.EventHandler(this.turn_on_Click);
            // 
            // turn_off
            // 
            this.turn_off.Location = new System.Drawing.Point(181, 153);
            this.turn_off.Name = "turn_off";
            this.turn_off.Size = new System.Drawing.Size(116, 36);
            this.turn_off.TabIndex = 3;
            this.turn_off.Text = "Wyłącz";
            this.turn_off.UseVisualStyleBackColor = true;
            this.turn_off.Click += new System.EventHandler(this.turn_off_Click);
            // 
            // take_picture
            // 
            this.take_picture.Location = new System.Drawing.Point(59, 213);
            this.take_picture.Name = "take_picture";
            this.take_picture.Size = new System.Drawing.Size(116, 36);
            this.take_picture.TabIndex = 4;
            this.take_picture.Text = "Zrób zdjęcie";
            this.take_picture.UseVisualStyleBackColor = true;
            this.take_picture.Click += new System.EventHandler(this.take_picture_Click);
            // 
            // record_video_start
            // 
            this.record_video_start.Location = new System.Drawing.Point(59, 264);
            this.record_video_start.Name = "record_video_start";
            this.record_video_start.Size = new System.Drawing.Size(121, 61);
            this.record_video_start.TabIndex = 5;
            this.record_video_start.Text = "Nagraj film";
            this.record_video_start.UseVisualStyleBackColor = true;
            this.record_video_start.Click += new System.EventHandler(this.record_video_Click);
            // 
            // contrast_bar
            // 
            this.contrast_bar.Location = new System.Drawing.Point(59, 426);
            this.contrast_bar.Maximum = 100;
            this.contrast_bar.Minimum = -100;
            this.contrast_bar.Name = "contrast_bar";
            this.contrast_bar.Size = new System.Drawing.Size(298, 69);
            this.contrast_bar.TabIndex = 6;
            this.contrast_bar.Scroll += new System.EventHandler(this.contrast_Scroll);
            // 
            // saturation_bar
            // 
            this.saturation_bar.Location = new System.Drawing.Point(60, 679);
            this.saturation_bar.Maximum = 100;
            this.saturation_bar.Minimum = -100;
            this.saturation_bar.Name = "saturation_bar";
            this.saturation_bar.Size = new System.Drawing.Size(297, 69);
            this.saturation_bar.TabIndex = 7;
            this.saturation_bar.Scroll += new System.EventHandler(this.saturation_Scroll);
            // 
            // brightness_bar
            // 
            this.brightness_bar.Location = new System.Drawing.Point(59, 546);
            this.brightness_bar.Maximum = 100;
            this.brightness_bar.Minimum = -100;
            this.brightness_bar.Name = "brightness_bar";
            this.brightness_bar.Size = new System.Drawing.Size(298, 69);
            this.brightness_bar.TabIndex = 8;
            this.brightness_bar.Scroll += new System.EventHandler(this.brightness_Scroll);
            // 
            // contrast_label
            // 
            this.contrast_label.AutoSize = true;
            this.contrast_label.Location = new System.Drawing.Point(66, 387);
            this.contrast_label.Name = "contrast_label";
            this.contrast_label.Size = new System.Drawing.Size(86, 20);
            this.contrast_label.TabIndex = 9;
            this.contrast_label.Text = "Kontrast: 0";
            this.contrast_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // brightness_label
            // 
            this.brightness_label.AutoSize = true;
            this.brightness_label.Location = new System.Drawing.Point(66, 523);
            this.brightness_label.Name = "brightness_label";
            this.brightness_label.Size = new System.Drawing.Size(85, 20);
            this.brightness_label.TabIndex = 10;
            this.brightness_label.Text = "Jasność: 0";
            this.brightness_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // saturation_label
            // 
            this.saturation_label.AutoSize = true;
            this.saturation_label.Location = new System.Drawing.Point(66, 656);
            this.saturation_label.Name = "saturation_label";
            this.saturation_label.Size = new System.Drawing.Size(99, 20);
            this.saturation_label.TabIndex = 11;
            this.saturation_label.Text = "Nasycenie: 0";
            // 
            // camera_box
            // 
            this.camera_box.Location = new System.Drawing.Point(408, 94);
            this.camera_box.Name = "camera_box";
            this.camera_box.Size = new System.Drawing.Size(1280, 960);
            this.camera_box.TabIndex = 12;
            this.camera_box.TabStop = false;
            this.camera_box.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // info_text_box
            // 
            this.info_text_box.Location = new System.Drawing.Point(100, 777);
            this.info_text_box.Name = "info_text_box";
            this.info_text_box.Size = new System.Drawing.Size(142, 50);
            this.info_text_box.TabIndex = 14;
            this.info_text_box.Text = "";
            // 
            // sensivity_bar
            // 
            this.sensivity_bar.Location = new System.Drawing.Point(43, 927);
            this.sensivity_bar.Maximum = 100;
            this.sensivity_bar.Name = "sensivity_bar";
            this.sensivity_bar.Size = new System.Drawing.Size(297, 69);
            this.sensivity_bar.TabIndex = 15;
            this.sensivity_bar.Value = 5;
            this.sensivity_bar.Scroll += new System.EventHandler(this.sensivity_bar_Scroll);
            // 
            // sensitivity_label
            // 
            this.sensitivity_label.AutoSize = true;
            this.sensitivity_label.Location = new System.Drawing.Point(76, 895);
            this.sensitivity_label.Name = "sensitivity_label";
            this.sensitivity_label.Size = new System.Drawing.Size(83, 20);
            this.sensitivity_label.TabIndex = 16;
            this.sensitivity_label.Text = "Czułość: 5";
            // 
            // ruch_label
            // 
            this.ruch_label.AutoSize = true;
            this.ruch_label.Location = new System.Drawing.Point(153, 1011);
            this.ruch_label.Name = "ruch_label";
            this.ruch_label.Size = new System.Drawing.Size(47, 20);
            this.ruch_label.TabIndex = 17;
            this.ruch_label.Text = "Ruch";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 1184);
            this.Controls.Add(this.ruch_label);
            this.Controls.Add(this.sensitivity_label);
            this.Controls.Add(this.sensivity_bar);
            this.Controls.Add(this.info_text_box);
            this.Controls.Add(this.camera_box);
            this.Controls.Add(this.saturation_label);
            this.Controls.Add(this.brightness_label);
            this.Controls.Add(this.contrast_label);
            this.Controls.Add(this.brightness_bar);
            this.Controls.Add(this.saturation_bar);
            this.Controls.Add(this.contrast_bar);
            this.Controls.Add(this.record_video_start);
            this.Controls.Add(this.take_picture);
            this.Controls.Add(this.turn_off);
            this.Controls.Add(this.turn_on);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contrast_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturation_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightness_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camera_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensivity_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button turn_on;
        private System.Windows.Forms.Button turn_off;
        private System.Windows.Forms.Button take_picture;
        private System.Windows.Forms.Button record_video_start;
        private System.Windows.Forms.TrackBar contrast_bar;
        private System.Windows.Forms.TrackBar saturation_bar;
        private System.Windows.Forms.TrackBar brightness_bar;
        private System.Windows.Forms.Label contrast_label;
        private System.Windows.Forms.Label brightness_label;
        private System.Windows.Forms.Label saturation_label;
        private System.Windows.Forms.PictureBox camera_box;
        private System.Windows.Forms.RichTextBox info_text_box;
        private System.Windows.Forms.TrackBar sensivity_bar;
        private System.Windows.Forms.Label sensitivity_label;
        private System.Windows.Forms.Label ruch_label;
    }
}

