using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200122A RID: 4650
public class BabelTowerTeamSelectPanel : UiPanelBase
{
	// Token: 0x06007BB2 RID: 31666 RVA: 0x00206ED4 File Offset: 0x002050D4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007BB3 RID: 31667 RVA: 0x00206F40 File Offset: 0x00205140
	protected override void OnStart()
	{
		this.TeamScroll = new GenericScrollViewNew<BabelTowerPreTeamItem, EditFormationData>(base.GetScrollViewWithScrollbar(0), new Func<BabelTowerPreTeamItem>(this.CreateTeamItem), null, false, null);
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			this.EmptyStateItem = item;
			this.EmptyStateItem.SetUIActive(false);
		}
	}

	// Token: 0x06007BB4 RID: 31668 RVA: 0x00206F8C File Offset: 0x0020518C
	public void RefreshTeamList()
	{
		this.SelectedTeamIndex = -1;
		this.TeamList = ModelBase<BabelTowerModel>.Instance.GetPresetTeamList();
		GenericScrollViewNew<BabelTowerPreTeamItem, EditFormationData> teamScroll = this.TeamScroll;
		if (teamScroll != null)
		{
			teamScroll.RefreshByData(this.TeamList, delegate
			{
				this.UpdateAllSelection();
			}, true);
		}
		UUIItem emptyStateItem = this.EmptyStateItem;
		if (emptyStateItem == null)
		{
			return;
		}
		emptyStateItem.SetUIActive(this.TeamList.Count <= 0);
	}

	// Token: 0x06007BB5 RID: 31669 RVA: 0x00206FF5 File Offset: 0x002051F5
	[NullableContext(1)]
	private BabelTowerPreTeamItem CreateTeamItem()
	{
		return new BabelTowerPreTeamItem
		{
			OnClickCallback = delegate(EditFormationData formationData, int index)
			{
				this.SelectedTeamIndex = index;
				this.UpdateAllSelection();
				Action<EditFormationData> onTeamSelect = this.OnTeamSelect;
				if (onTeamSelect == null)
				{
					return;
				}
				onTeamSelect(formationData);
			}
		};
	}

	// Token: 0x06007BB6 RID: 31670 RVA: 0x00207010 File Offset: 0x00205210
	private void UpdateAllSelection()
	{
		GenericScrollViewNew<BabelTowerPreTeamItem, EditFormationData> teamScroll = this.TeamScroll;
		List<BabelTowerPreTeamItem> list = (teamScroll != null) ? teamScroll.GetScrollItemList() : null;
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			BabelTowerPreTeamItem babelTowerPreTeamItem = list[i];
			bool selected = i == this.SelectedTeamIndex;
			babelTowerPreTeamItem.ForceSetSelected(selected);
		}
	}

	// Token: 0x04003B35 RID: 15157
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EditFormationData> OnTeamSelect;

	// Token: 0x04003B36 RID: 15158
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<BabelTowerPreTeamItem, EditFormationData> TeamScroll;

	// Token: 0x04003B37 RID: 15159
	[Nullable(1)]
	private List<EditFormationData> TeamList = new List<EditFormationData>();

	// Token: 0x04003B38 RID: 15160
	[Nullable(2)]
	private UUIItem EmptyStateItem;

	// Token: 0x04003B39 RID: 15161
	private int SelectedTeamIndex = -1;

	// Token: 0x02007591 RID: 30097
	private class EComp
	{
		// Token: 0x040288F2 RID: 166130
		public const int TeamScrollView = 0;

		// Token: 0x040288F3 RID: 166131
		public const int EmptyState = 1;
	}
}
