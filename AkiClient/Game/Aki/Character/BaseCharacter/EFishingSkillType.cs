using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004202 RID: 16898
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EFishingSkillType.EFishingSkillType")]
	public enum EFishingSkillType : byte
	{
		// Token: 0x04019106 RID: 102662
		传送,
		// Token: 0x04019107 RID: 102663
		炸鱼,
		// Token: 0x04019108 RID: 102664
		鱼饵,
		// Token: 0x04019109 RID: 102665
		驱散幽灵,
		// Token: 0x0401910A RID: 102666
		EFishingSkillType_MAX
	}
}
