//---------------------------------------------------------------------------
// FILE NAME: mainwindow.xaml.cs
// DATE:      Sunday, February 4, 2018   9 am
// WEATHER:   Fair, Temp 57°F, Pressure 30.14",
//            Humidity 74%, Wind calm
// Programmer's Cuvee XLIV
// Copyright (C) 2018 William E. Blum.  All rights reserved.
//---------------------------------------------------------------------------

using System;
using System.Windows;

namespace Utf16Conv
{
	public partial class MainWindow : Window
	{
		private readonly FileListViewModel vm = new FileListViewModel();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = vm;
		}

		private void ChooseDirectory_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				string directoryPath = UserPath.GetDirectory();
				if (directoryPath == null)
					return;
				vm.Load(directoryPath);
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
	}
}