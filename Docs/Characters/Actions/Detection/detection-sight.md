# Unity Project: Survival Adventure - Documentation - `DetectionSight`

Detects objects in a range or/and in a sight cone.

![`DetectionSight` component inspector preview](./Images/detection-sight-inspector.jpg)

## Settings

- **Collider**: The referenced collider is used to apply *Ignore Self* option. That option won't work if set to `true` but this field is empty.
- **Sight Range**: Defines how far this entity can detect objects.
- **Sight Angle**: Defines the angle of the detection cone (in degrees).
- **Detection Origin Offset**: Defines an offset to add to this object's transform position.
- **Range Detection Layer**: Defines the layers that can be detected when checking if objects are in range. You should target only the layers that the objects to detect are on.
- **Sight Detection Layer**: Defines the layers that can be detected as "obstacles" when checking if a detected object in range is in sight. You should target all possible layers.
- **Ignore Self**: If the selected detection layers include the current object layer, this object will detect itself. If this option is set to `true`, the object won't consider itself as something in sight.

## API

### `hasSomethingInSight()`

```cs
public bool HasSomethingInSight()
```

Checks if this object has something in sight.

### `GetColliderInRange()`

```cs
public Collider GetColliderInRange()
```

Gets the first collider detected in the detection range. Note that this method doesn't check the detection angle. Also, it just gets one of the detected objects in range, which is not guaranteed to be the closest.

Returns the detected collider, otherwise `null`.

### `GetObjectInRange()`

```cs
public GameObject GetObjectInRange()
```

Gets the first `GameObject` detected in the detection range. Note that this method doesn't check the detection angle. Also, it just gets one of the detected objects in range, which is not guaranteed to be the closest.

Returns the detected `GameObject`, otherwise `null`.

### `GetAllCollidersInRange()`

```cs
public Collider[] GetAllCollidersInRange()
```

Gets all the colliders in the detection range. Note that this method doesn't check the detection angle.

Returns an array of all the detected colliders.

### `GetAllObjectsInRange()`

```cs
public GameObject[] GetAllObjectsInRange()
```

Gets all the `GameObject` in the detection range. Note that this method doesn't check the detection angle.

Returns an array of all the detected `GameObject`.

### `GetColliderInSight()`

```cs
public Collider GetColliderInSight()
```

Gets the first collider in sight (in the detection range and in the detection angle). Note that this method just gets one of the detected objects in range, which is not guaranteed to be the closest.

Returns the found collider, otherwise `null`.

### `GetObjectInSight()`

```cs
public GameObject GetObjectInSight()
```

Gets the first `GameObject` in sight (in the detection range and in the detection cone). Note that this method just gets one of the detected objects in range, which is not guaranteed to be the closest.

Returns the found `GameObject`, otherwise `null`.

### `GetAllCollidersInSight()`

```cs
public Collider[] GetAllCollidersInSight()
```

Gets all colliders in sight (in the detection range and in the detection cone).

Returns all the colliders in sight.

### `GetAllObjectsInSight()`

```cs
public GameObject[] GetAllObjectsInSight()
```

Gets all `GameObject`s in sight (in the detection range and in the detection cone).

Returns all the `GameObject`s in sight.

### `DetectionOrigin`

```cs
public Vector3 DetectionOrigin { get; }
```

Gets the detection origin point, which is this object's position + the offset (defined in *Detection Origin Offset* field).