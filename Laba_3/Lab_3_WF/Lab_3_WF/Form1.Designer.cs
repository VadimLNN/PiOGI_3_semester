namespace Lab_3_WF
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_1 = new Lab_3_WF.HoverButton();
            this.SuspendLayout();
            // 
            // Button_1
            // 
            this.Button_1.Font = new System.Drawing.Font("Microsoft YaHei UI", 120.125F, System.Drawing.FontStyle.Bold);
            this.Button_1.ForeColor = System.Drawing.Color.White;
            this.Button_1.Location = new System.Drawing.Point(31, 112);
            this.Button_1.Name = "Button_1";
            this.Button_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Button_1.Size = new System.Drawing.Size(716, 206);
            this.Button_1.TabIndex = 0;
            this.Button_1.Text = " Button";
            this.Button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Button_1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private HoverButton Button_1;
    }
}

