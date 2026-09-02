using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Capability.Editor
{
	// Token: 0x0200707A RID: 28794
	[RequiredMember]
	public class FontConfig
	{
		// Token: 0x06045C9A RID: 285850 RVA: 0x012422A5 File Offset: 0x012404A5
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public FontConfig()
		{
		}

		// Token: 0x040270A0 RID: 159904
		[RequiredMember]
		public int Size;

		// Token: 0x040270A1 RID: 159905
		[Nullable(1)]
		[RequiredMember]
		public string Typeface;

		// Token: 0x040270A2 RID: 159906
		[RequiredMember]
		public int LetterSpacing;

		// Token: 0x040270A3 RID: 159907
		[RequiredMember]
		public FLinearColor Color;
	}
}
