using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A09 RID: 18953
	[NullableContext(1)]
	[Nullable(0)]
	public class InputDistributeTag
	{
		// Token: 0x060318D7 RID: 202967 RVA: 0x00C59E48 File Offset: 0x00C58048
		public InputDistributeTag(string tag, [Nullable(2)] InputDistributeTag parentTag = null)
		{
			this.TagNameInternal = tag;
			this.ParentTagInternal = parentTag;
			for (InputDistributeTag inputDistributeTag = parentTag; inputDistributeTag != null; inputDistributeTag = inputDistributeTag.ParentTag)
			{
				string tagName = inputDistributeTag.TagName;
				this.ParentTagNameSet.Add(tagName);
			}
		}

		// Token: 0x1700844B RID: 33867
		// (get) Token: 0x060318D8 RID: 202968 RVA: 0x00C59E96 File Offset: 0x00C58096
		public string TagName
		{
			get
			{
				return this.TagNameInternal;
			}
		}

		// Token: 0x1700844C RID: 33868
		// (get) Token: 0x060318D9 RID: 202969 RVA: 0x00C59E9E File Offset: 0x00C5809E
		[Nullable(2)]
		public InputDistributeTag ParentTag
		{
			[NullableContext(2)]
			get
			{
				return this.ParentTagInternal;
			}
		}

		// Token: 0x060318DA RID: 202970 RVA: 0x00C59EA6 File Offset: 0x00C580A6
		public bool MatchTag(string tag, bool bExactMatch = false)
		{
			return this.TagNameInternal == tag || (!bExactMatch && this.ParentTagNameSet.Contains(tag));
		}

		// Token: 0x0401CCD7 RID: 117975
		[Nullable(2)]
		private readonly InputDistributeTag ParentTagInternal;

		// Token: 0x0401CCD8 RID: 117976
		private readonly HashSet<string> ParentTagNameSet = new HashSet<string>();

		// Token: 0x0401CCD9 RID: 117977
		private readonly string TagNameInternal;
	}
}
