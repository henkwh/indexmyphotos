using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    class FlowLayoutOverview : FlowLayoutPanel {

        public FlowLayoutOverview() : base(){
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.Scroll += FlowLayoutOverview_Scroll; ;
        }


        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}
