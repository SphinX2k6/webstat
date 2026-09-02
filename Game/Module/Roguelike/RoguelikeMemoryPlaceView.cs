using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200518E RID: 20878
	public class RoguelikeMemoryPlaceView : UiViewBase
	{
		// Token: 0x06035B58 RID: 219992 RVA: 0x00D7EACE File Offset: 0x00D7CCCE
		[NullableContext(1)]
		public RoguelikeMemoryPlaceView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035B59 RID: 219993 RVA: 0x00D7EAD7 File Offset: 0x00D7CCD7
		[NullableContext(1)]
		private RoguelikeMemoryRewardItem CreateLoopScrollItem()
		{
			return new RoguelikeMemoryRewardItem();
		}

		// Token: 0x06035B5A RID: 219994 RVA: 0x00D7EAE0 File Offset: 0x00D7CCE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnTokenOverViewClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnAchievementViewClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035B5B RID: 219995 RVA: 0x00D7EC94 File Offset: 0x00D7CE94
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			});
			this.LoopScrollView = new LoopScrollView<RoguelikeMemoryRewardItem, RoguelikeMemoryRewardItemData>(base.GetLoopScrollViewComponent(7), base.GetItem(8).GetOwner() as AUIBaseActor, new Func<RoguelikeMemoryRewardItem>(this.CreateLoopScrollItem), false);
			base.GetLoopScrollViewComponent(7).RootUIComp.Get().GetParentAsUIItem().SetUIActive(false);
			this.CaptionItem.SetHelpBtnActive(false);
			this.SeasonData = (this.OpenParam as SeasonData);
			IReadOnlyList<Aki.Config.RogueSeasonReward> rogueSeasonReward = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonReward(this.SeasonData.SeasonId);
			List<RoguelikeMemoryRewardItemData> list = new List<RoguelikeMemoryRewardItemData>();
			for (int i = 0; i < rogueSeasonReward.Count<Aki.Config.RogueSeasonReward>(); i++)
			{
				Aki.Config.RogueSeasonReward value = rogueSeasonReward[i];
				list.Add(new RoguelikeMemoryRewardItemData
				{
					SeasonReward = this.SeasonData.SeasonRewardList[i],
					Config = new Aki.Config.RogueSeasonReward?(value)
				});
			}
			this.LoopScrollView.ReloadData(list, false);
			this.UpdateView();
		}

		// Token: 0x06035B5C RID: 219996 RVA: 0x00D7EDB4 File Offset: 0x00D7CFB4
		private void OnBtnTokenOverViewClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeTokenOverView, this.SeasonData, null);
		}

		// Token: 0x06035B5D RID: 219997 RVA: 0x00D7EDCC File Offset: 0x00D7CFCC
		private void OnBtnAchievementViewClick()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeAchievementView, null, null);
		}

		// Token: 0x06035B5E RID: 219998 RVA: 0x00D7EDE0 File Offset: 0x00D7CFE0
		protected void UpdateView()
		{
			int num = this.SeasonData.SeasonRewardList.Count<SeasonReward>();
			int pointItem = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null).Value.PointItem;
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(pointItem, 0);
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Roguelike_MemoryPlace_Level", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Roguelike_MemoryPlace_Exp", new <>z__ReadOnlyArray<object>(new object[]
			{
				itemCountByConfigId,
				paramConfigBySeasonId.Value.PointItemMaxCount
			}));
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(this.SeasonData.SeasonId);
			List<AchievementGroupData> achievementCategoryGroups = ModelBase<AchievementModel>.Instance.GetAchievementCategoryGroups(rogueSeasonConfigById.Value.Achievement, true);
			int num2 = 0;
			int num3 = 0;
			foreach (AchievementGroupData achievementGroupData in achievementCategoryGroups)
			{
				num3 += achievementGroupData.GetMaxProgress();
				num2 += achievementGroupData.GetCurrentProgress();
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Rogue_MemoryPlace_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2,
				num3
			}));
			int num4 = ConfigBase<RoguelikeConfig>.Instance.GetRogueTokenBySeasonId(this.SeasonData.SeasonId).Count<Aki.Config.RogueToken>();
			int num5 = this.SeasonData.RoguelikeTokenList.Count<RoguelikeToken>();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Rogue_MemoryPlace_Progress", new <>z__ReadOnlyArray<object>(new object[]
			{
				num5,
				num4
			}));
		}

		// Token: 0x0401ED29 RID: 126249
		[Nullable(2)]
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401ED2A RID: 126250
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected LoopScrollView<RoguelikeMemoryRewardItem, RoguelikeMemoryRewardItemData> LoopScrollView;

		// Token: 0x0401ED2B RID: 126251
		[Nullable(2)]
		protected SeasonData SeasonData;

		// Token: 0x0200B14E RID: 45390
		private class ERoguelikeMemoryPlaceViewDefine
		{
			// Token: 0x04036FC6 RID: 225222
			public const int CaptionItem = 0;

			// Token: 0x04036FC7 RID: 225223
			public const int BtnTokenOverView = 1;

			// Token: 0x04036FC8 RID: 225224
			public const int BtnAchievementView = 2;

			// Token: 0x04036FC9 RID: 225225
			public const int TxtCurLevel = 3;

			// Token: 0x04036FCA RID: 225226
			public const int TxtScore = 4;

			// Token: 0x04036FCB RID: 225227
			public const int TxtAchievementCollect = 5;

			// Token: 0x04036FCC RID: 225228
			public const int TxtTokenCollect = 6;

			// Token: 0x04036FCD RID: 225229
			public const int LoopScrollView = 7;

			// Token: 0x04036FCE RID: 225230
			public const int LoopScrollItem = 8;

			// Token: 0x04036FCF RID: 225231
			public const int PanelBottom = 9;
		}
	}
}
