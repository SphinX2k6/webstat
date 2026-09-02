using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066DC RID: 26332
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightRankItem : GridProxyAbstract<MotorFightRankData>
	{
		// Token: 0x06041BEA RID: 269290 RVA: 0x010DC648 File Offset: 0x010DA848
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnGotoBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041BEB RID: 269291 RVA: 0x010DC81C File Offset: 0x010DAA1C
		public override void Refresh(MotorFightRankData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (gridIndex != -1 && gridIndex < 3)
			{
				base.SetTextureByPath(MotorFightRankItemStatic.rankLightBgList[gridIndex], base.GetTexture(0), null, null);
				base.SetTextureByPath(MotorFightRankItemStatic.rankBgList[gridIndex], base.GetTexture(1), null, null);
				UUIArtText artText = base.GetArtText(2);
				if (artText != null)
				{
					artText.SetColor(FColor.FromHex(MotorFightRankItemStatic.rankNumberColor[gridIndex]));
				}
			}
			else
			{
				UUITexture texture = base.GetTexture(0);
				if (texture != null)
				{
					texture.SetUIActive(false);
				}
				base.SetTextureByPath(MotorFightRankItemStatic.rankBgList[3], base.GetTexture(1), null, null);
				UUIArtText artText2 = base.GetArtText(2);
				if (artText2 != null)
				{
					artText2.SetColor(FColor.FromHex(MotorFightRankItemStatic.rankNumberColor[3]));
				}
			}
			base.SetTextureByPath(data.TexturePath, base.GetTexture(3), null, null);
			base.SetTextureByPath(data.TexturePath, base.GetTexture(10), null, null);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(data.Name, true);
			}
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				text2.SetText(data.Score.ToString(), true);
			}
			UUIButtonComponent button = base.GetButton(8);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(data.HasData);
			}
			if (!data.HasData)
			{
				UUIArtText artText3 = base.GetArtText(2);
				if (artText3 != null)
				{
					artText3.SetText("--");
				}
				base.GetScrollViewWithScrollbar(6).RootUIComp.Get().SetUIActive(false);
				UUIText text3 = base.GetText(9);
				if (text3 != null)
				{
					text3.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "MotorFightGame_RankingInfo_01", Array.Empty<object>());
				return;
			}
			int num = gridIndex + 1;
			UUIArtText artText4 = base.GetArtText(2);
			if (artText4 != null)
			{
				string text4;
				if (num / 10 >= 1)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					text4 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				else
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendLiteral("0");
					defaultInterpolatedStringHandler.AppendFormatted<int>(num);
					text4 = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				artText4.SetText(text4);
			}
			new GenericScrollViewNew<MotorFightItemSmallGrid, MotorFightItemData>(base.GetScrollViewWithScrollbar(6), new Func<MotorFightItemSmallGrid>(this.CreateItem), null, false, null).RefreshByData(data.ItemList, null, false);
			UUIText text5 = base.GetText(9);
			if (text5 == null)
			{
				return;
			}
			text5.SetUIActive(data.ItemList.Count == 0);
		}

		// Token: 0x06041BEC RID: 269292 RVA: 0x010DCA9B File Offset: 0x010DAC9B
		private MotorFightItemSmallGrid CreateItem()
		{
			return new MotorFightItemSmallGrid();
		}

		// Token: 0x06041BED RID: 269293 RVA: 0x010DCAA2 File Offset: 0x010DACA2
		private void OnGotoBtnClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorFightRankDetailView, this.Data, null);
		}

		// Token: 0x04024AEA RID: 150250
		[Nullable(2)]
		private MotorFightRankData Data;

		// Token: 0x0200C70B RID: 50955
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D47F RID: 251007
			public const int TextureBgLight = 0;

			// Token: 0x0403D480 RID: 251008
			public const int TextureBg = 1;

			// Token: 0x0403D481 RID: 251009
			public const int ArtTextRankNum = 2;

			// Token: 0x0403D482 RID: 251010
			public const int TextureRole = 3;

			// Token: 0x0403D483 RID: 251011
			public const int TextPlayerName = 4;

			// Token: 0x0403D484 RID: 251012
			public const int TextScore = 5;

			// Token: 0x0403D485 RID: 251013
			public const int ScrollLayoutItem = 6;

			// Token: 0x0403D486 RID: 251014
			public const int ItemBase = 7;

			// Token: 0x0403D487 RID: 251015
			public const int BtnGoto = 8;

			// Token: 0x0403D488 RID: 251016
			public const int TextEmpty = 9;

			// Token: 0x0403D489 RID: 251017
			public const int TextureRoleShadow = 10;
		}
	}
}
