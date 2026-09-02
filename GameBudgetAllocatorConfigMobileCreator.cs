using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003496 RID: 13462
[NullableContext(1)]
[Nullable(0)]
public class GameBudgetAllocatorConfigMobileCreator : IGamebudgetAllocatorConfigPlatformCreator
{
	// Token: 0x0601C671 RID: 116337 RVA: 0x0088205C File Offset: 0x0088025C
	public GameBudgetAllocatorConfig CreateNormalEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 500U, 100U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 500U, 100U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 1000U, 500U, 10U, 0f, 0f),
			Normal_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 2000U, 100U, 0f, 0f),
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 1000U, 500U, 10U, 0f, 0f)
		};
	}

	// Token: 0x0601C672 RID: 116338 RVA: 0x00882130 File Offset: 0x00880330
	public GameBudgetAllocatorConfig CreateBossEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 200U, 0f, 0f),
			Normal_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 10U, 3000U, 500U, 0f, 0f),
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 2000U, 200U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 1U, 1U, 1U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 3000U, 500U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 10U, 2000U, 200U, 0f, 0f),
			Cutscene_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 5U, 5000U, 500U, 0f, 0f)
		};
	}

	// Token: 0x0601C673 RID: 116339 RVA: 0x00882294 File Offset: 0x00880494
	public GameBudgetAllocatorConfig CreateCharacterEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 2000U, 200U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 2000U, 200U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 100U, 0f, 0f),
			Normal_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 3000U, 300U, 0f, 0f),
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 120U, 1000U, 100U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 500U, 50U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 20U, 2000U, 300U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 3500U, 500U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C674 RID: 116340 RVA: 0x008823D8 File Offset: 0x008805D8
	public GameBudgetAllocatorConfig CreateNormalNpcEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 500U, 100U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 240U, 500U, 50U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 240U, 500U, 50U, 0f, 0f)
		};
	}

	// Token: 0x0601C675 RID: 116341 RVA: 0x00882484 File Offset: 0x00880684
	public GameBudgetAllocatorConfig CreateSimpleNpcEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 500U, 100U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 300U, 20U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C676 RID: 116342 RVA: 0x0088250E File Offset: 0x0088070E
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateFightEffectConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C677 RID: 116343 RVA: 0x00882524 File Offset: 0x00880724
	public GameBudgetAllocatorConfig CreateEffectConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 180U, 500U, 100U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 2000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 200U, 50U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 300U, 500U, 50U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 600U, 200U, 20U, 0f, 0f),
			Fighting_Fighting = null,
			Cutscene_Fighting = null,
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 4500U, 500U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 50U, 0f, 0f)
		};
	}

	// Token: 0x0601C678 RID: 116344 RVA: 0x00882640 File Offset: 0x00880840
	public GameBudgetAllocatorConfig CreateEffectImportanceConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 100U, 30000U, 3000U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 100U, 50000U, 5000U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 1000U, 100U, 0f, 0f),
			Normal_Fighting = null,
			Cutscene_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 100U, 5000U, 1000U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 600U, 500U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 100U, 5000U, 1000U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 100U, 50000U, 5000U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 1000U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C679 RID: 116345 RVA: 0x00882778 File Offset: 0x00880978
	public GameBudgetAllocatorConfig CreateStabilizeLowEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 10U, 1U, 1U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = null,
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C67A RID: 116346 RVA: 0x008827E4 File Offset: 0x008809E4
	public GameBudgetAllocatorConfig CreateAlwaysTickHotfixConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = null,
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C67B RID: 116347 RVA: 0x00882850 File Offset: 0x00880A50
	public GameBudgetAllocatorConfig CreateMoveSceneItemEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 3U, 10000U, 5000U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 3U, 10000U, 5000U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 500U, 10U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C67C RID: 116348 RVA: 0x008828F7 File Offset: 0x00880AF7
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreatePlayerAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C67D RID: 116349 RVA: 0x00882910 File Offset: 0x00880B10
	public GameBudgetAllocatorConfig CreateNormalEntityAlwaysTickConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = null,
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C67E RID: 116350 RVA: 0x0088297C File Offset: 0x00880B7C
	public GameBudgetAllocatorConfig CreateNormalEntityAlwaysTickWithoutNotRenderedConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 1000U, 500U, 10U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C67F RID: 116351 RVA: 0x00882A03 File Offset: 0x00880C03
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C680 RID: 116352 RVA: 0x00882A19 File Offset: 0x00880C19
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateCameraAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C681 RID: 116353 RVA: 0x00882A2F File Offset: 0x00880C2F
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateIdleExecConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C682 RID: 116354 RVA: 0x00882A46 File Offset: 0x00880C46
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateHUDTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 2000U, 300U, 0f, 0f);
	}

	// Token: 0x0601C683 RID: 116355 RVA: 0x00882A64 File Offset: 0x00880C64
	public GameBudgetAllocatorConfig CreateCharacterRenderConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 500U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 500U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 500U, 100U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 10000U, 500U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 10000U, 1000U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C684 RID: 116356 RVA: 0x00882B94 File Offset: 0x00880D94
	public GameBudgetAllocatorConfig CreateNpcRenderConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 100U, 100U, 0f, 0f),
			Normal_Fighting = null,
			Cutscene_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 1000U, 100U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 100U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 1000U, 100U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 10000U, 1000U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C685 RID: 116357 RVA: 0x00882CBF File Offset: 0x00880EBF
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateBattleHeadViewConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 2000U, 300U, 0f, 0f);
	}

	// Token: 0x0601C686 RID: 116358 RVA: 0x00882CE0 File Offset: 0x00880EE0
	public GameBudgetAllocatorConfig CreateCollisionPlantConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 3U, 300U, 100U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 3U, 300U, 100U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 3U, 1U, 1U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C687 RID: 116359 RVA: 0x00882D7B File Offset: 0x00880F7B
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateBlueprintSingletonConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C688 RID: 116360 RVA: 0x00882D94 File Offset: 0x00880F94
	public GameBudgetAllocatorConfig CreateSceneBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 2000U, 400U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 2000U, 400U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 1000U, 200U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C689 RID: 116361 RVA: 0x00882E40 File Offset: 0x00881040
	public GameBudgetAllocatorConfig CreateFarBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 8000U, 1000U, 0.3f, 0.01f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 8000U, 1000U, 0.3f, 0.01f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 2000U, 200U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C68A RID: 116362 RVA: 0x00882EEC File Offset: 0x008810EC
	public GameBudgetAllocatorConfig CreateSuperFarBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 50000U, 30000U, 0.3f, 0.01f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 50000U, 30000U, 0.3f, 0.01f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 5000U, 5000U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C68B RID: 116363 RVA: 0x00882F98 File Offset: 0x00881198
	public GameBudgetAllocatorConfig CreateDynamicPhysicsInteractionActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 1000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 1000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 300U, 50U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C68C RID: 116364 RVA: 0x00883040 File Offset: 0x00881240
	public GameBudgetAllocatorConfig CreateStaticPhysicsInteractionActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 10U, 500U, 100U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 10U, 500U, 100U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 300U, 25U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C68D RID: 116365 RVA: 0x008830E4 File Offset: 0x008812E4
	public GameBudgetAllocatorConfig CreateHighPriorityPhysicsInteractionActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 10U, 2000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 10U, 2000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 300U, 25U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C68E RID: 116366 RVA: 0x00883190 File Offset: 0x00881390
	public GameBudgetAllocatorConfig CreateSpecialBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = null,
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}
}
