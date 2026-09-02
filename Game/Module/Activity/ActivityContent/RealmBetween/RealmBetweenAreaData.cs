using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200652E RID: 25902
	[NullableContext(1)]
	[Nullable(0)]
	public class RealmBetweenAreaData
	{
		// Token: 0x06040C74 RID: 265332 RVA: 0x0109C45C File Offset: 0x0109A65C
		public RealmBetweenAreaData(int areaId)
		{
			this.AreaId = areaId;
		}

		// Token: 0x04024522 RID: 148770
		public int AreaId;

		// Token: 0x04024523 RID: 148771
		public HashSet<int> TravelTaskIdSet = new HashSet<int>();

		// Token: 0x04024524 RID: 148772
		public HashSet<int> PhantomTaskIdSet = new HashSet<int>();

		// Token: 0x04024525 RID: 148773
		public bool IsUnlock;
	}
}
