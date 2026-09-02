using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002081 RID: 8321
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SpecialItemModel : ModelBase<SpecialItemModel>
{
	// Token: 0x0600FD84 RID: 64900 RVA: 0x004588B8 File Offset: 0x00456AB8
	protected override bool OnInit()
	{
		foreach (SpecialItemDefine.ESpecialItemType especialItemType in this.NeedLoadSpecialItemType)
		{
			Type type;
			if (SpecialItemDefine.specialItemLogic != null && SpecialItemDefine.specialItemLogic.TryGetValue(especialItemType, out type))
			{
				SpecialItemLogicBase specialItemLogicBase = (SpecialItemLogicBase)Activator.CreateInstance(type, new object[]
				{
					especialItemType
				});
				specialItemLogicBase.Init();
				this.SpecialItemLogicMap.Add(especialItemType, specialItemLogicBase);
			}
		}
		return true;
	}

	// Token: 0x0600FD85 RID: 64901 RVA: 0x00458928 File Offset: 0x00456B28
	[NullableContext(2)]
	public SpecialItemLogicBase GetSpecialItemLogic(SpecialItemDefine.ESpecialItemType itemType)
	{
		if (ConfigBase<SpecialItemConfig>.Instance.GetConfig((int)itemType) == null)
		{
			return null;
		}
		SpecialItemLogicBase specialItemLogicBase = null;
		SpecialItemLogicBase specialItemLogicBase2;
		if (this.SpecialItemLogicMap.TryGetValue(itemType, out specialItemLogicBase2))
		{
			specialItemLogicBase = specialItemLogicBase2;
		}
		Type type;
		if (specialItemLogicBase == null && SpecialItemDefine.specialItemLogic != null && SpecialItemDefine.specialItemLogic.TryGetValue(itemType, out type))
		{
			specialItemLogicBase = (SpecialItemLogicBase)Activator.CreateInstance(type, new object[]
			{
				itemType
			});
		}
		return specialItemLogicBase;
	}

	// Token: 0x0600FD86 RID: 64902 RVA: 0x00458998 File Offset: 0x00456B98
	public int? GetEquipSpecialItemId()
	{
		if (ModelBase<RouletteModel>.Instance.EquipItemType.GetValueOrDefault() == InventoryDefine.EItemType.SpecialItem)
		{
			return new int?(ModelBase<RouletteModel>.Instance.CurrentEquipItemId);
		}
		return null;
	}

	// Token: 0x0600FD87 RID: 64903 RVA: 0x004589D4 File Offset: 0x00456BD4
	protected override bool OnClear()
	{
		foreach (KeyValuePair<SpecialItemDefine.ESpecialItemType, SpecialItemLogicBase> keyValuePair in this.SpecialItemLogicMap)
		{
			keyValuePair.Value.Destroy();
		}
		this.SpecialItemLogicMap.Clear();
		return true;
	}

	// Token: 0x040079A2 RID: 31138
	private readonly Dictionary<SpecialItemDefine.ESpecialItemType, SpecialItemLogicBase> SpecialItemLogicMap = new Dictionary<SpecialItemDefine.ESpecialItemType, SpecialItemLogicBase>();

	// Token: 0x040079A3 RID: 31139
	private readonly SpecialItemDefine.ESpecialItemType[] NeedLoadSpecialItemType = Array.Empty<SpecialItemDefine.ESpecialItemType>();

	// Token: 0x040079A4 RID: 31140
	public int? TagWatchedItemId;

	// Token: 0x040079A5 RID: 31141
	[Nullable(2)]
	public EntityHandle TagWatchedEntityHandle;

	// Token: 0x040079A6 RID: 31142
	public HashSet<int> WatchedAllowTagIds = new HashSet<int>();

	// Token: 0x040079A7 RID: 31143
	public HashSet<int> WatchedBanTagIds = new HashSet<int>();
}
