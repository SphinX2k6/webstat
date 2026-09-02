using System;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.BehaviorTree
{
	// Token: 0x02006E3C RID: 28220
	public enum EBTNode
	{
		// Token: 0x040261BA RID: 156090
		TsTaskLog,
		// Token: 0x040261BB RID: 156091
		TsTaskPatrol,
		// Token: 0x040261BC RID: 156092
		TsTaskUseSkillDesignated,
		// Token: 0x040261BD RID: 156093
		TsTaskBlackBoardSetString,
		// Token: 0x040261BE RID: 156094
		TsTaskPatrolWithEvents,
		// Token: 0x040261BF RID: 156095
		TsTaskBlackboardSetValues,
		// Token: 0x040261C0 RID: 156096
		TsTaskPlayMontage,
		// Token: 0x040261C1 RID: 156097
		TsTaskPlayWalkingOverlayMontage,
		// Token: 0x040261C2 RID: 156098
		TsTaskPatrolStateReset,
		// Token: 0x040261C3 RID: 156099
		TsTaskPlayBubble,
		// Token: 0x040261C4 RID: 156100
		TsTaskAddPlayBubble,
		// Token: 0x040261C5 RID: 156101
		TsTaskClearPlayBubble,
		// Token: 0x040261C6 RID: 156102
		TsTaskTurnToPosition,
		// Token: 0x040261C7 RID: 156103
		TsTaskTurnToEntity,
		// Token: 0x040261C8 RID: 156104
		TsTaskNpcLeisureInteract,
		// Token: 0x040261C9 RID: 156105
		TsTaskNpcSitOnChair,
		// Token: 0x040261CA RID: 156106
		TsTaskMoveToTarget,
		// Token: 0x040261CB RID: 156107
		TsTaskEnterPatrolState,
		// Token: 0x040261CC RID: 156108
		TsTaskWait,
		// Token: 0x040261CD RID: 156109
		TsTaskChangeNpcAbpState,
		// Token: 0x040261CE RID: 156110
		TsTaskEnableEntityLookAt,
		// Token: 0x040261CF RID: 156111
		TsTaskDisableEntityLookAt,
		// Token: 0x040261D0 RID: 156112
		TsDecoratorCheck,
		// Token: 0x040261D1 RID: 156113
		TsDecoratorActorsLocation,
		// Token: 0x040261D2 RID: 156114
		TsDecoratorBlackboardStringCompare,
		// Token: 0x040261D3 RID: 156115
		TsDecoratorBlackboardIntCompare,
		// Token: 0x040261D4 RID: 156116
		TsDecoratorBlackboardValuesCompare,
		// Token: 0x040261D5 RID: 156117
		TsDecoratorWeatherStateCheck,
		// Token: 0x040261D6 RID: 156118
		TsDecoratorTimeSpanCheck,
		// Token: 0x040261D7 RID: 156119
		TsDecoratorTimePeriodCheck,
		// Token: 0x040261D8 RID: 156120
		TsDecoratorLevelPlayStateCheck,
		// Token: 0x040261D9 RID: 156121
		TsDecoratorEntityStateCheck,
		// Token: 0x040261DA RID: 156122
		TsDecoratorQuestStateCheck,
		// Token: 0x040261DB RID: 156123
		TsDecoratorQuestStepStateCheck,
		// Token: 0x040261DC RID: 156124
		TsDecoratorVarCompare,
		// Token: 0x040261DD RID: 156125
		TsDecoratorDistanceCheck,
		// Token: 0x040261DE RID: 156126
		TsDecoratorDoOnce,
		// Token: 0x040261DF RID: 156127
		TsServiceAnimalPerception
	}
}
