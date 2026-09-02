using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497E RID: 18814
	[NullableContext(1)]
	public interface ISocketTrackingInfo
	{
		// Token: 0x170083E1 RID: 33761
		// (get) Token: 0x060312B3 RID: 201395
		// (set) Token: 0x060312B4 RID: 201396
		WeakReference<USceneComponent> TargetComponent { get; set; }

		// Token: 0x170083E2 RID: 33762
		// (get) Token: 0x060312B5 RID: 201397
		// (set) Token: 0x060312B6 RID: 201398
		FName SocketName { get; set; }
	}
}
