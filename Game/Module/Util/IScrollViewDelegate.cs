using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C7A RID: 19578
	public interface IScrollViewDelegate<out TProxy, [Nullable(2)] out TData> where TProxy : IGridProxy<TData>
	{
		// Token: 0x0603305A RID: 208986
		void SelectGridProxy(int gridIndex, int displayIndex, bool fireEvent);

		// Token: 0x0603305B RID: 208987
		int GetSelectedGridIndex();
	}
}
