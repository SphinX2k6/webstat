using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CE6 RID: 7398
public class GachaDiscountTimesItem : UiPanelBase
{
	// Token: 0x0600D904 RID: 55556 RVA: 0x003A2170 File Offset: 0x003A0370
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D905 RID: 55557 RVA: 0x003A221C File Offset: 0x003A041C
	[NullableContext(1)]
	public void Refresh(GachaDiscountInfo info)
	{
		int usedTimes = info.UsedTimes;
		int limitTimes = info.LimitTimes;
		int num = Math.Max(0, limitTimes - usedTimes);
		bool flag = num > 0;
		int num2 = (info.Times > 0) ? info.Times : 1;
		int num3 = num / num2;
		base.GetSprite(1).SetUIActive(flag);
		base.GetSprite(0).SetUIActive(!flag);
		UUIText text = base.GetText(2);
		UUIText text2 = base.GetText(3);
		text.useChangeColor = flag;
		text2.useChangeColor = flag;
		string text3 = (info.Times == 1) ? "DiscountCount_1" : ((info.Times == 10) ? "DiscountCount_2" : "");
		if (!string.IsNullOrEmpty(text3))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, text3, Array.Empty<object>());
		}
		else
		{
			text.SetText("", true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "DiscountCount_Num", new <>z__ReadOnlySingleElementList<object>(num3.ToString()));
	}

	// Token: 0x0200803A RID: 32826
	private enum EComponent
	{
		// Token: 0x0402B9EA RID: 178666
		SpritePointDisable,
		// Token: 0x0402B9EB RID: 178667
		SpritePointActive,
		// Token: 0x0402B9EC RID: 178668
		TextDescription,
		// Token: 0x0402B9ED RID: 178669
		TextValue
	}
}
