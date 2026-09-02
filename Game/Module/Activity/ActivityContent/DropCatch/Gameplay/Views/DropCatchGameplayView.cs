using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006914 RID: 26900
	[NullableContext(2)]
	[Nullable(0)]
	public class DropCatchGameplayView : UiTickViewBase
	{
		// Token: 0x06042CD6 RID: 273622 RVA: 0x01125270 File Offset: 0x01123470
		[NullableContext(1)]
		public DropCatchGameplayView(UiViewInfo viewInfo)
		{
			EDropCatchRobotAnimState[][] array = new EDropCatchRobotAnimState[2][];
			array[0] = new EDropCatchRobotAnimState[]
			{
				EDropCatchRobotAnimState.IdleRight,
				EDropCatchRobotAnimState.IdleLeft
			};
			int num = 1;
			EDropCatchRobotAnimState[] array2 = new EDropCatchRobotAnimState[2];
			array2[0] = EDropCatchRobotAnimState.HappyRight;
			array[num] = array2;
			this.RobotAnimStateTable = array;
			base..ctor(viewInfo);
		}

		// Token: 0x06042CD7 RID: 273623 RVA: 0x011252D8 File Offset: 0x011234D8
		protected override void OnRegisterComponent()
		{
			this.Proxy = (this.OpenParam as DropCatchGameplayProxy);
			this.Proxy.RegisterView(this);
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUIArtText)),
				new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUISprite)),
				new ValueTuple<int, Type>(11, typeof(UUISprite)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIArtText)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIItem)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(24, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnSkillButtonClick)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnPauseButtonClick)),
				new ValueTuple<int, Delegate>(5, new Action(this.OnDetailButtonClick))
			};
		}

		// Token: 0x06042CD8 RID: 273624 RVA: 0x01125580 File Offset: 0x01123780
		protected override UniTask OnBeforeStartAsync()
		{
			DropCatchGameplayView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DropCatchGameplayView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042CD9 RID: 273625 RVA: 0x011255C3 File Offset: 0x011237C3
		protected override void OnStart()
		{
			this.InitDropItemLayer();
			this.InitPools();
		}

		// Token: 0x06042CDA RID: 273626 RVA: 0x011255D4 File Offset: 0x011237D4
		private UniTask RefreshBgRoleView()
		{
			DropCatchGameplayView.<RefreshBgRoleView>d__22 <RefreshBgRoleView>d__;
			<RefreshBgRoleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshBgRoleView>d__.<>4__this = this;
			<RefreshBgRoleView>d__.<>1__state = -1;
			<RefreshBgRoleView>d__.<>t__builder.Start<DropCatchGameplayView.<RefreshBgRoleView>d__22>(ref <RefreshBgRoleView>d__);
			return <RefreshBgRoleView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CDB RID: 273627 RVA: 0x01125618 File Offset: 0x01123818
		private void InitPools()
		{
			if (this.FloatEffPool == null)
			{
				this.FloatEffPool = new DropCatchGameplayPanelViewPool<DropCatchGameplayFloatEffView>();
				this.FloatEffPool.Init(delegate
				{
					DropCatchGameplayView.<<InitPools>b__23_0>d <<InitPools>b__23_0>d;
					<<InitPools>b__23_0>d.<>t__builder = AsyncUniTaskMethodBuilder<DropCatchGameplayFloatEffView>.Create();
					<<InitPools>b__23_0>d.<>4__this = this;
					<<InitPools>b__23_0>d.<>1__state = -1;
					<<InitPools>b__23_0>d.<>t__builder.Start<DropCatchGameplayView.<<InitPools>b__23_0>d>(ref <<InitPools>b__23_0>d);
					return <<InitPools>b__23_0>d.<>t__builder.Task;
				});
			}
			if (this.DropItemFxPool == null)
			{
				this.DropItemFxPool = new DropCatchGameplayPanelViewPool<DropCatchGameplayDropItemFxView>();
				this.DropItemFxPool.Init(delegate
				{
					DropCatchGameplayView.<<InitPools>b__23_1>d <<InitPools>b__23_1>d;
					<<InitPools>b__23_1>d.<>t__builder = AsyncUniTaskMethodBuilder<DropCatchGameplayDropItemFxView>.Create();
					<<InitPools>b__23_1>d.<>4__this = this;
					<<InitPools>b__23_1>d.<>1__state = -1;
					<<InitPools>b__23_1>d.<>t__builder.Start<DropCatchGameplayView.<<InitPools>b__23_1>d>(ref <<InitPools>b__23_1>d);
					return <<InitPools>b__23_1>d.<>t__builder.Task;
				});
			}
		}

		// Token: 0x06042CDC RID: 273628 RVA: 0x01125679 File Offset: 0x01123879
		private void DestroyPools()
		{
			DropCatchGameplayPanelViewPool<DropCatchGameplayFloatEffView> floatEffPool = this.FloatEffPool;
			if (floatEffPool != null)
			{
				floatEffPool.DestroyAll();
			}
			DropCatchGameplayPanelViewPool<DropCatchGameplayDropItemFxView> dropItemFxPool = this.DropItemFxPool;
			if (dropItemFxPool == null)
			{
				return;
			}
			dropItemFxPool.DestroyAll();
		}

		// Token: 0x06042CDD RID: 273629 RVA: 0x0112569C File Offset: 0x0112389C
		protected override void OnBeforeDestroy()
		{
			this.DestroyPools();
			Singleton<AudioSystem>.Instance.SetState("game_sys_fever", "none", true);
			this.Proxy.OnGameplayViewDestroyed();
		}

		// Token: 0x06042CDE RID: 273630 RVA: 0x011256C4 File Offset: 0x011238C4
		private void RecyclePools()
		{
			DropCatchGameplayPanelViewPool<DropCatchGameplayFloatEffView> floatEffPool = this.FloatEffPool;
			if (floatEffPool != null)
			{
				floatEffPool.RecycleAll();
			}
			DropCatchGameplayPanelViewPool<DropCatchGameplayDropItemFxView> dropItemFxPool = this.DropItemFxPool;
			if (dropItemFxPool == null)
			{
				return;
			}
			dropItemFxPool.RecycleAll();
		}

		// Token: 0x06042CDF RID: 273631 RVA: 0x011256E8 File Offset: 0x011238E8
		public UniTask ResetView(bool isRestart)
		{
			DropCatchGameplayView.<ResetView>d__27 <ResetView>d__;
			<ResetView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetView>d__.<>4__this = this;
			<ResetView>d__.isRestart = isRestart;
			<ResetView>d__.<>1__state = -1;
			<ResetView>d__.<>t__builder.Start<DropCatchGameplayView.<ResetView>d__27>(ref <ResetView>d__);
			return <ResetView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE0 RID: 273632 RVA: 0x01125734 File Offset: 0x01123934
		public UniTask CreateFloatEffView(string icon = null, float? score = null)
		{
			DropCatchGameplayView.<CreateFloatEffView>d__28 <CreateFloatEffView>d__;
			<CreateFloatEffView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateFloatEffView>d__.<>4__this = this;
			<CreateFloatEffView>d__.icon = icon;
			<CreateFloatEffView>d__.score = score;
			<CreateFloatEffView>d__.<>1__state = -1;
			<CreateFloatEffView>d__.<>t__builder.Start<DropCatchGameplayView.<CreateFloatEffView>d__28>(ref <CreateFloatEffView>d__);
			return <CreateFloatEffView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE1 RID: 273633 RVA: 0x01125788 File Offset: 0x01123988
		[NullableContext(1)]
		public UniTask CreateDropItemFxView(EDropCatchDropItemNiagaraType type, Vector2D pos)
		{
			DropCatchGameplayView.<CreateDropItemFxView>d__29 <CreateDropItemFxView>d__;
			<CreateDropItemFxView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateDropItemFxView>d__.<>4__this = this;
			<CreateDropItemFxView>d__.type = type;
			<CreateDropItemFxView>d__.pos = pos;
			<CreateDropItemFxView>d__.<>1__state = -1;
			<CreateDropItemFxView>d__.<>t__builder.Start<DropCatchGameplayView.<CreateDropItemFxView>d__29>(ref <CreateDropItemFxView>d__);
			return <CreateDropItemFxView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE2 RID: 273634 RVA: 0x011257DC File Offset: 0x011239DC
		private UniTask InitJoyStick()
		{
			DropCatchGameplayView.<InitJoyStick>d__30 <InitJoyStick>d__;
			<InitJoyStick>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitJoyStick>d__.<>4__this = this;
			<InitJoyStick>d__.<>1__state = -1;
			<InitJoyStick>d__.<>t__builder.Start<DropCatchGameplayView.<InitJoyStick>d__30>(ref <InitJoyStick>d__);
			return <InitJoyStick>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE3 RID: 273635 RVA: 0x01125820 File Offset: 0x01123A20
		private UniTask InitMsgItem()
		{
			DropCatchGameplayView.<InitMsgItem>d__31 <InitMsgItem>d__;
			<InitMsgItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitMsgItem>d__.<>4__this = this;
			<InitMsgItem>d__.<>1__state = -1;
			<InitMsgItem>d__.<>t__builder.Start<DropCatchGameplayView.<InitMsgItem>d__31>(ref <InitMsgItem>d__);
			return <InitMsgItem>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE4 RID: 273636 RVA: 0x01125864 File Offset: 0x01123A64
		[NullableContext(1)]
		public void ShowMsgView(IDropCatchGameplayLeftMsgParams @params)
		{
			EDropCatchGameplayLeftMsgType type = @params.Type;
			if (type != EDropCatchGameplayLeftMsgType.Gameplay)
			{
				if (type != EDropCatchGameplayLeftMsgType.DropItem)
				{
					return;
				}
				this.MsgDropItemView.OpenParam = @params;
				DropCatchGameplayLeftMsgView msgDropItemView = this.MsgDropItemView;
				if (msgDropItemView == null)
				{
					return;
				}
				msgDropItemView.Show(null);
				return;
			}
			else
			{
				this.MsgGameplayView.OpenParam = @params;
				DropCatchGameplayLeftMsgView msgGameplayView = this.MsgGameplayView;
				if (msgGameplayView == null)
				{
					return;
				}
				msgGameplayView.Show(null);
				return;
			}
		}

		// Token: 0x06042CE5 RID: 273637 RVA: 0x011258BB File Offset: 0x01123ABB
		public void HideMsgView()
		{
			DropCatchGameplayLeftMsgView msgGameplayView = this.MsgGameplayView;
			if (msgGameplayView != null)
			{
				msgGameplayView.Hide(null);
			}
			DropCatchGameplayLeftMsgView msgDropItemView = this.MsgDropItemView;
			if (msgDropItemView == null)
			{
				return;
			}
			msgDropItemView.Hide(null);
		}

		// Token: 0x06042CE6 RID: 273638 RVA: 0x011258E0 File Offset: 0x01123AE0
		private UniTask InitRoleView()
		{
			DropCatchGameplayView.<InitRoleView>d__34 <InitRoleView>d__;
			<InitRoleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleView>d__.<>4__this = this;
			<InitRoleView>d__.<>1__state = -1;
			<InitRoleView>d__.<>t__builder.Start<DropCatchGameplayView.<InitRoleView>d__34>(ref <InitRoleView>d__);
			return <InitRoleView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE7 RID: 273639 RVA: 0x01125924 File Offset: 0x01123B24
		private UniTask RefreshRoleView()
		{
			DropCatchGameplayView.<RefreshRoleView>d__35 <RefreshRoleView>d__;
			<RefreshRoleView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleView>d__.<>4__this = this;
			<RefreshRoleView>d__.<>1__state = -1;
			<RefreshRoleView>d__.<>t__builder.Start<DropCatchGameplayView.<RefreshRoleView>d__35>(ref <RefreshRoleView>d__);
			return <RefreshRoleView>d__.<>t__builder.Task;
		}

		// Token: 0x06042CE8 RID: 273640 RVA: 0x01125968 File Offset: 0x01123B68
		private void InitScoreLayout()
		{
			DropCatchGameplayViewModel gameplayViewModel = this.Proxy.GetGameplayViewModel();
			List<float> list = (gameplayViewModel != null) ? gameplayViewModel.GetScoreLevels() : null;
			if (list == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取关卡配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.Proxy.GetCurGameplayId());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.ScoreLevelLayout == null)
			{
				this.ScoreLevelLayout = new GenericLayout<DropCatchGameplayScoreItem, IScoreLevelItemData>(base.GetVerticalLayout(7), () => new DropCatchGameplayScoreItem(), null, false, true);
			}
			this.ScoreDataList.Clear();
			foreach (float score in list)
			{
				this.ScoreDataList.Add(new IScoreLevelItemData
				{
					Score = score,
					IsFinish = false
				});
			}
		}

		// Token: 0x06042CE9 RID: 273641 RVA: 0x01125A6C File Offset: 0x01123C6C
		private void InitDropItemLayer()
		{
			UUIItem item = base.GetItem(1);
			this.DropItemLayerTemplate = ((item != null) ? item.GetAttachUIChild(0) : null);
			if (this.DropItemLayerTemplate == null)
			{
				return;
			}
			UUIItem dropItemLayerTemplate = this.DropItemLayerTemplate;
			if (dropItemLayerTemplate == null)
			{
				return;
			}
			dropItemLayerTemplate.SetUIActive(false);
		}

		// Token: 0x06042CEA RID: 273642 RVA: 0x01125AA4 File Offset: 0x01123CA4
		public UUIItem GetDropItemLayer(int index)
		{
			if (this.DropItemLayerTemplate == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "DropItemLayerTemplate is null", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			int count = this.DropItemLayers.Count;
			if (count <= index)
			{
				for (int i = count; i <= index; i++)
				{
					UUIItem uuiitem = Singleton<LguiUtil>.Instance.CopyItem(this.DropItemLayerTemplate, base.GetItem(1));
					uuiitem.SetUIActive(true);
					this.DropItemLayers.Add(uuiitem);
				}
				for (int j = 0; j < this.DropItemLayers.Count; j++)
				{
					this.DropItemLayers[j].SetHierarchyIndex(this.DropItemLayers.Count - j);
				}
			}
			return this.DropItemLayers[index];
		}

		// Token: 0x06042CEB RID: 273643 RVA: 0x01125B67 File Offset: 0x01123D67
		[NullableContext(1)]
		public UUIItem GetRoleUiParent()
		{
			return base.GetItem(2);
		}

		// Token: 0x06042CEC RID: 273644 RVA: 0x01125B70 File Offset: 0x01123D70
		private void OnSkillButtonClick()
		{
			base.PlaySequence("Use", null, false);
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_goldcatch_efx_energy_use");
			this.Proxy.UseRoleSkill();
		}

		// Token: 0x06042CED RID: 273645 RVA: 0x01125B9A File Offset: 0x01123D9A
		private void OnPauseButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchGameplayPauseView, this.Proxy, null);
		}

		// Token: 0x06042CEE RID: 273646 RVA: 0x01125BB2 File Offset: 0x01123DB2
		private void OnDetailButtonClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DropCatchDropItemDetailView, this.Proxy, null);
		}

		// Token: 0x06042CEF RID: 273647 RVA: 0x01125BCC File Offset: 0x01123DCC
		public void UpdateRoleEnergy()
		{
			DropCatchGameplayLogic gameplayLogic = this.Proxy.GetGameplayLogic();
			IRoleInstance roleInstance = (gameplayLogic != null) ? gameplayLogic.GetRole() : null;
			if (roleInstance == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "获取角色失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			float energy = roleInstance.GetEnergy();
			float maxEnergy = roleInstance.GetMaxEnergy();
			UUISprite sprite = base.GetSprite(10);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(energy / maxEnergy);
		}

		// Token: 0x06042CF0 RID: 273648 RVA: 0x01125C38 File Offset: 0x01123E38
		public void UpdateRoleSkillState()
		{
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			if (gameplayConfig != null && gameplayConfig.GetValueOrDefault().IsSpecial)
			{
				return;
			}
			DropCatchGameplayLogic gameplayLogic = this.Proxy.GetGameplayLogic();
			IRoleInstance roleInstance = (gameplayLogic != null) ? gameplayLogic.GetRole() : null;
			if (roleInstance == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.DropCatch, ELogAuthor.CB, "获取角色失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			EDropCatchRoleSkillState skillState = roleInstance.GetSkillState();
			if (skillState == EDropCatchRoleSkillState.Enable)
			{
				base.PlaySequence("FullEnergy", null, false);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_goldcatch_efx_energy_full");
			}
			else
			{
				base.PlaySequence("Disable", null, false);
			}
			if (skillState == EDropCatchRoleSkillState.Enable)
			{
				UUIButtonComponent button = base.GetButton(3);
				if (button != null && !button.IsSelfInteractive)
				{
					Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "DropCatchSkillActive");
				}
			}
			UUIButtonComponent button2 = base.GetButton(3);
			if (button2 != null)
			{
				button2.SetSelfInteractive(skillState == EDropCatchRoleSkillState.Enable);
			}
			if (skillState == EDropCatchRoleSkillState.InSkill)
			{
				DropCatchGameplayRoleView roleView = this.RoleView;
				if (roleView != null)
				{
					DropCatchGameplayRoleFxView fxView = roleView.GetFxView();
					if (fxView != null)
					{
						fxView.PlaySpeedUp();
					}
				}
				Singleton<AudioSystem>.Instance.SetState("game_sys_fever", "fever", true);
				return;
			}
			DropCatchGameplayRoleView roleView2 = this.RoleView;
			if (roleView2 != null)
			{
				DropCatchGameplayRoleFxView fxView2 = roleView2.GetFxView();
				if (fxView2 != null)
				{
					fxView2.HideSpeedUp();
				}
			}
			Singleton<AudioSystem>.Instance.SetState("game_sys_fever", "none", true);
		}

		// Token: 0x06042CF1 RID: 273649 RVA: 0x01125D94 File Offset: 0x01123F94
		public void UpdateScore()
		{
			float curScore = this.Proxy.GetCurScore();
			UUIArtText artText = base.GetArtText(6);
			if (artText != null)
			{
				artText.SetText(curScore.ToString());
			}
			foreach (IScoreLevelItemData scoreLevelItemData in this.ScoreDataList)
			{
				scoreLevelItemData.IsFinish = (curScore >= scoreLevelItemData.Score);
			}
			GenericLayout<DropCatchGameplayScoreItem, IScoreLevelItemData> scoreLevelLayout = this.ScoreLevelLayout;
			if (scoreLevelLayout == null)
			{
				return;
			}
			scoreLevelLayout.RefreshByData(this.ScoreDataList, null, false);
		}

		// Token: 0x06042CF2 RID: 273650 RVA: 0x01125E30 File Offset: 0x01124030
		public void UpdateRemainTime()
		{
			DropCatchGameplayLogic gameplayLogic = this.Proxy.GetGameplayLogic();
			float num = (gameplayLogic != null) ? gameplayLogic.GetRemainingTime() : 0f;
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat6((double)num * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text = base.GetText(9);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeDataFormat, true);
		}

		// Token: 0x06042CF3 RID: 273651 RVA: 0x01125E85 File Offset: 0x01124085
		public void RefreshCrazyMode(bool isCrazyMode)
		{
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(isCrazyMode);
			}
			base.PlaySequence("CrazyMode", null, false);
		}

		// Token: 0x06042CF4 RID: 273652 RVA: 0x01125EA8 File Offset: 0x011240A8
		public DropCatchGameplayRoleView GetRoleView()
		{
			return this.RoleView;
		}

		// Token: 0x06042CF5 RID: 273653 RVA: 0x01125EB0 File Offset: 0x011240B0
		public DropCatchGameplayJoystickView GetJoystickView()
		{
			return this.JoystickView;
		}

		// Token: 0x06042CF6 RID: 273654 RVA: 0x01125EB8 File Offset: 0x011240B8
		[NullableContext(1)]
		public UniTask PlayCountDown(Action onComplete)
		{
			DropCatchGameplayView.<PlayCountDown>d__50 <PlayCountDown>d__;
			<PlayCountDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCountDown>d__.<>4__this = this;
			<PlayCountDown>d__.onComplete = onComplete;
			<PlayCountDown>d__.<>1__state = -1;
			<PlayCountDown>d__.<>t__builder.Start<DropCatchGameplayView.<PlayCountDown>d__50>(ref <PlayCountDown>d__);
			return <PlayCountDown>d__.<>t__builder.Task;
		}

		// Token: 0x06042CF7 RID: 273655 RVA: 0x01125F03 File Offset: 0x01124103
		protected override void OnTick(float delta)
		{
			this.DrawDebug();
		}

		// Token: 0x06042CF8 RID: 273656 RVA: 0x01125F0B File Offset: 0x0112410B
		public void Pause()
		{
			DropCatchGameplayCountDownView countDownView = this.CountDownView;
			if (countDownView == null)
			{
				return;
			}
			countDownView.Pause();
		}

		// Token: 0x06042CF9 RID: 273657 RVA: 0x01125F1D File Offset: 0x0112411D
		public void Resume()
		{
			DropCatchGameplayCountDownView countDownView = this.CountDownView;
			if (countDownView == null)
			{
				return;
			}
			countDownView.Resume();
		}

		// Token: 0x06042CFA RID: 273658 RVA: 0x01125F30 File Offset: 0x01124130
		private void RefreshHistoryScore()
		{
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			if (gameplayConfig == null)
			{
				return;
			}
			bool flag = gameplayConfig.Value.IsSpecial && gameplayConfig.Value.IsNeedSettle;
			UUIItem item = base.GetItem(17);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				float gameplayScoreRecord = ModelBase<DropCatchModel>.Instance.GetGameplayScoreRecord(gameplayConfig.Value.Id);
				UUIArtText artText = base.GetArtText(18);
				if (artText == null)
				{
					return;
				}
				artText.SetText(gameplayScoreRecord.ToString());
			}
		}

		// Token: 0x06042CFB RID: 273659 RVA: 0x01125FC4 File Offset: 0x011241C4
		private void RefreshSkillVisible()
		{
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			if (gameplayConfig == null)
			{
				return;
			}
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(!gameplayConfig.Value.IsSpecial);
			}
			UUIButtonComponent button = base.GetButton(3);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(!gameplayConfig.Value.IsSpecial);
		}

		// Token: 0x06042CFC RID: 273660 RVA: 0x0112603C File Offset: 0x0112423C
		private void RefreshDetailButtonVisible()
		{
			DropCatchGameplay? gameplayConfig = this.Proxy.GetGameplayConfig();
			if (gameplayConfig == null)
			{
				return;
			}
			UUIButtonComponent button = base.GetButton(5);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(!gameplayConfig.Value.IsSpecial);
		}

		// Token: 0x06042CFD RID: 273661 RVA: 0x0112608F File Offset: 0x0112428F
		private void SetRobotLeft(int isLeft)
		{
			if (this.IsRobotLeft == isLeft)
			{
				return;
			}
			this.IsRobotLeft = isLeft;
			this.PlayRobotAnimation();
		}

		// Token: 0x06042CFE RID: 273662 RVA: 0x011260A8 File Offset: 0x011242A8
		private void SetRobotHappy(int isHappy)
		{
			if (this.IsRobotHappy == isHappy)
			{
				return;
			}
			this.IsRobotHappy = isHappy;
			this.PlayRobotAnimation();
		}

		// Token: 0x06042CFF RID: 273663 RVA: 0x011260C4 File Offset: 0x011242C4
		public void PlayRobotAnimation()
		{
			EDropCatchRobotAnimState edropCatchRobotAnimState = this.RobotAnimStateTable[this.IsRobotHappy][this.IsRobotLeft];
			EDropCatchRobotAnimState? lastRobotAnimState = this.LastRobotAnimState;
			EDropCatchRobotAnimState edropCatchRobotAnimState2 = edropCatchRobotAnimState;
			if (lastRobotAnimState.GetValueOrDefault() == edropCatchRobotAnimState2 & lastRobotAnimState != null)
			{
				return;
			}
			this.LastRobotAnimState = new EDropCatchRobotAnimState?(edropCatchRobotAnimState);
			USpineSkeletonAnimationComponent spine = base.GetSpine(23);
			if (spine == null)
			{
				return;
			}
			spine.SetAnimation(0, edropCatchRobotAnimState.ToEnumString(), true);
		}

		// Token: 0x06042D00 RID: 273664 RVA: 0x0112612C File Offset: 0x0112432C
		public UniTask PlayStartSequence()
		{
			DropCatchGameplayView.<PlayStartSequence>d__60 <PlayStartSequence>d__;
			<PlayStartSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequence>d__.<>4__this = this;
			<PlayStartSequence>d__.<>1__state = -1;
			<PlayStartSequence>d__.<>t__builder.Start<DropCatchGameplayView.<PlayStartSequence>d__60>(ref <PlayStartSequence>d__);
			return <PlayStartSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06042D01 RID: 273665 RVA: 0x01126170 File Offset: 0x01124370
		private void DrawDebug()
		{
			if (!Singleton<Info>.Instance.IsBuildShipping)
			{
				UUIText text = base.GetText(16);
				if (text != null)
				{
					text.SetUIActive(this.Proxy.GetEnableDebug());
				}
			}
			if (this.Proxy.GetEnableDebug())
			{
				DropCatchGameplayLogic gameplayLogic = this.Proxy.GetGameplayLogic();
				IRoleInstance roleInstance = (gameplayLogic != null) ? gameplayLogic.GetRole() : null;
				string text2;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
				if (roleInstance.GetSkillState() != EDropCatchRoleSkillState.InSkill)
				{
					text2 = "";
				}
				else
				{
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 3);
					defaultInterpolatedStringHandler.AppendLiteral("\n技能能量消耗:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetSkillReduceEnergy());
					defaultInterpolatedStringHandler.AppendLiteral("\n技能能量消耗提升间隔:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetSkillReduceEnergyRateInterval());
					defaultInterpolatedStringHandler.AppendLiteral("\n技能能量消耗提升倍率:");
					defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetSkillReduceEnergyRate());
					text2 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				string value = text2;
				string text3 = "";
				DropCatchGameplayLogic gameplayLogic2 = this.Proxy.GetGameplayLogic();
				Dictionary<int, IDropPoolRuntime> dictionary;
				if (gameplayLogic2 == null)
				{
					dictionary = null;
				}
				else
				{
					DropCatchGameplayDropItemMgr gameplayDropItemMgr = gameplayLogic2.GetGameplayDropItemMgr();
					dictionary = ((gameplayDropItemMgr != null) ? gameplayDropItemMgr.GetDropPools() : null);
				}
				Dictionary<int, IDropPoolRuntime> dictionary2 = dictionary;
				DropCatchGameplayLogic gameplayLogic3 = this.Proxy.GetGameplayLogic();
				float? num;
				if (gameplayLogic3 == null)
				{
					num = null;
				}
				else
				{
					DropCatchGameplayTimeMgr gameplayTimeMgr = gameplayLogic3.GetGameplayTimeMgr();
					num = ((gameplayTimeMgr != null) ? new float?(gameplayTimeMgr.GetTime()) : null);
				}
				float? num2 = num;
				if (dictionary2 != null && num2 != null)
				{
					foreach (IDropPoolRuntime dropPoolRuntime in dictionary2.Values)
					{
						float? num3 = num2;
						double? num4 = (num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null;
						double num5 = dropPoolRuntime.TimeRange[0];
						bool flag;
						if (num4.GetValueOrDefault() >= num5 & num4 != null)
						{
							if (dropPoolRuntime.TimeRange.Count != 1)
							{
								num3 = num2;
								num4 = ((num3 != null) ? new double?((double)num3.GetValueOrDefault()) : null);
								num5 = dropPoolRuntime.TimeRange[1];
								flag = (num4.GetValueOrDefault() <= num5 & num4 != null);
							}
							else
							{
								flag = true;
							}
						}
						else
						{
							flag = false;
						}
						if (flag)
						{
							string str = text3;
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
							defaultInterpolatedStringHandler.AppendLiteral("\nID:");
							defaultInterpolatedStringHandler.AppendFormatted<int>(dropPoolRuntime.PoolId);
							text3 = str + defaultInterpolatedStringHandler.ToStringAndClear();
						}
					}
				}
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(146, 21);
				defaultInterpolatedStringHandler.AppendLiteral("角色信息:Id:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(roleInstance.GetRoleId());
				defaultInterpolatedStringHandler.AppendLiteral("\n角色Size:X:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(roleInstance.GetRoleSize().X);
				defaultInterpolatedStringHandler.AppendLiteral(",Y:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(roleInstance.GetRoleSize().Y);
				defaultInterpolatedStringHandler.AppendLiteral("\n碗Size:X:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(roleInstance.GetBowlSize().X);
				defaultInterpolatedStringHandler.AppendLiteral(",Y:");
				defaultInterpolatedStringHandler.AppendFormatted<double>(roleInstance.GetBowlSize().Y);
				defaultInterpolatedStringHandler.AppendLiteral("\n速度:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetSpeedAttr().GetFinalValue());
				defaultInterpolatedStringHandler.AppendLiteral(",能量:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetEnergy());
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetMaxEnergy());
				defaultInterpolatedStringHandler.AppendLiteral("\n角色能量获取倍率:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetEnergyGetRate());
				defaultInterpolatedStringHandler.AppendLiteral("\n角色能量自动回复:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(roleInstance.GetEnergySelfRecover());
				defaultInterpolatedStringHandler.AppendLiteral("/秒\n角色护盾时间:");
				defaultInterpolatedStringHandler.AppendFormatted<double>((double)roleInstance.GetShieldTime() * Singleton<TimeUtil>.Instance.Millisecond);
				defaultInterpolatedStringHandler.AppendLiteral("秒\n角色技能状态:");
				defaultInterpolatedStringHandler.AppendFormatted<EDropCatchRoleSkillState>(roleInstance.GetSkillState());
				defaultInterpolatedStringHandler.AppendFormatted(value);
				defaultInterpolatedStringHandler.AppendLiteral("\n生效的掉落物池:");
				defaultInterpolatedStringHandler.AppendFormatted(text3);
				defaultInterpolatedStringHandler.AppendLiteral("\n关卡信息:Id:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Proxy.GetCurGameplayId());
				defaultInterpolatedStringHandler.AppendLiteral("\n区域:MinX:");
				DropCatchGameplayLogic gameplayLogic4 = this.Proxy.GetGameplayLogic();
				defaultInterpolatedStringHandler.AppendFormatted<double?>((gameplayLogic4 != null) ? new double?(gameplayLogic4.GetGameplayArea().MinX) : null);
				defaultInterpolatedStringHandler.AppendLiteral(",MinY:");
				DropCatchGameplayLogic gameplayLogic5 = this.Proxy.GetGameplayLogic();
				defaultInterpolatedStringHandler.AppendFormatted<double?>((gameplayLogic5 != null) ? new double?(gameplayLogic5.GetGameplayArea().MinY) : null);
				defaultInterpolatedStringHandler.AppendLiteral("\nMaxX:");
				DropCatchGameplayLogic gameplayLogic6 = this.Proxy.GetGameplayLogic();
				defaultInterpolatedStringHandler.AppendFormatted<double?>((gameplayLogic6 != null) ? new double?(gameplayLogic6.GetGameplayArea().MaxX) : null);
				defaultInterpolatedStringHandler.AppendLiteral(",MaxY:");
				DropCatchGameplayLogic gameplayLogic7 = this.Proxy.GetGameplayLogic();
				defaultInterpolatedStringHandler.AppendFormatted<double?>((gameplayLogic7 != null) ? new double?(gameplayLogic7.GetGameplayArea().MaxY) : null);
				defaultInterpolatedStringHandler.AppendLiteral("\n全局分数获取倍率:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.Proxy.GetGameplayLogic().GetAddScoreRate());
				defaultInterpolatedStringHandler.AppendLiteral("\n全局能量获取倍率:");
				defaultInterpolatedStringHandler.AppendFormatted<float>(this.Proxy.GetGameplayLogic().GetEnergyGetRate());
				string newText = defaultInterpolatedStringHandler.ToStringAndClear();
				base.GetText(16).SetText(newText, true);
			}
		}

		// Token: 0x040253BE RID: 152510
		private readonly int ROBOT_POS_X = 140;

		// Token: 0x040253BF RID: 152511
		[Nullable(1)]
		private DropCatchGameplayProxy Proxy;

		// Token: 0x040253C0 RID: 152512
		private DropCatchGameplayJoystickView JoystickView;

		// Token: 0x040253C1 RID: 152513
		private DropCatchGameplayLeftMsgView MsgGameplayView;

		// Token: 0x040253C2 RID: 152514
		private DropCatchGameplayLeftMsgView MsgDropItemView;

		// Token: 0x040253C3 RID: 152515
		private DropCatchGameplayRoleView RoleView;

		// Token: 0x040253C4 RID: 152516
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<DropCatchGameplayScoreItem, IScoreLevelItemData> ScoreLevelLayout;

		// Token: 0x040253C5 RID: 152517
		[Nullable(1)]
		private readonly List<IScoreLevelItemData> ScoreDataList = new List<IScoreLevelItemData>();

		// Token: 0x040253C6 RID: 152518
		[Nullable(1)]
		private readonly List<UUIItem> DropItemLayers = new List<UUIItem>();

		// Token: 0x040253C7 RID: 152519
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private DropCatchGameplayPanelViewPool<DropCatchGameplayFloatEffView> FloatEffPool;

		// Token: 0x040253C8 RID: 152520
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private DropCatchGameplayPanelViewPool<DropCatchGameplayDropItemFxView> DropItemFxPool;

		// Token: 0x040253C9 RID: 152521
		private DropCatchGameplayCountDownView CountDownView;

		// Token: 0x040253CA RID: 152522
		private UUIItem DropItemLayerTemplate;

		// Token: 0x040253CB RID: 152523
		private int IsRobotLeft = 1;

		// Token: 0x040253CC RID: 152524
		private int IsRobotHappy;

		// Token: 0x040253CD RID: 152525
		private EDropCatchRobotAnimState? LastRobotAnimState;

		// Token: 0x040253CE RID: 152526
		[Nullable(1)]
		private readonly EDropCatchRobotAnimState[][] RobotAnimStateTable;

		// Token: 0x040253CF RID: 152527
		private DropCatchGameplayRoleView BgRoleView;
	}
}
