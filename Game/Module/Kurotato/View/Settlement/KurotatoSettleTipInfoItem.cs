using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A83 RID: 23171
	public class KurotatoSettleTipInfoItem : UiPanelBase
	{
		// Token: 0x0603AA05 RID: 240133 RVA: 0x00ED9F44 File Offset: 0x00ED8144
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AA06 RID: 240134 RVA: 0x00ED9FAD File Offset: 0x00ED81AD
		[NullableContext(1)]
		public void Refresh(string tipsText, string valueText)
		{
			base.GetText(0).ShowTextNew(tipsText);
			base.GetText(1).SetText(valueText, true);
		}

		// Token: 0x0200BA57 RID: 47703
		private class EComps
		{
			// Token: 0x04039895 RID: 235669
			public const int TextTips = 0;

			// Token: 0x04039896 RID: 235670
			public const int TextValue = 1;
		}
	}
}
