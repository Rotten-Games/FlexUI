using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RottenGames.FlexUI
{
    /// <summary>
    /// Base class for game screens/views. Extend this to create menu screens, HUDs, etc.
    /// </summary>
    public abstract class FlexScreen
    {
        public VisualElement Root { get; private set; }
        public bool IsVisible => Root?.style.display == DisplayStyle.Flex;

        protected FlexScreen()
        {
            Root = new VisualElement();
            Root.style.position = Position.Absolute;
            Root.style.top = 0;
            Root.style.right = 0;
            Root.style.bottom = 0;
            Root.style.left = 0;
            Root.style.display = DisplayStyle.None;
            Root.AddToClassList("flex-screen");
        }

        /// <summary>
        /// Override to build your UI.
        /// </summary>
        protected abstract VisualElement Build();

        /// <summary>
        /// Initializes the screen. Call this once after construction.
        /// </summary>
        public void Initialize()
        {
            var content = Build();
            if (content != null)
                Root.Add(content);
            OnInitialized();
        }

        /// <summary>
        /// Called after Initialize.
        /// </summary>
        protected virtual void OnInitialized() { }

        /// <summary>
        /// Shows the screen.
        /// </summary>
        public virtual void Show()
        {
            Root.style.display = DisplayStyle.Flex;
            OnShow();
        }

        /// <summary>
        /// Hides the screen.
        /// </summary>
        public virtual void Hide()
        {
            Root.style.display = DisplayStyle.None;
            OnHide();
        }

        /// <summary>
        /// Toggles visibility.
        /// </summary>
        public void Toggle()
        {
            if (IsVisible)
                Hide();
            else
                Show();
        }

        /// <summary>
        /// Called when screen becomes visible.
        /// </summary>
        protected virtual void OnShow() { }

        /// <summary>
        /// Called when screen becomes hidden.
        /// </summary>
        protected virtual void OnHide() { }

        /// <summary>
        /// Override to update the screen each frame.
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Destroys the screen.
        /// </summary>
        public virtual void Destroy()
        {
            Root?.RemoveFromHierarchy();
            OnDestroy();
        }

        /// <summary>
        /// Called when the screen is destroyed.
        /// </summary>
        protected virtual void OnDestroy() { }
    }

    /// <summary>
    /// Manages multiple screens with navigation stack.
    /// </summary>
    public class FlexScreenManager
    {
        private readonly VisualElement _container;
        private readonly Dictionary<string, FlexScreen> _screens = new();
        private readonly Stack<string> _navigationStack = new();
        private string _currentScreenId;

        public FlexScreen CurrentScreen => 
            _currentScreenId != null && _screens.TryGetValue(_currentScreenId, out var screen) ? screen : null;

        public FlexScreenManager(VisualElement container)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }

        /// <summary>
        /// Registers a screen with an ID.
        /// </summary>
        public void Register(string id, FlexScreen screen)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Screen ID cannot be null or empty", nameof(id));
            if (screen == null)
                throw new ArgumentNullException(nameof(screen));

            _screens[id] = screen;
            screen.Initialize();
            _container.Add(screen.Root);
        }

        /// <summary>
        /// Registers and initializes a screen.
        /// </summary>
        public void Register<T>(string id) where T : FlexScreen, new()
        {
            Register(id, new T());
        }

        /// <summary>
        /// Shows a screen by ID.
        /// </summary>
        public void Show(string id, bool addToStack = true)
        {
            if (!_screens.TryGetValue(id, out var screen))
            {
                Debug.LogError($"FlexUI: Screen '{id}' not found");
                return;
            }

            // Hide current screen
            if (_currentScreenId != null && _screens.TryGetValue(_currentScreenId, out var current))
            {
                current.Hide();
                if (addToStack)
                    _navigationStack.Push(_currentScreenId);
            }

            _currentScreenId = id;
            screen.Show();
        }

        /// <summary>
        /// Goes back to previous screen.
        /// </summary>
        public bool GoBack()
        {
            if (_navigationStack.Count == 0)
                return false;

            var previousId = _navigationStack.Pop();
            Show(previousId, addToStack: false);
            return true;
        }

        /// <summary>
        /// Clears the navigation stack.
        /// </summary>
        public void ClearStack()
        {
            _navigationStack.Clear();
        }

        /// <summary>
        /// Gets a screen by ID.
        /// </summary>
        public FlexScreen Get(string id)
        {
            return _screens.TryGetValue(id, out var screen) ? screen : null;
        }

        /// <summary>
        /// Gets a typed screen by ID.
        /// </summary>
        public T Get<T>(string id) where T : FlexScreen
        {
            return Get(id) as T;
        }

        /// <summary>
        /// Updates all visible screens.
        /// </summary>
        public void Update()
        {
            foreach (var screen in _screens.Values)
            {
                if (screen.IsVisible)
                    screen.Update();
            }
        }

        /// <summary>
        /// Destroys all screens.
        /// </summary>
        public void DestroyAll()
        {
            foreach (var screen in _screens.Values)
                screen.Destroy();
            _screens.Clear();
            _navigationStack.Clear();
            _currentScreenId = null;
        }
    }
}
