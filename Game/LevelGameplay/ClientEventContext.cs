using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A52 RID: 27218
	[NullableContext(2)]
	[Nullable(0)]
	public class ClientEventContext : GeneralContext
	{
		// Token: 0x0604351A RID: 275738 RVA: 0x0114DCA1 File Offset: 0x0114BEA1
		public object GetEventHandleParams(int index)
		{
			object[] @params = this.Params;
			if (@params == null)
			{
				return null;
			}
			return @params.GetValueOrDefault(index);
		}

		// Token: 0x0604351B RID: 275739 RVA: 0x0114DCB5 File Offset: 0x0114BEB5
		public ClientEventContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.ClientEvent);
		}

		// Token: 0x0604351C RID: 275740 RVA: 0x0114DCCA File Offset: 0x0114BECA
		public override void Reset()
		{
			this.EventName = null;
			this.Params = null;
		}

		// Token: 0x0604351D RID: 275741 RVA: 0x0114DCE0 File Offset: 0x0114BEE0
		[NullableContext(1)]
		public static ClientEventContext Create(EEventName eventName, [Nullable(new byte[]
		{
			1,
			2
		})] params object[] @params)
		{
			ClientEventContext clientEventContext = GeneralContext.GetObj(EGeneralContextType.ClientEvent, null, () => new ClientEventContext()) as ClientEventContext;
			clientEventContext.EventName = new EEventName?(eventName);
			clientEventContext.Params = @params;
			return clientEventContext;
		}

		// Token: 0x040258A7 RID: 153767
		public EEventName? EventName;

		// Token: 0x040258A8 RID: 153768
		public object[] Params;
	}
}
