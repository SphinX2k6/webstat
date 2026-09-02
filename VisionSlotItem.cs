using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200254A RID: 9546
public class VisionSlotItem : UiPanelBase
{
	// Token: 0x06012941 RID: 76097 RVA: 0x0051E297 File Offset: 0x0051C497
	[NullableContext(1)]
	public VisionSlotItem(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
	}

	// Token: 0x06012942 RID: 76098 RVA: 0x0051E2AC File Offset: 0x0051C4AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06012943 RID: 76099 RVA: 0x0051E31C File Offset: 0x0051C51C
	[NullableContext(1)]
	public void Update(VisionSlotData data)
	{
		base.GetItem(0).SetUIActive(false);
		base.GetItem(1).SetUIActive(false);
		base.GetItem(2).SetUIActive(false);
		base.GetItem(3).SetUIActive(false);
		if (data.SlotState == EVisionSlotState.Lock)
		{
			base.GetItem(0).SetUIActive(true);
			return;
		}
		if (data.SlotState == EVisionSlotState.PreviewUnLock)
		{
			base.GetItem(1).SetUIActive(true);
			return;
		}
		if (data.SlotState == EVisionSlotState.UnlockAndNoProp)
		{
			base.GetItem(2).SetUIActive(true);
			return;
		}
		if (data.SlotState == EVisionSlotState.UnlockAndHaveProp)
		{
			base.GetItem(3).SetUIActive(true);
		}
	}

	// Token: 0x02008872 RID: 34930
	private enum ESlotComponent
	{
		// Token: 0x0402E16D RID: 188781
		ShowStateD,
		// Token: 0x0402E16E RID: 188782
		ShowStateC,
		// Token: 0x0402E16F RID: 188783
		ShowStateB,
		// Token: 0x0402E170 RID: 188784
		ShowStateA
	}
}
