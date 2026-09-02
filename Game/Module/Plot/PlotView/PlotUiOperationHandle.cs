using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053D2 RID: 21458
	[NullableContext(1)]
	[Nullable(0)]
	public sealed class PlotUiOperationHandle
	{
		// Token: 0x06036C50 RID: 224336 RVA: 0x00DE4809 File Offset: 0x00DE2A09
		public PlotUiOperationHandle(string name, EUiViewName targetView, PlotUiAsyncOperation operation, CustomPromise<bool> resultPromise, [Nullable(2)] Action onCancel = null)
		{
			this.Name = name;
			this.TargetView = targetView;
			this.Operation = operation;
			this.ResultPromise = resultPromise;
			this.OnCancel = onCancel;
		}

		// Token: 0x17008DBB RID: 36283
		// (get) Token: 0x06036C51 RID: 224337 RVA: 0x00DE4836 File Offset: 0x00DE2A36
		public string Name { get; }

		// Token: 0x17008DBC RID: 36284
		// (get) Token: 0x06036C52 RID: 224338 RVA: 0x00DE483E File Offset: 0x00DE2A3E
		public EUiViewName TargetView { get; }

		// Token: 0x17008DBD RID: 36285
		// (get) Token: 0x06036C53 RID: 224339 RVA: 0x00DE4846 File Offset: 0x00DE2A46
		public PlotUiAsyncOperation Operation { get; }

		// Token: 0x17008DBE RID: 36286
		// (get) Token: 0x06036C54 RID: 224340 RVA: 0x00DE484E File Offset: 0x00DE2A4E
		public CustomPromise<bool> ResultPromise { get; }

		// Token: 0x17008DBF RID: 36287
		// (get) Token: 0x06036C55 RID: 224341 RVA: 0x00DE4856 File Offset: 0x00DE2A56
		[Nullable(2)]
		public Action OnCancel { [NullableContext(2)] get; }
	}
}
