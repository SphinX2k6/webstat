using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006036 RID: 24630
	public class BattleHonamiStoryLeaveButton : BattleEntranceButton
	{
		// Token: 0x0603E214 RID: 254484 RVA: 0x00FDBA24 File Offset: 0x00FD9C24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			ref ValueTuple<int, Delegate> ptr = ref span2[num];
			int item = 0;
			Action item2;
			if ((item2 = BattleHonamiStoryLeaveButton.<>O.<0>__OnLeaveClick) == null)
			{
				item2 = (BattleHonamiStoryLeaveButton.<>O.<0>__OnLeaveClick = new Action(BattleHonamiStoryLeaveButton.OnLeaveClick));
			}
			ptr = new ValueTuple<int, Delegate>(item, item2);
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E215 RID: 254485 RVA: 0x00FDBAB8 File Offset: 0x00FD9CB8
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.TopButton);
			bool flag = BattleHonamiStoryLeaveButton.CanSafeLeave();
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.PlaySequencePurely(flag ? "Sucs" : "Start", false, false);
			this.AddEvents();
		}

		// Token: 0x0603E216 RID: 254486 RVA: 0x00FDBB0C File Offset: 0x00FD9D0C
		public override void Reset()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603E217 RID: 254487 RVA: 0x00FDBB32 File Offset: 0x00FD9D32
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStoryLeaveButtonUpdate, new Action(this.OnSafeLeaveUpdate));
		}

		// Token: 0x0603E218 RID: 254488 RVA: 0x00FDBB50 File Offset: 0x00FD9D50
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStoryLeaveButtonUpdate, new Action(this.OnSafeLeaveUpdate));
		}

		// Token: 0x0603E219 RID: 254489 RVA: 0x00FDBB6E File Offset: 0x00FD9D6E
		private void OnSafeLeaveUpdate()
		{
			if (BattleHonamiStoryLeaveButton.CanSafeLeave())
			{
				UiSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null)
				{
					sequencePlayer.StopPrevSequence(false, true);
				}
				UiSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 == null)
				{
					return;
				}
				sequencePlayer2.PlaySequencePurely("Sucs", false, false);
			}
		}

		// Token: 0x0603E21A RID: 254490 RVA: 0x00FDBBA1 File Offset: 0x00FD9DA1
		private static void OnLeaveClick()
		{
			ControllerBase<HonamiStoryController>.Instance.TryHonamiStoryInstLeave(false);
		}

		// Token: 0x0603E21B RID: 254491 RVA: 0x00FDBBAE File Offset: 0x00FD9DAE
		private static bool CanSafeLeave()
		{
			return ModelBase<HonamiStoryModel>.Instance.CanSafeLeave;
		}

		// Token: 0x04022D4A RID: 142666
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0200C0EC RID: 49388
		private enum EComponentType
		{
			// Token: 0x0403B69A RID: 243354
			LeaveButton
		}

		// Token: 0x0200C0ED RID: 49389
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403B69B RID: 243355
			public static Action <0>__OnLeaveClick;
		}
	}
}
