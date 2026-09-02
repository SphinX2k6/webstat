using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B6 RID: 18102
	public class CachedAstEntry
	{
		// Token: 0x0401AD2D RID: 109869
		[Nullable(1)]
		public IAstNode Ast;

		// Token: 0x0401AD2E RID: 109870
		public int RefCount;
	}
}
