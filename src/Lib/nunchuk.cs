/*
 * nunchuk.cs - Library to control 'Wii nunchuk' on system
 * Qwerty Games - 2017-05-24
 * Bruno Mondelo Giaramita
 * This library is under the 'GNU GENERAL PUBLIC LICENSE'
 * You should receive a copy of it with this code
*/

using System;
using System.Windows.Forms; // Send keys to the system


// The object
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

// The object keys
internal class NunchukKey {
	
	/*
	 * NunchukKey defines one key of the nunchuk
	 *
	 * Constructor:
	 *  NunchukKey (string, float, float)
	 *  NunchukKey (string)
	 *
	 * Methods:
	 *  int ReceiveValue (float) : Proves a value and sends the
		 value to the system
	 *  bool SendSystemChar () : Sends the key value to the system
	*/
	
	// The string to send to the system when this key is used
	string SystemChar;
	
	// Special button
	bool IsButton;
	
	// The lower sensibility to activate
	float MinSensibility;
	
	// The higher senibylity to activate
	float MaxSensibility;
	
	// Basic constructor
	public NunchukKey (string systemChar, float minSensibility,
		float maxSensibility) {
		
		/*
		 * Basic constructor for a nunchuk key
		 * Input: char, float, float
		 * Output: None
		*/
		
		SystemChar = systemChar;
		MinSensibility = minSensibility;
		MaxSensibility = maxSensibility;
		IsButton = false;
		
	}
	
	// Button constructor
	public NunchukKey (string systemChar) {
		
		/*
		 * Button constructor for a nunchuk key
		 * Input: char
		 * Output: None
		*/
		
		SystemChar = systemChar;
		IsButton = true;
		
	}
	
	// Received value checker
	public int ReceiveValue (float value) {
		
		/*
		 * Checks a received value and proves if it must send
		 * the key to the system
		 * Input: float
		 * Output: 0 - Key sent
				   1 - Key not sent
				  -1 - Error sending key
		*/
		
		// The method return status
		int status = 1;
		
		// A button key only checks if the value is
		// 1 - Send, 0 - Don't send
		// A normal key must check the sensibility
		if (IsButton)
			if (value == 1f)
				status = 0;
		else {
			if (value >= MaxSensibility || value <= MinSensibility)
				status = 0;
		}
		
		// Call the method to send the key to the system
		if (status == 0)
			if (! SendSystemChar())
				status = -1;
		
		return status;
		
	}
	
	// The system sender
	private bool SendSystemChar () {
		
		/*
		 * Sends the key string to the system
		 * Input: None
		 * Output: bool
		*/
		
		// The status of the function
		bool status = true;
		
		// Send the keys to the system
		// If that fails change the exit code
		// to false
		try {
			SendKeys.Send(SystemChar);
		}
		catch {
			status = false;
		}
		
		return status;
		
	}
	
}
