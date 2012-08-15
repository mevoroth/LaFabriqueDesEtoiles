using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Launcher.info;
using System.Net;
using System.Diagnostics;

namespace Launcher
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnquitter_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Voulez-vous quitter ?",
				"Quitter",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2,
				MessageBoxOptions.DefaultDesktopOnly,
				false) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void btnjouer_Click(object sender, EventArgs e)
		{
			String pseudo = this.txtpseudo.Text;
			String server = this.txtserver.Text;
			IPAddress address;
			String port = this.txtport.Text;
			UInt16 p = 0;
			bool error = false;
			if (String.IsNullOrEmpty(server)
				|| !IPAddress.TryParse(server, out address))
			{
				error = true;
			}
			if (String.IsNullOrEmpty(port)
				|| !UInt16.TryParse(port, out p))
			{
				error = true;
			}
			if (!error)
			{
				ProcessStartInfo psi = new ProcessStartInfo("..\\..\\..\\Starcraft\\Starcraft\\bin\\x86\\Debug\\StarcraftClient.exe", pseudo+" "+server+" "+port);
				Process.Start(psi);
			}
		}
	}
}
