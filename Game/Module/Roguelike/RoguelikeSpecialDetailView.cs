using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051AB RID: 20907
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSpecialDetailView : UiViewBase
	{
		// Token: 0x06035C28 RID: 220200 RVA: 0x00D85060 File Offset: 0x00D83260
		public RoguelikeSpecialDetailView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035C29 RID: 220201 RVA: 0x00D85090 File Offset: 0x00D83290
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickCloseBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035C2A RID: 220202 RVA: 0x00D85240 File Offset: 0x00D83440
		protected override void OnStart()
		{
			object[] array = this.OpenParam as object[];
			if (array == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.BB, "RoguelikeSpecialDetailView无效输入", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.GainEntryData = (array[0] as RogueGainEntry);
			this.CloseCallBack = (array[1] as Action<bool?>);
			this.StarLayout = new GenericLayout<RoguelikeSelectSpecialStarItem, bool>(base.GetHorizontalLayout(3), this.CreateStarItem, null, false, true);
			this.RefreshUi(this.GainEntryData);
		}

		// Token: 0x06035C2B RID: 220203 RVA: 0x00D852BF File Offset: 0x00D834BF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(this.RoguelikeDataRefresh));
		}

		// Token: 0x06035C2C RID: 220204 RVA: 0x00D852DD File Offset: 0x00D834DD
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(this.RoguelikeDataRefresh));
		}

		// Token: 0x06035C2D RID: 220205 RVA: 0x00D852FC File Offset: 0x00D834FC
		private void RefreshUi(RogueGainEntry data)
		{
			RougeMiraclecreation? roguelikeSpecialConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeSpecialConfig(data.ConfigId);
			if (roguelikeSpecialConfig == null)
			{
				return;
			}
			UUITexture iconTexture = base.GetTexture(0);
			iconTexture.SetUIActive(false);
			base.SetTextureByPath(roguelikeSpecialConfig.Value.Icon, iconTexture, null, delegate(bool _)
			{
				iconTexture.SetUIActive(true);
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), roguelikeSpecialConfig.Value.Name, Array.Empty<object>());
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			EDescModel? edescModel2;
			EDescModel? edescModel = edescModel2 = ((instance != null) ? new EDescModel?(instance.GetDescModel()) : null);
			EDescModel edescModel3 = EDescModel.SIMPLE;
			string textStringId = (edescModel2.GetValueOrDefault() == edescModel3 & edescModel2 != null) ? roguelikeSpecialConfig.Value.BriefDescribe : roguelikeSpecialConfig.Value.Describe;
			edescModel2 = edescModel;
			edescModel3 = EDescModel.SIMPLE;
			string[] source = (edescModel2.GetValueOrDefault() == edescModel3 & edescModel2 != null) ? roguelikeSpecialConfig.Value.BriefDescParam() : roguelikeSpecialConfig.Value.DescParam();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), textStringId, source.ToArray<string>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), roguelikeSpecialConfig.Value.StoryDescribe, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "RogueSpecialRemainTime", new <>z__ReadOnlySingleElementList<object>(data.RestCount));
			base.GetText(4).SetUIActive(data.RestCount != 0);
			int colorType = roguelikeSpecialConfig.Value.ColorType;
			RougeMiraclecreationColor? roguelikeMiraclecreationColorConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(colorType);
			FKuroCurveLinearColor fkuroCurveLinearColor = base.GetUiNiagara(8).ColorParameter.Get("Color");
			FColor fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaColor);
			fkuroCurveLinearColor.Constant = FLinearColor.FromSRGBColor(fcolor);
			FKuroCurveLinearColor fkuroCurveLinearColor2 = base.GetUiNiagara(9).ColorParameter.Get("Color");
			fcolor = FColor.FromHex(roguelikeMiraclecreationColorConfig.Value.NiaNorColor);
			fkuroCurveLinearColor2.Constant = FLinearColor.FromSRGBColor(fcolor);
			this.RefreshStarLayout(roguelikeSpecialConfig.Value.Level, roguelikeSpecialConfig.Value.MaxLevel);
		}

		// Token: 0x06035C2E RID: 220206 RVA: 0x00D85568 File Offset: 0x00D83768
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

		// Token: 0x06035C2F RID: 220207 RVA: 0x00D855A1 File Offset: 0x00D837A1
		private void RoguelikeDataRefresh()
		{
			this.RefreshUi(this.GainEntryData);
		}

		// Token: 0x06035C30 RID: 220208 RVA: 0x00D855AF File Offset: 0x00D837AF
		private void OnClickCloseBtn()
		{
			base.CloseMe(delegate(bool success)
			{
				Action<bool?> closeCallBack = this.CloseCallBack;
				if (closeCallBack == null)
				{
					return;
				}
				closeCallBack(new bool?(success));
			});
		}

		// Token: 0x0401ED93 RID: 126355
		[Nullable(2)]
		private RogueGainEntry GainEntryData;

		// Token: 0x0401ED94 RID: 126356
		[Nullable(2)]
		private Action<bool?> CloseCallBack;

		// Token: 0x0401ED95 RID: 126357
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoguelikeSelectSpecialStarItem, bool> StarLayout;

		// Token: 0x0401ED96 RID: 126358
		private readonly Func<RoguelikeSelectSpecialStarItem> CreateStarItem = () => new RoguelikeSelectSpecialStarItem();

		// Token: 0x0200B18A RID: 45450
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x040370EE RID: 225518
			public const int Icon = 0;

			// Token: 0x040370EF RID: 225519
			public const int BgIcon = 1;

			// Token: 0x040370F0 RID: 225520
			public const int Name = 2;

			// Token: 0x040370F1 RID: 225521
			public const int StarLayout = 3;

			// Token: 0x040370F2 RID: 225522
			public const int RemainTimeText = 4;

			// Token: 0x040370F3 RID: 225523
			public const int Desc = 5;

			// Token: 0x040370F4 RID: 225524
			public const int StoryDesc = 6;

			// Token: 0x040370F5 RID: 225525
			public const int CloseButton = 7;

			// Token: 0x040370F6 RID: 225526
			public const int Niagara = 8;

			// Token: 0x040370F7 RID: 225527
			public const int NiagaraNor = 9;
		}
	}
}
