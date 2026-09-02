using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View
{
	// Token: 0x02004FCD RID: 20429
	public class SheriffAnalysisResultPop : UiViewBase
	{
		// Token: 0x06034AFD RID: 215805 RVA: 0x00D362B1 File Offset: 0x00D344B1
		[NullableContext(1)]
		public SheriffAnalysisResultPop(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034AFE RID: 215806 RVA: 0x00D362BC File Offset: 0x00D344BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06034AFF RID: 215807 RVA: 0x00D36330 File Offset: 0x00D34530
		protected override void OnStart()
		{
			bool flag = (bool)this.OpenParam;
			base.GetItem(0).SetUIActive(flag);
			base.GetItem(1).SetUIActive(!flag);
		}

		// Token: 0x06034B00 RID: 215808 RVA: 0x00D36366 File Offset: 0x00D34566
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x0200AF9A RID: 44954
		private static class EDefine
		{
			// Token: 0x040367EF RID: 223215
			public const int PanelSuccess = 0;

			// Token: 0x040367F0 RID: 223216
			public const int PanelFailure = 1;
		}
	}
}
