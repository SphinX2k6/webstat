using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200507A RID: 20602
	[NullableContext(1)]
	public interface IRoleDevProsProjectConfig
	{
		// Token: 0x17008B73 RID: 35699
		// (get) Token: 0x060351D2 RID: 217554
		// (set) Token: 0x060351D3 RID: 217555
		int Id { get; set; }

		// Token: 0x17008B74 RID: 35700
		// (get) Token: 0x060351D4 RID: 217556
		// (set) Token: 0x060351D5 RID: 217557
		int ElementId { get; set; }

		// Token: 0x17008B75 RID: 35701
		// (get) Token: 0x060351D6 RID: 217558
		// (set) Token: 0x060351D7 RID: 217559
		string RoleName { get; set; }

		// Token: 0x17008B76 RID: 35702
		// (get) Token: 0x060351D8 RID: 217560
		// (set) Token: 0x060351D9 RID: 217561
		int RoleExperience { get; set; }

		// Token: 0x17008B77 RID: 35703
		// (get) Token: 0x060351DA RID: 217562
		// (set) Token: 0x060351DB RID: 217563
		int RoleGoalLevel { get; set; }

		// Token: 0x17008B78 RID: 35704
		// (get) Token: 0x060351DC RID: 217564
		// (set) Token: 0x060351DD RID: 217565
		int WeaponGoalLevel { get; set; }

		// Token: 0x17008B79 RID: 35705
		// (get) Token: 0x060351DE RID: 217566
		// (set) Token: 0x060351DF RID: 217567
		int WeaponExperience { get; set; }

		// Token: 0x17008B7A RID: 35706
		// (get) Token: 0x060351E0 RID: 217568
		// (set) Token: 0x060351E1 RID: 217569
		List<int> RoleItemGroup { get; set; }

		// Token: 0x17008B7B RID: 35707
		// (get) Token: 0x060351E2 RID: 217570
		// (set) Token: 0x060351E3 RID: 217571
		List<int> WeaponBreachItemGroup { get; set; }

		// Token: 0x17008B7C RID: 35708
		// (get) Token: 0x060351E4 RID: 217572
		// (set) Token: 0x060351E5 RID: 217573
		int WeaponType { get; set; }

		// Token: 0x17008B7D RID: 35709
		// (get) Token: 0x060351E6 RID: 217574
		// (set) Token: 0x060351E7 RID: 217575
		List<int> SkillItemGroup { get; set; }

		// Token: 0x17008B7E RID: 35710
		// (get) Token: 0x060351E8 RID: 217576
		// (set) Token: 0x060351E9 RID: 217577
		List<int> PrefectSkillLevel { get; set; }

		// Token: 0x17008B7F RID: 35711
		// (get) Token: 0x060351EA RID: 217578
		// (set) Token: 0x060351EB RID: 217579
		string RoleHeadIcon { get; set; }

		// Token: 0x17008B80 RID: 35712
		// (get) Token: 0x060351EC RID: 217580
		// (set) Token: 0x060351ED RID: 217581
		string RoleHeadIconSmall { get; set; }

		// Token: 0x17008B81 RID: 35713
		// (get) Token: 0x060351EE RID: 217582
		// (set) Token: 0x060351EF RID: 217583
		string FormationRoleCard { get; set; }
	}
}
