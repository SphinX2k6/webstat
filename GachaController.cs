using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CDD RID: 7389
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class GachaController : UiControllerBase<GachaController>
{
	// Token: 0x0600D8CB RID: 55499 RVA: 0x003A0A36 File Offset: 0x0039EC36
	protected override bool OnInit()
	{
		this.GachaRoleRecord = new HashSet<int>();
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.GachaMainView, new Action(this.OpenView));
		return true;
	}

	// Token: 0x0600D8CC RID: 55500 RVA: 0x003A0A5F File Offset: 0x0039EC5F
	private void OpenView()
	{
		this.OpenGachaMainView(true);
	}

	// Token: 0x0600D8CD RID: 55501 RVA: 0x003A0A68 File Offset: 0x0039EC68
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenDataUpdate));
		Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenDataUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(this.RefreshGachaMainView));
		Singleton<EventSystem>.Instance.Add(EEventName.AfterCloseGachaScene, new Action(this.OnAfterCloseGachaScent));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
	}

	// Token: 0x0600D8CE RID: 55502 RVA: 0x003A0B04 File Offset: 0x0039ED04
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenSet, new Action<EFunctionType, bool>(this.OnFunctionOpenDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenDataUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(this.RefreshGachaMainView));
		Singleton<EventSystem>.Instance.Remove(EEventName.AfterCloseGachaScene, new Action(this.OnAfterCloseGachaScent));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
	}

	// Token: 0x0600D8CF RID: 55503 RVA: 0x003A0BA0 File Offset: 0x0039EDA0
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<GachaResultNotify>(ENotifyMessageId.GachaResultNotify, new Action<GachaResultNotify, Net.CallbackStatus>(this.OnGachaResultNotify));
		Singleton<Net>.Instance.Register<GachaNewNotify>(ENotifyMessageId.GachaNewNotify, new Action<GachaNewNotify, Net.CallbackStatus>(this.OnGachaNewNotify));
		Singleton<Net>.Instance.Register<GachaDiscountNotify>(ENotifyMessageId.GachaDiscountNotify, new Action<GachaDiscountNotify, Net.CallbackStatus>(this.OnGachaDiscountNotify));
	}

	// Token: 0x0600D8D0 RID: 55504 RVA: 0x003A0C01 File Offset: 0x0039EE01
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GachaResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GachaNewNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.GachaDiscountNotify);
	}

	// Token: 0x0600D8D1 RID: 55505 RVA: 0x003A0C33 File Offset: 0x0039EE33
	private void OnWorldDone()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10009))
		{
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
		{
			this.GachaInfoRequest(false, false);
		}
	}

	// Token: 0x0600D8D2 RID: 55506 RVA: 0x003A0C60 File Offset: 0x0039EE60
	private void OnGachaNewNotify(GachaNewNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10009))
		{
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DrawMainView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaScanView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaResultView))
		{
			ModelBase<GachaModel>.Instance.IsCacheShowNewNotify = true;
			return;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
		{
			this.GachaInfoRequest(false, false);
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.GachaNewNotify);
	}

	// Token: 0x0600D8D3 RID: 55507 RVA: 0x003A0CE8 File Offset: 0x0039EEE8
	private void OnGachaResultNotify(GachaResultNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		List<global::GachaResult> list = new List<global::GachaResult>();
		foreach (Aki.Protocol.GachaResult gachaResult in message.GachaResults)
		{
			list.Add(new global::GachaResult
			{
				Proto_GachaReward = gachaResult.GachaReward,
				Proto_BottomExtraReward = gachaResult.BottomExtraReward,
				Proto_TransformRewards = gachaResult.TransformRewards.ToArray<GachaReward>(),
				Proto_ExtraRewards = gachaResult.ExtraRewards.ToArray<GachaReward>()
			});
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DrawMainView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaScanView))
		{
			IGachaViewOpenData resultViewData = new GachaViewOpenData
			{
				SkipOnLoadResourceFinish = false,
				ResultViewHideExtraReward = false,
				IsOnlyShowGold = false
			};
			ModelBase<GachaModel>.Instance.CacheGachaInfo(new CommonShowRoleInfo
			{
				ResultViewData = resultViewData,
				GachaResult = list.ToArray()
			});
			return;
		}
		ModelBase<GachaModel>.Instance.CurGachaResult = list.ToArray();
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DrawMainView, null, null);
	}

	// Token: 0x0600D8D4 RID: 55508 RVA: 0x003A0E00 File Offset: 0x0039F000
	private void OnGachaDiscountNotify(GachaDiscountNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(message.GachaId);
		if (gachaInfo == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Gacha;
			ELogAuthor author = ELogAuthor.LPH;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 1);
			defaultInterpolatedStringHandler.AppendLiteral("OnGachaDiscountNotify: GachaInfo not found, gachaId=");
			defaultInterpolatedStringHandler.AppendFormatted<int>(message.GachaId);
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		GachaDiscountInfo[] array = message.GachaDiscountInfos.ToArray<GachaDiscountInfo>();
		List<GachaDiscountInfo> list = gachaInfo.GachaDiscountInfos.ToList<GachaDiscountInfo>();
		GachaDiscountInfo[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			GachaDiscountInfo next = array2[i];
			GachaDiscountInfo gachaDiscountInfo = list.Find((GachaDiscountInfo discount) => discount.Times == next.Times);
			if (gachaDiscountInfo != null)
			{
				gachaDiscountInfo.UsedTimes = next.UsedTimes;
				gachaDiscountInfo.LimitTimes = next.LimitTimes;
				gachaDiscountInfo.DiscountConsume = next.DiscountConsume;
			}
			else
			{
				list.Add(next);
			}
		}
		gachaInfo.GachaDiscountInfos = list.ToArray();
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshGachaMainView);
	}

	// Token: 0x0600D8D5 RID: 55509 RVA: 0x003A0F25 File Offset: 0x0039F125
	private void OnFunctionOpenDataUpdate(EFunctionType functionType, bool isOpen)
	{
		if (functionType == EFunctionType.Gacha && isOpen)
		{
			ModelBase<GachaModel>.Instance.InitGachaPoolOpenRecord();
			this.GachaInfoRequest(false, false);
		}
	}

	// Token: 0x0600D8D6 RID: 55510 RVA: 0x003A0F45 File Offset: 0x0039F145
	private void RefreshGachaMainView()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
		{
			return;
		}
		this.GachaInfoRequest(false, false);
	}

	// Token: 0x0600D8D7 RID: 55511 RVA: 0x003A0F61 File Offset: 0x0039F161
	public bool CanCloseView()
	{
		if (!ModelBase<GachaModel>.Instance.CanCloseView)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseGachaSceneView);
			return false;
		}
		return true;
	}

	// Token: 0x0600D8D8 RID: 55512 RVA: 0x003A0F82 File Offset: 0x0039F182
	public void GachaHistoryRequest(int gachaId)
	{
	}

	// Token: 0x0600D8D9 RID: 55513 RVA: 0x003A0F84 File Offset: 0x0039F184
	public bool IsNewRole(int roleId)
	{
		bool flag = !this.GachaRoleRecord.Contains(roleId);
		if (flag)
		{
			this.GachaRoleRecord.Add(roleId);
		}
		return flag;
	}

	// Token: 0x0600D8DA RID: 55514 RVA: 0x003A0FA8 File Offset: 0x0039F1A8
	public UniTask GachaRequest(int gachaId, int gachaTimes, int poolId)
	{
		GachaController.<GachaRequest>d__18 <GachaRequest>d__;
		<GachaRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GachaRequest>d__.<>4__this = this;
		<GachaRequest>d__.gachaId = gachaId;
		<GachaRequest>d__.gachaTimes = gachaTimes;
		<GachaRequest>d__.poolId = poolId;
		<GachaRequest>d__.<>1__state = -1;
		<GachaRequest>d__.<>t__builder.Start<GachaController.<GachaRequest>d__18>(ref <GachaRequest>d__);
		return <GachaRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8DB RID: 55515 RVA: 0x003A1003 File Offset: 0x0039F203
	public void OpenGachaMainView(bool isFunctionViewOpen = false)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10009))
		{
			return;
		}
		this.GachaInfoRequest(true, isFunctionViewOpen);
	}

	// Token: 0x0600D8DC RID: 55516 RVA: 0x003A1020 File Offset: 0x0039F220
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<GachaPoolDetailResponse> GachaPoolDetailRequestAsync(int poolId)
	{
		GachaController.<GachaPoolDetailRequestAsync>d__20 <GachaPoolDetailRequestAsync>d__;
		<GachaPoolDetailRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<GachaPoolDetailResponse>.Create();
		<GachaPoolDetailRequestAsync>d__.poolId = poolId;
		<GachaPoolDetailRequestAsync>d__.<>1__state = -1;
		<GachaPoolDetailRequestAsync>d__.<>t__builder.Start<GachaController.<GachaPoolDetailRequestAsync>d__20>(ref <GachaPoolDetailRequestAsync>d__);
		return <GachaPoolDetailRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8DD RID: 55517 RVA: 0x003A1064 File Offset: 0x0039F264
	public void GachaInfoRequest(bool openView, bool isFunctionViewOpen = false)
	{
		double num = Singleton<TimeUtil>.Instance.GetServerTime() - this.LastGetInfoTime;
		this.LastGetInfoTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (num < 1.0)
		{
			if (openView && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, null, null);
			}
			return;
		}
		GachaInfoRequest message = Aki.Protocol.GachaInfoRequest.Create();
		Singleton<Net>.Instance.Call<GachaInfoResponse>(ERequestMessageId.GachaInfoRequest, message, delegate(GachaInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.ZJC, "请求抽奖数据失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15380, null, true, true);
				return;
			}
			if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				Singleton<Log>.Instance.Info(ELogModule.Gacha, ELogAuthor.LPH, "[GachaController.GachaInfoRequest] 在Loading中,打开抽卡界面取消", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			ModelBase<GachaModel>.Instance.InitGachaInfoMap(response.GachaInfos.ToArray<GachaInfo>());
			ModelBase<GachaModel>.Instance.TodayResultCount = response.DailyTotalLeftTimes;
			ModelBase<GachaModel>.Instance.RecordId = response.RecordId;
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshGachaMainView);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnOpenGachaChanged);
			if (openView && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, null, null);
			}
		}, 0);
	}

	// Token: 0x0600D8DE RID: 55518 RVA: 0x003A10F8 File Offset: 0x0039F2F8
	public UniTask GachaInfoRequestAsync()
	{
		GachaController.<GachaInfoRequestAsync>d__22 <GachaInfoRequestAsync>d__;
		<GachaInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GachaInfoRequestAsync>d__.<>4__this = this;
		<GachaInfoRequestAsync>d__.<>1__state = -1;
		<GachaInfoRequestAsync>d__.<>t__builder.Start<GachaController.<GachaInfoRequestAsync>d__22>(ref <GachaInfoRequestAsync>d__);
		return <GachaInfoRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D8DF RID: 55519 RVA: 0x003A113C File Offset: 0x0039F33C
	[NullableContext(2)]
	public void TryGachaInfoRequest(Action<bool> callback = null)
	{
		double num = Singleton<TimeUtil>.Instance.GetServerTime() - this.LastGetInfoTime;
		this.LastGetInfoTime = Singleton<TimeUtil>.Instance.GetServerTime();
		if (num < 1.0)
		{
			Action<bool> callback2 = callback;
			if (callback2 != null)
			{
				callback2(true);
			}
		}
		GachaInfoRequest message = Aki.Protocol.GachaInfoRequest.Create();
		Singleton<Net>.Instance.Call<GachaInfoResponse>(ERequestMessageId.GachaInfoRequest, message, delegate(GachaInfoResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.ZJC, "请求抽奖数据失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(false);
				return;
			}
			else if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15380, null, true, true);
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(false);
				return;
			}
			else if (ModelBase<LoadingModel>.Instance.IsLoading)
			{
				Singleton<Log>.Instance.Info(ELogModule.Gacha, ELogAuthor.LPH, "[GachaController.GachaInfoRequest] 在Loading中,打开抽卡界面取消", default(ReadOnlySpan<ValueTuple<string, object>>));
				Action<bool> callback5 = callback;
				if (callback5 == null)
				{
					return;
				}
				callback5(false);
				return;
			}
			else
			{
				ModelBase<GachaModel>.Instance.InitGachaInfoMap(response.GachaInfos.ToArray<GachaInfo>());
				ModelBase<GachaModel>.Instance.TodayResultCount = response.DailyTotalLeftTimes;
				ModelBase<GachaModel>.Instance.RecordId = response.RecordId;
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshGachaMainView);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnOpenGachaChanged);
				Action<bool> callback6 = callback;
				if (callback6 == null)
				{
					return;
				}
				callback6(true);
				return;
			}
		}, 0);
	}

	// Token: 0x0600D8E0 RID: 55520 RVA: 0x003A11B8 File Offset: 0x0039F3B8
	public void OpenGachaView(int openData = 0)
	{
		this.TryGachaInfoRequest(delegate(bool isSuccess)
		{
			if (isSuccess && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaMainView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaMainView, openData, null);
			}
		});
	}

	// Token: 0x0600D8E1 RID: 55521 RVA: 0x003A11E4 File Offset: 0x0039F3E4
	public void GachaUsePoolRequest(int gachaId, int poolId)
	{
		GachaUsePoolRequest gachaUsePoolRequest = Aki.Protocol.GachaUsePoolRequest.Create();
		gachaUsePoolRequest.GachaId = gachaId;
		gachaUsePoolRequest.PoolId = poolId;
		Singleton<Net>.Instance.Call<GachaUsePoolResponse>(ERequestMessageId.GachaUsePoolRequest, gachaUsePoolRequest, delegate(GachaUsePoolResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LZK, "选择卡池失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28808, null, true, true);
				return;
			}
			ProtoGachaInfo gachaInfo = ModelBase<GachaModel>.Instance.GetGachaInfo(gachaId);
			if (gachaInfo == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Gacha, ELogAuthor.LZK, "卡池设置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			gachaInfo.UsePoolId = poolId;
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.GachaPoolSelectResponse, gachaId, poolId);
		}, 0);
	}

	// Token: 0x0600D8E2 RID: 55522 RVA: 0x003A1240 File Offset: 0x0039F440
	public void PreloadGachaResultResource(Action<EUiRoleLoadResult> callback)
	{
		List<string> list = new List<string>();
		Dictionary<int, bool> dictionary = new Dictionary<int, bool>();
		global::GachaResult[] curGachaResult = ModelBase<GachaModel>.Instance.CurGachaResult;
		for (int i = 0; i < curGachaResult.Length; i++)
		{
			int itemId = curGachaResult[i].Proto_GachaReward.ItemId;
			switch (ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId))
			{
			case InventoryDefine.EItemDataType.RoleItem:
			{
				RoleInfo value = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(itemId).Value;
				if (!dictionary.ContainsKey(itemId))
				{
					dictionary.Add(itemId, true);
					list.AddRange(Singleton<UiModelResourcesManager>.Instance.GetRoleResourcesPath(value.Id));
				}
				int value2 = ModelBase<WeaponModel>.Instance.GetWeaponIdByRoleDataId(value.Id).Value;
				string[] collection = Singleton<UiModelResourcesManager>.Instance.GetWeaponResourcesPath(value2).ToArray();
				if (!dictionary.ContainsKey(itemId))
				{
					dictionary.Add(itemId, true);
					list.AddRange(collection);
				}
				RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(value.Id);
				list.AddRange(Singleton<UiModelResourcesManager>.Instance.GetHuluResourcesPath(CharacterUtils.GetHuluModelId(roleConfig.Value.PartyId)));
				break;
			}
			case InventoryDefine.EItemDataType.WeaponItem:
			{
				string[] collection = Singleton<UiModelResourcesManager>.Instance.GetWeaponResourcesPath(itemId).ToArray();
				if (!dictionary.ContainsKey(itemId))
				{
					dictionary.Add(itemId, true);
					list.AddRange(collection);
				}
				break;
			}
			}
		}
		Singleton<UiModelResourcesManager>.Instance.LoadUiModelResources(list, delegate(EUiRoleLoadResult result, Dictionary<string, UObject> _)
		{
			callback(result);
		});
	}

	// Token: 0x0600D8E3 RID: 55523 RVA: 0x003A13CC File Offset: 0x0039F5CC
	public void CommonShowRoleResult(RewardItemPackage itemPackage, bool skipOpenAnime, bool hideExtraReward)
	{
		int id = itemPackage.RewardItem.Id;
		if (ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(id)) == InventoryDefine.EItemDataType.RoleItem)
		{
			List<global::GachaResult> list = new List<global::GachaResult>();
			global::GachaResult gachaResult = new global::GachaResult();
			GachaReward gachaReward = GachaReward.Create();
			gachaReward.ItemId = id;
			gachaReward.ItemCount = 1;
			gachaResult.Proto_GachaReward = gachaReward;
			List<GachaReward> list2 = new List<GachaReward>();
			foreach (Aki.Protocol.RewardItem rewardItem in itemPackage.RewardItems)
			{
				GachaReward gachaReward2 = GachaReward.Create();
				gachaReward2.ItemId = rewardItem.Id;
				gachaReward2.ItemCount = rewardItem.Count;
				list2.Add(gachaReward2);
			}
			gachaResult.Proto_TransformRewards = list2.ToArray();
			list.Add(gachaResult);
			IGachaViewOpenData gachaViewOpenData = new GachaViewOpenData
			{
				SkipOnLoadResourceFinish = skipOpenAnime,
				ResultViewHideExtraReward = hideExtraReward,
				IsOnlyShowGold = false
			};
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DrawMainView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaScanView))
			{
				ModelBase<GachaModel>.Instance.CacheGachaInfo(new CommonShowRoleInfo
				{
					ResultViewData = gachaViewOpenData,
					GachaResult = list.ToArray()
				});
				return;
			}
			ModelBase<GachaModel>.Instance.CurGachaResult = list.ToArray();
			if (gachaViewOpenData.SkipOnLoadResourceFinish)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaScanView, gachaViewOpenData, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DrawMainView, gachaViewOpenData, null);
		}
	}

	// Token: 0x0600D8E4 RID: 55524 RVA: 0x003A1548 File Offset: 0x0039F748
	private void OnAfterCloseGachaScent()
	{
		ICommonShowRoleInfo cachedGachaInfo = ModelBase<GachaModel>.Instance.GetCachedGachaInfo();
		if (cachedGachaInfo != null)
		{
			ModelBase<GachaModel>.Instance.CurGachaResult = cachedGachaInfo.GachaResult;
			if (cachedGachaInfo.ResultViewData.SkipOnLoadResourceFinish)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaScanView, cachedGachaInfo.ResultViewData, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.DrawMainView, cachedGachaInfo.ResultViewData, null);
		}
	}

	// Token: 0x0600D8E5 RID: 55525 RVA: 0x003A15B0 File Offset: 0x0039F7B0
	public void OpenGachaSelectionView(ProtoGachaInfo gachaInfo)
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.GachaSelectionView))
		{
			GachaSelectionViewData gachaSelectionViewData = new GachaSelectionViewData();
			gachaSelectionViewData.GachaInfo = gachaInfo;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GachaSelectionView, gachaSelectionViewData, null);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<ProtoGachaInfo>(EEventName.GachaSelectionViewRefresh, gachaInfo);
	}

	// Token: 0x04006777 RID: 26487
	private HashSet<int> GachaRoleRecord;

	// Token: 0x04006778 RID: 26488
	private double LastGetInfoTime;

	// Token: 0x04006779 RID: 26489
	private const int MinGetInfoInterval = 1;
}
