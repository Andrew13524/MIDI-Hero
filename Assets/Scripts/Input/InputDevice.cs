using Assets.Scripts.Models;
using MidiJack;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Input
{
    public enum Device { Keyboard, Launchpad, Piano }
    public enum Key { ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT }
    public class InputDevice
    {
        private static Device device;
        private static byte[] lastInput;
        private static byte[] input;
        private static byte lowestButtonID;
        public InputDevice(Device device = Device.Keyboard, byte lowestButtonID = 36)
        {
            InputDevice.device = device;
            InputDevice.lowestButtonID = lowestButtonID;

            input     = new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
            lastInput = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        }
        public static byte[] PressedNotes()
        {
            switch (device)
            {
                case Device.Keyboard:
                    return KeyboardOutput();
                case Device.Launchpad:
                    return LaunchpadOutput();
                case Device.Piano:
                    return PianoOutput();
                default:
                    throw new NotSupportedException();
            }
        }

        private static byte[] KeyboardOutput()
        {
            byte IsKeyPressed(KeyCode keyCode)
            {
                if (UnityEngine.Input.GetKeyDown(keyCode)) return 1;
                else if (UnityEngine.Input.GetKeyUp(keyCode)) return 0;
                else
                {
                    if (!UnityEngine.Input.GetKey(keyCode)) // Have to do additional test; due to the possibility for multiple key presses
                        return 0;                           // sometimes the keyboard doesn't properly read the the initial input methods
                    else 
                        return 1;                            
                }
            }
            
            return new byte[]
            {
                IsKeyPressed(KeyCode.A),
                IsKeyPressed(KeyCode.S),
                IsKeyPressed(KeyCode.D),
                IsKeyPressed(KeyCode.F),
                IsKeyPressed(KeyCode.H),
                IsKeyPressed(KeyCode.J),
                IsKeyPressed(KeyCode.K),
                IsKeyPressed(KeyCode.L)
            };
        }
        private static byte[] PianoOutput()
        {
            return MidiKeysPressed();
        }
        private static byte[] LaunchpadOutput()
        {
            return MidiKeysPressed();
        }
        private static byte[] MidiKeysPressed()
        {
            input = lastInput;
            while (MidiDriver.Instance.History.Count > 0)
            {
                var midiMessge = MidiDriver.Instance.History.Dequeue();
                for (int i = 0; i < Constants.KEY_LENGTH; i++)
                {
                    if (midiMessge.data1 == (lowestButtonID + i))
                    {
                        if (midiMessge.data2 > 0)
                            input[i] = 1;
                        else
                            input[i] = 0;
                    }
                }
            }
            
            lastInput = input;
            return input;
        }
    }
}
