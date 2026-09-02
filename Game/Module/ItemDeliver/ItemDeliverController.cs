using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.ItemDeliver
{
	// Token: 0x02005B66 RID: 23398
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ItemDeliverController : UiControllerBase<ItemDeliverController>
	{
		// Token: 0x0603B2EB RID: 242411 RVA: 0x00EF9990 File Offset: 0x00EF7B90
		public void HandInItemRequest(GeneralContext context, List<PbHandInItem> handInItem, [Nullable(2)] Action<bool> onResponseCallback = null)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.GeneralLogicTree)
			{
				Action<bool> onResponseCallback2 = onResponseCallback;
				if (onResponseCallback2 == null)
				{
					return;
				}
				onResponseCallback2(false);
				return;
			}
			else
			{
				GeneralLogicTreeContext generalLogicTreeContext = context as GeneralLogicTreeContext;
				if (generalLogicTreeContext == null)
				{
					Singleton<Log>.Instance.Warn(ELogModule.Item, ELogAuthor.LRX, "ItemDeliverController::HandInItemRequest context is " + context.GetType().Name + ", not GeneralLogicTreeContext", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				int? behaviorTreeOwnerId = ModelBase<GeneralLogicTreeModel>.Instance.GetBehaviorTreeOwnerId(new long?(generalLogicTreeContext.TreeIncId));
				HandInItemRequest handInItemRequest = Aki.Protocol.HandInItemRequest.Create();
				handInItemRequest.TreeOwnerId = behaviorTreeOwnerId.Value;
				handInItemRequest.TreeIncId = generalLogicTreeContext.TreeIncId;
				handInItemRequest.NodeId = generalLogicTreeContext.NodeId;
				handInItemRequest.HandInItem.AddRange(handInItem);
				Singleton<Net>.Instance.Call<HandInItemResponse>(ERequestMessageId.HandInItemRequest, handInItemRequest, delegate(HandInItemResponse response, Net.CallbackStatus _)
				{
					if (response == null)
					{
						Action<bool> onResponseCallback3 = onResponseCallback;
						if (onResponseCallback3 == null)
						{
							return;
						}
						onResponseCallback3(false);
						return;
					}
					else if (response.ErrorId != Aki.Protocol.ErrorCode.Success)
					{
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorId, EResponseMessageId.HandInItemResponse, null, true, true);
						Action<bool> onResponseCallback4 = onResponseCallback;
						if (onResponseCallback4 == null)
						{
							return;
						}
						onResponseCallback4(false);
						return;
					}
					else
					{
						Action<bool> onResponseCallback5 = onResponseCallback;
						if (onResponseCallback5 == null)
						{
							return;
						}
						onResponseCallback5(true);
						return;
					}
				}, 0);
				return;
			}
		}

		// Token: 0x0603B2EC RID: 242412 RVA: 0x00EF9A74 File Offset: 0x00EF7C74
		public void ItemUseRequest(GeneralContext context, int itemConfigId, int itemCount, [Nullable(2)] Action<bool> onResponseCallback = null)
		{
			if (context.Type.GetValueOrDefault() == EGeneralContextType.Entity)
			{
				ItemUseRequest request = Aki.Protocol.ItemUseRequest.Create();
				request.Count = 1;
				request.ItemId = itemConfigId;
				request.Count = itemCount;
				Singleton<Net>.Instance.Call<ItemUseResponse>(ERequestMessageId.ItemUseRequest, request, delegate(ItemUseResponse response, Net.CallbackStatus _)
				{
					if (response == null)
					{
						Action<bool> onResponseCallback3 = onResponseCallback;
						if (onResponseCallback3 == null)
						{
							return;
						}
						onResponseCallback3(false);
						return;
					}
					else
					{
						if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
						{
							Action<bool> onResponseCallback4 = onResponseCallback;
							if (onResponseCallback4 != null)
							{
								onResponseCallback4(true);
							}
							Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnDeliveryProps, request.ItemId);
							return;
						}
						ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, EResponseMessageId.ItemUseResponse, null, true, true);
						Action<bool> onResponseCallback5 = onResponseCallback;
						if (onResponseCallback5 == null)
						{
							return;
						}
						onResponseCallback5(false);
						return;
					}
				}, 0);
				return;
			}
			Action<bool> onResponseCallback2 = onResponseCallback;
			if (onResponseCallback2 == null)
			{
				return;
			}
			onResponseCallback2(false);
		}

		// Token: 0x0603B2ED RID: 242413 RVA: 0x00EF9B00 File Offset: 0x00EF7D00
		[NullableContext(0)]
		public UniTask<bool> OpenItemDeliverView([Nullable(1)] DeliverData itemDeliverData)
		{
			ItemDeliverController.<OpenItemDeliverView>d__2 <OpenItemDeliverView>d__;
			<OpenItemDeliverView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenItemDeliverView>d__.itemDeliverData = itemDeliverData;
			<OpenItemDeliverView>d__.<>1__state = -1;
			<OpenItemDeliverView>d__.<>t__builder.Start<ItemDeliverController.<OpenItemDeliverView>d__2>(ref <OpenItemDeliverView>d__);
			return <OpenItemDeliverView>d__.<>t__builder.Task;
		}

		// Token: 0x0603B2EE RID: 242414 RVA: 0x00EF9B44 File Offset: 0x00EF7D44
		[NullableContext(2)]
		[return: Nullable(0)]
		public UniTask<bool> OpenItemDeliverViewByHandInItem([Nullable(1)] List<IHandInItem> items, [Nullable(1)] string npcName, string titleTextId = null, string descriptionTextId = null, GeneralContext content = null)
		{
			ItemDeliverController.<OpenItemDeliverViewByHandInItem>d__3 <OpenItemDeliverViewByHandInItem>d__;
			<OpenItemDeliverViewByHandInItem>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenItemDeliverViewByHandInItem>d__.<>4__this = this;
			<OpenItemDeliverViewByHandInItem>d__.items = items;
			<OpenItemDeliverViewByHandInItem>d__.npcName = npcName;
			<OpenItemDeliverViewByHandInItem>d__.titleTextId = titleTextId;
			<OpenItemDeliverViewByHandInItem>d__.descriptionTextId = descriptionTextId;
			<OpenItemDeliverViewByHandInItem>d__.content = content;
			<OpenItemDeliverViewByHandInItem>d__.<>1__state = -1;
			<OpenItemDeliverViewByHandInItem>d__.<>t__builder.Start<ItemDeliverController.<OpenItemDeliverViewByHandInItem>d__3>(ref <OpenItemDeliverViewByHandInItem>d__);
			return <OpenItemDeliverViewByHandInItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603B2EF RID: 242415 RVA: 0x00EF9BB4 File Offset: 0x00EF7DB4
		[NullableContext(2)]
		public void OpenItemDeliverViewByHandInGroup([Nullable(1)] IHandInGroup handInGroup, [Nullable(1)] string npcName, string titleTextId = null, string descriptionTextId = null, GeneralContext content = null)
		{
			if (handInGroup == null)
			{
				return;
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ItemDeliverView))
			{
				return;
			}
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			DeliverData deliverData = new DeliverData(npcName, titleTextId, descriptionTextId, content);
			EHandInItemType handInType = handInGroup.HandInType;
			List<int> itemIds = handInGroup.ItemIds;
			int count = handInGroup.Count;
			for (int i = 0; i < handInGroup.Slot; i++)
			{
				if (handInType == EHandInItemType.ItemIds)
				{
					DeliverSlotData deliverSlotData = deliverData.AddSlotData(itemIds, count, handInType);
					if (itemIds.Count == 1)
					{
						int itemConfigId = itemIds[0];
						int itemCountByConfigId = instance.GetItemCountByConfigId(itemConfigId, 0);
						if (deliverSlotData != null)
						{
							deliverSlotData.SetItem(itemConfigId, Math.Min(count, itemCountByConfigId));
						}
					}
				}
				else if (handInType == EHandInItemType.ItemType)
				{
					List<int> list = new List<int>();
					ItemConfig instance2 = ConfigBase<ItemConfig>.Instance;
					foreach (int itemType in itemIds)
					{
						foreach (ItemInfo itemInfo in instance2.GetConfigListByItemType(itemType))
						{
							int id = itemInfo.Id;
							list.Add(id);
						}
					}
					deliverData.AddSlotData(list, count, handInType);
				}
			}
			this.OpenItemDeliverView(deliverData);
		}
	}
}
