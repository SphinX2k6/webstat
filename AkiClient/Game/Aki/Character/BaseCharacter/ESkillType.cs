using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422D RID: 16941
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ESkillType.ESkillType")]
	public enum ESkillType : byte
	{
		// Token: 0x0401923A RID: 102970
		限定次数技能,
		// Token: 0x0401923B RID: 102971
		多段技能,
		// Token: 0x0401923C RID: 102972
		共享次数技能,
		// Token: 0x0401923D RID: 102973
		ESkillType_MAX
	}
}
