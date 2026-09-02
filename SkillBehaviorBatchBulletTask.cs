using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002DDC RID: 11740
[NullableContext(2)]
[Nullable(0)]
public class SkillBehaviorBatchBulletTask
{
	// Token: 0x06017A9B RID: 96923 RVA: 0x0069A18A File Offset: 0x0069838A
	public float GetInterval()
	{
		return this.Interval;
	}

	// Token: 0x06017A9C RID: 96924 RVA: 0x0069A192 File Offset: 0x00698392
	public BaseSkillComponent GetSkillComponent()
	{
		return this.SkillComponent;
	}

	// Token: 0x06017A9D RID: 96925 RVA: 0x0069A19A File Offset: 0x0069839A
	public TsBaseCharacter GetOwner()
	{
		return this.Owner;
	}

	// Token: 0x06017A9E RID: 96926 RVA: 0x0069A1A2 File Offset: 0x006983A2
	public int GetSkillId()
	{
		return this.SkillId;
	}

	// Token: 0x06017A9F RID: 96927 RVA: 0x0069A1AC File Offset: 0x006983AC
	[NullableContext(1)]
	public static SkillBehaviorBatchBulletTask Create(Entity owner, TSoftObjectPtr<UPrimaryDataAsset> configSoftPtr, int skillId)
	{
		DAC_BatchCreateBullet_C dac_BatchCreateBullet_C = Singleton<ResourceSystem>.Instance.Load<DAC_BatchCreateBullet_C>(configSoftPtr.ToAssetPathName(), "js_undefined");
		SSkillBehaviorBatchBullet @base = dac_BatchCreateBullet_C.Base;
		SkillBehaviorBatchBulletTask skillBehaviorBatchBulletTask = new SkillBehaviorBatchBulletTask();
		skillBehaviorBatchBulletTask.SkillId = skillId;
		SkillBehaviorBatchBulletTask skillBehaviorBatchBulletTask2 = skillBehaviorBatchBulletTask;
		CharacterActorComponent component = owner.GetComponent<CharacterActorComponent>();
		skillBehaviorBatchBulletTask2.Owner = ((component != null) ? component.Actor : null);
		if (GameplayTagUtils.IsValidTag(new FGameplayTag?(@base.ContinueWithTag)))
		{
			skillBehaviorBatchBulletTask.TagComponent = owner.GetComponent<BaseTagComponent>();
		}
		skillBehaviorBatchBulletTask.SkillComponent = owner.GetComponent<BaseSkillComponent>();
		skillBehaviorBatchBulletTask.StopOnSkillEnd = @base.StopOnSkillEnd;
		CharacterCustomValueComponent component2 = owner.GetComponent<CharacterCustomValueComponent>();
		skillBehaviorBatchBulletTask.ContinueWithTagId = @base.ContinueWithTag.TagId();
		skillBehaviorBatchBulletTask.Id = new string[@base.Id.Num()];
		for (int i = 0; i < @base.Id.Num(); i++)
		{
			skillBehaviorBatchBulletTask.Id[i] = @base.Id.Get(i);
		}
		skillBehaviorBatchBulletTask.Interval = @base.Interval;
		skillBehaviorBatchBulletTask.Number = @base.Number;
		if (dac_BatchCreateBullet_C.BeginPos == EBatchBulletPosition.DotMatrix)
		{
			DAC_BatchCreateBulletDotMatrix_C dac_BatchCreateBulletDotMatrix_C = dac_BatchCreateBullet_C as DAC_BatchCreateBulletDotMatrix_C;
			skillBehaviorBatchBulletTask.Shape = BatchBulletPositionDotMatrix.Create(component2, dac_BatchCreateBulletDotMatrix_C.Shape);
		}
		else if (dac_BatchCreateBullet_C.BeginPos == EBatchBulletPosition.Circle)
		{
			DAC_BatchCreateBulletCircle_C dac_BatchCreateBulletCircle_C = dac_BatchCreateBullet_C as DAC_BatchCreateBulletCircle_C;
			skillBehaviorBatchBulletTask.Shape = BatchBulletPositionCircle.Create(component2, dac_BatchCreateBulletCircle_C.Shape);
			BatchBulletPositionCircle batchBulletPositionCircle = skillBehaviorBatchBulletTask.Shape as BatchBulletPositionCircle;
			if (Math.Abs(batchBulletPositionCircle.AngleInterval) < 1E-08)
			{
				batchBulletPositionCircle.AngleInterval = (double)(360 / skillBehaviorBatchBulletTask.Number);
			}
		}
		else if (dac_BatchCreateBullet_C.BeginPos == EBatchBulletPosition.Spline)
		{
			DAC_BatchCreateBulletSpline_C dac_BatchCreateBulletSpline_C = dac_BatchCreateBullet_C as DAC_BatchCreateBulletSpline_C;
			skillBehaviorBatchBulletTask.Shape = BatchBulletPositionSpline.Create(component2, dac_BatchCreateBulletSpline_C.Shape, skillBehaviorBatchBulletTask);
		}
		skillBehaviorBatchBulletTask.StartMoveAfterAllCreate = (@base.StartMoving == EBatchBulletMoveStartMode.所有生成才移动);
		return skillBehaviorBatchBulletTask;
	}

