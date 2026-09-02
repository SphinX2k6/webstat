using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005041 RID: 20545
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevRoleViewItemData : IRoleDevRoleViewItemData
	{
		// Token: 0x17008B16 RID: 35606
		// (get) Token: 0x06034E70 RID: 216688 RVA: 0x00D467C3 File Offset: 0x00D449C3
		// (set) Token: 0x06034E71 RID: 216689 RVA: 0x00D467CB File Offset: 0x00D449CB
		public int RoleId { get; set; }

		// Token: 0x17008B17 RID: 35607
		// (get) Token: 0x06034E72 RID: 216690 RVA: 0x00D467D4 File Offset: 0x00D449D4
		// (set) Token: 0x06034E73 RID: 216691 RVA: 0x00D467DC File Offset: 0x00D449DC
		public int RoleLevel { get; set; }

		// Token: 0x17008B18 RID: 35608
		// (get) Token: 0x06034E74 RID: 216692 RVA: 0x00D467E5 File Offset: 0x00D449E5
		// (set) Token: 0x06034E75 RID: 216693 RVA: 0x00D467ED File Offset: 0x00D449ED
		public bool RoleLevelIsMax { get; set; }

		// Token: 0x17008B19 RID: 35609
		// (get) Token: 0x06034E76 RID: 216694 RVA: 0x00D467F6 File Offset: 0x00D449F6
		// (set) Token: 0x06034E77 RID: 216695 RVA: 0x00D467FE File Offset: 0x00D449FE
		public int BreachLevel { get; set; }

		// Token: 0x17008B1A RID: 35610
		// (get) Token: 0x06034E78 RID: 216696 RVA: 0x00D46807 File Offset: 0x00D44A07
		// (set) Token: 0x06034E79 RID: 216697 RVA: 0x00D4680F File Offset: 0x00D44A0F
		public int RoleGoalUpgradeLevel { get; set; }

		// Token: 0x17008B1B RID: 35611
		// (get) Token: 0x06034E7A RID: 216698 RVA: 0x00D46818 File Offset: 0x00D44A18
		// (set) Token: 0x06034E7B RID: 216699 RVA: 0x00D46820 File Offset: 0x00D44A20
		public int RoleGoalBreakLevel { get; set; }

		// Token: 0x17008B1C RID: 35612
		// (get) Token: 0x06034E7C RID: 216700 RVA: 0x00D46829 File Offset: 0x00D44A29
		// (set) Token: 0x06034E7D RID: 216701 RVA: 0x00D46831 File Offset: 0x00D44A31
		public string RoleName { get; set; }

		// Token: 0x17008B1D RID: 35613
		// (get) Token: 0x06034E7E RID: 216702 RVA: 0x00D4683A File Offset: 0x00D44A3A
		// (set) Token: 0x06034E7F RID: 216703 RVA: 0x00D46842 File Offset: 0x00D44A42
		public int GachaId { get; set; }

		// Token: 0x17008B1E RID: 35614
		// (get) Token: 0x06034E80 RID: 216704 RVA: 0x00D4684B File Offset: 0x00D44A4B
		// (set) Token: 0x06034E81 RID: 216705 RVA: 0x00D46853 File Offset: 0x00D44A53
		public bool IsForecast { get; set; }

		// Token: 0x17008B1F RID: 35615
		// (get) Token: 0x06034E82 RID: 216706 RVA: 0x00D4685C File Offset: 0x00D44A5C
		// (set) Token: 0x06034E83 RID: 216707 RVA: 0x00D46864 File Offset: 0x00D44A64
		public bool IsCall { get; set; }

		// Token: 0x17008B20 RID: 35616
		// (get) Token: 0x06034E84 RID: 216708 RVA: 0x00D4686D File Offset: 0x00D44A6D
		// (set) Token: 0x06034E85 RID: 216709 RVA: 0x00D46875 File Offset: 0x00D44A75
		public bool IsCanUpgrade { get; set; }

		// Token: 0x17008B21 RID: 35617
		// (get) Token: 0x06034E86 RID: 216710 RVA: 0x00D4687E File Offset: 0x00D44A7E
		// (set) Token: 0x06034E87 RID: 216711 RVA: 0x00D46886 File Offset: 0x00D44A86
		public bool IsCanBreach { get; set; }

		// Token: 0x17008B22 RID: 35618
		// (get) Token: 0x06034E88 RID: 216712 RVA: 0x00D4688F File Offset: 0x00D44A8F
		// (set) Token: 0x06034E89 RID: 216713 RVA: 0x00D46897 File Offset: 0x00D44A97
		public bool IsCanShowUpgradeItem { get; set; }

		// Token: 0x17008B23 RID: 35619
		// (get) Token: 0x06034E8A RID: 216714 RVA: 0x00D468A0 File Offset: 0x00D44AA0
		// (set) Token: 0x06034E8B RID: 216715 RVA: 0x00D468A8 File Offset: 0x00D44AA8
		public bool IsCanShowBreachItem { get; set; }

		// Token: 0x17008B24 RID: 35620
		// (get) Token: 0x06034E8C RID: 216716 RVA: 0x00D468B1 File Offset: 0x00D44AB1
		// (set) Token: 0x06034E8D RID: 216717 RVA: 0x00D468B9 File Offset: 0x00D44AB9
		public bool IsFinish { get; set; }

		// Token: 0x17008B25 RID: 35621
		// (get) Token: 0x06034E8E RID: 216718 RVA: 0x00D468C2 File Offset: 0x00D44AC2
		// (set) Token: 0x06034E8F RID: 216719 RVA: 0x00D468CA File Offset: 0x00D44ACA
		public bool IsAllMaterialEnough { get; set; }

		// Token: 0x17008B26 RID: 35622
		// (get) Token: 0x06034E90 RID: 216720 RVA: 0x00D468D3 File Offset: 0x00D44AD3
		// (set) Token: 0x06034E91 RID: 216721 RVA: 0x00D468DB File Offset: 0x00D44ADB
		public List<IRoleDevDetailItemData> DetailItems { get; set; }
	}
}
