using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02000FE0 RID: 4064
[NullableContext(1)]
[Nullable(0)]
public class AchievementGroupDataItem : UiPanelBase
{
	// Token: 0x060068C6 RID: 26822 RVA: 0x001B4CC6 File Offset: 0x001B2EC6
	public AchievementGroupDataItem(UUIItem uiItem)
	{
		this.SourceItem = uiItem;
	}

	// Token: 0x060068C7 RID: 26823 RVA: 0x001B4CD8 File Offset: 0x001B2ED8
	public UniTask Init()
	{
		AchievementGroupDataItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<AchievementGroupDataItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x060068C8 RID: 26824 RVA: 0x001B4D1C File Offset: 0x001B2F1C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060068C9 RID: 26825 RVA: 0x001B4D85 File Offset: 0x001B2F85
	protected override void OnStart()
	{
		this.ScrollView = new LoopScrollView<AchievementDataItem, AchievementData>(base.GetLoopScrollViewComponent(0), (AUIBaseActor)base.GetItem(1).GetOwner(), new Func<AchievementDataItem>(this.CreateItem), false);
	}

	// Token: 0x060068CA RID: 26826 RVA: 0x001B4DB8 File Offset: 0x001B2FB8
	public void Update(AchievementGroupData groupData)
	{
		List<AchievementData> groupAchievements = ModelBase<AchievementModel>.Instance.GetGroupAchievements(groupData.GetId(), true);
		groupAchievements.Sort(ModelBase<AchievementModel>.Instance.SortByTabIndex);
		this.RefreshScroller(groupAchievements);
	}

	// Token: 0x060068CB RID: 26827 RVA: 0x001B4DF0 File Offset: 0x001B2FF0
	private void RefreshScroller(List<AchievementData> dataList)
	{
		this.ScrollView.RefreshByData(dataList, true, null, false);
		if (dataList.Count > 0)
		{
			int selectAchievementIndex = this.GetSelectAchievementIndex(dataList);
			this.ScrollView.ScrollToGridIndex(selectAchievementIndex, true);
		}
	}

	// Token: 0x060068CC RID: 26828 RVA: 0x001B4E2C File Offset: 0x001B302C
	private int GetSelectAchievementIndex(List<AchievementData> dataList)
	{
		if (ModelBase<AchievementModel>.Instance.CurrentSelectAchievementId == -1)
		{
			return 0;
		}
		int result = 0;
		int count = dataList.Count;
		for (int i = 0; i < count; i++)
		{
			if (ModelBase<AchievementModel>.Instance.CurrentSelectAchievementId == dataList[i].GetId())
			{
				result = i;
				break;
			}
		}
		ModelBase<AchievementModel>.Instance.CurrentSelectAchievementId = -1;
		return result;
	}

	// Token: 0x060068CD RID: 26829 RVA: 0x001B4E85 File Offset: 0x001B3085
	private AchievementDataItem CreateItem()
	{
		return new AchievementDataItem();
	}

	// Token: 0x040031D9 RID: 12761
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<AchievementDataItem, AchievementData> ScrollView;

	// Token: 0x040031DA RID: 12762
	[Nullable(2)]
	private readonly UUIItem SourceItem;

	// Token: 0x020073BD RID: 29629
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040280C1 RID: 164033
		ItemScroller,
		// Token: 0x040280C2 RID: 164034
		ItemPrefab
	}
}
