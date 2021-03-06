﻿using MatterHackers.Agg;
using MatterHackers.Agg.UI;
using MatterHackers.Agg.VertexSource;
using MatterHackers.Csg;
using MatterHackers.Csg.Solids;
using MatterHackers.Csg.Transform;
using MatterHackers.VectorMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MatterCadGui cadWindow = new MatterCadGui(true);
            cadWindow.UseOpenGL = true;
            cadWindow.Title = "MatterCAD";

            cadWindow.ShowAsSystemWindow();
        }
    }

    public class MatterCadGui : SystemWindow
    {
        MatterCadGuiWidget matterCadGuiWidget;

        CsgObject TrainConnector()
        {
            CsgObject total;
            CsgObject bar = new Box(20, 5.8, 12, createCentered: false, name: "link");
            bar = new SetCenter(bar, Vector3.Zero);
            total = bar;
            CsgObject leftHold = new Cylinder(11.7 / 2, 12, Alignment.z);
            leftHold = new SetCenter(leftHold, bar.GetCenter() + new Vector3(12, 0, 0));
            CsgObject rightHold = leftHold.NewMirrorAccrossX();
            total += leftHold;
            total += rightHold;

            return total;
        }
        public MatterCadGui(bool renderRayTrace)
            : base(800, 600)
        {
            ////BackgroundColor = RGBA_Bytes.YellowGreen;
            //CsgObject testObject = TrainConnector();
            ////BoxCSG boxObject = new BoxCSG(20, 20, 20, "base box");
            //CsgObject csgObject = new Box(new Vector3(1, 1, 14), "test");
            //if (renderRayTrace)
            //{
            //    var matterCadGuiWidget = new MatterCadGuiWidget();
            //   // AddChild(csgObject);
            //   // AddChild(new MyGuiWidget());
            //    matterCadGuiWidget.AnchorAll();
            //    AnchorAll();
            //}

            if (renderRayTrace)
            {
                matterCadGuiWidget = new MatterCadGuiWidget();
                AddChild(matterCadGuiWidget);
                matterCadGuiWidget.AnchorAll();
                AnchorAll();
            }
        }

        //public override void OnDraw(Graphics2D graphics2D)
        //{
        //    RoundedRect roundRect = new RoundedRect(new RectangleDouble(Width / 2 - Width / 3 - 1, Height / 2 - Height / 8, Width / 2 + Width / 3 - 1, Height / 2 + Height / 8), 2);

        //    graphics2D.Circle(new Vector2(Width / 2, Height / 2), Width / 4 + Height / 4, new RGBA_Bytes(0, 0, 0));

        //    var csgObject = new Box(new Vector3(1, 1, 1), "test");
        //    graphics2D.Render(roundRect, RGBA_Bytes.Pink);
        //    graphics2D.Line(new Vector2(0, 0), new Vector2(100, 100), new RGBA_Bytes(125, 125, 152));

        //    base.OnDraw(graphics2D);
        //}
    }
    public class MatterCadGuiWidget : GuiWidget
    {
        GuiWidget objectEditorView;
        public MatterCadGuiWidget()
        {
            SuspendLayout();
            BackgroundColor = RGBA_Bytes.Blue;
            objectEditorView = new TextEditWidget("test", 300, 500)
            {
                HAnchor = HAnchor.ParentLeftRight,
                //     textEdit.MinimumSize = new Vector2(Math.Max(textEdit.MinimumSize.x, pixelWidth), Math.Max(textEdit.MinimumSize.y, pixelHeight));
                VAnchor = VAnchor.ParentBottomTop,
           //     BackgroundColor = RGBA_Bytes.Red,
                Text = "Hello World!",
                Multiline = true
            };
            ResumeLayout();
            AnchorAll();
            AddChild(objectEditorView);
        }
    }
}
