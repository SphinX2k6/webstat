using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200249A RID: 9370
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionFetterMonsterItem : GridProxyAbstract<VisionFetterMonsterData>
{
	// Token: 0x060122E4 RID: 74468 RVA: 0x0050087C File Offset: 0x004FEA7C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x060122E5 RID: 74469 RVA: 0x005008D6 File Offset: 0x004FEAD6
	protected override void OnStart()
	{
		this.MonsterLayout = new GenericLayout<VisionDetailMonsterItem, VisionDetailMonsterItemData>(base.GetGridLayout(1), new Func<VisionDetailMonsterItem>(this.InitMonsterItem), null, false, true);
	}

	// Token: 0x060122E6 RID: 74470 RVA: 0x005008F9 File Offset: 0x004FEAF9
	private VisionDetailMonsterItem InitMonsterItem()
	{
		return new VisionDetailMonsterItem();
	}

	// Token: 0x060122E7 RID: 74471 RVA: 0x00500900 File Offset: 0x004FEB00
	public override void Refresh(VisionFetterMonsterData data, bool isSelected, int gridIndex)
	{
		this.RefreshCost(data);
		this.RefreshMonster(data);
	}

	// Token: 0x060122E8 RID: 74472 RVA: 0x00500910 File Offset: 0x004FEB10
	private void RefreshCost(VisionFetterMonsterData data)
	{
		int cost = data.Cost;
		UUIText text = base.GetText(0);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(cost);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}

	// Token: 0x060122E9 RID: 74473 RVA: 0x00500949 File Offset: 0x004FEB49
	private void RefreshMonster(VisionFetterMonsterData data)
	{
		this.MonsterLayout.RefreshByData(data.MonsterList, null, false);
	}

	// Token: 0x04008DEA RID: 36330
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionDetailMonsterItem, VisionDetailMonsterItemData> MonsterLayout;

	// Token: 0x020087BB RID: 34747
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DDFE RID: 187902
		CostText,
		// Token: 0x0402DDFF RID: 187903
		MonsterLayout,
		// Token: 0x0402DE00 RID: 187904
		MonsterItem
	}
}
