using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020033B8 RID: 13240
public class RedDotRoleHandBook : RedDotBase
{
	// Token: 0x0601B8C8 RID: 112840 RVA: 0x0083AF21 File Offset: 0x00839121
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotStart, new Action(base.EventCheck));
	}

	// Token: 0x0601B8C9 RID: 112841 RVA: 0x0083AF5B File Offset: 0x0083915B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotRefreshItemData, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotStart, new Action(base.EventCheck));
	}

	// Token: 0x0601B8CA RID: 112842 RVA: 0x0083AF98 File Offset: 0x00839198
	protected override bool OnCheck(int uId = 0)
	{
		IReadOnlyList<RoleInfo> roleListByType = ConfigBase<RoleConfig>.Instance.GetRoleListByType(ERoleType.Common);
		int count = roleListByType.Count;
		for (int i = 0; i < count; i++)
		{
			RoleInfo roleInfo = roleListByType[i];
			int id = roleInfo.Id;
			if (roleInfo.PartyId != 9)
			{
				ItemInfo? itemInfo = null;
				int num = 0;
				using (Dictionary<int, int>.Enumerator enumerator = roleInfo.ExchangeConsume().GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<int, int> keyValuePair = enumerator.Current;
						int key = keyValuePair.Key;
						int value = keyValuePair.Value;
						itemInfo = ConfigBase<ItemConfig>.Instance.GetConfig(key);
						num = value;
					}
				}
				object roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(itemInfo.Value.Id, 0);
				if (roleInstanceById == null && itemCountByConfigId >= num)
				{
					return true;
				}
			}
		}
		return false;
	}
}
