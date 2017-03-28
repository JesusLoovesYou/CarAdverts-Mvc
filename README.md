# CarAdverts-Mvc

The Project consist DataLayer, ServiceLayer and MVC-ClientLayer.

	Data layer works with EitityFramework ORM. There is EFGenerik and EfdDletable Repositories. 
There is EfDataProvider that can generate instance of any repository and provide it to the services
and controllers if is nessesery.

	Service layer has Advert, File, VehicleModel, Manufacturer  and City services. They consist all busines
logic that is nessesery for controllers.

	MVC-ClientLayer has public part, private part and administrative part.
In the pusblic part users can search for some types of adverts, with many parameters.
They can see list of adverts, and detail advert, with its properties and Photos.

	The private part has all these functionalities maintanace with functionality for createing new adverts, and
adding multiple files jpf/png format to them.

	The admin part maintanace these functinalities with AJAX create, delete, update and list functinalities.
	
Project use only Razor template engine for generating the UI. There also used jQuery and AJAX.
ASP.NET WebForms is not allowed.
Are used sections and partial views - for wrapping carusel logic, and some navbar logic.
Are used also editor and display templates.

Theer is thwo areas Administrator area and User area.
There is tables, paging and searhing. 

The application has beautiful and responive UI. Is used Bootstrap and many custom styles.

For managing users and roles is used ASP.NET Identity System.

CreateAdvert page is cachedhed.

There is error handling and data validation to avoid crashes when invalid data is entered.
The app is prevented for XSS snd XSRF atacs.

Thee all layers have Unit Tests. Is used Dependency Iversion priciple and Dependency Injection technique.

Unit tests are configured to run in Jenkins - Continuous Integration server. And the application is hosted
in Azure hosting provider. Jenkins has settings for deploing in Azure after Bilding.