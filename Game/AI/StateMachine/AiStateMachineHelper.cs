using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpScript.Game.AI.StateMachine
{
	// Token: 0x020070CD RID: 28877
	public static class AiStateMachineHelper
	{
		// Token: 0x0604601D RID: 286749 RVA: 0x0125F284 File Offset: 0x0125D484
		[NullableContext(1)]
		public static void AppendDepthSpace(StringBuilder outBuilder, int depth)
		{
			for (int i = 0; i < depth; i++)
			{
				outBuilder.Append("    ");
			}
		}
	}
}
