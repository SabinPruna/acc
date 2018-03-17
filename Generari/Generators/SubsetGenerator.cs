using System.Collections.Generic;
using System.Linq;

namespace Generari.Generators {
    public class SubsetGenerator {
        public  IEnumerable<IEnumerable<T>> SubSetsOf<T>(IEnumerable<T> source) {

            if (!source.Any()) {
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);
            }

            IEnumerable<T> element = source.Take(1);

            IEnumerable<IEnumerable<T>> haveNots = SubSetsOf(source.Skip(1));
            IEnumerable<IEnumerable<T>> haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
        }
    }
}