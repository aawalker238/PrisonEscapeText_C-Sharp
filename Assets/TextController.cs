using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text text;
	private enum States {cell, cell_return, mirror, sheets_0, lock_0, cell_mirror, cell_north, cell_south, captured, sleeper, cell_safe, cell_east, trash, cell_east_return, hallway, caught, fight, surrender};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		//Frist Branch
		if (myState == States.cell) {
			state_cell();
		}
		else if (myState == States.cell_return) {
			state_cell_return();
		}
		else if (myState == States.sheets_0) {
			state_sheets_0();
		}
		else if (myState == States.mirror) {
			state_mirror();
		}
		else if (myState == States.lock_0) {
			state_lock_0();
		}
		//Second Branch
		else if (myState == States.cell_mirror) {
			state_cell_mirror();
		}
		else if (myState == States.cell_north) {
			state_cell_north();
		}
		else if (myState == States.cell_south) {
			state_cell_south();
		}
		
		//Third Branch
		else if (myState == States.captured) {
			state_captured();
		}
		else if (myState == States.cell_safe) {
			state_cell_safe();
		}
		
		//Fourth Branch
		else if (myState == States.cell_east) {
			state_cell_east();
		}
		else if (myState == States.cell_east_return) {
			state_cell_east_return();
		}
		
		//Fifth Branch
		else if (myState == States.trash) {
			state_trash();
		}
		else if (myState == States.hallway) {
			state_hallway();
		}
		
		//Sixth Branch
		else if (myState == States.fight) {
			state_fight();
		}
		else if (myState == States.caught) {
			state_caught();
		}
		else if (myState == States.surrender) {
			state_surrender();
		}
	}
	
	void state_cell () {
		text.text = "You wake up from what seems to be a year long sleep. You find youself in a prison cell and hear a few faint voices in the distance that seem to be in a foreign tongue. It's dark...There are some dirty sheets (and quite smelly at that) on the bed, an aged makeshift mirror on the wall. The door is locked from the outside...\n\n" +
			"* Press 'S' to View Sheets, 'M' to View Mirror, 'L' to View Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}
	}
	
	void state_cell_return () {
		text.text = "I've got figure out a way to get out of here...Hhmmm, maybe I should look around some more.\n\n" +
			"* Press 'S' to View Sheets, 'M' to View Mirror, 'L' to View Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
		else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}
	}
	
	void state_sheets_0 () {
		text.text = "I've been sleeping in these dirty things! What, these people don't believe in hospitality? Huh, that's a dumb question. Where am I anyway? Prison bars and dirty sheets...This can't be good.\n\n" +
			"* Press 'R' to Return to Cell.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_return;
		}
	}
	void state_mirror () {
		text.text = "Ahhh! What is this hideous creature on my face! Wow, you go from a clean-shaven Marine Captain to a bigfoot impersonator. How long have I been in here? Wait...what's behind this mirror? \n\n" +
			"* Press 'R' to Return to Cell, 'T' to Take Down Mirror.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_return;
		}
		else if (Input.GetKeyDown(KeyCode.T)){
			myState = States.cell_mirror;
		}
	}
	void state_lock_0 () {
		text.text = "This lock looks like it's trying to keep the Hope Diamond from escaping. How flattering, I must be worth something to them. But 'them' is who I am trying to find.\n\n" + 
					"* Press 'R' to Return to Cell.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_return;
		}
	}
	
	void state_cell_mirror () {
		text.text = "Smooth move Mr. Architect. A hole behind the body mirror? Who would have guessed, This is too good to be true. But I'm just in another cell now. AAAHHHHHH!!!! There are two mirrors in this cell. Let's see...perfect! Behind every body mirror is a way to the next cell. But why?\n\n" + 
			"* Press 'N' to go to the North Cell, 'S' to go to the South Cell.";
		if (Input.GetKeyDown(KeyCode.N)){
			myState = States.cell_north;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.cell_south;
		}
	}
	void state_cell_south () {
		text.text = "[Other Prisoner] يا كيف تحصل هنا جورادس جورادس.\n" + 
		"[You] Hey, shhh...be quiet!! SHHHHH! \n" + 
		"[Other Prisoner Starts Yelling for Help]\n\n" + 
			"* Press 'R' to Return to Previous Cell, 'S' to put him in a Sleeper Hold";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.captured;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.cell_safe;
		}
	}
	void state_captured () {
		text.text = "The guards come, taze you, now you're done...\n\n" + 
				"* Press 'R' to Replay.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	void state_cell_safe () {
		text.text = "Whew, that was close. Ok, just go back back to the other cell...\n" +
		"Let's try the other way.\n\n" + 
			"* Press 'N' to go to the North Cell.";
		if (Input.GetKeyDown(KeyCode.N)){
			myState = States.cell_north;
		}
	}

	void state_cell_north () {
		text.text = "Hhhmmm, an empty cell. Glad about that. One mirror. Let's see [Rips the mirror from the wall...].\n\n" + 
			"* Press 'E' to go to the East Cell.";
		if (Input.GetKeyDown(KeyCode.E)){
			myState = States.cell_east;
		}
	}
	
	void state_cell_east () {
		text.text = "Two mirrors, zero prisoners...That's my kind of math! Let's see [Rips the first mirror from the wall...then the second]. Two more options, will this maze ever end?\n\n" + 
			"* Press 'N' to go to the North Cell, 'S' to go to the South Cell.";
		if (Input.GetKeyDown(KeyCode.N)){
			myState = States.trash;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.hallway;
		}
	}
	void state_trash () {
		text.text = "Oh man! EHHHHHHH! Great, the trash room. Well at least I must be close to food...But then again, my appetite seems to have escaped me.\n\n" + 
			"* Press 'R' to Return to East Cell.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_east_return;
		}
	}
	void state_cell_east_return () {
		text.text = "Ok, I only have one more option [Walks to southern side of the cell].\n\n" + 
			"* Press 'S' to go through southern hole.";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.hallway;
		}
	}
	void state_hallway () {
		text.text = "[Guard approaching...Oh no, he sees you are starts yelling and coming toward you].\n\n" + 
			"* Press 'R' to Return to Previous Cell, 'S' to surrender, 'F' to fight.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.caught;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.surrender;
		}
		else if (Input.GetKeyDown(KeyCode.F)){
			myState = States.fight;
		}
	}
	void state_caught () {
		text.text = "You try to get away but the guard tazes you and you fall and blackout. You lose.\n\n" + 
			"* Press 'R' to Replay.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	void state_surrender () {
		text.text = "You surrender. They beat you. You lose.\n\n" + 
			"* Press 'R' to Replay.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	void state_fight () {
		text.text = "As the guard tries to apprehend you, he reaches for his gun, but being a trained marine, you kick the gun from his hand, grab the back of his neck and smash his face into the ground knocking him clean out. You grab his keys, swoop up the gun and the rest is history. To be continued...\n\n" + 
					"Congratulations, you win!";
	}
}
