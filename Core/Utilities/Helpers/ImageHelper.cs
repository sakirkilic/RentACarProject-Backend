using Core.Utilities.Result;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.IO;
using Entities.DTOs;

namespace Core.Utilities.Helpers
{
	public class ImageHelper
	{


		//public static IDataResult<ImageDto> Upload(IFormFile imageFile)
		//{
		//	ImageDto emptyImage=null;
		//	if (imageFile != null)
		//	{
		//		//foreach (var image in imageFiles)
		//		//{
		//		var imageExtension = Path.GetExtension(imageFile.FileName);
		//		var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageExtension;
		//		var filePath = Path.DirectorySeparatorChar.ToString() + "Images" + Path.DirectorySeparatorChar.ToString() + uniqueFileName;
		//		var uploadsFolder = Path.Combine("wwwroot", "Images");
		//		var filePathForCopy = Path.Combine(uploadsFolder, uniqueFileName);

		//		imageFile.CopyTo(new FileStream(filePathForCopy, FileMode.Create));

		//		var CarImageForAdd = new ImageDto
		//		{
		//			FullName = uniqueFileName,
		//			Extension = imageExtension,
		//			ImagePath = filePath,
		//			FolderName = uploadsFolder
		//		};

		//		return new SuccessDataResult<ImageDto>(CarImageForAdd);
		//		//}
		//	}
		//	return new ErrorDataResult<ImageDto>(emptyImage,false);
		//}
	}
}
