//---------------------------------------------------------------------------
// FILE NAME: UserPath.cs
// DATE:      Sunday, February 4, 2018   11 am
// WEATHER:   Fair, Temp 63°F, Pressure 30.15",
//            Humidity 63%, Wind calm
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System.Windows.Forms;
using Utf16Conv.Properties;

namespace Utf16Conv
{
	internal static class UserPath
	{
		public static string GetDirectory()
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
			{
				dialog.Description = Resources.DirectoryPrompt;
				var result = dialog.ShowDialog();
				return result == DialogResult.OK ? dialog.SelectedPath : null;
			}
		}
	}
}