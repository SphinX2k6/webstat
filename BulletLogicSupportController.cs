using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002DD0 RID: 11728
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicSupportController : BulletLogicController<LogicDataSupport, Entity>
{
	// Token: 0x06017A2C RID: 96812 RVA: 0x006959F9 File Offset: 0x00693BF9
	public BulletLogicSupportController(LogicDataSupport logicConfig, Entity bulletEntity) : base(logicConfig, bulletEntity)
	{
	}

	// Token: 0x06017A2D RID: 96813 RVA: 0x00695A03 File Offset: 0x00693C03
	public override void OnInit()
	{
		this.InitTraceInfo();
		this.Bullet.GetBulletInfo().BulletDataMain.Execution.SupportCamp.Add(this.LogicController.Camp);
	}

	// Token: 0x06017A2E RID: 96814 RVA: 0x00695A38 File Offset: 0x00693C38
	private void InitTraceInfo()
	{
		this.TempTrans = new FTransformDouble?(new FTransformDouble());
		this.TempImpactPoint = Vector.Create(0.0, 0.0, 0.0);
		this.LineTrace = new UTraceLineElement();
		this.LineTrace.bIsSingle = true;
		this.LineTrace.bIgnoreSelf = true;
		this.LineTrace.AddObjectTypeQuery(KuroObjectTypeQuery.Bullet);
		this.LineTrace.DrawTime = 5f;
		Singleton<TraceElementCommon>.Instance.SetTraceColor(this.LineTrace, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.LineTrace, ColorUtils.LinearRed);
	}

	// Token: 0x06017A2F RID: 96815 RVA: 0x00695AE8 File Offset: 0x00693CE8
	public override void BulletLogicAction(Entity otherBullet)
	{
		BulletInfo bulletInfo = (otherBullet as BulletEntity).GetBulletInfo();
		if (bulletInfo.AttackerCamp != this.LogicController.Camp || bulletInfo.HasTag(this.LogicController.Tag))
		{
			return;
		}
		bulletInfo.AddTag(this.LogicController.Tag);
		if (ObjectUtils.SoftObjectReferenceValid<UEffectModelBase>(this.LogicController.Effect))
		{
			FTransformDouble hitPointTransform = this.GetHitPointTransform(otherBullet);
			BulletStaticFunction.PlayBulletEffect(GlobalData.World, this.LogicController.Effect.GetAssetPathName().ToString(), hitPointTransform, this.Bullet.GetBulletInfo(), "[BulletLogicSupportController.BulletLogicAction] " + bulletInfo.BulletRowName);
		}
	}

	// Token: 0x06017A30 RID: 96816 RVA: 0x00695B98 File Offset: 0x00693D98
	private FTransformDouble GetHitPointTransform(Entity otherBullet)
	{
		BulletActorComponent component = this.Bullet.GetComponent<BulletActorComponent>();
		AActor owner = otherBullet.GetComponent<BulletActorComponent>().Owner;
		FTransformDouble ftransformDouble = owner.D_GetTransform();
		FVectorDouble fvectorDouble = UKismetMathLibrary.D_TransformLocation(ftransformDouble, (otherBullet as BulletEntity).Data.Base.CenterOffset.ToUeVector(false));
		ftransformDouble = component.ActorTransform;
		FVectorDouble fvectorDouble2 = UKismetMathLibrary.D_TransformLocation(ftransformDouble, this.Bullet.Data.Base.CenterOffset.ToUeVector(false));
		if (this.LineTrace == null)
		{
			this.InitTraceInfo();
		}
		this.LineTrace.WorldContextObject = owner;
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.LineTrace, fvectorDouble);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.LineTrace, fvectorDouble2);
		FTransformDouble? tempTrans = this.TempTrans;
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(this.LineTrace, "BulletLogicSupportController_GetHitPointTransform");
		UKuroHitResult hitResult = this.LineTrace.HitResult;
		if (flag && hitResult.bBlockingHit)
		{
			Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, 0, this.TempImpactPoint);
			ftransformDouble = tempTrans.Value;
			FQuat fquat = component.ActorRotation.Quaternion();
			ftransformDouble.SetRotation(fquat);
			ftransformDouble = tempTrans.Value;
			FVectorDouble fvectorDouble3 = this.TempImpactPoint.ToUeVector(false);
			ftransformDouble.SetTranslation(fvectorDouble3);
			ftransformDouble = tempTrans.Value;
			ftransformDouble.SetScale3D(FVector.OneVector);
		}
		else
		{
			tempTrans = new FTransformDouble?(owner.D_GetTransform());
		}
		this.LineTrace.WorldContextObject = null;
		return tempTrans.Value;
	}

	// Token: 0x0400B625 RID: 46629
	private const string PROFILE_KEY = "BulletLogicSupportController_GetHitPointTransform";

	// Token: 0x0400B626 RID: 46630
	private const float DRAW_TIME = 5f;

	// Token: 0x0400B627 RID: 46631
	[Nullable(2)]
	private UTraceLineElement LineTrace;

	// Token: 0x0400B628 RID: 46632
	private FTransformDouble? TempTrans;

	// Token: 0x0400B629 RID: 46633
	[Nullable(2)]
	private Vector TempImpactPoint;
}
