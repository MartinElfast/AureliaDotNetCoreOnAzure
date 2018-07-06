# AureliaDotNetCoreOnAzure

## Aurelia frontend, ASP.NET Core backend hosted on Azure (host is not active anymore)

Backstory: Customer with an art business was not able to update the contents of his website, due to lack of technical skill.

Client had basic computer skills, working with word, folders and files within windows.

My proposal: Build a CMS that filtered out content from its filesystem, client will only have to upload content to the server.

Client access the server through Filezilla or any other FTP client.

Workflow would be as follows: 
  1. Create a folder, give it the name of the artist.
  2. Put all the images for that artist in the folder.
  3. Put a txt file with the CV/resume in the folder (formatting will be kept and appears on the site).
    4. (Optionals);   
    Name an image "Front" and that one will appear on the landingpage (defaults to first img in alphabetical order).  
    Name an image "Profile" and it will appear above the CV on the artists details page (a picture of the actual artist).
    
Finally: Move all the folders onto the server with FTP application of choice.

### Points of interest to reader

I designed the backend in the classic MVC pattern for the API and a Repository pattern for the server side content management leveraged trough the .NET Core DI system, to keep it loosley coupled for future updates and be host and content service agnostic.

<a href="https://github.com/MartinElfast/AureliaDotNetCoreOnAzure/blob/master/src/skeleton/Startup.cs">Application entry point, Dependecy Injection registration etc.</a> for the development version / branch.

<a href="https://github.com/MartinElfast/AureliaDotNetCoreOnAzure/blob/master/src/skeleton/Data/Assetmapper.cs">Backend service content sorting algorithm</a>: Injected as an loosley coupled service through the .NET Core IoC system, its invoked as a Scoped service which means it will refresh each request, this is to satisfy the requirement of minimal content management, if new content is added to the server it will be live on the webpage right away.

The frontend is written in mostly TypeScript using the Aurelia framework, the design was supplied by the customer, this is the development branch and content will differ from the live version.

Performance:
With debugging with development build settings this service ran on the smallest Azure service (250MB RAM), and still had plenty memory to spare. I ran performance tests with more content then the production version, 4 concurrent users refreshing the webpage every 2 seconds and had a full response time cycle of less than 50ms (excluding rendering time for the browser, which varied on different devices) and a memory footpront of less than 25MB RAM usage at peak, this basically scaled linearly with increased concurrent requests.
