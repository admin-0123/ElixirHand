﻿using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ElixirHandShopSQLDBContextSeed
	{
			public static async Task SeedAsync(ElixirHandShopSQLDBContext context, ILoggerFactory loggerFactory)
			{
				try
				{
					//ProductsBrnads Data does not exist
					if (!context.ProductBrands.Any())
					{
						//Then go ahead and read it from the following path and store into brands variable, thanks
						var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(File.ReadAllText(@"C:\brands.json"));

						//Now go ahead, deserialized everything you read from above path, thanks
						//var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

						foreach (var item in brands)
						{
							//iterate all the item and add them into database
							context.ProductBrands.Add(item);
						}
						//Please save them, thanks
						await context.SaveChangesAsync();
					}

					//ProductTypes Data does not exist
					if (!context.ProductTypes.Any())
					{
						//Then go ahead and read it from the following path and store into brands variable, thanks
						var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

						//Now go ahead, deserialized everything you read from above path, thanks
						var types = System.Text.Json.JsonSerializer.Deserialize<List<ProductType>>(typesData);

						foreach (var item in types)
						{
							//iterate all the item and add them into database
							context.ProductTypes.Add(item);
						}
						//Please save them, thanks
						await context.SaveChangesAsync();
					}


					//Products Data does not exist
					if (!context.Products.Any())
					{
						//Then go ahead and read it from the following path and store into brands variable, thanks
						var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

						//Now go ahead, deserialized everything you read from above path, thanks
						var products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productsData);

						foreach (var item in products)
						{
							//iterate all the item and add them into database
							context.Products.Add(item);
						}
						//Please save them, thanks
						await context.SaveChangesAsync();
					}

				}
				catch (Exception ex)
				{
					var logger = loggerFactory.CreateLogger<ElixirHandShopSQLDBContextSeed>();
					logger.LogError(ex.Message);
				}
			}
		}
	}