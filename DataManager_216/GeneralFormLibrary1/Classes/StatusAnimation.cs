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

        public StatusAnimation(Form form, StatusStrip statusStrip)
        {
            TargetForm = form;
            TargetStatusStrip = statusStrip;
        }

        private static void AnimatedMessage(MentionStatusDelegate mentionStatus, CancellationToken ct)
        {
            int counter = 0;
            for (int i = 0; i < 300; i++)
            {
                string message = "Requesting Data.";
                if (counter == 1)
                {
                    message = message + ".";
                }
                else if (counter == 2)
                {
                    message = message + "..";
                }
                else if (counter >= 3)
                {
                    counter = -1;
                }
                System.Threading.Thread.Sleep(500);
                mentionStatus(message);

                //Check if canceled
                if (ct.IsCancellationRequested)
                {
                    message = "Request Complete";
                    mentionStatus(message);
                    return;
                }
                counter++;
            }

            return;
        }

        public void Start(CancellationTokenSource tokenSource)
        {
            CancellationToken ct = tokenSource.Token;
            Task t = Task.Run(() =>
            {
                GeneralFormLibrary1.StatusAnimation.AnimatedMessage(StatusUpdate, ct);
            }, tokenSource.Token);
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

            }
        }

    }
}
