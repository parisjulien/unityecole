# Unity Project: Survival Adventure - Documentation - Detection

Detection components.

## Classes

- [`Detection Sight`](./detection-sight.md): Detects objects in a range or/and in a sight cone

## Demo

See the detection demo scene in `/Assets/_GAME/_FINAL/Characters/Demos/Detection`.

This scene contain 3 objects:

- the *Blue* sphere is the "detector". It has a controller that allow you to move the object in *Play Mode*. It also have a configured `DetectionSight` component that allow it to detect the *Red* sphere when it's in sight
- the *Red* sphere is just a target. For testing purposes, it's on the *UI* layer, which is the only one that the *Blue* sphere can detect in its range.
- the *Wall* cube is a static object, meant to test the sight of the *Blue* sphere

Move the *Blue* sphere by using arrow keys or a gamepad left stick. If the *Red* sphere is in sight (so, in the *Blue* sphere's detection range, and not hidden behind the wall), you will see a log that says it!