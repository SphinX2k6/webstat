using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BD2 RID: 27602
	public class LevelEventReignsSetPropertyVisible : LevelEventBase
	{
		// Token: 0x06044086 RID: 278662 RVA: 0x011A5748 File Offset: 0x011A3948
		public LevelEventReignsSetPropertyVisible(int id) : base(id)
		{
		}

		// Token: 0x06044087 RID: 278663 RVA: 0x011A5751 File Offset: 0x011A3951
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
		}
	}
}
