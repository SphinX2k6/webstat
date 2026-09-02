using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x0200660F RID: 26127
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemSyncWeaponGridViewData : IPinballItemSyncWeaponGridViewData
	{
		// Token: 0x17009F4B RID: 40779
		// (get) Token: 0x0604148D RID: 267405 RVA: 0x010BF6F7 File Offset: 0x010BD8F7
		// (set) Token: 0x0604148E RID: 267406 RVA: 0x010BF6FF File Offset: 0x010BD8FF
		public PinballWeaponData WeaponData { get; set; }

		// Token: 0x17009F4C RID: 40780
		// (get) Token: 0x0604148F RID: 267407 RVA: 0x010BF708 File Offset: 0x010BD908
		// (set) Token: 0x06041490 RID: 267408 RVA: 0x010BF710 File Offset: 0x010BD910
		public bool IsSelected { get; set; }

		// Token: 0x17009F4D RID: 40781
		// (get) Token: 0x06041491 RID: 267409 RVA: 0x010BF719 File Offset: 0x010BD919
		// (set) Token: 0x06041492 RID: 267410 RVA: 0x010BF721 File Offset: 0x010BD921
		public bool CanEquip { get; set; }

		// Token: 0x17009F4E RID: 40782
		// (get) Token: 0x06041493 RID: 267411 RVA: 0x010BF72A File Offset: 0x010BD92A
		// (set) Token: 0x06041494 RID: 267412 RVA: 0x010BF732 File Offset: 0x010BD932
		public bool IsCurRoleEquip { get; set; }

		// Token: 0x17009F4F RID: 40783
		// (get) Token: 0x06041495 RID: 267413 RVA: 0x010BF73B File Offset: 0x010BD93B
		// (set) Token: 0x06041496 RID: 267414 RVA: 0x010BF743 File Offset: 0x010BD943
		public int QualityId { get; set; }

		// Token: 0x17009F50 RID: 40784
		// (get) Token: 0x06041497 RID: 267415 RVA: 0x010BF74C File Offset: 0x010BD94C
		// (set) Token: 0x06041498 RID: 267416 RVA: 0x010BF754 File Offset: 0x010BD954
		public Action<IPinballItemToggleCallback> OnStateChangeDelegate { get; set; }

		// Token: 0x17009F51 RID: 40785
		// (get) Token: 0x06041499 RID: 267417 RVA: 0x010BF75D File Offset: 0x010BD95D
		// (set) Token: 0x0604149A RID: 267418 RVA: 0x010BF765 File Offset: 0x010BD965
		public int RoleId { get; set; }
	}
}
