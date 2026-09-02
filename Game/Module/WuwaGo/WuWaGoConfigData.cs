using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004A9B RID: 19099
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoConfigData : IWuWaGoLevelData
	{
		// Token: 0x170084B2 RID: 33970
		// (get) Token: 0x06031CEC RID: 204012 RVA: 0x00C7981B File Offset: 0x00C77A1B
		// (set) Token: 0x06031CED RID: 204013 RVA: 0x00C79823 File Offset: 0x00C77A23
		[RequiredMember]
		public List<int> LevelEntityIds { get; set; }

		// Token: 0x06031CEE RID: 204014 RVA: 0x00C7982C File Offset: 0x00C77A2C
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoConfigData()
		{
		}
	}
}
