using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020018B5 RID: 6325
public class CommonConditionFilterItem : UiPanelBase
{
	// Token: 0x0600B5CA RID: 46538 RVA: 0x00305E6B File Offset: 0x0030406B
	[NullableContext(1)]
	public CommonConditionFilterItem(UUIItem uiItem, QualityInfo qualityInfo)
	{
		this.QualityInfo = qualityInfo;
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0600B5CB RID: 46539 RVA: 0x00305E88 File Offset: 0x00304088
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B5CC RID: 46540 RVA: 0x00305F2E File Offset: 0x0030412E
	private void ToggleClick(EToggleState state)
	{
		if (this.ToggleFunction != null)
		{
			this.ToggleFunction(this.QualityInfo.Id, this.QualityInfo.ConsumeFilterText);
		}
	}

	// Token: 0x0600B5CD RID: 46541 RVA: 0x00305F59 File Offset: 0x00304159
	protected override void OnStart()
	{
		base.GetText(1).ShowTextNew(this.QualityInfo.ConsumeFilterText);
	}

	// Token: 0x0600B5CE RID: 46542 RVA: 0x00305F74 File Offset: 0x00304174
	public void SetToggleState(bool bSelected, bool bFire = true)
	{
		EToggleState state = bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
	}

	// Token: 0x0600B5CF RID: 46543 RVA: 0x00305F9A File Offset: 0x0030419A
	[NullableContext(1)]
	public void SetToggleFunction(TCommonConditionFilterItemFunction toggleFunction)
	{
		this.ToggleFunction = toggleFunction;
	}

	// Token: 0x0600B5D0 RID: 46544 RVA: 0x00305FA3 File Offset: 0x003041A3
	public QualityInfo GetQualityInfo()
	{
		return this.QualityInfo;
	}

	// Token: 0x040055A3 RID: 21923
	[Nullable(2)]
	protected TCommonConditionFilterItemFunction ToggleFunction;

	// Token: 0x040055A4 RID: 21924
	protected QualityInfo QualityInfo;

	// Token: 0x02007C39 RID: 31801
	private class ECommonConditionFilterItem
	{
		// Token: 0x0402A6C8 RID: 173768
		public const int Toggle = 0;

		// Token: 0x0402A6C9 RID: 173769
		public const int Text = 1;
	}
}
