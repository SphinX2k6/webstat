using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A05 RID: 10757
[NullableContext(1)]
[Nullable(0)]
public class MoonTogetherInviteView : UiViewBase
{
	// Token: 0x06015761 RID: 87905 RVA: 0x005F2EF8 File Offset: 0x005F10F8
	public MoonTogetherInviteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015762 RID: 87906 RVA: 0x005F2F04 File Offset: 0x005F1104
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickExitBtn)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickInviteBtn))
		};
	}

	// Token: 0x06015763 RID: 87907 RVA: 0x005F301D File Offset: 0x005F121D
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x06015764 RID: 87908 RVA: 0x005F303B File Offset: 0x005F123B
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x06015765 RID: 87909 RVA: 0x005F3059 File Offset: 0x005F1259
	private void OnCameraFinish(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiViewName.MoonTogetherInviteView)
		{
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.RefreshRoleItemLocation();
			}, null, null);
		}
	}

	// Token: 0x06015766 RID: 87910 RVA: 0x005F308C File Offset: 0x005F128C
	protected override UniTask OnBeforeStartAsync()
	{
		MoonTogetherInviteView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MoonTogetherInviteView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015767 RID: 87911 RVA: 0x005F30D0 File Offset: 0x005F12D0
	private void RefreshRoleItemLocation()
	{
		int num;
		if (this.OpenParam != null)
		{
			num = ((int[])this.OpenParam)[0];
			ModelBase<MoonTogetherModel>.Instance.HandleEntityId = num;
		}
		else
		{
			num = ModelBase<MoonTogetherModel>.Instance.HandleEntityId;
		}
		List<EntityHandle> list = new List<EntityHandle>();
		ModelBase<CreatureModel>.Instance.GetEntitiesWithPbDataId(num, ref list);
		WorldEntity worldEntity;
		if (list.Count <= 0)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityHandle = list[0];
			worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
		}
		WorldEntity worldEntity2 = worldEntity;
		if (worldEntity2 == null)
		{
			return;
		}
		FVectorDouble actorLocation = worldEntity2.GetComponent<BaseActorComponent>().ActorLocation;
		Vector2D vector2D = new Vector2D();
		if (HudUnitUtils.PositionUtil.ProjectWorldToScreen(actorLocation, vector2D))
		{
			this.RoleItem.SetUiActive(true);
			this.RoleItem.GetRootItem().SetAnchorOffset(vector2D.ToUeVector2D(false));
		}
	}

	// Token: 0x06015768 RID: 87912 RVA: 0x005F318C File Offset: 0x005F138C
	private void InitAreaList()
	{
		List<MotorRoleCategory> list = new List<MotorRoleCategory>(ConfigBase<MoonTogetherConfig>.Instance.GetRoleAreaList() ?? Array.Empty<MotorRoleCategory>());
		list.Sort(delegate(MotorRoleCategory a, MotorRoleCategory b)
		{
			int num = (!ModelBase<MoonTogetherModel>.Instance.IsLinkageRegion(a.Id)) ? 1 : 0;
			int num2 = (!ModelBase<MoonTogetherModel>.Instance.IsLinkageRegion(b.Id)) ? 1 : 0;
			if (num != num2)
			{
				return num - num2;
			}
			return a.SortId - b.SortId;
		});
		List<int> list2 = new List<int>();
		foreach (MotorRoleCategory motorRoleCategory in list)
		{
			list2.Add(motorRoleCategory.Id);
		}
		this.CurrentSelectRoleId = ModelBase<ShipTogetherModel>.Instance.RiderSharingRoleId;
		MoonTogetherRoleItem roleItem = this.RoleItem;
		if (roleItem != null)
		{
			roleItem.RefreshRoleInfo(this.CurrentSelectRoleId);
		}
		int selectAreaId = 0;
		if (this.CurrentSelectRoleId != 0)
		{
			VehicleRidingRoles? vehicleRidingRolesById = ConfigBase<MoonTogetherConfig>.Instance.GetVehicleRidingRolesById(this.CurrentSelectRoleId);
			if (vehicleRidingRolesById != null)
			{
				selectAreaId = vehicleRidingRolesById.Value.RegionId;
			}
		}
		this.AreaSwitchGroupItem.RefreshAreaList(list2, selectAreaId);
	}

	// Token: 0x06015769 RID: 87913 RVA: 0x005F328C File Offset: 0x005F148C
	private MotorcycleTogetherRoleItem CreateLoopItem()
	{
		return new MotorcycleTogetherRoleItem
		{
			OnClickToggleCallBack = new Action<bool, int, int>(this.RoleItemToggleCallBack),
			IsToggleSelectOn = new Func<int, bool>(this.IsRoleSelectOn)
		};
	}

	// Token: 0x0601576A RID: 87914 RVA: 0x005F32B8 File Offset: 0x005F14B8
	private void RoleItemToggleCallBack(bool state, int roleId, int index)
	{
		this.RoleScrollView.DeselectCurrentGridProxy(false);
		if (state)
		{
			this.CurrentSelectRoleId = roleId;
			this.RoleScrollView.SelectGridProxy(index, false);
			ModelBase<MoonTogetherModel>.Instance.InviteRole(roleId);
		}
		else
		{
			this.CurrentSelectRoleId = 0;
			ModelBase<MoonTogetherModel>.Instance.InviteRole(0);
		}
		this.RoleScrollView.RefreshAllGridProxies();
		this.RefreshViewState();
	}

	// Token: 0x0601576B RID: 87915 RVA: 0x005F3318 File Offset: 0x005F1518
	private bool IsRoleSelectOn(int roleId)
	{
		return this.CurrentSelectRoleId == roleId;
	}

	// Token: 0x0601576C RID: 87916 RVA: 0x005F3323 File Offset: 0x005F1523
	private void OnSwitchArea(int areaId)
	{
		this.RefreshRoleList(areaId);
	}

	// Token: 0x0601576D RID: 87917 RVA: 0x005F332C File Offset: 0x005F152C
	private void RefreshRoleList(int areaId)
	{
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		List<RoleInstance> roleListAvailable = new List<RoleInstance>();
		foreach (RoleInstance roleInstance in roleList)
		{
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleInstance.GetRoleId()))
			{
				VehicleRidingRoles? vehicleRidingRolesById = ConfigBase<MoonTogetherConfig>.Instance.GetVehicleRidingRolesById(roleInstance.GetRoleId());
				if (vehicleRidingRolesById != null && vehicleRidingRolesById.Value.RegionId == areaId)
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
		base.GetItem(2).SetUIActive(!flag);
		UUILoopScrollViewComponent loopScrollViewComponent = base.GetLoopScrollViewComponent(3);
		loopScrollViewComponent.RootUIComp.Get().SetUIActive(flag);
		if (flag)
		{
			loopScrollViewComponent.StopMovement();
			Predicate<RoleInstance> <>9__2;
			this.RoleScrollView.RefreshByData(roleListAvailable, false, delegate
			{
				if (this.CurrentSelectRoleId <= 0)
				{
					this.RoleScrollView.ScrollToGridIndex(0, true);
					this.RoleItemToggleCallBack(false, 0, 0);
					return;
				}
				List<RoleInstance> roleListAvailable = roleListAvailable;
				Predicate<RoleInstance> match;
				if ((match = <>9__2) == null)
				{
					match = (<>9__2 = ((RoleInstance role) => role.GetRoleId() == this.CurrentSelectRoleId));
				}
				int num = roleListAvailable.FindIndex(match);
				if (num < 0)
				{
					this.RoleScrollView.ScrollToGridIndex(0, true);
					this.RoleItemToggleCallBack(false, 0, 0);
					return;
				}
				this.RoleScrollView.ScrollToGridIndexLate(num, true);
				this.RoleScrollView.DeselectCurrentGridProxy(false);
				this.RoleScrollView.SelectGridProxy(num, false);
				this.RoleItemToggleCallBack(true, this.CurrentSelectRoleId, num);
				if (Singleton<Info>.Instance.IsInGamepad())
				{
					MotorcycleTogetherRoleItem motorcycleTogetherRoleItem = this.RoleScrollView.UnsafeGetGridProxy(num, false);
					UUIItem uuiitem = (motorcycleTogetherRoleItem != null) ? motorcycleTogetherRoleItem.GetToggleRootItem() : null;
					if (uuiitem != null)
					{
						ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(uuiitem, true, false, false);
					}
				}
			}, true);
		}
		this.RefreshViewState();
	}

	// Token: 0x0601576E RID: 87918 RVA: 0x005F3458 File Offset: 0x005F1658
	private void RefreshViewState()
	{
		bool flag = this.CurrentSelectRoleId != 0;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), flag ? "MoonTogether_Invite" : "MoonTogether_Solo", Array.Empty<object>());
		MoonTogetherRoleItem roleItem = this.RoleItem;
		if (roleItem == null)
		{
			return;
		}
		roleItem.RefreshRoleInfo(this.CurrentSelectRoleId);
	}

	// Token: 0x0601576F RID: 87919 RVA: 0x005F34AA File Offset: 0x005F16AA
	private void OnClickExitBtn()
	{
		if (ModelBase<MoonTogetherModel>.Instance.IsInMoonTogether || ModelBase<MoonTogetherModel>.Instance.CurInviteRoleId > 0)
		{
			Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.MoonTogetherInviteView, EUiViewName.MoonTogetherMainView, null, null, true);
			return;
		}
		base.CloseMe(null);
	}

	// Token: 0x06015770 RID: 87920 RVA: 0x005F34E4 File Offset: 0x005F16E4
	private void OnClickInviteBtn()
	{
		ModelBase<MoonTogetherModel>.Instance.SendAndSave();
		Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.MoonTogetherInviteView, EUiViewName.MoonTogetherMainView, null, null, true);
	}

	// Token: 0x0400A529 RID: 42281
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A52A RID: 42282
	[Nullable(2)]
	private AreaSwitchGroupItem AreaSwitchGroupItem;

	// Token: 0x0400A52B RID: 42283
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleTogetherRoleItem, RoleInstance> RoleScrollView;

	// Token: 0x0400A52C RID: 42284
	[Nullable(2)]
	private MoonTogetherRoleItem RoleItem;

	// Token: 0x0400A52D RID: 42285
	private int CurrentSelectRoleId;

	// Token: 0x02008D7F RID: 36223
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402F94E RID: 194894
		public const int CaptionItem = 0;

		// Token: 0x0402F94F RID: 194895
		public const int AreaItem = 1;

		// Token: 0x0402F950 RID: 194896
		public const int EmptyItem = 2;

		// Token: 0x0402F951 RID: 194897
		public const int RoleLoopScrollView = 3;

		// Token: 0x0402F952 RID: 194898
		public const int RoleItem = 4;

		// Token: 0x0402F953 RID: 194899
		public const int ExitBtn = 5;

		// Token: 0x0402F954 RID: 194900
		public const int InviteBtn = 6;

		// Token: 0x0402F955 RID: 194901
		public const int InviteRoleItem = 7;

		// Token: 0x0402F956 RID: 194902
		public const int ConfirmText = 8;
	}
}
