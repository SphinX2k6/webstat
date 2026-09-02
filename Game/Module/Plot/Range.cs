using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005353 RID: 21331
	[NullableContext(1)]
	[Nullable(0)]
	internal class Range
	{
		// Token: 0x0603668B RID: 222859 RVA: 0x00DB81E9 File Offset: 0x00DB63E9
		public Range(Vector center, double radiusSquare, HashSet<int> ignoreList)
		{
		}

		// Token: 0x0401F493 RID: 128147
		public Vector Center = center;

		// Token: 0x0401F494 RID: 128148
		public double RadiusSquare = radiusSquare;

		// Token: 0x0401F495 RID: 128149
		public HashSet<int> IgnoreList = ignoreList;
	}
}
