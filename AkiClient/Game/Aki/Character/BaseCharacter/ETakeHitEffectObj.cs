using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004230 RID: 16944
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ETakeHitEffectObj.ETakeHitEffectObj")]
	public enum ETakeHitEffectObj : byte
	{
		// Token: 0x0401924A RID: 102986
		Default,
		// Token: 0x0401924B RID: 102987
		子弹未击中,
		// Token: 0x0401924C RID: 102988
		树木,
		// Token: 0x0401924D RID: 102989
		金属,
		// Token: 0x0401924E RID: 102990
		岩石,
		// Token: 0x0401924F RID: 102991
		ETakeHitEffectObj_MAX
	}
}
