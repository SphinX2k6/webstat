using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005586 RID: 21894
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailPassiveSkillItem : UiPanelBase
	{
		// Token: 0x06037C5C RID: 228444 RVA: 0x00E22810 File Offset: 0x00E20A10
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText))
			};
		}

		// Token: 0x06037C5D RID: 228445 RVA: 0x00E228D8 File Offset: 0x00E20AD8
		private void RefreshCondition(ICardDetailConditionOutData outData)
		{
			if (outData == null || StringUtils.IsBlank(outData.ConditionDesc))
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			base.GetItem(1).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), outData.ConditionDesc, new <>z__ReadOnlyArray<object>(new object[]
			{
				outData.CurrentProgress,
				outData.MaxProgress
			}));
			UUIText text = base.GetText(5);
			if (!StringUtils.IsBlank(outData.Title))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, outData.Title, Array.Empty<object>());
			}
			UUIItem uuiitem = text;
			bool valueOrDefault = outData.TitleChangeColor.GetValueOrDefault();
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(valueOrDefault, fcolor);
		}

		// Token: 0x06037C5E RID: 228446 RVA: 0x00E2299C File Offset: 0x00E20B9C
		private void RefreshProgress(ICardDetailConditionOutData outData)
		{
			UUIText text = base.GetText(3);
			if (outData == null || outData.MaxProgress == 0)
			{
				text.SetUIActive(false);
				return;
			}
			text.SetUIActive(true);
			if (!StringUtils.IsBlank(outData.Icon))
			{
				this.SetSpriteByPath(outData.Icon, base.GetSprite(4), true, null, null);
			}
			string textStringId = (outData.CurrentProgress >= outData.MaxProgress) ? "PhantomBattle_1163" : "PhantomBattle_1162";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, new <>z__ReadOnlyArray<object>(new object[]
			{
				outData.CurrentProgress,
				outData.MaxProgress
			}));
		}

		// Token: 0x06037C5F RID: 228447 RVA: 0x00E22A4C File Offset: 0x00E20C4C
		private void RefreshInData(ICardDetailConditionInData data)
		{
			if (data != null)
			{
				base.GetItem(1).SetUIActive(false);
				base.GetSprite(4).SetUIActive(false);
				base.GetText(3).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), data.TextArg.TextKey, data.TextArg.Params.ToArray<object>());
			}
		}

		// Token: 0x06037C60 RID: 228448 RVA: 0x00E22AAF File Offset: 0x00E20CAF
		private void RefreshOutData(ICardDetailConditionOutData outData)
		{
			this.RefreshCondition(outData);
			this.RefreshProgress(outData);
		}

		// Token: 0x06037C61 RID: 228449 RVA: 0x00E22AC0 File Offset: 0x00E20CC0
		private void RefreshEffectCount(ICardDetailEffectCountData effectCountData)
		{
			base.GetItem(6).SetUIActive(effectCountData != null);
			if (effectCountData != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "PhantomBattle_1161", new <>z__ReadOnlyArray<object>(new object[]
				{
					effectCountData.CurrentEffectCount,
					effectCountData.TotalEffectCount
				}));
			}
		}

		// Token: 0x06037C62 RID: 228450 RVA: 0x00E22B20 File Offset: 0x00E20D20
		public void Refresh(ICardDetailPassiveSkillData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.Desc, data.Params.ToArray());
			ICardDetailPassiveSkillFieldData fieldData = data.FieldData;
			this.RefreshOutData((fieldData != null) ? fieldData.OutData : null);
			ICardDetailPassiveSkillFieldData fieldData2 = data.FieldData;
			this.RefreshInData((fieldData2 != null) ? fieldData2.InData : null);
			this.RefreshEffectCount(data.EffectCountData);
		}

		// Token: 0x0200B525 RID: 46373
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04038128 RID: 229672
			public const int DescText = 0;

			// Token: 0x04038129 RID: 229673
			public const int ConditionItem = 1;

			// Token: 0x0403812A RID: 229674
			public const int ConditionText = 2;

			// Token: 0x0403812B RID: 229675
			public const int ProgressText = 3;

			// Token: 0x0403812C RID: 229676
			public const int ProgressIcon = 4;

			// Token: 0x0403812D RID: 229677
			public const int TitleText = 5;

			// Token: 0x0403812E RID: 229678
			public const int EffectCountItem = 6;

			// Token: 0x0403812F RID: 229679
			public const int EffectCountText = 7;
		}
	}
}
