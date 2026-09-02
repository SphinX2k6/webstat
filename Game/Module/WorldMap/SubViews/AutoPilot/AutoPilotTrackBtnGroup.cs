using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.AutoPilot
{
	// Token: 0x02004BDE RID: 19422
	[NullableContext(2)]
	[Nullable(0)]
	public class AutoPilotTrackBtnGroup : UiPanelBase
	{
		// Token: 0x17008710 RID: 34576
		// (get) Token: 0x06032AD6 RID: 207574 RVA: 0x00CB122D File Offset: 0x00CAF42D
		// (set) Token: 0x06032AD7 RID: 207575 RVA: 0x00CB1235 File Offset: 0x00CAF435
		public Action BtnGoQuickCallback { get; set; }

		// Token: 0x17008711 RID: 34577
		// (get) Token: 0x06032AD8 RID: 207576 RVA: 0x00CB123E File Offset: 0x00CAF43E
		// (set) Token: 0x06032AD9 RID: 207577 RVA: 0x00CB1246 File Offset: 0x00CAF446
		public Action BtnCancelCallback { get; set; }

		// Token: 0x06032ADA RID: 207578 RVA: 0x00CB1250 File Offset: 0x00CAF450
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCancel));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnGoQuick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032ADB RID: 207579 RVA: 0x00CB1319 File Offset: 0x00CAF519
		private void OnBtnCancel()
		{
			Action btnCancelCallback = this.BtnCancelCallback;
			if (btnCancelCallback == null)
			{
				return;
			}
			btnCancelCallback();
		}

		// Token: 0x06032ADC RID: 207580 RVA: 0x00CB132B File Offset: 0x00CAF52B
		private void OnBtnGoQuick()
		{
			Action btnGoQuickCallback = this.BtnGoQuickCallback;
			if (btnGoQuickCallback == null)
			{
				return;
			}
			btnGoQuickCallback();
		}

		// Token: 0x06032ADD RID: 207581 RVA: 0x00CB133D File Offset: 0x00CAF53D
		public void SetBtnGoQuickEnable(bool isEnable)
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(isEnable);
		}

		// Token: 0x0200ACC7 RID: 44231
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035AB1 RID: 219825
			public const int BtnCancel = 0;

			// Token: 0x04035AB2 RID: 219826
			public const int BtnGoQuick = 1;
		}
	}
}
