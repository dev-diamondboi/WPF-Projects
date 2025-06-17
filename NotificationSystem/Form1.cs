using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NotificationSystem
{
    public partial class Form1 : Form
    {
        public delegate void SubscriptionHandler(string contact);
        public event SubscriptionHandler SubscribeEvent;
        public event SubscriptionHandler UnsubscribeEvent;

        private List<SendViaEmail> emailSubscribers = new List<SendViaEmail>();
        private List<SendViaMobile> mobileSubscribers = new List<SendViaMobile>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnManageSubscription_Click(object sender, EventArgs e)
        {
            SubscriptionForm subForm = new SubscriptionForm();

            subForm.SubscribeEvent += SubscribeUser;
            subForm.UnsubscribeEvent += UnsubscribeUser;

            subForm.ShowDialog();
        }

        private void SubscribeUser(string contact)
        {
            if (contact.Contains("@")) // Email subscription
            {
                if (!emailSubscribers.Exists(e => e.Email == contact))
                {
                    emailSubscribers.Add(new SendViaEmail(contact));
                    lstSubscribers.Items.Add("Email: " + contact);
                    lblSubscribers.Text = $"Subscribers: {emailSubscribers.Count + mobileSubscribers.Count}";
                    btnPublishNotification.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Email already subscribed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Mobile subscription
            {
                if (!mobileSubscribers.Exists(m => m.MobileNumber == contact))
                {
                    mobileSubscribers.Add(new SendViaMobile(contact));
                    lstSubscribers.Items.Add("Mobile: " + contact);
                    lblSubscribers.Text = $"Subscribers: {emailSubscribers.Count + mobileSubscribers.Count}";
                    btnPublishNotification.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Mobile number already subscribed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void UnsubscribeUser(string contact)
        {
            if (contact.Contains("@")) // Email unsubscription
            {
                SendViaEmail emailSub = emailSubscribers.Find(e => e.Email == contact);
                if (emailSub != null)
                {
                    emailSubscribers.Remove(emailSub);
                    lstSubscribers.Items.Remove("Email: " + contact);
                    lblSubscribers.Text = $"Subscribers: {emailSubscribers.Count + mobileSubscribers.Count}";
                }
                else
                {
                    MessageBox.Show("Email not found in subscription list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else // Mobile unsubscription
            {
                SendViaMobile mobileSub = mobileSubscribers.Find(m => m.MobileNumber == contact);
                if (mobileSub != null)
                {
                    mobileSubscribers.Remove(mobileSub);
                    lstSubscribers.Items.Remove("Mobile: " + contact);
                    lblSubscribers.Text = $"Subscribers: {emailSubscribers.Count + mobileSubscribers.Count}";
                }
                else
                {
                    MessageBox.Show("Mobile number not found in subscription list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (emailSubscribers.Count == 0 && mobileSubscribers.Count == 0)
            {
                btnPublishNotification.Enabled = false;
            }
        }

        private void btnPublishNotification_Click(object sender, EventArgs e)
        {
            string message = "This is a notification for all subscribers.";

            foreach (var email in emailSubscribers)
            {
                email.SendNotification(message);
            }

            foreach (var mobile in mobileSubscribers)
            {
                mobile.SendNotification(message);
            }
        }
    }
}
