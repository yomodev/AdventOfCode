using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021Lib
{
    public static class Utils
    {
        public static IEnumerable<int> Range(int start, int end, int step = 1)
        {
            for (int i = start; i < end; i += step) yield return i;
        }

        public static IEnumerable<int> RangeEnd(int end, int step = 1)
        {
            for (int i = 0; i < end; i += step) yield return i;
        }

        public static IList<T> Fill<T>(this IList<T> list, int numberOfElements)
        {
            foreach (var _ in RangeEnd(numberOfElements)) { list.Add(default); }
            return list; // I chose this so that methods could be chained to it. 
        }

        public static IEnumerable<int> Range(Range range)
        {
            var start = Math.Min(range.Start.Value, range.End.Value);
            var end = Math.Max(range.Start.Value, range.End.Value);
            return Range(start, end);
        }

        public static IEnumerable<int> RangeInclusive(Range range)
        {
            var start = Math.Min(range.Start.Value, range.End.Value);
            var end = Math.Max(range.Start.Value, range.End.Value);
            return Range(start, end + 1);
        }

        public static IEnumerable<IEnumerable<T>> Buffer<T>(this IEnumerable<T> collection, int size, int overlap = 0)
        {
            if (collection == null) throw new NullReferenceException(nameof(collection));
            if (overlap < 0) throw new ArgumentOutOfRangeException(nameof(overlap));
            if (size < 2) throw new ArgumentOutOfRangeException(nameof(size));
            if (overlap >= size) throw new ArgumentOutOfRangeException(nameof(overlap));

            var list = new List<T>();
            foreach (var item in collection)
            {
                list.Add(item);

                if (list.Count == size)
                {
                    yield return list.ToList();
                    list = new List<T>(overlap == 0 
                        ? Enumerable.Empty<T>() : list.Skip(size - overlap));
                }
            }

            if (list.Count != overlap)
            {
                yield return list;
            }
        }

        public static IEnumerable<IEnumerable<T>> Buffer2<T>(this IEnumerable<T> collection, int size, int overlap = 0)
        {
            if (collection == null) throw new NullReferenceException(nameof(collection));
            if (overlap < 0) throw new ArgumentOutOfRangeException(nameof(overlap));
            if (size < 2) throw new ArgumentOutOfRangeException(nameof(size));
            if (overlap > size) throw new ArgumentOutOfRangeException(nameof(overlap));
            var removeFromQueue = 0;

            var queue = new Queue<T>();
            foreach (var item in collection)
            {
                if (removeFromQueue > 0 && queue.Any())
                {
                    queue.Dequeue();
                    removeFromQueue--;
                }

                queue.Enqueue(item);

                if (queue.Count == size && removeFromQueue == 0)
                {
                    removeFromQueue = size - overlap;
                    yield return queue.ToList();
                }
            }

            if (queue.Count > 0 && removeFromQueue != size - overlap)
            {
                yield return queue.Skip(removeFromQueue).ToList();
            }
        }

        public static IEnumerable<IEnumerable<T>> Buffers<T>(this IEnumerable<T> collection, int size, int overlap = 0)
        {
            if (collection == null) throw new NullReferenceException(nameof(collection));
            if (overlap < 0) throw new ArgumentOutOfRangeException(nameof(overlap));
            if (size < 2) throw new ArgumentOutOfRangeException(nameof(size));

            int counter = 0;
            var queue = new Queue<T>();
            var mod = 0;
            foreach (var item in collection)
            {
                counter++;

                if (queue.Count == size)
                {
                    queue.Dequeue();
                }

                queue.Enqueue(item);
                mod = (counter - overlap) % size;
                if (mod == 0 || counter == size)
                {
                    yield return queue.ToList();
                }
            }

            yield return queue.Count == 0 ? null : queue.Skip(size - mod).ToList();
        }

        //UEsDBBQAAAAIANpo2VQM5BkmSAIAAGsGAAAVAAAATmV3IFRleHQgRG9jdW1lbnQudHh0lVRdb9owFH2PlP9wxUNJJErgeQGp6zppUrVV7TRNGn1wkkuxcBzm2ENo9L/3Ok4I4aNsEoJw7ofvOfc4URRBXJo8Z2oz9b2I/rrvOOqi8YoploNkOU56pVbI8kdkGareNI6q2KnEDAXPub6QJbjET21myiQkCDO1ncntTM3kO6Xlkq8+c1Xqr4/Funz3lN+m0Fy+HOUo1EbJkuDmyfdWJhE8hVIzTT9f7qTJUbFEYHzPSx0Tf+o0ncLPpx8PTJWogqdKEnDKDHwvXTAFO/owgf6gPwBXCB3CFOtZlr0BcKmhy4iCowEkRSGgnp8QrQyGvvfX9/angbQQJpe2ROIa9kNB+MH3nqrnj4YL2hqUSZ3XgatEO0VnwnuUL3pB+R106GAq8D1T2slqEZwvYN8k7Vk7KHDx0BFZL7hACFpmfA7Bfofhncy+zV0Dl0G7M5JpjTLDDLCY10VJPRhMYQTbbSPL8LYwRIxAV97AN1lma74XToggtBJsOIoMnB+aBgS/Wq4ultAgywayiqXEsTOw/an0dHNRfNIa4h9mIOBWIHM7SQtJyzfoTkRRIuyadrbya/QMV1e+F5zc4ATGVpKusg+IyyA87jR+DsP/nbNjSFWsSZRWvgsGtSslnvTeQYgk4B+U2jAhNk7AU4SmMHYTnlb+tRH/4FLtTNDFr6+PlD6wAjG6sIx+r0/67y4rPbaGpPCoY/dzBreZc0Z9a/nPWmv/2DP3pt1uekEqS6TK2PN2JQExuFmt6J4FgX2thWldcCjVuTz3eQNQSwECFAAUAAAACADaaNlUDOQZJkgCAABrBgAAFQAAAAAAAAABACAAAAAAAAAATmV3IFRleHQgRG9jdW1lbnQudHh0UEsFBgAAAAABAAEAQwAAAHsCAAAAAA
    }
}
