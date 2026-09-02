using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BA6 RID: 7078
[NullableContext(2)]
[Nullable(0)]
public class FloroRanchActionDataBase : FloroRanchAsyncActionBase
{
	// Token: 0x0600CDDC RID: 52700 RVA: 0x0036D811 File Offset: 0x0036BA11
	[NullableContext(1)]
	public FloroRanchActionDataBase(FloroRanchUnitActionMsg actionData)
	{
		this.ActionType = actionData.UnitActionType;
		this.CasterEntityId = actionData.Caster;
	}

	// Token: 0x0600CDDD RID: 52701 RVA: 0x0036D831 File Offset: 0x0036BA31
	public void SetIgnoreCasterEntityAnim(int entityId)
	{
		this.IsIgnoreCasterAnim = (entityId == this.CasterEntity.EntityId);
	}

	// Token: 0x1700109A RID: 4250
	// (get) Token: 0x0600CDDE RID: 52702 RVA: 0x0036D847 File Offset: 0x0036BA47
	public FloroRanchEntityBase CasterEntity
	{
		get
		{
			return ModelBase<FloroRanchGamePlayModel>.Instance.GetEntity(this.CasterEntityId);
		}
	}

	// Token: 0x04006248 RID: 25160
	public FloroRanchUnitActionType ActionType;

	// Token: 0x04006249 RID: 25161
	protected bool IsIgnoreCasterAnim;

	// Token: 0x0400624A RID: 25162
	private readonly int CasterEntityId;
}
