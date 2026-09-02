using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.World.Controller;
using UnrealEngine;

namespace CSharpScript.Game.World.Define
{
	// Token: 0x020046DD RID: 18141
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GameBudgetAllocatorConfigCreator : Singleton<GameBudgetAllocatorConfigCreator>
	{
		// Token: 0x17008121 RID: 33057
		// (get) Token: 0x0602F2C2 RID: 193218 RVA: 0x00B2CF63 File Offset: 0x00B2B163
		public TsGameBudgetGroupConfigCache TsNormalEntityGroupConfig
		{
			get
			{
				return this.TsNormalEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008122 RID: 33058
		// (get) Token: 0x0602F2C3 RID: 193219 RVA: 0x00B2CF6B File Offset: 0x00B2B16B
		public TsGameBudgetGroupConfigCache TsBossEntityGroupConfig
		{
			get
			{
				return this.TsBossEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008123 RID: 33059
		// (get) Token: 0x0602F2C4 RID: 193220 RVA: 0x00B2CF73 File Offset: 0x00B2B173
		public TsGameBudgetGroupConfigCache TsCharacterEntityGroupConfig
		{
			get
			{
				return this.TsCharacterEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008124 RID: 33060
		// (get) Token: 0x0602F2C5 RID: 193221 RVA: 0x00B2CF7B File Offset: 0x00B2B17B
		public TsGameBudgetGroupConfigCache TsNormalNpcEntityGroupConfig
		{
			get
			{
				return this.TsNormalNpcEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008125 RID: 33061
		// (get) Token: 0x0602F2C6 RID: 193222 RVA: 0x00B2CF83 File Offset: 0x00B2B183
		public TsGameBudgetGroupConfigCache TsSimpleNpcEntityGroupConfig
		{
			get
			{
				return this.TsSimpleNpcEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008126 RID: 33062
		// (get) Token: 0x0602F2C7 RID: 193223 RVA: 0x00B2CF8B File Offset: 0x00B2B18B
		public TsGameBudgetGroupConfigCache TsFightEffectGroupConfig
		{
			get
			{
				return this.TsFightEffectGroupConfigInternal;
			}
		}

		// Token: 0x17008127 RID: 33063
		// (get) Token: 0x0602F2C8 RID: 193224 RVA: 0x00B2CF93 File Offset: 0x00B2B193
		public TsGameBudgetGroupConfigCache TsEffectGroupConfig
		{
			get
			{
				return this.TsEffectGroupConfigInternal;
			}
		}

		// Token: 0x17008128 RID: 33064
		// (get) Token: 0x0602F2C9 RID: 193225 RVA: 0x00B2CF9B File Offset: 0x00B2B19B
		public TsGameBudgetGroupConfigCache TsEffectInportanceGroupConfig
		{
			get
			{
				return this.TsEffectInportanceGroupConfigInternal;
			}
		}

		// Token: 0x17008129 RID: 33065
		// (get) Token: 0x0602F2CA RID: 193226 RVA: 0x00B2CFA3 File Offset: 0x00B2B1A3
		public TsGameBudgetGroupConfigCache TsAlwaysTickConfig
		{
			get
			{
				return this.TsAlwaysTickConfigInternal;
			}
		}

		// Token: 0x1700812A RID: 33066
		// (get) Token: 0x0602F2CB RID: 193227 RVA: 0x00B2CFAB File Offset: 0x00B2B1AB
		public TsGameBudgetGroupConfigCache TsPlayerAlwaysTickConfig
		{
			get
			{
				return this.TsPlayerAlwaysTickConfigInternal;
			}
		}

		// Token: 0x1700812B RID: 33067
		// (get) Token: 0x0602F2CC RID: 193228 RVA: 0x00B2CFB3 File Offset: 0x00B2B1B3
		public TsGameBudgetGroupConfigCache TsNormalEntityAlwaysTickConfig
		{
			get
			{
				return this.TsNormalEntityAlwaysTickConfigInternal;
			}
		}

		// Token: 0x1700812C RID: 33068
		// (get) Token: 0x0602F2CD RID: 193229 RVA: 0x00B2CFBB File Offset: 0x00B2B1BB
		public TsGameBudgetGroupConfigCache TsNormalEntityAlwaysTickWithoutNotRenderedConfig
		{
			get
			{
				return this.TsNormalEntityAlwaysTickWithoutNotRenderedConfigInternal;
			}
		}

		// Token: 0x1700812D RID: 33069
		// (get) Token: 0x0602F2CE RID: 193230 RVA: 0x00B2CFC3 File Offset: 0x00B2B1C3
		public TsGameBudgetGroupConfigCache TsIdleExecConfig
		{
			get
			{
				return this.TsIdleExecConfigInternal;
			}
		}

		// Token: 0x1700812E RID: 33070
		// (get) Token: 0x0602F2CF RID: 193231 RVA: 0x00B2CFCB File Offset: 0x00B2B1CB
		public TsGameBudgetGroupConfigCache TsAlwaysTick2Config
		{
			get
			{
				return this.TsAlwaysTick2ConfigInternal;
			}
		}

		// Token: 0x1700812F RID: 33071
		// (get) Token: 0x0602F2D0 RID: 193232 RVA: 0x00B2CFD3 File Offset: 0x00B2B1D3
		public TsGameBudgetGroupConfigCache TsHUDTickConfig
		{
			get
			{
				return this.TsHUDTickConfigInternal;
			}
		}

		// Token: 0x17008130 RID: 33072
		// (get) Token: 0x0602F2D1 RID: 193233 RVA: 0x00B2CFDB File Offset: 0x00B2B1DB
		public TsGameBudgetGroupConfigCache TsCharacterRenderConfig
		{
			get
			{
				return this.TsCharacterRenderConfigInternal;
			}
		}

		// Token: 0x17008131 RID: 33073
		// (get) Token: 0x0602F2D2 RID: 193234 RVA: 0x00B2CFE3 File Offset: 0x00B2B1E3
		public TsGameBudgetGroupConfigCache TsNpcRenderConfig
		{
			get
			{
				return this.TsNpcRenderConfigInternal;
			}
		}

		// Token: 0x17008132 RID: 33074
		// (get) Token: 0x0602F2D3 RID: 193235 RVA: 0x00B2CFEB File Offset: 0x00B2B1EB
		public TsGameBudgetGroupConfigCache TsStabilizeLowEntityGroupConfig
		{
			get
			{
				return this.TsStabilizeLowEntityGroupConfigInternal;
			}
		}

		// Token: 0x17008133 RID: 33075
		// (get) Token: 0x0602F2D4 RID: 193236 RVA: 0x00B2CFF3 File Offset: 0x00B2B1F3
		public TsGameBudgetGroupConfigCache TsBattleHeadStateViewConfig
		{
			get
			{
				return this.TsBattleHeadStateViewConfigInternal;
			}
		}

		// Token: 0x17008134 RID: 33076
		// (get) Token: 0x0602F2D5 RID: 193237 RVA: 0x00B2CFFB File Offset: 0x00B2B1FB
		public GameBudgetAllocatorConfig TsCharacterDtailConfig
		{
			get
			{
				return this.TsCharacterDtailConfigInternal;
			}
		}

		// Token: 0x17008135 RID: 33077
		// (get) Token: 0x0602F2D6 RID: 193238 RVA: 0x00B2D003 File Offset: 0x00B2B203
		public TsGameBudgetGroupConfigCache TsAlwaysTickHotFixConfig
		{
			get
			{
				return this.TsAlwaysTickHotFixConfigInternal;
			}
		}

		// Token: 0x17008136 RID: 33078
		// (get) Token: 0x0602F2D7 RID: 193239 RVA: 0x00B2D00B File Offset: 0x00B2B20B
		public TsGameBudgetGroupConfigCache TsMoveSceneItemEntityConfig
		{
			get
			{
				return this.TsMoveSceneItemEntityConfigInternal;
			}
		}

		// Token: 0x17008137 RID: 33079
		// (get) Token: 0x0602F2D8 RID: 193240 RVA: 0x00B2D013 File Offset: 0x00B2B213
		public TsGameBudgetGroupConfigCache TsCollisionPlantConfig
		{
			get
			{
				return this.TsCollisionPlantConfigInternal;
			}
		}

		// Token: 0x17008138 RID: 33080
		// (get) Token: 0x0602F2D9 RID: 193241 RVA: 0x00B2D01B File Offset: 0x00B2B21B
		public TsGameBudgetGroupConfigCache TsBlueprintSingletonConfig
		{
			get
			{
				return this.TsBlueprintSingletonConfigInternal;
			}
		}

		// Token: 0x17008139 RID: 33081
		// (get) Token: 0x0602F2DA RID: 193242 RVA: 0x00B2D023 File Offset: 0x00B2B223
		public TsGameBudgetGroupConfigCache TsSceneBlueprintActorConfig
		{
			get
			{
				return this.TsSceneBlueprintActorConfigInternal;
			}
		}

		// Token: 0x1700813A RID: 33082
		// (get) Token: 0x0602F2DB RID: 193243 RVA: 0x00B2D02B File Offset: 0x00B2B22B
		public TsGameBudgetGroupConfigCache TsFarBlueprintActorConfig
		{
			get
			{
				return this.TsFarBlueprintActorConfigInternal;
			}
		}

		// Token: 0x1700813B RID: 33083
		// (get) Token: 0x0602F2DC RID: 193244 RVA: 0x00B2D033 File Offset: 0x00B2B233
		public TsGameBudgetGroupConfigCache TsSuperFarBlueprintActorConfig
		{
			get
			{
				return this.TsSuperFarBlueprintActorConfigInternal;
			}
		}

		// Token: 0x1700813C RID: 33084
		// (get) Token: 0x0602F2DD RID: 193245 RVA: 0x00B2D03B File Offset: 0x00B2B23B
		public TsGameBudgetGroupConfigCache TsDynamicPhysicsInteractionActorConfig
		{
			get
			{
				return this.TsDynamicPhysicsInteractionActorConfigInternal;
			}
		}

		// Token: 0x1700813D RID: 33085
		// (get) Token: 0x0602F2DE RID: 193246 RVA: 0x00B2D043 File Offset: 0x00B2B243
		public TsGameBudgetGroupConfigCache TsStaticPhysicsInteractionActorConfig
		{
			get
			{
				return this.TsStaticPhysicsInteractionActorConfigInternal;
			}
		}

		// Token: 0x1700813E RID: 33086
		// (get) Token: 0x0602F2DF RID: 193247 RVA: 0x00B2D04B File Offset: 0x00B2B24B
		public TsGameBudgetGroupConfigCache TsHighPriorityPhysicsInteractionActorConfig
		{
			get
			{
				return this.TsHighPriorityPhysicsInteractionActorConfigInternal;
			}
		}

		// Token: 0x1700813F RID: 33087
		// (get) Token: 0x0602F2E0 RID: 193248 RVA: 0x00B2D053 File Offset: 0x00B2B253
		public TsGameBudgetGroupConfigCache TsSpecialBlueprintActorConfig
		{
			get
			{
				return this.TsSpecialBlueprintActorConfigInternal;
			}
		}

		// Token: 0x17008140 RID: 33088
		// (get) Token: 0x0602F2E1 RID: 193249 RVA: 0x00B2D05B File Offset: 0x00B2B25B
		public TsGameBudgetGroupConfigCache TsSparseGridPhysicsInteractionActorConfig
		{
			get
			{
				return this.TsSparseGridPhysicsInteractionActorConfigInternal;
			}
		}

		// Token: 0x0602F2E2 RID: 193250 RVA: 0x00B2D063 File Offset: 0x00B2B263
		public void CreateCharacterEntityConfigOnly()
		{
			this.TsCharacterDtailConfigInternal = this.CreateCharacterEntityConfig(new GameBudgetAllocatorConfigMobileCreator(), false);
		}

		// Token: 0x0602F2E3 RID: 193251 RVA: 0x00B2D078 File Offset: 0x00B2B278
		public void CreateConfigs()
		{
			IGamebudgetAllocatorConfigPlatformCreator creator;
			if (Singleton<Info>.Instance.IsPcPlatform())
			{
				creator = new GameBudgetAllocatorConfigPcCreator();
			}
			else
			{
				creator = new GameBudgetAllocatorConfigMobileCreator();
			}
			this.CreateNormalEntityConfig(creator);
			this.CreateBossEntityConfig(creator, true);
			this.CreateCharacterEntityConfig(creator, true);
			this.CreateNormalNpcEntityConfig(creator, true);
			this.CreateSimpleNpcEntityConfig(creator, true);
			this.CreateFightEffectConfig(creator);
			this.CreateEffectConfig(creator);
			this.CreateEffectImportanceConfig(creator);
			this.CreateStabilizeLowEntityConfig(creator);
			this.CreateAlwaysTickHotfixConfig(creator);
			this.CreateMoveSceneItemEntityConfig(creator);
			this.CreatePlayerAlwaysTickConfig(creator);
			this.CreateNormalEntityAlwaysTickConfig(creator);
			this.CreateNormalEntityAlwaysTickWithoutNotRenderedConfig(creator);
			this.CreateAlwaysTickConfig(creator);
			this.CreateCameraAlwaysTickConfig(creator);
			this.CreateIdleExecConfig(creator);
			this.CreateHUDTickConfig(creator);
			this.CreateCharacterRenderConfig(creator);
			this.CreateNpcRenderConfig(creator);
			this.CreateBattleHeadViewConfig(creator);
			this.CreateCollisionPlantConfig(creator);
			this.CreateBlueprintSingletonConfig(creator);
			this.CreateSceneBlueprintActorConfig(creator);
			this.CreateFarBlueprintActorConfig(creator);
			this.CreateSuperFarBlueprintActorConfig(creator);
			this.CreateDynamicPhysicsInteractionActorConfig(creator);
			this.CreateStaticPhysicsInteractionActorConfig(creator);
			this.CreateHighPriorityPhysicsInteractionActorConfig(creator);
			this.CreateSpecialBlueprintActorConfig(creator);
			this.CreateSparseGridPhysicsInteractionActorConfig(creator);
		}

		// Token: 0x0602F2E4 RID: 193252 RVA: 0x00B2D182 File Offset: 0x00B2B382
		public void UpdateGroupConfigTickStrategy(TsGameBudgetGroupConfigCache tsGroupConfig, int tickStrategy, uint distance)
		{
			tsGroupConfig.ueGroupConfig.DisableActorTickStrategy = (EDisableActorTickStrategy)tickStrategy;
			tsGroupConfig.ueGroupConfig.DisableActorTickDistance = distance;
		}

		// Token: 0x0602F2E5 RID: 193253 RVA: 0x00B2D19D File Offset: 0x00B2B39D
		public void RestoreGroupConfigTickStrategy(TsGameBudgetGroupConfigCache tsGroupConfig)
		{
			tsGroupConfig.ueGroupConfig.DisableActorTickStrategy = tsGroupConfig.DefaultDisableActorTickStrategy;
			tsGroupConfig.ueGroupConfig.DisableActorTickDistance = tsGroupConfig.DefaultDisableActorTickDistance;
		}

		// Token: 0x0602F2E6 RID: 193254 RVA: 0x00B2D1C4 File Offset: 0x00B2B3C4
		private void ApplyGroupConfig(FGameBudgetAllocatorGroupConfig groupConfig, GameBudgetAllocatorConfig detailConfigs)
		{
			FName groupName;
			foreach (string text in detailConfigs.Keys)
			{
				TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = detailConfigs[text];
				if (text == "Default")
				{
					if (tsGameBudgetAllocatorTickIntervalDetailConfig == null)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Game;
						ELogAuthor author = ELogAuthor.WY;
						string message = "Missing default config!";
						string item = "GroupName";
						groupName = groupConfig.GroupName;
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, groupName.ToString());
						instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref groupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
					if (tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartScreenRatio > 0f)
					{
						UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailScreenRadiusConfig(ref groupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartScreenRatio, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalScreenRatio);
					}
				}
				else if (tsGameBudgetAllocatorTickIntervalDetailConfig != null)
				{
					UKuroGameBudgetAllocatorCSharpInterface.SetTickIntervalDetailConfig(ref groupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.GlobalMode, tsGameBudgetAllocatorTickIntervalDetailConfig.ActorMode, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
					if (tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartScreenRatio > 0f)
					{
						UKuroGameBudgetAllocatorCSharpInterface.SetTickIntervalDetailScreenRadiusConfig(ref groupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.GlobalMode, tsGameBudgetAllocatorTickIntervalDetailConfig.ActorMode, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartScreenRatio, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalScreenRatio);
					}
				}
			}
			groupName = groupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, groupConfig);
		}

		// Token: 0x0602F2E7 RID: 193255 RVA: 0x00B2D308 File Offset: 0x00B2B508
		private void CreateIdleExecConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateIdleExecConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = (FNameUtil.GetDynamicFName("IdleExecGroup") ?? FName.NAME_None);
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Idle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 100U;
			this.TsIdleExecConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2E8 RID: 193256 RVA: 0x00B2D390 File Offset: 0x00B2B590
		private GameBudgetAllocatorConfig CreateBossEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator, bool isApply = true)
		{
			GameBudgetAllocatorConfig gameBudgetAllocatorConfig = creator.CreateBossEntityConfig();
			if (isApply)
			{
				FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
				fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BossEntity").Value;
				fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
				fgameBudgetAllocatorGroupConfig.TickPriority = 8U;
				this.TsBossEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
				this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, gameBudgetAllocatorConfig);
			}
			return gameBudgetAllocatorConfig;
		}

		// Token: 0x0602F2E9 RID: 193257 RVA: 0x00B2D3E8 File Offset: 0x00B2B5E8
		private GameBudgetAllocatorConfig CreateCharacterEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator, bool isApply = true)
		{
			GameBudgetAllocatorConfig gameBudgetAllocatorConfig = creator.CreateCharacterEntityConfig();
			if (isApply)
			{
				FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
				fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("CharacterEntity").Value;
				fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
				fgameBudgetAllocatorGroupConfig.TickPriority = 9U;
				this.TsCharacterEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
				this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, gameBudgetAllocatorConfig);
			}
			return gameBudgetAllocatorConfig;
		}

		// Token: 0x0602F2EA RID: 193258 RVA: 0x00B2D444 File Offset: 0x00B2B644
		private GameBudgetAllocatorConfig CreateNormalNpcEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator, bool isApply = true)
		{
			GameBudgetAllocatorConfig gameBudgetAllocatorConfig = creator.CreateNormalNpcEntityConfig();
			if (isApply)
			{
				FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
				fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("NormalNpcEntity").Value;
				fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
				fgameBudgetAllocatorGroupConfig.TickPriority = 10U;
				this.TsNormalNpcEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
				this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, gameBudgetAllocatorConfig);
			}
			return gameBudgetAllocatorConfig;
		}

		// Token: 0x0602F2EB RID: 193259 RVA: 0x00B2D4A0 File Offset: 0x00B2B6A0
		private GameBudgetAllocatorConfig CreateSimpleNpcEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator, bool isApply = true)
		{
			GameBudgetAllocatorConfig gameBudgetAllocatorConfig = creator.CreateSimpleNpcEntityConfig();
			if (isApply)
			{
				FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
				fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("SimpleNpcEntity").Value;
				fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
				fgameBudgetAllocatorGroupConfig.TickPriority = 11U;
				fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
				fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 3000U;
				this.TsSimpleNpcEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
				this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, gameBudgetAllocatorConfig);
			}
			return gameBudgetAllocatorConfig;
		}

		// Token: 0x0602F2EC RID: 193260 RVA: 0x00B2D50C File Offset: 0x00B2B70C
		private void CreateNormalEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateNormalEntityConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("NormalEntity").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			this.TsNormalEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2ED RID: 193261 RVA: 0x00B2D564 File Offset: 0x00B2B764
		private void CreateFightEffectConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateFightEffectConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("FightEffectGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Critical;
			fgameBudgetAllocatorGroupConfig.TickPriority = 7U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 30001U;
			this.TsFightEffectGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2EE RID: 193262 RVA: 0x00B2D5EC File Offset: 0x00B2B7EC
		private void CreateEffectConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateEffectConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("EffectGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 30001U;
			this.TsEffectGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2EF RID: 193263 RVA: 0x00B2D654 File Offset: 0x00B2B854
		private void CreateEffectImportanceConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateEffectImportanceConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("EffectImportanceGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 1000000U;
			this.TsEffectInportanceGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F0 RID: 193264 RVA: 0x00B2D6BC File Offset: 0x00B2B8BC
		private void CreateStabilizeLowEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateStabilizeLowEntityConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("CustomStabilizeLow").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsStabilizeLowEntityGroupConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F1 RID: 193265 RVA: 0x00B2D718 File Offset: 0x00B2B918
		private void CreateAlwaysTickHotfixConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateAlwaysTickHotfixConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("AlwaysTickHotFix").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsAlwaysTickHotFixConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F2 RID: 193266 RVA: 0x00B2D774 File Offset: 0x00B2B974
		private void CreateMoveSceneItemEntityConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateMoveSceneItemEntityConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("MoveSceneItemEntity").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 3U;
			this.TsMoveSceneItemEntityConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F3 RID: 193267 RVA: 0x00B2D7C8 File Offset: 0x00B2B9C8
		private void CreatePlayerAlwaysTickConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreatePlayerAlwaysTickConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("PlayerAlwaysTickGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Critical;
			fgameBudgetAllocatorGroupConfig.TickPriority = 4U;
			this.TsPlayerAlwaysTickConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2F4 RID: 193268 RVA: 0x00B2D840 File Offset: 0x00B2BA40
		private void CreateNormalEntityAlwaysTickConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateNormalEntityAlwaysTickConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("NormalEntityAlwaysTickGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsNormalEntityAlwaysTickConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F5 RID: 193269 RVA: 0x00B2D89C File Offset: 0x00B2BA9C
		private void CreateNormalEntityAlwaysTickWithoutNotRenderedConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateNormalEntityAlwaysTickWithoutNotRenderedConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("NormalEntityAlwaysTickWhitoutNotRenderedGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsNormalEntityAlwaysTickWithoutNotRenderedConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2F6 RID: 193270 RVA: 0x00B2D8F8 File Offset: 0x00B2BAF8
		private void CreateAlwaysTickConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateAlwaysTickConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("AlwaysTickGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Critical;
			fgameBudgetAllocatorGroupConfig.TickPriority = 5U;
			this.TsAlwaysTickConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2F7 RID: 193271 RVA: 0x00B2D970 File Offset: 0x00B2BB70
		private void CreateCameraAlwaysTickConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateCameraAlwaysTickConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("CameraAlwaysTickGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Critical;
			fgameBudgetAllocatorGroupConfig.TickPriority = 90U;
			this.TsAlwaysTick2ConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2F8 RID: 193272 RVA: 0x00B2D9E8 File Offset: 0x00B2BBE8
		private void CreateHUDTickConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateHUDTickConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("HUDGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 5000U;
			this.TsHUDTickConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2F9 RID: 193273 RVA: 0x00B2DA70 File Offset: 0x00B2BC70
		private void CreateBattleHeadViewConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateBattleHeadViewConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BattleHeadViewGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 5000U;
			this.TsBattleHeadStateViewConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2FA RID: 193274 RVA: 0x00B2DAF8 File Offset: 0x00B2BCF8
		public void CreateCharacterRenderConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateCharacterRenderConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("CharacterRenderGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.High;
			fgameBudgetAllocatorGroupConfig.TickPriority = 8U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 18000U;
			this.TsCharacterRenderConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2FB RID: 193275 RVA: 0x00B2DB60 File Offset: 0x00B2BD60
		public void CreateNpcRenderConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateNpcRenderConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("NpcRenderGroup").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 11U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 18000U;
			this.TsNpcRenderConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2FC RID: 193276 RVA: 0x00B2DBC8 File Offset: 0x00B2BDC8
		private void CreateCollisionPlantConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateCollisionPlantConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("CollisionPlant").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 1000U;
			this.TsCollisionPlantConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2FD RID: 193277 RVA: 0x00B2DC30 File Offset: 0x00B2BE30
		private void CreateBlueprintSingletonConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			TsGameBudgetAllocatorTickIntervalDetailConfig tsGameBudgetAllocatorTickIntervalDetailConfig = creator.CreateBlueprintSingletonConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.BlueprintSingleton").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsBlueprintSingletonConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			UKuroGameBudgetAllocatorCSharpInterface.SetDefaultTickIntervalDetailConfig(ref fgameBudgetAllocatorGroupConfig, tsGameBudgetAllocatorTickIntervalDetailConfig.MaxInterval, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionStartSize, tsGameBudgetAllocatorTickIntervalDetailConfig.TickReductionIntervalSize);
			FName groupName = fgameBudgetAllocatorGroupConfig.GroupName;
			UKuroGameBudgetAllocatorCSharpInterface.SetGroupConfig(groupName, fgameBudgetAllocatorGroupConfig);
		}

		// Token: 0x0602F2FE RID: 193278 RVA: 0x00B2DCB0 File Offset: 0x00B2BEB0
		private void CreateSceneBlueprintActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateSceneBlueprintActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.SceneBlueprintActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 10000U;
			this.TsSceneBlueprintActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F2FF RID: 193279 RVA: 0x00B2DD18 File Offset: 0x00B2BF18
		private void CreateFarBlueprintActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateFarBlueprintActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.FarBlueprintActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 28000U;
			this.TsFarBlueprintActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F300 RID: 193280 RVA: 0x00B2DD80 File Offset: 0x00B2BF80
		private void CreateSuperFarBlueprintActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateSuperFarBlueprintActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.SuperFarBlueprintActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsSuperFarBlueprintActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F301 RID: 193281 RVA: 0x00B2DDDC File Offset: 0x00B2BFDC
		private void CreateDynamicPhysicsInteractionActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateDynamicPhysicsInteractionActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.DynamicPhysicsInteractionActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 2500U;
			this.TsDynamicPhysicsInteractionActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F302 RID: 193282 RVA: 0x00B2DE44 File Offset: 0x00B2C044
		private void CreateStaticPhysicsInteractionActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateStaticPhysicsInteractionActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.StaticPhysicsInteractionActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Low;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 1500U;
			this.TsStaticPhysicsInteractionActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F303 RID: 193283 RVA: 0x00B2DEAC File Offset: 0x00B2C0AC
		private void CreateHighPriorityPhysicsInteractionActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateHighPriorityPhysicsInteractionActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.HighPriorityPhysicsInteractionActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = 5000U;
			this.TsHighPriorityPhysicsInteractionActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F304 RID: 193284 RVA: 0x00B2DF14 File Offset: 0x00B2C114
		private void CreateSpecialBlueprintActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateSpecialBlueprintActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.SpecialBlueprintActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsSpecialBlueprintActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F305 RID: 193285 RVA: 0x00B2DF70 File Offset: 0x00B2C170
		private void CreateSparseGridPhysicsInteractionActorConfig(IGamebudgetAllocatorConfigPlatformCreator creator)
		{
			GameBudgetAllocatorConfig detailConfigs = creator.CreateDynamicPhysicsInteractionActorConfig();
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("BlueprintTick.SparseGridPhysicsInteractionActor").Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_None;
			this.TsSparseGridPhysicsInteractionActorConfigInternal = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
		}

		// Token: 0x0602F306 RID: 193286 RVA: 0x00B2DFCC File Offset: 0x00B2C1CC
		public TsGameBudgetGroupConfigCache GetEffectDynamicGroup(uint inMaxDistance)
		{
			uint num = inMaxDistance;
			if (num >= 200000U)
			{
				return this.TsEffectInportanceGroupConfig;
			}
			if (UKuroStaticLibrary.IsLowMemoryDevice() && ControllerBase<LowMemoryScalabilityController>.Instance.IsSpecialLowMemoryMap() && num > 3000U)
			{
				num = (uint)(num - (num - 3000U) * 0.8);
			}
			TsGameBudgetGroupConfigCache result;
			if (this.TsEffectDynamicGroupConfigMap.TryGetValue(num, out result))
			{
				return result;
			}
			double num2 = 0.1 * num;
			double num3 = 0.2 * num;
			double num4 = 0.05 * num;
			double num5 = 0.1 * num;
			double num6 = 0.02 * num;
			double num7 = 0.1 * num;
			double num8 = (num - num2) / 179.0;
			double num9 = (num - num3) / 59.0;
			double num10 = (num - num4) / 299.0;
			double num11 = (num - num5) / 299.0;
			double num12 = (num - num6) / 599.0;
			double num13 = (num - num7) / 299.0;
			GameBudgetAllocatorConfig detailConfigs = new GameBudgetAllocatorConfig
			{
				Default = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 180U, (uint)num2, (uint)num8, 0f, 0f),
				Normal_Render = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 60U, (uint)num3, (uint)num9, 0f, 0f),
				Normal_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Normal, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, (uint)num4, (uint)num10, 0f, 0f),
				Normal_Fighting = null,
				Fighting_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 300U, (uint)num5, (uint)num11, 0f, 0f),
				Fighting_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Fighting, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 600U, (uint)num6, (uint)num12, 0f, 0f),
				Fighting_Fighting = null,
				Cutscene_Rendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_Rendered, 5U, (uint)num3, (uint)num9, 0f, 0f),
				Cutscene_NotRendered = new TsGameBudgetAllocatorTickIntervalDetailConfig(EGameBudgetAllocatorGlobalMode.GBA_GlobalMode_Cutscene, EGameBudgetAllocatorActorMode.GBA_ActorMode_NotRendered, 300U, (uint)num7, (uint)num13, 0f, 0f)
			};
			FGameBudgetAllocatorGroupConfig fgameBudgetAllocatorGroupConfig = new FGameBudgetAllocatorGroupConfig();
			fgameBudgetAllocatorGroupConfig.GroupName = FNameUtil.GetDynamicFName("EffectGroup_" + num.ToString()).Value;
			fgameBudgetAllocatorGroupConfig.SignificanceGroup = ESignificanceGroup.Middle;
			fgameBudgetAllocatorGroupConfig.TickPriority = 12U;
			fgameBudgetAllocatorGroupConfig.DisableActorTickStrategy = EDisableActorTickStrategy.DisableActorTickStrategy_DistanceOnly;
			fgameBudgetAllocatorGroupConfig.DisableActorTickDistance = num;
			TsGameBudgetGroupConfigCache tsGameBudgetGroupConfigCache = new TsGameBudgetGroupConfigCache(fgameBudgetAllocatorGroupConfig);
			this.TsEffectDynamicGroupConfigMap[num] = tsGameBudgetGroupConfigCache;
			this.ApplyGroupConfig(fgameBudgetAllocatorGroupConfig, detailConfigs);
			return tsGameBudgetGroupConfigCache;
		}

		// Token: 0x0401ADED RID: 110061
		private const int PRE_PLAYER_MOVE_TICK_PRIORITY = 3;

		// Token: 0x0401ADEE RID: 110062
		private const int PLAYER_ALWAYS_TICK_PRIORITY = 4;

		// Token: 0x0401ADEF RID: 110063
		private const int ALWAYS_TICK_PRIORITY = 5;

		// Token: 0x0401ADF0 RID: 110064
		private const int FIGHT_EFFECT_PRIPRITY = 7;

		// Token: 0x0401ADF1 RID: 110065
		private const int Boss_PRIORITY = 8;

		// Token: 0x0401ADF2 RID: 110066
		private const int ROLE_PRIORITY = 9;

		// Token: 0x0401ADF3 RID: 110067
		private const int NPC_PRIORITY = 10;

		// Token: 0x0401ADF4 RID: 110068
		private const int SIMPLE_NPC_PRIORITY = 11;

		// Token: 0x0401ADF5 RID: 110069
		private const int HUD_PRIORITY = 12;

		// Token: 0x0401ADF6 RID: 110070
		private const int BATTLE_HEAD_STATE_VIEW_PRIORITY = 12;

		// Token: 0x0401ADF7 RID: 110071
		private const int OTHER_PRIORITY = 12;

		// Token: 0x0401ADF8 RID: 110072
		private const int CAMERA_PRIORITY = 90;

		// Token: 0x0401ADF9 RID: 110073
		private const int IDLE_EXEC_PRIORITY = 100;

		// Token: 0x0401ADFA RID: 110074
		public const int EFFECT_ENABLE_RANGE = 30001;

		// Token: 0x0401ADFB RID: 110075
		public const int EFFECT_USE_BOUNDS_RANGE = 10000;

		// Token: 0x0401ADFC RID: 110076
		public const int EFFECT_IMPORTANCE_ENABLE_RANGE = 200000;

		// Token: 0x0401ADFD RID: 110077
		private const int EFFECT_IMPORTANCE_ENABLE_MAX_RANGE = 1000000;

		// Token: 0x0401ADFE RID: 110078
		private const int HUD_ENABLE_RANGE = 5000;

		// Token: 0x0401ADFF RID: 110079
		private const int BATTLE_HEAD_STATE_VIEW_RANGE = 5000;

		// Token: 0x0401AE00 RID: 110080
		private const int CHARCTER_RENDER_ENABLE_MAX_RANGE = 18000;

		// Token: 0x0401AE01 RID: 110081
		private const int COLLISION_PLANT_RANGE = 1000;

		// Token: 0x0401AE02 RID: 110082
		private const int SCENE_BLUEPRINT_ACTOR_RANGE = 10000;

		// Token: 0x0401AE03 RID: 110083
		private const int FAR_BLUEPRINT_ACTOR_RANGE = 28000;

		// Token: 0x0401AE04 RID: 110084
		private const int HIGH_PRIORITY_PHYSICS_INTERACTION_ACTOR_RANGE = 5000;

		// Token: 0x0401AE05 RID: 110085
		private const int DYNAMIC_PHYSICS_INTERACTION_ACTOR_RANGE = 2500;

		// Token: 0x0401AE06 RID: 110086
		private const int STATIC_PHYSICS_INTERACTION_ACTOR_RANGE = 1500;

		// Token: 0x0401AE07 RID: 110087
		private TsGameBudgetGroupConfigCache TsNormalEntityGroupConfigInternal;

		// Token: 0x0401AE08 RID: 110088
		private TsGameBudgetGroupConfigCache TsBossEntityGroupConfigInternal;

		// Token: 0x0401AE09 RID: 110089
		private TsGameBudgetGroupConfigCache TsCharacterEntityGroupConfigInternal;

		// Token: 0x0401AE0A RID: 110090
		private TsGameBudgetGroupConfigCache TsNormalNpcEntityGroupConfigInternal;

		// Token: 0x0401AE0B RID: 110091
		private TsGameBudgetGroupConfigCache TsSimpleNpcEntityGroupConfigInternal;

		// Token: 0x0401AE0C RID: 110092
		private TsGameBudgetGroupConfigCache TsFightEffectGroupConfigInternal;

		// Token: 0x0401AE0D RID: 110093
		private TsGameBudgetGroupConfigCache TsEffectGroupConfigInternal;

		// Token: 0x0401AE0E RID: 110094
		private TsGameBudgetGroupConfigCache TsEffectInportanceGroupConfigInternal;

		// Token: 0x0401AE0F RID: 110095
		private TsGameBudgetGroupConfigCache TsAlwaysTickConfigInternal;

		// Token: 0x0401AE10 RID: 110096
		private TsGameBudgetGroupConfigCache TsPlayerAlwaysTickConfigInternal;

		// Token: 0x0401AE11 RID: 110097
		private TsGameBudgetGroupConfigCache TsNormalEntityAlwaysTickConfigInternal;

		// Token: 0x0401AE12 RID: 110098
		private TsGameBudgetGroupConfigCache TsNormalEntityAlwaysTickWithoutNotRenderedConfigInternal;

		// Token: 0x0401AE13 RID: 110099
		private TsGameBudgetGroupConfigCache TsIdleExecConfigInternal;

		// Token: 0x0401AE14 RID: 110100
		private TsGameBudgetGroupConfigCache TsAlwaysTick2ConfigInternal;

		// Token: 0x0401AE15 RID: 110101
		private TsGameBudgetGroupConfigCache TsHUDTickConfigInternal;

		// Token: 0x0401AE16 RID: 110102
		private TsGameBudgetGroupConfigCache TsCharacterRenderConfigInternal;

		// Token: 0x0401AE17 RID: 110103
		private TsGameBudgetGroupConfigCache TsNpcRenderConfigInternal;

		// Token: 0x0401AE18 RID: 110104
		private TsGameBudgetGroupConfigCache TsStabilizeLowEntityGroupConfigInternal;

		// Token: 0x0401AE19 RID: 110105
		private TsGameBudgetGroupConfigCache TsBattleHeadStateViewConfigInternal;

		// Token: 0x0401AE1A RID: 110106
		private GameBudgetAllocatorConfig TsCharacterDtailConfigInternal;

		// Token: 0x0401AE1B RID: 110107
		private TsGameBudgetGroupConfigCache TsAlwaysTickHotFixConfigInternal;

		// Token: 0x0401AE1C RID: 110108
		private TsGameBudgetGroupConfigCache TsMoveSceneItemEntityConfigInternal;

		// Token: 0x0401AE1D RID: 110109
		private TsGameBudgetGroupConfigCache TsCollisionPlantConfigInternal;

		// Token: 0x0401AE1E RID: 110110
		private TsGameBudgetGroupConfigCache TsBlueprintSingletonConfigInternal;

		// Token: 0x0401AE1F RID: 110111
		private TsGameBudgetGroupConfigCache TsSceneBlueprintActorConfigInternal;

		// Token: 0x0401AE20 RID: 110112
		private TsGameBudgetGroupConfigCache TsFarBlueprintActorConfigInternal;

		// Token: 0x0401AE21 RID: 110113
		private TsGameBudgetGroupConfigCache TsSuperFarBlueprintActorConfigInternal;

		// Token: 0x0401AE22 RID: 110114
		private TsGameBudgetGroupConfigCache TsDynamicPhysicsInteractionActorConfigInternal;

		// Token: 0x0401AE23 RID: 110115
		private TsGameBudgetGroupConfigCache TsStaticPhysicsInteractionActorConfigInternal;

		// Token: 0x0401AE24 RID: 110116
		private TsGameBudgetGroupConfigCache TsHighPriorityPhysicsInteractionActorConfigInternal;

		// Token: 0x0401AE25 RID: 110117
		private TsGameBudgetGroupConfigCache TsSpecialBlueprintActorConfigInternal;

		// Token: 0x0401AE26 RID: 110118
		private TsGameBudgetGroupConfigCache TsSparseGridPhysicsInteractionActorConfigInternal;

		// Token: 0x0401AE27 RID: 110119
		public readonly Dictionary<uint, TsGameBudgetGroupConfigCache> TsEffectDynamicGroupConfigMap = new Dictionary<uint, TsGameBudgetGroupConfigCache>();
	}
}
