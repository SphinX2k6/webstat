using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x02006363 RID: 25443
	public class Spring25EnvelopeView : UiViewBase
	{
		// Token: 0x0603FE10 RID: 261648 RVA: 0x01062CB6 File Offset: 0x01060EB6
		[NullableContext(1)]
		public Spring25EnvelopeView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603FE11 RID: 261649 RVA: 0x01062CC0 File Offset: 0x01060EC0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.HandleBackClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.HandleConfirmClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603FE12 RID: 261650 RVA: 0x01062DCC File Offset: 0x01060FCC
		protected override void OnStart()
		{
			Spring25EnvelopeViewData spring25EnvelopeViewData = this.OpenParam as Spring25EnvelopeViewData;
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), spring25EnvelopeViewData.InfoTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), spring25EnvelopeViewData.TitleTextId, Array.Empty<object>());
		}

		// Token: 0x0603FE13 RID: 261651 RVA: 0x01062E1D File Offset: 0x0106101D
		private void HandleBackClick()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleResetCurrentSignId();
			base.CloseMe(null);
		}

		// Token: 0x0603FE14 RID: 261652 RVA: 0x01062E30 File Offset: 0x01061030
		private void HandleConfirmClick()
		{
			ControllerBase<ActivitySpring25Controller>.Instance.HandleResetCurrentSignId();
			base.CloseMe(null);
		}

		// Token: 0x0200C3C6 RID: 50118
		private class EComponent
		{
			// Token: 0x0403C4D6 RID: 246998
			public const int InfoText = 0;

			// Token: 0x0403C4D7 RID: 246999
			public const int BackButton = 1;

			// Token: 0x0403C4D8 RID: 247000
			public const int ConfirmButton = 2;

			// Token: 0x0403C4D9 RID: 247001
			public const int TitleText = 3;
		}
	}
}
