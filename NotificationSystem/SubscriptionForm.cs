using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static NotificationSystem.Form1;

namespace NotificationSystem
{
    public partial class SubscriptionForm : Form
    {
        public event SubscriptionHandler SubscribeEvent;
        public event SubscriptionHandler UnsubscribeEvent;


        public SubscriptionForm()
        {
            InitializeComponent();
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string mobile = txtMobile.Text.Trim();

            bool validInput = false;

            if (!string.IsNullOrEmpty(email) && IsValidEmail(email))
            {
                SubscribeEvent?.Invoke(email);
                validInput = true;
            }
            else if (!string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Invalid email format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!string.IsNullOrEmpty(mobile) && IsValidMobile(mobile))
            {
                SubscribeEvent?.Invoke(mobile);
                validInput = true;
            }
            else if (!string.IsNullOrEmpty(mobile))
            {
                MessageBox.Show("Invalid mobile format! Must be 10 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (validInput)
            {
                MessageBox.Show("Subscription successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string mobile = txtMobile.Text.Trim();

            if (!string.IsNullOrEmpty(email))
            {
                UnsubscribeEvent?.Invoke(email);
            }

            if (!string.IsNullOrEmpty(mobile))
            {
                UnsubscribeEvent?.Invoke(mobile);
            }

            MessageBox.Show("Unsubscription successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidMobile(string mobile)
        {
            return Regex.IsMatch(mobile, @"^\d{10}$");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
