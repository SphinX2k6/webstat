using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.RoleLangCustomModel;
using FilterDefine;

// Token: 0x020018F3 RID: 6387
[NullableContext(1)]
[Nullable(0)]
public class RoleFilter : CommonFilter
{
	// Token: 0x0600B768 RID: 46952 RVA: 0x0030CC54 File Offset: 0x0030AE54
	protected object GetElementConfigId(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((RoleDataBase)data).GetElementInfo().Value.Id;
	}

	// Token: 0x0600B769 RID: 46953 RVA: 0x0030CC84 File Offset: 0x0030AE84
	protected object GetWeaponType(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((RoleDataBase)data).GetRoleConfig().WeaponType;
	}

	// Token: 0x0600B76A RID: 46954 RVA: 0x0030CCAC File Offset: 0x0030AEAC
	protected object GetRoleTagIdList(object data, Dictionary<int, string> currentSelectMap)
	{
		RoleDataBase roleDataBase = (RoleDataBase)data;
		return ModelBase<RoleModel>.Instance.GetRoleTagByRoleInfo(roleDataBase.GetRoleConfig());
	}

	// Token: 0x0600B76B RID: 46955 RVA: 0x0030CCD0 File Offset: 0x0030AED0
	protected object GetRoleLangCustom(object data, Dictionary<int, string> currentSelectMap)
	{
		RoleInstance roleInstance = (RoleInstance)data;
		return ModelBase<RoleLangCustomModel>.Instance.GetRoleLangType(roleInstance.GetRoleId());
	}

	// Token: 0x0600B76C RID: 46956 RVA: 0x0030CCFC File Offset: 0x0030AEFC
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Element, new TFilterConfig(this.GetElementConfigId));
		this.FilterMap.Add(FilterDefine.EFilterType.Weapon, new TFilterConfig(this.GetWeaponType));
		this.FilterMap.Add(FilterDefine.EFilterType.RoleTag, new TFilterConfig(this.GetRoleTagIdList));
		this.FilterMap.Add(FilterDefine.EFilterType.RoleLangCustomType, new TFilterConfig(this.GetRoleLangCustom));
	}
}
