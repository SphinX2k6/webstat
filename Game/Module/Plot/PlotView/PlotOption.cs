using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053BE RID: 21438
	[RequiredMember]
	public class PlotOption
	{
		// Token: 0x06036A9C RID: 223900 RVA: 0x00DD96A4 File Offset: 0x00DD78A4
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public PlotOption()
		{
		}

		// Token: 0x0401F7CB RID: 128971
		[Nullable(1)]
		[RequiredMember]
		public ITalkOption Config;

		// Token: 0x0401F7CC RID: 128972
		[RequiredMember]
		public bool ConditionCheck;

		// Token: 0x0401F7CD RID: 128973
		[Nullable(2)]
		public Action OnClick;
	}
}
