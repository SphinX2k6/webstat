using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x020042EC RID: 17132
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EBaseCurveType.EBaseCurveType")]
	public enum EBaseCurveType : byte
	{
		// Token: 0x040197E4 RID: 104420
		线性,
		// Token: 0x040197E5 RID: 104421
		二阶_凹函数,
		// Token: 0x040197E6 RID: 104422
		二阶_凸函数,
		// Token: 0x040197E7 RID: 104423
		三阶_凹函数,
		// Token: 0x040197E8 RID: 104424
		三阶_凸函数,
		// Token: 0x040197E9 RID: 104425
		三阶_S函数,
		// Token: 0x040197EA RID: 104426
		三阶_反S函数,
		// Token: 0x040197EB RID: 104427
		幂函数_凹函数,
		// Token: 0x040197EC RID: 104428
		幂函数_凸函数,
		// Token: 0x040197ED RID: 104429
		幂函数_S函数,
		// Token: 0x040197EE RID: 104430
		幂函数_反S函数,
		// Token: 0x040197EF RID: 104431
		幂函数_抛物线,
		// Token: 0x040197F0 RID: 104432
		缓入缓出,
		// Token: 0x040197F1 RID: 104433
		缓入急出,
		// Token: 0x040197F2 RID: 104434
		急入缓出,
		// Token: 0x040197F3 RID: 104435
		急入急出,
		// Token: 0x040197F4 RID: 104436
		资产曲线,
		// Token: 0x040197F5 RID: 104437
		EBaseCurveType_MAX
	}
}
