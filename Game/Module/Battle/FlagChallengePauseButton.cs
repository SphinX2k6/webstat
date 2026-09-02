using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F20 RID: 24352
	public class FlagChallengePauseButton : UiPanelBase
	{
		// Token: 0x0603D2A7 RID: 250535 RVA: 0x00F8B054 File Offset: 0x00F89254
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
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D2A8 RID: 250536 RVA: 0x00F8B0FA File Offset: 0x00F892FA
		private void OnClicked()
		{
			Action clickCb = this.ClickCb;
			if (clickCb == null)
			{
				return;
			}
			clickCb();
		}

		// Token: 0x040224CD RID: 140493
		[Nullable(2)]
		public Action ClickCb;

		// Token: 0x0200BF2A RID: 48938
		private enum EPauseButtonType
		{
			// Token: 0x0403AD75 RID: 241013
			Panel,
			// Token: 0x0403AD76 RID: 241014
			Button
		}
	}
}
