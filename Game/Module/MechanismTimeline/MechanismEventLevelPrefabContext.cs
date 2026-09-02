using System;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DA RID: 22490
	public class MechanismEventLevelPrefabContext : MechanismEventContext
	{
		// Token: 0x06039265 RID: 234085 RVA: 0x00E7D62E File Offset: 0x00E7B82E
		public MechanismEventLevelPrefabContext(int pbDataId, int levelPrefabHandleId)
		{
		}

		// Token: 0x170091B7 RID: 37303
		// (get) Token: 0x06039266 RID: 234086 RVA: 0x00E7D644 File Offset: 0x00E7B844
		public override EMechanismEventContextType ContextType
		{
			get
			{
				return EMechanismEventContextType.LevelPrefab;
			}
		}

		// Token: 0x04020868 RID: 133224
		public readonly int PbDataId = pbDataId;

		// Token: 0x04020869 RID: 133225
		public readonly int LevelPrefabHandleId = levelPrefabHandleId;
	}
}
