using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.CombatMessage;
using Google.Protobuf;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E91 RID: 24209
	[NullableContext(1)]
	[Nullable(0)]
	public class CombatExactResponseDataPack
	{
		// Token: 0x0603CE0C RID: 249356 RVA: 0x00F74E5A File Offset: 0x00F7305A
		public CombatExactResponseDataPack(IMessage message, CombatResponseData.MessageOneofCase messageCase)
		{
		}

		// Token: 0x1700997B RID: 39291
		// (get) Token: 0x0603CE0D RID: 249357 RVA: 0x00F74E70 File Offset: 0x00F73070
		// (set) Token: 0x0603CE0E RID: 249358 RVA: 0x00F74E78 File Offset: 0x00F73078
		public IMessage Message { get; private set; } = message;

		// Token: 0x1700997C RID: 39292
		// (get) Token: 0x0603CE0F RID: 249359 RVA: 0x00F74E81 File Offset: 0x00F73081
		// (set) Token: 0x0603CE10 RID: 249360 RVA: 0x00F74E89 File Offset: 0x00F73089
		public CombatResponseData.MessageOneofCase MessageCase { get; private set; } = messageCase;
	}
}
