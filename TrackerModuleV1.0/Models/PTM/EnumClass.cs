using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrackerModuleV1._0.Models.PTM
{
    public class EnumClass
    {
        public enum PartType
        {
            Document = 1,
            Record = 2,
            Mechanical_Part = 3,
            Electrical_or_Electronic_Part = 4,
            Penumatic_Part = 5,
            Material_Part = 6,
            Tools_Part = 7,
            Test_and_Measurement_Equipment_Part = 8,
            Other = 9

        }

        //public  JsonResult subCategoryBind(string Part_Type)
        //{
        //    var subcategorylist = Enum.GetValues(typeo
        //        .Cast<PartType>()
        //        .Select(t => new AccessClass
        //        {
        //            ID = ((int)t),
        //            Name = t.ToString()
        //        });
        //}


        public enum Document
        {
            Product_Definition = 100,
            Concept_Proposal = 101,
            Technical_Specification = 102,
            Technical_Proposal = 103,
            Mechanical_Design_Document = 104,
            Mechanical_Design_Document_3d_Diagram = 201,
            Mechanical_Design_Document_2dDiagram = 202,
            Mechanical_Design_Document_BOM = 203,
            Mechanical_Design_Document_Assy_Diagram = 204,
            Mechanical_Design_Document_Assy_Instruction = 205

        }

        public enum Record
        {
            Mechanical_Design_Review_Record = 200,
            Mechanical_Design_Review_Record_3d_Diagram = 201,
            Review_Summary = 001,
            Evaluation_Results = 002,
            Verification_and_Validation_Results = 003,
            Simulation_Results = 004,
            Ceritfication = 005
        }

        public enum Mechanical_Part
        {
            Automation_Components = 100,
            Framing_Support = 200,
            Fasteners = 300,
            Materials = 500,
            Accessories_Other = 600
        }
    }

    public class AccessClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}