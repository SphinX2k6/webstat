using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DC9 RID: 19913
	[NullableContext(1)]
	public interface ITrapDefenseBuildingDevelopTabData
	{
		// Token: 0x17008836 RID: 34870
		// (get) Token: 0x060338CA RID: 211146
		// (set) Token: 0x060338CB RID: 211147
		ETrapDefenseBuildingDevelopTab TabType { get; set; }

		// Token: 0x17008837 RID: 34871
		// (get) Token: 0x060338CC RID: 211148
		// (set) Token: 0x060338CD RID: 211149
		string Icon { get; set; }

		// Token: 0x17008838 RID: 34872
		// (get) Token: 0x060338CE RID: 211150
		// (set) Token: 0x060338CF RID: 211151
		string TabName { get; set; }

		// Token: 0x17008839 RID: 34873
		// (get) Token: 0x060338D0 RID: 211152
		// (set) Token: 0x060338D1 RID: 211153
		ERedDotName? RedDot { get; set; }
	}
}
