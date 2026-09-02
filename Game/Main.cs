using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game
{
	// Token: 0x020046CF RID: 18127
	public class Main
	{
		// Token: 0x0602F264 RID: 193124 RVA: 0x00B2C08E File Offset: 0x00B2A28E
		[NullableContext(1)]
		public static void DoMain(UGameInstance gameInstance)
		{
			GameProcedure.Start(gameInstance);
		}
	}
}
