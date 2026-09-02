using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513F RID: 20799
	public class RoguelikeChallengeButtonItem : UiPanelBase
	{
		// Token: 0x060358A8 RID: 219304 RVA: 0x00D70D28 File Offset: 0x00D6EF28
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonCallback));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060358A9 RID: 219305 RVA: 0x00D70E31 File Offset: 0x00D6F031
		private void ButtonCallback()
		{
			Action buttonCallbackInternal = this.ButtonCallbackInternal;
			if (buttonCallbackInternal == null)
			{
				return;
			}
			buttonCallbackInternal();
		}

		// Token: 0x060358AA RID: 219306 RVA: 0x00D70E43 File Offset: 0x00D6F043
		[NullableContext(1)]
		public void SetButtonCallback(Action callback)
		{
			this.ButtonCallbackInternal = callback;
		}

		// Token: 0x060358AB RID: 219307 RVA: 0x00D70E4C File Offset: 0x00D6F04C
		public void SetTxtScore(int count)
		{
			base.GetText(3).SetText(count.ToString(), true);
		}

		// Token: 0x060358AC RID: 219308 RVA: 0x00D70E62 File Offset: 0x00D6F062
		public void SetProcessingState(bool bVisible)
		{
			base.GetItem(4).SetUIActive(bVisible);
		}

		// Token: 0x0401EC33 RID: 126003
		[Nullable(2)]
		private Action ButtonCallbackInternal;

		// Token: 0x0200B0DE RID: 45278
		private class EComponents
		{
			// Token: 0x04036DDB RID: 224731
			public const int BtnConfirm = 0;

			// Token: 0x04036DDC RID: 224732
			public const int TxtConfirm = 1;

			// Token: 0x04036DDD RID: 224733
			public const int ItemRedDot = 2;

			// Token: 0x04036DDE RID: 224734
			public const int TxtScore = 3;

			// Token: 0x04036DDF RID: 224735
			public const int PanelProcessing = 4;
		}
	}
}
