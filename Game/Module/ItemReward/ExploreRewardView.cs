using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B4B RID: 23371
	[NullableContext(2)]
	[Nullable(0)]
	public class ExploreRewardView : UiViewBase
	{
		// Token: 0x0603B1EA RID: 242154 RVA: 0x00EF51B3 File Offset: 0x00EF33B3
		[NullableContext(1)]
		public ExploreRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603B1EB RID: 242155 RVA: 0x00EF51C8 File Offset: 0x00EF33C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B1EC RID: 242156 RVA: 0x00EF53B0 File Offset: 0x00EF35B0
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<IReadOnlyList<RewardItemData>>(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshRewardButton, new Action(this.OnRefreshRewardButton));
			Singleton<EventSystem>.Instance.Add(EEventName.FriendApplyReceived, new Action(this.OnRefreshFriendApply));
			Singleton<EventSystem>.Instance.Add(EEventName.FriendApplicationListUpdate, new Action(this.OnRefreshFriendList));
			Singleton<EventSystem>.Instance.Add(EEventName.FriendAdded, new Action(this.OnRefreshFriendList));
			this.UiViewSequence.AddSequenceFinishEvent("Success", new Action<string>(this.OnRewardSequenceEnd), false);
			this.UiViewSequence.AddSequenceFinishEvent("Fail", new Action<string>(this.OnRewardSequenceEnd), false);
		}

		// Token: 0x0603B1ED RID: 242157 RVA: 0x00EF5484 File Offset: 0x00EF3684
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardViewItemList, new Action<IReadOnlyList<RewardItemData>>(this.OnRefreshRewardItemList));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshRewardButton, new Action(this.OnRefreshRewardButton));
			Singleton<EventSystem>.Instance.Remove(EEventName.FriendApplyReceived, new Action(this.OnRefreshFriendApply));
			Singleton<EventSystem>.Instance.Remove(EEventName.FriendApplicationListUpdate, new Action(this.OnRefreshFriendList));
			Singleton<EventSystem>.Instance.Remove(EEventName.FriendAdded, new Action(this.OnRefreshFriendList));
			this.UiViewSequence.RemoveSequenceFinishEvent("Success", new Action<string>(this.OnRewardSequenceEnd));
			this.UiViewSequence.RemoveSequenceFinishEvent("Fail", new Action<string>(this.OnRewardSequenceEnd));
		}

		// Token: 0x0603B1EE RID: 242158 RVA: 0x00EF5558 File Offset: 0x00EF3758
		private void OnRefreshRewardButton()
		{
			List<IRewardExploreConfirmButton> buttonInfoList = this.ExtendRewardInfo.ButtonInfoList;
			if (buttonInfoList != null && buttonInfoList.Count > 0)
			{
				int num = 0;
				foreach (IRewardExploreConfirmButton buttonData in buttonInfoList)
				{
					this.ButtonList[num].Refresh(buttonData);
					num++;
				}
			}
		}

		// Token: 0x0603B1EF RID: 242159 RVA: 0x00EF55D0 File Offset: 0x00EF37D0
		private void OnRefreshFriendList()
		{
			List<IRewardExploreFriendData> exploreFriendDataList = ControllerBase<ItemRewardController>.Instance.BuildExploreFriendDataList();
			ControllerBase<ItemRewardController>.Instance.SetExploreFriendDataList(exploreFriendDataList);
			this.RefreshFriendList();
		}

		// Token: 0x0603B1F0 RID: 242160 RVA: 0x00EF55FC File Offset: 0x00EF37FC
		private void OnRefreshFriendApply()
		{
			List<int> list = ControllerBase<ItemRewardController>.Instance.BuildExploreFriendIdList();
			if (ControllerBase<FriendController>.Instance.CheckHasAnyApplied(list.ToArray()) && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendApplyView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.FriendApplyView, list, null);
			}
		}

		// Token: 0x0603B1F1 RID: 242161 RVA: 0x00EF5648 File Offset: 0x00EF3848
		[NullableContext(1)]
		private void OnRefreshRewardItemList(IReadOnlyList<RewardItemData> itemList)
		{
			if (this.RewardItemList == null)
			{
				return;
			}
			this.RewardItemList.Refresh(this.RewardData.GetItemList(), true);
		}

		// Token: 0x0603B1F2 RID: 242162 RVA: 0x00EF566C File Offset: 0x00EF386C
		protected override UniTask OnBeforeStartAsync()
		{
			ExploreRewardView.<OnBeforeStartAsync>d__31 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ExploreRewardView.<OnBeforeStartAsync>d__31>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1F3 RID: 242163 RVA: 0x00EF56AF File Offset: 0x00EF38AF
		protected override void OnStart()
		{
			this.RefreshTipText();
			if (this.RefreshTitleVisible())
			{
				this.RefreshTitleText();
				this.RefreshTitleColor();
			}
			if (this.RefreshTitleTextureVisible())
			{
				this.RefreshTitleTexture();
			}
		}

		// Token: 0x0603B1F4 RID: 242164 RVA: 0x00EF56D9 File Offset: 0x00EF38D9
		protected override void OnAfterShow()
		{
			if (this.ExtendRewardInfo.ExploreFriendDataList != null)
			{
				this.OnRefreshFriendApply();
			}
		}

		// Token: 0x0603B1F5 RID: 242165 RVA: 0x00EF56F0 File Offset: 0x00EF38F0
		protected override void OnAfterPlayStartSequence()
		{
			if (this.RewardData.GetRewardInfo().IsSuccess)
			{
				this.UiViewSequence.PlaySequence("Success", true, null);
				return;
			}
			this.UiViewSequence.PlaySequence("Fail", true, null);
		}

		// Token: 0x0603B1F6 RID: 242166 RVA: 0x00EF5744 File Offset: 0x00EF3944
		protected override void OnBeforeDestroy()
		{
			Action onCloseCallback = this.RewardInfo.OnCloseCallback;
			if (onCloseCallback != null)
			{
				onCloseCallback();
			}
			this.RewardData = null;
			this.RewardInfo = null;
			RewardExploreRecord rewardExploreRecord = this.RewardExploreRecord;
			if (rewardExploreRecord != null)
			{
				rewardExploreRecord.Destroy(null);
			}
			this.RewardExploreRecord = null;
			RewardItemList rewardItemList = this.RewardItemList;
			if (rewardItemList != null)
			{
				rewardItemList.Destroy(null);
			}
			this.RewardItemList = null;
			RewardExploreBarList rewardExploreBarList = this.RewardExploreBarList;
			if (rewardExploreBarList != null)
			{
				rewardExploreBarList.Destroy(null);
			}
			this.RewardExploreBarList = null;
			RewardExploreTargetReachedList rewardExploreTargetReachedList = this.RewardExploreTargetReachedList;
			if (rewardExploreTargetReachedList != null)
			{
				rewardExploreTargetReachedList.Destroy(null);
			}
			this.RewardExploreTargetReachedList = null;
			RewardExploreScoreSubTitle rewardExploreScoreSubTitle = this.RewardExploreScoreSubTitle;
			if (rewardExploreScoreSubTitle != null)
			{
				rewardExploreScoreSubTitle.Destroy(null);
			}
			this.RewardExploreScoreSubTitle = null;
			RewardExploreToggle rewardExploreToggle = this.RewardExploreToggle;
			if (rewardExploreToggle != null)
			{
				rewardExploreToggle.Destroy(null);
			}
			this.RewardExploreToggle = null;
			RewardExploreDescription rewardExploreDescription = this.RewardExploreDescription;
			if (rewardExploreDescription != null)
			{
				rewardExploreDescription.Destroy(null);
			}
			this.RewardExploreDescription = null;
			RewardExploreRoguelikeBossChallengeItem rewardExploreRoguelikeBossChallengeItem = this.RewardExploreRoguelikeBossChallengeItem;
			if (rewardExploreRoguelikeBossChallengeItem != null)
			{
				rewardExploreRoguelikeBossChallengeItem.Destroy(null);
			}
			this.RewardExploreRoguelikeBossChallengeItem = null;
			BagFullTip bagFullTip = this.BagFullTip;
			if (bagFullTip != null)
			{
				bagFullTip.Destroy(null);
			}
			this.BagFullTip = null;
			foreach (RewardExploreConfirmButton rewardExploreConfirmButton in this.ButtonList)
			{
				rewardExploreConfirmButton.Destroy(null);
			}
			this.ButtonList.Clear();
			ModelBase<ItemRewardModel>.Instance.ClearCurrentRewardData();
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FriendApplyView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FriendApplyView, null);
			}
		}

		// Token: 0x0603B1F7 RID: 242167 RVA: 0x00EF58D0 File Offset: 0x00EF3AD0
		private bool RefreshTitleVisible()
		{
			UUIItem item = base.GetItem(0);
			bool flag = !StringUtils.IsEmpty(this.RewardInfo.Title);
			item.SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1F8 RID: 242168 RVA: 0x00EF5900 File Offset: 0x00EF3B00
		private void RefreshTitleText()
		{
			UUIText text = base.GetText(1);
			string title = this.RewardInfo.Title;
			if (!StringUtils.IsEmpty(title))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, title, Array.Empty<object>());
			}
		}

		// Token: 0x0603B1F9 RID: 242169 RVA: 0x00EF593C File Offset: 0x00EF3B3C
		private void RefreshTipText()
		{
			base.GetItem(18).SetUIActive(this.RewardInfo.Tip != null);
			if (this.RewardInfo.Tip != null)
			{
				base.GetText(19).SetText(this.RewardInfo.Tip, true);
			}
		}

		// Token: 0x0603B1FA RID: 242170 RVA: 0x00EF598C File Offset: 0x00EF3B8C
		private void RefreshTitleColor()
		{
			UUIText text = base.GetText(1);
			UUIEffectOutline uuieffectOutline = text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			string titleHexColor = this.RewardInfo.TitleHexColor;
			if (!StringUtils.IsEmpty(titleHexColor))
			{
				text.SetColor(FColor.FromHex(titleHexColor));
			}
			if (this.RewardInfo.IsSuccess)
			{
				uuieffectOutline.SetOutlineColor(FColor.FromHex("C48B29FF"));
				return;
			}
			uuieffectOutline.SetOutlineColor(FColor.FromHex("B33100FF"));
		}

		// Token: 0x0603B1FB RID: 242171 RVA: 0x00EF5A0C File Offset: 0x00EF3C0C
		private bool RefreshTitleTextureVisible()
		{
			UUIItem texture = base.GetTexture(2);
			bool flag = !StringUtils.IsEmpty(this.RewardInfo.TitleIconPath);
			texture.SetUIActive(flag);
			return flag;
		}

		// Token: 0x0603B1FC RID: 242172 RVA: 0x00EF5A3C File Offset: 0x00EF3C3C
		private void RefreshTitleTexture()
		{
			UUITexture titleTexture = base.GetTexture(2);
			string titleIconPath = this.RewardInfo.TitleIconPath;
			string titleIconHexColor = this.RewardInfo.TitleIconHexColor;
			if (!StringUtils.IsEmpty(titleIconPath))
			{
				titleTexture.SetUIActive(false);
				base.SetTextureByPath(titleIconPath, titleTexture, null, delegate(bool _)
				{
					titleTexture.SetUIActive(true);
				});
			}
			if (!StringUtils.IsEmpty(titleIconHexColor))
			{
				titleTexture.SetColor(FColor.FromHex(titleIconHexColor));
			}
		}

		// Token: 0x0603B1FD RID: 242173 RVA: 0x00EF5AC4 File Offset: 0x00EF3CC4
		private void RefreshFriendList()
		{
			List<IRewardExploreFriendData> exploreFriendDataList = this.ExtendRewardInfo.ExploreFriendDataList;
			if (exploreFriendDataList != null)
			{
				GenericLayout<RewardExploreFriendItem, IRewardExploreFriendData> rewardExploreFriendList = this.RewardExploreFriendList;
				if (rewardExploreFriendList == null)
				{
					return;
				}
				rewardExploreFriendList.RefreshByData(exploreFriendDataList, null, false);
			}
		}

		// Token: 0x0603B1FE RID: 242174 RVA: 0x00EF5AF4 File Offset: 0x00EF3CF4
		private UniTask NewExploreRecord()
		{
			ExploreRewardView.<NewExploreRecord>d__43 <NewExploreRecord>d__;
			<NewExploreRecord>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewExploreRecord>d__.<>4__this = this;
			<NewExploreRecord>d__.<>1__state = -1;
			<NewExploreRecord>d__.<>t__builder.Start<ExploreRewardView.<NewExploreRecord>d__43>(ref <NewExploreRecord>d__);
			return <NewExploreRecord>d__.<>t__builder.Task;
		}

		// Token: 0x0603B1FF RID: 242175 RVA: 0x00EF5B38 File Offset: 0x00EF3D38
		private UniTask NewRewardItemList()
		{
			ExploreRewardView.<NewRewardItemList>d__44 <NewRewardItemList>d__;
			<NewRewardItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRewardItemList>d__.<>4__this = this;
			<NewRewardItemList>d__.<>1__state = -1;
			<NewRewardItemList>d__.<>t__builder.Start<ExploreRewardView.<NewRewardItemList>d__44>(ref <NewRewardItemList>d__);
			return <NewRewardItemList>d__.<>t__builder.Task;
		}

		// Token: 0x0603B200 RID: 242176 RVA: 0x00EF5B7C File Offset: 0x00EF3D7C
		private UniTask NewBagFullTip()
		{
			ExploreRewardView.<NewBagFullTip>d__45 <NewBagFullTip>d__;
			<NewBagFullTip>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewBagFullTip>d__.<>4__this = this;
			<NewBagFullTip>d__.<>1__state = -1;
			<NewBagFullTip>d__.<>t__builder.Start<ExploreRewardView.<NewBagFullTip>d__45>(ref <NewBagFullTip>d__);
			return <NewBagFullTip>d__.<>t__builder.Task;
		}

		// Token: 0x0603B201 RID: 242177 RVA: 0x00EF5BC0 File Offset: 0x00EF3DC0
		private UniTask NewExploreBarList()
		{
			ExploreRewardView.<NewExploreBarList>d__46 <NewExploreBarList>d__;
			<NewExploreBarList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewExploreBarList>d__.<>4__this = this;
			<NewExploreBarList>d__.<>1__state = -1;
			<NewExploreBarList>d__.<>t__builder.Start<ExploreRewardView.<NewExploreBarList>d__46>(ref <NewExploreBarList>d__);
			return <NewExploreBarList>d__.<>t__builder.Task;
		}

		// Token: 0x0603B202 RID: 242178 RVA: 0x00EF5C04 File Offset: 0x00EF3E04
		private UniTask NewExploreDescription()
		{
			ExploreRewardView.<NewExploreDescription>d__47 <NewExploreDescription>d__;
			<NewExploreDescription>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewExploreDescription>d__.<>4__this = this;
			<NewExploreDescription>d__.<>1__state = -1;
			<NewExploreDescription>d__.<>t__builder.Start<ExploreRewardView.<NewExploreDescription>d__47>(ref <NewExploreDescription>d__);
			return <NewExploreDescription>d__.<>t__builder.Task;
		}

		// Token: 0x0603B203 RID: 242179 RVA: 0x00EF5C48 File Offset: 0x00EF3E48
		private UniTask NewTargetReachedList()
		{
			ExploreRewardView.<NewTargetReachedList>d__48 <NewTargetReachedList>d__;
			<NewTargetReachedList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewTargetReachedList>d__.<>4__this = this;
			<NewTargetReachedList>d__.<>1__state = -1;
			<NewTargetReachedList>d__.<>t__builder.Start<ExploreRewardView.<NewTargetReachedList>d__48>(ref <NewTargetReachedList>d__);
			return <NewTargetReachedList>d__.<>t__builder.Task;
		}

		// Token: 0x0603B204 RID: 242180 RVA: 0x00EF5C8C File Offset: 0x00EF3E8C
		private UniTask NewScoreSubTitle()
		{
			ExploreRewardView.<NewScoreSubTitle>d__49 <NewScoreSubTitle>d__;
			<NewScoreSubTitle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewScoreSubTitle>d__.<>4__this = this;
			<NewScoreSubTitle>d__.<>1__state = -1;
			<NewScoreSubTitle>d__.<>t__builder.Start<ExploreRewardView.<NewScoreSubTitle>d__49>(ref <NewScoreSubTitle>d__);
			return <NewScoreSubTitle>d__.<>t__builder.Task;
		}

		// Token: 0x0603B205 RID: 242181 RVA: 0x00EF5CD0 File Offset: 0x00EF3ED0
		private UniTask NewOnlineChallengePlayer()
		{
			ExploreRewardView.<NewOnlineChallengePlayer>d__50 <NewOnlineChallengePlayer>d__;
			<NewOnlineChallengePlayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewOnlineChallengePlayer>d__.<>4__this = this;
			<NewOnlineChallengePlayer>d__.<>1__state = -1;
			<NewOnlineChallengePlayer>d__.<>t__builder.Start<ExploreRewardView.<NewOnlineChallengePlayer>d__50>(ref <NewOnlineChallengePlayer>d__);
			return <NewOnlineChallengePlayer>d__.<>t__builder.Task;
		}

		// Token: 0x0603B206 RID: 242182 RVA: 0x00EF5D14 File Offset: 0x00EF3F14
		private UniTask NewStateToggle()
		{
			ExploreRewardView.<NewStateToggle>d__51 <NewStateToggle>d__;
			<NewStateToggle>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewStateToggle>d__.<>4__this = this;
			<NewStateToggle>d__.<>1__state = -1;
			<NewStateToggle>d__.<>t__builder.Start<ExploreRewardView.<NewStateToggle>d__51>(ref <NewStateToggle>d__);
			return <NewStateToggle>d__.<>t__builder.Task;
		}

		// Token: 0x0603B207 RID: 242183 RVA: 0x00EF5D58 File Offset: 0x00EF3F58
		private UniTask NewScoreReach()
		{
			ExploreRewardView.<NewScoreReach>d__52 <NewScoreReach>d__;
			<NewScoreReach>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewScoreReach>d__.<>4__this = this;
			<NewScoreReach>d__.<>1__state = -1;
			<NewScoreReach>d__.<>t__builder.Start<ExploreRewardView.<NewScoreReach>d__52>(ref <NewScoreReach>d__);
			return <NewScoreReach>d__.<>t__builder.Task;
		}

		// Token: 0x0603B208 RID: 242184 RVA: 0x00EF5D9C File Offset: 0x00EF3F9C
		private UniTask NewAccumulatedScoreItem()
		{
			ExploreRewardView.<NewAccumulatedScoreItem>d__53 <NewAccumulatedScoreItem>d__;
			<NewAccumulatedScoreItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewAccumulatedScoreItem>d__.<>4__this = this;
			<NewAccumulatedScoreItem>d__.<>1__state = -1;
			<NewAccumulatedScoreItem>d__.<>t__builder.Start<ExploreRewardView.<NewAccumulatedScoreItem>d__53>(ref <NewAccumulatedScoreItem>d__);
			return <NewAccumulatedScoreItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B209 RID: 242185 RVA: 0x00EF5DE0 File Offset: 0x00EF3FE0
		private UniTask NewFriendList()
		{
			ExploreRewardView.<NewFriendList>d__54 <NewFriendList>d__;
			<NewFriendList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewFriendList>d__.<>4__this = this;
			<NewFriendList>d__.<>1__state = -1;
			<NewFriendList>d__.<>t__builder.Start<ExploreRewardView.<NewFriendList>d__54>(ref <NewFriendList>d__);
			return <NewFriendList>d__.<>t__builder.Task;
		}

		// Token: 0x0603B20A RID: 242186 RVA: 0x00EF5E24 File Offset: 0x00EF4024
		private UniTask NewBabelTowerSuccessItem()
		{
			ExploreRewardView.<NewBabelTowerSuccessItem>d__55 <NewBabelTowerSuccessItem>d__;
			<NewBabelTowerSuccessItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewBabelTowerSuccessItem>d__.<>4__this = this;
			<NewBabelTowerSuccessItem>d__.<>1__state = -1;
			<NewBabelTowerSuccessItem>d__.<>t__builder.Start<ExploreRewardView.<NewBabelTowerSuccessItem>d__55>(ref <NewBabelTowerSuccessItem>d__);
			return <NewBabelTowerSuccessItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B20B RID: 242187 RVA: 0x00EF5E68 File Offset: 0x00EF4068
		private UniTask NewDangoAbyssSuccessItem()
		{
			ExploreRewardView.<NewDangoAbyssSuccessItem>d__56 <NewDangoAbyssSuccessItem>d__;
			<NewDangoAbyssSuccessItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewDangoAbyssSuccessItem>d__.<>4__this = this;
			<NewDangoAbyssSuccessItem>d__.<>1__state = -1;
			<NewDangoAbyssSuccessItem>d__.<>t__builder.Start<ExploreRewardView.<NewDangoAbyssSuccessItem>d__56>(ref <NewDangoAbyssSuccessItem>d__);
			return <NewDangoAbyssSuccessItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B20C RID: 242188 RVA: 0x00EF5EAC File Offset: 0x00EF40AC
		private UniTask NewHonamiTowerSuccessItem()
		{
			ExploreRewardView.<NewHonamiTowerSuccessItem>d__57 <NewHonamiTowerSuccessItem>d__;
			<NewHonamiTowerSuccessItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewHonamiTowerSuccessItem>d__.<>4__this = this;
			<NewHonamiTowerSuccessItem>d__.<>1__state = -1;
			<NewHonamiTowerSuccessItem>d__.<>t__builder.Start<ExploreRewardView.<NewHonamiTowerSuccessItem>d__57>(ref <NewHonamiTowerSuccessItem>d__);
			return <NewHonamiTowerSuccessItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B20D RID: 242189 RVA: 0x00EF5EF0 File Offset: 0x00EF40F0
		private UniTask NewRoguelikeBossChallengeItem()
		{
			ExploreRewardView.<NewRoguelikeBossChallengeItem>d__58 <NewRoguelikeBossChallengeItem>d__;
			<NewRoguelikeBossChallengeItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<NewRoguelikeBossChallengeItem>d__.<>4__this = this;
			<NewRoguelikeBossChallengeItem>d__.<>1__state = -1;
			<NewRoguelikeBossChallengeItem>d__.<>t__builder.Start<ExploreRewardView.<NewRoguelikeBossChallengeItem>d__58>(ref <NewRoguelikeBossChallengeItem>d__);
			return <NewRoguelikeBossChallengeItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B20E RID: 242190 RVA: 0x00EF5F34 File Offset: 0x00EF4134
		[NullableContext(1)]
		private RewardExploreConfirmButton NewButton(IRewardExploreConfirmButton buttonData, int buttonIndex)
		{
			UUIItem item = base.GetItem(5);
			UUIItem item2 = base.GetItem(4);
			RewardExploreConfirmButton rewardExploreConfirmButton = new RewardExploreConfirmButton(Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2), buttonIndex);
			rewardExploreConfirmButton.Refresh(buttonData);
			rewardExploreConfirmButton.SetActive(true);
			this.ButtonList.Add(rewardExploreConfirmButton);
			return rewardExploreConfirmButton;
		}

		// Token: 0x0603B20F RID: 242191 RVA: 0x00EF5F84 File Offset: 0x00EF4184
		[NullableContext(1)]
		private RewardExploreFriendItem CreateFriendGrid()
		{
			return new RewardExploreFriendItem();
		}

		// Token: 0x0603B210 RID: 242192 RVA: 0x00EF5F8C File Offset: 0x00EF418C
		public EToggleState? GetBottomToggleState()
		{
			RewardExploreToggle rewardExploreToggle = this.RewardExploreToggle;
			if (rewardExploreToggle == null)
			{
				return null;
			}
			return rewardExploreToggle.GetToggleState();
		}

		// Token: 0x0603B211 RID: 242193 RVA: 0x00EF5FB2 File Offset: 0x00EF41B2
		[NullableContext(1)]
		private void OnRewardSequenceEnd(string seqName)
		{
			RewardExploreOnlineChallengePlayer rewardExploreOnlineChallengePlayer = this.RewardExploreOnlineChallengePlayer;
			if (rewardExploreOnlineChallengePlayer == null)
			{
				return;
			}
			rewardExploreOnlineChallengePlayer.FullRefresh();
		}

		// Token: 0x0402155C RID: 136540
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<IExploreRewardInfo> RewardData;

		// Token: 0x0402155D RID: 136541
		private IExploreRewardInfo RewardInfo;

		// Token: 0x0402155E RID: 136542
		private IExtendRewardInfo ExtendRewardInfo;

		// Token: 0x0402155F RID: 136543
		private RewardExploreRecord RewardExploreRecord;

		// Token: 0x04021560 RID: 136544
		private RewardItemList RewardItemList;

		// Token: 0x04021561 RID: 136545
		private RewardExploreBarList RewardExploreBarList;

		// Token: 0x04021562 RID: 136546
		private RewardExploreDescription RewardExploreDescription;

		// Token: 0x04021563 RID: 136547
		private RewardExploreTargetReachedList RewardExploreTargetReachedList;

		// Token: 0x04021564 RID: 136548
		private RewardExploreScoreSubTitle RewardExploreScoreSubTitle;

		// Token: 0x04021565 RID: 136549
		private RewardExploreOnlineChallengePlayer RewardExploreOnlineChallengePlayer;

		// Token: 0x04021566 RID: 136550
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RewardExploreFriendItem, IRewardExploreFriendData> RewardExploreFriendList;

		// Token: 0x04021567 RID: 136551
		private BagFullTip BagFullTip;

		// Token: 0x04021568 RID: 136552
		private RewardExploreToggle RewardExploreToggle;

		// Token: 0x04021569 RID: 136553
		private RewardExploreScore RewardExploreScore;

		// Token: 0x0402156A RID: 136554
		private RewardExploreAccumulatedScoreItem RewardExploreAccumulatedScoreItem;

		// Token: 0x0402156B RID: 136555
		private RewardExploreBabelSuccessItem RewardExploreBabelSuccessItem;

		// Token: 0x0402156C RID: 136556
		private RewardExploreDangoAbyssSuccessItem RewardExploreDangoAbyssSuccessItem;

		// Token: 0x0402156D RID: 136557
		private RewardExploreHonamiTowerSuccessItem RewardExploreHonamiTowerSuccessItem;

		// Token: 0x0402156E RID: 136558
		private RewardExploreRoguelikeBossChallengeItem RewardExploreRoguelikeBossChallengeItem;

		// Token: 0x0402156F RID: 136559
		[Nullable(1)]
		private readonly List<RewardExploreConfirmButton> ButtonList = new List<RewardExploreConfirmButton>();

		// Token: 0x04021570 RID: 136560
		[Nullable(1)]
		private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

		// Token: 0x04021571 RID: 136561
		[Nullable(1)]
		private const string FAIL_OUTLINE_COLOR = "B33100FF";

		// Token: 0x0200BB34 RID: 47924
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039C5D RID: 236637
			public const int TitleItem = 0;

			// Token: 0x04039C5E RID: 236638
			public const int TitleText = 1;

			// Token: 0x04039C5F RID: 236639
			public const int TitleTexture = 2;

			// Token: 0x04039C60 RID: 236640
			public const int ContentItem = 3;

			// Token: 0x04039C61 RID: 236641
			public const int ButtonHorizontalItem = 4;

			// Token: 0x04039C62 RID: 236642
			public const int ButtonItem = 5;

			// Token: 0x04039C63 RID: 236643
			public const int ToggleItem = 6;

			// Token: 0x04039C64 RID: 236644
			public const int DoubleTip = 18;

			// Token: 0x04039C65 RID: 236645
			public const int DoubleTipTxt = 19;

			// Token: 0x04039C66 RID: 236646
			public const int Content = 20;

			// Token: 0x04039C67 RID: 236647
			public const int FriendItem = 21;

			// Token: 0x04039C68 RID: 236648
			public const int FriendGrid = 22;

			// Token: 0x04039C69 RID: 236649
			public const int ItemTeam = 23;
		}
	}
}
