# WPF BarcodeSimulator
BarcodeSimulator is a little tool that mimics the input of a ... barcodescanner.
This tool allows you to create a "playlist" of barcodes that will be simulated. This can be an enormous help when testing software.

BarcodeSimulator uses
* 1. NHotKey: to allow use of a global hotkey to initiate the barcode input even when another app. has focus
* 2. WindowsInput: to simulate keyboard input
* 3. Caliburn.Micro
* 4. Ninject

NHotKey and WindowsInput are the stars here. I just hacked them together to create a workable application.

# Usage
- Add a barcode e.g. 00325
- Add another barcode e.g. 00326
- Go to the receiving application (or you know... notepad to test)
- press **Shift + Insert**
- the barcodes are now being simulated..

If you wish to reuse sequences you can enter them and press **save**. Select a location and enter a name.

Next time you can recall the sequence by pressing **load** and picking the previously selected file.

The sequences are just lines in a .txt so you could by all means insert these barcodes straight into the file and then load them from the app.

Hope it's a help to someone! 
