using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.ResponsibilityChain;

// Token: 0x02003094 RID: 12436
public class InputFunctionContext : IParameterContext
{
	// Token: 0x06019A2D RID: 105005 RVA: 0x0077390F File Offset: 0x00771B0F
	[NullableContext(1)]
	public InputFunctionContext(Entity entity, int skillId)
	{
	}

	// Token: 0x06019A2E RID: 105006 RVA: 0x00773925 File Offset: 0x00771B25
	public bool IsValid()
	{
		return this.Entity.Valid;
	}

	// Token: 0x0400CC34 RID: 52276
	[Nullable(1)]
	public Entity Entity = entity;

	// Token: 0x0400CC35 RID: 52277
	public int SkillId = skillId;
}
