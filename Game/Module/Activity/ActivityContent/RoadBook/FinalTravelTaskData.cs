using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200648D RID: 25741
	public class FinalTravelTaskData
	{
		// Token: 0x17009E5E RID: 40542
		// (get) Token: 0x06040921 RID: 264481 RVA: 0x0108D04E File Offset: 0x0108B24E
		public int Current
		{
			get
			{
				return this.FinishedIdSet.Count;
			}
		}

		// Token: 0x06040922 RID: 264482 RVA: 0x0108D05B File Offset: 0x0108B25B
		public bool CanReceive()
		{
			return !this.IsReceived && this.Current == this.Target;
		}

		// Token: 0x04024228 RID: 148008
		public int Target = 1;

		// Token: 0x04024229 RID: 148009
		[Nullable(1)]
		public HashSet<int> FinishedIdSet = new HashSet<int>();

		// Token: 0x0402422A RID: 148010
		public bool IsReceived;
	}
}
