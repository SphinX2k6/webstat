using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C61 RID: 19553
	[NullableContext(1)]
	public interface IGridProxy<[Nullable(2)] TData>
	{
		// Token: 0x1700877E RID: 34686
		// (get) Token: 0x06032F27 RID: 208679
		// (set) Token: 0x06032F28 RID: 208680
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		IScrollViewDelegate<IGridProxy<TData>, TData> ScrollViewDelegate { [return: Nullable(new byte[]
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

		// Token: 0x1700877F RID: 34687
		// (get) Token: 0x06032F29 RID: 208681
		// (set) Token: 0x06032F2A RID: 208682
		int GridIndex { get; set; }

		// Token: 0x17008780 RID: 34688
		// (get) Token: 0x06032F2B RID: 208683
		// (set) Token: 0x06032F2C RID: 208684
		int DisplayIndex { get; set; }

		// Token: 0x06032F2D RID: 208685 RVA: 0x00CC30DB File Offset: 0x00CC12DB
		void Refresh(TData data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x06032F2E RID: 208686 RVA: 0x00CC30E0 File Offset: 0x00CC12E0
		UniTask RefreshAsync(TData data, bool isSelected, int gridIndex)
		{
			IGridProxy<TData>.<RefreshAsync>d__10 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<IGridProxy<TData>.<RefreshAsync>d__10>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032F2F RID: 208687
		void Clear();

		// Token: 0x06032F30 RID: 208688
		void OnSelected(bool fireEvent);

		// Token: 0x06032F31 RID: 208689
		void OnDeselected(bool fireEvent);

		// Token: 0x06032F32 RID: 208690
		void CreateThenShowByActor(AActor actor, [Nullable(2)] object parameters = null);

		// Token: 0x06032F33 RID: 208691
		UniTask CreateThenShowByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false);

		// Token: 0x06032F34 RID: 208692
		UniTask CreateByActorAsync(AActor actor, [Nullable(2)] object parameters = null, bool usePool = false);

		// Token: 0x06032F35 RID: 208693
		object GetKey(TData data, int gridIndex);
	}
}
