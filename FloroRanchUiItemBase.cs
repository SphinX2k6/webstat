using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001C77 RID: 7287
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUiItemBase : UiPanelBase
{
	// Token: 0x0600D4C7 RID: 54471 RVA: 0x0038CF1C File Offset: 0x0038B11C
	[NullableContext(2)]
	public FloroRanchEntityBase GetEntity()
	{
		return this.Entity;
	}

	// Token: 0x0600D4C8 RID: 54472 RVA: 0x0038CF24 File Offset: 0x0038B124
	public void BindData(FloroRanchEntityBase entity)
	{
		if (!this.CanBindEntity)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FloroRanchGamePlay;
			ELogAuthor author = ELogAuthor.BB;
			string message = base.GetType().Name + " 已经绑定了数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entity", entity.Info());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Entity = entity;
		this.CanBindEntity = false;
		Action<int> onEntityChangedCallback = this.OnEntityChangedCallback;
		if (onEntityChangedCallback == null)
		{
			return;
		}
		onEntityChangedCallback(entity.GetPoint());
	}

	// Token: 0x0600D4C9 RID: 54473 RVA: 0x0038CFA0 File Offset: 0x0038B1A0
	public void UnbindData()
	{
		if (this.Entity != null)
		{
			int point = this.Entity.GetPoint();
			this.Entity = null;
			this.CanBindEntity = true;
			Action<int> onEntityChangedCallback = this.OnEntityChangedCallback;
			if (onEntityChangedCallback == null)
			{
				return;
			}
			onEntityChangedCallback(point);
		}
	}

	// Token: 0x0600D4CA RID: 54474 RVA: 0x0038CFE0 File Offset: 0x0038B1E0
	public virtual UniTask ShowUiItem()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4CB RID: 54475 RVA: 0x0038CFE7 File Offset: 0x0038B1E7
	public virtual UniTask HideUiItem()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4CC RID: 54476 RVA: 0x0038CFEE File Offset: 0x0038B1EE
	public virtual UniTask RefreshItem()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4CD RID: 54477 RVA: 0x0038CFF5 File Offset: 0x0038B1F5
	public virtual UniTask PlayShowAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4CE RID: 54478 RVA: 0x0038CFFC File Offset: 0x0038B1FC
	public virtual UniTask PlayNormalAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4CF RID: 54479 RVA: 0x0038D003 File Offset: 0x0038B203
	public virtual UniTask PlayHideAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D0 RID: 54480 RVA: 0x0038D00A File Offset: 0x0038B20A
	public virtual void Pause()
	{
	}

	// Token: 0x0600D4D1 RID: 54481 RVA: 0x0038D00C File Offset: 0x0038B20C
	public virtual void Resume()
	{
	}

	// Token: 0x0600D4D2 RID: 54482 RVA: 0x0038D00E File Offset: 0x0038B20E
	public virtual UniTask MoveToItem(UUIItem targetItem)
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D3 RID: 54483 RVA: 0x0038D015 File Offset: 0x0038B215
	public virtual UniTask MoveToOriginalPosition()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D4 RID: 54484 RVA: 0x0038D01C File Offset: 0x0038B21C
	public virtual void MoveToOriginalPositionImmediate()
	{
	}

	// Token: 0x0600D4D5 RID: 54485 RVA: 0x0038D020 File Offset: 0x0038B220
	public virtual FTransform? GetRewardPopTransform()
	{
		return null;
	}

	// Token: 0x0600D4D6 RID: 54486 RVA: 0x0038D036 File Offset: 0x0038B236
	public virtual UniTask PlayEatAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D7 RID: 54487 RVA: 0x0038D03D File Offset: 0x0038B23D
	public virtual UniTask PlayBeEatAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D8 RID: 54488 RVA: 0x0038D044 File Offset: 0x0038B244
	public virtual UniTask PlaySacrificeAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4D9 RID: 54489 RVA: 0x0038D04B File Offset: 0x0038B24B
	public virtual UniTask PlayFusionHideAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4DA RID: 54490 RVA: 0x0038D052 File Offset: 0x0038B252
	public virtual UniTask PlayFusionShowAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4DB RID: 54491 RVA: 0x0038D059 File Offset: 0x0038B259
	public virtual UniTask PlayEvolveUpAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4DC RID: 54492 RVA: 0x0038D060 File Offset: 0x0038B260
	public virtual UniTask PlaySkillAnim()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600D4DD RID: 54493 RVA: 0x0038D067 File Offset: 0x0038B267
	public virtual void ShowCoinNiagara(long count)
	{
	}

	// Token: 0x0600D4DE RID: 54494 RVA: 0x0038D06C File Offset: 0x0038B26C
	public void ResetLayer()
	{
		FloroRanchEntityBase entity = this.Entity;
		int? num;
		if (entity == null)
		{
			num = null;
		}
		else
		{
			FloroRanchEntityDataComponent floroRanchEntityDataComponent = entity.CheckGetComponent<FloroRanchEntityDataComponent>();
			num = ((floroRanchEntityDataComponent != null) ? new int?(floroRanchEntityDataComponent.Point) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault(-1);
		this.GetOriginalItem().SetHierarchyIndex(valueOrDefault);
	}

	// Token: 0x0600D4DF RID: 54495 RVA: 0x0038D0C2 File Offset: 0x0038B2C2
	public void SetLayerTop()
	{
		UUIItem originalItem = this.GetOriginalItem();
		if (originalItem == null)
		{
			return;
		}
		originalItem.SetHierarchyIndex(99);
	}

	// Token: 0x0600D4E0 RID: 54496 RVA: 0x0038D0D6 File Offset: 0x0038B2D6
	public void BindEntityChangedCallback(Action<int> callback)
	{
		this.OnEntityChangedCallback = callback;
	}

	// Token: 0x04006533 RID: 25907
	[Nullable(2)]
	protected FloroRanchEntityBase Entity;

	// Token: 0x04006534 RID: 25908
	public bool CanBindEntity = true;

	// Token: 0x04006535 RID: 25909
	protected Action<int> OnEntityChangedCallback = delegate(int point)
	{
	};
}
