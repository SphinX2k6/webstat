using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Movement;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA4 RID: 19108
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoGridRelocationRequest : IWuWaGoGridRelocationRequest, IWuWaGoGridRelocationContext
	{
		// Token: 0x170084D7 RID: 34007
		// (get) Token: 0x06031D37 RID: 204087 RVA: 0x00C7995C File Offset: 0x00C77B5C
		// (set) Token: 0x06031D38 RID: 204088 RVA: 0x00C79964 File Offset: 0x00C77B64
		[RequiredMember]
		public WuWaGoGrid Grid { get; set; }

		// Token: 0x170084D8 RID: 34008
		// (get) Token: 0x06031D39 RID: 204089 RVA: 0x00C7996D File Offset: 0x00C77B6D
		// (set) Token: 0x06031D3A RID: 204090 RVA: 0x00C79975 File Offset: 0x00C77B75
		[RequiredMember]
		public Vector StartCoordinate { get; set; }

		// Token: 0x170084D9 RID: 34009
		// (get) Token: 0x06031D3B RID: 204091 RVA: 0x00C7997E File Offset: 0x00C77B7E
		// (set) Token: 0x06031D3C RID: 204092 RVA: 0x00C79986 File Offset: 0x00C77B86
		[RequiredMember]
		public Vector TargetCoordinate { get; set; }

		// Token: 0x170084DA RID: 34010
		// (get) Token: 0x06031D3D RID: 204093 RVA: 0x00C7998F File Offset: 0x00C77B8F
		// (set) Token: 0x06031D3E RID: 204094 RVA: 0x00C79997 File Offset: 0x00C77B97
		[RequiredMember]
		public WuWaGoGridController GridController { get; set; }

		// Token: 0x170084DB RID: 34011
		// (get) Token: 0x06031D3F RID: 204095 RVA: 0x00C799A0 File Offset: 0x00C77BA0
		// (set) Token: 0x06031D40 RID: 204096 RVA: 0x00C799A8 File Offset: 0x00C77BA8
		[RequiredMember]
		public string OldKey { get; set; }

		// Token: 0x170084DC RID: 34012
		// (get) Token: 0x06031D41 RID: 204097 RVA: 0x00C799B1 File Offset: 0x00C77BB1
		// (set) Token: 0x06031D42 RID: 204098 RVA: 0x00C799B9 File Offset: 0x00C77BB9
		[RequiredMember]
		public string TargetKey { get; set; }

		// Token: 0x170084DD RID: 34013
		// (get) Token: 0x06031D43 RID: 204099 RVA: 0x00C799C2 File Offset: 0x00C77BC2
		// (set) Token: 0x06031D44 RID: 204100 RVA: 0x00C799CA File Offset: 0x00C77BCA
		[RequiredMember]
		public IReadOnlyList<IWuWaGoGridMoveParticipant> Participants { get; set; }

		// Token: 0x06031D45 RID: 204101 RVA: 0x00C799D3 File Offset: 0x00C77BD3
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoGridRelocationRequest()
		{
		}
	}
}
