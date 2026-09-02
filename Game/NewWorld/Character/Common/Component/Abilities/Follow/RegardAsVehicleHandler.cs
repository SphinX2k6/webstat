using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.ResponsibilityChain;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004983 RID: 18819
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegardAsVehicleHandler : AbstractHandler<EntityHandleParameterContext>
	{
		// Token: 0x060312E0 RID: 201440 RVA: 0x00C3EB5C File Offset: 0x00C3CD5C
		protected override bool CanHandle(EntityHandleParameterContext context)
		{
			return context.EntityHandle.EntityType == 10;
		}

		// Token: 0x060312E1 RID: 201441 RVA: 0x00C3EB6D File Offset: 0x00C3CD6D
		protected override void ExecuteProcessing(EntityHandleParameterContext context)
		{
			context.OutPlayerFollowerHandlerType = new EPlayerFollowerHandlerType?(EPlayerFollowerHandlerType.Vehicle);
		}

		// Token: 0x060312E2 RID: 201442 RVA: 0x00C3EB7B File Offset: 0x00C3CD7B
		protected override bool ShouldStop(EntityHandleParameterContext context)
		{
			return false;
		}

		// Token: 0x060312E3 RID: 201443 RVA: 0x00C3EB7E File Offset: 0x00C3CD7E
		protected override void ExecuteStopping(EntityHandleParameterContext context)
		{
		}
	}
}
