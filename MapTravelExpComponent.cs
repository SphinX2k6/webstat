using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200138C RID: 5004
internal class MapTravelExpComponent : UiPanelBase
{
	// Token: 0x06008996 RID: 35222 RVA: 0x002431B0 File Offset: 0x002413B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06008997 RID: 35223 RVA: 0x0024323C File Offset: 0x0024143C
	public void SetProgress(int current, int target, bool isMax)
	{
		if (isMax)
		{
			base.GetSprite(1).SetFillAmount(1f);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MapTravelLevelMax_Text", Array.Empty<object>());
			return;
		}
		base.GetSprite(1).SetFillAmount(Singleton<MathUtils>.Instance.Clamp((float)current / (float)target, 0f, 1f));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "MapTravelExp_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			current,
			target
		}));
	}

	// Token: 0x06008998 RID: 35224 RVA: 0x002432D1 File Offset: 0x002414D1
	public void SetLevel(int level)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "MapTravelLv_Text", new <>z__ReadOnlySingleElementList<object>(level));
	}

	// Token: 0x0200772A RID: 30506
	private class EExpComponents
	{
		// Token: 0x04029087 RID: 168071
		public const int TxtLevel = 0;

		// Token: 0x04029088 RID: 168072
		public const int ExpRing = 1;

		// Token: 0x04029089 RID: 168073
		public const int ExpProgress = 2;
	}
}
