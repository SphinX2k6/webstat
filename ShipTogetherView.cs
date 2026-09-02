using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020029F2 RID: 10738
public class ShipTogetherView : UiViewBase
{
	// Token: 0x060156C7 RID: 87751 RVA: 0x005EF9AB File Offset: 0x005EDBAB
	[NullableContext(1)]
	public ShipTogetherView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060156C8 RID: 87752 RVA: 0x005EF9B4 File Offset: 0x005EDBB4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(2, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x060156C9 RID: 87753 RVA: 0x005EFA34 File Offset: 0x005EDC34
	protected override void OnStart()
	{
		this.RoleScrollView = new LoopScrollView<ShipTogetherRoleItem, IShipTogetherRoleItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<ShipTogetherRoleItem>(this.CreateLoopItem), false);
		ModelBase<ShipTogetherModel>.Instance.CurrentSelectTogetherRoleId = ModelBase<ShipTogetherModel>.Instance.RiderSharingRoleId;
	}

	// Token: 0x060156CA RID: 87754 RVA: 0x005EFA88 File Offset: 0x005EDC88
	protected override void OnBeforeShow()
	{
		ShipTogetherView.<>c__DisplayClass6_0 CS$<>8__locals1 = new ShipTogetherView.<>c__DisplayClass6_0();
		RoleInstance[] roleList = ModelBase<RoleModel>.Instance.GetRoleList();
		ShipTogetherView.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
		EditFormationData getCurrentFormationData = ModelBase<EditFormationModel>.Instance.GetCurrentFormationData;
		CS$<>8__locals2.currentFormationList = ((getCurrentFormationData != null) ? getCurrentFormationData.GetRoleIdList : null);
		List<IShipTogetherRoleItemData> list = new List<IShipTogetherRoleItemData>();
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
				ShipTogetherRoleItemData item = new ShipTogetherRoleItemData
				{
					RoleInstance = roleInstance,
					IsInFormation = (CS$<>8__locals1.currentFormationList.Contains(roleInstance.GetRoleId()) || CS$<>8__locals1.originalIdList.Contains(roleInstance.GetRoleId()))
				};
				list.Add(item);
			}
		}
		list.Sort(delegate(IShipTogetherRoleItemData a, IShipTogetherRoleItemData b)
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
		LoopScrollView<ShipTogetherRoleItem, IShipTogetherRoleItemData> roleScrollView = this.RoleScrollView;
		if (roleScrollView == null)
		{
			return;
		}
		roleScrollView.RefreshByData(list, false, null, false);
	}

	// Token: 0x060156CB RID: 87755 RVA: 0x005EFBCC File Offset: 0x005EDDCC
	[NullableContext(1)]
	private ShipTogetherRoleItem CreateLoopItem()
	{
		ShipTogetherRoleItem shipTogetherRoleItem = new ShipTogetherRoleItem();
		shipTogetherRoleItem.BindOnClickToggleCallBack(new Action<UUIExtendToggle, int>(this.RoleItemToggleCallBack));
		return shipTogetherRoleItem;
	}

	// Token: 0x060156CC RID: 87756 RVA: 0x005EFBE5 File Offset: 0x005EDDE5
	[NullableContext(2)]
	private void RoleItemToggleCallBack(UUIExtendToggle toggle, int roleId)
	{
		if (this.CurrentSelectToggle != toggle)
		{
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
		}
		this.CurrentSelectToggle = toggle;
		ModelBase<ShipTogetherModel>.Instance.CurrentSelectTogetherRoleId = roleId;
	}

	// Token: 0x060156CD RID: 87757 RVA: 0x005EFC18 File Offset: 0x005EDE18
	private void OnClickConfirmBtn()
	{
		if (ModelBase<ShipTogetherModel>.Instance.CurrentSelectTogetherRoleId != -1)
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnChangeRideSharingPassenger, ModelBase<ShipTogetherModel>.Instance.CurrentSelectTogetherRoleId, 1);
		}
		else
		{
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnRemoveRideSharingPassenger, -1, -1);
		}
		base.CloseMe(null);
	}

	// Token: 0x0400A4DE RID: 42206
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<ShipTogetherRoleItem, IShipTogetherRoleItemData> RoleScrollView;

	// Token: 0x0400A4DF RID: 42207
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x02008D70 RID: 36208
	private class EChildType
	{
		// Token: 0x0402F8EB RID: 194795
		public const int RoleLoopScrollView = 0;

		// Token: 0x0402F8EC RID: 194796
		public const int RoleItem = 1;

		// Token: 0x0402F8ED RID: 194797
		public const int ConfirmBtn = 2;
	}
}
