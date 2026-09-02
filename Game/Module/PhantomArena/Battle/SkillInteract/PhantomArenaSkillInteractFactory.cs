using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract
{
	// Token: 0x020055EE RID: 21998
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaSkillInteractFactory
	{
		// Token: 0x0603809C RID: 229532 RVA: 0x00E325E8 File Offset: 0x00E307E8
		public static PhantomArenaSkillInteractBase GetSkillInteract(int buffType)
		{
			Func<PhantomArenaSkillInteractBase> func;
			if (PhantomArenaSkillInteractFactory.SkillInteractMap.TryGetValue(buffType, out func))
			{
				return func();
			}
			return new PhantomArenaNormalSkillInteract();
		}

		// Token: 0x0603809D RID: 229533 RVA: 0x00E32610 File Offset: 0x00E30810
		public static bool HasSkillInteract(int buffType)
		{
			return PhantomArenaSkillInteractFactory.SkillInteractMap.ContainsKey(buffType);
		}

		// Token: 0x040200AF RID: 131247
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, Func<PhantomArenaSkillInteractBase>> SkillInteractMap = new Dictionary<int, Func<PhantomArenaSkillInteractBase>>
		{
			{
				2,
				() => new PhantomArenaSelectSkillInteract()
			},
			{
				7,
				() => new PhantomArenaChooseCardSkillInteract()
			},
			{
				21,
				() => new PhantomArenaSelectSkillInteract()
			},
			{
				23,
				() => new PhantomArenaSelectSkillInteract()
			},
			{
				24,
				() => new PhantomArenaSelectSkillInteract()
			},
			{
				25,
				() => new PhantomArenaSelectSkillInteract()
			},
			{
				27,
				() => new PhantomArenaSelectSkillInteract()
			}
		};
	}
}
