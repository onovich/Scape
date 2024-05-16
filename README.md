# Scape
Scape, 3D camera library, named after "景". The goal is to make it simpler, easier to use, and more accurate than Cinemachine.<br/>
**Scape, 3d 相机库，取名自「景」。目标是做得比 Cinemachine 简单、易用、准确。**

![](https://github.com/onovich/Scape/blob/main/Assets/com.tenon.scape/Resources_Sample/cover_scape.png)

Scape provides managed 3D Camera functionality for Unity. Currently, it is only suitable for perspective cameras in third-person scenes.<br/>
**Scape 为 Unity 里的 3D Camera 提供托管。目前仅适用于透视相机、第三人称场景。**

If you need a 2D camera, please refer to [Vista](https://github.com/onovich/Vista).<br>
**如果需要 2D 相机，请移步到 [Vista](https://github.com/onovich/Vista)。**

Scape does not hijack any Camera or Transform components from the upper layer, ensuring no side effects. The upper layer records the virtual camera created by the lower layer using an id, and it can be queried and accessed through interfaces.<br/>
**Scape 的底层不会劫持上层的任何 Camera 或 Transform，不会产生副作用。上层以 id  的形式记录下层创建的虚拟相机，通过接口查询和访问。**

# Availability
Still in development, not recommended for use.<br/>
**仍在开发中，不建议用。**

# Features
## Implemented
* FollowXYAndLookAt（like the camera in Sekiro and Breath of the Wild）
* FollowXYZ（like the camera in God of War and Red Dead Redemption）
* Damping
* Shake

## In Development
* ManualMove
* ManualOrbit

## To Be Implemented
* DeadZone / SoftZone
* TrackCamera
* FPCamera
* FlyModeCamera
* Transition Between Multiple Cameras
* Aim Group
* Stabilization

## Not In Plan
Camera Physics

# Sample
```
// Create And Init Camera

void Start() {
    // Camera
    cameraCore = new Camera3DCore();
    var t = agent.transform.position;
    var r = agent.transform.rotation;
    var s = agent.transform.localScale;
    var fov = agent.fieldOfView;
    var nearClip = agent.nearClipPlane;
    var farClip = agent.farClipPlane;
    var aspectRatio = agent.aspect;
    var screenWidth = screenSize.x;
    var cameraID = cameraCore.CreateTPCamera(t, r, s, fov, nearClip, farClip, aspectRatio, screenWidth);

    // Damping Factor
    cameraCore.SetTPCameraFollowDamppingFactor(followDampingFactor);
    cameraCore.SetTPCameraLookAtDamppingFactor(lookAtDampingFactor);

    // Dead Zone
    cameraCore.SetTPCameraDeadZone(deadZoneFOV);

    // Soft Zone
    cameraCore.SetTPCameraSoftZone(softZoneFOV);

    // Offset
    cameraCore.SetPersonOffset(t, r, s);

    // Follow Mode
    cameraCore.SetTPCameraFollowX(followX);
}
```

```
// Shake
void ShakeOnce(int cameraID) {
    cameraCore.ShakeOnce(cameraID, shakeFrequency, shakeAmplitude, shakeDuration, shakeEasingType, shakeEasingMode);
}
```

```
// Tick
void LateUpdate() {
    var dt = Time.deltaTime;
    Camera3DInfra.Tick(ctx, person.transform, dt);

    Logic3DBusiness.CameraPan_ApplySet(ctx);
    Logic3DBusiness.CameraPan_Apply(ctx);
    Logic3DBusiness.CameraPan_ApplyCancle(ctx);

    Logic3DBusiness.CameraOrbital_ApplySet(ctx);
    Logic3DBusiness.CameraOrbital_Apply(ctx);
    Logic3DBusiness.CameraOrbital_ApplyCancle(ctx);

    Camera3DInfra.GetTPCameraTR(ctx, out var pos, out var rot);
    agent.transform.position = pos;
    agent.transform.rotation = rot;

    Logic3DBusiness.ResetInput(ctx);
}
```

```
// Clear Buff
public void Clear() {
    cameraCore.Clear();
}
```

# Dependency
Easing Function Library
[Swing](https://github.com/onovich/Swing)

# UPM URL
ssh://git@github.com/onovich/Scape.git?path=/Assets/com.tenon.scape#main
