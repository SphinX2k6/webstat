using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002481 RID: 9345
internal class PhantomConfigEditToggle : UiPanelBase
{
	// Token: 0x06012232 RID: 74290 RVA: 0x004FC500 File Offset: 0x004FA700
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickedToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06012233 RID: 74291 RVA: 0x004FC5A8 File Offset: 0x004FA7A8
	protected override void OnStart()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.PhantomBattleConfigApplyPlanWhenSaved) as ServerStorageBoolean;
		EToggleState state = ((serverStorageBoolean != null) ? serverStorageBoolean.Get() : null).GetValueOrDefault() ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, true);
	}

	// Token: 0x06012234 RID: 74292 RVA: 0x004FC600 File Offset: 0x004FA800
	private void OnClickedToggle(EToggleState state)
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.PhantomBattleConfigApplyPlanWhenSaved) as ServerStorageBoolean;
		bool valueOrDefault = ((serverStorageBoolean != null) ? serverStorageBoolean.Get() : null).GetValueOrDefault();
		if (serverStorageBoolean != null)
		{
			serverStorageBoolean.Set(new bool?(!valueOrDefault));
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(valueOrDefault ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x02008799 RID: 34713
	private enum EToggle
	{
		// Token: 0x0402DD73 RID: 187763
		Toggle,
		// Token: 0x0402DD74 RID: 187764
		Txt
	}
}
