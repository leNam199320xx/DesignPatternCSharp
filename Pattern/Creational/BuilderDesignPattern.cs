﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Creational
{
    internal class BuilderDesignPattern
    {
        public class ReportDirector
        {
            public Report MakeReport(ReportBuilder reportBuilder)
            {
                reportBuilder.CreateNewReport();
                reportBuilder.SetReportType();
                reportBuilder.SetReportHeader();
                reportBuilder.SetReportContent();
                reportBuilder.SetReportFooter();
                return reportBuilder.GetReport();
            }
        }
        public class PDFReport : ReportBuilder
        {
            public override void SetReportContent()
            {
                reportObject.ReportContent = "PDF Content Section";
            }
            public override void SetReportFooter()
            {
                reportObject.ReportFooter = "PDF Footer";
            }
            public override void SetReportHeader()
            {
                reportObject.ReportHeader = "PDF Header";
            }
            public override void SetReportType()
            {
                reportObject.ReportType = "PDF";
            }
        }
        public class ExcelReport : ReportBuilder
        {
            public override void SetReportContent()
            {
                reportObject.ReportContent = "Excel Content Section";
            }
            public override void SetReportFooter()
            {
                reportObject.ReportFooter = "Excel Footer";
            }
            public override void SetReportHeader()
            {
                reportObject.ReportHeader = "Excel Header";
            }
            public override void SetReportType()
            {
                reportObject.ReportType = "Excel";
            }
        }
        public class Report
        {
            public string ReportType { get; set; }
            public string ReportHeader { get; set; }
            public string ReportFooter { get; set; }
            public string ReportContent { get; set; }
            public void DisplayReport()
            {
                Console.WriteLine("Report Type :" + ReportType);
                Console.WriteLine("Header :" + ReportHeader);
                Console.WriteLine("Content :" + ReportContent);
                Console.WriteLine("Footer :" + ReportFooter);
            }
        }
        public abstract class ReportBuilder
        {
            protected Report reportObject;
            public abstract void SetReportType();
            public abstract void SetReportHeader();
            public abstract void SetReportContent();
            public abstract void SetReportFooter();
            public void CreateNewReport()
            {
                reportObject = new Report();
            }
            public Report GetReport()
            {
                return reportObject;
            }
        }
    }
}
