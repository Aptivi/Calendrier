//
// Terminaux  Copyright (C) 2023-2026  Aptivi
//
// This file is part of Terminaux
//
// Terminaux is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Terminaux is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System.Globalization;
using SpecProbe.Software.Platform;
using DtfCalendar = System.Globalization.HijriCalendar;

namespace Calendrier.Types
{
    /// <summary>
    /// Hijri calendar
    /// </summary>
    public class HijriCalendar : BaseCalendar, ICalendar
    {
        /// <inheritdoc/>
        public override string Name =>
            "Hijri";

        /// <inheritdoc/>
        public override CultureInfo Culture
        {
            get
            {
                if (PlatformHelper.IsRunningFromMono())
                    return new("ar-SA");
                else
                {
                    var Cult = new CultureInfo("ar");
                    Cult.DateTimeFormat.Calendar = new DtfCalendar();
                    return Cult;
                }
            }
        }
    }
}
