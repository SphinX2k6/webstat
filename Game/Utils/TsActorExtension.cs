using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using UnrealEngine;

namespace CSharpScript.Game.Utils
{
	// Token: 0x020046FE RID: 18174
	[NullableContext(2)]
	[Nullable(0)]
	public static class TsActorExtension
	{
		// Token: 0x0602F414 RID: 193556 RVA: 0x00B34DC0 File Offset: 0x00B32FC0
		public static Entity GetEntityNoBlueprint(this ABaseCharacter a)
		{
			TsBaseCharacter tsBaseCharacter = a as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				return tsBaseCharacter.GetEntityNoBlueprint();
			}
			TsBaseVehicle tsBaseVehicle = a as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				return tsBaseVehicle.GetEntityNoBlueprint();
			}
			return null;
		}

		// Token: 0x0602F415 RID: 193557 RVA: 0x00B34DF0 File Offset: 0x00B32FF0
		public static void SetDitherEffect(this ABaseCharacter a, float dither, ECharacterDitherType ditherType = ECharacterDitherType.Temporary)
		{
			TsBaseCharacter tsBaseCharacter = a as TsBaseCharacter;
			if (tsBaseCharacter != null)
			{
				tsBaseCharacter.SetDitherEffect(dither, ditherType);
				return;
			}
			TsBaseVehicle tsBaseVehicle = a as TsBaseVehicle;
			if (tsBaseVehicle != null)
			{
				tsBaseVehicle.SetDitherEffect(dither, ditherType);
			}
		}
	}
}
