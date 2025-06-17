namespace NotificationSystem
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
            this.btnManageSubscription = new System.Windows.Forms.Button();
            this.btnPublishNotification = new System.Windows.Forms.Button();
            this.lstSubscribers = new System.Windows.Forms.ListBox();
            this.lblSubscribers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManageSubscription
            // 
            this.btnManageSubscription.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnManageSubscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageSubscription.Location = new System.Drawing.Point(53, 88);
            this.btnManageSubscription.Name = "btnManageSubscription";
            this.btnManageSubscription.Size = new System.Drawing.Size(184, 69);
            this.btnManageSubscription.TabIndex = 0;
            this.btnManageSubscription.Text = "Manage Subscription";
            this.btnManageSubscription.UseVisualStyleBackColor = false;
            this.btnManageSubscription.Click += new System.EventHandler(this.btnManageSubscription_Click);
            // 
            // btnPublishNotification
            // 
            this.btnPublishNotification.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPublishNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublishNotification.Location = new System.Drawing.Point(53, 205);
            this.btnPublishNotification.Name = "btnPublishNotification";
            this.btnPublishNotification.Size = new System.Drawing.Size(184, 69);
            this.btnPublishNotification.TabIndex = 1;
            this.btnPublishNotification.Text = "Publish Notification";
            this.btnPublishNotification.UseVisualStyleBackColor = false;
            // 
            // lstSubscribers
            // 
            this.lstSubscribers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lstSubscribers.FormattingEnabled = true;
            this.lstSubscribers.ItemHeight = 16;
            this.lstSubscribers.Location = new System.Drawing.Point(506, 205);
            this.lstSubscribers.Name = "lstSubscribers";
            this.lstSubscribers.Size = new System.Drawing.Size(227, 196);
            this.lstSubscribers.TabIndex = 3;
            // 
            // lblSubscribers
            // 
            this.lblSubscribers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblSubscribers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSubscribers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscribers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSubscribers.Location = new System.Drawing.Point(506, 88);
            this.lblSubscribers.Name = "lblSubscribers";
            this.lblSubscribers.Size = new System.Drawing.Size(227, 69);
            this.lblSubscribers.TabIndex = 4;
            this.lblSubscribers.Text = "Subscribers: 0";
            this.lblSubscribers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.lblSubscribers);
            this.Controls.Add(this.lstSubscribers);
            this.Controls.Add(this.btnPublishNotification);
            this.Controls.Add(this.btnManageSubscription);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "Form1";
            this.Text = "Notification System";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageSubscription;
        private System.Windows.Forms.Button btnPublishNotification;
        private System.Windows.Forms.ListBox lstSubscribers;
        private System.Windows.Forms.Label lblSubscribers;
    }
}

