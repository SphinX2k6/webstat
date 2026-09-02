using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F0 RID: 17904
	public interface ILoginModel
	{
		// Token: 0x1700808B RID: 32907
		// (get) Token: 0x0602EDB4 RID: 191924
		// (set) Token: 0x0602EDB5 RID: 191925
		[Nullable(new byte[]
		{
			1,
			2
		})]
		Func<string> GetSdkLoginConfigUid { [return: Nullable(new byte[]
		{
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			1,
			2
		})] set; }
	}
}
