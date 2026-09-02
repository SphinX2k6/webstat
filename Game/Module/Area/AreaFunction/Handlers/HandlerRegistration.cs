using System;

namespace CSharpScript.Game.Module.Area.AreaFunction.Handlers
{
	// Token: 0x02006183 RID: 24963
	public static class HandlerRegistration
	{
		// Token: 0x0603F15B RID: 258395 RVA: 0x0102E01A File Offset: 0x0102C21A
		public static void RegisterAllAreaFunctionHandlers()
		{
			AreaFunctionRegistry.RegisterFunctionHandler(new AirCurrentHandler());
		}
	}
}
