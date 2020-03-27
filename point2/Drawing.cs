using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Painter
{
    public class Drawing
    {
        static int penWidth = 20;

        public static Point Pen(Point MDown, Point MMove, Graphics g, Color penColor)
        {
            IntPtr pTarget = g.GetHdc();

            IntPtr pen = Win32.CreatePen(Win32.PenStyle.PS_SOLID | Win32.PenStyle.PS_GEOMETRIC | Win32.PenStyle.PS_ENDCAP_ROUND, penWidth, (uint)ColorTranslator.ToWin32(penColor));
            IntPtr oldpen = Win32.SelectObject(pTarget, pen);

            Win32.MoveToEx(pTarget, MDown.X, MDown.Y, IntPtr.Zero);
            Win32.LineTo(pTarget, MMove.X, MMove.Y);

            MDown.X = MMove.X;
            MDown.Y = MMove.Y;

            Win32.DeleteObject(Win32.SelectObject(pTarget, oldpen));
            g.ReleaseHdc(pTarget);

            return MMove;
        }

        public static void Figure(Point Start, Point End, Graphics g, int top, Color penColor)
        {
            IntPtr pTarget = g.GetHdc();
            int R1 = (End.X - Start.X) / 2;
            int R2 = (End.Y - Start.Y) / 2;
            Point Old = new Point(0, 0);
            Point New = new Point(0, 0);
            IntPtr pen = Win32.CreatePen(Win32.PenStyle.PS_SOLID | Win32.PenStyle.PS_GEOMETRIC | Win32.PenStyle.PS_ENDCAP_ROUND, penWidth, (uint)ColorTranslator.ToWin32(penColor));
            IntPtr oldpen = Win32.SelectObject(pTarget, pen);
            Point Center = new Point((End.X + Start.X) / 2, (End.Y + Start.Y) / 2);

            Old.X = (int)(Center.X + Math.Sin(0) * R1);
            Old.Y = (int)(Center.Y - Math.Cos(0) * R2);

            Win32.MoveToEx(pTarget, Old.X, Old.Y, IntPtr.Zero);

            for (int i = 1; i <= top; i++)
            {
                New.X = (int)(Center.X + Math.Sin(i * 2 * Math.PI / top) * R1);
                New.Y = (int)(Center.Y - Math.Cos(i * 2 * Math.PI / top) * R2);

                Win32.LineTo(pTarget, New.X, New.Y);
            }
            Win32.DeleteObject(Win32.SelectObject(pTarget, oldpen));
            g.ReleaseHdc(pTarget);
        }
    }
}


