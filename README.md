#AureliaDotNetCoreOnAzure

Aurelia frontend, ASP.NET Core backend hosted on Azure (host is not active anymore)

Backstory: Customer with an art business was not able to update the contents of his website, due to lack of technical skill.

Customer had basic computer skills, working with word, folders and files within windows.

My idea, make a backend that filtered out content from its filesystem, eliminating the requirement to learn a CMS.

Give client access to server through Filezilla or any other FTP client.

Workflow would be as follows: 
  1. Create a folder, give it the name of the artist.
  2. Put all the images for that artist in the folder.
  3. Put a txt file with the CV/resume in the folder (formatting will be kept and appears on the site).
    4. (Optionals):
    Name an image "Front" and that one will appear on the landingpage/frontpage (defaults to first img in alphabetical order).
    Name an image "Profile" and it will appear above the CV on the artists details page (a picture of the actual artist).
    
Finally: Move all the folders onto the server. 

If an old artists had to be removed just take them off the server, a new collection to be displayed replace the images etc.
