using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B35 RID: 23349
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiTowerRecordData : IHonamiTowerRecordData
	{
		// Token: 0x17009717 RID: 38679
		// (get) Token: 0x0603B0FD RID: 241917 RVA: 0x00EF29F3 File Offset: 0x00EF0BF3
		// (set) Token: 0x0603B0FE RID: 241918 RVA: 0x00EF29FB File Offset: 0x00EF0BFB
		public string RecordName { get; set; }

		// Token: 0x17009718 RID: 38680
		// (get) Token: 0x0603B0FF RID: 241919 RVA: 0x00EF2A04 File Offset: 0x00EF0C04
		// (set) Token: 0x0603B100 RID: 241920 RVA: 0x00EF2A0C File Offset: 0x00EF0C0C
		public string RecordValue { get; set; }
	}
}
