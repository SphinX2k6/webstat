using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using CSharpScript.Game.Module.Activity.ActivityContent.Tetris;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.ExploreLevel;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B02 RID: 23298
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ItemRewardController : UiControllerBase<ItemRewardController>
	{
		// Token: 0x0603AE91 RID: 241297 RVA: 0x00EF04F0 File Offset: 0x00EEE6F0
		protected override bool OnInit()
		{
			this.SoarStrengthItemId = ConfigCommonParamById.GetIntConfig("FlyStrengthItemId").Value;
			return true;
		}

		// Token: 0x0603AE92 RID: 241298 RVA: 0x00EF0516 File Offset: 0x00EEE716
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<ItemObtainNotify>(ENotifyMessageId.ItemObtainNotify, new Action<ItemObtainNotify, Net.CallbackStatus>(this.OnMsgItemObtainNotify));
		}

		// Token: 0x0603AE93 RID: 241299 RVA: 0x00EF0534 File Offset: 0x00EEE734
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemObtainNotify);
		}

		// Token: 0x0603AE94 RID: 241300 RVA: 0x00EF0548 File Offset: 0x00EEE748
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnItemRewardNotify, new Action<ItemRewardNotify>(this.OnItemRewardNotify));
			Singleton<EventSystem>.Instance.Add(EEventName.OnExploreRewardShowEnd, new Action(this.OnExploreLevelRewardViewShowEnd));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x0603AE95 RID: 241301 RVA: 0x00EF05AC File Offset: 0x00EEE7AC
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnItemRewardNotify, new Action<ItemRewardNotify>(this.OnItemRewardNotify));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnExploreRewardShowEnd, new Action(this.OnExploreLevelRewardViewShowEnd));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		}

		// Token: 0x0603AE96 RID: 241302 RVA: 0x00EF0610 File Offset: 0x00EEE810
		private void OnWorldDone()
		{
			List<RewardData<ICommonRewardInfo>> cacheCommonRewardDataList = ModelBase<ItemRewardModel>.Instance.CacheCommonRewardDataList;
			if (cacheCommonRewardDataList.Count > 0)
			{
				this.Open<ICommonRewardInfo>(cacheCommonRewardDataList[0], null);
			}
		}

		// Token: 0x0603AE97 RID: 241303 RVA: 0x00EF0640 File Offset: 0x00EEE840
		public int[] GetRewardViewReasonArray()
		{
			if (this.RewardViewReasonArray != null)
			{
				return this.RewardViewReasonArray;
			}
			this.RewardViewReasonArray = new int[0];
			IEnumerable<RewardViewFromSource> allRewardViewFromSourceConfig = ConfigBase<ItemRewardConfig>.Instance.GetAllRewardViewFromSourceConfig();
			List<int> list = new List<int>();
			foreach (RewardViewFromSource rewardViewFromSource in allRewardViewFromSourceConfig)
			{
				list.Add(rewardViewFromSource.RewardSourceId);
			}
			this.RewardViewReasonArray = list.ToArray();
			return this.RewardViewReasonArray;
		}

		// Token: 0x0603AE98 RID: 241304 RVA: 0x00EF06CC File Offset: 0x00EEE8CC
		private void ApplyDailyActivityLivenessUnionExpSplitForDisplay(int reasonId, [Nullable(2)] ItemRewardNotify notify, List<RewardItemData> rewardItemDataList)
		{
			if (reasonId != 19600)
			{
				return;
			}
			DailyActivityModel.LivenessUnionExpBonusSplitRule livenessUnionExpBonusSplitRule;
			if (!ModelBase<DailyActivityModel>.Instance.TryGetActiveLivenessUnionExpBonusSplitRule(out livenessUnionExpBonusSplitRule))
			{
				return;
			}
			MapField<int, RewardItemInfoList> mapField = (notify != null) ? notify.RewardItems : null;
			if (mapField != null)
			{
				foreach (KeyValuePair<int, RewardItemInfoList> keyValuePair in mapField)
				{
					if (keyValuePair.Key != 0)
					{
						RewardItemInfoList value = keyValuePair.Value;
						RepeatedField<RewardItemInfo> repeatedField = (value != null) ? value.ItemList : null;
						if (repeatedField != null && repeatedField.Count != 0)
						{
							if (repeatedField.Any((RewardItemInfo info) => info.ItemId == 1))
							{
								return;
							}
						}
					}
				}
			}
			if (rewardItemDataList.Any((RewardItemData d) => d.ConfigId == 1 && d.GetDropItemType() == EDropItemType.Activity))
			{
				return;
			}
			int num = -1;
			for (int i = 0; i < rewardItemDataList.Count; i++)
			{
				RewardItemData rewardItemData = rewardItemDataList[i];
				if (rewardItemData.ConfigId == 1 && rewardItemData.GetDropItemType() == EDropItemType.Normal)
				{
					if (num >= 0)
					{
						return;
					}
					num = i;
				}
			}
			if (num < 0)
			{
				return;
			}
			RewardItemData rewardItemData2 = rewardItemDataList[num];
			int count = rewardItemData2.Count;
			int num2 = count / 2;
			int num3 = count - num2;
			if (num3 <= 0 || num2 <= 0)
			{
				return;
			}
			rewardItemData2.Count = num2;
			rewardItemDataList.Add(new RewardItemData(1, num3, new int?(rewardItemData2.UniqueId), EDropItemType.Activity));
		}

		// Token: 0x0603AE99 RID: 241305 RVA: 0x00EF0840 File Offset: 0x00EEEA40
		private unsafe void OnItemRewardNotify(ItemRewardNotify notify)
		{
			MapField<int, RewardItemInfoList> rewardItems = notify.RewardItems;
			ICollection<int> keys = rewardItems.Keys;
			if (rewardItems == null || keys == null)
			{
				return;
			}
			int reason = notify.Reason;
			RewardViewFromSource? rewardViewFromSource = this.GetRewardViewReasonArray().Contains(reason) ? ConfigBase<ItemRewardConfig>.Instance.GetRewardViewFromSourceConfig(reason) : null;
			if (rewardViewFromSource != null && rewardViewFromSource.Value.RewardNotifyNotTrick)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Reward;
				ELogAuthor author = ELogAuthor.LJQ;
				string message = "[ItemRewardController]当掉落协议通知时,配置上不触发后续处理";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("rewardViewConfig", rewardViewFromSource.Value.Id);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			List<RewardItemData> list = new List<RewardItemData>();
			List<RewardItemData> list2 = new List<RewardItemData>();
			List<RewardItemData> list3 = new List<RewardItemData>();
			int soarStrengthItemCount = 0;
			foreach (int key in keys)
			{
				RewardItemInfoList rewardItemInfoList = rewardItems[key];
				RepeatedField<RewardItemInfo> repeatedField = (rewardItemInfoList != null) ? rewardItemInfoList.ItemList : null;
				if (repeatedField != null && repeatedField.Count != 0)
				{
					int dropItemType = int.Parse(key.ToString());
					foreach (RewardItemInfo rewardItemInfo in repeatedField)
					{
						InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemInfo.ItemId));
						RewardItemData item = new RewardItemData(rewardItemInfo.ItemId, rewardItemInfo.Count, new int?(rewardItemInfo.IncrId), (EDropItemType)dropItemType);
						if (rewardItemInfo.ItemId == this.SoarStrengthItemId)
						{
							soarStrengthItemCount += rewardItemInfo.Count;
						}
						if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleSkinItem)
						{
							list2.Add(item);
						}
						else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem)
						{
							if (ConfigFlySkinConfigById.GetConfig(rewardItemInfo.ItemId, true).Value.IsSpecialViewAfterObtain)
							{
								list3.Add(item);
							}
							else
							{
								list.Add(item);
							}
						}
						else
						{
							list.Add(item);
						}
					}
				}
			}
			this.ApplyDailyActivityLivenessUnionExpSplitForDisplay(reason, notify, list);
			if (ItemRewardDefine.FillRoleDevelopStateTagReasonIdList.Contains(reason))
			{
				ItemRewardRoleDevelopStateTagUtil.FillRewardRoleDevelopStateTagType(list);
			}
			ItemRewardModel instance2 = ModelBase<ItemRewardModel>.Instance;
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.YYZ;
			string message2 = "[ItemRewardController]当掉落协议通知时";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("reasonId", reason);
			instance3.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			int? currentReasonId = instance2.CurrentReasonId;
			int num = reason;
			if (!(currentReasonId.GetValueOrDefault() == num & currentReasonId != null))
			{
				instance2.ClearCurrentRewardData();
			}
			instance2.CurrentReasonId = new int?(reason);
			if (ItemRewardDefine.BlockReasonIdList.Contains(reason))
			{
				return;
			}
			if (reason == 20200)
			{
				this.OpenExploreLevelRewardView(list.ToArray());
				return;
			}
			if (reason == 52401)
			{
				this.OpenEncircleRewardView(list);
				return;
			}
			if (reason == 19707)
			{
				ModelBase<RoguelikeModel>.Instance.ShowRewardList = list;
				Singleton<KuroSdkReport>.Instance.OnRougeFinish();
				return;
			}
			if (reason == 15008)
			{
				List<IRewardExploreConfirmButton> list4 = new List<IRewardExploreConfirmButton>();
				RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
				rewardExploreConfirmButtonData.ButtonTextId = "ConfirmBox_45_ButtonText_1";
				rewardExploreConfirmButtonData.DescriptionTextId = null;
				rewardExploreConfirmButtonData.DescriptionArgs = null;
				rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
				rewardExploreConfirmButtonData.IsClickedCloseView = false;
				rewardExploreConfirmButtonData.OnClickedCallback = delegate(int index)
				{
					if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
					{
						Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
					}
				};
				RewardExploreConfirmButtonData item2 = rewardExploreConfirmButtonData;
				list4.Add(item2);
				string tip = null;
				if (notify.Magnification > 1)
				{
					DoubleDropFrom from = notify.From;
					if (from != DoubleDropFrom.DoubleActivity)
					{
						if (from == DoubleDropFrom.FromRegress)
						{
							int lastUnGetRewardLevelPlayId = ModelBase<ActivityRegressModel>.Instance.LastUnGetRewardLevelPlayId;
							if (lastUnGetRewardLevelPlayId != 0)
							{
								ModelBase<ActivityRegressModel>.Instance.LastUnGetRewardLevelPlayId = 0;
								ValueTuple<bool, int, int, string, string> levelPlayDoubleDropTuple = ModelBase<ActivityRegressModel>.Instance.GetLevelPlayDoubleDropTuple(lastUnGetRewardLevelPlayId);
								bool item3 = levelPlayDoubleDropTuple.Item1;
								int item4 = levelPlayDoubleDropTuple.Item2;
								int item5 = levelPlayDoubleDropTuple.Item3;
								string item6 = levelPlayDoubleDropTuple.Item4;
								string item7 = levelPlayDoubleDropTuple.Item5;
								if (item3)
								{
									string multiText = ConfigBase<TextConfig>.Instance.GetMultiText(item7, Array.Empty<string>());
									string multiText2 = ConfigBase<TextConfig>.Instance.GetMultiText(item6, new string[]
									{
										item4.ToString(),
										item5.ToString()
									});
									tip = multiText + multiText2;
								}
							}
						}
					}
					else
					{
						ActivityDoubleRewardController instance4 = ControllerBase<ActivityDoubleRewardController>.Instance;
						num = 1;
						List<int> list5 = new List<int>(num);
						CollectionsMarshal.SetCount<int>(list5, num);
						Span<int> span = CollectionsMarshal.AsSpan<int>(list5);
						int index2 = 0;
						*span[index2] = 3;
						tip = instance4.GetDungeonUpActivityFullTip(list5, false);
					}
				}
				this.OpenExploreRewardView(3006, true, list, null, null, list4, null, null, null, tip, null, null, null, null, new bool?(true), null, null);
				return;
			}
			if (reason == 6003 && rewardViewFromSource != null)
			{
				this.OpenQuestRewardView(rewardViewFromSource.Value.RewardViewId, list, null);
				return;
			}
			if (rewardViewFromSource == null)
			{
				this.AddItemList(list);
				return;
			}
			if (list2.Count > 0)
			{
				ControllerBase<SkinController>.Instance.OpenObtainSkinView(list2.ToArray(), list.ToArray());
				return;
			}
			if (list3.Count > 0)
			{
				ControllerBase<SkinController>.Instance.OpenObtainFlySkinView(list3.ToArray(), list.ToArray());
				return;
			}
			int rewardViewId = rewardViewFromSource.Value.RewardViewId;
			if (soarStrengthItemCount > 0)
			{
				this.OpenCommonRewardView(rewardViewId, list, delegate
				{
					this.OpenSoarStrengthUpView(soarStrengthItemCount);
				});
				return;
			}
			this.OpenCommonRewardView(rewardViewId, list, null);
		}

		// Token: 0x0603AE9A RID: 241306 RVA: 0x00EF0DC8 File Offset: 0x00EEEFC8
		private void OnMsgItemObtainNotify(ItemObtainNotify notify, [Nullable(2)] Net.CallbackStatus _)
		{
			this.OnItemObtainNotify(notify, null);
		}

		// Token: 0x0603AE9B RID: 241307 RVA: 0x00EF0DD4 File Offset: 0x00EEEFD4
		public void OnItemObtainNotify(ItemObtainNotify notify, [Nullable(2)] Action<bool?> callback)
		{
			RepeatedField<RewardItemPackage> rewardItemPackages = notify.RewardItemPackages;
			if (rewardItemPackages.Count <= 0)
			{
				return;
			}
			if (this.TryShowConsoleExtraPayGiftPreview(notify.Reason, delegate
			{
				this.OnItemObtainNotify(notify, callback);
			}))
			{
				return;
			}
			List<RewardItemData> list = new List<RewardItemData>();
			List<RewardItemData> list2 = new List<RewardItemData>();
			List<RewardItemData> list3 = new List<RewardItemData>();
			List<RewardItemData> list4 = new List<RewardItemData>();
			List<RewardItemData> list5 = new List<RewardItemData>();
			List<RewardItemPackage> list6 = new List<RewardItemPackage>();
			int num = 0;
			foreach (RewardItemPackage rewardItemPackage in rewardItemPackages)
			{
				InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(rewardItemPackage.RewardItem.Id));
				if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
				{
					list6.Add(rewardItemPackage);
				}
				else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleSkinItem)
				{
					RewardItemData item = new RewardItemData(rewardItemPackage.RewardItem.Id, rewardItemPackage.RewardItem.Count, new int?(rewardItemPackage.RewardItem.IncrId), EDropItemType.Normal);
					list2.Add(item);
				}
				else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem)
				{
					RewardItemData item2 = new RewardItemData(rewardItemPackage.RewardItem.Id, rewardItemPackage.RewardItem.Count, new int?(rewardItemPackage.RewardItem.IncrId), EDropItemType.Normal);
					if (ConfigFlySkinConfigById.GetConfig(rewardItemPackage.RewardItem.Id, true).Value.IsSpecialViewAfterObtain)
					{
						list3.Add(item2);
					}
					else
					{
						list.Add(item2);
					}
				}
				else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorFrameItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorStickerItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorDecorationItem || itemDataTypeByConfigId == InventoryDefine.EItemDataType.MotorSkinItem)
				{
					RewardItemData item3 = new RewardItemData(rewardItemPackage.RewardItem.Id, rewardItemPackage.RewardItem.Count, new int?(rewardItemPackage.RewardItem.IncrId), EDropItemType.Normal);
					list4.Add(item3);
					list.Add(item3);
				}
				else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.OrnamentItem)
				{
					RewardItemData item4 = new RewardItemData(rewardItemPackage.RewardItem.Id, rewardItemPackage.RewardItem.Count, new int?(rewardItemPackage.RewardItem.IncrId), EDropItemType.Normal);
					list5.Add(item4);
					list.Add(item4);
				}
				else
				{
					RewardItemData item5 = new RewardItemData(rewardItemPackage.RewardItem.Id, rewardItemPackage.RewardItem.Count, new int?(rewardItemPackage.RewardItem.IncrId), EDropItemType.Normal);
					if (rewardItemPackage.RewardItem.Id == this.SoarStrengthItemId)
					{
						num += rewardItemPackage.RewardItem.Count;
					}
					list.Add(item5);
				}
			}
			int reason = notify.Reason;
			this.ApplyDailyActivityLivenessUnionExpSplitForDisplay(reason, null, list);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[ItemRewardController]当服务端通知奖励获得时";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reasonId", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DispatchPackagedReward(reason, list, list6, list2, list3, list4, list5, num, callback, notify);
		}

		// Token: 0x0603AE9C RID: 241308 RVA: 0x00EF1100 File Offset: 0x00EEF300
		public void DispatchPackagedReward(int reasonId, List<RewardItemData> rewardItemDataList, List<RewardItemPackage> characterItemList, List<RewardItemData> obtainSkinItemDataList, List<RewardItemData> obtainFlySkinItemDataList, List<RewardItemData> obtainMotorItemDataList, List<RewardItemData> obtainOrnamentItemDataList, int soarStrengthItemCount, [Nullable(2)] Action<bool?> callback = null, [Nullable(2)] ItemObtainNotify originNotify = null)
		{
			if (ItemRewardDefine.BlockObtainReasonIdList.Contains(reasonId))
			{
				return;
			}
			if (rewardItemDataList.Any((RewardItemData item) => item.ConfigId == 50021))
			{
				return;
			}
			ItemRewardModel instance = ModelBase<ItemRewardModel>.Instance;
			int? currentReasonId = instance.CurrentReasonId;
			if (!(currentReasonId.GetValueOrDefault() == reasonId & currentReasonId != null))
			{
				instance.ClearCurrentRewardData();
			}
			instance.CurrentReasonId = new int?(reasonId);
			RewardViewFromSource? rewardViewFromSource = this.GetRewardViewReasonArray().Contains(reasonId) ? ConfigBase<ItemRewardConfig>.Instance.GetRewardViewFromSourceConfig(reasonId) : null;
			if (rewardViewFromSource != null)
			{
				int rewardViewId = rewardViewFromSource.Value.RewardViewId;
				int rewardSourceId = rewardViewFromSource.Value.RewardSourceId;
				if (rewardSourceId == 13000 && !ControllerBase<ItemExchangeController>.Instance.NeedPop)
				{
					return;
				}
				if (rewardSourceId == 6003)
				{
					this.OpenQuestRewardView(rewardViewId, rewardItemDataList, delegate
					{
						Action<bool?> callback2 = callback;
						if (callback2 == null)
						{
							return;
						}
						callback2(null);
					});
					return;
				}
				if (rewardSourceId == 27002)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_AutoMaterial", Array.Empty<object>());
					return;
				}
				if (soarStrengthItemCount > 0)
				{
					this.OpenObtainItemNormalRewardView(reasonId, rewardViewId, rewardItemDataList, delegate
					{
						this.OpenSoarStrengthUpView(soarStrengthItemCount);
					});
					return;
				}
				if ((rewardSourceId == 18500 || rewardSourceId == 18504 || rewardSourceId == 18505) && ControllerBase<BattlePassController>.Instance.IsNeedExtraRewardView())
				{
					this.OpenBattlePassExtraRewardView(rewardItemDataList);
					return;
				}
				if (rewardSourceId == 48007 && !ModelBase<ActivityRegressModel>.Instance.ActivityData.IsPayRewardUnlock() && ControllerBase<ActivityRegressController>.Instance.IsNeedExtraRewardView())
				{
					this.OpenRegressBpRewardView(rewardItemDataList);
					return;
				}
				if (reasonId == 53101)
				{
					this.OpenCommonRewardView(rewardViewId, rewardItemDataList, delegate
					{
						TetrisPlayView tetrisPlayView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.TetrisPlayView) as TetrisPlayView;
						if (tetrisPlayView != null)
						{
							tetrisPlayView.TetrisRewardClose();
						}
					});
					return;
				}
				if (obtainMotorItemDataList.Count > 0 && reasonId == 8001)
				{
					this.OpenMotorItemRewardView(rewardViewId, rewardItemDataList, obtainMotorItemDataList);
					return;
				}
				if (characterItemList.Count == 0 && obtainSkinItemDataList.Count == 0 && obtainFlySkinItemDataList.Count == 0 && obtainOrnamentItemDataList.Count == 0)
				{
					this.OpenObtainItemNormalRewardView(reasonId, rewardViewId, rewardItemDataList, delegate
					{
						Action<bool?> callback2 = callback;
						if (callback2 == null)
						{
							return;
						}
						callback2(null);
					});
					return;
				}
				if (rewardItemDataList.Count == 0 && characterItemList.Count > 0)
				{
					using (List<RewardItemPackage>.Enumerator enumerator = characterItemList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							RewardItemPackage itemPackage = enumerator.Current;
							ControllerBase<GachaController>.Instance.CommonShowRoleResult(itemPackage, true, false);
						}
						return;
					}
				}
				if (obtainSkinItemDataList.Count > 0)
				{
					ControllerBase<SkinController>.Instance.OpenObtainSkinView(obtainSkinItemDataList.ToArray(), rewardItemDataList.ToArray());
					return;
				}
				if (obtainFlySkinItemDataList.Count > 0)
				{
					ControllerBase<SkinController>.Instance.OpenObtainFlySkinView(obtainFlySkinItemDataList.ToArray(), rewardItemDataList.ToArray());
					return;
				}
				if (obtainOrnamentItemDataList.Count > 0)
				{
					this.OpenOrnamentItemRewardView(rewardViewId, rewardItemDataList, obtainOrnamentItemDataList, delegate
					{
						Action<bool?> callback2 = callback;
						if (callback2 == null)
						{
							return;
						}
						callback2(null);
					});
					return;
				}
				this.OpenObtainItemNormalRewardView(reasonId, rewardViewId, rewardItemDataList, delegate
				{
					foreach (RewardItemPackage itemPackage2 in characterItemList)
					{
						ControllerBase<GachaController>.Instance.CommonShowRoleResult(itemPackage2, true, false);
					}
					Action<bool?> callback2 = callback;
					if (callback2 == null)
					{
						return;
					}
					callback2(null);
				});
				return;
			}
			else if (reasonId > 50000)
			{
				int? intConfig = ConfigCommonParamById.GetIntConfig("DefaultConfigId");
				if (intConfig != null)
				{
					this.OpenObtainItemNormalRewardView(reasonId, intConfig.Value, rewardItemDataList, delegate
					{
						Action<bool?> callback2 = callback;
						if (callback2 == null)
						{
							return;
						}
						callback2(null);
					});
					return;
				}
			}
			else
			{
				this.AddItemList(rewardItemDataList);
				if (callback != null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Reward;
					ELogAuthor author = ELogAuthor.ZJC;
					string message = "OnItemObtainNotify err";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("notify", originNotify);
					instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
		}

		// Token: 0x0603AE9D RID: 241309 RVA: 0x00EF14AC File Offset: 0x00EEF6AC
		[NullableContext(2)]
		private void OpenObtainItemNormalRewardView(int reasonId, int configId, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null)
		{
			if (reasonId == 8001)
			{
				this.OpenPayRewardView(configId, rewardItemDataList, onCloseCallback);
				return;
			}
			this.OpenCommonRewardView(configId, rewardItemDataList, onCloseCallback);
		}

		// Token: 0x0603AE9E RID: 241310 RVA: 0x00EF14CC File Offset: 0x00EEF6CC
		[NullableContext(2)]
		public void OpenCommonRewardView(int configId, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null)
		{
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(configId, EUiViewName.CommonRewardView, rewardItemDataList, onCloseCallback, null, null, null, null, true, false);
			if (rewardData == null)
			{
				return;
			}
			this.Open<ICommonRewardInfo>(rewardData, null);
		}

		// Token: 0x0603AE9F RID: 241311 RVA: 0x00EF1500 File Offset: 0x00EEF700
		[NullableContext(2)]
		public void OpenPayRewardView(int configId, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null)
		{
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.CreateCommonRewardDataFromConfig(configId, EUiViewName.PayRewardView, rewardItemDataList, onCloseCallback, null, null, null, null, true, false);
			if (rewardData == null)
			{
				return;
			}
			ModelBase<ItemRewardModel>.Instance.CacheCommonRewardDataList.Add(rewardData);
			if (ModelBase<GameModeModel>.Instance.WorldDone)
			{
				this.Open<ICommonRewardInfo>(rewardData, null);
			}
		}

		// Token: 0x0603AEA0 RID: 241312 RVA: 0x00EF1550 File Offset: 0x00EEF750
		[NullableContext(2)]
		public void OpenQuestRewardView(int configId, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, Action onCloseCallback = null)
		{
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(configId, EUiViewName.QuestRewardView, rewardItemDataList, onCloseCallback, null, null, null, null, true, false);
			if (rewardData == null)
			{
				return;
			}
			this.Open<ICommonRewardInfo>(rewardData, null);
		}

		// Token: 0x0603AEA1 RID: 241313 RVA: 0x00EF1584 File Offset: 0x00EEF784
		private bool TryShowConsoleExtraPayGiftPreview(int reasonId, Action onConfirm)
		{
			ItemRewardController.<>c__DisplayClass19_0 CS$<>8__locals1 = new ItemRewardController.<>c__DisplayClass19_0();
			CS$<>8__locals1.onConfirm = onConfirm;
			PayShopModel instance = ModelBase<PayShopModel>.Instance;
			if (instance == null)
			{
				return false;
			}
			PayGiftPreviewBuildResult payGiftPreviewBuildResult = instance.TryBuildConsoleExtraPayGiftPreview(reasonId);
			if (payGiftPreviewBuildResult == null)
			{
				return false;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("DefaultConfigId");
			if (intConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Reward, ELogAuthor.YZY, "[ConsoleExtraPayGift] DefaultConfigId missing, fallback to normal flow", default(ReadOnlySpan<ValueTuple<string, object>>));
				instance.ClearPreviewPayGiftEntries();
				return false;
			}
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(intConfig.Value, EUiViewName.CommonRewardView, payGiftPreviewBuildResult.PreviewItems, new Action(CS$<>8__locals1.<TryShowConsoleExtraPayGiftPreview>g__previewOnClose|0), null, "PayGiftUseConfirm", null, null, true, true);
			if (rewardData == null)
			{
				instance.ClearPreviewPayGiftEntries();
				return false;
			}
			this.Open<ICommonRewardInfo>(rewardData, null);
			return true;
		}

		// Token: 0x0603AEA2 RID: 241314 RVA: 0x00EF163C File Offset: 0x00EEF83C
		public void OpenExploreLevelRewardView([Nullable(new byte[]
		{
			2,
			1
		})] RewardItemData[] rewardItemDataList = null)
		{
			CountryExploreLevelData currentCountryExploreLevelData = ModelBase<ExploreLevelModel>.Instance.GetCurrentCountryExploreLevelData();
			if (currentCountryExploreLevelData == null)
			{
				return;
			}
			int exploreLevel = currentCountryExploreLevelData.GetExploreLevel();
			this.ExploreRewardQueue.Push(new ValueTuple<RewardItemData[], int>(rewardItemDataList ?? Array.Empty<RewardItemData>(), exploreLevel));
			if (this.ExploreRewardQueue.Size == 1)
			{
				this.OpenExploreLevelRewardViewFromQueue();
			}
		}

		// Token: 0x0603AEA3 RID: 241315 RVA: 0x00EF168E File Offset: 0x00EEF88E
		private void OnExploreLevelRewardViewShowEnd()
		{
			this.ExploreRewardQueue.Pop();
			this.OpenExploreLevelRewardViewFromQueue();
		}

		// Token: 0x0603AEA4 RID: 241316 RVA: 0x00EF16A4 File Offset: 0x00EEF8A4
		private void OpenExploreLevelRewardViewFromQueue()
		{
			if (this.ExploreRewardQueue.Empty)
			{
				return;
			}
			ValueTuple<RewardItemData[], int> front = this.ExploreRewardQueue.Front;
			RewardItemData[] item = front.Item1;
			int item2 = front.Item2;
			RewardData<IExploreLevelRewardInfo> exploreLevelRewardData = ModelBase<ItemRewardModel>.Instance.GetExploreLevelRewardData(EUiViewName.ExploreLevelRewardView, item2, item2 + 1, item.ToList<RewardItemData>());
			this.Open<IExploreLevelRewardInfo>(exploreLevelRewardData, null);
		}

		// Token: 0x0603AEA5 RID: 241317 RVA: 0x00EF16FC File Offset: 0x00EEF8FC
		public void OpenCompositeRewardView(int configId, bool isSuccess = true, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardProgress> progressQueue = null)
		{
			RewardData<ICompositeRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCompositeRewardDataFromConfig(configId, isSuccess, rewardItemDataList, progressQueue);
			if (rewardData == null)
			{
				return;
			}
			this.Open<ICompositeRewardInfo>(rewardData, null);
		}

		// Token: 0x0603AEA6 RID: 241318 RVA: 0x00EF1728 File Offset: 0x00EEF928
		[NullableContext(2)]
		public bool OpenExploreRewardView(int configId, bool isSuccess = true, [Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemDataList = null, IRewardExploreRecord exploreRecordInfo = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreBar> exploreBarDataList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreConfirmButton> buttonInfoList = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreTargetReached> targetReached = null, IRewardExploreToggle stateToggle = null, Action onCloseCallback = null, string tip = null, Action<bool> finishCallback = null, bool? isShowOnlineChallengePlayer = null, [Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardExploreFriendData> exploreFriendDataList = null, ReachTargetData scoreReachedData = null, bool? isRewardMultiLine = null, AccumulatedScoreData accumulatedScoreData = null, string titleTextId = null)
		{
			RewardData<IExploreRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshExploreRewardDataFromConfig(configId, isSuccess, rewardItemDataList, exploreRecordInfo, exploreBarDataList, buttonInfoList, targetReached, stateToggle, onCloseCallback, tip, isShowOnlineChallengePlayer, exploreFriendDataList, scoreReachedData, isRewardMultiLine, accumulatedScoreData, titleTextId);
			if (rewardData == null)
			{
				return false;
			}
			this.Open<IExploreRewardInfo>(rewardData, finishCallback);
			return true;
		}

		// Token: 0x0603AEA7 RID: 241319 RVA: 0x00EF176C File Offset: 0x00EEF96C
		public bool OpenExploreRewardViewNew(IExploreRewardViewData data)
		{
			RewardData<IExploreRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshExploreRewardDataFromConfigNew(data);
			if (rewardData == null)
			{
				return false;
			}
			this.Open<IExploreRewardInfo>(rewardData, data.FinishCallback);
			return true;
		}

		// Token: 0x0603AEA8 RID: 241320 RVA: 0x00EF1798 File Offset: 0x00EEF998
		public bool OpenBattlePassExtraRewardView(List<RewardItemData> rewardItemDataList)
		{
			RewardData<IBattlePassExtraRewardInfo> rewardData = ControllerBase<BattlePassController>.Instance.BuildExtraRewardData(rewardItemDataList);
			this.Open<IBattlePassExtraRewardInfo>(rewardData, rewardData.GetRewardInfo().FinishCallback);
			return true;
		}

		// Token: 0x0603AEA9 RID: 241321 RVA: 0x00EF17C4 File Offset: 0x00EEF9C4
		public bool OpenRegressBpRewardView(List<RewardItemData> rewardItemDataList)
		{
			RewardData<IBattlePassExtraRewardInfo> rewardData = ControllerBase<ActivityRegressController>.Instance.BuildExtraRewardData(rewardItemDataList);
			this.Open<IBattlePassExtraRewardInfo>(rewardData, rewardData.GetRewardInfo().FinishCallback);
			return true;
		}

		// Token: 0x0603AEAA RID: 241322 RVA: 0x00EF17F0 File Offset: 0x00EEF9F0
		public bool OpenEncircleRewardView(List<RewardItemData> rewardItemDataList)
		{
			RewardData<IEncircleRewardInfo> rewardData = ControllerBase<ActivityEncircleController>.Instance.BuildRewardData(rewardItemDataList);
			this.Open<IEncircleRewardInfo>(rewardData, null);
			return true;
		}

		// Token: 0x0603AEAB RID: 241323 RVA: 0x00EF1814 File Offset: 0x00EEFA14
		public bool OpenMotorItemRewardView(int configId, List<RewardItemData> rewardItemDataList, List<RewardItemData> obtainMotorItemDataList)
		{
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.MotorDevelop);
			bool flag2 = false;
			if (flag)
			{
				flag2 = ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultSkin();
			}
			bool flag3 = flag && flag2;
			string leftBtnTextId = flag ? "MotorBike_Shop_CloseButton" : null;
			string rightBtnTextId = flag3 ? "MotorBike_Shop_EquipButton" : null;
			int jumpDiyType = 0;
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.MotorSkinBuyDetailView))
			{
				MotorSkinBuyDetailView motorSkinBuyDetailView = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.MotorSkinBuyDetailView) as MotorSkinBuyDetailView;
				MotorSkinBuyDetailViewData motorSkinBuyDetailViewData = (motorSkinBuyDetailView != null) ? motorSkinBuyDetailView.GetViewData() : null;
				if (motorSkinBuyDetailViewData != null)
				{
					ShopMotorSkinData currentGoodsData = motorSkinBuyDetailViewData.GetCurrentGoodsData();
					MotorSkinData motorSkinData = (currentGoodsData != null) ? currentGoodsData.GetMotorSkinData() : null;
					MotorSkinShow? motorSkinShow = (motorSkinData != null) ? motorSkinData.GetMotorSkinShow() : null;
					if (motorSkinShow != null)
					{
						jumpDiyType = motorSkinShow.Value.JumpDiyRoot;
					}
				}
			}
			Action rightAction = flag3 ? delegate()
			{
				ControllerBase<MotorcycleDiyController>.Instance.OpenTargetViewByReward(obtainMotorItemDataList.ToList<RewardItemData>(), jumpDiyType);
			} : null;
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(configId, EUiViewName.CommonRewardView, rewardItemDataList, null, leftBtnTextId, rightBtnTextId, new Action(ItemRewardController.<OpenMotorItemRewardView>g__quitCallback|29_0), rightAction, false, false);
			if (rewardData == null)
			{
				return false;
			}
			this.Open<ICommonRewardInfo>(rewardData, null);
			return true;
		}

		// Token: 0x0603AEAC RID: 241324 RVA: 0x00EF193C File Offset: 0x00EEFB3C
		public bool OpenOrnamentItemRewardView(int configId, List<RewardItemData> rewardItemDataList, List<RewardItemData> obtainOrnamentItemDataList, [Nullable(2)] Action onCloseCallback = null)
		{
			ItemRewardController.<>c__DisplayClass30_0 CS$<>8__locals1 = new ItemRewardController.<>c__DisplayClass30_0();
			CS$<>8__locals1.onCloseCallback = onCloseCallback;
			CS$<>8__locals1.obtainOrnamentItemDataList = obtainOrnamentItemDataList;
			RewardData<ICommonRewardInfo> rewardData = ModelBase<ItemRewardModel>.Instance.RefreshCommonRewardDataFromConfig(configId, EUiViewName.CommonRewardView, rewardItemDataList, null, "MotorBike_Shop_CloseButton", "OrnamentShop_text_01", new Action(CS$<>8__locals1.<OpenOrnamentItemRewardView>g__quitCallback|0), new Action(CS$<>8__locals1.<OpenOrnamentItemRewardView>g__equipCallback|1), false, false);
			if (rewardData == null)
			{
				return false;
			}
			this.Open<ICommonRewardInfo>(rewardData, null);
			return true;
		}

		// Token: 0x0603AEAD RID: 241325 RVA: 0x00EF19A4 File Offset: 0x00EEFBA4
		public void Open<[Nullable(0)] T>(RewardData<T> rewardData, [Nullable(2)] Action<bool> finishCallback = null) where T : IRewardInfo
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DrawMainView))
			{
				return;
			}
			T rewardInfo = rewardData.GetRewardInfo();
			if (Singleton<UiManager>.Instance.IsViewOpen(rewardInfo.ViewName))
			{
				Singleton<EventSystem>.Instance.Emit<IRewardDataInterface>(EEventName.OnRefreshRewardView, rewardData);
				return;
			}
			EUiViewName viewName = rewardInfo.ViewName;
			Singleton<UiManager>.Instance.OpenView(viewName, rewardData, delegate(bool success, int viewId)
			{
				Action<bool> finishCallback2 = finishCallback;
				if (finishCallback2 != null)
				{
					finishCallback2(success);
				}
				if (!success)
				{
					return;
				}
				UiViewBase uiViewBase = Singleton<UiModel>.Instance.NormalStack.Peek();
				if (uiViewBase == null)
				{
					return;
				}
				uiViewBase.AddChildViewById(viewId);
			});
		}

		// Token: 0x0603AEAE RID: 241326 RVA: 0x00EF1A28 File Offset: 0x00EEFC28
		public void Close([Nullable(new byte[]
		{
			2,
			1
		})] RewardData<IRewardInfo> rewardData = null)
		{
			if (rewardData != null)
			{
				EUiViewName viewName = rewardData.GetRewardInfo().ViewName;
				if (Singleton<UiManager>.Instance.IsViewShow(viewName))
				{
					Singleton<UiManager>.Instance.CloseView(viewName, null);
				}
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CommonRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CommonRewardView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CompositeRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.CompositeRewardView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
			}
		}

		// Token: 0x0603AEAF RID: 241327 RVA: 0x00EF1AC1 File Offset: 0x00EEFCC1
		public void SetItemList(List<RewardItemData> rewardItemList)
		{
			ModelBase<ItemRewardModel>.Instance.SetItemList(rewardItemList);
		}

		// Token: 0x0603AEB0 RID: 241328 RVA: 0x00EF1ACE File Offset: 0x00EEFCCE
		public void AddItemList(List<RewardItemData> rewardItemList)
		{
			ModelBase<ItemRewardModel>.Instance.AddItemList(rewardItemList);
		}

		// Token: 0x0603AEB1 RID: 241329 RVA: 0x00EF1ADB File Offset: 0x00EEFCDB
		public void SetProgressQueue(List<IRewardProgress> progressQueue)
		{
			ModelBase<ItemRewardModel>.Instance.SetProgressQueue(progressQueue);
		}

		// Token: 0x0603AEB2 RID: 241330 RVA: 0x00EF1AE8 File Offset: 0x00EEFCE8
		public void SetExploreBarDataList(List<IRewardExploreBar> exploreBarDataList)
		{
			ModelBase<ItemRewardModel>.Instance.SetExploreBarDataList(exploreBarDataList);
		}

		// Token: 0x0603AEB3 RID: 241331 RVA: 0x00EF1AF5 File Offset: 0x00EEFCF5
		public void SetExploreRecordInfo(IRewardExploreRecord exploreRecordInfo)
		{
			ModelBase<ItemRewardModel>.Instance.SetExploreRecordInfo(exploreRecordInfo);
		}

		// Token: 0x0603AEB4 RID: 241332 RVA: 0x00EF1B02 File Offset: 0x00EEFD02
		public void SetButtonList(List<IRewardExploreConfirmButton> exploreButtonInfo)
		{
			ModelBase<ItemRewardModel>.Instance.SetButtonList(exploreButtonInfo);
		}

		// Token: 0x0603AEB5 RID: 241333 RVA: 0x00EF1B0F File Offset: 0x00EEFD0F
		public void SetExploreFriendDataList(List<IRewardExploreFriendData> exploreFriendDataList)
		{
			ModelBase<ItemRewardModel>.Instance.SetExploreFriendDataList(exploreFriendDataList);
		}

		// Token: 0x0603AEB6 RID: 241334 RVA: 0x00EF1B1C File Offset: 0x00EEFD1C
		public List<IRewardExploreFriendData> BuildExploreFriendDataList()
		{
			List<IRewardExploreFriendData> list = new List<IRewardExploreFriendData>();
			FriendModel instance = ModelBase<FriendModel>.Instance;
			OnlineModel instance2 = ModelBase<OnlineModel>.Instance;
			foreach (OnlineTeamData onlineTeamData in instance2.GetTeamList())
			{
				if (!onlineTeamData.IsSelf)
				{
					int playerId = onlineTeamData.PlayerId;
					OnlineTeamData currentTeamListById = instance2.GetCurrentTeamListById(playerId);
					string playerIconPath = (currentTeamListById != null) ? ModelBase<PersonalModel>.Instance.GetPlayerHeadData(onlineTeamData.HeadId, false).GetRoleHeadIconCircle() : "";
					string playerIndexPath = (currentTeamListById != null) ? this.BuildTeamIndexIcon(currentTeamListById.PlayerNumber) : "";
					RewardExploreFriendData rewardExploreFriendData = new RewardExploreFriendData();
					rewardExploreFriendData.PlayerId = playerId;
					rewardExploreFriendData.PlayerLevel = onlineTeamData.Level;
					rewardExploreFriendData.IsMyFriend = instance.IsMyFriend(playerId);
					rewardExploreFriendData.PlayerName = (((currentTeamListById != null) ? currentTeamListById.PlayerName : null) ?? "");
					rewardExploreFriendData.PlayerDesc = (((currentTeamListById != null) ? currentTeamListById.Signature : null) ?? "");
					rewardExploreFriendData.PlayerIconPath = playerIconPath;
					rewardExploreFriendData.PlayerIndexPath = playerIndexPath;
					rewardExploreFriendData.OnClickCallback = delegate(int pid)
					{
						ControllerBase<FriendController>.Instance.RequestFriendApplyAddSend(pid, FriendApplyWay.RecentlyTeam);
					};
					RewardExploreFriendData item = rewardExploreFriendData;
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0603AEB7 RID: 241335 RVA: 0x00EF1C8C File Offset: 0x00EEFE8C
		private string BuildTeamIndexIcon(int onlineIndex)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("FormationOnline");
			defaultInterpolatedStringHandler.AppendFormatted<int>(onlineIndex);
			defaultInterpolatedStringHandler.AppendLiteral("PIcon");
			string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
			return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		}

		// Token: 0x0603AEB8 RID: 241336 RVA: 0x00EF1CD8 File Offset: 0x00EEFED8
		public List<int> BuildExploreFriendIdList()
		{
			List<int> list = new List<int>();
			foreach (OnlineTeamData onlineTeamData in ModelBase<OnlineModel>.Instance.GetTeamList())
			{
				if (!onlineTeamData.IsSelf)
				{
					list.Add(onlineTeamData.PlayerId);
				}
			}
			return list;
		}

		// Token: 0x0603AEB9 RID: 241337 RVA: 0x00EF1D44 File Offset: 0x00EEFF44
		[NullableContext(2)]
		public void PlayAudio(string audioId, PlayResult result = null)
		{
			if (StringUtils.IsEmpty(audioId))
			{
				return;
			}
			Audio? audioPath = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId);
			if (audioPath == null)
			{
				return;
			}
			Singleton<AudioController>.Instance.PostEventByUi(audioPath.Value.Path, result, null, null);
		}

		// Token: 0x0603AEBA RID: 241338 RVA: 0x00EF1D94 File Offset: 0x00EEFF94
		public unsafe void OpenSoarStrengthUpView(int strengthItemCount)
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlyStrengthItemId");
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(intConfig.Value);
			if (itemConfig == null || itemConfig.Value.ParametersLength == 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			if (num2 < itemConfig.Value.ParametersLength)
			{
				num = itemConfig.Value.Parameters(num2).Value.Value;
			}
			if (num == 0)
			{
				return;
			}
			PropRewardConf? config = ConfigPropRewardConfById.GetConfig(num, true);
			if (config == null)
			{
				return;
			}
			float num3 = 0f;
			for (int i = 0; i < config.Value.PropsLength; i++)
			{
				ConfigPropValue value = config.Value.Props(i).Value;
				if (value.Id == 10)
				{
					num3 = value.Value;
					break;
				}
			}
			if (num3 == 0f)
			{
				return;
			}
			num3 *= (float)strengthItemCount;
			int num4 = (int)ControllerBase<FormationAttributeController>.Instance.GetMax(EFormationAttributeId.SoarStrength);
			FormationProperty value2 = ConfigFormationPropertyById.GetConfig(10, true).Value;
			AttributeInfo attributeInfo = new AttributeInfo
			{
				Name = value2.Name,
				IconPath = value2.Icon,
				ShowArrow = new bool?(true),
				PreText = ((int)Math.Floor((double)((float)num4 - num3) / 100.0)).ToString(),
				CurText = ((int)Math.Floor((double)num4 / 100.0)).ToString()
			};
			LevelUpSuccessAttributeData levelUpSuccessAttributeData = new LevelUpSuccessAttributeData();
			levelUpSuccessAttributeData.Title = "Flying_EnergyUp";
			levelUpSuccessAttributeData.StrengthUpgradeData = new StrengthUpgradeData
			{
				AttributeId = EFormationAttributeId.SoarStrength,
				SingleStrengthValue = ConfigCommonParamById.GetIntConfig("FlySingleStrengthValue").Value,
				MaxSingleStrengthItemCount = ConfigCommonParamById.GetIntConfig("FlyMaxSingleStrengthItemCount").Value,
				MaxStrength = num4
			};
			int num5 = 1;
			List<IAttributeInfo> list = new List<IAttributeInfo>(num5);
			CollectionsMarshal.SetCount<IAttributeInfo>(list, num5);
			Span<IAttributeInfo> span = CollectionsMarshal.AsSpan<IAttributeInfo>(list);
			int index = 0;
			*span[index] = attributeInfo;
			levelUpSuccessAttributeData.AttributeInfo = list;
			LevelUpSuccessAttributeData data = levelUpSuccessAttributeData;
			ControllerBase<RoleLevelUpSuccessController>.Instance.OpenSuccessAttributeView(data, null);
		}

		// Token: 0x0603AEBC RID: 241340 RVA: 0x00EF1FE2 File Offset: 0x00EF01E2
		[CompilerGenerated]
		internal static void <OpenMotorItemRewardView>g__quitCallback|29_0()
		{
			if (ModelBase<MotorcycleDiyModel>.Instance.IsEquipFrameLockedByPlayer())
			{
				ModelBase<MotorcycleDiyModel>.Instance.ResetSelectedItemInfo();
			}
		}

		// Token: 0x04021443 RID: 136259
		[Nullable(2)]
		protected int[] RewardViewReasonArray;

		// Token: 0x04021444 RID: 136260
		private int SoarStrengthItemId;

		// Token: 0x04021445 RID: 136261
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			1
		})]
		private readonly Queue<ValueTuple<RewardItemData[], int>> ExploreRewardQueue = new Queue<ValueTuple<RewardItemData[], int>>(4);
	}
}
