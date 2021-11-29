using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Windows;

namespace GeneralFormLibrary1
{
    public class StatusAnimation
    {
        public delegate void MentionStatusDelegate(string statusMessage);
        private delegate void InvokeDelegate();

        private Form TargetForm {get; set;}
        private StatusStrip TargetStatusStrip { get; set; }
        private CancellationTokenSource TokenSource { get; set; }

        public StatusAnimation(Form form, StatusStrip statusStrip, CancellationTokenSource tokenSource)
        {
            TargetForm = form;
            TargetStatusStrip = statusStrip;
            TokenSource = tokenSource;
        }

        private void AnimatedMessage(MentionStatusDelegate mentionStatus)
        {
            int counter = 0;
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < 300; i++)
            {
                message.Clear();
                message.Append("Requesting Data.");
                if (counter == 1)
                {
                    message.Append(".");
                }
                else if (counter == 2)
                {
                    message.Append("..");
                }
                else if (counter >= 3)
                {
                    counter = -1;
                }
                System.Threading.Thread.Sleep(500);
                mentionStatus(message.ToString());

                //Check if canceled
                if (TokenSource.IsCancellationRequested)
                {
                    message.Clear();
                    message.Append("Request Complete");
                    mentionStatus(message.ToString());
                    return;
                }
                counter++;
            }

            return;
        }

        public void Start()
        {
            CancellationToken ct = TokenSource.Token;
            Task t = Task.Run(() =>
            {
                AnimatedMessage(StatusUpdate);
            }, TokenSource.Token);
        }

        public void Cancel()
        {
            TokenSource.Cancel();
        }

        private void StatusUpdate(string status)
        {
            try
            {
                TargetForm.BeginInvoke(new InvokeDelegate(() =>
                {
                    TargetStatusStrip.Items.Clear();
                    ToolStripItem item = TargetStatusStrip.Items.Add(status);
                    item.BackColor = Color.Transparent;
                    item.ForeColor = Color.Black;
                    TargetForm.Refresh();
                }));
            }
            catch
            {
                TokenSource.Cancel();
            }
        }

    }
}
