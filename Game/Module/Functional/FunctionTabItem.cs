using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1E RID: 23838
	public class FunctionTabItem : UiPanelBase
	{
		// Token: 0x0603C1C5 RID: 246213 RVA: 0x00F3E280 File Offset: 0x00F3C480
		[NullableContext(1)]
		public FunctionTabItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C1C6 RID: 246214 RVA: 0x00F3E298 File Offset: 0x00F3C498
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C1C7 RID: 246215 RVA: 0x00F3E2E0 File Offset: 0x00F3C4E0
		public void SetToggleState(bool bSelected)
		{
			base.GetExtendToggle(0).SetToggleState(bSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0200BD8F RID: 48527
		private class ECompDefine
		{
			// Token: 0x0403A615 RID: 239125
			public const int Toggle = 0;
		}
	}
}
