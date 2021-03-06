﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;

#if !BUILD_WINDOWS
using Scroller = Microsoft.UI.Xaml.Controls.Primitives.Scroller;
using MUXControlsTestHooks = Microsoft.UI.Private.Controls.MUXControlsTestHooks;
using MUXControlsTestHooksLoggingMessageEventArgs = Microsoft.UI.Private.Controls.MUXControlsTestHooksLoggingMessageEventArgs;
#endif

namespace MUXControlsTestApp
{
    public sealed partial class ScrollerManipulationModePage : TestPage
    {
        private List<string> fullLogs = new List<string>();

        public ScrollerManipulationModePage()
        {
            this.InitializeComponent();

            scroller0.StateChanged += Scroller_StateChanged;
            scroller1.StateChanged += Scroller_StateChanged;
        }
        private void Scroller_StateChanged(Scroller sender, object args)
        {
            if (sender == scroller0)
                txtScroller0State.Text = "scroller0 " + scroller0.State.ToString();
            else if (sender == scroller1)
                txtScroller1State.Text = "scroller1 " + scroller1.State.ToString();
        }

        private void CmbManipulationMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb == null)
                return;
            switch (cmb.Name)
            {
                case "cmbManipulationModeS1":
                    scroller1.ManipulationMode = ManipulationModeFromIndex(cmb.SelectedIndex);
                    break;
                case "cmbManipulationModeSP1":
                    stackPanel1.ManipulationMode = ManipulationModeFromIndex(cmb.SelectedIndex);
                    break;
                case "cmbManipulationModeS0":
                    scroller0.ManipulationMode = ManipulationModeFromIndex(cmb.SelectedIndex);
                    break;
                case "cmbManipulationModeSP0":
                    stackPanel0.ManipulationMode = ManipulationModeFromIndex(cmb.SelectedIndex);
                    break;
            }
        }

        private ManipulationModes ManipulationModeFromIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return ManipulationModes.System;
                case 1:
                    return ManipulationModes.None;
                case 2:
                    return ManipulationModes.TranslateX;
            }
            return ManipulationModes.All;
        }

        private void ChkLogScrollerMessages_Checked(object sender, RoutedEventArgs e)
        {
            //Turn on info and verbose logging for the Scroller type:
            MUXControlsTestHooks.SetLoggingLevelForType("Scroller", isLoggingInfoLevel: true, isLoggingVerboseLevel: true);

            MUXControlsTestHooks.LoggingMessage += MUXControlsTestHooks_LoggingMessage;
        }

        private void ChkLogScrollerMessages_Unchecked(object sender, RoutedEventArgs e)
        {
            //Turn off info and verbose logging for the Scroller type:
            MUXControlsTestHooks.SetLoggingLevelForType("Scroller", isLoggingInfoLevel: false, isLoggingVerboseLevel: false);

            MUXControlsTestHooks.LoggingMessage -= MUXControlsTestHooks_LoggingMessage;
        }

        private void MUXControlsTestHooks_LoggingMessage(object sender, MUXControlsTestHooksLoggingMessageEventArgs args)
        {
            // Cut off the terminating new line.
            string msg = args.Message.Substring(0, args.Message.Length - 1);
            string senderName = string.Empty;

            try
            {
                FrameworkElement fe = sender as FrameworkElement;

                if (fe != null)
                {
                    senderName = "s:" + fe.Name + ", ";
                }
            }
            catch
            {
            }

            if (args.IsVerboseLevel)
            {
                this.fullLogs.Add("Verbose: " + senderName + "m:" + msg);
            }
            else
            {
                this.fullLogs.Add("Info: " + senderName + "m:" + msg);
            }
        }

        private void btnGetFullLog_Click(object sender, RoutedEventArgs e)
        {
            foreach (string log in this.fullLogs)
            {
                this.cmbFullLog.Items.Add(log);
            }
        }

        private void btnClearFullLog_Click(object sender, RoutedEventArgs e)
        {
            this.fullLogs.Clear();
            this.cmbFullLog.Items.Clear();
        }
    }
}
