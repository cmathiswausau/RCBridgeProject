// <copyright file="MenuManager.cs" company="MathisSystems.com">
// Copyright (c) MathisSystems.com. All rights reserved.
// </copyright>

namespace Menu
{
    using System;
    using Input;

    /// <summary>
    /// Handles user menu interaction.
    /// </summary>
    public class MenuManager
    {
        private readonly JoystickService joystickService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuManager"/> class.
        /// </summary>
        public MenuManager()
        {
            this.joystickService = new JoystickService();
        }

        /// <summary>
        /// Runs the menu loop.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Joystick Debug Menu ===");
                Console.WriteLine("1. List joysticks");
                Console.WriteLine("2. Monitor joystick (raw)");
                Console.WriteLine("3. Monitor RC values (1000–2000)");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        this.joystickService.ListJoysticks();
                        break;
                    case "2":
                        this.joystickService.MonitorJoystickRaw();
                        break;
                    case "3":
                        this.joystickService.MonitorJoystickMapped();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}