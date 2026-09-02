using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C53 RID: 23635
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrActivityBtnItem : UiPanelBase
	{
		// Token: 0x0603BB66 RID: 244582 RVA: 0x00F20324 File Offset: 0x00F1E524
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BB67 RID: 244583 RVA: 0x00F203EB File Offset: 0x00F1E5EB
		private void ButtonClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x0603BB68 RID: 244584 RVA: 0x00F203FD File Offset: 0x00F1E5FD
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x0603BB69 RID: 244585 RVA: 0x00F20406 File Offset: 0x00F1E606
		public void SetText(string text)
		{
			base.GetText(1).ShowTextNew(text);
		}

		// Token: 0x0603BB6A RID: 244586 RVA: 0x00F20415 File Offset: 0x00F1E615
		public void SetRedPointVisible(bool visible)
		{
			base.GetItem(2).SetUIActive(visible);
		}

		// Token: 0x04021924 RID: 137508
		private Action ButtonFunction;

		// Token: 0x0200BCC9 RID: 48329
		[NullableContext(0)]
		private class EButtonItemDefine
		{
			// Token: 0x0403A299 RID: 238233
			public const int Button = 0;

			// Token: 0x0403A29A RID: 238234
			public const int ButtonText = 1;

			// Token: 0x0403A29B RID: 238235
			public const int PanelRedPoint = 2;
		}
	}
}
