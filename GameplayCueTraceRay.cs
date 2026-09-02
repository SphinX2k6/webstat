using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002FBC RID: 12220
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueTraceRay : GameplayCueEffect
{
	// Token: 0x06018EBB RID: 102075 RVA: 0x0070F6E6 File Offset: 0x0070D8E6
	protected override void OnInit()
	{
		base.OnInit();
		this.InitTrace();
		this.HitResultDistanceList = new List<GameplayCueTraceRay.HitResultDistance>();
	}

	// Token: 0x06018EBC RID: 102076 RVA: 0x0070F700 File Offset: 0x0070D900
	protected override void OnCreate()
	{
		base.OnCreate();
		if (this.TargetSocket != null)
		{
			this.HasSocket = (this.TargetSocket != FName.NAME_None);
		}
		this.EffectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle);
		if (this.CueConfig.ResourcesLength > 0)
		{
			Vector vector = Vector.Create();
			this.HitEffectItem = GameplayCueEffectCommonItem.Spawn(this.ActorInternal, vector.ToUeVector(false), this.CueConfig.Resources());
		}
	}

	// Token: 0x06018EBD RID: 102077 RVA: 0x0070F78C File Offset: 0x0070D98C
	protected override void OnDestroy()
	{
		base.OnDestroy();
		UTraceBaseElement traceElement = this.TraceElement;
		if (traceElement != null)
		{
			traceElement.Dispose();
		}
		this.TraceElement = null;
		this.EffectActor.Clear();
		GameplayCueEffectCommonItem hitEffectItem = this.HitEffectItem;
		if (hitEffectItem != null)
		{
			hitEffectItem.Destroy();
		}
		this.HitEffectItem = null;
		if (this.TraceDelegate != null)
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool, UTraceBaseElement, double, double>(this.TraceHitResultHandle));
			this.TraceDelegate = null;
		}
	}

	// Token: 0x06018EBE RID: 102078 RVA: 0x0070F7FA File Offset: 0x0070D9FA
	public override void OnEnable()
	{
		base.OnEnable();
		this.IsEnable = true;
		GameplayCueEffectCommonItem hitEffectItem = this.HitEffectItem;
		if (hitEffectItem == null)
		{
			return;
		}
		hitEffectItem.SetVisible(true);
	}

	// Token: 0x06018EBF RID: 102079 RVA: 0x0070F81A File Offset: 0x0070DA1A
	public override void OnDisable()
	{
		base.OnDisable();
		this.IsEnable = false;
		GameplayCueEffectCommonItem hitEffectItem = this.HitEffectItem;
		if (hitEffectItem == null)
		{
			return;
		}
		hitEffectItem.SetVisible(false);
	}

	// Token: 0x06018EC0 RID: 102080 RVA: 0x0070F83A File Offset: 0x0070DA3A
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		if (this.IsEnable)
		{
			this.Trace();
		}
	}

	// Token: 0x06018EC1 RID: 102081 RVA: 0x0070F854 File Offset: 0x0070DA54
	private void InitTrace()
	{
		int parametersLength = this.CueConfig.ParametersLength;
		if (parametersLength > 0)
		{
			this.TraceType = (GameplayCueTraceRay.ETraceType)Math.Min(int.Parse(this.CueConfig.Parameters(0)), 1);
		}
		List<EObjectTypeQuery> list = new List<EObjectTypeQuery>();
		if (parametersLength > 1)
		{
			string text = this.CueConfig.Parameters(1);
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == '1')
				{
					if (i == 0)
					{
						list.Add(KuroObjectTypeQuery.WorldStatic);
						list.Add(KuroObjectTypeQuery.WorldDynamic);
					}
					else if (i == 1)
					{
						list.Add(KuroObjectTypeQuery.PawnPlayer);
					}
					else if (i == 2)
					{
						list.Add(KuroObjectTypeQuery.PawnMonster);
					}
				}
			}
		}
		if (parametersLength > 2)
		{
			this.TraceLength = float.Parse(this.CueConfig.Parameters(2));
		}
		if (parametersLength > 3)
		{
			this.EffectScaleAxis = (GameplayCueTraceRay.EEffectScaleAxis)Math.Min(int.Parse(this.CueConfig.Parameters(3)), 2);
		}
		if (parametersLength > 4 && this.TraceType == GameplayCueTraceRay.ETraceType.Sphere)
		{
			this.TraceRadius = float.Parse(this.CueConfig.Parameters(4));
		}
		UTraceBaseElement utraceBaseElement;
		if (this.TraceType == GameplayCueTraceRay.ETraceType.Sphere)
		{
			utraceBaseElement = new UTraceSphereElement
			{
				Radius = this.TraceRadius
			};
		}
		else
		{
			utraceBaseElement = new UTraceLineElement();
		}
		utraceBaseElement.WorldContextObject = GlobalData.World;
		utraceBaseElement.bIsSingle = true;
		utraceBaseElement.bTraceComplex = false;
		utraceBaseElement.bIgnoreSelf = true;
		utraceBaseElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		foreach (EObjectTypeQuery objectType in list)
		{
			utraceBaseElement.AddObjectTypeQuery(objectType);
		}
		this.TraceElement = utraceBaseElement;
		this.TraceDelegate = global::DelegateUtils.ToManualReleaseDelegate<FAsyncTraceDelegate>(new Action<bool, UTraceBaseElement, double, double>(this.TraceHitResultHandle));
	}

	// Token: 0x06018EC2 RID: 102082 RVA: 0x0070FA18 File Offset: 0x0070DC18
	private void Trace()
	{
		if (this.TraceElement == null)
		{
			return;
		}
		ABaseCharacter actorInternal = this.ActorInternal;
		Vector traceStartPoint = this.TraceStartPoint;
		Vector traceEndPoint = this.TraceEndPoint;
		FTransform ftransform;
		if (this.HasSocket)
		{
			ftransform = actorInternal.Mesh.D_GetSocketTransform(this.TargetSocket, ERelativeTransformSpace.RTS_World).ToTransform();
		}
		else
		{
			ftransform = actorInternal.GetTransform();
		}
		this.TraceTransform.FromUeTransform(ftransform);
		Vector vector = traceStartPoint;
		FVector location = ftransform.GetLocation();
		vector.FromUeVector(location);
		this.TraceQuat.FromUeQuat(ftransform.GetRotation());
		this.TraceQuat.RotateVector(Vector.ForwardVectorProxy, this.TraceForward);
		traceEndPoint.FromUeVector(this.TraceForward);
		traceEndPoint.MultiplyEqual((double)this.TraceLength);
		traceEndPoint.AdditionEqual(traceStartPoint);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, traceStartPoint);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, traceEndPoint);
		TraceHandle traceHandle;
		if (this.TraceType == GameplayCueTraceRay.ETraceType.Sphere)
		{
			traceHandle = Singleton<TraceElementCommon>.Instance.AsyncSphereTrace((UTraceSphereElement)this.TraceElement, "ProfileGameplayCueTraceRay", this.TraceDelegate);
		}
		else
		{
			traceHandle = Singleton<TraceElementCommon>.Instance.AsyncLineTrace((UTraceLineElement)this.TraceElement, "ProfileGameplayCueTraceRay", this.TraceDelegate);
		}
		this.TraceFrame = (double)traceHandle.Frame;
		this.TraceIndex = (double)traceHandle.Index;
	}

	// Token: 0x06018EC3 RID: 102083 RVA: 0x0070FB68 File Offset: 0x0070DD68
	[NullableContext(2)]
	private void TraceHitResultHandle(bool result, UTraceBaseElement element, double frame, double index)
	{
		if (!this.IsActive || !this.IsEnable)
		{
			return;
		}
		if (frame < this.TraceFrame)
		{
			return;
		}
		if (frame == this.TraceFrame && index < this.TraceIndex)
		{
			return;
		}
		this.TraceFrame = frame;
		this.TraceIndex = index;
		UKuroHitResult hitResult = element.HitResult;
		int? num = (hitResult != null) ? new int?(hitResult.GetHitCount()) : null;
		int? num2 = num;
		int num3 = 0;
		if (!(num2.GetValueOrDefault() == num3 & num2 != null))
		{
			this.HitResultDistanceList.Clear();
			int num4 = 0;
			for (;;)
			{
				int num5 = num4;
				num2 = num;
				if (!(num5 < num2.GetValueOrDefault() & num2 != null))
				{
					break;
				}
				this.HitResultDistanceList.Add(new GameplayCueTraceRay.HitResultDistance
				{
					Distance = element.HitResult.DistanceArray.Get(num4),
					Index = num4
				});
				num4++;
			}
			if (this.HitResultDistanceList.Count > 0)
			{
				this.HitResultDistanceList.Sort((GameplayCueTraceRay.HitResultDistance a, GameplayCueTraceRay.HitResultDistance b) => a.Distance.CompareTo(b.Distance));
				if (this.EffectScaleAxis == GameplayCueTraceRay.EEffectScaleAxis.X)
				{
					this.EffectScale.X = (double)(this.HitResultDistanceList[0].Distance / this.TraceLength);
				}
				else if (this.EffectScaleAxis == GameplayCueTraceRay.EEffectScaleAxis.Y)
				{
					this.EffectScale.Y = (double)(this.HitResultDistanceList[0].Distance / this.TraceLength);
				}
				else
				{
					this.EffectScale.Z = (double)(this.HitResultDistanceList[0].Distance / this.TraceLength);
				}
				OneOf<KuroEffectActorHandle, AActor> effectActor = this.EffectActor;
				FVectorDouble fvectorDouble = this.EffectScale.ToUeVector(false);
				effectActor.D_SetActorScale3D(fvectorDouble);
				int index2 = this.HitResultDistanceList[0].Index;
				UKuroHitResult hitResult2 = element.HitResult;
				TArray<float> tarray = (hitResult2 != null) ? hitResult2.LocationX_Array : null;
				UKuroHitResult hitResult3 = element.HitResult;
				TArray<float> tarray2 = (hitResult3 != null) ? hitResult3.LocationY_Array : null;
				UKuroHitResult hitResult4 = element.HitResult;
				TArray<float> tarray3 = (hitResult4 != null) ? hitResult4.LocationZ_Array : null;
				this.HitResultLocation.X = ((tarray != null && index2 < tarray.Num()) ? ((double)tarray.Get(index2)) : this.HitResultLocation.X);
				this.HitResultLocation.Y = ((tarray2 != null && index2 < tarray2.Num()) ? ((double)tarray2.Get(index2)) : this.HitResultLocation.Y);
				this.HitResultLocation.Z = ((tarray3 != null && index2 < tarray3.Num()) ? ((double)tarray3.Get(index2)) : this.HitResultLocation.Z);
				GameplayCueEffectCommonItem hitEffectItem = this.HitEffectItem;
				if (hitEffectItem == null)
				{
					return;
				}
				hitEffectItem.Refresh(true, this.HitResultLocation, this.TraceTransform.GetRotation().Rotator(null));
				return;
			}
		}
		else
		{
			GameplayCueEffectCommonItem hitEffectItem2 = this.HitEffectItem;
			if (hitEffectItem2 == null)
			{
				return;
			}
			hitEffectItem2.Refresh(false, null, null);
		}
	}

	// Token: 0x0400C2C0 RID: 49856
	private const float DEFAULT_TRACE_LENGTH = 1000f;

	// Token: 0x0400C2C1 RID: 49857
	private const float DEFAULT_TRACE_RADIUS = 10f;

	// Token: 0x0400C2C2 RID: 49858
	private const string PROFILE_GAMEPLAY_CUE_TRACE_RAY = "ProfileGameplayCueTraceRay";

	// Token: 0x0400C2C3 RID: 49859
	[Nullable(2)]
	private UTraceBaseElement TraceElement;

	// Token: 0x0400C2C4 RID: 49860
	private GameplayCueTraceRay.ETraceType TraceType;

	// Token: 0x0400C2C5 RID: 49861
	private float TraceLength = 1000f;

	// Token: 0x0400C2C6 RID: 49862
	private float TraceRadius = 10f;

	// Token: 0x0400C2C7 RID: 49863
	private Vector TraceStartPoint = Vector.Create();

	// Token: 0x0400C2C8 RID: 49864
	private Vector TraceEndPoint = Vector.Create();

	// Token: 0x0400C2C9 RID: 49865
	private Vector TraceForward = Vector.Create();

	// Token: 0x0400C2CA RID: 49866
	private Transform TraceTransform = Transform.Create();

	// Token: 0x0400C2CB RID: 49867
	private Quat TraceQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C2CC RID: 49868
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private OneOf<KuroEffectActorHandle, AActor> EffectActor;

	// Token: 0x0400C2CD RID: 49869
	[Nullable(2)]
	private GameplayCueEffectCommonItem HitEffectItem;

	// Token: 0x0400C2CE RID: 49870
	private bool HasSocket;

	// Token: 0x0400C2CF RID: 49871
	private Vector HitResultLocation = Vector.Create();

	// Token: 0x0400C2D0 RID: 49872
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<GameplayCueTraceRay.HitResultDistance> HitResultDistanceList;

	// Token: 0x0400C2D1 RID: 49873
	private GameplayCueTraceRay.EEffectScaleAxis EffectScaleAxis;

	// Token: 0x0400C2D2 RID: 49874
	private Vector EffectScale = Vector.Create(1.0, 1.0, 1.0);

	// Token: 0x0400C2D3 RID: 49875
	private double TraceFrame;

	// Token: 0x0400C2D4 RID: 49876
	private double TraceIndex;

	// Token: 0x0400C2D5 RID: 49877
	[Nullable(2)]
	private FAsyncTraceDelegate TraceDelegate;

	// Token: 0x0400C2D6 RID: 49878
	private bool IsEnable = true;

	// Token: 0x02009343 RID: 37699
	[NullableContext(0)]
	private enum ETraceType
	{
		// Token: 0x04031059 RID: 200793
		Ray,
		// Token: 0x0403105A RID: 200794
		Sphere,
		// Token: 0x0403105B RID: 200795
		MAX
	}

	// Token: 0x02009344 RID: 37700
	[NullableContext(0)]
	private enum ETraceObjectType
	{
		// Token: 0x0403105D RID: 200797
		World,
		// Token: 0x0403105E RID: 200798
		Player,
		// Token: 0x0403105F RID: 200799
		Monster,
		// Token: 0x04031060 RID: 200800
		MAX
	}

	// Token: 0x02009345 RID: 37701
	[NullableContext(0)]
	private enum EEffectScaleAxis
	{
		// Token: 0x04031062 RID: 200802
		X,
		// Token: 0x04031063 RID: 200803
		Y,
		// Token: 0x04031064 RID: 200804
		Z,
		// Token: 0x04031065 RID: 200805
		MAX
	}

	// Token: 0x02009346 RID: 37702
	[NullableContext(0)]
	private class HitResultDistance
	{
		// Token: 0x04031066 RID: 200806
		public int Index;

		// Token: 0x04031067 RID: 200807
		public float Distance;
	}
}
