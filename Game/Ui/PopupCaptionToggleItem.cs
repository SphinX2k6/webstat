using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CA RID: 18890
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupCaptionToggleItem : UiPanelBase
	{
		// Token: 0x060316C6 RID: 202438 RVA: 0x00C4BE4C File Offset: 0x00C4A04C
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

		// Token: 0x060316C7 RID: 202439 RVA: 0x00C4BEF2 File Offset: 0x00C4A0F2
		private void OnClickToggle(EToggleState state)
		{
			Action<EToggleState> onClickToggleCallback = this.OnClickToggleCallback;
			if (onClickToggleCallback == null)
			{
				return;
			}
			onClickToggleCallback(state);
		}

		// Token: 0x060316C8 RID: 202440 RVA: 0x00C4BF05 File Offset: 0x00C4A105
		public void SetClickToggleCallback(Action<EToggleState> callback)
		{
			this.OnClickToggleCallback = callback;
		}

		// Token: 0x060316C9 RID: 202441 RVA: 0x00C4BF0E File Offset: 0x00C4A10E
		public void SetNameText(string name)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), name, Array.Empty<object>());
		}

		// Token: 0x060316CA RID: 202442 RVA: 0x00C4BF27 File Offset: 0x00C4A127
		public EToggleState GetToggleState()
		{
			return base.GetExtendToggle(0).ToggleState;
		}

		// Token: 0x060316CB RID: 202443 RVA: 0x00C4BF35 File Offset: 0x00C4A135
		public void InitToggleState(EToggleState toggleState)
		{
			base.GetExtendToggle(0).SetToggleState(toggleState, false, false, true);
		}

		// Token: 0x0401C602 RID: 116226
		protected Action<EToggleState> OnClickToggleCallback;

		// Token: 0x0200AA54 RID: 43604
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B36 RID: 215862
			public const int Toggle = 0;

			// Token: 0x04034B37 RID: 215863
			public const int Name = 1;
		}
	}
}
