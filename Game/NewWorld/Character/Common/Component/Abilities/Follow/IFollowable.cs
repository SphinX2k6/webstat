using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200496D RID: 18797
	[NullableContext(2)]
	public interface IFollowable
	{
		// Token: 0x06031275 RID: 201333
		EntityHandle GetFollower();

		// Token: 0x06031276 RID: 201334
		bool IsFollowerEnable();
	}
}
