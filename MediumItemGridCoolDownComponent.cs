using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019B8 RID: 6584
public class MediumItemGridCoolDownComponent : MediumItemGridComponent
{
	// Token: 0x0600BD1D RID: 48413 RVA: 0x00323300 File Offset: 0x00321500
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

	// Token: 0x0600BD1E RID: 48414 RVA: 0x0032336C File Offset: 0x0032156C
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IMediumItemGridCoolDownComponentParams mediumItemGridCoolDownComponentParams = data as IMediumItemGridCoolDownComponentParams;
		if (mediumItemGridCoolDownComponentParams == null)
		{
			return;
		}
		float? coolDown = mediumItemGridCoolDownComponentParams.CoolDown;
		float? totalCdTime = mediumItemGridCoolDownComponentParams.TotalCdTime;
		if (coolDown == null || coolDown.Value == 0f || totalCdTime == null || totalCdTime.Value == 0f)
		{
			this.SetActive(false);
			return;
		}
		UUISprite sprite = base.GetSprite(0);
		if (sprite != null)
		{
			sprite.SetFillAmount(coolDown.Value / totalCdTime.Value);
		}
		this.SetActive(true);
		UUIText text = base.GetText(1);
		if (coolDown.Value < (float)ModelBase<MediumItemGridModel>.Instance.ItemGridCoolDownSecond)
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

	// Token: 0x0600BD1F RID: 48415 RVA: 0x003234CF File Offset: 0x003216CF
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemCD";
	}

	// Token: 0x0600BD20 RID: 48416 RVA: 0x003234D6 File Offset: 0x003216D6
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CBA RID: 31930
	private class EChildType
	{
		// Token: 0x0402A95C RID: 174428
		public const int CoolDownPercentSprite = 0;

		// Token: 0x0402A95D RID: 174429
		public const int CoolDownText = 1;
	}
}
