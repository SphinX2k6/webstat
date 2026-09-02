using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DB RID: 16859
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAttributeEffectType.EAttributeEffectType")]
	public enum EAttributeEffectType : byte
	{
		// Token: 0x04018FEA RID: 102378
		伤害,
		// Token: 0x04018FEB RID: 102379
		加血,
		// Token: 0x04018FEC RID: 102380
		修改属性,
		// Token: 0x04018FED RID: 102381
		EAttributeEffectType_MAX
	}
}
