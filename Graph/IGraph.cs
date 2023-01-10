using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graph
{
    public interface IGraph<T> : IEnumerable<T> // düğümdekileri verebilsin diye
    {
        bool isWeightedGraph { get; }  // ağırlık bir graph mu
        int Count { get; }  // sayısı
        IGraphVertex<T> ReferenceVertex { get; }
        IEnumerable<IGraphVertex<T>> VerticesAsEnumberable { get; } // dolaşmak için
        IEnumerable<T> Edges(T key);  // kenarlar
        IGraph<T> Clone();  // klon 
        bool ContainsVertex(T key);   // düğümü içeriyor mu
        IGraphVertex<T> GetVertex(T key);  // düğümü getir
        bool HasEdge(T source, T dest);  // bağlantı var mı düğümler arasında
        void AddVertex(T key);  // düğüm ekle
        void RemoveVertex(T key);  // düğüm sil
        void RemoveEdge(T source, T dest);  // kenar sil
    }

    public interface IDiGraph<T> : IGraph<T>
    {
        new IDiGraphVertex<T> ReferenceVertex { get; } 
        new IEnumerable<IDiGraphVertex<T>> VerticesAsEnumberable { get; }
        new IDiGraphVertex<T> GetVertex(T key);
    }

    public interface IGraphVertex<T> : IEnumerable<T>
    {
        T Key { get; }  // anahtar
        IEnumerable<IEdge<T>> Edges { get; } // kenarlar
        IEdge<T> GetEdge(IGraphVertex<T> targetVertex);  // hedef düğümün özelliklerini ver 
    }

    public interface IDiGraphVertex<T> : IGraphVertex<T>
    {
        IDiEdge<T> GetOutEdge(IDiGraphVertex<T> targetVertex);
        IEnumerable<IDiEdge<T>> OutEdges { get; }
        IEnumerable<IDiEdge<T>> InEdges { get; }
        int OutEdgesCount { get; }
        int InEdgesCount { get; }
    }

    public interface IEdge<T>  // kenar
    {
        T TargetVertexKey { get; } // u dan v ye ise v yi ifade eder
        IGraphVertex<T> TargetVertex { get; } // dugumun kendisi
        W Weight<W>() where W : IComparable;   // kenarın ağırlıgı
    }

    public interface IDiEdge<T> : IEdge<T>
    {
        new IDiGraphVertex<T> TargetVertex { get; }
    }

}
