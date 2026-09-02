using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BF2 RID: 11250
public class TowerDetailSwitchItem : UiPanelBase
{
	// Token: 0x0601672A RID: 91946 RVA: 0x0063C152 File Offset: 0x0063A352
	[NullableContext(1)]
	public TowerDetailSwitchItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x0601672B RID: 91947 RVA: 0x0063C168 File Offset: 0x0063A368
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickSwitchToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601672C RID: 91948 RVA: 0x0063C20E File Offset: 0x0063A40E
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetToggleGroup(null);
		extendToggle.CanExecuteChange.Unbind();
		extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
	}

	// Token: 0x0601672D RID: 91949 RVA: 0x0063C23F File Offset: 0x0063A43F
	private bool CanExecuteChange()
	{
		return ModelBase<TowerDetailModel>.Instance.CurrentSelectDetailId != this.TowerSwitchData.Index;
	}

	// Token: 0x0601672E RID: 91950 RVA: 0x0063C25C File Offset: 0x0063A45C
	[NullableContext(1)]
	public void Update(TowerSwitchData data)
	{
		this.TowerSwitchData = data;
		string name = data.Name;
		base.GetText(1).SetText(name, true);
		this.RefreshView();
	}

	// Token: 0x0601672F RID: 91951 RVA: 0x0063C28B File Offset: 0x0063A48B
	private void RefreshView()
	{
		if (ModelBase<TowerDetailModel>.Instance.CurrentSelectDetailId != this.TowerSwitchData.Index)
		{
			base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			return;
		}
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06016730 RID: 91952 RVA: 0x0063C2C5 File Offset: 0x0063A4C5
	private void OnClickSwitchToggle(EToggleState toggleState)
	{
		ModelBase<TowerDetailModel>.Instance.CurrentSelectDetailId = this.TowerSwitchData.Index;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnClickSingleTimeTowerDetailSwitchBtn);
	}

	// Token: 0x0400ADCB RID: 44491
	[Nullable(2)]
	private TowerSwitchData TowerSwitchData;

	// Token: 0x02008EE7 RID: 36583
	private class EChildType
	{
		// Token: 0x0403000D RID: 196621
		public const int SwitchToggle = 0;

		// Token: 0x0403000E RID: 196622
		public const int TitleText = 1;
	}
}
