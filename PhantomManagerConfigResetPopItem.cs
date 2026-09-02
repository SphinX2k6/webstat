using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002488 RID: 9352
public class PhantomManagerConfigResetPopItem : UiViewBase
{
	// Token: 0x0601225C RID: 74332 RVA: 0x004FD630 File Offset: 0x004FB830
	[NullableContext(1)]
	public PhantomManagerConfigResetPopItem(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601225D RID: 74333 RVA: 0x004FD63C File Offset: 0x004FB83C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedCancel));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickedConfirm));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action<EToggleState>(this.OnClickedReset1));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action<EToggleState>(this.OnClickedReset2));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601225E RID: 74334 RVA: 0x004FD78D File Offset: 0x004FB98D
	protected override void OnStart()
	{
		base.GetExtendToggle(2).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		this.OnSuccessCb = (this.OpenParam as Action);
	}

	// Token: 0x0601225F RID: 74335 RVA: 0x004FD7B1 File Offset: 0x004FB9B1
	private void OnClickedReset1(EToggleState state)
	{
		base.GetExtendToggle(3).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.CurrentSelectId = 0;
	}

	// Token: 0x06012260 RID: 74336 RVA: 0x004FD7CB File Offset: 0x004FB9CB
	private void OnClickedReset2(EToggleState state)
	{
		base.GetExtendToggle(2).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.CurrentSelectId = 1;
	}

	// Token: 0x06012261 RID: 74337 RVA: 0x004FD7E5 File Offset: 0x004FB9E5
	private void OnClickedCancel()
	{
		base.CloseMe(null);
	}

	// Token: 0x06012262 RID: 74338 RVA: 0x004FD7EE File Offset: 0x004FB9EE
	private void OnClickedConfirm()
	{
		ModelBase<PhantomBattleModel>.Instance.GetPhantomConfigData().ResetAllFetterOpen(this.CurrentSelectId == 1).ContinueWith(delegate(bool value)
		{
			if (value)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomProject_CleanPlan_Des_6", Array.Empty<object>());
				Action onSuccessCb = this.OnSuccessCb;
				if (onSuccessCb != null)
				{
					onSuccessCb();
				}
				base.CloseMe(null);
			}
		}).Forget();
	}

	// Token: 0x04008D9A RID: 36250
	private int CurrentSelectId;

	// Token: 0x04008D9B RID: 36251
	[Nullable(2)]
	private Action OnSuccessCb;

	// Token: 0x020087A1 RID: 34721
	private enum EDefine
	{
		// Token: 0x0402DDA0 RID: 187808
		BtnCancel,
		// Token: 0x0402DDA1 RID: 187809
		BtnConfirm,
		// Token: 0x0402DDA2 RID: 187810
		ResetToggle1,
		// Token: 0x0402DDA3 RID: 187811
		ResetToggle2
	}
}
