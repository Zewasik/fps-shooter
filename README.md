# FPS Shooter Game with 3rd Person Camera View

This repository contains a simple FPS Shooter game created using Unity. Players can control a character, aim with the mouse, shoot enemies and manage their inventory. The game features animations, visual effects for guns, and a basic save system. Below, you'll find instructions on how to play the game and an overview of the project structure.

## Gameplay Instructions

- **Movement**: Use the **W**, **A**, **S**, and **D** keys to move the character.
- **Jump**: Press the **Space** key to make the character jump.
- **Run**: Hold down the **Shift** key while moving to make the character run.
- **Aim**: Move the mouse to aim the character's weapon.
- **Shoot**: Left-click to shoot the equipped weapon.
- **Switch Weapons**: Use the **Mouse Scroll** to switch between inventory items.
- **Main Menu**: The main menu allows you to start the game or exit.
- **Level UI**: If the player wins by defeating all enemies, a win screen appears. If the player dies, a lose screen appears.

## Project Structure

The project is structured as follows:

- **Animations**: Contains animation files for character movements and gun shooting.
- **Materials**: Contains material assets for the character and enemies.
- **Models**: Contains 3D models for the character and enemies.
- **Prefabs**: Contains prefabricated objects, including enemies and weapons.
- **Scripts**: Contains C# scripts that control gameplay, player interactions, and more.
- **Scenes**: Contains the main game scene and UI scenes for menus and win/lose screens.

## Used Packages

This project makes use of the following packages:

- **AI Navigation 1.1.4**: This package provides navigation functionality for AI-controlled characters. It allows enemies to navigate the game environment and detect the player's presence.

- **Input System 1.6.3**: The Input System package simplifies and centralizes input management. It enhances player controls by providing better support for various input devices and customization.

- **TextMeshPro 3.0.6**: TextMeshPro offers enhanced text rendering capabilities, including improved text appearance and support for rich text features. It's used to create visually appealing UI elements in the game.

## How to Play

1. Clone or download the repository.
2. Open the Unity project in your Unity editor (recommended version: Unity 2022.3.7f1).
3. Navigate to the **Scenes/Menu** folder and open the **MainMenu.unity** file.
4. Press the **Play** button in the Unity editor to start the game.
5. Follow the gameplay instructions to navigate, aim, shoot, switch weapons, and interact with enemies.

---

**Disclaimer:** This project is a simplified example for educational purposes and may not include all features and best practices of a fully polished game.
