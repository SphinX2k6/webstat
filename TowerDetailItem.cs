using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002BF1 RID: 11249
public class TowerDetailItem : GridProxyAbstract<int>
{
	// Token: 0x06016723 RID: 91939 RVA: 0x0063BFE8 File Offset: 0x0063A1E8
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
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016724 RID: 91940 RVA: 0x0063C090 File Offset: 0x0063A290
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TowerId = data;
		TowerConfig? towerInfo = ConfigBase<TowerClimbConfig>.Instance.GetTowerInfo(data);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "Text_TowerOnlyFloor_Text", new <>z__ReadOnlySingleElementList<object>(towerInfo.Value.Floor));
		if (data == ModelBase<TowerModel>.Instance.CurrentSelectFloor)
		{
			this.SetToggleState(EToggleState.ETT_Checked);
			return;
		}
		this.SetToggleState(EToggleState.ETT_UnChecked);
	}

	// Token: 0x06016725 RID: 91941 RVA: 0x0063C0FB File Offset: 0x0063A2FB
	[NullableContext(1)]
	public void BindOnClickToggle(Action<int> onClickToggle)
	{
		this.OnClickToggleHandle = onClickToggle;
	}

	// Token: 0x06016726 RID: 91942 RVA: 0x0063C104 File Offset: 0x0063A304
	public void SetToggleState(EToggleState state)
	{
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		if (state == EToggleState.ETT_Checked)
		{
			this.OnClickToggle(state);
		}
	}

	// Token: 0x06016727 RID: 91943 RVA: 0x0063C122 File Offset: 0x0063A322
	private void OnClickToggle(EToggleState toggleState)
	{
		Action<int> onClickToggleHandle = this.OnClickToggleHandle;
		if (onClickToggleHandle == null)
		{
			return;
		}
		onClickToggleHandle(this.TowerId);
	}

	// Token: 0x06016728 RID: 91944 RVA: 0x0063C13A File Offset: 0x0063A33A
	protected override void OnBeforeDestroy()
	{
		this.OnClickToggleHandle = null;
	}

	// Token: 0x0400ADC9 RID: 44489
	[Nullable(2)]
	private Action<int> OnClickToggleHandle;

	// Token: 0x0400ADCA RID: 44490
	private int TowerId = -1;

	// Token: 0x02008EE6 RID: 36582
	private enum EChildType
	{
		// Token: 0x0403000B RID: 196619
		FloorToggle,
		// Token: 0x0403000C RID: 196620
		FloorNumberText
	}
}
