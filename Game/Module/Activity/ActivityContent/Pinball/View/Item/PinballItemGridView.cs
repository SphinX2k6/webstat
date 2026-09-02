using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006609 RID: 26121
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class PinballItemGridView<[Nullable(2)] TData> : PinballItemView, IGridProxy<!0>
	{
		// Token: 0x17009F38 RID: 40760
		// (get) Token: 0x06041452 RID: 267346 RVA: 0x010BF50F File Offset: 0x010BD70F
		// (set) Token: 0x06041453 RID: 267347 RVA: 0x010BF517 File Offset: 0x010BD717
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<TData>, TData> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x17009F39 RID: 40761
		// (get) Token: 0x06041454 RID: 267348 RVA: 0x010BF520 File Offset: 0x010BD720
		// (set) Token: 0x06041455 RID: 267349 RVA: 0x010BF528 File Offset: 0x010BD728
		public int GridIndex { get; set; }

		// Token: 0x17009F3A RID: 40762
		// (get) Token: 0x06041456 RID: 267350 RVA: 0x010BF531 File Offset: 0x010BD731
		// (set) Token: 0x06041457 RID: 267351 RVA: 0x010BF539 File Offset: 0x010BD739
		public int DisplayIndex { get; set; }

		// Token: 0x06041458 RID: 267352
		public abstract UniTask RefreshAsync(TData data, bool isSelected, int gridIndex);

		// Token: 0x06041459 RID: 267353
		public abstract void Refresh(TData data, bool isSelected, int gridIndex);

		// Token: 0x0604145A RID: 267354 RVA: 0x010BF542 File Offset: 0x010BD742
		public void Clear()
		{
		}

		// Token: 0x0604145B RID: 267355 RVA: 0x010BF544 File Offset: 0x010BD744
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0604145C RID: 267356 RVA: 0x010BF546 File Offset: 0x010BD746
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0604145D RID: 267357 RVA: 0x010BF548 File Offset: 0x010BD748
		public object GetKey(TData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
