using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.NewWorld.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DF1 RID: 24049
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class CookController : UiControllerBase<CookController>
	{
		// Token: 0x0603C826 RID: 247846 RVA: 0x00F5DF48 File Offset: 0x00F5C148
		protected override bool OnInit()
		{
			this.CookCoinId = ConfigCommonParamById.GetIntConfig("CookCost").GetValueOrDefault(-1);
			return base.OnInit();
		}

		// Token: 0x0603C827 RID: 247847 RVA: 0x00F5DF74 File Offset: 0x00F5C174
		protected override bool OnClear()
		{
			this.ClearCookDisplay();
			return true;
		}

		// Token: 0x0603C828 RID: 247848 RVA: 0x00F5DF7D File Offset: 0x00F5C17D
		protected override bool OnLeaveLevel()
		{
			this.ClearCookDisplay();
			return true;
		}

		// Token: 0x0603C829 RID: 247849 RVA: 0x00F5DF88 File Offset: 0x00F5C188
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = CookController.<>O.<0>__UpdateCookRoleItemDataList) == null)
			{
				handle = (CookController.<>O.<0>__UpdateCookRoleItemDataList = new Action<int>(CookController.UpdateCookRoleItemDataList));
			}
			instance.Add<int>(name, handle);
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.ShowCookStudy));
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
		}

		// Token: 0x0603C82A RID: 247850 RVA: 0x00F5DFF8 File Offset: 0x00F5C1F8
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.ActiveRole;
			Action<int> handle;
			if ((handle = CookController.<>O.<0>__UpdateCookRoleItemDataList) == null)
			{
				handle = (CookController.<>O.<0>__UpdateCookRoleItemDataList = new Action<int>(CookController.UpdateCookRoleItemDataList));
			}
			instance.Remove(name, handle);
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new Action<int, int>(this.ShowCookStudy));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.LoadNewList));
		}

		// Token: 0x0603C82B RID: 247851 RVA: 0x00F5E068 File Offset: 0x00F5C268
		private static void UpdateCookRoleItemDataList(int i)
		{
			ModelBase<CookModel>.Instance.UpdateCookRoleItemDataList();
		}

		// Token: 0x0603C82C RID: 247852 RVA: 0x00F5E074 File Offset: 0x00F5C274
		private void ShowCookStudy(int configId, int count)
		{
			if (!ConfigBase<CSharpScript.Game.Module.Item.ItemConfig>.Instance.GetConfig(configId).Value.ShowTypes().Contains(24))
			{
				return;
			}
			CookFormula cookFormulaByFormulaItemId = ConfigBase<CookConfig>.Instance.GetCookFormulaByFormulaItemId(configId);
			string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaByFormulaItemId.Name);
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CookStudy", new object[]
			{
				localText
			});
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFormula);
		}

		// Token: 0x0603C82D RID: 247853 RVA: 0x00F5E0ED File Offset: 0x00F5C2ED
		private void LoadNewList()
		{
			ModelBase<CookModel>.Instance.CreateMachiningDataList();
		}

		// Token: 0x0603C82E RID: 247854 RVA: 0x00F5E0F9 File Offset: 0x00F5C2F9
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<CookingInfoUpdateNotify>(ENotifyMessageId.CookingInfoUpdateNotify, new Action<CookingInfoUpdateNotify, Net.CallbackStatus>(this.HandleCookingInfoUpdateNotify));
			Singleton<Net>.Instance.Register<CookingFormulaUpdateNotify>(ENotifyMessageId.CookingFormulaUpdateNotify, new Action<CookingFormulaUpdateNotify, Net.CallbackStatus>(this.HandleCookingFormulaUpdateNotify));
		}

		// Token: 0x0603C82F RID: 247855 RVA: 0x00F5E133 File Offset: 0x00F5C333
		[NullableContext(1)]
		private void HandleCookingInfoUpdateNotify(CookingInfoUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<CookModel>.Instance.UpdateCookerInfo(response.CookingInfo);
			Singleton<EventSystem>.Instance.Emit(EEventName.UpdateCookerInfo);
		}

		// Token: 0x0603C830 RID: 247856 RVA: 0x00F5E155 File Offset: 0x00F5C355
		[NullableContext(1)]
		private void HandleCookingFormulaUpdateNotify(CookingFormulaUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			ModelBase<CookModel>.Instance.UpdateCookingDataList(response.FoodFormulaInfos);
			ModelBase<CookModel>.Instance.UpdateMachiningDataList(response.ProcessedFoodFormulaInfos, true);
		}

		// Token: 0x0603C831 RID: 247857 RVA: 0x00F5E178 File Offset: 0x00F5C378
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CookingInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CookingFormulaUpdateNotify);
		}

		// Token: 0x0603C832 RID: 247858 RVA: 0x00F5E19A File Offset: 0x00F5C39A
		public bool CheckCanShowExpItem()
		{
			return ModelBase<CookModel>.Instance.GetCookerInfo().AddExp != 0;
		}

		// Token: 0x0603C833 RID: 247859 RVA: 0x00F5E1B0 File Offset: 0x00F5C3B0
		private void HandleCookingProtocolResponse(CookingDataResponse response)
		{
			ModelBase<CookModel>.Instance.CreateCookerInfo(response.CookingInfo);
			ModelBase<CookModel>.Instance.CreateCookingDataList(response.FoodFormulaInfos);
			ModelBase<CookModel>.Instance.UpdateCookingDataByServerConfig(response.FormulaConfigs);
			ModelBase<CookModel>.Instance.UpdateMachiningDataList(response.ProcessedFoodFormulaInfos, false);
			ModelBase<CookModel>.Instance.SaveLimitRefreshTime(response.LimitRefreshTime);
		}

		// Token: 0x0603C834 RID: 247860 RVA: 0x00F5E210 File Offset: 0x00F5C410
		[NullableContext(0)]
		public UniTask<bool> SendCookingDataRequestAsync()
		{
			CookController.<SendCookingDataRequestAsync>d__20 <SendCookingDataRequestAsync>d__;
			<SendCookingDataRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SendCookingDataRequestAsync>d__.<>4__this = this;
			<SendCookingDataRequestAsync>d__.<>1__state = -1;
			<SendCookingDataRequestAsync>d__.<>t__builder.Start<CookController.<SendCookingDataRequestAsync>d__20>(ref <SendCookingDataRequestAsync>d__);
			return <SendCookingDataRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C835 RID: 247861 RVA: 0x00F5E254 File Offset: 0x00F5C454
		public void SendCookFormulaRequest(int formulaId)
		{
			CookFormulaRequest cookFormulaRequest = CookFormulaRequest.Create();
			cookFormulaRequest.CookFormulaId = formulaId;
			Singleton<Net>.Instance.Call<CookFormulaResponse>(ERequestMessageId.CookFormulaRequest, cookFormulaRequest, new Action<CookFormulaResponse, Net.CallbackStatus>(this.HandleCookFormulaResponse), 0);
		}

		// Token: 0x0603C836 RID: 247862 RVA: 0x00F5E28C File Offset: 0x00F5C48C
		private void HandleCookFormulaResponse(CookFormulaResponse response, Net.CallbackStatus _)
		{
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				ModelBase<CookModel>.Instance.UnlockCookMenuData(response.CookFormulaId);
				CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(response.CookFormulaId);
				string localText = ConfigBase<CookConfig>.Instance.GetLocalText(cookFormulaById.Name);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("CookStudy", new object[]
				{
					localText
				});
				Singleton<EventSystem>.Instance.Emit(EEventName.UpdateFormula);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 26276, null, true, true);
		}

		// Token: 0x0603C837 RID: 247863 RVA: 0x00F5E318 File Offset: 0x00F5C518
		public void SendCookFoodRequest(int formulaId, int roleId, int cookCount)
		{
			CookFoodRequest cookFoodRequest = CookFoodRequest.Create();
			cookFoodRequest.Id = formulaId;
			cookFoodRequest.RoleId = roleId;
			cookFoodRequest.CookCount = cookCount;
			cookFoodRequest.InteractEntityId = ModelBase<CookModel>.Instance.CurrentInteractCreatureDataLongId.Value;
			Singleton<Net>.Instance.Call<CookFoodResponse>(ERequestMessageId.CookFoodRequest, cookFoodRequest, new Action<CookFoodResponse, Net.CallbackStatus>(this.HandleCookFoodResponse), 0);
		}

		// Token: 0x0603C838 RID: 247864 RVA: 0x00F5E374 File Offset: 0x00F5C574
		private void HandleCookFoodResponse(CookFoodResponse response, Net.CallbackStatus _)
		{
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				ICookingData cookingDataById = ModelBase<CookModel>.Instance.GetCookingDataById(response.Id);
				if (cookingDataById != null)
				{
					cookingDataById.LastRoleId = new int?(response.RoleId);
				}
				List<SingleItemInfo> list = new List<SingleItemInfo>();
				if (response.ItemInfos != null)
				{
					foreach (SingleItemInfo item in response.ItemInfos)
					{
						list.Add(item);
					}
				}
				if (response.ExtraItemInfos != null && response.ExtraItemInfos.Count != 0)
				{
					foreach (SingleItemInfo item2 in response.ExtraItemInfos)
					{
						list.Add(item2);
					}
				}
				ModelBase<CookModel>.Instance.UpdateCookItemList(list);
				this.SetCompositeRewardView(response);
				this.PlayCookSuccessDisplay(delegate
				{
					ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2001, true, null, null);
				});
				Singleton<EventSystem>.Instance.Emit(EEventName.CookSuccess);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 20879, null, true, true);
			Singleton<EventSystem>.Instance.Emit(EEventName.CookFail);
		}

		// Token: 0x0603C839 RID: 247865 RVA: 0x00F5E4C4 File Offset: 0x00F5C6C4
		[NullableContext(1)]
		private void SetCompositeRewardView(CookFoodResponse response)
		{
			CookModel instance = ModelBase<CookModel>.Instance;
			ICookerInfoData cookerInfo = instance.GetCookerInfo();
			int cookingLevel = cookerInfo.CookingLevel;
			int cookerMaxLevel = instance.GetCookerMaxLevel();
			CookLevel cookLevelByLevel = instance.GetCookLevelByLevel(cookerMaxLevel);
			int totalProficiencys = cookerInfo.TotalProficiencys;
			int completeness = cookLevelByLevel.Completeness;
			int lastExp = instance.LastExp;
			List<IRewardProgress> progressQueue = null;
			if (lastExp != totalProficiencys && (lastExp < completeness || (cookingLevel < cookerMaxLevel && totalProficiencys < completeness)))
			{
				CookLevel cookLevelByLevel2 = instance.GetCookLevelByLevel(Math.Min(cookerMaxLevel, cookingLevel + 1));
				RewardProgress item = new RewardProgress
				{
					FromProgress = lastExp,
					ToProgress = totalProficiencys,
					MaxProgress = cookLevelByLevel2.Completeness
				};
				progressQueue = new List<IRewardProgress>
				{
					item
				};
			}
			instance.LastExp = totalProficiencys;
			List<RewardItemData> list = new List<RewardItemData>();
			if (response.ItemInfos != null)
			{
				foreach (SingleItemInfo singleItemInfo in response.ItemInfos)
				{
					RewardItemData item2 = new RewardItemData(singleItemInfo.ItemId, singleItemInfo.ItemNum, null, EDropItemType.Normal);
					list.Add(item2);
				}
			}
			if (response.ExtraItemInfos != null)
			{
				foreach (SingleItemInfo singleItemInfo2 in response.ExtraItemInfos)
				{
					RewardItemData item3 = new RewardItemData(singleItemInfo2.ItemId, singleItemInfo2.ItemNum, null, EDropItemType.Normal);
					list.Add(item3);
				}
			}
			ControllerBase<ItemRewardController>.Instance.SetItemList(list);
			ControllerBase<ItemRewardController>.Instance.SetProgressQueue(progressQueue);
		}

		// Token: 0x0603C83A RID: 247866 RVA: 0x00F5E670 File Offset: 0x00F5C870
		[NullableContext(1)]
		private List<ISingleItemInfo> PrimaryFoodFilter(List<ISingleItemInfo> primaryFoodList)
		{
			List<ISingleItemInfo> list = new List<ISingleItemInfo>();
			foreach (ISingleItemInfo singleItemInfo in primaryFoodList)
			{
				if (singleItemInfo.Proto_IsUnlock)
				{
					list.Add(singleItemInfo);
				}
			}
			return list;
		}

		// Token: 0x0603C83B RID: 247867 RVA: 0x00F5E6D0 File Offset: 0x00F5C8D0
		[NullableContext(1)]
		public void SendFoodProcessRequest(int formulaId, List<ISingleItemInfo> primaryFoodList, int cookCount)
		{
			FoodProcessRequest foodProcessRequest = FoodProcessRequest.Create();
			foodProcessRequest.Id = formulaId;
			foreach (ISingleItemInfo singleItemInfo in this.PrimaryFoodFilter(primaryFoodList))
			{
				SingleItemInfo singleItemInfo2 = SingleItemInfo.Create();
				singleItemInfo2.ItemId = singleItemInfo.Proto_ItemId;
				singleItemInfo2.ItemNum = singleItemInfo.Proto_ItemNum;
				foodProcessRequest.PrimaryFood.Add(singleItemInfo2);
			}
			foodProcessRequest.CookCount = cookCount;
			foodProcessRequest.InteractEntityId = ModelBase<CookModel>.Instance.CurrentInteractCreatureDataLongId.Value;
			Singleton<Net>.Instance.Call<FoodProcessResponse>(ERequestMessageId.FoodProcessRequest, foodProcessRequest, new Action<FoodProcessResponse, Net.CallbackStatus>(this.HandleFoodProcessResponse), 0);
		}

		// Token: 0x0603C83C RID: 247868 RVA: 0x00F5E790 File Offset: 0x00F5C990
		private void HandleFoodProcessResponse(FoodProcessResponse response, Net.CallbackStatus _)
		{
			if (response.Code != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 17202, null, true, true);
				return;
			}
			IMachiningData machiningDataById = ModelBase<CookModel>.Instance.GetMachiningDataById(response.Id);
			bool lockState = response.LockState;
			if (machiningDataById != null)
			{
				machiningDataById.IsUnLock = lockState;
				if (response.UnlockParam != null && response.UnlockParam.Count != 0)
				{
					machiningDataById.UnlockList.Clear();
					foreach (int item in response.UnlockParam)
					{
						machiningDataById.UnlockList.Add(item);
					}
				}
			}
			ModelBase<CookModel>.Instance.UpdateCookItemList(response.FinalFood);
			if (lockState)
			{
				this.PlayCookSuccessDisplay(delegate
				{
					ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2002, true, null, null);
				});
			}
			else
			{
				this.PlayCookFailDisplay(delegate
				{
					ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2005, false, null, null);
				});
			}
			if (response.LockState)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.MachiningSuccess);
				return;
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.MachiningStudyFail);
		}

		// Token: 0x0603C83D RID: 247869 RVA: 0x00F5E8D0 File Offset: 0x00F5CAD0
		public void SendCertificateLevelRewardRequest()
		{
			CertificateLevelRewardRequest message = CertificateLevelRewardRequest.Create();
			Singleton<Net>.Instance.Call<CertificateLevelRewardResponse>(ERequestMessageId.CertificateLevelRewardRequest, message, new Action<CertificateLevelRewardResponse, Net.CallbackStatus>(this.HandleCertificateLevelRewardResponse), 0);
		}

		// Token: 0x0603C83E RID: 247870 RVA: 0x00F5E900 File Offset: 0x00F5CB00
		private void HandleCertificateLevelRewardResponse(CertificateLevelRewardResponse response, Net.CallbackStatus _)
		{
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.UpgradeCookerLevel);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 17653, null, true, true);
		}

		// Token: 0x0603C83F RID: 247871 RVA: 0x00F5E934 File Offset: 0x00F5CB34
		public void SendFixToolRequest(int fixId, long entityId)
		{
			FixToolRequest fixToolRequest = FixToolRequest.Create();
			fixToolRequest.FixTool = fixId;
			fixToolRequest.EntityId = entityId;
			Singleton<Net>.Instance.Call<FixToolResponse>(ERequestMessageId.FixToolRequest, fixToolRequest, delegate(FixToolResponse response, Net.CallbackStatus _)
			{
				this.HandleFixToolResponse(response, _, fixId);
			}, 0);
		}

		// Token: 0x0603C840 RID: 247872 RVA: 0x00F5E98C File Offset: 0x00F5CB8C
		private void HandleFixToolResponse(FixToolResponse response, Net.CallbackStatus _, int fixId)
		{
			if (response.Code == Aki.Protocol.ErrorCode.Success)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "请求修复厨具成功";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("修复Id", fixId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<EventSystem>.Instance.Emit(EEventName.FixSuccess);
				return;
			}
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Code, 25245, null, true, true);
		}

		// Token: 0x0603C841 RID: 247873 RVA: 0x00F5E9F9 File Offset: 0x00F5CBF9
		public void SetCurrentFixId(int fixId)
		{
			ModelBase<CookModel>.Instance.CurrentFixId = fixId;
		}

		// Token: 0x0603C842 RID: 247874 RVA: 0x00F5EA06 File Offset: 0x00F5CC06
		public int GetCurrentFixId()
		{
			return ModelBase<CookModel>.Instance.CurrentFixId;
		}

		// Token: 0x0603C843 RID: 247875 RVA: 0x00F5EA12 File Offset: 0x00F5CC12
		public void SetCurrentEntityId(long entityId)
		{
			ModelBase<CookModel>.Instance.CurrentEntityId = new long?(entityId);
		}

		// Token: 0x0603C844 RID: 247876 RVA: 0x00F5EA24 File Offset: 0x00F5CC24
		public long? GetCurrentEntityId()
		{
			return ModelBase<CookModel>.Instance.CurrentEntityId;
		}

		// Token: 0x0603C845 RID: 247877 RVA: 0x00F5EA30 File Offset: 0x00F5CC30
		public bool CheckCanCook(int itemId)
		{
			return ModelBase<CookModel>.Instance.CheckCanCook(itemId);
		}

		// Token: 0x0603C846 RID: 247878 RVA: 0x00F5EA40 File Offset: 0x00F5CC40
		public bool CheckCanProcessed(int itemId)
		{
			CookProcessed cookProcessedById = ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId);
			int num = cookProcessedById.ConsumeItemsId().Length;
			for (int i = 0; i < num; i++)
			{
				OneItemConfig oneItemConfig = cookProcessedById.ConsumeItemsId()[i];
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0);
				if (oneItemConfig.Count > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C847 RID: 247879 RVA: 0x00F5EAA0 File Offset: 0x00F5CCA0
		public bool CheckCanAdd(int sum, int itemId, ECookListType type)
		{
			if (type != ECookListType.Cooking)
			{
				return type == ECookListType.Machining && this.DoCheckCanAdd(sum, ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId).ConsumeItemsId());
			}
			return this.DoCheckCanAdd(sum, ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId).ConsumeItems());
		}

		// Token: 0x0603C848 RID: 247880 RVA: 0x00F5EAF0 File Offset: 0x00F5CCF0
		[NullableContext(1)]
		private bool DoCheckCanAdd(int sum, OneItemConfig[] itemMap)
		{
			int num = itemMap.Length;
			for (int i = 0; i < num; i++)
			{
				OneItemConfig oneItemConfig = itemMap[i];
				int num2 = sum * oneItemConfig.Count;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0);
				if (num2 > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C849 RID: 247881 RVA: 0x00F5EB38 File Offset: 0x00F5CD38
		public int GetMaxCreateCount(int itemId, ECookListType type)
		{
			if (type == ECookListType.Cooking)
			{
				return this.DoGetMaxCreateCount(ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId).ConsumeItems());
			}
			if (type != ECookListType.Machining)
			{
				return 0;
			}
			return this.DoGetMaxCreateCount(ConfigBase<CookConfig>.Instance.GetCookProcessedById(itemId).ConsumeItemsId());
		}

		// Token: 0x0603C84A RID: 247882 RVA: 0x00F5EB84 File Offset: 0x00F5CD84
		[NullableContext(1)]
		private int DoGetMaxCreateCount(OneItemConfig[] itemMap)
		{
			int num = ConfigCommonParamById.GetIntConfig("max_cooking_count").Value;
			int num2 = itemMap.Length;
			for (int i = 0; i < num2; i++)
			{
				OneItemConfig oneItemConfig = itemMap[i];
				int count = oneItemConfig.Count;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(oneItemConfig.ItemId, 0);
				if (count > itemCountByConfigId)
				{
					return 0;
				}
				double num3 = (double)Singleton<MathUtils>.Instance.GetFloatPointFloor((float)(itemCountByConfigId / count), 0);
				num = (((double)num < num3) ? num : ((int)num3));
			}
			return num;
		}

		// Token: 0x0603C84B RID: 247883 RVA: 0x00F5EC04 File Offset: 0x00F5CE04
		public bool CheckIsBuff(int roleId, int itemId)
		{
			CookFormula cookFormulaById = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId);
			int num = cookFormulaById.RoleList().Length;
			for (int i = 0; i < num; i++)
			{
				if (cookFormulaById.RoleList()[i] == roleId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C84C RID: 247884 RVA: 0x00F5EC44 File Offset: 0x00F5CE44
		public bool CheckIsBuffEx(int roleId, int itemId)
		{
			int[] array = ConfigBase<CookConfig>.Instance.GetCookFormulaById(itemId).RoleList();
			int num = array.Length;
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				if (array[i] == roleId)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return false;
			}
			foreach (int num2 in ModelBase<RoleModel>.Instance.GetRoleIdList())
			{
				for (int j = 0; j < num; j++)
				{
					if (array[j] == num2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C84D RID: 247885 RVA: 0x00F5ECF4 File Offset: 0x00F5CEF4
		[NullableContext(1)]
		public string GetCookInfoText(int roleId)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
			IReadOnlyList<Aki.Config.Skill> skillList = ConfigBase<RoleSkillConfig>.Instance.GetSkillList(roleConfig.Value.SkillId);
			string result = "";
			if (skillList != null)
			{
				foreach (Aki.Config.Skill skill in skillList)
				{
					if (skill.LeftSkillEffect != 0)
					{
						result = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(skill.SkillDescribe, null), skill.SkillDetailNum());
					}
				}
			}
			return result;
		}

		// Token: 0x0603C84E RID: 247886 RVA: 0x00F5ED90 File Offset: 0x00F5CF90
		public bool CheckCanFix()
		{
			foreach (KeyValuePair<int, int> keyValuePair in ConfigBase<CookConfig>.Instance.GetCookFixToolById(this.GetCurrentFixId()).Items())
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0);
				if (value > itemCountByConfigId)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C84F RID: 247887 RVA: 0x00F5EE18 File Offset: 0x00F5D018
		[NullableContext(1)]
		public List<CommonItemData> GetCookItemSelectedList(int itemId)
		{
			List<CommonItemData> commonItemByShowType = ModelBase<InventoryModel>.Instance.GetCommonItemByShowType(InventoryDefine.EShowType.CookMaterial);
			IMachiningData machiningDataById = ModelBase<CookModel>.Instance.GetMachiningDataById(itemId);
			List<CommonItemData> list = new List<CommonItemData>();
			foreach (CommonItemData commonItemData in commonItemByShowType)
			{
				if (!machiningDataById.UnlockList.Contains(commonItemData.GetConfigId()))
				{
					list.Add(commonItemData);
				}
			}
			return list;
		}

		// Token: 0x0603C850 RID: 247888 RVA: 0x00F5EE98 File Offset: 0x00F5D098
		public bool CheckTmpListHasLock()
		{
			foreach (ISingleItemInfo singleItemInfo in ModelBase<CookModel>.Instance.GetTmpMachiningItemList())
			{
				if (!singleItemInfo.Proto_IsUnlock)
				{
					return true;
				}
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(singleItemInfo.Proto_ItemId, 0);
				if (singleItemInfo.Proto_ItemNum > itemCountByConfigId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C851 RID: 247889 RVA: 0x00F5EF18 File Offset: 0x00F5D118
		public bool CheckIsUnlock(int machiningId, int itemId)
		{
			return ModelBase<CookModel>.Instance.GetMachiningDataById(machiningId).UnlockList.Contains(itemId);
		}

		// Token: 0x0603C852 RID: 247890 RVA: 0x00F5EF30 File Offset: 0x00F5D130
		public bool CheckCanGetCookerLevel()
		{
			ICookerInfoData cookerInfo = ModelBase<CookModel>.Instance.GetCookerInfo();
			if (cookerInfo.CookingLevel != ModelBase<CookModel>.Instance.GetCookerMaxLevel())
			{
				int sumExpByLevel = ModelBase<CookModel>.Instance.GetSumExpByLevel(cookerInfo.CookingLevel);
				if (cookerInfo.TotalProficiencys >= sumExpByLevel)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C853 RID: 247891 RVA: 0x00F5EF78 File Offset: 0x00F5D178
		[NullableContext(0)]
		public UniTask<bool> ShowFixCookView()
		{
			CookController.<ShowFixCookView>d__51 <ShowFixCookView>d__;
			<ShowFixCookView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ShowFixCookView>d__.<>4__this = this;
			<ShowFixCookView>d__.<>1__state = -1;
			<ShowFixCookView>d__.<>t__builder.Start<CookController.<ShowFixCookView>d__51>(ref <ShowFixCookView>d__);
			return <ShowFixCookView>d__.<>t__builder.Task;
		}

		// Token: 0x0603C854 RID: 247892 RVA: 0x00F5EFBC File Offset: 0x00F5D1BC
		public void PlayCookSuccessDisplay(Action onFinished = null)
		{
			this.ClearCookDisplay();
			LevelTagComponent currentEntityTagComponent = CookController.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				if (onFinished != null)
				{
					onFinished();
				}
				return;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CookRootView);
			if (viewByName != null)
			{
				Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(new UiViewInfoForTimeDilation
				{
					ViewId = viewByName.GetViewId(),
					TimeDilation = 1f,
					DebugName = new EUiViewName?(EUiViewName.CookRootView),
					Reason = "Cook"
				});
			}
			this.IsPlayingSuccessDisplay = true;
			this.OnCookSuccessFinished = onFinished;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBeginPlayCookSuccessDisplay);
			currentEntityTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.成功"]));
			this.CookDisplayTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayCookSuccessDisplayFinished);
				UiViewBase viewByName2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CookRootView);
				if (viewByName2 != null)
				{
					Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(new UiViewInfoForTimeDilation
					{
						ViewId = viewByName2.GetViewId(),
						TimeDilation = viewByName2.ViewInfo.TimeDilation,
						DebugName = new EUiViewName?(EUiViewName.CookRootView),
						Reason = "Cook"
					});
				}
				this.IsPlayingSuccessDisplay = false;
				if (this.OnCookSuccessFinished != null)
				{
					this.OnCookSuccessFinished();
				}
			}, 300f, null, null, true, 1f);
		}

		// Token: 0x0603C855 RID: 247893 RVA: 0x00F5F098 File Offset: 0x00F5D298
		public void SkipCookSuccessDisplay()
		{
			if (!this.IsPlayingSuccessDisplay)
			{
				return;
			}
			if (this.OnCookSuccessFinished != null)
			{
				this.OnCookSuccessFinished();
			}
			this.OnCookSuccessFinished = null;
		}

		// Token: 0x0603C856 RID: 247894 RVA: 0x00F5F0C0 File Offset: 0x00F5D2C0
		public void PlayCookFailDisplay(Action onFinished = null)
		{
			this.ClearCookDisplay();
			LevelTagComponent currentEntityTagComponent = CookController.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent == null)
			{
				return;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CookRootView);
			if (viewByName != null)
			{
				Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(new UiViewInfoForTimeDilation
				{
					ViewId = viewByName.GetViewId(),
					TimeDilation = 1f,
					DebugName = new EUiViewName?(EUiViewName.CookRootView),
					Reason = "Cook"
				});
			}
			this.IsPlayingFailDisplay = true;
			this.OnCookFailFinished = onFinished;
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBeginPlayCookFailDisplay);
			currentEntityTagComponent.AddTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"]));
			this.CookDisplayTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPlayCookFailDisplayFinished);
				UiViewBase viewByName2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CookRootView);
				if (viewByName2 != null)
				{
					Singleton<UiTimeDilation>.Instance.SetGameTimeDilation(new UiViewInfoForTimeDilation
					{
						ViewId = viewByName2.GetViewId(),
						TimeDilation = viewByName2.ViewInfo.TimeDilation,
						DebugName = new EUiViewName?(EUiViewName.CookRootView),
						Reason = "Cook"
					});
				}
				this.IsPlayingFailDisplay = false;
				if (this.OnCookFailFinished != null)
				{
					this.OnCookFailFinished();
				}
			}, 300f, null, null, true, 1f);
		}

		// Token: 0x0603C857 RID: 247895 RVA: 0x00F5F193 File Offset: 0x00F5D393
		public void SkipCookFailDisplay()
		{
			if (!this.IsPlayingFailDisplay)
			{
				return;
			}
			if (this.OnCookFailFinished != null)
			{
				this.OnCookFailFinished();
			}
			this.OnCookFailFinished = null;
		}

		// Token: 0x0603C858 RID: 247896 RVA: 0x00F5F1B8 File Offset: 0x00F5D3B8
		public void ClearCookDisplay()
		{
			LevelTagComponent currentEntityTagComponent = CookController.GetCurrentEntityTagComponent();
			if (currentEntityTagComponent != null)
			{
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.成功"]));
				currentEntityTagComponent.RemoveTag(new int?(GameplayTagDefine.EGameplayTagId["关卡.场景交互物.失败"]));
			}
			if (this.CookDisplayTimerId != null && TimerSystem.GameplayTimeInstance.Has(this.CookDisplayTimerId))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.CookDisplayTimerId);
				this.CookDisplayTimerId = null;
			}
			this.IsPlayingSuccessDisplay = false;
			this.IsPlayingFailDisplay = false;
			this.OnCookSuccessFinished = null;
			this.OnCookFailFinished = null;
		}

		// Token: 0x0603C859 RID: 247897 RVA: 0x00F5F254 File Offset: 0x00F5D454
		private static LevelTagComponent GetCurrentEntityTagComponent()
		{
			int valueOrDefault = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId.GetValueOrDefault();
			if (valueOrDefault == 0)
			{
				return null;
			}
			Entity entity = Singleton<EntitySystem>.Instance.Get(valueOrDefault);
			if (entity == null)
			{
				return null;
			}
			return entity.GetComponent<LevelTagComponent>();
		}

		// Token: 0x0603C85A RID: 247898 RVA: 0x00F5F290 File Offset: 0x00F5D490
		[NullableContext(1)]
		public void TryRequestChangeEntityStateByEvent(ECookMechanismState @event, UiViewBase view)
		{
			if (!CookDefine.CookEntityCanChangeArray.Contains(view.ViewInfo.Name))
			{
				return;
			}
			int valueOrDefault = ModelBase<InteractionModel>.Instance.CurrentInteractEntityId.GetValueOrDefault();
			if (valueOrDefault == 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.Cook, ELogAuthor.WZ, "当前无法获取交互实体的id", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			long creatureDataId = ModelBase<CreatureModel>.Instance.GetCreatureDataId(valueOrDefault);
			if (creatureDataId == 0L)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "当前交互实体无法获取服务端实体uid";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("client entity uid", valueOrDefault);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			LevelGeneralNetworks.RequestEntitySendEvent(creatureDataId, @event.ToString());
		}

		// Token: 0x04022063 RID: 139363
		public int CookCoinId;

		// Token: 0x04022064 RID: 139364
		private TimerHandle CookDisplayTimerId;

		// Token: 0x04022065 RID: 139365
		public bool IsPlayingSuccessDisplay;

		// Token: 0x04022066 RID: 139366
		public bool IsPlayingFailDisplay;

		// Token: 0x04022067 RID: 139367
		private Action OnCookSuccessFinished;

		// Token: 0x04022068 RID: 139368
		private Action OnCookFailFinished;

		// Token: 0x0200BE3D RID: 48701
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403A912 RID: 239890
			[Nullable(0)]
			public static Action<int> <0>__UpdateCookRoleItemDataList;
		}
	}
}
