using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Extension methods that add fluent styling API to any VisualElement.
    /// </summary>
    public static class VisualElementExtensions
    {
        #region Layout

        public static T WithPadding<T>(this T element, float all) where T : VisualElement
        {
            element.style.paddingTop = all;
            element.style.paddingRight = all;
            element.style.paddingBottom = all;
            element.style.paddingLeft = all;
            return element;
        }

        public static T WithPadding<T>(this T element, float vertical, float horizontal) where T : VisualElement
        {
            element.style.paddingTop = vertical;
            element.style.paddingBottom = vertical;
            element.style.paddingLeft = horizontal;
            element.style.paddingRight = horizontal;
            return element;
        }

        public static T WithMargin<T>(this T element, float all) where T : VisualElement
        {
            element.style.marginTop = all;
            element.style.marginRight = all;
            element.style.marginBottom = all;
            element.style.marginLeft = all;
            return element;
        }

        public static T WithMargin<T>(this T element, float vertical, float horizontal) where T : VisualElement
        {
            element.style.marginTop = vertical;
            element.style.marginBottom = vertical;
            element.style.marginLeft = horizontal;
            element.style.marginRight = horizontal;
            return element;
        }

        public static T WithWidth<T>(this T element, float width) where T : VisualElement
        {
            element.style.width = width;
            return element;
        }

        public static T WithWidthPercent<T>(this T element, float percent) where T : VisualElement
        {
            element.style.width = Length.Percent(percent);
            return element;
        }

        public static T WithHeight<T>(this T element, float height) where T : VisualElement
        {
            element.style.height = height;
            return element;
        }

        public static T WithHeightPercent<T>(this T element, float percent) where T : VisualElement
        {
            element.style.height = Length.Percent(percent);
            return element;
        }

        public static T WithSize<T>(this T element, float width, float height) where T : VisualElement
        {
            element.style.width = width;
            element.style.height = height;
            return element;
        }

        public static T WithMinWidth<T>(this T element, float width) where T : VisualElement
        {
            element.style.minWidth = width;
            return element;
        }

        public static T WithMaxWidth<T>(this T element, float width) where T : VisualElement
        {
            element.style.maxWidth = width;
            return element;
        }

        public static T WithMinHeight<T>(this T element, float height) where T : VisualElement
        {
            element.style.minHeight = height;
            return element;
        }

        public static T WithMaxHeight<T>(this T element, float height) where T : VisualElement
        {
            element.style.maxHeight = height;
            return element;
        }

        #endregion

        #region Flex

        public static T WithGrow<T>(this T element, float grow = 1) where T : VisualElement
        {
            element.style.flexGrow = grow;
            return element;
        }

        public static T WithShrink<T>(this T element, float shrink = 1) where T : VisualElement
        {
            element.style.flexShrink = shrink;
            return element;
        }

        public static T WithBasis<T>(this T element, float basis) where T : VisualElement
        {
            element.style.flexBasis = basis;
            return element;
        }

        public static T WithAlignSelf<T>(this T element, Align align) where T : VisualElement
        {
            element.style.alignSelf = align;
            return element;
        }

        #endregion

        #region Appearance

        public static T WithBackground<T>(this T element, Color color) where T : VisualElement
        {
            element.style.backgroundColor = color;
            return element;
        }

        public static T WithBackground<T>(this T element, string hex) where T : VisualElement
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
                element.style.backgroundColor = color;
            return element;
        }

        public static T WithRounded<T>(this T element, float radius) where T : VisualElement
        {
            element.style.borderTopLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderBottomRightRadius = radius;
            return element;
        }

        public static T WithBorder<T>(this T element, float width, Color color) where T : VisualElement
        {
            element.style.borderTopWidth = width;
            element.style.borderRightWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderLeftWidth = width;
            element.style.borderTopColor = color;
            element.style.borderRightColor = color;
            element.style.borderBottomColor = color;
            element.style.borderLeftColor = color;
            return element;
        }

        public static T WithOpacity<T>(this T element, float opacity) where T : VisualElement
        {
            element.style.opacity = opacity;
            return element;
        }

        #endregion

        #region Text Styling

        public static T WithFontSize<T>(this T element, float size) where T : VisualElement
        {
            element.style.fontSize = size;
            return element;
        }

        public static T WithTextColor<T>(this T element, Color color) where T : VisualElement
        {
            element.style.color = color;
            return element;
        }

        public static T WithTextColor<T>(this T element, string hex) where T : VisualElement
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
                element.style.color = color;
            return element;
        }

        public static T WithBold<T>(this T element) where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.Bold;
            return element;
        }

        public static T WithItalic<T>(this T element) where T : VisualElement
        {
            element.style.unityFontStyleAndWeight = FontStyle.Italic;
            return element;
        }

        public static T WithTextAlign<T>(this T element, TextAnchor anchor) where T : VisualElement
        {
            element.style.unityTextAlign = anchor;
            return element;
        }

        #endregion

        #region Position

        public static T WithAbsolute<T>(this T element) where T : VisualElement
        {
            element.style.position = Position.Absolute;
            return element;
        }

        public static T WithRelative<T>(this T element) where T : VisualElement
        {
            element.style.position = Position.Relative;
            return element;
        }

        public static T WithTop<T>(this T element, float value) where T : VisualElement
        {
            element.style.top = value;
            return element;
        }

        public static T WithRight<T>(this T element, float value) where T : VisualElement
        {
            element.style.right = value;
            return element;
        }

        public static T WithBottom<T>(this T element, float value) where T : VisualElement
        {
            element.style.bottom = value;
            return element;
        }

        public static T WithLeft<T>(this T element, float value) where T : VisualElement
        {
            element.style.left = value;
            return element;
        }

        /// <summary>
        /// Fills the parent (absolute positioned, all edges 0).
        /// </summary>
        public static T WithFill<T>(this T element) where T : VisualElement
        {
            element.style.position = Position.Absolute;
            element.style.top = 0;
            element.style.right = 0;
            element.style.bottom = 0;
            element.style.left = 0;
            return element;
        }

        #endregion

        #region Utility

        public static T WithClass<T>(this T element, string className) where T : VisualElement
        {
            element.AddToClassList(className);
            return element;
        }

        public static T WithClasses<T>(this T element, params string[] classNames) where T : VisualElement
        {
            foreach (var className in classNames)
                element.AddToClassList(className);
            return element;
        }

        public static T WithName<T>(this T element, string elementName) where T : VisualElement
        {
            element.name = elementName;
            return element;
        }

        public static T WithStyle<T>(this T element, Action<IStyle> styleAction) where T : VisualElement
        {
            styleAction?.Invoke(element.style);
            return element;
        }

        public static T WithTooltip<T>(this T element, string tooltip) where T : VisualElement
        {
            element.tooltip = tooltip;
            return element;
        }

        public static T WithVisible<T>(this T element, bool visible) where T : VisualElement
        {
            element.style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
            return element;
        }

        public static T Hidden<T>(this T element) where T : VisualElement
        {
            element.style.display = DisplayStyle.None;
            return element;
        }

        #endregion

        #region Events

        public static T OnClick<T>(this T element, Action callback) where T : VisualElement
        {
            element.RegisterCallback<ClickEvent>(evt => callback?.Invoke());
            return element;
        }

        public static T OnMouseEnter<T>(this T element, Action callback) where T : VisualElement
        {
            element.RegisterCallback<MouseEnterEvent>(evt => callback?.Invoke());
            return element;
        }

        public static T OnMouseLeave<T>(this T element, Action callback) where T : VisualElement
        {
            element.RegisterCallback<MouseLeaveEvent>(evt => callback?.Invoke());
            return element;
        }

        public static T OnFocus<T>(this T element, Action callback) where T : VisualElement
        {
            element.RegisterCallback<FocusInEvent>(evt => callback?.Invoke());
            return element;
        }

        public static T OnBlur<T>(this T element, Action callback) where T : VisualElement
        {
            element.RegisterCallback<FocusOutEvent>(evt => callback?.Invoke());
            return element;
        }

        #endregion

        #region Hierarchy

        /// <summary>
        /// Adds this element to a parent and returns this element for chaining.
        /// </summary>
        public static T AddTo<T>(this T element, VisualElement parent) where T : VisualElement
        {
            parent.Add(element);
            return element;
        }

        /// <summary>
        /// Adds a child and returns this element for chaining.
        /// </summary>
        public static T WithChild<T>(this T element, VisualElement child) where T : VisualElement
        {
            element.Add(child);
            return element;
        }

        /// <summary>
        /// Adds multiple children and returns this element for chaining.
        /// </summary>
        public static T WithChildren<T>(this T element, params VisualElement[] children) where T : VisualElement
        {
            foreach (var child in children)
            {
                if (child != null)
                    element.Add(child);
            }
            return element;
        }

        #endregion
    }
}
