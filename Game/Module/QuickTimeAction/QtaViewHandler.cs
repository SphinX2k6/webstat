using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickTimeAction
{
	// Token: 0x020052B1 RID: 21169
	[NullableContext(2)]
	[Nullable(0)]
	public class QtaViewHandler
	{
		// Token: 0x060361DC RID: 221660 RVA: 0x00DA0AD8 File Offset: 0x00D9ECD8
		public QtaViewHandler(QtaViewParam qtaViewParam)
		{
			if (qtaViewParam == null || qtaViewParam.QtaHandleId == 0)
			{
				Singleton<Log>.Instance.Info(ELogModule.Camera, ELogAuthor.HWR, "QtaViewParam:参数无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.QtaViewParam = qtaViewParam;
		}

		// Token: 0x060361DD RID: 221661 RVA: 0x00DA0B19 File Offset: 0x00D9ED19
		public void SetResult(EQtaResult result)
		{
			this.QtaResult = result;
		}

		// Token: 0x060361DE RID: 221662 RVA: 0x00DA0B22 File Offset: 0x00D9ED22
		public void Finish()
		{
			if (this.QtaViewParam == null)
			{
				return;
			}
			TQtaViewCallback finishCallback = this.QtaViewParam.FinishCallback;
			if (finishCallback == null)
			{
				return;
			}
			finishCallback(this.QtaViewParam.QtaHandleId, this.QtaResult);
		}

		// Token: 0x0401F172 RID: 127346
		private EQtaResult QtaResult;

		// Token: 0x0401F173 RID: 127347
		public QtaViewParam QtaViewParam;
	}
}
