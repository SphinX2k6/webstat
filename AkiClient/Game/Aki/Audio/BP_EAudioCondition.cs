using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437A RID: 17274
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_EAudioCondition.BP_EAudioCondition")]
	public enum BP_EAudioCondition : byte
	{
		// Token: 0x04019D72 RID: 105842
		FightState,
		// Token: 0x04019D73 RID: 105843
		Time,
		// Token: 0x04019D74 RID: 105844
		Weather,
		// Token: 0x04019D75 RID: 105845
		BP_MAX
	}
}
