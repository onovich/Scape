using System;
using UnityEngine;
using MortiseFrame.Swing;

namespace TenonKit.Vista.Camera3D {

    public class Camera3DCore {

        Camera3DContext ctx;

        public Camera3DCore(Camera mainCamera, Vector3 viewSize) {
            ctx = new Camera3DContext();
            ctx.Inject(mainCamera);
            ctx.Init(viewSize);
        }

        // Tick
        public void Tick(float dt) {
            if (!ctx.Inited) {
                return;
            }
            Camera3DConstraintPhase.Tick(ctx, dt);
            Camera3DShakePhase.Tick(ctx, dt);
        }

        // Camera
        public int CreateFreeCamera3D(Vector3 pos, Vector3 confinerMax, Vector3 confinerMin) {
            var camera = Camera3DFactory.CreateCamera3D(ctx, pos, confinerMax, confinerMin);
            ctx.AddCamera(camera, camera.ID);
            return camera.ID;
        }

        public int CreateTrackCamera3D(Vector3 pos, Vector3 confinerMax, Vector3 confinerMin, Transform driver) {
            var camera = Camera3DFactory.CreateCamera3D(ctx, pos, confinerMax, confinerMin);
            ctx.AddCamera(camera, camera.ID);
            Camera3DFollowDomain.FSM_SetMoveByDriver(ctx, camera.ID, driver);
            return camera.ID;
        }

        public void SetCurrentCamera(int cameraID) {
            ctx.SetCurrentCamera(cameraID);
        }

        // Composer
        //// DeadZone
        public void SetComposerDeadZone(int cameraID, Vector2 normalizedSize) {
            Camera3DComposerDomain.SetDeadZone(ctx, cameraID, normalizedSize);
        }

        public void EnableComposerDeadZone(int cameraID, bool enable) {
            Camera3DComposerDomain.EnableDeadZone(ctx, cameraID, enable);
        }

        public bool IsComposerDeadZoneEnable(int cameraID) {
            return Camera3DComposerDomain.IsDeadZoneEnable(ctx, cameraID);
        }

        //// SoftZone
        public void SetComposerSoftZone(int cameraID, Vector2 normalizedSize, Vector3 dampingFactor) {
            Camera3DComposerDomain.SetSoftZone(ctx, cameraID, normalizedSize, dampingFactor);
        }

        public void EnableComposerSoftZone(int cameraID, bool enable) {
            Camera3DComposerDomain.EnableSoftZone(ctx, cameraID, enable);
        }

        public bool IsComposerSoftZoneEnable(int cameraID) {
            return Camera3DComposerDomain.IsSoftZoneEnable(ctx, cameraID);
        }

        // Transposer
        //// DeadZone
        public void SetTransposerDeadZone(int cameraID, Vector2 normalizedSize) {
            Camera3DTransposerDomain.SetDeadZone(ctx, cameraID, normalizedSize);
        }

        public void EnableTransposerDeadZone(int cameraID, bool enable) {
            Camera3DTransposerDomain.EnableDeadZone(ctx, cameraID, enable);
        }

        public bool IsTransposerDeadZoneEnable(int cameraID) {
            return Camera3DTransposerDomain.IsDeadZoneEnable(ctx, cameraID);
        }

        //// SoftZone
        public void SetTransposerSoftZone(int cameraID, Vector2 normalizedSize, Vector3 dampingFactor) {
            Camera3DTransposerDomain.SetSoftZone(ctx, cameraID, normalizedSize, dampingFactor);
        }

        public void EnableTransposerSoftZone(int cameraID, bool enable) {
            Camera3DTransposerDomain.EnableSoftZone(ctx, cameraID, enable);
        }

        public bool IsTransposerSoftZoneEnable(int cameraID) {
            return Camera3DTransposerDomain.IsSoftZoneEnable(ctx, cameraID);
        }

        // Move
        public void FreeCamera_SetMoveToTarget(int cameraID, Vector3 target, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None, Action onComplete = null) {
            Camera3DFollowDomain.FSM_SetMoveToTarget(ctx, cameraID, target, duration, easingType, easingMode, onComplete);
        }

        // Rotate
        public void Rotate(int cameraID, float yaw, float pitch, float roll) {
            Camera3DRotateDomain.Rotate(ctx, cameraID, yaw, pitch, roll);
        }

        // Shake
        public void ShakeOnce(int cameraID, float frequency, float amplitude, float duration, EasingType type = EasingType.Linear, EasingMode mode = EasingMode.None) {
            Camera3DShakeDomain.ShakeOnce(ctx, cameraID, frequency, amplitude, duration, type, mode);
        }

        public void Clear() {
            ctx.Clear();
        }

        public void DrawGizmos() {
            var camera = ctx.CurrentCamera;
            DrawGizmos3DHelper.DrawGizmos(ctx, ctx.MainCamera);
        }

    }

}