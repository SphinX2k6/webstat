using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BEF RID: 11247
[NullableContext(1)]
[Nullable(0)]
public class TowerDetailInformationMonsterItem : UiPanelBase
{
	// Token: 0x06016717 RID: 91927 RVA: 0x0063BD35 File Offset: 0x00639F35
	public TowerDetailInformationMonsterItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06016718 RID: 91928 RVA: 0x0063BD4C File Offset: 0x00639F4C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016719 RID: 91929 RVA: 0x0063BDD6 File Offset: 0x00639FD6
	protected override void OnStart()
	{
		base.GetItem(1).SetUIParent(base.GetGridLayout(2).GetRootComponent(), false);
		this.MonsterLayout = new GenericLayoutNew<TowerDetailInformationMonsterSubItem>(base.GetGridLayout(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TowerDetailInformationMonsterSubItem>(this.CreateMonsterItem), null);
	}

	// Token: 0x0601671A RID: 91930 RVA: 0x0063BE10 File Offset: 0x0063A010
	private ILayoutItem<TowerDetailInformationMonsterSubItem> CreateMonsterItem(object tempData, UUIItem uiItem, int index)
	{
		TowerDetailMonster towerDetailMonster = (TowerDetailMonster)tempData;
		TowerDetailInformationMonsterSubItem towerDetailInformationMonsterSubItem = new TowerDetailInformationMonsterSubItem(uiItem);
		towerDetailInformationMonsterSubItem.Update(towerDetailMonster.MonsterId, towerDetailMonster.ShowLevel);
		return new LayoutItem<TowerDetailInformationMonsterSubItem>
		{
			Key = index,
			Value = towerDetailInformationMonsterSubItem
		};
	}

	// Token: 0x0601671B RID: 91931 RVA: 0x0063BE55 File Offset: 0x0063A055
	public void Update(TowerDetailMonsterData data, ETowerDetailInformationType showType)
	{
		this.MonsterData = data;
		this.RefreshView();
	}

	// Token: 0x0601671C RID: 91932 RVA: 0x0063BE64 File Offset: 0x0063A064
	private void RefreshView()
	{
		List<TowerDetailMonster> monsterInfos = this.MonsterData.MonsterInfos;
		this.MonsterLayout.RebuildLayoutByDataNew<TowerDetailMonster>(monsterInfos, null);
	}

	// Token: 0x0601671D RID: 91933 RVA: 0x0063BE92 File Offset: 0x0063A092
	protected override void OnBeforeDestroy()
	{
		this.MonsterLayout.ClearChildren();
	}

	// Token: 0x0400ADC5 RID: 44485
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutNew<TowerDetailInformationMonsterSubItem> MonsterLayout;

	// Token: 0x0400ADC6 RID: 44486
	[Nullable(2)]
	private TowerDetailMonsterData MonsterData;

	// Token: 0x02008EE4 RID: 36580
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x04030002 RID: 196610
		public const int TitleText = 0;

		// Token: 0x04030003 RID: 196611
		public const int MonsterItem = 1;

		// Token: 0x04030004 RID: 196612
		public const int MonsterScroller = 2;
	}
}
