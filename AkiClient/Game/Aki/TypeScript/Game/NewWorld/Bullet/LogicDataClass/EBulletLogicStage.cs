using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Bullet.LogicDataClass
{
	// Token: 0x020039C4 RID: 14788
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/EBulletLogicStage.EBulletLogicStage")]
	public enum EBulletLogicStage : byte
	{
		// Token: 0x0400EA6E RID: 60014
		OnBegin,
		// Token: 0x0400EA6F RID: 60015
		OnHit,
		// Token: 0x0400EA70 RID: 60016
		OnDestroy,
		// Token: 0x0400EA71 RID: 60017
		OnRebound,
		// Token: 0x0400EA72 RID: 60018
		OnSupport,
		// Token: 0x0400EA73 RID: 60019
		ReplaceMove,
		// Token: 0x0400EA74 RID: 60020
		OnHitBullet,
		// Token: 0x0400EA75 RID: 60021
		OnBulletCollision,
		// Token: 0x0400EA76 RID: 60022
		EBulletLogicStage_MAX
	}
}
