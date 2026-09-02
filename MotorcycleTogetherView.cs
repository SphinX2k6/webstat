using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002289 RID: 8841
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleTogetherView : UiViewBase
{
	// Token: 0x06010B6C RID: 68460 RVA: 0x00493C7C File Offset: 0x00491E7C
	[NullableContext(1)]
	public MotorcycleTogetherView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010B6D RID: 68461 RVA: 0x00493C88 File Offset: 0x00491E88
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickExitBtn))
		};
	}

	// Token: 0x06010B6E RID: 68462 RVA: 0x00493D60 File Offset: 0x00491F60
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleTogetherView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleTogetherView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010B6F RID: 68463 RVA: 0x00493DA4 File Offset: 0x00491FA4
	private void InitAreaList()
	{
		IReadOnlyList<MotorRoleCategory> readOnlyList = ConfigMotorRoleCategoryAll.GetConfigList(true);
		if (readOnlyList == null)
		{
			readOnlyList = new List<MotorRoleCategory>();
		}
		List<MotorRoleCategory> list = new List<MotorRoleCategory>(readOnlyList);
		list.Sort(delegate(MotorRoleCategory a, MotorRoleCategory b)
		{
			MotorRoleCategory motorRoleCategory2 = a;
			MotorRoleCategory motorRoleCategory3 = b;
			return motorRoleCategory2.SortId - motorRoleCategory3.SortId;
		});
		List<int> list2 = new List<int>();
		foreach (MotorRoleCategory motorRoleCategory in list)
		{
			list2.Add(motorRoleCategory.Id);
		}
		this.CurrentSelectRoleId = ModelBase<ShipTogetherModel>.Instance.RiderSharingRoleId;
		int selectAreaId = 0;
		if (this.CurrentSelectRoleId != 0)
		{
			VehicleRidingRoles? config = ConfigVehicleRidingRolesById.GetConfig(this.CurrentSelectRoleId, true);
			if (config != null)
			{
				selectAreaId = config.Value.RegionId;
			}
		}
		this.AreaSwitchGroupItem.RefreshAreaList(list2, selectAreaId);
	}

	// Token: 0x06010B70 RID: 68464 RVA: 0x00493E88 File Offset: 0x00492088
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x06010B71 RID: 68465 RVA: 0x00493E8A File Offset: 0x0049208A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnMovieMotorRideSharingModeChangeResponse, new Action<bool, bool>(this.OnMovieMotorRideSharingModeChangeResponse));
	}

	// Token: 0x06010B72 RID: 68466 RVA: 0x00493EA8 File Offset: 0x004920A8
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMovieMotorRideSharingModeChangeResponse, new Action<bool, bool>(this.OnMovieMotorRideSharingModeChangeResponse));
	}

	// Token: 0x06010B73 RID: 68467 RVA: 0x00493EC6 File Offset: 0x004920C6
	private void OnSwitchArea(int areaId)
	{
		this.RefreshRoleList(areaId);
	}

	// Token: 0x06010B74 RID: 68468 RVA: 0x00493ED0 File Offset: 0x004920D0
	private void RefreshRoleList(int areaId)
	{
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		List<RoleInstance> roleListAvailable = new List<RoleInstance>();
		foreach (RoleInstance roleInstance in roleList)
		{
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleInstance.GetRoleId()))
			{
				VehicleRidingRoles? config = ConfigVehicleRidingRolesById.GetConfig(roleInstance.GetRoleId(), true);
				if (config != null && config.Value.RegionId == areaId)
				{
					roleListAvailable.Add(roleInstance);
				}
			}
		}
		roleListAvailable.Sort(delegate(RoleInstance a, RoleInstance b)
		{
			int favorLevel = a.GetFavorData().GetFavorLevel();
			int favorLevel2 = b.GetFavorData().GetFavorLevel();
			if (favorLevel != favorLevel2)
			{
				return favorLevel2 - favorLevel;
			}
			return a.GetRoleId() - b.GetRoleId();
		});
		bool flag = roleListAvailable.Count != 0;
		base.GetItem(6).SetUIActive(!flag);
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(2);
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			loopScrollViewComponent.StopMovement();
			this.RoleScrollView.RefreshByData(roleListAvailable, false, delegate
			{
				if (this.CurrentSelectRoleId <= 0)
				{
					this.RoleScrollView.ScrollToGridIndex(0, true);
					return;
				}
				int num = -1;
				for (int j = 0; j < roleListAvailable.Count; j++)
				{
					if (roleListAvailable[j].GetRoleId() == this.CurrentSelectRoleId)
					{
						num = j;
						break;
					}
				}
				if (num < 0)
				{
					this.RoleScrollView.ScrollToGridIndex(0, true);
					return;
				}
				this.RoleScrollView.ScrollToGridIndex(num, true);
				this.RoleScrollView.DeselectCurrentGridProxy(false);
				this.RoleScrollView.SelectGridProxy(num, false);
			}, true);
		}
		this.RefreshViewState();
	}

	// Token: 0x06010B75 RID: 68469 RVA: 0x00493FF8 File Offset: 0x004921F8
	private void RefreshViewState()
	{
		bool flag = this.CurrentSelectRoleId != 0;
		this.ButtonConfirm.SetLocalTextNew(flag ? "MotorSharingRide_Button01" : "MotorSharingRide_Button02", Array.Empty<object>());
	}

	// Token: 0x06010B76 RID: 68470 RVA: 0x0049402E File Offset: 0x0049222E
	[NullableContext(1)]
	private MotorcycleTogetherRoleItem CreateLoopItem()
	{
		return new MotorcycleTogetherRoleItem
		{
			OnClickToggleCallBack = new Action<bool, int, int>(this.RoleItemToggleCallBack),
			IsToggleSelectOn = new Func<int, bool>(this.IsRoleSelectOn)
		};
	}

	// Token: 0x06010B77 RID: 68471 RVA: 0x00494059 File Offset: 0x00492259
	private void RoleItemToggleCallBack(bool state, int roleId, int index)
	{
		this.RoleScrollView.DeselectCurrentGridProxy(false);
		if (state)
		{
			this.CurrentSelectRoleId = roleId;
			this.RoleScrollView.SelectGridProxy(index, false);
		}
		else
		{
			this.CurrentSelectRoleId = 0;
		}
		this.RefreshViewState();
	}

	// Token: 0x06010B78 RID: 68472 RVA: 0x0049408D File Offset: 0x0049228D
	private bool IsRoleSelectOn(int roleId)
	{
		return this.CurrentSelectRoleId == roleId;
	}

	// Token: 0x06010B79 RID: 68473 RVA: 0x00494098 File Offset: 0x00492298
	private void OnClickConfirmBtn(int _)
	{
		if (!ModelBase<ShipTogetherModel>.Instance.IsInMovieRideSharingMode)
		{
			return;
		}
		int riderSharingRoleId = ModelBase<ShipTogetherModel>.Instance.RiderSharingRoleId;
		if (this.CurrentSelectRoleId != 0 && this.CurrentSelectRoleId != riderSharingRoleId)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnChangeRideSharingPassenger, this.CurrentSelectRoleId, 1);
		}
		else if (this.CurrentSelectRoleId == 0 && riderSharingRoleId != 0)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnRemoveRideSharingPassenger, -1, -1);
		}
		base.CloseMe(null);
	}

	// Token: 0x06010B7A RID: 68474 RVA: 0x0049410B File Offset: 0x0049230B
	private void OnClickExitBtn()
	{
		if (!ModelBase<ShipTogetherModel>.Instance.RiderSharingState)
		{
			return;
		}
		if (ModelBase<ShipTogetherModel>.Instance.IsInMovieRideSharingMode && this.ExitRideSharePromise == null)
		{
			this.ExitRideShareMode().Forget();
		}
	}

	// Token: 0x06010B7B RID: 68475 RVA: 0x0049413C File Offset: 0x0049233C
	private UniTask ExitRideShareMode()
	{
		MotorcycleTogetherView.<ExitRideShareMode>d__22 <ExitRideShareMode>d__;
		<ExitRideShareMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<ExitRideShareMode>d__.<>4__this = this;
		<ExitRideShareMode>d__.<>1__state = -1;
		<ExitRideShareMode>d__.<>t__builder.Start<MotorcycleTogetherView.<ExitRideShareMode>d__22>(ref <ExitRideShareMode>d__);
		return <ExitRideShareMode>d__.<>t__builder.Task;
	}

	// Token: 0x06010B7C RID: 68476 RVA: 0x0049417F File Offset: 0x0049237F
	private void OnMovieMotorRideSharingModeChangeResponse(bool enable, bool success)
	{
		CustomPromise exitRideSharePromise = this.ExitRideSharePromise;
		if (exitRideSharePromise != null)
		{
			exitRideSharePromise.SetResult();
		}
		this.ExitRideSharePromise = null;
		if (!enable)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x040083E9 RID: 33769
	private PopupCaptionItem CaptionItem;

	// Token: 0x040083EA RID: 33770
	private AreaSwitchGroupItem AreaSwitchGroupItem;

	// Token: 0x040083EB RID: 33771
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleTogetherRoleItem, RoleInstance> RoleScrollView;

	// Token: 0x040083EC RID: 33772
	private ButtonItem ButtonConfirm;

	// Token: 0x040083ED RID: 33773
	private int CurrentSelectRoleId;

	// Token: 0x040083EE RID: 33774
	private CustomPromise ExitRideSharePromise;

	// Token: 0x02008550 RID: 34128
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402D1DA RID: 184794
		public const int CaptionItem = 0;

		// Token: 0x0402D1DB RID: 184795
		public const int SwitchGroupItem = 1;

		// Token: 0x0402D1DC RID: 184796
		public const int RoleLoopScrollView = 2;

		// Token: 0x0402D1DD RID: 184797
		public const int RoleItem = 3;

		// Token: 0x0402D1DE RID: 184798
		public const int BtnConfirm = 4;

		// Token: 0x0402D1DF RID: 184799
		public const int BtnExit = 5;

		// Token: 0x0402D1E0 RID: 184800
		public const int EmptyItem = 6;
	}
}
