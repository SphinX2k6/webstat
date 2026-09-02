using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Area.AreaFunction
{
	// Token: 0x0200617F RID: 24959
	public static class AreaFunctionUtils
	{
		// Token: 0x0603F144 RID: 258372 RVA: 0x0102D364 File Offset: 0x0102B564
		[NullableContext(2)]
		public static Entity GetLocalRoleEntity()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return null;
			}
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			if (characterActorComponent == null)
			{
				return null;
			}
			return characterActorComponent.Entity;
		}
	}
}
