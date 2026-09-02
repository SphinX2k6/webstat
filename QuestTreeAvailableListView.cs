using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020026B2 RID: 9906
public class QuestTreeAvailableListView : UiViewBase
{
	// Token: 0x06013876 RID: 79990 RVA: 0x005718B1 File Offset: 0x0056FAB1
	[NullableContext(1)]
	public QuestTreeAvailableListView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06013877 RID: 79991 RVA: 0x005718BC File Offset: 0x0056FABC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013878 RID: 79992 RVA: 0x00571948 File Offset: 0x0056FB48
	protected override void OnStart()
	{
		List<QuestTreeNodeData> data = (this.OpenParam as List<QuestTreeNodeData>) ?? new List<QuestTreeNodeData>();
		this.LoopScrollView = new LoopScrollView<QuestTreeAvailableNodeItem, QuestTreeNodeData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, () => new QuestTreeAvailableNodeItem(), false);
		this.LoopScrollView.RefreshByData(data, false, null, false);
	}

	// Token: 0x04009824 RID: 38948
	[Nullable(1)]
	private LoopScrollView<QuestTreeAvailableNodeItem, QuestTreeNodeData> LoopScrollView;

	// Token: 0x02008A46 RID: 35398
	private class EComponentDefine
	{
		// Token: 0x0402E9EF RID: 190959
		public const int LoopScrollView = 0;

		// Token: 0x0402E9F0 RID: 190960
		public const int ItemQuest = 1;

		// Token: 0x0402E9F1 RID: 190961
		public const int TextNum = 2;
	}
}
