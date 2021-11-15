# Lab-9

DLL used here is extension to DLL was presented in 3rd lecture. DLL was used to save both object's position and color. Also the object's color can be changed to random colors with DLL.
The character is moving with WASD and Space.

## SavePosition() and SaveColor()
These are the main functions which handle the saving process. They open and create a file and store data into it.

Using for loop in Start() (plugin.cs), we go through the entire string and split it to numbers and convert them to float using float.parse(). Because Color and Vector3 can only take int and float variables.
