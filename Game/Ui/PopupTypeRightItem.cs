using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049CE RID: 18894
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupTypeRightItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x060316EA RID: 202474 RVA: 0x00C4C41E File Offset: 0x00C4A61E
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x060316EB RID: 202475 RVA: 0x00C4C427 File Offset: 0x00C4A627
		public override UUIItem GetCostParent()
		{
			return null;
		}

		// Token: 0x060316EC RID: 202476 RVA: 0x00C4C42C File Offset: 0x00C4A62C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(base.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060316ED RID: 202477 RVA: 0x00C4C538 File Offset: 0x00C4A738
		public override void OnSetBackBtnShowState(bool state)
		{
			UUIItem uuiitem = base.GetButton(0).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(state);
		}

		// Token: 0x060316EE RID: 202478 RVA: 0x00C4C564 File Offset: 0x00C4A764
		public override void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x060316EF RID: 202479 RVA: 0x00C4C566 File Offset: 0x00C4A766
		public override void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x060316F0 RID: 202480 RVA: 0x00C4C568 File Offset: 0x00C4A768
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
		}

		// Token: 0x060316F1 RID: 202481 RVA: 0x00C4C56A File Offset: 0x00C4A76A
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
		}

		// Token: 0x060316F2 RID: 202482 RVA: 0x00C4C56C File Offset: 0x00C4A76C
		public void ShowMoraleBg(bool show)
		{
			this.SetMoraleBgActive(show);
			this.SetWhiteBgActive(!show);
		}

		// Token: 0x060316F3 RID: 202483 RVA: 0x00C4C57F File Offset: 0x00C4A77F
		private void SetMoraleBgActive(bool active)
		{
			UUITexture texture = base.GetTexture(4);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(active);
		}

		// Token: 0x060316F4 RID: 202484 RVA: 0x00C4C593 File Offset: 0x00C4A793
		private void SetWhiteBgActive(bool active)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(active);
		}

		// Token: 0x0200AA58 RID: 43608
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B45 RID: 215877
			public const int BackBtn = 0;

			// Token: 0x04034B46 RID: 215878
			public const int Content = 1;

			// Token: 0x04034B47 RID: 215879
			public const int TexturePatternB = 2;

			// Token: 0x04034B48 RID: 215880
			public const int TextureWitheBgTop = 3;

			// Token: 0x04034B49 RID: 215881
			public const int TextureMoraleBgTop = 4;
		}
	}
}
