using System;
using CSharpScript.Game.Camera;
using CSharpScript.Game.LevelGamePlay.ResetPlayer;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.SeamlessTravel;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.World.Model;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049FA RID: 18938
	public class BlockInputDistribute : InputDistributeSetup
	{
		// Token: 0x060318A7 RID: 202919 RVA: 0x00C58A54 File Offset: 0x00C56C54
		public override bool OnRefresh()
		{
			if (this.IsInSeamlessTravel())
			{
				SeamlessTravelModel instance = ModelBase<SeamlessTravelModel>.Instance;
				if (instance != null && instance.IsSeamlessTravel)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.YJX, "[InputDistribute]无缝加载过渡场景中，使用无缝加载设置的输入分发tag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTags(ModelBase<SeamlessTravelModel>.Instance.SeamlessTravelInputDistributeTags);
					return true;
				}
				Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.YJX, "[InputDistribute]无缝加载过渡场景中，只允许角色轴向输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetInputDistributeTag("FightInputRoot.FightInput.AxisInput");
				return true;
			}
			else
			{
				if (this.IsLoading())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]加载中设置输入分发tag为 MouseInputTag NavigationTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTags(new string[]
					{
						"UiInputRoot.MouseInputTag",
						"UiInputRoot.Navigation"
					});
					return true;
				}
				if (this.IsKick())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]断线中，则设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (this.IsSdkGetFocus())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]Sdk打开界面，则设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (this.IsInBattleSettlement())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.CFT, "[InputDistribute]战斗结算中设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (ModelBase<DeadReviveModel>.Instance.BlockAllInput)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.LYY, "[InputDistribute]死亡界面打开中设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (ModelBase<ResetPlayerModel>.Instance.IsReseting)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.LYY, "[InputDistribute]重置玩家位置中设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (ModelBase<SceneTeamModel>.Instance.IsSeamlessUpdateTeamBlockInput)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.LYY, "[InputDistribute]切换编队无缝表现中, 只允许角色轴向输入", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("FightInputRoot.FightInput.AxisInput");
					return true;
				}
				if (this.IsInVideoView())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.JYS, "[InputDistribute]CG中，则设置输入分发tag为 UiInputRootTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("UiInputRoot");
					return true;
				}
				if (this.IsInBlackScreen())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.JYS, "[InputDistribute]黑幕中，则设置输入分发tag为 MouseInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("UiInputRoot.MouseInputTag");
					return true;
				}
				if (this.IsTransitionPopupBlock())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.JYS, "[InputDistribute] 转场弹窗中，禁用输入", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (ControllerBase<CameraController>.Instance.IsSequenceCameraInCinematic("MainCamera"))
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]玩家角色在播放处决中，大招中等镜头时，只允许角色技能输入，设置输入分发tag为 CharacterSkillInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("FightInputRoot.FightInput.ActionInput.CharacterSkillInput");
					return true;
				}
				MapModel instance2 = ModelBase<MapModel>.Instance;
				if (instance2 != null && instance2.IsInUnopenedAreaPullback())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]角色进入未开放区域启动拉回，设置输入分发tag为 MouseInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("UiInputRoot.MouseInputTag");
					return true;
				}
				if (this.IsInWaterfallMove())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.YJX, "[InputDistribute]角色处于载具攀瀑状态，禁止所有输入", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
				BaseTagComponent baseTagComponent;
				if (getCurrentEntity == null)
				{
					baseTagComponent = null;
				}
				else
				{
					WorldEntity entity = getCurrentEntity.Entity;
					baseTagComponent = ((entity != null) ? entity.GetComponent<BaseTagComponent>() : null);
				}
				BaseTagComponent baseTagComponent2 = baseTagComponent;
				if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.溺水"]))
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]角色落水中，则设置输入分发tag为 MouseInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("UiInputRoot.MouseInputTag");
					return true;
				}
				if (baseTagComponent2 != null && baseTagComponent2.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.驾驶载具.退出中"]))
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.YJX, "[InputDistribute]角色退出载具中，禁止交互和战斗输入", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTags(new string[]
					{
						"FightInputRoot.FightInput.AxisInput",
						"UiInputRoot.Navigation"
					});
					return true;
				}
				MenuModel instance3 = ModelBase<MenuModel>.Instance;
				if (instance3 != null && instance3.IsWaitForKeyInput)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]玩家设置按键中，则设置输入分发tag为 NavigationTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTags(new string[]
					{
						"UiInputRoot.Navigation",
						"UiInputRoot.MouseInputTag"
					});
					return true;
				}
				if (ModelBase<GeneralLogicTreeModel>.Instance.DisableInput)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]行为配置禁用输入 设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (this.IsInLinkExplosion())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.WWJ, "[InputDistribute]播放Link分屏中 设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				SubLevelModel instance4 = ModelBase<SubLevelModel>.Instance;
				if (instance4 != null && instance4.IsInSubLevelSwitchingAndBlockingInput())
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.XXJ, "[InputDistribute]切换子关卡且禁止输入 设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.SetInputDistributeTag("BlockAllInputTag");
					return true;
				}
				if (ModelBase<DeadEyeModeModel>.Instance.IsInDeadEyeMode)
				{
					Singleton<Log>.Instance.Info(ELogModule.Input, ELogAuthor.WWJ, "[InputDistribute]死眼跳台玩法中 设置输入分发tag为 BlockAllInputTag", default(ReadOnlySpan<ValueTuple<string, object>>));
					string[] inputDistributeTags = new string[]
					{
						"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
						"UiInputRoot"
					};
					base.SetInputDistributeTags(inputDistributeTags);
					return true;
				}
				return false;
			}
		}

		// Token: 0x060318A8 RID: 202920 RVA: 0x00C58F73 File Offset: 0x00C57173
		private bool IsInSeamlessTravel()
		{
			if (!ModelBase<SeamlessTravelModel>.Instance.IsSeamlessTravel)
			{
				TeleportContext teleportContext = ModelBase<TeleportModel>.Instance.TeleportContext;
				return teleportContext != null && teleportContext.IsInSeamlessTeleport;
			}
			return true;
		}

		// Token: 0x060318A9 RID: 202921 RVA: 0x00C58F98 File Offset: 0x00C57198
		private bool IsLoading()
		{
			return ModelBase<LoadingModel>.Instance.IsLoading;
		}

		// Token: 0x060318AA RID: 202922 RVA: 0x00C58FA4 File Offset: 0x00C571A4
		private bool IsKick()
		{
			return ModelBase<ReConnectModel>.Instance.GetReConnectStatus() == EReConnectStatus.ReConnectDoing;
		}

		// Token: 0x060318AB RID: 202923 RVA: 0x00C58FB3 File Offset: 0x00C571B3
		private bool IsSdkGetFocus()
		{
			return ModelBase<KuroSdkModel>.Instance.GetSdkFocusState();
		}

		// Token: 0x060318AC RID: 202924 RVA: 0x00C58FBF File Offset: 0x00C571BF
		private bool IsInVideoView()
		{
			return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VideoView);
		}

		// Token: 0x060318AD RID: 202925 RVA: 0x00C58FD0 File Offset: 0x00C571D0
		private bool IsInBlackScreen()
		{
			return ControllerBase<BlackScreenFadeController>.Instance.NeedInputDis;
		}

		// Token: 0x060318AE RID: 202926 RVA: 0x00C58FDC File Offset: 0x00C571DC
		private bool IsInBattleSettlement()
		{
			return ModelBase<BattleUiModel>.Instance.IsInBattleSettlement;
		}

		// Token: 0x060318AF RID: 202927 RVA: 0x00C58FE8 File Offset: 0x00C571E8
		private bool IsInWaterfallMove()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			CharacterActorComponent characterActorComponent = (baseCharacter != null) ? baseCharacter.CharacterActorComponent : null;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (characterActorComponent != null) ? characterActorComponent.Entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			object obj;
			if (characterDriveVehicleComponent == null)
			{
				obj = null;
			}
			else
			{
				Entity vehicleEntity = characterDriveVehicleComponent.VehicleEntity;
				obj = ((vehicleEntity != null) ? vehicleEntity.GetComponent<GongduolaPerformComponent>() : null);
			}
			object obj2 = obj;
			return obj2 != null && obj2.IsWaterfallMove;
		}

		// Token: 0x060318B0 RID: 202928 RVA: 0x00C5903A File Offset: 0x00C5723A
		private bool IsInLinkExplosion()
		{
			BattleLinkController instance = ControllerBase<BattleLinkController>.Instance;
			return instance != null && instance.GetIsInLinkExplosion();
		}

		// Token: 0x060318B1 RID: 202929 RVA: 0x00C5904C File Offset: 0x00C5724C
		private bool IsTransitionPopupBlock()
		{
			TransitionPopupView transitionPopupView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TransitionPopupView) as TransitionPopupView;
			return transitionPopupView != null && transitionPopupView.IsLimitOperation;
		}
	}
}
