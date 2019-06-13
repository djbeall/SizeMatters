# SizeMatters

Size Matters is a 2D platform game created with Unity. The player can move horizontally using the left and right arrow keys and jump 
using the spacebar. The player can also press ‘P’ to pause the game and press ‘R’ to restart the level.

In the first stage, the goal is to make it to the finish. The stage automatically side-scrolls, so the player loses it they fall off 
the screen if they do not move quickly enough. There are also some obstacles along the way, and the player loses if they touch a spike. 
Throughout the level, there are food pickups scattered around. As the player picks up more food, their radius increases. Different foods 
have different values. Fruits (apples, cherries, and avocados) increases the radius by  0.1 units, bacon is worth 0.2 units, and a 
chicken leg is worth 0.3 units. If the player makes it to the end of the stage, they progress to the boss stage. If the player loses, 
a message is displayed, and the level automatically restarts after a short delay.

The second stage is the boss stage where the goal is to knock the opponent off of the platform. The size of the player is the same as 
it was as the end of the previous level, meaning it is dependent on how many food pickups were gathered. The larger the player is, the 
stronger it is, and the greater force it has on the boss. If the player knocks the boss off the platform, the player wins. If the player 
is knocked off by the boss, the player loses. 
