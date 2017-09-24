# DisplayOrientationCtrl

This library enables you to change display orientation.
'ScreenRotateApp' project is a sample application.

# API

## Gets orientation of a target display

```cs
var displayNumber = 0;
var orientation = DisplayOrientationCtrl.API.GetCurrentDisplayOrientation(displayNumber);
```

or

```cs
var displayDeviceName = @"\\.\DISPLAY1";
var orientation = DisplayOrientationCtrl.API.GetCurrentDisplayOrientation(displayDeviceName);
```
(If orientation is null, displayNumber/displayDeviceName is not valid.)

| DisplayOrientation | Orientation |
| :---: | :---: |
| Default | 0 |
| Rotate90Degrees | 90 |
| Rotate180Degrees | 180 |
| Rotate270Degrees | 270 |

## Changes orientation

```cs
var displayNumber = 0;
DisplayOrientationCtrl.API.TryChangeOrientation(displayNumber, DisplayOrientationCtrl.DisplayOrientation.Rotate90Degrees);
```

or

```cs
var displayDeviceName = @"\\.\DISPLAY1";
DisplayOrientationCtrl.API.TryChangeOrientation(displayDeviceName, DisplayOrientationCtrl.DisplayOrientation.Rotate90Degrees);
```

## Gets display device names

```cs
var deviceNames = DisplayOrientationCtrl.API.GetAllActiveDisplayNames();
```
