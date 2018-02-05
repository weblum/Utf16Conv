//---------------------------------------------------------------------------
// FILE NAME: mainwindow.xaml.cs
// DATE:      Sunday, February 4, 2018   9 am
// WEATHER:   Fair, Temp 57°F, Pressure 30.14",
//            Humidity 74%, Wind calm
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Utf16Conv.Annotations;
// ReSharper disable MemberCanBePrivate.Global

namespace Utf16Conv
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private string directoryPath;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
		}

		public FileListViewModel Vm { get; } = new FileListViewModel();

		public string DirectoryPath
		{
			get => directoryPath;
			private set
			{
				if (Equals(directoryPath, value)) return;
				directoryPath = value;
				OnPropertyChanged();
			}
		}

		private void ChooseDirectory_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				DirectoryPath = UserPath.GetDirectory();
				if (DirectoryPath == null)
					return;
				Vm.Load(DirectoryPath);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, Title);
			}
		}

		private void ConvertFiles_OnClick(object sender, RoutedEventArgs e)
		{
			IList items = DataGrid1.SelectedItems;

			try
			{
				foreach (FileViewModel fvm in items)
					Transcoder.Translate(fvm.FullPath);
				Vm.Load(DirectoryPath);
			}
			catch (Exception x)
			{
				MessageBox.Show(x.Message, Title);
			}
		}

		private void Exit_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		private void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}