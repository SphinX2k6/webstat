using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x02005731 RID: 22321
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class MingSuController : UiControllerBase<MingSuController>
	{
		// Token: 0x06038CEB RID: 232683 RVA: 0x00E63F50 File Offset: 0x00E62150
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x06038CEC RID: 232684 RVA: 0x00E63F54 File Offset: 0x00E62154
		protected override void OnAddEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnAntiqueShopUpgradeSequenceFinished;
			Action handle;
			if ((handle = MingSuController.<>O.<0>__OnAntiqueShopUpgradeSequenceFinished) == null)
			{
				handle = (MingSuController.<>O.<0>__OnAntiqueShopUpgradeSequenceFinished = new Action(MingSuController.OnAntiqueShopUpgradeSequenceFinished));
			}
			instance.Add(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnAntiqueShopLevelMaxSequenceFinished;
			Action handle2;
			if ((handle2 = MingSuController.<>O.<1>__OnAntiqueShopLevelMaxSequenceFinished) == null)
			{
				handle2 = (MingSuController.<>O.<1>__OnAntiqueShopLevelMaxSequenceFinished = new Action(MingSuController.OnAntiqueShopLevelMaxSequenceFinished));
			}
			instance2.Add(name2, handle2);
		}

		// Token: 0x06038CED RID: 232685 RVA: 0x00E63FB8 File Offset: 0x00E621B8
		protected override void OnRemoveEvents()
		{
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.OnAntiqueShopUpgradeSequenceFinished;
			Action handle;
			if ((handle = MingSuController.<>O.<0>__OnAntiqueShopUpgradeSequenceFinished) == null)
			{
				handle = (MingSuController.<>O.<0>__OnAntiqueShopUpgradeSequenceFinished = new Action(MingSuController.OnAntiqueShopUpgradeSequenceFinished));
			}
			instance.Remove(name, handle);
			EventSystem instance2 = Singleton<EventSystem>.Instance;
			EEventName name2 = EEventName.OnAntiqueShopLevelMaxSequenceFinished;
			Action handle2;
			if ((handle2 = MingSuController.<>O.<1>__OnAntiqueShopLevelMaxSequenceFinished) == null)
			{
				handle2 = (MingSuController.<>O.<1>__OnAntiqueShopLevelMaxSequenceFinished = new Action(MingSuController.OnAntiqueShopLevelMaxSequenceFinished));
			}
			instance2.Remove(name2, handle2);
		}

		// Token: 0x06038CEE RID: 232686 RVA: 0x00E6401C File Offset: 0x00E6221C
		private static void OnAntiqueShopUpgradeSequenceFinished()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MingSuTi;
			ELogAuthor author = ELogAuthor.BB;
			string message = "[CollectionItemDisplay]当提交物品等级提升时,开始打开结算界面";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentDragonPoolId", ModelBase<MingSuModel>.Instance.GetCurrentDragonPoolId());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			switch (ModelBase<MingSuModel>.Instance.GetCurrentDragonPoolId())
			{
			case 1:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2006, true, null, null);
				return;
			case 2:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2007, true, null, null);
				return;
			case 3:
				break;
			case 4:
			case 5:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2008, true, null, null);
				return;
			case 6:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2009, true, null, null);
				return;
			case 7:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2010, true, null, null);
				return;
			case 8:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2011, true, null, null);
				break;
			default:
				return;
			}
		}

		// Token: 0x06038CEF RID: 232687 RVA: 0x00E64104 File Offset: 0x00E62304
		private static void OnAntiqueShopLevelMaxSequenceFinished()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MingSuTi;
			ELogAuthor author = ELogAuthor.BB;
			string message = "[CollectionItemDisplay]当提交物品等级升至满级时,开始打开结算界面";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurrentDragonPoolId", ModelBase<MingSuModel>.Instance.GetCurrentDragonPoolId());
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			switch (ModelBase<MingSuModel>.Instance.GetCurrentDragonPoolId())
			{
			case 1:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2006, true, null, null);
				return;
			case 2:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2007, true, null, null);
				return;
			case 3:
				break;
			case 4:
			case 5:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2008, true, null, null);
				return;
			case 6:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2009, true, null, null);
				return;
			case 7:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2010, true, null, null);
				return;
			case 8:
				ControllerBase<ItemRewardController>.Instance.OpenCompositeRewardView(2011, true, null, null);
				break;
			default:
				return;
			}
		}

		// Token: 0x06038CF0 RID: 232688 RVA: 0x00E641EC File Offset: 0x00E623EC
		public static bool OpenView(int dragonPoolId, TOpenViewCallBack finishCallback = null)
		{
			DragonPool? dragonPoolConfigById = ConfigBase<CollectItemConfig>.Instance.GetDragonPoolConfigById(dragonPoolId);
			if (dragonPoolConfigById == null)
			{
				return false;
			}
			MingSuModel mingSuModel = ModelBase<MingSuModel>.Instance;
			mingSuModel.SetCurrentDragonPoolId(dragonPoolId);
			mingSuModel.SetCollectItemConfigId(dragonPoolConfigById.Value.CoreId);
			if (dragonPoolId == 3)
			{
				MingSuController.SendOpenDarkCoastDeliveryRequest(dragonPoolId, delegate
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.DarkCoastDeliveryMainView, mingSuModel.GetDragonPoolInstanceById(dragonPoolId), finishCallback);
				});
			}
			else
			{
				MingSuController.SendOpenDragonPoolRequest(dragonPoolId, delegate
				{
					switch (dragonPoolId)
					{
					case 1:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.MingSuView, null, finishCallback);
						return;
					case 2:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.CollectItemView, null, finishCallback);
						return;
					case 3:
						break;
					case 4:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.PupuVillageItemView, null, finishCallback);
						return;
					case 5:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.PupuVillageItemViewQIQIU, null, finishCallback);
						return;
					case 6:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.LaHaiLuoCollectView, null, finishCallback);
						return;
					case 7:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.RiLingCollectView, null, finishCallback);
						return;
					case 8:
						Singleton<UiManager>.Instance.OpenView(EUiViewName.MengZhouCollectView, null, finishCallback);
						break;
					default:
						return;
					}
				});
			}
			return true;
		}

		// Token: 0x06038CF1 RID: 232689 RVA: 0x00E6429C File Offset: 0x00E6249C
		public static void SendOpenDragonPoolRequest(int dragonPoolId, Action onResponse = null)
		{
			DragonPoolConfRequest dragonPoolConfRequest = DragonPoolConfRequest.Create();
			dragonPoolConfRequest.DragonPoolId = dragonPoolId;
			Singleton<Net>.Instance.Call<DragonPoolConfResponse>(ERequestMessageId.DragonPoolConfRequest, dragonPoolConfRequest, delegate(DragonPoolConfResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29355, null, true, true);
					return;
				}
				ModelBase<MingSuModel>.Instance.RefreshDragonPoolDropItems(response.DragonPoolConf);
				Action onResponse2 = onResponse;
				if (onResponse2 == null)
				{
					return;
				}
				onResponse2();
			}, 0);
		}

		// Token: 0x06038CF2 RID: 232690 RVA: 0x00E642E0 File Offset: 0x00E624E0
		public static void SendOpenDarkCoastDeliveryRequest(int dragonPoolId, Action onResponse = null)
		{
			DarkCoastInfoRequest darkCoastInfoRequest = DarkCoastInfoRequest.Create();
			darkCoastInfoRequest.DragonPoolId = dragonPoolId;
			Singleton<Net>.Instance.Call<DarkCoastInfoResponse>(ERequestMessageId.DarkCoastInfoRequest, darkCoastInfoRequest, delegate(DarkCoastInfoResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25351, null, true, true);
					return;
				}
				ModelBase<MingSuModel>.Instance.RefreshDragonPoolDropItems(response.DragonPoolConf);
				ModelBase<MingSuModel>.Instance.RefreshDarkCoastGuardInfo(dragonPoolId, response.GuardIds.ToArray<int>(), response.TreasureBoxDone.ToArray<int>());
				ModelBase<MingSuModel>.Instance.RefreshDragonPoolLevelGains(dragonPoolId, response.LevelGains);
				Action onResponse2 = onResponse;
				if (onResponse2 == null)
				{
					return;
				}
				onResponse2();
			}, 0);
		}

		// Token: 0x06038CF3 RID: 232691 RVA: 0x00E64330 File Offset: 0x00E62530
		[NullableContext(0)]
		public static UniTask<bool> SendDarkCoastDeliveryRequestAsync()
		{
			MingSuController.<SendDarkCoastDeliveryRequestAsync>d__8 <SendDarkCoastDeliveryRequestAsync>d__;
			<SendDarkCoastDeliveryRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<SendDarkCoastDeliveryRequestAsync>d__.<>1__state = -1;
			<SendDarkCoastDeliveryRequestAsync>d__.<>t__builder.Start<MingSuController.<SendDarkCoastDeliveryRequestAsync>d__8>(ref <SendDarkCoastDeliveryRequestAsync>d__);
			return <SendDarkCoastDeliveryRequestAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038CF4 RID: 232692 RVA: 0x00E6436C File Offset: 0x00E6256C
		public unsafe static void SendHandInMingSuRequest(int dragonPoolId)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MingSuTi;
			ELogAuthor author = ELogAuthor.BB;
			string message = "HandInMingSuRequest";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dragonPoolId", dragonPoolId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			HandInMingSuRequest handInMingSuRequest = HandInMingSuRequest.Create();
			handInMingSuRequest.DragonPoolId = dragonPoolId;
			handInMingSuRequest.InteractEntityId = ModelBase<MingSuModel>.Instance.CurrentInteractCreatureDataLongId.Value;
			Singleton<Net>.Instance.Call<HandInMingSuResponse>(ERequestMessageId.HandInMingSuRequest, handInMingSuRequest, delegate(HandInMingSuResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MingSuTi;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "[CollectionItemDisplay]HandInMingSuResponse";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dragonPoolId", dragonPoolId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("提交数量", response.InjectedCoreItemCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("提交后的等级", response.Level);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("提交后已领取的等级", response.LevelGains);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					MingSuInstance dragonPoolInstanceById = ModelBase<MingSuModel>.Instance.GetDragonPoolInstanceById(response.DragonPoolId);
					if (dragonPoolInstanceById != null)
					{
						int level = response.Level;
						int dragonPoolLevel = dragonPoolInstanceById.GetDragonPoolLevel();
						int dragonPoolMaxLevel = dragonPoolInstanceById.GetDragonPoolMaxLevel();
						Log instance3 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.MingSuTi;
						ELogAuthor author3 = ELogAuthor.BB;
						string message3 = "[CollectionItemDisplay]广播等级提升事件";
						<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray4<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("dragonPoolId", dragonPoolId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("currentLevel", dragonPoolLevel);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("newLevel", level);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("maxLevel", dragonPoolMaxLevel);
						instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 4));
						if (level >= dragonPoolMaxLevel)
						{
							Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemLevelMax);
						}
						else if (dragonPoolLevel < level)
						{
							Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemLevelUp);
						}
						else
						{
							Singleton<EventSystem>.Instance.Emit(EEventName.OnSubmitItemSuccess);
						}
					}
					ModelBase<MingSuModel>.Instance.RefreshDragonPoolActiveStatus(response.DragonPoolId, response.LevelGains);
					ModelBase<MingSuModel>.Instance.RefreshDragonPoolLevel(response.DragonPoolId, response.Level);
					ModelBase<MingSuModel>.Instance.RefreshDragonPoolHadCoreCount(response.DragonPoolId, response.InjectedCoreItemCount);
					Singleton<EventSystem>.Instance.Emit(EEventName.UpdateDragonPoolView);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28038, null, true, true);
				ControllerBase<ItemRewardController>.Instance.Close(null);
			}, 0);
		}

		// Token: 0x06038CF5 RID: 232693 RVA: 0x00E643FC File Offset: 0x00E625FC
		public static void SendMingSuHandRewardRequest(int dragonPoolId)
		{
			MingSuHandRewardRequest mingSuHandRewardRequest = MingSuHandRewardRequest.Create();
			mingSuHandRewardRequest.DragonPoolId = dragonPoolId;
			mingSuHandRewardRequest.InteractEntityId = ModelBase<MingSuModel>.Instance.CurrentInteractCreatureDataLongId.Value;
			Singleton<Net>.Instance.Call<MingSuHandRewardResponse>(ERequestMessageId.MingSuHandRewardRequest, mingSuHandRewardRequest, delegate(MingSuHandRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
				{
					ModelBase<MingSuModel>.Instance.RefreshDragonPoolLevelGains(dragonPoolId, response.LevelGains);
					IActivityRewardViewData activityRewardViewData = (ModelBase<MingSuModel>.Instance.GetDragonPoolInstanceById(dragonPoolId) as DarkCoastDeliveryData).GetActivityRewardViewData();
					Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, activityRewardViewData);
					return;
				}
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17272, null, true, true);
			}, 0);
		}

		// Token: 0x0200B7DC RID: 47068
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04038DE7 RID: 232935
			[Nullable(0)]
			public static Action <0>__OnAntiqueShopUpgradeSequenceFinished;

			// Token: 0x04038DE8 RID: 232936
			[Nullable(0)]
			public static Action <1>__OnAntiqueShopLevelMaxSequenceFinished;
		}
	}
}
