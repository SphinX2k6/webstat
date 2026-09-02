using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level
{
	// Token: 0x02006602 RID: 26114
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballLevelInfoPanel : UiPanelBase
	{
		// Token: 0x06041410 RID: 267280 RVA: 0x010BD548 File Offset: 0x010BB748
		protected unsafe override void OnRegisterComponent()
		{
			int num = 22;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnBtnEnemyDetailClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041411 RID: 267281 RVA: 0x010BD894 File Offset: 0x010BBA94
		protected override UniTask OnBeforeStartAsync()
		{
			PinballLevelInfoPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballLevelInfoPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041412 RID: 267282 RVA: 0x010BD8D8 File Offset: 0x010BBAD8
		protected override void OnStart()
		{
			this.FirstRewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(10), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, null);
			this.StarLayout = new GenericLayout<PinballLevelInfoStarItem, IPinballLevelStarData>(base.GetVerticalLayout(14), new Func<PinballLevelInfoStarItem>(this.InitStarItem), base.GetItem(15).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06041413 RID: 267283 RVA: 0x010BD93A File Offset: 0x010BBB3A
		private PinballLevelInfoStarItem InitStarItem()
		{
			return new PinballLevelInfoStarItem();
		}

		// Token: 0x06041414 RID: 267284 RVA: 0x010BD941 File Offset: 0x010BBB41
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = new Func<TItem, bool>(this.OnShowRewardReceivedCallBack)
			};
		}

		// Token: 0x06041415 RID: 267285 RVA: 0x010BD95C File Offset: 0x010BBB5C
		private void RefreshScoreInfo(int curScore, int scoreLevelRewardLength, Func<int, int> getScoreLevel, Func<int, int> getScoreLevelDropId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Pinball_Level_Score", new <>z__ReadOnlySingleElementList<object>(curScore));
			UUISprite[] array = new UUISprite[]
			{
				base.GetSprite(5),
				base.GetSprite(6)
			};
			for (int i = 0; i < scoreLevelRewardLength; i++)
			{
				int num = getScoreLevel(i);
				int configDropId = getScoreLevelDropId(i);
				PinballLevelScoreData data = new PinballLevelScoreData
				{
					CurScore = curScore,
					ConfigScore = num,
					ConfigDropId = configDropId
				};
				this.ScoreRewardItems[i].Refresh(data);
				if (i != 0)
				{
					int num2 = getScoreLevel(i - 1);
					int num3 = num - num2;
					float fillAmount = Math.Min(1f, Math.Max(0f, (float)(curScore - num2) / (float)num3));
					array[i - 1].SetFillAmount(fillAmount);
				}
			}
		}

		// Token: 0x06041416 RID: 267286 RVA: 0x010BDA38 File Offset: 0x010BBC38
		private void RefreshStarInfo(int[] passedConditionIds, int starCondLength, Func<int, int> getStarCond)
		{
			List<IPinballLevelStarData> list = new List<IPinballLevelStarData>();
			for (int i = 0; i < starCondLength; i++)
			{
				int num = getStarCond(i);
				PinballLevelTarget? pinballLevelTargetConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelTargetConfigById(num);
				PinballLevelStarData item = new PinballLevelStarData
				{
					ConditionId = num,
					Passed = (Array.IndexOf<int>(passedConditionIds, num) >= 0),
					ConfigConditionDesc = pinballLevelTargetConfigById.Value.CondDesc,
					ConfigTargetValue = new int?(pinballLevelTargetConfigById.Value.NeedNum)
				};
				list.Add(item);
			}
			this.StarLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06041417 RID: 267287 RVA: 0x010BDAD4 File Offset: 0x010BBCD4
		private void RefreshFirstRewardInfo(int rewardDropId)
		{
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(rewardDropId);
			this.FirstRewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
		}

		// Token: 0x06041418 RID: 267288 RVA: 0x010BDAFC File Offset: 0x010BBCFC
		public void Refresh(IPinballLevelInfoData data)
		{
			this.Data = data;
			PinballLevelConfig? levelConfig = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(data.LevelId);
			if (levelConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), levelConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), levelConfig.Value.Desc, Array.Empty<object>());
			UUIText text = base.GetText(2);
			TWeakObjectPtr<UUIItem> rootUIComp = base.GetVerticalLayout(14).RootUIComp;
			UUIItem item = base.GetItem(16);
			UUIItem item2 = base.GetItem(3);
			UUIButtonComponent button = base.GetButton(13);
			UUIText text2 = base.GetText(18);
			UUIText text3 = base.GetText(19);
			UUITexture texture = base.GetTexture(20);
			text.SetUIActive(data.ShowDesc.GetValueOrDefault());
			if (data.ShowDesc.GetValueOrDefault() && !StringUtils.IsBlank(levelConfig.Value.ScoreDesc))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, levelConfig.Value.ScoreDesc, Array.Empty<object>());
			}
			rootUIComp.Get().SetUIActive(data.ShowStar.GetValueOrDefault());
			if (data.ShowStar.GetValueOrDefault() && data.LevelStarConditionIds != null)
			{
				this.RefreshStarInfo(data.LevelStarConditionIds, levelConfig.Value.StarCondLength, (int i) => levelConfig.Value.StarCond(i));
			}
			item.SetUIActive(data.ShowReward.GetValueOrDefault());
			if (data.ShowReward.GetValueOrDefault())
			{
				int rewardDropId = data.RewardDropId ?? levelConfig.Value.FirstClearDropId;
				this.RefreshFirstRewardInfo(rewardDropId);
			}
			item2.SetUIActive(data.ShowScore.GetValueOrDefault());
			if (data.ShowScore.GetValueOrDefault())
			{
				int valueOrDefault = this.Data.LevelScore.GetValueOrDefault();
				this.RefreshScoreInfo(valueOrDefault, levelConfig.Value.ScoreLevelRewardLength, (int i) => levelConfig.Value.ScoreLevelReward(i).Value.Key, (int i) => levelConfig.Value.ScoreLevelReward(i).Value.Value);
			}
			if (data.RewardClearTitle != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, data.RewardClearTitle, Array.Empty<object>());
			}
			text3.SetUIActive(false);
			texture.SetUIActive(false);
			bool valueOrDefault2 = data.LevelLock.GetValueOrDefault();
			button.RootUIComp.Get().SetUIActive(!valueOrDefault2);
			this.LockTipsItem.SetUiActive(valueOrDefault2);
			this.LockTipsItem.SetTextByText(data.LevelLockTexts ?? "");
		}

		// Token: 0x06041419 RID: 267289 RVA: 0x010BDDF0 File Offset: 0x010BBFF0
		private bool OnShowRewardReceivedCallBack(TItem data)
		{
			return this.Data != null && this.Data.RewardReceived.GetValueOrDefault();
		}

		// Token: 0x0604141A RID: 267290 RVA: 0x010BDE1A File Offset: 0x010BC01A
		private void OnBtnEnemyDetailClick()
		{
			ControllerBase<PinballController>.Instance.OpenMonsterDetailView(this.Data.RealLevelId).Forget<bool>();
		}

		// Token: 0x0604141B RID: 267291 RVA: 0x010BDE38 File Offset: 0x010BC038
		private void OnBtnConfirmClick()
		{
			PinballFormationViewData param = new PinballFormationViewData
			{
				LevelId = this.Data.LevelId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFormationView, param, null);
		}

		// Token: 0x0604141C RID: 267292 RVA: 0x010BDE70 File Offset: 0x010BC070
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			string a = configParams[0];
			UUIItem uuiitem = null;
			if (!(a == "BtnGo"))
			{
				if (!(a == "BtnDetail"))
				{
					if (!(a == "Reward"))
					{
						if (!(a == "Scroll"))
						{
							if (a == "RewardProgress")
							{
								uuiitem = base.GetItem(3);
							}
						}
						else
						{
							uuiitem = base.GetItem(21);
						}
					}
					else
					{
						uuiitem = base.GetScrollViewWithScrollbar(10).RootUIComp;
					}
				}
				else
				{
					uuiitem = base.GetButton(12).RootUIComp.Get();
				}
			}
			else
			{
				uuiitem = base.GetButton(13).RootUIComp.Get();
			}
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x0402486C RID: 149612
		[Nullable(2)]
		private IPinballLevelInfoData Data;

		// Token: 0x0402486D RID: 149613
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> FirstRewardScroll;

		// Token: 0x0402486E RID: 149614
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<PinballLevelInfoStarItem, IPinballLevelStarData> StarLayout;

		// Token: 0x0402486F RID: 149615
		private readonly List<PinballLevelInfoScoreItem> ScoreRewardItems = new List<PinballLevelInfoScoreItem>();

		// Token: 0x04024870 RID: 149616
		[Nullable(2)]
		private ButtonItem ConfirmBtnItem;

		// Token: 0x04024871 RID: 149617
		[Nullable(2)]
		private FunctionalPanelConditionActivate LockTipsItem;

		// Token: 0x0200C622 RID: 50722
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CFC5 RID: 249797
			TxtTitle,
			// Token: 0x0403CFC6 RID: 249798
			TxtDesc,
			// Token: 0x0403CFC7 RID: 249799
			TxtSpecialExplan,
			// Token: 0x0403CFC8 RID: 249800
			BgScoreProgress,
			// Token: 0x0403CFC9 RID: 249801
			TxtScore,
			// Token: 0x0403CFCA RID: 249802
			SprBar1,
			// Token: 0x0403CFCB RID: 249803
			SprBar2,
			// Token: 0x0403CFCC RID: 249804
			ScoreRewardItem1,
			// Token: 0x0403CFCD RID: 249805
			ScoreRewardItem2,
			// Token: 0x0403CFCE RID: 249806
			ScoreRewardItem3,
			// Token: 0x0403CFCF RID: 249807
			FirstRewardScorll,
			// Token: 0x0403CFD0 RID: 249808
			FirstRewardItem,
			// Token: 0x0403CFD1 RID: 249809
			BtnEnemyDetail,
			// Token: 0x0403CFD2 RID: 249810
			BtnConfirm,
			// Token: 0x0403CFD3 RID: 249811
			StarLayout,
			// Token: 0x0403CFD4 RID: 249812
			StarItem,
			// Token: 0x0403CFD5 RID: 249813
			BgFirstReward,
			// Token: 0x0403CFD6 RID: 249814
			BgLockTips,
			// Token: 0x0403CFD7 RID: 249815
			TxtRewardClearTitleName,
			// Token: 0x0403CFD8 RID: 249816
			TxtRewardClearDoing,
			// Token: 0x0403CFD9 RID: 249817
			TexRewardClearFinish,
			// Token: 0x0403CFDA RID: 249818
			ItemScrollView
		}
	}
}
