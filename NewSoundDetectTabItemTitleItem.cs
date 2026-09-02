using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using UnrealEngine;

// Token: 0x0200174C RID: 5964
[Nullable(new byte[]
{
	0,
	1
})]
public class NewSoundDetectTabItemTitleItem : SyncGridProxyAbstract<NewSoundDetectTabItemData>
{
	// Token: 0x0600A7CE RID: 42958 RVA: 0x002CAB6C File Offset: 0x002C8D6C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChange))
		};
	}

	// Token: 0x0600A7CF RID: 42959 RVA: 0x002CAC5C File Offset: 0x002C8E5C
	[NullableContext(1)]
	public override void Refresh(NewSoundDetectTabItemData data)
	{
		this.Area = data.Area;
		this.IsVisible = data.IsVisible;
		EToggleState state = data.IsVisible ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.SetToggleState(state, false, false, false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTextId, Array.Empty<object>());
		if (!string.IsNullOrEmpty(data.IconPath))
		{
			this.SetSpriteByPath(data.IconPath, base.GetSprite(2), false, null, null);
		}
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			sprite.SetUIActive(!string.IsNullOrEmpty(data.IconPath));
		}
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(!string.IsNullOrEmpty(data.IconPath));
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(string.IsNullOrEmpty(data.IconPath));
	}

	// Token: 0x0600A7D0 RID: 42960 RVA: 0x002CAD48 File Offset: 0x002C8F48
	private void OnToggleStateChange(EToggleState state)
	{
		if (this.OnClickCallBack != null)
		{
			this.OnClickCallBack(this.Area, !this.IsVisible);
		}
	}

	// Token: 0x04004F37 RID: 20279
	private int Area;

	// Token: 0x04004F38 RID: 20280
	private bool IsVisible;

	// Token: 0x04004F39 RID: 20281
	[Nullable(2)]
	public Action<int, bool> OnClickCallBack;

	// Token: 0x02007AB3 RID: 31411
	private enum ENewSoundDetectTabItemTitleItem
	{
		// Token: 0x0402A088 RID: 172168
		Toggle,
		// Token: 0x0402A089 RID: 172169
		Title,
		// Token: 0x0402A08A RID: 172170
		Icon,
		// Token: 0x0402A08B RID: 172171
		PanelWithIconBg,
		// Token: 0x0402A08C RID: 172172
		PanelNoIconBg
	}
}
