using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006216 RID: 25110
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSettlementViewButtonData : IWheelTowerSettlementViewButtonData
	{
		// Token: 0x17009BD2 RID: 39890
		// (get) Token: 0x0603F5A5 RID: 259493 RVA: 0x0103EB01 File Offset: 0x0103CD01
		// (set) Token: 0x0603F5A6 RID: 259494 RVA: 0x0103EB09 File Offset: 0x0103CD09
		public string Name { get; set; } = string.Empty;

		// Token: 0x17009BD3 RID: 39891
		// (get) Token: 0x0603F5A7 RID: 259495 RVA: 0x0103EB12 File Offset: 0x0103CD12
		// (set) Token: 0x0603F5A8 RID: 259496 RVA: 0x0103EB1A File Offset: 0x0103CD1A
		public Action OnClick { get; set; } = delegate()
		{
		};

		// Token: 0x17009BD4 RID: 39892
		// (get) Token: 0x0603F5A9 RID: 259497 RVA: 0x0103EB23 File Offset: 0x0103CD23
		// (set) Token: 0x0603F5AA RID: 259498 RVA: 0x0103EB2B File Offset: 0x0103CD2B
		public EConfirmBoxConfigId? ConfirmBoxId { get; set; }
	}
}
