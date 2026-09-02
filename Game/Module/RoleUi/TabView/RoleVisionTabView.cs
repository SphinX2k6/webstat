using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi.TabView.VisionSubView;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.TabView
{
	// Token: 0x02005065 RID: 20581
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleVisionTabView : UiTabViewBase
	{
		// Token: 0x0603503B RID: 217147 RVA: 0x00D4BEC0 File Offset: 0x00D4A0C0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(10, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(6, new Action(this.OnShowCalabash)),
				new ValueTuple<int, Delegate>(9, new Action(this.OnVisionGroupButton))
			};
		}

		// Token: 0x0603503C RID: 217148 RVA: 0x00D4C008 File Offset: 0x00D4A208
		protected override void AddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, new Action<int, int, bool>(this.OnEquipEquipment));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.PhantomPersonalSkillActive, new Action<int>(this.OnPhantomPersonalSkillActive));
			Singleton<EventSystem>.Instance.Add(EEventName.PhantomEquipError, new Action(this.OnEquipError));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetRoleFlag, new Action(this.ResetRoleFlag));
			Singleton<EventSystem>.Instance.Add(EEventName.HideVisionTabRole, new Action(this.HideVisionTabRole));
		}

		// Token: 0x0603503D RID: 217149 RVA: 0x00D4C0C0 File Offset: 0x00D4A2C0
		protected override void RemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoleSystemChangeRole, new Action<int>(this.OnChangeRole));
			Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.PhantomEquipWithSourceAndTargetPos, new Action<int, int, bool>(this.OnEquipEquipment));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.PhantomPersonalSkillActive, new Action<int>(this.OnPhantomPersonalSkillActive));
			Singleton<EventSystem>.Instance.Remove(EEventName.PhantomEquipError, new Action(this.OnEquipError));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetRoleFlag, new Action(this.ResetRoleFlag));
			Singleton<EventSystem>.Instance.Remove(EEventName.HideVisionTabRole, new Action(this.HideVisionTabRole));
		}

		// Token: 0x0603503E RID: 217150 RVA: 0x00D4C175 File Offset: 0x00D4A375
		private void HideVisionTabRole()
		{
			this.HideRole(true);
		}

		// Token: 0x0603503F RID: 217151 RVA: 0x00D4C17E File Offset: 0x00D4A37E
		private void ResetRoleFlag()
		{
			this.HasUpdateRole = false;
		}

		// Token: 0x06035040 RID: 217152 RVA: 0x00D4C187 File Offset: 0x00D4A387
		private void OnShowCalabash()
		{
			this.OpenCalabashView().Forget();
		}

		// Token: 0x06035041 RID: 217153 RVA: 0x00D4C194 File Offset: 0x00D4A394
		private void OnVisionGroupButton()
		{
			this.OnClickVisionGroupButton();
		}

		// Token: 0x06035042 RID: 217154 RVA: 0x00D4C19C File Offset: 0x00D4A39C
		private UniTask OpenCalabashView()
		{
			RoleVisionTabView.<OpenCalabashView>d__24 <OpenCalabashView>d__;
			<OpenCalabashView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenCalabashView>d__.<>4__this = this;
			<OpenCalabashView>d__.<>1__state = -1;
			<OpenCalabashView>d__.<>t__builder.Start<RoleVisionTabView.<OpenCalabashView>d__24>(ref <OpenCalabashView>d__);
			return <OpenCalabashView>d__.<>t__builder.Task;
		}

		// Token: 0x06035043 RID: 217155 RVA: 0x00D4C1E0 File Offset: 0x00D4A3E0
		protected override UniTask OnBeforeStartAsync()
		{
			RoleVisionTabView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleVisionTabView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035044 RID: 217156 RVA: 0x00D4C224 File Offset: 0x00D4A424
		private void OnClickVisionGroupButton()
		{
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			this.HideRole(true);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionAssembleView, curSelectRoleId, null);
		}

		// Token: 0x06035045 RID: 217157 RVA: 0x00D4C25C File Offset: 0x00D4A45C
		protected override void OnStart()
		{
			base.GetItem(7).SetUIActive(true);
			base.GetItem(7).SetRaycastTarget(false);
			this.RoleVisionInfoPanel.SetActive(true);
			this.RoleVisionInfoPanel.SetConfirmButtonCall(delegate
			{
				this.OnClickVision(this.CurrentSelectIndex);
			});
			base.GetButton(6).RootUIComp.Get().SetUIActive(true);
			this.AnimationTime = ConfigBase<PhantomBattleConfig>.Instance.GetVisionDragCurveTime();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnVisionRefineSubNeedAck);
		}

		// Token: 0x06035046 RID: 217158 RVA: 0x00D4C2E0 File Offset: 0x00D4A4E0
		private UniTask InitVisionHeadItem()
		{
			RoleVisionTabView.<InitVisionHeadItem>d__28 <InitVisionHeadItem>d__;
			<InitVisionHeadItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitVisionHeadItem>d__.<>4__this = this;
			<InitVisionHeadItem>d__.<>1__state = -1;
			<InitVisionHeadItem>d__.<>t__builder.Start<RoleVisionTabView.<InitVisionHeadItem>d__28>(ref <InitVisionHeadItem>d__);
			return <InitVisionHeadItem>d__.<>t__builder.Task;
		}

		// Token: 0x06035047 RID: 217159 RVA: 0x00D4C323 File Offset: 0x00D4A523
		protected void PlayMontageStart(bool reLoop = false)
		{
			ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Chip, reLoop, false, false);
		}

		// Token: 0x06035048 RID: 217160 RVA: 0x00D4C334 File Offset: 0x00D4A534
		protected override void OnBeforeShow()
		{
			ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
			this.ShowRoleModel();
			if (this.HasUpdateRole)
			{
				this.PlayMontageStart(true);
				this.HasUpdateRole = false;
			}
			else if (this.IfHiddenRole)
			{
				this.PlayMontageStart(true);
				this.IfHiddenRole = false;
			}
			else
			{
				this.PlayMontageStart(false);
			}
			this.CurrentSelectIndex = 0;
			this.RefreshView();
			this.ResetClickState();
			this.RefreshPhantomClickState();
			this.CurrentDragIndex = 999;
			this.ResetVisionPosition(true).Forget();
			int curSelectRoleId = this.RoleViewAgent.GetCurSelectRoleId();
			this.RefreshGroupRedDot();
			this.RefreshGroupButtonShowState();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshVisionEquipRedPoint, curSelectRoleId);
		}

		// Token: 0x06035049 RID: 217161 RVA: 0x00D4C3E4 File Offset: 0x00D4A5E4
		private void RefreshGroupRedDot()
		{
			bool visionGroupFirstOpenState = ModelBase<VisionEquipGroupModel>.Instance.GetVisionGroupFirstOpenState();
			base.GetItem(10).SetUIActive(visionGroupFirstOpenState);
		}

		// Token: 0x0603504A RID: 217162 RVA: 0x00D4C40A File Offset: 0x00D4A60A
		protected void OnChangeRole(int roleId)
		{
			this.RefreshView();
			this.HasUpdateRole = true;
			this.PlayMontageStart(true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshVisionEquipRedPoint, roleId);
		}

		// Token: 0x0603504B RID: 217163 RVA: 0x00D4C434 File Offset: 0x00D4A634
		private void RefreshView()
		{
			this.RefreshPhantom();
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			bool flag = curSelectRoleData.IsTrialRole();
			ControllerBase<PhantomBattleController>.Instance.ChangeRoleEvent(curSelectRoleData.GetDataId());
			this.RoleVisionInfoPanel.RefreshView(this.RoleViewAgent);
			base.GetButton(6).RootUIComp.Get().SetUIActive(!flag);
			this.RefreshCost();
		}

		// Token: 0x0603504C RID: 217164 RVA: 0x00D4C4A0 File Offset: 0x00D4A6A0
		private void RefreshCost()
		{
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			int roleCurrentPhantomCost;
			int num;
			if (curSelectRoleData != null && curSelectRoleData.IsTrialRole())
			{
				roleCurrentPhantomCost = ModelBase<PhantomBattleModel>.Instance.GetRoleCurrentPhantomCost(curSelectRoleData.GetDataId());
				num = ConfigBase<PhantomBattleConfig>.Instance.GetVisionReachableCostMax();
			}
			else
			{
				roleCurrentPhantomCost = ModelBase<PhantomBattleModel>.Instance.GetRoleCurrentPhantomCost(curSelectRoleData.GetRoleId());
				num = this.GetCostMax();
			}
			base.GetText(8).SetText(StringUtils.Format("{0}/{1}", new string[]
			{
				roleCurrentPhantomCost.ToString(),
				num.ToString()
			}), true);
			int roleId = curSelectRoleData.GetRoleId();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshVisionEquipRedPoint, roleId);
		}

		// Token: 0x0603504D RID: 217165 RVA: 0x00D4C547 File Offset: 0x00D4A747
		private int GetCostMax()
		{
			return ModelBase<PhantomBattleModel>.Instance.GetMaxCost();
		}

		// Token: 0x0603504E RID: 217166 RVA: 0x00D4C553 File Offset: 0x00D4A753
		private void OnPhantomPersonalSkillActive(int uniqueId)
		{
			this.RefreshPhantom();
		}

		// Token: 0x0603504F RID: 217167 RVA: 0x00D4C55C File Offset: 0x00D4A75C
		protected void RefreshPhantom()
		{
			RoleViewAgent roleViewAgent = this.RoleViewAgent;
			RoleDataBase roleDataBase = (roleViewAgent != null) ? roleViewAgent.GetCurSelectRoleData() : null;
			List<PhantomDataBase> currentViewShowPhantomList = ModelBase<PhantomBattleModel>.Instance.GetCurrentViewShowPhantomList(roleDataBase);
			int count = this.RoleVisionItem.Count;
			for (int i = 0; i < count; i++)
			{
				PhantomDataBase data = (currentViewShowPhantomList.Count > i) ? currentViewShowPhantomList[i] : null;
				this.RoleVisionItem[i].UpdateItem(data, roleDataBase);
				this.VisionDragItem[i].Refresh(data, roleDataBase.IsTrialRole());
			}
			this.RefreshCost();
		}

		// Token: 0x06035050 RID: 217168 RVA: 0x00D4C5E8 File Offset: 0x00D4A7E8
		protected void OnEquipError()
		{
			this.ResetVisionPosition(true).Forget();
		}

		// Token: 0x06035051 RID: 217169 RVA: 0x00D4C5F6 File Offset: 0x00D4A7F6
		protected override void OnBeforeHide()
		{
			this.CancelPendingDragAndAnimation();
			Singleton<UiLayer>.Instance.SetShowMaskLayer("playBackToStartPositionAnimation", false);
			Singleton<UiLayer>.Instance.SetShowMaskLayer("OnEquipVision", false);
		}

		// Token: 0x06035052 RID: 217170 RVA: 0x00D4C620 File Offset: 0x00D4A820
		private void CancelPendingDragAndAnimation()
		{
			CustomPromise<bool> failAnimationPromise = this.FailAnimationPromise;
			if (failAnimationPromise != null)
			{
				failAnimationPromise.SetResult(true);
			}
			this.IsAnimationOn = false;
			this.IsFailAnimation = false;
			this.CeaseAnimationState = false;
			foreach (VisionCommonDragItem visionCommonDragItem in this.VisionDragItem)
			{
				visionCommonDragItem.CancelDrag();
			}
			ModelBase<PhantomBattleModel>.Instance.ClearCurrentDragIndex();
			this.CurrentDragIndex = 999;
			this.ResetVisionPosition(false).Forget();
		}

		// Token: 0x06035053 RID: 217171 RVA: 0x00D4C6B8 File Offset: 0x00D4A8B8
		protected void OnClickFailVision(int index)
		{
			if (!this.IfCanClick())
			{
				return;
			}
			this.ResetVisionPosition(true).Forget();
		}

		// Token: 0x06035054 RID: 217172 RVA: 0x00D4C6D0 File Offset: 0x00D4A8D0
		protected void OnClickVision(int index)
		{
			if (!this.IfCanClick())
			{
				return;
			}
			this.ResetVisionPosition(true).Forget();
			RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
			if (curSelectRoleData.IsTrialRole())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RolePhantomTrialTips", Array.Empty<object>());
				return;
			}
			this.CurrentSelectIndex = index;
			ModelBase<PhantomBattleModel>.Instance.CurrentEquipmentSelectIndex = index;
			int? num = new int?(ControllerBase<PhantomBattleController>.Instance.GetEquipByIndex(curSelectRoleData.GetRoleId(), index));
			ModelBase<PhantomBattleModel>.Instance.CurrentSelectUniqueId = num.Value;
			this.HideRole(true);
			this.RefreshPhantomClickState();
			this.ResetVisionPosition(true).Forget();
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_click");
			PhantomUtil.OpenVisionEquipmentView(curSelectRoleData.GetRoleId(), -1, new ERoleViewSource?(this.RoleViewAgent.Source));
			this.UiViewSequence.PlaySequencePurely("HideView", false, false);
		}

		// Token: 0x06035055 RID: 217173 RVA: 0x00D4C7B0 File Offset: 0x00D4A9B0
		private void RefreshGroupButtonShowState()
		{
			bool flag = this.RoleViewAgent.GetCurSelectRoleData().IsTrialRole();
			bool flag2 = ModelBase<FunctionModel>.Instance.IsOpen(10075);
			base.GetButton(9).RootUIComp.Get().SetUIActive(flag2 && !flag);
		}

		// Token: 0x06035056 RID: 217174 RVA: 0x00D4C804 File Offset: 0x00D4AA04
		private void ResetClickState()
		{
			int count = this.RoleVisionItem.Count;
			for (int i = 0; i < count; i++)
			{
				this.RoleVisionItem[i].SetToggleState(EToggleState.ETT_UnDetermined, false, false);
			}
		}

		// Token: 0x06035057 RID: 217175 RVA: 0x00D4C840 File Offset: 0x00D4AA40
		private void RefreshPhantomClickState()
		{
			int count = this.RoleVisionItem.Count;
			for (int i = 0; i < count; i++)
			{
				this.RoleVisionItem[i].SetToggleState(EToggleState.ETT_UnChecked, false, false);
			}
		}

		// Token: 0x06035058 RID: 217176 RVA: 0x00D4C87C File Offset: 0x00D4AA7C
		protected void OnPointerDownCallBack(int index)
		{
			if (!this.IfCanClick())
			{
				return;
			}
			base.GetItem(7).SetRaycastTarget(true);
			int count = this.VisionDragItem.Count;
			for (int i = 0; i < count; i++)
			{
				this.VisionDragItem[i].StartClickCheckTimer();
			}
			this.CurrentDragIndex = 999;
		}

		// Token: 0x06035059 RID: 217177 RVA: 0x00D4C8D3 File Offset: 0x00D4AAD3
		protected void OnPointerUpCallBack(int index)
		{
			base.GetItem(7).SetRaycastTarget(false);
		}

		// Token: 0x0603505A RID: 217178 RVA: 0x00D4C8E4 File Offset: 0x00D4AAE4
		protected void OnBeginDrag(int index)
		{
			this.CurrentDragIndex = index;
			if (this.RoleViewAgent.GetCurSelectRoleData().IsTrialRole())
			{
				return;
			}
			foreach (VisionCommonDragItem visionCommonDragItem in this.VisionDragItem)
			{
				visionCommonDragItem.StartDragState();
			}
			int count = this.VisionDragItem.Count;
			for (int i = 0; i < count; i++)
			{
				if (ModelBase<PhantomBattleModel>.Instance.CheckIfCurrentDragIndex(this.VisionDragItem[i].GetCurrentIndex()))
				{
					this.VisionDragItem[i].SetDragItemHierarchyMax();
				}
			}
			this.VisionDragItem[index].SetItemToPointerPosition();
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drag");
		}

		// Token: 0x0603505B RID: 217179 RVA: 0x00D4C9B8 File Offset: 0x00D4ABB8
		protected void OnDragEndCallBack(VisionCommonDragItem self, List<VisionCommonDragItem> targets, bool _)
		{
			if (targets.Count >= 1)
			{
				int currentIndex = self.GetCurrentIndex();
				int overlapIndex = VisionCommonDragItem.GetOverlapIndex(self, targets);
				RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
				List<int> incrIdList = ModelBase<PhantomBattleModel>.Instance.GetBattleDataById(curSelectRoleData.GetRoleId()).GetIncrIdList();
				this.SetIndexVisionMoveState(currentIndex, true);
				this.SetIndexVisionMoveState(overlapIndex, true);
				this.SetIndexVisionAnimateState(currentIndex, true);
				this.SetIndexVisionAnimateState(overlapIndex, true);
				ControllerBase<PhantomBattleController>.Instance.SendPhantomPutOnRequest(incrIdList[currentIndex], curSelectRoleData.GetRoleId(), overlapIndex, currentIndex, true);
				return;
			}
			this.ResetVisionPosition(true).Forget();
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_item_drop");
		}

		// Token: 0x0603505C RID: 217180 RVA: 0x00D4CA58 File Offset: 0x00D4AC58
		private void OnEquipEquipment(int selfIndex, int targetIndex, bool fromDrag)
		{
			if (!fromDrag)
			{
				this.RefreshPhantom();
				return;
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer("OnEquipVision", true);
			this.IsAnimationOn = false;
			this.CurrentRunningTime = 0f;
			Vector2D animationTargetPos = this.VisionDragItem[targetIndex].GetAnimationTargetPos();
			this.VisionDragItem[selfIndex].SetDragComponentToTargetPositionParam(animationTargetPos);
			Vector2D animationTargetPos2 = this.VisionDragItem[selfIndex].GetAnimationTargetPos();
			this.VisionDragItem[targetIndex].SetDragComponentToTargetPositionParam(animationTargetPos2);
			this.CurrentAnimationSourceIndex = selfIndex;
			this.CurrentAnimationTargetIndex = targetIndex;
			this.SetIndexVisionMoveState(this.CurrentAnimationSourceIndex, true);
			this.SetIndexVisionMoveState(this.CurrentAnimationTargetIndex, true);
			this.SetIndexVisionAnimateState(this.CurrentAnimationSourceIndex, true);
			this.SetIndexVisionAnimateState(this.CurrentAnimationTargetIndex, true);
			this.IsAnimationOn = true;
			Singleton<AudioSystem>.Instance.PostEvent("ui_vision_equip_on");
		}

		// Token: 0x0603505D RID: 217181 RVA: 0x00D4CB32 File Offset: 0x00D4AD32
		private void SetIndexVisionMoveState(int index, bool state)
		{
			if (index >= 0)
			{
				this.VisionDragItem[index].SetMovingState(state);
			}
		}

		// Token: 0x0603505E RID: 217182 RVA: 0x00D4CB4A File Offset: 0x00D4AD4A
		private void SetIndexVisionAnimateState(int index, bool state)
		{
			if (index >= 0)
			{
				this.RoleVisionItem[index].SetAnimationState(state);
			}
		}

		// Token: 0x0603505F RID: 217183 RVA: 0x00D4CB62 File Offset: 0x00D4AD62
		protected override void OnTickUiTabViewBase(float deltaTime)
		{
			this.CheckPlayMoveFailAnimation(deltaTime);
			this.CheckPlayMoveSuccessAnimation(deltaTime);
		}

		// Token: 0x06035060 RID: 217184 RVA: 0x00D4CB74 File Offset: 0x00D4AD74
		private void CheckPlayMoveSuccessAnimation(float deltaTime)
		{
			if (!this.IsAnimationOn)
			{
				return;
			}
			this.CurrentRunningTime += deltaTime;
			float num = this.CurrentRunningTime / (float)this.AnimationTime;
			if (num >= 1f)
			{
				num = 1f;
			}
			this.VisionDragItem[this.CurrentAnimationSourceIndex].TickDoCeaseAnimation(num);
			this.VisionDragItem[this.CurrentAnimationTargetIndex].TickDoCeaseAnimation(num);
			if (num >= 1f)
			{
				this.DoCeaseAnimationAndResetView().Forget();
				this.IsAnimationOn = false;
			}
		}

		// Token: 0x06035061 RID: 217185 RVA: 0x00D4CC00 File Offset: 0x00D4AE00
		private void CheckPlayMoveFailAnimation(float deltaTime)
		{
			if (!this.IsFailAnimation)
			{
				return;
			}
			this.CurrentRunningTime += deltaTime;
			float num = this.CurrentRunningTime / (float)this.AnimationTime;
			if (num >= 1f)
			{
				num = 1f;
			}
			this.VisionDragItem[this.CurrentDragIndex].TickDoCeaseAnimation(num);
			if (num >= 1f)
			{
				this.DoFailCeaseAnimation(this.CurrentDragIndex).Forget();
				this.IsFailAnimation = false;
			}
		}

		// Token: 0x06035062 RID: 217186 RVA: 0x00D4CC79 File Offset: 0x00D4AE79
		private bool IfCanClick()
		{
			return !this.IsAnimationOn && !this.IsFailAnimation && !this.CeaseAnimationState;
		}

		// Token: 0x06035063 RID: 217187 RVA: 0x00D4CC98 File Offset: 0x00D4AE98
		private UniTask DoCeaseAnimationAndResetView()
		{
			RoleVisionTabView.<DoCeaseAnimationAndResetView>d__58 <DoCeaseAnimationAndResetView>d__;
			<DoCeaseAnimationAndResetView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoCeaseAnimationAndResetView>d__.<>4__this = this;
			<DoCeaseAnimationAndResetView>d__.<>1__state = -1;
			<DoCeaseAnimationAndResetView>d__.<>t__builder.Start<RoleVisionTabView.<DoCeaseAnimationAndResetView>d__58>(ref <DoCeaseAnimationAndResetView>d__);
			return <DoCeaseAnimationAndResetView>d__.<>t__builder.Task;
		}

		// Token: 0x06035064 RID: 217188 RVA: 0x00D4CCDC File Offset: 0x00D4AEDC
		private UniTask DoFailCeaseAnimation(int index)
		{
			RoleVisionTabView.<DoFailCeaseAnimation>d__59 <DoFailCeaseAnimation>d__;
			<DoFailCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<DoFailCeaseAnimation>d__.<>4__this = this;
			<DoFailCeaseAnimation>d__.index = index;
			<DoFailCeaseAnimation>d__.<>1__state = -1;
			<DoFailCeaseAnimation>d__.<>t__builder.Start<RoleVisionTabView.<DoFailCeaseAnimation>d__59>(ref <DoFailCeaseAnimation>d__);
			return <DoFailCeaseAnimation>d__.<>t__builder.Task;
		}

		// Token: 0x06035065 RID: 217189 RVA: 0x00D4CD28 File Offset: 0x00D4AF28
		private UniTask PlayCeaseAnimation(int index)
		{
			RoleVisionTabView.<PlayCeaseAnimation>d__60 <PlayCeaseAnimation>d__;
			<PlayCeaseAnimation>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCeaseAnimation>d__.<>4__this = this;
			<PlayCeaseAnimation>d__.index = index;
			<PlayCeaseAnimation>d__.<>1__state = -1;
			<PlayCeaseAnimation>d__.<>t__builder.Start<RoleVisionTabView.<PlayCeaseAnimation>d__60>(ref <PlayCeaseAnimation>d__);
			return <PlayCeaseAnimation>d__.<>t__builder.Task;
		}

		// Token: 0x06035066 RID: 217190 RVA: 0x00D4CD74 File Offset: 0x00D4AF74
		private UniTask ResetVisionPosition(bool playBackToStartPositionAnimation = true)
		{
			RoleVisionTabView.<ResetVisionPosition>d__61 <ResetVisionPosition>d__;
			<ResetVisionPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetVisionPosition>d__.<>4__this = this;
			<ResetVisionPosition>d__.playBackToStartPositionAnimation = playBackToStartPositionAnimation;
			<ResetVisionPosition>d__.<>1__state = -1;
			<ResetVisionPosition>d__.<>t__builder.Start<RoleVisionTabView.<ResetVisionPosition>d__61>(ref <ResetVisionPosition>d__);
			return <ResetVisionPosition>d__.<>t__builder.Task;
		}

		// Token: 0x06035067 RID: 217191 RVA: 0x00D4CDBF File Offset: 0x00D4AFBF
		private void HideRole(bool isHide)
		{
			if (isHide)
			{
				Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
				this.IfHiddenRole = true;
			}
		}

		// Token: 0x06035068 RID: 217192 RVA: 0x00D4CDD8 File Offset: 0x00D4AFD8
		private void ShowRoleModel()
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			if (roleSystemRoleActor == null)
			{
				return;
			}
			UiModelBase model = roleSystemRoleActor.Model;
			Singleton<UiModelUtil>.Instance.StopFade(model);
			Singleton<UiModelUtil>.Instance.SetDitherEffect(model, 1f);
			Singleton<UiModelUtil>.Instance.SetVisible(model, true);
		}

		// Token: 0x06035069 RID: 217193 RVA: 0x00D4CE24 File Offset: 0x00D4B024
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private UUIItem[] GetRoleVisionGuideItem(int index)
		{
			if (!this.IfCanClick())
			{
				return null;
			}
			if (index >= 0)
			{
				RoleVisionCommonItem roleVisionCommonItem = this.RoleVisionItem[index];
				UUIItem uuiitem;
				if (roleVisionCommonItem == null)
				{
					uuiitem = null;
				}
				else
				{
					UUIDraggableComponent dragComponent = roleVisionCommonItem.GetDragComponent();
					uuiitem = ((dragComponent != null) ? dragComponent.RootUIComp.Get() : null);
				}
				UUIItem uuiitem2 = uuiitem;
				if (uuiitem2 != null)
				{
					return new UUIItem[]
					{
						uuiitem2,
						uuiitem2
					};
				}
			}
			return null;
		}

		// Token: 0x0603506A RID: 217194 RVA: 0x00D4CE80 File Offset: 0x00D4B080
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 1)
			{
				if (configParams[0] == "Equipped")
				{
					RoleDataBase curSelectRoleData = this.RoleViewAgent.GetCurSelectRoleData();
					List<PhantomDataBase> currentViewShowPhantomList = ModelBase<PhantomBattleModel>.Instance.GetCurrentViewShowPhantomList(curSelectRoleData);
					int index = -1;
					for (int i = 0; i < currentViewShowPhantomList.Count; i++)
					{
						if (currentViewShowPhantomList[i] != null)
						{
							index = i;
							break;
						}
					}
					return this.GetRoleVisionGuideItem(index);
				}
				if (configParams[0] == "First")
				{
					return this.GetRoleVisionGuideItem(0);
				}
				RoleVisionInfoPanel roleVisionInfoPanel = this.RoleVisionInfoPanel;
				UUIItem uuiitem = (roleVisionInfoPanel != null) ? roleVisionInfoPanel.GetTxtItemByIndex(int.Parse(configParams[0])) : null;
				if (uuiitem != null)
				{
					return new UUIItem[]
					{
						uuiitem,
						uuiitem
					};
				}
			}
			return null;
		}

		// Token: 0x0603506B RID: 217195 RVA: 0x00D4CF30 File Offset: 0x00D4B130
		protected override void OnBeforeDestroy()
		{
			this.IsAnimationOn = false;
		}

		// Token: 0x0401E886 RID: 125062
		private const int INVALIDINDEX = 999;

		// Token: 0x0401E887 RID: 125063
		[Nullable(2)]
		private CustomPromise<bool> FailAnimationPromise;

		// Token: 0x0401E888 RID: 125064
		private bool IsAnimationOn;

		// Token: 0x0401E889 RID: 125065
		private bool IsFailAnimation;

		// Token: 0x0401E88A RID: 125066
		private bool CeaseAnimationState;

		// Token: 0x0401E88B RID: 125067
		private int CurrentAnimationSourceIndex = -1;

		// Token: 0x0401E88C RID: 125068
		private int CurrentAnimationTargetIndex = -1;

		// Token: 0x0401E88D RID: 125069
		private int AnimationTime;

		// Token: 0x0401E88E RID: 125070
		private float CurrentRunningTime;

		// Token: 0x0401E88F RID: 125071
		private int CurrentDragIndex = 999;

		// Token: 0x0401E890 RID: 125072
		[Nullable(2)]
		private RoleVisionInfoPanel RoleVisionInfoPanel;

		// Token: 0x0401E891 RID: 125073
		[Nullable(2)]
		private RoleViewAgent RoleViewAgent;

		// Token: 0x0401E892 RID: 125074
		private readonly List<RoleVisionCommonItem> RoleVisionItem = new List<RoleVisionCommonItem>();

		// Token: 0x0401E893 RID: 125075
		private readonly List<VisionCommonDragItem> VisionDragItem = new List<VisionCommonDragItem>();

		// Token: 0x0401E894 RID: 125076
		private int CurrentSelectIndex;

		// Token: 0x0401E895 RID: 125077
		private bool IfHiddenRole;

		// Token: 0x0401E896 RID: 125078
		private bool HasUpdateRole;

		// Token: 0x0200B015 RID: 45077
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x040369F2 RID: 223730
			MainVisionItem,
			// Token: 0x040369F3 RID: 223731
			SubVisionItem1,
			// Token: 0x040369F4 RID: 223732
			SubVisionItem2,
			// Token: 0x040369F5 RID: 223733
			SubVisionItem3,
			// Token: 0x040369F6 RID: 223734
			SubVisionItem4,
			// Token: 0x040369F7 RID: 223735
			VisionInfoPanel,
			// Token: 0x040369F8 RID: 223736
			CalabashBtn,
			// Token: 0x040369F9 RID: 223737
			DragPanel,
			// Token: 0x040369FA RID: 223738
			CurrentCostText,
			// Token: 0x040369FB RID: 223739
			VisionGroupButton,
			// Token: 0x040369FC RID: 223740
			VisionGroupRedDot
		}
	}
}
