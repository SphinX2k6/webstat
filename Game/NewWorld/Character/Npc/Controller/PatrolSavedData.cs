using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Npc.Controller
{
	// Token: 0x020048D3 RID: 18643
	[NullableContext(1)]
	[Nullable(0)]
	public class PatrolSavedData
	{
		// Token: 0x06030A5F RID: 199263 RVA: 0x00BFCCA8 File Offset: 0x00BFAEA8
		public bool IsValid()
		{
			return this.SplineId != 0 && this.PointId != -1 && this.PatrolState != "";
		}

		// Token: 0x06030A60 RID: 199264 RVA: 0x00BFCCD0 File Offset: 0x00BFAED0
		public PatrolSavedData DeepCopy()
		{
			return new PatrolSavedData
			{
				SplineId = this.SplineId,
				PointId = this.PointId,
				Direction = this.Direction,
				State = this.State,
				PatrolState = this.PatrolState,
				ActionIndex = this.ActionIndex,
				ActionType = this.ActionType
			};
		}

		// Token: 0x0401BF66 RID: 114534
		public int SplineId;

		// Token: 0x0401BF67 RID: 114535
		public int PointId = -1;

		// Token: 0x0401BF68 RID: 114536
		public bool Direction;

		// Token: 0x0401BF69 RID: 114537
		public EPatrolState State;

		// Token: 0x0401BF6A RID: 114538
		public string PatrolState = "";

		// Token: 0x0401BF6B RID: 114539
		public int ActionIndex;

		// Token: 0x0401BF6C RID: 114540
		public int ActionType;
	}
}
