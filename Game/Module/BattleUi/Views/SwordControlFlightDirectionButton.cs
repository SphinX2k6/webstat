using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006114 RID: 24852
	[NullableContext(2)]
	[Nullable(0)]
	public class SwordControlFlightDirectionButton : UiPanelBase
	{
		// Token: 0x17009AD4 RID: 39636
		// (get) Token: 0x0603EC60 RID: 257120 RVA: 0x0101332A File Offset: 0x0101152A
		// (set) Token: 0x0603EC61 RID: 257121 RVA: 0x01013332 File Offset: 0x01011532
		public Action OnPressCallback { get; set; }

		// Token: 0x17009AD5 RID: 39637
		// (get) Token: 0x0603EC62 RID: 257122 RVA: 0x0101333B File Offset: 0x0101153B
		// (set) Token: 0x0603EC63 RID: 257123 RVA: 0x01013343 File Offset: 0x01011543
		public Action OnReleaseCallback { get; set; }

		// Token: 0x17009AD6 RID: 39638
		// (get) Token: 0x0603EC64 RID: 257124 RVA: 0x0101334C File Offset: 0x0101154C
		public bool IsPressed
		{
			get
			{
				return this.HasPressedInput;
			}
		}

		// Token: 0x0603EC65 RID: 257125 RVA: 0x01013354 File Offset: 0x01011554
		public SwordControlFlightDirectionButton()
		{
			base.SkipDestroyActor = true;
		}

		// Token: 0x0603EC66 RID: 257126 RVA: 0x01013364 File Offset: 0x01011564
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISelectableStateHolder));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EC67 RID: 257127 RVA: 0x010133CD File Offset: 0x010115CD
		protected override void OnStart()
		{
			this.Button = base.GetButton(0);
			this.BindButtonEvent();
		}

		// Token: 0x0603EC68 RID: 257128 RVA: 0x010133E2 File Offset: 0x010115E2
		protected override void OnBeforeDestroy()
		{
			if (this.HasPressedInput)
			{
				this.HasPressedInput = false;
				Action onReleaseCallback = this.OnReleaseCallback;
				if (onReleaseCallback != null)
				{
					onReleaseCallback();
				}
			}
			this.UnBindButtonEvent();
			this.Button = null;
		}

		// Token: 0x0603EC69 RID: 257129 RVA: 0x01013414 File Offset: 0x01011614
		private void BindButtonEvent()
		{
			UUIButtonComponent button = this.Button;
			if (button != null)
			{
				button.OnPointDownCallBack.Bind(new Action(this.OnPressButton));
			}
			UUIButtonComponent button2 = this.Button;
			if (button2 != null)
			{
				button2.OnPointUpCallBack.Bind(new Action(this.OnReleaseButton));
			}
			UUIButtonComponent button3 = this.Button;
			if (button3 == null)
			{
				return;
			}
			button3.OnPointCancelCallBack.Bind(new Action(this.OnReleaseButton));
		}

		// Token: 0x0603EC6A RID: 257130 RVA: 0x01013488 File Offset: 0x01011688
		private void UnBindButtonEvent()
		{
			UUIButtonComponent button = this.Button;
			if (button != null)
			{
				button.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button2 = this.Button;
			if (button2 != null)
			{
				button2.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button3 = this.Button;
			if (button3 == null)
			{
				return;
			}
			button3.OnPointCancelCallBack.Unbind();
		}

		// Token: 0x0603EC6B RID: 257131 RVA: 0x010134D6 File Offset: 0x010116D6
		private void OnPressButton()
		{
			if (this.HasPressedInput)
			{
				return;
			}
			this.HasPressedInput = true;
			Action onPressCallback = this.OnPressCallback;
			if (onPressCallback == null)
			{
				return;
			}
			onPressCallback();
		}

		// Token: 0x0603EC6C RID: 257132 RVA: 0x010134F8 File Offset: 0x010116F8
		private void OnReleaseButton()
		{
			if (!this.HasPressedInput)
			{
				return;
			}
			this.HasPressedInput = false;
			Action onReleaseCallback = this.OnReleaseCallback;
			if (onReleaseCallback == null)
			{
				return;
			}
			onReleaseCallback();
		}

		// Token: 0x04023363 RID: 144227
		private UUIButtonComponent Button;

		// Token: 0x04023364 RID: 144228
		private bool HasPressedInput;

		// Token: 0x0200C29C RID: 49820
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BFF9 RID: 245753
			Button,
			// Token: 0x0403BFFA RID: 245754
			StateHolder
		}
	}
}
