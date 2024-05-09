# glowing-palm-tree


prices found on https://www.marketnews.usda.gov/mnp/fv-report-retail?repType=wiz&run=Run&portal=fv&locChoose=location&commodityClass=allcommodity&startIndex=1&type=retail&class=VEGETABLES&commodity=PEPPERS%2C+OTHER&region=MIDWEST+U.S.&organic=ALL&repDate=03%2F01%2F2024&endDate=03%2F31%2F2024&compareLy=No 

used data from march to have the most current at the moment 

yield will be given as average lbs/acre

price are per lb



update, not sure if it was the computer or VSCode but scaffolding commands were not working

original:
dotnet aspnet-codegenerator razorpage -m Crop -dc RazorPagesCropDbContext -udl -outDir Pages\Crop --referenceScriptLibraries -sqlite

attempt 2 because the key wouldn't recognize and "-sqlite" was obsolete
dotnet ef dbcontext scaffold "Data Source=CropDatabase.db" Microsoft.EntityFrameworkCore.Sqlite

attempt 3 that finally worked after the second key line was implemented
dotnet aspnet-codegenerator razorpage -m Crop -dc CropDbContext -udl -outDir Pages\Crop --referenceScriptLibraries --databaseProvider sqlite

asp-for="AtNewFarm" asp-items="Model.NewFarm" class = "form-control"