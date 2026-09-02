using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200238C RID: 9100
public class BattlePassTaskTabItem : UiPanelBase, IGridProxy<EBattlePassTaskUpdateState>
{
	// Token: 0x1700159C RID: 5532
	// (get) Token: 0x060116EE RID: 71406 RVA: 0x004CE473 File Offset: 0x004CC673
	// (set) Token: 0x060116EF RID: 71407 RVA: 0x004CE47B File Offset: 0x004CC67B
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public IScrollViewDelegate<IGridProxy<EBattlePassTaskUpdateState>, EBattlePassTaskUpdateState> ScrollViewDelegate { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x1700159D RID: 5533
	// (get) Token: 0x060116F0 RID: 71408 RVA: 0x004CE484 File Offset: 0x004CC684
	// (set) Token: 0x060116F1 RID: 71409 RVA: 0x004CE48C File Offset: 0x004CC68C
	public int GridIndex { get; set; }

	// Token: 0x1700159E RID: 5534
	// (get) Token: 0x060116F2 RID: 71410 RVA: 0x004CE495 File Offset: 0x004CC695
	// (set) Token: 0x060116F3 RID: 71411 RVA: 0x004CE49D File Offset: 0x004CC69D
	public int DisplayIndex { get; set; }

	// Token: 0x060116F4 RID: 71412 RVA: 0x004CE4A8 File Offset: 0x004CC6A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060116F5 RID: 71413 RVA: 0x004CE590 File Offset: 0x004CC790
	protected override void OnStart()
	{
		base.GetExtendToggle(2).CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x060116F6 RID: 71414 RVA: 0x004CE5AF File Offset: 0x004CC7AF
	private bool CanExecuteChange()
	{
		Func<int, bool> onCanExecuteChange = this.OnCanExecuteChange;
		return onCanExecuteChange == null || onCanExecuteChange(this.GridIndex);
	}

	// Token: 0x060116F7 RID: 71415 RVA: 0x004CE5C8 File Offset: 0x004CC7C8
	private void ToggleClick(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack == null)
			{
				return;
			}
			selectedCallBack(this.GridIndex);
		}
	}

	// Token: 0x060116F8 RID: 71416 RVA: 0x004CE5E6 File Offset: 0x004CC7E6
	public void SetForceSwitch(EToggleState state, bool bFire = false)
	{
		base.GetExtendToggle(2).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x060116F9 RID: 71417 RVA: 0x004CE5F9 File Offset: 0x004CC7F9
	[NullableContext(1)]
	public void SetSelectedCallBack(Action<int> callback)
	{
		this.SelectedCallBack = callback;
	}

	// Token: 0x060116FA RID: 71418 RVA: 0x004CE602 File Offset: 0x004CC802
	[NullableContext(1)]
	public void SetCanExecuteChange(Func<int, bool> callback)
	{
		this.OnCanExecuteChange = callback;
	}

	// Token: 0x060116FB RID: 71419 RVA: 0x004CE60B File Offset: 0x004CC80B
	public void Refresh(EBattlePassTaskUpdateState data, bool isSelected, int gridIndex)
	{
		this.UpdateView(data);
	}

	// Token: 0x060116FC RID: 71420 RVA: 0x004CE614 File Offset: 0x004CC814
	[NullableContext(1)]
	public object GetKey(EBattlePassTaskUpdateState data, int gridIndex)
	{
		return data;
	}

	// Token: 0x060116FD RID: 71421 RVA: 0x004CE61C File Offset: 0x004CC81C
	public void Clear()
	{
		this.UnBindRedDot();
	}

	// Token: 0x060116FE RID: 71422 RVA: 0x004CE624 File Offset: 0x004CC824
	public void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x060116FF RID: 71423 RVA: 0x004CE626 File Offset: 0x004CC826
	public void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x06011700 RID: 71424 RVA: 0x004CE628 File Offset: 0x004CC828
	public void OnSelected()
	{
	}

	// Token: 0x06011701 RID: 71425 RVA: 0x004CE62A File Offset: 0x004CC82A
	public void OnDeselected()
	{
	}

	// Token: 0x06011702 RID: 71426 RVA: 0x004CE62C File Offset: 0x004CC82C
	public void UpdateView(EBattlePassTaskUpdateState type)
	{
		UUIText text = base.GetText(0);
		BattlePassModel instance = ModelBase<BattlePassModel>.Instance;
		long num = instance.GetBattlePassEndTime();
		switch (type)
		{
		case EBattlePassTaskUpdateState.Always:
			this.RedDotName = new ERedDotName?(ERedDotName.BattlePassAlwaysTaskTab);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_BattlePassAwalsTask_Text", Array.Empty<object>());
			break;
		case EBattlePassTaskUpdateState.EveryDay:
			num = Math.Min(num, instance.GetDayEndTime());
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BattlePassDayTask", Array.Empty<object>());
			this.RedDotName = new ERedDotName?(ERedDotName.BattlePassDayTaskTab);
			break;
		case EBattlePassTaskUpdateState.EveryWeek:
			num = Math.Min(num, instance.GetWeekEndTime());
			Singleton<LguiUtil>.Instance.SetLocalText(text, "BattlePassWeekTask", Array.Empty<object>());
			this.RedDotName = new ERedDotName?(ERedDotName.BattlePassWeekTaskTab);
			break;
		}
		UUIText text2 = base.GetText(1);
		double num2 = Singleton<TimeUtil>.Instance.CalculateHourGapBetweenNow((double)num, true);
		int num3 = (int)Math.Floor(num2 / Singleton<TimeUtil>.Instance.OneDayHourCount);
		int num4 = (int)Math.Floor(num2 - (double)num3 * Singleton<TimeUtil>.Instance.OneDayHourCount);
		if (num3 > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_BattlePassRefreshTime1_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				num3,
				num4
			}));
		}
		else if (num4 > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_BattlePassRefreshTime2_Text", new <>z__ReadOnlySingleElementList<object>(num4));
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "Text_BattlePassRefreshTime3_Text", Array.Empty<object>());
		}
		this.BindRedDot();
	}

	// Token: 0x06011703 RID: 71427 RVA: 0x004CE79D File Offset: 0x004CC99D
	private void BindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, base.GetItem(3), null, 0);
		}
	}

	// Token: 0x06011704 RID: 71428 RVA: 0x004CE7CA File Offset: 0x004CC9CA
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
			this.RedDotName = null;
		}
	}

	// Token: 0x040088E5 RID: 35045
	private ERedDotName? RedDotName;

	// Token: 0x040088E6 RID: 35046
	[Nullable(2)]
	protected Action<int> SelectedCallBack;

	// Token: 0x040088E7 RID: 35047
	[Nullable(2)]
	protected Func<int, bool> OnCanExecuteChange;

	// Token: 0x020086A6 RID: 34470
	private enum EComponents
	{
		// Token: 0x0402D8B2 RID: 186546
		TitleText,
		// Token: 0x0402D8B3 RID: 186547
		TimeText,
		// Token: 0x0402D8B4 RID: 186548
		ExtendToggle,
		// Token: 0x0402D8B5 RID: 186549
		RedDot
	}
}
