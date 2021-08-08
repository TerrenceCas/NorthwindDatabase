using System;
using System.Runtime.Serialization;

namespace NorthwindDatabase
{
    [Serializable()]
    public class ProductDto : ISerializable
    {
        public string SupplierIds { get; set; }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int? ReorderLevel { get; set; }
        public int? TargetLevel { get; set; }
        public string QuantityPerUnit { get; set; }
        public bool Discontinued { get; set; }
        public int? MinimumReorderQuantity { get; set; }
        public string Category { get; set; }
        public byte[] Attachments { get; set; }

        public ProductDto() { }

        public ProductDto(SerializationInfo info, StreamingContext context)
        {
            SupplierIds = (string)info.GetValue("SupplierIds", typeof(string));
            Id = (int)info.GetValue("Id", typeof(int));
            ProductCode = (string)info.GetValue("ProductCode", typeof(string));
            ProductName = (string)info.GetValue("ProductName", typeof(string));
            Description = (string)info.GetValue("Description", typeof(string));
            StandardCost = (decimal?)info.GetValue("StandardCost", typeof(decimal?));
            ListPrice = (decimal)info.GetValue("ListPrice", typeof(decimal));
            ReorderLevel = (int?)info.GetValue("ReorderLevel", typeof(int?));
            TargetLevel = (int?)info.GetValue("TargetLevel", typeof(int?));
            QuantityPerUnit = (string)info.GetValue("QuantityPerUnit", typeof(string));
            Discontinued = (bool)info.GetValue("Discontinued", typeof(bool));
            MinimumReorderQuantity = (int?)info.GetValue("MinimumReorderQuantity", typeof(int?));
            Category = (string)info.GetValue("Category", typeof(string));
            Attachments = (byte[])info.GetValue("Attachments", typeof(byte[]));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SupplierIds", SupplierIds);
            info.AddValue("Id", Id);
            info.AddValue("ProductCode", ProductCode);
            info.AddValue("ProductName", ProductName);
            info.AddValue("Description", Description);
            info.AddValue("StandardCost", StandardCost);
            info.AddValue("ListPrice", ListPrice);
            info.AddValue("ReorderLevel", ReorderLevel);
            info.AddValue("TargetLevel", TargetLevel);
            info.AddValue("QuantityPerUnit", QuantityPerUnit);
            info.AddValue("Discontinued", Discontinued);
            info.AddValue("MinimumReorderQuantity", MinimumReorderQuantity);
            info.AddValue("Category", Category);
            info.AddValue("Attachments", Attachments);
        }
    }
}
