using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002687 RID: 9863
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class QuestReviewLineItem : GridProxyAbstract<QuestReviewLineData>
{
	// Token: 0x0601374B RID: 79691 RVA: 0x0056BAF0 File Offset: 0x00569CF0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601374C RID: 79692 RVA: 0x0056BB59 File Offset: 0x00569D59
	protected override void OnStart()
	{
		this.LayoutLine = new GenericLayout<QuestReviewNodeItem, QuestReviewNodeParam>(base.GetHorizontalLayout(0), new Func<QuestReviewNodeItem>(this.CreateNodeItem), null, false, true);
	}

	// Token: 0x0601374D RID: 79693 RVA: 0x0056BB7C File Offset: 0x00569D7C
	public override void Refresh(QuestReviewLineData data, bool isSelected, int gridIndex)
	{
		if (!ModelBase<QuestReviewModel>.Instance.IsQuestLineHasAnyVisibleNode(data.Id))
		{
			base.GetRootItem().SetUIActive(false);
			return;
		}
		base.GetRootItem().SetUIActive(true);
		if (data.IsTempLine)
		{
			this.LayoutLine.RefreshByData(new List<QuestReviewNodeParam>(), null, false);
			return;
		}
		List<int> nodeIdListByQuestLineId = ModelBase<QuestReviewModel>.Instance.GetNodeIdListByQuestLineId(data.Id);
		List<QuestReviewNodeParam> list = new List<QuestReviewNodeParam>();
		bool flag = ModelBase<QuestReviewModel>.Instance.HasQuestLineFused();
		for (int i = 0; i < nodeIdListByQuestLineId.Count; i++)
		{
			int num = nodeIdListByQuestLineId[i];
			QuestReviewNodeData questReviewNodeDataById = ModelBase<QuestReviewModel>.Instance.GetQuestReviewNodeDataById(num);
			bool isLastSlotEmpty = i > 0 && (nodeIdListByQuestLineId[i - 1] == 0 || !ModelBase<QuestReviewModel>.Instance.IsNodeVisible(nodeIdListByQuestLineId[i - 1]));
			bool isDestroy = data.IsDestroy;
			bool flag2 = ModelBase<QuestReviewModel>.Instance.IsNodeVisible(num);
			bool shouldHide = questReviewNodeDataById == null || !flag2;
			for (int j = i + 1; j < nodeIdListByQuestLineId.Count; j++)
			{
				int num2 = nodeIdListByQuestLineId[j];
				if (num2 != 0 && ModelBase<QuestReviewModel>.Instance.IsNodeVisible(num2))
				{
					shouldHide = false;
					break;
				}
			}
			if (num == 3604 && !flag)
			{
				shouldHide = true;
			}
			QuestReviewNodeParam item = new QuestReviewNodeParam
			{
				Data = questReviewNodeDataById,
				IsLastSlotEmpty = isLastSlotEmpty,
				IsDestroy = isDestroy,
				IsLastSlot = (i == nodeIdListByQuestLineId.Count - 1),
				LineColorHex = data.LineColorHex,
				StarIcon = data.StarIcon,
				RoundIcon = data.RoundIcon,
				LineId = data.Id,
				ShouldHide = shouldHide,
				SlotIndex = i
			};
			list.Add(item);
		}
		this.LayoutLine.RefreshByData(list, null, false);
		TimerSystem.Instance.Next(delegate(float _)
		{
			if (data.IsShow)
			{
				data.IsFirstTimeShow = false;
			}
			if (data.IsDestroy)
			{
				data.IsFirstTimeDestroy = false;
			}
			if (data.SkipAnim)
			{
				data.SkipAnim = false;
			}
		}, null, null);
	}

	// Token: 0x0601374E RID: 79694 RVA: 0x0056BD95 File Offset: 0x00569F95
	private QuestReviewNodeItem CreateNodeItem()
	{
		return new QuestReviewNodeItem();
	}

	// Token: 0x040097A5 RID: 38821
	private GenericLayout<QuestReviewNodeItem, QuestReviewNodeParam> LayoutLine;

	// Token: 0x02008A29 RID: 35369
	[NullableContext(0)]
	private class EQuestLineComponentDefine
	{
		// Token: 0x0402E979 RID: 190841
		public const int LayoutSelf = 0;

		// Token: 0x0402E97A RID: 190842
		public const int ItemNode = 1;
	}
}
