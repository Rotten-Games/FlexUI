using UnityEngine;
using UnityEngine.UIElements;
using RottenGames.FlexUI;

namespace RottenGames.FlexUI.Samples
{
    /// <summary>
    /// Basic example showing core FlexUI features.
    /// Attach this to a GameObject with a UIDocument component.
    /// </summary>
    public class BasicUsageExample : MonoBehaviour
    {
        private UIDocument _document;

        void Start()
        {
            _document = GetComponent<UIDocument>();
            if (_document == null)
            {
                Debug.LogError("UIDocument component required!");
                return;
            }

            BuildUI();
        }

        void BuildUI()
        {
            var root = _document.rootVisualElement;
            
            // Clear existing content
            root.Clear();
            
            // Set background
            root.style.backgroundColor = Theme.Background;

            // Build a simple menu
            var menu = Flex.Column(
                // Header
                Flex.Text("FlexUI Demo")
                    .WithFontSize(Theme.FontSizeXl)
                    .WithBold()
                    .WithTextColor(Theme.TextPrimary),
                
                Flex.Gap(Theme.SpacingLg),
                
                // Card with buttons
                FlexComponents.Card(
                    Flex.Text("Welcome to FlexUI!")
                        .WithTextColor(Theme.TextPrimary),
                    
                    Flex.Gap(Theme.SpacingMd),
                    
                    // Button row
                    Flex.Row(
                        FlexComponents.PrimaryButton("Play", () => Debug.Log("Play clicked!")),
                        FlexComponents.SecondaryButton("Settings", () => Debug.Log("Settings clicked!")),
                        FlexComponents.OutlineButton("Quit", () => Debug.Log("Quit clicked!"))
                    ).Gap(Theme.SpacingSm)
                ),
                
                Flex.Gap(Theme.SpacingMd),
                
                // Form example
                FlexComponents.CardWithHeader("Settings",
                    FlexComponents.TextField("Player Name", "", name => Debug.Log($"Name: {name}")),
                    
                    Flex.Row(
                        Flex.Text("Music Volume").WithGrow().WithTextColor(Theme.TextPrimary),
                        Flex.Slider(0, 100, 50).WithWidth(200)
                    ).AlignCenter(),
                    
                    Flex.Row(
                        Flex.Text("Sound Effects").WithGrow().WithTextColor(Theme.TextPrimary),
                        Flex.Toggle(null, true)
                    ).AlignCenter()
                ).MaxWidth(400),
                
                Flex.Gap(Theme.SpacingMd),
                
                // List example
                FlexComponents.CardWithHeader("High Scores",
                    FlexComponents.List(
                        CreateScoreItem("Player1", 10000),
                        CreateScoreItem("Player2", 8500),
                        CreateScoreItem("Player3", 7200)
                    )
                ).MaxWidth(400)
            )
            .Padding(Theme.SpacingLg)
            .Center()
            .Grow();

            root.Add(menu);
        }

        VisualElement CreateScoreItem(string name, int score)
        {
            return FlexComponents.ListItem(
                Flex.Text(name).WithGrow().WithTextColor(Theme.TextPrimary),
                FlexComponents.Badge(score.ToString("N0"), Theme.Primary)
            );
        }
    }
}
