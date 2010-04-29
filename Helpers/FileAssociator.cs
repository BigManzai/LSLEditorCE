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
using System.Text;
using Microsoft.Win32;


namespace LSLEditor.Helpers
{
	class FileAssociator
	{
		// Associate file extension with progID, description, icon and application
		public static bool Associate(string strExtension, string strFileNameType, string strDescription, string strApplication,int intIconNr)
		{
			try
			{
				Registry.ClassesRoot.CreateSubKey(strExtension).SetValue("", strFileNameType);
				if (strFileNameType != null && strFileNameType.Length > 0)
				{
					using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(strFileNameType))
					{
						if (strDescription != null)
							key.SetValue("", strDescription);
						if (strApplication != null)
						{
							key.CreateSubKey("DefaultIcon").SetValue("", strApplication + "," + intIconNr);
							key.CreateSubKey(@"Shell\Open\Command").SetValue("", "\"" + strApplication + "\" \"%1\"");
						}
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool DeAssociate(string strExtension, string strFileNameType)
		{
			try
			{
				Registry.ClassesRoot.DeleteSubKey(strExtension);
				Registry.ClassesRoot.DeleteSubKeyTree(strFileNameType);
				return true;
			}
			catch
			{
				return false;
			}
		}

		// Return true if extension already associated in registry
		public static bool IsAssociated(string strExtension)
		{
			try
			{
				return (Registry.ClassesRoot.OpenSubKey(strExtension, false) != null);
			}
			catch
			{
				return false;
			}
		}

		private void Test()
		{
			if (!IsAssociated(".lsl"))
				Associate(".lsl", "LSLEditorScript", "SecondLife lsl File for LSLEditor", System.Reflection.Assembly.GetExecutingAssembly().Location, 0);
			DeAssociate(".lsl", "LSLEditorScript");
		}

	}
}