using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x020061A4 RID: 24996
	public class MatTypeDes : IStaticVariableResetter
	{
		// Token: 0x0603F1E5 RID: 258533 RVA: 0x0102F6CC File Offset: 0x0102D8CC
		static MatTypeDes()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MatTypeDes.CreateStaticDefaultValue), new Action(MatTypeDes.ResetStaticDefaultValue));
		}

		// Token: 0x17009B37 RID: 39735
		// (get) Token: 0x0603F1E6 RID: 258534 RVA: 0x0102F6EB File Offset: 0x0102D8EB
		[Nullable(1)]
		public static Dictionary<EMatType, string> Values
		{
			[NullableContext(1)]
			get
			{
				return MatTypeDes._values;
			}
		}

		// Token: 0x0603F1E7 RID: 258535 RVA: 0x0102F6F2 File Offset: 0x0102D8F2
		public static void CreateStaticDefaultValue()
		{
			Dictionary<EMatType, string> dictionary = new Dictionary<EMatType, string>();
			dictionary[EMatType.All] = "AdventureMatType_All";
			dictionary[EMatType.Weapon] = "AdventureMatType_Weapon";
			dictionary[EMatType.Character] = "AdventureMatType_Character";
			dictionary[EMatType.Experience] = "AdventureMatType_Experience";
			MatTypeDes._values = dictionary;
		}

		// Token: 0x0603F1E8 RID: 258536 RVA: 0x0102F72E File Offset: 0x0102D92E
		public static void ResetStaticDefaultValue()
		{
			MatTypeDes._values = null;
		}

		// Token: 0x040236C4 RID: 145092
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private static Dictionary<EMatType, string> _values;
	}
}
