using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004975 RID: 18805
	[NullableContext(1)]
	public interface IPlayerFollowerHandlerFactory<[Nullable(0)] out T> where T : IPlayerFollowerHandler
	{
		// Token: 0x06031288 RID: 201352
		T Create(int playerId);
	}
}
