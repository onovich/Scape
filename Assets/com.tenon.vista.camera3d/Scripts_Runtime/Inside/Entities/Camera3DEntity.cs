using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace TenonKit.Vista.Camera3D {

    internal class Camera3DEntity {

        // ID
        int id;
        internal int ID => id;

        // Pos
        Vector3 pos;
        internal Vector3 Pos => pos;

        // Rotate
        Quaternion rotate;

        // Confiner
        Camera3DConfinerComponent confinerComponent;

        // Transposer
        Camera3DTransposerComponent transposerComponent;
        internal Camera3DTransposerComponent TransposerComponent => transposerComponent;
        internal Vector3 Transposer_SoftZone_DampingFactor => transposerComponent.SoftZoneDampingFactor;

        // Composer
        Camera3DComposerComponent composerComponent;
        internal Camera3DComposerComponent ComposerComponent => composerComponent;
        internal Vector3 Composer_SoftZone_DampingFactor => composerComponent.SoftZoneDampingFactor;

        // FSM
        Camera3DMovingComponent fsmCom;
        internal Camera3DMovingComponent FSMCom => fsmCom;

        // Shake
        Camera3DShakeComponent shakeComponent;
        internal Camera3DShakeComponent ShakeComponent => shakeComponent;

        internal Camera3DEntity() {
            fsmCom = new Camera3DMovingComponent();
            transposerComponent = new Camera3DTransposerComponent();
            composerComponent = new Camera3DComposerComponent();
            shakeComponent = new Camera3DShakeComponent();
        }

        // ID
        internal void SetID(int id) {
            this.id = id;
        }

        // Pos
        internal void SetPos(Vector3 pos) {
            this.pos = pos;
        }

        // Rotate
        internal void Rotate(float yaw, float pitch, float roll) {
            var eulerRotation = new Vector3(pitch, yaw, roll);
            var quaterRotation = Quaternion.Euler(eulerRotation);
            rotate = quaterRotation;
        }

        // Confiner
        internal void SetConfiner(Vector3 confinerWorldMax, Vector3 confinerWorldMin) {
            this.confinerComponent = new Camera3DConfinerComponent(confinerWorldMax, confinerWorldMin);
        }

        internal bool TryClampByConfiner(Vector3 pos, float fov, float aspect, out Vector3 dst) {
            return confinerComponent.TryClamp(pos, fov, aspect, out dst);
        }

        internal Vector3 GetConfinerCenter() {
            return (confinerComponent.ConfinerWorldMax + confinerComponent.ConfinerWorldMin) / 2f;
        }

        internal Vector3 GetConfinerSize() {
            return confinerComponent.ConfinerWorldMax - confinerComponent.ConfinerWorldMin;
        }

        // Shake
        internal void ShakeOnce(float frequency, float amplitude, float duration, EasingType type = EasingType.Linear, EasingMode mode = EasingMode.None) {
            shakeComponent.ShakeOnce(frequency, amplitude, duration, type, mode);
        }

        // Transposer
        //// Transposer DeadZone
        internal void Transposer_DeadZone_Set(Vector2 normalizedSize, Vector2 viewSize) {
            transposerComponent.SetDeadZone(normalizedSize, viewSize);
        }

        internal Vector2 Transposer_DeadZone_GetScreenDiff(Vector2 screenPos) {
            return transposerComponent.GetDeadZoneScreenDiff(screenPos);
        }

        internal Vector2 Transposer_DeadZone_GetSize() {
            return transposerComponent.GetDeadZoneSize();
        }

        internal bool Transposer_DeadZone_IsEnable() {
            return transposerComponent.IsDeadZoneEnable();
        }

        internal void Transposer_DeadZone_Enable(bool enable) {
            transposerComponent.EnableDeadZone(enable);
        }

        //// Transposer SoftZone
        internal void Transposer_SoftZone_Set(Vector2 normalizedSize, Vector2 viewSize, Vector3 dampingFactor) {
            transposerComponent.SetSoftZone(normalizedSize, viewSize, dampingFactor);
        }

        internal Vector2 Transposer_SoftZone_GetScreenDiff(Vector2 screenPos) {
            return transposerComponent.GetSoftZoneScreenDiff(screenPos);
        }

        internal Vector2 Transposer_SoftZone_GetSize() {
            return transposerComponent.GetSoftZoneSize();
        }

        internal bool Transposer_SoftZone_IsEnable() {
            return transposerComponent.IsSoftZoneEnable();
        }

        internal void Transposer_SoftZone_Enable(bool enable) {
            transposerComponent.EnableSoftZone(enable);
        }

        // Composer
        //// Composer DeadZone
        internal void Composer_DeadZone_Set(Vector2 normalizedSize, Vector2 viewSize) {
            composerComponent.SetDeadZone(normalizedSize, viewSize);
        }

        internal Vector2 Composer_DeadZone_GetScreenDiff(Vector2 screenPos) {
            return composerComponent.GetDeadZoneScreenDiff(screenPos);
        }

        internal Vector2 Composer_DeadZone_GetSize() {
            return composerComponent.GetDeadZoneSize();
        }

        internal bool Composer_DeadZone_IsEnable() {
            return composerComponent.IsDeadZoneEnable();
        }

        internal void Composer_DeadZone_Enable(bool enable) {
            composerComponent.EnableDeadZone(enable);
        }

        //// Composer SoftZone
        internal void Composer_SoftZone_Set(Vector2 normalizedSize, Vector2 viewSize, Vector3 dampingFactor) {
            composerComponent.SetSoftZone(normalizedSize, viewSize, dampingFactor);
        }

        internal Vector2 Composer_SoftZone_GetScreenDiff(Vector2 screenPos) {
            return composerComponent.GetSoftZoneScreenDiff(screenPos);
        }

        internal Vector2 Composer_SoftZone_GetSize() {
            return composerComponent.GetSoftZoneSize();
        }

        internal bool Composer_SoftZone_IsEnable() {
            return composerComponent.IsSoftZoneEnable();
        }

        internal void Composer_SoftZone_Enable(bool enable) {
            composerComponent.EnableSoftZone(enable);
        }

    }

}