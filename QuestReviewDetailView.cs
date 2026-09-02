using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002684 RID: 9860
public class QuestReviewDetailView : UiViewBase
{
	// Token: 0x0601372B RID: 79659 RVA: 0x0056AE6E File Offset: 0x0056906E
	[NullableContext(1)]
	public QuestReviewDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601372C RID: 79660 RVA: 0x0056AE78 File Offset: 0x00569078
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnLeftClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnRightClick));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnBtnCloseClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601372D RID: 79661 RVA: 0x0056B070 File Offset: 0x00569270
	protected override UniTask OnBeforeStartAsync()
	{
		QuestReviewDetailView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestReviewDetailView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601372E RID: 79662 RVA: 0x0056B0B4 File Offset: 0x005692B4
	[NullableContext(1)]
	private UniTask RefreshAsync(QuestReviewNodeData node)
	{
		QuestReviewDetailView.<RefreshAsync>d__6 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.node = node;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<QuestReviewDetailView.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601372F RID: 79663 RVA: 0x0056B100 File Offset: 0x00569300
	private void OnBtnLeftClick()
	{
		QuestReviewNodeData predecessorNodeByNodeId = ModelBase<QuestReviewModel>.Instance.GetPredecessorNodeByNodeId(this.Node.Id);
		if (predecessorNodeByNodeId != null)
		{
			this.RefreshAsync(predecessorNodeByNodeId);
		}
	}

	// Token: 0x06013730 RID: 79664 RVA: 0x0056B130 File Offset: 0x00569330
	private void OnBtnRightClick()
	{
		QuestReviewNodeData successorNodeByNodeId = ModelBase<QuestReviewModel>.Instance.GetSuccessorNodeByNodeId(this.Node.Id);
		if (successorNodeByNodeId != null)
		{
			this.RefreshAsync(successorNodeByNodeId);
		}
	}

	// Token: 0x06013731 RID: 79665 RVA: 0x0056B15E File Offset: 0x0056935E
	private void OnBtnCloseClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400979C RID: 38812
	[Nullable(2)]
	private QuestReviewNodeData Node;

	// Token: 0x0400979D RID: 38813
	[Nullable(2)]
	private QuestReviewDetailImageItem ImageItem;

	// Token: 0x02008A1E RID: 35358
	private class EComponentDefine
	{
		// Token: 0x0402E948 RID: 190792
		public const int ItemImage = 0;

		// Token: 0x0402E949 RID: 190793
		public const int DraggableViewport = 1;

		// Token: 0x0402E94A RID: 190794
		public const int BtnLeft = 2;

		// Token: 0x0402E94B RID: 190795
		public const int BtnRight = 3;

		// Token: 0x0402E94C RID: 190796
		public const int BtnClose = 4;

		// Token: 0x0402E94D RID: 190797
		public const int ScrollDesc = 5;

		// Token: 0x0402E94E RID: 190798
		public const int TextDesc = 6;

		// Token: 0x0402E94F RID: 190799
		public const int TextBrief = 7;

		// Token: 0x0402E950 RID: 190800
		public const int TextName = 8;

		// Token: 0x0402E951 RID: 190801
		public const int ItemBrief = 9;
	}
}
