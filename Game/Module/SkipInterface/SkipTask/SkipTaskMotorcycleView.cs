using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Functional;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F2E RID: 20270
	public class SkipTaskMotorcycleView : SkipTask
	{
		// Token: 0x060345BD RID: 214461 RVA: 0x00D1A937 File Offset: 0x00D18B37
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView(EFunctionType.MotorDevelop);
		}
	}
}
