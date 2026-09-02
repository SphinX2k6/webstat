using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497D RID: 18813
	[NullableContext(1)]
	public interface IFollowShooterAttachStrategy
	{
		// Token: 0x060312B0 RID: 201392
		void OnAttach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule, USceneComponent targetComponent);

		// Token: 0x060312B1 RID: 201393
		void OnDetach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule);

		// Token: 0x060312B2 RID: 201394
		float? UpdateTransform(USceneComponent sceneComponent, IUpdateRotationParams @params);
	}
}
