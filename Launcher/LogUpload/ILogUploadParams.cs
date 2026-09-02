using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045EB RID: 17899
	[NullableContext(1)]
	public interface ILogUploadParams
	{
		// Token: 0x17008082 RID: 32898
		// (get) Token: 0x0602EDA7 RID: 191911
		INet Net { get; }

		// Token: 0x17008083 RID: 32899
		// (get) Token: 0x0602EDA8 RID: 191912
		IPlayerInfoModel PlayerInfoModel { get; }

		// Token: 0x17008084 RID: 32900
		// (get) Token: 0x0602EDA9 RID: 191913
		ILocalStorage LocalStorage { get; }

		// Token: 0x17008085 RID: 32901
		// (get) Token: 0x0602EDAA RID: 191914
		IKuroSdkController KuroSdkController { get; }

		// Token: 0x17008086 RID: 32902
		// (get) Token: 0x0602EDAB RID: 191915
		ILoginModel LoginModel { get; }
	}
}
