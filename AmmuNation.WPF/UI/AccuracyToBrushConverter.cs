// <copyright file="AccuracyToBrushConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WPF.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;
    using System.Windows.Media;

    /// <summary>
    /// Accuracy to brush color converter class.
    /// </summary>
    public class AccuracyToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Returns a color by accuracy.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="targetType">targetType.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture.</param>
        /// <returns>Brushes color.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int accuracy = (int)value;

            if (accuracy >= 80)
            {
                return Brushes.LightGreen;
            }
            else if (accuracy <= 50)
            {
                return Brushes.Salmon;
            }
            else
            {
                return Brushes.LightYellow;
            }
        }

        /// <summary>
        /// Backward converter.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="targetType">targettype.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture.</param>
        /// <returns>Nothing.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
