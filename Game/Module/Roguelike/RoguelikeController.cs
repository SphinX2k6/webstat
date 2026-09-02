using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonViewModel;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Weather;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005121 RID: 20769
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class RoguelikeController : UiControllerBase<RoguelikeController>
	{
		// Token: 0x0603578A RID: 219018 RVA: 0x00D6BBBB File Offset: 0x00D69DBB
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoading));
		}

		// Token: 0x0603578B RID: 219019 RVA: 0x00D6BBD9 File Offset: 0x00D69DD9
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseLoadingView, new Action(this.OnCloseLoading));
		}

		// Token: 0x0603578C RID: 219020 RVA: 0x00D6BBF8 File Offset: 0x00D69DF8
		public void OnCloseLoading()
		{
			if (ModelBase<RoguelikeModel>.Instance.ShowRewardList != null && ModelBase<RoguelikeModel>.Instance.ShowRewardList.Count > 0)
			{
				this.IsFromRogueToNormal = new bool?(false);
				List<RewardItemData> showRewardList = ModelBase<RoguelikeModel>.Instance.ShowRewardList;
				ModelBase<RoguelikeModel>.Instance.ShowRewardList = null;
				List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>();
				RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
				{
					ButtonTextId = "ConfirmBox_45_ButtonText_1",
					DescriptionTextId = null,
					DescriptionArgs = null,
					IsTimeDownCloseView = false,
					IsClickedCloseView = false,
					OnClickedCallback = delegate(int index)
					{
						if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
						{
							Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, delegate(bool success)
							{
								if (success)
								{
									this.OpenRoguelikeActivityView().ContinueWith(delegate(bool task)
									{
										RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
										if (paramConfigBySeasonId != null && paramConfigBySeasonId.Value.DungeonList() != null && ModelBase<RoguelikeModel>.Instance != null && ModelBase<RoguelikeModel>.Instance.CurDungeonId != null)
										{
											int num = paramConfigBySeasonId.Value.DungeonList().ToList<int>().FindIndex((int value) => value == ModelBase<RoguelikeModel>.Instance.CurDungeonId.Value);
											int num2 = num + 1;
											if (num != -1 && num2 < paramConfigBySeasonId.Value.DungeonListLength)
											{
												InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(paramConfigBySeasonId.Value.DungeonList()[num2]);
												if (config != null && ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(config.Value.Id))
												{
													string localTextNew = ConfigMultiTextLang.GetLocalTextNew(config.Value.MapName, null);
													Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeUnlockTips, localTextNew, null);
												}
											}
											ModelBase<RoguelikeModel>.Instance.CurDungeonId = null;
										}
									});
								}
							});
						}
					}
				};
				list.Add(item);
				ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3010, true, showRewardList, null, null, list, null, null, null, null, null, null, null, null, null, null, null);
			}
			else if (this.IsFromRogueToNormal.GetValueOrDefault())
			{
				this.IsFromRogueToNormal = new bool?(false);
				this.OpenRoguelikeActivityView();
			}
			this.CurrentFlowId = 0;
			this.CurrentFlowListName = "";
			this.CurrentStateId = 0;
		}

		// Token: 0x0603578D RID: 219021 RVA: 0x00D6BD04 File Offset: 0x00D69F04
		[NullableContext(0)]
		public UniTask<bool> OpenRoguelikeActivityView()
		{
			RoguelikeController.<OpenRoguelikeActivityView>d__8 <OpenRoguelikeActivityView>d__;
			<OpenRoguelikeActivityView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenRoguelikeActivityView>d__.<>1__state = -1;
			<OpenRoguelikeActivityView>d__.<>t__builder.Start<RoguelikeController.<OpenRoguelikeActivityView>d__8>(ref <OpenRoguelikeActivityView>d__);
			return <OpenRoguelikeActivityView>d__.<>t__builder.Task;
		}

		// Token: 0x0603578E RID: 219022 RVA: 0x00D6BD40 File Offset: 0x00D69F40
		protected override void OnAddOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeActivityView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeInstanceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeMemoryPlaceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeSelectRoleView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeTokenOverView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeSkillView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeExitTips, new Func<EUiViewName, object, bool>(this.CheckCanOpenExitTips), "RoguelikeController.CheckCanOpenExitTips");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeEntranceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen), "RoguelikeController.CheckCanOpen");
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RoguelikeAchieveView, new Func<EUiViewName, object, bool>(this.CheckCanOpenAchieve), "RoguelikeController.CheckCanOpen");
		}

		// Token: 0x0603578F RID: 219023 RVA: 0x00D6BE70 File Offset: 0x00D6A070
		protected override void OnRemoveOpenViewCheckFunction()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeActivityView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeInstanceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeMemoryPlaceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeSelectRoleView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeTokenOverView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RogueInfoView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeSkillView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeEntranceView, new Func<EUiViewName, object, bool>(this.CheckCanOpen));
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RoguelikeAchieveView, new Func<EUiViewName, object, bool>(this.CheckCanOpenAchieve));
		}

		// Token: 0x06035790 RID: 219024 RVA: 0x00D6BF70 File Offset: 0x00D6A170
		public bool CheckCanOpen(EUiViewName viewName, object openParam)
		{
			if (!ModelBase<RoguelikeModel>.Instance.CheckRogueIsOpen())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_Not_Open_Tip", Array.Empty<object>());
				return false;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Multi_Tip", Array.Empty<object>());
				return false;
			}
			if (this.IsFromRogueToNormal.GetValueOrDefault())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Rogue_Function_Instance_End_Tip", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06035791 RID: 219025 RVA: 0x00D6BFE8 File Offset: 0x00D6A1E8
		private bool CheckCanOpenAchieve(EUiViewName viewName, object openParam)
		{
			if (!ModelBase<RoguelikeModel>.Instance.CheckRogueIsOpen())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_Not_Open_Tip", Array.Empty<object>());
				return false;
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Multi_Tip", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06035792 RID: 219026 RVA: 0x00D6C03A File Offset: 0x00D6A23A
		public bool CheckCanOpenExitTips(EUiViewName viewName, object openParam)
		{
			if (this.IsFromRogueToNormal.GetValueOrDefault())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_Instance_End_Tip", Array.Empty<object>());
				return false;
			}
			return true;
		}

		// Token: 0x06035793 RID: 219027 RVA: 0x00D6C060 File Offset: 0x00D6A260
		public UniTask OpenBuffSelectViewByIdAsync(int index)
		{
			RoguelikeController.<OpenBuffSelectViewByIdAsync>d__14 <OpenBuffSelectViewByIdAsync>d__;
			<OpenBuffSelectViewByIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenBuffSelectViewByIdAsync>d__.<>4__this = this;
			<OpenBuffSelectViewByIdAsync>d__.index = index;
			<OpenBuffSelectViewByIdAsync>d__.<>1__state = -1;
			<OpenBuffSelectViewByIdAsync>d__.<>t__builder.Start<RoguelikeController.<OpenBuffSelectViewByIdAsync>d__14>(ref <OpenBuffSelectViewByIdAsync>d__);
			return <OpenBuffSelectViewByIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035794 RID: 219028 RVA: 0x00D6C0AC File Offset: 0x00D6A2AC
		[NullableContext(0)]
		public UniTask<bool> OpenBuffSelectViewById(int index)
		{
			RoguelikeController.<OpenBuffSelectViewById>d__15 <OpenBuffSelectViewById>d__;
			<OpenBuffSelectViewById>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenBuffSelectViewById>d__.<>4__this = this;
			<OpenBuffSelectViewById>d__.index = index;
			<OpenBuffSelectViewById>d__.<>1__state = -1;
			<OpenBuffSelectViewById>d__.<>t__builder.Start<RoguelikeController.<OpenBuffSelectViewById>d__15>(ref <OpenBuffSelectViewById>d__);
			return <OpenBuffSelectViewById>d__.<>t__builder.Task;
		}

		// Token: 0x06035795 RID: 219029 RVA: 0x00D6C0F8 File Offset: 0x00D6A2F8
		public EUiViewName? GetViewNameByGainType(RoguelikeGainDataType type)
		{
			switch (type)
			{
			case RoguelikeGainDataType.Phantom:
				if (ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry.ConfigId) == null)
				{
					return new EUiViewName?(EUiViewName.RoguePhantomSelectView);
				}
				return new EUiViewName?(EUiViewName.RoguePhantomReplaceView);
			case RoguelikeGainDataType.Shop:
				return new EUiViewName?(EUiViewName.RogueShopView);
			case RoguelikeGainDataType.Role:
				return new EUiViewName?(EUiViewName.RoleReplaceView);
			case RoguelikeGainDataType.CommonBuff:
				return new EUiViewName?(EUiViewName.CommonSelectView);
			case RoguelikeGainDataType.RoleBuff:
				return new EUiViewName?(EUiViewName.RoleBuffSelectView);
			case RoguelikeGainDataType.Event:
				return new EUiViewName?(EUiViewName.RoguelikeRandomEventView);
			case RoguelikeGainDataType.Miraclecreation:
				return new EUiViewName?(EUiViewName.RoguelikeSelectSpecialView);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roguelike;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "当前增益类型没有对应的界面数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type.ToString());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x06035796 RID: 219030 RVA: 0x00D6C1F0 File Offset: 0x00D6A3F0
		public void RoguelikeCurrencyNotify(RoguelikeCurrencyNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<RoguelikeModel>.Instance.RoguelikeCurrencyDictMap.Clear();
			foreach (int num in notify.CurrencyDict.Keys)
			{
				ModelBase<RoguelikeModel>.Instance.SetRoguelikeCurrency(num, notify.CurrencyDict[num]);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeCurrencyUpdate);
			Singleton<EventSystem>.Instance.Emit(EEventName.PayShopGoodsBuy);
		}

		// Token: 0x06035797 RID: 219031 RVA: 0x00D6C284 File Offset: 0x00D6A484
		public void RoguelikeCurrencyUpdateNotify(RoguelikeCurrencyUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			if (paramConfigBySeasonId == null)
			{
				return;
			}
			foreach (int num in notify.CurrencyUpdateDict.Keys)
			{
				int num2 = num;
				int num3 = notify.CurrencyUpdateDict[num];
				ModelBase<RoguelikeModel>.Instance.UpdateRoguelikeCurrency(num2, num3);
				if (num2 == paramConfigBySeasonId.Value.InsideCurrency && num3 > 0)
				{
					ControllerBase<ItemHintController>.Instance.AddRoguelikeItemList(paramConfigBySeasonId.Value.InsideCurrency, num3);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeCurrencyUpdate);
		}

		// Token: 0x06035798 RID: 219032 RVA: 0x00D6C354 File Offset: 0x00D6A554
		private void OnRoguelikeEventGainNotify(RoguelikeEventGainNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			this.RoguelikeEventGainNotify(notify, null);
		}

		// Token: 0x06035799 RID: 219033 RVA: 0x00D6C360 File Offset: 0x00D6A560
		public void RoguelikeEventGainNotify(RoguelikeEventGainNotify notify, [Nullable(2)] Action<bool?> callback = null)
		{
			List<RogueGainEntry> list = new List<RogueGainEntry>();
			if (notify.RogueGainEntryList.Count > 0)
			{
				foreach (RogueGainEntry rogueGainEntry in notify.RogueGainEntryList)
				{
					list.Add(new RogueGainEntry(rogueGainEntry, null));
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueEventResultViewOneByOne, new EventResult(list, callback), null);
				return;
			}
			if (notify.RogueGainEntryList2.Count > 0)
			{
				foreach (RogueGainEntry rogueGainEntry2 in notify.RogueGainEntryList2)
				{
					list.Add(new RogueGainEntry(rogueGainEntry2, null));
				}
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueEventResultViewAll, new EventResult(list, callback), null);
				return;
			}
			if (callback != null)
			{
				callback(null);
			}
		}

		// Token: 0x0603579A RID: 219034 RVA: 0x00D6C46C File Offset: 0x00D6A66C
		public void RoguelikeGainDataUpdateNotify(RoguelikeGainDataUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			if (ModelBase<RoguelikeModel>.Instance.RogueInfo == null)
			{
				return;
			}
			ModelBase<RoguelikeModel>.Instance.RogueInfo.Update(notify);
		}

		// Token: 0x0603579B RID: 219035 RVA: 0x00D6C48B File Offset: 0x00D6A68B
		public void RoguelikeChooseDataNotify(RoguelikeChooseDataNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RoguelikeModel>.Instance.SetRoguelikeChooseData(notify.RoguelikeChooseDataList);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeChooseDataNotify);
		}

		// Token: 0x0603579C RID: 219036 RVA: 0x00D6C4AD File Offset: 0x00D6A6AD
		public void RoguelikeTalentUnlockNotify(RoguelikeTalentUnlockNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RoguelikeModel>.Instance.SetRoguelikeSkillData(notify.SkillId, 0);
		}

		// Token: 0x0603579D RID: 219037 RVA: 0x00D6C4C0 File Offset: 0x00D6A6C0
		public void RoguelikeRefreshGainRequest(int bindId)
		{
			RoguelikeRefreshGainRequest roguelikeRefreshGainRequest = Aki.Protocol.RoguelikeRefreshGainRequest.Create();
			roguelikeRefreshGainRequest.BindId = bindId;
			roguelikeRefreshGainRequest.Layer = ModelBase<RoguelikeModel>.Instance.CurRoomCount;
			Singleton<Net>.Instance.Call<RoguelikeRefreshGainResponse>(ERequestMessageId.RoguelikeRefreshGainRequest, roguelikeRefreshGainRequest, delegate(RoguelikeRefreshGainResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeScrollingTipsView(response.ErrorCode, response.ErrorParams.ToArray<string>());
					return;
				}
				ModelBase<RoguelikeModel>.Instance.SetRoguelikeChooseData(new <>z__ReadOnlySingleElementList<RoguelikeChooseData>(response.RoguelikeChooseData));
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RoguelikeRefreshGain, response.RoguelikeChooseData.Index);
			}, 0);
		}

		// Token: 0x0603579E RID: 219038 RVA: 0x00D6C51C File Offset: 0x00D6A71C
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<RoguelikeLastInfoResponse> RoguelikeLastInfoRequestAsync()
		{
			RoguelikeController.<RoguelikeLastInfoRequestAsync>d__25 <RoguelikeLastInfoRequestAsync>d__;
			<RoguelikeLastInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<RoguelikeLastInfoResponse>.Create();
			<RoguelikeLastInfoRequestAsync>d__.<>1__state = -1;
			<RoguelikeLastInfoRequestAsync>d__.<>t__builder.Start<RoguelikeController.<RoguelikeLastInfoRequestAsync>d__25>(ref <RoguelikeLastInfoRequestAsync>d__);
			return <RoguelikeLastInfoRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603579F RID: 219039 RVA: 0x00D6C558 File Offset: 0x00D6A758
		public void EnterCurrentRogueEntrance()
		{
			RogueSeasonData seasonData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData().SeasonData;
			if (seasonData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.LPH, "打开副本选择界面时肉鸽赛季数据为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(seasonData.SeasonId);
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(rogueSeasonConfigById.Value.InstanceDungeonEntrance, 0, null).Forget<bool>();
		}

		// Token: 0x060357A0 RID: 219040 RVA: 0x00D6C5CC File Offset: 0x00D6A7CC
		public void OpenRoguelikeInstanceView()
		{
			RoguelikeDungeonViewModel param = new RoguelikeDungeonViewModel();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.InstanceDungeonEntranceView, param, null);
		}

		// Token: 0x060357A1 RID: 219041 RVA: 0x00D6C5F0 File Offset: 0x00D6A7F0
		[NullableContext(2)]
		public void OpenRogueInfoView(RoguelikeInfo rogueInfo = null, bool checkLimit = true, bool showCurrency = true, ERogueInfoViewPage defaultPage = ERogueInfoViewPage.Overview)
		{
			if (checkLimit)
			{
				if (!ModelBase<RoguelikeModel>.Instance.CheckRogueIsOpen())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Function_Not_Open_Tip", Array.Empty<object>());
					return;
				}
				if (ModelBase<GameModeModel>.Instance.IsMulti)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Rogue_Multi_Tip", Array.Empty<object>());
					return;
				}
				if (this.IsFromRogueToNormal.GetValueOrDefault())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Rogue_Function_Instance_End_Tip", Array.Empty<object>());
					return;
				}
			}
			RogueInfoViewModel rogueInfoViewModel = new RogueInfoViewModel(rogueInfo ?? ModelBase<RoguelikeModel>.Instance.RogueInfo);
			rogueInfoViewModel.ShowCurrency = showCurrency;
			rogueInfoViewModel.DefaultPage = defaultPage;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueInfoView, rogueInfoViewModel, null);
		}

		// Token: 0x060357A2 RID: 219042 RVA: 0x00D6C69C File Offset: 0x00D6A89C
		public UniTask OpenRoguelikeAchieveView(IRoguelikeAchieveViewInfo viewInfo)
		{
			RoguelikeController.<OpenRoguelikeAchieveView>d__29 <OpenRoguelikeAchieveView>d__;
			<OpenRoguelikeAchieveView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenRoguelikeAchieveView>d__.viewInfo = viewInfo;
			<OpenRoguelikeAchieveView>d__.<>1__state = -1;
			<OpenRoguelikeAchieveView>d__.<>t__builder.Start<RoguelikeController.<OpenRoguelikeAchieveView>d__29>(ref <OpenRoguelikeAchieveView>d__);
			return <OpenRoguelikeAchieveView>d__.<>t__builder.Task;
		}

		// Token: 0x060357A3 RID: 219043 RVA: 0x00D6C6DF File Offset: 0x00D6A8DF
		public void OpenRoguelikeSelectRoleView(int instanceId)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeEntranceView, instanceId, null);
		}

		// Token: 0x060357A4 RID: 219044 RVA: 0x00D6C6F8 File Offset: 0x00D6A8F8
		public void OpenRoguelikeSkillView(int seasonId)
		{
			this.RoguelikeTalentInfoRequest(seasonId).ContinueWith(delegate()
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeSkillView, seasonId, null);
			});
		}

		// Token: 0x060357A5 RID: 219045 RVA: 0x00D6C730 File Offset: 0x00D6A930
		private unsafe void OpenRoguelikeBossChallengeResultView(int instId, RogueTowerTrialResultInfo resultInfo)
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			RogueTowerTrialResultInfo resultInfo2 = resultInfo;
			bool flag;
			if (resultInfo2 == null)
			{
				flag = false;
			}
			else
			{
				int historyMaxKills = resultInfo2.HistoryMaxKills;
				flag = true;
			}
			if (flag && rogueSeasonData != null)
			{
				int historyMaxKills2 = resultInfo.HistoryMaxKills;
				rogueSeasonData.TowerTrialBestClearCount = historyMaxKills2;
			}
			if (resultInfo == null)
			{
				if (ModelBase<RoguelikeModel>.Instance.CheckInRoguelike())
				{
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				}
				return;
			}
			IRewardExploreConfirmButton rewardExploreConfirmButton = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Rogue_TowerResult_Exit",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					this.IsFromRogueToNormal = new bool?(ModelBase<RoguelikeModel>.Instance.CheckInRoguelike());
					ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
				}
			};
			IRewardExploreConfirmButton rewardExploreConfirmButton2 = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "Rogue_TowerResult_Retry",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = delegate(int _)
				{
					this.RoguelikeBossChallengeStartRequest(instId, resultInfo.SlotId, null);
				}
			};
			ExploreRewardViewData exploreRewardViewData = new ExploreRewardViewData();
			exploreRewardViewData.ConfigId = 3032;
			exploreRewardViewData.IsSuccess = true;
			int num = 2;
			List<IRewardExploreConfirmButton> list = new List<IRewardExploreConfirmButton>(num);
			CollectionsMarshal.SetCount<IRewardExploreConfirmButton>(list, num);
			Span<IRewardExploreConfirmButton> span = CollectionsMarshal.AsSpan<IRewardExploreConfirmButton>(list);
			int num2 = 0;
			*span[num2] = rewardExploreConfirmButton;
			num2++;
			*span[num2] = rewardExploreConfirmButton2;
			exploreRewardViewData.ButtonInfoList = list;
			exploreRewardViewData.IsBagFull = new bool?(false);
			ExploreRewardViewData exploreRewardViewData2 = exploreRewardViewData;
			IRoguelikeBossChallengeData roguelikeBossChallengeData = new RoguelikeBossChallengeData
			{
				IsNewRecord = resultInfo.IsNewRecord,
				PassTime = resultInfo.TotalCostTime,
				InstId = instId,
				BossTotalCount = resultInfo.MaxCount,
				FinishedBossIdList = resultInfo.Ids,
				CurrentBossId = new int?(resultInfo.ChallengingBossId)
			};
			exploreRewardViewData2.RoguelikeBossChallengeData = roguelikeBossChallengeData;
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(exploreRewardViewData2);
		}

		// Token: 0x060357A6 RID: 219046 RVA: 0x00D6C914 File Offset: 0x00D6AB14
		public UniTask RoguelikeTalentInfoRequest(int seasonId)
		{
			RoguelikeController.<RoguelikeTalentInfoRequest>d__33 <RoguelikeTalentInfoRequest>d__;
			<RoguelikeTalentInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoguelikeTalentInfoRequest>d__.seasonId = seasonId;
			<RoguelikeTalentInfoRequest>d__.<>1__state = -1;
			<RoguelikeTalentInfoRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeTalentInfoRequest>d__33>(ref <RoguelikeTalentInfoRequest>d__);
			return <RoguelikeTalentInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357A7 RID: 219047 RVA: 0x00D6C958 File Offset: 0x00D6AB58
		[NullableContext(0)]
		public UniTask<bool> RoguelikeRoleRoomSelectRequest(int roomId, int index)
		{
			RoguelikeController.<RoguelikeRoleRoomSelectRequest>d__34 <RoguelikeRoleRoomSelectRequest>d__;
			<RoguelikeRoleRoomSelectRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RoguelikeRoleRoomSelectRequest>d__.roomId = roomId;
			<RoguelikeRoleRoomSelectRequest>d__.index = index;
			<RoguelikeRoleRoomSelectRequest>d__.<>1__state = -1;
			<RoguelikeRoleRoomSelectRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeRoleRoomSelectRequest>d__34>(ref <RoguelikeRoleRoomSelectRequest>d__);
			return <RoguelikeRoleRoomSelectRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357A8 RID: 219048 RVA: 0x00D6C9A4 File Offset: 0x00D6ABA4
		[NullableContext(0)]
		public UniTask<bool> RoguelikeSeasonRewardReceiveRequest([Nullable(1)] List<int> indexList, int? seasonId = null)
		{
			RoguelikeController.<RoguelikeSeasonRewardReceiveRequest>d__35 <RoguelikeSeasonRewardReceiveRequest>d__;
			<RoguelikeSeasonRewardReceiveRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RoguelikeSeasonRewardReceiveRequest>d__.indexList = indexList;
			<RoguelikeSeasonRewardReceiveRequest>d__.seasonId = seasonId;
			<RoguelikeSeasonRewardReceiveRequest>d__.<>1__state = -1;
			<RoguelikeSeasonRewardReceiveRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeSeasonRewardReceiveRequest>d__35>(ref <RoguelikeSeasonRewardReceiveRequest>d__);
			return <RoguelikeSeasonRewardReceiveRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357A9 RID: 219049 RVA: 0x00D6C9F0 File Offset: 0x00D6ABF0
		public UniTask RoguelikeTalentLevelUpRequest(int skillId)
		{
			RoguelikeController.<RoguelikeTalentLevelUpRequest>d__36 <RoguelikeTalentLevelUpRequest>d__;
			<RoguelikeTalentLevelUpRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoguelikeTalentLevelUpRequest>d__.skillId = skillId;
			<RoguelikeTalentLevelUpRequest>d__.<>1__state = -1;
			<RoguelikeTalentLevelUpRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeTalentLevelUpRequest>d__36>(ref <RoguelikeTalentLevelUpRequest>d__);
			return <RoguelikeTalentLevelUpRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357AA RID: 219050 RVA: 0x00D6CA34 File Offset: 0x00D6AC34
		[NullableContext(0)]
		public UniTask<bool> RoguelikeStartRequest(bool isContinue, int instanceId, [Nullable(1)] List<int> roleIds, int hotEntryGroupId)
		{
			RoguelikeController.<RoguelikeStartRequest>d__37 <RoguelikeStartRequest>d__;
			<RoguelikeStartRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RoguelikeStartRequest>d__.isContinue = isContinue;
			<RoguelikeStartRequest>d__.instanceId = instanceId;
			<RoguelikeStartRequest>d__.roleIds = roleIds;
			<RoguelikeStartRequest>d__.hotEntryGroupId = hotEntryGroupId;
			<RoguelikeStartRequest>d__.<>1__state = -1;
			<RoguelikeStartRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeStartRequest>d__37>(ref <RoguelikeStartRequest>d__);
			return <RoguelikeStartRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357AB RID: 219051 RVA: 0x00D6CA90 File Offset: 0x00D6AC90
		public void RoguelikeQuitRequest()
		{
			if (this.IsFromRogueToNormal.GetValueOrDefault())
			{
				return;
			}
			bool isGuideDungeon = ModelBase<RoguelikeModel>.Instance.CheckIsGuideDungeon();
			RoguelikeQuitRequest message = Aki.Protocol.RoguelikeQuitRequest.Create();
			Singleton<Net>.Instance.Call<RoguelikeQuitResponse>(ERequestMessageId.RoguelikeQuitRequest, message, delegate(RoguelikeQuitResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20226, null, true, true);
				}
				this.IsFromRogueToNormal = new bool?(!isGuideDungeon);
				ModelBase<InstanceDungeonModel>.Instance.ClearInstanceDungeonInfo();
			}, 0);
		}

		// Token: 0x060357AC RID: 219052 RVA: 0x00D6CAEC File Offset: 0x00D6ACEC
		[NullableContext(2)]
		public void RoguelikeResultRequest(int instId, Action<bool> callback = null)
		{
			if (!this.IsFromRogueToNormal.GetValueOrDefault())
			{
				RoguelikeResultRequest roguelikeResultRequest = Aki.Protocol.RoguelikeResultRequest.Create();
				roguelikeResultRequest.InstId = instId;
				Singleton<Net>.Instance.Call<RoguelikeResultResponse>(ERequestMessageId.RoguelikeResultRequest, roguelikeResultRequest, delegate(RoguelikeResultResponse response, Net.CallbackStatus _)
				{
					if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27938, null, true, true);
						Action<bool> callback3 = callback;
						if (callback3 == null)
						{
							return;
						}
						callback3(false);
						return;
					}
					else
					{
						RoguelikeResultInfo roguelikeResultInfo = response.RoguelikeResultInfo;
						if (this.TryExitRoguelikeWithoutSettleView(roguelikeResultInfo))
						{
							Action<bool> callback4 = callback;
							if (callback4 == null)
							{
								return;
							}
							callback4(false);
							return;
						}
						else
						{
							this.IsFromRogueToNormal = new bool?(ModelBase<RoguelikeModel>.Instance.CheckInRoguelike());
							Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeSettleView, roguelikeResultInfo, null);
							Action<bool> callback5 = callback;
							if (callback5 == null)
							{
								return;
							}
							callback5(true);
							return;
						}
					}
				}, 0);
				return;
			}
			Action<bool> callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2(false);
		}

		// Token: 0x060357AD RID: 219053 RVA: 0x00D6CB58 File Offset: 0x00D6AD58
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<RogueInstExtraInfoResponse> RoguelikeInstExtraInfoRequest(int? seasonId = null)
		{
			RoguelikeController.<RoguelikeInstExtraInfoRequest>d__40 <RoguelikeInstExtraInfoRequest>d__;
			<RoguelikeInstExtraInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<RogueInstExtraInfoResponse>.Create();
			<RoguelikeInstExtraInfoRequest>d__.seasonId = seasonId;
			<RoguelikeInstExtraInfoRequest>d__.<>1__state = -1;
			<RoguelikeInstExtraInfoRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeInstExtraInfoRequest>d__40>(ref <RoguelikeInstExtraInfoRequest>d__);
			return <RoguelikeInstExtraInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357AE RID: 219054 RVA: 0x00D6CB9C File Offset: 0x00D6AD9C
		public void RogueChooseDataResultRequest(EPerkType perkType)
		{
			RogueGainEntry selectRogueGainEntry = ModelBase<RoguelikeModel>.Instance.CurrentRogueGainEntry;
			RogueGainEntry oldRogueGainEntry = null;
			if (perkType == EPerkType.Phantom)
			{
				oldRogueGainEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry;
			}
			else if (perkType == EPerkType.Role)
			{
				oldRogueGainEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.RoleEntry;
			}
			else if (perkType == EPerkType.Shop)
			{
				oldRogueGainEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry;
				int shopItemCoinId = selectRogueGainEntry.ShopItemCoinId;
				int roguelikeCurrency = ModelBase<RoguelikeModel>.Instance.GetRoguelikeCurrency(shopItemCoinId);
				int? currentPrice = selectRogueGainEntry.CurrentPrice;
				int num = 0;
				if (roguelikeCurrency < ((currentPrice.GetValueOrDefault() == num & currentPrice != null) ? new int?(selectRogueGainEntry.OriginalPrice) : selectRogueGainEntry.CurrentPrice).Value)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("RoguelikeShopNotEnoughCurrency", Array.Empty<object>());
					return;
				}
			}
			else
			{
				oldRogueGainEntry = ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry;
			}
			RoguelikeChooseDataResultRequest request = RoguelikeChooseDataResultRequest.Create();
			RoguelikeChooseDataResultRequest request3 = request;
			RogueGainEntry selectRogueGainEntry3 = selectRogueGainEntry;
			request3.Index = ((selectRogueGainEntry3 != null) ? selectRogueGainEntry3.Index : null).GetValueOrDefault();
			RoguelikeChooseDataResultRequest request2 = request;
			RogueGainEntry selectRogueGainEntry2 = selectRogueGainEntry;
			request2.BindId = ((selectRogueGainEntry2 != null) ? selectRogueGainEntry2.BindId : null).GetValueOrDefault();
			request.Layer = ModelBase<RoguelikeModel>.Instance.CurRoomCount;
			if (perkType == EPerkType.Event)
			{
				request.BindId = -2;
			}
			Singleton<Net>.Instance.Call<RoguelikeChooseDataResultResponse>(ERequestMessageId.RoguelikeChooseDataResultRequest, request, delegate(RoguelikeChooseDataResultResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode == Aki.Protocol.ErrorCode.RogueGainIsSelect)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21339, response.ErrorParams, false, true);
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21339, response.ErrorParams, true, true);
					return;
				}
				RoguelikeChooseData roguelikeChooseDataById = ModelBase<RoguelikeModel>.Instance.GetRoguelikeChooseDataById(request.BindId);
				roguelikeChooseDataById.IsSelect = new bool?(response.IsSelect);
				RogueGainEntry p = null;
				if (perkType == EPerkType.Phantom)
				{
					p = ModelBase<RoguelikeModel>.Instance.RogueInfo.PhantomEntry;
				}
				else if (perkType == EPerkType.Role)
				{
					p = ModelBase<RoguelikeModel>.Instance.RogueInfo.RoleEntry;
				}
				else if (perkType == EPerkType.Shop)
				{
					selectRogueGainEntry.IsSell = new bool?(true);
					p = selectRogueGainEntry;
				}
				else
				{
					if (perkType == EPerkType.Event)
					{
						if (response.RoguelikeChooseDataNotify.RoguelikeChooseDataList.Count <= 0)
						{
							roguelikeChooseDataById.RogueGainEntryList = new List<RogueGainEntry>();
							goto IL_150;
						}
						using (IEnumerator<RoguelikeChooseData> enumerator = response.RoguelikeChooseDataNotify.RoguelikeChooseDataList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								RoguelikeChooseData item = enumerator.Current;
								ModelBase<RoguelikeModel>.Instance.SetRoguelikeChooseData(new <>z__ReadOnlySingleElementList<RoguelikeChooseData>(item));
							}
							goto IL_150;
						}
					}
					if (perkType == EPerkType.Special)
					{
						p = selectRogueGainEntry;
					}
				}
				IL_150:
				Singleton<EventSystem>.Instance.Emit<RogueGainEntry, RogueGainEntry, bool, int, RoguelikeChooseDataResultResponse>(EEventName.RoguelikeChooseDataResult, p, oldRogueGainEntry, true, request.BindId, response);
			}, 0);
		}

		// Token: 0x060357AF RID: 219055 RVA: 0x00D6CD74 File Offset: 0x00D6AF74
		[NullableContext(0)]
		public UniTask<bool> RoguelikeAchieveSaveRecordRequest(int slotId)
		{
			RoguelikeController.<RoguelikeAchieveSaveRecordRequest>d__42 <RoguelikeAchieveSaveRecordRequest>d__;
			<RoguelikeAchieveSaveRecordRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RoguelikeAchieveSaveRecordRequest>d__.slotId = slotId;
			<RoguelikeAchieveSaveRecordRequest>d__.<>1__state = -1;
			<RoguelikeAchieveSaveRecordRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeAchieveSaveRecordRequest>d__42>(ref <RoguelikeAchieveSaveRecordRequest>d__);
			return <RoguelikeAchieveSaveRecordRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357B0 RID: 219056 RVA: 0x00D6CDB8 File Offset: 0x00D6AFB8
		[NullableContext(2)]
		public void RoguelikeAchieveGiveUpRequest(Action<bool> callback = null)
		{
			RogueTowerTrialGiveUpTempArchiveRequest message = RogueTowerTrialGiveUpTempArchiveRequest.Create();
			Singleton<Net>.Instance.Call<RogueTowerTrialGiveUpTempArchiveResponse>(ERequestMessageId.RogueTowerTrialGiveUpTempArchiveRequest, message, delegate(RogueTowerTrialGiveUpTempArchiveResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25637, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x060357B1 RID: 219057 RVA: 0x00D6CDF8 File Offset: 0x00D6AFF8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public UniTask<List<RogueArchiveInfoData>> RogueArchiveListRequest(int seasonId)
		{
			RoguelikeController.<RogueArchiveListRequest>d__44 <RogueArchiveListRequest>d__;
			<RogueArchiveListRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<List<RogueArchiveInfoData>>.Create();
			<RogueArchiveListRequest>d__.seasonId = seasonId;
			<RogueArchiveListRequest>d__.<>1__state = -1;
			<RogueArchiveListRequest>d__.<>t__builder.Start<RoguelikeController.<RogueArchiveListRequest>d__44>(ref <RogueArchiveListRequest>d__);
			return <RogueArchiveListRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357B2 RID: 219058 RVA: 0x00D6CE3C File Offset: 0x00D6B03C
		[NullableContext(2)]
		public void RoguelikeBossChallengeStartRequest(int instId, int slotId, Action<bool> callback = null)
		{
			RogueTowerTrialStartRequest rogueTowerTrialStartRequest = RogueTowerTrialStartRequest.Create();
			rogueTowerTrialStartRequest.InstId = instId;
			rogueTowerTrialStartRequest.SlotId = slotId;
			Singleton<Net>.Instance.Call<RogueTowerTrialStartResponse>(ERequestMessageId.RogueTowerTrialStartRequest, rogueTowerTrialStartRequest, delegate(RogueTowerTrialStartResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26846, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x060357B3 RID: 219059 RVA: 0x00D6CE88 File Offset: 0x00D6B088
		[NullableContext(2)]
		public void RoguelikeBossChallengeSelectBossRequest(int id, Action<bool> callback = null)
		{
			RogueTowerTrialSelectBossRequest rogueTowerTrialSelectBossRequest = RogueTowerTrialSelectBossRequest.Create();
			rogueTowerTrialSelectBossRequest.Id = id;
			Singleton<Net>.Instance.Call<RogueTowerTrialSelectBossResponse>(ERequestMessageId.RogueTowerTrialSelectBossRequest, rogueTowerTrialSelectBossRequest, delegate(RogueTowerTrialSelectBossResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17403, null, true, true);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x060357B4 RID: 219060 RVA: 0x00D6CECC File Offset: 0x00D6B0CC
		[NullableContext(2)]
		public void RoguelikeBossChallengeResultRequest(int instId, Action<bool> callback = null)
		{
			RogueTowerTrialResultRequest rogueTowerTrialResultRequest = RogueTowerTrialResultRequest.Create();
			rogueTowerTrialResultRequest.InstId = instId;
			Singleton<Net>.Instance.Call<RogueTowerTrialResultResponse>(ERequestMessageId.RogueTowerTrialResultRequest, rogueTowerTrialResultRequest, delegate(RogueTowerTrialResultResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25560, null, true, true);
					this.OpenRoguelikeBossChallengeResultView(instId, null);
					Action<bool> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(false);
					return;
				}
				else
				{
					this.OpenRoguelikeBossChallengeResultView(instId, response.RogueTowerTrialResultInfo);
					Action<bool> callback3 = callback;
					if (callback3 == null)
					{
						return;
					}
					callback3(true);
					return;
				}
			}, 0);
		}

		// Token: 0x060357B5 RID: 219061 RVA: 0x00D6CF24 File Offset: 0x00D6B124
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<RoguelikeSubLevelNotify>(ENotifyMessageId.RoguelikeSubLevelNotify, new Action<RoguelikeSubLevelNotify, Net.CallbackStatus>(this.RoguelikeSubLevelNotify));
			Singleton<Net>.Instance.Register<RoguelikeInfoNotify>(ENotifyMessageId.RoguelikeInfoNotify, new Action<RoguelikeInfoNotify, Net.CallbackStatus>(this.OnRogueInfoNotify));
			Singleton<Net>.Instance.Register<RoguelikeChooseDataNotify>(ENotifyMessageId.RoguelikeChooseDataNotify, new Action<RoguelikeChooseDataNotify, Net.CallbackStatus>(this.RoguelikeChooseDataNotify));
			Singleton<Net>.Instance.Register<RoguelikeRoomInfoNotify>(ENotifyMessageId.RoguelikeRoomInfoNotify, new Action<RoguelikeRoomInfoNotify, Net.CallbackStatus>(this.RoguelikeRoomInfoNotify));
			Singleton<Net>.Instance.Register<RoguelikeResultNotify>(ENotifyMessageId.RoguelikeResultNotify, new Action<RoguelikeResultNotify, Net.CallbackStatus>(this.RoguelikeResultNotify));
			Singleton<Net>.Instance.Register<RoguelikeTalentUnlockNotify>(ENotifyMessageId.RoguelikeTalentUnlockNotify, new Action<RoguelikeTalentUnlockNotify, Net.CallbackStatus>(this.RoguelikeTalentUnlockNotify));
			Singleton<Net>.Instance.Register<RoguelikeCurrencyNotify>(ENotifyMessageId.RoguelikeCurrencyNotify, new Action<RoguelikeCurrencyNotify, Net.CallbackStatus>(this.RoguelikeCurrencyNotify));
			Singleton<Net>.Instance.Register<RoguelikeCurrencyUpdateNotify>(ENotifyMessageId.RoguelikeCurrencyUpdateNotify, new Action<RoguelikeCurrencyUpdateNotify, Net.CallbackStatus>(this.RoguelikeCurrencyUpdateNotify));
			Singleton<Net>.Instance.Register<RoguelikeEventGainNotify>(ENotifyMessageId.RoguelikeEventGainNotify, new Action<RoguelikeEventGainNotify, Net.CallbackStatus>(this.OnRoguelikeEventGainNotify));
			Singleton<Net>.Instance.Register<RoguelikeGainDataUpdateNotify>(ENotifyMessageId.RoguelikeGainDataUpdateNotify, new Action<RoguelikeGainDataUpdateNotify, Net.CallbackStatus>(this.RoguelikeGainDataUpdateNotify));
			Singleton<Net>.Instance.Register<RoguelikeRoleRoomNotify>(ENotifyMessageId.RoguelikeRoleRoomNotify, new Action<RoguelikeRoleRoomNotify, Net.CallbackStatus>(this.RoguelikeRoleRoomNotify));
			Singleton<Net>.Instance.Register<RogueBlackFlowerNotify>(ENotifyMessageId.RogueBlackFlowerNotify, new Action<RogueBlackFlowerNotify, Net.CallbackStatus>(this.OnRogueBlackFlowerNotify));
			Singleton<Net>.Instance.Register<RogueTowerTrialSelectBossNotify>(ENotifyMessageId.RogueTowerTrialSelectBossNotify, new Action<RogueTowerTrialSelectBossNotify, Net.CallbackStatus>(this.OnRogueTowerTrialSelectBossNotify));
			Singleton<Net>.Instance.Register<RogueTowerTrialResultNotify>(ENotifyMessageId.RogueTowerTrialResultNotify, new Action<RogueTowerTrialResultNotify, Net.CallbackStatus>(this.OnRogueTowerTrialResultNotify));
		}

		// Token: 0x060357B6 RID: 219062 RVA: 0x00D6D0BC File Offset: 0x00D6B2BC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeSubLevelNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeChooseDataNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeRoomInfoNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeResultNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeTalentUnlockNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeCurrencyNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeCurrencyUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeEventGainNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeRoleRoomNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoguelikeGainDataUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueTowerTrialSelectBossNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RogueTowerTrialResultNotify);
		}

		// Token: 0x060357B7 RID: 219063 RVA: 0x00D6D19C File Offset: 0x00D6B39C
		private void OnRogueBlackFlowerNotify(RogueBlackFlowerNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
			RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
			if (rogueSeasonData == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Roguelike, ELogAuthor.LPH, "领取黒石花奖励失败，赛季数据不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int num = rogueSeasonData.BlackFlowerMaxCount - rogueSeasonData.BlackFlowerUseCount;
			if (num <= 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueBlackFlowerRewardNoCount", Array.Empty<object>());
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RogueBlackFlower);
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				this.RogueBlackFlowerRequest(notify.EntityConfigId, false);
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.RogueBlackFlowerRequest(notify.EntityConfigId, true);
			};
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("RogueBlackFlowerRewardTip", null);
			confirmBoxDataNew.Tip = StringUtils.Format(localTextNew, new string[]
			{
				num.ToString(),
				rogueSeasonData.BlackFlowerMaxCount.ToString()
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x060357B8 RID: 219064 RVA: 0x00D6D2A4 File Offset: 0x00D6B4A4
		private void RoguelikeRoleRoomNotify(RoguelikeRoleRoomNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RoguelikeCharacterSelectOpenParam param = new RoguelikeCharacterSelectOpenParam
			{
				Index = notify.Index,
				RoomIdList = notify.RoleRoomIds.ToList<int>()
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueCharacterRoomSelectView, param, null);
		}

		// Token: 0x060357B9 RID: 219065 RVA: 0x00D6D2E8 File Offset: 0x00D6B4E8
		private void RoguelikeResultNotify(RoguelikeResultNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			RoguelikeResultInfo resultInfo = notify.RoguelikeResultInfo;
			if (this.TryExitRoguelikeWithoutSettleView(resultInfo))
			{
				return;
			}
			this.IsFromRogueToNormal = new bool?(!ModelBase<RoguelikeModel>.Instance.CheckIsGuideDungeon());
			if (resultInfo.IsDeadTrigger)
			{
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeSettleView, resultInfo, null);
				}, 2000f, null, null, true, 1f);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeSettleView, resultInfo, null);
		}

		// Token: 0x060357BA RID: 219066 RVA: 0x00D6D376 File Offset: 0x00D6B576
		private bool TryExitRoguelikeWithoutSettleView(RoguelikeResultInfo resultInfo)
		{
			if (resultInfo.InstId != 0)
			{
				return false;
			}
			if (ModelBase<RoguelikeModel>.Instance.CheckInRoguelike())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
			}
			return true;
		}

		// Token: 0x060357BB RID: 219067 RVA: 0x00D6D39C File Offset: 0x00D6B59C
		private unsafe void RoguelikeRoomInfoNotify(RoguelikeRoomInfoNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<RoguelikeModel>.Instance.CurRoomCount = notify.CurLayer;
			ModelBase<RoguelikeModel>.Instance.TotalRoomCount = notify.MaxLayer;
			ModelBase<RoguelikeModel>.Instance.CurRoomId = new int?(notify.RoguelikeRoomId);
			RogueRoomPool? roguelikeRoomPoolConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeRoomPoolConfig(notify.RoguelikeRoomId);
			RogueRoomType? roguelikeRoomTypeConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeRoomTypeConfigById(notify.RoguelikeRoomTypeId);
			ModelBase<RoguelikeModel>.Instance.CurRoomTypeId = ((roguelikeRoomTypeConfigById != null) ? roguelikeRoomTypeConfigById.GetValueOrDefault().RoomType : null);
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			int? num = (roguelikeRoomTypeConfigById != null) ? new int?(roguelikeRoomTypeConfigById.GetValueOrDefault().RoomTipsType) : null;
			instance.CurRoomType = ((num != null) ? new RoguelikeRoomType?((RoguelikeRoomType)num.GetValueOrDefault()) : null);
			if (!StringUtils.IsEmpty((roguelikeRoomPoolConfig != null) ? roguelikeRoomPoolConfig.GetValueOrDefault().RoomsMusicState : null))
			{
				ModelBase<RoguelikeModel>.Instance.CurRoomMusicState = ((roguelikeRoomPoolConfig != null) ? roguelikeRoomPoolConfig.GetValueOrDefault().RoomsMusicState : null);
			}
			else
			{
				ModelBase<RoguelikeModel>.Instance.CurRoomMusicState = ((roguelikeRoomTypeConfigById != null) ? roguelikeRoomTypeConfigById.GetValueOrDefault().RoomsMusicState : null);
			}
			if (notify.SkyBoxId != 0)
			{
				ModelBase<WeatherModel>.Instance.GetWorldWeatherActor().ChangeWeather(notify.SkyBoxId, 0f);
			}
			else
			{
				ControllerBase<WeatherController>.Instance.StopWeather();
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roguelike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[经典肉鸽] 房间信息变更";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("RoomId", notify.RoguelikeRoomId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoomTypeId", notify.RoguelikeRoomTypeId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("RoomType", (roguelikeRoomTypeConfigById != null) ? roguelikeRoomTypeConfigById.GetValueOrDefault().RoomType : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Progress", notify.CurLayer.ToString() + "/" + notify.MaxLayer.ToString());
			instance2.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x060357BC RID: 219068 RVA: 0x00D6D5F4 File Offset: 0x00D6B7F4
		private unsafe void OnRogueInfoNotify(RoguelikeInfoNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (notify.RoguelikeInstInfo == null)
			{
				return;
			}
			ModelBase<RoguelikeModel>.Instance.RogueModeType = new RogueChallengeModeType?(notify.ModeType);
			ModelBase<RoguelikeModel>.Instance.RogueInfo = new RoguelikeInfo(notify.RoguelikeInstInfo);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Roguelike;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[经典肉鸽] 进入玩法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Mode", notify.ModeType);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
			string item = "Role";
			RogueGainEntry roleEntry = notify.RoguelikeInstInfo.RoleEntry;
			ptr = new ValueTuple<string, object>(item, (roleEntry != null) ? new int?(roleEntry.ConfigId) : null);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x060357BD RID: 219069 RVA: 0x00D6D6BC File Offset: 0x00D6B8BC
		private void OnRogueTowerTrialSelectBossNotify(RogueTowerTrialSelectBossNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.RoguelikeBossChallengeView) != null)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RoguelikeBossChallengeView, null);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RoguelikeBossChallengeView, notify.BossInfos.ToList<RogueTowerTrialBossInfo>(), null);
		}

		// Token: 0x060357BE RID: 219070 RVA: 0x00D6D6FC File Offset: 0x00D6B8FC
		private void OnRogueTowerTrialResultNotify(RogueTowerTrialResultNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			int instanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			this.OpenRoguelikeBossChallengeResultView(instanceId, notify.RogueTowerTrialResultInfo);
		}

		// Token: 0x060357BF RID: 219071 RVA: 0x00D6D724 File Offset: 0x00D6B924
		private void RoguelikeSubLevelNotify(RoguelikeSubLevelNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			RoguelikeController.<>c__DisplayClass58_0 CS$<>8__locals1 = new RoguelikeController.<>c__DisplayClass58_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.notify = notify;
			AsyncTask task = new AsyncTask("RoguelikeSubLevelChangeTask", delegate()
			{
				RoguelikeController.<>c__DisplayClass58_0.<<RoguelikeSubLevelNotify>b__0>d <<RoguelikeSubLevelNotify>b__0>d;
				<<RoguelikeSubLevelNotify>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
				<<RoguelikeSubLevelNotify>b__0>d.<>4__this = CS$<>8__locals1;
				<<RoguelikeSubLevelNotify>b__0>d.<>1__state = -1;
				<<RoguelikeSubLevelNotify>b__0>d.<>t__builder.Start<RoguelikeController.<>c__DisplayClass58_0.<<RoguelikeSubLevelNotify>b__0>d>(ref <<RoguelikeSubLevelNotify>b__0>d);
				return <<RoguelikeSubLevelNotify>b__0>d.<>t__builder.Task;
			}, null, null, null);
			Singleton<TaskSystem>.Instance.AddTask(task);
			Singleton<TaskSystem>.Instance.Run();
		}

		// Token: 0x060357C0 RID: 219072 RVA: 0x00D6D778 File Offset: 0x00D6B978
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1,
			1
		})]
		private ValueTuple<string[], string[]> FilterSameSubLevel(RoguelikeSubLevelNotify notify)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			foreach (string text in notify.UnLoadSubLevels)
			{
				bool flag = false;
				foreach (string b in notify.LoadSubLevels)
				{
					if (text == b)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(text);
				}
			}
			foreach (string text2 in notify.LoadSubLevels)
			{
				bool flag2 = false;
				foreach (string b2 in notify.UnLoadSubLevels)
				{
					if (text2 == b2)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					list2.Add(text2);
				}
			}
			return new ValueTuple<string[], string[]>(list.ToArray(), list2.ToArray());
		}

		// Token: 0x060357C1 RID: 219073 RVA: 0x00D6D8C4 File Offset: 0x00D6BAC4
		private void RogueBlackFlowerRequest(int entityId, bool isReceive)
		{
			RogueBlackFlowerRequest rogueBlackFlowerRequest = Aki.Protocol.RogueBlackFlowerRequest.Create();
			rogueBlackFlowerRequest.EntityConfigId = entityId;
			rogueBlackFlowerRequest.Ret = isReceive;
			Singleton<Net>.Instance.Call<RogueBlackFlowerResponse>(ERequestMessageId.RogueBlackFlowerRequest, rogueBlackFlowerRequest, delegate(RogueBlackFlowerResponse response, Net.CallbackStatus _)
			{
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16497, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060357C2 RID: 219074 RVA: 0x00D6D918 File Offset: 0x00D6BB18
		private UniTask RoguelikeGotoNextRoomRequest()
		{
			RoguelikeController.<RoguelikeGotoNextRoomRequest>d__61 <RoguelikeGotoNextRoomRequest>d__;
			<RoguelikeGotoNextRoomRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoguelikeGotoNextRoomRequest>d__.<>1__state = -1;
			<RoguelikeGotoNextRoomRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeGotoNextRoomRequest>d__61>(ref <RoguelikeGotoNextRoomRequest>d__);
			return <RoguelikeGotoNextRoomRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C3 RID: 219075 RVA: 0x00D6D954 File Offset: 0x00D6BB54
		public UniTask RoguelikeGiveUpGainRequest(int bindId)
		{
			RoguelikeController.<RoguelikeGiveUpGainRequest>d__62 <RoguelikeGiveUpGainRequest>d__;
			<RoguelikeGiveUpGainRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoguelikeGiveUpGainRequest>d__.bindId = bindId;
			<RoguelikeGiveUpGainRequest>d__.<>1__state = -1;
			<RoguelikeGiveUpGainRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeGiveUpGainRequest>d__62>(ref <RoguelikeGiveUpGainRequest>d__);
			return <RoguelikeGiveUpGainRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C4 RID: 219076 RVA: 0x00D6D998 File Offset: 0x00D6BB98
		[NullableContext(0)]
		public UniTask<bool> RoguelikeTokenReceiveRequest(int seasonId, int id)
		{
			RoguelikeController.<RoguelikeTokenReceiveRequest>d__63 <RoguelikeTokenReceiveRequest>d__;
			<RoguelikeTokenReceiveRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RoguelikeTokenReceiveRequest>d__.seasonId = seasonId;
			<RoguelikeTokenReceiveRequest>d__.id = id;
			<RoguelikeTokenReceiveRequest>d__.<>1__state = -1;
			<RoguelikeTokenReceiveRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeTokenReceiveRequest>d__63>(ref <RoguelikeTokenReceiveRequest>d__);
			return <RoguelikeTokenReceiveRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C5 RID: 219077 RVA: 0x00D6D9E4 File Offset: 0x00D6BBE4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<RoguelikePopularEntriesInfoResponse> RoguelikePopularEntriesInfoRequest(int instanceId)
		{
			RoguelikeController.<RoguelikePopularEntriesInfoRequest>d__64 <RoguelikePopularEntriesInfoRequest>d__;
			<RoguelikePopularEntriesInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<RoguelikePopularEntriesInfoResponse>.Create();
			<RoguelikePopularEntriesInfoRequest>d__.instanceId = instanceId;
			<RoguelikePopularEntriesInfoRequest>d__.<>1__state = -1;
			<RoguelikePopularEntriesInfoRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikePopularEntriesInfoRequest>d__64>(ref <RoguelikePopularEntriesInfoRequest>d__);
			return <RoguelikePopularEntriesInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C6 RID: 219078 RVA: 0x00D6DA28 File Offset: 0x00D6BC28
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<RoguelikeTrialRoleInfoResponse> RoguelikeTrialRoleInfoRequest(List<int> instanceIdList)
		{
			RoguelikeController.<RoguelikeTrialRoleInfoRequest>d__65 <RoguelikeTrialRoleInfoRequest>d__;
			<RoguelikeTrialRoleInfoRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder<RoguelikeTrialRoleInfoResponse>.Create();
			<RoguelikeTrialRoleInfoRequest>d__.instanceIdList = instanceIdList;
			<RoguelikeTrialRoleInfoRequest>d__.<>1__state = -1;
			<RoguelikeTrialRoleInfoRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikeTrialRoleInfoRequest>d__65>(ref <RoguelikeTrialRoleInfoRequest>d__);
			return <RoguelikeTrialRoleInfoRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C7 RID: 219079 RVA: 0x00D6DA6C File Offset: 0x00D6BC6C
		public UniTask RoguelikePopularEntriesChangeRequest(int instanceId, List<int> entries)
		{
			RoguelikeController.<RoguelikePopularEntriesChangeRequest>d__66 <RoguelikePopularEntriesChangeRequest>d__;
			<RoguelikePopularEntriesChangeRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RoguelikePopularEntriesChangeRequest>d__.instanceId = instanceId;
			<RoguelikePopularEntriesChangeRequest>d__.entries = entries;
			<RoguelikePopularEntriesChangeRequest>d__.<>1__state = -1;
			<RoguelikePopularEntriesChangeRequest>d__.<>t__builder.Start<RoguelikeController.<RoguelikePopularEntriesChangeRequest>d__66>(ref <RoguelikePopularEntriesChangeRequest>d__);
			return <RoguelikePopularEntriesChangeRequest>d__.<>t__builder.Task;
		}

		// Token: 0x060357C8 RID: 219080 RVA: 0x00D6DAB8 File Offset: 0x00D6BCB8
		[NullableContext(2)]
		public unsafe Action<bool?> CreateCloseViewCallBack([Nullable(1)] RoguelikeChooseDataResultResponse notify, Action<bool?> finishCallback = null)
		{
			RogueViewPackage rogueViewPackage = notify.RogueViewPackage;
			RepeatedField<RogueViewGroup> repeatedField = (rogueViewPackage != null) ? rogueViewPackage.RogueViewGroups : null;
			if (repeatedField == null || repeatedField.Count <= 0)
			{
				Action<bool?> finishCallback2 = finishCallback;
				if (finishCallback2 != null)
				{
					finishCallback2(null);
				}
				return null;
			}
			List<RogueViewUnit> rogueUnits = new List<RogueViewUnit>();
			foreach (RogueViewGroup rogueViewGroup in repeatedField)
			{
				if (rogueViewGroup.RogueViewUnit != null)
				{
					rogueUnits.Add(rogueViewGroup.RogueViewUnit);
				}
				if (rogueViewGroup.ChildRogueViewUnits.Count <= 0)
				{
					foreach (RogueViewUnit item in rogueViewGroup.ChildRogueViewUnits)
					{
						rogueUnits.Add(item);
					}
				}
			}
			if (rogueUnits.Count <= 0)
			{
				Action<bool?> finishCallback3 = finishCallback;
				if (finishCallback3 != null)
				{
					finishCallback3(null);
				}
				return null;
			}
			int index = 0;
			Action<bool?> callback = null;
			callback = delegate(bool? result)
			{
				bool? flag = result;
				bool flag2 = false;
				int index;
				if (flag.GetValueOrDefault() == flag2 & flag != null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Roguelike;
					ELogAuthor author = ELogAuthor.ZJC;
					string message = "CreateCloseViewCallBack err";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("index", index);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("notify", notify);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
				List<RogueViewUnit> rogueUnits;
				if (index >= rogueUnits.Count)
				{
					Action<bool?> finishCallback4 = finishCallback;
					if (finishCallback4 == null)
					{
						return;
					}
					finishCallback4(null);
					return;
				}
				else
				{
					rogueUnits = rogueUnits;
					index = index;
					index++;
					RogueViewUnit rogueViewUnit = rogueUnits[index];
					RogueViewUnit.DataOneofCase dataCase = rogueViewUnit.DataCase;
					if (dataCase == RogueViewUnit.DataOneofCase.RoguelikeEventGainNotify)
					{
						this.RoguelikeEventGainNotify(rogueViewUnit.RoguelikeEventGainNotify, callback);
						return;
					}
					if (dataCase != RogueViewUnit.DataOneofCase.ItemObtainNotify)
					{
						return;
					}
					ControllerBase<ItemRewardController>.Instance.OnItemObtainNotify(rogueViewUnit.ItemObtainNotify, callback);
					return;
				}
			};
			return callback;
		}

		// Token: 0x0401EBF0 RID: 125936
		private bool? IsFromRogueToNormal = new bool?(false);

		// Token: 0x0401EBF1 RID: 125937
		public string CurrentFlowListName = "";

		// Token: 0x0401EBF2 RID: 125938
		public int CurrentFlowId;

		// Token: 0x0401EBF3 RID: 125939
		public int CurrentStateId;

		// Token: 0x0401EBF4 RID: 125940
		public int RandomEventIndex;
	}
}
