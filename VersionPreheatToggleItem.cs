using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200162C RID: 5676
internal class VersionPreheatToggleItem : UiPanelBase
{
	// Token: 0x0600A004 RID: 40964 RVA: 0x0029D55C File Offset: 0x0029B75C
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.HandleOnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A005 RID: 40965 RVA: 0x0029D604 File Offset: 0x0029B804
	private void HandleOnClick(EToggleState toggleState)
	{
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.VersionPreheatOnClickVote, this.PassData.ClickPassData);
		VersionPreheatVoteToggleData passData = this.PassData;
		passData.ClickFunc(passData.Id, passData.ClickPassData).Forget();
	}

	// Token: 0x0600A006 RID: 40966 RVA: 0x0029D64F File Offset: 0x0029B84F
	[NullableContext(1)]
	public void RefreshExternal(VersionPreheatVoteToggleData data)
	{
		this.PassData = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.ContentTextId, Array.Empty<object>());
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600A007 RID: 40967 RVA: 0x0029D685 File Offset: 0x0029B885
	public void RefreshToggle(bool isChosen)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		extendToggle.SetToggleState(isChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		extendToggle.IsSelfInteractive = false;
	}

	// Token: 0x0600A008 RID: 40968 RVA: 0x0029D6A5 File Offset: 0x0029B8A5
	public void RefreshToggleDirectly(bool isChosen)
	{
		base.GetExtendToggle(0).SetToggleState(isChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0400497C RID: 18812
	[Nullable(1)]
	private VersionPreheatVoteToggleData PassData;

	// Token: 0x020079E9 RID: 31209
	private class EToggleComponent
	{
		// Token: 0x04029DB2 RID: 171442
		public const int RootToggle = 0;

		// Token: 0x04029DB3 RID: 171443
		public const int ContentText = 1;
	}
}
