using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A53 RID: 27219
	public class CombinationContext : GeneralContext
	{
		// Token: 0x0604351E RID: 275742 RVA: 0x0114DD34 File Offset: 0x0114BF34
		public CombinationContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.Combination);
		}

		// Token: 0x0604351F RID: 275743 RVA: 0x0114DD49 File Offset: 0x0114BF49
		public override void Reset()
		{
			this.Contexts = null;
		}

		// Token: 0x06043520 RID: 275744 RVA: 0x0114DD54 File Offset: 0x0114BF54
		[NullableContext(1)]
		public static CombinationContext Create(params GeneralContext[] contexts)
		{
			CombinationContext combinationContext = GeneralContext.GetObj(EGeneralContextType.Combination, null, () => new CombinationContext()) as CombinationContext;
			combinationContext.Contexts = new List<GeneralContext>();
			foreach (GeneralContext generalContext in contexts)
			{
				if (generalContext.Type.GetValueOrDefault() == EGeneralContextType.Combination)
				{
					if ((generalContext as CombinationContext).Contexts != null)
					{
						combinationContext.Contexts.AddRange((generalContext as CombinationContext).Contexts);
					}
				}
				else
				{
					combinationContext.Contexts.Add(generalContext);
				}
			}
			return combinationContext;
		}

		// Token: 0x06043521 RID: 275745 RVA: 0x0114DDFC File Offset: 0x0114BFFC
		[return: Nullable(2)]
		public T GetContextByType<T>(EGeneralContextType type) where T : GeneralContext
		{
			if (this.Contexts == null)
			{
				return default(T);
			}
			for (int i = this.Contexts.Count - 1; i >= 0; i--)
			{
				GeneralContext generalContext = this.Contexts[i];
				EGeneralContextType? type2 = generalContext.Type;
				if (type2.GetValueOrDefault() == type & type2 != null)
				{
					return generalContext as T;
				}
			}
			return default(T);
		}

		// Token: 0x040258A9 RID: 153769
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<GeneralContext> Contexts;
	}
}
