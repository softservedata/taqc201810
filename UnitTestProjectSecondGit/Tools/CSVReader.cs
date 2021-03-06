﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProjectSecondGit.Tools
{
    public class CSVReader : ExternalReader
    {
        private const char CSV_SPLIT_BY = ';';
        //public string Filename { get; private set; }
        //public string Path { get; private set; }

        public CSVReader(string filename) : base(filename)
        {
        }

        public override IList<IList<string>> GetAllCells(string path)
        {
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((row = streamReader.ReadLine()) != null)
                {
                    allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                }
            }
            return allCells;
        }

    }
}
