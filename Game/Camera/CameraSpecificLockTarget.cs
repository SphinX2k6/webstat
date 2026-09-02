using System;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200708A RID: 28810
	public abstract class CameraSpecificLockTarget
	{
		// Token: 0x06045D2C RID: 285996 RVA: 0x01247F18 File Offset: 0x01246118
		protected CameraSpecificLockTarget(ECameraSpecificLockType type, int id, int priority)
		{
		}

		// Token: 0x1700A59D RID: 42397
		// (get) Token: 0x06045D2D RID: 285997 RVA: 0x01247F35 File Offset: 0x01246135
		public ECameraSpecificLockType Type { get; } = type;

		// Token: 0x1700A59E RID: 42398
		// (get) Token: 0x06045D2E RID: 285998 RVA: 0x01247F3D File Offset: 0x0124613D
		public int Id { get; } = id;

		// Token: 0x1700A59F RID: 42399
		// (get) Token: 0x06045D2F RID: 285999 RVA: 0x01247F45 File Offset: 0x01246145
		public int Priority { get; } = priority;

		// Token: 0x06045D30 RID: 286000 RVA: 0x01247F4D File Offset: 0x0124614D
		public virtual bool IsValid()
		{
			return true;
		}

		// Token: 0x04027161 RID: 160097
		public bool MarkDelete;
	}
}
