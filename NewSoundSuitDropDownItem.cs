using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02001755 RID: 5973
public class NewSoundSuitDropDownItem : DropDownItemBase<int>
{
	// Token: 0x0600A7F2 RID: 42994 RVA: 0x002CB8F4 File Offset: 0x002C9AF4
	[NullableContext(1)]
	public NewSoundSuitDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x0600A7F3 RID: 42995 RVA: 0x002CB900 File Offset: 0x002C9B00
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
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x0600A7F4 RID: 42996 RVA: 0x002CB9D7 File Offset: 0x002C9BD7
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600A7F5 RID: 42997 RVA: 0x002CB9FE File Offset: 0x002C9BFE
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0600A7F6 RID: 42998 RVA: 0x002CBA08 File Offset: 0x002C9C08
	protected override void OnShowDropDownItemBase(int data)
	{
		this.VisionFetterSuitItem = new VisionFetterSuitItem(base.GetItem(2));
		this.VisionFetterSuitItem.Init();
		string newText;
		if (data > 0)
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data).FetterGroupName, null) ?? "");
		}
		else
		{
			newText = (ConfigMultiTextLang.GetLocalTextNew("Text_FilterTextAllVisionFetter_Text", null) ?? "");
		}
		base.GetText(1).SetText(newText, true);
		bool flag = true;
		if (flag)
		{
			PhantomFetterGroup? fetterGroupData = (data > 0) ? new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data)) : null;
			this.VisionFetterSuitItem.Update(fetterGroupData);
		}
		this.VisionFetterSuitItem.SetActive(flag);
	}

	// Token: 0x0600A7F7 RID: 42999 RVA: 0x002CBAC7 File Offset: 0x002C9CC7
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04004F41 RID: 20289
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x02007ABA RID: 31418
	private enum EComponent
	{
		// Token: 0x0402A0A8 RID: 172200
		TogOption,
		// Token: 0x0402A0A9 RID: 172201
		TxtOption,
		// Token: 0x0402A0AA RID: 172202
		SuitElementItem,
		// Token: 0x0402A0AB RID: 172203
		CurrentNumText,
		// Token: 0x0402A0AC RID: 172204
		LikeItem
	}
}
