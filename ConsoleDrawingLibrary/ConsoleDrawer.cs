using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDrawingLibrary
{
    public class ConsoleDrawer
    {
        public static void DrawPoint(int x, int y, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (x >= Console.WindowWidth) return;
            if (y >= Console.WindowHeight) return;

            var curColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
            Console.ForegroundColor = curColor;
        }

        public static void DrawLine(int x1, int y1, int x2, int y2, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            int xDif = x2 - x1;
            int yDif = y2 - y1;
            var length = Math.Sqrt(yDif * yDif + xDif * xDif);
            for (int i = 0; i < length; i++)
            {
                if (i == 28)
                {
                    Console.Write("");
                }
                var mappedX = Math.Round((i / length) * xDif);
                var mappedY = Math.Round((i / length) * yDif);
                DrawPoint(x1 + (int)mappedX, y1 + (int)mappedY, color, backgroundColor, symbol);
            }
            DrawPoint(x1, y1, color, backgroundColor, symbol);
            DrawPoint(x2, y2, color, backgroundColor, symbol);
        }

        public static void DrawRect(int x, int y, int width, int height, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            DrawLine(x, y, x + width, y, color, backgroundColor, symbol);
            DrawLine(x, y + height, x + width, y + height, color, backgroundColor, symbol);
            DrawLine(x, y, x, y + height, color, backgroundColor, symbol);
            DrawLine(x + width, y, x + width, y + height, color, backgroundColor, symbol);
        }
        public static void DrawFilledRect(int x, int y, int width, int height, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            if (height < width)
                for (int i = 0; i < height; i++)
                {
                    DrawLine(x, y + i, x + width, y + i, color, backgroundColor, symbol);
                }
            else
                for (int i = 0; i < width; i++)
                {
                    DrawLine(x + i, y, x + i, y + height, color, backgroundColor, symbol);
                }
        }

        public static void DrawBezier(int startX, int startY, int endX, int endY, int curveX, int curveY, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            (int x, int y) start = (startX, startY);
            (int x, int y) end = (endX, endY);
            (int x, int y) curve = (curveX, curveY);
            int len = 100;
            for (float i = 0; i < len; i++)
            {
                float iter = i / len;
                var x1 = Lerp(start.x, curve.x, iter);
                var y1 = Lerp(start.y, curve.y, iter);
                var x2 = Lerp(curve.x, end.x, iter);
                var y2 = Lerp(curve.y, end.y, iter);

                var newX = Lerp(x1, x2, iter);
                var newY = Lerp(y1, y2, iter);
                DrawPoint((int)newX, (int)newY, color, backgroundColor, symbol);
            }
            //"Handles"
            //DrawLine(start.x,start.y,curve.x,curve.y,ConsoleColor.Blue);
            //DrawLine(end.x,end.y,curve.x,curve.y, ConsoleColor.Red);
        }

        public static void DrawCircle(int x, int y, int radius, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            float len = radius * 2 * 3.2f;
            for (int i = 0; i < radius * 2 + 1; i++)
            {
                int cur = i;
                int toMid = radius - cur;
                int circleY = (int)Math.Sqrt(radius * radius - toMid * toMid);
                DrawPoint(x + i, y + circleY, color, backgroundColor, symbol);
                DrawPoint(x + i, y - circleY, color, backgroundColor, symbol);

                DrawPoint(x + radius + circleY, y - radius + i, color, backgroundColor, symbol);
                DrawPoint(x + radius - circleY, y - radius + i, color, backgroundColor, symbol);
            }
        }

        public static void DrawFilledCircle(int x, int y, int radius, ConsoleColor color = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, char symbol = '#')
        {
            float len = radius * 2 * 3.2f;
            for (int i = 0; i < radius * 2 + 1; i++)
            {
                int cur = i;
                int toMid = radius - cur;
                int circleY = (int)Math.Sqrt(radius * radius - toMid * toMid);
                DrawLine(x + i, y, x + i, y + circleY, color, backgroundColor, symbol);
                DrawLine(x + i, y, x + i, y - circleY, color, backgroundColor, symbol);
            }
        }

        static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
    }
}
