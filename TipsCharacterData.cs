using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02001989 RID: 6537
[NullableContext(1)]
[Nullable(0)]
public class TipsCharacterData : ItemTipsData
{
	// Token: 0x0600BBE7 RID: 48103 RVA: 0x0031EA14 File Offset: 0x0031CC14
	public TipsCharacterData(ItemTipsParam data) : base(data)
	{
		this.ItemType = EItemTipsType.Character;
		RoleConfig instance = ConfigBase<RoleConfig>.Instance;
		RoleInfo? roleConfig = instance.GetRoleConfig(this.ConfigId);
		int parentId = roleConfig.Value.ParentId;
		if (parentId > 0)
		{
			roleConfig = instance.GetRoleConfig(parentId);
		}
		int elementId = roleConfig.Value.ElementId;
		this.RoleName = roleConfig.Value.Name;
		this.ElementConfig = ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(elementId);
		this.RoleHeadTexturePath = roleConfig.Value.RoleHeadIconBig;
		this.RoleIntroduction = roleConfig.Value.Introduction;
	}

	// Token: 0x0600BBE8 RID: 48104 RVA: 0x0031EAE4 File Offset: 0x0031CCE4
	public string GetRoleName()
	{
		return this.RoleName;
	}

	// Token: 0x0600BBE9 RID: 48105 RVA: 0x0031EAEC File Offset: 0x0031CCEC
	public ElementInfo GetElementConfig()
	{
		return this.ElementConfig.Value;
	}

	// Token: 0x0600BBEA RID: 48106 RVA: 0x0031EAF9 File Offset: 0x0031CCF9
	public string GetHeadTexutePath()
	{
		return this.RoleHeadTexturePath;
	}

	// Token: 0x0600BBEB RID: 48107 RVA: 0x0031EB01 File Offset: 0x0031CD01
	public string GetRoleIntroduction()
	{
		return this.RoleIntroduction;
	}

	// Token: 0x040058F3 RID: 22771
	private readonly string RoleName = "";

	// Token: 0x040058F4 RID: 22772
	private readonly ElementInfo? ElementConfig;

	// Token: 0x040058F5 RID: 22773
	private readonly string RoleHeadTexturePath = "";

	// Token: 0x040058F6 RID: 22774
	private readonly string RoleIntroduction = "";
}
