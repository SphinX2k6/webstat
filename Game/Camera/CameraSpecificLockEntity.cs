using System;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200708B RID: 28811
	public class CameraSpecificLockEntity : CameraSpecificLockTarget
	{
		// Token: 0x06045D31 RID: 286001 RVA: 0x01247F50 File Offset: 0x01246150
		public CameraSpecificLockEntity(int entityId, int priority, int id) : base(ECameraSpecificLockType.Entity, id, priority)
		{
		}

		// Token: 0x1700A5A0 RID: 42400
		// (get) Token: 0x06045D32 RID: 286002 RVA: 0x01247F62 File Offset: 0x01246162
		public int EntityId { get; } = entityId;

		// Token: 0x06045D33 RID: 286003 RVA: 0x01247F6A File Offset: 0x0124616A
		public override bool IsValid()
		{
			EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(this.EntityId);
			return handle != null && handle.Valid;
		}
	}
}
