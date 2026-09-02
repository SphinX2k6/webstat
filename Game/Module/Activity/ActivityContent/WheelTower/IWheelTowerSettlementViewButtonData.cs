using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006215 RID: 25109
	[NullableContext(1)]
	public interface IWheelTowerSettlementViewButtonData
	{
		// Token: 0x17009BCF RID: 39887
		// (get) Token: 0x0603F59F RID: 259487
		// (set) Token: 0x0603F5A0 RID: 259488
		string Name { get; set; }

		// Token: 0x17009BD0 RID: 39888
		// (get) Token: 0x0603F5A1 RID: 259489
		// (set) Token: 0x0603F5A2 RID: 259490
		Action OnClick { get; set; }

		// Token: 0x17009BD1 RID: 39889
		// (get) Token: 0x0603F5A3 RID: 259491
		// (set) Token: 0x0603F5A4 RID: 259492
		EConfirmBoxConfigId? ConfirmBoxId { get; set; }
	}
}
