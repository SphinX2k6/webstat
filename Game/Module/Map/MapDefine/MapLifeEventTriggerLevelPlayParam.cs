using System;
using CSharpScript.Game.Module.Map.View.BaseMap.Assistant.MapLifeEvent;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058D9 RID: 22745
	public class MapLifeEventTriggerLevelPlayParam : IMapSceneGameplayUnlockData
	{
		// Token: 0x17009382 RID: 37762
		// (get) Token: 0x06039BAB RID: 236459 RVA: 0x00EA0446 File Offset: 0x00E9E646
		// (set) Token: 0x06039BAC RID: 236460 RVA: 0x00EA044E File Offset: 0x00E9E64E
		int IMapSceneGameplayUnlockData.RelativeType
		{
			get
			{
				return (int)this.RelativeType;
			}
			set
			{
				this.RelativeType = (EMarkRelativeType)value;
			}
		}

		// Token: 0x17009383 RID: 37763
		// (get) Token: 0x06039BAD RID: 236461 RVA: 0x00EA0457 File Offset: 0x00E9E657
		// (set) Token: 0x06039BAE RID: 236462 RVA: 0x00EA045F File Offset: 0x00E9E65F
		int IMapSceneGameplayUnlockData.RelativeSubType
		{
			get
			{
				return this.RelativeSubType;
			}
			set
			{
				this.RelativeSubType = value;
			}
		}

		// Token: 0x04020BC0 RID: 134080
		public EMarkRelativeType RelativeType;

		// Token: 0x04020BC1 RID: 134081
		public int RelativeSubType;
	}
}
