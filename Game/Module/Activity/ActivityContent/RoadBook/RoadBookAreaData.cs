using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x0200648B RID: 25739
	[NullableContext(1)]
	[Nullable(0)]
	public class RoadBookAreaData
	{
		// Token: 0x0604091D RID: 264477 RVA: 0x0108CFDB File Offset: 0x0108B1DB
		public RoadBookAreaData(int areaId)
		{
			this.AreaId = areaId;
		}

		// Token: 0x04024219 RID: 147993
		public int AreaId;

		// Token: 0x0402421A RID: 147994
		public HashSet<int> TravelTaskIdSet = new HashSet<int>();

		// Token: 0x0402421B RID: 147995
		public HashSet<int> PhantomTaskIdSet = new HashSet<int>();

		// Token: 0x0402421C RID: 147996
		public bool IsUnlock;
	}
}
