﻿using Intex_II_Section4_Team12.Context;
using Intex_II_Section4_Team12.Models;
using Intex_II_Section4_Team12.NavigationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace Intex_II_Section4_Team12.Repositories
{
    public class MummyRepository : IMummyRepository
    {
        public MummyRepository(MummyContext context)
        {
            _context = context;
        }

        private readonly MummyContext _context;
        private int pageSize = 20;

        public Burialmain GetRecord(int recordId)
        {
            return _context
                .Burialmains
                .Include(b => b.BodyAnalysisCharts)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainStructures)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainTextilefunctions)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainColors)
                .SingleOrDefault(b => b.Id == recordId);
        }

        /// <summary>
        /// Get all records with attached entities.
        /// </summary>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        public ICollection<Burialmain> GetAllPaged(int pageNum = 1)
        {
            if (pageNum == 0) { pageNum = 1; }

            var numToSkip = (pageNum - 1) / pageSize;

            var burials = _context
                .Set<Burialmain>()
                // .Include(b => b.BodyAnalysisCharts)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainStructures)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainTextilefunctions)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainColors)
                .Skip(numToSkip)
                .Take(pageSize)
                .ToList();

            return burials;
        }

        public FilteredRecordsWithPages GetFiltered(FilteredRecordRequest request)
        {
            if (request.PageNum == 0) { request.PageNum = 1; }

            var numToSkip = (request.PageNum - 1) * pageSize;

            IQueryable<Burialmain> burials;

            burials = _context
                .Set<Burialmain>()
                //.Include(b => b.BodyAnalysisCharts)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainStructures)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainTextilefunctions)
                .Include(b => b.MainTextiles)
                    .ThenInclude(t => t.MainColors);

            //FILTERS
            //Sex
            if (!String.IsNullOrEmpty(request.Sex))
            {
                burials = burials
                    .Where(b => b.Sex == request.Sex);
            }

            //Burial depths
            if (request.MinBurialDepth.HasValue && request.MinBurialDepth > 0)
            {
                burials = burials
                    .Where(b => b.Depth != null && b.Depth >= request.MinBurialDepth);
            }
            if (request.MaxBurialDepth.HasValue && request.MaxBurialDepth > 0)
            {
                burials = burials
                    .Where(b => b.Depth != null && b.Depth <= request.MaxBurialDepth);
            }

            //Age at Death
            if (request.AgeAtDeath.Count > 0)
            {
                var ageList = new List<string>();
                foreach (var age in request.AgeAtDeath)
                {
                    if (age != "")
                    {
                        ageList.Add(age);
                    }
                }
                burials = burials
                    .Where(b => ageList.Contains(b.Ageatdeath));
            }

            //Head direction
            if (!String.IsNullOrEmpty(request.HeadDirection))
            {
                burials = burials
                    .Where(b => b.Headdirection == request.HeadDirection);
            }

            //Hair colors
            if (request.HairColors.Count > 0)
            {
                burials = burials
                    .Where(b => request.HairColors.Contains(b.Haircolor));
            }

            //Face bundles
            if (request.FaceBundles != null)
            {
                burials = burials
                    .Where(b => b.Facebundles == request.FaceBundles);
            }

            //BODY ANALYSIS
            //Stature
            if (!String.IsNullOrEmpty(request.EstimateStature))
            {
                burials = burials
                    .Where(b => b.BodyAnalysisCharts
                        .Any(c => c.EstimateStature
                            .Contains(request.EstimateStature)));
            }


            //TEXTILE FUNCTIONS
            //Structure
            if (!String.IsNullOrEmpty(request.TextileStructure))
            {
                burials = burials
                    .Where(b => b.MainTextiles
                        .Any(t => t.MainStructures
                            .Any(s => s.Value.Contains(request.TextileStructure))));
            }

            //Color
            if (!String.IsNullOrEmpty(request.TextileColor))
            {
                burials = burials
                    .Where(b => b.MainTextiles
                        .Any(t => t.MainColors
                            .Any(c => c.Value.Contains(request.TextileColor))));
            }

            //Ribbons
            if (request.ContainsRibbons.HasValue && request.ContainsRibbons == true)
            {
                burials = burials
                    .Where(b => b.MainTextiles
                        .Any(t => t.Description.Contains("ribbon")));
            }

            //Function
            if (!String.IsNullOrEmpty(request.TextileFunction))
            {
                burials = burials
                    .Where(b => b.MainTextiles
                        .Any(t => t.MainTextilefunctions
                            .Any(f => f.Value.Contains(request.TextileFunction))));
            }

            //Burial ID
            if (!String.IsNullOrEmpty(request.BurialId))
            {
                burials = burials
                    .Where(b => (b.Squarenorthsouth + b.Northsouth + b.Squareeastwest + b.Eastwest + b.Area + b.Burialnumber) == request.BurialId);
            }

            var burialList = burials
                .Skip(numToSkip)
                .Take(pageSize)
                .ToList();

            var numPages = burials.Count() / pageSize;
            if (numPages == 0) { numPages = 1; }

            FilteredRecordsWithPages response = new FilteredRecordsWithPages(burialList, request.PageNum, numPages);

            return response;

        }


    }
}
