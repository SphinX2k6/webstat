using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x02006991 RID: 27025
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopEntranceView : UiViewBase
	{
		// Token: 0x060430B8 RID: 274616 RVA: 0x01137853 File Offset: 0x01135A53
		public CoopEntranceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x060430B9 RID: 274617 RVA: 0x0113785C File Offset: 0x01135A5C
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
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIText)),
				new ValueTuple<int, Type>(14, typeof(UUIText))
			};
		}

		// Token: 0x060430BA RID: 274618 RVA: 0x011379C4 File Offset: 0x01135BC4
		protected override void OnBeforeCreate()
		{
			this.ActivityData = (this.OpenParam as CoopActivityData);
		}

		// Token: 0x060430BB RID: 274619 RVA: 0x011379D8 File Offset: 0x01135BD8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCoopLevelUpdate, new Action(this.RefreshRole));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCoopLevelUpdate, new Action(this.RefreshRewardButton));
			Singleton<EventSystem>.Instance.Add(EEventName.OnCoopSpUpdate, new Action(this.RefreshRewardButton));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060430BC RID: 274620 RVA: 0x01137A58 File Offset: 0x01135C58
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopLevelUpdate, new Action(this.RefreshRole));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopLevelUpdate, new Action(this.RefreshRewardButton));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCoopSpUpdate, new Action(this.RefreshRewardButton));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x060430BD RID: 274621 RVA: 0x01137AD8 File Offset: 0x01135CD8
		protected override UniTask OnBeforeStartAsync()
		{
			CoopEntranceView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CoopEntranceView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060430BE RID: 274622 RVA: 0x01137B1C File Offset: 0x01135D1C
		protected override void OnBeforeShow()
		{
			this.RefreshRole();
			this.RefreshRewardButton();
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			if (Singleton<GameSettingsDeviceRender>.Instance.IsVulkanRHI() != 0)
			{
				this.ValueBeforeShow = UKismetSystemLibrary.GetConsoleVariableIntValue("r.LGUI.CreateMeshSectionOptVis");
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.LGUI.CreateMeshSectionOptVis 0", null);
			}
		}

		// Token: 0x060430BF RID: 274623 RVA: 0x01137B78 File Offset: 0x01135D78
		protected override void OnBeforeHide()
		{
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.LGUI.CreateMeshSectionOptVis ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.ValueBeforeShow);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}

		// Token: 0x060430C0 RID: 274624 RVA: 0x01137BBC File Offset: 0x01135DBC
		private void OnClickedRole(CoopRoleData data)
		{
			int roleIndexByRoleId = this.ActivityData.GetRoleIndexByRoleId(data.RoleId);
			if (roleIndexByRoleId == -1)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopRoleSelectView, new CoopRoleSelectViewParams
			{
				ActivityData = this.ActivityData,
				Index = roleIndexByRoleId,
				Level = 0,
				LevelId = 0,
				IsOpenByUpGradeView = false
			}, null);
		}

		// Token: 0x060430C1 RID: 274625 RVA: 0x01137C20 File Offset: 0x01135E20
		private void RefreshRole()
		{
			List<CoopRoleData> coopRoleDataList = this.ActivityData.CoopRoleDataList;
			if (coopRoleDataList == null)
			{
				return;
			}
			for (int i = 0; i < this.RoleButtonList.Count; i++)
			{
				CoopEntryRoleItem coopEntryRoleItem = this.RoleButtonList[i];
				CoopRoleData coopRoleData = (i < coopRoleDataList.Count) ? coopRoleDataList[i] : null;
				if (coopRoleData != null)
				{
					coopEntryRoleItem.Refresh(coopRoleData, false, i);
				}
			}
		}

		// Token: 0x060430C2 RID: 274626 RVA: 0x01137C80 File Offset: 0x01135E80
		private void RefreshRewardButton()
		{
			int claimedRewardCount = this.ActivityData.GetClaimedRewardCount();
			CoopRewardButton rewardButton = this.RewardButton;
			if (rewardButton != null)
			{
				rewardButton.RefreshRewardCount(claimedRewardCount);
			}
			CoopRewardButton rewardButton2 = this.RewardButton;
			if (rewardButton2 == null)
			{
				return;
			}
			rewardButton2.SetRedDotShow(this.ActivityData.IsHasCoopSpRewardRedDot());
		}

		// Token: 0x060430C3 RID: 274627 RVA: 0x01137CC6 File Offset: 0x01135EC6
		private void OnClickRewardBtn()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CoopSpRewardView, this.ActivityData, null);
		}

		// Token: 0x060430C4 RID: 274628 RVA: 0x01137CE0 File Offset: 0x01135EE0
		private void OnRefreshCommonActivityRedDot(int id)
		{
			CoopActivityData activityData = this.ActivityData;
			int? num = (activityData != null) ? new int?(activityData.Id) : null;
			if (!(id == num.GetValueOrDefault() & num != null))
			{
				return;
			}
			this.RefreshRole();
		}

		// Token: 0x060430C5 RID: 274629 RVA: 0x01137D28 File Offset: 0x01135F28
		private void OnRolePointerEnter(CoopRoleData data)
		{
			CoopRole? coopRoleConfigByRoleId = ConfigBase<CoopConfig>.Instance.GetCoopRoleConfigByRoleId(data.RoleId);
			if (coopRoleConfigByRoleId == null)
			{
				return;
			}
			UUIText text = base.GetText(13);
			if (text != null && !string.IsNullOrEmpty(coopRoleConfigByRoleId.Value.RoleName))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, coopRoleConfigByRoleId.Value.RoleName, Array.Empty<object>());
			}
			int roleCurCoopLevelIdFinalZero = this.ActivityData.GetRoleCurCoopLevelIdFinalZero(data.RoleId);
			UUIText text2 = base.GetText(14);
			if (text2 != null)
			{
				text2.SetUIActive(roleCurCoopLevelIdFinalZero > 0);
			}
			if (text2 != null && roleCurCoopLevelIdFinalZero > 0)
			{
				CoopRoleLevel? coopConfigById = ConfigBase<CoopConfig>.Instance.GetCoopConfigById(roleCurCoopLevelIdFinalZero);
				if (coopConfigById != null)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, coopConfigById.Value.LevelUpText, Array.Empty<object>());
				}
			}
			UUIItem item = base.GetItem(12);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x060430C6 RID: 274630 RVA: 0x01137E0B File Offset: 0x0113600B
		private void OnRolePointerExit()
		{
			UUIItem item = base.GetItem(12);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x04025585 RID: 152965
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<CoopEntryRoleItem> RoleButtonList;

		// Token: 0x04025586 RID: 152966
		[Nullable(2)]
		private CoopActivityData ActivityData;

		// Token: 0x04025587 RID: 152967
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025588 RID: 152968
		[Nullable(2)]
		private CoopRewardButton RewardButton;

		// Token: 0x04025589 RID: 152969
		private int ValueBeforeShow;
	}
}
