using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F0A RID: 24330
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingBuffTipsPanel : UiPanelBase
	{
		// Token: 0x0603D1B9 RID: 250297 RVA: 0x00F858A0 File Offset: 0x00F83AA0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1BA RID: 250298 RVA: 0x00F85A14 File Offset: 0x00F83C14
		public void Refresh(BossPilingBuffCountInfo buffInfo)
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
			}
			BossPilingBuff value = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(buffInfo.BuffId).Value;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(value.Name);
			}
			base.SetTextureByPath(value.Icon, base.GetTexture(3), null, null);
			UUINiagara uiNiagara = base.GetUiNiagara(5);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(value.Quality == 3);
			}
			UUINiagara uiNiagara2 = base.GetUiNiagara(5);
			if (uiNiagara2 != null)
			{
				uiNiagara2.SetUIActive(value.Quality == 4);
			}
			UUINiagara uiNiagara3 = base.GetUiNiagara(6);
			if (uiNiagara3 != null)
			{
				uiNiagara3.SetUIActive(value.Quality == 5);
			}
			string valueOrDefault = BossPilingBuffTipsPanel.QualityTexMap.GetValueOrDefault(value.Quality, "");
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(valueOrDefault);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			string valueOrDefault2 = BossPilingBuffTipsPanel.QualitySpriteMap.GetValueOrDefault(value.Quality, "");
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(valueOrDefault2);
			this.SetSpriteByPath(resourcePath2, base.GetSprite(4), false, null, null);
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(buffInfo.Count > 1);
			}
			if (buffInfo.Count > 1)
			{
				UUIText text2 = base.GetText(8);
				if (text2 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
					defaultInterpolatedStringHandler.AppendLiteral("x");
					defaultInterpolatedStringHandler.AppendFormatted<int>(buffInfo.Count);
					text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Desc, value.DescArgs());
		}

		// Token: 0x04022453 RID: 140371
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string> QualityTexMap = new Dictionary<int, string>
		{
			{
				3,
				"T_BossPilingCollectionQualityBlue"
			},
			{
				4,
				"T_BossPilingCollectionQualityPurple"
			},
			{
				5,
				"T_BossPilingCollectionQualityGold"
			}
		};

		// Token: 0x04022454 RID: 140372
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, string> QualitySpriteMap = new Dictionary<int, string>
		{
			{
				3,
				"SP_QualityBlueA"
			},
			{
				4,
				"SP_QualityPurpleA"
			},
			{
				5,
				"SP_QualityGlodA"
			}
		};

		// Token: 0x0200BF0A RID: 48906
		[NullableContext(0)]
		private enum EDefine
		{
			// Token: 0x0403ACCE RID: 240846
			TexBg,
			// Token: 0x0403ACCF RID: 240847
			TxtName,
			// Token: 0x0403ACD0 RID: 240848
			TxtTips,
			// Token: 0x0403ACD1 RID: 240849
			TexIcon,
			// Token: 0x0403ACD2 RID: 240850
			SpriteQuality,
			// Token: 0x0403ACD3 RID: 240851
			NiagaraPurple,
			// Token: 0x0403ACD4 RID: 240852
			NiagaraGold,
			// Token: 0x0403ACD5 RID: 240853
			CountItem,
			// Token: 0x0403ACD6 RID: 240854
			TxtCount,
			// Token: 0x0403ACD7 RID: 240855
			NiagaraBlue
		}
	}
}
