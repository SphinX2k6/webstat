using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006273 RID: 25203
	public interface ITotalTopUpPickRoleRewardItemData
	{
		// Token: 0x17009C3E RID: 39998
		// (get) Token: 0x0603F7B6 RID: 260022
		// (set) Token: 0x0603F7B7 RID: 260023
		int Index { get; set; }

		// Token: 0x17009C3F RID: 39999
		// (get) Token: 0x0603F7B8 RID: 260024
		// (set) Token: 0x0603F7B9 RID: 260025
		int RoleId { get; set; }

		// Token: 0x17009C40 RID: 40000
		// (get) Token: 0x0603F7BA RID: 260026
		// (set) Token: 0x0603F7BB RID: 260027
		int RoleChain { get; set; }

		// Token: 0x17009C41 RID: 40001
		// (get) Token: 0x0603F7BC RID: 260028
		// (set) Token: 0x0603F7BD RID: 260029
		bool RoleOwned { get; set; }

		// Token: 0x17009C42 RID: 40002
		// (get) Token: 0x0603F7BE RID: 260030
		// (set) Token: 0x0603F7BF RID: 260031
		int ItemId { get; set; }

		// Token: 0x17009C43 RID: 40003
		// (get) Token: 0x0603F7C0 RID: 260032
		// (set) Token: 0x0603F7C1 RID: 260033
		int ItemCount { get; set; }

		// Token: 0x17009C44 RID: 40004
		// (get) Token: 0x0603F7C2 RID: 260034
		// (set) Token: 0x0603F7C3 RID: 260035
		bool CanClaim { get; set; }
	}
}
