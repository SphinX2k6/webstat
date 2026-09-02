using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.GamePlay.TriggerItems
{
	// Token: 0x02003DC5 RID: 15813
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/GamePlay/TriggerItems/ETriggerType.ETriggerType")]
	public enum ETriggerType : byte
	{
		// Token: 0x04014312 RID: 82706
		Wall,
		// Token: 0x04014313 RID: 82707
		NotOpened,
		// Token: 0x04014314 RID: 82708
		Hurt,
		// Token: 0x04014315 RID: 82709
		Plot,
		// Token: 0x04014316 RID: 82710
		Events,
		// Token: 0x04014317 RID: 82711
		ControlObject,
		// Token: 0x04014318 RID: 82712
		EffectArea,
		// Token: 0x04014319 RID: 82713
		ETriggerType_MAX
	}
}
