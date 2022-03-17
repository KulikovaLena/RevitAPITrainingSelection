using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            

            var levels = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .OfType<Level>()
                .ToList();

            int ducts1=0;
            int ducts2=0;
            int ducts3=0;
            int ductsRoof=0;
            
            foreach (Level level in levels)
            {
                ducts1 = new FilteredElementCollector(doc)
                    .OfClass(typeof(Duct))
                    .OfType<Duct>()
                    .Where(x => x.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString() == "Level 1")
                    .Count();
                
                    ducts1++;
            }

            foreach (Level level in levels)
            {
                ducts2 = new FilteredElementCollector(doc)
                    .OfClass(typeof(Duct))
                    .OfType<Duct>()
                    .Where(x => x.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString() == "Level 2")
                    .Count();

                ducts2++;
            }

            foreach (Level level in levels)
            {
                ducts3 = new FilteredElementCollector(doc)
                    .OfClass(typeof(Duct))
                    .OfType<Duct>()
                    .Where(x => x.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString() == "Level 3")
                    .Count();

                ducts3++;
            }

            foreach (Level level in levels)
            {
                ductsRoof = new FilteredElementCollector(doc)
                    .OfClass(typeof(Duct))
                    .OfType<Duct>()
                    .Where(x => x.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString() == "Roof Level")
                    .Count();

                ductsRoof++;
            }

            TaskDialog.Show($"Ducts count 1:", $"Level 1: {ducts1}{Environment.NewLine}Level 2: {ducts2}{Environment.NewLine}Level 3: {ducts3}{Environment.NewLine}Roof level: {ductsRoof}");

            return Result.Succeeded;
        }
    }
}
