using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.CombatMessage;
using Google.Protobuf;

namespace CSharpScript.Game.Module.CombatMessage
{
	// Token: 0x02005E8F RID: 24207
	[NullableContext(1)]
	[Nullable(0)]
	public class CombatExactNotifyDataPack
	{
		// Token: 0x0603CE02 RID: 249346 RVA: 0x00F74DEA File Offset: 0x00F72FEA
		public CombatExactNotifyDataPack(IMessage message, CombatNotifyData.MessageOneofCase messageCase)
		{
		}

		// Token: 0x17009977 RID: 39287
		// (get) Token: 0x0603CE03 RID: 249347 RVA: 0x00F74E00 File Offset: 0x00F73000
		// (set) Token: 0x0603CE04 RID: 249348 RVA: 0x00F74E08 File Offset: 0x00F73008
		public IMessage Message { get; private set; } = message;

		// Token: 0x17009978 RID: 39288
		// (get) Token: 0x0603CE05 RID: 249349 RVA: 0x00F74E11 File Offset: 0x00F73011
		// (set) Token: 0x0603CE06 RID: 249350 RVA: 0x00F74E19 File Offset: 0x00F73019
		public CombatNotifyData.MessageOneofCase MessageCase { get; private set; } = messageCase;
	}
}
