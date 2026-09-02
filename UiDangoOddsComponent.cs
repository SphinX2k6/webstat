using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C99 RID: 11417
[NullableContext(1)]
[Nullable(0)]
public class UiDangoOddsComponent : UiModelComponentBase
{
	// Token: 0x06016E95 RID: 93845 RVA: 0x0065A3C4 File Offset: 0x006585C4
	protected override void OnInit()
	{
		this.UiOddsItem = new RacingBetsOddsItem();
		this.UiOddsItem.CreateByResourceIdAsync("UiItem_RoleBetNum", Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pop), false);
		this.NeedTick = true;
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.UiModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016E96 RID: 93846 RVA: 0x0065A423 File Offset: 0x00658623
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E97 RID: 93847 RVA: 0x0065A447 File Offset: 0x00658647
	protected override void OnTick(float deltaTime)
	{
		this.FollowRootPosition();
	}

	// Token: 0x06016E98 RID: 93848 RVA: 0x0065A44F File Offset: 0x0065864F
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
		this.UiOddsItem.Destroy(null);
	}

	// Token: 0x06016E99 RID: 93849 RVA: 0x0065A47F File Offset: 0x0065867F
	private void OnModelLoadComplete()
	{
		this.FollowRootPosition();
	}

	// Token: 0x06016E9A RID: 93850 RVA: 0x0065A488 File Offset: 0x00658688
	private void FollowRootPosition()
	{
		if (this.UiModelActorComponent != null)
		{
			AActor actor = this.UiModelActorComponent.GetActor();
			float z = this.UiModelActorComponent.Actor.GetActorScale3D().Z;
			this.OddsOffset.Multiply((double)z, this.TargetOffset);
			FVector2D actorLguiPos = Singleton<UiModelUtil>.Instance.GetActorLguiPos(actor, this.TargetOffset);
			this.UiOddsItem.SetItemOffset(actorLguiPos);
		}
	}

	// Token: 0x06016E9B RID: 93851 RVA: 0x0065A4F1 File Offset: 0x006586F1
	public void SetOffset(float offset)
	{
		if (offset == 0f)
		{
			return;
		}
		this.OddsOffset.Z = (double)offset;
	}

	// Token: 0x06016E9C RID: 93852 RVA: 0x0065A509 File Offset: 0x00658709
	public void Refresh(int odds, int rank, bool isBet)
	{
		this.UiOddsItem.RefreshUi(odds, rank, isBet);
	}

	// Token: 0x06016E9D RID: 93853 RVA: 0x0065A519 File Offset: 0x00658719
	public void SetVisible(bool visible)
	{
		this.UiOddsItem.SetVisible(visible);
	}

	// Token: 0x0400B0B4 RID: 45236
	protected UiModelActorComponent UiModelActorComponent;

	// Token: 0x0400B0B5 RID: 45237
	protected UiModelDataComponent UiModelDataComponent;

	// Token: 0x0400B0B6 RID: 45238
	protected RacingBetsOddsItem UiOddsItem;

	// Token: 0x0400B0B7 RID: 45239
	private readonly Vector OddsOffset = Vector.Create(0.0, 0.0, 120.0);

	// Token: 0x0400B0B8 RID: 45240
	private readonly Vector TargetOffset = Vector.Create(0.0, 0.0, 120.0);
}
