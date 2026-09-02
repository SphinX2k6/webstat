using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F5B RID: 24411
	public class EntranceButtonParameter
	{
		// Token: 0x040226AA RID: 140970
		public ERedDotName? RedDotName;

		// Token: 0x040226AB RID: 140971
		public EFunctionType? FunctionType;

		// Token: 0x040226AC RID: 140972
		public EBattleUiChild ChildType;

		// Token: 0x040226AD RID: 140973
		public bool HideInGamepad;

		// Token: 0x040226AE RID: 140974
		public bool HideByRoleConfig;

		// Token: 0x040226AF RID: 140975
		[Nullable(2)]
		public string IconPath;
	}
}
