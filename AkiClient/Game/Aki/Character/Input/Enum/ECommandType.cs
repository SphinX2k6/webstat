using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Input.Enum
{
	// Token: 0x020041AB RID: 16811
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Enum/ECommandType.ECommandType")]
	public enum ECommandType : byte
	{
		// Token: 0x04018D60 RID: 101728
		None,
		// Token: 0x04018D61 RID: 101729
		Skill,
		// Token: 0x04018D62 RID: 101730
		Jump,
		// Token: 0x04018D63 RID: 101731
		Climb,
		// Token: 0x04018D64 RID: 101732
		Sprint,
		// Token: 0x04018D65 RID: 101733
		FastSwim,
		// Token: 0x04018D66 RID: 101734
		FastClimb,
		// Token: 0x04018D67 RID: 101735
		SwitchCharacter,
		// Token: 0x04018D68 RID: 101736
		SwitchWalk,
		// Token: 0x04018D69 RID: 101737
		SendGameplayEvent,
		// Token: 0x04018D6A RID: 101738
		XaBoost,
		// Token: 0x04018D6B RID: 101739
		Swallow,
		// Token: 0x04018D6C RID: 101740
		Drop,
		// Token: 0x04018D6D RID: 101741
		ECommandType_MAX
	}
}
