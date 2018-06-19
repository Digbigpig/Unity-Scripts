Descriptions:

Equipment-Panel
    This gif demonstrates the equipment panel I have extended functionality of. It includes a click to equip/unequip functionality as well as adding the associated skill boosts to the player's stats.
  
Manual Moving
    Normally I wouldnt include something so trivial as a basic wasd movement controller, however, this one is special to me because I manipulate the Unity's AI Agent feature which allows for click to move and path finding. This allows for a smooth transition from casual play with the mouse as your primary form a movement to an agressive wasd movement. This also allows for speed calculations to be applied to one component rather than having two systems for WASD and Agent movement.

Skill Based Combat
    This feature is one of the core mechanics of the game. Besides an auto attack feature, the skills based combat allows for a multitude of different combat options and variations. This was implimented using scriptable objects using vitrtual functions that are overwritten to allow for the specific functionality of the skill. They have cooldown and energy usage attributes as well as having an associated character class that they will only be available to (warriors, magicians, etc.).
