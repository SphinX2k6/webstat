using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006530 RID: 25904
	public class FinalTravelTaskData
	{
		// Token: 0x17009E9C RID: 40604
		// (get) Token: 0x06040C78 RID: 265336 RVA: 0x0109C4CF File Offset: 0x0109A6CF
		public int Current
		{
			get
			{
				return this.FinishedIdSet.Count;
			}
		}

		// Token: 0x06040C79 RID: 265337 RVA: 0x0109C4DC File Offset: 0x0109A6DC
		public bool CanReceive()
		{
			return !this.IsReceived && this.Current == this.Target;
		}

		// Token: 0x04024531 RID: 148785
		public int Target = 1;

		// Token: 0x04024532 RID: 148786
		[Nullable(1)]
		public HashSet<int> FinishedIdSet = new HashSet<int>();

		// Token: 0x04024533 RID: 148787
		public bool IsReceived;
	}
}
