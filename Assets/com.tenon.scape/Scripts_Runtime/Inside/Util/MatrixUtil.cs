using UnityEngine;

namespace TenonKit.Scape {

    internal static class MatrixUtil {

        // TRS
        internal static TRS3DModel ApplyTRSWithOffset(in TRS3DModel target, in TRS3DModel offset) {
            if (target.r.x == 0 && target.r.y == 0 && target.r.z == 0 && target.r.w == 0) {
                return target;
            }
            Matrix4x4 m = Matrix4x4.TRS(target.t, target.r, target.s);
            TRS3DModel dst = new TRS3DModel(
                m.MultiplyPoint(offset.t),
                target.r * offset.r,
                new Vector3(
                    target.s.x * offset.s.x,
                    target.s.y * offset.s.y,
                    target.s.z * offset.s.z
                )
            );
            return dst;
        }

        // MVP
        internal static Matrix4x4 GetModelMatrix(in TRS3DModel trs) {
            return Matrix4x4.TRS(trs.t, trs.r, trs.s);
        }

        internal static Matrix4x4 GetViewMatrix(ICamera3D camera) {
            return camera.GetViewMatrix();
        }

        internal static Matrix4x4 GetProjectionMatrix(ICamera3D camera) {
            return camera.GetProjectionMatrix();
        }

        // VP
        internal static Vector3 WorldToScreenPoint(ICamera3D camera, Vector3 worldSpacePoint, Vector2 screenSize) {

            // World -> View
            Matrix4x4 viewMatrix = camera.GetViewMatrix();
            Vector3 cameraSpacePoint = viewMatrix * new Vector4(worldSpacePoint.x, worldSpacePoint.y, worldSpacePoint.z, 1);

            // View -> Projection
            Matrix4x4 projectionMatrix = camera.GetProjectionMatrix();
            Vector4 clipSpacePoint = projectionMatrix * cameraSpacePoint;

            // Projection -> NDC
            Vector3 ndcPoint = clipSpacePoint / clipSpacePoint.w;

            // NDC -> ViewPort
            Vector3 viewportPoint = new Vector3(
                (-ndcPoint.x + 1) * 0.5f,
                (-ndcPoint.y + 1) * 0.5f,
                cameraSpacePoint.z
            );

            // ViewPort -> Screen
            Vector3 screenPoint = new Vector3(
                viewportPoint.x * screenSize.x,
                viewportPoint.y * screenSize.y,
                viewportPoint.z
            );

            return screenPoint;
        }

    }

}