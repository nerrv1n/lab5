﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace EventHandling.Object
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<Bubble> OnBubbleOverlap;
        public Action<RedBubble> OnRedBubbleOverlap;
        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle)
        {

        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DarkOliveGreen), -15, -15, 50, 50);
            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 50, 50);
            g.DrawLine(new Pen(Color.Black, 2), 0, 12, 50, 0);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            
            if (obj is Marker) OnMarkerOverlap(obj as Marker);
            if (obj is Bubble) OnBubbleOverlap(obj as Bubble);
            if (obj is RedBubble) OnRedBubbleOverlap(obj as RedBubble);
        }

    }
}
