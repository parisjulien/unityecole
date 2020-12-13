# Unity Project: Survival Adventure - Documentation - `CharacterAnimatorUtility`

This utility component can be used on animated characters to play animations directly from unity events.

In the case of the movement, it also smoothes the acceleration/deceleration animation.

![`CharacterAnimatorUtility` inspector preview](./Images/character-animator-utility.jpg)

## Usage

As an example, this component is used by the Player prefab: the `StartMovement()` and `StopMovement()` methods are linked to the Player's movement component's `OnBeginMove` and `OnEndMove` events.

## Settings

- **Animator**: Reference to the `Animator` component that contains the character animations.
- **Acceleration Curve**: Defines an acceleration curve, where X represents the duration and Y represents the maximum speed ratio (between 0 and 1). Using this allow you to smooth the animation.
- **Deceleration Curve**: Defines an deceleration curve, where X represents the duration and Y represents the maximum speed ratio (between 0 and 1). Using this allow you to smooth the animation.

### Working with curves

In the case of this component, the curve makes the acceleration and deceleration operations very easy to configure. This way, tou can define how the value gradually increase or decrease along time when the player starts or ends moving.

The curves are used instead of timers. We could've use timers to define the duration of acceleration and deceleration, but the animation transition would've been linear. With curves, you have a very simple yet complete control of how the speed increases or decreases.

## API

### `StartMovement()`

```cs
public void StartMovement()
```

Makes the character accelerate.

### `StopMovement()`

```cs
public void StopMovement()
```

Makes the character decelerate.

### `SetTrigger()`

```cs
public void SetTrigger(string _TriggerName)
```

Enables the named trigger on the referenced `Animator`.

- `string _TriggerName`: The name of the trigger to enable.