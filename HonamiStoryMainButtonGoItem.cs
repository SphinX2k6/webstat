using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F40 RID: 8000
public class HonamiStoryMainButtonGoItem : UiPanelBase
{
	// Token: 0x0600EF64 RID: 61284 RVA: 0x00416A84 File Offset: 0x00414C84
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnEnter));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EF65 RID: 61285 RVA: 0x00416B90 File Offset: 0x00414D90
	public void RefreshButtonState()
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(10112);
		base.GetItem(3).SetUIActive(!flag);
		base.GetItem(4).SetUIActive(flag);
		HonamiStoryActivityData activityData = ModelBase<HonamiStoryModel>.Instance.GetActivityData(true);
		if (activityData == null)
		{
			base.GetItem(2).SetUIActive(false);
			return;
		}
		bool uiactive = activityData.IsLevelSelectHasViewRedDot();
		base.GetItem(2).SetUIActive(uiactive);
	}

	// Token: 0x0600EF66 RID: 61286 RVA: 0x00416BFB File Offset: 0x00414DFB
	[NullableContext(1)]
	public void SetOnBtnEnterCallback(Action callback)
	{
		this.OnBtnEnterCallback = callback;
	}

	// Token: 0x0600EF67 RID: 61287 RVA: 0x00416C04 File Offset: 0x00414E04
	private void OnBtnEnter()
	{
		Action onBtnEnterCallback = this.OnBtnEnterCallback;
		if (onBtnEnterCallback == null)
		{
			return;
		}
		onBtnEnterCallback();
	}

	// Token: 0x04007323 RID: 29475
	[Nullable(2)]
	private Action OnBtnEnterCallback;
}
