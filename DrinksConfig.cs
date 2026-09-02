using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000FF6 RID: 4086
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class DrinksConfig : ConfigBase<DrinksConfig>
{
	// Token: 0x060069F3 RID: 27123 RVA: 0x001BA6E8 File Offset: 0x001B88E8
	public DrinksDrinkBase? GetDrinkBase(int id)
	{
		DrinksDrinkBase? config = ConfigDrinksDrinkBaseById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksDrinkBase表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069F4 RID: 27124 RVA: 0x001BA740 File Offset: 0x001B8940
	public IReadOnlyList<DrinksDrinkBase> GetAllDrinkBase()
	{
		IReadOnlyList<DrinksDrinkBase> configList = ConfigDrinksDrinkBaseAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<DrinksDrinkBase>();
		}
		return configList;
	}

	// Token: 0x060069F5 RID: 27125 RVA: 0x001BA760 File Offset: 0x001B8960
	public DrinksBatching? GetBatching(int id)
	{
		DrinksBatching? config = ConfigDrinksBatchingById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksBatching表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069F6 RID: 27126 RVA: 0x001BA7B8 File Offset: 0x001B89B8
	public IReadOnlyList<DrinksBatching> GetAllBatching()
	{
		IReadOnlyList<DrinksBatching> configList = ConfigDrinksBatchingAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<DrinksBatching>();
		}
		return configList;
	}

	// Token: 0x060069F7 RID: 27127 RVA: 0x001BA7D8 File Offset: 0x001B89D8
	public DrinksOrnament? GetOrnament(int id)
	{
		DrinksOrnament? config = ConfigDrinksOrnamentById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksOrnament表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069F8 RID: 27128 RVA: 0x001BA830 File Offset: 0x001B8A30
	public IReadOnlyList<DrinksOrnament> GetAllOrnament()
	{
		IReadOnlyList<DrinksOrnament> configList = ConfigDrinksOrnamentAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<DrinksOrnament>();
		}
		return configList;
	}

	// Token: 0x060069F9 RID: 27129 RVA: 0x001BA850 File Offset: 0x001B8A50
	public DrinksRequireList? GetRequireList(int id)
	{
		DrinksRequireList? config = ConfigDrinksRequireListById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksRequireList表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069FA RID: 27130 RVA: 0x001BA8A8 File Offset: 0x001B8AA8
	public DrinksRoleLikeDrink? GetRoleLikeDrink(int id)
	{
		DrinksRoleLikeDrink? config = ConfigDrinksRoleLikeDrinkById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksRoleLikeDrink表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069FB RID: 27131 RVA: 0x001BA900 File Offset: 0x001B8B00
	public DrinksFlavorRange? GetFlavorRange(int id)
	{
		DrinksFlavorRange? config = ConfigDrinksFlavorRangeById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksFlavorRange表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069FC RID: 27132 RVA: 0x001BA958 File Offset: 0x001B8B58
	public IReadOnlyList<DrinksFlavorRange> GetFlavorRangeGroup(int id)
	{
		IReadOnlyList<DrinksFlavorRange> configList = ConfigDrinksFlavorRangeByGroupId.GetConfigList(id, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksFlavorRange表无效Group";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Group", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<DrinksFlavorRange>();
		}
		return configList;
	}

	// Token: 0x060069FD RID: 27133 RVA: 0x001BA9A8 File Offset: 0x001B8BA8
	public DrinksFlavorType? GetFlavorType(EDrinksFlavorType id)
	{
		DrinksFlavorType? config = ConfigDrinksFlavorTypeById.GetConfig((int)id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksFlavorType表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069FE RID: 27134 RVA: 0x001BAA00 File Offset: 0x001B8C00
	public DrinksDrinkMix? GetDrinkMix(int id)
	{
		DrinksDrinkMix? config = ConfigDrinksDrinkMixById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksDrinkMix表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x060069FF RID: 27135 RVA: 0x001BAA58 File Offset: 0x001B8C58
	public IReadOnlyList<DrinksDrinkMix> GetAllMix()
	{
		IReadOnlyList<DrinksDrinkMix> configList = ConfigDrinksDrinkMixAll.GetConfigList(true);
		if (configList == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Drinks, ELogAuthor.WHJ, "DrinksDrinkMix表无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			return Array.Empty<DrinksDrinkMix>();
		}
		return configList;
	}

	// Token: 0x06006A00 RID: 27136 RVA: 0x001BAA98 File Offset: 0x001B8C98
	public IReadOnlyList<DrinksRequireList> GetRequireListByRole(int roleId)
	{
		IReadOnlyList<DrinksRequireList> configList = ConfigDrinksRequireListByRoleId.GetConfigList(roleId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksRequireList表无效role";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("role", roleId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return Array.Empty<DrinksRequireList>();
		}
		return configList;
	}

	// Token: 0x06006A01 RID: 27137 RVA: 0x001BAAE8 File Offset: 0x001B8CE8
	public DrinksStepConfig? GetStepConfig(EDrinksPlayStep step)
	{
		DrinksStepConfig? config = ConfigDrinksStepConfigById.GetConfig((int)step, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksStepConfig表无效role";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("step", step);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06006A02 RID: 27138 RVA: 0x001BAB40 File Offset: 0x001B8D40
	public DrinksRoleInvite? GetInviteConfig(int configId)
	{
		DrinksRoleInvite? config = ConfigDrinksRoleInviteById.GetConfig(configId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksRoleInvite表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configId", configId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06006A03 RID: 27139 RVA: 0x001BAB98 File Offset: 0x001B8D98
	public DrinksRoleInvite? GetInviteConfigByRole(int id)
	{
		IReadOnlyList<DrinksRoleInvite> allInvite = this.GetAllInvite();
		for (int i = 0; i < allInvite.Count; i++)
		{
			DrinksRoleInvite value = allInvite[i];
			if (value.RoleId == id)
			{
				return new DrinksRoleInvite?(value);
			}
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Drinks;
		ELogAuthor author = ELogAuthor.WHJ;
		string message = "DrinksRoleInvite表无效roleId";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06006A04 RID: 27140 RVA: 0x001BAC10 File Offset: 0x001B8E10
	public IReadOnlyList<DrinksRoleInvite> GetAllInvite()
	{
		IReadOnlyList<DrinksRoleInvite> configList = ConfigDrinksRoleInviteAll.GetConfigList(true);
		if (configList == null)
		{
			return new List<DrinksRoleInvite>();
		}
		return configList;
	}

	// Token: 0x06006A05 RID: 27141 RVA: 0x001BAC30 File Offset: 0x001B8E30
	public DrinksDialog? GetDialog(string id)
	{
		DrinksDialog? config = ConfigDrinksDialogById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksDialog表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06006A06 RID: 27142 RVA: 0x001BAC84 File Offset: 0x001B8E84
	public DrinksParam? GetParam(int id)
	{
		DrinksParam? config = ConfigDrinksParamById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Drinks;
			ELogAuthor author = ELogAuthor.WHJ;
			string message = "DrinksParam表无效id";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06006A07 RID: 27143 RVA: 0x001BACDC File Offset: 0x001B8EDC
	public int GetFlavorMax()
	{
		return ConfigCommonParamById.GetIntConfig("DrinksFlavorMax").GetValueOrDefault(10);
	}

	// Token: 0x06006A08 RID: 27144 RVA: 0x001BAD00 File Offset: 0x001B8F00
	public int GetQTETimeLimit()
	{
		return ConfigCommonParamById.GetIntConfig("DrinksQTETimeLimit").GetValueOrDefault(9000);
	}

	// Token: 0x06006A09 RID: 27145 RVA: 0x001BAD24 File Offset: 0x001B8F24
	public int GetQTESpeed()
	{
		return ConfigCommonParamById.GetIntConfig("DrinksQTETimeSpeed").GetValueOrDefault(1500);
	}

	// Token: 0x06006A0A RID: 27146 RVA: 0x001BAD48 File Offset: 0x001B8F48
	public int GetQTESeqTime()
	{
		return ConfigCommonParamById.GetIntConfig("DrinksQTESeqTime").GetValueOrDefault(500);
	}

	// Token: 0x06006A0B RID: 27147 RVA: 0x001BAD6C File Offset: 0x001B8F6C
	public IReadOnlyList<int> GetNeedHideNpcId()
	{
		return ConfigCommonParamById.GetIntArrayConfig("DrinksNPCEntity") ?? new List<int>();
	}
}
