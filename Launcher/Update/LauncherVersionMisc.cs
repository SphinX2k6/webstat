using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BD RID: 17597
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherVersionMisc : AppVersionMisc
	{
		// Token: 0x0602E725 RID: 190245 RVA: 0x00AFEDDF File Offset: 0x00AFCFDF
		protected override string GetUpdateVersionKey()
		{
			return "LauncherVersion";
		}

		// Token: 0x0602E726 RID: 190246 RVA: 0x00AFEDE6 File Offset: 0x00AFCFE6
		protected override string GetSaveUpdateVersionKey()
		{
			return "SavedLauncherVersion";
		}

		// Token: 0x0602E727 RID: 190247 RVA: 0x00AFEDED File Offset: 0x00AFCFED
		protected override string GetIndexFilePrefix()
		{
			return "UpdaterPatchList_";
		}

		// Token: 0x0602E728 RID: 190248 RVA: 0x00AFEDF4 File Offset: 0x00AFCFF4
		protected override string GetMountFileName()
		{
			return "LauncherMount.txt";
		}

		// Token: 0x0602E729 RID: 190249 RVA: 0x00AFEDFB File Offset: 0x00AFCFFB
		public override string GetResType()
		{
			return EResType.Launcher.ToEnumString();
		}

		// Token: 0x0602E72A RID: 190250 RVA: 0x00AFEE03 File Offset: 0x00AFD003
		protected override string GetRemoteVersion()
		{
			return Singleton<RemoteInfo>.Instance.Config.LauncherVersion;
		}

		// Token: 0x0602E72B RID: 190251 RVA: 0x00AFEE14 File Offset: 0x00AFD014
		protected override Dictionary<string, string> GetRemoteSha1Map()
		{
			return Singleton<RemoteInfo>.Instance.Config.LauncherIndexSha1;
		}
	}
}
