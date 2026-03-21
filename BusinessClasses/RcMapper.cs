// <copyright file="RcMapper.cs" company="MathisSystems.com">
// Copyright (c) MathisSystems.com. All rights reserved.
// </copyright>

namespace BusinessClasses
{
    /// <summary>
    /// Converts joystick axis values into RC channel values.
    /// </summary>
    public class RcMapper
    {
        /// <summary>
        /// Minimum RC value.
        /// </summary>
        private const int RcMin = 1000;

        /// <summary>
        /// Maximum RC value.
        /// </summary>
        private const int RcMax = 2000;

        /// <summary>
        /// Maximum joystick value.
        /// </summary>
        private const int JoystickMax = 65535;

        /// <summary>
        /// Maps a joystick axis value to RC range.
        /// </summary>
        /// <param name="value">Joystick value.</param>
        /// <returns>RC channel value.</returns>
        public int MapAxis(int value)
        {
            return RcMin + (value * (RcMax - RcMin) / JoystickMax);
        }
    }
}