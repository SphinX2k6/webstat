using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Pause
{
	// Token: 0x02005A92 RID: 23186
	internal class PauseButtonItem : UiPanelBase
	{
		// Token: 0x0603AAA5 RID: 240293 RVA: 0x00EDD960 File Offset: 0x00EDBB60
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603AAA6 RID: 240294 RVA: 0x00EDDA06 File Offset: 0x00EDBC06
		[NullableContext(1)]
		public void SetClickCb(Action cb)
		{
			this.ClickCb = cb;
		}

		// Token: 0x0603AAA7 RID: 240295 RVA: 0x00EDDA0F File Offset: 0x00EDBC0F
		private void OnClick()
		{
			Action clickCb = this.ClickCb;
			if (clickCb == null)
			{
				return;
			}
			clickCb();
		}

		// Token: 0x040212D4 RID: 135892
		[Nullable(2)]
		private Action ClickCb;

		// Token: 0x0200BA81 RID: 47745
		private enum EPauseBtnComp
		{
			// Token: 0x04039958 RID: 235864
			Self,
			// Token: 0x04039959 RID: 235865
			Button
		}
	}
}
