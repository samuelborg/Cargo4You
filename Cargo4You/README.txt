NOTES AND INSTRUCTIONS
===========================================================================================================================

Solution was developed and tested on Visual Studio Enterprise 2015 and web browser Google Chrome (v 50 BETA)

Please take not of the following files:
	Models/Packages.cs
	Controllers/PackagesController.cs
	all View files in Views/Packages (especially new view CheckOut)

Migrations were done in development of this project. If preview returns errors because of the database context, do the following:
	1 Go to Tools > NuGet Package Manager > Package Manager Console
	2 On the console, enable migration (type 'Enable-Migration')
	3 Also on the console, update the database (type 'Update-Database'

The web application was developed using Bootstrap and huge modifications to the theme Lumen (compare project to Lumen demo here: https://bootswatch.com/lumen/)

Note the method for calculating the prices of dimenions and weight is calculatePrices() and is at the end of PackagesController.cs (line 146 - 190)
It is called in the controller in the ActionResult methods, Create and Edit, before the model data is saved.

Thank you for your time.
Samuel Borg
