using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x0200530A RID: 21258
	public class QuickHackTargetItem : UiPanelBase
	{
		// Token: 0x06036457 RID: 222295 RVA: 0x00DAE384 File Offset: 0x00DAC584
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036458 RID: 222296 RVA: 0x00DAE3CC File Offset: 0x00DAC5CC
		[NullableContext(1)]
		public void RefreshTitle(string title)
		{
			base.GetText(3).SetText(title, true);
		}

		// Token: 0x0200B23C RID: 45628
		private class ETargetItemComponentType
		{
			// Token: 0x0403743E RID: 226366
			public const int TitleText = 3;
		}
	}
}
