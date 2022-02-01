# Unity-Localisation-System
A basic implementation of a localisation system in Unity, based on [GameDevGuide's implementation](https://www.youtube.com/watch?v=c-dzg4M20wY). Credit mostly to him, though I have made my own tweaks to the system.

## Usage

This is intended to be essentially dragged-and-dropped into your project. All of the files should be in the right place, right folders and everything.

To localise text, make sure you have TextMeshPro installed. Create an object with a TextMeshPro text component on it and then drag the TextLocaliseUI component onto it. Set the "Text Field" variable to the TextMeshPro - Text component on the object, and set the key to use in the text field. You can preview the localised text in the dropdown under the text field. You can add to the dictionary from the editor using the second button to the right of the text field, or search through the dictionary with the first button to the right.

This script should also automatically set the text to the text you set in the TextMeshPro text field, so you can set your key text there instead of setting it in two places at once. This also has the advantage of putting your key text directly on UI elements so you can see if there is some text that doesn't have a proper localisation right away.

## Prerequisites

TextMeshPro, and that's about it.