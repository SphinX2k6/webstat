using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;

namespace CSharpScript.Game.LevelGameplay.SplineConstrainedDrag.Capability
{
	// Token: 0x020069F9 RID: 27129
	[NullableContext(2)]
	[Nullable(0)]
	public class DraggableHoverStateData : CapabilityData
	{
		// Token: 0x0604337F RID: 275327 RVA: 0x01148029 File Offset: 0x01146229
		public DraggableHoverStateData(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x06043380 RID: 275328 RVA: 0x01148032 File Offset: 0x01146232
		public override void OnAdded()
		{
			this.HasResult = false;
			this.HoveredActorKey = null;
		}

		// Token: 0x06043381 RID: 275329 RVA: 0x01148042 File Offset: 0x01146242
		public override void OnRemoved()
		{
			this.HasResult = false;
			this.HoveredActorKey = null;
		}

		// Token: 0x04025799 RID: 153497
		public bool HasResult;

		// Token: 0x0402579A RID: 153498
		public string HoveredActorKey;
	}
}
