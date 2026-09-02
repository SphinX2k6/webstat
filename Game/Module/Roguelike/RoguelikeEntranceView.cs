using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005150 RID: 20816
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeEntranceView : UiViewBase
	{
		// Token: 0x0603593C RID: 219452 RVA: 0x00D73E00 File Offset: 0x00D72000
		[NullableContext(1)]
		public RoguelikeEntranceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603593D RID: 219453 RVA: 0x00D73E0C File Offset: 0x00D7200C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603593E RID: 219454 RVA: 0x00D73F1C File Offset: 0x00D7211C
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeEntranceView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeEntranceView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603593F RID: 219455 RVA: 0x00D73F60 File Offset: 0x00D72160
		protected override void OnStart()
		{
			this.RoleSelectPanel.ShowNewUnlockRole(this.Vm.ShowNewUnlockRole);
			if (this.Vm.HasMultiAvailableEntriesGroup())
			{
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoguelikeEntranceCanSetMultiplier");
				return;
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RoguelikeEntranceLockSetMultiplier");
		}

		// Token: 0x06035940 RID: 219456 RVA: 0x00D73FBC File Offset: 0x00D721BC
		protected override void OnBeforeShow()
		{
			RoguelikeEntryData currentSelectEntryData = this.Vm.CurrentSelectEntryData;
			int? num = (currentSelectEntryData != null) ? new int?(currentSelectEntryData.GroupId) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					this.EntriesPanel.ScrollToGroup(num.Value);
					return;
				}
			}
		}

		// Token: 0x06035941 RID: 219457 RVA: 0x00D74022 File Offset: 0x00D72222
		protected override void OnAfterShow()
		{
			if (this.NewUnlockEntriesGroupId != null)
			{
				this.ShowNewUnlockEntriesGroupId(this.NewUnlockEntriesGroupId.Value).Forget();
				this.NewUnlockEntriesGroupId = null;
			}
		}

		// Token: 0x06035942 RID: 219458 RVA: 0x00D74053 File Offset: 0x00D72253
		protected override void OnBeforeDestroy()
		{
			this.UnlockLevelSequencePlayer = null;
			ModelBase<RoguelikeModel>.Instance.ClearEntranceViewModel();
		}

		// Token: 0x06035943 RID: 219459 RVA: 0x00D74066 File Offset: 0x00D72266
		private void OnBtnBack()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.RevertEntranceFlowStep();
			base.CloseMe(null);
		}

		// Token: 0x06035944 RID: 219460 RVA: 0x00D7407C File Offset: 0x00D7227C
		private UniTask InitEntriesPanel()
		{
			RoguelikeEntranceView.<InitEntriesPanel>d__16 <InitEntriesPanel>d__;
			<InitEntriesPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEntriesPanel>d__.<>4__this = this;
			<InitEntriesPanel>d__.<>1__state = -1;
			<InitEntriesPanel>d__.<>t__builder.Start<RoguelikeEntranceView.<InitEntriesPanel>d__16>(ref <InitEntriesPanel>d__);
			return <InitEntriesPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06035945 RID: 219461 RVA: 0x00D740C0 File Offset: 0x00D722C0
		private UniTask InitEntriesDescPanel()
		{
			RoguelikeEntranceView.<InitEntriesDescPanel>d__17 <InitEntriesDescPanel>d__;
			<InitEntriesDescPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEntriesDescPanel>d__.<>4__this = this;
			<InitEntriesDescPanel>d__.<>1__state = -1;
			<InitEntriesDescPanel>d__.<>t__builder.Start<RoguelikeEntranceView.<InitEntriesDescPanel>d__17>(ref <InitEntriesDescPanel>d__);
			return <InitEntriesDescPanel>d__.<>t__builder.Task;
		}

		// Token: 0x06035946 RID: 219462 RVA: 0x00D74104 File Offset: 0x00D72304
		private void OnMultiplierChange(bool isAdd)
		{
			int currentEntriesGroupIndex = this.Vm.CurrentEntriesGroupIndex;
			this.Vm.CurrentEntriesGroupIndex += (isAdd ? 1 : -1);
			if (currentEntriesGroupIndex != this.Vm.CurrentEntriesGroupIndex)
			{
				this.EntriesDescPanel.Refresh(this.Vm);
				this.EntriesPanel.Refresh(this.Vm);
				this.EntriesPanel.ScrollToGroup(this.Vm.EntriesDataGroupList[this.Vm.CurrentEntriesGroupIndex].Id);
			}
		}

		// Token: 0x06035947 RID: 219463 RVA: 0x00D74190 File Offset: 0x00D72390
		[NullableContext(1)]
		private void OnClickEntry(bool isSelect, RoguelikeEntryData data)
		{
			if (this.Vm.CurrentSelectEntryData == data)
			{
				return;
			}
			if (!isSelect)
			{
				return;
			}
			if (this.Vm.CurrentSelectEntryData != null)
			{
				Action<bool, bool> setEntryToggleState = this.Vm.CurrentSelectEntryData.SetEntryToggleState;
				if (setEntryToggleState != null)
				{
					setEntryToggleState(false, false);
				}
				this.Vm.CurrentSelectEntryData = null;
			}
			this.Vm.SetCurrentSelectEntryData(data);
			this.EntriesPanel.RefreshSelectEntry(this.Vm, data, true);
		}

		// Token: 0x06035948 RID: 219464 RVA: 0x00D74208 File Offset: 0x00D72408
		[NullableContext(0)]
		public UniTask ShowNewUnlockEntriesGroupId(ValueTuple<int, int> groupId)
		{
			RoguelikeEntranceView.<ShowNewUnlockEntriesGroupId>d__20 <ShowNewUnlockEntriesGroupId>d__;
			<ShowNewUnlockEntriesGroupId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowNewUnlockEntriesGroupId>d__.<>4__this = this;
			<ShowNewUnlockEntriesGroupId>d__.groupId = groupId;
			<ShowNewUnlockEntriesGroupId>d__.<>1__state = -1;
			<ShowNewUnlockEntriesGroupId>d__.<>t__builder.Start<RoguelikeEntranceView.<ShowNewUnlockEntriesGroupId>d__20>(ref <ShowNewUnlockEntriesGroupId>d__);
			return <ShowNewUnlockEntriesGroupId>d__.<>t__builder.Task;
		}

		// Token: 0x06035949 RID: 219465 RVA: 0x00D74254 File Offset: 0x00D72454
		private UniTask InitRoleSelectPanel()
		{
			RoguelikeEntranceView.<InitRoleSelectPanel>d__21 <InitRoleSelectPanel>d__;
			<InitRoleSelectPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleSelectPanel>d__.<>4__this = this;
			<InitRoleSelectPanel>d__.<>1__state = -1;
			<InitRoleSelectPanel>d__.<>t__builder.Start<RoguelikeEntranceView.<InitRoleSelectPanel>d__21>(ref <InitRoleSelectPanel>d__);
			return <InitRoleSelectPanel>d__.<>t__builder.Task;
		}

		// Token: 0x0603594A RID: 219466 RVA: 0x00D74298 File Offset: 0x00D72498
		private void OnClickRoleItemFunc(int index)
		{
			int selectRoleId = this.Vm.FormationIdList[index];
			Action<int> confirmFunction = delegate(int roleId)
			{
				int selectRoleId;
				if (selectRoleId == roleId)
				{
					this.Vm.FormationIdList[index] = 0;
				}
				else
				{
					selectRoleId = selectRoleId;
					for (int i = 0; i < this.Vm.FormationIdList.Count; i++)
					{
						if (this.Vm.FormationIdList[i] == roleId)
						{
							this.Vm.FormationIdList[i] = selectRoleId;
							break;
						}
					}
					this.Vm.FormationIdList[index] = roleId;
				}
				this.Vm.CacheRoleSelect();
				this.RoleSelectPanel.Refresh(this.Vm);
			};
			Func<int, string> getConfirmButtonTextCallBack = delegate(int roleConfigId)
			{
				if (roleConfigId == 0)
				{
					return null;
				}
				if (selectRoleId == 0)
				{
					return "JoinText";
				}
				if (selectRoleId == roleConfigId)
				{
					return "GoDownText";
				}
				return "ChangeText";
			};
			TeamRoleSelectViewData teamRoleSelectViewData = new TeamRoleSelectViewData(EFilterSortGroupId.EditFormation, selectRoleId, this.Vm.GetFormationRoleDataList(), confirmFunction, null, new int?(index + 1), null);
			teamRoleSelectViewData.FormationRoleList = this.Vm.FormationIdList.ToArray();
			teamRoleSelectViewData.IsNeedRevive = new Func<int, bool>(this.IsNeedRevive);
			teamRoleSelectViewData.GetConfirmButtonTextCallBack = getConfirmButtonTextCallBack;
			teamRoleSelectViewData.GetDetailButtonVisible = new Func<int, bool>(this.GetDetailButtonVisible);
			teamRoleSelectViewData.GetConfirmButtonEnableCallBack = new Func<int, bool>(this.CanJoinTeam);
			teamRoleSelectViewData.CanJoinTeam = new Func<int, bool>(this.CanJoinTeam);
			if (index != 0)
			{
				teamRoleSelectViewData.GetCustomSkillShowData = new Func<int, List<TeamRoleSkillData>>(this.Vm.GetSupportCustomSkillShowData);
			}
			teamRoleSelectViewData.OverrideGridProxyCreate = (() => new TeamRoleGridRoguelike());
			ControllerBase<RoleController>.Instance.OpenTeamRoleSelectView(teamRoleSelectViewData);
			if (this.Vm.ShowNewUnlockRole)
			{
				this.RoleSelectPanel.ShowNewUnlockRole(false);
				this.Vm.CacheNewUnlockRoleId();
			}
		}

		// Token: 0x0603594B RID: 219467 RVA: 0x00D743F8 File Offset: 0x00D725F8
		private bool IsNeedRevive(int roleConfigId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleConfigId, true);
			return !((roleDataById != null) ? new bool?(roleDataById.IsTrialRole()) : null).GetValueOrDefault() && ModelBase<EditFormationModel>.Instance.IsRoleDead(roleConfigId);
		}

		// Token: 0x0603594C RID: 219468 RVA: 0x00D74444 File Offset: 0x00D72644
		private bool GetDetailButtonVisible(int roleId)
		{
			return false;
		}

		// Token: 0x0603594D RID: 219469 RVA: 0x00D74448 File Offset: 0x00D72648
		private bool CanJoinTeam(int roleId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			bool? flag = (roleDataById != null) ? new bool?(roleDataById.IsTrialRole()) : null;
			foreach (int num in this.Vm.FormationIdList)
			{
				RoleDataBase roleDataById2 = ModelBase<RoleModel>.Instance.GetRoleDataById(num, true);
				if (roleDataById2 != null && roleDataById2.IsTrialRole() && roleDataById2.GetRoleId() == roleId)
				{
					return false;
				}
				if (roleDataById != null && flag.GetValueOrDefault() && roleDataById.GetRoleId() == num)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603594E RID: 219470 RVA: 0x00D7450C File Offset: 0x00D7270C
		private void OnEnterInst()
		{
			Action action = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.ContinueEntranceFlow();
			};
			if (this.Vm.FormationIdList[0] == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RoguelikeInstEnterEmptyTips", Array.Empty<object>());
				return;
			}
			bool flag = false;
			using (List<int>.Enumerator enumerator = this.Vm.FormationIdList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeInstEnterConfirm);
				confirmBoxDataNew.FunctionMap[2] = action;
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
				return;
			}
			action();
		}

		// Token: 0x0401EC6B RID: 126059
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401EC6C RID: 126060
		private RoguelikePopularEntriesDescPanel EntriesDescPanel;

		// Token: 0x0401EC6D RID: 126061
		private RoguelikePopularEntriesPanel EntriesPanel;

		// Token: 0x0401EC6E RID: 126062
		private RoguelikeRoleSelectPanel RoleSelectPanel;

		// Token: 0x0401EC6F RID: 126063
		[Nullable(1)]
		private RoguelikeEntranceViewModel Vm;

		// Token: 0x0401EC70 RID: 126064
		[Nullable(0)]
		private ValueTuple<int, int>? NewUnlockEntriesGroupId;

		// Token: 0x0401EC71 RID: 126065
		private LevelSequencePlayer UnlockLevelSequencePlayer;

		// Token: 0x0200B0F2 RID: 45298
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036E2D RID: 224813
			public const int CaptionItem = 0;

			// Token: 0x04036E2E RID: 224814
			public const int PopularEntriesPanel = 1;

			// Token: 0x04036E2F RID: 224815
			public const int PopularEntriesDescPanel = 2;

			// Token: 0x04036E30 RID: 224816
			public const int RoleSelectPanel = 3;

			// Token: 0x04036E31 RID: 224817
			public const int PanelEntriesGroupNewUnlock = 4;

			// Token: 0x04036E32 RID: 224818
			public const int TxtLastGroup = 5;

			// Token: 0x04036E33 RID: 224819
			public const int TxtNewGroup = 6;
		}
	}
}
