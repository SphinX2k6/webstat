using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059F3 RID: 23027
	public class RewardPopItem : UiPanelBase
	{
		// Token: 0x0603A579 RID: 238969 RVA: 0x00ECB0AE File Offset: 0x00EC92AE
		[NullableContext(1)]
		public RewardPopItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603A57A RID: 238970 RVA: 0x00ECB0C4 File Offset: 0x00EC92C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A57B RID: 238971 RVA: 0x00ECB1AE File Offset: 0x00EC93AE
		[NullableContext(1)]
		public void Update(ICommonPopItemData data)
		{
			this.ItemData = data;
			this.SetIcon();
			this.SetQuality();
			this.SetCount();
		}

		// Token: 0x0603A57C RID: 238972 RVA: 0x00ECB1CC File Offset: 0x00EC93CC
		private void SetIcon()
		{
			base.SetItemIcon(base.GetTexture(4), this.ItemData.ItemId, null, null);
		}

		// Token: 0x0603A57D RID: 238973 RVA: 0x00ECB1FC File Offset: 0x00EC93FC
		private void SetQuality()
		{
			base.SetItemQualityIcon(base.GetSprite(5), this.ItemData.ItemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0603A57E RID: 238974 RVA: 0x00ECB22C File Offset: 0x00EC942C
		private void SetCount()
		{
			base.GetText(8).SetText(this.ItemData.ItemNum.ToString(), true);
		}

		// Token: 0x0603A57F RID: 238975 RVA: 0x00ECB259 File Offset: 0x00EC9459
		private void OnClick()
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemData.ItemId, true, null);
		}

		// Token: 0x040210AC RID: 135340
		[Nullable(2)]
		private ICommonPopItemData ItemData;

		// Token: 0x0200B9C3 RID: 47555
		private class ECommonPopItemDefine
		{
			// Token: 0x0403966A RID: 235114
			public const int IconTexture = 4;

			// Token: 0x0403966B RID: 235115
			public const int QualitySprite = 5;

			// Token: 0x0403966C RID: 235116
			public const int NumText = 8;

			// Token: 0x0403966D RID: 235117
			public const int ItemButton = 9;
		}
	}
}
