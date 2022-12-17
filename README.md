# VR-Breakout
VR Breakout marries old school and new tech. It's is a simple 3D Breakout game playable only in VR, tested on HTC Vive Pro 2.   
Developed for CIS5680 at the University of Pennsylvania.

The source code of this project is available in this repository itself.  
The executable can be found in the Github releases (direct link [here](https://github.com/VR-Breakout/VR-Breakout/releases/tag/v1.0)).

## Demo & Trailer
[Demo link](https://youtu.be/EWWbixV8CAQ)
[Trailer link](https://youtu.be/0abRJAB6MZE)

## Documentation

### User's Guide
Before playing the game, ensure that you own a VR headset and controller with a trigger and menu button. Some amount of space (roughly 5 by 5 meters) will also be needed.

Once downloaded, simply start the executable with all VR peripherals plugged in. You will find yourself in a rectangular room, with a grid of blocks at the other end. Two paddles in game track your left and right controllers (although only one is necessary). To play, press the trigger on your VR controller to spawn a ball. Hit it with the paddle to begin play. The collision of the paddle is much like a real life one (e.g., hit the ball harder to make the ball go faster). If a ball hits a block, the block will be destroyed. At some point, balls will bounce back to the player, and will need to be struck again. If the ball hits the back wall behind your starting position, a breaking sound effect will be heard, and that ball will disappear. 

On the floor of the game, there is a "Timer" and "Score" visible. The score text increases by 10 for each block you destroy, but also decreases by 10 for each ball that hits the back wall. You can summon as many balls as you want with the controller by repeatedly pressing your controller's trigger; be careful about managing the number of balls and their effectiveness with possible point losses if they strike the back wall!

The timer counts down from 200 seconds. If it reaches 0 and there are still blocks remaining, it will be "Game Over". On the other hand, if you destroy all blocks within the 200 second time limit, you win the game!

### Setup and Configuration
The game requires no setup beyond the VR space-based setup that comes with the device. For development purposes, the game is a simple Unity game that can be pulled from this repository and opened in any Unity project (game developed with 2021.3.14f1). 

### Major Gameplay Features
A (*) indicates a major change/revamp from beta to final version.
- Ball elastic collision logic
- Paddle physics to emulate physical kinematic transfer of energy*
- Various tricks to change ball interaction feel:
  - non-parallel walls of room (angled outward for ball return)
  - drag-based slowdown of ball as it approaches player*
  - minimum and maximum velocities to guarantee game speed
- Ping-pong paddle collision model*
- SFX*
- Emission-based VFX*
- Haptic feedback on ball collision
- Overall game logic for scoring*, timer*, game over conditions*, etc.

### Technical Issues
Our game setup was plagued with numerous issues. The original desktop we attempted to develop on repeatedly blue-screened and refused to recognize VR headset input. We switched to another desktop, but it seemed to have a variety of Unity-based issues. After some wrangling, we were able to get it to work, but it possessed a GTX Titan, which seemed insufficient in terms of graphical power. As a result, we experienced various slowdowns in our playtesting, and the graphical fidelity of our game had to be downscaled to run properly on the VR headset.

### Assets Used
Our sound effects were sourced from [Free Sound Effects Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-sound-effects-pack-155776), and [FREE Casual Game SFX Pack](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116); and our paddle model is from [Beach Bat](https://assetstore.unity.com/packages/3d/props/beach-bat-103176).

Trailer Music from [Orbit (Free Ambient Video Game Music)](https://assetstore.unity.com/packages/audio/ambient/orbit-free-ambient-video-game-music-204571).


