using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045EE RID: 17902
	[NullableContext(1)]
	public interface ILocalStorage
	{
		// Token: 0x17008089 RID: 32905
		// (get) Token: 0x0602EDB0 RID: 191920
		// (set) Token: 0x0602EDB1 RID: 191921
		Func<int?> GetRecentlyLoginUid { get; set; }
	}
}
