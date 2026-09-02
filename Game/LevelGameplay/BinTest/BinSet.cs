using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.BinTest
{
	// Token: 0x02006F4D RID: 28493
	public class BinSet
	{
		// Token: 0x04026771 RID: 157553
		public int BinNum;

		// Token: 0x04026772 RID: 157554
		public double MinX;

		// Token: 0x04026773 RID: 157555
		public double MaxX;

		// Token: 0x04026774 RID: 157556
		public double MaxY;

		// Token: 0x04026775 RID: 157557
		public double DeltaY;

		// Token: 0x04026776 RID: 157558
		public double ReciprocalDeltaY;

		// Token: 0x04026777 RID: 157559
		[Nullable(1)]
		public List<Bin> Bins = new List<Bin>();

		// Token: 0x04026778 RID: 157560
		public double MinY;
	}
}
