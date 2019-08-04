﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NGettext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FFXIITataruHelper
{
    public class LanguagueWrapper
    {
        Window _SettingsWindow;

        public enum Languages : int
        {
            None = 0,
            Russian = 1,
            English = 2,
            Spanish = 3,
            Polish = 4
        };

        public Languages CurrentLanguage
        {
            get { return _CurrentLanguage; }

            set
            {
                if (value != _CurrentLanguage || true)
                {
                    SetLanguague(value);

                    _CurrentLanguage = value;
                }
            }
        }

        Languages _CurrentLanguage;

        string _DirPath = GlobalSettings.LocalisationDirPath;

        public LanguagueWrapper(Window window)
        {
            _SettingsWindow = window;
            _CurrentLanguage = Languages.None;
        }

        private void SetLanguague(Languages languague)
        {
            string path = _DirPath;

            if (languague != Languages.None)
            {
                if (languague == Languages.English)
                    path += GlobalSettings.en_US_LanguaguePath;

                if (languague == Languages.Russian)
                    path += GlobalSettings.ru_RU_LanguaguePath;

                if (languague == Languages.Spanish)
                    path += GlobalSettings.es_ES_LanguaguePath;

                if (languague == Languages.Polish)
                    path += GlobalSettings.pl_PL_LanguaguePath;

                LoadDynamicTranslation(path);
            }
        }


        private void LoadDynamicTranslation(string path)
        {
            ICatalog catalog = new Catalog();
            try
            {
                var fs = File.Open(path, System.IO.FileMode.Open);
                catalog = new Catalog(fs);
                fs.Close();
                fs.Dispose();
            }
            catch (Exception e)
            {
                Logger.WriteLog(Convert.ToString(e));
            }

            _SettingsWindow.Resources["SettingsWindowName"] = catalog.GetString("Settings");
            _SettingsWindow.Resources["ChatWindowName"] = catalog.GetString("Chat Window");
            _SettingsWindow.Resources["StreamWindowName"] = catalog.GetString("Stream Chat Window");

            _SettingsWindow.Resources["DocLanguage"] = catalog.GetString("Language");
            _SettingsWindow.Resources["DocLanguageEn"] = catalog.GetString("English");
            _SettingsWindow.Resources["DocLanguageRu"] = catalog.GetString("Russian");

            _SettingsWindow.Resources["DockHelp"] = catalog.GetString("Help");

            _SettingsWindow.Resources["ChatAppearance"] = catalog.GetString("Chat Appearance");
            _SettingsWindow.Resources["TranslationSettings"] = catalog.GetString("Translation Settings");
            _SettingsWindow.Resources["GeneralBehavior"] = catalog.GetString("General Behavior");

            _SettingsWindow.Resources["FontSettings"] = catalog.GetString("Font Settings");
            _SettingsWindow.Resources["FontSize"] = catalog.GetString("Font Size");

            _SettingsWindow.Resources["FontColor"] = catalog.GetString("Font Color");
            _SettingsWindow.Resources["FontColor1"] = catalog.GetString("Color 1");
            _SettingsWindow.Resources["FontColor2"] = catalog.GetString("Color 2");

            _SettingsWindow.Resources["BackgroundColor"] = catalog.GetString("Background Color");

            _SettingsWindow.Resources["ColorPickerStandardButtonHeader"] = catalog.GetString("Standard");
            _SettingsWindow.Resources["ColorPickerAdvancedButtonHeader"] = catalog.GetString("Advanced");
            _SettingsWindow.Resources["ColorPickerAvailableColorsHeader"] = catalog.GetString("Available Colors");
            _SettingsWindow.Resources["ColorPickerStandardColorsHeader"] = catalog.GetString("Standard Colors");
            _SettingsWindow.Resources["ColorPickerRecentColorsHeader"] = catalog.GetString("Recent Colors");

            _SettingsWindow.Resources["ParagraphSettings"] = catalog.GetString("Paragraph Settings");
            _SettingsWindow.Resources["IntervalWidth"] = catalog.GetString("Interval Width");
            _SettingsWindow.Resources["LineBreakHeight"] = catalog.GetString("Line Break Height");

            _SettingsWindow.Resources["ChatCodes"] = catalog.GetString("Chat Codes");

            _SettingsWindow.Resources["TranslationEngine"] = catalog.GetString("Translation Engine");
            _SettingsWindow.Resources["FFLanguage"] = catalog.GetString("FF Language");
            _SettingsWindow.Resources["TraslateTo"] = catalog.GetString("Traslate To");

            _SettingsWindow.Resources["Hotkeys"] = catalog.GetString("Hotkeys");

            _SettingsWindow.Resources["ShowHideChatWindowHK"] = catalog.GetString("Show/hide Chat Window");
            _SettingsWindow.Resources["ShowHideChatWindowHKToolTip"] = catalog.GetString("Show Hide Chat Window Hotkey Tooltip");

            _SettingsWindow.Resources["ClickThroughHK"] = catalog.GetString("Click Through");
            _SettingsWindow.Resources["ClickThroughHKToolTip"] = catalog.GetString("Click Through HotKey ToolTip");

            _SettingsWindow.Resources["ClearChatHK"] = catalog.GetString("Clear Chat");
            _SettingsWindow.Resources["ClearChatHKToolTip"] = catalog.GetString("Clear Chat HotKey ToolTip");

            _SettingsWindow.Resources["OtherSett"] = catalog.GetString("Other");
            _SettingsWindow.Resources["ClickThroughCB"] = catalog.GetString("Click Through");
            _SettingsWindow.Resources["AlwaysOnTopCB"] = catalog.GetString("Always On Top");
            _SettingsWindow.Resources["AutoHideCB"] = catalog.GetString("Auto Hide");

            _SettingsWindow.Resources["DirectMemoryCB"] = catalog.GetString("Direct Memory Reading");
            _SettingsWindow.Resources["DirectMemoryToolTip"] = catalog.GetString("Direct Memory Reading Tooltip");

            _SettingsWindow.Resources["HideToTrayCB"] = catalog.GetString("Hide to Tray");

            _SettingsWindow.Resources["AlwaysOnTopCB"] = catalog.GetString("Always On Top");
            _SettingsWindow.Resources["HideToTrayCB"] = catalog.GetString("Hide to Tray");

            _SettingsWindow.Resources["StreamerWindowCB"] = catalog.GetString("Streamer Window");

            _SettingsWindow.Resources["ShowChatBox"] = catalog.GetString("Show Chat Window");
            _SettingsWindow.Resources["HideChatBox"] = catalog.GetString("Hide Chat Window");

            _SettingsWindow.Resources["ResetChatPosition"] = catalog.GetString("Reset Chat Position");

            _SettingsWindow.Resources["TranslationEngineError"] = catalog.GetString("Translation engine error. Consider switching to other engine.");

            _SettingsWindow.Resources["FFStatusLable"] = catalog.GetString("FF Status:");

            _SettingsWindow.Resources["FFStatusText"] = catalog.GetString("Couldn't find FFXIV process.");

            _SettingsWindow.Resources["FFStatusTextFound"] = catalog.GetString("Process found:");

            _SettingsWindow.Resources["DearPatrons"] = catalog.GetString("Dear Patrons!");
            _SettingsWindow.Resources["PatronsMsg"] = catalog.GetString("We express great appreciation");
            _SettingsWindow.Resources["PatronsThankYou"] = catalog.GetString("Thank you");

            _SettingsWindow.Resources["TranslationEngineSwitchMsg"] = catalog.GetString("Translation engine error. Switching to:");

            _SettingsWindow.Resources["CkSystem"] = catalog.GetString("System");
            _SettingsWindow.Resources["CkEcho"] = catalog.GetString("Echo");
            _SettingsWindow.Resources["CkError"] = catalog.GetString("Error");
            _SettingsWindow.Resources["CkNPCD"] = catalog.GetString("NPCD");
            _SettingsWindow.Resources["CkNPCA"] = catalog.GetString("NPCA");
            _SettingsWindow.Resources["CkRecruitment"] = catalog.GetString("Recruitment");
            _SettingsWindow.Resources["CkSay"] = catalog.GetString("Say");
            _SettingsWindow.Resources["CkShout"] = catalog.GetString("Shout");
            _SettingsWindow.Resources["CkParty"] = catalog.GetString("Party");
            _SettingsWindow.Resources["CkTell"] = catalog.GetString("Tell");
            _SettingsWindow.Resources["CkFreeCompany"] = catalog.GetString("FreeCompany");
            _SettingsWindow.Resources["CkYell"] = catalog.GetString("Yell");
            _SettingsWindow.Resources["CkAlliance"] = catalog.GetString("Alliance");
            _SettingsWindow.Resources["CkLinkShell1"] = catalog.GetString("LinkShell1");
            _SettingsWindow.Resources["CkLinkShell2"] = catalog.GetString("LinkShell2");
            _SettingsWindow.Resources["CkLinkShell3"] = catalog.GetString("LinkShell3");
            _SettingsWindow.Resources["CkLinkShell4"] = catalog.GetString("LinkShell4");
            _SettingsWindow.Resources["CkLinkShell5"] = catalog.GetString("LinkShell5");
            _SettingsWindow.Resources["CkLinkShell6"] = catalog.GetString("LinkShell6");
            _SettingsWindow.Resources["CkLinkShell7"] = catalog.GetString("LinkShell7");
            _SettingsWindow.Resources["CkLinkShell8"] = catalog.GetString("LinkShell8");
            _SettingsWindow.Resources["CkNoviceNetwork"] = catalog.GetString("NoviceNetwork");

        }
    }
}
