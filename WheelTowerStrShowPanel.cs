using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016A6 RID: 5798
public class WheelTowerStrShowPanel : UiPanelBase
{
	// Token: 0x0600A16C RID: 41324 RVA: 0x002A6AC8 File Offset: 0x002A4CC8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.ButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A16D RID: 41325 RVA: 0x002A6BD4 File Offset: 0x002A4DD4
	protected override void OnStart()
	{
		this.Scroll = new GenericScrollViewNew<StrItem, WheelTowerStrItemData>(base.GetScrollViewWithScrollbar(0), () => new StrItem(), null, false, null);
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetText(ModelBase<WheelTowerModel>.Instance.GetTowerConfig().DefaultCostEnergy.ToString(), true);
	}

	// Token: 0x0600A16E RID: 41326 RVA: 0x002A6C44 File Offset: 0x002A4E44
	public void Refresh()
	{
		List<WheelTowerStrItemData> list = new List<WheelTowerStrItemData>();
		foreach (int roleId in ModelBase<WheelTowerModel>.Instance.TmpSelectedRoleMap.Values)
		{
			int num = ModelBase<WheelTowerModel>.Instance.TryGetRealRoleId(roleId);
			if (ModelBase<WheelTowerModel>.Instance.IsEnhanceRole(num))
			{
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(num);
				if (roleConfig != null)
				{
					list.Add(new WheelTowerStrItemData
					{
						RoleName = roleConfig.Value.Name,
						DescList = ModelBase<WheelTowerModel>.Instance.GetRoleEnhanceDesc(num)
					});
				}
			}
		}
		this.SetNullState(list.Count == 0);
		GenericScrollViewNew<StrItem, WheelTowerStrItemData> scroll = this.Scroll;
		if (scroll == null)
		{
			return;
		}
		scroll.RefreshByData(list, null, false);
	}

	// Token: 0x0600A16F RID: 41327 RVA: 0x002A6D24 File Offset: 0x002A4F24
	public void SetNullState(bool nullState)
	{
		UUIItem item = base.GetItem(2);
		if (item != null)
		{
			item.SetUIActive(nullState);
		}
		UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(0);
		if (scrollViewWithScrollbar == null)
		{
			return;
		}
		UUIItem uuiitem = scrollViewWithScrollbar.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(!nullState);
	}

	// Token: 0x0600A170 RID: 41328 RVA: 0x002A6D6B File Offset: 0x002A4F6B
	private void ButtonClick()
	{
		Action onClickConfirm = this.OnClickConfirm;
		if (onClickConfirm == null)
		{
			return;
		}
		onClickConfirm();
	}

	// Token: 0x04004B67 RID: 19303
	[Nullable(2)]
	public Action OnClickConfirm;

	// Token: 0x04004B68 RID: 19304
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<StrItem, WheelTowerStrItemData> Scroll;
}
