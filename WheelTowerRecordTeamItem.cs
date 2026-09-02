using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200165C RID: 5724
public class WheelTowerRecordTeamItem : GridProxyAbstract<int>
{
	// Token: 0x0600A077 RID: 41079 RVA: 0x002A0394 File Offset: 0x0029E594
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A078 RID: 41080 RVA: 0x002A047C File Offset: 0x0029E67C
	protected override void OnStart()
	{
		base.GetExtendToggle(0).bLockStateOnSelect = true;
	}

	// Token: 0x0600A079 RID: 41081 RVA: 0x002A048C File Offset: 0x0029E68C
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		int num = gridIndex + 1;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WheelTower_Team_Name", new <>z__ReadOnlySingleElementList<object>(num));
		this.NumberFirst = num / 10;
		this.NumberSecond = num % 10;
		if (this.NumberFirst == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_Team_Number", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.NumberFirst,
				this.NumberSecond
			}));
		}
		else
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelTower_Team_Score", new <>z__ReadOnlySingleElementList<object>(data));
	}

	// Token: 0x0600A07A RID: 41082 RVA: 0x002A0590 File Offset: 0x0029E790
	public override void OnSelected(bool fireEvent)
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		this.SetToggleState(true);
	}

	// Token: 0x0600A07B RID: 41083 RVA: 0x002A05E4 File Offset: 0x0029E7E4
	public override void OnDeselected(bool fireEvent)
	{
		if (this.NumberFirst == 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_Team_Number", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.NumberFirst,
				this.NumberSecond
			}));
		}
		else
		{
			UUIText text = base.GetText(1);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("<color=#ffffff>");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberFirst);
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.NumberSecond);
				defaultInterpolatedStringHandler.AppendLiteral("</color>");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}
		this.SetToggleState(false);
	}

	// Token: 0x0600A07C RID: 41084 RVA: 0x002A0695 File Offset: 0x0029E895
	private void OnToggleClick(EToggleState state)
	{
		Action<int> onToggleClickCallback = this.OnToggleClickCallback;
		if (onToggleClickCallback == null)
		{
			return;
		}
		onToggleClickCallback(base.GridIndex);
	}

	// Token: 0x0600A07D RID: 41085 RVA: 0x002A06AD File Offset: 0x0029E8AD
	public void SetToggleState(bool state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x04004A17 RID: 18967
	private int NumberFirst;

	// Token: 0x04004A18 RID: 18968
	private int NumberSecond;

	// Token: 0x04004A19 RID: 18969
	[Nullable(2)]
	public Action<int> OnToggleClickCallback;
}
