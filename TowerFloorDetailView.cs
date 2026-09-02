using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BF4 RID: 11252
[NullableContext(1)]
[Nullable(0)]
public class TowerFloorDetailView : UiViewBase
{
	// Token: 0x06016735 RID: 91957 RVA: 0x0063C3C4 File Offset: 0x0063A5C4
	public TowerFloorDetailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016736 RID: 91958 RVA: 0x0063C3D0 File Offset: 0x0063A5D0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIGridLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016737 RID: 91959 RVA: 0x0063C47C File Offset: 0x0063A67C
	protected override void OnStart()
	{
		int currentSelectDifficulties = ModelBase<TowerModel>.Instance.CurrentSelectDifficulties;
		this.FloorLayout = new GenericLayout<TowerDetailItem, int>(base.GetHorizontalLayout(0), new Func<TowerDetailItem>(this.InitFloorItem), null, false, true);
		this.BuffShowLayout = new GenericLayout<TowerBuffShowItem, long>(base.GetVerticalLayout(1), new Func<TowerBuffShowItem>(this.InitBuffItem), null, false, true);
		this.TargetStarLayout = new GenericLayout<TowerStarsComplexItem, ValueTuple<bool, TowerTarget>>(base.GetVerticalLayout(2), new Func<TowerStarsComplexItem>(this.InitTargetStarItem), null, false, true);
		this.MonsterLayout = new GenericLayout<TowerMonsterItem, int>(base.GetGridLayout(3), new Func<TowerMonsterItem>(this.InitMonsterItem), null, false, true);
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(ModelBase<TowerModel>.Instance.CurrentSelectFloor);
		int[] difficultyAreaAllFloor = ModelBase<TowerModel>.Instance.GetDifficultyAreaAllFloor(currentSelectDifficulties, towerInfo.Value.AreaNum);
		this.FloorLayout.RefreshByData(difficultyAreaAllFloor.ToList<int>(), null, false);
	}

	// Token: 0x06016738 RID: 91960 RVA: 0x0063C55C File Offset: 0x0063A75C
	protected override void OnBeforeDestroy()
	{
		this.FloorLayout.ClearChildren();
		this.FloorLayout = null;
		this.BuffShowLayout.ClearChildren();
		this.BuffShowLayout = null;
		this.TargetStarLayout.ClearChildren();
		this.TargetStarLayout = null;
		this.MonsterLayout.ClearChildren();
		this.MonsterLayout = null;
	}

	// Token: 0x06016739 RID: 91961 RVA: 0x0063C5B1 File Offset: 0x0063A7B1
	private TowerDetailItem InitFloorItem()
	{
		TowerDetailItem towerDetailItem = new TowerDetailItem();
		towerDetailItem.BindOnClickToggle(new Action<int>(this.RefreshView));
		return towerDetailItem;
	}

	// Token: 0x0601673A RID: 91962 RVA: 0x0063C5CA File Offset: 0x0063A7CA
	private TowerBuffShowItem InitBuffItem()
	{
		return new TowerBuffShowItem();
	}

	// Token: 0x0601673B RID: 91963 RVA: 0x0063C5D1 File Offset: 0x0063A7D1
	private TowerStarsComplexItem InitTargetStarItem()
	{
		return new TowerStarsComplexItem();
	}

	// Token: 0x0601673C RID: 91964 RVA: 0x0063C5D8 File Offset: 0x0063A7D8
	private TowerMonsterItem InitMonsterItem()
	{
		return new TowerMonsterItem();
	}

	// Token: 0x0601673D RID: 91965 RVA: 0x0063C5E0 File Offset: 0x0063A7E0
	private void RefreshView(int towerId)
	{
		TowerConfig value = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(towerId).Value;
		this.BuffShowLayout.RefreshByData(value.ShowBuffs().ToList<long>(), null, false);
		int instanceId = value.InstanceId;
		int levelText = ConfigBase<InstanceDungeonConfig>.Instance.GetRecommendLevel(instanceId, ModelBase<WorldLevelModel>.Instance.CurWorldLevel);
		this.MonsterLayout.RefreshByData(value.ShowMonsters().ToList<int>(), delegate
		{
			foreach (TowerMonsterItem towerMonsterItem in this.MonsterLayout.GetLayoutItemList())
			{
				towerMonsterItem.SetLevelText(levelText);
			}
		}, false);
		List<ValueTuple<bool, TowerTarget>> list = new List<ValueTuple<bool, TowerTarget>>();
		List<int> floorStarsIndex = ModelBase<TowerModel>.Instance.GetFloorStarsIndex(towerId);
		IReadOnlyList<int> readOnlyList = value.TargetConfig();
		for (int i = 0; i < 3; i++)
		{
			if (i < readOnlyList.Count)
			{
				TowerTarget? targetConfig = ConfigBase<TowerClimbConfig>.Instance.GetTargetConfig(readOnlyList[i]);
				ValueTuple<bool, TowerTarget> item = new ValueTuple<bool, TowerTarget>(floorStarsIndex != null && floorStarsIndex.Contains(i), targetConfig.Value);
				list.Add(item);
			}
		}
		this.TargetStarLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0400ADCC RID: 44492
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerDetailItem, int> FloorLayout;

	// Token: 0x0400ADCD RID: 44493
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerBuffShowItem, long> BuffShowLayout;

	// Token: 0x0400ADCE RID: 44494
	[Nullable(new byte[]
	{
		2,
		1,
		0
	})]
	private GenericLayout<TowerStarsComplexItem, ValueTuple<bool, TowerTarget>> TargetStarLayout;

	// Token: 0x0400ADCF RID: 44495
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TowerMonsterItem, int> MonsterLayout;

	// Token: 0x02008EE9 RID: 36585
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04030013 RID: 196627
		FloorLayout,
		// Token: 0x04030014 RID: 196628
		ShowBuffLayout,
		// Token: 0x04030015 RID: 196629
		TargetStarLayout,
		// Token: 0x04030016 RID: 196630
		MonsterLayout
	}
}
