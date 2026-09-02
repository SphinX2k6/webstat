using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003497 RID: 13463
[NullableContext(1)]
[Nullable(0)]
public class GameBudgetAllocatorConfigPcCreator : IGamebudgetAllocatorConfigPlatformCreator
{
	// Token: 0x0601C690 RID: 116368 RVA: 0x00883204 File Offset: 0x00881404
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
			Cutscene_Fighting = null,
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 1000U, 500U, 10U, 0f, 0f)
		};
	}

	// Token: 0x0601C691 RID: 116369 RVA: 0x008832E0 File Offset: 0x008814E0
	public GameBudgetAllocatorConfig CreateBossEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 5000U, 500U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 5000U, 500U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1500U, 300U, 0f, 0f),
			Normal_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 10U, 5000U, 700U, 0f, 0f),
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1500U, 150U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 1U, 1U, 1U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 5000U, 700U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 10U, 3000U, 300U, 0f, 0f),
			Cutscene_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 5U, 7000U, 700U, 0f, 0f)
		};
	}

	// Token: 0x0601C692 RID: 116370 RVA: 0x00883448 File Offset: 0x00881648
	public GameBudgetAllocatorConfig CreateCharacterEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 3000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 2000U, 200U, 0f, 0f),
			Normal_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 5000U, 500U, 0f, 0f),
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 120U, 2000U, 200U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 20U, 3000U, 500U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 5000U, 700U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 2000U, 200U, 0f, 0f)
		};
	}

	// Token: 0x0601C693 RID: 116371 RVA: 0x00883594 File Offset: 0x00881794
	public GameBudgetAllocatorConfig CreateNormalNpcEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 1000U, 200U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 240U, 1000U, 100U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_Fighting = null,
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 240U, 1000U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C694 RID: 116372 RVA: 0x00883640 File Offset: 0x00881840
	public GameBudgetAllocatorConfig CreateSimpleNpcEntityConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 1000U, 200U, 0f, 0f),
			Normal_Render = null,
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 60U, 500U, 30U, 0f, 0f),
			Normal_Fighting = null,
			Fighting_Rendered = null,
			Fighting_NotRendered = null,
			Fighting_Fighting = null,
			Cutscene_Rendered = null,
			Cutscene_NotRendered = null,
			Cutscene_Fighting = null
		};
	}

	// Token: 0x0601C695 RID: 116373 RVA: 0x008836CD File Offset: 0x008818CD
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateFightEffectConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C696 RID: 116374 RVA: 0x008836E4 File Offset: 0x008818E4
	public GameBudgetAllocatorConfig CreateEffectConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 180U, 500U, 100U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 2000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 200U, 50U, 0f, 0f),
			Normal_Fighting = null,
			Cutscene_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 300U, 500U, 50U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 600U, 200U, 20U, 0f, 0f),
			Fighting_Fighting = null,
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 4500U, 500U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 120U, 1000U, 50U, 0f, 0f)
		};
	}

	// Token: 0x0601C697 RID: 116375 RVA: 0x00883800 File Offset: 0x00881A00
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

	// Token: 0x0601C698 RID: 116376 RVA: 0x00883938 File Offset: 0x00881B38
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

	// Token: 0x0601C699 RID: 116377 RVA: 0x008839A4 File Offset: 0x00881BA4
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

	// Token: 0x0601C69A RID: 116378 RVA: 0x00883A10 File Offset: 0x00881C10
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

	// Token: 0x0601C69B RID: 116379 RVA: 0x00883AB7 File Offset: 0x00881CB7
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreatePlayerAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C69C RID: 116380 RVA: 0x00883AD0 File Offset: 0x00881CD0
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

	// Token: 0x0601C69D RID: 116381 RVA: 0x00883B3C File Offset: 0x00881D3C
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

	// Token: 0x0601C69E RID: 116382 RVA: 0x00883BC3 File Offset: 0x00881DC3
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C69F RID: 116383 RVA: 0x00883BD9 File Offset: 0x00881DD9
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateCameraAlwaysTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C6A0 RID: 116384 RVA: 0x00883BEF File Offset: 0x00881DEF
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateIdleExecConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C6A1 RID: 116385 RVA: 0x00883C06 File Offset: 0x00881E06
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateHUDTickConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 3500U, 500U, 0f, 0f);
	}

	// Token: 0x0601C6A2 RID: 116386 RVA: 0x00883C24 File Offset: 0x00881E24
	public GameBudgetAllocatorConfig CreateCharacterRenderConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 5000U, 300U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 5000U, 300U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 1000U, 200U, 0f, 0f),
			Normal_Fighting = null,
			Cutscene_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 5000U, 500U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 500U, 200U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 13000U, 700U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 13000U, 1300U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 500U, 200U, 0f, 0f)
		};
	}

	// Token: 0x0601C6A3 RID: 116387 RVA: 0x00883D64 File Offset: 0x00881F64
	public GameBudgetAllocatorConfig CreateNpcRenderConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1500U, 500U, 0f, 0f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 30U, 1500U, 500U, 0f, 0f),
			Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f),
			Normal_Fighting = null,
			Cutscene_Fighting = null,
			Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, 1500U, 200U, 0f, 0f),
			Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f),
			Fighting_Fighting = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Fighting, 60U, 1500U, 200U, 0f, 0f),
			Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 10000U, 1000U, 0f, 0f),
			Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, 300U, 100U, 0f, 0f)
		};
	}

	// Token: 0x0601C6A4 RID: 116388 RVA: 0x00883E9B File Offset: 0x0088209B
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateBattleHeadViewConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, 3000U, 500U, 0f, 0f);
	}

	// Token: 0x0601C6A5 RID: 116389 RVA: 0x00883EBC File Offset: 0x008820BC
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

	// Token: 0x0601C6A6 RID: 116390 RVA: 0x00883F57 File Offset: 0x00882157
	public TsGameBudgetAllocatorTickIntervalDetailConfig CreateBlueprintSingletonConfig()
	{
		return new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 1U, 1U, 1U, 0f, 0f);
	}

	// Token: 0x0601C6A7 RID: 116391 RVA: 0x00883F70 File Offset: 0x00882170
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

	// Token: 0x0601C6A8 RID: 116392 RVA: 0x0088401C File Offset: 0x0088221C
	public GameBudgetAllocatorConfig CreateFarBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 8000U, 1000U, 0.2f, 0.005f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 8000U, 1000U, 0.2f, 0.005f),
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

	// Token: 0x0601C6A9 RID: 116393 RVA: 0x008840C8 File Offset: 0x008822C8
	public GameBudgetAllocatorConfig CreateSuperFarBlueprintActorConfig()
	{
		return new GameBudgetAllocatorConfig
		{
			Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 50000U, 30000U, 0.2f, 0.008f),
			Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 20U, 50000U, 30000U, 0.2f, 0.008f),
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

	// Token: 0x0601C6AA RID: 116394 RVA: 0x00884174 File Offset: 0x00882374
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
			Cutscene_NotRendered = null
		};
	}

	// Token: 0x0601C6AB RID: 116395 RVA: 0x00884214 File Offset: 0x00882414
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

	// Token: 0x0601C6AC RID: 116396 RVA: 0x008842B8 File Offset: 0x008824B8
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

	// Token: 0x0601C6AD RID: 116397 RVA: 0x00884364 File Offset: 0x00882564
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
