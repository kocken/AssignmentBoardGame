You can see the content of this by opening commandline and navigate to the DocsSrc folder, and write ```docfx .\docfx.json --serve --port 8081```, then open your browser and navigate to [localhost:8081](http://localhost:8081).



**NOTES**

When the project is running through Visual Studio and the browser pops up with the localhost URL, you will be able to join the game. 

If you'd like to leave or reset the game, you can do so by clicking the buttons. The leave game button is only available when you're part of the lobby/game.

The game stores your player session through cookies, whereas the cookie is saved for 30 days. If you leave the game, your cookie will be removed. Until it's removed, you will auto-join games/lobbies with the same player name. 

To update the lobby/game, simply press F5 on your browser to refresh the page. 

Only two players are able to play, if a third person tries join then a notice-message will show that the lobby already is full. 

"Server" messages (notices), given when players join/leave and when the game is reset (with more) is only shown once temporary, and is only shown by the person executing the action.



**RESOURCES USED**

Roger Harford's short "Introduction to ASP.NET MVC" youtube playlist
https://www.youtube.com/watch?v=YSHW9F2dtOY&list=PLC46E714C386B068B

@Html#Raw information
https://stackoverflow.com/questions/26902189/how-to-split-the-success-message

https://forums.asp.net/t/2017595.aspx?How+to+pass+object+of+class+in+url+action+in+mvc+C+

http://www.tutorialsteacher.com/mvc/routing-in-mvc

http://www.tutorialsteacher.com/mvc/viewbag-in-asp.net-mvc



**HOW TO PLAY**

Just looking at the website provides enough information to be able to play, but if you'd like further detailed information, look below. 

On the opened web-page (located at localhost:x), join the game by providing a player name into the text-field and clicking submit. 

Next, yourself or a friend will have to join, to take the second and last spot. 

To join, open up a secondary browser and type in the same URL to get to the web page. 

Once this is done, join like before, providing an unique name and clicking submit, and the game will start. 

Once both players are in, you will see 9 green rectangles towards the bottom, as well as a title above it saying who's turn it is. The player who's turn it is need to click an available tile (rectangle). 

The available tiles are the ones without any text. Tiles which are marked with 'X' or 'O' are taken by either you or the other player. Players will always use the same mark during a game-round. 

Once the player have clicked an available tile, it's the other player's turn to choose an available tile. 

This choose-a-tile process will continue until a player have won, by getting 3 of the same mark in a row, or until all tiles have been picked, whereas there will be a draw. 

After a finished game, whatever it was drawn, won or lost, players will be shown a draw/win/lose page, whereas they can choose to either leave or restart the game.