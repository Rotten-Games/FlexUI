using UnityEngine;
using UnityEngine.UIElements;
using RottenGames.FlexUI;

namespace RottenGames.FlexUI.Samples
{
    /// <summary>
    /// Complete game menu example with multiple screens.
    /// </summary>
    public class GameMenuExample : MonoBehaviour
    {
        private UIDocument _document;
        private FlexScreenManager _screenManager;

        void Start()
        {
            _document = GetComponent<UIDocument>();
            if (_document == null)
            {
                Debug.LogError("UIDocument component required!");
                return;
            }

            SetupScreens();
        }

        void SetupScreens()
        {
            var root = _document.rootVisualElement;
            root.Clear();
            root.style.backgroundColor = Theme.Background;

            _screenManager = new FlexScreenManager(root);
            
            // Register screens
            _screenManager.Register("main", new MainMenuScreen(_screenManager));
            _screenManager.Register("settings", new SettingsScreen(_screenManager));
            _screenManager.Register("credits", new CreditsScreen(_screenManager));
            
            // Show main menu
            _screenManager.Show("main");
        }

        void Update()
        {
            _screenManager?.Update();
        }

        void OnDestroy()
        {
            _screenManager?.DestroyAll();
        }
    }

    #region Screens

    public class MainMenuScreen : FlexScreen
    {
        private readonly FlexScreenManager _manager;

        public MainMenuScreen(FlexScreenManager manager)
        {
            _manager = manager;
        }

        protected override VisualElement Build()
        {
            return Flex.Column(
                // Title
                Flex.Text("MY GAME")
                    .WithFontSize(48)
                    .WithBold()
                    .WithTextColor(Theme.Primary),
                
                Flex.Gap(Theme.SpacingXl),
                
                // Menu buttons
                Flex.Column(
                    CreateMenuButton("PLAY", () => Debug.Log("Starting game...")),
                    CreateMenuButton("SETTINGS", () => _manager.Show("settings")),
                    CreateMenuButton("CREDITS", () => _manager.Show("credits")),
                    CreateMenuButton("QUIT", () => Application.Quit())
                ).Gap(Theme.SpacingSm).MinWidth(250)
            )
            .Center()
            .Grow()
            .Background(Theme.Background);
        }

        private Button CreateMenuButton(string text, System.Action onClick)
        {
            var btn = FlexComponents.PrimaryButton(text, onClick);
            btn.style.width = Length.Percent(100);
            btn.style.paddingTop = Theme.SpacingMd;
            btn.style.paddingBottom = Theme.SpacingMd;
            return btn;
        }
    }

    public class SettingsScreen : FlexScreen
    {
        private readonly FlexScreenManager _manager;
        private float _musicVolume = 80;
        private float _sfxVolume = 100;
        private bool _fullscreen = true;

        public SettingsScreen(FlexScreenManager manager)
        {
            _manager = manager;
        }

        protected override VisualElement Build()
        {
            return Flex.Column(
                // Header
                FlexComponents.Header("Settings",
                    FlexComponents.OutlineButton("Back", () => _manager.GoBack())
                ),
                
                // Content
                Flex.Column(
                    // Audio section
                    FlexComponents.CardWithHeader("Audio",
                        CreateSliderRow("Music Volume", _musicVolume, v => _musicVolume = v),
                        CreateSliderRow("SFX Volume", _sfxVolume, v => _sfxVolume = v)
                    ),
                    
                    Flex.Gap(Theme.SpacingMd),
                    
                    // Video section
                    FlexComponents.CardWithHeader("Video",
                        CreateToggleRow("Fullscreen", _fullscreen, v => _fullscreen = v),
                        CreateDropdownRow("Resolution", new() { "1920x1080", "1280x720", "800x600" })
                    ),
                    
                    Flex.Gap(Theme.SpacingLg),
                    
                    // Actions
                    Flex.Row(
                        FlexComponents.SecondaryButton("Reset to Default", ResetSettings),
                        FlexComponents.PrimaryButton("Apply", ApplySettings)
                    ).Gap(Theme.SpacingSm).JustifyCenter()
                )
                .Padding(Theme.SpacingLg)
                .MaxWidth(500)
                .AlignSelf(Align.Center)
                .Grow()
            )
            .Background(Theme.Background);
        }

        private FlexContainer CreateSliderRow(string label, float value, System.Action<float> onChange)
        {
            var slider = Flex.Slider(0, 100, value);
            slider.RegisterValueChangedCallback(evt => onChange(evt.newValue));
            
            return Flex.Row(
                Flex.Text(label).WithGrow().WithTextColor(Theme.TextPrimary),
                slider.WithWidth(150)
            ).AlignCenter().Margin(0, 0, Theme.SpacingSm, 0);
        }

        private FlexContainer CreateToggleRow(string label, bool value, System.Action<bool> onChange)
        {
            var toggle = Flex.Toggle(null, value);
            toggle.RegisterValueChangedCallback(evt => onChange(evt.newValue));
            
            return Flex.Row(
                Flex.Text(label).WithGrow().WithTextColor(Theme.TextPrimary),
                toggle
            ).AlignCenter().Margin(0, 0, Theme.SpacingSm, 0);
        }

        private FlexContainer CreateDropdownRow(string label, System.Collections.Generic.List<string> options)
        {
            return Flex.Row(
                Flex.Text(label).WithGrow().WithTextColor(Theme.TextPrimary),
                Flex.Dropdown(null, options).WithWidth(150)
            ).AlignCenter().Margin(0, 0, Theme.SpacingSm, 0);
        }

        private void ResetSettings()
        {
            _musicVolume = 80;
            _sfxVolume = 100;
            _fullscreen = true;
            Debug.Log("Settings reset to default");
        }

        private void ApplySettings()
        {
            Debug.Log($"Applied: Music={_musicVolume}, SFX={_sfxVolume}, Fullscreen={_fullscreen}");
        }
    }

    public class CreditsScreen : FlexScreen
    {
        private readonly FlexScreenManager _manager;

        public CreditsScreen(FlexScreenManager manager)
        {
            _manager = manager;
        }

        protected override VisualElement Build()
        {
            return Flex.Column(
                // Header
                FlexComponents.Header("Credits",
                    FlexComponents.OutlineButton("Back", () => _manager.GoBack())
                ),
                
                // Content
                Flex.Column(
                    CreateCreditSection("Development", new[] { "Lead Developer - You", "UI Framework - FlexUI" }),
                    CreateCreditSection("Art", new[] { "Character Art - Artist Name", "Environment - Another Artist" }),
                    CreateCreditSection("Audio", new[] { "Music - Composer Name", "Sound Effects - SFX Studio" }),
                    CreateCreditSection("Special Thanks", new[] { "Unity Technologies", "The Open Source Community", "Coffee" })
                )
                .Gap(Theme.SpacingLg)
                .Padding(Theme.SpacingLg)
                .AlignItems(Align.Center)
                .Grow()
            )
            .Background(Theme.Background);
        }

        private FlexContainer CreateCreditSection(string title, string[] names)
        {
            var section = Flex.Column(
                Flex.Text(title)
                    .WithFontSize(Theme.FontSizeLg)
                    .WithBold()
                    .WithTextColor(Theme.Primary)
            ).AlignItems(Align.Center);

            foreach (var name in names)
            {
                section.Add(
                    Flex.Text(name)
                        .WithTextColor(Theme.TextSecondary)
                        .WithMargin(Theme.SpacingXs, 0, 0, 0)
                );
            }

            return section;
        }
    }

    #endregion
}
