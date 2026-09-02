using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F07 RID: 24327
	public class BossPilingBuffCountItem : UiPanelBase
	{
		// Token: 0x0603D1AB RID: 250283 RVA: 0x00F852CC File Offset: 0x00F834CC
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

		// Token: 0x0603D1AC RID: 250284 RVA: 0x00F85314 File Offset: 0x00F83514
		public void Refresh(int count)
		{
			base.SetUiActive(count >= 2);
			if (count < 2)
			{
				return;
			}
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<int>(count);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0200BF07 RID: 48903
		private enum ECount
		{
			// Token: 0x0403ACB7 RID: 240823
			Txt
		}
	}
}
