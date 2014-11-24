using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
	
	/// <summary>
	/// Quits the application
	/// </summary>
	protected void OnQuit(object sender, System.EventArgs e)
	{
		Application.Quit();
	}
	
	/// <summary>
	/// Calculates the result
	/// </summary>
	protected void OnOperate(object sender, System.EventArgs e)
 {
		double op1;
		double op2;
		double result;
		
		// Convert op1
		try {
			op1 = Convert.ToDouble( this.edOp1.Text );
		} catch(Exception) {
 
			op1 = 0.0;
		}
		
		// Convert op2
		try {
			op2 = Convert.ToDouble( this.edOp2.Text );
		} catch(Exception) {
 
			op2 = 0.0;
		}

        try {
    		// Operate
    		switch(  cbOpr.ActiveText[ 0 ] ) {
    		case '+':
    			result = op1 + op2;
    			break;
    		case '-':
    			result = op1 - op2;
    			break;
    		case '*':
    			result = op1 * op2;
    			break;
    		case '/':
    			result = op1 / op2;
    			break;
    		default:
                result = 0.0;
                break;
    		}
        } catch(Exception) {
            result = 0.0;
        }

		
		// Show result
		this.edResult.Text = Convert.ToString( result );
	}
	
	/// <summary>
	/// When the operand changes, trigger a recalculation.
	/// </summary>
	protected void OnOpChanged(object sender, System.EventArgs e)
	{
		this.OnOperate( null, null );
	}
}
