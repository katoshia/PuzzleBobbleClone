README - NOTES - VERSION ONE

GitHub link to repository - https://github.com/katoshia/PuzzleBobbleClone

Developer Notes - Time
~6-7 hours put in
~3-4 hours on Unity updates and first build of project files - down time + 8 for sleep, and 3 for meals
- 1 - 1.5 hours on github repository setup (additional update was required). pulled and cloned for verification it was working properly - time for first build added in already for the cloned project.

Developer Notes - Attempts
- attempted to use tilemap and palette for prefabs as this was a supported function - not on this version of Unity
- had to recreate container and bubble prefabs for each variant
- basis game logic
	Bubble - sprite for handling the bubble objects - handles interactions with wall, top(to be implemented) and physics.
	Shooter - bubble shooter, rotation for Input(keyboard currently), bubble preview, shoot speed, physics based on the speed
	GameManager - UI script - not fully implemented - place holder
	BubbleGrid/Container - Script used to mange the container of the bubble board 
	still needs a levelManager - plan to implement three levels currently
- basic layout - UI/UX to be implemented last step

Known bugs
	Bubble Shooter - Preview Bubble sometimes collides with itself at creation - frame jump?
	Ceilint/Top - logic to snap bubbles at the top of the board - not implmeented.
	SnaptoArea/Grid - Bubbles are hitting the grid but not snapping into place as expected - Might use tilemap for position setting - will need to calculate the offsets based on the hexagon formation

logic to be implemented
	booleans for isFixed(bubbles at top)
	booleans for isConnected(bubbles on board connected to neighbors)
	score to be updated
	level manager
	ui and audio
	animations (not many to use but can use the "popping" animation on bubbles that connect and match(3 or more) or on bubbles that drop after they're disconnected from the top (isFixed bubbles)
	win conditions
	exit conditions


