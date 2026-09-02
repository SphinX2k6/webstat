using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C7C RID: 7292
[NullableContext(1)]
[Nullable(0)]
public class FragmentedCluesView : UiViewBase
{
	// Token: 0x0600D50D RID: 54541 RVA: 0x0038DC94 File Offset: 0x0038BE94
	public FragmentedCluesView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600D50E RID: 54542 RVA: 0x0038DCA0 File Offset: 0x0038BEA0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnLeftBtnClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnRightBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D50F RID: 54543 RVA: 0x0038DDED File Offset: 0x0038BFED
	private void RevertCurrentPageSelect()
	{
		this.CurrentDotData[this.CurrentPageIndex] = false;
	}

	// Token: 0x0600D510 RID: 54544 RVA: 0x0038DE01 File Offset: 0x0038C001
	private void OnLeftBtnClick()
	{
		this.RevertCurrentPageSelect();
		this.CurrentPageIndex--;
		if (this.CurrentPageIndex < 0)
		{
			this.CurrentPageIndex = 0;
		}
		this.RefreshView();
	}

	// Token: 0x0600D511 RID: 54545 RVA: 0x0038DE2D File Offset: 0x0038C02D
	private void OnRightBtnClick()
	{
		this.RevertCurrentPageSelect();
		this.CurrentPageIndex++;
		if (this.CurrentPageIndex > this.PageMax - 1)
		{
			this.CurrentPageIndex = this.PageMax - 1;
		}
		this.RefreshView();
	}

	// Token: 0x0600D512 RID: 54546 RVA: 0x0038DE67 File Offset: 0x0038C067
	protected override void OnStart()
	{
		this.DotLayout = new GenericLayout<MemoryPageDot, bool>(base.GetHorizontalLayout(0), new Func<MemoryPageDot>(this.CreateDot), null, false, true);
	}

	// Token: 0x0600D513 RID: 54547 RVA: 0x0038DE8A File Offset: 0x0038C08A
	private MemoryPageDot CreateDot()
	{
		return new MemoryPageDot();
	}

	// Token: 0x0600D514 RID: 54548 RVA: 0x0038DE94 File Offset: 0x0038C094
	protected override void OnBeforeShow()
	{
		this.CurrentOpenTopic = (this.OpenParam as FragmentMemoryCollectData);
		int count = this.CurrentOpenTopic.GetClueContent().Count;
		this.CurrentDotData = new List<bool>(count);
		for (int i = 0; i < count; i++)
		{
			this.CurrentDotData[i] = false;
		}
		this.PageMax = this.CurrentDotData.Count;
		this.CurrentPageIndex = 0;
		this.CurrentDotData[this.CurrentPageIndex] = true;
		this.RefreshView();
	}

	// Token: 0x0600D515 RID: 54549 RVA: 0x0038DF18 File Offset: 0x0038C118
	private void RefreshView()
	{
		this.RefreshPageDotLayout();
		this.RefreshTexture();
		this.RefreshName();
		this.RefreshDescription();
		this.RefreshRightBtn();
		this.RefreshLeftBtn();
	}

	// Token: 0x0600D516 RID: 54550 RVA: 0x0038DF40 File Offset: 0x0038C140
	private string GetPageIndexTexture(int index)
	{
		return this.CurrentOpenTopic.GetClueContent()[index].Texture;
	}

	// Token: 0x0600D517 RID: 54551 RVA: 0x0038DF68 File Offset: 0x0038C168
	private string GetPageIndexDescription(int index)
	{
		return this.CurrentOpenTopic.GetClueContent()[index].Desc;
	}

	// Token: 0x0600D518 RID: 54552 RVA: 0x0038DF90 File Offset: 0x0038C190
	private void RefreshName()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), this.CurrentOpenTopic.GetClueEntrance().Title, Array.Empty<object>());
	}

	// Token: 0x0600D519 RID: 54553 RVA: 0x0038DFC6 File Offset: 0x0038C1C6
	private void RefreshDescription()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), this.GetPageIndexDescription(this.CurrentPageIndex), Array.Empty<object>());
	}

	// Token: 0x0600D51A RID: 54554 RVA: 0x0038DFEC File Offset: 0x0038C1EC
	private void RefreshRightBtn()
	{
		bool selfInteractive = this.CurrentPageIndex < this.PageMax - 1;
		UUIButtonComponent button = base.GetButton(5);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(selfInteractive);
	}

	// Token: 0x0600D51B RID: 54555 RVA: 0x0038E01C File Offset: 0x0038C21C
	private void RefreshLeftBtn()
	{
		bool selfInteractive = this.CurrentPageIndex > 0;
		UUIButtonComponent button = base.GetButton(4);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(selfInteractive);
	}

	// Token: 0x0600D51C RID: 54556 RVA: 0x0038E048 File Offset: 0x0038C248
	private void RefreshTexture()
	{
		string pageIndexTexture = this.GetPageIndexTexture(this.CurrentPageIndex);
		base.SetTextureByPath(pageIndexTexture, base.GetTexture(1), null, null);
	}

	// Token: 0x0600D51D RID: 54557 RVA: 0x0038E07A File Offset: 0x0038C27A
	private void RefreshPageDotLayout()
	{
		this.CurrentDotData[this.CurrentPageIndex] = true;
		this.DotLayout.RefreshByData(this.CurrentDotData, null, false);
	}

	// Token: 0x0400653E RID: 25918
	private List<bool> CurrentDotData;

	// Token: 0x0400653F RID: 25919
	[Nullable(2)]
	private FragmentMemoryCollectData CurrentOpenTopic;

	// Token: 0x04006540 RID: 25920
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<MemoryPageDot, bool> DotLayout;

	// Token: 0x04006541 RID: 25921
	private int CurrentPageIndex;

	// Token: 0x04006542 RID: 25922
	private int PageMax;

	// Token: 0x02007FCC RID: 32716
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B7EE RID: 178158
		public const int PageDotLayout = 0;

		// Token: 0x0402B7EF RID: 178159
		public const int Texture = 1;

		// Token: 0x0402B7F0 RID: 178160
		public const int TextContent = 2;

		// Token: 0x0402B7F1 RID: 178161
		public const int TextName = 3;

		// Token: 0x0402B7F2 RID: 178162
		public const int LeftBtn = 4;

		// Token: 0x0402B7F3 RID: 178163
		public const int RightBtn = 5;
	}
}
