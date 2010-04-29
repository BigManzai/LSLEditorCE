// /**
// ********
// *
// * ORIGIONAL CODE BASE IS Copyright (C) 2006-2010 by Alphons van der Heijden
// * The code was donated on 4/28/2010 by Alphons van der Heijden
// * To Brandon'Dimentox Travanti' Husbands & Malcolm J. Kudra which in turn Liscense under the GPLv2.
// * In agreement to Alphons van der Heijden wishes.
// *
// * The community would like to thank Alphons for all of his hard work, blood sweat and tears.
// * Without his work the community would be stuck with crappy editors.
// *
// * The source code in this file ("Source Code") is provided by The LSLEditor Group
// * to you under the terms of the GNU General Public License, version 2.0
// * ("GPL"), unless you have obtained a separate licensing agreement
// * ("Other License"), formally executed by you and The LSLEditor Group.  Terms of
// * the GPL can be found in the gplv2.txt document.
// *
// ********
// * GPLv2 Header
// ********
// * LSLEditor, a External editor for the LSL Language.
// * Copyright (C) 2010 The LSLEditor Group.
// 
// * This program is free software; you can redistribute it and/or
// * modify it under the terms of the GNU General Public License
// * as published by the Free Software Foundation; either version 2
// * of the License, or (at your option) any later version.
// *
// * This program is distributed in the hope that it will be useful,
// * but WITHOUT ANY WARRANTY; without even the implied warranty of
// * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// * GNU General Public License for more details.
// *
// * You should have received a copy of the GNU General Public License
// * along with this program; if not, write to the Free Software
// * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// ********
// *
// * The above copyright notice and this permission notice shall be included in all 
// * copies or substantial portions of the Software.
// *
// ********
// */
using System;
using System.Windows.Forms;

namespace LSLEditor
{
	public partial class GotoWindow : Form
	{
		private LSLEditorForm lslEditForm;
		public GotoWindow(LSLEditorForm lslEditForm)
		{
			InitializeComponent();
			this.Icon = lslEditForm.Icon;
			this.lslEditForm = lslEditForm;

			EditForm editForm = this.lslEditForm.ActiveMdiForm as EditForm;
			this.label1.Text = "Line number (1-"+editForm.TextBox.Lines.Length+")";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Goto()
		{
			EditForm editForm = this.lslEditForm.ActiveMdiForm as EditForm;
			if (editForm == null)
				return;
			try
			{
				int intLine = Convert.ToInt32(this.textBox1.Text);
				editForm.TextBox.Goto(intLine);
				this.Close();
			}
			catch
			{
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Goto();
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				Goto();
				e.SuppressKeyPress = true;
			}

		}
	}
}