using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// A wrapper around VisualElement that provides a fluent API for layout and styling.
    /// </summary>
    public class FlexContainer : VisualElement
    {
        public FlexContainer(FlexDirection direction = FlexDirection.Column, params VisualElement[] children)
        {
            style.flexDirection = direction;
            
            foreach (var child in children)
            {
                if (child != null)
                    Add(child);
            }
        }

        #region Layout

        /// <summary>
        /// Sets the gap (spacing) between children.
        /// </summary>
        public FlexContainer Gap(float gap)
        {
            // UI Toolkit doesn't have gap property directly, we simulate it
            // by adding margin to children except the first
            RegisterCallback<GeometryChangedEvent>(evt =>
            {
                for (int i = 1; i < childCount; i++)
                {
                    var child = ElementAt(i);
                    if (style.flexDirection == FlexDirection.Row || style.flexDirection == FlexDirection.RowReverse)
                        child.style.marginLeft = gap;
                    else
                        child.style.marginTop = gap;
                }
            });
            return this;
        }

        /// <summary>
        /// Sets padding on all sides.
        /// </summary>
        public FlexContainer Padding(float all)
        {
            style.paddingTop = all;
            style.paddingRight = all;
            style.paddingBottom = all;
            style.paddingLeft = all;
            return this;
        }

        /// <summary>
        /// Sets padding with individual values (top, right, bottom, left).
        /// </summary>
        public FlexContainer Padding(float top, float right, float bottom, float left)
        {
            style.paddingTop = top;
            style.paddingRight = right;
            style.paddingBottom = bottom;
            style.paddingLeft = left;
            return this;
        }

        /// <summary>
        /// Sets padding with vertical and horizontal values.
        /// </summary>
        public FlexContainer Padding(float vertical, float horizontal)
        {
            style.paddingTop = vertical;
            style.paddingBottom = vertical;
            style.paddingLeft = horizontal;
            style.paddingRight = horizontal;
            return this;
        }

        /// <summary>
        /// Sets margin on all sides.
        /// </summary>
        public FlexContainer Margin(float all)
        {
            style.marginTop = all;
            style.marginRight = all;
            style.marginBottom = all;
            style.marginLeft = all;
            return this;
        }

        /// <summary>
        /// Sets margin with individual values.
        /// </summary>
        public FlexContainer Margin(float top, float right, float bottom, float left)
        {
            style.marginTop = top;
            style.marginRight = right;
            style.marginBottom = bottom;
            style.marginLeft = left;
            return this;
        }

        /// <summary>
        /// Sets fixed width.
        /// </summary>
        public FlexContainer Width(float width)
        {
            style.width = width;
            return this;
        }

        /// <summary>
        /// Sets width as percentage.
        /// </summary>
        public FlexContainer WidthPercent(float percent)
        {
            style.width = Length.Percent(percent);
            return this;
        }

        /// <summary>
        /// Sets fixed height.
        /// </summary>
        public FlexContainer Height(float height)
        {
            style.height = height;
            return this;
        }

        /// <summary>
        /// Sets height as percentage.
        /// </summary>
        public FlexContainer HeightPercent(float percent)
        {
            style.height = Length.Percent(percent);
            return this;
        }

        /// <summary>
        /// Sets both width and height.
        /// </summary>
        public FlexContainer Size(float width, float height)
        {
            style.width = width;
            style.height = height;
            return this;
        }

        /// <summary>
        /// Sets min width.
        /// </summary>
        public FlexContainer MinWidth(float width)
        {
            style.minWidth = width;
            return this;
        }

        /// <summary>
        /// Sets max width.
        /// </summary>
        public FlexContainer MaxWidth(float width)
        {
            style.maxWidth = width;
            return this;
        }

        /// <summary>
        /// Sets min height.
        /// </summary>
        public FlexContainer MinHeight(float height)
        {
            style.minHeight = height;
            return this;
        }

        /// <summary>
        /// Sets max height.
        /// </summary>
        public FlexContainer MaxHeight(float height)
        {
            style.maxHeight = height;
            return this;
        }

        #endregion

        #region Flex Properties

        /// <summary>
        /// Sets flex-grow.
        /// </summary>
        public FlexContainer Grow(float grow = 1)
        {
            style.flexGrow = grow;
            return this;
        }

        /// <summary>
        /// Sets flex-shrink.
        /// </summary>
        public FlexContainer Shrink(float shrink = 1)
        {
            style.flexShrink = shrink;
            return this;
        }

        /// <summary>
        /// Sets flex-basis.
        /// </summary>
        public FlexContainer Basis(float basis)
        {
            style.flexBasis = basis;
            return this;
        }

        /// <summary>
        /// Sets flex-wrap.
        /// </summary>
        public FlexContainer Wrap(Wrap wrap = UnityEngine.UIElements.Wrap.Wrap)
        {
            style.flexWrap = wrap;
            return this;
        }

        #endregion

        #region Alignment

        /// <summary>
        /// Sets justify-content (main axis alignment).
        /// </summary>
        public FlexContainer Justify(Justify justify)
        {
            style.justifyContent = justify;
            return this;
        }

        /// <summary>
        /// Shorthand: justify-content: center
        /// </summary>
        public FlexContainer JustifyCenter() => Justify(UnityEngine.UIElements.Justify.Center);

        /// <summary>
        /// Shorthand: justify-content: space-between
        /// </summary>
        public FlexContainer JustifyBetween() => Justify(UnityEngine.UIElements.Justify.SpaceBetween);

        /// <summary>
        /// Shorthand: justify-content: space-around
        /// </summary>
        public FlexContainer JustifyAround() => Justify(UnityEngine.UIElements.Justify.SpaceAround);

        /// <summary>
        /// Shorthand: justify-content: flex-end
        /// </summary>
        public FlexContainer JustifyEnd() => Justify(UnityEngine.UIElements.Justify.FlexEnd);

        /// <summary>
        /// Sets align-items (cross axis alignment).
        /// </summary>
        public FlexContainer AlignItems(Align align)
        {
            style.alignItems = align;
            return this;
        }

        /// <summary>
        /// Shorthand: align-items: center
        /// </summary>
        public FlexContainer AlignCenter() => AlignItems(Align.Center);

        /// <summary>
        /// Shorthand: align-items: stretch
        /// </summary>
        public FlexContainer AlignStretch() => AlignItems(Align.Stretch);

        /// <summary>
        /// Shorthand: align-items: flex-start
        /// </summary>
        public FlexContainer AlignStart() => AlignItems(Align.FlexStart);

        /// <summary>
        /// Shorthand: align-items: flex-end
        /// </summary>
        public FlexContainer AlignEnd() => AlignItems(Align.FlexEnd);

        /// <summary>
        /// Sets align-self for this container.
        /// </summary>
        public FlexContainer AlignSelf(Align align)
        {
            style.alignSelf = align;
            return this;
        }

        /// <summary>
        /// Centers both axes (justify + align).
        /// </summary>
        public FlexContainer Center()
        {
            style.justifyContent = UnityEngine.UIElements.Justify.Center;
            style.alignItems = Align.Center;
            return this;
        }

        #endregion

        #region Background & Appearance

        /// <summary>
        /// Sets background color.
        /// </summary>
        public FlexContainer Background(Color color)
        {
            style.backgroundColor = color;
            return this;
        }

        /// <summary>
        /// Sets background color from hex string.
        /// </summary>
        public FlexContainer Background(string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out Color color))
                style.backgroundColor = color;
            return this;
        }

        /// <summary>
        /// Sets border radius on all corners.
        /// </summary>
        public FlexContainer Rounded(float radius)
        {
            style.borderTopLeftRadius = radius;
            style.borderTopRightRadius = radius;
            style.borderBottomLeftRadius = radius;
            style.borderBottomRightRadius = radius;
            return this;
        }

        /// <summary>
        /// Sets border radius with individual values.
        /// </summary>
        public FlexContainer Rounded(float topLeft, float topRight, float bottomRight, float bottomLeft)
        {
            style.borderTopLeftRadius = topLeft;
            style.borderTopRightRadius = topRight;
            style.borderBottomRightRadius = bottomRight;
            style.borderBottomLeftRadius = bottomLeft;
            return this;
        }

        /// <summary>
        /// Sets border on all sides.
        /// </summary>
        public FlexContainer Border(float width, Color color)
        {
            style.borderTopWidth = width;
            style.borderRightWidth = width;
            style.borderBottomWidth = width;
            style.borderLeftWidth = width;
            style.borderTopColor = color;
            style.borderRightColor = color;
            style.borderBottomColor = color;
            style.borderLeftColor = color;
            return this;
        }

        /// <summary>
        /// Sets opacity.
        /// </summary>
        public FlexContainer Opacity(float opacity)
        {
            style.opacity = opacity;
            return this;
        }

        /// <summary>
        /// Sets overflow behavior.
        /// </summary>
        public FlexContainer Overflow(Overflow overflow)
        {
            style.overflow = overflow;
            return this;
        }

        /// <summary>
        /// Hides overflow.
        /// </summary>
        public FlexContainer ClipOverflow() => Overflow(UnityEngine.UIElements.Overflow.Hidden);

        #endregion

        #region Position

        /// <summary>
        /// Sets position to absolute.
        /// </summary>
        public FlexContainer Absolute()
        {
            style.position = Position.Absolute;
            return this;
        }

        /// <summary>
        /// Sets position to relative.
        /// </summary>
        public FlexContainer Relative()
        {
            style.position = Position.Relative;
            return this;
        }

        /// <summary>
        /// Sets top position.
        /// </summary>
        public FlexContainer Top(float value)
        {
            style.top = value;
            return this;
        }

        /// <summary>
        /// Sets right position.
        /// </summary>
        public FlexContainer Right(float value)
        {
            style.right = value;
            return this;
        }

        /// <summary>
        /// Sets bottom position.
        /// </summary>
        public FlexContainer Bottom(float value)
        {
            style.bottom = value;
            return this;
        }

        /// <summary>
        /// Sets left position.
        /// </summary>
        public FlexContainer Left(float value)
        {
            style.left = value;
            return this;
        }

        /// <summary>
        /// Fills the parent container (absolute positioned, all edges at 0).
        /// </summary>
        public FlexContainer Fill()
        {
            style.position = Position.Absolute;
            style.top = 0;
            style.right = 0;
            style.bottom = 0;
            style.left = 0;
            return this;
        }

        #endregion

        #region Utility

        /// <summary>
        /// Adds a USS class.
        /// </summary>
        public FlexContainer Class(string className)
        {
            AddToClassList(className);
            return this;
        }

        /// <summary>
        /// Adds multiple USS classes.
        /// </summary>
        public FlexContainer Classes(params string[] classNames)
        {
            foreach (var className in classNames)
                AddToClassList(className);
            return this;
        }

        /// <summary>
        /// Sets the element name.
        /// </summary>
        public FlexContainer Name(string elementName)
        {
            name = elementName;
            return this;
        }

        /// <summary>
        /// Applies a custom style action.
        /// </summary>
        public FlexContainer Style(Action<IStyle> styleAction)
        {
            styleAction?.Invoke(style);
            return this;
        }

        /// <summary>
        /// Adds a child element.
        /// </summary>
        public FlexContainer Child(VisualElement child)
        {
            if (child != null)
                Add(child);
            return this;
        }

        /// <summary>
        /// Adds multiple child elements.
        /// </summary>
        public FlexContainer Children(params VisualElement[] children)
        {
            foreach (var child in children)
            {
                if (child != null)
                    Add(child);
            }
            return this;
        }

        /// <summary>
        /// Conditionally adds a child element.
        /// </summary>
        public FlexContainer ChildIf(bool condition, Func<VisualElement> childFactory)
        {
            if (condition && childFactory != null)
            {
                var child = childFactory();
                if (child != null)
                    Add(child);
            }
            return this;
        }

        /// <summary>
        /// Conditionally applies styling.
        /// </summary>
        public FlexContainer If(bool condition, Action<FlexContainer> action)
        {
            if (condition)
                action?.Invoke(this);
            return this;
        }

        /// <summary>
        /// Sets visibility.
        /// </summary>
        public FlexContainer Visible(bool visible)
        {
            style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
            return this;
        }

        /// <summary>
        /// Hides the element.
        /// </summary>
        public FlexContainer Hide()
        {
            style.display = DisplayStyle.None;
            return this;
        }

        /// <summary>
        /// Shows the element.
        /// </summary>
        public FlexContainer Show()
        {
            style.display = DisplayStyle.Flex;
            return this;
        }

        #endregion
    }
}
