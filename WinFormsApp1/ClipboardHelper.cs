using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipboardCycle
{
    public class ClipboardMessageFilter : IMessageFilter
    {
        private const int WM_CLIPBOARDUPDATE = 0x031D;

        public event EventHandler ClipboardUpdate;

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                ClipboardUpdate?.Invoke(this, EventArgs.Empty);
            }
            return false;
        }
    }
}
