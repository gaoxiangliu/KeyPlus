using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeyboardHook01
{
    partial class Form1 : Form
    {
        private static string[] colorToneSchemes;

        public void InitializeUIComponents()
        {
            InitTextsInUI();
            ChangeColorToneUI();
            LoadModeUI();
            ChangeModeUI();
            ChangeLanguageMenuUI();
            LoadRefreshModeUI();
            LoadKeepTrace();
            LoadKeyAssignmentEnable();
            LoadStayOnTopStatus();
            LoadMechanicalSimulatorUI();
            InitializePictureBoxOfLegendIndicator();
            setToolTips();
        }

        private void InitializePictureBoxOfLegendIndicator()
        {
            picIndicator.Location = lblKeyInput.Location;
            picIndicator.Size = lblKeyInput.Size;
        }

        private void InitializeColorToneShcemes()
        {
            colorToneSchemes = new string[]
            {
                Language.GetText("red"),
                Language.GetText("green"),
                Language.GetText("blue"),
                Language.GetText("yellow"),
                Language.GetText("cyan"),
                Language.GetText("magenta"),
                Language.GetText("half_rainbow"),
                Language.GetText("rainbow"),
                Language.GetText("black_and_white")
            };
        }

        /// <summary>
        /// only called once
        /// </summary>
        private void RemoveAllComponentsFocus()
        {
            radioDelayed.Enter += new EventHandler(RemoveFocus);
            radioKeyboardTest.Enter += new EventHandler(RemoveFocus);
            radioRealTime.Enter += new EventHandler(RemoveFocus);
            radioThisTime.Enter += new EventHandler(RemoveFocus);
            radioTotal.Enter += new EventHandler(RemoveFocus);
            checkKeepTrace.Enter += new EventHandler(RemoveFocus);
            btnClear.Enter += new EventHandler(RemoveFocus);
            btnStatisticsList.Enter += new EventHandler(RemoveFocus);
            btnKeyPadEnter.Enter += new EventHandler(RemoveFocus);
        }

        private void RemoveFocus(object sender, EventArgs e)
        {
            btnRemoveFocus.Focus();
        }

        /// <summary>
        /// Load text for menu and other FIXED UI
        /// </summary>
        private void InitTextsInUI()
        {
            Language.LoadTextByLanguage();

            InitializeMenu();
            CreateRightClickMenu();

            groupBoxMode.Text = Language.GetText("menu_mode");
            radioTotal.Text = Language.GetText("mode_total");
            radioThisTime.Text = Language.GetText("mode_current");
            radioKeyboardTest.Text = Language.GetText("mode_test");

            groupBoxColor.Text = Language.GetText("color_tone");

            lblKeyCode.Text = Language.GetText("key_code");
            lblKeyChar.Text = Language.GetText("key_char");
            lblKeyName.Text = Language.GetText("key_name");
            lblKeystrokeTotal.Text = Language.GetText("mode_total");
            lblKeystrokeCurrent.Text = Language.GetText("mode_current");
            groupBoxRefreshMode.Text = Language.GetText("refresh");
            radioRealTime.Text = Language.GetText("real_time");
            radioDelayed.Text = Language.GetText("delayed");
            txtGraphRefreshTip.Text = Language.GetText("tip_graph_refresh");
            btnClear.Text = Language.GetText("clear");
            btnStatisticsList.Text = Language.GetText("statistics_list");
            checkKeepTrace.Text = Language.GetText("keep_trace");

            ClearLabelText();

            InitializeColorToneShcemes();
            comboBoxColor.Items.Clear();
            comboBoxColor.Items.AddRange(colorToneSchemes);
        }

        private void ClearLabelText()
        {
            lblTextCurrentKeystrokes.Text = "";
            lblTextKeyChar.Text = "";
            lblTextKeyCode.Text = "";
            lblTextKeyName.Text = "";
            lblTextTotalKeystrokes.Text = "";
        }

        private void ChangeColorToneUI()
        {
            comboBoxColor.SelectedIndex = Configure.colorKeystroke;
            mColorRed.Checked = false;
            mColorGreen.Checked = false;
            mColorBlue.Checked = false;
            mColorYellow.Checked = false;
            mColorCyan.Checked = false;
            mColorMagenta.Checked = false;
            mColorHalfRainbow.Checked = false;
            mColorRainbow.Checked = false;
            mColorBlackAndWhite.Checked = false;
            switch (Configure.colorKeystroke)
            {
                case 0:
                    mColorRed.Checked = true;
                    break;
                case 1:
                    mColorGreen.Checked = true;
                    break;
                case 2:
                    mColorBlue.Checked = true;
                    break;
                case 3:
                    mColorYellow.Checked = true;
                    break;
                case 4:
                    mColorCyan.Checked = true;
                    break;
                case 5:
                    mColorMagenta.Checked = true;
                    break;
                case 6:
                    mColorHalfRainbow.Checked = true;
                    break;
                case 7:
                    mColorRainbow.Checked = true;
                    break;
                case 8:
                    mColorBlackAndWhite.Checked = true;
                    break;
                default:
                    break;
            }
            MyDrawColorIndicator();
        }

        private void ChangeModeUI()
        {
            modeTotal.Checked = false;
            modeCurrent.Checked = false;
            modeTest.Checked = false;
            switch (Configure.mode)
            {
                case 0:
                    //radioTotal.Checked = true;
                    modeTotal.Checked = true;
                    lblModeTips.Text = Language.GetText("mode_total_tip") + Keyboard.keyCountStartsFrom;
                    lblModeDescription.Text = Language.GetText("mode_statistics_desc");
                    btnClear.Text = Language.GetText("reset");
                    groupBoxRefreshMode.Enabled = true;
                    groupBoxColor.Enabled = true;
                    preferenceColor.Enabled = true;
                    checkKeepTrace.Enabled = false;
                    lblColorIndicator.Text = Language.GetText("color_indicator");
                    MyDrawColorIndicator();
                    break;
                case 1:
                    //radioThisTime.Checked = true;
                    modeCurrent.Checked = true;
                    lblModeTips.Text = Language.GetText("mode_current_tip") + Keyboard.keyCountCurrentStartsFrom.ToString("yyyy-MM-dd  HH:mm:ss");
                    lblModeDescription.Text = Language.GetText("mode_statistics_desc");
                    btnClear.Text = Language.GetText("reset");
                    groupBoxRefreshMode.Enabled = true;
                    groupBoxColor.Enabled = true;
                    preferenceColor.Enabled = true;
                    checkKeepTrace.Enabled = false;
                    lblColorIndicator.Text = Language.GetText("color_indicator");
                    MyDrawColorIndicator();
                    break;
                case 2:
                    //radioKeyboardTest.Checked = true;
                    modeTest.Checked = true;
                    lblModeTips.Text = Language.GetText("mode_test_tip");
                    lblModeDescription.Text = Language.GetText("mode_test_desc");
                    btnClear.Text = Language.GetText("clear");
                    groupBoxRefreshMode.Enabled = false;
                    groupBoxColor.Enabled = false;
                    preferenceColor.Enabled = false;
                    checkKeepTrace.Enabled = true;
                    lblColorIndicator.Text = Language.GetText("key_input");
                    //lblKeyInput.Text = " ";
                    //lblKeyInput.Text = "";
                    MyDrawClear();
                    break;
                default:
                    break;
            }
        }

        private void ChangeLanguageMenuUI()
        {
            languageEnglish.Checked = false;
            languageSimplifiedChinese.Checked = false;
            switch (Configure.language)
            {
                case 0:
                    languageEnglish.Checked = true;
                    break;
                case 1:
                    languageSimplifiedChinese.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void LoadRefreshModeUI()
        {
            if (Configure.refreshMode == 0)
                radioDelayed.Checked = true;
            else
                radioRealTime.Checked = true;
        }

        private void LoadModeUI()
        {
            modeTotal.Checked = false;
            modeCurrent.Checked = false;
            modeTest.Checked = false;
            switch (Configure.mode)
            {
                case 0:
                    radioTotal.Checked = true;
                    modeTotal.Checked = true;
                    break;
                case 1:
                    radioThisTime.Checked = true;
                    modeCurrent.Checked = true;
                    break;
                case 2:
                    radioKeyboardTest.Checked = true;
                    modeTest.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void LoadKeepTrace()
        {
            if (Configure.keepTrace == 1)
                checkKeepTrace.Checked = true;
            else
                checkKeepTrace.Checked = false;
        }

        private void LoadStayOnTopStatus()
        {
            if (Configure.stayOnTop == 1)
            {
                this.TopMost = true;
                preferenceStayOnTop.Checked = true;
            }
            else
            {
                this.TopMost = false;
                preferenceStayOnTop.Checked = false;
            }
        }

        private void LoadKeyAssignmentEnable()
        {
            if (Configure.enableKeyAssignment == 0)
            {
                assignmentEnable.Checked = false;
                assignmentDisable.Checked = true;
            }
            else if (Configure.enableKeyAssignment == 1)
            {
                assignmentEnable.Checked = true;
                assignmentDisable.Checked = false;
            }
        }

        private void LoadMechanicalSimulatorUI()
        {
            mechanicalMute.Checked = false;
            mechanicalCherryBlue.Checked = false;
            mechanicalCherryBrown.Checked = false;
            mechanicalCherryRed.Checked = false;
            mechanicalCherrySliver.Checked = false;
            mechanicalCherryBlack.Checked = false;
            mechanicalCherrySlientRed.Checked = false;
            mechanicalCherrySLientBlack.Checked = false;
            mechanicalCherryGreen.Checked = false;
            mechancialNovelkeysCreams.Checked = false;
            mechanicalHolyPandas.Checked = false;
            mechanicalTurquoiseTealios.Checked = false;
            mechanicalGateronBlackInks.Checked = false;
            mechanicalKailhBoxNavies.Checked = false;
            mechanicalBucklingSpring.Checked = false;
            mechanicalSKCMBlueAlps.Checked = false;
            mechanicalTopre.Checked = false;
            switch (Configure.mechanicalSound)
            {
                case 0:
                    mechanicalMute.Checked = true;
                    break;
                case 1:
                    mechanicalCherryBlue.Checked = true;
                    break;
                case 2:
                    mechanicalCherryBrown.Checked = true;
                    break;
                case 3:
                    mechanicalCherryRed.Checked = true;
                    break;
                case 4:
                    mechanicalCherrySliver.Checked = true;
                    break;
                case 5:
                    mechanicalCherryBlack.Checked = true;
                    break;
                case 6:
                    mechanicalCherrySlientRed.Checked = true;
                    break;
                case 7:
                    mechanicalCherrySLientBlack.Checked = true;
                    break;
                case 8:
                    mechanicalCherryGreen.Checked = true;
                    break;
                case 9:
                    mechancialNovelkeysCreams.Checked = true;
                    break;
                case 10:
                    mechanicalHolyPandas.Checked = true;
                    break;
                case 11:
                    mechanicalTurquoiseTealios.Checked = true;
                    break;
                case 12:
                    mechanicalGateronBlackInks.Checked = true;
                    break;
                case 13:
                    mechanicalKailhBoxNavies.Checked = true;
                    break;
                case 14:
                    mechanicalBucklingSpring.Checked = true;
                    break;
                case 15:
                    mechanicalSKCMBlueAlps.Checked = true;
                    break;
                case 16:
                    mechanicalTopre.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void ShowKeyInfo(int keyCode)
        {
            try
            {
                lblTextKeyCode.Text = keyCode.ToString() + " (0x" + keyCode.ToString("X") + ")";
                lblTextKeyChar.Text = Keyboard.keyChar[keyCode];
                lblTextKeyName.Text = Keyboard.keyName[keyCode];
                lblTextTotalKeystrokes.Text = Keyboard.keyCount[keyCode].ToString();
                lblTextCurrentKeystrokes.Text = Keyboard.keyCountCurrent[keyCode].ToString();
            }
            catch
            {
                lblTextKeyCode.Text = "";
                lblTextKeyChar.Text = "";
                lblTextKeyName.Text = "";
                lblTextTotalKeystrokes.Text = "";
                lblTextCurrentKeystrokes.Text = "";
            }
        }

        private void setToolTips()
        {
            toolTip1.SetToolTip(groupBoxRefreshMode, Language.GetText("tooltip_refresh_mode"));
            toolTip1.SetToolTip(radioDelayed, Language.GetText("tooltip_refresh_mode"));
            toolTip1.SetToolTip(radioRealTime, Language.GetText("tooltip_refresh_mode"));
            toolTip1.SetToolTip(checkKeepTrace, Language.GetText("tooltip_keep_trace"));
        }
    }
}
