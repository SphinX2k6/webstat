using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006115 RID: 24853
	[NullableContext(2)]
	[Nullable(0)]
	public class SwordControlFlightView : UiViewBase
	{
		// Token: 0x0603EC6D RID: 257133 RVA: 0x0101351A File Offset: 0x0101171A
		[NullableContext(1)]
		public SwordControlFlightView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603EC6E RID: 257134 RVA: 0x01013524 File Offset: 0x01011724
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC6F RID: 257135 RVA: 0x010135B0 File Offset: 0x010117B0
		protected override UniTask OnBeforeStartAsync()
		{
			SwordControlFlightView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SwordControlFlightView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EC70 RID: 257136 RVA: 0x010135F4 File Offset: 0x010117F4
		protected override void OnStart()
		{
			this.BtnLeftButton.OnPressCallback = new Action(this.UpdateMoveRightAxis);
			this.BtnLeftButton.OnReleaseCallback = new Action(this.UpdateMoveRightAxis);
			this.BtnRightButton.OnPressCallback = new Action(this.UpdateMoveRightAxis);
			this.BtnRightButton.OnReleaseCallback = new Action(this.UpdateMoveRightAxis);
			SwordControlGroundAttackButton flightAttackButton = this.FlightAttackButton;
			if (flightAttackButton != null)
			{
				flightAttackButton.SetInteractive(true, false);
			}
			this.RefreshRoleData();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
		}

		// Token: 0x0603EC71 RID: 257137 RVA: 0x01013694 File Offset: 0x01011894
		protected override void OnBeforeDestroy()
		{
			SwordControlFlightDirectionButton btnLeftButton = this.BtnLeftButton;
			if (btnLeftButton != null)
			{
				btnLeftButton.Destroy(null);
			}
			this.BtnLeftButton = null;
			SwordControlFlightDirectionButton btnRightButton = this.BtnRightButton;
			if (btnRightButton != null)
			{
				btnRightButton.Destroy(null);
			}
			this.BtnRightButton = null;
			SwordControlGroundAttackButton flightAttackButton = this.FlightAttackButton;
			if (flightAttackButton != null)
			{
				flightAttackButton.Destroy(null);
			}
			this.FlightAttackButton = null;
			this.RemoveListenHideAttackBtnTagChanged();
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiCurRoleDataChanged, new Action<int, int>(this.OnBattleUiCurRoleDataChanged));
			this.RoleData = null;
		}

		// Token: 0x0603EC72 RID: 257138 RVA: 0x01013715 File Offset: 0x01011915
		protected override void OnBeforeShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, SwordControlFlightView.HideBattleUiChildernList, false, true, 0);
		}

		// Token: 0x0603EC73 RID: 257139 RVA: 0x0101372F File Offset: 0x0101192F
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.Custom, SwordControlFlightView.HideBattleUiChildernList, true, true, 0);
		}

		// Token: 0x0603EC74 RID: 257140 RVA: 0x01013749 File Offset: 0x01011949
		private void OnBattleUiCurRoleDataChanged(int newEntityId, int oldEntityId)
		{
			this.RefreshRoleData();
		}

		// Token: 0x0603EC75 RID: 257141 RVA: 0x01013754 File Offset: 0x01011954
		private void RefreshRoleData()
		{
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (this.RoleData == curRoleData)
			{
				this.RefreshAttackBtnVisible();
				return;
			}
			this.RemoveListenHideAttackBtnTagChanged();
			this.RoleData = curRoleData;
			this.ListenForHideAttackBtnTagChanged();
			this.RefreshAttackBtnVisible();
		}

		// Token: 0x0603EC76 RID: 257142 RVA: 0x01013798 File Offset: 0x01011998
		private void ListenForHideAttackBtnTagChanged()
		{
			BattleUiRoleData roleData = this.RoleData;
			BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
			if (baseTagComponent == null)
			{
				return;
			}
			this.HideSkillNorTagTask = baseTagComponent.ListenForTagAddOrRemove(new int?(SwordControlFlightView.HideAttackBtnTagId), new BaseTagComponent.TTagSwitchedCallback(this.OnHideAttackBtnTagChanged), null);
		}

		// Token: 0x0603EC77 RID: 257143 RVA: 0x010137DF File Offset: 0x010119DF
		private void RemoveListenHideAttackBtnTagChanged()
		{
			ITagTask hideSkillNorTagTask = this.HideSkillNorTagTask;
			if (hideSkillNorTagTask != null)
			{
				hideSkillNorTagTask.EndTask();
			}
			this.HideSkillNorTagTask = null;
		}

		// Token: 0x0603EC78 RID: 257144 RVA: 0x010137F9 File Offset: 0x010119F9
		private void OnHideAttackBtnTagChanged(int tagId, bool tagExists)
		{
			this.SetAttackBtnVisible(!tagExists);
		}

		// Token: 0x0603EC79 RID: 257145 RVA: 0x01013808 File Offset: 0x01011A08
		private void RefreshAttackBtnVisible()
		{
			BattleUiRoleData roleData = this.RoleData;
			bool? flag;
			if (roleData == null)
			{
				flag = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				flag = ((gameplayTagComponent != null) ? new bool?(gameplayTagComponent.HasTag(SwordControlFlightView.HideAttackBtnTagId)) : null);
			}
			bool? flag2 = flag;
			bool valueOrDefault = flag2.GetValueOrDefault();
			this.SetAttackBtnVisible(!valueOrDefault);
		}

		// Token: 0x0603EC7A RID: 257146 RVA: 0x01013860 File Offset: 0x01011A60
		private void SetAttackBtnVisible(bool visible)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x0603EC7B RID: 257147 RVA: 0x01013874 File Offset: 0x01011A74
		private void UpdateMoveRightAxis()
		{
			SwordControlFlightDirectionButton btnLeftButton = this.BtnLeftButton;
			bool flag = btnLeftButton != null && btnLeftButton.IsPressed;
			SwordControlFlightDirectionButton btnRightButton = this.BtnRightButton;
			bool flag2 = btnRightButton != null && btnRightButton.IsPressed;
			float value = 0f;
			if (flag && !flag2)
			{
				value = -1f;
			}
			else if (flag2 && !flag)
			{
				value = 1f;
			}
			ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, value, false);
		}

		// Token: 0x04023367 RID: 144231
		private static readonly int HideAttackBtnTagId = GameplayTagDefine.EGameplayTagId["功能.功能制作.隐藏按钮功能.隐藏普攻按键"];

		// Token: 0x04023368 RID: 144232
		[Nullable(1)]
		private static readonly IReadOnlyList<EBattleUiChild> HideBattleUiChildernList = new <>z__ReadOnlyArray<EBattleUiChild>(new EBattleUiChild[]
		{
			EBattleUiChild.SkillButton,
			EBattleUiChild.GamepadSkillButton,
			EBattleUiChild.Joystick
		});

		// Token: 0x04023369 RID: 144233
		private SwordControlFlightDirectionButton BtnLeftButton;

		// Token: 0x0402336A RID: 144234
		private SwordControlFlightDirectionButton BtnRightButton;

		// Token: 0x0402336B RID: 144235
		private SwordControlGroundAttackButton FlightAttackButton;

		// Token: 0x0402336C RID: 144236
		private BattleUiRoleData RoleData;

		// Token: 0x0402336D RID: 144237
		private ITagTask HideSkillNorTagTask;

		// Token: 0x0200C29D RID: 49821
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BFFC RID: 245756
			BtnLeft,
			// Token: 0x0403BFFD RID: 245757
			BtnRight,
			// Token: 0x0403BFFE RID: 245758
			BtnSkillNor
		}
	}
}
