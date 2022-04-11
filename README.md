# PokeDexter

This standalone app returns some Pokemon lookup data.

![](PokeDexter_AltDescription.gif)

### How To Use
1. On a Windows machine, [download the latest build](https://github.com/AntSkilton/PokeDexter/releases/download/v0.2/PokeDexter.Release.0.2.7z), and unzip it. You may need 7Zip to unzip it.
2. Run `PokeDexterApp.exe`. If UAC pops up, select "More Info" and then "Run Anyway".
3. Enter any Pokemon name or it's number in the search bar to find some information about it.
---
There is search validation, and there's an easter egg if you fail a valid input on the first try.

The alternative description processes the description into either a Shakespeare or Yoda translation via the Fun Translations API. There are only 5 free requests per hour, so error handling is in place for when too many requests are made.

If this was a for a production project, I would consider a different frontend implementation such as Blazor which doesn't require the user to download a new client everytime new client changes are made.
