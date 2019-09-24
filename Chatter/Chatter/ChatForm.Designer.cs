namespace Chattter
{
    partial class ChatForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ChatRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ChatRichTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sendTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sendButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ChatRichTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ChatRichTextBox, 2);
            this.ChatRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.ChatRichTextBox.Name = "ChatRichTextBox";
            this.ChatRichTextBox.ReadOnly = true;
            this.ChatRichTextBox.Size = new System.Drawing.Size(794, 399);
            this.ChatRichTextBox.TabIndex = 0;
            this.ChatRichTextBox.Text = "";
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(3, 408);
            this.sendTextBox.MaxLength = 968;
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(634, 39);
            this.sendTextBox.TabIndex = 1;
            this.sendTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendTextBox_KeyPress);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(643, 408);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(154, 39);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChatForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox ChatRichTextBox;
        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
    }
}

