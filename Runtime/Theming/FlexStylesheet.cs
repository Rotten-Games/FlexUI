using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Helper to generate USS stylesheets programmatically from a theme.
    /// </summary>
    public static class FlexStylesheet
    {
        /// <summary>
        /// Generates a complete USS stylesheet string from the current theme.
        /// Save this to a .uss file or apply via StyleSheet.
        /// </summary>
        public static string GenerateUSS(FlexTheme theme = null)
        {
            theme ??= Theme.Current;
            
            return $@"
/* FlexUI Generated Stylesheet */
/* Generated from theme: {theme.name} */

/* ===== Root & Base ===== */
.flex-root {{
    flex-grow: 1;
    background-color: {ColorToHex(theme.background)};
}}

.flex-screen {{
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
}}

/* ===== Cards & Panels ===== */
.flex-card {{
    background-color: {ColorToHex(theme.surface)};
    padding: {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
}}

.flex-panel {{
    background-color: {ColorToHex(theme.surface)};
    border-width: {theme.borderWidth}px;
    border-color: {ColorToHex(theme.border)};
    padding: {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
}}

/* ===== Buttons ===== */
.flex-btn-primary {{
    background-color: {ColorToHex(theme.primary)};
    color: white;
    padding: {theme.spacingSm}px {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
    border-width: 0;
    -unity-font-style: bold;
}}

.flex-btn-primary:hover {{
    background-color: {ColorToHex(Darken(theme.primary, 0.1f))};
}}

.flex-btn-primary:active {{
    background-color: {ColorToHex(Darken(theme.primary, 0.2f))};
}}

.flex-btn-secondary {{
    background-color: {ColorToHex(theme.secondary)};
    color: white;
    padding: {theme.spacingSm}px {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
    border-width: 0;
}}

.flex-btn-secondary:hover {{
    background-color: {ColorToHex(Darken(theme.secondary, 0.1f))};
}}

.flex-btn-outline {{
    background-color: transparent;
    color: {ColorToHex(theme.primary)};
    border-width: {theme.borderWidth}px;
    border-color: {ColorToHex(theme.primary)};
    padding: {theme.spacingSm}px {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
}}

.flex-btn-outline:hover {{
    background-color: {ColorToHex(new Color(theme.primary.r, theme.primary.g, theme.primary.b, 0.1f))};
}}

.flex-btn-danger {{
    background-color: {ColorToHex(theme.danger)};
    color: white;
    padding: {theme.spacingSm}px {theme.spacingMd}px;
    border-radius: {theme.borderRadius}px;
    border-width: 0;
}}

.flex-btn-danger:hover {{
    background-color: {ColorToHex(Darken(theme.danger, 0.1f))};
}}

/* ===== Lists ===== */
.flex-list {{
    flex-direction: column;
}}

.flex-list-item {{
    flex-direction: row;
    padding: {theme.spacingSm}px;
    background-color: {ColorToHex(theme.surface)};
    border-radius: {theme.borderRadius}px;
    align-items: center;
}}

.flex-list-item:hover {{
    background-color: {ColorToHex(theme.surfaceVariant)};
}}

/* ===== Modal ===== */
.flex-modal-overlay {{
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background-color: rgba(0, 0, 0, 0.5);
    justify-content: center;
    align-items: center;
}}

.flex-modal {{
    background-color: {ColorToHex(theme.surface)};
    padding: {theme.spacingLg}px;
    border-radius: {theme.borderRadius}px;
    min-width: 300px;
    max-width: 500px;
}}

/* ===== Form ===== */
.flex-form {{
    flex-direction: column;
}}

.flex-form-field {{
    flex-direction: column;
    margin-bottom: {theme.spacingMd}px;
}}

.flex-form-field Label {{
    font-size: {theme.fontSizeSm}px;
    color: {ColorToHex(theme.textSecondary)};
    margin-bottom: {theme.spacingXs}px;
}}

.flex-form-field TextField {{
    padding: {theme.spacingSm}px;
}}

/* ===== Header & Navigation ===== */
.flex-header {{
    flex-direction: row;
    background-color: {ColorToHex(theme.surface)};
    padding: {theme.spacingMd}px;
    align-items: center;
}}

.flex-navbar {{
    flex-direction: row;
    background-color: {ColorToHex(theme.surface)};
    padding: {theme.spacingSm}px {theme.spacingMd}px;
    align-items: center;
}}

/* ===== Badge ===== */
.flex-badge {{
    background-color: {ColorToHex(theme.primary)};
    color: white;
    padding: 2px {theme.spacingSm}px;
    border-radius: {theme.borderRadius}px;
    font-size: {theme.fontSizeXs}px;
}}

/* ===== Typography ===== */
.text-xs {{ font-size: {theme.fontSizeXs}px; }}
.text-sm {{ font-size: {theme.fontSizeSm}px; }}
.text-md {{ font-size: {theme.fontSizeMd}px; }}
.text-lg {{ font-size: {theme.fontSizeLg}px; }}
.text-xl {{ font-size: {theme.fontSizeXl}px; }}
.text-xxl {{ font-size: {theme.fontSizeXxl}px; }}

.text-primary {{ color: {ColorToHex(theme.textPrimary)}; }}
.text-secondary {{ color: {ColorToHex(theme.textSecondary)}; }}
.text-disabled {{ color: {ColorToHex(theme.textDisabled)}; }}

.text-bold {{ -unity-font-style: bold; }}
.text-italic {{ -unity-font-style: italic; }}
.text-center {{ -unity-text-align: middle-center; }}
.text-left {{ -unity-text-align: middle-left; }}
.text-right {{ -unity-text-align: middle-right; }}

/* ===== Spacing Utilities ===== */
.p-xs {{ padding: {theme.spacingXs}px; }}
.p-sm {{ padding: {theme.spacingSm}px; }}
.p-md {{ padding: {theme.spacingMd}px; }}
.p-lg {{ padding: {theme.spacingLg}px; }}
.p-xl {{ padding: {theme.spacingXl}px; }}

.m-xs {{ margin: {theme.spacingXs}px; }}
.m-sm {{ margin: {theme.spacingSm}px; }}
.m-md {{ margin: {theme.spacingMd}px; }}
.m-lg {{ margin: {theme.spacingLg}px; }}
.m-xl {{ margin: {theme.spacingXl}px; }}

/* ===== Flex Utilities ===== */
.flex-row {{ flex-direction: row; }}
.flex-column {{ flex-direction: column; }}
.flex-grow {{ flex-grow: 1; }}
.flex-shrink {{ flex-shrink: 1; }}
.flex-wrap {{ flex-wrap: wrap; }}

.justify-start {{ justify-content: flex-start; }}
.justify-center {{ justify-content: center; }}
.justify-end {{ justify-content: flex-end; }}
.justify-between {{ justify-content: space-between; }}
.justify-around {{ justify-content: space-around; }}

.align-start {{ align-items: flex-start; }}
.align-center {{ align-items: center; }}
.align-end {{ align-items: flex-end; }}
.align-stretch {{ align-items: stretch; }}

/* ===== Background Utilities ===== */
.bg-primary {{ background-color: {ColorToHex(theme.primary)}; }}
.bg-secondary {{ background-color: {ColorToHex(theme.secondary)}; }}
.bg-success {{ background-color: {ColorToHex(theme.success)}; }}
.bg-warning {{ background-color: {ColorToHex(theme.warning)}; }}
.bg-danger {{ background-color: {ColorToHex(theme.danger)}; }}
.bg-surface {{ background-color: {ColorToHex(theme.surface)}; }}
.bg-background {{ background-color: {ColorToHex(theme.background)}; }}

/* ===== Border Utilities ===== */
.rounded {{ border-radius: {theme.borderRadius}px; }}
.rounded-sm {{ border-radius: {theme.borderRadius * 0.5f}px; }}
.rounded-lg {{ border-radius: {theme.borderRadius * 2f}px; }}
.rounded-full {{ border-radius: 9999px; }}

.border {{
    border-width: {theme.borderWidth}px;
    border-color: {ColorToHex(theme.border)};
}}

/* ===== Display Utilities ===== */
.hidden {{ display: none; }}
.visible {{ display: flex; }}
";
        }

        /// <summary>
        /// Converts a Color to hex string.
        /// </summary>
        public static string ColorToHex(Color color)
        {
            return $"#{ColorUtility.ToHtmlStringRGBA(color)}";
        }

        /// <summary>
        /// Darkens a color by a factor.
        /// </summary>
        public static Color Darken(Color color, float factor)
        {
            return new Color(
                color.r * (1 - factor),
                color.g * (1 - factor),
                color.b * (1 - factor),
                color.a
            );
        }

        /// <summary>
        /// Lightens a color by a factor.
        /// </summary>
        public static Color Lighten(Color color, float factor)
        {
            return new Color(
                color.r + (1 - color.r) * factor,
                color.g + (1 - color.g) * factor,
                color.b + (1 - color.b) * factor,
                color.a
            );
        }
    }
}
