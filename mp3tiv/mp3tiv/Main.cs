using System;
using Gtk;

namespace mp3tiv
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
