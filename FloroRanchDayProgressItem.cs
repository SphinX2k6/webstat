using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001C52 RID: 7250
public class FloroRanchDayProgressItem : UiPanelBase
{
	// Token: 0x0600D391 RID: 54161 RVA: 0x003866E8 File Offset: 0x003848E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D392 RID: 54162 RVA: 0x00386793 File Offset: 0x00384993
	protected override void OnStart()
	{
		this.PointLayout = new GenericLayout<PointItem, IProgressItem>(base.GetHorizontalLayout(2), new Func<PointItem>(this.CreatePointItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600D393 RID: 54163 RVA: 0x003867C6 File Offset: 0x003849C6
	[NullableContext(1)]
	private PointItem CreatePointItem()
	{
		return new PointItem();
	}

	// Token: 0x0600D394 RID: 54164 RVA: 0x003867D0 File Offset: 0x003849D0
	public void RefreshDay(int remindDay, long maxDay)
	{
		List<IProgressItem> list = new List<IProgressItem>();
		int num = 1;
		while ((long)num <= maxDay)
		{
			list.Add(new ProgressItem
			{
				DayIndex = num,
				IsPassed = ((long)num < maxDay - (long)remindDay + 1L)
			});
			num++;
		}
		GenericLayout<PointItem, IProgressItem> pointLayout = this.PointLayout;
		if (pointLayout == null)
		{
			return;
		}
		pointLayout.RefreshByData(list, delegate
		{
			float fillAmount = 100f / (float)(maxDay - 1L) * (float)(remindDay - 1) / 100f;
			UUISprite sprite = this.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetFillAmount(fillAmount);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.GetText(0), "Farm_DayLast", new <>z__ReadOnlySingleElementList<object>(remindDay));
		}, false);
	}

	// Token: 0x040064BB RID: 25787
	[Nullable(1)]
	private GenericLayout<PointItem, IProgressItem> PointLayout;

	// Token: 0x02007F62 RID: 32610
	private class EComponentDefine
	{
		// Token: 0x0402B5F0 RID: 177648
		public const int DayText = 0;

		// Token: 0x0402B5F1 RID: 177649
		public const int ProgressSprite = 1;

		// Token: 0x0402B5F2 RID: 177650
		public const int PointLayout = 2;

		// Token: 0x0402B5F3 RID: 177651
		public const int PointItem = 3;
	}
}
