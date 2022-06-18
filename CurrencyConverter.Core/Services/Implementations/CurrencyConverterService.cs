using CurrencyConverter.Core.Services.Interfaces;
using CurrencyConverter.Core.ViewModels.CurrencyConverter;
using CurrencyConverter.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CurrencyConverter.Core.Services.Implementations
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        private CurrencyConverterDbContext _context;
        public CurrencyConverterService(CurrencyConverterDbContext context)
        {
            _context = context;
        }
        public ResultConvertViewModel Convert(DataFormCurrencyConverterViewModel Model)
        {
            try
            {
                decimal FinalAmount = Model.Amount;
                int VertexCount = _context.Currencies.Count();
                List<ConversionRate> ConversionRates = _context.ConversionRates.ToList();
                List<List<int>> graph = new List<List<int>>();
                for (int i = 0; i < VertexCount; i++)
                    graph.Add(new List<int>());

                for (int i = 0; i < ConversionRates.Count-1; i++)
                {
                    graph[ConversionRates[i].FromCurrency].Add(ConversionRates[i].ToCurrency);
                    graph[ConversionRates[i].ToCurrency].Add(ConversionRates[i].FromCurrency);
                }

                List<int> ShortestPath = FindShortestPath(graph, Model.FromCurrencyId, Model.ToCurrencyId, VertexCount);
                string ShortestPathStr = string.Empty;
                if(ShortestPath!=null)
                {
                    for (int i = 0; i < ShortestPath.Count; i++)
                    {
                        ShortestPathStr += _context.Currencies.Where(c => c.Id == ShortestPath[i]).Select(c => c.Title).FirstOrDefault() + " >";
                    }
                    ShortestPathStr = ShortestPathStr.Remove(ShortestPathStr.Length - 1, 1);
                }

                for (int i = 0; i < ShortestPath.Count - 1; i++)
                {
                    if (ConversionRates.Where(r => (r.FromCurrency == ShortestPath[i] && r.ToCurrency == ShortestPath[i + 1])).Any())
                        FinalAmount *= ConversionRates.Where(r => (r.FromCurrency == ShortestPath[i] && r.ToCurrency == ShortestPath[i + 1])).Select(r => r.Rate).FirstOrDefault();

                    else if (ConversionRates.Where(r => (r.FromCurrency == ShortestPath[i + 1] && r.ToCurrency == ShortestPath[i])).Any())
                        FinalAmount *= 1 / ConversionRates.Where(r => (r.FromCurrency == ShortestPath[i + 1] && r.ToCurrency == ShortestPath[i])).Select(r => r.Rate).FirstOrDefault();

                }
                return new ResultConvertViewModel() { FinalAmount = FinalAmount , Path = ShortestPathStr };
            }
            catch (Exception ex)
            {
                return new ResultConvertViewModel() { FinalAmount = -1, Path = null };
            }
            
        }
        private static List<int> FindShortestPath(List<List<int>> graph, int FromCurrencyId, int ToCurrencyId, int VertexCount)
        {
            int[] predecessor = new int[VertexCount];
            int[] distance = new int[VertexCount];

            if (BFSSerch(graph, FromCurrencyId, ToCurrencyId, VertexCount, predecessor, distance) == false)
            {
                return null;
            }

            List<int> path = new List<int>();
            int crawl = ToCurrencyId;
            path.Add(crawl);

            while (predecessor[crawl] != -1)
            {
                path.Add(predecessor[crawl]);
                crawl = predecessor[crawl];
            }

            path.Reverse();
            return path;
        }
        private static bool BFSSerch(List<List<int>> graph, int FromCurrencyId, int ToCurrencyId, int VertexCount, int[] predecessor, int[] distance)
        {
            List<int> queue = new List<int>();

            bool[] visited = new bool[VertexCount];

            for (int i = 0; i < VertexCount; i++)
            {
                visited[i] = false;
                distance[i] = int.MaxValue;
                predecessor[i] = -1;
            }

            visited[FromCurrencyId] = true;
            distance[FromCurrencyId] = 0;
            queue.Add(FromCurrencyId);

            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int i = 0;
                         i < graph[u].Count; i++)
                {
                    if (visited[graph[u][i]] == false)
                    {
                        visited[graph[u][i]] = true;
                        distance[graph[u][i]] = distance[u] + 1;
                        predecessor[graph[u][i]] = u;
                        queue.Add(graph[u][i]);

                        if (graph[u][i] == ToCurrencyId)
                            return true;
                    }
                }
            }
            return false;
        }
        public LoadFormCurrencyConverterViewModel GetDataForm()
        {
            LoadFormCurrencyConverterViewModel _LoadFormCurrencyConverterViewModel = new LoadFormCurrencyConverterViewModel();
            _LoadFormCurrencyConverterViewModel.FromCurrency = _context.Currencies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();

            _LoadFormCurrencyConverterViewModel.ToCurrency = _context.Currencies.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            }).ToList();
            return _LoadFormCurrencyConverterViewModel;
        }
    }
}
