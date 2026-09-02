using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.InteractHandler
{
	// Token: 0x0200494A RID: 18762
	public abstract class ManipulateInteractHandlerBase : IManipulateInteractHandler
	{
		// Token: 0x060310E2 RID: 200930 RVA: 0x00C3210E File Offset: 0x00C3030E
		[NullableContext(1)]
		protected ManipulateInteractHandlerBase(IManipulateInteractContext context)
		{
		}

		// Token: 0x060310E3 RID: 200931
		public abstract bool Start();

		// Token: 0x060310E4 RID: 200932
		public abstract void End();

		// Token: 0x060310E5 RID: 200933 RVA: 0x00C32120 File Offset: 0x00C30320
		protected void ApplyInteractBuff()
		{
			string roleBody = this.Context.ActorComp.CreatureData.GetRoleConfig().Value.RoleBody;
			this.Context.CurBuffId = new long?((roleBody == "MaleXL") ? 640003013L : 640003012L);
			this.Context.BuffComp.AddBuff(this.Context.CurBuffId.Value, new AddBuffParam
			{
				InstigatorId = this.Context.CreatureDataComp.GetCreatureDataId(),
				Level = new int?(1),
				Reason = "[CharacterManipulateInteractComponent]"
			});
		}

		// Token: 0x060310E6 RID: 200934 RVA: 0x00C321D4 File Offset: 0x00C303D4
		protected void RemoveInteractBuffImmediate()
		{
			if (this.Context.BuffComp != null && this.Context.CurBuffId != null)
			{
				this.Context.BuffComp.RemoveBuff(this.Context.CurBuffId.Value, -1, "[CharacterManipulateInteractComponent]", null, null, null);
				this.Context.CurBuffId = null;
			}
		}

		// Token: 0x0401C3D6 RID: 115670
		[Nullable(1)]
		protected readonly IManipulateInteractContext Context = context;
	}
}
