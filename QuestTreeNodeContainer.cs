using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026BD RID: 9917
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class QuestTreeNodeContainer : QuestTreeNodeItemBase<List<QuestTreeNodeData>>
{
	// Token: 0x170018BA RID: 6330
	// (get) Token: 0x060138D4 RID: 80084 RVA: 0x00573398 File Offset: 0x00571598
	public override EQuestTreeNodeType Type
	{
		get
		{
			return EQuestTreeNodeType.Container;
		}
	}

	// Token: 0x060138D5 RID: 80085 RVA: 0x0057339C File Offset: 0x0057159C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060138D6 RID: 80086 RVA: 0x0057348C File Offset: 0x0057168C
	protected override void OnStart()
	{
		this.ItemPool = new QuestTreeNodeItemPool(base.Loader, base.GetItem(2));
		Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "QuestTreePictureNodeItem", ETickingGroup.TG_PrePhysics, true, 0, true);
		this.TickId = ((ticker != null) ? ticker.Id : -1);
	}

	// Token: 0x060138D7 RID: 80087 RVA: 0x005734E2 File Offset: 0x005716E2
	protected override void OnBeforeDestroy()
	{
		this.ItemPool.ClearPool();
		if (this.TickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.TickId);
			this.TickId = -1;
		}
	}

	// Token: 0x060138D8 RID: 80088 RVA: 0x00573510 File Offset: 0x00571710
	public override void Refresh(List<QuestTreeNodeData> data, bool isSelected, int gridIndex)
	{
		this.RefreshAsync(data, isSelected, gridIndex);
	}

	// Token: 0x060138D9 RID: 80089 RVA: 0x0057351C File Offset: 0x0057171C
	public override UniTask RefreshAsync(List<QuestTreeNodeData> data, bool isSelected, int gridIndex)
	{
		QuestTreeNodeContainer.<RefreshAsync>d__11 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.data = data;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<QuestTreeNodeContainer.<RefreshAsync>d__11>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060138DA RID: 80090 RVA: 0x00573567 File Offset: 0x00571767
	public override void UpdateData(QuestTreeNodeData data)
	{
	}

	// Token: 0x060138DB RID: 80091 RVA: 0x00573569 File Offset: 0x00571769
	public override void UpdateDataList(List<QuestTreeNodeData> data)
	{
	}

	// Token: 0x060138DC RID: 80092 RVA: 0x0057356C File Offset: 0x0057176C
	public override UniTask CreateSelf(UUIItem parent)
	{
		QuestTreeNodeContainer.<CreateSelf>d__14 <CreateSelf>d__;
		<CreateSelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateSelf>d__.<>4__this = this;
		<CreateSelf>d__.parent = parent;
		<CreateSelf>d__.<>1__state = -1;
		<CreateSelf>d__.<>t__builder.Start<QuestTreeNodeContainer.<CreateSelf>d__14>(ref <CreateSelf>d__);
		return <CreateSelf>d__.<>t__builder.Task;
	}

	// Token: 0x060138DD RID: 80093 RVA: 0x005735B8 File Offset: 0x005717B8
	public override float GetAdditionalHeight()
	{
		IQuestTreeNodeItem itemByData = this.ItemPool.GetItemByData(this.Data[0]);
		if (itemByData != null)
		{
			return Math.Max(itemByData.GetAdditionalHeight() - base.GetItem(2).GetHeight(), 0f);
		}
		return 0f;
	}

	// Token: 0x060138DE RID: 80094 RVA: 0x00573604 File Offset: 0x00571804
	private void OnTick(float delta)
	{
		float additionalHeight = this.GetAdditionalHeight();
		this.LayoutMargin.Bottom = additionalHeight;
		base.GetVerticalLayout(0).SetPadding(this.LayoutMargin);
	}

	// Token: 0x0400984C RID: 38988
	private QuestTreeNodeItemPool ItemPool;

	// Token: 0x0400984D RID: 38989
	private List<QuestTreeNodeData> Data = new List<QuestTreeNodeData>();

	// Token: 0x0400984E RID: 38990
	private int TickId = -1;

	// Token: 0x0400984F RID: 38991
	private FMargin LayoutMargin = new FMargin(0f, 0f, 0f, 0f);

	// Token: 0x02008A5A RID: 35418
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EA60 RID: 191072
		public const int LayoutSelf = 0;

		// Token: 0x0402EA61 RID: 191073
		public const int ItemLayoutUp = 1;

		// Token: 0x0402EA62 RID: 191074
		public const int ItemContainer = 2;

		// Token: 0x0402EA63 RID: 191075
		public const int ItemLineTypeA = 3;

		// Token: 0x0402EA64 RID: 191076
		public const int ItemLineTypeB = 4;

		// Token: 0x0402EA65 RID: 191077
		public const int ItemLayoutDown = 5;
	}
}
