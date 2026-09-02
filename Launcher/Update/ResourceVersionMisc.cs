using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;

namespace CSharpScript.Launcher.Update
{
	// Token: 0x020044BE RID: 17598
	[NullableContext(1)]
	[Nullable(0)]
	public class ResourceVersionMisc : AppVersionMisc
	{
		// Token: 0x0602E72D RID: 190253 RVA: 0x00AFEE2D File Offset: 0x00AFD02D
		protected override string GetUpdateVersionKey()
		{
			return "ResourceVersion";
		}

		// Token: 0x0602E72E RID: 190254 RVA: 0x00AFEE34 File Offset: 0x00AFD034
		protected override string GetSaveUpdateVersionKey()
		{
			return "SavedResourceVersion";
		}

		// Token: 0x0602E72F RID: 190255 RVA: 0x00AFEE3B File Offset: 0x00AFD03B
		protected override string GetIndexFilePrefix()
		{
			return "PatchList_";
		}

		// Token: 0x0602E730 RID: 190256 RVA: 0x00AFEE42 File Offset: 0x00AFD042
		protected override string GetMountFileName()
		{
			return "ResourceMount.txt";
		}

		// Token: 0x0602E731 RID: 190257 RVA: 0x00AFEE49 File Offset: 0x00AFD049
		public override string GetResType()
		{
			return EResType.Resource.ToEnumString();
		}

		// Token: 0x0602E732 RID: 190258 RVA: 0x00AFEE51 File Offset: 0x00AFD051
		protected override string GetRemoteVersion()
		{
			return Singleton<RemoteInfo>.Instance.Config.ResourceVersion;
		}

		// Token: 0x0602E733 RID: 190259 RVA: 0x00AFEE62 File Offset: 0x00AFD062
		protected override Dictionary<string, string> GetRemoteSha1Map()
		{
			return Singleton<RemoteInfo>.Instance.Config.ResourceIndexSha1;
		}
	}
}
