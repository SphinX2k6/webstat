using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004965 RID: 18789
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class SocketTrackingInfo : ISocketTrackingInfo
	{
		// Token: 0x170083D0 RID: 33744
		// (get) Token: 0x06031204 RID: 201220 RVA: 0x00C3A764 File Offset: 0x00C38964
		// (set) Token: 0x06031205 RID: 201221 RVA: 0x00C3A76C File Offset: 0x00C3896C
		[RequiredMember]
		public WeakReference<USceneComponent> TargetComponent { get; set; }

		// Token: 0x170083D1 RID: 33745
		// (get) Token: 0x06031206 RID: 201222 RVA: 0x00C3A775 File Offset: 0x00C38975
		// (set) Token: 0x06031207 RID: 201223 RVA: 0x00C3A77D File Offset: 0x00C3897D
		[RequiredMember]
		public FName SocketName { get; set; }

		// Token: 0x06031208 RID: 201224 RVA: 0x00C3A786 File Offset: 0x00C38986
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SocketTrackingInfo()
		{
		}
	}
}
