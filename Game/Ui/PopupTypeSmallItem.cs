using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CF RID: 18895
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupTypeSmallItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x060316F5 RID: 202485 RVA: 0x00C4C5A7 File Offset: 0x00C4A7A7
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x060316F6 RID: 202486 RVA: 0x00C4C5B0 File Offset: 0x00C4A7B0
		public override UUIItem GetCostParent()
		{
			return base.GetItem(3);
		}

		// Token: 0x060316F7 RID: 202487 RVA: 0x00C4C5BC File Offset: 0x00C4A7BC
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

		// Token: 0x060316F8 RID: 202488 RVA: 0x00C4C6C7 File Offset: 0x00C4A8C7
		public override void OnSetCloseBtnInteractive(bool state)
		{
			base.GetButton(2).SetSelfInteractive(state);
		}

		// Token: 0x060316F9 RID: 202489 RVA: 0x00C4C6D8 File Offset: 0x00C4A8D8
		public override void OnSetBackBtnShowState(bool state)
		{
			UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(state);
		}

		// Token: 0x060316FA RID: 202490 RVA: 0x00C4C704 File Offset: 0x00C4A904
		public override void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x060316FB RID: 202491 RVA: 0x00C4C706 File Offset: 0x00C4A906
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
		}

		// Token: 0x060316FC RID: 202492 RVA: 0x00C4C708 File Offset: 0x00C4A908
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
			for (int i = 0; i < commonCurrencyItemList.Length; i++)
			{
				commonCurrencyItemList[i].GetRootItem().SetUIParent(base.GetItem(3), false);
			}
		}

		// Token: 0x0200AA59 RID: 43609
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B4A RID: 215882
			public const int Mask = 0;

			// Token: 0x04034B4B RID: 215883
			public const int Content = 1;

			// Token: 0x04034B4C RID: 215884
			public const int BackBtn = 2;

			// Token: 0x04034B4D RID: 215885
			public const int CostContent = 3;
		}
	}
}
