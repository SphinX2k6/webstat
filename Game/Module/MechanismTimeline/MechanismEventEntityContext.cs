using System;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057D9 RID: 22489
	public class MechanismEventEntityContext : MechanismEventContext
	{
		// Token: 0x06039263 RID: 234083 RVA: 0x00E7D60E File Offset: 0x00E7B80E
		public MechanismEventEntityContext(int entityId, long createDataId, int pbDataId)
		{
		}

		// Token: 0x170091B6 RID: 37302
		// (get) Token: 0x06039264 RID: 234084 RVA: 0x00E7D62B File Offset: 0x00E7B82B
		public override EMechanismEventContextType ContextType
		{
			get
			{
				return EMechanismEventContextType.Entity;
			}
		}

		// Token: 0x04020865 RID: 133221
		public readonly int EntityId = entityId;

		// Token: 0x04020866 RID: 133222
		public readonly long CreateDataId = createDataId;

		// Token: 0x04020867 RID: 133223
		public readonly int PbDataId = pbDataId;
	}
}
