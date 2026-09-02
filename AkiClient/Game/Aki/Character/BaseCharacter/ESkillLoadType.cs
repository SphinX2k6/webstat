using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004227 RID: 16935
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillLoadType.ESkillLoadType")]
	public enum ESkillLoadType : byte
	{
		// Token: 0x04019212 RID: 102930
		AlwaysLoad,
		// Token: 0x04019213 RID: 102931
		Ignore,
		// Token: 0x04019214 RID: 102932
		OnlySummonVision,
		// Token: 0x04019215 RID: 102933
		OnlyShiftVision,
		// Token: 0x04019216 RID: 102934
		ESkillLoadType_MAX
	}
}
