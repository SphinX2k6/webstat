using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Map.Container.MapOperation
{
	// Token: 0x020058F3 RID: 22771
	[NullableContext(1)]
	[Nullable(0)]
	[StaticVariableRuleIgnore]
	public static class MapOperationQueue
	{
		// Token: 0x06039CAB RID: 236715 RVA: 0x00EA34B0 File Offset: 0x00EA16B0
		public static void Run(IMapOperation op)
		{
			MapOperationQueue.<>c__DisplayClass1_0 CS$<>8__locals1 = new MapOperationQueue.<>c__DisplayClass1_0();
			CS$<>8__locals1.op = op;
			UiAsyncTask task = new UiAsyncTask("MapOperationQueue." + CS$<>8__locals1.op.OpName, delegate()
			{
				MapOperationQueue.<>c__DisplayClass1_0.<<Run>b__0>d <<Run>b__0>d;
				<<Run>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Run>b__0>d.<>4__this = CS$<>8__locals1;
				<<Run>b__0>d.<>1__state = -1;
				<<Run>b__0>d.<>t__builder.Start<MapOperationQueue.<>c__DisplayClass1_0.<<Run>b__0>d>(ref <<Run>b__0>d);
				return <<Run>b__0>d.<>t__builder.Task;
			}, null);
			MapOperationQueue.AsyncTaskManager.RunTask(task);
		}

		// Token: 0x06039CAC RID: 236716 RVA: 0x00EA3500 File Offset: 0x00EA1700
		public static void RunMapMark(IMapMarkOperation op)
		{
			if (op.OpName == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int?>(op.MarkId);
				defaultInterpolatedStringHandler.AppendLiteral(".");
				defaultInterpolatedStringHandler.AppendFormatted<EMarkType>(op.MarkType);
				op.OpName = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			MapOperationQueue.Run(op);
		}

		// Token: 0x06039CAD RID: 236717 RVA: 0x00EA355B File Offset: 0x00EA175B
		public static void Clear()
		{
			MapOperationQueue.AsyncTaskManager.CancelAllTask();
		}

		// Token: 0x04020C14 RID: 134164
		private static readonly UiAsyncTaskManager AsyncTaskManager = new UiAsyncTaskManager();
	}
}
