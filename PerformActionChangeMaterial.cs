using System;
using System.Runtime.CompilerServices;

// Token: 0x0200318D RID: 12685
[NullableContext(1)]
[Nullable(0)]
public class PerformActionChangeMaterial : PerformAction
{
	// Token: 0x0601A4DD RID: 107741 RVA: 0x007BF17C File Offset: 0x007BD37C
	public override void Register(Entity entity)
	{
		base.Register(entity);
		CommonNpcPerformComponent component = entity.GetComponent<CommonNpcPerformComponent>();
		this.NpcMatController = component.MaterialController;
	}

	// Token: 0x0601A4DE RID: 107742 RVA: 0x007BF1A3 File Offset: 0x007BD3A3
	public override void UnRegister()
	{
		this.NpcMatController = null;
		base.UnRegister();
	}

	// Token: 0x0601A4DF RID: 107743 RVA: 0x007BF1B2 File Offset: 0x007BD3B2
	public override void Begin()
	{
		if (this.Entity == null)
		{
			return;
		}
		if (this.DaPath == "")
		{
			return;
		}
		this.Handle = this.NpcMatController.ApplyMaterialEffect(this.DaPath);
	}

	// Token: 0x0601A4E0 RID: 107744 RVA: 0x007BF1E7 File Offset: 0x007BD3E7
	public override void End()
	{
		if (this.Entity == null)
		{
			return;
		}
		if (this.DaPath == "")
		{
			return;
		}
		this.NpcMatController.RemoveMaterialEffect(this.Handle);
		this.Handle = 0;
	}

	// Token: 0x0400D407 RID: 54279
	public new EPerformActionType Type = EPerformActionType.ChangeMaterial;

	// Token: 0x0400D408 RID: 54280
	public string DaPath = "";

	// Token: 0x0400D409 RID: 54281
	public int Handle;

	// Token: 0x0400D40A RID: 54282
	[Nullable(2)]
	public NpcMaterialController NpcMatController;
}