	// Token: 0x06017AA0 RID: 96928 RVA: 0x0069A38C File Offset: 0x0069858C
	public UniTask StartAsync()
	{
		SkillBehaviorBatchBulletTask.<StartAsync>d__19 <StartAsync>d__;
		<StartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartAsync>d__.<>4__this = this;
		<StartAsync>d__.<>1__state = -1;
		<StartAsync>d__.<>t__builder.Start<SkillBehaviorBatchBulletTask.<StartAsync>d__19>(ref <StartAsync>d__);
		return <StartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017AA1 RID: 96929 RVA: 0x0069A3D0 File Offset: 0x006985D0
	private void Start()
	{
		if (this.Shape.GetDelay() > 0f && !this.IsCreateContinue())
		{
			this.Shape.OnBreak();
			return;
		}
		this.BulletEntityId = new List<int>();
		if (this.Interval > 0f)
		{
			this.Action(0f);
			this.TimerHandle = TimerSystem.Instance.Loop(new TTimerAction(this.Action), this.Interval * 1000f, this.Number - 1, 1f, null, "[批量生成子弹]", true);
			return;
		}
		int num = 0;
		while (num < this.Number && (this.TagComponent == null || this.TagComponent.HasTag(this.ContinueWithTagId)) && (this.SkillId == 0 || !this.StopOnSkillEnd || (this.SkillComponent.CurrentSkill != null && this.SkillComponent.CurrentSkill.SkillId == this.SkillId)))
		{
			int num2 = this.CreateBullet(num);
			if (num2 != 0)
			{
				this.BulletEntityId.Add(num2);
			}
			num++;
		}
	}

	// Token: 0x06017AA2 RID: 96930 RVA: 0x0069A4DC File Offset: 0x006986DC
	private void Action(float delta = 0f)
	{
		if (this.IsCreateContinue())
		{
			int num = this.CreateBullet(this.Counter);
			if (num != 0)
			{
				this.BulletEntityId.Add(num);
				if (this.StartMoveAfterAllCreate)
				{
					ControllerBase<BulletController>.Instance.SetBulletSpeedRatio(num, 0f);
					ControllerBase<BulletController>.Instance.SetBulletLiveRatio(num, 0f);
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HCW, "批量生成子弹失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.Counter++;
			if (this.StartMoveAfterAllCreate && this.Counter >= this.Number)
			{
				for (int i = 0; i < this.Number; i++)
				{
					int id = this.BulletEntityId[i];
					ControllerBase<BulletController>.Instance.SetBulletSpeedRatio(id, 1f);
					ControllerBase<BulletController>.Instance.SetBulletLiveRatio(id, 1f);
				}
				this.Shape.OnEnd();
				return;
			}
		}
		else
		{
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle == null || !timerHandle.Remove())
			{
				Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.HCW, "停止批量生成子弹失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			this.Shape.OnBreak();
			if (this.Shape.IsDestroyOnEnd())
			{
				for (int j = 0; j < this.Number; j++)
				{
					ControllerBase<BulletController>.Instance.DestroyBullet(this.BulletEntityId[j], this.Shape.IsSummonChildBullet(), EBulletDestroyReason.Normal, false);
				}
				return;
			}
			if (this.StartMoveAfterAllCreate)
			{
				for (int k = 0; k < this.Number; k++)
				{
					ControllerBase<BulletController>.Instance.SetBulletSpeedRatio(this.BulletEntityId[k], 1f);
				}
			}
		}
	}

	// Token: 0x06017AA3 RID: 96931 RVA: 0x0069A688 File Offset: 0x00698888
	private int CreateBullet(int index)
	{
		string bulletRowName = this.Id[index % this.Id.Length];
		Transform transform = this.Shape.ToTransform(index);
		if (transform == null)
		{
			return 0;
		}
		BaseSkillComponent skillComponent = this.SkillComponent;
		Skill skill = (skillComponent != null) ? skillComponent.GetSkill(this.SkillId) : null;
		long? preContextId = (skill != null && skill.SkillBehaviorAnimNotifyMessageId != null) ? ((skill != null) ? skill.SkillBehaviorAnimNotifyMessageId : null) : ((skill != null) ? skill.CombatMessageId : null);
		Vector vector = this.Shape.ToTargetLocation(transform);
		return BulletUtil.CreateBulletFromAN(this.Owner, bulletRowName, new FTransformDouble?(transform.ToUeTransform()), this.SkillId, false, preContextId, (vector != null) ? new FVectorDouble?(vector.ToUeVector(false)) : null, null, null);
	}

	// Token: 0x06017AA4 RID: 96932 RVA: 0x0069A770 File Offset: 0x00698970
	private bool IsCreateContinue()
	{
		return (this.TagComponent == null || this.TagComponent.HasTag(this.ContinueWithTagId)) && (!this.StopOnSkillEnd || (this.SkillComponent.CurrentSkill != null && this.SkillComponent.CurrentSkill.SkillId == this.SkillId));
	}

	// Token: 0x0400B66D RID: 46701
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] Id;

	// Token: 0x0400B66E RID: 46702
	private float Interval;

	// Token: 0x0400B66F RID: 46703
	private int Number;

	// Token: 0x0400B670 RID: 46704
	private IBatchBulletPositionShape Shape;

	// Token: 0x0400B671 RID: 46705
	private bool StartMoveAfterAllCreate;

	// Token: 0x0400B672 RID: 46706
	private int ContinueWithTagId;

	// Token: 0x0400B673 RID: 46707
	private BaseTagComponent TagComponent;

	// Token: 0x0400B674 RID: 46708
	private BaseSkillComponent SkillComponent;

	// Token: 0x0400B675 RID: 46709
	private TsBaseCharacter Owner;

	// Token: 0x0400B676 RID: 46710
	private int SkillId;

	// Token: 0x0400B677 RID: 46711
	private bool StopOnSkillEnd;

	// Token: 0x0400B678 RID: 46712
	private int Counter;

	// Token: 0x0400B679 RID: 46713
	private List<int> BulletEntityId;

	// Token: 0x0400B67A RID: 46714
	private TimerHandle TimerHandle;
}
