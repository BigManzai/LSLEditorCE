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
// * ("Other License"), formally executed by you and Linden Lab.  Terms of
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
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace LSLEditor
{
	public partial class GListBox : ListBox
	{
		public ImageList ImageList;

		public GListBox(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			// Set owner draw mode
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ImageList = new ImageList();
		}

		public GListBox()
		{
			InitializeComponent();

			// Set owner draw mode
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ImageList = new ImageList();
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			try
			{
				GListBoxItem item;
				Rectangle bounds = new Rectangle(e.Bounds.X + e.Bounds.Height, e.Bounds.Y, e.Bounds.Width - e.Bounds.Height - 1, e.Bounds.Height);
				item = (GListBoxItem)Items[e.Index];
				if (item.ImageIndex != -1)
				{
					e.Graphics.FillRectangle(new SolidBrush(this.BackColor), bounds);
					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
						e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);

					e.Graphics.DrawImage(ImageList.Images[item.ImageIndex], bounds.Left - bounds.Height, bounds.Top, bounds.Height, bounds.Height);
					e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor),
						bounds.Left, bounds.Top);
				}
				else
				{
					e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor),
						bounds.Left, bounds.Top);
				}
			}
			catch
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				if (e.Index != -1)
				{
					try
					{
						e.Graphics.DrawString(Items[e.Index].ToString(), e.Font,
							new SolidBrush(e.ForeColor), e.Bounds.Left, e.Bounds.Top);
					}
					catch
					{
					}
				}
				else
				{
					e.Graphics.DrawString(Text, e.Font, new SolidBrush(e.ForeColor),
						e.Bounds.Left, e.Bounds.Top);
				}
			}
			base.OnDrawItem(e);
		}
	}//End of GListBox class

	// GListBoxItem class 
	public class GListBoxItem
	{
		private string _myText;
		private int _myImageIndex;
		// properties 
		public string Text
		{
			get { return _myText; }
			set { _myText = value; }
		}
		public int ImageIndex
		{
			get { return _myImageIndex; }
			set { _myImageIndex = value; }
		}
		//constructor
		public GListBoxItem(string text, int index)
		{
			_myText = text;
			_myImageIndex = index;
		}
		public GListBoxItem(string text) : this(text, -1) { }
		public GListBoxItem() : this("") { }
		public override string ToString()
		{
			return _myText;
		}
	}//End of GListBoxItem class
}