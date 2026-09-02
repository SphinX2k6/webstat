using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x0200629C RID: 25244
	public class RoundConfig : IRoundConfig
	{
		// Token: 0x17009C62 RID: 40034
		// (get) Token: 0x0603F888 RID: 260232 RVA: 0x01049286 File Offset: 0x01047486
		// (set) Token: 0x0603F889 RID: 260233 RVA: 0x0104928E File Offset: 0x0104748E
		public int Id { get; set; }

		// Token: 0x17009C63 RID: 40035
		// (get) Token: 0x0603F88A RID: 260234 RVA: 0x01049297 File Offset: 0x01047497
		// (set) Token: 0x0603F88B RID: 260235 RVA: 0x0104929F File Offset: 0x0104749F
		public int LevelId { get; set; }

		// Token: 0x17009C64 RID: 40036
		// (get) Token: 0x0603F88C RID: 260236 RVA: 0x010492A8 File Offset: 0x010474A8
		// (set) Token: 0x0603F88D RID: 260237 RVA: 0x010492B0 File Offset: 0x010474B0
		public int Round { get; set; }

		// Token: 0x17009C65 RID: 40037
		// (get) Token: 0x0603F88E RID: 260238 RVA: 0x010492B9 File Offset: 0x010474B9
		// (set) Token: 0x0603F88F RID: 260239 RVA: 0x010492C1 File Offset: 0x010474C1
		public int ShapeId { get; set; }

		// Token: 0x17009C66 RID: 40038
		// (get) Token: 0x0603F890 RID: 260240 RVA: 0x010492CA File Offset: 0x010474CA
		// (set) Token: 0x0603F891 RID: 260241 RVA: 0x010492D2 File Offset: 0x010474D2
		public int Color { get; set; }

		// Token: 0x17009C67 RID: 40039
		// (get) Token: 0x0603F892 RID: 260242 RVA: 0x010492DB File Offset: 0x010474DB
		// (set) Token: 0x0603F893 RID: 260243 RVA: 0x010492E3 File Offset: 0x010474E3
		public int Gem { get; set; }

		// Token: 0x17009C68 RID: 40040
		// (get) Token: 0x0603F894 RID: 260244 RVA: 0x010492EC File Offset: 0x010474EC
		// (set) Token: 0x0603F895 RID: 260245 RVA: 0x010492F4 File Offset: 0x010474F4
		public int GemFill { get; set; }
	}
}
