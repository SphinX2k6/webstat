using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200496C RID: 18796
	[NullableContext(1)]
	public interface IFollower
	{
		// Token: 0x06031271 RID: 201329
		void Possessed();

		// Token: 0x06031272 RID: 201330
		void UnPossessed();

		// Token: 0x06031273 RID: 201331
		bool SetEnable(bool enable, BPEEnableFollowShooter enableType, string reason);

		// Token: 0x06031274 RID: 201332
		bool GetEnable();
	}
}
