using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065C0 RID: 26048
	public class PinballSettleUnlockTipsView : UiPanelBase
	{
		// Token: 0x06041176 RID: 266614 RVA: 0x010B3A1C File Offset: 0x010B1C1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041177 RID: 266615 RVA: 0x010B3A64 File Offset: 0x010B1C64
		[NullableContext(1)]
		public void ShowTxt(string textId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0200C5C5 RID: 50629
		private enum EComponent
		{
			// Token: 0x0403CDF8 RID: 249336
			TextTips
		}
	}
}
