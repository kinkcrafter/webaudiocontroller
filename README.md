# DISCLAIMER

**This Repository does NOT contain any adult content.** However it DOES contain some graphic descriptions and code in this project is meant to provide interesting learning and entertainment opportunities for consenting adults.

# Web Audio Controller
Control Audio Feeds over LAN via browser; runs as a C# embedded Windows Forms App.  This code is AS-IS.  I will entertain PRs and issues, so feel free to contribute!

## Release notes
- The Dec2020 release has significantly improved the clone to build story and fixed many dependency issues that folks were experiencing.
- Text-to-Speech has been added!  Type in your commands via the webapp and speak away!
  - You can install new language with this process [Install new languages](https://support.microsoft.com/en-us/office/how-to-download-text-to-speech-languages-for-windows-10-d5a6b612-b3ae-423f-afa5-4f6caf1ec5d3#:~:text=Install%20a%20new%20Text-to-Speech%20language%20in%20Windows%2010.,installed%20when%20your%20machine%20turns%20back%20on.%20)
  - Pick your language on the server's GUI, it has a dropdown in the "voice and noice" pane.
  - Sending text commands will save the text in your browser session only, you can click and repeat them but they will clear if you reload your browser.

## Acks

This service borrows heavily from [NAudio](https://github.com/naudio/NAudio), a C# library that allows code to interact with audio APIs in windows.

## Setup
Build or Debug this project in Visual Studio.  I used VS2019; VSCode and VS2017 may work as well.

When running the compiled program or debugging in VS, the process must be ran in administrator mode for the embedded app to serve pages on port 12345.

If you want to let phones, computers, or any other devices on the LAN control the audio app, you will need to allow port 12345 inbound connectivity for devices on the local network

## Usage

### Form App

Run the App **(in Administrator Mode!)**, a windows form will load up.  From this WinFroms app, you can do the following:
- View the status that scrolls across the top of the app
- Create, Load, Delete Profiles
- Create, Load, Delete Voice Playlists
  - Record new Voice files
  - Assign, Remove, and Reorder Voice files
- Create, Load, Delete Audio Playlists
  - Add, Remove, and Reorder Audio files
- Click the hyperlink to the [WebApp Page](http://127.0.0.1:12345)

### Web App

Either browse to the [WebApp Page](http://127.0.0.1:12345) on the machine running the WinForms App or browse to port 12345 on the IP address belonging to the machine running the WinForms App.

You can do the following:
- View what the app is current doing
  - Playing Noise, Audio, Voice, Stopped, Muted, etc...
- Stop or Pause whatever is playing
- Play White or Pink Noises
- Play Audio from the playlists
- Play Voice recordings from the playlists
- Record/Upload a voice file that will then play over the audio

_Note: When an audio file is recorded via the WebApp, it will be uploaded ot the server, which will save the audio file here:_ `C:\Users\<username>\AppData\Local\WebAudioService\LiveAudio`

_Have fun with that!_

## How to **REALLY** use this App

This App was designed for Adult BDSM Scenes to be used in a few different ways.
this app was designed to play audio over a windows tablet/laptop/whatever to either bluetooth audio or whatever wired audio your device outputs to a submissive.

`A submissive cannot hear their owner's voice when wearing a hood during a scene!  Ms. Crafter and I like to have some interaction during intense sensory deprivation scenes.  It's also a bummer to be in a hood and hear Ms. Crafter or myself rattling around during a scene!  Earbuds can be put on before the hood is put on and whoever's on top gets to control whatever the submissive hears.  This includes songs with the AUDIO feature, pre-recorded messages from Ms. Crafter telling mr crafter how naught he's been with the VOICE feature, white/pink noise with the NOISE feature, or Mr. Crafter talk directly to ms crafter and tell her that she's not allowed to cum with the TALK feature.`

`Mr. and Ms. Crafter have a remote control fetish.  Ms. Crafter is on top this week and wants a nice massage from mr crafter tonight.  Ms. Crafter tells mr crafter to put on his bluetooth earbuds and she cue's up a playlist of massage voice commands.  She plays whatever songs she wants mr crafter to hear with AUDIO.  When she wants to give mr crafter an instruction about the massage, she goes to the VOICE feature and hits 'use more lotion', she recorded the voice track for earlier.  mr crafter hears this and complys, with the songs from AUDIO resuming after her command is played over bluetooth.  Ms. Crafter is not very happy with mr crafter's massage, so she changes the playlist in the VOICE feature to the punishment playlist that she also recorded previously and plays 'get on your knees for a spanking', which plays to mr crafter.  mr crafter anxiously gets into position.  Ms. Crafter uses the TALK feature to tell mr crafter "I want you to count the swats".  mr crafter says "yes Mistress" and counts the swats as she delivers punishment to mr crafter.`

## Why???

This solved a few issues and scenarios and fit well into Mr. and Ms. Crafter's kinks.
