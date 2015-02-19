/*
This Javascript will en/decrypt a string using the HTML XOR algorithim
XORCRYPT Version 1.2

This version is much faster because it does not use Base64 encoding.
It is also more difficult to crack, because the key is as long as the
password, and the only way to hack it is to try every possible password.

The latest version has some small bugs cleaned up, reorganized decrypt
sequence and is now crossplatform, crossbrowser compatible, with the
exception of Netscape 2.X. It would be possible to make it compatible
with Netscape 2.X, but I see no point.

For more information on this very simple algorithim email me.

This script was written by:
Evan Jones, 1997
jonesev@home.com
You may use this script any way you wish as long as you email me and let me know.
*/

/* Create the encrypt table */
// The last char in the table is always the escape code
// The table is not quite 128 chars, it is 95 (minus the escape char)
// Values 93-127 must be escaped

var cryptTable=new String(" ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789	!@#$%^&*()`'-=[];,./?_+{}|:<>~");
var cryptLength=new Number(cryptTable.length-1) //93 Chars
var escapeChar=cryptTable.charAt(cryptLength); // The escape code is ~

var lineFeed="\n"; //The linefeed char - escaped to double escapeChar
var doubleQuote='"'; //Double quotes are escaped to ~'
var clearMessage=new Number(5000); //The number of ms to wait to clear the status bar message
 
/* This function uses the key and encrypts a string with the password */
// Encryption strips all linefeeds - but they are replaced upon decrypt
function encrypt(input, password)
{
var inChar, inValue, outValue;

var output="";
var arNumberPw = new Array();

var pwLength=password.length;
var inLength=input.length;

var stopStatus=Math.round(inLength/10);
var statusBar=0;

for (var pwIndex=0; pwIndex<pwLength; pwIndex++)
	{
	arNumberPw[pwIndex]=cryptTable.indexOf(password.charAt(pwIndex));
	}

/* XOR all the chars */
for (var inIndex=0, pwIndex=0; inIndex<inLength; inIndex++, pwIndex++)
	{
	if (pwIndex==pwLength) //Make sure the password index is in range
		{
		pwIndex=0;
		}
	
	/* Get the input */

	inChar=input.charAt(inIndex)
	inValue=cryptTable.indexOf(inChar);

	/* Conversion/Escaping Sequence */
	// If the outValue is in the character map, encode it
		// If the encoded value is outside the character map, escape it
		// Else convert it to a char
	// If the input char is a linefeed, escape it
	// If the input char is a double quote, escape it
	// If the input char wasn't found, pass it through

	if (inValue!=-1)
		{
		outValue=arNumberPw[pwIndex] ^ inValue;
		if (outValue>=cryptLength)
			{
			outValue=escapeChar+cryptTable.charAt(outValue-cryptLength);
			}
		else outValue=cryptTable.charAt(outValue);
		}	
	else if (inChar=="\r")
		{
		outValue=escapeChar+escapeChar;
		if (input.charAt(inIndex+1)=="\n") inIndex++; //If it is a 2 char linefeed skip next one
		}
	else if (inChar=="\n")
		{
		outValue=escapeChar+escapeChar;
		}
	else if (inChar==doubleQuote)
		{
		outValue=escapeChar+"'";
		}
	else
		{
		outValue=inChar;
		}

	output+=outValue; //Output the char

	/* Status bar progress indicator */

	if (inIndex>=statusBar)
		{
		window.status=inIndex+"/"+inLength+" characters decrypted ("+Math.round(inIndex/inLength*100)+"%)";
		statusBar+=stopStatus;
		}
	}

window.status=inLength+"/"+inLength+" characters encrypted (100%)";
setTimeout("window.status=''", clearMessage);

return output;
}


/* This function uses the key and encrypts a string with the password */

function decrypt(input, password)
{
var inChar, inValue, outValue, escape=false;

var output="";
var arNumberPw = new Array();

var pwLength=password.length;
var inLength=input.length;

var stopStatus=Math.round(inLength/10);
var statusBar=0;

for (var pwIndex=0; pwIndex<pwLength; pwIndex++)
	{
	arNumberPw[pwIndex]=cryptTable.indexOf(password.charAt(pwIndex));
	}

/* XOR all the chars */
for (var inIndex=0, pwIndex=0; inIndex<inLength; inIndex++, pwIndex++)
	{
	if (pwIndex>=pwLength) //Make sure the password index is in range
		{
		pwIndex=0;
		}
	
	/* Get the input */
	inChar=input.charAt(inIndex);
	inValue=cryptTable.indexOf(inChar);

	/* Decrypting/Unescaping Sequence */
	// If the input char wasn't found, pass it through (error checking)
	// If the last char was an escapeChar
		//And the input is an escapeChar, output a linefeed
		//Or the input is a single quote, output a double quote
		//Otherwise just add the cryptLength to the inValue
		//Turn escape off
	// If the inValue hasn't been coverted to an outValue yet
		// If the inChar is an escapeChar, turn escape on
		// Otherwise decrypt the encrypted character
	
	if (inValue==-1)
		{
		outValue=inChar;
		}	

	else if (escape)
		{
		if (inValue==cryptLength)
			{
			outValue=lineFeed;
			inValue=-1;
			}
		else if (inChar=="'")
			{
			outValue=doubleQuote;
			inValue=-1;
			}
		else
			{
			inValue+=cryptLength;
			}
		escape=false;
		}
	else if (inValue==cryptLength)
		{
		escape=true;
		pwIndex--; //Stop the password from incrementing
		outValue="";
		inValue=-1;
		}

	if (inValue!=-1)
		{
		outValue=cryptTable.charAt(arNumberPw[pwIndex] ^ inValue);
		}
	
	/* Output */

	output+=outValue;

	/* Status bar progress indicator */

	if (inIndex>=statusBar)
		{
		window.status=inIndex+"/"+inLength+" characters decrypted ("+Math.round(inIndex/inLength*100)+"%)";
		statusBar+=stopStatus;
		}
	}

window.status=inLength+"/"+inLength+" characters decrypted (100%)";
setTimeout("window.status=''", clearMessage);

return output;
}
