using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BCB RID: 19403
	[NullableContext(1)]
	[Nullable(0)]
	public class MediumItemListPanel : UiPanelBase
	{
		// Token: 0x06032A47 RID: 207431 RVA: 0x00CAFA24 File Offset: 0x00CADC24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032A48 RID: 207432 RVA: 0x00CAFAAE File Offset: 0x00CADCAE
		protected override void OnStart()
		{
			this.RewardLayout = new GenericLayout<MediumItemListItem, TItem>(base.GetGridLayout(1), new Func<MediumItemListItem>(this.CreateGridItem), null, false, true);
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText("", true);
		}

		// Token: 0x06032A49 RID: 207433 RVA: 0x00CAFAE8 File Offset: 0x00CADCE8
		private MediumItemListItem CreateGridItem()
		{
			return new MediumItemListItem
			{
				GetBottomTextCallback = this.GetBottomTextCallback
			};
		}

		// Token: 0x06032A4A RID: 207434 RVA: 0x00CAFAFC File Offset: 0x00CADCFC
		public void Refresh(List<TItem> data)
		{
			GenericLayout<MediumItemListItem, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByDataAsync(data, false, null).Forget();
		}

		// Token: 0x06032A4B RID: 207435 RVA: 0x00CAFB29 File Offset: 0x00CADD29
		public void SetTitleNewTxt(string newTxtId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), newTxtId, Array.Empty<object>());
		}

		// Token: 0x0401D80A RID: 120842
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MediumItemListItem, TItem> RewardLayout;

		// Token: 0x0401D80B RID: 120843
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<int, string> GetBottomTextCallback;

		// Token: 0x0200ACB4 RID: 44212
		[NullableContext(0)]
		public static class ERewardItemBarChildCom
		{
			// Token: 0x04035A69 RID: 219753
			public const int UiTextInstanceTitle = 0;

			// Token: 0x04035A6A RID: 219754
			public const int UiItemContainer = 1;

			// Token: 0x04035A6B RID: 219755
			public const int UiItemItem = 2;
		}
	}
}
