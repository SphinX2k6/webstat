using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001A11 RID: 6673
[NullableContext(1)]
[Nullable(0)]
public abstract class LoopScrollSmallItemGrid<[Nullable(2)] TData> : SmallItemGrid, IGridProxy<TData>
{
	// Token: 0x17000FAA RID: 4010
	// (get) Token: 0x0600BF4B RID: 48971 RVA: 0x00329A5B File Offset: 0x00327C5B
	// (set) Token: 0x0600BF4C RID: 48972 RVA: 0x00329A63 File Offset: 0x00327C63
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

	// Token: 0x17000FAB RID: 4011
	// (get) Token: 0x0600BF4D RID: 48973 RVA: 0x00329A6C File Offset: 0x00327C6C
	// (set) Token: 0x0600BF4E RID: 48974 RVA: 0x00329A74 File Offset: 0x00327C74
	public int GridIndex { get; set; }

	// Token: 0x17000FAC RID: 4012
	// (get) Token: 0x0600BF4F RID: 48975 RVA: 0x00329A7D File Offset: 0x00327C7D
	// (set) Token: 0x0600BF50 RID: 48976 RVA: 0x00329A85 File Offset: 0x00327C85
	public int DisplayIndex { get; set; }

	// Token: 0x0600BF51 RID: 48977 RVA: 0x00329A8E File Offset: 0x00327C8E
	public virtual void Refresh(TData data, bool isSelected, int gridIndex)
	{
		this.OnRefresh(data, isSelected, gridIndex);
	}

	// Token: 0x0600BF52 RID: 48978
	protected abstract void OnRefresh(TData data, bool isSelected, int gridIndex);

	// Token: 0x0600BF53 RID: 48979 RVA: 0x00329A99 File Offset: 0x00327C99
	public void Clear()
	{
	}

	// Token: 0x0600BF54 RID: 48980 RVA: 0x00329A9B File Offset: 0x00327C9B
	public virtual void OnSelected(bool fireEvent)
	{
	}

	// Token: 0x0600BF55 RID: 48981 RVA: 0x00329A9D File Offset: 0x00327C9D
	public virtual void OnDeselected(bool fireEvent)
	{
	}

	// Token: 0x0600BF56 RID: 48982 RVA: 0x00329A9F File Offset: 0x00327C9F
	public void CreateThenShowByActor(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x0600BF57 RID: 48983 RVA: 0x00329AA9 File Offset: 0x00327CA9
	public UniTask CreateThenShowByActorAsync(AActor actor)
	{
		return base.CreateThenShowByActorAsync(actor, null, false);
	}

	// Token: 0x0600BF58 RID: 48984 RVA: 0x00329AB4 File Offset: 0x00327CB4
	public UniTask CreateByActorAsync(AActor actor)
	{
		return base.CreateByActorAsync(actor, null, false);
	}

	// Token: 0x0600BF59 RID: 48985 RVA: 0x00329ABF File Offset: 0x00327CBF
	protected override void OnAddEvents()
	{
		this.OnShowGridAnimationCallback = new Action<int, UUIItem>(this.OnShowGridAnimation);
		Singleton<EventSystem>.Instance.Add<int, UUIItem>(EEventName.OnShowGridAnimation, this.OnShowGridAnimationCallback);
	}

	// Token: 0x0600BF5A RID: 48986 RVA: 0x00329AE9 File Offset: 0x00327CE9
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, UUIItem>(EEventName.OnShowGridAnimation, this.OnShowGridAnimationCallback);
		this.OnShowGridAnimationCallback = null;
	}

	// Token: 0x0600BF5B RID: 48987 RVA: 0x00329B08 File Offset: 0x00327D08
	protected void OnShowGridAnimation(int gridIndex, UUIItem gridItem)
	{
		if (gridIndex != this.GridIndex)
		{
			return;
		}
		if (this.IsSelected)
		{
			this.SetSelected(false, false);
			this.SetSelected(true, false);
		}
	}

	// Token: 0x0600BF5C RID: 48988 RVA: 0x00329B2C File Offset: 0x00327D2C
	[return: Nullable(2)]
	public virtual object GetKey(TData data, int gridIndex)
	{
		return this.GridIndex;
	}

	// Token: 0x040059E5 RID: 23013
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIItem> OnShowGridAnimationCallback;
}
