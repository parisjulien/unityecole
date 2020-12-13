# Unity Project: Survival Adventure - Documentation - Inputs

In this project, we use the new Unity's *Input System*, a package published in a stable version since *Unity 2019.4.0*.

The inputs configuration can be found in `/Assets/_GAME/_FINAL/Inputs/GameControls.inputactions`. You can open and edit it by double-clicking on the asset, or clicking the *Edit asset* button in the inspector.

The configured actions support both keyboard and gamepad.

## Actions

- **Move**: WASD (or ZQSD on *azerty* keyboards) on keyboard, Left stick or D-Pad on gamepad
- **Fire**: Space on keyboard, left mouse button, West button (X on XBox controller, square on PS controller) or right trigger on gamepad

## Demo

See the demo directory at `/Assets/_GAME/_FINAL/Inputs/Demos`. This ddirectory contains a demo scene and a test script that shows how to use the *Input Actions*.

Open the scene, run *Play Mode*, and start testing the *Move* (keyboard arrows or gamepad left stick) and *Fire* (keyboard space or gamepad right trigger) actions.

- [`Demos_Inputs` component documentation](./demos-inputs.md)

## Relative links

[=> See the official *Input System* documentation](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/)