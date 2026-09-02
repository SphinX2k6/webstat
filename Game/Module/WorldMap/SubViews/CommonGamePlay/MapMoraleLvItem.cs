using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.CommonGamePlay
{
	// Token: 0x02004BD9 RID: 19417
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMoraleLvItem : UiPanelBase
	{
		// Token: 0x06032ABA RID: 207546 RVA: 0x00CB0B7C File Offset: 0x00CAED7C
		public UniTask Init(UUIItem parentItem, string resId = "UiItem_MapTipMorale")
		{
			MapMoraleLvItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.parentItem = parentItem;
			<Init>d__.resId = resId;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MapMoraleLvItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06032ABB RID: 207547 RVA: 0x00CB0BD0 File Offset: 0x00CAEDD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032ABC RID: 207548 RVA: 0x00CB0C5A File Offset: 0x00CAEE5A
		public void UpdateTitle(string titleId)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(titleId);
		}

		// Token: 0x06032ABD RID: 207549 RVA: 0x00CB0C6E File Offset: 0x00CAEE6E
		public void UpdateLv(int lv)
		{
			UUIArtText artText = base.GetArtText(1);
			if (artText == null)
			{
				return;
			}
			artText.SetText(lv.ToString());
		}

		// Token: 0x06032ABE RID: 207550 RVA: 0x00CB0C88 File Offset: 0x00CAEE88
		public void UpdateLvColor(string hexColor)
		{
			UUIArtText artText = base.GetArtText(1);
			if (artText == null)
			{
				return;
			}
			artText.SetColor(FColor.FromHex(hexColor));
		}

		// Token: 0x06032ABF RID: 207551 RVA: 0x00CB0CA1 File Offset: 0x00CAEEA1
		public void UpdateBgColor(string hexColor)
		{
			UUITexture texture = base.GetTexture(2);
			if (texture == null)
			{
				return;
			}
			texture.SetColor(FColor.FromHex(hexColor));
		}

		// Token: 0x06032AC0 RID: 207552 RVA: 0x00CB0CBC File Offset: 0x00CAEEBC
		public void UpdateData(IMapMoraleLvItemData data)
		{
			this.UpdateTitle(data.TitleId);
			this.UpdateLv(data.Lv);
			if (!string.IsNullOrEmpty(data.LvColor))
			{
				this.UpdateLvColor(data.LvColor);
			}
			if (!string.IsNullOrEmpty(data.BgColor))
			{
				this.UpdateBgColor(data.BgColor);
			}
		}

		// Token: 0x0200ACC0 RID: 44224
		[NullableContext(0)]
		public static class EChildType
		{
			// Token: 0x04035A99 RID: 219801
			public const int TxtTitle = 0;

			// Token: 0x04035A9A RID: 219802
			public const int ArtLv = 1;

			// Token: 0x04035A9B RID: 219803
			public const int TexBg = 2;
		}
	}
}
