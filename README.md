# ProjectVegas
A project to make a game player controller but there are so many out there now and they come with unity but this my idea on how to code it, this is a working sample of a player walking in a city

I worked on games in Unity for about wow 9 years now I wont put much on here I try to stay away from unity I love it but I got into some real nightmares with it most of my stuff is under a NDA so you will never see it on git

My Design 
Its not really the player controller that's important here its how its all set up it I might make some better samples of the way we got out self's out of a lot of hell working on beg games with big teams and remote workers from around the world.

Notice the game has no cameras I instantiate each prefab screen from Resources this is a grate way to do it because it loads fast and its good on memory you can even load the resources from a server and dynamically load them with updates and not even have up update your app in the market.
Not having to upload your app in the market can be really grate for you.

One other thing is, I always try to not use variables in unitys editor and [HideInInspector] dragging your objects into the UI means things can get broken later on and you may forget where everything gos
so use GameObject.Find() and Resources.Load() are grate to use, Unity does not show you this but they want you get get used to the product and how easy it is to use but when your working on huge projects in big teams with git and servers and some people have pro and some not you can wind up in hell at work on a broken project trying to put it back together.. could be impossible! So Unity Editor is not you friend Unity is a grate project I love it but a few times we wish we just did it all in native code the troubles that you can face can be a deal breaker.    
