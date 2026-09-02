using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001640 RID: 5696
public class WheelTowerBossHandBookModeItem : GridProxyAbstract<bool>
{
	// Token: 0x17000D7C RID: 3452
	// (get) Token: 0x0600A036 RID: 41014 RVA: 0x0029E79B File Offset: 0x0029C99B
	// (set) Token: 0x0600A037 RID: 41015 RVA: 0x0029E7A3 File Offset: 0x0029C9A3
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<bool, UUIExtendToggle, bool> OnClickToggleBack { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x0600A038 RID: 41016 RVA: 0x0029E7AC File Offset: 0x0029C9AC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A039 RID: 41017 RVA: 0x0029E874 File Offset: 0x0029CA74
	public override void Refresh(bool isEndless, bool isSelected, int gridIndex)
	{
		this.IsEndless = isEndless;
		string textStringId = isEndless ? "WheelTowerModeTitle_Endless" : "WheelTowerModeTitle_Normal";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x0600A03A RID: 41018 RVA: 0x0029E8C1 File Offset: 0x0029CAC1
	public override void OnSelected(bool fireEvent)
	{
		this.InvokeToggleClick(fireEvent);
	}

	// Token: 0x0600A03B RID: 41019 RVA: 0x0029E8CA File Offset: 0x0029CACA
	private void OnToggleClick(EToggleState state)
	{
		this.InvokeToggleClick(state == EToggleState.ETT_Checked);
	}

	// Token: 0x0600A03C RID: 41020 RVA: 0x0029E8D8 File Offset: 0x0029CAD8
	private void InvokeToggleClick(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			Action<bool, UUIExtendToggle, bool> onClickToggleBack = this.OnClickToggleBack;
			if (onClickToggleBack == null)
			{
				return;
			}
			onClickToggleBack(this.IsEndless, extendToggle, fireEvent);
		}
	}

	// Token: 0x040049B8 RID: 18872
	private bool IsEndless;
}
