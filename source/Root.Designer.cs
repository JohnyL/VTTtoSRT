namespace VTTtoSRT
{
  partial class Root
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
      btnConvert = new Button();
      chkDeleteSrtFile = new CheckBox();
      SuspendLayout();
      // 
      // btnConvert
      // 
      btnConvert.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
      btnConvert.Location = new Point(14, 14);
      btnConvert.Margin = new Padding(4, 3, 4, 3);
      btnConvert.Name = "btnConvert";
      btnConvert.Size = new Size(303, 38);
      btnConvert.TabIndex = 0;
      btnConvert.Text = "Convert VTT to SRT";
      btnConvert.UseVisualStyleBackColor = true;
      btnConvert.Click += OnConvert;
      // 
      // chkDeleteSrtFile
      // 
      chkDeleteSrtFile.AutoSize = true;
      chkDeleteSrtFile.Location = new Point(14, 58);
      chkDeleteSrtFile.Name = "chkDeleteSrtFile";
      chkDeleteSrtFile.Size = new Size(199, 19);
      chkDeleteSrtFile.TabIndex = 1;
      chkDeleteSrtFile.Text = "Delete SRT file(s) after converting";
      chkDeleteSrtFile.UseVisualStyleBackColor = true;
      // 
      // Root
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(332, 87);
      Controls.Add(chkDeleteSrtFile);
      Controls.Add(btnConvert);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Margin = new Padding(4, 3, 4, 3);
      Name = "Root";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "VTT to SRT";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Button btnConvert;
    private CheckBox chkDeleteSrtFile;
  }
}

