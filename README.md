# FlexUI

A simplified, declarative API for Unity UI Toolkit. Build UI faster with intuitive builders, theming, and common patterns.

## Requirements

- Unity 6 (6000.0+)

## Installation

### Via Git URL (Recommended)

1. Open Window > Package Manager
2. Click "+" > "Add package from git URL..."
3. Enter: `https://github.com/rottengames/flexui.git`

### Via Local Folder

1. Clone/download this repository
2. Open Window > Package Manager
3. Click "+" > "Add package from disk..."
4. Select the `package.json` file

## Quick Start

```csharp
using RottenGames.FlexUI;
using UnityEngine.UIElements;

public class MyUI : MonoBehaviour
{
    void Start()
    {
        var doc = GetComponent<UIDocument>();
        var root = doc.rootVisualElement;

        // Build UI declaratively
        root.Add(
            Flex.Column(
                Flex.Text("Hello FlexUI!").WithFontSize(24).WithBold(),
                Flex.Gap(16),
                Flex.Row(
                    FlexComponents.PrimaryButton("Click Me", () => Debug.Log("Clicked!")),
                    FlexComponents.SecondaryButton("Cancel")
                ).Gap(8)
            )
            .Padding(24)
            .Center()
        );
    }
}
```

## Core API

### Layout Containers

```csharp
// Vertical layout (column)
Flex.Column(child1, child2, child3)

// Horizontal layout (row)
Flex.Row(child1, child2, child3)

// Generic container
Flex.Container(children)

// Scrollable container
Flex.Scroll(ScrollViewMode.Vertical, children)
```

### Basic Controls

```csharp
Flex.Text("Label text")
Flex.Button("Click me", () => { })
Flex.Input("Label", "default value")
Flex.Toggle("Enable feature", true)
Flex.Slider(0, 100, 50)
Flex.Dropdown("Choose", options, 0)
Flex.Image(texture)
Flex.Progress("Loading", 0, 100, 50)
```

### Spacing

```csharp
Flex.Spacer()      // Flexible spacer (flex-grow: 1)
Flex.Gap(16)       // Fixed size gap
Flex.Divider()     // Horizontal line
```

## FlexContainer Chainable Methods

### Layout

```csharp
.Gap(12)                    // Spacing between children
.Padding(16)                // All sides
.Padding(8, 16)             // Vertical, horizontal
.Padding(8, 16, 8, 16)      // Top, right, bottom, left
.Margin(16)                 // Same patterns as padding
.Width(200)
.WidthPercent(50)
.Height(100)
.HeightPercent(100)
.Size(200, 100)
.MinWidth(100).MaxWidth(400)
.MinHeight(50).MaxHeight(300)
```

### Flex Properties

```csharp
.Grow(1)
.Shrink(0)
.Basis(100)
.Wrap()
```

### Alignment

```csharp
.Justify(Justify.Center)
.JustifyCenter()
.JustifyBetween()
.JustifyAround()
.JustifyEnd()

.AlignItems(Align.Center)
.AlignCenter()
.AlignStretch()
.AlignStart()
.AlignEnd()

.Center()  // Centers both axes
```

### Appearance

```csharp
.Background(Color.red)
.Background("#FF5500")
.Rounded(8)
.Rounded(8, 8, 0, 0)   // Individual corners
.Border(2, Color.white)
.Opacity(0.5f)
.Overflow(Overflow.Hidden)
.ClipOverflow()
```

### Position

```csharp
.Absolute()
.Relative()
.Top(10).Right(10).Bottom(10).Left(10)
.Fill()  // Absolute + all edges 0
```

### Utility

```csharp
.Class("my-class")
.Classes("class1", "class2")
.Name("element-name")
.Style(s => s.borderWidth = 2)
.Child(element)
.Children(e1, e2, e3)
.ChildIf(condition, () => element)
.If(condition, container => container.Background(Color.red))
.Visible(true)
.Hide()
.Show()
```

## Extension Methods

All VisualElements can use extension methods:

