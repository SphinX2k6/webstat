using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4F RID: 20303
	public class SkipToMapWithPhantomAreaChallenge : SkipTask
	{
		// Token: 0x06034600 RID: 214528 RVA: 0x00D1BD18 File Offset: 0x00D19F18
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			PhantomArenaBattleController.OpenPhantomArenaMapEntrance(new int?((int)data[0]), new bool?(true));
			base.Finish();
		}
	}
}
