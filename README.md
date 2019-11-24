# Overview

This project is a restart of a project that I worked on over Christmas break of this past year. I decided to restart it in order to make the code cleaner, and redo the process.

# Documentation
The project is set up to use Dependency Injection. I am using the Unity Framework, which allows for easy integration. Along with DI, I also use a Factory Pattern to provide the various components of the bot, such as the Discord Client and Discord Web Socket.

The directory 'Providers,' contains all of the Factory classes. They provide the things necessary for the bot to work correctly. Each class returns a single object via a static Method 'GetDefault().' These, along with the Unity class, are hopefully going to be the only static classes in the entire project.

All of the code lies within the DiscordLibrary project.
# Overview of various classes
## Handler Classes
### CommandHandler
This class checks to see if a message sent in a given Discord channel is prefixed by the command prefix, in this case "!." If it is, the CommandHandler will create a command context, which is responsible for acting upon the command that was sent through.

## DiscordEventHandler
This class is for handling all the Discord events, such as messages being received, users joining the server, and other things of that nature.

