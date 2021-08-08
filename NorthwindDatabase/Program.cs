using NorthwindDatabase.DbModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;

namespace NorthwindDatabase
{
    class Program
    {
        private static readonly northwindContext _context = new northwindContext();

        static void Main(string[] args)
        {
            var customer = _context.Customers.ToList();
            var customerDto = customer.Select(c => new CustomerDto
            {
                Id = c.Id,
                Company = c.Company,
                LastName = c.LastName,
                FirstName = c.FirstName,
                EmailAddress = c.EmailAddress,
                JobTitle = c.JobTitle,
                BusinessPhone = c.BusinessPhone,
                HomePhone = c.HomePhone,
                MobilePhone = c.MobilePhone,
                FaxNumber = c.FaxNumber,
                Address = c.Address,
                City = c.City,
                StateProvince = c.StateProvince,
                ZipPostalCode = c.ZipPostalCode,
                CountryRegion = c.CountryRegion,
                WebPage = c.WebPage,
                Notes = c.Notes,
                Attachments = c.Attachments,
            });

            var products = _context.Products.ToList();
            var productsDto = new List<ProductDto>();

            foreach (var p in products)
            {
                ProductDto prod = new ProductDto
                {
                    SupplierIds = p.SupplierIds,
                    Id = p.Id,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    ReorderLevel = p.ReorderLevel,
                    TargetLevel = p.TargetLevel,
                    QuantityPerUnit = p.QuantityPerUnit,
                    Discontinued = p.Discontinued,
                    MinimumReorderQuantity = p.MinimumReorderQuantity,
                    Category = p.Category,
                    Attachments = p.Attachments,
                };
                productsDto.Add(prod);
            }

            // CustomerDto
            string xmlCustomersDto = "customersDto.xml";
            ToXmlFile(xmlCustomersDto, productsDto);

            string jsonCustomersDto = "customersDto.json";
            ToJsonFile(jsonCustomersDto, productsDto);

            string binaryCustomersDto = "customersDto.dat";
            ToBinaryFile(binaryCustomersDto, productsDto);

            // ProductDto
            string xmlProductsDto = "productsDto.xml";
            ToXmlFile(xmlProductsDto, productsDto);

            string jsonProductsDto = "productsDto.json";
            ToJsonFile(jsonProductsDto, productsDto);

            string binaryProductsDto = "productsDto.dat";
            ToBinaryFile(binaryProductsDto, productsDto);

            List<SerializedFile> fileList = new List<SerializedFile>
            {
                new SerializedFile{
                    Name = xmlCustomersDto,
                    Size = new FileInfo(xmlCustomersDto).Length },
                new SerializedFile{
                    Name = jsonCustomersDto,
                    Size = new FileInfo(jsonCustomersDto).Length },
                new SerializedFile{
                    Name = binaryCustomersDto,
                    Size = new FileInfo(binaryCustomersDto).Length },
                new SerializedFile{
                    Name = xmlProductsDto,
                    Size = new FileInfo(xmlProductsDto).Length },
                new SerializedFile{
                    Name = jsonProductsDto,
                    Size = new FileInfo(jsonProductsDto).Length },
                new SerializedFile{
                    Name = binaryProductsDto,
                    Size = new FileInfo(binaryProductsDto).Length },
            };

            fileList.Sort();
            int place = 1;
            foreach (var file in fileList)
            {
                WriteLine($"{place++}. {file.Name} : {file.Size} bytes");
            }
        }
        public static void ToBinaryFile<T>(string file, T obj)
        {
            using (Stream st = File.Open(file, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(st, obj);
            }
        }
        public static void ToJsonFile<T>(string file, T obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(file, json);
        }
        public static T FromXmlFile<T>(string file)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(T));
            var xmlContent = File.ReadAllText(file);

            using (StringReader sr = new StringReader(xmlContent))
            {
                return (T)xmls.Deserialize(sr);
            }
        }
        public static void ToXmlFile<T>(string file, T obj)
        {
            using (StringWriter sw =
                new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                xmls.Serialize(sw, obj);
                File.WriteAllText(file, sw.ToString());
            }
        }
    }
}
