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

namespace LSLEditor.Helpers
{
	class Measure
	{
		public static RectangleF MeasureDisplayString(System.Windows.Forms.Control control, string text, Font font)
		{
			Graphics graphics = control.CreateGraphics();
			RectangleF rect = MeasureDisplayString(graphics, text, font);
			graphics.Dispose();
			return rect;
		}

		public static RectangleF MeasureDisplayString(Graphics graphics, string text, Font font)
		{
			StringFormat format = new StringFormat();
			RectangleF rect = new RectangleF(0, 0, 4096, 4096);
			CharacterRange[] ranges = { new CharacterRange(0, text.Length) };
			Region[] regions = new Region[1];
			format.SetMeasurableCharacterRanges(ranges);
			regions = graphics.MeasureCharacterRanges(text, font, rect, format);
			return regions[0].GetBounds(graphics);
		}
	}
}