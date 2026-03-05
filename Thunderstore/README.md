# RoR2 Mumble Link (Proximity Chat)
A client-side Risk of Rain 2 mod that implements positional audio using Mumble. This means voice chat is spatialized in-game by tracking your player position.

If you have any problems with this mod or you would like to suggest a feature, simply open a issue on the GitHub repository or contact me in the RoR2 modding discord. My username should be `zysex`.

# Setup Guide
1. First and foremost, **install [Mumble](https://www.mumble.info/)** if you haven't already.
2. From the main screen, go to Configure -> Settings.
3. Go to Audio Output.
    * Make sure the enabled box is checked under **Positional Audio**.
    * Configure the Positional Audio settings. It is highly recommended that all players have similar/identical PA settings.
    ![audio output](https://raw.githubusercontent.com/NotZyrex/RoR2-Mumble-Link/refs/heads/master/docs/1.png)
4. Go to Plugins.
    * Ensure **Link to Game and Transmit Position** is checked, and the **Link** plugin is enabled.
    ![plugins](https://raw.githubusercontent.com/NotZyrex/RoR2-Mumble-Link/refs/heads/master/docs/2.png)

Ensure you have correctly followed these instructions, then connect to a Mumble server with your friends and start a run. If successful, you should see `Link (Risk of Rain 2) linked` in Mumble's chat logs.

> **Note:** Using public servers means your IP address and activity may be visible to the server operator, and other users who connect can listen in on your conversations. If you would like to setup your own server, refer to this [guide](https://www.makeuseof.com/how-install-own-mumble-server/).

# Additional Notes
* If everyone else is quiet, try increasing **Maximum Distance**.
* When streaming or recording, make sure your software captures both in-game audio and Mumble! Voice chat audio is **not** handled through the game.