//---------------------------------------------------------------------------
// FILE NAME: Transcoder.cs
// DATE:      Sunday, February 4, 2018   7 pm
// WEATHER:   Fair, Temp 62°F, Pressure 30.07",
//            Humidity 50%, Wind calm
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System.IO;
using System.Text;

namespace Utf16Conv
{
	internal static class Transcoder
	{
		private static void Translate(string inPath, string outPath)
		{
			Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
			using (TextWriter w = new StreamWriter(outPath, append: false, encoding: encoding))
			using (TextReader r = File.OpenText(inPath))
			{
				string line;
				while ((line = r.ReadLine()) != null)
					w.WriteLine(line);
			}
		}

		public static void Translate(string inPath)
		{
			string tempFileName = null;

			try
			{
				tempFileName = Path.GetTempFileName();
				Translate(inPath, tempFileName);
				File.Replace(tempFileName, inPath, inPath + ".BAK");
			}
			finally
			{
				if (tempFileName != null)
					File.Delete(tempFileName);
			}
		}
	}
}