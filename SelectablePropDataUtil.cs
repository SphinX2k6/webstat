using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02001A06 RID: 6662
[NullableContext(1)]
[Nullable(0)]
public class SelectablePropDataUtil : IStaticVariableResetter
{
	// Token: 0x0600BEE2 RID: 48866 RVA: 0x003283DE File Offset: 0x003265DE
	static SelectablePropDataUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SelectablePropDataUtil.CreateStaticDefaultValue), new Action(SelectablePropDataUtil.ResetStaticDefaultValue));
	}

	// Token: 0x0600BEE3 RID: 48867 RVA: 0x003283FD File Offset: 0x003265FD
	public static void CreateStaticDefaultValue()
	{
		SelectablePropDataUtil.TickIntervalTimeInternal = null;
		SelectablePropDataUtil.TickMaxTimeInternal = null;
		SelectablePropDataUtil.TickMinTimeInternal = null;
	}

	// Token: 0x0600BEE4 RID: 48868 RVA: 0x00328420 File Offset: 0x00326620
	public static void ResetStaticDefaultValue()
	{
		SelectablePropDataUtil.TickIntervalTimeInternal = null;
		SelectablePropDataUtil.TickMaxTimeInternal = null;
		SelectablePropDataUtil.TickMinTimeInternal = null;
	}

	// Token: 0x17000F9A RID: 3994
	// (get) Token: 0x0600BEE5 RID: 48869 RVA: 0x00328443 File Offset: 0x00326643
	public static int TickMaxTime
	{
		get
		{
			if (SelectablePropDataUtil.TickMaxTimeInternal == null)
			{
				SelectablePropDataUtil.TickMaxTimeInternal = ConfigBase<CommonConfig>.Instance.GetSelectablePropItemTickMaxTime();
			}
			return SelectablePropDataUtil.TickMaxTimeInternal.Value;
		}
	}

	// Token: 0x17000F9B RID: 3995
	// (get) Token: 0x0600BEE6 RID: 48870 RVA: 0x0032846A File Offset: 0x0032666A
	public static int TickMinTime
	{
		get
		{
			if (SelectablePropDataUtil.TickMinTimeInternal == null)
			{
				SelectablePropDataUtil.TickMinTimeInternal = ConfigBase<CommonConfig>.Instance.GetSelectablePropItemTickMinTime();
			}
			return SelectablePropDataUtil.TickMinTimeInternal.Value;
		}
	}

	// Token: 0x17000F9C RID: 3996
	// (get) Token: 0x0600BEE7 RID: 48871 RVA: 0x00328491 File Offset: 0x00326691
	public static int TickInternalTime
	{
		get
		{
			if (SelectablePropDataUtil.TickIntervalTimeInternal == null)
			{
				SelectablePropDataUtil.TickIntervalTimeInternal = ConfigBase<CommonConfig>.Instance.GetSelectablePropItemTickIntervalTime();
			}
			return SelectablePropDataUtil.TickIntervalTimeInternal.Value;
		}
	}

	// Token: 0x0600BEE8 RID: 48872 RVA: 0x003284B8 File Offset: 0x003266B8
	[return: Nullable(2)]
	public static SelectablePropData GetSelectablePropData(ItemDataBase itemData)
	{
		InventoryDefine.EItemDataType itemDataType = itemData.GetItemDataType();
		if (itemDataType == InventoryDefine.EItemDataType.WeaponItem)
		{
			return SelectablePropDataUtil.WeaponPropData(itemData.GetUniqueId());
		}
		if (itemDataType == InventoryDefine.EItemDataType.PhantomItem)
		{
			return SelectablePropDataUtil.PhantomPropData(itemData.GetUniqueId(), itemData.GetCount());
		}
		if (itemDataType == InventoryDefine.EItemDataType.DangoAbyssItem)
		{
			return SelectablePropDataUtil.DangoAbyssItemPropData(itemData);
		}
		return SelectablePropDataUtil.MaterialPropData(itemData.GetConfigId(), itemData.GetCount());
	}

	// Token: 0x0600BEE9 RID: 48873 RVA: 0x00328510 File Offset: 0x00326710
	protected static SelectablePropData WeaponPropData(int incId)
	{
		SelectablePropData selectablePropData = new SelectablePropData();
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId);
		if (weaponDataByIncId == null)
		{
			return selectablePropData;
		}
		selectablePropData.IncId = incId;
		selectablePropData.ItemId = weaponDataByIncId.GetItemId();
		selectablePropData.ItemDataType = InventoryDefine.EItemDataType.WeaponItem;
		selectablePropData.ResonanceLevel = weaponDataByIncId.GetResonanceLevel();
		selectablePropData.LevelText = ConfigBase<TextConfig>.Instance.GetTextById("LevelShow").Replace("{0}", weaponDataByIncId.GetLevel().ToString());
		selectablePropData.RoleId = weaponDataByIncId.GetRoleId();
		return selectablePropData;
	}

	// Token: 0x0600BEEA RID: 48874 RVA: 0x00328594 File Offset: 0x00326794
	[NullableContext(2)]
	protected static SelectablePropData PhantomPropData(int incId, int count)
	{
		PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(incId);
		if (phantomBattleData == null)
		{
			return null;
		}
		return new SelectablePropData
		{
			IncId = incId,
			ItemId = phantomBattleData.GetConfigId(false),
			ItemDataType = InventoryDefine.EItemDataType.PhantomItem,
			LevelText = ConfigBase<TextConfig>.Instance.GetTextById("LevelShow").Replace("{0}", phantomBattleData.GetPhantomLevel().ToString()),
			Count = count
		};
	}

	// Token: 0x0600BEEB RID: 48875 RVA: 0x00328608 File Offset: 0x00326808
	[return: Nullable(2)]
	protected static SelectablePropData DangoAbyssItemPropData(ItemDataBase itemData)
	{
		AbyssPluginItemInfo pluginItemInfoById = ModelBase<DangoAbyssModel>.Instance.GetPluginItemInfoById(itemData.GetUniqueId());
		if (pluginItemInfoById == null)
		{
			return null;
		}
		return new SelectablePropData
		{
			IncId = itemData.GetUniqueId(),
			ItemId = itemData.GetConfigId(),
			ItemDataType = itemData.GetItemDataType(),
			RoleId = pluginItemInfoById.GetRoleId()
		};
	}

	// Token: 0x0600BEEC RID: 48876 RVA: 0x00328660 File Offset: 0x00326860
	protected static SelectablePropData MaterialPropData(int configId, int count)
	{
		return new SelectablePropData
		{
			IncId = 0,
			LevelText = count.ToString(),
			ItemDataType = InventoryDefine.EItemDataType.CommonItem,
			ItemId = configId,
			Count = count
		};
	}

	// Token: 0x040059C0 RID: 22976
	private static int? TickMaxTimeInternal;

	// Token: 0x040059C1 RID: 22977
	private static int? TickMinTimeInternal;

	// Token: 0x040059C2 RID: 22978
	private static int? TickIntervalTimeInternal;
}
