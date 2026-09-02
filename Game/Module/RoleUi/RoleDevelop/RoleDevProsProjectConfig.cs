using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200507B RID: 20603
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevProsProjectConfig : IRoleDevProsProjectConfig
	{
		// Token: 0x17008B82 RID: 35714
		// (get) Token: 0x060351F1 RID: 217585 RVA: 0x00D52C57 File Offset: 0x00D50E57
		// (set) Token: 0x060351F2 RID: 217586 RVA: 0x00D52C5F File Offset: 0x00D50E5F
		public int Id { get; set; }

		// Token: 0x17008B83 RID: 35715
		// (get) Token: 0x060351F3 RID: 217587 RVA: 0x00D52C68 File Offset: 0x00D50E68
		// (set) Token: 0x060351F4 RID: 217588 RVA: 0x00D52C70 File Offset: 0x00D50E70
		public int ElementId { get; set; }

		// Token: 0x17008B84 RID: 35716
		// (get) Token: 0x060351F5 RID: 217589 RVA: 0x00D52C79 File Offset: 0x00D50E79
		// (set) Token: 0x060351F6 RID: 217590 RVA: 0x00D52C81 File Offset: 0x00D50E81
		public string RoleName { get; set; } = string.Empty;

		// Token: 0x17008B85 RID: 35717
		// (get) Token: 0x060351F7 RID: 217591 RVA: 0x00D52C8A File Offset: 0x00D50E8A
		// (set) Token: 0x060351F8 RID: 217592 RVA: 0x00D52C92 File Offset: 0x00D50E92
		public int RoleExperience { get; set; }

		// Token: 0x17008B86 RID: 35718
		// (get) Token: 0x060351F9 RID: 217593 RVA: 0x00D52C9B File Offset: 0x00D50E9B
		// (set) Token: 0x060351FA RID: 217594 RVA: 0x00D52CA3 File Offset: 0x00D50EA3
		public int RoleGoalLevel { get; set; }

		// Token: 0x17008B87 RID: 35719
		// (get) Token: 0x060351FB RID: 217595 RVA: 0x00D52CAC File Offset: 0x00D50EAC
		// (set) Token: 0x060351FC RID: 217596 RVA: 0x00D52CB4 File Offset: 0x00D50EB4
		public int WeaponGoalLevel { get; set; }

		// Token: 0x17008B88 RID: 35720
		// (get) Token: 0x060351FD RID: 217597 RVA: 0x00D52CBD File Offset: 0x00D50EBD
		// (set) Token: 0x060351FE RID: 217598 RVA: 0x00D52CC5 File Offset: 0x00D50EC5
		public int WeaponExperience { get; set; }

		// Token: 0x17008B89 RID: 35721
		// (get) Token: 0x060351FF RID: 217599 RVA: 0x00D52CCE File Offset: 0x00D50ECE
		// (set) Token: 0x06035200 RID: 217600 RVA: 0x00D52CD6 File Offset: 0x00D50ED6
		public List<int> RoleItemGroup { get; set; } = new List<int>();

		// Token: 0x17008B8A RID: 35722
		// (get) Token: 0x06035201 RID: 217601 RVA: 0x00D52CDF File Offset: 0x00D50EDF
		// (set) Token: 0x06035202 RID: 217602 RVA: 0x00D52CE7 File Offset: 0x00D50EE7
		public List<int> WeaponBreachItemGroup { get; set; } = new List<int>();

		// Token: 0x17008B8B RID: 35723
		// (get) Token: 0x06035203 RID: 217603 RVA: 0x00D52CF0 File Offset: 0x00D50EF0
		// (set) Token: 0x06035204 RID: 217604 RVA: 0x00D52CF8 File Offset: 0x00D50EF8
		public int WeaponType { get; set; }

		// Token: 0x17008B8C RID: 35724
		// (get) Token: 0x06035205 RID: 217605 RVA: 0x00D52D01 File Offset: 0x00D50F01
		// (set) Token: 0x06035206 RID: 217606 RVA: 0x00D52D09 File Offset: 0x00D50F09
		public List<int> SkillItemGroup { get; set; } = new List<int>();

		// Token: 0x17008B8D RID: 35725
		// (get) Token: 0x06035207 RID: 217607 RVA: 0x00D52D12 File Offset: 0x00D50F12
		// (set) Token: 0x06035208 RID: 217608 RVA: 0x00D52D1A File Offset: 0x00D50F1A
		public List<int> PrefectSkillLevel { get; set; } = new List<int>();

		// Token: 0x17008B8E RID: 35726
		// (get) Token: 0x06035209 RID: 217609 RVA: 0x00D52D23 File Offset: 0x00D50F23
		// (set) Token: 0x0603520A RID: 217610 RVA: 0x00D52D2B File Offset: 0x00D50F2B
		public string RoleHeadIcon { get; set; } = string.Empty;

		// Token: 0x17008B8F RID: 35727
		// (get) Token: 0x0603520B RID: 217611 RVA: 0x00D52D34 File Offset: 0x00D50F34
		// (set) Token: 0x0603520C RID: 217612 RVA: 0x00D52D3C File Offset: 0x00D50F3C
		public string RoleHeadIconSmall { get; set; } = string.Empty;

		// Token: 0x17008B90 RID: 35728
		// (get) Token: 0x0603520D RID: 217613 RVA: 0x00D52D45 File Offset: 0x00D50F45
		// (set) Token: 0x0603520E RID: 217614 RVA: 0x00D52D4D File Offset: 0x00D50F4D
		public string FormationRoleCard { get; set; } = string.Empty;
	}
}
