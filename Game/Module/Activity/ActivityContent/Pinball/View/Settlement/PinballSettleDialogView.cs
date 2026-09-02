using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B4 RID: 26036
	public class PinballSettleDialogView : UiPanelBase
	{
		// Token: 0x060410EE RID: 266478 RVA: 0x010B179C File Offset: 0x010AF99C
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

		// Token: 0x060410EF RID: 266479 RVA: 0x010B17E4 File Offset: 0x010AF9E4
		[NullableContext(1)]
		public void ShowTxt(string textId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0200C5B5 RID: 50613
		private enum EComponent
		{
			// Token: 0x0403CDA1 RID: 249249
			TextDialog
		}
	}
}
