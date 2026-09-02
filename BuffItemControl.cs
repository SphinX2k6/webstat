using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.DeadRevive;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x020017C3 RID: 6083
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class BuffItemControl : UiControllerBase<BuffItemControl>
{
	// Token: 0x0600AC59 RID: 44121 RVA: 0x002DF5BF File Offset: 0x002DD7BF
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600AC5A RID: 44122 RVA: 0x002DF5C2 File Offset: 0x002DD7C2
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0600AC5B RID: 44123 RVA: 0x002DF5C5 File Offset: 0x002DD7C5
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<BuffItemNotify>(ENotifyMessageId.BuffItemNotify, new Action<BuffItemNotify, Net.CallbackStatus>(this.NotifyBuffItem));
		Singleton<Net>.Instance.Register<BuffItemUpdateNotify>(ENotifyMessageId.BuffItemUpdateNotify, new Action<BuffItemUpdateNotify, Net.CallbackStatus>(this.BuffItemUpdateNotify));
	}

	// Token: 0x0600AC5C RID: 44124 RVA: 0x002DF5FF File Offset: 0x002DD7FF
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BuffItemNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BuffItemUpdateNotify);
	}

	// Token: 0x0600AC5D RID: 44125 RVA: 0x002DF624 File Offset: 0x002DD824
	public void RequestUseBuffItem(int itemConfigId, int useCount, int useRoleConfigId)
	{
		BuffItemControl.<>c__DisplayClass5_0 CS$<>8__locals1 = new BuffItemControl.<>c__DisplayClass5_0();
		CS$<>8__locals1.useCount = useCount;
		BuffItemRequest buffItemRequest = BuffItemRequest.Create();
		buffItemRequest.ItemId = itemConfigId;
		buffItemRequest.Num = CS$<>8__locals1.useCount;
		buffItemRequest.RoleId = useRoleConfigId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BuffItem;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "[Inventory]客户端请求使用Buff道具";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("massage", buffItemRequest);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		Singleton<Net>.Instance.Call<BuffItemResponse>(ERequestMessageId.BuffItemRequest, buffItemRequest, new Action<BuffItemResponse, Net.CallbackStatus>(CS$<>8__locals1.<RequestUseBuffItem>g__responseBuffItem|0), 0);
	}

	// Token: 0x0600AC5E RID: 44126 RVA: 0x002DF6A4 File Offset: 0x002DD8A4
	private void NotifyBuffItem(BuffItemNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		RepeatedField<Aki.Protocol.BuffItem> itemBuffList = message.ItemBuffList;
		if (itemBuffList != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.BuffItem, ELogAuthor.YYZ, "[Inventory]服务端通知Buff道具数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			foreach (Aki.Protocol.BuffItem buffInfo in itemBuffList)
			{
				this.RefreshBuffItem(buffInfo);
			}
		}
		RepeatedField<EquipBuffItem> equipItemList = message.EquipItemList;
		if (equipItemList != null)
		{
			foreach (EquipBuffItem itemInfo in equipItemList)
			{
				this.RefreshEquipBuffItem(itemInfo, false);
			}
		}
	}

	// Token: 0x0600AC5F RID: 44127 RVA: 0x002DF760 File Offset: 0x002DD960
	private unsafe void BuffItemUpdateNotify(BuffItemUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (message.BuffItem != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BuffItem;
			ELogAuthor author = ELogAuthor.YYZ;
			string message2 = "[Inventory]服务端通知Buff道具进入CD";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ItemId", message.BuffItem.ItemId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Cd", message.BuffItem.CdTime);
			instance.Info(module, author, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.RefreshBuffItem(message.BuffItem);
		}
		RepeatedField<EquipBuffItem> equipItemList = message.EquipItemList;
		if (equipItemList != null)
		{
			foreach (EquipBuffItem itemInfo in equipItemList)
			{
				this.RefreshEquipBuffItem(itemInfo, true);
			}
		}
	}

	// Token: 0x0600AC60 RID: 44128 RVA: 0x002DF838 File Offset: 0x002DDA38
	private void RefreshBuffItem(Aki.Protocol.BuffItem buffInfo)
	{
		int itemId = buffInfo.ItemId;
		if (itemId == 0)
		{
			return;
		}
		long cdTime = buffInfo.CdTime;
		BuffItemConfig instance = ConfigBase<BuffItemConfig>.Instance;
		BuffItemModel instance2 = ModelBase<BuffItemModel>.Instance;
		Aki.Config.BuffItem? buffItemConfig = instance.GetBuffItemConfig(itemId);
		if (buffItemConfig == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BuffItem;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[Inventory]服务端通知Buff道具进入CD时，s.属性奖励表中找不到对应Buff道具";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", buffInfo.ItemId);
			instance3.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int publicCdGroup = buffItemConfig.Value.PublicCdGroup;
		if (publicCdGroup > 0)
		{
			IReadOnlyList<Aki.Config.BuffItem> buffItemConfigByPublicCdGroup = instance.GetBuffItemConfigByPublicCdGroup(publicCdGroup);
			BuffItemCdGroup? buffItemCdGroup = instance.GetBuffItemCdGroup(publicCdGroup);
			using (IEnumerator<Aki.Config.BuffItem> enumerator = buffItemConfigByPublicCdGroup.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Aki.Config.BuffItem buffItem = enumerator.Current;
					instance2.SetBuffItemCdTimeStamp(buffItem.Id, cdTime, buffItemCdGroup.Value.CoolDownTime);
				}
				return;
			}
		}
		instance2.SetBuffItemCdTimeStamp(itemId, cdTime, buffItemConfig.Value.Cd);
	}

	// Token: 0x0600AC61 RID: 44129 RVA: 0x002DF944 File Offset: 0x002DDB44
	private void RefreshEquipBuffItem(EquipBuffItem itemInfo, bool notifyUpdate = false)
	{
		int itemId = itemInfo.ItemId;
		bool equiped = itemInfo.Equiped;
		bool flag = ModelBase<BuffItemModel>.Instance.IsEquippedBuffItem(itemId);
		if (notifyUpdate)
		{
			bool flag2 = !flag && equiped;
			bool flag3 = flag && !equiped;
			if ((flag2 || flag3) && Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.InventoryView))
			{
				IReadOnlyList<BuffEquipItem> buffEquipItemByItemId = ConfigBase<BuffItemConfig>.Instance.GetBuffEquipItemByItemId(itemId);
				if (buffEquipItemByItemId.Count > 0)
				{
					string text = flag2 ? buffEquipItemByItemId[0].EquipTips : buffEquipItemByItemId[0].UnEquipTips;
					if (!StringUtils.IsEmpty(text))
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(text, Array.Empty<object>());
					}
				}
			}
		}
		ModelBase<BuffItemModel>.Instance.SetBuffEquipItem(itemId, equiped);
		Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnEquipBuffItemUpdate, itemId, equiped);
	}

	// Token: 0x0600AC62 RID: 44130 RVA: 0x002DFA14 File Offset: 0x002DDC14
	public void InitializeAllUseBuffItemRoleFromPlayerFormationInstance(int useItemConfigId)
	{
		BuffItemModel instance = ModelBase<BuffItemModel>.Instance;
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
		for (int i = 0; i < teamItems.Count; i++)
		{
			SceneTeamItem sceneTeamItem = teamItems[i];
			if (sceneTeamItem.GetConfigId <= 10000)
			{
				int position = i + 1;
				int getConfigId = sceneTeamItem.GetConfigId;
				string roleName = ModelBase<RoleModel>.Instance.GetRoleName(getConfigId, null);
				EntityHandle entityHandle = sceneTeamItem.EntityHandle;
				BaseAttributeComponent baseAttributeComponent;
				if (entityHandle == null)
				{
					baseAttributeComponent = null;
				}
				else
				{
					WorldEntity entity = entityHandle.Entity;
					baseAttributeComponent = ((entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null);
				}
				BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
				int roleLevel = 0;
				int maxAttribute = 0;
				int currentAttribute = 0;
				if (baseAttributeComponent2 != null)
				{
					roleLevel = (int)baseAttributeComponent2.GetCurrentValue(EAttributeType.Lv);
					maxAttribute = (int)baseAttributeComponent2.GetCurrentValue(EAttributeType.LifeMax);
					currentAttribute = (int)baseAttributeComponent2.GetCurrentValue(EAttributeType.Life);
				}
				instance.NewUseBuffItemRoleData(roleName, position, getConfigId, roleLevel, currentAttribute, maxAttribute, useItemConfigId, entityHandle.Entity);
			}
		}
	}

	// Token: 0x0600AC63 RID: 44131 RVA: 0x002DFAF4 File Offset: 0x002DDCF4
	public bool TryUseResurrectionItem(int roleConfigId)
	{
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("use_buff_item_id_list");
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		BuffItemModel instance2 = ModelBase<BuffItemModel>.Instance;
		BuffItemConfig instance3 = ConfigBase<BuffItemConfig>.Instance;
		bool flag = true;
		bool flag2 = true;
		double num = 3.402823466E+38;
		foreach (int num2 in intArrayConfig)
		{
			if (instance.GetItemCountByConfigId(num2, 0) > 0 && instance3.IsResurrectionItem(num2))
			{
				flag = false;
				double buffItemRemainCdTime = instance2.GetBuffItemRemainCdTime(num2);
				if (buffItemRemainCdTime <= 0.0)
				{
					flag2 = false;
					ReviveItemData param = new ReviveItemData(roleConfigId, intArrayConfig, num2);
					if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.UseReviveItemView))
					{
						Singleton<UiManager>.Instance.OpenView(EUiViewName.UseReviveItemView, param, null);
					}
					return true;
				}
				if (buffItemRemainCdTime < num)
				{
					num = buffItemRemainCdTime;
				}
			}
		}
		if (flag)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NotResurrectionItem", Array.Empty<object>());
		}
		else if (flag2)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("AllResurrectionItemInCd", new object[]
			{
				num.ToString("0")
			});
		}
		return false;
	}

	// Token: 0x040051A5 RID: 20901
	private const int TRIAL_ROLE_ID = 10000;
}
