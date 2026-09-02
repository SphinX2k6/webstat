using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CB RID: 18891
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupTypeBigItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x060316CD RID: 202445 RVA: 0x00C4BF50 File Offset: 0x00C4A150
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x060316CE RID: 202446 RVA: 0x00C4BF59 File Offset: 0x00C4A159
		public override UUIItem GetCostParent()
		{
			return base.GetItem(3);
		}

		// Token: 0x060316CF RID: 202447 RVA: 0x00C4BF64 File Offset: 0x00C4A164
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.OnClickMaskButton));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(base.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060316D0 RID: 202448 RVA: 0x00C4C070 File Offset: 0x00C4A270
		public override void OnSetBackBtnShowState(bool state)
		{
			UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(state);
		}

		// Token: 0x060316D1 RID: 202449 RVA: 0x00C4C09C File Offset: 0x00C4A29C
		public override void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x060316D2 RID: 202450 RVA: 0x00C4C09E File Offset: 0x00C4A29E
		public override void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x060316D3 RID: 202451 RVA: 0x00C4C0A0 File Offset: 0x00C4A2A0
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
		}

		// Token: 0x060316D4 RID: 202452 RVA: 0x00C4C0A4 File Offset: 0x00C4A2A4
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
			for (int i = 0; i < commonCurrencyItemList.Length; i++)
			{
				commonCurrencyItemList[i].GetRootItem().SetUIParent(base.GetItem(3), false);
			}
		}

		// Token: 0x0200AA55 RID: 43605
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B38 RID: 215864
			public const int Mask = 0;

			// Token: 0x04034B39 RID: 215865
			public const int Content = 1;

			// Token: 0x04034B3A RID: 215866
			public const int BackBtn = 2;

			// Token: 0x04034B3B RID: 215867
			public const int CostContent = 3;
		}
	}
}
