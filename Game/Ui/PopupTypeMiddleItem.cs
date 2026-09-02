using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CD RID: 18893
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupTypeMiddleItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x060316E0 RID: 202464 RVA: 0x00C4C26A File Offset: 0x00C4A46A
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x060316E1 RID: 202465 RVA: 0x00C4C273 File Offset: 0x00C4A473
		public override UUIItem GetCostParent()
		{
			return base.GetItem(3);
		}

		// Token: 0x060316E2 RID: 202466 RVA: 0x00C4C27C File Offset: 0x00C4A47C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
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

		// Token: 0x060316E3 RID: 202467 RVA: 0x00C4C3A8 File Offset: 0x00C4A5A8
		public override void OnSetBackBtnShowState(bool state)
		{
			UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(state);
		}

		// Token: 0x060316E4 RID: 202468 RVA: 0x00C4C3D4 File Offset: 0x00C4A5D4
		public override void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x060316E5 RID: 202469 RVA: 0x00C4C3D6 File Offset: 0x00C4A5D6
		public override void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x060316E6 RID: 202470 RVA: 0x00C4C3D8 File Offset: 0x00C4A5D8
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
		}

		// Token: 0x060316E7 RID: 202471 RVA: 0x00C4C3DC File Offset: 0x00C4A5DC
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
			for (int i = 0; i < commonCurrencyItemList.Length; i++)
			{
				commonCurrencyItemList[i].GetRootItem().SetUIParent(base.GetItem(3), false);
			}
		}

		// Token: 0x0200AA57 RID: 43607
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B40 RID: 215872
			public const int Mask = 0;

			// Token: 0x04034B41 RID: 215873
			public const int Content = 1;

			// Token: 0x04034B42 RID: 215874
			public const int BackBtn = 2;

			// Token: 0x04034B43 RID: 215875
			public const int CostContent = 3;

			// Token: 0x04034B44 RID: 215876
			public const int TxtTitle = 4;
		}
	}
}
