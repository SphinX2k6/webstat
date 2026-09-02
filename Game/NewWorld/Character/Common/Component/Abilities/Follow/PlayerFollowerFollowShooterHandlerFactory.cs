using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004982 RID: 18818
	public class PlayerFollowerFollowShooterHandlerFactory : IPlayerFollowerHandlerFactory<IPlayerFollowerFollowShooterHandler>
	{
		// Token: 0x060312DE RID: 201438 RVA: 0x00C3EB4C File Offset: 0x00C3CD4C
		[NullableContext(1)]
		public IPlayerFollowerFollowShooterHandler Create(int playerId)
		{
			return new PlayerFollowerFollowShooterHandler(playerId);
		}
	}
}
