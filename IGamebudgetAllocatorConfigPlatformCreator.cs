using System;
using System.Runtime.CompilerServices;

// Token: 0x02003495 RID: 13461
[NullableContext(1)]
public interface IGamebudgetAllocatorConfigPlatformCreator
{
	// Token: 0x0601C653 RID: 116307
	GameBudgetAllocatorConfig CreateNormalEntityConfig();

	// Token: 0x0601C654 RID: 116308
	GameBudgetAllocatorConfig CreateBossEntityConfig();

	// Token: 0x0601C655 RID: 116309
	GameBudgetAllocatorConfig CreateCharacterEntityConfig();

	// Token: 0x0601C656 RID: 116310
	GameBudgetAllocatorConfig CreateNormalNpcEntityConfig();

	// Token: 0x0601C657 RID: 116311
	GameBudgetAllocatorConfig CreateSimpleNpcEntityConfig();

	// Token: 0x0601C658 RID: 116312
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateFightEffectConfig();

	// Token: 0x0601C659 RID: 116313
	GameBudgetAllocatorConfig CreateEffectConfig();

	// Token: 0x0601C65A RID: 116314
	GameBudgetAllocatorConfig CreateEffectImportanceConfig();

	// Token: 0x0601C65B RID: 116315
	GameBudgetAllocatorConfig CreateStabilizeLowEntityConfig();

	// Token: 0x0601C65C RID: 116316
	GameBudgetAllocatorConfig CreateAlwaysTickHotfixConfig();

	// Token: 0x0601C65D RID: 116317
	GameBudgetAllocatorConfig CreateMoveSceneItemEntityConfig();

	// Token: 0x0601C65E RID: 116318
	TsGameBudgetAllocatorTickIntervalDetailConfig CreatePlayerAlwaysTickConfig();

	// Token: 0x0601C65F RID: 116319
	GameBudgetAllocatorConfig CreateNormalEntityAlwaysTickConfig();

	// Token: 0x0601C660 RID: 116320
	GameBudgetAllocatorConfig CreateNormalEntityAlwaysTickWithoutNotRenderedConfig();

	// Token: 0x0601C661 RID: 116321
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateAlwaysTickConfig();

	// Token: 0x0601C662 RID: 116322
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateCameraAlwaysTickConfig();

	// Token: 0x0601C663 RID: 116323
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateIdleExecConfig();

	// Token: 0x0601C664 RID: 116324
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateHUDTickConfig();

	// Token: 0x0601C665 RID: 116325
	GameBudgetAllocatorConfig CreateCharacterRenderConfig();

	// Token: 0x0601C666 RID: 116326
	GameBudgetAllocatorConfig CreateNpcRenderConfig();

	// Token: 0x0601C667 RID: 116327
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateBattleHeadViewConfig();

	// Token: 0x0601C668 RID: 116328
	GameBudgetAllocatorConfig CreateCollisionPlantConfig();

	// Token: 0x0601C669 RID: 116329
	TsGameBudgetAllocatorTickIntervalDetailConfig CreateBlueprintSingletonConfig();

	// Token: 0x0601C66A RID: 116330
	GameBudgetAllocatorConfig CreateSceneBlueprintActorConfig();

	// Token: 0x0601C66B RID: 116331
	GameBudgetAllocatorConfig CreateFarBlueprintActorConfig();

	// Token: 0x0601C66C RID: 116332
	GameBudgetAllocatorConfig CreateSuperFarBlueprintActorConfig();

	// Token: 0x0601C66D RID: 116333
	GameBudgetAllocatorConfig CreateDynamicPhysicsInteractionActorConfig();

	// Token: 0x0601C66E RID: 116334
	GameBudgetAllocatorConfig CreateStaticPhysicsInteractionActorConfig();

	// Token: 0x0601C66F RID: 116335
	GameBudgetAllocatorConfig CreateHighPriorityPhysicsInteractionActorConfig();

	// Token: 0x0601C670 RID: 116336
	GameBudgetAllocatorConfig CreateSpecialBlueprintActorConfig();
}
