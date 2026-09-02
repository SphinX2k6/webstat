using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053BA RID: 21434
	[NullableContext(2)]
	public interface ISimulatePlot
	{
		// Token: 0x06036A89 RID: 223881
		void SimulateClickSubtitle();

		// Token: 0x06036A8A RID: 223882
		void SimulateClickOption();

		// Token: 0x17008DB2 RID: 36274
		// (get) Token: 0x06036A8B RID: 223883
		ITalkItem CurrentSubtitle { get; }
	}
}
