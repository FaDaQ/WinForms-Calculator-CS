namespace Калькулятор_GUI_V2
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
            this.ExpressionPanel = new System.Windows.Forms.Panel();
            this.Expression = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.StandartMode = new System.Windows.Forms.Button();
            this.IPMode = new System.Windows.Forms.Button();
            this.ExpressionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExpressionPanel
            // 
            this.ExpressionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpressionPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.ExpressionPanel.Controls.Add(this.Expression);
            this.ExpressionPanel.Location = new System.Drawing.Point(4, 12);
            this.ExpressionPanel.Name = "ExpressionPanel";
            this.ExpressionPanel.Size = new System.Drawing.Size(560, 100);
            this.ExpressionPanel.TabIndex = 0;
            // 
            // Expression
            // 
            this.Expression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Expression.AutoSize = true;
            this.Expression.BackColor = System.Drawing.Color.Transparent;
            this.Expression.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Expression.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Expression.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Expression.Location = new System.Drawing.Point(3, 29);
            this.Expression.Name = "Expression";
            this.Expression.Size = new System.Drawing.Size(40, 45);
            this.Expression.TabIndex = 0;
            this.Expression.Text = "0";
            this.Expression.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.DimGray;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimizeButton.Location = new System.Drawing.Point(503, -2);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(40, 23);
            this.MinimizeButton.TabIndex = 2;
            this.MinimizeButton.Text = " ‾";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.MinimizeButton.UseVisualStyleBackColor = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Brown;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.Location = new System.Drawing.Point(544, -2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(40, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = " X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CloseButton.UseVisualStyleBackColor = false;
            // 
            // StandartMode
            // 
            this.StandartMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StandartMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StandartMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.StandartMode.Location = new System.Drawing.Point(12, 663);
            this.StandartMode.Name = "StandartMode";
            this.StandartMode.Size = new System.Drawing.Size(75, 23);
            this.StandartMode.TabIndex = 3;
            this.StandartMode.Text = "Обычный";
            this.StandartMode.UseVisualStyleBackColor = false;
            // 
            // IPMode
            // 
            this.IPMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.IPMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IPMode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.IPMode.Location = new System.Drawing.Point(93, 663);
            this.IPMode.Name = "IPMode";
            this.IPMode.Size = new System.Drawing.Size(75, 23);
            this.IPMode.TabIndex = 4;
            this.IPMode.Text = "IP";
            this.IPMode.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 698);
            this.Controls.Add(this.IPMode);
            this.Controls.Add(this.StandartMode);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ExpressionPanel);
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ExpressionPanel.ResumeLayout(false);
            this.ExpressionPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ExpressionPanel;
        private Label Expression;
        private Button CloseButton;
        private Button MinimizeButton;
        private Button StandartMode;
        private Button IPMode;
    }
}