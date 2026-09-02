using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common
{
	// Token: 0x02004BCD RID: 19405
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupListItemPanel : UiPanelBase
	{
		// Token: 0x06032A54 RID: 207444 RVA: 0x00CAFCEC File Offset: 0x00CADEEC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032A55 RID: 207445 RVA: 0x00CAFDB8 File Offset: 0x00CADFB8
		public void SetTxtLActive(bool active)
		{
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(active);
		}

		// Token: 0x06032A56 RID: 207446 RVA: 0x00CAFDCC File Offset: 0x00CADFCC
		public void SetTxtLNewTxt(string newTxtId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), newTxtId, Array.Empty<object>());
		}

		// Token: 0x06032A57 RID: 207447 RVA: 0x00CAFDE5 File Offset: 0x00CADFE5
		public void SetTxtRActive(bool active)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetUIActive(active);
		}

		// Token: 0x06032A58 RID: 207448 RVA: 0x00CAFDF9 File Offset: 0x00CADFF9
		public void SetTxtRNewTxt(string newTxtId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), newTxtId, args);
		}

		// Token: 0x06032A59 RID: 207449 RVA: 0x00CAFE0E File Offset: 0x00CAE00E
		public void SetTxtRTxt(string txt)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(txt, true);
		}

		// Token: 0x06032A5A RID: 207450 RVA: 0x00CAFE23 File Offset: 0x00CAE023
		public void SetTxtRTxtColor(string hexColor)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetColor(FColor.FromHex(hexColor));
		}

		// Token: 0x06032A5B RID: 207451 RVA: 0x00CAFE3C File Offset: 0x00CAE03C
		public void SetBtnHelpA2Active(bool active)
		{
			UUIButtonComponent button = base.GetButton(2);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(active);
		}

		// Token: 0x06032A5C RID: 207452 RVA: 0x00CAFE68 File Offset: 0x00CAE068
		public void SetTexIconActive(bool active)
		{
			UUITexture texture = base.GetTexture(3);
			if (texture == null)
			{
				return;
			}
			texture.SetUIActive(active);
		}

		// Token: 0x06032A5D RID: 207453 RVA: 0x00CAFE7C File Offset: 0x00CAE07C
		public void SetTexIcon(string assetName)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(assetName);
			base.SetTextureByPath(resourcePath, base.GetTexture(3), null, null);
		}

		// Token: 0x06032A5E RID: 207454 RVA: 0x00CAFEAD File Offset: 0x00CAE0AD
		public void SetIconActive(bool active)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(active);
		}

		// Token: 0x06032A5F RID: 207455 RVA: 0x00CAFEC4 File Offset: 0x00CAE0C4
		public void SetIconSprite(string assetName)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(assetName);
			this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
		}

		// Token: 0x0200ACB6 RID: 44214
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035A72 RID: 219762
			public const int TxtL = 0;

			// Token: 0x04035A73 RID: 219763
			public const int TxtR = 1;

			// Token: 0x04035A74 RID: 219764
			public const int BtnHelpA2 = 2;

			// Token: 0x04035A75 RID: 219765
			public const int TexIcon = 3;

			// Token: 0x04035A76 RID: 219766
			public const int Icon = 4;
		}
	}
}
