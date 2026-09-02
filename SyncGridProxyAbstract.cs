using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02002CD0 RID: 11472
[NullableContext(1)]
[Nullable(0)]
public abstract class SyncGridProxyAbstract<[Nullable(2)] TData> : UiPanelBase, ISyncGridProxy<TData>, ISyncGridProxy
{
	// Token: 0x17001E6D RID: 7789
	// (get) Token: 0x060171C4 RID: 94660 RVA: 0x0066729D File Offset: 0x0066549D
	// (set) Token: 0x060171C5 RID: 94661 RVA: 0x006672A5 File Offset: 0x006654A5
	public int GridIndex { get; set; }

	// Token: 0x060171C6 RID: 94662 RVA: 0x006672AE File Offset: 0x006654AE
	public virtual void Refresh(TData data)
	{
	}

	// Token: 0x060171C7 RID: 94663 RVA: 0x006672B0 File Offset: 0x006654B0
	public virtual void Clear()
	{
	}

	// Token: 0x060171C8 RID: 94664 RVA: 0x006672B2 File Offset: 0x006654B2
	public void CreateByActor(AActor actor)
	{
		base.CreateByActor(actor, null);
	}

	// Token: 0x060171C9 RID: 94665 RVA: 0x006672BC File Offset: 0x006654BC
	public void CreateThenShowByActor(AActor actor)
	{
		base.CreateThenShowByActor(actor, null);
	}

	// Token: 0x060171CA RID: 94666 RVA: 0x006672C6 File Offset: 0x006654C6
	protected override UniTask OnCreateAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x060171CB RID: 94667 RVA: 0x006672CD File Offset: 0x006654CD
	protected override UniTask OnBeforeStartAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x060171CC RID: 94668 RVA: 0x006672D4 File Offset: 0x006654D4
	void ISyncGridProxy.Refresh(object data)
	{
		this.Refresh((TData)((object)data));
	}
}
