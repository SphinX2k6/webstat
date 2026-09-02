using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004ACB RID: 19147
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class GridMoveParticipantExecution : IGridMoveParticipantExecution
	{
		// Token: 0x1700851E RID: 34078
		// (get) Token: 0x06031EA1 RID: 204449 RVA: 0x00C7DC14 File Offset: 0x00C7BE14
		// (set) Token: 0x06031EA2 RID: 204450 RVA: 0x00C7DC1C File Offset: 0x00C7BE1C
		[RequiredMember]
		public IWuWaGoGridMoveParticipant Participant { get; set; }

		// Token: 0x1700851F RID: 34079
		// (get) Token: 0x06031EA3 RID: 204451 RVA: 0x00C7DC25 File Offset: 0x00C7BE25
		// (set) Token: 0x06031EA4 RID: 204452 RVA: 0x00C7DC2D File Offset: 0x00C7BE2D
		[RequiredMember]
		public IWuWaGoGridRelocationContext Context { get; set; }

		// Token: 0x06031EA5 RID: 204453 RVA: 0x00C7DC36 File Offset: 0x00C7BE36
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public GridMoveParticipantExecution()
		{
		}
	}
}
