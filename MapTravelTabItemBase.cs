using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001394 RID: 5012
public class MapTravelTabItemBase : UiPanelBase
{
	// Token: 0x060089D3 RID: 35283 RVA: 0x00243FF4 File Offset: 0x002421F4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectOn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060089D4 RID: 35284 RVA: 0x0024411E File Offset: 0x0024231E
	private void OnToggleSelectOn(EToggleState _)
	{
		if (this.Data != null)
		{
			Action<SoarChallengePlayData> selectedCallBack = this.SelectedCallBack;
			if (selectedCallBack == null)
			{
				return;
			}
			selectedCallBack(this.Data);
		}
	}

	// Token: 0x060089D5 RID: 35285 RVA: 0x00244140 File Offset: 0x00242340
	public void SetToggleState(bool bOn, bool bFireEvent)
	{
		EToggleState state = bOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, bFireEvent, false, false);
	}

	// Token: 0x04004097 RID: 16535
	[Nullable(2)]
	protected SoarChallengePlayData Data;

	// Token: 0x04004098 RID: 16536
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<SoarChallengePlayData> SelectedCallBack;

	// Token: 0x02007735 RID: 30517
	private class ETabComponents
	{
		// Token: 0x040290C0 RID: 168128
		public const int Toggle = 0;

		// Token: 0x040290C1 RID: 168129
		public const int Name = 1;

		// Token: 0x040290C2 RID: 168130
		public const int SpriteDone = 2;

		// Token: 0x040290C3 RID: 168131
		public const int SpriteLock = 3;

		// Token: 0x040290C4 RID: 168132
		public const int RedDot = 4;

		// Token: 0x040290C5 RID: 168133
		public const int ItemNew = 5;
	}
}
