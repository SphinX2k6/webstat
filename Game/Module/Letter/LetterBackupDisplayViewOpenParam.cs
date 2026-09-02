using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Letter
{
	// Token: 0x02005A1E RID: 23070
	[RequiredMember]
	public class LetterBackupDisplayViewOpenParam : ILetterBackupDisplayViewOpenParam
	{
		// Token: 0x170094DB RID: 38107
		// (get) Token: 0x0603A682 RID: 239234 RVA: 0x00ECF177 File Offset: 0x00ECD377
		// (set) Token: 0x0603A683 RID: 239235 RVA: 0x00ECF17F File Offset: 0x00ECD37F
		[RequiredMember]
		public int LetterId { get; set; }

		// Token: 0x170094DC RID: 38108
		// (get) Token: 0x0603A684 RID: 239236 RVA: 0x00ECF188 File Offset: 0x00ECD388
		// (set) Token: 0x0603A685 RID: 239237 RVA: 0x00ECF190 File Offset: 0x00ECD390
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IReadOnlyList<ITalkItem> Items { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170094DD RID: 38109
		// (get) Token: 0x0603A686 RID: 239238 RVA: 0x00ECF199 File Offset: 0x00ECD399
		// (set) Token: 0x0603A687 RID: 239239 RVA: 0x00ECF1A1 File Offset: 0x00ECD3A1
		public ELetterStyle? LetterStyle { get; set; }

		// Token: 0x0603A688 RID: 239240 RVA: 0x00ECF1AA File Offset: 0x00ECD3AA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public LetterBackupDisplayViewOpenParam()
		{
		}
	}
}
