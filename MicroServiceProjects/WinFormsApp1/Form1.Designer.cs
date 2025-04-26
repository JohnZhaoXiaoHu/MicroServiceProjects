
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            btn = new System.Windows.Forms.Button();
            btn_Task = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn
            // 
            btn.Location = new System.Drawing.Point(220, 262);
            btn.Name = "btn";
            btn.Size = new System.Drawing.Size(75, 26);
            btn.TabIndex = 0;
            btn.Text = "浏  览";
            btn.UseVisualStyleBackColor = true;
            btn.Click += btn_Click;
            // 
            // btn_Task
            // 
            btn_Task.Location = new System.Drawing.Point(485, 262);
            btn_Task.Name = "btn_Task";
            btn_Task.Size = new System.Drawing.Size(75, 26);
            btn_Task.TabIndex = 1;
            btn_Task.Text = "Task";
            btn_Task.UseVisualStyleBackColor = true;
            btn_Task.Click += btn_Task_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 510);
            Controls.Add(btn_Task);
            Controls.Add(btn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btn_Task;
    }
}

