//---------------------------------------------------------------------------
// FILE NAME: FileViewModel.cs
// DATE:      Sunday, February 4, 2018   11 am
// WEATHER:   Fair, Temp 66°F, Pressure 30.14",
//            Humidity 61%, Wind 3.5 mph from the West
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Utf16Conv.Annotations;
// ReSharper disable UnusedMember.Global

namespace Utf16Conv
{
	public class FileViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private string fileName;
		private string encoding;

		public string FileName
		{
			get => fileName;
			set
			{
				if (Equals(fileName, value)) return;
				fileName = value;
				OnPropertyChanged();
			}
		}

		public string Encoding
		{
			get => encoding;
			set
			{
				if (Equals(encoding, value)) return;
				encoding = value;
				OnPropertyChanged();
			}
		}

		public string FullPath { get; set; }

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}