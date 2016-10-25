using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CountingCastles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var castleCounter = new CastleCounter();
            castleCounter.CountCastles(1, 1, Parity.Odd);
        }
    }

    public class CastleCounter
    {
        private readonly SolutionCache _cache = new SolutionCache();

        public int CountCastles(int width, int height, Parity parity)
        {
            if (_cache.HasSolution(width, height, parity)) return _cache[width, height, parity];
            if (height == 1 && parity == Parity.Odd)
            {
                _cache[width, height, parity] = 1;
                return 1;
            }

            if (height == 2)
            {
                
            }
        }
    }

    public enum Parity
    {
        Even, Odd
    }
    internal class SolutionCache
    {
        private readonly Dictionary<CastleRules, int> _configurationCount = new Dictionary<CastleRules, int>(); 

        public bool HasSolution(int width, int height, Parity parity)
        {
            return _configurationCount.ContainsKey(new CastleRules(width, height, parity));
        }

        public int this[int width, int height, Parity parity]
        {
            get { return _configurationCount[new CastleRules(width, height, parity)]; }
            set { _configurationCount[new CastleRules(width, height, parity)] = value; }
        } 
    }

    internal class CastleRules
    {
        public int Width { get; }
        public int Height { get; }
        public Parity Parity { get; }

        public CastleRules(int width, int height, Parity parity)
        {
            Width = width;
            Height = height;
            Parity = parity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var other = obj as CastleRules;
            if (ReferenceEquals(other, null)) return false;

            return other.Width == Width && other.Height == Height && other.Parity == Parity;
        }

        protected bool Equals(CastleRules other)
        {
            return Width == other.Width && Height == other.Height && Parity == other.Parity;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Width;
                hashCode = (hashCode*397) ^ Height;
                hashCode = (hashCode*397) ^ (int) Parity;
                return hashCode;
            }
        }
    }
}
