using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.GamePlay.FindSunSpirit;
using CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite
{
	// Token: 0x02006EB1 RID: 28337
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class FindSunSpiritModel : ModelBase<FindSunSpiritModel>
	{
		// Token: 0x040263F1 RID: 156657
		public AActor CurrentCameraActor;

		// Token: 0x040263F2 RID: 156658
		public BP_FindSunSpiritGlobalConfig_C GlobalConfig;

		// Token: 0x040263F3 RID: 156659
		public IFindSunSpirit Config;

		// Token: 0x040263F4 RID: 156660
		public Vector LevelPosition;

		// Token: 0x040263F5 RID: 156661
		public Rotator LevelRotator;

		// Token: 0x040263F6 RID: 156662
		public Quat LevelQuat;

		// Token: 0x040263F7 RID: 156663
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<FindSunSpiritEndTarget> LevelEndTargetList;

		// Token: 0x040263F8 RID: 156664
		public int ResetTimes;

		// Token: 0x040263F9 RID: 156665
		public int FailResetDelayTime;

		// Token: 0x040263FA RID: 156666
		public bool IsGameFinish;

		// Token: 0x040263FB RID: 156667
		public bool GameFinishResult;

		// Token: 0x040263FC RID: 156668
		public Action<bool> OnFindSunSpiritFinish;

		// Token: 0x040263FD RID: 156669
		public IFindSunSpiritUploadInfo UploadInfo;

		// Token: 0x040263FE RID: 156670
		public FindSunSpiritLevelConfig LevelConfig;

		// Token: 0x040263FF RID: 156671
		public bool IsGameplayReady;

		// Token: 0x04026400 RID: 156672
		public FindSunSpiritLevelPlay LevelPlay;

		// Token: 0x04026401 RID: 156673
		public FindSunSpiritPerformManager PerformManager;

		// Token: 0x04026402 RID: 156674
		public bool IsTriggerCooldown;

		// Token: 0x04026403 RID: 156675
		public int TriggerCooldownTime;

		// Token: 0x04026404 RID: 156676
		public TimerHandle TriggerCooldownTimer;
	}
}
