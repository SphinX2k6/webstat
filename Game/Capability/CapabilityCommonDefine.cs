using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Capability
{
	// Token: 0x02007073 RID: 28787
	public static class CapabilityCommonDefine
	{
		// Token: 0x06045C41 RID: 285761 RVA: 0x012408F0 File Offset: 0x0123EAF0
		// Note: this type is marked as 'beforefieldinit'.
		static CapabilityCommonDefine()
		{
			Dictionary<ETickingGroup, string> dictionary = new Dictionary<ETickingGroup, string>();
			dictionary[ETickingGroup.TG_PrePhysics] = "PrePhysics";
			dictionary[ETickingGroup.TG_StartPhysics] = "StartPhysics";
			dictionary[ETickingGroup.TG_DuringPhysics] = "DuringPhysics";
			dictionary[ETickingGroup.TG_EndPhysics] = "EndPhysics";
			dictionary[ETickingGroup.TG_PostPhysics] = "PostPhysics";
			dictionary[ETickingGroup.TG_PostUpdateWork] = "PostUpdateWork";
			dictionary[ETickingGroup.TG_LastDemotable] = "LastDemotable";
			dictionary[ETickingGroup.TG_NewlySpawned] = "NewlySpawned";
			dictionary[ETickingGroup.TG_MAX] = "MAX";
			CapabilityCommonDefine.ueTickingGroupName = dictionary;
		}

		// Token: 0x04027083 RID: 159875
		[Nullable(1)]
		public static readonly IReadOnlyDictionary<ETickingGroup, string> ueTickingGroupName;

		// Token: 0x04027084 RID: 159876
		[Nullable(1)]
		public const string CAPABILITY_DEBUG_KEY = "Capability";

		// Token: 0x0200CCA9 RID: 52393
		public enum ECapabilityState
		{
			// Token: 0x0403EC70 RID: 257136
			Inactive,
			// Token: 0x0403EC71 RID: 257137
			Deactivated,
			// Token: 0x0403EC72 RID: 257138
			Active,
			// Token: 0x0403EC73 RID: 257139
			Blocked
		}

		// Token: 0x0200CCAA RID: 52394
		public enum ECapabilityDebugEvent
		{
			// Token: 0x0403EC75 RID: 257141
			Setup,
			// Token: 0x0403EC76 RID: 257142
			PreTick,
			// Token: 0x0403EC77 RID: 257143
			ShouldActivate,
			// Token: 0x0403EC78 RID: 257144
			ShouldDeactivate,
			// Token: 0x0403EC79 RID: 257145
			OnActivated,
			// Token: 0x0403EC7A RID: 257146
			OnDeactivated,
			// Token: 0x0403EC7B RID: 257147
			TickActive,
			// Token: 0x0403EC7C RID: 257148
			Blocked,
			// Token: 0x0403EC7D RID: 257149
			Unblocked,
			// Token: 0x0403EC7E RID: 257150
			Interrupted
		}
	}
}
