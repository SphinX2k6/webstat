using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200289F RID: 10399
public class StrengthUpgradeBarItem : UiPanelBase
{
	// Token: 0x0601498F RID: 84367 RVA: 0x005B42B9 File Offset: 0x005B24B9
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06014990 RID: 84368 RVA: 0x005B42F2 File Offset: 0x005B24F2
	protected override void OnStart()
	{
		this.LineItemList = new List<UUIItem>();
		this.LineItemList.Add(base.GetItem(1));
	}

	// Token: 0x06014991 RID: 84369 RVA: 0x005B4311 File Offset: 0x005B2511
	[NullableContext(1)]
	public void Update(IStrengthUpgradeData data)
	{
		this.Data = data;
		this.Refresh();
	}

	// Token: 0x06014992 RID: 84370 RVA: 0x005B4320 File Offset: 0x005B2520
	public void Refresh()
	{
		if (this.Data == null)
		{
			return;
		}
		int singleStrengthValue = this.Data.SingleStrengthValue;
		int maxSingleStrengthItemCount = this.Data.MaxSingleStrengthItemCount;
		int num = Math.Min(this.Data.MaxStrength / singleStrengthValue, maxSingleStrengthItemCount);
		this.RefreshLineItem(num);
		base.GetSprite(0).SetFillAmount(1f / (float)num);
	}

	// Token: 0x06014993 RID: 84371 RVA: 0x005B4380 File Offset: 0x005B2580
	private void RefreshLineItem(int count)
	{
		if (this.LineItemList == null)
		{
			return;
		}
		UUIItem item = base.GetItem(1);
		UUIItem parentAsUIItem = item.GetParentAsUIItem();
		for (int i = this.LineItemList.Count; i < count; i++)
		{
			this.LineItemList.Add(Singleton<LguiUtil>.Instance.CopyItem(item, parentAsUIItem));
		}
		float num = 360f / (float)count;
		float num2 = 0f;
		for (int j = 0; j < count; j++)
		{
			UUIItem uuiitem = this.LineItemList[j];
			this.RotationCache.Yaw = num2;
			uuiitem.SetUIRelativeRotation(this.RotationCache);
			num2 += num;
		}
	}

	// Token: 0x04009F2F RID: 40751
	[Nullable(2)]
	private IStrengthUpgradeData Data;

	// Token: 0x04009F30 RID: 40752
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<UUIItem> LineItemList;

	// Token: 0x04009F31 RID: 40753
	private FRotator RotationCache = new FRotator(0f, 0f, 0f);
}
