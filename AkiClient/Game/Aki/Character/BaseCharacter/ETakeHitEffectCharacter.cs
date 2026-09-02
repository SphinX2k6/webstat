using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200422F RID: 16943
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ETakeHitEffectCharacter.ETakeHitEffectCharacter")]
	public enum ETakeHitEffectCharacter : byte
	{
		// Token: 0x04019244 RID: 102980
		_default,
		// Token: 0x04019245 RID: 102981
		肉质,
		// Token: 0x04019246 RID: 102982
		金属,
		// Token: 0x04019247 RID: 102983
		矿石,
		// Token: 0x04019248 RID: 102984
		ETakeHitEffectCharacter_MAX
	}
}
