using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001907 RID: 6407
[NullableContext(1)]
[Nullable(0)]
public class FilterItem : UiPanelBase
{
	// Token: 0x0600B7EC RID: 47084 RVA: 0x0030E752 File Offset: 0x0030C952
	public FilterItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B7ED RID: 47085 RVA: 0x0030E768 File Offset: 0x0030C968
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleEvent));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B7EE RID: 47086 RVA: 0x0030E871 File Offset: 0x0030CA71
	private void ToggleEvent(EToggleState state)
	{
		TFilterItemToggleEvent toggleFunction = this.ToggleFunction;
		if (toggleFunction == null)
		{
			return;
		}
		toggleFunction(state, this.Data.FilterId, this.Data.Content);
	}

	// Token: 0x0600B7EF RID: 47087 RVA: 0x0030E89C File Offset: 0x0030CA9C
	private void SetContent()
	{
		string content = this.Data.Content;
		base.GetText(4).SetText(content, true);
	}

	// Token: 0x0600B7F0 RID: 47088 RVA: 0x0030E8C4 File Offset: 0x0030CAC4
	private void SetIcon()
	{
		string iconPath = this.Data.GetIconPath();
		UUIItem item = base.GetItem(1);
		if (StringUtils.IsBlank(iconPath))
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		bool flag = iconPath.Contains("Atlas");
		UUITexture texture = base.GetTexture(2);
		texture.SetUIActive(!flag);
		UUISprite sprite = base.GetSprite(3);
		sprite.SetUIActive(flag);
		FColor? fcolor;
		if (flag)
		{
			this.SetSpriteByPath(iconPath, sprite, false, null, null);
			UUIItem uuiitem = sprite;
			bool needChangeColor = this.Data.NeedChangeColor;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(needChangeColor, fcolor);
			return;
		}
		base.SetTextureByPath(iconPath, texture, null, null);
		UUIItem uuiitem2 = texture;
		bool needChangeColor2 = this.Data.NeedChangeColor;
		fcolor = new FColor?(texture.changeColor);
		uuiitem2.SetChangeColor(needChangeColor2, fcolor);
	}

	// Token: 0x0600B7F1 RID: 47089 RVA: 0x0030E999 File Offset: 0x0030CB99
	public void SetToggleFunction(TFilterItemToggleEvent toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B7F2 RID: 47090 RVA: 0x0030E9A4 File Offset: 0x0030CBA4
	public void SetToggleState(bool bSelected)
	{
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x0600B7F3 RID: 47091 RVA: 0x0030E9CA File Offset: 0x0030CBCA
	public void ShowTemp(FilterItemData data, bool bSelected)
	{
		this.Data = data;
		this.SetContent();
		this.SetIcon();
		this.SetToggleState(bSelected);
	}

	// Token: 0x040056B5 RID: 22197
	[Nullable(2)]
	private FilterItemData Data;

	// Token: 0x040056B6 RID: 22198
	[Nullable(2)]
	private TFilterItemToggleEvent ToggleFunction;

	// Token: 0x02007C56 RID: 31830
	[NullableContext(0)]
	private enum EFilterItemDefine
	{
		// Token: 0x0402A781 RID: 173953
		Toggle,
		// Token: 0x0402A782 RID: 173954
		IconRoot,
		// Token: 0x0402A783 RID: 173955
		Icon,
		// Token: 0x0402A784 RID: 173956
		Sprite,
		// Token: 0x0402A785 RID: 173957
		Content
	}
}
