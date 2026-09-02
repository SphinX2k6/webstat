using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E5F RID: 28255
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class HourglassOpenParam : IHourglassOpenParam
	{
		// Token: 0x1700A38F RID: 41871
		// (get) Token: 0x0604492C RID: 280876 RVA: 0x011D384E File Offset: 0x011D1A4E
		// (set) Token: 0x0604492D RID: 280877 RVA: 0x011D3856 File Offset: 0x011D1A56
		[RequiredMember]
		public IQteHourglass Config { get; set; }

		// Token: 0x1700A390 RID: 41872
		// (get) Token: 0x0604492E RID: 280878 RVA: 0x011D385F File Offset: 0x011D1A5F
		// (set) Token: 0x0604492F RID: 280879 RVA: 0x011D3867 File Offset: 0x011D1A67
		public bool? AutoStartQte { get; set; }

		// Token: 0x06044930 RID: 280880 RVA: 0x011D3870 File Offset: 0x011D1A70
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public HourglassOpenParam()
		{
		}
	}
}
