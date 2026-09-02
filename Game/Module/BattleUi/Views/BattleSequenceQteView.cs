using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC3 RID: 24515
	public class BattleSequenceQteView : UiViewBase
	{
		// Token: 0x0603DA54 RID: 252500 RVA: 0x00FB4973 File Offset: 0x00FB2B73
		[NullableContext(1)]
		public BattleSequenceQteView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603DA55 RID: 252501 RVA: 0x00FB497C File Offset: 0x00FB2B7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedQteButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603DA56 RID: 252502 RVA: 0x00FB4A01 File Offset: 0x00FB2C01
		private void OnClickedQteButton()
		{
		}

		// Token: 0x0603DA57 RID: 252503 RVA: 0x00FB4A03 File Offset: 0x00FB2C03
		protected override void OnAfterPlayStartSequence()
		{
			this.UiViewSequence.PlaySequencePurely("Huxi", false, false);
		}

		// Token: 0x0200C02C RID: 49196
		private enum EChildCom
		{
			// Token: 0x0403B290 RID: 242320
			BtnQte
		}
	}
}
