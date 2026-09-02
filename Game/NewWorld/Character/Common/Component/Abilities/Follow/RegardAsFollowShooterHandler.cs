using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.ResponsibilityChain;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004980 RID: 18816
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegardAsFollowShooterHandler : AbstractHandler<EntityHandleParameterContext>
	{
		// Token: 0x060312C8 RID: 201416 RVA: 0x00C3E7F9 File Offset: 0x00C3C9F9
		protected override bool CanHandle(EntityHandleParameterContext context)
		{
			return FollowUtils.IsFollowShooter(context.EntityHandle);
		}

		// Token: 0x060312C9 RID: 201417 RVA: 0x00C3E806 File Offset: 0x00C3CA06
		protected override void ExecuteProcessing(EntityHandleParameterContext context)
		{
			context.OutPlayerFollowerHandlerType = new EPlayerFollowerHandlerType?(EPlayerFollowerHandlerType.FollowShooter);
		}

		// Token: 0x060312CA RID: 201418 RVA: 0x00C3E814 File Offset: 0x00C3CA14
		protected override bool ShouldStop(EntityHandleParameterContext context)
		{
			return false;
		}

		// Token: 0x060312CB RID: 201419 RVA: 0x00C3E817 File Offset: 0x00C3CA17
		protected override void ExecuteStopping(EntityHandleParameterContext context)
		{
		}
	}
}
