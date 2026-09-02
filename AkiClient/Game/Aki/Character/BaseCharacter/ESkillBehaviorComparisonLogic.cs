using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200421D RID: 16925
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillBehaviorComparisonLogic.ESkillBehaviorComparisonLogic")]
	public enum ESkillBehaviorComparisonLogic : byte
	{
		// Token: 0x040191BE RID: 102846
		Greater,
		// Token: 0x040191BF RID: 102847
		GreaterEqual,
		// Token: 0x040191C0 RID: 102848
		Equal,
		// Token: 0x040191C1 RID: 102849
		Less,
		// Token: 0x040191C2 RID: 102850
		LessEqual,
		// Token: 0x040191C3 RID: 102851
		Range,
		// Token: 0x040191C4 RID: 102852
		ESkillBehaviorComparisonLogic_MAX
	}
}
