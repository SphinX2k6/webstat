using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C24 RID: 27684
	public class LevelEventUnlockDungeonEntry : LevelEventBase
	{
		// Token: 0x060441B4 RID: 278964 RVA: 0x011AF650 File Offset: 0x011AD850
		public LevelEventUnlockDungeonEntry(int id) : base(id)
		{
		}

		// Token: 0x060441B5 RID: 278965 RVA: 0x011AF65C File Offset: 0x011AD85C
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			Singleton<global::Log>.Instance.Info(ELogModule.InstanceDungeon, ELogAuthor.LJQ, "注意，该行为已经废弃，通知程序处理", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
