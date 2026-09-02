using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Typing;

namespace UnrealEngine
{
	// Token: 0x020043DD RID: 17373
	public class GameplayTagCache : IStaticVariableResetter
	{
		// Token: 0x0602E283 RID: 189059 RVA: 0x00ADAE17 File Offset: 0x00AD9017
		static GameplayTagCache()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(GameplayTagCache.CreateStaticDefaultValue), new Action(GameplayTagCache.ResetStaticDefaultValue));
		}

		// Token: 0x0602E284 RID: 189060 RVA: 0x00ADAE36 File Offset: 0x00AD9036
		public static void CreateStaticDefaultValue()
		{
			GameplayTagCache.TagIdCache = new Dictionary<FName, int>();
			GameplayTagCache.OriginalTagNameCache = new Dictionary<FName, FName>();
		}

		// Token: 0x0602E285 RID: 189061 RVA: 0x00ADAE4C File Offset: 0x00AD904C
		public static void ResetStaticDefaultValue()
		{
			GameplayTagCache.TagIdCache = null;
			GameplayTagCache.OriginalTagNameCache = null;
		}

		// Token: 0x0602E286 RID: 189062 RVA: 0x00ADAE5C File Offset: 0x00AD905C
		public static int GetOrCreateTagId(FName tagName)
		{
			int num;
			if (!GameplayTagCache.TagIdCache.TryGetValue(tagName, out num))
			{
				num = UGASBPLibrary.FnvHash(tagName.ToString());
				GameplayTagCache.TagIdCache[tagName] = num;
			}
			return num;
		}

		// Token: 0x0602E287 RID: 189063 RVA: 0x00ADAE98 File Offset: 0x00AD9098
		public static FName GetOrCreateOriginalTagName(FName tagName)
		{
			FName fname;
			if (!GameplayTagCache.OriginalTagNameCache.TryGetValue(tagName, out fname))
			{
				fname = GameplayTagsManager.GetOriginalTag(tagName);
				GameplayTagCache.OriginalTagNameCache[tagName] = fname;
			}
			return fname;
		}

		// Token: 0x0401A1AE RID: 106926
		[Nullable(2)]
		private static Dictionary<FName, int> TagIdCache;

		// Token: 0x0401A1AF RID: 106927
		[Nullable(2)]
		private static Dictionary<FName, FName> OriginalTagNameCache;
	}
}
