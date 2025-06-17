namespace NotificationSystem
{
    public class SendViaMobile
    {
        public string MobileNumber { get; set; }

        public SendViaMobile(string mobileNumber)
        {
            MobileNumber = mobileNumber;
        }

        public void SendNotification(string message)
        {
            // Simulate sending a mobile SMS
            System.Windows.Forms.MessageBox.Show($"SMS sent to {MobileNumber}: {message}", "Notification", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
