using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Compose;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Manufacture.Forging
{
	// Token: 0x020059A1 RID: 22945
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ForgingController : UiControllerBase<ForgingController>
	{
		// Token: 0x17009483 RID: 38019
		// (get) Token: 0x0603A16A RID: 237930 RVA: 0x00EB3644 File Offset: 0x00EB1844
		public int ForgingCostId
		{
			get
			{
				return ConfigCommonParamById.GetIntConfig("ForgingCost").GetValueOrDefault(-1);
			}
		}

		// Token: 0x0603A16B RID: 237931 RVA: 0x00EB3664 File Offset: 0x00EB1864
		protected override bool OnClear()
		{
			this.ClearCurrentInteractionEntityDisplay();
			return true;
		}

		// Token: 0x0603A16C RID: 237932 RVA: 0x00EB366D File Offset: 0x00EB186D
		protected override bool OnLeaveLevel()
		{
			this.ClearCurrentInteractionEntityDisplay();
			return true;
		}

		// Token: 0x0603A16D RID: 237933 RVA: 0x00EB3678 File Offset: 0x00EB1878
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = ForgingController.<>O.<0>__UpdateHelpRoleItemDataList) == null)
			{
				handle = (ForgingController.<>O.<0>__UpdateHelpRoleItemDataList = new Action<int>(ForgingController.UpdateHelpRoleItemDataList));
			}
			instance.Add<int>(name, handle);
			Singleton<EventSystem>.Instance.Add(EEventName.SwitchViewType, new Action<CSharpScript.Game.Module.Manufacture.Common.EViewType>(this.SwitchViewType));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
		}

		// Token: 0x0603A16E RID: 237934 RVA: 0x00EB36E8 File Offset: 0x00EB18E8
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = ForgingController.<>O.<0>__UpdateHelpRoleItemDataList) == null)
			{
				handle = (ForgingController.<>O.<0>__UpdateHelpRoleItemDataList = new Action<int>(ForgingController.UpdateHelpRoleItemDataList));
			}
			instance.Remove(name, handle);
			Singleton<EventSystem>.Instance.Remove(EEventName.SwitchViewType, new Action<CSharpScript.Game.Module.Manufacture.Common.EViewType>(this.SwitchViewType));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
		}

		// Token: 0x0603A16F RID: 237935 RVA: 0x00EB3758 File Offset: 0x00EB1958
		private void LoadNewList()
		{
			ModelBase<ForgingModel>.Instance.CreateForgingDataList();
			this.SendForgeInfoRequest();
		}

		// Token: 0x0603A170 RID: 237936 RVA: 0x00EB376A File Offset: 0x00EB196A
		private void SwitchViewType(CSharpScript.Game.Module.Manufacture.Common.EViewType viewType)
		{
			if (Singleton<CommonManager>.Instance.GetCurrentSystem() != CSharpScript.Game.Module.Manufacture.Common.ESystemType.ForgingSystem)
			{
				return;
			}
			if (viewType == CSharpScript.Game.Module.Manufacture.Common.EViewType.RoleViewType)
			{
				ModelBase<ForgingModel>.Instance.CurrentForgingViewType = EForgingViewType.ForgingRoleType;
				return;
			}
			if (viewType != CSharpScript.Game.Module.Manufacture.Common.EViewType.ManufactureViewType)
			{
				return;
			}
			ModelBase<ForgingModel>.Instance.CurrentForgingViewType = EForgingViewType.ForgingType;
		}

		// Token: 0x0603A171 RID: 237937 RVA: 0x00EB3799 File Offset: 0x00EB1999
		private static void UpdateHelpRoleItemDataList(int i)
		{
			ModelBase<ForgingModel>.Instance.UpdateHelpRoleItemDataList();
		}

		// Token: 0x0603A172 RID: 237938 RVA: 0x00EB37A5 File Offset: 0x00EB19A5
		public void RegisterCurrentInteractionEntity()
		{
			this.CurrentInteractionEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
		}

		// Token: 0x0603A173 RID: 237939 RVA: 0x00EB37B7 File Offset: 0x00EB19B7
		public void ClearCurrentInteractionEntityDisplay()
		{
			if (this.CurrentInteractionEntityId == null)
			{
				return;
			}
			this.ClearForgingDisplay();
			this.CurrentInteractionEntityId = null;
		}

		// Token: 0x0603A174 RID: 237940 RVA: 0x00EB37D9 File Offset: 0x00EB19D9
		[NullableContext(2)]
		private void UpdateForgingDataCore(ForgeInfoResponse response)
		{
			ModelBase<ForgingModel>.Instance.UpdateForgingDataList(response.ForgeInfoList);
			ModelBase<ForgingModel>.Instance.UpdateForgingByServerConfig(response.ForgeInfoList);
		}

		// Token: 0x0603A175 RID: 237941 RVA: 0x00EB37FB File Offset: 0x00EB19FB
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<ForgeItemInfoUpdateNotify>(ENotifyMessageId.ForgeItemInfoUpdateNotify, delegate(ForgeItemInfoUpdateNotify response, Net.CallbackStatus status)
			{
				ForgingModel instance = ModelBase<ForgingModel>.Instance;
				bool flag = false;
				foreach (OneForgeInfo oneForgeInfo in response.ForgeInfoList)
				{
					int id = oneForgeInfo.Id;
					IWeaponForgingData forgingDataById = instance.GetForgingDataById(id);
					if (forgingDataById != null && forgingDataById.IsUnlock <= 0)
					{
						forgingDataById.IsNew = true;
						forgingDataById.IsUnlock = 1;
						ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.ForgingLevelKey, id);
						flag = true;
					}
				}
				if (flag)
				{
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("FormulaLearned", Array.Empty<object>());
				}
			});
		}

		// Token: 0x0603A176 RID: 237942 RVA: 0x00EB382C File Offset: 0x00EB1A2C
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ForgeItemInfoUpdateNotify);
		}

		// Token: 0x0603A177 RID: 237943 RVA: 0x00EB3840 File Offset: 0x00EB1A40
		public void SendForgeInfoRequest()
		{
			if (this.SendForgeInfoRequestFlag)
			{
				return;
			}
			this.SendForgeInfoRequestFlag = true;
			ForgeInfoRequest message = ForgeInfoRequest.Create();
			Singleton<Net>.Instance.Call<ForgeInfoResponse>(ERequestMessageId.ForgeInfoRequest, message, delegate(ForgeInfoResponse response, Net.CallbackStatus status)
			{
				this.SendForgeInfoRequestFlag = false;
				if (response.Code == Aki.Protocol.ErrorCode.Success)
				{
					ModelBase<ForgingModel>.Instance.SaveLimitRefreshTime(response.LimitRefreshTime);
					this.UpdateForgingDataCore(response);
					Singleton<EventSystem>.Instance.Emit(EEventName.GetForgingData);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 18525, null, true, false);
				if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ForgingRootView))
				{
					Singleton<UiManager>.Instance.CloseView(EUiViewName.ForgingRootView, null);
				}
			}, 0);
		}

		// Token: 0x0603A178 RID: 237944 RVA: 0x00EB3880 File Offset: 0x00EB1A80
		public UniTask SendForgeInfoRequestAsync()
		{
			ForgingController.<SendForgeInfoRequestAsync>d__23 <SendForgeInfoRequestAsync>d__;
			<SendForgeInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendForgeInfoRequestAsync>d__.<>4__this = this;
			<SendForgeInfoRequestAsync>d__.<>1__state = -1;
			<SendForgeInfoRequestAsync>d__.<>t__builder.Start<ForgingController.<SendForgeInfoRequestAsync>d__23>(ref <SendForgeInfoRequestAsync>d__);
			return <SendForgeInfoRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A179 RID: 237945 RVA: 0x00EB38C4 File Offset: 0x00EB1AC4
		public void SendForgeItemRequest(int id, int roleId, int forgingCount)
		{
			ForgeItemRequest forgeItemRequest = ForgeItemRequest.Create();
			forgeItemRequest.Id = id;
			forgeItemRequest.RoleId = roleId;
			forgeItemRequest.Count = forgingCount;
			forgeItemRequest.InteractEntityId = ModelBase<ForgingModel>.Instance.CurrentInteractCreatureDataLongId.Value;
			Singleton<Net>.Instance.Call<ForgeItemResponse>(ERequestMessageId.ForgeItemRequest, forgeItemRequest, delegate(ForgeItemResponse response, Net.CallbackStatus status)
			{
				if (response.Code == Aki.Protocol.ErrorCode.Success)
				{
					IWeaponForgingData forgingDataById = ModelBase<ForgingModel>.Instance.GetForgingDataById(response.Id);
					if (forgingDataById != null)
					{
						forgingDataById.LastRoleId = response.RoleId;
					}
					RepeatedField<SingleItemInfo> itemInfos = response.ItemInfos;
					if (response.ExtraItemInfos.Count != 0)
					{
						itemInfos.AddRange(response.ExtraItemInfos);
					}
					List<RewardItemData> list = new List<RewardItemData>();
					foreach (SingleItemInfo singleItemInfo in itemInfos)
					{
						int itemId = singleItemInfo.ItemId;
						int count = 1;
						for (int i = 0; i < singleItemInfo.ItemNum; i++)
						{
							RewardItemData item = new RewardItemData(itemId, count, null, EDropItemType.Normal);
							list.Add(item);
						}
					}
					this.PlayForgingAudio("play_ui_fx_spl_gen_robot_success_vo", null);
					ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2003, true, list, null);
					ModelBase<ForgingModel>.Instance.UpdateForgingItemList(itemInfos);
					Singleton<EventSystem>.Instance.Emit(EEventName.ForgingSuccess);
					return;
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.ForgingFail);
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 18761, null, true, true);
			}, 0);
		}

		// Token: 0x0603A17A RID: 237946 RVA: 0x00EB3920 File Offset: 0x00EB1B20
		public void SendForgeFormulaUnlockRequest(int formulaId)
		{
			ForgeFormulaUnlockRequest forgeFormulaUnlockRequest = ForgeFormulaUnlockRequest.Create();
			forgeFormulaUnlockRequest.Id = formulaId;
			Singleton<Net>.Instance.Call<ForgeFormulaUnlockResponse>(ERequestMessageId.ForgeFormulaUnlockRequest, forgeFormulaUnlockRequest, delegate(ForgeFormulaUnlockResponse response, Net.CallbackStatus status)
			{
				if (response.Code == Aki.Protocol.ErrorCode.Success)
				{
					ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(formulaId);
					string localText = ConfigBase<ForgingConfig>.Instance.GetLocalText(forgeFormulaById.Value.Name);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ComposeStudy", new object[]
					{
						localText
					});
					Singleton<EventSystem>.Instance.Emit(EEventName.UpdateForgingFormula);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 28537, null, true, true);
			}, 0);
		}

		// Token: 0x0603A17B RID: 237947 RVA: 0x00EB396C File Offset: 0x00EB1B6C
		public bool CheckIsBuff(int roleId, int id)
		{
			return ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id).Value.RoleList().Contains(roleId);
		}

		// Token: 0x0603A17C RID: 237948 RVA: 0x00EB399C File Offset: 0x00EB1B9C
		public bool CheckIsBuffEx(int roleId, int itemId)
		{
			int[] source = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(itemId).Value.RoleList();
			if (source.Contains(roleId))
			{
				return false;
			}
			foreach (int value in ModelBase<RoleModel>.Instance.GetRoleIdList())
			{
				if (source.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A17D RID: 237949 RVA: 0x00EB3A28 File Offset: 0x00EB1C28
		public int GetMaxCreateCount(int itemId)
		{
			return this.DoGetMaxCreateCount(ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(itemId).Value.ConsumeItems(), ConfigCommonParamById.GetIntConfig("MaxForgingCount").Value);
		}

		// Token: 0x0603A17E RID: 237950 RVA: 0x00EB3A68 File Offset: 0x00EB1C68
		private int DoGetMaxCreateCount(IList<OneItemConfig> itemMap, int limitCount)
		{
			int num = limitCount;
			foreach (OneItemConfig oneItemConfig in itemMap)
			{
				int count = oneItemConfig.Count;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0);
				if (count > itemCountByConfigId)
				{
					return 0;
				}
				int num2 = itemCountByConfigId / count;
				num = ((num < num2) ? num : num2);
			}
			return num;
		}

		// Token: 0x0603A17F RID: 237951 RVA: 0x00EB3AE8 File Offset: 0x00EB1CE8
		public string GetForgingInfoText(int roleId)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			IEnumerable<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
			string result = "";
			foreach (Aki.Config.Skill skill in skillList)
			{
				if (skill.LeftSkillEffect != 0)
				{
					result = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(skill.SkillDescribe, null), skill.SkillDetailNum());
				}
			}
			return result;
		}

		// Token: 0x0603A180 RID: 237952 RVA: 0x00EB3B78 File Offset: 0x00EB1D78
		public bool CheckCanForging(int id)
		{
			return ModelBase<ForgingModel>.Instance.CheckCanForging(id);
		}

		// Token: 0x0603A181 RID: 237953 RVA: 0x00EB3B88 File Offset: 0x00EB1D88
		public bool CheckCanUnlock(int id)
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id);
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(forgeFormulaById.Value.FormulaItemId, 0) != 0;
		}

		// Token: 0x0603A182 RID: 237954 RVA: 0x00EB3BBE File Offset: 0x00EB1DBE
		public bool CheckCanForgingOrCanUnlock(int id)
		{
			if (ModelBase<ForgingModel>.Instance.GetForgingDataById(id).IsUnlock > 0)
			{
				return this.CheckCanForging(id);
			}
			return this.CheckCanUnlock(id);
		}

		// Token: 0x0603A183 RID: 237955 RVA: 0x00EB3BE4 File Offset: 0x00EB1DE4
		public string GetForgingText(int id)
		{
			ForgeFormula? forgeFormulaById = ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id);
			return ConfigBase<ForgingConfig>.Instance.GetLocalText(forgeFormulaById.Value.Name);
		}

		// Token: 0x0603A184 RID: 237956 RVA: 0x00EB3C18 File Offset: 0x00EB1E18
		public int GetForgingId(int id)
		{
			return ConfigBase<ForgingConfig>.Instance.GetForgeFormulaById(id).Value.ItemId;
		}

		// Token: 0x0603A185 RID: 237957 RVA: 0x00EB3C40 File Offset: 0x00EB1E40
		public List<ISingleItemInfo> GetForgingMaterialList(int itemId)
		{
			return ModelBase<ForgingModel>.Instance.GetForgingMaterialList(itemId);
		}

		// Token: 0x0603A186 RID: 237958 RVA: 0x00EB3C4D File Offset: 0x00EB1E4D
		public List<ICommonRoleItemData> GetHelpRoleItemDataList(int itemId)
		{
			return ModelBase<ForgingModel>.Instance.GetHelpRoleItemDataList(itemId);
		}

		// Token: 0x0603A187 RID: 237959 RVA: 0x00EB3C5A File Offset: 0x00EB1E5A
		public bool CheckShowRoleView()
		{
			return true;
		}

		// Token: 0x0603A188 RID: 237960 RVA: 0x00EB3C5D File Offset: 0x00EB1E5D
		public int GetCurrentRoleId()
		{
			return ModelBase<ForgingModel>.Instance.CurrentForgingRoleId;
		}

		// Token: 0x0603A189 RID: 237961 RVA: 0x00EB3C69 File Offset: 0x00EB1E69
		public void SetCurrentRoleId(int roleId)
		{
			ModelBase<ForgingModel>.Instance.CurrentForgingRoleId = roleId;
		}

		// Token: 0x0603A18A RID: 237962 RVA: 0x00EB3C76 File Offset: 0x00EB1E76
		public void SendManufacture(int itemId, int count)
		{
			if (!this.CheckCanForging(itemId))
			{
				this.PlayForgingFailDisplay(new Action(this.PlayForgingLoopDisplay));
				return;
			}
			this.SendForgeItemRequest(itemId, this.GetCurrentRoleId(), count);
		}

		// Token: 0x0603A18B RID: 237963 RVA: 0x00EB3CA2 File Offset: 0x00EB1EA2
		public int GetForgingRoleId(int itemId)
		{
			return ModelBase<ForgingModel>.Instance.GetForgingRoleId(itemId);
		}

		// Token: 0x0603A18C RID: 237964 RVA: 0x00EB3CAF File Offset: 0x00EB1EAF
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonPopItemData> GetForgingItemList()
		{
			return ModelBase<ForgingModel>.Instance.GetForgingItemList();
		}

		// Token: 0x0603A18D RID: 237965 RVA: 0x00EB3CBC File Offset: 0x00EB1EBC
		[NullableContext(2)]
		public void PlayForgingEnterDisplay(Action onFinished = null)
		{
			this.ClearForgingDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			this.PlayForgingAudio("play_ui_fx_spl_gen_page_open", null);
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.进入"];
			currentEntityTagComponent.AddTag(new int?(value));
		}

		// Token: 0x0603A18E RID: 237966 RVA: 0x00EB3D04 File Offset: 0x00EB1F04
		public void PlayForgingLoopDisplay()
		{
			this.ClearForgingDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			currentEntityTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.循环"]));
		}

		// Token: 0x0603A18F RID: 237967 RVA: 0x00EB3D3C File Offset: 0x00EB1F3C
		[NullableContext(2)]
		public bool PlayForgingWorkingDisplay(Action onFinished = null)
		{
			this.ClearForgingDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return false;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBeginPlayForgingWorkingDisplay);
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.工作中"];
			currentEntityTagComponent.AddTag(new int?(value));
			this.OnWorkingDisplayFinished = onFinished;
			this.ForgingDisplayTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayForgingWorkingDisplayFinished);
				if (this.OnWorkingDisplayFinished != null)
				{
					this.OnWorkingDisplayFinished();
				}
			}, 2000f, null, null, true, 1f);
			return true;
		}

		// Token: 0x0603A190 RID: 237968 RVA: 0x00EB3DB8 File Offset: 0x00EB1FB8
		[NullableContext(2)]
		public unsafe void PlayForgingFlow(PlayFlow playFlow, EPlotLowLevelPosition position = EPlotLowLevelPosition.Center)
		{
			if (playFlow != null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "[PlayForgingFlow]播放D级剧情";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", playFlow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StateId", playFlow.StateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", playFlow.FlowId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				UiParam uiParam = new UiParam
				{
					ViewName = new EUiViewName?(EUiViewName.ForgingRootView),
					Position = new EPlotLowLevelPosition?(position),
					TextWidth = new EPlotTextWidthType?(EPlotTextWidthType.Short)
				};
				ControllerBase<FlowController>.Instance.StartFlowForView(playFlow.FlowListName, playFlow.StateId, playFlow.FlowId, uiParam, true);
			}
		}

		// Token: 0x0603A191 RID: 237969 RVA: 0x00EB3EA0 File Offset: 0x00EB20A0
		private void PlayForgingAudio(string audioId, [Nullable(2)] PlayResult result = null)
		{
			Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId);
			if (audioPath == null)
			{
				return;
			}
			Singleton<AudioController>.Instance.PostEventByUi(audioPath.Value.Path, result, null, null);
		}

		// Token: 0x0603A192 RID: 237970 RVA: 0x00EB3EE7 File Offset: 0x00EB20E7
		public void PlayLeaveForgingAudio()
		{
			this.PlayForgingAudio("play_ui_fx_spl_gen_page_close", null);
		}

		// Token: 0x0603A193 RID: 237971 RVA: 0x00EB3EF8 File Offset: 0x00EB20F8
		[NullableContext(2)]
		public void PlayForgingFailDisplay(Action onFinished = null)
		{
			this.ClearForgingDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			PlayFlow composeFailFlow = ModelBase<ComposeModel>.Instance.ComposeFailFlow;
			this.PlayForgingFlow(composeFailFlow, EPlotLowLevelPosition.Center);
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"];
			currentEntityTagComponent.AddTag(new int?(value));
			this.OnFailDisplayFinished = onFinished;
			this.ForgingDisplayTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (this.OnFailDisplayFinished != null)
				{
					this.OnFailDisplayFinished();
				}
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603A194 RID: 237972 RVA: 0x00EB3F78 File Offset: 0x00EB2178
		public void ClearForgingDisplay()
		{
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent != null)
			{
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.工作中"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.循环"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.进入"]));
			}
			if (this.ForgingDisplayTimerId != null && TimerSystem.Instance.Has(this.ForgingDisplayTimerId))
			{
				TimerSystem.Instance.Remove(this.ForgingDisplayTimerId);
				this.ForgingDisplayTimerId = null;
			}
		}

		// Token: 0x0603A195 RID: 237973 RVA: 0x00EB4030 File Offset: 0x00EB2230
		[NullableContext(2)]
		private LevelTagComponent GetCurrentEntityTagComponent()
		{
			int? currentInteractEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
			if (currentInteractEntityId == null)
			{
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(currentInteractEntityId.Value);
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<LevelTagComponent>();
		}

		// Token: 0x04020F24 RID: 134948
		public const string ENTER_AUDIO_ID = "play_ui_fx_spl_gen_page_open";

		// Token: 0x04020F25 RID: 134949
		public const string LEAVE_AUDIO_ID = "play_ui_fx_spl_gen_page_close";

		// Token: 0x04020F26 RID: 134950
		public const string SUCCESS_AUDIO_ID = "play_ui_fx_spl_gen_robot_success_vo";

		// Token: 0x04020F27 RID: 134951
		[Nullable(2)]
		private TimerHandle ForgingDisplayTimerId;

		// Token: 0x04020F28 RID: 134952
		[Nullable(2)]
		private Action OnWorkingDisplayFinished;

		// Token: 0x04020F29 RID: 134953
		[Nullable(2)]
		private Action OnFailDisplayFinished;

		// Token: 0x04020F2A RID: 134954
		private int? CurrentInteractionEntityId = new int?(0);

		// Token: 0x04020F2B RID: 134955
		private bool SendForgeInfoRequestFlag;

		// Token: 0x0200B95F RID: 47455
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403941F RID: 234527
			[Nullable(0)]
			public static Action<int> <0>__UpdateHelpRoleItemDataList;
		}
	}
}
