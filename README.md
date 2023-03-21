# MIDI-Hero

![MIDIHero](https://user-images.githubusercontent.com/77464600/164816073-9adf05b7-214d-4a19-9cb9-aa7b7ad41a0f.PNG)

## Choose device
The devices that work with this game include: MIDI Keyboards, Launchpads, or even a PC Keyboard in case you don't have a MIDI device!

![name](https://user-images.githubusercontent.com/77464600/225025399-22f9dc55-ce35-4326-882c-15721540d865.PNG)

## Create a new song
In order to create a new song you must enter the song name, artist of the song, and a .ogg file that contains the audio for said song.

![newSong](https://user-images.githubusercontent.com/77464600/164816119-23cde3b8-1981-4e0b-985c-a44f2187c4eb.PNG)

## Record your song
During the recording process, the audio file you uploaded will begin playing.
As it plays you can use the device you chose and MidiHero will record your inputs!

![recording](https://user-images.githubusercontent.com/77464600/225025556-0df85e80-3a1e-4930-897e-3ae0bb4ea2e1.PNG)

## Select the song you want to play
Once you are done recording songs, they will appear in a list on the main screen.
The number next to the song is the difficulty rating.

If your song has more notes per minute, the higher the difficulty rating!

![select](https://user-images.githubusercontent.com/77464600/225025586-be43b181-ee80-4077-9608-7f600592eeee.PNG)

## Play!
Finally, play the song you recorded!

The notes will fall from the top of the screen in the same way you recorded them earlier.
The game will keep track of your score and streak, as well as indicate how accurate your timing is (MISS, OKAY, GOOD, GREAT, PERFECT)

![song](https://user-images.githubusercontent.com/77464600/164816429-958b5059-a0ab-4fa6-a65f-82c6100f2d3e.PNG)

## See your score
Once the song is finished you can see how well you preformed!

![score](https://user-images.githubusercontent.com/77464600/225025608-464c85a7-196b-4743-a937-1779ccebf55e.PNG)

# Advanced Concepts
If you are interested, here is a detailed look at some of the systems working behind the scenes to get this program to work properly!

## Calculating Note Spawn Times
The problem that occurs when calculating when the notes should spawn is not abundantly clear initially, as it may seem simple at first glance.

Within the game there are two modes: Recording mode, and Playing mode.
During the recording process if, say, the first note is pressed at 5.25s, then during the playing process that same note should spawn at 5.25s. Right?

The problem is, that won't work the way you may expect.

Before we go into that, lets explain the different note states.
There are "Deyployable" notes, and "Action" notes.
Deployable notes are the notes that fall from the top of the screen.
Action notes are the player-controlled notes. They always remain at the bottom of the screen.
When the deployable notes reach their coresponding action note, the player is expected to play that note.

If you look at the diagram below, the "Note Highway" is the screen that the user sees.
The "Deployable" Note position is where those notes initially spawn, just above the screen out of the users sight.

![lookAhead](https://user-images.githubusercontent.com/77464600/225050583-fce21390-a8cb-44b2-975a-2ced76d0261c.PNG)

If we go back to our example, if a deployable note spawns at 5.25s, by the time it reaches the action note, time has passed making the note out of sync!

Instead of spawning the note at 5.25s, we actually want the deployable note to touch the action note at EXACTLY 5.25s.

Therefore, we have to do some math to determine at what time the note needs to spawn at so it arrives at the action note accordingly. 
We need to calulate distance divided by time, so we know how long it takes the note to travel from the spawn location to the action note.

With that being said, we need the distance of the action note to the spawn location of the deployable note. This is called the "Look Ahead".

So, we take the value of the x cordinate where the action note is, 
and the value of the x cordinate where the spawn location of the deployable note is.

In this case we are taking the absolute value because it the first x coordinate is a negative value.
(Example: If we didn't take the absolute value then -5 + 20 = 15, whereas Abs(-5) + Abs(20) = 25.)

Then, we need the speed. In my case, the deployable notes fall of a rate of 10 units per second.
So, the code looks like this!

![lookAheadCode](https://user-images.githubusercontent.com/77464600/225050979-d23e9f5f-3392-4142-b07e-cf486cdf5333.PNG)

Then, in our case, simply subtract 5.25s to the delay. (An exmple value could be 4.5s)

Now we are done.... right?

Well, we've actually created a new problem. Can you see it?

What if, during the recording process we played a note within the first second. Say, 0.5s for example.
If the delay is 1.5s then 0.5 - 1.5 = -1s.

The note would spawn before 1s before the scene is even loaded!

With this being said, the solution is quite simple.
Instead of playing the audio as soon as the scene loads, delay it as well (we can use the same delay we calculated for the deployable notes)
and only accept input AFTER the initial delay.

And there you go! That is how MIDI Hero calculates when notes should spawn!

## Note Hitboxes
Another complexity with this particular game is the different timings that you can earn depending on how accurate you are.
These timing include: MISS, OKAY, GOOD, GREAT, PERFECT

There are many different ways you could go about calculating these, but the option that I chose was to have a prefab for notes with multiple hitboxes.

![hitboxes](https://user-images.githubusercontent.com/77464600/225058317-87db2008-ab94-49f4-93e3-78085530fd55.PNG)

As soon as one of the deployable note's hitboxes touches an action note I add 1 to a counter, the higher the number the better the score.
(Example: If the counter is 5, the that is considered PERFECT)

Once the action note begins exiting the hitboxes, the counter will decrease.

So, this is what the code will look like:

![noteHitboxCode1](https://user-images.githubusercontent.com/77464600/225061798-53460215-20d8-464e-a381-3865f5713cb5.PNG)

The counter can then be easily deciphered with an enum:

![noteHitboxCode2](https://user-images.githubusercontent.com/77464600/225062522-f92a4466-aef9-4a0c-9862-98191e35fc48.PNG)

Depending on how good the timing is, the higher the score. This is calculted by using a dictionary where the key is the hitbox, and the value is the score:

![noteHitboxCode3](https://user-images.githubusercontent.com/77464600/225063926-478a3ca8-23b4-46b2-972c-fe165353d1d9.PNG)

And finally, the score is added during playtime:

![noteHitboxCode4](https://user-images.githubusercontent.com/77464600/225064574-a152fce6-6d11-40c1-916b-8d209da8ffac.PNG)

