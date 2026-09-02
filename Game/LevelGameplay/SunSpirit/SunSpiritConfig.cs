using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.NPC.GPUNPC.BP.CrowdAi;
using AkiClient.Game.Aki.Data.Gameplay.SunSpirit;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit
{
	// Token: 0x02006A9A RID: 27290
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritConfig
	{
		// Token: 0x060437CB RID: 276427 RVA: 0x0116356C File Offset: 0x0116176C
		public void UpdateFromUeData(BP_SunSpiritConfig_C ueData)
		{
			this.CrowdAiConfig = ueData.CrowdAiConfig;
			this.CrowdAiSystemIndex = ueData.CrowdAiSystemIndex;
			this.AroundPlayerPosQueryRadius = ueData.AroundPlayerPosQueryRadius;
			this.AroundPlayerPosQueryBoidRadius = ueData.AroundPlayerPosQueryBoidRadius;
			this.AroundPlayerPosQueryMaxTryCount = ueData.AroundPlayerPosQueryMaxTryCount;
			this.FlyingEffectMaxDist = ueData.FlyingEffectMaxDist;
			this.FlyingEffectMinDist = ueData.FlyingEffectMinDist;
			this.FlyingEffectUpdateFailMaxTimeSec = ueData.FlyingEffectUpdateFailMaxTimeSec;
			this.FlyingEffectUpdateFailMaxCount = ueData.FlyingEffectUpdateFailMaxCount;
			this.FlyingEffectMaxFlyingDuration = ueData.FlyingEffectMaxFlyingDuration;
			this.FlyingEffectDaPath = ueData.FlyingEffectDa.ToAssetPathName();
			this.FlyFromPlayerToGearInOrderFromMinToMax = ueData.FlyFromPlayerToGearInOrderFromMinToMax;
			this.FlyFromPlayerToGearDelayInterval = ueData.FlyFromPlayerToGearDelayInterval;
			this.FlyFromPlayerToGearWaitTimeBeforeFly = ueData.FlyFromPlayerToGearWaitTimeBeforeFly;
			this.FlyFromPlayerToGearSpeedForCalc = ueData.FlyFromPlayerToGearSpeedForCalc;
			this.FlyFromPlayerToGearDefaultDuration = ueData.FlyFromPlayerToGearDefaultDuration;
			this.FlyFromGearToPlayerInOrderFromMinToMax = ueData.FlyFromGearToPlayerInOrderFromMinToMax;
			this.FlyFromGearToPlayerDelayInterval = ueData.FlyFromGearToPlayerDelayInterval;
			this.FlyFromGearToPlayerWaitTimeBeforeFly = ueData.FlyFromGearToPlayerWaitTimeBeforeFly;
			this.FlyFromGearToPlayerSpeedForCalc = ueData.FlyFromGearToPlayerSpeedForCalc;
			this.FlyFromGearToPlayerDefaultDuration = ueData.FlyFromGearToPlayerDefaultDuration;
			this.FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc = ueData.FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc;
			this.LauncherHintUiAnchorOffset.FromUeVector2D(ueData.LauncherHintUiAnchorOffset);
			this.LauncherHintUiPosLerpSpeed.FromUeVector2D(ueData.LauncherHintUiPosLerpSpeed);
			this.CharacterHintUiAnchorOffset.FromUeVector2D(ueData.CharacterHintUiAnchorOffset);
			this.CharacterHintUiPosLerpSpeed.FromUeVector2D(ueData.CharacterHintUiPosLerpSpeed);
			this.CharacterHintUiShowDurationWhenUpdate = ueData.CharacterHintUiShowDurationWhenUpdate;
		}

		// Token: 0x04025B19 RID: 154393
		[Nullable(2)]
		public BP_CrowdAiConfig_C CrowdAiConfig;

		// Token: 0x04025B1A RID: 154394
		public int CrowdAiSystemIndex;

		// Token: 0x04025B1B RID: 154395
		public float AroundPlayerPosQueryRadius = 200f;

		// Token: 0x04025B1C RID: 154396
		public float AroundPlayerPosQueryBoidRadius = 25f;

		// Token: 0x04025B1D RID: 154397
		public int AroundPlayerPosQueryMaxTryCount = 10;

		// Token: 0x04025B1E RID: 154398
		public float FlyingEffectMaxDist = 10000f;

		// Token: 0x04025B1F RID: 154399
		public float FlyingEffectMinDist = 1f;

		// Token: 0x04025B20 RID: 154400
		public float FlyingEffectUpdateFailMaxTimeSec = 1f;

		// Token: 0x04025B21 RID: 154401
		public int FlyingEffectUpdateFailMaxCount = 3;

		// Token: 0x04025B22 RID: 154402
		public float FlyingEffectMaxFlyingDuration = 10f;

		// Token: 0x04025B23 RID: 154403
		public string FlyingEffectDaPath = "/Game/Aki/Effect/EffectGroup/SA1Riling/DA_Fx_Group_Riling_Trail02.DA_Fx_Group_Riling_Trail02";

		// Token: 0x04025B24 RID: 154404
		public bool FlyFromPlayerToGearInOrderFromMinToMax = true;

		// Token: 0x04025B25 RID: 154405
		public float FlyFromPlayerToGearDelayInterval = 0.15f;

		// Token: 0x04025B26 RID: 154406
		public float FlyFromPlayerToGearWaitTimeBeforeFly = 1f;

		// Token: 0x04025B27 RID: 154407
		public float FlyFromPlayerToGearSpeedForCalc = 500f;

		// Token: 0x04025B28 RID: 154408
		public float FlyFromPlayerToGearDefaultDuration = 2f;

		// Token: 0x04025B29 RID: 154409
		public bool FlyFromGearToPlayerInOrderFromMinToMax;

		// Token: 0x04025B2A RID: 154410
		public float FlyFromGearToPlayerDelayInterval = 0.15f;

		// Token: 0x04025B2B RID: 154411
		public float FlyFromGearToPlayerWaitTimeBeforeFly = 1f;

		// Token: 0x04025B2C RID: 154412
		public float FlyFromGearToPlayerSpeedForCalc = 500f;

		// Token: 0x04025B2D RID: 154413
		public float FlyFromGearToPlayerDefaultDuration = 2f;

		// Token: 0x04025B2E RID: 154414
		public float FlyFromGearToPlayerMaxOffsetForReQueryTargetLoc = 400f;

		// Token: 0x04025B2F RID: 154415
		public Vector2D LauncherHintUiAnchorOffset = Vector2D.Create(50.0, -100.0);

		// Token: 0x04025B30 RID: 154416
		public Vector2D LauncherHintUiPosLerpSpeed = Vector2D.Create(5.0, 5.0);

		// Token: 0x04025B31 RID: 154417
		public Vector2D CharacterHintUiAnchorOffset = Vector2D.Create(100.0, -100.0);

		// Token: 0x04025B32 RID: 154418
		public Vector2D CharacterHintUiPosLerpSpeed = Vector2D.Create(5.0, 5.0);

		// Token: 0x04025B33 RID: 154419
		public float CharacterHintUiShowDurationWhenUpdate = 3f;
	}
}
