using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB4 RID: 19124
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class MovableFloorMoveRequest : IMovableFloorMoveRequest
	{
		// Token: 0x17008512 RID: 34066
		// (get) Token: 0x06031DA1 RID: 204193 RVA: 0x00C79B82 File Offset: 0x00C77D82
		// (set) Token: 0x06031DA2 RID: 204194 RVA: 0x00C79B8A File Offset: 0x00C77D8A
		[RequiredMember]
		public MovableFloorController Controller { get; set; }

		// Token: 0x17008513 RID: 34067
		// (get) Token: 0x06031DA3 RID: 204195 RVA: 0x00C79B93 File Offset: 0x00C77D93
		// (set) Token: 0x06031DA4 RID: 204196 RVA: 0x00C79B9B File Offset: 0x00C77D9B
		[RequiredMember]
		public IWuWaGoGridRelocationRequest RelocationRequest { get; set; }

		// Token: 0x06031DA5 RID: 204197 RVA: 0x00C79BA4 File Offset: 0x00C77DA4
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MovableFloorMoveRequest()
		{
		}
	}
}
