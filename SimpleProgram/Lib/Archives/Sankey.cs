using System.Collections.Generic;
using System.Linq;

// ReSharper disable IdentifierTypo

namespace SimpleProgram.Lib.Archives
{
    public class Sankey
    {
        private readonly List<SankeyNode> _nodes = new List<SankeyNode>();
        private readonly List<SankeyLink> _links = new List<SankeyLink>();

        public List<string> NodeLabels => (from n in _nodes select n.Label).ToList();
        public List<int> LinkSources => (from l in _links select l.Source.Index).ToList();
        public List<int> LinkTargets => (from l in _links select l.Target.Index).ToList();
        public List<double> LinkValues => (from l in _links select l.Value).ToList();
        public List<string> LinkLabels => (from l in _links select l.Label).ToList();
        
        public SankeyNode AddNode(string label)
        {
            var node = new SankeyNode(label, _nodes.Count);
            _nodes.Add(node);
            return node;
        }

        public SankeyLink AddLink(SankeyNode source, SankeyNode target, double value, string label = "")
        {
            var link = new SankeyLink(source, target, value, label);
            _links.Add(link);
            return link;
        }
    }

    public struct SankeyNode
    {
        public string Label { get; }
        public int Index { get; }

        public SankeyNode(string label, int index)
        {
            Label = label;
            Index = index;
        }
    }

    public struct SankeyLink
    {
        public SankeyNode Source { get; }
        public SankeyNode Target { get; }
        public double Value { get; }
        public string Label { get; }

        public SankeyLink(SankeyNode source, SankeyNode target, double value, string label)
        {
            Source = source;
            Target = target;
            Value = value;
            Label = label;
        }
    }
}