using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002027 RID: 8231
[NullableContext(1)]
[Nullable(0)]
public class DestroyPreviewView : UiViewBase
{
	// Token: 0x0600FA3B RID: 64059 RVA: 0x00448A88 File Offset: 0x00446C88
	public DestroyPreviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600FA3C RID: 64060 RVA: 0x00448B50 File Offset: 0x00446D50
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600FA3D RID: 64061 RVA: 0x00448C40 File Offset: 0x00446E40
	protected override UniTask OnBeforeStartAsync()
	{
		DestroyPreviewView.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DestroyPreviewView.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600FA3E RID: 64062 RVA: 0x00448C84 File Offset: 0x00446E84
	protected override void OnAfterShow()
	{
		if (this.HasResultItem)
		{
			this.UiViewSequence.PlaySequence("Notice", false, null);
		}
	}

	// Token: 0x0600FA3F RID: 64063 RVA: 0x00448CB3 File Offset: 0x00446EB3
	private DestroyPreviewGrid CreateItemGrid()
	{
		return new DestroyPreviewGrid();
	}

	// Token: 0x0600FA40 RID: 64064 RVA: 0x00448CBC File Offset: 0x00446EBC
	private void ReSizeLoopScrollView(int itemCount, UUILoopScrollViewComponent loopScrollView)
	{
		int num = 630;
		int num2 = 525;
		if (itemCount < this.layoutSize.Length)
		{
			num = this.layoutSize[itemCount].Item1;
			num2 = this.layoutSize[itemCount].Item2;
		}
		loopScrollView.RootUIComp.Get().SetWidth((float)num);
		loopScrollView.RootUIComp.Get().SetHeight((float)num2);
	}

	// Token: 0x0600FA41 RID: 64065 RVA: 0x00448D30 File Offset: 0x00446F30
	private void RequestDecomposeItem()
	{
		List<DecomposeItemInfo> list = new List<DecomposeItemInfo>();
		foreach (TItem titem in this.DestroyItemList)
		{
			DecomposeItemInfo decomposeItemInfo = DecomposeItemInfo.Create();
			decomposeItemInfo.ItemId = titem.ItemData.ItemId;
			decomposeItemInfo.IncrId = titem.ItemData.IncId;
			decomposeItemInfo.Count = titem.Count;
			list.Add(decomposeItemInfo);
		}
		ControllerBase<InventoryController>.Instance.ItemDestructRequest(list.ToArray());
	}

	// Token: 0x04007823 RID: 30755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<DestroyPreviewGrid, TItem> OriginScrollView;

	// Token: 0x04007824 RID: 30756
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<DestroyPreviewGrid, TItem> ResultScrollView;

	// Token: 0x04007825 RID: 30757
	private List<TItem> DestroyItemList = new List<TItem>();

	// Token: 0x04007826 RID: 30758
	[Nullable(2)]
	private ButtonItem ButtonLeft;

	// Token: 0x04007827 RID: 30759
	[Nullable(2)]
	private ButtonItem ButtonRight;

	// Token: 0x04007828 RID: 30760
	private bool HasResultItem;

	// Token: 0x04007829 RID: 30761
	private const int GRID_SIZE = 210;

	// Token: 0x0400782A RID: 30762
	private const int GRID_NORMAL_WIDTH_SIZE = 630;

	// Token: 0x0400782B RID: 30763
	private const int GRID_NORMAL_HEIGHT_SIZE = 525;

	// Token: 0x0400782C RID: 30764
	[Nullable(new byte[]
	{
		1,
		0
	})]
	private readonly ValueTuple<int, int>[] layoutSize = new ValueTuple<int, int>[]
	{
		new ValueTuple<int, int>(630, 525),
		new ValueTuple<int, int>(210, 210),
		new ValueTuple<int, int>(420, 210),
		new ValueTuple<int, int>(630, 210),
		new ValueTuple<int, int>(630, 420),
		new ValueTuple<int, int>(630, 420),
		new ValueTuple<int, int>(630, 420)
	};

	// Token: 0x020083CD RID: 33741
	[NullableContext(0)]
	private enum EDestroyPreviewNode
	{
		// Token: 0x0402CAF3 RID: 183027
		LoopScrollViewLeft,
		// Token: 0x0402CAF4 RID: 183028
		LoopScrollViewRight,
		// Token: 0x0402CAF5 RID: 183029
		ItemGrid,
		// Token: 0x0402CAF6 RID: 183030
		TextNone,
		// Token: 0x0402CAF7 RID: 183031
		ButtonLeft,
		// Token: 0x0402CAF8 RID: 183032
		ButtonRight
	}
}
