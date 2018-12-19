// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

// DO NOT EDIT! This file was generated by CustomTasks.DependencyPropertyCodeGen
#pragma once

class NavigationViewItemProperties
{
public:
    NavigationViewItemProperties();

    void CompactPaneLength(double value);
    double CompactPaneLength();

    void HasUnrealizedChildren(bool value);
    bool HasUnrealizedChildren();

    void Icon(winrt::IconElement const& value);
    winrt::IconElement Icon();

    void IsChildSelected(bool value);
    bool IsChildSelected();

    void IsExpanded(bool value);
    bool IsExpanded();

    void MenuItems(winrt::IVector<winrt::IInspectable> const& value);
    winrt::IVector<winrt::IInspectable> MenuItems();

    void MenuItemsSource(winrt::IInspectable const& value);
    winrt::IInspectable MenuItemsSource();

    void SelectsOnInvoked(bool value);
    bool SelectsOnInvoked();

    static winrt::DependencyProperty CompactPaneLengthProperty() { return s_CompactPaneLengthProperty; }
    static winrt::DependencyProperty HasUnrealizedChildrenProperty() { return s_HasUnrealizedChildrenProperty; }
    static winrt::DependencyProperty IconProperty() { return s_IconProperty; }
    static winrt::DependencyProperty IsChildSelectedProperty() { return s_IsChildSelectedProperty; }
    static winrt::DependencyProperty IsExpandedProperty() { return s_IsExpandedProperty; }
    static winrt::DependencyProperty MenuItemsProperty() { return s_MenuItemsProperty; }
    static winrt::DependencyProperty MenuItemsSourceProperty() { return s_MenuItemsSourceProperty; }
    static winrt::DependencyProperty SelectsOnInvokedProperty() { return s_SelectsOnInvokedProperty; }

    static GlobalDependencyProperty s_CompactPaneLengthProperty;
    static GlobalDependencyProperty s_HasUnrealizedChildrenProperty;
    static GlobalDependencyProperty s_IconProperty;
    static GlobalDependencyProperty s_IsChildSelectedProperty;
    static GlobalDependencyProperty s_IsExpandedProperty;
    static GlobalDependencyProperty s_MenuItemsProperty;
    static GlobalDependencyProperty s_MenuItemsSourceProperty;
    static GlobalDependencyProperty s_SelectsOnInvokedProperty;

    static void EnsureProperties();
    static void ClearProperties();

    static void OnPropertyChanged(
        winrt::DependencyObject const& sender,
        winrt::DependencyPropertyChangedEventArgs const& args);
};
