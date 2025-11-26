using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Pre-built UI components for common patterns.
    /// </summary>
    public static class FlexComponents
    {
        #region Cards & Panels

        /// <summary>
        /// Creates a card/panel with background, padding, and rounded corners.
        /// </summary>
        public static FlexContainer Card(params VisualElement[] children)
        {
            return Flex.Column(children)
                .Background(Theme.Surface)
                .Padding(Theme.SpacingMd)
                .Rounded(Theme.BorderRadius)
                .Class("flex-card");
        }

        /// <summary>
        /// Creates a card with a header.
        /// </summary>
        public static FlexContainer CardWithHeader(string title, params VisualElement[] children)
        {
            return Flex.Column(
                Flex.Text(title)
                    .WithFontSize(Theme.FontSizeLg)
                    .WithBold()
                    .WithMargin(0, 0, Theme.SpacingSm, 0),
                Flex.Divider(),
                Flex.Column(children).Gap(Theme.SpacingSm)
            )
            .Background(Theme.Surface)
            .Padding(Theme.SpacingMd)
            .Rounded(Theme.BorderRadius)
            .Class("flex-card");
        }

        /// <summary>
        /// Creates a bordered panel.
        /// </summary>
        public static FlexContainer Panel(params VisualElement[] children)
        {
            return Flex.Column(children)
                .Background(Theme.Surface)
                .Border(Theme.BorderWidth, Theme.Border)
                .Padding(Theme.SpacingMd)
                .Rounded(Theme.BorderRadius)
                .Class("flex-panel");
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Creates a primary styled button.
        /// </summary>
        public static Button PrimaryButton(string text, Action onClick = null)
        {
            var btn = Flex.Button(text, onClick, "flex-btn-primary");
            btn.style.backgroundColor = Theme.Primary;
            btn.style.color = Color.white;
            btn.style.paddingTop = Theme.SpacingSm;
            btn.style.paddingBottom = Theme.SpacingSm;
            btn.style.paddingLeft = Theme.SpacingMd;
            btn.style.paddingRight = Theme.SpacingMd;
            btn.style.borderTopLeftRadius = Theme.BorderRadius;
            btn.style.borderTopRightRadius = Theme.BorderRadius;
            btn.style.borderBottomLeftRadius = Theme.BorderRadius;
            btn.style.borderBottomRightRadius = Theme.BorderRadius;
            return btn;
        }

        /// <summary>
        /// Creates a secondary styled button.
        /// </summary>
        public static Button SecondaryButton(string text, Action onClick = null)
        {
            var btn = Flex.Button(text, onClick, "flex-btn-secondary");
            btn.style.backgroundColor = Theme.Secondary;
            btn.style.color = Color.white;
            btn.style.paddingTop = Theme.SpacingSm;
            btn.style.paddingBottom = Theme.SpacingSm;
            btn.style.paddingLeft = Theme.SpacingMd;
            btn.style.paddingRight = Theme.SpacingMd;
            btn.style.borderTopLeftRadius = Theme.BorderRadius;
            btn.style.borderTopRightRadius = Theme.BorderRadius;
            btn.style.borderBottomLeftRadius = Theme.BorderRadius;
            btn.style.borderBottomRightRadius = Theme.BorderRadius;
            return btn;
        }

        /// <summary>
        /// Creates an outlined button.
        /// </summary>
        public static Button OutlineButton(string text, Action onClick = null)
        {
            var btn = Flex.Button(text, onClick, "flex-btn-outline");
            btn.style.backgroundColor = Color.clear;
            btn.style.borderTopWidth = Theme.BorderWidth;
            btn.style.borderRightWidth = Theme.BorderWidth;
            btn.style.borderBottomWidth = Theme.BorderWidth;
            btn.style.borderLeftWidth = Theme.BorderWidth;
            btn.style.borderTopColor = Theme.Primary;
            btn.style.borderRightColor = Theme.Primary;
            btn.style.borderBottomColor = Theme.Primary;
            btn.style.borderLeftColor = Theme.Primary;
            btn.style.color = Theme.Primary;
            btn.style.paddingTop = Theme.SpacingSm;
            btn.style.paddingBottom = Theme.SpacingSm;
            btn.style.paddingLeft = Theme.SpacingMd;
            btn.style.paddingRight = Theme.SpacingMd;
            btn.style.borderTopLeftRadius = Theme.BorderRadius;
            btn.style.borderTopRightRadius = Theme.BorderRadius;
            btn.style.borderBottomLeftRadius = Theme.BorderRadius;
            btn.style.borderBottomRightRadius = Theme.BorderRadius;
            return btn;
        }

        /// <summary>
        /// Creates a danger/destructive button.
        /// </summary>
        public static Button DangerButton(string text, Action onClick = null)
        {
            var btn = Flex.Button(text, onClick, "flex-btn-danger");
            btn.style.backgroundColor = Theme.Danger;
            btn.style.color = Color.white;
            btn.style.paddingTop = Theme.SpacingSm;
            btn.style.paddingBottom = Theme.SpacingSm;
            btn.style.paddingLeft = Theme.SpacingMd;
            btn.style.paddingRight = Theme.SpacingMd;
            btn.style.borderTopLeftRadius = Theme.BorderRadius;
            btn.style.borderTopRightRadius = Theme.BorderRadius;
            btn.style.borderBottomLeftRadius = Theme.BorderRadius;
            btn.style.borderBottomRightRadius = Theme.BorderRadius;
            return btn;
        }

        /// <summary>
        /// Creates a button group (horizontal row of buttons).
        /// </summary>
        public static FlexContainer ButtonGroup(params Button[] buttons)
        {
            return Flex.Row(buttons).Gap(Theme.SpacingSm).Class("flex-btn-group");
        }

        #endregion

        #region Lists

        /// <summary>
        /// Creates a simple vertical list.
        /// </summary>
        public static FlexContainer List(params VisualElement[] items)
        {
            return Flex.Column(items)
                .Gap(Theme.SpacingXs)
                .Class("flex-list");
        }

        /// <summary>
        /// Creates a list item with consistent styling.
        /// </summary>
        public static FlexContainer ListItem(params VisualElement[] content)
        {
            return Flex.Row(content)
                .Padding(Theme.SpacingSm)
                .AlignCenter()
                .Background(Theme.Surface)
                .Rounded(Theme.BorderRadius)
                .Class("flex-list-item");
        }

        /// <summary>
        /// Creates a list from data with a template function.
        /// </summary>
        public static FlexContainer ListFrom<T>(IEnumerable<T> items, Func<T, VisualElement> template)
        {
            var container = Flex.Column().Gap(Theme.SpacingXs).Class("flex-list");
            foreach (var item in items)
            {
                var element = template(item);
                if (element != null)
                    container.Add(element);
            }
            return container;
        }

        #endregion

        #region Modal & Overlay

        /// <summary>
        /// Creates a modal overlay (darkened background).
        /// </summary>
        public static FlexContainer ModalOverlay(VisualElement content, Action onBackdropClick = null)
        {
            var overlay = Flex.Container()
                .Fill()
                .Background(new Color(0, 0, 0, 0.5f))
                .Center()
                .Class("flex-modal-overlay");

            if (onBackdropClick != null)
            {
                overlay.RegisterCallback<ClickEvent>(evt =>
                {
                    if (evt.target == overlay)
                        onBackdropClick();
                });
            }

            if (content != null)
                overlay.Add(content);

            return overlay;
        }

        /// <summary>
        /// Creates a modal dialog.
        /// </summary>
        public static FlexContainer Modal(string title, VisualElement content, params Button[] actions)
        {
            var actionsRow = Flex.Row(actions).Gap(Theme.SpacingSm).JustifyEnd();

            return Flex.Column(
                Flex.Text(title)
                    .WithFontSize(Theme.FontSizeLg)
                    .WithBold(),
                Flex.Divider(),
                content,
                Flex.Gap(Theme.SpacingMd),
                actionsRow
            )
            .Background(Theme.Surface)
            .Padding(Theme.SpacingLg)
            .Rounded(Theme.BorderRadius)
            .MinWidth(300)
            .MaxWidth(500)
            .Class("flex-modal");
        }

        #endregion

        #region Form Elements

        /// <summary>
        /// Creates a form group with label and input.
        /// </summary>
        public static FlexContainer FormField(string label, VisualElement input)
        {
            return Flex.Column(
                Flex.Text(label)
                    .WithFontSize(Theme.FontSizeSm)
                    .WithTextColor(Theme.TextSecondary)
                    .WithMargin(0, 0, Theme.SpacingXs, 0),
                input
            ).Class("flex-form-field");
        }

        /// <summary>
        /// Creates a text input form field.
        /// </summary>
        public static FlexContainer TextField(string label, string placeholder = "", Action<string> onValueChanged = null)
        {
            var input = Flex.Input(null, "");
            input.style.paddingTop = Theme.SpacingSm;
            input.style.paddingBottom = Theme.SpacingSm;
            input.style.paddingLeft = Theme.SpacingSm;
            input.style.paddingRight = Theme.SpacingSm;

            if (onValueChanged != null)
                input.RegisterValueChangedCallback(evt => onValueChanged(evt.newValue));

            return FormField(label, input);
        }

        /// <summary>
        /// Creates a form with vertical layout and consistent spacing.
        /// </summary>
        public static FlexContainer Form(params VisualElement[] fields)
        {
            return Flex.Column(fields)
                .Gap(Theme.SpacingMd)
                .Class("flex-form");
        }

        #endregion

        #region Headers & Navigation

        /// <summary>
        /// Creates a header bar.
        /// </summary>
        public static FlexContainer Header(string title, params VisualElement[] actions)
        {
            return Flex.Row(
                Flex.Text(title)
                    .WithFontSize(Theme.FontSizeXl)
                    .WithBold()
                    .WithGrow(),
                Flex.Row(actions).Gap(Theme.SpacingSm)
            )
            .Background(Theme.Surface)
            .Padding(Theme.SpacingMd)
            .AlignCenter()
            .Class("flex-header");
        }

        /// <summary>
        /// Creates a navigation bar.
        /// </summary>
        public static FlexContainer NavBar(params VisualElement[] items)
        {
            return Flex.Row(items)
                .Gap(Theme.SpacingMd)
                .Background(Theme.Surface)
                .Padding(Theme.SpacingSm, Theme.SpacingMd)
                .AlignCenter()
                .Class("flex-navbar");
        }

        #endregion

        #region Status & Badges

        /// <summary>
        /// Creates a badge/tag.
        /// </summary>
        public static Label Badge(string text, Color? color = null)
        {
            var badge = Flex.Text(text, "flex-badge");
            badge.style.backgroundColor = color ?? Theme.Primary;
            badge.style.color = Color.white;
            badge.style.paddingTop = 2;
            badge.style.paddingBottom = 2;
            badge.style.paddingLeft = Theme.SpacingSm;
            badge.style.paddingRight = Theme.SpacingSm;
            badge.style.borderTopLeftRadius = Theme.BorderRadius;
            badge.style.borderTopRightRadius = Theme.BorderRadius;
            badge.style.borderBottomLeftRadius = Theme.BorderRadius;
            badge.style.borderBottomRightRadius = Theme.BorderRadius;
            badge.style.fontSize = Theme.FontSizeXs;
            return badge;
        }

        /// <summary>
        /// Creates a status indicator.
        /// </summary>
        public static FlexContainer StatusIndicator(string label, StatusType status)
        {
            var color = status switch
            {
                StatusType.Success => Theme.Success,
                StatusType.Warning => Theme.Warning,
                StatusType.Error => Theme.Danger,
                _ => Theme.Secondary
            };

            var dot = new VisualElement();
            dot.style.width = 8;
            dot.style.height = 8;
            dot.style.backgroundColor = color;
            dot.style.borderTopLeftRadius = 4;
            dot.style.borderTopRightRadius = 4;
            dot.style.borderBottomLeftRadius = 4;
            dot.style.borderBottomRightRadius = 4;

            return Flex.Row(dot, Flex.Text(label).WithMargin(0, 0, 0, Theme.SpacingSm))
                .AlignCenter()
                .Class("flex-status");
        }

        #endregion
    }

    public enum StatusType
    {
        Default,
        Success,
        Warning,
        Error
    }
}
