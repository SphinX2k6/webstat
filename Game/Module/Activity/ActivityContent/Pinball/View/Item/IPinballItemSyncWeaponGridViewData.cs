using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660E RID: 26126
	[NullableContext(1)]
	public interface IPinballItemSyncWeaponGridViewData
	{
		// Token: 0x17009F44 RID: 40772
		// (get) Token: 0x0604147F RID: 267391
		// (set) Token: 0x06041480 RID: 267392
		PinballWeaponData WeaponData { get; set; }

		// Token: 0x17009F45 RID: 40773
		// (get) Token: 0x06041481 RID: 267393
		// (set) Token: 0x06041482 RID: 267394
		bool IsSelected { get; set; }

		// Token: 0x17009F46 RID: 40774
		// (get) Token: 0x06041483 RID: 267395
		// (set) Token: 0x06041484 RID: 267396
		bool CanEquip { get; set; }

		// Token: 0x17009F47 RID: 40775
		// (get) Token: 0x06041485 RID: 267397
		// (set) Token: 0x06041486 RID: 267398
		bool IsCurRoleEquip { get; set; }

		// Token: 0x17009F48 RID: 40776
		// (get) Token: 0x06041487 RID: 267399
		// (set) Token: 0x06041488 RID: 267400
		int QualityId { get; set; }

		// Token: 0x17009F49 RID: 40777
		// (get) Token: 0x06041489 RID: 267401
		// (set) Token: 0x0604148A RID: 267402
		Action<IPinballItemToggleCallback> OnStateChangeDelegate { get; set; }

		// Token: 0x17009F4A RID: 40778
		// (get) Token: 0x0604148B RID: 267403
		// (set) Token: 0x0604148C RID: 267404
		int RoleId { get; set; }
	}
}
