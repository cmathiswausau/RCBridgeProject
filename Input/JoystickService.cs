// <copyright file="JoystickService.cs" company="MathisSystems.com">
// Copyright (c) MathisSystems.com. All rights reserved.
// </copyright>

namespace Input
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using BusinessClasses;
    using SharpDX.DirectInput;

    /// <summary>
    /// Provides joystick interaction functionality.
    /// </summary>
    public class JoystickService
    {
        /// <summary>
        /// Lists all joystick devices.
        /// </summary>
        public void ListJoysticks()
        {
            var directInput = new DirectInput();
            var devices = new List<DeviceInstance>();

            devices.AddRange(directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices));
            devices.AddRange(directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices));

            Console.Clear();
            Console.WriteLine("=== DEVICES ===");
            Console.WriteLine();

            foreach (var device in devices)
            {
                Console.WriteLine($"Name: {device.InstanceName}");
                Console.WriteLine($"Type: {device.Type}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Monitors raw joystick values.
        /// </summary>
        public void MonitorJoystickRaw()
        {
            var joystick = this.GetFirstJoystick();

            while (true)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();

                Console.Clear();
                Console.WriteLine("=== RAW ===");
                Console.WriteLine();

                Console.WriteLine($"X: {state.X}");
                Console.WriteLine($"Y: {state.Y}");
                Console.WriteLine($"Z: {state.Z}");
                Console.WriteLine($"RotationZ: {state.RotationZ}");

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Monitors mapped RC values.
        /// </summary>
        public void MonitorJoystickMapped()
        {
            var joystick = this.GetFirstJoystick();
            var mapper = new RcMapper();

            while (true)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();

                int roll = mapper.MapAxis(state.X);
                int pitch = mapper.MapAxis(state.Y);
                int throttle = mapper.MapAxis(state.Z);
                int yaw = mapper.MapAxis(state.RotationZ);

                Console.Clear();
                Console.WriteLine("=== RC VALUES ===");
                Console.WriteLine();

                Console.WriteLine($"Roll: {roll}");
                Console.WriteLine($"Pitch: {pitch}");
                Console.WriteLine($"Throttle: {throttle}");
                Console.WriteLine($"Yaw: {yaw}");

                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// Gets the first joystick.
        /// </summary>
        private Joystick GetFirstJoystick()
        {
            var directInput = new DirectInput();
            var devices = new List<DeviceInstance>();

            devices.AddRange(directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices));
            devices.AddRange(directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices));

            if (devices.Count == 0)
            {
                throw new InvalidOperationException("No joystick found.");
            }

            var joystick = new Joystick(directInput, devices[0].InstanceGuid);
            joystick.Acquire();
            return joystick;
        }
    }
}