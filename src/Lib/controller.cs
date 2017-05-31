/*
 * controller.cs - Library to control 'Wii nunchuk' controller
 * Qwerty Games - 2017-05-31
 * Bruno Mondelo Giaramita
 * This library is under the 'GNU GENERAL PUBLIC LICENSE'
 * You should receive a copy of it with this code
*/

using System;


namespace Nunchuk {
	
	internal class Nunchuk {
	
		/*
		 * Nunchuk defines the main program object to control
		 * the nunchuk on the system
		 * 
		 * Constructors:
		 *
		*/
		
		// Joy-stick keys
		NunchukKey JoyStickUp;
		NunchukKey JoyStickDown;
		NunchukKey JoyStickRight;
		NunchukKey JoyStickLeft;
		
		// Buttons keys
		NunchukKey CButton;
		NunchukKey ZButton;
	
	}

}
