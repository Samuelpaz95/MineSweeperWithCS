# MineSweeperWithCS

This is an implementation of the minesweeper with c # using ASP.NET to make a webapp.

The backend is controlled by an API from the FrontEnd.

## Implementation

We have the backend inside the gameSrc folder where the minesweeper game works, within this directory we have the following classes:

- Item.cs
- Clue.cs
- Mine.cs
- Terrain.cs
- TerrainPart.cs
- Player.cs
- Game.cs

These classes compose the logical operation of the game.

We also have the Models directory with the classes:

- GameState.cs
- Movement.cs
- tableCreator.cs

These are necessary classes to check the status of the application and it is part of the structure of the webapp created by the ASP.NET Framework.

And finally we have the Controllers directory with the GameStateControllers.cs classes that is part of the webpp structure and is used to make queries to the API.

The program.cs and Startup.cs files were generated automatically when creating the project with dotnet, these classes are to start the web application to be able to control it from the browser.

## Get Started.

To launch the web application inside the MineSweeper directory run:

```bash
dotnet restore
dotnet run
```

in the browser enter the url: **localhost:5000**

## Authors

* **Willy Samuel Paz Colque** - *All*