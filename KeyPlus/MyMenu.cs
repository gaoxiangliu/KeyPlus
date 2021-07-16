using System;
using System.Windows.Forms;


namespace KeyboardHook01
{
    /// <summary>
    /// In this file, menu for the main form will be created and events will be handled
    /// </summary>
    partial class Form1 : Form
    {
        private MainMenu mainMenu;

        private MenuItem menuFile;
        private MenuItem fileSave;
        private MenuItem fileExit;

        private MenuItem menuMode;
        private MenuItem modeTotal;
        private MenuItem modeCurrent;
        private MenuItem modeTest;

        private MenuItem menuPreference;
        private MenuItem preferenceLanguage;
        private MenuItem languageEnglish;
        private MenuItem languageSimplifiedChinese;
        private MenuItem preferenceColor;
        private MenuItem mColorRed;
        private MenuItem mColorGreen;
        private MenuItem mColorBlue;
        private MenuItem mColorYellow;
        private MenuItem mColorCyan;
        private MenuItem mColorMagenta;
        private MenuItem mColorHalfRainbow;
        private MenuItem mColorRainbow;
        private MenuItem mColorBlackAndWhite;
        private MenuItem preferenceStayOnTop;
        private MenuItem preferenceSettings;

        private MenuItem menuSkillTests;
        private MenuItem skillWPM;
        private MenuItem skillCPS;
        private MenuItem skillSpaceTest;

        private MenuItem menuKeyAssignment;
        private MenuItem assignmentEnable;
        private MenuItem assignmentDisable;
        private MenuItem assignmentConf;

        private MenuItem menuMechanical;
        private MenuItem mechanicalMute;
        private MenuItem mechanicalCherryBlue;
        private MenuItem mechanicalCherryBrown;
        private MenuItem mechanicalCherryRed;
        private MenuItem mechanicalCherrySliver;
        private MenuItem mechanicalCherryBlack;
        private MenuItem mechanicalCherrySlientRed;
        private MenuItem mechanicalCherrySLientBlack;
        private MenuItem mechanicalCherryGreen;
        private MenuItem mechancialNovelkeysCreams;
        private MenuItem mechanicalHolyPandas;
        private MenuItem mechanicalTurquoiseTealios;
        private MenuItem mechanicalGateronBlackInks;
        private MenuItem mechanicalKailhBoxNavies;
        private MenuItem mechanicalBucklingSpring;
        private MenuItem mechanicalSKCMBlueAlps;
        private MenuItem mechanicalTopre;

        private MenuItem menuHelp;
        private MenuItem helpView;
        private MenuItem helpAbout;


