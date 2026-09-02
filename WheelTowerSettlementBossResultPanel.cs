using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001693 RID: 5779
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerSettlementBossResultPanel : UiPanelBase
{
	// Token: 0x0600A126 RID: 41254 RVA: 0x002A4D74 File Offset: 0x002A2F74
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

	// Token: 0x0600A127 RID: 41255 RVA: 0x002A4DDD File Offset: 0x002A2FDD
	protected override void OnStart()
	{
		this.BossScrollView = new GenericScrollViewNew<WheelTowerSettlementBossItem, IBossItemData>(base.GetScrollViewWithScrollbar(0), new Func<WheelTowerSettlementBossItem>(this.CreateBossItem), null, false, null);
	}

	// Token: 0x0600A128 RID: 41256 RVA: 0x002A4E00 File Offset: 0x002A3000
	public void Refresh(List<IBossItemData> bossList)
	{
		GenericScrollViewNew<WheelTowerSettlementBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView == null)
		{
			return;
		}
		bossScrollView.RefreshByData(bossList, null, true);
	}

	// Token: 0x0600A129 RID: 41257 RVA: 0x002A4E15 File Offset: 0x002A3015
	public void SetBossScrollEnable(bool canScroll)
	{
		GenericScrollViewNew<WheelTowerSettlementBossItem, IBossItemData> bossScrollView = this.BossScrollView;
		if (bossScrollView == null)
		{
			return;
		}
		bossScrollView.SetVerticalScrollEnable(canScroll);
	}

	// Token: 0x0600A12A RID: 41258 RVA: 0x002A4E28 File Offset: 0x002A3028
	private WheelTowerSettlementBossItem CreateBossItem()
	{
		return new WheelTowerSettlementBossItem();
	}

	// Token: 0x04004B12 RID: 19218
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<WheelTowerSettlementBossItem, IBossItemData> BossScrollView;
}
