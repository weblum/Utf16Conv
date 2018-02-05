//---------------------------------------------------------------------------
// FILE NAME: FileListViewModel.cs
// DATE:      Sunday, February 4, 2018   11 am
// WEATHER:   Fair, Temp 66°F, Pressure 30.14",
//            Humidity 61%, Wind 3.5 mph from the West
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.IO;
using AutoIt.Common;

namespace Utf16Conv
{
	internal class FileListViewModel : ObservableCollection<FileViewModel>
	{
		private const SearchOption Top = SearchOption.TopDirectoryOnly;

		public void Load(string directoryPath)
		{
			Clear();
			string[] files = Directory.GetFiles(directoryPath, "*.*", Top);
			TextEncodingDetect detector = new TextEncodingDetect();

			foreach (string file in files)
			{
				byte[] buffer = File.ReadAllBytes(file);
				var encoding = detector.DetectEncoding(buffer, buffer.Length);
				FileViewModel fileVm = new FileViewModel
				{
					FileName = Path.GetFileName(file),
					Encoding = encoding.ToString(),
					FullPath = file
				};
				Add(fileVm);
			}
		}
	}
}