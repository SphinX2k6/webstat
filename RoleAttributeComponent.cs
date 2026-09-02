using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020031E3 RID: 12771
[NullableContext(1)]
[Nullable(0)]
public class RoleAttributeComponent : CharacterAttributeComponent
{
	// Token: 0x0601A79A RID: 108442 RVA: 0x007D2211 File Offset: 0x007D0411
	public override void CollectBoundsLockers(EAttributeType attrId, List<IBoundsLocker> output)
	{
		base.CollectBoundsLockers(attrId, output);
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		PlayerAttributeComponent playerAttributeComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerAttributeComponent>() : null;
		if (playerAttributeComponent == null)
		{
			return;
		}
		playerAttributeComponent.CollectBoundsLockers(attrId, output);
	}

	// Token: 0x0601A79B RID: 108443 RVA: 0x007D2247 File Offset: 0x007D0447
	public override void CollectModifiers(EAttributeType attrId, List<CharacterAttributeTypes.IModifier> output)
	{
		base.CollectModifiers(attrId, output);
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		PlayerAttributeComponent playerAttributeComponent = (playerEntity != null) ? playerEntity.GetComponent<PlayerAttributeComponent>() : null;
		if (playerAttributeComponent == null)
		{
			return;
		}
		playerAttributeComponent.CollectModifiers(attrId, output);
	}

	// Token: 0x0601A79C RID: 108444 RVA: 0x007D227D File Offset: 0x007D047D
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		RoleAttributeComponent roleAttributeComponent = (RoleAttributeComponent)componentTemplate;
		return true;
	}
}
