using MortiseFrame.Abacus;

namespace MortiseFrame.Vista {

    public class CameraDriver {

        FVector2 pos;
        public FVector2 Pos => pos;

        public CameraDriver(FVector2 pos) {
            this.pos = pos;
        }

        public void SetPos(FVector2 pos) {
            this.pos = pos;
        }

    }

}