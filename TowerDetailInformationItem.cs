using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BEE RID: 11246
[NullableContext(1)]
[Nullable(0)]
public class TowerDetailInformationItem : UiPanelBase
{
	// Token: 0x0601670F RID: 91919 RVA: 0x0063BB58 File Offset: 0x00639D58
	public TowerDetailInformationItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06016710 RID: 91920 RVA: 0x0063BB70 File Offset: 0x00639D70
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06016711 RID: 91921 RVA: 0x0063BC1B File Offset: 0x00639E1B
	protected override void OnStart()
	{
		this.BuffItem = new TowerDetailInformationBuffItem(base.GetItem(1));
		this.MonsterItem = new TowerDetailInformationMonsterItem(base.GetItem(2));
	}

	// Token: 0x06016712 RID: 91922 RVA: 0x0063BC41 File Offset: 0x00639E41
	private void HideAllView()
	{
		base.GetItem(1).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
	}

	// Token: 0x06016713 RID: 91923 RVA: 0x0063BC60 File Offset: 0x00639E60
	public void Update(TowerInformationData data)
	{
		this.HideAllView();
		if (data.Type == ETowerDetailInformationType.Buff)
		{
			base.GetItem(1).SetUIActive(true);
			this.BuffItem.Update(data.TowerDetailBuffData);
		}
		else
		{
			base.GetItem(2).SetUIActive(true);
			this.MonsterItem.Update(data.MonsterData, data.Type);
		}
		this.RefreshAttributeText(data);
		this.RefreshAttributeItem(data.Type);
	}

	// Token: 0x06016714 RID: 91924 RVA: 0x0063BCD2 File Offset: 0x00639ED2
	protected override void OnBeforeDestroy()
	{
		this.MonsterItem.Destroy(null);
		this.MonsterItem = null;
		this.BuffItem.Destroy(null);
		this.BuffItem = null;
	}

	// Token: 0x06016715 RID: 91925 RVA: 0x0063BCFA File Offset: 0x00639EFA
	private void RefreshAttributeText(TowerInformationData data)
	{
		base.GetText(0).SetText(data.Title, true);
	}

	// Token: 0x06016716 RID: 91926 RVA: 0x0063BD10 File Offset: 0x00639F10
	private void RefreshAttributeItem(ETowerDetailInformationType type)
	{
		bool uiactive = false;
		if (type == ETowerDetailInformationType.Buff || type == ETowerDetailInformationType.Monster)
		{
			uiactive = true;
		}
		base.GetItem(3).SetUIActive(uiactive);
	}

	// Token: 0x0400ADC3 RID: 44483
	[Nullable(2)]
	private TowerDetailInformationBuffItem BuffItem;

	// Token: 0x0400ADC4 RID: 44484
	[Nullable(2)]
	private TowerDetailInformationMonsterItem MonsterItem;

	// Token: 0x02008EE3 RID: 36579
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402FFFE RID: 196606
		public const int AttirbuteText = 0;

		// Token: 0x0402FFFF RID: 196607
		public const int BuffItem = 1;

		// Token: 0x04030000 RID: 196608
		public const int MonsterItem = 2;

		// Token: 0x04030001 RID: 196609
		public const int AttributeItem = 3;
	}
}
