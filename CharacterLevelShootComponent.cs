using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay.AimLine;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.NewWorld.SceneItem.Model;
using UnrealEngine;

// Token: 0x02003057 RID: 12375
[NullableContext(1)]
[Nullable(0)]
public class CharacterLevelShootComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x06019663 RID: 104035 RVA: 0x00753CC4 File Offset: 0x00751EC4
	static CharacterLevelShootComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterLevelShootComponent.CreateStaticDefaultValue), new Action(CharacterLevelShootComponent.ResetStaticDefaultValue));
	}

	// Token: 0x1700223D RID: 8765
	// (get) Token: 0x06019664 RID: 104036 RVA: 0x00753CED File Offset: 0x00751EED
	private static List<Vector> VectorPool
	{
		get
		{
			return CharacterLevelShootComponent._vectorPool;
		}
	}

	// Token: 0x1700223E RID: 8766
	// (get) Token: 0x06019665 RID: 104037 RVA: 0x00753CF4 File Offset: 0x00751EF4
	private static List<List<Vector>> VectorArrayPool
	{
		get
		{
			return CharacterLevelShootComponent._vectorArrayPool;
		}
	}

	// Token: 0x06019666 RID: 104038 RVA: 0x00753CFC File Offset: 0x00751EFC
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.SplinePoints = new List<Vector>();
		this.StartTrackLocation = Vector.Create();
		this.TrackDir = Vector.Create();
		this.EndTrackLocation = Vector.Create();
		this.TempVector = Vector.Create();
		this.FireVector = Vector.Create();
		this.HitReboundInfoMap = new Dictionary<int, List<Vector>>();
		return true;
	}

	// Token: 0x06019667 RID: 104039 RVA: 0x00753D79 File Offset: 0x00751F79
	protected override void OnActivate()
	{
		this.InitBulletTraceElement();
		this.OnArmFireBulletTask = this.TagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["功能.功能制作.瞄准模式.射击通知"]), new BaseTagComponent.TTagSwitchedCallback(this.OnArmShoot), null);
	}

	// Token: 0x06019668 RID: 104040 RVA: 0x00753DB4 File Offset: 0x00751FB4
	public override bool End()
	{
		this.ActorComp = null;
		this.TagComp = null;
		this.BulletTraceElement = null;
		this.SplinePoints = null;
		this.StartTrackLocation = null;
		this.TrackDir = null;
		this.EndTrackLocation = null;
		this.TempVector = null;
		ITagTask onArmFireBulletTask = this.OnArmFireBulletTask;
		if (onArmFireBulletTask != null)
		{
			onArmFireBulletTask.EndTask();
		}
		this.OnArmFireBulletTask = null;
		this.FireVector = null;
		this.HitReboundInfoMap = null;
		return true;
	}

	// Token: 0x06019669 RID: 104041 RVA: 0x00753E20 File Offset: 0x00752020
	private void InitBulletTraceElement()
	{
		if (this.BulletTraceElement == null)
		{
			this.BulletTraceElement = new UTraceLineElement();
			this.BulletTraceElement.bIsSingle = true;
			this.BulletTraceElement.bIgnoreSelf = true;
			this.BulletTraceElement.SetTraceTypeQuery(KuroTraceTypeQuery.Visible);
		}
		this.BulletTraceElement.WorldContextObject = this.ActorComp.Owner;
	}

	// Token: 0x0601966A RID: 104042 RVA: 0x00753E7E File Offset: 0x0075207E
	public void OnEnterAimShoot()
	{
		if (!this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.显示射击轨迹"]))
		{
			return;
		}
		if (this.IsActive)
		{
			return;
		}
		this.IsActive = true;
		ControllerBase<LevelAimLineController>.Instance.PlayEffect("/Game/Aki/Effect/EffectGroup/BigWorld/DA_Fx_Group_SignalSpline.DA_Fx_Group_SignalSpline");
	}

	// Token: 0x0601966B RID: 104043 RVA: 0x00753EBD File Offset: 0x007520BD
	public void OnExitAimShoot()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.IsActive = false;
		ControllerBase<LevelAimLineController>.Instance.StopEffect();
	}

	// Token: 0x0601966C RID: 104044 RVA: 0x00753EDA File Offset: 0x007520DA
	private void OnArmShoot(int tagId, bool tagExist)
	{
	}

	// Token: 0x0601966D RID: 104045 RVA: 0x00753EDC File Offset: 0x007520DC
	protected override void OnTick(float delta)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.UpdateAimInstructionSpline();
	}

	// Token: 0x0601966E RID: 104046 RVA: 0x00753EED File Offset: 0x007520ED
	public Vector GetEndPointPosition(Vector start, Vector dir)
	{
		dir.Multiply((double)this.TrackLength, this.EndTrackLocation);
		start.Addition(this.EndTrackLocation, this.EndTrackLocation);
		return this.EndTrackLocation;
	}

	// Token: 0x0601966F RID: 104047 RVA: 0x00753F1C File Offset: 0x0075211C
	private Vector GetVector()
	{
		if (CharacterLevelShootComponent.VectorPool.Count < 1)
		{
			return Vector.Create();
		}
		List<Vector> vectorPool = CharacterLevelShootComponent.VectorPool;
		Vector result = vectorPool[vectorPool.Count - 1];
		CharacterLevelShootComponent.VectorPool.RemoveAt(CharacterLevelShootComponent.VectorPool.Count - 1);
		return result;
	}

	// Token: 0x06019670 RID: 104048 RVA: 0x00753F59 File Offset: 0x00752159
	private void ReleaseVector(Vector value)
	{
		value.Set(0.0, 0.0, 0.0);
		CharacterLevelShootComponent.VectorPool.Add(value);
	}

	// Token: 0x06019671 RID: 104049 RVA: 0x00753F87 File Offset: 0x00752187
	private List<Vector> GetVectorArray()
	{
		if (CharacterLevelShootComponent.VectorArrayPool.Count < 1)
		{
			return new List<Vector>();
		}
		List<List<Vector>> vectorArrayPool = CharacterLevelShootComponent.VectorArrayPool;
		List<Vector> result = vectorArrayPool[vectorArrayPool.Count - 1];
		CharacterLevelShootComponent.VectorArrayPool.RemoveAt(CharacterLevelShootComponent.VectorArrayPool.Count - 1);
		return result;
	}

	// Token: 0x06019672 RID: 104050 RVA: 0x00753FC4 File Offset: 0x007521C4
	private void ReleaseVectorArray(List<Vector> value)
	{
		foreach (Vector value2 in value)
		{
			this.ReleaseVector(value2);
		}
		value.Clear();
		CharacterLevelShootComponent.VectorArrayPool.Add(value);
	}

	// Token: 0x06019673 RID: 104051 RVA: 0x00754024 File Offset: 0x00752224
	private void UpdateAimInstructionSpline()
	{
		FTransformDouble ftransformDouble = this.ActorComp.SkeletalMesh.D_GetSocketTransform(new FName("WeaponProp01_2"), ERelativeTransformSpace.RTS_World);
		APlayerCameraManager characterCameraManager = Global.CharacterCameraManager;
		Vector trackDir = this.TrackDir;
		FVector actorForwardVector = characterCameraManager.GetActorForwardVector();
		trackDir.FromUeVector(actorForwardVector);
		this.TrackDir.Multiply(CharacterLevelShootComponent.FireBulletPositionOffset, this.TempVector);
		Vector startTrackLocation = this.StartTrackLocation;
		FVectorDouble fvectorDouble = characterCameraManager.D_GetCameraLocation();
		startTrackLocation.FromUeVector(fvectorDouble);
		this.StartTrackLocation.Addition(this.TempVector, this.StartTrackLocation);
		this.EndTrackLocation = this.GetEndPointPosition(this.StartTrackLocation, this.TrackDir);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.BulletTraceElement, this.StartTrackLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.BulletTraceElement, this.EndTrackLocation);
		Vector startTrackLocation2 = this.StartTrackLocation;
		fvectorDouble = ftransformDouble.GetLocation();
		startTrackLocation2.FromUeVector(fvectorDouble);
		this.SplinePoints.Add(this.StartTrackLocation);
		bool flag = Singleton<TraceElementCommon>.Instance.LineTrace(this.BulletTraceElement, "CharacterLevelShootComponent_PreCalculateBulletTrack");
		bool flag2 = false;
		bool flag3 = false;
		if (flag)
		{
			UKuroHitResult hitResult = this.BulletTraceElement.HitResult;
			while (hitResult.GetHitCount() > 0)
			{
				Vector vector = this.GetVector();
				Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, 0, vector);
				this.SplinePoints.Add(vector);
				this.SplinePoints[this.SplinePoints.Count - 1].Subtraction(this.SplinePoints[this.SplinePoints.Count - 2], this.TrackDir);
				this.TrackDir.Normalize(9.99999993922529E-09);
				TWeakObjectPtr<AActor> weak = hitResult.Actors.Get(0);
				EntityHandle entityByActor = ModelBase<SceneInteractionModel>.Instance.GetEntityByActor(weak, false);
				if (entityByActor == null)
				{
					flag2 = true;
					break;
				}
				SceneItemReboundComponent component = entityByActor.Entity.GetComponent<SceneItemReboundComponent>();
				if (component == null)
				{
					flag2 = true;
					break;
				}
				if (this.HitReboundInfoMap.ContainsKey(entityByActor.Id))
				{
					List<Vector> list = this.HitReboundInfoMap[entityByActor.Id];
					for (int i = 0; i < list.Count; i += 2)
					{
						Vector inB = list[i];
						Vector inB2 = list[i + 1];
						if (vector.Equals(inB, 9.999999747378752E-05) && this.TrackDir.Equals(inB2, 9.999999747378752E-05))
						{
							flag3 = true;
							break;
						}
					}
					if (flag3)
					{
						break;
					}
					list.Add(vector);
					Vector vector2 = this.GetVector();
					vector2.DeepCopy(this.TrackDir);
					list.Add(vector2);
					if (list.Count > 10)
					{
						flag3 = true;
						break;
					}
				}
				else
				{
					List<Vector> vectorArray = this.GetVectorArray();
					vectorArray.Add(vector);
					Vector vector3 = this.GetVector();
					vector3.DeepCopy(this.TrackDir);
					vectorArray.Add(vector3);
					this.HitReboundInfoMap[entityByActor.Id] = vectorArray;
				}
				if (!component.CalculateReflectDir(this.TrackDir, this.TrackDir, weak, true))
				{
					flag2 = true;
					break;
				}
				this.TrackDir.Multiply(0.10000000149011612, this.TempVector);
				vector.Addition(this.TempVector, this.TempVector);
				this.EndTrackLocation = this.GetEndPointPosition(vector, this.TrackDir);
				Singleton<TraceElementCommon>.Instance.SetStartLocation(this.BulletTraceElement, this.TempVector);
				Singleton<TraceElementCommon>.Instance.SetEndLocation(this.BulletTraceElement, this.EndTrackLocation);
				Singleton<TraceElementCommon>.Instance.LineTrace(this.BulletTraceElement, "CharacterLevelShootComponent_PreCalculateBulletTrack");
			}
		}
		int num = -1;
		if (!flag2 && !flag3)
		{
			num = this.SplinePoints.Count;
			this.SplinePoints.Add(this.EndTrackLocation);
		}
		if (this.SplinePoints.Count > 1)
		{
			this.SplinePoints[1].Subtraction(this.SplinePoints[0], this.FireVector);
			this.FireVector.Normalize(9.99999993922529E-09);
			ControllerBase<LevelAimLineController>.Instance.UpdatePoints(this.SplinePoints, EAimLineType.Line);
		}
		else
		{
			Singleton<Log>.Instance.Warn(ELogModule.Level, ELogAuthor.WLJ, "[LevelShoot]Length of SplinePoints less then 2", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		if (num > -1 && num < this.SplinePoints.Count)
		{
			this.SplinePoints.RemoveAt(num);
		}
		for (int j = 1; j < this.SplinePoints.Count; j++)
		{
			this.ReleaseVector(this.SplinePoints[j]);
		}
		foreach (List<Vector> value in this.HitReboundInfoMap.Values)
		{
			this.ReleaseVectorArray(value);
		}
		this.SplinePoints.Clear();
		this.HitReboundInfoMap.Clear();
	}

	// Token: 0x06019674 RID: 104052 RVA: 0x00754518 File Offset: 0x00752718
	public static void CreateStaticDefaultValue()
	{
		CharacterLevelShootComponent._vectorPool = new List<Vector>();
		CharacterLevelShootComponent._vectorArrayPool = new List<List<Vector>>();
	}

	// Token: 0x06019675 RID: 104053 RVA: 0x0075452E File Offset: 0x0075272E
	public static void ResetStaticDefaultValue()
	{
		CharacterLevelShootComponent._vectorPool = null;
		CharacterLevelShootComponent._vectorArrayPool = null;
	}

	// Token: 0x06019676 RID: 104054 RVA: 0x0075453C File Offset: 0x0075273C
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterLevelShootComponent characterLevelShootComponent = (CharacterLevelShootComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterLevelShootComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterLevelShootComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsActive"))
		{
			this.IsActive = characterLevelShootComponent.IsActive;
		}
		if (base.CanResetComponentProperty("BulletTraceElement"))
		{
			if (characterLevelShootComponent.BulletTraceElement == null)
			{
				this.BulletTraceElement = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UTraceLineElement>(this.BulletTraceElement), "BulletTraceElement"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SplinePoints"))
		{
			if (characterLevelShootComponent.SplinePoints == null)
			{
				this.SplinePoints = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<List<Vector>>(this.SplinePoints), "SplinePoints"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StartTrackLocation"))
		{
			if (characterLevelShootComponent.StartTrackLocation == null)
			{
				this.StartTrackLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.StartTrackLocation), "StartTrackLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TrackDir"))
		{
			if (characterLevelShootComponent.TrackDir == null)
			{
				this.TrackDir = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TrackDir), "TrackDir"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("EndTrackLocation"))
		{
			if (characterLevelShootComponent.EndTrackLocation == null)
			{
				this.EndTrackLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.EndTrackLocation), "EndTrackLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TempVector"))
		{
			if (characterLevelShootComponent.TempVector == null)
			{
				this.TempVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.TempVector), "TempVector"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("HitReboundInfoMap"))
		{
			if (characterLevelShootComponent.HitReboundInfoMap == null)
			{
				this.HitReboundInfoMap = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, List<Vector>>>(this.HitReboundInfoMap), "HitReboundInfoMap"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnArmFireBulletTask"))
		{
			if (characterLevelShootComponent.OnArmFireBulletTask == null)
			{
				this.OnArmFireBulletTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.OnArmFireBulletTask), "OnArmFireBulletTask"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("FireVector"))
		{
			if (characterLevelShootComponent.FireVector == null)
			{
				this.FireVector = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector>(this.FireVector), "FireVector"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C901 RID: 51457
	private const string PROFILE_BULLECT_TRACK = "CharacterLevelShootComponent_PreCalculateBulletTrack";

	// Token: 0x0400C902 RID: 51458
	private const string DEMO_LEVEL_AIM_LINE_EFFECT_PATH = "/Game/Aki/Effect/EffectGroup/BigWorld/DA_Fx_Group_SignalSpline.DA_Fx_Group_SignalSpline";

	// Token: 0x0400C903 RID: 51459
	private const float REFLECT_START_OFFSET = 0.1f;

	// Token: 0x0400C904 RID: 51460
	private const string BULLET_FIRE_BONE_NAME = "WeaponProp01_2";

	// Token: 0x0400C905 RID: 51461
	private const int MAX_HIT_COUNT_ON_ONE = 10;

	// Token: 0x0400C906 RID: 51462
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C907 RID: 51463
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C908 RID: 51464
	private readonly int TrackLength = 5000;

	// Token: 0x0400C909 RID: 51465
	[StaticVariableRuleIgnore]
	private static readonly Vector FireBulletPositionOffset = Vector.ForwardVectorProxy;

	// Token: 0x0400C90A RID: 51466
	private bool IsActive;

	// Token: 0x0400C90B RID: 51467
	[Nullable(2)]
	private UTraceLineElement BulletTraceElement;

	// Token: 0x0400C90C RID: 51468
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> SplinePoints;

	// Token: 0x0400C90D RID: 51469
	[Nullable(2)]
	private Vector StartTrackLocation;

	// Token: 0x0400C90E RID: 51470
	[Nullable(2)]
	private Vector TrackDir;

	// Token: 0x0400C90F RID: 51471
	[Nullable(2)]
	private Vector EndTrackLocation;

	// Token: 0x0400C910 RID: 51472
	[Nullable(2)]
	private Vector TempVector;

	// Token: 0x0400C911 RID: 51473
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private Dictionary<int, List<Vector>> HitReboundInfoMap;

	// Token: 0x0400C912 RID: 51474
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<Vector> _vectorPool;

	// Token: 0x0400C913 RID: 51475
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static List<List<Vector>> _vectorArrayPool;

	// Token: 0x0400C914 RID: 51476
	[Nullable(2)]
	private ITagTask OnArmFireBulletTask;

	// Token: 0x0400C915 RID: 51477
	[Nullable(2)]
	private Vector FireVector;
}
