using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001680 RID: 5760
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerTeamItem : UiPanelBase
{
	// Token: 0x17000D85 RID: 3461
	// (get) Token: 0x0600A0E6 RID: 41190 RVA: 0x002A2F4B File Offset: 0x002A114B
	// (set) Token: 0x0600A0E7 RID: 41191 RVA: 0x002A2F53 File Offset: 0x002A1153
	public Action ClickCallback { get; set; }

	// Token: 0x0600A0E8 RID: 41192 RVA: 0x002A2F5C File Offset: 0x002A115C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0E9 RID: 41193 RVA: 0x002A3065 File Offset: 0x002A1265
	protected override void OnStart()
	{
		this.RoleIconLayout = new GenericLayout<WheelTowerRoleItem, RoleDataWithBranch>(base.GetHorizontalLayout(1), () => new WheelTowerRoleItem(), null, false, true);
	}

	// Token: 0x0600A0EA RID: 41194 RVA: 0x002A309C File Offset: 0x002A129C
	[NullableContext(1)]
	public void Refresh(List<RoleDataWithBranch> roleDataList)
	{
		GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> roleIconLayout = this.RoleIconLayout;
		if (roleIconLayout != null)
		{
			roleIconLayout.RefreshByData(roleDataList, null, false);
		}
		List<IConflictInfo> list = ModelBase<WheelTowerModel>.Instance.CheckCurrentSelectConflict();
		bool uiactive = false;
		foreach (IConflictInfo conflictInfo in list)
		{
			if (ModelBase<WheelTowerModel>.Instance.SelectedEnergyInfo.GetRoleEnergy(conflictInfo.RoleId) > 0)
			{
				uiactive = true;
				break;
			}
		}
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A0EB RID: 41195 RVA: 0x002A3130 File Offset: 0x002A1330
	private void OnClick()
	{
		Action clickCallback = this.ClickCallback;
		if (clickCallback == null)
		{
			return;
		}
		clickCallback();
	}

	// Token: 0x04004AC1 RID: 19137
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerRoleItem, RoleDataWithBranch> RoleIconLayout;
}
