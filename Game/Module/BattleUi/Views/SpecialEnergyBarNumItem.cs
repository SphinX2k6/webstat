using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060FB RID: 24827
	public class SpecialEnergyBarNumItem : UiPanelBase
	{
		// Token: 0x0603EBA9 RID: 256937 RVA: 0x0100F564 File Offset: 0x0100D764
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

		// Token: 0x0603EBAA RID: 256938 RVA: 0x0100F5AC File Offset: 0x0100D7AC
		public void SetNum(int num)
		{
			if (this.Num == num)
			{
				return;
			}
			this.Num = num;
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString(), true);
		}

		// Token: 0x040232D9 RID: 144089
		private int Num = -1;

		// Token: 0x0200C283 RID: 49795
		private enum EChildType
		{
			// Token: 0x0403BF7A RID: 245626
			NumText
		}
	}
}
