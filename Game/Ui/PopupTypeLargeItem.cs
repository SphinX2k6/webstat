using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CC RID: 18892
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupTypeLargeItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x060316D6 RID: 202454 RVA: 0x00C4C0DE File Offset: 0x00C4A2DE
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x060316D7 RID: 202455 RVA: 0x00C4C0E7 File Offset: 0x00C4A2E7
		public override UUIItem GetCostParent()
		{
			return base.GetItem(2);
		}

		// Token: 0x060316D8 RID: 202456 RVA: 0x00C4C0F0 File Offset: 0x00C4A2F0
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060316D9 RID: 202457 RVA: 0x00C4C1D8 File Offset: 0x00C4A3D8
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(3));
			this.PopupCaptionItem.SetCloseCallBack(new Action(base.TryHideSelf));
		}

		// Token: 0x060316DA RID: 202458 RVA: 0x00C4C203 File Offset: 0x00C4A403
		public override void OnSetHelpButtonActive(bool state)
		{
			this.PopupCaptionItem.SetHelpBtnActive(state);
		}

		// Token: 0x060316DB RID: 202459 RVA: 0x00C4C211 File Offset: 0x00C4A411
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
			this.PopupCaptionItem.SetTitleByTextIdAndArg(textId, args);
		}

		// Token: 0x060316DC RID: 202460 RVA: 0x00C4C220 File Offset: 0x00C4A420
		public override void OnSetBackBtnShowState(bool state)
		{
			this.PopupCaptionItem.SetCloseBtnActive(state);
		}

		// Token: 0x060316DD RID: 202461 RVA: 0x00C4C22E File Offset: 0x00C4A42E
		public override void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x060316DE RID: 202462 RVA: 0x00C4C230 File Offset: 0x00C4A430
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
			for (int i = 0; i < commonCurrencyItemList.Length; i++)
			{
				commonCurrencyItemList[i].GetRootItem().SetUIParent(base.GetItem(2), false);
			}
		}

		// Token: 0x0401C603 RID: 116227
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0200AA56 RID: 43606
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B3C RID: 215868
			public const int Mask = 0;

			// Token: 0x04034B3D RID: 215869
			public const int Content = 1;

			// Token: 0x04034B3E RID: 215870
			public const int CostContent = 2;

			// Token: 0x04034B3F RID: 215871
			public const int CaptionItem = 3;
		}
	}
}
