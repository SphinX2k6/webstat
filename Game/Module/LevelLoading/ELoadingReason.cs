using System;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A18 RID: 23064
	public enum ELoadingReason
	{
		// Token: 0x0402111C RID: 135452
		Common,
		// Token: 0x0402111D RID: 135453
		Revive,
		// Token: 0x0402111E RID: 135454
		BehaviorTreeRollback,
		// Token: 0x0402111F RID: 135455
		JumpToNextSubtitleOrChildSeq,
		// Token: 0x04021120 RID: 135456
		TurntableControlViewOnBtnResetClicked,
		// Token: 0x04021121 RID: 135457
		SundialControlViewOnBtnResetClicked,
		// Token: 0x04021122 RID: 135458
		Teleport,
		// Token: 0x04021123 RID: 135459
		LoadingTeleport,
		// Token: 0x04021124 RID: 135460
		SimpleLevelSequence,
		// Token: 0x04021125 RID: 135461
		PlotTeleport,
		// Token: 0x04021126 RID: 135462
		CenterText,
		// Token: 0x04021127 RID: 135463
		Photograph,
		// Token: 0x04021128 RID: 135464
		WaitFormation,
		// Token: 0x04021129 RID: 135465
		Signal,
		// Token: 0x0402112A RID: 135466
		SubLevelLoading,
		// Token: 0x0402112B RID: 135467
		RogueSubLevelLoading,
		// Token: 0x0402112C RID: 135468
		BrokenRock,
		// Token: 0x0402112D RID: 135469
		AbyssSubLevelLoading,
		// Token: 0x0402112E RID: 135470
		RoverSubLevelLoading,
		// Token: 0x0402112F RID: 135471
		CG,
		// Token: 0x04021130 RID: 135472
		QuestFocusMode,
		// Token: 0x04021131 RID: 135473
		SpecialTransition,
		// Token: 0x04021132 RID: 135474
		SpecialTransitionKeep,
		// Token: 0x04021133 RID: 135475
		MotorRideSharing,
		// Token: 0x04021134 RID: 135476
		FindSunSpirit,
		// Token: 0x04021135 RID: 135477
		SlidingBlocks,
		// Token: 0x04021136 RID: 135478
		MusicalInstrument,
		// Token: 0x04021137 RID: 135479
		PlotFormationMemory,
		// Token: 0x04021138 RID: 135480
		None
	}
}
