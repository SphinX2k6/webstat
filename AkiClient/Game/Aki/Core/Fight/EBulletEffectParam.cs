using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5A RID: 16218
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletEffectParam.EBulletEffectParam")]
	public enum EBulletEffectParam : byte
	{
		// Token: 0x04015569 RID: 87401
		无,
		// Token: 0x0401556A RID: 87402
		激光子弹特效原长度,
		// Token: 0x0401556B RID: 87403
		相对位置,
		// Token: 0x0401556C RID: 87404
		相对旋转,
		// Token: 0x0401556D RID: 87405
		缩放,
		// Token: 0x0401556E RID: 87406
		特效质量,
		// Token: 0x0401556F RID: 87407
		EBulletEffectParam_MAX
	}
}
