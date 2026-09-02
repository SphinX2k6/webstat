using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006004 RID: 24580
	[NullableContext(2)]
	[Nullable(0)]
	public class BreakWeaknessPanel : UiPanelBase
	{
		// Token: 0x0603DE78 RID: 253560 RVA: 0x00FCA614 File Offset: 0x00FC8814
		[NullableContext(1)]
		public void Init(UUIItem parentItem, [Nullable(2)] UUIItem rootItem)
		{
			this.CurVisible = false;
			this.TargetVisible = false;
			this.ChildViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			this.ChildVisible = this.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
			this.ButtonConfig = ConfigBase<SkillButtonConfig>.Instance.GetBehaviorCommonButtonConfig(2004);
			this.InteractionShowDelay = ConfigCommonParamById.GetFloatConfig("WeaknessInteractionShowDelay").Value;
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("WeaknessDistanceLimit");
			this.HorizontalDistance = (float)((intArrayConfig != null && intArrayConfig.Count > 0) ? intArrayConfig[0] : 0);
			this.UpDistance = (float)((intArrayConfig != null && intArrayConfig.Count > 1) ? intArrayConfig[1] : 0);
			this.DownDistance = (float)((intArrayConfig != null && intArrayConfig.Count > 2) ? intArrayConfig[2] : 0);
			this.Initialize(parentItem, rootItem).Forget();
		}

		// Token: 0x0603DE79 RID: 253561 RVA: 0x00FCA6F0 File Offset: 0x00FC88F0
		[NullableContext(1)]
		public UniTask Initialize(UUIItem parentItem, [Nullable(2)] UUIItem rootItem)
		{
			BreakWeaknessPanel.<Initialize>d__44 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.parentItem = parentItem;
			<Initialize>d__.rootItem = rootItem;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<BreakWeaknessPanel.<Initialize>d__44>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE7A RID: 253562 RVA: 0x00FCA744 File Offset: 0x00FC8944
		protected unsafe override void OnRegisterComponent()
		{
			int num;
			Span<ValueTuple<int, Type>> span;
			int num2;
			if (Singleton<Info>.Instance.IsInTouch())
			{
				num = 2;
				List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
				CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
				span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
				num2 = 0;
				*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
				num2++;
				*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
				this.ComponentRegisterInfos = list;
				num2 = 1;
				List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
				CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
				Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
				num = 0;
				*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickSkillButton));
				this.BtnBindInfo = list2;
				return;
			}
			num = 1;
			List<ValueTuple<int, Type>> list3 = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list3, num);
			span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list3);
			num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list3;
		}

		// Token: 0x0603DE7B RID: 253563 RVA: 0x00FCA838 File Offset: 0x00FC8A38
		protected override UniTask OnBeforeStartAsync()
		{
			BreakWeaknessPanel.<OnBeforeStartAsync>d__46 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BreakWeaknessPanel.<OnBeforeStartAsync>d__46>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE7C RID: 253564 RVA: 0x00FCA87C File Offset: 0x00FC8A7C
		[NullableContext(0)]
		private UniTask<bool> NewKeyItem()
		{
			BreakWeaknessPanel.<NewKeyItem>d__47 <NewKeyItem>d__;
			<NewKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<NewKeyItem>d__.<>4__this = this;
			<NewKeyItem>d__.<>1__state = -1;
			<NewKeyItem>d__.<>t__builder.Start<BreakWeaknessPanel.<NewKeyItem>d__47>(ref <NewKeyItem>d__);
			return <NewKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE7D RID: 253565 RVA: 0x00FCA8BF File Offset: 0x00FC8ABF
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TexIcon = base.GetTexture(1);
			if (this.TagComponent != null)
			{
				this.OnDisableTagChanged(0, false);
			}
		}

		// Token: 0x0603DE7E RID: 253566 RVA: 0x00FCA8F0 File Offset: 0x00FC8AF0
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopPlayingSequence(false, true);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlayLevelSequenceByName("Start", false, null, false);
			}
			this.IsClicked = false;
			this.RefreshIcon();
		}

		// Token: 0x0603DE7F RID: 253567 RVA: 0x00FCA93E File Offset: 0x00FC8B3E
		protected override void OnAfterHide()
		{
			this.TempMonsterEntityHandle = null;
			this.TempTargetSocket = null;
		}

		// Token: 0x0603DE80 RID: 253568 RVA: 0x00FCA954 File Offset: 0x00FC8B54
		private void RefreshIcon()
		{
			if (this.TexIcon == null)
			{
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				return;
			}
			RoleInfo? roleConfig = getCurrentEntity.Entity.GetComponent<CreatureDataComponent>().GetRoleConfig();
			int num = (roleConfig != null) ? roleConfig.GetValueOrDefault().WeaponType : 1;
			string skillIcon = this.ButtonConfig.Value.SkillIcons(num - 1);
			this.SetSkillIcon(skillIcon);
		}

		// Token: 0x0603DE81 RID: 253569 RVA: 0x00FCA9D4 File Offset: 0x00FC8BD4
		[NullableContext(1)]
		private void SetSkillIcon(string skillIconPath)
		{
			if (string.IsNullOrEmpty(skillIconPath))
			{
				return;
			}
			if (this.SkillIconPath == skillIconPath)
			{
				return;
			}
			if (this.SetTextureHandleId != 0)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.SetTextureHandleId);
			}
			this.IsLoadingSkillIcon = true;
			this.SkillIconPath = skillIconPath;
			this.SetTextureHandleId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(skillIconPath, delegate([Nullable(2)] UTexture textureData, string _)
			{
				this.IsLoadingSkillIcon = false;
				if (this.TexIcon == null || this.SkillIconPath != skillIconPath)
				{
					return;
				}
				if (textureData == null)
				{
					this.TexIcon.SetUIActive(false);
					return;
				}
				this.TexIcon.SetTexture(textureData);
				this.TexIcon.SetUIActive(true);
			}, 103, "js_undefined");
			this.SkillIconPath = skillIconPath;
			if (this.IsLoadingSkillIcon)
			{
				this.TexIcon.SetUIActive(false);
			}
		}

		// Token: 0x0603DE82 RID: 253570 RVA: 0x00FCAA8C File Offset: 0x00FC8C8C
		protected override UniTask OnBeforeHideAsync()
		{
			BreakWeaknessPanel.<OnBeforeHideAsync>d__53 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<BreakWeaknessPanel.<OnBeforeHideAsync>d__53>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DE83 RID: 253571 RVA: 0x00FCAACF File Offset: 0x00FC8CCF
		private void OnCloseAnimTimerEnd(float _)
		{
			this.CloseTimer = null;
			this.Promise.SetResult();
			this.Promise = null;
		}

		// Token: 0x0603DE84 RID: 253572 RVA: 0x00FCAAEC File Offset: 0x00FC8CEC
		protected override void OnBeforeDestroy()
		{
			if (this.MonsterEntityHandle != null)
			{
				this.OnRemove();
			}
			if (this.CloseTimer != null)
			{
				TimerSystem.Instance.Remove(this.CloseTimer);
				this.CloseTimer = null;
				this.Promise.SetResult();
				this.Promise = null;
			}
			this.TexIcon = null;
			this.TempMonsterEntityHandle = null;
			this.RemoveEvents();
			this.RemoveNextTick();
			this.RemoveInteractionShowTimer(true);
		}

		// Token: 0x0603DE85 RID: 253573 RVA: 0x00FCAB5C File Offset: 0x00FC8D5C
		private void AddEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.BindAction("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			this.ChildViewData.AddCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleChildVisibleChanged));
		}

		// Token: 0x0603DE86 RID: 253574 RVA: 0x00FCABAC File Offset: 0x00FC8DAC
		private void RemoveEvents()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				ControllerBase<InputDistributeController>.Instance.UnBindAction("通用交互", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			}
			this.ChildViewData.RemoveCallback(EBattleUiChild.BattleHud, new Action(this.OnBattleChildVisibleChanged));
		}

		// Token: 0x0603DE87 RID: 253575 RVA: 0x00FCABF9 File Offset: 0x00FC8DF9
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType == InputDistributeDefine.EActionType.Release)
			{
				this.OnInteract();
			}
		}

		// Token: 0x0603DE88 RID: 253576 RVA: 0x00FCAC05 File Offset: 0x00FC8E05
		private void OnClickSkillButton()
		{
			this.OnInteract();
		}

		// Token: 0x0603DE89 RID: 253577 RVA: 0x00FCAC10 File Offset: 0x00FC8E10
		private void OnInteract()
		{
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle == null || !monsterEntityHandle.Valid)
			{
				this.OnRemove();
				return;
			}
			this.RefreshEntityDistanceValid();
			if (!this.DistanceValid)
			{
				this.RefreshVisible();
				return;
			}
			this.RefreshLogicVisible();
			if (!this.IsLogicVisible())
			{
				return;
			}
			PawnInteractBaseComponent component = this.MonsterEntityHandle.Entity.GetComponent<PawnInteractBaseComponent>();
			if (component == null || !component.IsPawnInteractive())
			{
				return;
			}
			component.InteractPawn(-1, null);
			this.IsClicked = true;
		}

		// Token: 0x0603DE8A RID: 253578 RVA: 0x00FCAC92 File Offset: 0x00FC8E92
		private void OnBattleChildVisibleChanged()
		{
			this.ChildVisible = this.ChildViewData.GetChildVisible(EBattleUiChild.BattleHud);
			this.RefreshVisible();
		}

		// Token: 0x0603DE8B RID: 253579 RVA: 0x00FCACB0 File Offset: 0x00FC8EB0
		public void ShowByEntity(int entityId, ECustomOptionType? optionType)
		{
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle != null && monsterEntityHandle.Id == entityId)
			{
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(entityId);
			if (entityById == null)
			{
				this.OnRemove();
				return;
			}
			this.RemoveEntityEvents();
			this.MonsterEntityHandle = entityById;
			this.MonsterWeaknessComp = this.MonsterEntityHandle.Entity.GetComponent<MonsterWeaknessComponent>();
			this.OnAdd();
			this.RefreshIcon();
		}

		// Token: 0x0603DE8C RID: 253580 RVA: 0x00FCAD1A File Offset: 0x00FC8F1A
		public void HideByEntity(int entityId)
		{
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle == null || monsterEntityHandle.Id != entityId)
			{
				return;
			}
			this.OnRemove();
		}

		// Token: 0x0603DE8D RID: 253581 RVA: 0x00FCAD3D File Offset: 0x00FC8F3D
		public void ChangeRole()
		{
			if (this.MonsterEntityHandle == null)
			{
				return;
			}
			this.ClearAllTagCountChangedCallback();
			this.RemoveCharAnimBreakPointListener();
			this.RefreshPlayerEntity();
			this.RefreshIcon();
		}

		// Token: 0x0603DE8E RID: 253582 RVA: 0x00FCAD60 File Offset: 0x00FC8F60
		private void RefreshPlayerEntity()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				this.TagComponent = null;
				this.SkillComponent = null;
				this.RefreshVisible();
				return;
			}
			this.TagComponent = getCurrentEntity.Entity.GetComponent<BaseTagComponent>();
			this.SkillComponent = getCurrentEntity.Entity.GetComponent<BaseSkillComponent>();
			this.AddEntityEvents();
			this.OnDisableTagChanged(0, false);
			this.OnHiddenTagChanged(0, false);
			this.OnSkillAnimTagChanged(0, false);
		}

		// Token: 0x0603DE8F RID: 253583 RVA: 0x00FCADDE File Offset: 0x00FC8FDE
		private void OnAdd()
		{
			this.RefreshEntityDistanceValid();
			this.RefreshPlayerEntity();
			this.AddTimer();
			this.RemoveInteractionShowTimer(false);
			ModelBase<BattleUiModel>.Instance.SetExecutionInteractEnable(true);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, false, true, 0);
		}

		// Token: 0x0603DE90 RID: 253584 RVA: 0x00FCAE1C File Offset: 0x00FC901C
		private void OnRemove()
		{
			this.RemoveEntityEvents();
			this.RemoveTimer();
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle != null && monsterEntityHandle.Valid)
			{
				this.TempMonsterEntityHandle = this.MonsterEntityHandle;
				MonsterWeaknessComponent monsterWeaknessComp = this.MonsterWeaknessComp;
				string text = (monsterWeaknessComp != null) ? monsterWeaknessComp.TargetSocket : null;
				this.TempTargetSocket = new FName?((!string.IsNullOrEmpty(text)) ? new FName(text) : this.hitCaseSocket);
			}
			this.MonsterEntityHandle = null;
			this.MonsterWeaknessComp = null;
			this.TagComponent = null;
			this.SkillComponent = null;
			this.DistanceValid = false;
			this.RefreshVisible();
			this.AddInteractionShowTimer();
			ModelBase<BattleUiModel>.Instance.SetExecutionInteractEnable(false);
		}

		// Token: 0x0603DE91 RID: 253585 RVA: 0x00FCAEC4 File Offset: 0x00FC90C4
		private void AddEntityEvents()
		{
			if (this.MonsterEntityHandle == null)
			{
				return;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<ERemoveEntityType, EntityHandle>(this.MonsterEntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.MonsterEntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
			}
			BehaviorCommonButton value = this.ButtonConfig.Value;
			for (int i = 0; i < value.DisableTagsLength; i++)
			{
				this.ListenForTagAddOrRemoveChanged(value.DisableTags(i), new BaseTagComponent.TTagSwitchedCallback(this.OnDisableTagChanged));
			}
			for (int j = 0; j < value.HiddenTagsLength; j++)
			{
				this.ListenForTagAddOrRemoveChanged(value.HiddenTags(j), new BaseTagComponent.TTagSwitchedCallback(this.OnHiddenTagChanged));
			}
			this.ListenForTagAddOrRemoveChanged(BreakWeaknessPanel.ultimateTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSkillAnimTagChanged));
			this.ListenForTagAddOrRemoveChanged(BreakWeaknessPanel.qteTag, new BaseTagComponent.TTagSwitchedCallback(this.OnSkillAnimTagChanged));
		}

		// Token: 0x0603DE92 RID: 253586 RVA: 0x00FCAFB1 File Offset: 0x00FC91B1
		private void RemoveEntityEvents()
		{
			this.ClearAllTagCountChangedCallback();
			this.RemoveCharAnimBreakPointListener();
			this.SkillAnimVisible = true;
			if (this.MonsterEntityHandle == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.MonsterEntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}

		// Token: 0x0603DE93 RID: 253587 RVA: 0x00FCAFF1 File Offset: 0x00FC91F1
		[NullableContext(1)]
		private void OnRemoveEntity(ERemoveEntityType eRemoveEntityType, EntityHandle entityHandle)
		{
			this.OnRemove();
		}

		// Token: 0x0603DE94 RID: 253588 RVA: 0x00FCAFFC File Offset: 0x00FC91FC
		private void OnDisableTagChanged(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				this.SetEnable(false);
				return;
			}
			BehaviorCommonButton value = this.ButtonConfig.Value;
			for (int i = 0; i < value.DisableTagsLength; i++)
			{
				if (this.TagComponent.HasTag(value.DisableTags(i)))
				{
					this.SetEnable(false);
					return;
				}
			}
			this.SetEnable(true);
		}

		// Token: 0x0603DE95 RID: 253589 RVA: 0x00FCB058 File Offset: 0x00FC9258
		private void OnHiddenTagChanged(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				this.TagVisible = false;
				this.RefreshVisible();
				return;
			}
			BehaviorCommonButton value = this.ButtonConfig.Value;
			for (int i = 0; i < value.HiddenTagsLength; i++)
			{
				if (this.TagComponent.HasTag(value.HiddenTags(i)))
				{
					this.TagVisible = false;
					this.RefreshVisible();
					return;
				}
			}
			this.TagVisible = true;
			this.RefreshVisible();
		}

		// Token: 0x0603DE96 RID: 253590 RVA: 0x00FCB0C4 File Offset: 0x00FC92C4
		private void OnSkillAnimTagChanged(int tagId, bool tagExist)
		{
			this.RefreshSkillAnimVisible();
		}

		// Token: 0x0603DE97 RID: 253591 RVA: 0x00FCB0CC File Offset: 0x00FC92CC
		private void RefreshSkillAnimVisible()
		{
			if (this.TagComponent == null)
			{
				return;
			}
			if (this.TagComponent.HasTag(BreakWeaknessPanel.ultimateTag) || this.TagComponent.HasTag(BreakWeaknessPanel.qteTag))
			{
				BaseSkillComponent skillComponent = this.SkillComponent;
				this.SkillAnimVisible = (skillComponent == null || skillComponent.IsMainSkillReadyEnd);
				this.RefreshVisible();
				if (!this.SkillAnimVisible)
				{
					this.AddCharAnimBreakPointListener();
					return;
				}
			}
			else
			{
				this.RemoveCharAnimBreakPointListener();
				this.SkillAnimVisible = true;
				this.RefreshVisible();
			}
		}

		// Token: 0x0603DE98 RID: 253592 RVA: 0x00FCB149 File Offset: 0x00FC9349
		private void AddCharAnimBreakPointListener()
		{
			if (this.IsListeningCharAnimBreakPoint)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Add<int>(EEventName.CharAnimBreakPoint, new Action<int>(this.OnCharAnimBreakPoint));
			this.IsListeningCharAnimBreakPoint = true;
		}

		// Token: 0x0603DE99 RID: 253593 RVA: 0x00FCB174 File Offset: 0x00FC9374
		private void RemoveCharAnimBreakPointListener()
		{
			if (!this.IsListeningCharAnimBreakPoint)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.CharAnimBreakPoint, new Action<int>(this.OnCharAnimBreakPoint));
			this.IsListeningCharAnimBreakPoint = false;
		}

		// Token: 0x0603DE9A RID: 253594 RVA: 0x00FCB19F File Offset: 0x00FC939F
		private void OnCharAnimBreakPoint(int charId)
		{
			this.RefreshSkillAnimVisible();
		}

		// Token: 0x0603DE9B RID: 253595 RVA: 0x00FCB1A7 File Offset: 0x00FC93A7
		private void SetEnable(bool value)
		{
			if (this.RootItem == null)
			{
				return;
			}
			if (value)
			{
				this.RootItem.SetAlpha(1f);
				return;
			}
			this.RootItem.SetAlpha(0.5f);
		}

		// Token: 0x0603DE9C RID: 253596 RVA: 0x00FCB1D8 File Offset: 0x00FC93D8
		[NullableContext(1)]
		private void ListenForTagAddOrRemoveChanged(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent == null)
			{
				return;
			}
			ITagTask item = tagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null);
			this.TagTaskList.Add(item);
		}

		// Token: 0x0603DE9D RID: 253597 RVA: 0x00FCB20C File Offset: 0x00FC940C
		private void ClearAllTagCountChangedCallback()
		{
			if (this.TagTaskList.Count > 0)
			{
				foreach (ITagTask tagTask in this.TagTaskList)
				{
					tagTask.EndTask();
				}
				this.TagTaskList.Clear();
			}
		}

		// Token: 0x0603DE9E RID: 253598 RVA: 0x00FCB278 File Offset: 0x00FC9478
		public void Tick(float delta)
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			if (base.IsShowOrShowing || base.IsHiding)
			{
				this.RefreshActiveAndPosition();
				if (!this.IsInScreen && this.TargetVisible)
				{
					this.SetVisible(false);
				}
				return;
			}
			if (this.IsLogicVisible() && this.ChildVisible)
			{
				this.RefreshActiveAndPosition();
				if (this.IsInScreen)
				{
					this.SetVisible(true);
				}
				return;
			}
		}

		// Token: 0x0603DE9F RID: 253599 RVA: 0x00FCB2E8 File Offset: 0x00FC94E8
		private void RefreshActiveAndPosition()
		{
			if (this.RootItem == null)
			{
				return;
			}
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle == null || !monsterEntityHandle.Valid)
			{
				EntityHandle tempMonsterEntityHandle = this.TempMonsterEntityHandle;
				if (tempMonsterEntityHandle == null || !tempMonsterEntityHandle.Valid)
				{
					return;
				}
			}
			FVectorDouble? worldLocation = this.GetWorldLocation();
			if (worldLocation == null)
			{
				return;
			}
			this.IsInScreen = HudUnitUtils.PositionUtil.ProjectWorldToScreen(worldLocation.Value, this.ScreenPos);
			if (!this.IsInScreen)
			{
				return;
			}
			this.RootItem.SetAnchorOffset(this.ScreenPos.ToUeVector2D(false));
		}

		// Token: 0x0603DEA0 RID: 253600 RVA: 0x00FCB37C File Offset: 0x00FC957C
		private FVectorDouble? GetWorldLocation()
		{
			EntityHandle entityHandle = this.MonsterEntityHandle ?? this.TempMonsterEntityHandle;
			if (entityHandle == null)
			{
				return null;
			}
			TsBaseCharacter tsBaseCharacter = entityHandle.Entity.GetComponent<BaseActorComponent>().Owner as TsBaseCharacter;
			if (tsBaseCharacter == null)
			{
				return null;
			}
			USceneComponent mesh = tsBaseCharacter.Mesh;
			MonsterWeaknessComponent monsterWeaknessComp = this.MonsterWeaknessComp;
			string text = (monsterWeaknessComp != null) ? monsterWeaknessComp.TargetSocket : null;
			FName inSocketName = (!string.IsNullOrEmpty(text)) ? new FName(text) : (this.TempTargetSocket ?? this.hitCaseSocket);
			return new FVectorDouble?(mesh.D_GetSocketLocation(inSocketName));
		}

		// Token: 0x0603DEA1 RID: 253601 RVA: 0x00FCB424 File Offset: 0x00FC9624
		private void RefreshVisible()
		{
			this.RefreshLogicVisible();
			if (!this.IsLogicVisible() || !this.ChildVisible)
			{
				this.SetVisible(false);
				return;
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.RefreshActiveAndPosition();
			}
			else
			{
				this.IsInScreen = true;
			}
			if (this.IsInScreen)
			{
				this.SetVisible(true);
				return;
			}
			this.SetVisible(false);
		}

		// Token: 0x0603DEA2 RID: 253602 RVA: 0x00FCB481 File Offset: 0x00FC9681
		private void SetVisible(bool value)
		{
			this.TargetVisible = value;
			if (this.TargetVisible == this.CurVisible)
			{
				this.RemoveNextTick();
				return;
			}
			this.AddNextTick();
		}

		// Token: 0x0603DEA3 RID: 253603 RVA: 0x00FCB4A5 File Offset: 0x00FC96A5
		private void AddNextTick()
		{
			if (this.NextTick != null)
			{
				return;
			}
			this.NextTick = TimerSystem.Instance.Next(new TTimerAction(this.OnNextTick), null, null);
		}

		// Token: 0x0603DEA4 RID: 253604 RVA: 0x00FCB4CE File Offset: 0x00FC96CE
		private void RemoveNextTick()
		{
			if (this.NextTick == null)
			{
				return;
			}
			TimerSystem.Instance.Remove(this.NextTick);
			this.NextTick = null;
		}

		// Token: 0x0603DEA5 RID: 253605 RVA: 0x00FCB4F4 File Offset: 0x00FC96F4
		private void OnNextTick(float _)
		{
			this.NextTick = null;
			if (this.CurVisible != this.TargetVisible)
			{
				this.CurVisible = this.TargetVisible;
				if (this.CurVisible)
				{
					base.Show(null);
					if (this.CloseTimer != null)
					{
						TimerSystem.Instance.Remove(this.CloseTimer);
						this.CloseTimer = null;
						this.Promise.SetResult();
						this.Promise = null;
						return;
					}
				}
				else
				{
					base.Hide(null);
				}
			}
		}

		// Token: 0x0603DEA6 RID: 253606 RVA: 0x00FCB56B File Offset: 0x00FC976B
		private void AddTimer()
		{
			if (this.Timer != null)
			{
				return;
			}
			this.Timer = TimerSystem.Instance.Forever(new TTimerAction(this.OnTimer), 200f, 1f, null, null, true);
		}

		// Token: 0x0603DEA7 RID: 253607 RVA: 0x00FCB59F File Offset: 0x00FC979F
		private void RemoveTimer()
		{
			if (this.Timer == null)
			{
				return;
			}
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}

		// Token: 0x0603DEA8 RID: 253608 RVA: 0x00FCB5C2 File Offset: 0x00FC97C2
		private void OnTimer(float _)
		{
			bool distanceValid = this.DistanceValid;
			this.RefreshEntityDistanceValid();
			if (distanceValid != this.DistanceValid)
			{
				this.RefreshVisible();
			}
		}

		// Token: 0x0603DEA9 RID: 253609 RVA: 0x00FCB5E0 File Offset: 0x00FC97E0
		private void RefreshEntityDistanceValid()
		{
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			if (monsterEntityHandle == null || !monsterEntityHandle.Valid || this.MonsterWeaknessComp == null)
			{
				this.DistanceValid = false;
				return;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null || !getCurrentEntity.Valid)
			{
				this.DistanceValid = false;
				return;
			}
			global::Vector actorLocationProxy = getCurrentEntity.Entity.GetComponent<BaseActorComponent>().ActorLocationProxy;
			FVectorDouble? worldLocation = this.GetWorldLocation();
			if (worldLocation == null)
			{
				this.DistanceValid = false;
				return;
			}
			FVectorDouble value = worldLocation.Value;
			double num = actorLocationProxy.Z - value.Z;
			if (num < (double)(-(double)this.UpDistance) || num > (double)this.DownDistance)
			{
				this.DistanceValid = false;
				return;
			}
			double num2 = actorLocationProxy.X - value.X;
			double num3 = actorLocationProxy.Y - value.Y;
			double num4 = num2 * num2 + num3 * num3;
			float horizontalDistance = this.HorizontalDistance;
			if (num4 > (double)(horizontalDistance * horizontalDistance))
			{
				this.DistanceValid = false;
				return;
			}
			this.DistanceValid = true;
		}

		// Token: 0x0603DEAA RID: 253610 RVA: 0x00FCB6DF File Offset: 0x00FC98DF
		private bool IsLogicVisible()
		{
			return this.LogicVisible;
		}

		// Token: 0x0603DEAB RID: 253611 RVA: 0x00FCB6E7 File Offset: 0x00FC98E7
		private bool CameraSeqVisible()
		{
			return this.ChildViewData.GetVisibleByReason(EBattleUiChild.BattleHud, EBattleUiVisibleReason.CameraSeq);
		}

		// Token: 0x0603DEAC RID: 253612 RVA: 0x00FCB6F8 File Offset: 0x00FC98F8
		private void RefreshLogicVisible()
		{
			bool flag = this.DistanceValid && this.CameraSeqVisible() && this.TagVisible && this.SkillAnimVisible;
			EntityHandle monsterEntityHandle = this.MonsterEntityHandle;
			int num = (monsterEntityHandle != null) ? monsterEntityHandle.Id : 0;
			if (flag == this.LogicVisible && this.LastMonsterEntityId == num)
			{
				return;
			}
			this.LogicVisible = flag;
			this.LastMonsterEntityId = num;
			Singleton<EventSystem>.Instance.Emit<bool, int>(EEventName.BreakWeaknessPanelLogicVisibleChange, flag, num);
		}

		// Token: 0x0603DEAD RID: 253613 RVA: 0x00FCB76D File Offset: 0x00FC996D
		private void AddInteractionShowTimer()
		{
			this.RemoveInteractionShowTimer(false);
			this.InteractionShowTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, true, true, 0);
				this.InteractionShowTimer = null;
			}, this.InteractionShowDelay, null, null, true, 1f);
		}

		// Token: 0x0603DEAE RID: 253614 RVA: 0x00FCB7A0 File Offset: 0x00FC99A0
		private void RemoveInteractionShowTimer(bool resetVisible = false)
		{
			if (this.InteractionShowTimer != null)
			{
				TimerSystem.Instance.Remove(this.InteractionShowTimer);
				this.InteractionShowTimer = null;
				if (resetVisible)
				{
					ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, true, true, 0);
				}
			}
		}

		// Token: 0x04022B94 RID: 142228
		private const float CLOSE_ANIM_TIME = 300f;

		// Token: 0x04022B95 RID: 142229
		private const EBattleUiChild ChildType = EBattleUiChild.BattleHud;

		// Token: 0x04022B96 RID: 142230
		private static readonly int ultimateTag = GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.大招"];

		// Token: 0x04022B97 RID: 142231
		private static readonly int qteTag = GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.QTE"];

		// Token: 0x04022B98 RID: 142232
		private readonly FName hitCaseSocket = new FName("HitCase");

		// Token: 0x04022B99 RID: 142233
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022B9A RID: 142234
		[Nullable(1)]
		private readonly Vector2D ScreenPos = new Vector2D();

		// Token: 0x04022B9B RID: 142235
		private EntityHandle MonsterEntityHandle;

		// Token: 0x04022B9C RID: 142236
		private int LastMonsterEntityId;

		// Token: 0x04022B9D RID: 142237
		private MonsterWeaknessComponent MonsterWeaknessComp;

		// Token: 0x04022B9E RID: 142238
		private BaseTagComponent TagComponent;

		// Token: 0x04022B9F RID: 142239
		private BaseSkillComponent SkillComponent;

		// Token: 0x04022BA0 RID: 142240
		[Nullable(1)]
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x04022BA1 RID: 142241
		private bool IsListeningCharAnimBreakPoint;

		// Token: 0x04022BA2 RID: 142242
		private UUITexture TexIcon;

		// Token: 0x04022BA3 RID: 142243
		private InputMultiKeyItem KeyItem;

		// Token: 0x04022BA4 RID: 142244
		private TimerHandle CloseTimer;

		// Token: 0x04022BA5 RID: 142245
		private CustomPromise Promise;

		// Token: 0x04022BA6 RID: 142246
		private BattleUiChildViewData ChildViewData;

		// Token: 0x04022BA7 RID: 142247
		private bool ChildVisible = true;

		// Token: 0x04022BA8 RID: 142248
		private bool TagVisible = true;

		// Token: 0x04022BA9 RID: 142249
		private bool SkillAnimVisible = true;

		// Token: 0x04022BAA RID: 142250
		private BehaviorCommonButton? ButtonConfig;

		// Token: 0x04022BAB RID: 142251
		private bool IsClicked;

		// Token: 0x04022BAC RID: 142252
		private string SkillIconPath;

		// Token: 0x04022BAD RID: 142253
		private int SetTextureHandleId;

		// Token: 0x04022BAE RID: 142254
		private bool IsLoadingSkillIcon;

		// Token: 0x04022BAF RID: 142255
		private bool IsInScreen;

		// Token: 0x04022BB0 RID: 142256
		private EntityHandle TempMonsterEntityHandle;

		// Token: 0x04022BB1 RID: 142257
		private FName? TempTargetSocket;

		// Token: 0x04022BB2 RID: 142258
		private TimerHandle InteractionShowTimer;

		// Token: 0x04022BB3 RID: 142259
		private bool CurVisible;

		// Token: 0x04022BB4 RID: 142260
		private bool TargetVisible;

		// Token: 0x04022BB5 RID: 142261
		private TimerHandle NextTick;

		// Token: 0x04022BB6 RID: 142262
		private TimerHandle Timer;

		// Token: 0x04022BB7 RID: 142263
		private bool DistanceValid;

		// Token: 0x04022BB8 RID: 142264
		private float InteractionShowDelay;

		// Token: 0x04022BB9 RID: 142265
		private float HorizontalDistance;

		// Token: 0x04022BBA RID: 142266
		private float UpDistance;

		// Token: 0x04022BBB RID: 142267
		private float DownDistance;

		// Token: 0x04022BBC RID: 142268
		private bool LogicVisible;

		// Token: 0x0200C093 RID: 49299
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B4B3 RID: 242867
			SkillButton,
			// Token: 0x0403B4B4 RID: 242868
			TexIcon
		}

		// Token: 0x0200C094 RID: 49300
		[NullableContext(0)]
		private enum EDesktopType
		{
			// Token: 0x0403B4B6 RID: 242870
			KeyItem
		}
	}
}
