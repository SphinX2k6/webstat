using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C5 RID: 18885
	[NullableContext(1)]
	[Nullable(0)]
	public class FullScreenViewItem : CommonPopViewBase, ICommonPopView
	{
		// Token: 0x06031661 RID: 202337 RVA: 0x00C4AAD4 File Offset: 0x00C48CD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06031662 RID: 202338 RVA: 0x00C4AB3D File Offset: 0x00C48D3D
		protected override void OnStart()
		{
			this.PopupCaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.PopupCaptionItem.SetCloseCallBack(new Action(base.TryHideSelf));
		}

		// Token: 0x06031663 RID: 202339 RVA: 0x00C4AB68 File Offset: 0x00C48D68
		public override UUIItem GetAttachParent()
		{
			return base.GetItem(1);
		}

		// Token: 0x06031664 RID: 202340 RVA: 0x00C4AB71 File Offset: 0x00C48D71
		public void SetCaptionTitleIconVisible(bool bVisible)
		{
			this.PopupCaptionItem.SetTitleIconVisible(bVisible);
		}

		// Token: 0x06031665 RID: 202341 RVA: 0x00C4AB7F File Offset: 0x00C48D7F
		public void SetCaptionTitleVisible(bool bVisible)
		{
			this.PopupCaptionItem.SetTitleTextActive(bVisible);
		}

		// Token: 0x06031666 RID: 202342 RVA: 0x00C4AB8D File Offset: 0x00C48D8D
		public override void OnSetTitleByTextIdAndArg(string textId, params object[] args)
		{
			this.PopupCaptionItem.SetTitleByTextIdAndArg(textId, args);
		}

		// Token: 0x06031667 RID: 202343 RVA: 0x00C4AB9C File Offset: 0x00C48D9C
		public override void OnSetCloseBtnInteractive(bool state)
		{
		}

		// Token: 0x06031668 RID: 202344 RVA: 0x00C4AB9E File Offset: 0x00C48D9E
		public override void OnSetHelpButtonActive(bool state)
		{
		}

		// Token: 0x06031669 RID: 202345 RVA: 0x00C4ABA0 File Offset: 0x00C48DA0
		public override void OnSetBackBtnShowState(bool state)
		{
		}

		// Token: 0x0603166A RID: 202346 RVA: 0x00C4ABA2 File Offset: 0x00C48DA2
		public override void OnRefreshCost(CommonCurrencyItem[] commonCurrencyItemList)
		{
		}

		// Token: 0x0401C5F5 RID: 116213
		private PopupCaptionItem PopupCaptionItem;

		// Token: 0x0200AA45 RID: 43589
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034AFA RID: 215802
			public const int CaptionItem = 0;

			// Token: 0x04034AFB RID: 215803
			public const int ContentItem = 1;
		}
	}
}
