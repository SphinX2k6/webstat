using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004985 RID: 18821
	public class PlayerFollowerVehicleHandlerFactory : IPlayerFollowerHandlerFactory<IPlayerFollowerVehicleHandler>
	{
		// Token: 0x060312EF RID: 201455 RVA: 0x00C3EED8 File Offset: 0x00C3D0D8
		[NullableContext(1)]
		public IPlayerFollowerVehicleHandler Create(int playerId)
		{
			return new PlayerFollowerVehicleHandler();
		}
	}
}
