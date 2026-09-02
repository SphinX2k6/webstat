using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Utils
{
	// Token: 0x020046B7 RID: 18103
	[NullableContext(1)]
	[Nullable(0)]
	public class FormulaCacheManager : IStaticVariableResetter
	{
		// Token: 0x0602F18C RID: 192908 RVA: 0x00B27EF9 File Offset: 0x00B260F9
		static FormulaCacheManager()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(FormulaCacheManager.CreateStaticDefaultValue), new Action(FormulaCacheManager.ResetStaticDefaultValue));
		}

		// Token: 0x0602F18D RID: 192909 RVA: 0x00B27F18 File Offset: 0x00B26118
		public static void CreateStaticDefaultValue()
		{
			FormulaCacheManager.Cache = new Dictionary<string, CachedAstEntry>();
		}

		// Token: 0x0602F18E RID: 192910 RVA: 0x00B27F24 File Offset: 0x00B26124
		public static void ResetStaticDefaultValue()
		{
			FormulaCacheManager.Cache = null;
		}

		// Token: 0x0602F18F RID: 192911 RVA: 0x00B27F2C File Offset: 0x00B2612C
		public static IAstNode Acquire(string formulaStr)
		{
			CachedAstEntry cachedAstEntry;
			if (FormulaCacheManager.Cache.TryGetValue(formulaStr, out cachedAstEntry))
			{
				cachedAstEntry.RefCount++;
				return cachedAstEntry.Ast;
			}
			IAstNode astNode = new Parser(new Lexer(formulaStr).Tokenize()).Parse(formulaStr);
			FormulaCacheManager.Cache[formulaStr] = new CachedAstEntry
			{
				Ast = astNode,
				RefCount = 1
			};
			return astNode;
		}

		// Token: 0x0602F190 RID: 192912 RVA: 0x00B27F94 File Offset: 0x00B26194
		public static void Release(string formulaStr)
		{
			CachedAstEntry cachedAstEntry;
			if (!FormulaCacheManager.Cache.TryGetValue(formulaStr, out cachedAstEntry))
			{
				return;
			}
			cachedAstEntry.RefCount--;
			if (cachedAstEntry.RefCount <= 0)
			{
				FormulaCacheManager.Cache.Remove(formulaStr);
			}
		}

		// Token: 0x0602F191 RID: 192913 RVA: 0x00B27FD4 File Offset: 0x00B261D4
		public static int GetCacheSize()
		{
			return FormulaCacheManager.Cache.Count;
		}

		// Token: 0x0602F192 RID: 192914 RVA: 0x00B27FE0 File Offset: 0x00B261E0
		public static int GetRefCount(string formulaStr)
		{
			CachedAstEntry cachedAstEntry;
			if (!FormulaCacheManager.Cache.TryGetValue(formulaStr, out cachedAstEntry))
			{
				return 0;
			}
			return cachedAstEntry.RefCount;
		}

		// Token: 0x0401AD2F RID: 109871
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static Dictionary<string, CachedAstEntry> Cache;
	}
}
