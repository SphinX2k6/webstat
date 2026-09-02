using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045ED RID: 17901
	[NullableContext(1)]
	public interface IPlayerInfoModel
	{
		// Token: 0x17008088 RID: 32904
		// (get) Token: 0x0602EDAE RID: 191918
		// (set) Token: 0x0602EDAF RID: 191919
		Func<int?> GetId { get; set; }
	}
}
