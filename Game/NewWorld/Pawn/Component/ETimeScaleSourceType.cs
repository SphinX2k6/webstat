using System;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048B1 RID: 18609
	public enum ETimeScaleSourceType
	{
		// Token: 0x0401BDFE RID: 114174
		DefaultTimeScale,
		// Token: 0x0401BDFF RID: 114175
		MyBullet,
		// Token: 0x0401BE00 RID: 114176
		OthersBullet,
		// Token: 0x0401BE01 RID: 114177
		Counter,
		// Token: 0x0401BE02 RID: 114178
		BeCountered,
		// Token: 0x0401BE03 RID: 114179
		BattleSettlement,
		// Token: 0x0401BE04 RID: 114180
		Buff,
		// Token: 0x0401BE05 RID: 114181
		PanelQte,
		// Token: 0x0401BE06 RID: 114182
		TimeStopMachine,
		// Token: 0x0401BE07 RID: 114183
		InnerPauseLock,
		// Token: 0x0401BE08 RID: 114184
		InnerNormalizeTimeScaleLock,
		// Token: 0x0401BE09 RID: 114185
		InnerDelayLock = 10,
		// Token: 0x0401BE0A RID: 114186
		InnerForceTimeScale,
		// Token: 0x0401BE0B RID: 114187
		Portal,
		// Token: 0x0401BE0C RID: 114188
		DeathEffect,
		// Token: 0x0401BE0D RID: 114189
		PhantomArenaBattle,
		// Token: 0x0401BE0E RID: 114190
		SelfCentered,
		// Token: 0x0401BE0F RID: 114191
		SelfBeHit,
		// Token: 0x0401BE10 RID: 114192
		DeadEyeMode,
		// Token: 0x0401BE11 RID: 114193
		MAX,
		// Token: 0x0401BE12 RID: 114194
		UiModel
	}
}
