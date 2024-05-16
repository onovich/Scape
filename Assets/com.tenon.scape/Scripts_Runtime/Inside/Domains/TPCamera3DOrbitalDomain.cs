using System;
using MortiseFrame.Swing;
using UnityEngine;

namespace TenonKit.Scape {

    internal static class TPCamera3DOrbitalDomain {

        public static void ApplyOrbital(Camera3DContext ctx, int id, Vector3 axis, float dt) {
            var has = ctx.TryGetTPCamera(id, out var camera);
            if (!has) {
                V3Log.Error($"ManualOrbitalDriver Error, Camera Not Found: ID = {id}");
                return;
            }
            var speed = camera.fsmCom.manualOrbital_manualOrbitalSpeed;

            var currentPos = camera.trs.t;
            var person = camera.personTRS;

            if (camera.followX) {
                TPCamera3DMoveDomain.ApplyFollowXYZ(ctx, camera.id, in camera.personTRS, dt);
            } else {
                TPCamera3DMoveDomain.ApplyFollowYZ(ctx, camera.id, in camera.personTRS, dt);
                Camera3DLookAtPhase.ApplyLookAtPerson(ctx, camera.id, in camera.personTRS, dt);
            }

            if (axis == Vector3.zero) {
                return;
            }

            // 投影 Person 到 xz 平面
            Vector3 projCenter = new Vector3(person.t.x, camera.trs.t.y, person.t.z);
            Vector3 localOffset = axis * speed * dt;
            Vector3 targetPos = currentPos + camera.trs.r * localOffset;
            bool isClockWise = axis.x < 0;
            Vector3 pos = OrbitHelper.Round3D(currentPos, targetPos, projCenter, 1, 1, isClockWise);

            TPCamera3DMoveDomain.SetPos(ctx, id, pos);
        }

    }

}