using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BF RID: 26303
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourMainView : UiTickViewBase
	{
		// Token: 0x06041AC8 RID: 269000 RVA: 0x010D713B File Offset: 0x010D533B
		public MotorParkourMainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041AC9 RID: 269001 RVA: 0x010D7144 File Offset: 0x010D5344
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnRewardBtnClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(13, new Action(this.OnGotoBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041ACA RID: 269002 RVA: 0x010D73E4 File Offset: 0x010D55E4
		protected override UniTask OnBeforeStartAsync()
		{
			MotorParkourMainView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorParkourMainView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041ACB RID: 269003 RVA: 0x010D7428 File Offset: 0x010D5628
		protected override void OnBeforeShow()
		{
			this.LevelScrollLayout.RefreshByData(this.ActivityData.GetLevelDataList(), delegate
			{
				this.RefreshView(this.CurLevelData);
				this.LevelScrollLayout.LateScrollTo(this.LevelScrollLayout.GetItemByKey(this.CurLevelData.Id), null, false);
			}, true);
			bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female;
			string resourceId = flag ? "T_LevelSelectBgFemale" : "T_LevelSelectBgMale";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			string resourceId2 = flag ? "T_RoleFemale" : "T_RoleMale";
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2);
			base.SetTextureByPath(resourcePath2, base.GetTexture(16), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "MotorParkour_RewardProgress_1", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.ActivityData.GetFinishedTaskNum(),
				this.ActivityData.GetAllTaskNum()
			}));
			UUIItem item = base.GetItem(15);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.ActivityData.RewardHasRedDot());
		}

		// Token: 0x06041ACC RID: 269004 RVA: 0x010D7534 File Offset: 0x010D5734
		private void RefreshView(MotorParkourLevelData levelData)
		{
			this.CurLevelData = levelData;
			MotorParkourLevelItem scrollItemByKey = this.LevelScrollLayout.GetScrollItemByKey(levelData.Id);
			int? num = (scrollItemByKey != null) ? new int?(scrollItemByKey.GridIndex) : null;
			if (num != null)
			{
				this.LevelScrollLayout.SelectGridProxy(num.Value, false);
			}
			else
			{
				this.LevelScrollLayout.SelectGridProxy(-1, false);
			}
			UUITexture texture = base.GetTexture(8);
			base.SetTextureByPath(levelData.RaceTrackTexture, texture, null, null);
			if (texture != null)
			{
				UUIItem uuiitem = texture;
				FRotator frotator = new FRotator(0f, (float)levelData.RouteTextureRotation, 0f);
				uuiitem.SetUIRelativeRotation(frotator);
			}
			this.RankLayout.RefreshByData(levelData.HistoryRankList, null, true);
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(levelData.BestRecordTime != 0);
			}
			string remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat5((double)levelData.BestRecordTime * Singleton<TimeUtil>.Instance.Millisecond);
			UUIText text = base.GetText(12);
			if (text != null)
			{
				text.SetText(remainTimeDataFormat, true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), levelData.RouteName, Array.Empty<object>());
		}

		// Token: 0x06041ACD RID: 269005 RVA: 0x010D7664 File Offset: 0x010D5864
		protected override void OnTick(float delta)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(this.ActivityData.EndShowTime, localTextNew);
			UUIText text = base.GetText(6);
			if (text == null)
			{
				return;
			}
			text.SetText(remainTimeText, true);
		}

		// Token: 0x06041ACE RID: 269006 RVA: 0x010D76A8 File Offset: 0x010D58A8
		private void OnToggleCallback(MotorParkourLevelData levelData)
		{
			if (levelData.IsUnLock)
			{
				this.RefreshView(levelData);
				base.PlaySequence("Switch", null, false);
				return;
			}
			if (!levelData.IsReachUnlockTime())
			{
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("GuideTips_96101_Content", null);
				string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(levelData.UnlockTime, localTextNew);
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(remainTimeText);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorParkour_GuideText_1", Array.Empty<object>());
		}

		// Token: 0x06041ACF RID: 269007 RVA: 0x010D7718 File Offset: 0x010D5918
		private MotorParkourLevelItem CreateLevelItem()
		{
			return new MotorParkourLevelItem
			{
				OnToggleCallback = new Action<MotorParkourLevelData>(this.OnToggleCallback)
			};
		}

		// Token: 0x06041AD0 RID: 269008 RVA: 0x010D7731 File Offset: 0x010D5931
		private MotorParkourRankItem CreateRankItem()
		{
			return new MotorParkourRankItem();
		}

		// Token: 0x06041AD1 RID: 269009 RVA: 0x010D7738 File Offset: 0x010D5938
		private void OnRewardBtnClick()
		{
			MotorParkourLevelData selectedLevelDataInRewardView = this.ActivityData.GetSelectedLevelDataInRewardView();
			MotorParkourRewardView.IMotorParkourRewardViewData param = new MotorParkourRewardView.MotorParkourRewardViewData
			{
				ActivityData = this.ActivityData,
				SelectLevelData = selectedLevelDataInRewardView
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorParkourRewardView, param, null);
		}

		// Token: 0x06041AD2 RID: 269010 RVA: 0x010D777B File Offset: 0x010D597B
		private void OnGotoBtnClick()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_600064_Text", Array.Empty<object>());
				return;
			}
			ControllerBase<MotorParkourController>.Instance.EnterMotorParkourDungeonDirectly(this.CurLevelData.Id);
		}

		// Token: 0x06041AD3 RID: 269011 RVA: 0x010D77B3 File Offset: 0x010D59B3
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024A83 RID: 150147
		[Nullable(2)]
		private MotorParkourActivityData ActivityData;

		// Token: 0x04024A84 RID: 150148
		private MotorParkourLevelData CurLevelData;

		// Token: 0x04024A85 RID: 150149
		private GenericScrollViewNew<MotorParkourLevelItem, MotorParkourLevelData> LevelScrollLayout;

		// Token: 0x04024A86 RID: 150150
		private GenericLayout<MotorParkourRankItem, MotorParkourRankData> RankLayout;

		// Token: 0x04024A87 RID: 150151
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x0200C6E9 RID: 50921
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3D4 RID: 250836
			public const int TextureBg = 0;

			// Token: 0x0403D3D5 RID: 250837
			public const int ItemCaption = 1;

			// Token: 0x0403D3D6 RID: 250838
			public const int ScrollLayoutLevel = 2;

			// Token: 0x0403D3D7 RID: 250839
			public const int ItemLevel = 3;

			// Token: 0x0403D3D8 RID: 250840
			public const int BtnReward = 4;

			// Token: 0x0403D3D9 RID: 250841
			public const int TextRewardProgress = 5;

			// Token: 0x0403D3DA RID: 250842
			public const int TextRewardTime = 6;

			// Token: 0x0403D3DB RID: 250843
			public const int TextRaceTrackTitle = 7;

			// Token: 0x0403D3DC RID: 250844
			public const int TextureRaceTrack = 8;

			// Token: 0x0403D3DD RID: 250845
			public const int TextRankTitle = 9;

			// Token: 0x0403D3DE RID: 250846
			public const int LayoutRank = 10;

			// Token: 0x0403D3DF RID: 250847
			public const int ItemRank = 11;

			// Token: 0x0403D3E0 RID: 250848
			public const int TextBestRecordTime = 12;

			// Token: 0x0403D3E1 RID: 250849
			public const int BtnGoto = 13;

			// Token: 0x0403D3E2 RID: 250850
			public const int ItemBestRecordPanel = 14;

			// Token: 0x0403D3E3 RID: 250851
			public const int ItemRewardRedDot = 15;

			// Token: 0x0403D3E4 RID: 250852
			public const int TextureCharacterBg = 16;
		}
	}
}
