using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E4 RID: 23012
	[NullableContext(1)]
	[Nullable(0)]
	public class ICommonRoleItemData
	{
		// Token: 0x170094B9 RID: 38073
		// (get) Token: 0x0603A4CD RID: 238797 RVA: 0x00EC8295 File Offset: 0x00EC6495
		// (set) Token: 0x0603A4CE RID: 238798 RVA: 0x00EC829D File Offset: 0x00EC649D
		public int RoleId { get; set; }

		// Token: 0x170094BA RID: 38074
		// (get) Token: 0x0603A4CF RID: 238799 RVA: 0x00EC82A6 File Offset: 0x00EC64A6
		// (set) Token: 0x0603A4D0 RID: 238800 RVA: 0x00EC82AE File Offset: 0x00EC64AE
		public string RoleName { get; set; } = string.Empty;

		// Token: 0x170094BB RID: 38075
		// (get) Token: 0x0603A4D1 RID: 238801 RVA: 0x00EC82B7 File Offset: 0x00EC64B7
		// (set) Token: 0x0603A4D2 RID: 238802 RVA: 0x00EC82BF File Offset: 0x00EC64BF
		public string RoleIcon { get; set; } = string.Empty;

		// Token: 0x170094BC RID: 38076
		// (get) Token: 0x0603A4D3 RID: 238803 RVA: 0x00EC82C8 File Offset: 0x00EC64C8
		// (set) Token: 0x0603A4D4 RID: 238804 RVA: 0x00EC82D0 File Offset: 0x00EC64D0
		public bool IsBuff { get; set; }

		// Token: 0x170094BD RID: 38077
		// (get) Token: 0x0603A4D5 RID: 238805 RVA: 0x00EC82D9 File Offset: 0x00EC64D9
		// (set) Token: 0x0603A4D6 RID: 238806 RVA: 0x00EC82E1 File Offset: 0x00EC64E1
		public int ItemId { get; set; }
	}
}
