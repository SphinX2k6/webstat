using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002685 RID: 9861
[NullableContext(1)]
[Nullable(0)]
public class QuestReviewDetailImageItem : UiPanelBase
{
	// Token: 0x06013732 RID: 79666 RVA: 0x0056B167 File Offset: 0x00569367
	public QuestReviewDetailImageItem(QuestReviewNodeData node)
	{
		this.Node = node;
	}

	// Token: 0x06013733 RID: 79667 RVA: 0x0056B178 File Offset: 0x00569378
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013734 RID: 79668 RVA: 0x0056B1E4 File Offset: 0x005693E4
	protected override UniTask OnBeforeStartAsync()
	{
		QuestReviewDetailImageItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestReviewDetailImageItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013735 RID: 79669 RVA: 0x0056B228 File Offset: 0x00569428
	public UniTask RefreshAsync(QuestReviewNodeData node)
	{
		QuestReviewDetailImageItem.<RefreshAsync>d__4 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.node = node;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<QuestReviewDetailImageItem.<RefreshAsync>d__4>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0400979E RID: 38814
	private readonly QuestReviewNodeData Node;

	// Token: 0x02008A21 RID: 35361
	[NullableContext(0)]
	private class EImageItemComponentDefine
	{
		// Token: 0x0402E95B RID: 190811
		public const int BtnSelf = 0;

		// Token: 0x0402E95C RID: 190812
		public const int TextureBg = 1;
	}
}
