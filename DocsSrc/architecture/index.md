# Board game architecture

## GameEngine
In the GameEngine project, all code revolving the actual game (backend) is located. 
It requires a frontend to be used though, in order to show up all the game-tiles and to call/communicate with this backend. This is done within the "BoardGameWui" project described below.

The main file is "TicTacToe.cs". 

This file has all game logic; logic for whatever a game is finished/won, logic for knowing if the game/lobby is full or not, methods to make a player join/leave, method to make player-moves, to restart the game and so on. 
This file also contains the game data; a list of the player names, a variable of the player who made the most recent move (which is used to store the winner, if a game has be won) as well as an array of the (9) gameboard-tiles. 
The gameboard-tiles have their own object class called "GameBoardTile". This file contains coordinates (a point with x and y), as well as a mark-value. 
The mark variable and variable is of the custom-made "Mark" enum-type, which can be "X", "O" and "Available". 

When the TicTacToe file is initialized, it populates the gameboard-tiles with coordinates and makes the tiles have the mark-value "Available". 

While this game engine is relatively simple, it could very well be used as a base for other online/game projects due to the many useful methods that will required in these type of projects. 
In fact, the majority of methods would be of great use in these kind of online/game projects, such as join/leave/reset/get opponent name etc.

## BoardGameWui
In the BoardGameWui project, all code revolving the web and MVC is located. 

The URL routes all are configured to lead to the "Index" action of the "TicTacToeController" controller, which is the only controller of this project. This makes the whole application playable on the root URL, as well as provides some additional stability.
This controller-class will determine what the player will see (the view) and get redirected to. 
It's also the center and communicating file, that will manipulate browser cookie data, store & grab information from the game engine, create & populate model-data, and execute actions chosen from the view. 
The Index action of this controller is the main action and decides the view that should be chosen for the player. All actions redirect to this action, to make it clean and only have one action-class deciding which view to show. 
Before a view is chosen, the data is then applied to a GameSession object, which is the only model-class for this project. 
The model is passed onto the view, and carries with the crucial data that the views need, being the player name, opponent name, who's turn it is, as well as the gameboard (the 9 game-tiles). 

There are 4 views, which is what the player sees in his or her browser. In these views there are actions that the player can execute, which will be handled by the controller (TicTacToeController) class.
The first one is Lobby, which is the view chosen before a game has started and the game is awaiting for two players to have join. There's a form that players can use to join. Once the two players have joined, the Game view is shown. 
The Game view shows as long a game is in progress. There's a title that shows who's turn it is. Below, the game-board is shown of 9 buttons, which are clickable by the player who's turn it is. 
Once a game is finished, the player will be shown with either the GameDraw view or the GameOver view. The GameDraw view will be shown if there was no winner, and the GameOver view will be shown if there was a winner. 
If there was a winner, the player will know who won by looking at the title. Below, they will be able to reset the game if they so which to play again. 

In this project I sadly did not use that good of a MVC structure. 
The model class is supposed to be the MVC class that does most of/all the data handling, but in my project it was the controller class that handled the data storage. 
The controller file stored the game-engine object, which was done statically for the object to not disappear. 
I did this because I had no better solution for the approach I wanted to take, which was to store all data in the memory, within the application. 
I learned that the MVC structure is a bad approach when the data is saved within the memory of the solution. Data should instead be properly saved locally or in a type of database when using MVC.