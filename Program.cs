// <copyright file="Program.cs" company="MathisSystems.com">
// Copyright (c) MathisSystems.com. All rights reserved.
// </copyright>

namespace RCBridgeProject
{
    using Menu;

    /// <summary>
    /// Entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            var menu = new MenuManager();
            menu.Run();
        }
    }
}