```csharp
Flex.Text("Hello")
    .WithPadding(8)
    .WithMargin(4)
    .WithBackground(Color.blue)
    .WithRounded(4)
    .WithFontSize(18)
    .WithBold()
    .WithTextColor(Color.white)
    .OnClick(() => Debug.Log("Clicked!"));
```

## Pre-built Components

### Cards & Panels

```csharp
FlexComponents.Card(children)
FlexComponents.CardWithHeader("Title", children)
FlexComponents.Panel(children)
```

### Buttons

```csharp
FlexComponents.PrimaryButton("Text", onClick)
FlexComponents.SecondaryButton("Text", onClick)
FlexComponents.OutlineButton("Text", onClick)
FlexComponents.DangerButton("Text", onClick)
FlexComponents.ButtonGroup(btn1, btn2, btn3)
```

### Lists

```csharp
FlexComponents.List(items)
FlexComponents.ListItem(content)
FlexComponents.ListFrom(data, item => CreateElement(item))
```

### Modals

```csharp
FlexComponents.ModalOverlay(content, onBackdropClick)
FlexComponents.Modal("Title", content, actionButtons)
```

### Forms

```csharp
FlexComponents.Form(fields)
FlexComponents.FormField("Label", inputElement)
FlexComponents.TextField("Label", "placeholder", onValueChanged)
```

### Navigation

```csharp
FlexComponents.Header("Title", actionButtons)
FlexComponents.NavBar(items)
```

### Status

```csharp
FlexComponents.Badge("New", Theme.Primary)
FlexComponents.StatusIndicator("Online", StatusType.Success)
```

## Theming

### Using the Theme

```csharp
// Colors
Theme.Primary, Theme.Secondary, Theme.Success, Theme.Warning, Theme.Danger
Theme.Background, Theme.Surface, Theme.SurfaceVariant
Theme.TextPrimary, Theme.TextSecondary, Theme.TextDisabled
Theme.Border

// Spacing
Theme.SpacingXs, Theme.SpacingSm, Theme.SpacingMd, Theme.SpacingLg, Theme.SpacingXl
Theme.Spacing(SpacingSize.Md)

// Typography
Theme.FontSizeXs through Theme.FontSizeXxl
Theme.FontSize(FontSizeOption.Lg)

// Other
Theme.BorderWidth, Theme.BorderRadius
```

### Custom Theme

```csharp
// Create via ScriptableObject
[CreateAssetMenu] Create > FlexUI > Theme

// Or programmatically
var theme = FlexTheme.CreateDarkTheme();
theme.primary = new Color(0.3f, 0.7f, 1f);
Theme.Current = theme;
```

### Generate USS

```csharp
string uss = FlexStylesheet.GenerateUSS();
// Save to .uss file or apply to StyleSheet
```

## Screen Management

### Creating Screens

```csharp
public class MainMenuScreen : FlexScreen
{
    protected override VisualElement Build()
    {
        return Flex.Column(
            Flex.Text("Main Menu"),
            FlexComponents.PrimaryButton("Play", StartGame)
        ).Center();
    }

    protected override void OnShow() { }
    protected override void OnHide() { }
}
```

### Screen Manager

```csharp
var manager = new FlexScreenManager(rootElement);

// Register screens
manager.Register("main", new MainMenuScreen());
manager.Register("settings", new SettingsScreen());

// Navigate
manager.Show("main");
manager.Show("settings");  // Pushes to stack
manager.GoBack();          // Returns to main
manager.ClearStack();
```

## Best Practices

1. **Use Theme values** instead of hardcoded colors/sizes
2. **Create reusable components** for repeated patterns
3. **Use FlexScreen** for full-screen views with lifecycle
4. **Apply USS classes** for complex styling that needs hover/active states
5. **Generate USS** from theme for consistency

## Samples

Import samples from Package Manager:
- **Basic Usage** - Core features demo
- **Game Menu Example** - Complete menu with screen navigation

## License

MIT License - See LICENSE file
