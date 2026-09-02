using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020031FC RID: 12796
public class RolePartyComponent : EntityComponent
{
	// Token: 0x0601A8BA RID: 108730 RVA: 0x007DB73C File Offset: 0x007D993C
	protected override bool OnStart()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		BaseTagComponent baseTagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		RoleInfo? roleConfig = component.GetRoleConfig();
		Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(roleConfig.Value.PartyId);
		if (influenceConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "势力.xlsx配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RoleId", component.GetRoleId());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return true;
		}
		for (int i = 0; i < influenceConfig.Value.PartyTagsLength; i++)
		{
			baseTagComponent.AddTag(new int?(influenceConfig.Value.PartyTags(i)));
		}
		return true;
	}

	// Token: 0x0601A8BB RID: 108731 RVA: 0x007DB7FC File Offset: 0x007D99FC
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RolePartyComponent rolePartyComponent = (RolePartyComponent)componentTemplate;
		return true;
	}
}
