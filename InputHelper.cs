using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

/// A class for helping out with input-related tasks, such as checking if a key or mouse button has been pressed.
public class InputHelper
{
    // The current and previous mouse/keyboard states.
    MouseState currentMouseState, previousMouseState;
    KeyboardState currentKeyboardState, previousKeyboardState;
    
    /// Updates the InputHelper object by retrieving the new mouse/keyboard state, and keeping the previous state as a back-up.

    public void Update(GameTime gameTime)
    {
        // update the mouse and keyboard states
        previousMouseState = currentMouseState;
        previousKeyboardState = currentKeyboardState;
        currentMouseState = Mouse.GetState();
        currentKeyboardState = Keyboard.GetState();
    }

    /// Gets the current position of the mouse cursor.
    public Vector2 MousePosition
    {
        get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
    }

    /// Returns whether or not the left mouse button has just been pressed.
    public bool MouseLeftButtonPressed()
    {
        return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
    }

    public bool KeyPressed(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
    }

    public bool KeyDown(Keys k)
    {
        return currentKeyboardState.IsKeyDown(k);
    }
}