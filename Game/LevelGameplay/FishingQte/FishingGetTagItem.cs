using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA1 RID: 28321
	public class FishingGetTagItem : UiPanelBase
	{
		// Token: 0x06044AE1 RID: 281313 RVA: 0x011D9FE0 File Offset: 0x011D81E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AE2 RID: 281314 RVA: 0x011DA04C File Offset: 0x011D824C
		public void RefreshTag(EFishingQteGetItemTagType tagType)
		{
			string text = null;
			string text2 = null;
			string text3 = null;
			if (tagType != EFishingQteGetItemTagType.Multiply)
			{
				if (tagType == EFishingQteGetItemTagType.Extra)
				{
					text = "Reward_Tag_Extra";
					text2 = ConfigCommonParamById.GetStringConfig("Reward_Tag_Extra_Bg_Color");
					text3 = ConfigCommonParamById.GetStringConfig("Reward_Tag_Extra_Text_Color");
				}
			}
			else
			{
				text = "Reward_Tag_Magnification";
				text2 = ConfigCommonParamById.GetStringConfig("Reward_Tag_Magnification_Bg_Color");
				text3 = ConfigCommonParamById.GetStringConfig("Reward_Tag_Magnification_Text_Color");
			}
			if (!string.IsNullOrEmpty(text))
			{
				base.GetText(1).ShowTextNew(text);
			}
			if (!string.IsNullOrEmpty(text3))
			{
				base.GetText(1).SetColor(FColor.FromHex(text3));
			}
			if (!string.IsNullOrEmpty(text2))
			{
				base.GetSprite(0).SetColor(FColor.FromHex(text2));
			}
		}

		// Token: 0x0200CB71 RID: 52081
		private class ETagComponents
		{
			// Token: 0x0403E6EA RID: 255722
			public const int SpriteBg = 0;

			// Token: 0x0403E6EB RID: 255723
			public const int Txt = 1;
		}
	}
}
