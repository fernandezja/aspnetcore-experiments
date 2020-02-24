# aspnetcore-experiments
Code Kata with ASP.NET Core (practicing, exploring, experimenting, testing and playing)



| Example 	| Description 	|
|-----	|-------	|
|[ViewLocationExpander](https://github.com/fernandezja/aspnetcore-experiments/tree/master/src/ViewLocationExpander) | Add multiple location for our views. Add locations to the razor engine to search the views (views, components, etc.) using / expanding the folders where the resource is searched. Simple example of the [IViewLocationExpander](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.razor.iviewlocationexpander)interface by adding one or more new search paths.      	|
|[ViewAddPhysicalExternalFolder](https://github.com/fernandezja/aspnetcore-experiments/tree/master/src/ViewAddPhysicalExternalFolder)     	|Add physical folders (outside the assembly execute folder) where the razor view engine can search (views, components, etc). Using [MvcRazorRuntimeCompilationOptions ](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.1) add FileProviders of the type PhysicalFileProvider        	|