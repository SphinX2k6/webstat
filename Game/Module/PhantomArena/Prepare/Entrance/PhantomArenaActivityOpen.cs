using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GenericPrompt.View;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BD RID: 21693
	public class PhantomArenaActivityOpen : GenericPromptFloatTipsBase
	{
		// Token: 0x06037416 RID: 226326 RVA: 0x00E04431 File Offset: 0x00E02631
		[NullableContext(1)]
		public PhantomArenaActivityOpen(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06037417 RID: 226327 RVA: 0x00E0443A File Offset: 0x00E0263A
		protected override void SetMainText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}

		// Token: 0x06037418 RID: 226328 RVA: 0x00E0443C File Offset: 0x00E0263C
		protected override void SetExtraText([ParamCollection] [Nullable(new byte[]
		{
			1,
			2
		})] IReadOnlyList<object> param)
		{
		}
	}
}
