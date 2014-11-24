using System;
using System.IO;
using Gtk;
using GtkUtil;

public partial class MainWindow: Gtk.Window
{	
	public const int ID3TagLength = 128;
	public const string ID3TagMark = "TAG";
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	public void ReadMp3TagFromFile(string path)
	{
		var buffer = new char[ ID3TagLength ];
			
		// Open file
		using ( var binReader = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
			// Take last 128 bytes in
			binReader.BaseStream.Seek( -ID3TagLength, SeekOrigin.End );
			int bytesRead = binReader.Read( buffer, 0, ID3TagLength );
			
			if ( bytesRead == ID3TagLength ) {
				string tagMark = new string( buffer, 0, 3 );
				
				if ( tagMark == ID3TagMark ) {
					// Read the ID3 tag data
					edTitle.Text = ( new string( buffer, 3, 30 ) ).Trim();
					edAuthor.Text = ( new string( buffer, 33, 30 ) ).Trim();
					edAlbum.Text = ( new string( buffer, 63, 30 ) ).Trim();
					edYear.Text =  ( new string( buffer, 93, 4 ) ).Trim();
				}
			}
		}

		return;
	}

	protected void OnQuit(object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	protected void OnOpen(object sender, System.EventArgs e)
	{
		string fileName = "";
		
		if ( Util.DlgOpen( "Mp3Tiv", "Open", this, ref fileName, "*.mp3" ) ) {
			this.ReadMp3TagFromFile( fileName );
		}
	}
}
