using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E6B RID: 20075
	public class TrapDefenseResultInfoBtn : UiPanelBase
	{
		// Token: 0x06033E1D RID: 212509 RVA: 0x00CFAD54 File Offset: 0x00CF8F54
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

		// Token: 0x06033E1E RID: 212510 RVA: 0x00CFADFA File Offset: 0x00CF8FFA
		private void OnClicked()
		{
			if (this.ClickCb != null)
			{
				this.ClickCb();
			}
		}

		// Token: 0x0401E01F RID: 122911
		[Nullable(1)]
		public Action ClickCb;

		// Token: 0x0200AE21 RID: 44577
		internal class EBtn
		{
			// Token: 0x04036138 RID: 221496
			public const int Panel = 0;

			// Token: 0x04036139 RID: 221497
			public const int Btn = 1;
		}
	}
}
