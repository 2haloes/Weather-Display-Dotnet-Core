# Weather-Display-Dotnet-Core
Cross platform weather display built using dotnet core and AvaloniaUI

## Minimum requirements 
### OS 
*Any OS that can install dotnet core

### Screen Resolution
* 800x480 (any multiple of this or a 16:9  window size recommended)

### Other requirements
* Internet connection


## Features  
* See the current weather easily
* 5 day forecast 
* Usable anywhere for any location
* Supports SI (°C) and US (°F) units
* Works fullscreen for embedded devices
* Content expands with the window size while retaining image and text quality (Tested up to 1080P)
* Easy to configure settings
* Easy to modify to suit your needs using Visual Studio (Windows/Mac) or Avalonia Studio (Any dotnet core supporting OS)

## Why make this?

3 years ago, I had the idea to make something nice for my parents, the idea was a small device that could show you the weather, the current tempreture and a short summery, I couldn't find one so I made my own. This, running on a localhost ASP.NET server rendering in Chromium on a Raspberry Pi became the first version of the program. Since then, it has gone though 5 major versions each successive version and technology used was made to fix issues that the previous version made it hard or impossible to overcome.

The previous versions are as follows:
* ASP.NET The first version, showing the current weather, the time and a short summery of what was to come
* ASP.NET revised, added daily weather display which has been part of the layout since
* Winforms, cut the power needed to run the program as running a eletron type program on a RPi made the program slow
* Python 3, Winforms had issues crashing but I didn't (and admittedly still don't) know a lot about using Python
* AvaloniaUI, this version, adds a settings menu and allows for scaling the window up (not done before), being cross platform in a language I know better is a big help in allowing me to maintain and keep the program working if anything breaks

As I have gotten so used to using my own weather display, I have kept it up to date with the best cross platform devlopments I can find


# Credits
* JSON.NET for JSON handling
* NetCore.Encrypt for making encryption much easier
* Prisem.Core for making MVVM code easier to create
* AvaloniaUI for making a dotnet core program a possible option
* DarkSky for making the API that this program runs on
* Icons made by <a href="https://www.flaticon.com/authors/rns" title="RNS">RNS</a> from <a href="https://www.flaticon.com/" 		    title="Flaticon">www.flaticon.com</a> is licensed by <a href="http://creativecommons.org/licenses/by/3.0/" 		    title="Creative Commons BY 3.0" target="_blank">CC 3.0 BY</a>
