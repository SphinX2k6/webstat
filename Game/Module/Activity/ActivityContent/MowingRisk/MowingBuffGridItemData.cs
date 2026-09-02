using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006683 RID: 26243
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffGridItemData : IMowingBuffGridItemData
	{
		// Token: 0x17009FDD RID: 40925
		// (get) Token: 0x060418CC RID: 268492 RVA: 0x010D0DC7 File Offset: 0x010CEFC7
		// (set) Token: 0x060418CD RID: 268493 RVA: 0x010D0DCF File Offset: 0x010CEFCF
		public int BuffId { get; set; }

		// Token: 0x17009FDE RID: 40926
		// (get) Token: 0x060418CE RID: 268494 RVA: 0x010D0DD8 File Offset: 0x010CEFD8
		// (set) Token: 0x060418CF RID: 268495 RVA: 0x010D0DE0 File Offset: 0x010CEFE0
		public string QualityPath { get; set; }

		// Token: 0x17009FDF RID: 40927
		// (get) Token: 0x060418D0 RID: 268496 RVA: 0x010D0DE9 File Offset: 0x010CEFE9
		// (set) Token: 0x060418D1 RID: 268497 RVA: 0x010D0DF1 File Offset: 0x010CEFF1
		public string IconPath { get; set; }

		// Token: 0x17009FE0 RID: 40928
		// (get) Token: 0x060418D2 RID: 268498 RVA: 0x010D0DFA File Offset: 0x010CEFFA
		// (set) Token: 0x060418D3 RID: 268499 RVA: 0x010D0E02 File Offset: 0x010CF002
		public string NameTextId { get; set; }

		// Token: 0x17009FE1 RID: 40929
		// (get) Token: 0x060418D4 RID: 268500 RVA: 0x010D0E0B File Offset: 0x010CF00B
		// (set) Token: 0x060418D5 RID: 268501 RVA: 0x010D0E13 File Offset: 0x010CF013
		public bool IsShowBackground { get; set; }

		// Token: 0x17009FE2 RID: 40930
		// (get) Token: 0x060418D6 RID: 268502 RVA: 0x010D0E1C File Offset: 0x010CF01C
		// (set) Token: 0x060418D7 RID: 268503 RVA: 0x010D0E24 File Offset: 0x010CF024
		public bool IsChosen { get; set; }

		// Token: 0x17009FE3 RID: 40931
		// (get) Token: 0x060418D8 RID: 268504 RVA: 0x010D0E2D File Offset: 0x010CF02D
		// (set) Token: 0x060418D9 RID: 268505 RVA: 0x010D0E35 File Offset: 0x010CF035
		public bool IsUnlock { get; set; }

		// Token: 0x17009FE4 RID: 40932
		// (get) Token: 0x060418DA RID: 268506 RVA: 0x010D0E3E File Offset: 0x010CF03E
		// (set) Token: 0x060418DB RID: 268507 RVA: 0x010D0E46 File Offset: 0x010CF046
		public string LevelContent { get; set; }
	}
}
