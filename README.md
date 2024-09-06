## Poe·tts — Pillars of Eternity Text to Speech

## XReaper notes

I found this project while searching for a way to do TTS for POE's infinite walls of text. This branch aims to improve this amazing project for my own use, all credits to the original author https://github.com/miled.

### Improvements implemented:

- Upgrade .NET SDK to NET 8.
- Add support for multiple languages, for now only english and spanish are configured.
- Game path is requested to be manually selected at startup, avoiding the unreliable Windows registry search.
- Configuration file now stores last selected language and voice.
- Work around a bug in the Microsoft Speech API that prevents form getting all the installed voices.
- Add a textbox with the tessaract command output for easier debugging.
- Add a save button for manually saving the configuration.
- Modify the build script so releasing an standalone app is as simple as publishing the solution the standard way, including all tessaract dependencies.
- Clean up the repository.
- Fix a few unhandled exceptions.

## Original Readme

Poetts is a tiny utility -made for my personal use- to synthesize some of the horribly long text on Pillars of Eternity through Windows SAPI text-to-speech engine.

### Audience

Anyone who's visually impaired, have reading difficulties or who's simply too lazy to read tons of text.

### How it use

To use Poetts, keep the Dialog box running on the background, then open Pillars of Eternity and use the available hot-keys from within the game (Ctrl+R to synthesize the text, Ctrl+P to pause or resume and Ctrl+S to stop the speaker).

![Image1](https://raw.githubusercontent.com/miled/poetts/master/image1.png)

    Notes: 
    Depending on amount of text on the screen and your computer, the process my take few seconds.
    Poetts may generate funny results at times.

Poetts is best used for this kind of interfaces:

![Image2](https://raw.githubusercontent.com/miled/poetts/master/image2.png)

### How it works

Poetts uses [Tesseract OCR](https://code.google.com/p/tesseract-ocr/) to convert images into text before attempting to match the extracted text to the game data folder to find the right sentences to read. This process however isn't too accurate and Poetts may generate unexpected results at times.

### Disclaimer

Obsidian Entertainment, is not affiliated, associated, or endorsed by me.
