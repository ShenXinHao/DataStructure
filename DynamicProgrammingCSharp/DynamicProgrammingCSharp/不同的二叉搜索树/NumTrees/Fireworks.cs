namespace NumTrees;

public class Fireworks
{
    static Random random = new Random();

 
    public static void LaunchFirework()
    {
        int launchX = random.Next(10, Console.WindowWidth - 10); // 随机发射位置
        int launchHeight = random.Next(Console.WindowHeight / 2, Console.WindowHeight - 5); // 随机高度

        // 烟花上升效果
        for (int y = Console.WindowHeight - 2; y > launchHeight; y--)
        {
            Console.SetCursorPosition(launchX, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|"); // 烟花上升轨迹
            Thread.Sleep(50);

            // 清除上一个位置的轨迹
            Console.SetCursorPosition(launchX, y);
            Console.Write(" ");
        }

        // 烟花爆炸效果
        Explode(launchX, launchHeight);
    }

    public static void Explode(int centerX, int centerY)
    {
        int explosionSize = random.Next(5, 10); // 爆炸的范围大小

        // 烟花的爆炸效果
        for (int i = 0; i < explosionSize * 2; i++)
        {
            int offsetX = random.Next(-explosionSize, explosionSize);
            int offsetY = random.Next(-explosionSize, explosionSize);

            int x = centerX + offsetX;
            int y = centerY + offsetY;

            if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = (ConsoleColor)random.Next(1, 16); // 随机颜色
                Console.Write("*"); // 烟花的火花字符
            }
        }

        Thread.Sleep(500); // 保持爆炸效果一会儿

        // 清除爆炸效果
        for (int i = 0; i < explosionSize * 2; i++)
        {
            int offsetX = random.Next(-explosionSize, explosionSize);
            int offsetY = random.Next(-explosionSize, explosionSize);

            int x = centerX + offsetX;
            int y = centerY + offsetY;

            if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
            }
        }
        Console.ResetColor();
    }
}