using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Item
{
	// Token: 0x02005B7A RID: 23418
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ItemController : UiControllerBase<ItemController>
	{
		// Token: 0x0603B341 RID: 242497 RVA: 0x00EFB50C File Offset: 0x00EF970C
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
			Singleton<EventSystem>.Instance.Add<IProto_NormalItem, bool>(EEventName.OnAddCommonItem, new Action<IProto_NormalItem, bool>(this.OnAddCommonItem));
			Singleton<EventSystem>.Instance.Add<WeaponItem, bool, bool>(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
			Singleton<EventSystem>.Instance.Add<TItem[]>(EEventName.OnAddOrnamentItemList, new Action<TItem[]>(this.OnAddOrnamentItemList));
		}

		// Token: 0x0603B342 RID: 242498 RVA: 0x00EFB58C File Offset: 0x00EF978C
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnLoadingNetDataDone, new Action(this.OnDataDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddCommonItem, new Action<IProto_NormalItem, bool>(this.OnAddCommonItem));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnAddWeaponItem, new Action<WeaponItem, bool, bool>(this.OnAddWeaponItem));
			Singleton<EventSystem>.Instance.Remove<TItem[]>(EEventName.OnAddOrnamentItemList, new Action<TItem[]>(this.OnAddOrnamentItemList));
		}

		// Token: 0x0603B343 RID: 242499 RVA: 0x00EFB609 File Offset: 0x00EF9809
		private void OnDataDone()
		{
			ModelBase<ItemModel>.Instance.LoadGetItemConfigIdList();
		}

		// Token: 0x0603B344 RID: 242500 RVA: 0x00EFB618 File Offset: 0x00EF9818
		private void OnAddCommonItem(IProto_NormalItem normalItem, bool isShowNewTips)
		{
			ItemModel instance = ModelBase<ItemModel>.Instance;
			int id = normalItem.Id;
			if (instance.IsGotItem(id))
			{
				return;
			}
			ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(id);
			if (config != null && config.GetValueOrDefault().ObtainedShow == 0)
			{
				return;
			}
			if (isShowNewTips)
			{
				this.AddNewItemTip(id);
			}
			instance.AddGetItemConfigIdList(id);
		}

		// Token: 0x0603B345 RID: 242501 RVA: 0x00EFB67C File Offset: 0x00EF987C
		private void OnAddWeaponItem(WeaponItem weaponItem, bool bAddFromRole, bool isShowNewTips)
		{
			int id = weaponItem.Id;
			ItemModel instance = ModelBase<ItemModel>.Instance;
			if (instance.IsGotItem(id))
			{
				return;
			}
			if (isShowNewTips)
			{
				this.AddNewItemTip(id);
			}
			instance.AddGetItemConfigIdList(id);
		}

		// Token: 0x0603B346 RID: 242502 RVA: 0x00EFB6B4 File Offset: 0x00EF98B4
		private void OnAddOrnamentItemList(TItem[] itemList)
		{
			ItemModel instance = ModelBase<ItemModel>.Instance;
			for (int i = 0; i < itemList.Length; i++)
			{
				int itemId = itemList[i].ItemData.ItemId;
				if (!instance.IsGotItem(itemId))
				{
					this.AddNewItemTip(itemId);
					instance.AddGetItemConfigIdList(itemId);
				}
			}
		}

		// Token: 0x0603B347 RID: 242503 RVA: 0x00EFB700 File Offset: 0x00EF9900
		[NullableContext(2)]
		public void OpenItemTipsByItemId(int itemId, bool canSkip = true, TOpenViewCallBack finishCallback = null)
		{
			ItemTipsParam itemTipsParam = new ItemTipsParam();
			itemTipsParam.ItemId = itemId;
			itemTipsParam.CanSkip = canSkip;
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.CsSyncItemTipsData, itemId, canSkip);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemTipsView, itemTipsParam, finishCallback);
		}

		// Token: 0x0603B348 RID: 242504 RVA: 0x00EFB744 File Offset: 0x00EF9944
		public void OpenTitleTipsByItemId(int titleId)
		{
			ItemTipsParam itemTipsParam = new ItemTipsParam();
			itemTipsParam.ItemId = titleId;
			itemTipsParam.CanSkip = true;
			itemTipsParam.ExtraParam = "OpenTitlePreviewView";
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemTipsView, itemTipsParam, null);
		}

		// Token: 0x0603B349 RID: 242505 RVA: 0x00EFB784 File Offset: 0x00EF9984
		[NullableContext(2)]
		public void OpenItemTipsByItemUid(int itemUid, int itemConfigId, bool canSkip = true, TOpenViewCallBack finishCallback = null)
		{
			ItemTipsParam itemTipsParam = new ItemTipsParam();
			itemTipsParam.ItemUid = itemUid;
			itemTipsParam.ItemId = itemConfigId;
			itemTipsParam.CanSkip = canSkip;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemTipsView, itemTipsParam, finishCallback);
		}

		// Token: 0x0603B34A RID: 242506 RVA: 0x00EFB7C0 File Offset: 0x00EF99C0
		[NullableContext(2)]
		public void OpenItemTipsByExtraParam(int itemUid, int itemConfigId, object extraParam, bool canSkip = true, TOpenViewCallBack finishCallback = null)
		{
			ItemTipsParam itemTipsParam = new ItemTipsParam();
			itemTipsParam.ItemUid = itemUid;
			itemTipsParam.ItemId = itemConfigId;
			itemTipsParam.ExtraParam = extraParam;
			itemTipsParam.CanSkip = canSkip;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ItemTipsView, itemTipsParam, finishCallback);
		}

		// Token: 0x0603B34B RID: 242507 RVA: 0x00EFB802 File Offset: 0x00EF9A02
		public void AddNewItemTip(int itemId)
		{
			ModelBase<ItemModel>.Instance.PushWaitItemList(itemId);
		}

		// Token: 0x0603B34C RID: 242508 RVA: 0x00EFB810 File Offset: 0x00EF9A10
		public void CheckNewItemTips()
		{
			if (ModelBase<ItemModel>.Instance.IsWaitItemListEmpty() && ModelBase<ItemModel>.Instance.IsWaitPhantomListEmpty() && ModelBase<ItemModel>.Instance.IsWaitVillageInfrTreeListEmpty())
			{
				bool isPrintNoRewardReason = this.IsPrintNoRewardReason;
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.NewItemTipsView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomTipsView) || Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VillageInfrNewTipsView) || !Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView))
			{
				bool isPrintNoRewardReason2 = this.IsPrintNoRewardReason;
				return;
			}
			if (ModelBase<SundryModel>.Instance.IsBlockTips)
			{
				bool isPrintNoRewardReason3 = this.IsPrintNoRewardReason;
				return;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("next_new_item_show_time");
			double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
			double lastCloseTimeStamp = ModelBase<ItemModel>.Instance.LastCloseTimeStamp;
			int? num = intConfig;
			double? num2 = lastCloseTimeStamp + ((num != null) ? new double?((double)num.GetValueOrDefault()) : null);
			if (serverTimeStamp < num2.GetValueOrDefault() & num2 != null)
			{
				return;
			}
			if (!ModelBase<ItemModel>.Instance.IsWaitItemListEmpty())
			{
				int? num3 = ModelBase<ItemModel>.Instance.ShiftWaitItemList();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.NewItemTipsView, num3, null);
			}
			else if (!ModelBase<ItemModel>.Instance.IsWaitPhantomListEmpty())
			{
				int? num4 = ModelBase<ItemModel>.Instance.ShiftWaitPhantomList();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomTipsView, num4, null);
			}
			else if (!ModelBase<ItemModel>.Instance.IsWaitVillageInfrTreeListEmpty())
			{
				int? num5 = ModelBase<ItemModel>.Instance.ShiftWaitVillageInfrTree();
				Singleton<UiManager>.Instance.OpenView(EUiViewName.VillageInfrNewTipsView, num5, null);
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_item_hint_get_item_first_time");
			this.LastItemHintAudioPlayedTime = new double?(Singleton<Time>.Instance.Now);
			this.LastItemHintAudioLevel = 3;
			Singleton<Log>.Instance.Info(ELogModule.Audio, ELogAuthor.YJY, "[Item] 播放新物品提示音效", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x04021602 RID: 136706
		public double? LastItemHintAudioPlayedTime;

		// Token: 0x04021603 RID: 136707
		public int LastItemHintAudioLevel;

		// Token: 0x04021604 RID: 136708
		public bool IsPrintNoRewardReason;
	}
}
