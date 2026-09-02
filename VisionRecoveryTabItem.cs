using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200180D RID: 6157
public class VisionRecoveryTabItem : GridProxyAbstract<EVisionRecoveryTabViewType>
{
	// Token: 0x0600AF14 RID: 44820 RVA: 0x002EA0A4 File Offset: 0x002E82A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600AF15 RID: 44821 RVA: 0x002EA10B File Offset: 0x002E830B
	public override void Refresh(EVisionRecoveryTabViewType data, bool isSelected, int gridIndex)
	{
		this.Type = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), CalabashDefine.visionRecoveryTabViewTypeName[this.Type], Array.Empty<object>());
	}

	// Token: 0x0600AF16 RID: 44822 RVA: 0x002EA13A File Offset: 0x002E833A
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<EVisionRecoveryTabViewType, UUIExtendToggle> onClickToggleCallBack = this.OnClickToggleCallBack;
		if (onClickToggleCallBack == null)
		{
			return;
		}
		onClickToggleCallBack(this.Type, base.GetExtendToggle(0));
	}

	// Token: 0x0600AF17 RID: 44823 RVA: 0x002EA159 File Offset: 0x002E8359
	public void SelectToggle()
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, true, false, false);
	}

	// Token: 0x0400530C RID: 21260
	private EVisionRecoveryTabViewType Type;

	// Token: 0x0400530D RID: 21261
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<EVisionRecoveryTabViewType, UUIExtendToggle> OnClickToggleCallBack;

	// Token: 0x02007B89 RID: 31625
	private enum EComponent
	{
		// Token: 0x0402A39A RID: 172954
		Toggle,
		// Token: 0x0402A39B RID: 172955
		NameText
	}
}
