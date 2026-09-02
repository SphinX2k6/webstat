using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C60 RID: 19552
	[NullableContext(2)]
	public interface IGridPreserver
	{
		// Token: 0x06032F1C RID: 208668
		int GetDisplayGridNum();

		// Token: 0x06032F1D RID: 208669
		int GetPreservedGridNum();

		// Token: 0x06032F1E RID: 208670
		int GetDisplayGridStartIndex();

		// Token: 0x06032F1F RID: 208671
		int GetDisplayGridEndIndex();

		// Token: 0x06032F20 RID: 208672
		UUIItem GetGrid(int gridIndex);

		// Token: 0x06032F21 RID: 208673
		UUIItem GetGridByDisplayIndex(int displayIndex);

		// Token: 0x06032F22 RID: 208674
		float GetGridAnimationInterval();

		// Token: 0x06032F23 RID: 208675
		float GetGridAnimationStartTime();

		// Token: 0x06032F24 RID: 208676
		void NotifyAnimationStart();

		// Token: 0x06032F25 RID: 208677
		void NotifyAnimationEnd();

		// Token: 0x06032F26 RID: 208678
		UUIInturnAnimController GetUiAnimController();
	}
}
