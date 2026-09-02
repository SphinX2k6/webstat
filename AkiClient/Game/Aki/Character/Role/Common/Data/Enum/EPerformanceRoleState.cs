using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Enum
{
	// Token: 0x0200400E RID: 16398
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Enum/EPerformanceRoleState.EPerformanceRoleState")]
	public enum EPerformanceRoleState : byte
	{
		// Token: 0x040172B1 RID: 94897
		None,
		// Token: 0x040172B2 RID: 94898
		Attribute,
		// Token: 0x040172B3 RID: 94899
		Attribute_Inten,
		// Token: 0x040172B4 RID: 94900
		Attribute_Perform,
		// Token: 0x040172B5 RID: 94901
		Skill_Head,
		// Token: 0x040172B6 RID: 94902
		Skill,
		// Token: 0x040172B7 RID: 94903
		Weapon,
		// Token: 0x040172B8 RID: 94904
		Resonance,
		// Token: 0x040172B9 RID: 94905
		Chip,
		// Token: 0x040172BA RID: 94906
		CreateRole_Forward,
		// Token: 0x040172BB RID: 94907
		CreateRole_Back,
		// Token: 0x040172BC RID: 94908
		CreateRole_Idle,
		// Token: 0x040172BD RID: 94909
		RoleBreach,
		// Token: 0x040172BE RID: 94910
		Favor,
		// Token: 0x040172BF RID: 94911
		Favor_Experience,
		// Token: 0x040172C0 RID: 94912
		Favor_Voice,
		// Token: 0x040172C1 RID: 94913
		Favor_Action,
		// Token: 0x040172C2 RID: 94914
		CreateRole_Head,
		// Token: 0x040172C3 RID: 94915
		CreateRole_Login,
		// Token: 0x040172C4 RID: 94916
		RoleElement,
		// Token: 0x040172C5 RID: 94917
		RoleElement_Stand,
		// Token: 0x040172C6 RID: 94918
		RoleElement_End,
		// Token: 0x040172C7 RID: 94919
		EPerformanceRoleState_MAX
	}
}
