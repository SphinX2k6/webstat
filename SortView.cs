using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.FilterSort.Sort.AttributeSort;
using CSharpScript.Game.Module.FilterSort.Sort.BaseSortGroup;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001958 RID: 6488
[NullableContext(2)]
[Nullable(0)]
public class SortView : UiViewBase
{
	// Token: 0x0600BA10 RID: 47632 RVA: 0x00318C34 File Offset: 0x00316E34
	[NullableContext(1)]
	public SortView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600BA11 RID: 47633 RVA: 0x00318C40 File Offset: 0x00316E40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.ResetView)),
			new ValueTuple<int, Delegate>(1, new Action(this.SaveDataAndCloseView))
		};
	}

	// Token: 0x0600BA12 RID: 47634 RVA: 0x00318CEB File Offset: 0x00316EEB
	private void ResetView()
	{
		this.BaseSortGroup.Reset();
		this.AttributeSortGroup.Reset();
	}

	// Token: 0x0600BA13 RID: 47635 RVA: 0x00318D04 File Offset: 0x00316F04
	private void SaveDataAndCloseView()
	{
		SortResultData sortResultData = ModelBase<SortModel>.Instance.GetSortResultData(this.ViewData.UniqueId);
		ValueTuple<int, string>? tempSelect = this.BaseSortGroup.GetTempSelect();
		sortResultData.SetSelectBaseSort(new SortViewBaseSort(tempSelect.Value.Item1, tempSelect.Value.Item2));
		sortResultData.SetSelectAttributeSort(this.AttributeSortGroup.GetTempSelectMap());
		Action confirmFunction = this.ViewData.ConfirmFunction;
		if (confirmFunction != null)
		{
			confirmFunction();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600BA14 RID: 47636 RVA: 0x00318D82 File Offset: 0x00316F82
	protected override void OnStart()
	{
		this.BaseSortGroup = new BaseSortGroup(base.GetItem(2));
		this.AttributeSortGroup = new AttributeSortGroup(base.GetItem(3));
		this.ViewData = (this.OpenParam as SortViewData);
		this.InitSort();
	}

	// Token: 0x0600BA15 RID: 47637 RVA: 0x00318DBF File Offset: 0x00316FBF
	protected override void OnBeforeDestroy()
	{
		this.BaseSortGroup.Destroy(null);
		this.AttributeSortGroup.Destroy(null);
	}

	// Token: 0x0600BA16 RID: 47638 RVA: 0x00318DD9 File Offset: 0x00316FD9
	private void InitSort()
	{
		this.BaseSortGroup.Init(this.ViewData.UniqueId);
		this.AttributeSortGroup.Init(this.ViewData.UniqueId);
	}

	// Token: 0x040057EB RID: 22507
	private BaseSortGroup BaseSortGroup;

	// Token: 0x040057EC RID: 22508
	private AttributeSortGroup AttributeSortGroup;

	// Token: 0x040057ED RID: 22509
	private SortViewData ViewData;

	// Token: 0x02007C75 RID: 31861
	[NullableContext(0)]
	private static class ECompDefine
	{
		// Token: 0x0402A814 RID: 174100
		public const int ClearButton = 0;

		// Token: 0x0402A815 RID: 174101
		public const int ConfirmButton = 1;

		// Token: 0x0402A816 RID: 174102
		public const int BaseLayoutItem = 2;

		// Token: 0x0402A817 RID: 174103
		public const int AttributeLayoutItem = 3;
	}
}
