using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020013F8 RID: 5112
[NullableContext(1)]
[Nullable(0)]
public class MoonChasingMemoryDetailView : UiViewBase
{
	// Token: 0x06008DA9 RID: 36265 RVA: 0x002536EC File Offset: 0x002518EC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x06008DAA RID: 36266 RVA: 0x00253772 File Offset: 0x00251972
	public MoonChasingMemoryDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008DAB RID: 36267 RVA: 0x0025377C File Offset: 0x0025197C
	protected override void OnStart()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.CloseSelf));
		this.ContentLayoutA = new GenericLayout<MemoryContentItemA, IMemoryItemData>(base.GetGridLayout(1), new Func<MemoryContentItemA>(this.OnCreateContentA), null, false, true);
		this.ContentLayoutB = new GenericLayout<MemoryContentItemB, IMemoryItemData>(base.GetHorizontalLayout(3), new Func<MemoryContentItemB>(this.OnCreateContentB), null, false, true);
	}

	// Token: 0x06008DAC RID: 36268 RVA: 0x002537F8 File Offset: 0x002519F8
	protected override void OnBeforeShow()
	{
		List<IMemoryItemData> list = this.OpenParam as List<IMemoryItemData>;
		if (list == null)
		{
			return;
		}
		List<IMemoryItemData> list2 = new List<IMemoryItemData>();
		foreach (IMemoryItemData memoryItemData in list)
		{
			if (memoryItemData.Classify == EMemoryClassify.Normal)
			{
				list2.Add(memoryItemData);
			}
		}
		this.ContentLayoutA.RefreshByData(list2, null, false);
		List<IMemoryItemData> list3 = new List<IMemoryItemData>();
		foreach (IMemoryItemData memoryItemData2 in list)
		{
			if (memoryItemData2.Classify == EMemoryClassify.Important)
			{
				list3.Add(memoryItemData2);
			}
		}
		this.ContentLayoutB.RefreshByData(list3, null, false);
	}

	// Token: 0x06008DAD RID: 36269 RVA: 0x002538D4 File Offset: 0x00251AD4
	private MemoryContentItemA OnCreateContentA()
	{
		return new MemoryContentItemA();
	}

	// Token: 0x06008DAE RID: 36270 RVA: 0x002538DB File Offset: 0x00251ADB
	private MemoryContentItemB OnCreateContentB()
	{
		return new MemoryContentItemB();
	}

	// Token: 0x04004206 RID: 16902
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004207 RID: 16903
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MemoryContentItemA, IMemoryItemData> ContentLayoutA;

	// Token: 0x04004208 RID: 16904
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MemoryContentItemB, IMemoryItemData> ContentLayoutB;

	// Token: 0x020077E6 RID: 30694
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x04029421 RID: 168993
		public const int Caption = 0;

		// Token: 0x04029422 RID: 168994
		public const int ContentLayoutA = 1;

		// Token: 0x04029423 RID: 168995
		public const int ContentA = 2;

		// Token: 0x04029424 RID: 168996
		public const int ContentLayoutB = 3;

		// Token: 0x04029425 RID: 168997
		public const int ContentB = 4;
	}
}
