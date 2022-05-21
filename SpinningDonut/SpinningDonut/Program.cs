float A = 0, B = 0, i, j;
int k;
float[] z = new float[1760];
char[] b = new char[1760];

while (!(Console.KeyAvailable && Console.ReadKey(false).Key == ConsoleKey.Escape))
{
    Console.CursorVisible = false;

    Array.Clear(z);
    Array.Fill(b, ' ');

    for (j = 0; j < 6.28; j += (float)0.07)
    {
        for (i = 0; i < 6.28; i += (float)0.02)
        {
            float c = (float)Math.Sin(i),
                  d = (float)Math.Cos(j),
                  e = (float)Math.Sin(A),
                  f = (float)Math.Sin(j),
                  g = (float)Math.Cos(A);

            float h = d + 2, D = 1 / (c * h * e + f * g + 5);

            float l = (float)Math.Cos(i),
                  m = (float)Math.Cos(B),
                  n = (float)Math.Sin(B);

            float t = c * h * g - f * e;

            int x = (int)(40 + 30 * D * (l * h * m - t * n));
            int y = (int)(12 + 15 * D * (l * h * n + t * m));
            int o = x + 80 * y;
            int N = (int)(8 * ((f * e - c * d * g) * m - c * d * e - f * g - l * d * n));

            if (22 > y && y > 0 && x > 0 && 80 > x && D > z[o])
            {
                z[o] = D;
                b[o] = ".,-~:;=!*#$@"[N > 0 ? N : 0];
            }
        }
    }

    Console.Write("\x1b[H");
    for (k = 0; k < 1761; k++)
    {
        Console.Write(k % 80 != 0 ? b[k] : (char)10);
        A += (float)0.00004;
        B += (float)0.00002;
    }
}