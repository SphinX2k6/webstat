using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C6F RID: 23663
	public class InfrastructureShopMenuItem : GridProxyAbstract<int>
	{
		// Token: 0x0603BCCB RID: 244939 RVA: 0x00F2916C File Offset: 0x00F2736C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleItemInner));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BCCC RID: 244940 RVA: 0x00F29214 File Offset: 0x00F27414
		public override void Refresh(int dataId, bool isSelected, int gridIndex)
		{
			this.Level = dataId;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			string text2;
			text.ShowTextNew((InfrastructureDefine.infrShopTabMenuName.TryGetValue(this.Level, out text2) && text2 != null) ? text2 : "");
		}

		// Token: 0x0603BCCD RID: 244941 RVA: 0x00F29258 File Offset: 0x00F27458
		[NullableContext(1)]
		public void SetOnClickToggleItem(Action<int> onClickToggleItem)
		{
			this.OnClickToggleItem = onClickToggleItem;
		}

		// Token: 0x0603BCCE RID: 244942 RVA: 0x00F29261 File Offset: 0x00F27461
		public void SetDeselect()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603BCCF RID: 244943 RVA: 0x00F29279 File Offset: 0x00F27479
		public void SetSelect()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x0603BCD0 RID: 244944 RVA: 0x00F29291 File Offset: 0x00F27491
		private void OnClickToggleItemInner(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<int> onClickToggleItem = this.OnClickToggleItem;
				if (onClickToggleItem == null)
				{
					return;
				}
				onClickToggleItem(this.Level);
			}
		}

		// Token: 0x04021997 RID: 137623
		public int Level;

		// Token: 0x04021998 RID: 137624
		[Nullable(2)]
		private Action<int> OnClickToggleItem;

		// Token: 0x0200BD20 RID: 48416
		private class EChildType
		{
			// Token: 0x0403A497 RID: 238743
			public const int ToggleItem = 0;

			// Token: 0x0403A498 RID: 238744
			public const int TextTitle = 1;
		}
	}
}
