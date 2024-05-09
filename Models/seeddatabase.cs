using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace final_proj
{
    public static class SeedData
    {
            public static void Initialize(IServiceProvider serviceProvider)
            {
            using (var context = new CropDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<CropDbContext>>()))
            {
            // double check to see the crops were seeded so it doesn't seed multiple times 
            if (context.Crops.Any())
            {
                return; // DB has been seeded
            }

            context.Crops.AddRange
            (
            new Crop { cNAme = "Jalapeno", sun = 6, temp = 80, Price = 1.49, avYeild = 15000 },
            new Crop { cNAme = "Tomato", sun = 8, temp = 70, Price = 1.99, avYeild = 25000 },
            new Crop { cNAme = "Spinach", sun = 5, temp = 55, Price = 4.99, avYeild = 14400 },
            new Crop { cNAme = "Arugula", sun = 6, temp = 55, Price = 15.00, avYeild = 9000 },
            new Crop { cNAme = "Tomatillo", sun = 6, temp = 77, Price = 1.49, avYeild = 18000 },
            new Crop { cNAme = "Cucumber", sun = 6, temp = 80, Price = 2.50, avYeild = 19000 },
            new Crop { cNAme = "Cilantro", sun = 5, temp = 65, Price = 1.99, avYeild = 15000 },
            new Crop { cNAme = "Zucchini", sun = 8, temp = 80, Price = 1.89, avYeild = 16000 },
            new Crop { cNAme = "White Onion", sun = 10, temp = 75, Price = 1.49, avYeild = 9900 },
            new Crop { cNAme = "Bell Pepper", sun = 6, temp = 75, Price = 2.59, avYeild = 12000 },
            new Crop { cNAme = "Artichoke", sun = 8, temp = 75, Price = 3.00, avYeild = 4013 },
            new Crop { cNAme = "Pumpkin", sun = 6, temp = 80, Price = 1.00, avYeild = 40000 },
            new Crop { cNAme = "Garlic", sun = 8, temp = 65, Price = 2.00, avYeild = 16500 },
            new Crop { cNAme = "Broccoli", sun = 6, temp = 67, Price = 3.00, avYeild = 10000 },
            new Crop { cNAme = "Brussle Sprouts", sun = 8, temp = 60, Price = 5.99, avYeild = 19600 },
            new Crop { cNAme = "Green Beans", sun = 8, temp = 75, Price = 3.78, avYeild = 13500 },
            new Crop { cNAme = "Carrot", sun = 7, temp = 65, Price = 1.25, avYeild = 34000 },
            new Crop { cNAme = "Eggplant", sun = 6, temp = 82, Price = 1.99, avYeild = 24000 },
            new Crop { cNAme = "Sweet Potato", sun = 6, temp = 85, Price = 0.63, avYeild = 25000 },
            new Crop { cNAme = "Russet Potato", sun = 8, temp = 65, Price = 1.17, avYeild = 43830 },
            new Crop { cNAme = "Cremini Mushroom", sun = 2, temp = 60, Price = 8.00, avYeild = 261360 },
            new Crop { cNAme = "Portabello Mushroom ", sun = 2, temp = 70, Price = 9.99, avYeild = 12000 },
            new Crop { cNAme = "Pinto Bean", sun = 8, temp = 80, Price = 0.38, avYeild = 2648 },
            new Crop { cNAme = "Asparagus", sun = 8, temp = 68, Price = 5.99, avYeild = 4000 },
            new Crop { cNAme = "Caulifower", sun = 6, temp = 60, Price = 2.99, avYeild = 20000 },
            new Crop { cNAme = "Butternut Squash", sun = 6, temp = 83, Price = 2.49, avYeild = 12500 }
            );


            List<Farmer> farmers = new()
            {
            
            new Farmer { fName = "Luna ", address = "Canyon, Tx", avRain = 2.56, avTemp = 82, CostpUnit = 1.78 },
            new Farmer { fName = "James", address = "Fresno, Ca", avRain = 0.61, avTemp = 84, CostpUnit = 3.50 },
            new Farmer { fName = "Liam ", address = "Boise, Id", avRain = 1.71, avTemp = 72, CostpUnit = 2.50 },
            new Farmer { fName = "Conway", address = "Hill City, Ks", avRain = 3.78, avTemp = 76, CostpUnit = 1.98 },
            new Farmer { fName = "Tucker", address = "Orange, Tx", avRain = 4.64, avTemp = 85, CostpUnit = 2.25 },
            };

            context.AddRange(farmers);

            List<Production> productions = new()
            {
            new Production {cID = 18, fID = 0},
            new Production {cID = 19, fID = 0},
            new Production {cID = 25, fID = 0},
            new Production {cID = 24, fID = 0},
            new Production {cID = 17, fID = 0},
            new Production {cID = 7, fID = 0},

            new Production {cID = 2, fID = 1},
            new Production {cID = 21, fID = 1},

            new Production {cID = 0, fID = 2},
            new Production {cID = 1, fID = 2},
            new Production {cID = 4, fID = 2},
            new Production {cID = 6, fID = 2},

            new Production {cID = 9, fID = 3},
            new Production {cID = 10, fID = 3},
            new Production {cID = 11, fID = 3},
            new Production {cID = 16, fID = 3},
            new Production {cID = 24, fID = 3},

            new Production {cID = 2, fID = 4},
            new Production {cID = 3, fID = 4},
            new Production {cID = 14, fID = 4},
            new Production {cID = 23, fID = 4},
            };

            context.AddRange(productions);
               
            context.SaveChanges();
        }
    }
}
}