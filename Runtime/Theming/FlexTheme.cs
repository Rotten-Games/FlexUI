using System;
using System.Collections.Generic;
using UnityEngine;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Defines a theme with colors, spacing, typography, and other design tokens.
    /// </summary>
    [CreateAssetMenu(fileName = "FlexUITheme", menuName = "FlexUI/Theme")]
    public class FlexTheme : ScriptableObject
    {
        [Header("Colors")]
        public Color primary = new Color(0.2f, 0.6f, 1f);
        public Color secondary = new Color(0.5f, 0.5f, 0.5f);
        public Color success = new Color(0.2f, 0.8f, 0.4f);
        public Color warning = new Color(1f, 0.8f, 0.2f);
        public Color danger = new Color(1f, 0.3f, 0.3f);
        
        [Header("Background Colors")]
        public Color background = new Color(0.1f, 0.1f, 0.1f);
        public Color surface = new Color(0.15f, 0.15f, 0.15f);
        public Color surfaceVariant = new Color(0.2f, 0.2f, 0.2f);
        
        [Header("Text Colors")]
        public Color textPrimary = Color.white;
        public Color textSecondary = new Color(0.7f, 0.7f, 0.7f);
        public Color textDisabled = new Color(0.4f, 0.4f, 0.4f);
        
        [Header("Border")]
        public Color border = new Color(0.3f, 0.3f, 0.3f);
        public float borderWidth = 1f;
        public float borderRadius = 4f;
        
        [Header("Spacing")]
        public float spacingXs = 4f;
        public float spacingSm = 8f;
        public float spacingMd = 16f;
        public float spacingLg = 24f;
        public float spacingXl = 32f;
        
        [Header("Typography")]
        public float fontSizeXs = 10f;
        public float fontSizeSm = 12f;
        public float fontSizeMd = 14f;
        public float fontSizeLg = 18f;
        public float fontSizeXl = 24f;
        public float fontSizeXxl = 32f;
        
        [Header("Shadows & Effects")]
        public Color shadowColor = new Color(0, 0, 0, 0.3f);
        public float shadowBlur = 8f;
        
        /// <summary>
        /// Gets spacing by size name.
        /// </summary>
        public float GetSpacing(SpacingSize size)
        {
            return size switch
            {
                SpacingSize.Xs => spacingXs,
                SpacingSize.Sm => spacingSm,
                SpacingSize.Md => spacingMd,
                SpacingSize.Lg => spacingLg,
                SpacingSize.Xl => spacingXl,
                _ => spacingMd
            };
        }
        
        /// <summary>
        /// Gets font size by size name.
        /// </summary>
        public float GetFontSize(FontSizeOption size)
        {
            return size switch
            {
                FontSizeOption.Xs => fontSizeXs,
                FontSizeOption.Sm => fontSizeSm,
                FontSizeOption.Md => fontSizeMd,
                FontSizeOption.Lg => fontSizeLg,
                FontSizeOption.Xl => fontSizeXl,
                FontSizeOption.Xxl => fontSizeXxl,
                _ => fontSizeMd
            };
        }

        /// <summary>
        /// Creates a default dark theme.
        /// </summary>
        public static FlexTheme CreateDarkTheme()
        {
            var theme = CreateInstance<FlexTheme>();
            // Default values are already dark theme
            return theme;
        }

        /// <summary>
        /// Creates a light theme.
        /// </summary>
        public static FlexTheme CreateLightTheme()
        {
            var theme = CreateInstance<FlexTheme>();
            
            theme.background = new Color(0.95f, 0.95f, 0.95f);
            theme.surface = Color.white;
            theme.surfaceVariant = new Color(0.9f, 0.9f, 0.9f);
            theme.textPrimary = new Color(0.1f, 0.1f, 0.1f);
            theme.textSecondary = new Color(0.4f, 0.4f, 0.4f);
            theme.textDisabled = new Color(0.6f, 0.6f, 0.6f);
            theme.border = new Color(0.8f, 0.8f, 0.8f);
            
            return theme;
        }
    }

    public enum SpacingSize
    {
        Xs,
        Sm,
        Md,
        Lg,
        Xl
    }

    public enum FontSizeOption
    {
        Xs,
        Sm,
        Md,
        Lg,
        Xl,
        Xxl
    }

    /// <summary>
    /// Static accessor for the current theme.
    /// </summary>
    public static class Theme
    {
        private static FlexTheme _current;
        
        /// <summary>
        /// Gets or sets the current theme. Creates a default if none set.
        /// </summary>
        public static FlexTheme Current
        {
            get
            {
                if (_current == null)
                    _current = FlexTheme.CreateDarkTheme();
                return _current;
            }
            set => _current = value;
        }

        // Color shortcuts
        public static Color Primary => Current.primary;
        public static Color Secondary => Current.secondary;
        public static Color Success => Current.success;
        public static Color Warning => Current.warning;
        public static Color Danger => Current.danger;
        public static Color Background => Current.background;
        public static Color Surface => Current.surface;
        public static Color SurfaceVariant => Current.surfaceVariant;
        public static Color TextPrimary => Current.textPrimary;
        public static Color TextSecondary => Current.textSecondary;
        public static Color TextDisabled => Current.textDisabled;
        public static Color Border => Current.border;
        
        // Spacing shortcuts
        public static float SpacingXs => Current.spacingXs;
        public static float SpacingSm => Current.spacingSm;
        public static float SpacingMd => Current.spacingMd;
        public static float SpacingLg => Current.spacingLg;
        public static float SpacingXl => Current.spacingXl;
        
        // Typography shortcuts
        public static float FontSizeXs => Current.fontSizeXs;
        public static float FontSizeSm => Current.fontSizeSm;
        public static float FontSizeMd => Current.fontSizeMd;
        public static float FontSizeLg => Current.fontSizeLg;
        public static float FontSizeXl => Current.fontSizeXl;
        public static float FontSizeXxl => Current.fontSizeXxl;
        
        // Other
        public static float BorderWidth => Current.borderWidth;
        public static float BorderRadius => Current.borderRadius;

        /// <summary>
        /// Gets spacing by size.
        /// </summary>
        public static float Spacing(SpacingSize size) => Current.GetSpacing(size);

        /// <summary>
        /// Gets font size by size.
        /// </summary>
        public static float FontSize(FontSizeOption size) => Current.GetFontSize(size);
    }
}
