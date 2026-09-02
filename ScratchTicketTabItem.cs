using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015A6 RID: 5542
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ScratchTicketTabItem : GridProxyAbstract<ScratchTicketRoundData>
{
	// Token: 0x06009C13 RID: 39955 RVA: 0x0028D7EC File Offset: 0x0028B9EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickTabToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009C14 RID: 39956 RVA: 0x0028D8D4 File Offset: 0x0028BAD4
	protected override void OnBeforeCreateImplement()
	{
		this.UiLevelSequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.UiLevelSequence);
		base.GetExtendToggle(0).CanExecuteChange.Bind(() => base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_UnChecked);
	}

	// Token: 0x06009C15 RID: 39957 RVA: 0x0028D90C File Offset: 0x0028BB0C
	public override void Refresh(ScratchTicketRoundData data, bool isSelected, int gridIndex)
	{
		this.RoundData = data;
		this.SetSpriteByPath(data.Config.Value.TogRoundIcon, base.GetSprite(1), false, null, null);
		EScratchTicketRoundState roundState = data.GetRoundState();
		base.GetItem(2).SetUIActive(roundState == EScratchTicketRoundState.Lock);
		base.GetItem(3).SetUIActive(roundState == EScratchTicketRoundState.Finish);
	}

	// Token: 0x06009C16 RID: 39958 RVA: 0x0028D974 File Offset: 0x0028BB74
	public void SetSelect(bool state, bool isFireEvent)
	{
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleStateForce(state2, isFireEvent, false, false);
	}

	// Token: 0x06009C17 RID: 39959 RVA: 0x0028D999 File Offset: 0x0028BB99
	private void OnClickTabToggle(EToggleState toggleState)
	{
		Action<ScratchTicketRoundData, ScratchTicketTabItem> clickToggleCallBack = this.ClickToggleCallBack;
		if (clickToggleCallBack == null)
		{
			return;
		}
		clickToggleCallBack(this.RoundData, this);
	}

	// Token: 0x06009C18 RID: 39960 RVA: 0x0028D9B2 File Offset: 0x0028BBB2
	public void SetClickToggleCallback(Action<ScratchTicketRoundData, ScratchTicketTabItem> callback)
	{
		this.ClickToggleCallBack = callback;
	}

	// Token: 0x040047D3 RID: 18387
	[Nullable(2)]
	private ScratchTicketRoundData RoundData;

	// Token: 0x040047D4 RID: 18388
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Action<ScratchTicketRoundData, ScratchTicketTabItem> ClickToggleCallBack;

	// Token: 0x040047D5 RID: 18389
	[Nullable(2)]
	public UiBehaviorLevelSequence UiLevelSequence;

	// Token: 0x02007965 RID: 31077
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x04029B33 RID: 170803
		public const int TabToggle = 0;

		// Token: 0x04029B34 RID: 170804
		public const int RoundIcon = 1;

		// Token: 0x04029B35 RID: 170805
		public const int LockItem = 2;

		// Token: 0x04029B36 RID: 170806
		public const int FinishItem = 3;
	}
}
