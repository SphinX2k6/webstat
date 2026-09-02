using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BB2 RID: 27570
	public class LevelEventLog : LevelEventBase
	{
		// Token: 0x06043FF8 RID: 278520 RVA: 0x0119F699 File Offset: 0x0119D899
		public LevelEventLog(int id) : base(id)
		{
		}

		// Token: 0x06043FF9 RID: 278521 RVA: 0x0119F6A4 File Offset: 0x0119D8A4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			Aki.TDConfigMgr.Action.Log log = inParams as Aki.TDConfigMgr.Action.Log;
			if (log == null)
			{
				return;
			}
			string level = log.Level;
			if (level == "Warn")
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelEvent, ELogAuthor.YZH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (level == "Info")
			{
				Singleton<global::Log>.Instance.Info(ELogModule.LevelEvent, ELogAuthor.YZH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!(level == "Error"))
			{
				return;
			}
			Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YZH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}
}
