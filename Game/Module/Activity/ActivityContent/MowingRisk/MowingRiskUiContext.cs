using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200666D RID: 26221
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskUiContext : IMowingRiskContextDisposable
	{
		// Token: 0x0604181F RID: 268319 RVA: 0x010D0789 File Offset: 0x010CE989
		public MowingRiskUiContext(MowingRiskModel attachedModel)
		{
			this.AttachedModel = attachedModel;
		}

		// Token: 0x06041820 RID: 268320 RVA: 0x010D07A3 File Offset: 0x010CE9A3
		public void Dispose()
		{
		}

		// Token: 0x06041821 RID: 268321 RVA: 0x010D07A8 File Offset: 0x010CE9A8
		public void SyncNewBuff(List<int> addBuffIds)
		{
			foreach (int item in addBuffIds)
			{
				if (!this.NewBuffToShowCache.Contains(item))
				{
					this.NewBuffToShowCache.Add(item);
				}
			}
		}

		// Token: 0x06041822 RID: 268322 RVA: 0x010D080C File Offset: 0x010CEA0C
		public void ResetCacheInBattle()
		{
			this.NewBuffToShowCache.Clear();
		}

		// Token: 0x040249AD RID: 149933
		public readonly MowingRiskModel AttachedModel;

		// Token: 0x040249AE RID: 149934
		public EMowingBuffViewUsage CurrentBuffViewUsage;

		// Token: 0x040249AF RID: 149935
		public EMowingBuffTabViewType CurrentBuffViewType;

		// Token: 0x040249B0 RID: 149936
		public int? CurrentChosenOverviewBuffId;

		// Token: 0x040249B1 RID: 149937
		public int? CurrentChosenProgressIndex;

		// Token: 0x040249B2 RID: 149938
		public readonly List<int> NewBuffToShowCache = new List<int>();
	}
}
