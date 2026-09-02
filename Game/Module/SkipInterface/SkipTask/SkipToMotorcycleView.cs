using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Functional;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F51 RID: 20305
	public class SkipToMotorcycleView : SkipTask
	{
		// Token: 0x06034605 RID: 214533 RVA: 0x00D1BDB4 File Offset: 0x00D19FB4
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
