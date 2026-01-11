//
// Calendrier  Copyright (C) 2026  Aptivi
//
// This file is part of Calendrier
//
// Calendrier is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Calendrier is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using Calendrier.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using SpecProbe.Software.Platform;

namespace Calendrier.Tests
{
    [TestClass]
    public sealed class CalendarTests
    {
        [TestMethod]
        [DataRow(nameof(CalendarTypes.Chinese), nameof(ChineseCalendar))]
        [DataRow(nameof(CalendarTypes.Gregorian), nameof(GregorianCalendar))]
        [DataRow(nameof(CalendarTypes.Hijri), nameof(HijriCalendar))]
        [DataRow(nameof(CalendarTypes.Japanese), nameof(JapaneseCalendar))]
        [DataRow(nameof(CalendarTypes.Persian), nameof(PersianCalendar))]
        [DataRow(nameof(CalendarTypes.SaudiHijri), nameof(SaudiHijriCalendar))]
        [DataRow(nameof(CalendarTypes.Taiwanese), nameof(TaiwaneseCalendar))]
        [DataRow(nameof(CalendarTypes.ThaiBuddhist), nameof(ThaiBuddhistCalendar))]
        [DataRow(nameof(CalendarTypes.Variant), nameof(VariantCalendar))]
        public void TestGetCalendarFromName(string calendarName, string expectedCalendarNameType)
        {
            var calendar = CalendarTools.GetCalendar(calendarName);
            calendar.GetType().Name.ShouldBe(expectedCalendarNameType);
        }

        [TestMethod]
        [DataRow(nameof(CalendarTypes.Chinese), nameof(ChineseCalendar), "zh-CN", "GregorianCalendar")]
        [DataRow(nameof(CalendarTypes.Gregorian), nameof(GregorianCalendar), "en-US", "GregorianCalendar")]
        [DataRow(nameof(CalendarTypes.Hijri), nameof(HijriCalendar), "ar", "HijriCalendar")]
        [DataRow(nameof(CalendarTypes.Japanese), nameof(JapaneseCalendar), "ja-JP", "JapaneseCalendar")]
        [DataRow(nameof(CalendarTypes.SaudiHijri), nameof(SaudiHijriCalendar), "ar-SA", "UmAlQuraCalendar")]
        [DataRow(nameof(CalendarTypes.Taiwanese), nameof(TaiwaneseCalendar), "zh-TW", "TaiwanCalendar")]
        [DataRow(nameof(CalendarTypes.ThaiBuddhist), nameof(ThaiBuddhistCalendar), "th-TH", "ThaiBuddhistCalendar")]
        public void TestGetCalendarFromNameDeep(string calendarName, string expectedCalendarNameType, string expectedCulture, string expectedCalendarType)
        {
            var calendar = CalendarTools.GetCalendar(calendarName);
            calendar.GetType().Name.ShouldBe(expectedCalendarNameType);
            calendar.Culture.Name.ShouldBe(expectedCulture == "ar" && PlatformHelper.IsRunningFromMono() ? "ar-SA" : expectedCulture);
            calendar.Calendar.GetType().Name.ShouldBe(expectedCalendarType == "HijriCalendar" && PlatformHelper.IsRunningFromMono() ? "UmAlQuraCalendar" : expectedCalendarType);
        }

        [TestMethod]
        [DataRow(CalendarTypes.Chinese, nameof(ChineseCalendar))]
        [DataRow(CalendarTypes.Gregorian, nameof(GregorianCalendar))]
        [DataRow(CalendarTypes.Hijri, nameof(HijriCalendar))]
        [DataRow(CalendarTypes.Japanese, nameof(JapaneseCalendar))]
        [DataRow(CalendarTypes.Persian, nameof(PersianCalendar))]
        [DataRow(CalendarTypes.SaudiHijri, nameof(SaudiHijriCalendar))]
        [DataRow(CalendarTypes.Taiwanese, nameof(TaiwaneseCalendar))]
        [DataRow(CalendarTypes.ThaiBuddhist, nameof(ThaiBuddhistCalendar))]
        [DataRow(CalendarTypes.Variant, nameof(VariantCalendar))]
        public void TestGetCalendarFromEnum(CalendarTypes calendarName, string expectedCalendarNameType)
        {
            var calendar = CalendarTools.GetCalendar(calendarName);
            calendar.GetType().Name.ShouldBe(expectedCalendarNameType);
        }

        [TestMethod]
        [DataRow(CalendarTypes.Chinese, nameof(ChineseCalendar), "zh-CN", "GregorianCalendar")]
        [DataRow(CalendarTypes.Gregorian, nameof(GregorianCalendar), "en-US", "GregorianCalendar")]
        [DataRow(CalendarTypes.Hijri, nameof(HijriCalendar), "ar", "HijriCalendar")]
        [DataRow(CalendarTypes.Japanese, nameof(JapaneseCalendar), "ja-JP", "JapaneseCalendar")]
        [DataRow(CalendarTypes.SaudiHijri, nameof(SaudiHijriCalendar), "ar-SA", "UmAlQuraCalendar")]
        [DataRow(CalendarTypes.Taiwanese, nameof(TaiwaneseCalendar), "zh-TW", "TaiwanCalendar")]
        [DataRow(CalendarTypes.ThaiBuddhist, nameof(ThaiBuddhistCalendar), "th-TH", "ThaiBuddhistCalendar")]
        public void TestGetCalendarFromEnumDeep(CalendarTypes calendarName, string expectedCalendarNameType, string expectedCulture, string expectedCalendarType)
        {
            var calendar = CalendarTools.GetCalendar(calendarName);
            calendar.GetType().Name.ShouldBe(expectedCalendarNameType);
            calendar.Culture.Name.ShouldBe(expectedCulture == "ar" && PlatformHelper.IsRunningFromMono() ? "ar-SA" : expectedCulture);
            calendar.Calendar.GetType().Name.ShouldBe(expectedCalendarType == "HijriCalendar" && PlatformHelper.IsRunningFromMono() ? "UmAlQuraCalendar" : expectedCalendarType);
        }

        [TestMethod]
        [DataRow(nameof(CalendarTypes.Chinese), CalendarTypes.Chinese)]
        [DataRow(nameof(CalendarTypes.Gregorian), CalendarTypes.Gregorian)]
        [DataRow(nameof(CalendarTypes.Hijri), CalendarTypes.Hijri)]
        [DataRow(nameof(CalendarTypes.Japanese), CalendarTypes.Japanese)]
        [DataRow(nameof(CalendarTypes.Persian), CalendarTypes.Persian)]
        [DataRow(nameof(CalendarTypes.SaudiHijri), CalendarTypes.SaudiHijri)]
        [DataRow(nameof(CalendarTypes.Taiwanese), CalendarTypes.Taiwanese)]
        [DataRow(nameof(CalendarTypes.ThaiBuddhist), CalendarTypes.ThaiBuddhist)]
        [DataRow(nameof(CalendarTypes.Variant), CalendarTypes.Variant)]
        public void TestGetCalendarTypeFromName(string calendarName, CalendarTypes expectedCalendarType)
        {
            var calendar = CalendarTools.GetCalendarTypeFromName(calendarName);
            calendar.ShouldBe(expectedCalendarType);
        }
    }
}
