using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C8D RID: 19597
	public class FindNavigationResult
	{
		// Token: 0x06033148 RID: 209224 RVA: 0x00CCB23D File Offset: 0x00CC943D
		public bool IsFindNavigation()
		{
			return this.Result == EFindNavigationResult.CanFocus;
		}

		// Token: 0x06033149 RID: 209225 RVA: 0x00CCB248 File Offset: 0x00CC9448
		public bool IsInLoopingProcess()
		{
			return this.Result == EFindNavigationResult.LoopOrLayoutAnimation;
		}

		// Token: 0x0603314A RID: 209226 RVA: 0x00CCB253 File Offset: 0x00CC9453
		public bool IsNotFindNavigation()
		{
			return this.Result == EFindNavigationResult.CantFocus;
		}

		// Token: 0x0603314B RID: 209227 RVA: 0x00CCB25E File Offset: 0x00CC945E
		public bool IsFinishFind()
		{
			return this.Result == EFindNavigationResult.CanFocus || this.Result == EFindNavigationResult.CantFocus;
		}

		// Token: 0x0401DB53 RID: 121683
		public EFindNavigationResult Result;

		// Token: 0x0401DB54 RID: 121684
		[Nullable(2)]
		public TsUiNavigationBehaviorListener Listener;
	}
}
