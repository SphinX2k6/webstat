using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E9 RID: 26089
	public class PinballPlotSelectionItem : UiPanelBase
	{
		// Token: 0x060412A4 RID: 266916 RVA: 0x010B765C File Offset: 0x010B585C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnOptionButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060412A5 RID: 266917 RVA: 0x010B7704 File Offset: 0x010B5904
		[NullableContext(1)]
		public void Refresh(IPinballPlotSelectionItemData data)
		{
			this.Data = data;
			string newText = ConfigBase<PinballConfig>.Instance.CovertOptionIndexToText(data.OptionIndex);
			base.GetText(1).SetText(newText, true);
		}

		// Token: 0x060412A6 RID: 266918 RVA: 0x010B7737 File Offset: 0x010B5937
		private void OnOptionButtonClick()
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.OptionDelegate(this.Data.OptionIndex);
		}

		// Token: 0x040247E0 RID: 149472
		[Nullable(2)]
		private IPinballPlotSelectionItemData Data;

		// Token: 0x0200C5EB RID: 50667
		private enum EComponent
		{
			// Token: 0x0403CEB2 RID: 249522
			OptionButton,
			// Token: 0x0403CEB3 RID: 249523
			OptionTitleText
		}
	}
}
