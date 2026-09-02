using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AutoAttach
{
	// Token: 0x02006155 RID: 24917
	[NullableContext(2)]
	public interface IAutoAttachBaseView<T>
	{
		// Token: 0x0603EF46 RID: 257862
		int GetDataLength();

		// Token: 0x0603EF47 RID: 257863
		int GetShowItemNum();

		// Token: 0x0603EF48 RID: 257864
		float GetItemSize();

		// Token: 0x0603EF49 RID: 257865
		float GetGap();

		// Token: 0x0603EF4A RID: 257866
		bool GetIfCircle();

		// Token: 0x0603EF4B RID: 257867
		float GetViewSize();

		// Token: 0x0603EF4C RID: 257868
		EAttachDirection? GetCurrentMoveDirection();

		// Token: 0x0603EF4D RID: 257869
		float GetTrueBoundary();

		// Token: 0x0603EF4E RID: 257870
		int GetCurrentSelectIndex();
	}
}
