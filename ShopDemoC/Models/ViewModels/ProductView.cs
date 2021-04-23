using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Shop.Models.ViewModels
{
	public class ProductView
	{
		public ProductView()
		{
		}

		public ProductView(Product product)
		{
			if (product == null)
			{
				return;
			}

			Id = product.Id;
			Name = product.Name;
			CategoryId = product.CategoryId;
			Status = product.Status;
			PublishDate = product.PublishDate;
			FeatureImage = product.FeatureImage;
			ImgLink1 = product.ImgLink1;
			ImgLink2 = product.ImgLink2;
			ImgLink3 = product.ImgLink3;
			ImgLink4 = product.ImgLink4;
			Description = product.Description;
			Info = product.Info;
			Hot = product.Hot;
			Price = product.Price;
			Brand = product.Brand;
		}

		public void CopyToProduct(ref Product product)
		{
			product.Name = Name;
			product.Price = Price;   // TODO: use product price			
			product.PublishDate = PublishDate;
			product.Status = Status;
			product.CategoryId = CategoryId;
			product.Description = Description;
			product.Info = Info;
			product.Hot = Hot;
			product.Id = Id;
			product.Brand = Brand;
		}
		public long Id { get; set; }

		public string Name { get; set; }

		[Display(Name = "Category")]
		public long CategoryId { get; set; }

		public PublishStatus Status { get; set; }

		[Display(Name = "Publish status")]
		public DateTime PublishDate { get; set; }

		public string Brand { get; set; }

		[Display(Name = "Featured image")]
		public string FeatureImage { get; set; }
		public string ImgLink1 { get; set; }
		public string ImgLink2 { get; set; }
		public string ImgLink3 { get; set; }
		public string ImgLink4 { get; set; }

		public double Price { get; set; }

		[AllowHtml]
		public string Description { get; set; }

		[AllowHtml]
		public string Info { get; set; }

		public int Hot { get; set; }

		public HttpPostedFileBase UploadFile { get; set; }
		public HttpPostedFileBase UploadFile1 { get; set; }
		public HttpPostedFileBase UploadFile2 { get; set; }
		public HttpPostedFileBase UploadFile3 { get; set; }
		public HttpPostedFileBase UploadFile4 { get; set; }
	}
}