using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020012D3 RID: 4819
[NullableContext(1)]
[Nullable(0)]
public class AbyssPluginItemInfo : AttributeItemData
{
	// Token: 0x0600819B RID: 33179 RVA: 0x0022467F File Offset: 0x0022287F
	public AbyssPluginItemInfo(Aki.Protocol.AbyssPluginItemInfo data) : base(data.ItemId, data.IncrId, data.FuncValue, InventoryDefine.EItemDataType.DangoAbyssItem)
	{
		this.Count = data.Count;
	}

	// Token: 0x0600819C RID: 33180 RVA: 0x002246A7 File Offset: 0x002228A7
	public void SetRoleId(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x0600819D RID: 33181 RVA: 0x002246B0 File Offset: 0x002228B0
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0600819E RID: 33182 RVA: 0x002246B8 File Offset: 0x002228B8
	public int GetItemId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600819F RID: 33183 RVA: 0x002246C0 File Offset: 0x002228C0
	public override TItemConfig GetConfig()
	{
		return ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(this.ConfigId).Value;
	}

	// Token: 0x060081A0 RID: 33184 RVA: 0x002246EC File Offset: 0x002228EC
	public override InventoryDefine.EItemMainTypeId? GetMainType()
	{
		return null;
	}

	// Token: 0x060081A1 RID: 33185 RVA: 0x00224702 File Offset: 0x00222902
	public override InventoryDefine.EItemType? GetType()
	{
		return new InventoryDefine.EItemType?(InventoryDefine.EItemType.AbyssItem);
	}

	// Token: 0x060081A2 RID: 33186 RVA: 0x00224710 File Offset: 0x00222910
	public override int GetSortIndex()
	{
		TypeInfo? itemTypeConfig = base.GetItemTypeConfig();
		if (itemTypeConfig == null)
		{
			return 0;
		}
		return itemTypeConfig.Value.SortIndex;
	}

	// Token: 0x060081A3 RID: 33187 RVA: 0x00224740 File Offset: 0x00222940
	[NullableContext(0)]
	public override Span<int> GetItemAccess()
	{
		return default(Span<int>);
	}

	// Token: 0x060081A4 RID: 33188 RVA: 0x00224756 File Offset: 0x00222956
	public override int GetMaxStackCount()
	{
		return 1;
	}

	// Token: 0x060081A5 RID: 33189 RVA: 0x00224759 File Offset: 0x00222959
	public override int GetUseCountLimit()
	{
		return 1;
	}

	// Token: 0x060081A6 RID: 33190 RVA: 0x0022475C File Offset: 0x0022295C
	public override InventoryDefine.ERedDotDisableRule GetRedDotDisableRule()
	{
		return InventoryDefine.ERedDotDisableRule.AfterSelect;
	}

	// Token: 0x060081A7 RID: 33191 RVA: 0x0022475F File Offset: 0x0022295F
	public override bool IsValid()
	{
		return true;
	}

	// Token: 0x060081A8 RID: 33192 RVA: 0x00224762 File Offset: 0x00222962
	public override bool HasRedDot()
	{
		return false;
	}

	// Token: 0x060081A9 RID: 33193 RVA: 0x00224768 File Offset: 0x00222968
	public override int GetQuality()
	{
		return this.GetConfig().As<AbyssItem>().Value.QualityId;
	}

	// Token: 0x060081AA RID: 33194 RVA: 0x00224790 File Offset: 0x00222990
	public ConfigPropValue[] GetProp()
	{
		return this.GetConfig().As<AbyssItem>().Value.Prop();
	}

	// Token: 0x060081AB RID: 33195 RVA: 0x002247B8 File Offset: 0x002229B8
	public int GetBelongRole()
	{
		return this.GetConfig().As<AbyssItem>().Value.BelongLittleRole;
	}

	// Token: 0x060081AC RID: 33196 RVA: 0x002247E0 File Offset: 0x002229E0
	public bool GetCanRecovery()
	{
		return this.RoleId <= 0 && !this.GetIsLock();
	}

	// Token: 0x060081AD RID: 33197 RVA: 0x002247F8 File Offset: 0x002229F8
	public string GetFormationCoreBgPath()
	{
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(this.GetQuality());
		return ((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssCoreItemFormationBg : null) ?? "";
	}

	// Token: 0x060081AE RID: 33198 RVA: 0x0022483C File Offset: 0x00222A3C
	public string GetFormationBgPath()
	{
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(this.GetQuality());
		return ((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssItemFormationBg : null) ?? "";
	}

	// Token: 0x060081AF RID: 33199 RVA: 0x00224880 File Offset: 0x00222A80
	public string GetFormationBgColor()
	{
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(this.GetQuality());
		return ((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssItemFormationBgColor : null) ?? "";
	}

	// Token: 0x060081B0 RID: 33200 RVA: 0x002248C4 File Offset: 0x00222AC4
	public string GetPassiveSkillDesc()
	{
		string passiveBuffShowDesc = this.GetConfig().As<AbyssItem>().Value.PassiveBuffShowDesc;
		if (passiveBuffShowDesc == "")
		{
			return "";
		}
		string[] passiveSkillDescAdd = this.GetPassiveSkillDescAdd();
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(passiveBuffShowDesc, null), passiveSkillDescAdd);
	}

	// Token: 0x060081B1 RID: 33201 RVA: 0x00224914 File Offset: 0x00222B14
	public string GetBgDesc()
	{
		string bgDescription = this.GetConfig().As<AbyssItem>().Value.BgDescription;
		if (bgDescription == "")
		{
			return "";
		}
		string[] passiveSkillDescAdd = this.GetPassiveSkillDescAdd();
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(bgDescription, null), passiveSkillDescAdd);
	}

	// Token: 0x060081B2 RID: 33202 RVA: 0x00224964 File Offset: 0x00222B64
	private string[] GetPassiveSkillDescAdd()
	{
		AbyssItem value = this.GetConfig().As<AbyssItem>().Value;
		if (value.LevelDescStrArray().Length > 0)
		{
			int j = 0;
			StringArray? stringArray = value.LevelDescStrArray(j);
			if (stringArray != null)
			{
				StringArray value2 = stringArray.Value;
				int arrayStringLength = value2.ArrayStringLength;
				string[] array = new string[arrayStringLength];
				for (int i = 0; i < arrayStringLength; i++)
				{
					array[i] = value2.ArrayString(i);
				}
				return array;
			}
		}
		return Array.Empty<string>();
	}

	// Token: 0x060081B3 RID: 33203 RVA: 0x002249E7 File Offset: 0x00222BE7
	[NullableContext(2)]
	public override InventoryDefine.IItemViewDataInfo GetItemViewDataInfo(ItemViewDefine.EItemOperationMode viewMode)
	{
		return null;
	}

	// Token: 0x04003DCB RID: 15819
	private int RoleId;
}
