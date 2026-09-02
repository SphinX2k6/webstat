using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005181 RID: 20865
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikeActivityView : UiTickViewBase
	{
		// Token: 0x06035AF1 RID: 219889 RVA: 0x00D7C57B File Offset: 0x00D7A77B
		[NullableContext(1)]
		public RoguelikeActivityView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035AF2 RID: 219890 RVA: 0x00D7C590 File Offset: 0x00D7A790
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnBtnSkillTreeClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnBtnDoorClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnBtnShop));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035AF3 RID: 219891 RVA: 0x00D7C854 File Offset: 0x00D7AA54
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeActivityView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeActivityView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035AF4 RID: 219892 RVA: 0x00D7C898 File Offset: 0x00D7AA98
		protected override void OnStart()
		{
			this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
			this.CaptionItem.SetCloseCallBack(delegate
			{
				Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
			});
			Activity? localConfig = this.ActivityRogueData.LocalConfig;
			if (localConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), localConfig.Value.DescTheme, Array.Empty<object>());
			this.RefreshUi();
			if (this.NewUnlockPhantomList.Count > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikePhantomNewUnlockView, this.NewUnlockPhantomList, null);
			}
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.ClearTempAchieveInfo));
		}

		// Token: 0x06035AF5 RID: 219893 RVA: 0x00D7C950 File Offset: 0x00D7AB50
		protected override void OnBeforeShow()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RogueSkillUnlock, base.GetItem(8), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoguelikeAchievement, base.GetItem(9), null, 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoguelikeShop, base.GetItem(10), delegate(bool newState, int _)
			{
				UUIItem item = base.GetItem(10);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(newState);
			}, 0);
		}

		// Token: 0x06035AF6 RID: 219894 RVA: 0x00D7C9A9 File Offset: 0x00D7ABA9
		protected override void OnBeforeHide()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RogueSkillUnlock);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RoguelikeAchievement);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.RoguelikeShop);
		}

		// Token: 0x06035AF7 RID: 219895 RVA: 0x00D7C9CF File Offset: 0x00D7ABCF
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeCurrencyUpdate, new Action(this.RefreshUi));
		}

		// Token: 0x06035AF8 RID: 219896 RVA: 0x00D7C9ED File Offset: 0x00D7ABED
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeCurrencyUpdate, new Action(this.RefreshUi));
		}

		// Token: 0x06035AF9 RID: 219897 RVA: 0x00D7CA0B File Offset: 0x00D7AC0B
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoguelikeArchiveSaved, new Action<int>(this.ClearTempAchieveInfo));
		}

		// Token: 0x06035AFA RID: 219898 RVA: 0x00D7CA29 File Offset: 0x00D7AC29
		protected override void OnTick(float delta)
		{
			this.RefreshRemainTime();
		}

		// Token: 0x06035AFB RID: 219899 RVA: 0x00D7CA34 File Offset: 0x00D7AC34
		protected unsafe void OnBtnShop()
		{
			if (this.ActivityRogueData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			RogueSeasonData seasonData = this.ActivityRogueData.SeasonData;
			if (seasonData == null)
			{
				return;
			}
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(seasonData.SeasonId);
			if (rogueSeasonConfigById.Value.ShopId == 0)
			{
				return;
			}
			PayShopViewData payShopViewData = new PayShopViewData();
			PayShopViewData payShopViewData2 = payShopViewData;
			int num = 1;
			List<int> list = new List<int>(num);
			CollectionsMarshal.SetCount<int>(list, num);
			Span<int> span = CollectionsMarshal.AsSpan<int>(list);
			int index = 0;
			*span[index] = rogueSeasonConfigById.Value.ShopId;
			payShopViewData2.ShowShopIdList = list;
			payShopViewData.PayShopId = (PayShopDefine.EPayShopTabType)rogueSeasonConfigById.Value.ShopId;
			ModelBase<RoguelikeModel>.Instance.RecordRoguelikeShopRedDot();
			ControllerBase<PayShopController>.Instance.OpenPayShopView(payShopViewData, null);
		}

		// Token: 0x06035AFC RID: 219900 RVA: 0x00D7CB04 File Offset: 0x00D7AD04
		protected void OnBtnSkillTreeClick()
		{
			if (this.ActivityRogueData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			ActivityRogueData activityRogueData = this.ActivityRogueData;
			RogueSeasonData rogueSeasonData = (activityRogueData != null) ? activityRogueData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeSkillView(rogueSeasonData.SeasonId);
		}

		// Token: 0x06035AFD RID: 219901 RVA: 0x00D7CB5C File Offset: 0x00D7AD5C
		protected void OnBtnDoorClick()
		{
			if (this.ActivityRogueData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			ActivityRogueData activityRogueData = this.ActivityRogueData;
			RogueSeasonData rogueSeasonData = (activityRogueData != null) ? activityRogueData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				return;
			}
			if (ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId).Value.Achievement == 0)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeAchievementView, null, null);
		}

		// Token: 0x06035AFE RID: 219902 RVA: 0x00D7CBD8 File Offset: 0x00D7ADD8
		private void RefreshLastInfo()
		{
			RoguelikeLastInfo lastInfo = this.LastInfo;
			bool processingState = lastInfo != null && lastInfo.ModeType == RogueChallengeModeType.NormalInst;
			RoguelikeLastInfo lastInfo2 = this.LastInfo;
			bool processingState2 = lastInfo2 != null && lastInfo2.ModeType == RogueChallengeModeType.TowerTrial;
			RoguelikeChallengeButtonItem bossChallengeButton = this.BossChallengeButton;
			if (bossChallengeButton != null)
			{
				bossChallengeButton.SetProcessingState(processingState2);
			}
			RoguelikeActivityNormalInstButton normalInstButton = this.NormalInstButton;
			if (normalInstButton == null)
			{
				return;
			}
			normalInstButton.SetProcessingState(processingState);
		}

		// Token: 0x06035AFF RID: 219903 RVA: 0x00D7CC34 File Offset: 0x00D7AE34
		private void RefreshBossChallengeButton()
		{
			RoguelikeChallengeButtonItem bossChallengeButton = this.BossChallengeButton;
			if (bossChallengeButton == null)
			{
				return;
			}
			bossChallengeButton.SetTxtScore(this.ActivityRogueData.SeasonData.TowerTrialBestClearCount);
		}

		// Token: 0x06035B00 RID: 219904 RVA: 0x00D7CC58 File Offset: 0x00D7AE58
		private bool CheckTempAchieveExist()
		{
			if (this.TempAchieveInfo == null)
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RoguelikeTempArchiveProcessConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			Action<bool> clearTempAchieveInfo = delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					return;
				}
				this.ClearTempAchieveInfo(0);
			};
			Action value = delegate()
			{
				ControllerBase<RoguelikeController>.Instance.RoguelikeAchieveGiveUpRequest(clearTempAchieveInfo);
			};
			Action value2 = delegate()
			{
				RogueArchiveInfoData rogueArchiveInfoData = new RogueArchiveInfoData();
				rogueArchiveInfoData.Update(this.TempAchieveInfo);
				RoguelikeAchieveViewInfo viewInfo = new RoguelikeAchieveViewInfo
				{
					Mode = ERoguelikeAchieveViewMode.Archive,
					TempRecordInfo = rogueArchiveInfoData
				};
				ControllerBase<RoguelikeController>.Instance.OpenRoguelikeAchieveView(viewInfo).Forget();
			};
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = value2;
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}

		// Token: 0x06035B01 RID: 219905 RVA: 0x00D7CCE8 File Offset: 0x00D7AEE8
		private bool CheckLastInfoExist()
		{
			if (this.LastInfo == null || this.LastInfo.InstId == 0)
			{
				return false;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew((this.LastInfo.ModeType == RogueChallengeModeType.TowerTrial) ? EConfirmBoxConfigId.RoguelikeBossChallengeLeaveArchiveConfirm : EConfirmBoxConfigId.RoguelikeNormalLeaveArchiveConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			if (this.LastInfo.ModeType == RogueChallengeModeType.NormalInst)
			{
				confirmBoxDataNew.SetTextArgs(new string[]
				{
					this.LastInfo.CurLayer.ToString(),
					this.LastInfo.MaxLayer.ToString()
				});
			}
			Action<bool> clearLastInfo = delegate(bool isSuccess)
			{
				if (!isSuccess)
				{
					return;
				}
				this.ClearLastInfo();
				this.RefreshBossChallengeButton();
			};
			Action value = delegate()
			{
				RoguelikeLastInfo lastInfo = this.LastInfo;
				if (lastInfo != null && lastInfo.ModeType == RogueChallengeModeType.NormalInst)
				{
					ControllerBase<RoguelikeController>.Instance.RoguelikeResultRequest(this.LastInfo.InstId, clearLastInfo);
				}
				RoguelikeLastInfo lastInfo2 = this.LastInfo;
				if (lastInfo2 != null && lastInfo2.ModeType == RogueChallengeModeType.TowerTrial)
				{
					ControllerBase<RoguelikeController>.Instance.RoguelikeBossChallengeResultRequest(this.LastInfo.InstId, clearLastInfo);
				}
			};
			Action value2 = delegate()
			{
				if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
					return;
				}
				RoguelikeLastInfo lastInfo = this.LastInfo;
				if (lastInfo != null && lastInfo.ModeType == RogueChallengeModeType.NormalInst)
				{
					ControllerBase<RoguelikeController>.Instance.RoguelikeStartRequest(true, this.LastInfo.InstId, new List<int>(), 0).Forget<bool>();
				}
				RoguelikeLastInfo lastInfo2 = this.LastInfo;
				if (lastInfo2 != null && lastInfo2.ModeType == RogueChallengeModeType.TowerTrial)
				{
					ControllerBase<RoguelikeController>.Instance.RoguelikeBossChallengeStartRequest(this.LastInfo.InstId, 0, null);
				}
			};
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[2] = value2;
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return true;
		}

		// Token: 0x06035B02 RID: 219906 RVA: 0x00D7CDE4 File Offset: 0x00D7AFE4
		protected void OnBtnConfirmClick()
		{
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			if (this.ActivityRogueData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			if (this.CheckTempAchieveExist())
			{
				return;
			}
			if (this.CheckLastInfoExist())
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.EnterCurrentRogueEntrance();
		}

		// Token: 0x06035B03 RID: 219907 RVA: 0x00D7CE54 File Offset: 0x00D7B054
		protected void OnBtnBossChallengeClick()
		{
			if (ControllerBase<RoleController>.Instance.IsInRoleTrial())
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TrialRoleDungeonsLimit", Array.Empty<object>());
				return;
			}
			if (this.ActivityRogueData.GetRogueActivityState() == ERogueActivityState.Close)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			if (this.CheckTempAchieveExist())
			{
				return;
			}
			if (this.CheckLastInfoExist())
			{
				return;
			}
			RoguelikeAchieveViewInfo viewInfo = new RoguelikeAchieveViewInfo
			{
				Mode = ERoguelikeAchieveViewMode.UseArchive
			};
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeAchieveView(viewInfo).Forget();
		}

		// Token: 0x06035B04 RID: 219908 RVA: 0x00D7CED4 File Offset: 0x00D7B0D4
		private void ClearTempAchieveInfo(int slotId)
		{
			this.TempAchieveInfo = null;
		}

		// Token: 0x06035B05 RID: 219909 RVA: 0x00D7CEDD File Offset: 0x00D7B0DD
		private void ClearLastInfo()
		{
			this.LastInfo = null;
			this.RefreshLastInfo();
		}

		// Token: 0x06035B06 RID: 219910 RVA: 0x00D7CEEC File Offset: 0x00D7B0EC
		protected void RefreshUi()
		{
			ActivityRogueData activityRogueData = this.ActivityRogueData;
			RogueSeasonData rogueSeasonData = (activityRogueData != null) ? activityRogueData.SeasonData : null;
			if (rogueSeasonData != null)
			{
				RogueParam? rogueParam;
				int num = (ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null) != null) ? rogueParam.GetValueOrDefault().WeekTokenMaxCount : 1;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Roguelike_ActivityMain_ScoreProgress", new <>z__ReadOnlyArray<object>(new object[]
				{
					rogueSeasonData.TokenItemCount,
					num
				}));
			}
			this.RefreshRemainTime();
		}

		// Token: 0x06035B07 RID: 219911 RVA: 0x00D7CF80 File Offset: 0x00D7B180
		protected void RefreshRemainTime()
		{
			UUIItem item = base.GetItem(13);
			UUIText text = base.GetText(12);
			ERogueActivityState rogueActivityState = this.ActivityRogueData.GetRogueActivityState();
			if (rogueActivityState == ERogueActivityState.Open)
			{
				RoguelikeActivityNormalInstButton normalInstButton = this.NormalInstButton;
				if (normalInstButton != null)
				{
					normalInstButton.SetActive(true);
				}
				RoguelikeChallengeButtonItem bossChallengeButton = this.BossChallengeButton;
				if (bossChallengeButton != null)
				{
					bossChallengeButton.SetActive(true);
				}
				item.SetUIActive(false);
				double remainTime = (double)this.ActivityRogueData.EndOpenTime - Singleton<TimeUtil>.Instance.GetServerTime();
				CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(remainTime);
				text.SetText(remainTimeDataFormat.CountDownText, true);
				return;
			}
			if (rogueActivityState == ERogueActivityState.ReceiveReward)
			{
				RoguelikeActivityNormalInstButton normalInstButton2 = this.NormalInstButton;
				if (normalInstButton2 != null)
				{
					normalInstButton2.SetActive(false);
				}
				RoguelikeChallengeButtonItem bossChallengeButton2 = this.BossChallengeButton;
				if (bossChallengeButton2 != null)
				{
					bossChallengeButton2.SetActive(false);
				}
				item.SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalText(text, "Rogue_Function_End_Tip", Array.Empty<object>());
				return;
			}
			RoguelikeActivityNormalInstButton normalInstButton3 = this.NormalInstButton;
			if (normalInstButton3 != null)
			{
				normalInstButton3.SetActive(false);
			}
			RoguelikeChallengeButtonItem bossChallengeButton3 = this.BossChallengeButton;
			if (bossChallengeButton3 != null)
			{
				bossChallengeButton3.SetActive(false);
			}
			item.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "Rogue_Function_End_Tip", Array.Empty<object>());
		}

		// Token: 0x06035B08 RID: 219912 RVA: 0x00D7D094 File Offset: 0x00D7B294
		private UniTask InitRequest()
		{
			RoguelikeActivityView.<InitRequest>d__32 <InitRequest>d__;
			<InitRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRequest>d__.<>4__this = this;
			<InitRequest>d__.<>1__state = -1;
			<InitRequest>d__.<>t__builder.Start<RoguelikeActivityView.<InitRequest>d__32>(ref <InitRequest>d__);
			return <InitRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06035B09 RID: 219913 RVA: 0x00D7D0D8 File Offset: 0x00D7B2D8
		[NullableContext(1)]
		private List<int> GetNewUnlockPhantomList(IReadOnlyList<int> unlockPhantomList)
		{
			List<int> list = new List<int>();
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.RoguelikeNewPhantomUnlock) as ServerStorageSet;
			foreach (int num in unlockPhantomList)
			{
				RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(num);
				if (roguePhantomConfig != null && roguePhantomConfig.Value.UnlockInst != 0 && !serverStorageSet.Has(num))
				{
					serverStorageSet.Add(num);
					list.Add(num);
				}
			}
			return list;
		}

		// Token: 0x0401ED06 RID: 126214
		protected PopupCaptionItem CaptionItem;

		// Token: 0x0401ED07 RID: 126215
		private ActivityRogueData ActivityRogueData;

		// Token: 0x0401ED08 RID: 126216
		private RoguelikeBlackFlowerItem BlackFlowerComponent;

		// Token: 0x0401ED09 RID: 126217
		private RoguelikeChallengeButtonItem BossChallengeButton;

		// Token: 0x0401ED0A RID: 126218
		private RoguelikeActivityNormalInstButton NormalInstButton;

		// Token: 0x0401ED0B RID: 126219
		private RoguelikeLastInfo LastInfo;

		// Token: 0x0401ED0C RID: 126220
		private RogueArchiveInfo TempAchieveInfo;

		// Token: 0x0401ED0D RID: 126221
		[Nullable(1)]
		private List<int> NewUnlockPhantomList = new List<int>();

		// Token: 0x0200B139 RID: 45369
		[NullableContext(0)]
		private class ERoguelikeActivityViewDefine
		{
			// Token: 0x04036F6D RID: 225133
			public const int CaptionItem = 0;

			// Token: 0x04036F6E RID: 225134
			public const int TxtTitle = 1;

			// Token: 0x04036F6F RID: 225135
			public const int BtnSkillTree = 2;

			// Token: 0x04036F70 RID: 225136
			public const int BtnDoor = 3;

			// Token: 0x04036F71 RID: 225137
			public const int BtnConfirm = 4;

			// Token: 0x04036F72 RID: 225138
			public const int TexBg = 5;

			// Token: 0x04036F73 RID: 225139
			public const int BtnRewardShop = 6;

			// Token: 0x04036F74 RID: 225140
			public const int TxtRewardShopProgress = 7;

			// Token: 0x04036F75 RID: 225141
			public const int SkillRedItem = 8;

			// Token: 0x04036F76 RID: 225142
			public const int AchievementRedItem = 9;

			// Token: 0x04036F77 RID: 225143
			public const int ShopRedItem = 10;

			// Token: 0x04036F78 RID: 225144
			public const int TxtSubTitle = 11;

			// Token: 0x04036F79 RID: 225145
			public const int ActivityTimeText = 12;

			// Token: 0x04036F7A RID: 225146
			public const int ActivityEndItem = 13;

			// Token: 0x04036F7B RID: 225147
			public const int BlackFlowerItem = 14;

			// Token: 0x04036F7C RID: 225148
			public const int BtnBossChallenge = 15;
		}
	}
}
