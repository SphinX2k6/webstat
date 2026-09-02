using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Compose.QuicklyPopup;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Plot.PlotView;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059B3 RID: 22963
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ComposeController : UiControllerBase<ComposeController>
	{
		// Token: 0x17009486 RID: 38022
		// (get) Token: 0x0603A23C RID: 238140 RVA: 0x00EB84FC File Offset: 0x00EB66FC
		public int ComposeCoinId
		{
			get
			{
				return ConfigCommonParamById.GetIntConfig("ComposeCost").GetValueOrDefault(-1);
			}
		}

		// Token: 0x0603A23D RID: 238141 RVA: 0x00EB851C File Offset: 0x00EB671C
		protected override bool OnClear()
		{
			this.ClearCurrentInteractionEntityDisplay();
			return true;
		}

		// Token: 0x0603A23E RID: 238142 RVA: 0x00EB8525 File Offset: 0x00EB6725
		protected override bool OnLeaveLevel()
		{
			this.ClearCurrentInteractionEntityDisplay();
			return true;
		}

		// Token: 0x0603A23F RID: 238143 RVA: 0x00EB8530 File Offset: 0x00EB6730
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = ComposeController.<>O.<0>__UpdateHelpRoleItemDataList) == null)
			{
				handle = (ComposeController.<>O.<0>__UpdateHelpRoleItemDataList = new Action<int>(ComposeController.UpdateHelpRoleItemDataList));
			}
			instance.Add<int>(name, handle);
			Singleton<EventSystem>.Instance.Add(EEventName.SwitchViewType, new Action<CSharpScript.Game.Module.Manufacture.Common.EViewType>(this.SwitchViewType));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.ShowComposeStudy));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603A240 RID: 238144 RVA: 0x00EB85D8 File Offset: 0x00EB67D8
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = ComposeController.<>O.<0>__UpdateHelpRoleItemDataList) == null)
			{
				handle = (ComposeController.<>O.<0>__UpdateHelpRoleItemDataList = new Action<int>(ComposeController.UpdateHelpRoleItemDataList));
			}
			instance.Remove(name, handle);
			Singleton<EventSystem>.Instance.Remove(EEventName.SwitchViewType, new Action<CSharpScript.Game.Module.Manufacture.Common.EViewType>(this.SwitchViewType));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.ShowComposeStudy));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
		}

		// Token: 0x0603A241 RID: 238145 RVA: 0x00EB867D File Offset: 0x00EB687D
		private void LoadNewList()
		{
			ModelBase<ComposeModel>.Instance.CreatePurificationDataList();
		}

		// Token: 0x0603A242 RID: 238146 RVA: 0x00EB868C File Offset: 0x00EB688C
		private void SwitchViewType(CSharpScript.Game.Module.Manufacture.Common.EViewType viewType)
		{
			if (Singleton<CommonManager>.Instance.GetCurrentSystem() != CSharpScript.Game.Module.Manufacture.Common.ESystemType.ComposeSystem)
			{
				return;
			}
			switch (viewType)
			{
			case CSharpScript.Game.Module.Manufacture.Common.EViewType.RoleViewType:
				ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeRoleType;
				return;
			case CSharpScript.Game.Module.Manufacture.Common.EViewType.LevelViewType:
				ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeLevelType;
				return;
			case CSharpScript.Game.Module.Manufacture.Common.EViewType.ManufactureViewType:
				ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeType;
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A243 RID: 238147 RVA: 0x00EB86E0 File Offset: 0x00EB68E0
		private void ShowComposeStudy(int configId, int count)
		{
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(configId);
			if (!config.Value.ShowTypes().Contains(35) && !config.Value.ShowTypes().Contains(37))
			{
				return;
			}
			SynthesisFormula? synthesisFormulaByFormulaItemId = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaByFormulaItemId(configId);
			string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(synthesisFormulaByFormulaItemId.Value.Name);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ComposeStudy", new object[]
			{
				localText
			});
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFormula);
		}

		// Token: 0x0603A244 RID: 238148 RVA: 0x00EB877A File Offset: 0x00EB697A
		private void OnCloseView(EUiViewName view, int viewId)
		{
			if (view == EUiViewName.ItemTipsView)
			{
				ModelBase<ComposeModel>.Instance.ComposeSelectItem = null;
			}
		}

		// Token: 0x0603A245 RID: 238149 RVA: 0x00EB8794 File Offset: 0x00EB6994
		private static void UpdateHelpRoleItemDataList(int i)
		{
			ModelBase<ComposeModel>.Instance.UpdateHelpRoleItemDataList();
		}

		// Token: 0x0603A246 RID: 238150 RVA: 0x00EB87A0 File Offset: 0x00EB69A0
		public void RegisterCurrentInteractionEntity()
		{
			this.CurrentInteractionEntityId = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId;
		}

		// Token: 0x0603A247 RID: 238151 RVA: 0x00EB87B2 File Offset: 0x00EB69B2
		public void ClearCurrentInteractionEntityDisplay()
		{
			if (this.CurrentInteractionEntityId == null)
			{
				return;
			}
			this.ClearCompositeDisplay();
			this.CurrentInteractionEntityId = null;
		}

		// Token: 0x0603A248 RID: 238152 RVA: 0x00EB87D4 File Offset: 0x00EB69D4
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<SynthesisInfoUpdateNotify>(ENotifyMessageId.SynthesisInfoUpdateNotify, delegate(SynthesisInfoUpdateNotify response, Net.CallbackStatus _)
			{
				ModelBase<ComposeModel>.Instance.UpdateComposeDataList(response.SynthesisInfoList);
				ModelBase<ComposeModel>.Instance.HideComposeDataList(response.HideSynthesisIdList);
			});
			Singleton<Net>.Instance.Register<SynthesisLevelUpdateNotify>(ENotifyMessageId.SynthesisLevelUpdateNotify, delegate(SynthesisLevelUpdateNotify response, Net.CallbackStatus _)
			{
				ModelBase<ComposeModel>.Instance.UpdateComposeInfo(response.LevelInfo);
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateComposeInfo);
			});
		}

		// Token: 0x0603A249 RID: 238153 RVA: 0x00EB883F File Offset: 0x00EB6A3F
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SynthesisInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.SynthesisLevelUpdateNotify);
		}

		// Token: 0x0603A24A RID: 238154 RVA: 0x00EB8864 File Offset: 0x00EB6A64
		[NullableContext(2)]
		private void HandleSynthesisInfoRequestCore(SynthesisInfoResponse response)
		{
			ModelBase<ComposeModel>.Instance.CreateComposeDataList(response.SynthesisInfoList);
			ModelBase<ComposeModel>.Instance.UpdateComposeByServerConfig(response.SynthesisConfigs);
			ModelBase<ComposeModel>.Instance.CreateComposeLevelInfo(response.LevelInfo);
			ModelBase<ComposeModel>.Instance.SaveLimitRefreshTime(response.LimitRefreshTime);
		}

		// Token: 0x0603A24B RID: 238155 RVA: 0x00EB88B4 File Offset: 0x00EB6AB4
		public UniTask SendSynthesisInfoRequestAsync()
		{
			ComposeController.<SendSynthesisInfoRequestAsync>d__24 <SendSynthesisInfoRequestAsync>d__;
			<SendSynthesisInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendSynthesisInfoRequestAsync>d__.<>4__this = this;
			<SendSynthesisInfoRequestAsync>d__.<>1__state = -1;
			<SendSynthesisInfoRequestAsync>d__.<>t__builder.Start<ComposeController.<SendSynthesisInfoRequestAsync>d__24>(ref <SendSynthesisInfoRequestAsync>d__);
			return <SendSynthesisInfoRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A24C RID: 238156 RVA: 0x00EB88F8 File Offset: 0x00EB6AF8
		public UniTask SendSynthesisItemRequestBatchNew(List<IComposePopupGridItemData> composeGridData, [Nullable(2)] Action successCallback = null)
		{
			ComposeController.<SendSynthesisItemRequestBatchNew>d__25 <SendSynthesisItemRequestBatchNew>d__;
			<SendSynthesisItemRequestBatchNew>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendSynthesisItemRequestBatchNew>d__.<>4__this = this;
			<SendSynthesisItemRequestBatchNew>d__.composeGridData = composeGridData;
			<SendSynthesisItemRequestBatchNew>d__.successCallback = successCallback;
			<SendSynthesisItemRequestBatchNew>d__.<>1__state = -1;
			<SendSynthesisItemRequestBatchNew>d__.<>t__builder.Start<ComposeController.<SendSynthesisItemRequestBatchNew>d__25>(ref <SendSynthesisItemRequestBatchNew>d__);
			return <SendSynthesisItemRequestBatchNew>d__.<>t__builder.Task;
		}

		// Token: 0x0603A24D RID: 238157 RVA: 0x00EB894C File Offset: 0x00EB6B4C
		public UniTask SendSynthesisItemRequestNew(int id, int composeCount, List<SingleItemInfo> composeMaterialList, [Nullable(2)] Action successCallback = null)
		{
			ComposeController.<SendSynthesisItemRequestNew>d__26 <SendSynthesisItemRequestNew>d__;
			<SendSynthesisItemRequestNew>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendSynthesisItemRequestNew>d__.<>4__this = this;
			<SendSynthesisItemRequestNew>d__.id = id;
			<SendSynthesisItemRequestNew>d__.composeCount = composeCount;
			<SendSynthesisItemRequestNew>d__.composeMaterialList = composeMaterialList;
			<SendSynthesisItemRequestNew>d__.successCallback = successCallback;
			<SendSynthesisItemRequestNew>d__.<>1__state = -1;
			<SendSynthesisItemRequestNew>d__.<>t__builder.Start<ComposeController.<SendSynthesisItemRequestNew>d__26>(ref <SendSynthesisItemRequestNew>d__);
			return <SendSynthesisItemRequestNew>d__.<>t__builder.Task;
		}

		// Token: 0x0603A24E RID: 238158 RVA: 0x00EB89B0 File Offset: 0x00EB6BB0
		public UniTask SendSynthesisItemRequest(int id, int roleId, int composeCount)
		{
			ComposeController.<SendSynthesisItemRequest>d__27 <SendSynthesisItemRequest>d__;
			<SendSynthesisItemRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendSynthesisItemRequest>d__.<>4__this = this;
			<SendSynthesisItemRequest>d__.id = id;
			<SendSynthesisItemRequest>d__.roleId = roleId;
			<SendSynthesisItemRequest>d__.composeCount = composeCount;
			<SendSynthesisItemRequest>d__.<>1__state = -1;
			<SendSynthesisItemRequest>d__.<>t__builder.Start<ComposeController.<SendSynthesisItemRequest>d__27>(ref <SendSynthesisItemRequest>d__);
			return <SendSynthesisItemRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603A24F RID: 238159 RVA: 0x00EB8A0B File Offset: 0x00EB6C0B
		private static string FormatItemInfoList(IEnumerable<SingleItemInfo> list)
		{
			return string.Join(",", list.Select(delegate(SingleItemInfo item)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(item.ItemId);
				defaultInterpolatedStringHandler.AppendLiteral("x");
				defaultInterpolatedStringHandler.AppendFormatted<int>(item.ItemNum);
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}));
		}

		// Token: 0x0603A250 RID: 238160 RVA: 0x00EB8A3C File Offset: 0x00EB6C3C
		private static string FormatBatchItems(IEnumerable<BatchItem> items)
		{
			return string.Join("|", items.Select(delegate(BatchItem it)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
				defaultInterpolatedStringHandler.AppendFormatted<int>(it.Id);
				defaultInterpolatedStringHandler.AppendLiteral("x");
				defaultInterpolatedStringHandler.AppendFormatted<int>(it.Count);
				defaultInterpolatedStringHandler.AppendLiteral("{");
				defaultInterpolatedStringHandler.AppendFormatted(ComposeController.FormatItemInfoList(it.CostItems));
				defaultInterpolatedStringHandler.AppendLiteral("}");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}));
		}

		// Token: 0x0603A251 RID: 238161 RVA: 0x00EB8A70 File Offset: 0x00EB6C70
		private static string FormatConsumeMap(Dictionary<int, int> consumeItems)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<int, int> keyValuePair in consumeItems)
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int value = num;
				int value2 = num2;
				List<string> list2 = list;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("x");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value2);
				list2.Add(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return string.Join(",", list);
		}

		// Token: 0x0603A252 RID: 238162 RVA: 0x00EB8B0C File Offset: 0x00EB6D0C
		private unsafe void ProcessComposeResponseSuccess(IList<SingleItemInfo> tmpList, [Nullable(2)] Action successCallback = null)
		{
			ComposeController.<>c__DisplayClass31_0 CS$<>8__locals1 = new ComposeController.<>c__DisplayClass31_0();
			CS$<>8__locals1.<>4__this = this;
			ComposeModel instance = ModelBase<ComposeModel>.Instance;
			IComposeLevelInfoData composeInfo = instance.GetComposeInfo();
			int composeLevel = composeInfo.ComposeLevel;
			int composeMaxLevel = instance.GetComposeMaxLevel();
			SynthesisLevel? composeLevelByLevel = instance.GetComposeLevelByLevel(composeMaxLevel);
			int totalProficiency = composeInfo.TotalProficiency;
			int completeness = composeLevelByLevel.Value.Completeness;
			CS$<>8__locals1.rewardProgressList = null;
			if (instance.CurrentComposeListType == EComposeListType.ReagentProduction && (instance.LastExp < completeness || (composeLevel < composeMaxLevel && totalProficiency < completeness)))
			{
				SynthesisLevel? composeLevelByLevel2 = instance.GetComposeLevelByLevel(Math.Min(composeMaxLevel, composeLevel + 1));
				IRewardProgress rewardProgress = new RewardProgress
				{
					FromProgress = instance.LastExp,
					ToProgress = totalProficiency,
					MaxProgress = composeLevelByLevel2.Value.Completeness
				};
				ComposeController.<>c__DisplayClass31_0 CS$<>8__locals2 = CS$<>8__locals1;
				int num = 1;
				List<IRewardProgress> list = new List<IRewardProgress>(num);
				CollectionsMarshal.SetCount<IRewardProgress>(list, num);
				Span<IRewardProgress> span = CollectionsMarshal.AsSpan<IRewardProgress>(list);
				int index = 0;
				*span[index] = rewardProgress;
				CS$<>8__locals2.rewardProgressList = list;
			}
			instance.LastExp = totalProficiency;
			CS$<>8__locals1.rewardItemDataList = new List<RewardItemData>();
			foreach (SingleItemInfo singleItemInfo in tmpList)
			{
				int itemId = singleItemInfo.ItemId;
				int itemNum = singleItemInfo.ItemNum;
				RewardItemData item = new RewardItemData(itemId, itemNum, null, EDropItemType.Normal);
				CS$<>8__locals1.rewardItemDataList.Add(item);
			}
			if (successCallback != null)
			{
				successCallback();
			}
			else if (!this.PlayCompositeWorkingDisplay(delegate
			{
				CS$<>8__locals1.<>4__this.PlayCompositeAudio("play_ui_fx_spl_gen_robot_success_vo", null);
				CS$<>8__locals1.<>4__this.PlayCompositeLoopDisplay();
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2004, true, CS$<>8__locals1.rewardItemDataList, CS$<>8__locals1.rewardProgressList);
			}))
			{
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2004, true, CS$<>8__locals1.rewardItemDataList, CS$<>8__locals1.rewardProgressList);
			}
			ModelBase<ComposeModel>.Instance.UpdateComposeItemList(tmpList);
			Singleton<EventSystem>.Instance.Emit(EEventName.ComposeSuccess);
		}

		// Token: 0x0603A253 RID: 238163 RVA: 0x00EB8CD0 File Offset: 0x00EB6ED0
		[NullableContext(2)]
		public UniTask SendExchangeItemRequest(int targetId, int consumeItemId, int consumeCount, Action successCallback = null)
		{
			ComposeController.<SendExchangeItemRequest>d__32 <SendExchangeItemRequest>d__;
			<SendExchangeItemRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendExchangeItemRequest>d__.targetId = targetId;
			<SendExchangeItemRequest>d__.consumeItemId = consumeItemId;
			<SendExchangeItemRequest>d__.consumeCount = consumeCount;
			<SendExchangeItemRequest>d__.successCallback = successCallback;
			<SendExchangeItemRequest>d__.<>1__state = -1;
			<SendExchangeItemRequest>d__.<>t__builder.Start<ComposeController.<SendExchangeItemRequest>d__32>(ref <SendExchangeItemRequest>d__);
			return <SendExchangeItemRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603A254 RID: 238164 RVA: 0x00EB8D2C File Offset: 0x00EB6F2C
		public UniTask SendBatchMaterialReplaceRequest(int targetId, Dictionary<int, int> consumeItems, [Nullable(2)] Action successCallback = null)
		{
			ComposeController.<SendBatchMaterialReplaceRequest>d__33 <SendBatchMaterialReplaceRequest>d__;
			<SendBatchMaterialReplaceRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendBatchMaterialReplaceRequest>d__.targetId = targetId;
			<SendBatchMaterialReplaceRequest>d__.consumeItems = consumeItems;
			<SendBatchMaterialReplaceRequest>d__.successCallback = successCallback;
			<SendBatchMaterialReplaceRequest>d__.<>1__state = -1;
			<SendBatchMaterialReplaceRequest>d__.<>t__builder.Start<ComposeController.<SendBatchMaterialReplaceRequest>d__33>(ref <SendBatchMaterialReplaceRequest>d__);
			return <SendBatchMaterialReplaceRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603A255 RID: 238165 RVA: 0x00EB8D80 File Offset: 0x00EB6F80
		public void SendSynthesisLevelRewardRequest()
		{
			if (this.SendRewardFlag)
			{
				return;
			}
			SynthesisLevelRewardRequest message = SynthesisLevelRewardRequest.Create();
			this.SendRewardFlag = true;
			Singleton<Net>.Instance.Call<SynthesisLevelRewardResponse>(ERequestMessageId.SynthesisLevelRewardRequest, message, delegate(SynthesisLevelRewardResponse response, Net.CallbackStatus status)
			{
				this.SendRewardFlag = false;
				if (response.Code == Aki.Protocol.ErrorCode.Success)
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.UpgradeComposeLevel);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 23187, null, true, true);
			}, 0);
		}

		// Token: 0x0603A256 RID: 238166 RVA: 0x00EB8DC0 File Offset: 0x00EB6FC0
		public void SendSynthesisFormulaUnlockRequest(int formulaId)
		{
			SynthesisFormulaUnlockRequest synthesisFormulaUnlockRequest = SynthesisFormulaUnlockRequest.Create();
			synthesisFormulaUnlockRequest.Id = formulaId;
			Singleton<Net>.Instance.Call<SynthesisFormulaUnlockResponse>(ERequestMessageId.SynthesisFormulaUnlockRequest, synthesisFormulaUnlockRequest, delegate(SynthesisFormulaUnlockResponse response, Net.CallbackStatus status)
			{
				if (response.Code == Aki.Protocol.ErrorCode.Success)
				{
					ModelBase<ComposeModel>.Instance.UnlockReagentProductionData(response.Id);
					ModelBase<ComposeModel>.Instance.UnlockStructureData(response.Id);
					SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(formulaId);
					string localText = ConfigBase<ComposeConfig>.Instance.GetLocalText(synthesisFormulaById.Value.Name);
					ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("ComposeStudy", new object[]
					{
						localText
					});
					Singleton<EventSystem>.Instance.Emit(EEventName.UpdateComposeFormula);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 18698, null, true, true);
			}, 0);
		}

		// Token: 0x0603A257 RID: 238167 RVA: 0x00EB8E0C File Offset: 0x00EB700C
		public bool CheckIsBuff(int roleId, int itemId)
		{
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(itemId);
			for (int i = 0; i < synthesisFormulaById.Value.RoleListLength; i++)
			{
				if (synthesisFormulaById.Value.RoleList(i) == roleId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A258 RID: 238168 RVA: 0x00EB8E58 File Offset: 0x00EB7058
		public string GetComposeInfoText(int roleId)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			IEnumerable<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
			string result = "";
			foreach (Aki.Config.Skill skill in skillList)
			{
				if (skill.LeftSkillEffect != 0)
				{
					List<string> list = new List<string>();
					for (int i = 0; i < skill.SkillDetailNumLength; i++)
					{
						list.Add(skill.SkillDetailNum(i));
					}
					result = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(skill.SkillDescribe, null), list.ToArray());
				}
			}
			return result;
		}

		// Token: 0x0603A259 RID: 238169 RVA: 0x00EB8F18 File Offset: 0x00EB7118
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICommonPopItemData> GetComposeItemList()
		{
			return ModelBase<ComposeModel>.Instance.GetComposeItemList();
		}

		// Token: 0x0603A25A RID: 238170 RVA: 0x00EB8F24 File Offset: 0x00EB7124
		public void SetSelectedComposeLevel(int level)
		{
			ModelBase<ComposeModel>.Instance.SelectedComposeLevel = level;
		}

		// Token: 0x0603A25B RID: 238171 RVA: 0x00EB8F31 File Offset: 0x00EB7131
		public int GetSelectedComposeLevel()
		{
			return ModelBase<ComposeModel>.Instance.SelectedComposeLevel;
		}

		// Token: 0x0603A25C RID: 238172 RVA: 0x00EB8F3D File Offset: 0x00EB713D
		[NullableContext(2)]
		public IComposeLevelInfoData GetRewardLevelInfo()
		{
			return ModelBase<ComposeModel>.Instance.GetComposeInfo();
		}

		// Token: 0x0603A25D RID: 238173 RVA: 0x00EB8F49 File Offset: 0x00EB7149
		public SynthesisLevel? GetComposeLevelByLevel(int level)
		{
			return ModelBase<ComposeModel>.Instance.GetComposeLevelByLevel(level);
		}

		// Token: 0x0603A25E RID: 238174 RVA: 0x00EB8F56 File Offset: 0x00EB7156
		public int GetSumExpByLevel(int level)
		{
			return ModelBase<ComposeModel>.Instance.GetSumExpByLevel(level);
		}

		// Token: 0x0603A25F RID: 238175 RVA: 0x00EB8F63 File Offset: 0x00EB7163
		public int GetDropIdByLevel(int level)
		{
			return ModelBase<ComposeModel>.Instance.GetDropIdByLevel(level);
		}

		// Token: 0x0603A260 RID: 238176 RVA: 0x00EB8F70 File Offset: 0x00EB7170
		public int GetComposeMaxLevel()
		{
			return ModelBase<ComposeModel>.Instance.GetComposeMaxLevel();
		}

		// Token: 0x0603A261 RID: 238177 RVA: 0x00EB8F7C File Offset: 0x00EB717C
		public bool CheckCanReagentProduction(int id)
		{
			return ModelBase<ComposeModel>.Instance.CheckCanReagentProduction(id);
		}

		// Token: 0x0603A262 RID: 238178 RVA: 0x00EB8F89 File Offset: 0x00EB7189
		public bool CheckCanPurification(int id)
		{
			return ModelBase<ComposeModel>.Instance.CheckCanPurification(id);
		}

		// Token: 0x0603A263 RID: 238179 RVA: 0x00EB8F96 File Offset: 0x00EB7196
		public bool CheckCanCollect(int id)
		{
			return ModelBase<ComposeModel>.Instance.CheckCanCollect(id);
		}

		// Token: 0x0603A264 RID: 238180 RVA: 0x00EB8FA3 File Offset: 0x00EB71A3
		public bool CheckCanExchange(int id)
		{
			return ModelBase<ComposeModel>.Instance.CheckCanExchange(id);
		}

		// Token: 0x0603A265 RID: 238181 RVA: 0x00EB8FB0 File Offset: 0x00EB71B0
		public bool CheckCanStructure(int id)
		{
			return ModelBase<ComposeModel>.Instance.CheckCanStructure(id);
		}

		// Token: 0x0603A266 RID: 238182 RVA: 0x00EB8FC0 File Offset: 0x00EB71C0
		public bool CheckIsBuffEx(int roleId, int itemId)
		{
			int[] array = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(itemId).Value.RoleList();
			int[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] == roleId)
				{
					return false;
				}
			}
			foreach (int value in ModelBase<RoleModel>.Instance.GetRoleIdList())
			{
				if (array.Contains(value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A267 RID: 238183 RVA: 0x00EB9060 File Offset: 0x00EB7260
		public string GetComposeText(int itemId)
		{
			return ModelBase<ComposeModel>.Instance.GetComposeText(itemId);
		}

		// Token: 0x0603A268 RID: 238184 RVA: 0x00EB906D File Offset: 0x00EB726D
		public int GetComposeId(int itemId)
		{
			return ModelBase<ComposeModel>.Instance.GetComposeId(itemId);
		}

		// Token: 0x0603A269 RID: 238185 RVA: 0x00EB907A File Offset: 0x00EB727A
		public bool CheckShowRoleView()
		{
			return true;
		}

		// Token: 0x0603A26A RID: 238186 RVA: 0x00EB9080 File Offset: 0x00EB7280
		[NullableContext(2)]
		public int GetMaxCreateCount(int configId, IBaseItemData itemData = null)
		{
			if (ModelBase<ComposeModel>.Instance.IsInPurificationList())
			{
				return ModelBase<ComposeModel>.Instance.GetMaxCreateCountPurification(configId, itemData);
			}
			SynthesisFormula? synthesisFormulaById = ConfigBase<ComposeConfig>.Instance.GetSynthesisFormulaById(configId);
			List<OneItemConfig> list = new List<OneItemConfig>(synthesisFormulaById.Value.ConsumeItemsLength);
			for (int i = 0; i < synthesisFormulaById.Value.ConsumeItemsLength; i++)
			{
				list.Add(synthesisFormulaById.Value.ConsumeItems(i).Value);
			}
			int num = this.DoGetMaxCreateCount(list, synthesisFormulaById.Value.LimitCount);
			if (itemData == null)
			{
				return num;
			}
			if (itemData.TotalMakeCountInLimitTime <= 0)
			{
				return num;
			}
			int val = itemData.TotalMakeCountInLimitTime - itemData.MadeCountInLimitTime;
			return Math.Min(num, val);
		}

		// Token: 0x0603A26B RID: 238187 RVA: 0x00EB9148 File Offset: 0x00EB7348
		private int DoGetMaxCreateCount(IList<OneItemConfig> itemMap, int limitCount)
		{
			int num = 0;
			if (limitCount != 0)
			{
				num = limitCount;
			}
			else
			{
				num = ConfigCommonParamById.GetIntConfig("max_cooking_count").Value;
			}
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

		// Token: 0x0603A26C RID: 238188 RVA: 0x00EB91E4 File Offset: 0x00EB73E4
		public UniTask SendManufacture(int configId, int count)
		{
			ComposeController.<SendManufacture>d__58 <SendManufacture>d__;
			<SendManufacture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendManufacture>d__.<>4__this = this;
			<SendManufacture>d__.configId = configId;
			<SendManufacture>d__.count = count;
			<SendManufacture>d__.<>1__state = -1;
			<SendManufacture>d__.<>t__builder.Start<ComposeController.<SendManufacture>d__58>(ref <SendManufacture>d__);
			return <SendManufacture>d__.<>t__builder.Task;
		}

		// Token: 0x0603A26D RID: 238189 RVA: 0x00EB9238 File Offset: 0x00EB7438
		[NullableContext(2)]
		public UniTask SendExchangeRequest(int targetId, int consumeItemId, int consumeCount, Action successCallback = null)
		{
			ComposeController.<SendExchangeRequest>d__59 <SendExchangeRequest>d__;
			<SendExchangeRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SendExchangeRequest>d__.<>4__this = this;
			<SendExchangeRequest>d__.targetId = targetId;
			<SendExchangeRequest>d__.consumeItemId = consumeItemId;
			<SendExchangeRequest>d__.consumeCount = consumeCount;
			<SendExchangeRequest>d__.successCallback = successCallback;
			<SendExchangeRequest>d__.<>1__state = -1;
			<SendExchangeRequest>d__.<>t__builder.Start<ComposeController.<SendExchangeRequest>d__59>(ref <SendExchangeRequest>d__);
			return <SendExchangeRequest>d__.<>t__builder.Task;
		}

		// Token: 0x0603A26E RID: 238190 RVA: 0x00EB929C File Offset: 0x00EB749C
		public int GetCurrentRoleId()
		{
			return ModelBase<ComposeModel>.Instance.CurrentComposeRoleId;
		}

		// Token: 0x0603A26F RID: 238191 RVA: 0x00EB92A8 File Offset: 0x00EB74A8
		public void SetCurrentRoleId(int roleId)
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeRoleId = roleId;
		}

		// Token: 0x0603A270 RID: 238192 RVA: 0x00EB92B5 File Offset: 0x00EB74B5
		public List<ISingleItemInfo> GetManufactureMaterialList(int itemId)
		{
			return ModelBase<ComposeModel>.Instance.GetComposeMaterialList(itemId);
		}

		// Token: 0x0603A271 RID: 238193 RVA: 0x00EB92C2 File Offset: 0x00EB74C2
		public List<ICommonRoleItemData> GetHelpRoleItemDataList(int itemId)
		{
			return ModelBase<ComposeModel>.Instance.GetHelpRoleItemDataList(itemId);
		}

		// Token: 0x0603A272 RID: 238194 RVA: 0x00EB92D0 File Offset: 0x00EB74D0
		public int GetComposeRoleId(int itemId)
		{
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				return ModelBase<ComposeModel>.Instance.GetReagentProductionRoleId(itemId);
			case EComposeListType.Structure:
				return ModelBase<ComposeModel>.Instance.GetStructureRoleId(itemId);
			case EComposeListType.Purification:
				return ModelBase<ComposeModel>.Instance.GetPurificationRoleId(itemId);
			case EComposeListType.Collect:
				return ModelBase<ComposeModel>.Instance.GetCollectRoleId(itemId);
			}
			return 0;
		}

		// Token: 0x0603A273 RID: 238195 RVA: 0x00EB9337 File Offset: 0x00EB7537
		public bool CheckCanShowExpItem()
		{
			return ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.ReagentProduction;
		}

		// Token: 0x0603A274 RID: 238196 RVA: 0x00EB934C File Offset: 0x00EB754C
		public bool CheckCanGetComposeLevel()
		{
			IComposeLevelInfoData composeInfo = ModelBase<ComposeModel>.Instance.GetComposeInfo();
			if (composeInfo.ComposeLevel != ModelBase<ComposeModel>.Instance.GetComposeMaxLevel())
			{
				int sumExpByLevel = ModelBase<ComposeModel>.Instance.GetSumExpByLevel(composeInfo.ComposeLevel);
				if (composeInfo.TotalProficiency >= sumExpByLevel)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A275 RID: 238197 RVA: 0x00EB9394 File Offset: 0x00EB7594
		[NullableContext(2)]
		public void PlayCompositeEnterDisplay(Action onFinished = null)
		{
			this.ClearCompositeDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			PlayFlow composeEnterFlow = ModelBase<ComposeModel>.Instance.ComposeEnterFlow;
			this.PlayCompositeFlow(composeEnterFlow);
			this.PlayCompositeAudio("play_ui_fx_spl_gen_page_open", null);
			Singleton<global::Log>.Instance.Info(ELogModule.Test, ELogAuthor.WZ, "[CompositeDisplay]播放进入合成表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.进入"];
			currentEntityTagComponent.AddTag(new int?(value));
			this.OnEnterDisplayFinished = onFinished;
			this.CompositeDisplayTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (this.OnEnterDisplayFinished != null)
				{
					this.OnEnterDisplayFinished();
				}
			}, 3000f, null, null, true, 1f);
		}

		// Token: 0x0603A276 RID: 238198 RVA: 0x00EB9438 File Offset: 0x00EB7638
		public void PlayCompositeLoopDisplay()
		{
			this.ClearCompositeDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Test, ELogAuthor.WZ, "[CompositeDisplay]播放合成循环表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			currentEntityTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.循环"]));
		}

		// Token: 0x0603A277 RID: 238199 RVA: 0x00EB948C File Offset: 0x00EB768C
		[NullableContext(2)]
		public bool PlayCompositeWorkingDisplay(Action onFinished = null)
		{
			this.ClearCompositeDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return false;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBeginPlayCompositeWorkingDisplay);
			Singleton<global::Log>.Instance.Info(ELogModule.Test, ELogAuthor.WZ, "[CompositeDisplay]播放合成工作中表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.工作中"];
			currentEntityTagComponent.AddTag(new int?(value));
			this.OnWorkingDisplayFinished = onFinished;
			this.CompositeDisplayTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayCompositeWorkingDisplayFinished);
				if (this.OnWorkingDisplayFinished != null)
				{
					this.OnWorkingDisplayFinished();
				}
			}, 2000f, null, null, true, 1f);
			return true;
		}

		// Token: 0x0603A278 RID: 238200 RVA: 0x00EB9524 File Offset: 0x00EB7724
		[NullableContext(2)]
		public unsafe void PlayCompositeFlow(PlayFlow playFlow)
		{
			if (playFlow != null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Test;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "[PlayCompositeFlow]播放D级剧情";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("FlowListName", playFlow.FlowListName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("StateId", playFlow.StateId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("FlowId", playFlow.FlowId);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				UiParam uiParam = new UiParam
				{
					ViewName = new EUiViewName?(EUiViewName.ComposeCarryOnView),
					Position = new EPlotLowLevelPosition?(EPlotLowLevelPosition.Center),
					TextWidth = new EPlotTextWidthType?(EPlotTextWidthType.Short)
				};
				ControllerBase<FlowController>.Instance.StartFlowForView(playFlow.FlowListName, playFlow.StateId, playFlow.FlowId, uiParam, true);
			}
		}

		// Token: 0x0603A279 RID: 238201 RVA: 0x00EB960C File Offset: 0x00EB780C
		private void PlayCompositeAudio(string audioId, [Nullable(2)] PlayResult result = null)
		{
			Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId);
			if (audioPath == null)
			{
				return;
			}
			Singleton<AudioController>.Instance.PostEventByUi(audioPath.Value.Path, result, null, null);
		}

		// Token: 0x0603A27A RID: 238202 RVA: 0x00EB9653 File Offset: 0x00EB7853
		public void PlayLeaveCompositeAudio()
		{
			this.PlayCompositeAudio("play_ui_fx_spl_gen_page_close", null);
		}

		// Token: 0x0603A27B RID: 238203 RVA: 0x00EB9664 File Offset: 0x00EB7864
		[NullableContext(2)]
		public void PlayCompositeFailDisplay(Action onFinished = null)
		{
			this.ClearCompositeDisplay();
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			PlayFlow composeFailFlow = ModelBase<ComposeModel>.Instance.ComposeFailFlow;
			this.PlayCompositeFlow(composeFailFlow);
			Singleton<global::Log>.Instance.Info(ELogModule.Test, ELogAuthor.WZ, "[CompositeDisplay]播放合成失败表现", default(ReadOnlySpan<ValueTuple<string, object>>));
			int value = GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"];
			currentEntityTagComponent.AddTag(new int?(value));
			this.OnFailDisplayFinished = onFinished;
			this.CompositeDisplayTimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				if (this.OnFailDisplayFinished != null)
				{
					this.OnFailDisplayFinished();
				}
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603A27C RID: 238204 RVA: 0x00EB96FC File Offset: 0x00EB78FC
		public void ClearCompositeDisplay()
		{
			LevelTagComponent currentEntityTagComponent = this.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent != null)
			{
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.工作中"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.循环"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.进入"]));
				Singleton<global::Log>.Instance.Info(ELogModule.Test, ELogAuthor.WZ, "[CompositeDisplay]清理所有GameplayTag", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.OnEnterDisplayFinished = null;
			this.OnWorkingDisplayFinished = null;
			this.OnFailDisplayFinished = null;
			if (this.CompositeDisplayTimerId != null && TimerSystem.Instance.Has(this.CompositeDisplayTimerId))
			{
				TimerSystem.Instance.Remove(this.CompositeDisplayTimerId);
				this.CompositeDisplayTimerId = null;
			}
		}

		// Token: 0x0603A27D RID: 238205 RVA: 0x00EB97E8 File Offset: 0x00EB79E8
		[NullableContext(2)]
		private LevelTagComponent GetCurrentEntityTagComponent()
		{
			if (this.CurrentInteractionEntityId == null)
			{
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(this.CurrentInteractionEntityId.Value);
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<LevelTagComponent>();
		}

		// Token: 0x04020F86 RID: 135046
		private const string ENTER_AUDIO_ID = "play_ui_fx_spl_gen_page_open";

		// Token: 0x04020F87 RID: 135047
		private const string LEAVE_AUDIO_ID = "play_ui_fx_spl_gen_page_close";

		// Token: 0x04020F88 RID: 135048
		private const string SUCCESS_AUDIO_ID = "play_ui_fx_spl_gen_robot_success_vo";

		// Token: 0x04020F89 RID: 135049
		[Nullable(2)]
		private TimerHandle CompositeDisplayTimerId;

		// Token: 0x04020F8A RID: 135050
		[Nullable(2)]
		private Action OnEnterDisplayFinished;

		// Token: 0x04020F8B RID: 135051
		[Nullable(2)]
		private Action OnWorkingDisplayFinished;

		// Token: 0x04020F8C RID: 135052
		[Nullable(2)]
		private Action OnFailDisplayFinished;

		// Token: 0x04020F8D RID: 135053
		private int? CurrentInteractionEntityId;

		// Token: 0x04020F8E RID: 135054
		private bool SendRewardFlag;

		// Token: 0x0200B979 RID: 47481
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x040394B4 RID: 234676
			[Nullable(0)]
			public static Action<int> <0>__UpdateHelpRoleItemDataList;
		}
	}
}
