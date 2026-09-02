using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001679 RID: 5753
public class WheelTowerSmallBuffItem : UiPanelBase
{
	// Token: 0x0600A0D5 RID: 41173 RVA: 0x002A2980 File Offset: 0x002A0B80
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0D6 RID: 41174 RVA: 0x002A2A68 File Offset: 0x002A0C68
	public void Refresh(int buffId)
	{
		bool flag = buffId > 0;
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(!flag);
		}
		UUIItem item2 = base.GetItem(2);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
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
		base.SetTextureByPath(buffConfigById.Value.Icon, base.GetTexture(3), null, null);
	}

	// Token: 0x0600A0D7 RID: 41175 RVA: 0x002A2AE3 File Offset: 0x002A0CE3
	private void OnBtnClick()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WheelTowerBuffSelectView, 32, null);
	}
}
