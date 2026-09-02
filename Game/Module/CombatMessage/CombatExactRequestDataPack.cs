using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.CombatMessage;
using Google.Protobuf;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E90 RID: 24208
	[NullableContext(1)]
	[Nullable(0)]
	public class CombatExactRequestDataPack
	{
		// Token: 0x0603CE07 RID: 249351 RVA: 0x00F74E22 File Offset: 0x00F73022
		public CombatExactRequestDataPack(IMessage message, CombatRequestData.MessageOneofCase messageCase)
		{
		}

		// Token: 0x17009979 RID: 39289
		// (get) Token: 0x0603CE08 RID: 249352 RVA: 0x00F74E38 File Offset: 0x00F73038
		// (set) Token: 0x0603CE09 RID: 249353 RVA: 0x00F74E40 File Offset: 0x00F73040
		public IMessage Message { get; private set; } = message;

		// Token: 0x1700997A RID: 39290
		// (get) Token: 0x0603CE0A RID: 249354 RVA: 0x00F74E49 File Offset: 0x00F73049
		// (set) Token: 0x0603CE0B RID: 249355 RVA: 0x00F74E51 File Offset: 0x00F73051
		public CombatRequestData.MessageOneofCase MessageCase { get; private set; } = messageCase;
	}
}
