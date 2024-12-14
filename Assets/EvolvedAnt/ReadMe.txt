Music Transition Prefab
By: EvolvedAnt#0001

This prefab enables placing triggers that activate smooth transitons between the volume of multiple audio sources.
Useful for background music that relates to specific areas the player may walk through that changes dynamically.

Instructions
============

Seting up the Music Manager:
	Add the MusicManager script to an empty gameobject in the scene.
	Set the transition duration and add all the audio sources to the Music Collection field that you'll be using.
	Optional: You may also enable the use of curves to create custom shapes for the transition between audio sources.

Setting up the triggers:
	Create box colliders with the Is Trigger flag enabled and add the MusicTrigger script.
	Assign the MusicManager gameobject to the Music Manager field for your triggers.
	Assign the audio source you want to play when the player walks through the trigger.
	
Future features
===============

A future release will enable customizing audio sources so they will always play from the begining of the audio clip if desired.
Doing so is also a slight performance boost, as audio sources will not take up CPU time when they aren't heard.


