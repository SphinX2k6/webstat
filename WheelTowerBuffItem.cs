using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200166F RID: 5743
public class WheelTowerBuffItem : UiPanelBase
{
	// Token: 0x0600A0B0 RID: 41136 RVA: 0x002A15A0 File Offset: 0x0029F7A0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ClickAction));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ClickAction));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0B1 RID: 41137 RVA: 0x002A1710 File Offset: 0x0029F910
	public void Refresh(int buffId)
	{
		bool flag = buffId > 0;
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(flag);
			}
		}
		UUIButtonComponent button2 = base.GetButton(0);
		if (button2 != null)
		{
			UUIItem uuiitem2 = button2.RootUIComp.Get();
			if (uuiitem2 != null)
			{
				uuiitem2.SetUIActive(!flag);
			}
		}
		if (!flag)
		{
			return;
		}
		NewTowerBuff? buffConfigById = ConfigBase<WheelTowerConfig>.Instance.GetBuffConfigById(buffId);
		if (buffConfigById == null)
		{
			return;
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.ShowTextNew(buffConfigById.Value.Name);
		}
		base.SetTextureByPath(buffConfigById.Value.Icon, base.GetTexture(2), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), buffConfigById.Value.Desc, buffConfigById.Value.DescParam());
	}

	// Token: 0x0600A0B2 RID: 41138 RVA: 0x002A1802 File Offset: 0x0029FA02
	private void ClickAction()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerBuffSelectView, null, null);
	}
}
