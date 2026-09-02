using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001CA9 RID: 7337
[NullableContext(1)]
[Nullable(0)]
public class FullScreenEffectView
{
	// Token: 0x0600D766 RID: 55142 RVA: 0x00399B6C File Offset: 0x00397D6C
	public UniTask Init(string path, int priority)
	{
		FullScreenEffectView.<Init>d__9 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.path = path;
		<Init>d__.priority = priority;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<FullScreenEffectView.<Init>d__9>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600D767 RID: 55143 RVA: 0x00399BC0 File Offset: 0x00397DC0
	public void SetEffectVisibility(bool visibility, bool eventControl)
	{
		if (eventControl)
		{
			if (visibility)
			{
				this.NiagaraComponentDelayId = TimerSystem.Instance.Delay(new TTimerAction(this.BindEffectEven), 100f, null, null, true, 1f);
			}
			else
			{
				this.UnBindEffectEvent();
			}
		}
		if (this.Visibility != visibility)
		{
			this.RootItem.SetIsUIActive(visibility);
			this.Visibility = visibility;
		}
	}

	// Token: 0x0600D768 RID: 55144 RVA: 0x00399C20 File Offset: 0x00397E20
	private void SetRootActor(AActor actor)
	{
		UUIItem rootItem = (UUIItem)actor.GetComponentByClass(UUIItem.StaticClass());
		this.RootActor = actor;
		this.RootItem = rootItem;
	}

	// Token: 0x0600D769 RID: 55145 RVA: 0x00399C51 File Offset: 0x00397E51
	public static int Compare(FullScreenEffectView a, FullScreenEffectView b)
	{
		return b.Priority - a.Priority;
	}

	// Token: 0x0600D76A RID: 55146 RVA: 0x00399C60 File Offset: 0x00397E60
	public void Destroy()
	{
		Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.HandleId);
		this.NiagaraSet.Clear();
		Singleton<ActorSystem>.Instance.Put("FullScreenEffectView.Destroy", this.RootActor, null);
	}

	// Token: 0x0600D76B RID: 55147 RVA: 0x00399C94 File Offset: 0x00397E94
	private void BindEffectEven(float _)
	{
		this.NiagaraSet.Clear();
	}

	// Token: 0x0600D76C RID: 55148 RVA: 0x00399CA1 File Offset: 0x00397EA1
	private void UnBindEffectEvent()
	{
		if (TimerSystem.Instance.Has(this.NiagaraComponentDelayId))
		{
			TimerSystem.Instance.Remove(this.NiagaraComponentDelayId);
		}
		this.NiagaraSet.Clear();
		this.NiagaraComponentDelayId = null;
	}

	// Token: 0x0600D76D RID: 55149 RVA: 0x00399CD8 File Offset: 0x00397ED8
	public void DeActive()
	{
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(this.RootActor, UUINiagara.StaticClass(), false);
		for (int i = 0; i < componentsInChildren.Num(); i++)
		{
			UUINiagara uuiniagara = (UUINiagara)componentsInChildren.Get(i);
			if (uuiniagara != null)
			{
				uuiniagara.DeactivateSystem();
			}
		}
	}

	// Token: 0x0600D76E RID: 55150 RVA: 0x00399D24 File Offset: 0x00397F24
	public bool IsEffectPlay()
	{
		TArray<UActorComponent> componentsInChildren = ULGUIBPLibrary.GetComponentsInChildren(this.RootActor, UUINiagara.StaticClass(), false);
		for (int i = 0; i < componentsInChildren.Num(); i++)
		{
			if ((UUINiagara)componentsInChildren.Get(i) != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400660E RID: 26126
	[Nullable(2)]
	protected UUIItem RootItem;

	// Token: 0x0400660F RID: 26127
	[Nullable(2)]
	protected AActor RootActor;

	// Token: 0x04006610 RID: 26128
	public int Priority;

	// Token: 0x04006611 RID: 26129
	public string Path = string.Empty;

	// Token: 0x04006612 RID: 26130
	private bool Visibility = true;

	// Token: 0x04006613 RID: 26131
	[Nullable(2)]
	private TimerHandle NiagaraComponentDelayId;

	// Token: 0x04006614 RID: 26132
	private readonly HashSet<int> NiagaraSet = new HashSet<int>();

	// Token: 0x04006615 RID: 26133
	private int HandleId;

	// Token: 0x04006616 RID: 26134
	private const int DELAY_TIME = 100;
}
