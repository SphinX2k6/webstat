using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02001A1B RID: 6683
public class SmallItemGridCoolDownComponent : SmallItemGridComponent
{
	// Token: 0x0600BFD5 RID: 49109 RVA: 0x0032BD58 File Offset: 0x00329F58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BFD6 RID: 49110 RVA: 0x0032BDC4 File Offset: 0x00329FC4
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		ISmallItemGridCoolDownComponentParams smallItemGridCoolDownComponentParams = (ISmallItemGridCoolDownComponentParams)tempData;
		float? coolDown = smallItemGridCoolDownComponentParams.CoolDown;
		float? totalCdTime = smallItemGridCoolDownComponentParams.TotalCdTime;
		if (coolDown == null || totalCdTime == null)
		{
			this.SetActive(false);
			return;
		}
		base.GetSprite(0).SetFillAmount(coolDown.Value / totalCdTime.Value);
		this.SetActive(true);
		UUIText text = base.GetText(1);
		if (coolDown.Value < (float)ModelBase<SmallItemGridModel>.Instance.ItemGridCoolDownSecond)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ItemCdTime_Second", new <>z__ReadOnlySingleElementList<object>(coolDown.Value.ToString("F1")));
			return;
		}
		int timeValue = Singleton<TimeUtil>.Instance.CalculateRemainingTime((double)coolDown.Value, CommonDefine.ETimeType.Minute).TimeValue;
		if ((double)coolDown.Value < Singleton<TimeUtil>.Instance.Hour)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ItemCdTime_Minute", new <>z__ReadOnlySingleElementList<object>(timeValue));
			return;
		}
		if (coolDown.Value < (float)Singleton<TimeUtil>.Instance.OneDaySeconds)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ItemCdTime_Hour", new <>z__ReadOnlySingleElementList<object>(timeValue));
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "ItemCdTime_Day", new <>z__ReadOnlySingleElementList<object>(timeValue));
	}

	// Token: 0x0600BFD7 RID: 49111 RVA: 0x0032BEFB File Offset: 0x0032A0FB
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBCD";
	}

	// Token: 0x0600BFD8 RID: 49112 RVA: 0x0032BF02 File Offset: 0x0032A102
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CF6 RID: 31990
	private enum EChildType
	{
		// Token: 0x0402AA07 RID: 174599
		CoolDownPercentSprite,
		// Token: 0x0402AA08 RID: 174600
		CoolDownText
	}
}
