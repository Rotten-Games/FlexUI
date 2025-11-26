using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Main entry point for FlexUI. Provides a declarative API for building UI Toolkit interfaces.
    /// </summary>
    public static class Flex
    {
        #region Containers

        /// <summary>
        /// Creates a horizontal row container (flex-direction: row).
        /// </summary>
        public static FlexContainer Row(params VisualElement[] children)
        {
            return new FlexContainer(FlexDirection.Row, children);
        }

        /// <summary>
        /// Creates a vertical column container (flex-direction: column).
        /// </summary>
        public static FlexContainer Column(params VisualElement[] children)
        {
            return new FlexContainer(FlexDirection.Column, children);
        }

        /// <summary>
        /// Creates a basic container with no predefined direction.
        /// </summary>
        public static FlexContainer Container(params VisualElement[] children)
        {
            return new FlexContainer(FlexDirection.Column, children);
        }

        /// <summary>
        /// Creates a scrollable container.
        /// </summary>
        public static ScrollView Scroll(ScrollViewMode mode = ScrollViewMode.Vertical, params VisualElement[] children)
        {
            var scroll = new ScrollView(mode);
            foreach (var child in children)
            {
                scroll.Add(child);
            }
            return scroll;
        }

        #endregion

        #region Controls

        /// <summary>
        /// Creates a label with optional styling.
        /// </summary>
        public static Label Text(string text, string className = null)
        {
            var label = new Label(text);
            if (!string.IsNullOrEmpty(className))
                label.AddToClassList(className);
            return label;
        }

        /// <summary>
        /// Creates a button with click handler.
        /// </summary>
        public static Button Button(string text, Action onClick = null, string className = null)
        {
            var button = new Button(onClick) { text = text };
            if (!string.IsNullOrEmpty(className))
                button.AddToClassList(className);
            return button;
        }

        /// <summary>
        /// Creates a text input field.
        /// </summary>
        public static TextField Input(string label = null, string value = "", string className = null)
        {
            var field = new TextField(label) { value = value };
            if (!string.IsNullOrEmpty(className))
                field.AddToClassList(className);
            return field;
        }

        /// <summary>
        /// Creates a toggle/checkbox.
        /// </summary>
        public static Toggle Toggle(string label = null, bool value = false, string className = null)
        {
            var toggle = new UnityEngine.UIElements.Toggle(label) { value = value };
            if (!string.IsNullOrEmpty(className))
                toggle.AddToClassList(className);
            return toggle;
        }

        /// <summary>
        /// Creates a slider.
        /// </summary>
        public static Slider Slider(float min, float max, float value = 0, string label = null, string className = null)
        {
            var slider = new Slider(label, min, max) { value = value };
            if (!string.IsNullOrEmpty(className))
                slider.AddToClassList(className);
            return slider;
        }

        /// <summary>
        /// Creates an image element.
        /// </summary>
        public static Image Image(Texture2D texture = null, Sprite sprite = null, string className = null)
        {
            var image = new Image();
            if (texture != null) image.image = texture;
            if (sprite != null) image.sprite = sprite;
            if (!string.IsNullOrEmpty(className))
                image.AddToClassList(className);
            return image;
        }

        /// <summary>
        /// Creates a dropdown field.
        /// </summary>
        public static DropdownField Dropdown(string label, System.Collections.Generic.List<string> choices, int defaultIndex = 0, string className = null)
        {
            var dropdown = new DropdownField(label, choices, defaultIndex);
            if (!string.IsNullOrEmpty(className))
                dropdown.AddToClassList(className);
            return dropdown;
        }

        /// <summary>
        /// Creates a progress bar.
        /// </summary>
        public static ProgressBar Progress(string title = null, float min = 0, float max = 100, float value = 0, string className = null)
        {
            var bar = new ProgressBar
            {
                title = title,
                lowValue = min,
                highValue = max,
                value = value
            };
            if (!string.IsNullOrEmpty(className))
                bar.AddToClassList(className);
            return bar;
        }

        /// <summary>
        /// Creates a foldout (collapsible section).
        /// </summary>
        public static Foldout Foldout(string title, bool open = true, params VisualElement[] children)
        {
            var foldout = new Foldout { text = title, value = open };
            foreach (var child in children)
            {
                foldout.Add(child);
            }
            return foldout;
        }

        #endregion

        #region Spacers

        /// <summary>
        /// Creates a flexible spacer that expands to fill available space.
        /// </summary>
        public static VisualElement Spacer()
        {
            var spacer = new VisualElement();
            spacer.style.flexGrow = 1;
            return spacer;
        }

        /// <summary>
        /// Creates a fixed-size spacer.
        /// </summary>
        public static VisualElement Gap(float size)
        {
            var gap = new VisualElement();
            gap.style.width = size;
            gap.style.height = size;
            gap.style.flexShrink = 0;
            return gap;
        }

        /// <summary>
        /// Creates a horizontal divider line.
        /// </summary>
        public static VisualElement Divider(float thickness = 1, Color? color = null)
        {
            var divider = new VisualElement();
            divider.style.height = thickness;
            divider.style.backgroundColor = color ?? new Color(0.5f, 0.5f, 0.5f, 0.5f);
            divider.style.flexShrink = 0;
            divider.style.marginTop = 4;
            divider.style.marginBottom = 4;
            return divider;
        }

        #endregion
    }
}
