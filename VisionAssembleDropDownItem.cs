using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020024E2 RID: 9442
public class VisionAssembleDropDownItem : DropDownItemBase<int>
{
	// Token: 0x06012557 RID: 75095 RVA: 0x0050A14D File Offset: 0x0050834D
	[NullableContext(1)]
	public VisionAssembleDropDownItem(UUIItem uiItem) : base(uiItem)
	{
	}

	// Token: 0x06012558 RID: 75096 RVA: 0x0050A158 File Offset: 0x00508358
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06012559 RID: 75097 RVA: 0x0050A1D3 File Offset: 0x005083D3
	[NullableContext(2)]
	protected override UUIExtendToggle GetDropDownToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x0601255A RID: 75098 RVA: 0x0050A1DC File Offset: 0x005083DC
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
		base.GetText(3).SetText("", true);
		PhantomFetterGroup? fetterGroupData = (data > 0) ? new PhantomFetterGroup?(ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(data)) : null;
		this.VisionFetterSuitItem.Update(fetterGroupData);
		this.VisionFetterSuitItem.SetActive(true);
	}

	// Token: 0x0601255B RID: 75099 RVA: 0x0050A2A0 File Offset: 0x005084A0
	protected override void OnBeforeDestroy()
	{
		VisionFetterSuitItem visionFetterSuitItem = this.VisionFetterSuitItem;
		if (visionFetterSuitItem == null)
		{
			return;
		}
		visionFetterSuitItem.Destroy(null);
	}

	// Token: 0x04008EFA RID: 36602
	[Nullable(2)]
	private VisionFetterSuitItem VisionFetterSuitItem;

	// Token: 0x020087F0 RID: 34800
	private enum EComponent
	{
		// Token: 0x0402DED2 RID: 188114
		TogOption,
		// Token: 0x0402DED3 RID: 188115
		TxtOption,
		// Token: 0x0402DED4 RID: 188116
		SuitElementItem,
		// Token: 0x0402DED5 RID: 188117
		CurrentNumText
	}
}
