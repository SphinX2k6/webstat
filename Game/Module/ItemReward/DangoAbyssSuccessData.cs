using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B33 RID: 23347
	[NullableContext(1)]
	[Nullable(0)]
	public class DangoAbyssSuccessData : IDangoAbyssSuccessData
	{
		// Token: 0x17009713 RID: 38675
		// (get) Token: 0x0603B0F4 RID: 241908 RVA: 0x00EF29C9 File Offset: 0x00EF0BC9
		// (set) Token: 0x0603B0F5 RID: 241909 RVA: 0x00EF29D1 File Offset: 0x00EF0BD1
		public List<RewardItemData> RewardItemData { get; set; }

		// Token: 0x17009714 RID: 38676
		// (get) Token: 0x0603B0F6 RID: 241910 RVA: 0x00EF29DA File Offset: 0x00EF0BDA
		// (set) Token: 0x0603B0F7 RID: 241911 RVA: 0x00EF29E2 File Offset: 0x00EF0BE2
		public float Progress { get; set; }
	}
}
