using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A0F RID: 10767
[NullableContext(1)]
[Nullable(0)]
public class ShowerInviteView : UiViewBase
{
	// Token: 0x060157C9 RID: 88009 RVA: 0x005F4DF4 File Offset: 0x005F2FF4
	public ShowerInviteView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060157CA RID: 88010 RVA: 0x005F4E14 File Offset: 0x005F3014
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnConfirmButtonClick)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnLeftButtonClick)),
			new ValueTuple<int, Delegate>(7, new Action(this.OnRightButtonClick))
		};
	}

	// Token: 0x060157CB RID: 88011 RVA: 0x005F4F8C File Offset: 0x005F318C
	protected override UniTask OnBeforeStartAsync()
	{
		ShowerInviteView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShowerInviteView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060157CC RID: 88012 RVA: 0x005F4FD0 File Offset: 0x005F31D0
	protected override void OnStart()
	{
		List<int> showerSeatConfigIds = this.OpenParam as List<int>;
		ModelBase<ShowerModel>.Instance.SetShowerSeatConfigIds(showerSeatConfigIds);
	}

	// Token: 0x060157CD RID: 88013 RVA: 0x005F4FF4 File Offset: 0x005F31F4
	protected override void OnBeforeShow()
	{
		ShowerInviteView.<>c__DisplayClass10_0 CS$<>8__locals1 = new ShowerInviteView.<>c__DisplayClass10_0();
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		ShowerInviteView.<>c__DisplayClass10_0 CS$<>8__locals2 = CS$<>8__locals1;
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		CS$<>8__locals2.currentFormationList = (((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null) ?? Array.Empty<int>());
		CS$<>8__locals1.originalIdList = new List<int>();
		foreach (int num in CS$<>8__locals1.currentFormationList)
		{
			if (num > 100000)
			{
				TrialRoleInfo? trialRoleInfo;
				CS$<>8__locals1.originalIdList.Add((ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(num) != null) ? trialRoleInfo.GetValueOrDefault().ParentId : 0);
			}
		}
		foreach (RoleInstance roleInstance in roleList)
		{
			if (!ModelBase<RoleModel>.Instance.IsMainRole(roleInstance.GetRoleId()))
			{
				ShowerInviteItemData item = new ShowerInviteItemData
				{
					RoleInstance = roleInstance,
					IsInFormation = (CS$<>8__locals1.currentFormationList.Contains(roleInstance.GetRoleId()) || CS$<>8__locals1.originalIdList.Contains(roleInstance.GetRoleId()))
				};
				this.RoleDataList.Add(item);
			}
		}
		this.RoleDataList.Sort(delegate(IShowerInviteItemData a, IShowerInviteItemData b)
		{
			RoleInstance roleInstance2 = a.RoleInstance;
			RoleInstance roleInstance3 = b.RoleInstance;
			bool flag = CS$<>8__locals1.currentFormationList.Contains(roleInstance2.GetRoleId()) || CS$<>8__locals1.originalIdList.Contains(roleInstance2.GetRoleId());
			bool flag2 = CS$<>8__locals1.currentFormationList.Contains(roleInstance3.GetRoleId()) || CS$<>8__locals1.originalIdList.Contains(roleInstance3.GetRoleId());
			if (!flag && !flag2)
			{
				int favorLevel = roleInstance2.GetFavorData().GetFavorLevel();
				int favorLevel2 = roleInstance3.GetFavorData().GetFavorLevel();
				if (favorLevel != favorLevel2)
				{
					return favorLevel2 - favorLevel;
				}
				return roleInstance3.GetRoleCreateTime() - roleInstance2.GetRoleCreateTime();
			}
			else
			{
				if (flag && flag2)
				{
					return 0;
				}
				if (flag)
				{
					return 1;
				}
				return -1;
			}
		});
		foreach (ShowerRoleItem showerRoleItem in this.RoleItems)
		{
			showerRoleItem.SetUiActive(false);
		}
		ModelBase<ShowerModel>.Instance.ResetCurInviteRoles();
		this.OnPosSwitchCallback(ModelBase<ShowerModel>.Instance.CurSelectPosIndex);
	}

	// Token: 0x060157CE RID: 88014 RVA: 0x005F5188 File Offset: 0x005F3388
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x060157CF RID: 88015 RVA: 0x005F51A6 File Offset: 0x005F33A6
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUiBlendInTimeCameraFinished, new Action<UiCameraHandleData>(this.OnCameraFinish));
	}

	// Token: 0x060157D0 RID: 88016 RVA: 0x005F51C4 File Offset: 0x005F33C4
	private void OnCameraFinish(UiCameraHandleData handleData)
	{
		if (handleData.ViewName == EUiViewName.ShowerInviteView)
		{
			Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.LRC, "OnCameraFinish:ShowerInviteView OnCameraFinish", default(ReadOnlySpan<ValueTuple<string, object>>));
			TimerSystem.Instance.Next(delegate(float _)
			{
				this.InitRoleItems();
			}, null, null);
		}
	}

	// Token: 0x060157D1 RID: 88017 RVA: 0x005F521D File Offset: 0x005F341D
	private ShowerInviteItem CreateRoleInfoItem()
	{
		ShowerInviteItem showerInviteItem = new ShowerInviteItem();
		showerInviteItem.BindRoleSelectCallback(new Action<RoleInstance>(this.OnRoleSelectCallback));
		return showerInviteItem;
	}

	// Token: 0x060157D2 RID: 88018 RVA: 0x005F5238 File Offset: 0x005F3438
	private void InitRoleItems()
	{
		int num = Math.Min(ModelBase<ShowerModel>.Instance.PosCount, this.RoleItems.Count);
		this.RoleShowCount = 0;
		for (int i = 0; i < num; i++)
		{
			ShowerRoleItem showerRoleItem = this.RoleItems[i];
			WorldEntity showerSeatEntityByPos = ModelBase<ShowerModel>.Instance.GetShowerSeatEntityByPos(i);
			bool flag = showerRoleItem.SetPos(i, showerSeatEntityByPos);
			showerRoleItem.SetUiActive(flag);
			if (flag)
			{
				this.RoleShowCount++;
			}
		}
		for (int j = 0; j < this.RoleShowCount; j++)
		{
			this.RoleItems[j].BindPosChangeCallback(new Action<int>(this.OnPosSwitchCallback));
		}
		this.RefreshRoleItems();
	}

	// Token: 0x060157D3 RID: 88019 RVA: 0x005F52E4 File Offset: 0x005F34E4
	private void RefreshRoleItems()
	{
		for (int i = 0; i < this.RoleShowCount; i++)
		{
			ShowerRoleItem showerRoleItem = this.RoleItems[i];
			RoleInstance roleInstanceByPos = ModelBase<ShowerModel>.Instance.GetRoleInstanceByPos(i);
			showerRoleItem.RefreshRoleInfo(ModelBase<ShowerModel>.Instance.CurSelectPosIndex, roleInstanceByPos);
		}
	}

	// Token: 0x060157D4 RID: 88020 RVA: 0x005F532A File Offset: 0x005F352A
	private void OnRoleSelectCallback(RoleInstance roleInstance)
	{
		ModelBase<ShowerModel>.Instance.InviteRole(roleInstance);
		this.RefreshView();
	}

	// Token: 0x060157D5 RID: 88021 RVA: 0x005F533D File Offset: 0x005F353D
	private void OnPosSwitchCallback(int posIndex)
	{
		ModelBase<ShowerModel>.Instance.ChangePos(posIndex);
		this.RefreshView();
		this.SetSelectedRoleItem();
	}

	// Token: 0x060157D6 RID: 88022 RVA: 0x005F5358 File Offset: 0x005F3558
	private void RefreshView()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "ShowerInvitePos", new <>z__ReadOnlySingleElementList<object>(ModelBase<ShowerModel>.Instance.CurSelectPosIndex + 1));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "ShowerInviteNumber", new <>z__ReadOnlySingleElementList<object>(ModelBase<ShowerModel>.Instance.GetInviteNumString()));
		LoopScrollView<ShowerInviteItem, IShowerInviteItemData> roleInfoScrollView = this.RoleInfoScrollView;
		if (roleInfoScrollView != null)
		{
			roleInfoScrollView.RefreshByData(this.RoleDataList, false, null, false);
		}
		this.RefreshRoleItems();
	}

	// Token: 0x060157D7 RID: 88023 RVA: 0x005F53D8 File Offset: 0x005F35D8
	private void SetSelectedRoleItem()
	{
		RoleInstance roleInstanceByPos = ModelBase<ShowerModel>.Instance.GetRoleInstanceByPos(ModelBase<ShowerModel>.Instance.CurSelectPosIndex);
		if (roleInstanceByPos == null)
		{
			return;
		}
		int num = 0;
		this.RoleInfoScrollView.DeselectCurrentGridProxy(false);
		while (num < this.RoleDataList.Count && roleInstanceByPos.GetRoleId() != this.RoleDataList[num].RoleInstance.GetRoleId())
		{
			num++;
		}
		this.RoleInfoScrollView.ScrollToGridIndex(num, true);
		this.RoleInfoScrollView.SelectGridProxy(num, false);
	}

	// Token: 0x060157D8 RID: 88024 RVA: 0x005F5458 File Offset: 0x005F3658
	private void OnConfirmButtonClick()
	{
		ModelBase<ShowerModel>.Instance.SendAndSave();
		Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.ShowerInviteView, EUiViewName.ShowerMainView, null, null, true);
	}

	// Token: 0x060157D9 RID: 88025 RVA: 0x005F547B File Offset: 0x005F367B
	private void OnLeftButtonClick()
	{
		ModelBase<ShowerModel>.Instance.LeftPos();
		this.RefreshView();
		this.SetSelectedRoleItem();
	}

	// Token: 0x060157DA RID: 88026 RVA: 0x005F5493 File Offset: 0x005F3693
	private void OnRightButtonClick()
	{
		ModelBase<ShowerModel>.Instance.RightPos();
		this.RefreshView();
		this.SetSelectedRoleItem();
	}

	// Token: 0x060157DB RID: 88027 RVA: 0x005F54AC File Offset: 0x005F36AC
	private void OnClickBack()
	{
		if (ModelBase<ShowerModel>.Instance.IsInShower)
		{
			Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.ShowerInviteView, EUiViewName.ShowerMainView, null, null, true);
		}
		else
		{
			ModelBase<ShowerModel>.Instance.ClearCurInviteRoles();
			base.CloseMe(null);
		}
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_com_cam_whoosh");
	}

	// Token: 0x0400A555 RID: 42325
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShowerInviteItem, IShowerInviteItemData> RoleInfoScrollView;

	// Token: 0x0400A556 RID: 42326
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400A557 RID: 42327
	private readonly List<IShowerInviteItemData> RoleDataList = new List<IShowerInviteItemData>();

	// Token: 0x0400A558 RID: 42328
	private readonly List<ShowerRoleItem> RoleItems = new List<ShowerRoleItem>();

	// Token: 0x0400A559 RID: 42329
	private int RoleShowCount;

	// Token: 0x02008D8E RID: 36238
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402F990 RID: 194960
		public const int RoleInfoScrollView = 0;

		// Token: 0x0402F991 RID: 194961
		public const int RoleInfoItem = 1;

		// Token: 0x0402F992 RID: 194962
		public const int ConfirmButton = 2;

		// Token: 0x0402F993 RID: 194963
		public const int ConfirmText = 3;

		// Token: 0x0402F994 RID: 194964
		public const int CaptionItem = 4;

		// Token: 0x0402F995 RID: 194965
		public const int MaxCountText = 5;

		// Token: 0x0402F996 RID: 194966
		public const int LeftButton = 6;

		// Token: 0x0402F997 RID: 194967
		public const int RightButton = 7;

		// Token: 0x0402F998 RID: 194968
		public const int PosNameText = 8;

		// Token: 0x0402F999 RID: 194969
		public const int FirstRole = 9;

		// Token: 0x0402F99A RID: 194970
		public const int SecondRole = 10;

		// Token: 0x0402F99B RID: 194971
		public const int ThirdRole = 11;
	}
}
