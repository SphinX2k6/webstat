using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Define;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability
{
	// Token: 0x020069FD RID: 27133
	[NullableContext(1)]
	[Nullable(0)]
	public class DraggableStateData : CapabilityData
	{
		// Token: 0x060433A9 RID: 275369 RVA: 0x01148E1C File Offset: 0x0114701C
		[NullableContext(2)]
		public DraggableStateData(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x060433AA RID: 275370 RVA: 0x01148E51 File Offset: 0x01147051
		public override void OnAdded()
		{
			this.ResetSpeedSample();
		}

		// Token: 0x060433AB RID: 275371 RVA: 0x01148E59 File Offset: 0x01147059
		public override void OnRemoved()
		{
			this.Appliers.Clear();
			this.States.Clear();
			this.PendingRegister.Clear();
			this.PendingUnregister.Clear();
			this.ResetSpeedSample();
		}

		// Token: 0x060433AC RID: 275372 RVA: 0x01148E90 File Offset: 0x01147090
		public void PushRegister(IKuroSplineConstrainedDrag drag)
		{
			string actorKey = drag.GetActorKey();
			this.PendingUnregister.Remove(actorKey);
			this.PendingRegister[actorKey] = drag;
		}

		// Token: 0x060433AD RID: 275373 RVA: 0x01148EC0 File Offset: 0x011470C0
		public void PushUnregister(IKuroSplineConstrainedDrag drag)
		{
			string actorKey = drag.GetActorKey();
			this.PendingRegister.Remove(actorKey);
			this.PendingUnregister[actorKey] = drag;
		}

		// Token: 0x060433AE RID: 275374 RVA: 0x01148EEE File Offset: 0x011470EE
		public void ResetSpeedSample()
		{
			this.SpeedSampleDrag = null;
			this.SpeedSampleDistance = 0f;
			this.SelectedMovingSpeed = 0f;
			this.ActiveDragMoving = false;
			this.LowSpeedDurationSeconds = 0f;
		}

		// Token: 0x0402579F RID: 153503
		public readonly Dictionary<string, IDraggableStateApplier> Appliers = new Dictionary<string, IDraggableStateApplier>();

		// Token: 0x040257A0 RID: 153504
		public readonly Dictionary<string, EDraggableState> States = new Dictionary<string, EDraggableState>();

		// Token: 0x040257A1 RID: 153505
		public readonly Dictionary<string, IKuroSplineConstrainedDrag> PendingRegister = new Dictionary<string, IKuroSplineConstrainedDrag>();

		// Token: 0x040257A2 RID: 153506
		public readonly Dictionary<string, IKuroSplineConstrainedDrag> PendingUnregister = new Dictionary<string, IKuroSplineConstrainedDrag>();

		// Token: 0x040257A3 RID: 153507
		[Nullable(2)]
		public IKuroSplineConstrainedDrag SpeedSampleDrag;

		// Token: 0x040257A4 RID: 153508
		public float SpeedSampleDistance;

		// Token: 0x040257A5 RID: 153509
		public float SelectedMovingSpeed;

		// Token: 0x040257A6 RID: 153510
		public bool ActiveDragMoving;

		// Token: 0x040257A7 RID: 153511
		public float LowSpeedDurationSeconds;
	}
}
