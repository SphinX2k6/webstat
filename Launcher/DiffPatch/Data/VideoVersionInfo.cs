using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x02004654 RID: 18004
	[NullableContext(1)]
	[Nullable(0)]
	public class VideoVersionInfo : ResVersionInfo
	{
		// Token: 0x0602EFA9 RID: 192425 RVA: 0x00B2171B File Offset: 0x00B1F91B
		public VideoVersionInfo(bool hasContent) : base("video", "video", new Dictionary<string, string>())
		{
			this.hasContent = hasContent;
		}

		// Token: 0x0602EFAA RID: 192426 RVA: 0x00B21739 File Offset: 0x00B1F939
		public override void Init()
		{
		}

		// Token: 0x0602EFAB RID: 192427 RVA: 0x00B2173B File Offset: 0x00B1F93B
		public override string GetResType()
		{
			return "Video";
		}

		// Token: 0x0602EFAC RID: 192428 RVA: 0x00B21742 File Offset: 0x00B1F942
		public override bool HasContentOnRemote()
		{
			return this.hasContent;
		}

		// Token: 0x170080AB RID: 32939
		// (get) Token: 0x0602EFAD RID: 192429 RVA: 0x00B2174A File Offset: 0x00B1F94A
		public override string ManifestHash
		{
			get
			{
				return "";
			}
		}

		// Token: 0x0602EFAE RID: 192430 RVA: 0x00B21751 File Offset: 0x00B1F951
		public override bool UpdateVersionRecord()
		{
			return true;
		}

		// Token: 0x0602EFAF RID: 192431 RVA: 0x00B21754 File Offset: 0x00B1F954
		public override bool ClearVersionRecord()
		{
			return true;
		}

		// Token: 0x0401ABCC RID: 109516
		private readonly bool hasContent;
	}
}
