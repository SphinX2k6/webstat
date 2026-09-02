using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;

// Token: 0x020031BA RID: 12730
[NullableContext(1)]
[Nullable(0)]
public class InterestItemEntity : InterestItemBase
{
	// Token: 0x170023E2 RID: 9186
	// (get) Token: 0x0601A661 RID: 108129 RVA: 0x007C8DED File Offset: 0x007C6FED
	public override EInterestItemType Type
	{
		get
		{
			return EInterestItemType.Entity;
		}
	}

	// Token: 0x0601A662 RID: 108130 RVA: 0x007C8DF0 File Offset: 0x007C6FF0
	public override bool GetLocation(Vector outVector)
	{
		Entity entity = this.GetEntity();
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent == null)
		{
			return false;
		}
		outVector.DeepCopy(baseActorComponent.ActorLocationProxy);
		return true;
	}

	// Token: 0x0601A663 RID: 108131 RVA: 0x007C8E22 File Offset: 0x007C7022
	public override string GetDebugInfo()
	{
		return this.PbDataId.ToString();
	}

	// Token: 0x0601A664 RID: 108132 RVA: 0x007C8E2F File Offset: 0x007C702F
	[NullableContext(2)]
	public Entity GetEntity()
	{
		if (this.PbDataId == -1)
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return null;
			}
			return baseCharacter.GetEntityNoBlueprint();
		}
		else
		{
			EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.PbDataId);
			if (entityByPbDataId == null)
			{
				return null;
			}
			return entityByPbDataId.Entity;
		}
	}

	// Token: 0x0400D508 RID: 54536
	public int PbDataId;
}
