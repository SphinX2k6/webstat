using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B9D RID: 27549
	public class LevelEventExitMovieCamera : LevelEventBase
	{
		// Token: 0x06043FA0 RID: 278432 RVA: 0x0119D4F3 File Offset: 0x0119B6F3
		public LevelEventExitMovieCamera(int id) : base(id)
		{
		}

		// Token: 0x06043FA1 RID: 278433 RVA: 0x0119D4FC File Offset: 0x0119B6FC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (!(inParams is ExitMovieCamera))
			{
				base.FinishExecute(false, false, true);
				return;
			}
			Singleton<global::Log>.Instance.Info(ELogModule.Event, ELogAuthor.LJM, "[电影镜头]通过LevelEvent离开电影镜头", default(ReadOnlySpan<ValueTuple<string, object>>));
			CameraModel instance = ModelBase<CameraModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.MainModel.StopMovieCamera(delegate(bool success)
			{
				base.FinishExecute(success, false, true);
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.LJM;
				string message = "[电影镜头]通过LevelEvent离开电影镜头结果";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", success);
				instance2.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, "关卡事件,停止电影镜头");
		}
	}
}
