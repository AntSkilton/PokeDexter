# PokeDexter

This standalone app returns some Pokemon lookup data.

![](PokeDexter_AltDescription.gif)

### How To Run
1. On a Windows machine, [download the latest build](https://github.com/AntSkilton/PokeDexter/releases/download/release/PokeDexter_Release_0.1.7z), and unzip it. You may need 7Zip to unzip it.
2. Run `PokeDexterApp.exe`. If UAC pops up, select "More Info" and then "Run Anyway".
3. Enter any Pokemon name or it's number in the search bar to find some information about it.
---

### How To Open The Project
1. Open `PokeDexter.sln` in your preferred IDE such as Rider.
2. External packages will be missing which you'll need to get via NuGet. `Alt + Shift + N` to bring up the menu, then `NuGet Force Restore` should retrieve key packages such as Asp.Net WebApi Client PokeApiNet, Newtonsoft JSON and other dependencies.
3. You'll find the business logic in the `PokeDexterLibrary` project, and the WPF built frontend  available in the `PokeDexterFrontend` project. 

---
These is search validation, and there's an easter egg if you fail an input on the first try. Hint: It returns a specific Pokemon.

The alternative description processes the description into either a Shakespeare or Yoda translation via the Fun Translations API. There are only 5 free requests per hour, so frontend error handling is in place for when too many requests are made.

If this was a for a production project, I would consider a different frontend implementation such as Blazor which doesn't require the user to download a new client everytime new client changes are made.