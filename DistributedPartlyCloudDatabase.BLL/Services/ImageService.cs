using DistributedPartlyCloudDatabase.BLL.Interface.Services;
using System;
using System.Collections.Generic;
using DistributedPartlyCloudDatabase.BLL.Interface.Entities;
using DistributedPartlyCloudDatabase.DAL.Interface.Repositories;
using DistributedPartlyCloudDatabase.BLL.Mappers;
using System.Linq;
using System.IO;
using System.Drawing;

namespace DistributedPartlyCloudDatabase.BLL.Services
{
    public class ImageService : IImageService
    {
        private IDBTwoRepositories DBTwoRepositories;

        public ImageService(IDBTwoRepositories DBTwoRepositories)
        {
            this.DBTwoRepositories = DBTwoRepositories;
        }

        public void CreateImage(ImageEntity imageEntity)
        {
            DBTwoRepositories.ImageRepository.Create(imageEntity.ToDalImage());
            DBTwoRepositories.Commit();
        }

        public IEnumerable<ImageEntity> GetAllImageEntities()
        {
            return DBTwoRepositories.ImageRepository
                .GetAll()
                .Select(img => img.ToBllImage());
        }

        public IEnumerable<ImageEntity> GetByUserNickname(string userNickname)
        {
            return DBTwoRepositories.ImageRepository
                .GetAll()
                .Where(img => img.UserNickname == userNickname)
                .Select(img => img.ToBllImage());
        }
        
        public ImageEntity GetImageEntity(int id)
        {
            throw new NotImplementedException();
        }

        public string ComputeHashCode(byte[] image)
        {

            MemoryStream memoryStream = new MemoryStream(image);
            Image fullsizeImage = Image.FromStream(memoryStream);

            Image thumbnailImage = ScaleImage(fullsizeImage);
            Image greyscaledImage = GrayscaleImage(thumbnailImage);
            Color averageColor = AverageColor(greyscaledImage);

            return GetHash(greyscaledImage, averageColor);
        }


        private Image ScaleImage(Image source)
        {           
            return source.GetThumbnailImage(8, 8, null, IntPtr.Zero);     
        }

        private Image GrayscaleImage(Image source)
        {
            Bitmap image = new Bitmap(source.Width, source.Height);
            Bitmap bitmap = new Bitmap(source);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;

                    image.SetPixel(x, y, Color.FromArgb(pixel.A, avg, avg, avg));
                }
            }

            return image;
        }

        private Color AverageColor(Image source)
        {
            Bitmap bitmap = new Bitmap(source);
            int sumR = 0;
            int sumG = 0;
            int sumB = 0;
            int width = bitmap.Width;
            int height = bitmap.Height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    sumR += pixelColor.R * pixelColor.R;
                    sumG += pixelColor.G * pixelColor.G;
                    sumB += pixelColor.B * pixelColor.B;
                }
            }

            return Color.FromArgb(
                (int)Math.Sqrt(sumR / (width * height)),
                (int)Math.Sqrt(sumG / (width * height)),
                (int)Math.Sqrt(sumB / (width * height)));
        } 

        public string GetHash(Image source, Color averageColor)
        {
            Bitmap bitmap = new Bitmap(source);
            int width = bitmap.Width;
            int height = bitmap.Height;
            byte[,] hashArray = new byte[height, width];

            for (int x = 0; x < height; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // because R, G, B values in grayscaled imgs are equal
                    if (pixelColor.R >= averageColor.R)
                    {                        
                        hashArray[x, y] = 1;
                    }
                    else
                    {
                        hashArray[x, y] = 0;
                    }
                }
            }           
            
            ulong number = GetNumberFromBytes(hashArray);

            return number.ToString("x");
        }

        public ulong GetNumberFromBytes(byte[,] matrix)
        {
            ulong deg2 = 1;
            ulong result = 0;
            int n = matrix.GetLength(0);

            for (int i = n - 1; i != -1; --i)
            {
                for (int j = n - 1; j != -1; --j)
                {
                    if (matrix[i, j] == 1)
                    {
                        result += deg2;
                    }
                    deg2 *= 2;
                }
            }

            return result;
        }
    }
}
