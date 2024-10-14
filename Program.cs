using System.Drawing;
using System.Drawing.Imaging;
Console.WriteLine("Please provide the image path as a command line argument :");
string inputPath = Console.ReadLine();

if (inputPath is null) { Console.WriteLine("Please provide the image path as a command line argument"); return; }

if (!File.Exists(inputPath)) { Console.WriteLine("The specified file does not exist"); return; }

string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imageInRGBA.png");

using (Bitmap originalBitmap = new(inputPath))
{
    Bitmap rgbaBitmap = new (originalBitmap.Width, originalBitmap.Height, PixelFormat.Format32bppArgb);

    using (Graphics graphics = Graphics.FromImage(rgbaBitmap))
    {
        graphics.DrawImage(originalBitmap, new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height));
    }
    rgbaBitmap.Save(outputPath, ImageFormat.Png);
}
Console.WriteLine("The image has been converted to RGBA mode and saved successfully");