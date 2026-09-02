using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x02002052 RID: 8274
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(42)]
public class ItemHintController : UiControllerBase<ItemHintController>
{
	// Token: 0x1700129C RID: 4764
	// (get) Token: 0x0600FBFC RID: 64508 RVA: 0x0045342C File Offset: 0x0045162C
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x0600FBFD RID: 64509 RVA: 0x0045342F File Offset: 0x0045162F
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ItemRewardNotify>(ENotifyMessageId.ItemRewardNotify, new Action<ItemRewardNotify, Net.CallbackStatus>(this.HandleItemRewardNotify));
	}

	// Token: 0x0600FBFE RID: 64510 RVA: 0x0045344D File Offset: 0x0045164D
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ItemRewardNotify);
	}

	// Token: 0x0600FBFF RID: 64511 RVA: 0x0045345F File Offset: 0x0045165F
	private void TryOpenItemReward(AddCountItemInfo[] addCountItemInfoList)
	{
		if (addCountItemInfoList.Length == 0)
		{
			return;
		}
		if (this.CheckShowInItemHint())
		{
			ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(addCountItemInfoList);
		}
	}

	// Token: 0x0600FC00 RID: 64512 RVA: 0x0045347C File Offset: 0x0045167C
	private bool CheckShowInItemHint()
	{
		if (this.CanShowHintOtherViewIsOpen(true))
		{
			return true;
		}
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.PlotView);
		if (viewByName != null && !viewByName.IsRegister)
		{
			return true;
		}
		UiViewBase viewByName2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.FunctionOpenView);
		return viewByName2 != null && !viewByName2.IsRegister;
	}

	// Token: 0x0600FC01 RID: 64513 RVA: 0x004534D0 File Offset: 0x004516D0
	public void HandleItemRewardNotify(ItemRewardNotify inItemRewardNotify, [Nullable(2)] Net.CallbackStatus status)
	{
		MapField<int, RewardItemInfoList> rewardItems = inItemRewardNotify.RewardItems;
		if (rewardItems == null)
		{
			return;
		}
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(inItemRewardNotify.DropId);
		EShowBgType? eshowBgType = null;
		if (!dropPackage.Value.ShowBg)
		{
			eshowBgType = new EShowBgType?(EShowBgType.None);
		}
		else
		{
			foreach (int key in rewardItems.Keys)
			{
				RewardItemInfoList rewardItemInfoList;
				if (rewardItems.TryGetValue(key, out rewardItemInfoList) && rewardItemInfoList != null)
				{
					RepeatedField<RewardItemInfo> itemList = rewardItemInfoList.ItemList;
					if (itemList != null)
					{
						foreach (RewardItemInfo rewardItemInfo in itemList)
						{
							int showPlanId = rewardItemInfo.ShowPlanId;
							DropShowPlan? dropShowPlan = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropShowPlan(showPlanId);
							if (dropShowPlan == null)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.ItemHint;
								ELogAuthor author = ELogAuthor.CFT;
								string message = "缺少showPlan配置";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("showPlanId", showPlanId);
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							}
							else if (dropShowPlan.Value.ShowBg != 0 && rewardItemInfo.Count > 0)
							{
								if (eshowBgType == null)
								{
									eshowBgType = new EShowBgType?((EShowBgType)dropShowPlan.Value.ShowBg);
								}
								else if (eshowBgType.Value != (EShowBgType)dropShowPlan.Value.ShowBg)
								{
									Log instance2 = Singleton<Log>.Instance;
									ELogModule module2 = ELogModule.ItemHint;
									ELogAuthor author2 = ELogAuthor.CFT;
									string message2 = "一次掉落有多个不同背景的掉落组，请检查配置";
									ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("dropId", inItemRewardNotify.DropId);
									instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
								}
							}
						}
					}
				}
			}
		}
		if (eshowBgType != null)
		{
			EShowBgType valueOrDefault = eshowBgType.GetValueOrDefault();
			if (valueOrDefault != EShowBgType.None && valueOrDefault - EShowBgType.ItemReward <= 2)
			{
				ItemHintController.AddItemRewardList(inItemRewardNotify);
			}
		}
		Singleton<EventSystem>.Instance.Emit<ItemRewardNotify>(EEventName.OnItemRewardNotify, inItemRewardNotify);
	}

	// Token: 0x0600FC02 RID: 64514 RVA: 0x004536EC File Offset: 0x004518EC
	public static void AddItemRewardList(ItemRewardNotify itemRewardInfo)
	{
		ModelBase<ItemHintModel>.Instance.AddItemRewardList(itemRewardInfo);
	}

	// Token: 0x0600FC03 RID: 64515 RVA: 0x004536FC File Offset: 0x004518FC
	public ItemRewardInfo[] CombineAllShowItems(ItemRewardNotify inItemRewardNotify, bool needSort)
	{
		List<ItemRewardInfo> list = new List<ItemRewardInfo>();
		Dictionary<int, ItemRewardInfo> dictionary = new Dictionary<int, ItemRewardInfo>();
		MapField<int, RewardItemInfoList> rewardItems = inItemRewardNotify.RewardItems;
		if (rewardItems == null)
		{
			return list.ToArray();
		}
		foreach (int key in rewardItems.Keys)
		{
			RewardItemInfoList rewardItemInfoList;
			if (rewardItems.TryGetValue(key, out rewardItemInfoList) && rewardItemInfoList != null)
			{
				RepeatedField<RewardItemInfo> itemList = rewardItemInfoList.ItemList;
				if (itemList != null)
				{
					foreach (RewardItemInfo rewardItemInfo in itemList)
					{
						if (rewardItemInfo.Count != 0)
						{
							DropShowPlan? dropShowPlan = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropShowPlan(rewardItemInfo.ShowPlanId);
							if (dropShowPlan == null)
							{
								Log instance = Singleton<Log>.Instance;
								ELogModule module = ELogModule.ItemHint;
								ELogAuthor author = ELogAuthor.CFT;
								string message = "缺少ShowPlan配置";
								ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("showPlanId", rewardItemInfo.ShowPlanId);
								instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
							}
							else if (dropShowPlan.Value.ShowBg != 0)
							{
								if (dictionary.ContainsKey(rewardItemInfo.ItemId))
								{
									dictionary[rewardItemInfo.ItemId].ItemCount += rewardItemInfo.Count;
								}
								else
								{
									CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(rewardItemInfo.ItemId);
									ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
									itemRewardInfo.ItemId = new int?(rewardItemInfo.ItemId);
									itemRewardInfo.ItemCount = new int?(rewardItemInfo.Count);
									itemRewardInfo.Quality = itemConfigData.QualityId;
									dictionary.Add(itemRewardInfo.ItemId.Value, itemRewardInfo);
								}
							}
						}
					}
				}
			}
		}
		foreach (KeyValuePair<int, ItemRewardInfo> keyValuePair in dictionary)
		{
			list.Add(keyValuePair.Value);
		}
		if (needSort)
		{
			list.Sort(delegate(ItemRewardInfo a, ItemRewardInfo b)
			{
				if (a.Quality != b.Quality)
				{
					return a.Quality - b.Quality;
				}
				return a.ItemId.Value - b.ItemId.Value;
			});
		}
		return list.ToArray();
	}

	// Token: 0x0600FC04 RID: 64516 RVA: 0x00453994 File Offset: 0x00451B94
	public static List<TItem> ConvertRewardListToItem(List<ItemRewardInfo> itemList)
	{
		List<TItem> list = new List<TItem>();
		foreach (ItemRewardInfo itemRewardInfo in itemList)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(itemRewardInfo.ItemId.Value, 0), itemRewardInfo.ItemCount.Value);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600FC05 RID: 64517 RVA: 0x00453A0C File Offset: 0x00451C0C
	public DropShowPlan? GetFirstShowBgDropGroup(ItemRewardNotify inItemRewardNotify)
	{
		MapField<int, RewardItemInfoList> rewardItems = inItemRewardNotify.RewardItems;
		if (rewardItems == null)
		{
			return null;
		}
		foreach (int key in rewardItems.Keys)
		{
			RewardItemInfoList rewardItemInfoList;
			if (rewardItems.TryGetValue(key, out rewardItemInfoList) && rewardItemInfoList != null)
			{
				RepeatedField<RewardItemInfo> itemList = rewardItemInfoList.ItemList;
				if (itemList != null)
				{
					foreach (RewardItemInfo rewardItemInfo in itemList)
					{
						int showPlanId = rewardItemInfo.ShowPlanId;
						DropShowPlan? dropShowPlan = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropShowPlan(showPlanId);
						if (dropShowPlan == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.ItemHint;
							ELogAuthor author = ELogAuthor.CFT;
							string message = "缺少ShowPlan配置";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("showPlanId", rewardItemInfo.ShowPlanId);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else if (dropShowPlan.Value.ShowBg != 0)
						{
							return dropShowPlan;
						}
					}
				}
			}
		}
		return null;
	}

	// Token: 0x0600FC06 RID: 64518 RVA: 0x00453B40 File Offset: 0x00451D40
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int, int, int, int, int, int>(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Add<int, int, int>(EEventName.OnPlayerExpChanged, new Action<int, int, int>(this.OnPlayerExpChanged));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Add<PlotResultInfo>(EEventName.PlotNetworkEnd, new Action<PlotResultInfo>(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, new Action(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<WeaponItem>, bool, bool>(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Add<TItem>(EEventName.OnAddFavorItem, new Action<TItem>(this.OnAddFavorItem));
		Singleton<EventSystem>.Instance.Add<TItem[]>(EEventName.OnAddOrnamentItemList, new Action<TItem[]>(this.OnAddOrnamentItemList));
	}

	// Token: 0x0600FC07 RID: 64519 RVA: 0x00453C7C File Offset: 0x00451E7C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerLevelChanged, new Action<int, int, int, int, int, int, int>(this.OnPlayerLevelChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayerExpChanged, new Action<int, int, int>(this.OnPlayerExpChanged));
		Singleton<EventSystem>.Instance.Remove<PlotInfo>(EEventName.PlotNetworkStart, delegate(PlotInfo data)
		{
			this.CheckVisibility(data);
		});
		Singleton<EventSystem>.Instance.Remove<PlotResultInfo>(EEventName.PlotNetworkEnd, delegate(PlotResultInfo data)
		{
			this.CheckVisibility(data);
		});
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.OpenView, delegate(EUiViewName name, int id)
		{
			this.CheckVisibility(name, id);
		});
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, delegate(EUiViewName name, int id)
		{
			this.CheckVisibility(name, id);
		});
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, new Action(this.CheckVisibility));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddWeaponItemList, new Action<IReadOnlyList<WeaponItem>, bool, bool>(this.OnAddWeaponItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddPhantomItemList, new Action<IReadOnlyList<Aki.Protocol.PhantomItem>, bool>(this.OnAddPhantomItemList));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAddFavorItem, new Action<TItem>(this.OnAddFavorItem));
		Singleton<EventSystem>.Instance.Remove<TItem[]>(EEventName.OnAddOrnamentItemList, new Action<TItem[]>(this.OnAddOrnamentItemList));
	}

	// Token: 0x0600FC08 RID: 64520 RVA: 0x00453DB8 File Offset: 0x00451FB8
	private void OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
		addCountItemInfo.Id = 1;
		addCountItemInfo.Count = addExp;
		addCountItemInfo.IncrId = 0;
		list.Add(addCountItemInfo);
		this.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC09 RID: 64521 RVA: 0x00453DFC File Offset: 0x00451FFC
	private void OnPlayerExpChanged(int currentExp, int lastExp, int maxExp)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
		addCountItemInfo.Id = 1;
		addCountItemInfo.Count = currentExp - lastExp;
		addCountItemInfo.IncrId = 0;
		list.Add(addCountItemInfo);
		this.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC0A RID: 64522 RVA: 0x00453E40 File Offset: 0x00452040
	public void AddCommonItemList(IReadOnlyList<NormalItem> normalItemList)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (NormalItem normalItem in normalItemList)
		{
			int id = normalItem.Id;
			if (id != 1)
			{
				CommonItemData commonItemData = instance.GetCommonItemData(id, 0);
				if (commonItemData != null)
				{
					int lastCount = commonItemData.GetLastCount();
					int count = normalItem.Count;
					int num = (lastCount > 0) ? (count - lastCount) : count;
					if (num >= 0)
					{
						AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
						addCountItemInfo.Id = normalItem.Id;
						addCountItemInfo.Count = num;
						addCountItemInfo.IncrId = 0;
						list.Add(addCountItemInfo);
					}
				}
			}
		}
		ControllerBase<ItemHintController>.Instance.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC0B RID: 64523 RVA: 0x00453F0C File Offset: 0x0045210C
	public void AddCommonItemList(IReadOnlyList<ValidTimeItem> normalItemList)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		foreach (ValidTimeItem validTimeItem in normalItemList)
		{
			int id = validTimeItem.Id;
			if (id != 1)
			{
				CommonItemData commonItemData = instance.GetCommonItemData(id, 0);
				if (commonItemData != null)
				{
					int lastCount = commonItemData.GetLastCount();
					int count = validTimeItem.Count;
					int num = (lastCount > 0) ? (count - lastCount) : count;
					if (num >= 0)
					{
						AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
						addCountItemInfo.Id = validTimeItem.Id;
						addCountItemInfo.Count = num;
						addCountItemInfo.IncrId = validTimeItem.IncrId;
						list.Add(addCountItemInfo);
					}
				}
			}
		}
		ControllerBase<ItemHintController>.Instance.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC0C RID: 64524 RVA: 0x00453FE0 File Offset: 0x004521E0
	public void AddRecallItemList([TupleElementNames(new string[]
	{
		"configId",
		"addCount"
	})] [Nullable(new byte[]
	{
		1,
		0
	})] ValueTuple<int, int>[] addCountList)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (ValueTuple<int, int> valueTuple in addCountList)
		{
			int item = valueTuple.Item1;
			int item2 = valueTuple.Item2;
			if (item != 1 && item2 > 0)
			{
				AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
				addCountItemInfo.Id = item;
				addCountItemInfo.Count = item2;
				addCountItemInfo.IncrId = 0;
				list.Add(addCountItemInfo);
			}
		}
		this.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC0D RID: 64525 RVA: 0x00454058 File Offset: 0x00452258
	public void AddRoguelikeItemList(int itemId, int count)
	{
		AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
		addCountItemInfo.Id = itemId;
		addCountItemInfo.Count = count;
		addCountItemInfo.IncrId = 0;
		ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(new AddCountItemInfo[]
		{
			addCountItemInfo
		});
	}

	// Token: 0x0600FC0E RID: 64526 RVA: 0x00454094 File Offset: 0x00452294
	public void AddAbyssItemList(Dictionary<int, int> dataMap)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (KeyValuePair<int, int> keyValuePair in dataMap)
		{
			AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
			addCountItemInfo.Id = keyValuePair.Key;
			addCountItemInfo.Count = keyValuePair.Value;
			addCountItemInfo.IncrId = 0;
			list.Add(addCountItemInfo);
		}
		ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(list.ToArray());
	}

	// Token: 0x0600FC0F RID: 64527 RVA: 0x00454120 File Offset: 0x00452320
	public void AddItemRewardInfoList([Nullable(new byte[]
	{
		1,
		0
	})] List<ValueTuple<int, int>> infoList)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (ValueTuple<int, int> valueTuple in infoList)
		{
			AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
			addCountItemInfo.Id = valueTuple.Item1;
			addCountItemInfo.Count = valueTuple.Item2;
			addCountItemInfo.IncrId = 0;
			list.Add(addCountItemInfo);
		}
		ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(list.ToArray());
	}

	// Token: 0x0600FC10 RID: 64528 RVA: 0x004541AC File Offset: 0x004523AC
	private void OnAddWeaponItemList(IReadOnlyList<WeaponItem> weaponItemList, bool bAddFromRole, bool bShowNewTips)
	{
		if (bAddFromRole || !bShowNewTips)
		{
			return;
		}
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (WeaponItem weaponItem in weaponItemList)
		{
			AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
			addCountItemInfo.Id = weaponItem.Id;
			addCountItemInfo.Count = 1;
			addCountItemInfo.IncrId = 0;
			list.Add(addCountItemInfo);
		}
		this.TryOpenItemReward(list.ToArray());
	}

	// Token: 0x0600FC11 RID: 64529 RVA: 0x00454230 File Offset: 0x00452430
	private void OnAddPhantomItemList(IReadOnlyList<Aki.Protocol.PhantomItem> phantomItemList, bool isCatch)
	{
		if (!isCatch)
		{
			return;
		}
		foreach (Aki.Protocol.PhantomItem phantomItem in phantomItemList)
		{
			ModelBase<ItemModel>.Instance.PushWaitPhantomItem(phantomItem.IncrId);
		}
	}

	// Token: 0x0600FC12 RID: 64530 RVA: 0x00454288 File Offset: 0x00452488
	private void OnAddFavorItem(TItem item)
	{
		AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
		addCountItemInfo.Id = item.ItemData.ItemId;
		addCountItemInfo.Count = item.Count;
		addCountItemInfo.IncrId = 0;
		this.TryOpenItemReward(new AddCountItemInfo[]
		{
			addCountItemInfo
		});
	}

	// Token: 0x0600FC13 RID: 64531 RVA: 0x004542D0 File Offset: 0x004524D0
	private void OnAddOrnamentItemList(TItem[] itemList)
	{
		List<AddCountItemInfo> list = new List<AddCountItemInfo>();
		foreach (TItem titem in itemList)
		{
			AddCountItemInfo addCountItemInfo = AddCountItemInfo.Create();
			addCountItemInfo.Id = titem.ItemData.ItemId;
			addCountItemInfo.Count = titem.Count;
			addCountItemInfo.IncrId = 0;
			list.Add(addCountItemInfo);
		}
		ModelBase<ItemHintModel>.Instance.MainInterfaceInsertItemRewardInfo(list.ToArray());
	}

	// Token: 0x0600FC14 RID: 64532 RVA: 0x00454341 File Offset: 0x00452541
	private void CheckVisibility()
	{
		this.CheckVisibilityInternal();
	}

	// Token: 0x0600FC15 RID: 64533 RVA: 0x00454349 File Offset: 0x00452549
	private void CheckVisibility(PlotInfo plotInfo)
	{
		this.CheckVisibilityInternal();
	}

	// Token: 0x0600FC16 RID: 64534 RVA: 0x00454351 File Offset: 0x00452551
	private void CheckVisibility(PlotResultInfo plotResultInfo)
	{
		this.CheckVisibilityInternal();
	}

	// Token: 0x0600FC17 RID: 64535 RVA: 0x00454359 File Offset: 0x00452559
	private void CheckVisibility(EUiViewName viewName, int viewId)
	{
		this.CheckVisibilityInternal();
	}

	// Token: 0x0600FC18 RID: 64536 RVA: 0x00454364 File Offset: 0x00452564
	private void CheckVisibilityInternal()
	{
		bool visibility = ModelBase<ItemHintModel>.Instance.Visibility;
		bool flag = ModelBase<PlotModel>.Instance.IsInHighLevelPlot();
		bool isLoadingView = ModelBase<LoadingModel>.Instance.IsLoadingView;
		bool flag2 = this.CanShowHintOtherViewIsOpen(false);
		bool flag3 = !flag && flag2 && !isLoadingView;
		if (flag3 != visibility)
		{
			ModelBase<ItemHintModel>.Instance.Visibility = flag3;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ItemHint;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "奖励可视化状态改变";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Visibility", flag3);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.ItemHintVisibilityChange, flag3);
		}
	}

	// Token: 0x0600FC19 RID: 64537 RVA: 0x004543FC File Offset: 0x004525FC
	private bool CanShowHintOtherViewIsOpen(bool isPush = false)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BattleView))
		{
			return true;
		}
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.DangoMonopolyMainView))
		{
			return false;
		}
		ActivityDangoMonopolyConfig instance = ConfigBase<ActivityDangoMonopolyConfig>.Instance;
		if (!isPush)
		{
			return instance.GetIsOpenHintShow();
		}
		return instance.GetIsPushHintShow();
	}

	// Token: 0x0600FC1A RID: 64538 RVA: 0x00454445 File Offset: 0x00452645
	protected override void OnTick(float delta)
	{
		this.CheckItemHint();
		if (!ModelBase<ItemHintModel>.Instance.Visibility)
		{
			return;
		}
		ControllerBase<ItemController>.Instance.CheckNewItemTips();
		this.CheckItemReward();
	}

	// Token: 0x0600FC1B RID: 64539 RVA: 0x0045446C File Offset: 0x0045266C
	public void CheckItemReward()
	{
		if (ModelBase<ItemHintModel>.Instance.IsItemRewardListEmpty)
		{
			bool isPrintNoRewardReason = this.IsPrintNoRewardReason;
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemRewardView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SceneGameplayItemRewardView) || ModelBase<SundryModel>.Instance.IsBlockTips)
		{
			bool isPrintNoRewardReason2 = this.IsPrintNoRewardReason;
			return;
		}
		ItemRewardNotify itemReward = ModelBase<ItemHintModel>.Instance.PeekItemRewardListFirst().ItemReward;
		MapField<int, RewardItemInfoList> mapField = (itemReward != null) ? itemReward.RewardItems : null;
		if (mapField == null)
		{
			ModelBase<ItemHintModel>.Instance.ShiftItemRewardListFirst();
			bool isPrintNoRewardReason3 = this.IsPrintNoRewardReason;
			return;
		}
		EShowBgType? eshowBgType = null;
		foreach (int key in mapField.Keys)
		{
			RewardItemInfoList rewardItemInfoList;
			if (mapField.TryGetValue(key, out rewardItemInfoList) && rewardItemInfoList != null)
			{
				RepeatedField<RewardItemInfo> itemList = rewardItemInfoList.ItemList;
				if (itemList != null)
				{
					foreach (RewardItemInfo rewardItemInfo in itemList)
					{
						int showPlanId = rewardItemInfo.ShowPlanId;
						DropShowPlan? dropShowPlan = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropShowPlan(showPlanId);
						if (dropShowPlan == null)
						{
							Log instance = Singleton<Log>.Instance;
							ELogModule module = ELogModule.ItemHint;
							ELogAuthor author = ELogAuthor.CFT;
							string message = "缺少showPlan配置";
							ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("showPlanId", showPlanId);
							instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
						}
						else if (dropShowPlan.Value.ShowBg != 0 && rewardItemInfo.Count > 0 && eshowBgType == null)
						{
							eshowBgType = new EShowBgType?((EShowBgType)dropShowPlan.Value.ShowBg);
							break;
						}
					}
				}
			}
		}
		if (eshowBgType != null)
		{
			EShowBgType valueOrDefault = eshowBgType.GetValueOrDefault();
			if (valueOrDefault == EShowBgType.None)
			{
				bool isPrintNoRewardReason4 = this.IsPrintNoRewardReason;
				return;
			}
			if (valueOrDefault - EShowBgType.ItemReward > 2)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(this.showBgTypeToView[eshowBgType.Value].Value, null, null);
		}
	}

	// Token: 0x0600FC1C RID: 64540 RVA: 0x00454678 File Offset: 0x00452878
	public void CheckItemHint()
	{
		if (!ModelBase<ItemHintModel>.Instance.Visibility)
		{
			bool isPrintNoRewardReason = this.IsPrintNoRewardReason;
			return;
		}
		if (ModelBase<ItemHintModel>.Instance.IsMainInterfaceDataEmpty && ModelBase<ItemHintModel>.Instance.IsPriorInterfaceDataEmpty)
		{
			bool isPrintNoRewardReason2 = this.IsPrintNoRewardReason;
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemHintView))
		{
			bool isPrintNoRewardReason3 = this.IsPrintNoRewardReason;
			return;
		}
		if (ModelBase<SundryModel>.Instance.IsBlockTips)
		{
			bool isPrintNoRewardReason4 = this.IsPrintNoRewardReason;
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemHintView, null, null);
	}

	// Token: 0x04007900 RID: 30976
	public bool IsPrintNoRewardReason;

	// Token: 0x04007901 RID: 30977
	private IReadOnlyDictionary<EShowBgType, EUiViewName?> showBgTypeToView = new Dictionary<EShowBgType, EUiViewName?>
	{
		{
			EShowBgType.None,
			null
		},
		{
			EShowBgType.ItemReward,
			new EUiViewName?(EUiViewName.ItemRewardView)
		},
		{
			EShowBgType.ItemRewardWithMouse,
			new EUiViewName?(EUiViewName.ItemRewardView)
		},
		{
			EShowBgType.GameplayItemReward,
			new EUiViewName?(EUiViewName.SceneGameplayItemRewardView)
		}
	};
}
