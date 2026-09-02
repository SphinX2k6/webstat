using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D7D RID: 11645
[NullableContext(1)]
[Nullable(0)]
public class BulletActionCenter
{
	// Token: 0x060177DE RID: 96222 RVA: 0x00682AE6 File Offset: 0x00680CE6
	public void Init()
	{
		this.InitActions();
	}

	// Token: 0x060177DF RID: 96223 RVA: 0x00682AEE File Offset: 0x00680CEE
	public void Clear()
	{
		this.BulletActionContainerList = null;
	}

	// Token: 0x060177E0 RID: 96224 RVA: 0x00682AF8 File Offset: 0x00680CF8
	private void InitActions()
	{
		this.BulletActionContainerList = new BulletActionContainer[19];
		this.InitAction(EBulletAction.Test, typeof(BulletActionInfoSimple), typeof(BulletActionTest), false);
		this.InitAction(EBulletAction.InitBullet, typeof(BulletActionInfoSimple), typeof(BulletActionInitBullet), false);
		this.InitAction(EBulletAction.InitHit, typeof(BulletActionInfoSimple), typeof(BulletActionInitHit), false);
		this.InitAction(EBulletAction.InitMove, typeof(BulletActionInfoSimple), typeof(BulletActionInitMove), false);
		this.InitAction(EBulletAction.InitRender, typeof(BulletActionInfoSimple), typeof(BulletActionInitRender), true);
		this.InitAction(EBulletAction.TimeScale, typeof(BulletActionInfoSimple), typeof(BulletActionTimeScale), true);
		this.InitAction(EBulletAction.AfterInit, typeof(BulletActionInfoSimple), typeof(BulletActionAfterInit), false);
		this.InitAction(EBulletAction.InitCollision, typeof(BulletActionInfoSimple), typeof(BulletActionInitCollision), false);
		this.InitAction(EBulletAction.UpdateEffect, typeof(BulletActionInfoSimple), typeof(BulletActionUpdateEffect), true);
		this.InitAction(EBulletAction.UpdateAttackerFrozen, typeof(BulletActionInfoSimple), typeof(BulletActionUpdateAttackerFrozen), true);
		this.InitAction(EBulletAction.UpdateLiveTime, typeof(BulletActionInfoSimple), typeof(BulletActionUpdateLiveTime), true);
		this.InitAction(EBulletAction.Child, typeof(BulletActionInfoSimple), typeof(BulletActionChild), true);
		this.InitAction(EBulletAction.SummonBullet, typeof(BulletActionInfoSummonBullet), typeof(BulletActionSummonBullet), false);
		this.InitAction(EBulletAction.SummonEntity, typeof(BulletActionInfoSimple), typeof(BulletActionSummonEntity), false);
		this.InitAction(EBulletAction.DestroyBullet, typeof(BulletActionInfoDestroyBullet), typeof(BulletActionDestroyBullet), false);
		this.InitAction(EBulletAction.AttachActor, typeof(BulletActionInfoAttachActor), typeof(BulletActionAttachActor), false);
		this.InitAction(EBulletAction.AttachParentEffect, typeof(BulletActionInfoSimple), typeof(BulletActionAttachParentEffect), true);
		this.InitAction(EBulletAction.DelayDestroyBullet, typeof(BulletActionInfoDelayDestroyBullet), typeof(BulletActionDelayDestroyBullet), true);
		this.InitAction(EBulletAction.SceneInteract, typeof(BulletActionInfoSimple), typeof(BulletActionSceneInteract), true);
	}

	// Token: 0x060177E1 RID: 96225 RVA: 0x00682D30 File Offset: 0x00680F30
	private void InitAction(EBulletAction type, Type actionInfoClass, Type actionClass, bool isPersistentAction = false)
	{
		if (this.BulletActionContainerList[(int)type] != null)
		{
			return;
		}
		BulletActionContainer bulletActionContainer = new BulletActionContainer();
		bulletActionContainer.Init(type, actionInfoClass, actionClass, isPersistentAction);
		this.BulletActionContainerList[(int)type] = bulletActionContainer;
	}

	// Token: 0x060177E2 RID: 96226 RVA: 0x00682D62 File Offset: 0x00680F62
	public BulletActionContainer GetBulletActionContainer(EBulletAction type)
	{
		return this.BulletActionContainerList[(int)type];
	}

	// Token: 0x060177E3 RID: 96227 RVA: 0x00682D6C File Offset: 0x00680F6C
	public BulletActionInfoBase CreateBulletActionInfo(EBulletAction type)
	{
		return this.GetBulletActionContainer(type).GetActionInfo();
	}

	// Token: 0x060177E4 RID: 96228 RVA: 0x00682D7A File Offset: 0x00680F7A
	public void RecycleBulletActionInfo(BulletActionInfoBase actionInfo)
	{
		this.GetBulletActionContainer(actionInfo.Type).RecycleActionInfo(actionInfo);
	}

	// Token: 0x060177E5 RID: 96229 RVA: 0x00682D8E File Offset: 0x00680F8E
	public BulletActionBase CreateBulletAction(EBulletAction type)
	{
		return this.GetBulletActionContainer(type).GetAction();
	}

	// Token: 0x060177E6 RID: 96230 RVA: 0x00682D9C File Offset: 0x00680F9C
	public void RecycleBulletAction(BulletActionBase action)
	{
		this.GetBulletActionContainer(action.Type).RecycleAction(action);
	}

	// Token: 0x0400B41D RID: 46109
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private BulletActionContainer[] BulletActionContainerList;
}
