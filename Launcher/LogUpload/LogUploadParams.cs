using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045F1 RID: 17905
	[NullableContext(1)]
	[Nullable(0)]
	public class LogUploadParams : ILogUploadParams
	{
		// Token: 0x1700808C RID: 32908
		// (get) Token: 0x0602EDB6 RID: 191926 RVA: 0x00B18E85 File Offset: 0x00B17085
		// (set) Token: 0x0602EDB7 RID: 191927 RVA: 0x00B18E8D File Offset: 0x00B1708D
		public INet Net { get; set; }

		// Token: 0x1700808D RID: 32909
		// (get) Token: 0x0602EDB8 RID: 191928 RVA: 0x00B18E96 File Offset: 0x00B17096
		// (set) Token: 0x0602EDB9 RID: 191929 RVA: 0x00B18E9E File Offset: 0x00B1709E
		public IPlayerInfoModel PlayerInfoModel { get; set; }

		// Token: 0x1700808E RID: 32910
		// (get) Token: 0x0602EDBA RID: 191930 RVA: 0x00B18EA7 File Offset: 0x00B170A7
		// (set) Token: 0x0602EDBB RID: 191931 RVA: 0x00B18EAF File Offset: 0x00B170AF
		public ILocalStorage LocalStorage { get; set; }

		// Token: 0x1700808F RID: 32911
		// (get) Token: 0x0602EDBC RID: 191932 RVA: 0x00B18EB8 File Offset: 0x00B170B8
		// (set) Token: 0x0602EDBD RID: 191933 RVA: 0x00B18EC0 File Offset: 0x00B170C0
		public IKuroSdkController KuroSdkController { get; set; }

		// Token: 0x17008090 RID: 32912
		// (get) Token: 0x0602EDBE RID: 191934 RVA: 0x00B18EC9 File Offset: 0x00B170C9
		// (set) Token: 0x0602EDBF RID: 191935 RVA: 0x00B18ED1 File Offset: 0x00B170D1
		public ILoginModel LoginModel { get; set; }
	}
}
