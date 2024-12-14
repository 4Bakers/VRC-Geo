Music Transition Prefab
By: EvolvedAnt
Discord: EvolvedAnt#0001

This prefab enables placing triggers that activate smooth transitons between the volume of multiple audio sources.
Useful for background music that relates to specific areas the player may walk through that changes dynamically.

Instructions
============

MANUAL SET UP:

Seting up the Music Manager:
	Add the MusicManager script to an empty gameobject in the scene.
	Set the transition duration and add all the audio sources to the Music Collection field that you'll be using.
	Optional: You may also enable the use of curves to create custom shapes for the transition between audio sources.

Setting up the triggers:
	Create box colliders with the Is Trigger flag enabled and add the MusicTrigger script.
	Assign the MusicManager gameobject to the Music Manager field for your triggers.
	Assign the audio source you want to play when the player walks through the trigger.
	Optional: Set any custom volume you'd like to reach, default is full volume.
	Optional: Set whether you'd like the sound to start over when activated.
		  Note: This only works if the audio has reached 0 volume, otherwise it will continue where the audio left off.

AUTOMATIC SET UP:

Just add the prefab to your scene, delete the example environment, and resetup the triggers and music as desired, making sure the MusicManager always has ALL your audio sources added to the Music Collection that you will be utilizing for music transitions. See the manual set up instructures above for more details on the MusicManager and MusicTrigger script setup.
	
USEFUL TIP
=========
Place a music trigger at the spawn location, to control what music should play upon the user respawning.

Credit is appreciated but not required~