using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200519A RID: 20890
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeSelectSpecialItem : GridProxyAbstract<RogueGainEntry>
	{
		// Token: 0x06035BAE RID: 220078 RVA: 0x00D80F44 File Offset: 0x00D7F144
		public RoguelikeSelectSpecialItem(Action<RoguelikeSelectSpecialItem, RogueGainEntry> clickSpecialItemCallback)
		{
			this.ClickSpecialItemCallback = clickSpecialItemCallback;
		}

		// Token: 0x06035BAF RID: 220079 RVA: 0x00D80F78 File Offset: 0x00D7F178
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action<EToggleState>(this.OnClickSpecialItem));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035BB0 RID: 220080 RVA: 0x00D811D3 File Offset: 0x00D7F3D3
		protected override void OnBeforeShow()
		{
			this.StarLayout = new GenericLayout<RoguelikeSelectSpecialStarItem, bool>(base.GetHorizontalLayout(4), this.CreateStarItem, null, false, true);
		}

		// Token: 0x06035BB1 RID: 220081 RVA: 0x00D811F0 File Offset: 0x00D7F3F0
		public override void Refresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			this.RogueGainEntry = data;
			RougeMiraclecreation? roguelikeSpecialConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeSpecialConfig(data.ConfigId);
			if (roguelikeSpecialConfig == null)
			{
				return;
			}
			UUITexture iconTexture = base.GetTexture(1);
			iconTexture.SetUIActive(false);
			base.SetTextureByPath(roguelikeSpecialConfig.Value.Icon, iconTexture, null, delegate(bool _)
			{
				iconTexture.SetUIActive(true);
			});
			EDescModel? edescModel2;
			EDescModel? edescModel = edescModel2 = new EDescModel?(ModelBase<RoguelikeModel>.Instance.GetDescModel());
			EDescModel edescModel3 = EDescModel.SIMPLE;
			string textStringId = (edescModel2.GetValueOrDefault() == edescModel3 & edescModel2 != null) ? roguelikeSpecialConfig.Value.BriefDescribe : roguelikeSpecialConfig.Value.Describe;
			edescModel2 = edescModel;
			edescModel3 = EDescModel.SIMPLE;
			string[] source = (edescModel2.GetValueOrDefault() == edescModel3 & edescModel2 != null) ? roguelikeSpecialConfig.Value.BriefDescParam() : roguelikeSpecialConfig.Value.DescParam();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), textStringId, source.ToArray<string>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), roguelikeSpecialConfig.Value.Name, Array.Empty<object>());
			UUIText text = base.GetText(7);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "RogueSpecialRemainTime", new <>z__ReadOnlySingleElementList<object>(data.RestCount));
			text.SetUIActive(data.RestCount != 0);
			base.GetItem(12).SetUIActive(data.IsNew);
			if (roguelikeSpecialConfig.Value.Level > 0)
			{
				base.GetItem(2).SetUIActive(true);
				base.GetItem(3).SetUIActive(false);
				this.RefreshStarLayout(roguelikeSpecialConfig.Value.Level, roguelikeSpecialConfig.Value.MaxLevel);
			}
			else
			{
				base.GetItem(2).SetUIActive(false);
				base.GetItem(3).SetUIActive(true);
			}
			if (data.IsValid)
			{
				base.GetItem(8).SetUIActive(false);
				base.GetTexture(0).SetAlpha(1f);
			}
			else
			{
				base.GetItem(8).SetUIActive(true);
				base.GetTexture(0).SetAlpha(0.6f);
			}
			int colorType = roguelikeSpecialConfig.Value.ColorType;
			RougeMiraclecreationColor? roguelikeMiraclecreationColorConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(colorType);
			FKuroCurveLinearColor fkuroCurveLinearColor = base.GetUiNiagara(10).ColorParameter.Get("Color");
			FColor fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaColor);
			fkuroCurveLinearColor.Constant = FLinearColor.FromSRGBColor(fcolor);
			FKuroCurveLinearColor fkuroCurveLinearColor2 = base.GetUiNiagara(11).ColorParameter.Get("Color");
			fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaNorColor);
			fkuroCurveLinearColor2.Constant = FLinearColor.FromSRGBColor(fcolor);
			FKuroCurveLinearColor fkuroCurveLinearColor3 = base.GetUiNiagara(13).ColorParameter.Get("Color");
			fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaSelectColor);
			fkuroCurveLinearColor3.Constant = FLinearColor.FromSRGBColor(fcolor);
			FKuroCurveLinearColor fkuroCurveLinearColor4 = base.GetUiNiagara(14).ColorParameter.Get("Color");
			fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaSelect1Color);
			fkuroCurveLinearColor4.Constant = FLinearColor.FromSRGBColor(fcolor);
		}

		// Token: 0x06035BB2 RID: 220082 RVA: 0x00D81544 File Offset: 0x00D7F744
		private void RefreshStarLayout(int level, int maxLevel)
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i < maxLevel; i++)
			{
				bool item = level > i;
				list.Add(item);
			}
			this.StarLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035BB3 RID: 220083 RVA: 0x00D81580 File Offset: 0x00D7F780
		public void SetSelect(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(9).SetToggleState(state2, false, false, false);
		}

		// Token: 0x06035BB4 RID: 220084 RVA: 0x00D815A7 File Offset: 0x00D7F7A7
		private void OnClickSpecialItem(EToggleState state)
		{
			if (this.ClickSpecialItemCallback != null)
			{
				this.ClickSpecialItemCallback(this, this.RogueGainEntry);
			}
		}

		// Token: 0x0401ED5C RID: 126300
		[Nullable(2)]
		private RogueGainEntry RogueGainEntry;

		// Token: 0x0401ED5D RID: 126301
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private readonly Action<RoguelikeSelectSpecialItem, RogueGainEntry> ClickSpecialItemCallback;

		// Token: 0x0401ED5E RID: 126302
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoguelikeSelectSpecialStarItem, bool> StarLayout;

		// Token: 0x0401ED5F RID: 126303
		private readonly Func<RoguelikeSelectSpecialStarItem> CreateStarItem = () => new RoguelikeSelectSpecialStarItem();

		// Token: 0x0200B162 RID: 45410
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403701E RID: 225310
			public const int BackGroundIcon = 0;

			// Token: 0x0403701F RID: 225311
			public const int Icon = 1;

			// Token: 0x04037020 RID: 225312
			public const int StarLineItem = 2;

			// Token: 0x04037021 RID: 225313
			public const int NoStarLineItem = 3;

			// Token: 0x04037022 RID: 225314
			public const int StarLayout = 4;

			// Token: 0x04037023 RID: 225315
			public const int NameText = 5;

			// Token: 0x04037024 RID: 225316
			public const int DescText = 6;

			// Token: 0x04037025 RID: 225317
			public const int RemainTimeText = 7;

			// Token: 0x04037026 RID: 225318
			public const int DisableItem = 8;

			// Token: 0x04037027 RID: 225319
			public const int ClickToggle = 9;

			// Token: 0x04037028 RID: 225320
			public const int Niagara = 10;

			// Token: 0x04037029 RID: 225321
			public const int NiagaraNor = 11;

			// Token: 0x0403702A RID: 225322
			public const int NewItem = 12;

			// Token: 0x0403702B RID: 225323
			public const int NiagaraSelect = 13;

			// Token: 0x0403702C RID: 225324
			public const int NiagaraSelect1 = 14;
		}
	}
}
