# unity_softlockon_project

The main script is Assets/SoftTargetScript.cs

In order to set this up, you need to create an empty gameobject underneath your main player or actor and add this script to it. 

From there, set the correct layer ID (for whatever you want to lock on to) and distance in the inspector.

You can offset the child gameobject from the parent in order to give a certain direction priority. 

The sample scene has the soft target gameobject offset 1 unit unit in front of the demo player
