using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x0200669E RID: 26270
	public class MowingBuffIntroduce : UiPanelBase
	{
		// Token: 0x060419A2 RID: 268706 RVA: 0x010D1F34 File Offset: 0x010D0134
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060419A3 RID: 268707 RVA: 0x010D2106 File Offset: 0x010D0306
		protected override void OnStart()
		{
			UUISprite sprite = base.GetSprite(8);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(false);
		}

		// Token: 0x060419A4 RID: 268708 RVA: 0x010D211C File Offset: 0x010D031C
		[NullableContext(1)]
		public void RefreshByCustomData(IMowingBuffIntroduceData data)
		{
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(data.LevelTextId != null);
			}
			if (!string.IsNullOrEmpty(data.LevelTextId))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.LevelTextId, data.LevelTextArgs);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.NameTextId, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.TipsTextId, data.TipsArgs);
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(data.BackgroundPath != null);
			}
			if (!string.IsNullOrEmpty(data.BackgroundPath))
			{
				base.SetTextureByPath(data.BackgroundPath, texture, null, null);
			}
			UUITexture texture2 = base.GetTexture(5);
			if (texture2 != null)
			{
				texture2.SetUIActive(data.IconPath != null);
			}
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				base.SetTextureByPath(data.IconPath, texture2, null, null);
			}
			this.RefreshNiagaraByEnum(data.HexColor);
			UUISprite sprite = base.GetSprite(7);
			if (sprite != null)
			{
				sprite.SetUIActive(!data.IsUnlock);
			}
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool bUseChangeColor = !data.IsUnlock;
				FColor? fcolor = null;
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			if (texture2 != null)
			{
				texture2.SetIsGray(!data.IsUnlock);
			}
			if (texture2 != null)
			{
				texture2.SetAlpha(data.IsUnlock ? 1f : 0.3f);
			}
		}

		// Token: 0x060419A5 RID: 268709 RVA: 0x010D2290 File Offset: 0x010D0490
		[NullableContext(1)]
		private void RefreshNiagaraByEnum(string enumValue)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(6);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(enumValue == EMowingBuffQualityHexColor.Blue.ToString());
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(9);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(enumValue == EMowingBuffQualityHexColor.Purple.ToString());
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(10);
			if (uiNiagara3 == null)
			{
				return;
			}
			uiNiagara3.SetUIActive(enumValue == EMowingBuffQualityHexColor.Gold.ToString());
		}

		// Token: 0x060419A6 RID: 268710 RVA: 0x010D2316 File Offset: 0x010D0516
		private void OnClickToggle(EToggleState _)
		{
		}

		// Token: 0x04024A25 RID: 150053
		private const float GRAY_ALPHA = 0.3f;

		// Token: 0x0200C6A9 RID: 50857
		private class EComponent
		{
			// Token: 0x0403D2B8 RID: 250552
			public const int Toggle = 0;

			// Token: 0x0403D2B9 RID: 250553
			public const int BackgroundTexture = 1;

			// Token: 0x0403D2BA RID: 250554
			public const int LevelText = 2;

			// Token: 0x0403D2BB RID: 250555
			public const int NameText = 3;

			// Token: 0x0403D2BC RID: 250556
			public const int TipsText = 4;

			// Token: 0x0403D2BD RID: 250557
			public const int IconTexture = 5;

			// Token: 0x0403D2BE RID: 250558
			public const int QualityBlueNiagara = 6;

			// Token: 0x0403D2BF RID: 250559
			public const int LockSprite = 7;

			// Token: 0x0403D2C0 RID: 250560
			public const int QualitySprite = 8;

			// Token: 0x0403D2C1 RID: 250561
			public const int QualityPurpleNiagara = 9;

			// Token: 0x0403D2C2 RID: 250562
			public const int QualityGoldNiagara = 10;
		}
	}
}
