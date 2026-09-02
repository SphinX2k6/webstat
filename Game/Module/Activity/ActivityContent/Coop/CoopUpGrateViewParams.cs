using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069A6 RID: 27046
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopUpGrateViewParams
	{
		// Token: 0x1700A1EE RID: 41454
		// (get) Token: 0x06043148 RID: 274760 RVA: 0x0113AB6C File Offset: 0x01138D6C
		// (set) Token: 0x06043149 RID: 274761 RVA: 0x0113AB74 File Offset: 0x01138D74
		public CoopActivityData ActivityData { get; set; }

		// Token: 0x1700A1EF RID: 41455
		// (get) Token: 0x0604314A RID: 274762 RVA: 0x0113AB7D File Offset: 0x01138D7D
		// (set) Token: 0x0604314B RID: 274763 RVA: 0x0113AB85 File Offset: 0x01138D85
		public int RoleId { get; set; }

		// Token: 0x1700A1F0 RID: 41456
		// (get) Token: 0x0604314C RID: 274764 RVA: 0x0113AB8E File Offset: 0x01138D8E
		// (set) Token: 0x0604314D RID: 274765 RVA: 0x0113AB96 File Offset: 0x01138D96
		public int PreLevel { get; set; }

		// Token: 0x1700A1F1 RID: 41457
		// (get) Token: 0x0604314E RID: 274766 RVA: 0x0113AB9F File Offset: 0x01138D9F
		// (set) Token: 0x0604314F RID: 274767 RVA: 0x0113ABA7 File Offset: 0x01138DA7
		public int NextLevel { get; set; }

		// Token: 0x1700A1F2 RID: 41458
		// (get) Token: 0x06043150 RID: 274768 RVA: 0x0113ABB0 File Offset: 0x01138DB0
		// (set) Token: 0x06043151 RID: 274769 RVA: 0x0113ABB8 File Offset: 0x01138DB8
		public bool IsMaxLevel { get; set; }

		// Token: 0x1700A1F3 RID: 41459
		// (get) Token: 0x06043152 RID: 274770 RVA: 0x0113ABC1 File Offset: 0x01138DC1
		// (set) Token: 0x06043153 RID: 274771 RVA: 0x0113ABC9 File Offset: 0x01138DC9
		public bool IsNew { get; set; }
	}
}
