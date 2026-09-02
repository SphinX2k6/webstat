using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleLangCustomModel
{
	// Token: 0x020050EE RID: 20718
	[NullableContext(1)]
	public interface IRoleLangCustomDeleteInfo
	{
		// Token: 0x17008C2F RID: 35887
		// (get) Token: 0x06035648 RID: 218696
		// (set) Token: 0x06035649 RID: 218697
		int RoleId { get; set; }

		// Token: 0x17008C30 RID: 35888
		// (get) Token: 0x0603564A RID: 218698
		// (set) Token: 0x0603564B RID: 218699
		Action RefreshCallback { get; set; }

		// Token: 0x17008C31 RID: 35889
		// (get) Token: 0x0603564C RID: 218700
		// (set) Token: 0x0603564D RID: 218701
		Action CloseCallback { get; set; }
	}
}
