using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Enum;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004973 RID: 18803
	[NullableContext(1)]
	public interface IPlayerFollowerFollowShooterHandler : IPlayerFollowerHandler
	{
		// Token: 0x06031281 RID: 201345
		bool SetFollowShooterEnable(bool enable, BPEEnableFollowShooter enableType, string reason);

		// Token: 0x06031282 RID: 201346
		[NullableContext(2)]
		EntityHandle GetFollowShooter();

		// Token: 0x06031283 RID: 201347
		bool IsFollowShooterEnable();

		// Token: 0x06031284 RID: 201348
		void AddFollowShooterCustomEntityId(string customKey, int entityId);

		// Token: 0x06031285 RID: 201349
		int? GetFollowShooterCustomEntityId(string customKey);

		// Token: 0x06031286 RID: 201350
		bool RemoveFollowShooterCustomEntityId(string customKey);
	}
}
