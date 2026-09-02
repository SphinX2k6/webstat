using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001C70 RID: 7280
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTechGridPanel : UiPanelBase, IGridProxy<List<FloroRanchTechnologyData>>
{
	// Token: 0x17001125 RID: 4389
	// (get) Token: 0x0600D478 RID: 54392 RVA: 0x0038B557 File Offset: 0x00389757
	// (set) Token: 0x0600D479 RID: 54393 RVA: 0x0038B55F File Offset: 0x0038975F
	public IScrollViewDelegate<IGridProxy<List<FloroRanchTechnologyData>>, List<FloroRanchTechnologyData>> ScrollViewDelegate { get; set; }

	// Token: 0x17001126 RID: 4390
	// (get) Token: 0x0600D47A RID: 54394 RVA: 0x0038B568 File Offset: 0x00389768
	// (set) Token: 0x0600D47B RID: 54395 RVA: 0x0038B570 File Offset: 0x00389770
	public int GridIndex { get; set; }

	// Token: 0x17001127 RID: 4391
	// (get) Token: 0x0600D47C RID: 54396 RVA: 0x0038B579 File Offset: 0x00389779
	// (set) Token: 0x0600D47D RID: 54397 RVA: 0x0038B581 File Offset: 0x00389781
	public int DisplayIndex { get; set; }

	// Token: 0x0600D47E RID: 54398 RVA: 0x0038B58C File Offset: 0x0038978C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D47F RID: 54399 RVA: 0x0038B618 File Offset: 0x00389818
	public void Refresh(List<FloroRanchTechnologyData> dataList, bool isSelected, int gridIndex)
	{
		foreach (FloroRanchTechnologyData floroRanchTechnologyData in dataList)
		{
			UUIItem item = base.GetItem(floroRanchTechnologyData.Row);
			FloroRanchTechNodeItem floroRanchTechNodeItem = null;
			if (floroRanchTechnologyData.Row < this.TechNodeItemList.Count)
			{
				floroRanchTechNodeItem = this.TechNodeItemList[floroRanchTechnologyData.Row];
			}
			if (floroRanchTechNodeItem != null)
			{
				floroRanchTechNodeItem.Refresh(null);
			}
			else
			{
				FloroRanchTechNodeItem techNode = new FloroRanchTechNodeItem(item, floroRanchTechnologyData, this.RootItem);
				techNode.CreateThenShowByResourceIdAsync("UiItem_PastureSkillA", item, false).ContinueWith(delegate()
				{
					techNode.OnClickCallback = this.OnSelectTechNode;
					techNode.Refresh(null);
				});
				while (this.TechNodeItemList.Count <= floroRanchTechnologyData.Row)
				{
					this.TechNodeItemList.Add(null);
				}
				this.TechNodeItemList[floroRanchTechnologyData.Row] = techNode;
			}
		}
	}

	// Token: 0x0600D480 RID: 54400 RVA: 0x0038B72C File Offset: 0x0038992C
	public void Clear()
	{
	}

	// Token: 0x0600D481 RID: 54401 RVA: 0x0038B72E File Offset: 0x0038992E
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600D482 RID: 54402 RVA: 0x0038B730 File Offset: 0x00389930
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600D483 RID: 54403 RVA: 0x0038B732 File Offset: 0x00389932
	[return: Nullable(2)]
	public object GetKey(List<FloroRanchTechnologyData> data, int gridIndex)
	{
		return null;
	}

	// Token: 0x04006514 RID: 25876
	private readonly List<FloroRanchTechNodeItem> TechNodeItemList = new List<FloroRanchTechNodeItem>();

	// Token: 0x04006516 RID: 25878
	public Action<FloroRanchTechNodeItem> OnSelectTechNode = delegate(FloroRanchTechNodeItem technologyNode)
	{
	};

	// Token: 0x02007F9A RID: 32666
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B715 RID: 177941
		public const int Pos1 = 0;

		// Token: 0x0402B716 RID: 177942
		public const int Pos2 = 1;

		// Token: 0x0402B717 RID: 177943
		public const int Pos3 = 2;
	}
}
