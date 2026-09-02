using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.LevelConditions;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.LevelLoading;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MusicalInstrument
{
	// Token: 0x020056CB RID: 22219
	public class GuqinSubController : MusicalInstrumentSubController
	{
		// Token: 0x060388D8 RID: 231640 RVA: 0x00E539B3 File Offset: 0x00E51BB3
		public override EInstrumentType GetType()
		{
			return EInstrumentType.ChineseZither;
		}

		// Token: 0x060388D9 RID: 231641 RVA: 0x00E539B8 File Offset: 0x00E51BB8
		[NullableContext(2)]
		private string GetAbortReason()
		{
			GameModeModel instance = ModelBase<GameModeModel>.Instance;
			if (!instance.WorldDone)
			{
				return "世界未就绪";
			}
			if (instance.IsTeleport)
			{
				return "传送中";
			}
			if (instance.ChangeModeState)
			{
				return "切换世界模式中";
			}
			if (this.IsEnterCancelled)
			{
				return "进入已被取消";
			}
			if (this.IsEntityChanged())
			{
				return "弹琴实体已被换下";
			}
			if (this.IsSkillStarted && !this.IsSkillPlaying())
			{
				return "弹琴技能已被打断";
			}
			return null;
		}

		// Token: 0x060388DA RID: 231642 RVA: 0x00E53A28 File Offset: 0x00E51C28
		private bool CheckAborted()
		{
			string abortReason = this.GetAbortReason();
			if (abortReason == null)
			{
				return false;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MusicalInstrument;
			ELogAuthor author = ELogAuthor.CB;
			string message = "古琴玩法:进入中止";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", abortReason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}

		// Token: 0x060388DB RID: 231643 RVA: 0x00E53A6C File Offset: 0x00E51C6C
		public override UniTask<bool> OnEnter([Nullable(1)] MusicalInstrumentEnterParam param)
		{
			GuqinSubController.<OnEnter>d__17 <OnEnter>d__;
			<OnEnter>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnEnter>d__.<>4__this = this;
			<OnEnter>d__.<>1__state = -1;
			<OnEnter>d__.<>t__builder.Start<GuqinSubController.<OnEnter>d__17>(ref <OnEnter>d__);
			return <OnEnter>d__.<>t__builder.Task;
		}

		// Token: 0x060388DC RID: 231644 RVA: 0x00E53AAF File Offset: 0x00E51CAF
		public override void CancelEnter()
		{
			this.IsEnterCancelled = true;
			this.EndSkill();
			this.CancelWaitMontage();
		}

		// Token: 0x060388DD RID: 231645 RVA: 0x00E53AC4 File Offset: 0x00E51CC4
		private bool CheckRestrictedWithTip()
		{
			int restrictConditionGroupId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(80700051).Value.RestrictConditionGroupId;
			if (restrictConditionGroupId <= 0)
			{
				return false;
			}
			if (!ControllerBase<LevelGeneralController>.Instance.CheckCondition(restrictConditionGroupId.ToString(), null, false, Array.Empty<object>()))
			{
				return false;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MusicalInstrument;
			ELogAuthor author = ELogAuthor.CB;
			string message = "古琴玩法:进入-限制条件已满足,取消进入";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConditionGroupId", restrictConditionGroupId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(restrictConditionGroupId);
			if (conditionGroupHintText != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(conditionGroupHintText, Array.Empty<object>());
			}
			return true;
		}

		// Token: 0x060388DE RID: 231646 RVA: 0x00E53B60 File Offset: 0x00E51D60
		private UniTask EnsureBattleViewReset()
		{
			GuqinSubController.<EnsureBattleViewReset>d__20 <EnsureBattleViewReset>d__;
			<EnsureBattleViewReset>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureBattleViewReset>d__.<>1__state = -1;
			<EnsureBattleViewReset>d__.<>t__builder.Start<GuqinSubController.<EnsureBattleViewReset>d__20>(ref <EnsureBattleViewReset>d__);
			return <EnsureBattleViewReset>d__.<>t__builder.Task;
		}

		// Token: 0x060388DF RID: 231647 RVA: 0x00E53B9C File Offset: 0x00E51D9C
		private UniTask<bool> PrepareNormalEnter()
		{
			GuqinSubController.<PrepareNormalEnter>d__21 <PrepareNormalEnter>d__;
			<PrepareNormalEnter>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<PrepareNormalEnter>d__.<>4__this = this;
			<PrepareNormalEnter>d__.<>1__state = -1;
			<PrepareNormalEnter>d__.<>t__builder.Start<GuqinSubController.<PrepareNormalEnter>d__21>(ref <PrepareNormalEnter>d__);
			return <PrepareNormalEnter>d__.<>t__builder.Task;
		}

		// Token: 0x060388E0 RID: 231648 RVA: 0x00E53BE0 File Offset: 0x00E51DE0
		private bool PrepareQteEnter()
		{
			this.HandleBattleViewVisible(false);
			string uiCameraId = ConfigGuQinActivityParamById.GetConfig(111400001, true).Value.UiCameraId;
			this.CameraHandle = Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(uiCameraId, false, true, "1001", false, null, null);
			if (!this.CaptureCurrentEntity())
			{
				return false;
			}
			this.PlayQtePreMontage();
			return true;
		}

		// Token: 0x060388E1 RID: 231649 RVA: 0x00E53C44 File Offset: 0x00E51E44
		private UniTask<bool> EnterInternal([Nullable(2)] MusicalInstrumentQteData qteData)
		{
			GuqinSubController.<EnterInternal>d__23 <EnterInternal>d__;
			<EnterInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<EnterInternal>d__.<>4__this = this;
			<EnterInternal>d__.qteData = qteData;
			<EnterInternal>d__.<>1__state = -1;
			<EnterInternal>d__.<>t__builder.Start<GuqinSubController.<EnterInternal>d__23>(ref <EnterInternal>d__);
			return <EnterInternal>d__.<>t__builder.Task;
		}

		// Token: 0x060388E2 RID: 231650 RVA: 0x00E53C90 File Offset: 0x00E51E90
		[NullableContext(2)]
		private void RollbackEnter(MusicalInstrumentQteData qteData)
		{
			this.RemoveExitEvents();
			if (this.IsServerEntered)
			{
				this.RequestPlayState(ZitherOpState.OpExit).Forget<bool>();
				this.IsServerEntered = false;
			}
			if (Singleton<EventSystem>.Instance.Has<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd)))
			{
				Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnSkillEnd, new Action<int, int>(this.OnSkillEnd));
			}
			this.EndSkill();
			this.CancelWaitMontage();
			this.DestroyView();
			if (qteData == null)
			{
				if (this.ConditionPassCallback != null)
				{
					int restrictConditionGroupId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(80700051).Value.RestrictConditionGroupId;
					Singleton<LevelConditionRegistry>.Instance.UnRegisterConditionGroup(restrictConditionGroupId, this.ConditionPassCallback);
				}
			}
			else if (this.CameraHandle != null)
			{
				this.PlayQteEndSection();
				Singleton<UiCameraAnimationManager>.Instance.PopCameraHandle(this.CameraHandle, null);
				this.CameraHandle = null;
			}
			this.HandleBattleViewVisible(true);
			ControllerBase<LevelLoadingController>.Instance.CloseLoading((qteData == null) ? ELoadingReason.MusicalInstrument : ELoadingReason.Common, "GuqinSubController.Enter", null, new float?(0.5f));
			this.UnlockInput();
		}

		// Token: 0x060388E3 RID: 231651 RVA: 0x00E53D96 File Offset: 0x00E51F96
		private void RefreshInputTag(EInputControllerMainType last, EInputControllerMainType now)
		{
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x060388E4 RID: 231652 RVA: 0x00E53DA2 File Offset: 0x00E51FA2
		private void LockInput()
		{
			Singleton<InputManager>.Instance.RegisterLockShortcutKeyReason("MusicalInstrument.ChineseZither", null);
			this.SetInputRestricted(true);
			Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.RefreshInputTag));
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x060388E5 RID: 231653 RVA: 0x00E53DE1 File Offset: 0x00E51FE1
		private void UnlockInput()
		{
			Singleton<InputManager>.Instance.RemoveLockShortcutKeyReason("MusicalInstrument.ChineseZither");
			this.SetInputRestricted(false);
			Singleton<EventSystem>.Instance.Remove<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.RefreshInputTag));
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
		}

		// Token: 0x060388E6 RID: 231654 RVA: 0x00E53E20 File Offset: 0x00E52020
		private void SetInputRestricted(bool restricted)
		{
			MusicalInstrumentSubModel subModel = base.GetSubModel();
			if (subModel == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取不到SubModel", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			subModel.IsInputRestricted = restricted;
		}

		// Token: 0x060388E7 RID: 231655 RVA: 0x00E53E60 File Offset: 0x00E52060
		private void AddExitEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeMode, new Action(this.OnGameModeChanged));
		}

		// Token: 0x060388E8 RID: 231656 RVA: 0x00E53EE0 File Offset: 0x00E520E0
		private void RemoveExitEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationChanged));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CharOnRoleDead, new Action<int>(this.OnRoleDead));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeMode, new Action(this.OnGameModeChanged));
		}

		// Token: 0x060388E9 RID: 231657 RVA: 0x00E53F60 File Offset: 0x00E52160
		private bool CaptureCurrentEntity()
		{
			this.CurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (this.CurrentEntity == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:进入-取不到弹琴实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return true;
		}

		// Token: 0x060388EA RID: 231658 RVA: 0x00E53FA7 File Offset: 0x00E521A7
		private bool IsEntityOnStage()
		{
			return this.CurrentEntity != null && this.CurrentEntity == ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		}

		// Token: 0x060388EB RID: 231659 RVA: 0x00E53FC5 File Offset: 0x00E521C5
		private bool IsEntityChanged()
		{
			return this.CurrentEntity != null && this.CurrentEntity != ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		}

		// Token: 0x060388EC RID: 231660 RVA: 0x00E53FE8 File Offset: 0x00E521E8
		private void OnFormationChanged()
		{
			if (!this.IsEntityChanged())
			{
				return;
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.MusicalInstrument;
			ELogAuthor author = ELogAuthor.CB;
			string message = "古琴玩法:弹琴实体已被换下,触发退出";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Old";
			EntityHandle currentEntity = this.CurrentEntity;
			ptr = new ValueTuple<string, object>(item, (currentEntity != null) ? new int?(currentEntity.Id) : null);
			ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item2 = "New";
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			ptr2 = new ValueTuple<string, object>(item2, (getCurrentEntity != null) ? new int?(getCurrentEntity.Id) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388ED RID: 231661 RVA: 0x00E540C0 File Offset: 0x00E522C0
		private void OnGameModeChanged()
		{
			Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:世界模式已切换,触发退出", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388EE RID: 231662 RVA: 0x00E5410C File Offset: 0x00E5230C
		private void OnRestrictConditionCallback([Nullable(new byte[]
		{
			2,
			1
		})] object[] parameters)
		{
			int restrictConditionGroupId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(80700051).Value.RestrictConditionGroupId;
			if (restrictConditionGroupId > 0)
			{
				string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(restrictConditionGroupId);
				if (conditionGroupHintText != null)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(conditionGroupHintText, Array.Empty<object>());
				}
			}
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388EF RID: 231663 RVA: 0x00E54177 File Offset: 0x00E52377
		private void OnTeleportStart(bool loading)
		{
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388F0 RID: 231664 RVA: 0x00E5419C File Offset: 0x00E5239C
		private void OnRoleDead(int charId)
		{
			EntityHandle currentEntity = this.CurrentEntity;
			int? num = (currentEntity != null) ? new int?(currentEntity.Id) : null;
			if (!(charId == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.CurrentEntity = null;
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388F1 RID: 231665 RVA: 0x00E54208 File Offset: 0x00E52408
		private void OnSkillEnd(int entityId, int skillId)
		{
			EntityHandle currentEntity = this.CurrentEntity;
			int? num = (currentEntity != null) ? new int?(currentEntity.Id) : null;
			if (!(entityId == num.GetValueOrDefault() & num != null) || skillId != 800030)
			{
				return;
			}
			this.IsSkillEnded = true;
			this.CancelWaitMontage();
		}

		// Token: 0x060388F2 RID: 231666 RVA: 0x00E54260 File Offset: 0x00E52460
		private UniTask<bool> CreateView()
		{
			GuqinSubController.<CreateView>d__40 <CreateView>d__;
			<CreateView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CreateView>d__.<>4__this = this;
			<CreateView>d__.<>1__state = -1;
			<CreateView>d__.<>t__builder.Start<GuqinSubController.<CreateView>d__40>(ref <CreateView>d__);
			return <CreateView>d__.<>t__builder.Task;
		}

		// Token: 0x060388F3 RID: 231667 RVA: 0x00E542A3 File Offset: 0x00E524A3
		private void DestroyView()
		{
			if (this.ViewId != null)
			{
				Singleton<UiManager>.Instance.CloseViewById(this.ViewId.Value, null);
				this.ViewId = null;
			}
		}

		// Token: 0x060388F4 RID: 231668 RVA: 0x00E542D4 File Offset: 0x00E524D4
		private void HandleBattleViewVisible(bool visible)
		{
			if (visible)
			{
				BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
				if (childViewData == null)
				{
					return;
				}
				childViewData.ShowBattleView(EBattleUiVisibleReason.UiControl, 0);
				return;
			}
			else
			{
				BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
				if (childViewData2 == null)
				{
					return;
				}
				childViewData2.HideBattleView(EBattleUiVisibleReason.UiControl, new List<EBattleUiChild>
				{
					EBattleUiChild.GuideTipsView
				}, 0);
				return;
			}
		}

		// Token: 0x060388F5 RID: 231669 RVA: 0x00E54320 File Offset: 0x00E52520
		public override UniTask<bool> OnExit([Nullable(1)] MusicalInstrumentExitParam param)
		{
			GuqinSubController.<OnExit>d__43 <OnExit>d__;
			<OnExit>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnExit>d__.<>4__this = this;
			<OnExit>d__.<>1__state = -1;
			<OnExit>d__.<>t__builder.Start<GuqinSubController.<OnExit>d__43>(ref <OnExit>d__);
			return <OnExit>d__.<>t__builder.Task;
		}

		// Token: 0x060388F6 RID: 231670 RVA: 0x00E54364 File Offset: 0x00E52564
		private UniTask<bool> UseSkill()
		{
			GuqinSubController.<UseSkill>d__44 <UseSkill>d__;
			<UseSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<UseSkill>d__.<>1__state = -1;
			<UseSkill>d__.<>t__builder.Start<GuqinSubController.<UseSkill>d__44>(ref <UseSkill>d__);
			return <UseSkill>d__.<>t__builder.Task;
		}

		// Token: 0x060388F7 RID: 231671 RVA: 0x00E543A0 File Offset: 0x00E525A0
		private bool IsSkillPlaying()
		{
			EntityHandle currentEntity = this.CurrentEntity;
			object obj;
			if (currentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 == null)
			{
				return false;
			}
			global::Skill currentSkill = obj2.CurrentSkill;
			return ((currentSkill != null) ? new int?(currentSkill.SkillId) : null).GetValueOrDefault() == 800030;
		}

		// Token: 0x060388F8 RID: 231672 RVA: 0x00E54400 File Offset: 0x00E52600
		private void EndSkill()
		{
			EntityHandle currentEntity = this.CurrentEntity;
			object obj;
			if (currentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
			object obj2 = obj;
			bool flag;
			if (obj2 == null)
			{
				flag = true;
			}
			else
			{
				global::Skill currentSkill = obj2.CurrentSkill;
				flag = (((currentSkill != null) ? new int?(currentSkill.SkillId) : null).GetValueOrDefault() != 800030);
			}
			if (flag)
			{
				return;
			}
			EntityHandle currentEntity2 = this.CurrentEntity;
			BaseTagComponent baseTagComponent;
			if (currentEntity2 == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity2 = currentEntity2.Entity;
				baseTagComponent = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取不到Tag组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int tagIdByName = GameplayTagUtils.GetTagIdByName("系统.活动.弹琴玩法.结束弹琴");
			if (baseTagComponent2.HasTag(tagIdByName))
			{
				return;
			}
			baseTagComponent2.AddTag(new int?(tagIdByName));
		}

		// Token: 0x060388F9 RID: 231673 RVA: 0x00E544C8 File Offset: 0x00E526C8
		private UniTask WaitQteAudioFinish()
		{
			GuqinSubController.<WaitQteAudioFinish>d__47 <WaitQteAudioFinish>d__;
			<WaitQteAudioFinish>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitQteAudioFinish>d__.<>4__this = this;
			<WaitQteAudioFinish>d__.<>1__state = -1;
			<WaitQteAudioFinish>d__.<>t__builder.Start<GuqinSubController.<WaitQteAudioFinish>d__47>(ref <WaitQteAudioFinish>d__);
			return <WaitQteAudioFinish>d__.<>t__builder.Task;
		}

		// Token: 0x060388FA RID: 231674 RVA: 0x00E5450B File Offset: 0x00E5270B
		public override void OnQteCompleted()
		{
			ControllerBase<MusicalInstrumentController>.Instance.Exit(new MusicalInstrumentExitParam
			{
				Type = this.GetType()
			}).Forget<bool>();
		}

		// Token: 0x060388FB RID: 231675 RVA: 0x00E54530 File Offset: 0x00E52730
		private void PlayQtePreMontage()
		{
			GuQinActivityParam? config = ConfigGuQinActivityParamById.GetConfig(111400001, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.MusicalInstrument;
				ELogAuthor author = ELogAuthor.CB;
				string message = "古琴玩法:获取不到活动配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", 111400001);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			GuQinActivityParam valueOrDefault = config.GetValueOrDefault();
			string montagePath = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? valueOrDefault.MaleMontagePaths(0) : valueOrDefault.FemaleMontagePaths(0);
			EntityHandle currentEntity = this.CurrentEntity;
			CharacterAnimationComponent characterAnimationComponent;
			if (currentEntity == null)
			{
				characterAnimationComponent = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
			if (characterAnimationComponent2 == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取不到动画组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			characterAnimationComponent2.MontageManager.PlayMontage(new IPlayMontageParam
			{
				MontagePath = montagePath,
				InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.START_SECTION)
			});
		}

		// Token: 0x060388FC RID: 231676 RVA: 0x00E54624 File Offset: 0x00E52824
		private UniTask WaitMontageSection(FName sectionName)
		{
			GuqinSubController.<WaitMontageSection>d__50 <WaitMontageSection>d__;
			<WaitMontageSection>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitMontageSection>d__.<>4__this = this;
			<WaitMontageSection>d__.sectionName = sectionName;
			<WaitMontageSection>d__.<>1__state = -1;
			<WaitMontageSection>d__.<>t__builder.Start<GuqinSubController.<WaitMontageSection>d__50>(ref <WaitMontageSection>d__);
			return <WaitMontageSection>d__.<>t__builder.Task;
		}

		// Token: 0x060388FD RID: 231677 RVA: 0x00E54670 File Offset: 0x00E52870
		private void CancelWaitMontage()
		{
			TimerHandle montageTimer = this.MontageTimer;
			if (montageTimer != null && montageTimer.Valid())
			{
				this.MontageTimer.Remove();
			}
			this.MontageTimer = null;
			CustomPromise montagePromise = this.MontagePromise;
			if (montagePromise != null)
			{
				montagePromise.SetResult();
			}
			this.MontagePromise = null;
		}

		// Token: 0x060388FE RID: 231678 RVA: 0x00E546BC File Offset: 0x00E528BC
		private float? GetMontageSectionEndTime(FName sectionName)
		{
			if (!this.IsEntityOnStage())
			{
				return null;
			}
			EntityHandle currentEntity = this.CurrentEntity;
			object obj;
			if (currentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			object obj2 = obj;
			UAnimMontage uanimMontage;
			if (obj2 == null)
			{
				uanimMontage = null;
			}
			else
			{
				UAnimInstance mainAnimInstance = obj2.MainAnimInstance;
				uanimMontage = ((mainAnimInstance != null) ? mainAnimInstance.GetCurrentActiveMontage() : null);
			}
			UAnimMontage uanimMontage2 = uanimMontage;
			if (uanimMontage2 == null)
			{
				return null;
			}
			TArray<FCompositeSection> compositeSections = uanimMontage2.CompositeSections;
			int num = compositeSections.Num();
			for (int i = 0; i < num; i++)
			{
				if (compositeSections.Get(i).SectionName.Equals(sectionName))
				{
					return new float?((i + 1 < num) ? compositeSections.Get(i + 1).SegmentBeginTime : uanimMontage2.SequenceLength);
				}
			}
			return null;
		}

		// Token: 0x060388FF RID: 231679 RVA: 0x00E54784 File Offset: 0x00E52984
		private UniTask WaitMontagePosition(float targetPosition)
		{
			GuqinSubController.<WaitMontagePosition>d__53 <WaitMontagePosition>d__;
			<WaitMontagePosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<WaitMontagePosition>d__.<>4__this = this;
			<WaitMontagePosition>d__.targetPosition = targetPosition;
			<WaitMontagePosition>d__.<>1__state = -1;
			<WaitMontagePosition>d__.<>t__builder.Start<GuqinSubController.<WaitMontagePosition>d__53>(ref <WaitMontagePosition>d__);
			return <WaitMontagePosition>d__.<>t__builder.Task;
		}

		// Token: 0x06038900 RID: 231680 RVA: 0x00E547D0 File Offset: 0x00E529D0
		private float GetCurrentMontageBlendInTime()
		{
			if (!this.IsEntityOnStage())
			{
				return 0f;
			}
			EntityHandle currentEntity = this.CurrentEntity;
			object obj;
			if (currentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			object obj2 = obj;
			object obj3;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				UAnimInstance mainAnimInstance = obj2.MainAnimInstance;
				obj3 = ((mainAnimInstance != null) ? mainAnimInstance.GetCurrentActiveMontage() : null);
			}
			object obj4 = obj3;
			if (obj4 == null)
			{
				return 0f;
			}
			return obj4.BlendIn.BlendTime;
		}

		// Token: 0x06038901 RID: 231681 RVA: 0x00E54838 File Offset: 0x00E52A38
		private void PlayQtePostMontage()
		{
			GuQinActivityParam? config = ConfigGuQinActivityParamById.GetConfig(111400001, true);
			if (config == null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.MusicalInstrument;
				ELogAuthor author = ELogAuthor.CB;
				string message = "古琴玩法:获取不到活动配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", 111400001);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			GuQinActivityParam valueOrDefault = config.GetValueOrDefault();
			string montagePath = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? valueOrDefault.MaleMontagePaths(1) : valueOrDefault.FemaleMontagePaths(1);
			EntityHandle currentEntity = this.CurrentEntity;
			CharacterAnimationComponent characterAnimationComponent;
			if (currentEntity == null)
			{
				characterAnimationComponent = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
			if (characterAnimationComponent2 == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取不到动画组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			characterAnimationComponent2.MontageManager.PlayMontage(new IPlayMontageParam
			{
				MontagePath = montagePath,
				InSectionToStartMontageAt = new FName?(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION)
			});
		}

		// Token: 0x06038902 RID: 231682 RVA: 0x00E5492C File Offset: 0x00E52B2C
		private void PlayQteEndSection()
		{
			EntityHandle currentEntity = this.CurrentEntity;
			CharacterAnimationComponent characterAnimationComponent;
			if (currentEntity == null)
			{
				characterAnimationComponent = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				characterAnimationComponent = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			CharacterAnimationComponent characterAnimationComponent2 = characterAnimationComponent;
			if (characterAnimationComponent2 == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.MusicalInstrument, ELogAuthor.CB, "古琴玩法:获取不到动画组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			characterAnimationComponent2.MontageManager.StopMontage(new IStopMontageParam
			{
				Method = new EStopMethod?(EStopMethod.BlendToEndSection)
			});
		}

		// Token: 0x06038903 RID: 231683 RVA: 0x00E54998 File Offset: 0x00E52B98
		private float GetCurrentMontageBlendOutTime()
		{
			if (!this.IsEntityOnStage())
			{
				return 0f;
			}
			EntityHandle currentEntity = this.CurrentEntity;
			object obj;
			if (currentEntity == null)
			{
				obj = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				obj = ((entity != null) ? entity.GetComponent<CharacterAnimationComponent>() : null);
			}
			object obj2 = obj;
			object obj3;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				UAnimInstance mainAnimInstance = obj2.MainAnimInstance;
				obj3 = ((mainAnimInstance != null) ? mainAnimInstance.GetCurrentActiveMontage() : null);
			}
			object obj4 = obj3;
			if (obj4 == null)
			{
				return 0f;
			}
			return obj4.BlendOut.BlendTime;
		}

		// Token: 0x06038904 RID: 231684 RVA: 0x00E54A00 File Offset: 0x00E52C00
		private UniTask<bool> RequestPlayState(ZitherOpState state)
		{
			GuqinSubController.<RequestPlayState>d__58 <RequestPlayState>d__;
			<RequestPlayState>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestPlayState>d__.state = state;
			<RequestPlayState>d__.<>1__state = -1;
			<RequestPlayState>d__.<>t__builder.Start<GuqinSubController.<RequestPlayState>d__58>(ref <RequestPlayState>d__);
			return <RequestPlayState>d__.<>t__builder.Task;
		}

		// Token: 0x06038905 RID: 231685 RVA: 0x00E54A43 File Offset: 0x00E52C43
		[NullableContext(2)]
		public GuqinView GetView()
		{
			if (this.ViewId == null)
			{
				return null;
			}
			return Singleton<UiManager>.Instance.GetView(this.ViewId.Value) as GuqinView;
		}

		// Token: 0x06038906 RID: 231686 RVA: 0x00E54A70 File Offset: 0x00E52C70
		[NullableContext(1)]
		public void OnGamepadCameraZoom(string axisName, float value)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			MusicalInstrumentSubModel subModel = base.GetSubModel();
			if (((subModel != null) ? subModel.GetQteData() : null) != null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.HelpView))
			{
				return;
			}
			EntityHandle currentEntity = this.CurrentEntity;
			CharacterInputComponent characterInputComponent;
			if (currentEntity == null)
			{
				characterInputComponent = null;
			}
			else
			{
				WorldEntity entity = currentEntity.Entity;
				characterInputComponent = ((entity != null) ? entity.GetComponent<CharacterInputComponent>() : null);
			}
			CharacterInputComponent characterInputComponent2 = characterInputComponent;
			if (characterInputComponent2 == null)
			{
				return;
			}
			float value2 = value * 80f;
			characterInputComponent2.HandleInputAxis(EInputAxis.Zoom, value2);
		}

		// Token: 0x04020457 RID: 132183
		private const int SKILL_ID = 800030;

		// Token: 0x04020458 RID: 132184
		private const int ACTIVITYID = 111400001;

		// Token: 0x04020459 RID: 132185
		[Nullable(1)]
		private const string END_GUQIN_TAG_NAME = "系统.活动.弹琴玩法.结束弹琴";

		// Token: 0x0402045A RID: 132186
		private const float BLACK_FADE_TIME = 0.5f;

		// Token: 0x0402045B RID: 132187
		[Nullable(2)]
		private CustomPromise MontagePromise;

		// Token: 0x0402045C RID: 132188
		[Nullable(2)]
		private TimerHandle MontageTimer;

		// Token: 0x0402045D RID: 132189
		[Nullable(2)]
		private UiCameraHandleData CameraHandle;

		// Token: 0x0402045E RID: 132190
		private int? ViewId;

		// Token: 0x0402045F RID: 132191
		[Nullable(1)]
		private ConditionPassCallback ConditionPassCallback;

		// Token: 0x04020460 RID: 132192
		[Nullable(2)]
		private EntityHandle CurrentEntity;

		// Token: 0x04020461 RID: 132193
		private bool IsSkillEnded;

		// Token: 0x04020462 RID: 132194
		private bool IsEnterCancelled;

		// Token: 0x04020463 RID: 132195
		private bool IsSkillStarted;

		// Token: 0x04020464 RID: 132196
		private bool IsServerEntered;
	}
}
