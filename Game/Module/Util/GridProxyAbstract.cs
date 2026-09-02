using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C5F RID: 19551
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class GridProxyAbstract<[Nullable(2)] TData> : UiPanelBase, IGridProxy<TData>
	{
		// Token: 0x1700877B RID: 34683
		// (get) Token: 0x06032F0C RID: 208652 RVA: 0x00CC3055 File Offset: 0x00CC1255
		// (set) Token: 0x06032F0D RID: 208653 RVA: 0x00CC305D File Offset: 0x00CC125D
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

		// Token: 0x1700877C RID: 34684
		// (get) Token: 0x06032F0E RID: 208654 RVA: 0x00CC3066 File Offset: 0x00CC1266
		// (set) Token: 0x06032F0F RID: 208655 RVA: 0x00CC306E File Offset: 0x00CC126E
		public int GridIndex { get; set; }

		// Token: 0x1700877D RID: 34685
		// (get) Token: 0x06032F10 RID: 208656 RVA: 0x00CC3077 File Offset: 0x00CC1277
		// (set) Token: 0x06032F11 RID: 208657 RVA: 0x00CC307F File Offset: 0x00CC127F
		public int DisplayIndex { get; set; }

		// Token: 0x06032F12 RID: 208658 RVA: 0x00CC3088 File Offset: 0x00CC1288
		public virtual void Refresh(TData data, bool isSelected, int gridIndex)
		{
			throw new NotImplementedException("GridProxyAbstract 必须在子类中实现 Refresh");
		}

		// Token: 0x06032F13 RID: 208659 RVA: 0x00CC3094 File Offset: 0x00CC1294
		public virtual UniTask RefreshAsync(TData data, bool isSelected, int gridIndex)
		{
			throw new NotImplementedException("GridProxyAbstract 必须在子类中实现 RefreshAsync");
		}

		// Token: 0x06032F14 RID: 208660 RVA: 0x00CC30A0 File Offset: 0x00CC12A0
		public virtual void Clear()
		{
		}

		// Token: 0x06032F15 RID: 208661 RVA: 0x00CC30A2 File Offset: 0x00CC12A2
		public virtual void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06032F16 RID: 208662 RVA: 0x00CC30A4 File Offset: 0x00CC12A4
		public virtual void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06032F17 RID: 208663 RVA: 0x00CC30A6 File Offset: 0x00CC12A6
		public virtual void CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x06032F18 RID: 208664 RVA: 0x00CC30B0 File Offset: 0x00CC12B0
		public virtual UniTask CreateThenShowByActorAsync(AActor actor)
		{
			return base.CreateThenShowByActorAsync(actor, null, false);
		}

		// Token: 0x06032F19 RID: 208665 RVA: 0x00CC30BB File Offset: 0x00CC12BB
		public virtual UniTask CreateByActorAsync(AActor actor)
		{
			return base.CreateByActorAsync(actor, null, false);
		}

		// Token: 0x06032F1A RID: 208666 RVA: 0x00CC30C6 File Offset: 0x00CC12C6
		public virtual object GetKey(TData data, int displayIndex)
		{
			return this.GridIndex;
		}
	}
}
