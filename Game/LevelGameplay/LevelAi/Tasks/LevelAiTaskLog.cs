using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelAi.Tasks
{
	// Token: 0x02006E22 RID: 28194
	public class LevelAiTaskLog : LevelAiTask
	{
		// Token: 0x06044717 RID: 280343 RVA: 0x011C78F8 File Offset: 0x011C5AF8
		protected override ELevelAiNodeResult ExecuteTask()
		{
			Aki.TDConfigMgr.Action.Log log = this.Params as Aki.TDConfigMgr.Action.Log;
			if (log == null)
			{
				return ELevelAiNodeResult.Succeeded;
			}
			string level = log.Level;
			if (!(level == "Warn"))
			{
				if (!(level == "Info"))
				{
					if (level == "Error")
					{
						Singleton<global::Log>.Instance.Error(ELogModule.LevelAi, ELogAuthor.CJH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
				else
				{
					Singleton<global::Log>.Instance.Info(ELogModule.LevelAi, ELogAuthor.CJH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			else
			{
				Singleton<global::Log>.Instance.Warn(ELogModule.LevelAi, ELogAuthor.CJH, log.Content, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return ELevelAiNodeResult.Succeeded;
		}
	}
}
