using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using UnrealEngine;

// Token: 0x02002DC9 RID: 11721
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicShakeCameraController : BulletLogicController<LogicDataShakeScreen, object>
{
	// Token: 0x06017A0C RID: 96780 RVA: 0x006943D4 File Offset: 0x006925D4
	public BulletLogicShakeCameraController(LogicDataShakeScreen param, Entity bullet) : base(param, bullet)
	{
		base.NeedTick = true;
		this.ActorComp = bullet.GetComponent<BulletActorComponent>();
		this.CountMax = (int)param.Count;
		this.MsInterval = param.Interval * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		if (CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.Bullet.GetBulletInfo().AttackerHandle))
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UClass>(this.LogicController.Shake.ToAssetPathName(), delegate([Nullable(2)] UClass shakeClass, string path)
			{
				this.ShakeClass = shakeClass;
			}, 100, "js_undefined");
		}
	}

	// Token: 0x06017A0D RID: 96781 RVA: 0x00694468 File Offset: 0x00692668
	protected override void Update(float deltaTime)
	{
		if (!this.Started)
		{
			return;
		}
		if (this.Counter >= this.CountMax)
		{
			return;
		}
		if (this.MsTimeCounter < this.MsInterval)
		{
			this.MsTimeCounter += deltaTime;
			return;
		}
		if (this.ShakeClass == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.PlayWorldCameraShake(this.ShakeClass, new FVectorDouble?(this.ActorComp.ActorLocation), this.LogicController.InnerRadius, this.LogicController.OuterRadius, this.LogicController.Falloff, this.LogicController.OrientShakeTowardsEpicenter, "MainCamera");
		this.MsTimeCounter = 0f;
		this.Counter++;
	}

	// Token: 0x06017A0E RID: 96782 RVA: 0x00694524 File Offset: 0x00692724
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		if (this.ShakeClass == null)
		{
			return;
		}
		ControllerBase<CameraController>.Instance.PlayWorldCameraShake(this.ShakeClass, new FVectorDouble?(this.ActorComp.ActorLocation), this.LogicController.InnerRadius, this.LogicController.OuterRadius, this.LogicController.Falloff, this.LogicController.OrientShakeTowardsEpicenter, "MainCamera");
		this.Started = true;
		this.MsTimeCounter = 0f;
		this.Counter = 1;
	}

	// Token: 0x0400B608 RID: 46600
	private readonly BulletActorComponent ActorComp;

	// Token: 0x0400B609 RID: 46601
	private bool Started;

	// Token: 0x0400B60A RID: 46602
	private float MsTimeCounter;

	// Token: 0x0400B60B RID: 46603
	private int Counter;

	// Token: 0x0400B60C RID: 46604
	private readonly int CountMax;

	// Token: 0x0400B60D RID: 46605
	private readonly float MsInterval;

	// Token: 0x0400B60E RID: 46606
	[Nullable(2)]
	private UClass ShakeClass;
}
