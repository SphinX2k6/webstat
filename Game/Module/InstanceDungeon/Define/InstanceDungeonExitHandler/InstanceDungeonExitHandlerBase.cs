using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.InstanceDungeon.Define.InstanceDungeonExitHandler
{
	// Token: 0x02005C38 RID: 23608
	public abstract class InstanceDungeonExitHandlerBase
	{
		// Token: 0x0603BA74 RID: 244340
		public abstract bool Checker();

		// Token: 0x0603BA75 RID: 244341
		[NullableContext(2)]
		public abstract void HandleExit(InstanceDungeonExitHandlerData param);
	}
}
