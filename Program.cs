using System.Drawing;
using System.Drawing.Imaging;
Console.WriteLine("Please provide the image path as a command line argument:");
string inputPath = Console.ReadLine();

if (inputPath is null) {Console.WriteLine("Please provide the image path as a command line argument"); return; }

if (!File.Exists(inputPath)) { Console.WriteLine("The specified file does not exist"); return; }

try
    {
        string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileNameWithoutExtension(inputPath) + "ImageInRGBA" + Path.GetExtension(inputPath));

        using (Bitmap originalBitmap = new(inputPath))
        {
            Bitmap rgbaBitmap = new(originalBitmap.Width, originalBitmap.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(rgbaBitmap))
            {
                graphics.DrawImage(originalBitmap, new Rectangle(0, 0, originalBitmap.Width, originalBitmap.Height));
            }

            ImageFormat format;
            switch (Path.GetExtension(inputPath).ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    format = ImageFormat.Bmp;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                case ".ico":
                    format = ImageFormat.Icon;
                    break;
                case ".Webp":
                    format = ImageFormat.Webp;
                    break;
                case ".Heif":
                    format = ImageFormat.Heif;
                    break;
            default:
                    Console.WriteLine("Unsupported image format");
                    return;
            }

            rgbaBitmap.Save(outputPath, format);
        }
        Console.WriteLine("The image has been converted to RGBA mode and saved successfully :)");
    }
    catch (ArgumentException e)
    { Console.WriteLine("The image appears corrupted (Try with other image :/) => " + e.Message); return; }
    catch (Exception e)
    { Console.WriteLine("Other error, please reports the bug => " + e.Message); return; }