using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E20 RID: 20000
	public class TrapDefenseResultContinueButton : UiPanelBase
	{
		// Token: 0x06033B65 RID: 211813 RVA: 0x00CECE10 File Offset: 0x00CEB010
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B66 RID: 211814 RVA: 0x00CECED7 File Offset: 0x00CEB0D7
		[NullableContext(1)]
		public void ShowText(string key)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), key, Array.Empty<object>());
		}

		// Token: 0x06033B67 RID: 211815 RVA: 0x00CECEF0 File Offset: 0x00CEB0F0
		private void OnClickedBtn()
		{
			if (this.OnClickCb != null)
			{
				this.OnClickCb();
			}
		}

		// Token: 0x0401DF0F RID: 122639
		[Nullable(1)]
		public Action OnClickCb;

		// Token: 0x0200AD9B RID: 44443
		private class EContinueBtn
		{
			// Token: 0x04035E94 RID: 220820
			public const int Btn = 0;

			// Token: 0x04035E95 RID: 220821
			public const int Txt = 1;

			// Token: 0x04035E96 RID: 220822
			public const int RedDot = 2;
		}
	}
}