        private void InitializeMenu()
        {
            mainMenu = new MainMenu();

            // file
            menuFile = mainMenu.MenuItems.Add(Language.GetText("menu_file"));
            fileSave = new MenuItem(Language.GetText("save"), new EventHandler(MenuHandlerSave));
            fileExit = new MenuItem(Language.GetText("exit"), new EventHandler(MenuHandlerExit));
            menuFile.MenuItems.Add(fileSave);
            menuFile.MenuItems.Add("-");
            menuFile.MenuItems.Add(fileExit);

            // Mode
            menuMode = mainMenu.MenuItems.Add(Language.GetText("menu_mode"));
            modeTotal = new MenuItem(Language.GetText("mode_total"), new EventHandler(MenuHandlerMode));
            modeCurrent = new MenuItem(Language.GetText("mode_current"), new EventHandler(MenuHandlerMode));
            modeTest = new MenuItem(Language.GetText("mode_test"), new EventHandler(MenuHandlerMode));
            menuMode.MenuItems.Add(modeTotal);
            menuMode.MenuItems.Add(modeCurrent);
            menuMode.MenuItems.Add(modeTest);

            // Settings
            menuPreference = mainMenu.MenuItems.Add(Language.GetText("menu_preference"));
            preferenceLanguage = new MenuItem(Language.GetText("language"));
            languageEnglish = new MenuItem(Language.GetText("english"), new EventHandler(MenuHandlerLanguage));
            languageSimplifiedChinese = new MenuItem(Language.GetText("simplified_chinese"), new EventHandler(MenuHandlerLanguage));
            mColorRed = new MenuItem(Language.GetText("red"), new EventHandler(MenuHandlerColor));
            mColorGreen = new MenuItem(Language.GetText("green"), new EventHandler(MenuHandlerColor));
            mColorBlue = new MenuItem(Language.GetText("blue"), new EventHandler(MenuHandlerColor));
            mColorYellow = new MenuItem(Language.GetText("yellow"), new EventHandler(MenuHandlerColor));
            mColorCyan = new MenuItem(Language.GetText("cyan"), new EventHandler(MenuHandlerColor));
            mColorMagenta = new MenuItem(Language.GetText("magenta"), new EventHandler(MenuHandlerColor));
            mColorHalfRainbow = new MenuItem(Language.GetText("half_rainbow"), new EventHandler(MenuHandlerColor));
            mColorRainbow = new MenuItem(Language.GetText("rainbow"), new EventHandler(MenuHandlerColor));
            mColorBlackAndWhite = new MenuItem(Language.GetText("black_and_white"), new EventHandler(MenuHandlerColor));
            preferenceColor = new MenuItem(Language.GetText("color_tone"));
            preferenceStayOnTop = new MenuItem(Language.GetText("stay_on_top"), new EventHandler(MenuHandlerTrivia));
            preferenceSettings = new MenuItem(Language.GetText("settings"), new EventHandler(MenuHandlerSettings));
            menuPreference.MenuItems.Add(preferenceLanguage);
            preferenceLanguage.MenuItems.Add(languageEnglish);
            preferenceLanguage.MenuItems.Add(languageSimplifiedChinese);
            menuPreference.MenuItems.Add(preferenceColor);
            preferenceColor.MenuItems.Add(mColorRed);
            preferenceColor.MenuItems.Add(mColorGreen);
            preferenceColor.MenuItems.Add(mColorBlue);
            preferenceColor.MenuItems.Add(mColorYellow);
            preferenceColor.MenuItems.Add(mColorCyan);
            preferenceColor.MenuItems.Add(mColorMagenta);
            preferenceColor.MenuItems.Add(mColorHalfRainbow);
            preferenceColor.MenuItems.Add(mColorRainbow);
            preferenceColor.MenuItems.Add(mColorBlackAndWhite);
            menuPreference.MenuItems.Add("-");
            menuPreference.MenuItems.Add(preferenceStayOnTop);
            menuPreference.MenuItems.Add("-");
            menuPreference.MenuItems.Add(preferenceSettings);

            // skill tests
            menuSkillTests = mainMenu.MenuItems.Add(Language.GetText("menu_skill_tests"));
            skillWPM = new MenuItem(Language.GetText("skill_wpm"), new EventHandler(MenuHandlerSkillTests));
            skillCPS = new MenuItem(Language.GetText("skill_cps"), new EventHandler(MenuHandlerSkillTests));
            skillSpaceTest = new MenuItem(Language.GetText("skill_st"), new EventHandler(MenuHandlerSkillTests));
            menuSkillTests.MenuItems.Add(skillWPM);
            menuSkillTests.MenuItems.Add(skillCPS);
            menuSkillTests.MenuItems.Add(skillSpaceTest);

            // key assignment
            menuKeyAssignment = mainMenu.MenuItems.Add(Language.GetText("menu_key_assignment"));
            assignmentEnable = new MenuItem(Language.GetText("enable"), new EventHandler(MenuHandlerKeyAssignment));
            assignmentDisable = new MenuItem(Language.GetText("disable"), new EventHandler(MenuHandlerKeyAssignment));
            assignmentConf = new MenuItem(Language.GetText("configure"), new EventHandler(MenuHandlerKeyAssignment));
            menuKeyAssignment.MenuItems.Add(assignmentEnable);
            menuKeyAssignment.MenuItems.Add(assignmentDisable);
            menuKeyAssignment.MenuItems.Add("-");
            menuKeyAssignment.MenuItems.Add(assignmentConf);

            // mechanical keyboard sound simulator
            menuMechanical = mainMenu.MenuItems.Add(Language.GetText("mechanical_simulator"));
            mechanicalMute = new MenuItem(Language.GetText("mute"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherryBlue = new MenuItem(Language.GetText("cherry_mx_blue"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherryBrown = new MenuItem(Language.GetText("cherry_mx_brown"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherryRed = new MenuItem(Language.GetText("cherry_mx_red"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherrySliver = new MenuItem(Language.GetText("cherry_mx_sliver"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherryBlack = new MenuItem(Language.GetText("cherry_mx_black"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherrySlientRed = new MenuItem(Language.GetText("cherry_mx_slient_red"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherrySLientBlack = new MenuItem(Language.GetText("cherry_mx_slient_black"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalCherryGreen = new MenuItem(Language.GetText("cherry_mx_green"), new EventHandler(MenuHandlerMechanicalSound));
            mechancialNovelkeysCreams = new MenuItem(Language.GetText("novelkeys_creams"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalHolyPandas = new MenuItem(Language.GetText("holy_pandas"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalTurquoiseTealios = new MenuItem(Language.GetText("turquoise_tealios"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalGateronBlackInks = new MenuItem(Language.GetText("gateron_black_inks"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalKailhBoxNavies = new MenuItem(Language.GetText("kailh_box_navies"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalBucklingSpring = new MenuItem(Language.GetText("buckling_spring"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalSKCMBlueAlps = new MenuItem(Language.GetText("skcm_blue_alps"), new EventHandler(MenuHandlerMechanicalSound));
            mechanicalTopre = new MenuItem(Language.GetText("topre"), new EventHandler(MenuHandlerMechanicalSound));
            menuMechanical.MenuItems.Add(mechanicalMute);
            menuMechanical.MenuItems.Add(mechanicalCherryBlue);
            menuMechanical.MenuItems.Add(mechanicalCherryBrown);
            menuMechanical.MenuItems.Add(mechanicalCherryRed);
            menuMechanical.MenuItems.Add(mechanicalCherrySliver);
            menuMechanical.MenuItems.Add(mechanicalCherryBlack);
            menuMechanical.MenuItems.Add(mechanicalCherrySlientRed);
            menuMechanical.MenuItems.Add(mechanicalCherrySLientBlack);
            menuMechanical.MenuItems.Add(mechanicalCherryGreen);
            menuMechanical.MenuItems.Add(mechancialNovelkeysCreams);
            menuMechanical.MenuItems.Add(mechanicalHolyPandas);
            menuMechanical.MenuItems.Add(mechanicalTurquoiseTealios);
            menuMechanical.MenuItems.Add(mechanicalGateronBlackInks);
            menuMechanical.MenuItems.Add(mechanicalKailhBoxNavies);
            menuMechanical.MenuItems.Add(mechanicalBucklingSpring);
            menuMechanical.MenuItems.Add(mechanicalSKCMBlueAlps);
            menuMechanical.MenuItems.Add(mechanicalTopre);

            // help
            menuHelp = mainMenu.MenuItems.Add(Language.GetText("menu_help"));
            helpView = new MenuItem(Language.GetText("view_help"), new EventHandler(MenuHandlerHelp));
            helpAbout = new MenuItem(Language.GetText("about"), new EventHandler(MenuHandlerHelp));
            menuHelp.MenuItems.Add(helpView);
            menuHelp.MenuItems.Add(helpAbout);

            this.Menu = mainMenu;
        }

        private void MenuHandlerColor(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == mColorRed)
            {
                Configure.colorKeystroke = 0;
            }
            else if (item == mColorGreen)
            {
                Configure.colorKeystroke = 1;
            }
            else if (item == mColorBlue)
            {
                Configure.colorKeystroke = 2;
            }
            else if (item == mColorYellow)
            {
                Configure.colorKeystroke = 3;
            }
            else if (item == mColorCyan)
            {
                Configure.colorKeystroke = 4;
            }
            else if (item == mColorMagenta)
            {
                Configure.colorKeystroke = 5;
            }
            else if (item == mColorHalfRainbow)
            {
                Configure.colorKeystroke = 6;
            }
            else if (item == mColorRainbow)
            {
                Configure.colorKeystroke = 7;
            }
            else if (item == mColorBlackAndWhite)
            {
                Configure.colorKeystroke = 8;
            }
            ShowKeystrokesGraphByCurrentMode();
            ChangeColorToneUI();
            Storage.WriteConfigurationToFile();
        }

        private void MenuHandlerMode(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == modeTotal)
            {
                Configure.mode = 0;
                ChangeModeUI();
                LoadModeUI();
                ShowKeystrokesGraphByCurrentMode();
            }
            else if (item == modeCurrent)
            {
                Configure.mode = 1;
                ChangeModeUI();
                LoadModeUI();
                ShowKeystrokesGraphByCurrentMode();
            }
            else if (item == modeTest)
            {
                Configure.mode = 2;
                ChangeModeUI();
                LoadModeUI();
                ShowKeystrokesGraphByCurrentMode();
            }
            Storage.WriteConfigurationToFile();
        }

        private void MenuHandlerTrivia(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if(item == preferenceStayOnTop)
            {
                if (preferenceStayOnTop.Checked == false)
                {
                    preferenceStayOnTop.Checked = true;
                    this.TopMost = true;
                    Configure.stayOnTop = 1;
                }
                else
                {
                    preferenceStayOnTop.Checked = false;
                    this.TopMost = false;
                    Configure.stayOnTop = 0;
                }
                Storage.WriteConfigurationToFile();
            }
        }

        private void MenuHandlerExit(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if(item == fileExit)
            {
                if (Configure.exitAfterAlert == 0)
                {
                    Application.Exit();
                }
                else
                {
                    var result = MessageBox.Show(Language.GetText("exit_alert"), Language.GetText("warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Application.Exit();
                }
            }
        }

        private void MenuHandlerSave(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if(item == fileSave)
            {
                SaveManually();
            }
        }

        private void MenuHandlerSkillTests(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if(item == skillCPS)
            {
                FormCPS formCPS = new FormCPS();
                formCPS.Show();
            }
            else if(item == skillSpaceTest)
            {
                if (formSpaceCPS == null)
                    formSpaceCPS = new FormSpaceCPS();
                formSpaceCPS.Show();
            }
            else if (item == skillWPM)
            {
                FormWPM formWMP = new FormWPM();
                formWMP.Show();
            }
        }

        private void MenuHandlerLanguage(object sender, EventArgs e)
        {
            languageEnglish.Checked = false;
            languageSimplifiedChinese.Checked = false;
            MenuItem item = (MenuItem)sender;
            if (item == languageEnglish)
            {
                Configure.language = 0;
                languageEnglish.Checked = true;
            }
            else if (item == languageSimplifiedChinese)
            {
                Configure.language = 1;
                languageSimplifiedChinese.Checked = true;
            }
            //DialogResult dialogResult = MessageBox.Show(Language.GetText("alert_reboot"), Language.GetText("info"), MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    this.Close();
            //}
            InitializeUIComponents();
            try
            {
                formSpaceCPS.Close();
                if (formStatisticsList != null)
                {
                    formStatisticsList.LoadLanguage();
                    formStatisticsList.InitializeStatisticsList();
                    formStatisticsList.RefreshStatisticsList();
                }
                formKeyAssignment.Close();
                formSettings.Close();
            }
            catch { }
            formSpaceCPS = new FormSpaceCPS();
            formKeyAssignment = new FormKeyAssignment();
            formSettings = new FormSettings(this);
            Storage.WriteConfigurationToFile();
        }

        private void MenuHandlerKeyAssignment(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == assignmentConf)
            {
                if (formKeyAssignment == null)
                    formKeyAssignment = new FormKeyAssignment();
                if (!FormKeyAssignment.open)
                    formKeyAssignment.RefreshList();
                formKeyAssignment.Show();
                FormKeyAssignment.open = true;
            }
            else if (item == assignmentEnable)
            {
                assignmentEnable.Checked = true;
                assignmentDisable.Checked = false;
                Configure.enableKeyAssignment = 1;
            }
            else if (item == assignmentDisable)
            {
                assignmentEnable.Checked = false;
                assignmentDisable.Checked = true;
                Configure.enableKeyAssignment = 0;
            }
            Storage.WriteConfigurationToFile();
        }
        private void MenuHandlerSettings(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == preferenceSettings)
            {
                if (formSettings == null)
                {
                    formSettings = new FormSettings(this);
                }
                formSettings.Show();
            }
        }

        private void MenuHandlerMechanicalSound(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == mechanicalMute)
            {
                Configure.mechanicalSound = 0;
            }
            else if (item == mechanicalCherryBlue)
            {
                Configure.mechanicalSound = 1;
            }
            else if (item == mechanicalCherryBrown)
            {
                Configure.mechanicalSound = 2;
            }
            else if (item == mechanicalCherryRed)
            {
                Configure.mechanicalSound = 3;
            }
            else if (item == mechanicalCherrySliver)
            {
                Configure.mechanicalSound = 4;
            }
            else if (item == mechanicalCherryBlack)
            {
                Configure.mechanicalSound = 5;
            }
            else if (item == mechanicalCherrySlientRed)
            {
                Configure.mechanicalSound = 6;
            }
            else if (item == mechanicalCherrySLientBlack)
            {
                Configure.mechanicalSound = 7;
            }
            else if (item == mechanicalCherryGreen)
            {
                Configure.mechanicalSound = 8;
            }
            else if (item == mechancialNovelkeysCreams)
            {
                Configure.mechanicalSound = 9;
            }
            else if (item == mechanicalHolyPandas)
            {
                Configure.mechanicalSound = 10;
            }
            else if (item == mechanicalTurquoiseTealios)
            {
                Configure.mechanicalSound = 11;
            }
            else if (item == mechanicalGateronBlackInks)
            {
                Configure.mechanicalSound = 12;
            }
            else if (item == mechanicalKailhBoxNavies)
            {
                Configure.mechanicalSound = 13;
            }
            else if (item == mechanicalBucklingSpring)
            {
                Configure.mechanicalSound = 14;
            }
            else if (item == mechanicalSKCMBlueAlps)
            {
                Configure.mechanicalSound = 15;
            }
            else if (item == mechanicalTopre)
            {
                Configure.mechanicalSound = 16;
            }
            Storage.WriteConfigurationToFile();
            LoadMechanicalSimulatorUI();
        }

        private void MenuHandlerHelp(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == helpAbout)
            {
                if (formAbout == null)
                    formAbout = new FormAbout();
                formAbout.Show();
            }
            else if (item == helpView)
            {
                if (formHelp == null)
                    formHelp = new FormHelp();
                formHelp.Show();
            }
        }
    }
}
