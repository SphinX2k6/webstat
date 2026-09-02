using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;

namespace CSharpScript.Game.LevelGamePlay.OperationRestrict
{
	// Token: 0x02006B37 RID: 27447
	[NullableContext(1)]
	[Nullable(0)]
	public class ISkillOptionToInputAction
	{
		// Token: 0x1700A31F RID: 41759
		// (get) Token: 0x06043D2A RID: 277802 RVA: 0x011873E4 File Offset: 0x011855E4
		// (set) Token: 0x06043D2B RID: 277803 RVA: 0x011873EC File Offset: 0x011855EC
		public string OptionKey { get; set; }

		// Token: 0x1700A320 RID: 41760
		// (get) Token: 0x06043D2C RID: 277804 RVA: 0x011873F5 File Offset: 0x011855F5
		// (set) Token: 0x06043D2D RID: 277805 RVA: 0x011873FD File Offset: 0x011855FD
		public EInputAction InputAction { get; set; }
	}
}
