using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Plot
{
	// Token: 0x020065E6 RID: 26086
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballPlotOptionItem : GridProxyAbstract<IPinballPlotOptionItemData>
	{
		// Token: 0x06041297 RID: 266903 RVA: 0x010B74D0 File Offset: 0x010B56D0
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnOptionButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041298 RID: 266904 RVA: 0x010B7598 File Offset: 0x010B5798
		[NullableContext(1)]
		public override void Refresh(IPinballPlotOptionItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			string newText = ConfigBase<PinballConfig>.Instance.CovertOptionIndexToText(data.OptionIndex);
			base.GetText(1).SetText(newText, true);
			TableTextArgNew optionText = data.OptionText;
			string textStringId = optionText.TextKey ?? "";
			IReadOnlyList<object> args = optionText.Params ?? Array.Empty<object>();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textStringId, args);
		}

		// Token: 0x06041299 RID: 266905 RVA: 0x010B7603 File Offset: 0x010B5803
		private void OnOptionButtonClick()
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.OptionDelegate(this.Data.OptionIndex);
		}

		// Token: 0x040247DD RID: 149469
		[Nullable(2)]
		private IPinballPlotOptionItemData Data;

		// Token: 0x0200C5EA RID: 50666
		private enum EComponent
		{
			// Token: 0x0403CEAE RID: 249518
			OptionButton,
			// Token: 0x0403CEAF RID: 249519
			OptionTitleText,
			// Token: 0x0403CEB0 RID: 249520
			OptionDescText
		}
	}
}
