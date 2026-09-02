using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02003152 RID: 12626
[NullableContext(1)]
[Nullable(0)]
public class SpecialSkillXiaKongSummoned
{
	// Token: 0x0601A260 RID: 107104 RVA: 0x007ACE20 File Offset: 0x007AB020
	public void Init(EntityHandle entityHandle)
	{
		if (entityHandle.Valid && entityHandle.Entity != null)
		{
			this.EntityHandle = entityHandle;
			this.AnimComp = entityHandle.Entity.GetComponent<CharacterAnimationComponent>();
			Singleton<EventSystem>.Instance.AddWithTarget<ERemoveEntityType, EntityHandle>(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
	}

	// Token: 0x0601A261 RID: 107105 RVA: 0x007ACE78 File Offset: 0x007AB078
	public void Destroy()
	{
		EntityHandle entityHandle = this.EntityHandle;
		if (((entityHandle != null) ? entityHandle.Entity : null) != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget(this.EntityHandle, EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
		}
		this.EntityHandle = null;
		this.AnimComp = null;
	}

	// Token: 0x0601A262 RID: 107106 RVA: 0x007ACEC9 File Offset: 0x007AB0C9
	private void OnRemoveEntity(ERemoveEntityType eRemoveEntityType, EntityHandle entityHandle)
	{
		this.Destroy();
	}

	// Token: 0x0400D20A RID: 53770
	[Nullable(2)]
	public EntityHandle EntityHandle;

	// Token: 0x0400D20B RID: 53771
	[Nullable(2)]
	public CharacterAnimationComponent AnimComp;
}
