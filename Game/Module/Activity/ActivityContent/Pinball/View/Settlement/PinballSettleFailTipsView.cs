using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B5 RID: 26037
	public class PinballSettleFailTipsView : UiPanelBase
	{
		// Token: 0x060410F1 RID: 266481 RVA: 0x010B1808 File Offset: 0x010AFA08
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

		// Token: 0x060410F2 RID: 266482 RVA: 0x010B1850 File Offset: 0x010AFA50
		[NullableContext(1)]
		public void ShowTxt(string textId)
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
		}

		// Token: 0x0200C5B6 RID: 50614
		private enum EComponent
		{
			// Token: 0x0403CDA3 RID: 249251
			TextTips
		}
	}
}
