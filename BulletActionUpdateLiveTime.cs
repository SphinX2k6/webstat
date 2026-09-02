using System;
using UnrealEngine;

// Token: 0x02002D96 RID: 11670
public class BulletActionUpdateLiveTime : BulletActionBase
{
	// Token: 0x06017871 RID: 96369 RVA: 0x0068AFDD File Offset: 0x006891DD
	public BulletActionUpdateLiveTime(EBulletAction type) : base(type)
	{
	}

	// Token: 0x06017872 RID: 96370 RVA: 0x0068AFE6 File Offset: 0x006891E6
	protected override void OnExecute()
	{
		this.BulletInfo.LiveTime = 0f;
		this.BulletInfo.LiveTimeAddDelta = 0f;
		this.BulletInfo.CreateFrame = 0;
	}

	// Token: 0x06017873 RID: 96371 RVA: 0x0068B014 File Offset: 0x00689214
	public override void AfterTick(float delta)
	{
		if (this.BulletInfo.CreateFrame == 0)
		{
			this.BulletInfo.CreateFrame = Singleton<Time>.Instance.Frame;
		}
		this.BulletInfo.LiveTime = this.BulletInfo.LiveTimeAddDelta;
		if (this.BulletInfo.NeedDestroy)
		{
			return;
		}
		AActor actor = this.BulletInfo.Actor;
		if (actor == null || !actor.IsValid())
		{
			this.DestroyBullet();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "子弹Actor被意外销毁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("子弹Id", this.BulletInfo.BulletRowName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (actor.IsActorBeingDestroyed())
		{
			this.DestroyBullet();
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "子弹Actor.IsActorBeingDestroyed为true";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("子弹Id", this.BulletInfo.BulletRowName);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		float duration = this.BulletInfo.Duration;
		if (duration < 0f)
		{
			return;
		}
		if (this.BulletInfo.LiveTime >= duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond)
		{
			this.BulletInfo.IsTimeNotEnough = true;
			this.DestroyBullet();
			return;
		}
		if (this.BulletInfo.AttackerHandle == null)
		{
			this.DestroyBullet();
		}
	}

	// Token: 0x06017874 RID: 96372 RVA: 0x0068B151 File Offset: 0x00689351
	private void DestroyBullet()
	{
		ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletInfo.BulletEntityId, false, EBulletDestroyReason.Normal, false);
		this.IsFinish = true;
	}
}
