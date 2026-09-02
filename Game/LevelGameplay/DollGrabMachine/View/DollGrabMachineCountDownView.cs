using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006EF3 RID: 28403
	public class DollGrabMachineCountDownView : UiViewBase
	{
		// Token: 0x06044D73 RID: 281971 RVA: 0x011E9B83 File Offset: 0x011E7D83
		[NullableContext(1)]
		public DollGrabMachineCountDownView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06044D74 RID: 281972 RVA: 0x011E9B8C File Offset: 0x011E7D8C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044D75 RID: 281973 RVA: 0x011E9BD4 File Offset: 0x011E7DD4
		protected override void OnBeforeShow()
		{
			this.PnlTips = base.GetItem(0);
			UUIItem pnlTips = this.PnlTips;
			if (pnlTips != null)
			{
				pnlTips.SetAnchorOffsetY(0f);
			}
			Singleton<EventSystem>.Instance.Add<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
		}

		// Token: 0x06044D76 RID: 281974 RVA: 0x011E9C20 File Offset: 0x011E7E20
		protected override void OnAfterPlayStartSequence()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDollGrabMachineEndCoolDown);
			Singleton<EventSystem>.Instance.Remove<EDollGrabMachineEndReason>(EEventName.OnDollGrabMachineEnd, new Action<EDollGrabMachineEndReason>(this.OnDollGrabMachineEnd));
			base.CloseMe(null);
		}

		// Token: 0x06044D77 RID: 281975 RVA: 0x011E9C55 File Offset: 0x011E7E55
		private void OnDollGrabMachineEnd(EDollGrabMachineEndReason reason)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null && uiViewSequence.IsInSequence())
			{
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 == null)
				{
					return;
				}
				uiViewSequence2.StopSequenceByKey("Start", false, false);
			}
		}

		// Token: 0x04026597 RID: 157079
		[Nullable(2)]
		private UUIItem PnlTips;

		// Token: 0x0200CBCF RID: 52175
		private enum EViewComponent
		{
			// Token: 0x0403E82F RID: 256047
			PnlTips
		}
	}
}
