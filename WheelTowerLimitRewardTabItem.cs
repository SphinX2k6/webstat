using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001685 RID: 5765
public class WheelTowerLimitRewardTabItem : UiPanelBase
{
	// Token: 0x0600A0FB RID: 41211 RVA: 0x002A3854 File Offset: 0x002A1A54
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A0FC RID: 41212 RVA: 0x002A393C File Offset: 0x002A1B3C
	protected override void OnStart()
	{
		UUIExtendToggle toggle = base.GetExtendToggle(0);
		toggle.CanExecuteChange.Bind(() => toggle.ToggleState != EToggleState.ETT_Checked);
		ModelBase<WheelTowerModel>.Instance.ActivityData.RecordReadReward();
	}

	// Token: 0x0600A0FD RID: 41213 RVA: 0x002A3988 File Offset: 0x002A1B88
	public void Refresh(int diff)
	{
		this.Diff = diff;
		bool flag = diff == 1;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(flag ? "WheelBattleMode_Endless" : "WheelBattleMode_Normal");
		}
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		EFilterMode filterMode = flag ? EFilterMode.Endless : EFilterMode.Normal;
		int totalRewardProgress = activityData.GetTotalRewardProgress(filterMode);
		int currentRewardProgress = activityData.GetCurrentRewardProgress(filterMode);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelBattleMode_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			currentRewardProgress,
			totalRewardProgress
		}));
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(activityData.HasAnyRewardCanReceive(filterMode));
	}

	// Token: 0x0600A0FE RID: 41214 RVA: 0x002A3A32 File Offset: 0x002A1C32
	[NullableContext(1)]
	public void SetToggleClickCallback(Action<int, UUIExtendToggle> callback)
	{
		this.ToggleClickCallback = callback;
	}

	// Token: 0x0600A0FF RID: 41215 RVA: 0x002A3A3B File Offset: 0x002A1C3B
	public void SetToggleStateForce(bool isSelected, bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, fireEvent, false, false);
	}

	// Token: 0x0600A100 RID: 41216 RVA: 0x002A3A58 File Offset: 0x002A1C58
	public void OnDeselected(bool fireEvent)
	{
		this.SetToggleStateForce(false, false);
	}

	// Token: 0x0600A101 RID: 41217 RVA: 0x002A3A62 File Offset: 0x002A1C62
	private void OnClickToggle(EToggleState state)
	{
		Action<int, UUIExtendToggle> toggleClickCallback = this.ToggleClickCallback;
		if (toggleClickCallback == null)
		{
			return;
		}
		toggleClickCallback(this.Diff, base.GetExtendToggle(0));
	}

	// Token: 0x04004AD4 RID: 19156
	private int Diff = -1;

	// Token: 0x04004AD5 RID: 19157
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> ToggleClickCallback;
}
