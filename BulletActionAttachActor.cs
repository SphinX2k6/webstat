using System;
using UnrealEngine;

// Token: 0x02002D79 RID: 11641
public class BulletActionAttachActor : BulletActionBase
{
	// Token: 0x060177D0 RID: 96208 RVA: 0x00682790 File Offset: 0x00680990
	public BulletActionAttachActor(EBulletAction type) : base(type)
	{
	}

	// Token: 0x060177D1 RID: 96209 RVA: 0x0068279C File Offset: 0x0068099C
	protected unsafe override void OnExecute()
	{
		BulletActionInfoAttachActor bulletActionInfoAttachActor = (BulletActionInfoAttachActor)this.ActionInfo;
		if (bulletActionInfoAttachActor.IsParentActor)
		{
			this.BulletInfo.Actor.K2_AttachToActor(bulletActionInfoAttachActor.Actor, bulletActionInfoAttachActor.SocketName ?? FName.NAME_None, bulletActionInfoAttachActor.LocationRule.Value, bulletActionInfoAttachActor.RotationRule.Value, bulletActionInfoAttachActor.ScaleRule.Value, bulletActionInfoAttachActor.WeldSimulatedBodies, true);
			this.BulletInfo.ActorComponent.NeedDetach = true;
			this.BulletInfo.ActorComponent.NeedDetachForBaseMovement = false;
			if (Singleton<BulletConstant>.Instance.OpenMoveLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Bullet;
				ELogAuthor author = ELogAuthor.HCW;
				string message = "BulletActionAttachActor";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Bullet", this.BulletInfo.BulletRowName);
				ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
				string item = "Actor";
				AActor actor = bulletActionInfoAttachActor.Actor;
				ptr = new ValueTuple<string, object>(item, (actor != null) ? actor.GetName() : null);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NeedDetach", this.BulletInfo.ActorComponent.NeedDetach);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			}
			if (bulletActionInfoAttachActor.RelativeLocation != null)
			{
				this.BulletInfo.Actor.D_K2_SetActorRelativeLocation(bulletActionInfoAttachActor.RelativeLocation.Value, true, ref WorldGlobal.SweepHitResult, true);
			}
			if (bulletActionInfoAttachActor.RelativeRotation != null)
			{
				this.BulletInfo.Actor.K2_SetActorRelativeRotation(bulletActionInfoAttachActor.RelativeRotation.Value, true, ref WorldGlobal.SweepHitResult, true);
				return;
			}
		}
		else
		{
			bulletActionInfoAttachActor.Actor.K2_AttachToActor(this.BulletInfo.Actor, bulletActionInfoAttachActor.SocketName ?? FName.NAME_None, bulletActionInfoAttachActor.LocationRule.Value, bulletActionInfoAttachActor.RotationRule.Value, bulletActionInfoAttachActor.ScaleRule.Value, bulletActionInfoAttachActor.WeldSimulatedBodies, true);
			this.BulletInfo.ActorComponent.ChildrenAttached.Add(bulletActionInfoAttachActor.Actor);
			if (bulletActionInfoAttachActor.RelativeLocation != null)
			{
				bulletActionInfoAttachActor.Actor.D_K2_SetActorRelativeLocation(bulletActionInfoAttachActor.RelativeLocation.Value, true, ref WorldGlobal.SweepHitResult, true);
			}
			if (bulletActionInfoAttachActor.RelativeRotation != null)
			{
				bulletActionInfoAttachActor.Actor.K2_SetActorRelativeRotation(bulletActionInfoAttachActor.RelativeRotation.Value, true, ref WorldGlobal.SweepHitResult, true);
			}
		}
	}
}
