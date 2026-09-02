using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Core.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002D98 RID: 11672
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/BulletBlueprintFunctionLibrary.BulletBlueprintFunctionLibrary_C")]
public class BulletBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x0601787B RID: 96379 RVA: 0x0068B56C File Offset: 0x0068976C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float CreateBulletForDebug(TsBaseCharacter owner, string bulletRowName)
	{
		return (float)ControllerBase<BulletController>.Instance.CreateBulletForDebug(owner, bulletRowName);
	}

	// Token: 0x0601787C RID: 96380 RVA: 0x0068B57C File Offset: 0x0068977C
	[NullableContext(1)]
	private static string GetSpecialBulletToSkillId(string bulletRowName, string skillId)
	{
		if (skillId != "")
		{
			return skillId;
		}
		int valueOrDefault = SpecialBulletToSkillIdMap.Values.GetValueOrDefault(bulletRowName, 0);
		if (valueOrDefault == 0)
		{
			return "";
		}
		return valueOrDefault.ToString();
	}

	// Token: 0x0601787D RID: 96381 RVA: 0x0068B5B8 File Offset: 0x006897B8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int CreateBulletFromGA(TsBaseCharacter owner, string bulletRowName, FTransformDouble initialTransform, string skillId, bool needSync = true, FVectorDouble targetLocation = default(FVectorDouble))
	{
		string specialBulletToSkillId = BulletBlueprintFunctionLibrary.GetSpecialBulletToSkillId(bulletRowName, skillId);
		if (specialBulletToSkillId == "")
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "CreateBulletFromGA的SkillId为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("bullet", bulletRowName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		long? skillContextId = BulletUtil.GetSkillContextId(owner.GetEntityNoBlueprint(), int.Parse(specialBulletToSkillId));
		BulletController instance2 = ControllerBase<BulletController>.Instance;
		FTransformDouble? initialTransform2 = new FTransformDouble?(initialTransform);
		BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
		bulletCreateParams.SkillId = int.Parse(specialBulletToSkillId);
		bulletCreateParams.SkillContextId = skillContextId;
		bulletCreateParams.SyncType = (needSync ? global::EBulletSyncType.SyncCreate : global::EBulletSyncType.Local);
		bulletCreateParams.InitTargetLocation = new FVectorDouble?(targetLocation);
		Entity entityNoBlueprint = owner.GetEntityNoBlueprint();
		ISkillBattleContext battleContext;
		if (entityNoBlueprint == null)
		{
			battleContext = null;
		}
		else
		{
			BaseSkillComponent component = entityNoBlueprint.GetComponent<BaseSkillComponent>();
			if (component == null)
			{
				battleContext = null;
			}
			else
			{
				Skill skill = component.GetSkill(int.Parse(specialBulletToSkillId));
				battleContext = ((skill != null) ? skill.BattleContext : null);
			}
		}
		bulletCreateParams.BattleContext = battleContext;
		BulletEntity bulletEntity = instance2.CreateBulletCustomTarget(owner, bulletRowName, initialTransform2, bulletCreateParams, skillContextId, EBulletCreateSource.Skill);
		if (bulletEntity != null)
		{
			return bulletEntity.Id;
		}
		return -1;
	}

	// Token: 0x0601787E RID: 96382 RVA: 0x0068B6A0 File Offset: 0x006898A0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static AActor GetBulletActorById(int id)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(id);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		return entity.GetComponent<BulletActorComponent>().Owner;
	}

	// Token: 0x0601787F RID: 96383 RVA: 0x0068B6D7 File Offset: 0x006898D7
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool DestroyBullet(int id, bool isSummonChildBullet, bool destroyEffectImmediately = false)
	{
		ControllerBase<BulletController>.Instance.DestroyBullet(id, isSummonChildBullet, EBulletDestroyReason.Normal, destroyEffectImmediately);
		return true;
	}

	// Token: 0x06017880 RID: 96384 RVA: 0x0068B6E8 File Offset: 0x006898E8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DestroyAllBullet(bool summonChild = false)
	{
		ControllerBase<BulletController>.Instance.DestroyAllBullet(summonChild);
	}

	// Token: 0x06017881 RID: 96385 RVA: 0x0068B6F5 File Offset: 0x006898F5
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DestroySpecifiedBullet(int ownerId, FName bulletName, bool summonChild = false, int includeTeammate = 0, float interval = 0f)
	{
		ControllerBase<BulletController>.Instance.DestroySpecifiedBullet(ownerId, bulletName, summonChild, includeTeammate, interval);
	}

	// Token: 0x06017882 RID: 96386 RVA: 0x0068B707 File Offset: 0x00689907
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetSpecifiedBulletCount(int ownerId, FName bulletName)
	{
		return ControllerBase<BulletController>.Instance.GetSpecifiedBulletCount(ownerId, bulletName);
	}

	// Token: 0x06017883 RID: 96387 RVA: 0x0068B718 File Offset: 0x00689918
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<int> GetCharacterLaunchedBulletIds(int characterId)
	{
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(characterId);
		if (bulletSetByAttacker == null)
		{
			return null;
		}
		TArray<int> tarray = new TArray<int>();
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			tarray.Add(bulletEntity.Id);
		}
		return tarray;
	}

	// Token: 0x06017884 RID: 96388 RVA: 0x0068B780 File Offset: 0x00689980
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DebugShowBulletCollision(bool isShow, int entityId)
	{
		ModelBase<BulletModel>.Instance.SetBulletCollisionDraw(entityId, isShow);
	}

	// Token: 0x06017885 RID: 96389 RVA: 0x0068B78E File Offset: 0x0068998E
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void DebugShowBulletTrace(bool isShow, int entityId)
	{
		ModelBase<BulletModel>.Instance.SetBulletTraceDraw(entityId, isShow);
	}

	// Token: 0x06017886 RID: 96390 RVA: 0x0068B79C File Offset: 0x0068999C
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetIsShowBulletCollision(int entityId)
	{
		return ModelBase<BulletModel>.Instance.ShowBulletCollision(entityId);
	}

	// Token: 0x06017887 RID: 96391 RVA: 0x0068B7A9 File Offset: 0x006899A9
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool GetIsShowBulletTrace(int entityId)
	{
		BulletModel instance = ModelBase<BulletModel>.Instance;
		return instance != null && instance.ShowBulletTrace(entityId);
	}

	// Token: 0x06017888 RID: 96392 RVA: 0x0068B7BC File Offset: 0x006899BC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void FrozenBulletTimeByBulletName(TsBaseCharacter character, string bulletDataName, float time)
	{
		BulletUtil.FrozenCharacterBullet(character.GetEntityIdNoBlueprint(), bulletDataName, time);
	}

	// Token: 0x06017889 RID: 96393 RVA: 0x0068B7CB File Offset: 0x006899CB
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetEntityIdByCustomKey(int attackerId, string customKey, int targetId)
	{
		ModelBase<BulletModel>.Instance.SetEntityIdByCustomKey(attackerId, customKey, targetId);
	}

	// Token: 0x0601788A RID: 96394 RVA: 0x0068B7DC File Offset: 0x006899DC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<int> GetAllBullet()
	{
		TArray<int> tarray = new TArray<int>();
		foreach (OrderedSet<BulletEntity> orderedSet in ModelBase<BulletModel>.Instance.GetAttackerBulletIterator())
		{
			foreach (BulletEntity bulletEntity in orderedSet)
			{
				tarray.Add(bulletEntity.Id);
			}
		}
		return tarray;
	}

	// Token: 0x0601788B RID: 96395 RVA: 0x0068B870 File Offset: 0x00689A70
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FTransformDouble GetBulletTransform(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		FTransformDouble? ftransformDouble;
		if (bulletInfo == null)
		{
			ftransformDouble = null;
		}
		else
		{
			BulletActorComponent actorComponent = bulletInfo.ActorComponent;
			ftransformDouble = ((actorComponent != null) ? new FTransformDouble?(actorComponent.ActorTransform) : null);
		}
		FTransformDouble? ftransformDouble2 = ftransformDouble;
		if (ftransformDouble2 == null)
		{
			return FTransformDouble.Identity;
		}
		return ftransformDouble2.GetValueOrDefault();
	}

	// Token: 0x0601788C RID: 96396 RVA: 0x0068B8C7 File Offset: 0x00689AC7
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TsBaseCharacter GetBulletAttacker(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		return ((bulletInfo != null) ? bulletInfo.AttackerActorComp.Owner : null) as TsBaseCharacter;
	}

	// Token: 0x0601788D RID: 96397 RVA: 0x0068B8E5 File Offset: 0x00689AE5
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static UPrimitiveComponent GetBulletCollision(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		if (bulletInfo == null)
		{
			return null;
		}
		return bulletInfo.CollisionInfo.CollisionComponent;
	}

	// Token: 0x0601788E RID: 96398 RVA: 0x0068B8FD File Offset: 0x00689AFD
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static string GetBulletName(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		if (bulletInfo == null)
		{
			return null;
		}
		return bulletInfo.BulletDataMain.BulletName;
	}

	// Token: 0x0601788F RID: 96399 RVA: 0x0068B918 File Offset: 0x00689B18
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetBulletStopHitTrue(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		BulletCollisionInfo bulletCollisionInfo = (bulletInfo != null) ? bulletInfo.CollisionInfo : null;
		if (bulletCollisionInfo != null)
		{
			bulletCollisionInfo.StopHit = true;
		}
	}

	// Token: 0x06017890 RID: 96400 RVA: 0x0068B944 File Offset: 0x00689B44
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetBulletTarget(int id, TsBaseCharacter character)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		if (character != null)
		{
			if (bulletInfo != null)
			{
				bulletInfo.SetTargetById(character.GetEntityIdNoBlueprint());
				return;
			}
		}
		else if (bulletInfo != null)
		{
			bulletInfo.SetTargetById(0);
		}
	}

	// Token: 0x06017891 RID: 96401 RVA: 0x0068B975 File Offset: 0x00689B75
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetBulletSummon(int id)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		if (bulletInfo == null)
		{
			return;
		}
		BulletChildInfo childInfo = bulletInfo.ChildInfo;
		if (childInfo == null)
		{
			return;
		}
		childInfo.SetIsActiveSummonChildBullet(true);
	}

	// Token: 0x06017892 RID: 96402 RVA: 0x0068B994 File Offset: 0x00689B94
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetBulletTransform(int id, FTransformDouble newTransform)
	{
		BulletInfo bulletInfo = BulletBlueprintFunctionLibrary.GetBulletInfo(id);
		if (bulletInfo == null)
		{
			return;
		}
		bulletInfo.ActorComponent.SetActorTransform(newTransform, "unknown", true, null);
	}

	// Token: 0x06017893 RID: 96403 RVA: 0x0068B9C7 File Offset: 0x00689BC7
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetBeginSpeed(int id, float newSpeed)
	{
		ControllerBase<BulletController>.Instance.SetBulletSpeedRatio(id, newSpeed);
	}

	// Token: 0x06017894 RID: 96404 RVA: 0x0068B9D5 File Offset: 0x00689BD5
	[NullableContext(2)]
	private static BulletInfo GetBulletInfo(int id)
	{
		BulletEntity bulletEntityById = ModelBase<BulletModel>.Instance.GetBulletEntityById(id);
		if (bulletEntityById == null)
		{
			return null;
		}
		return bulletEntityById.GetBulletInfo();
	}

	// Token: 0x06017895 RID: 96405 RVA: 0x0068B9F0 File Offset: 0x00689BF0
	[NullableContext(1)]
	private static void CalSectorPoints(FVector centerPoint, FVector forward, FVector up, float angle, float radius, int sectionNum, TArray<FVector> outVectorArray)
	{
		forward.Normalize(1E-08f);
		up.Normalize(1E-08f);
		float angleDeg = (sectionNum > 0) ? (angle / (float)sectionNum) : angle;
		FVector fvector = forward.RotateAngleAxis(-1f * (angle / 2f), up);
		FVector fvector2 = fvector * radius;
		FVector value = centerPoint + fvector2;
		outVectorArray.Add(value);
		for (int i = 0; i < sectionNum; i++)
		{
			fvector2 = fvector2.RotateAngleAxis(angleDeg, up);
			FVector value2 = centerPoint + fvector2;
			outVectorArray.Add(value2);
		}
	}

	// Token: 0x06017896 RID: 96406 RVA: 0x0068BA86 File Offset: 0x00689C86
	[NullableContext(1)]
	private static void RectangleTriangles(int leftDown, int leftTop, int rightDown, int rightTop, TArray<int> outTriangles)
	{
		outTriangles.Add(rightDown);
		outTriangles.Add(rightTop);
		outTriangles.Add(leftTop);
		outTriangles.Add(rightDown);
		outTriangles.Add(leftTop);
		outTriangles.Add(leftDown);
	}

	// Token: 0x06017897 RID: 96407 RVA: 0x0068BAB8 File Offset: 0x00689CB8
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CalcPipe(FVector centerPoint, FVector forward, FVector up, float outsideRadius, float insideRadius, float height, int sectionNum, ref TArray<FVector> outVertices, ref TArray<int> outTriangles)
	{
		forward.Normalize(1E-08f);
		up.Normalize(1E-08f);
		Vector vector = Vector.Create(up);
		vector.MultiplyEqual((double)height);
		Vector vector2 = Vector.Create(centerPoint);
		Vector vector3 = Vector.Create();
		vector2.Subtraction(vector, vector3);
		Vector vector4 = Vector.Create();
		vector2.Addition(vector, vector4);
		int num = 0;
		BulletBlueprintFunctionLibrary.CalSectorPoints(vector3.ToUeVectorOld(), forward, up, 360f, insideRadius, sectionNum, outVertices);
		int num2 = outVertices.Num();
		BulletBlueprintFunctionLibrary.CalSectorPoints(vector3.ToUeVectorOld(), forward, up, 360f, outsideRadius, sectionNum, outVertices);
		int num3 = outVertices.Num();
		BulletBlueprintFunctionLibrary.CalSectorPoints(vector4.ToUeVectorOld(), forward, up, 360f, insideRadius, sectionNum, outVertices);
		int num4 = outVertices.Num();
		BulletBlueprintFunctionLibrary.CalSectorPoints(vector4.ToUeVectorOld(), forward, up, 360f, outsideRadius, sectionNum, outVertices);
		for (int i = 0; i < num2 - 1; i++)
		{
			int leftDown = num3 + i;
			int rightDown = num3 + i + 1;
			int leftTop = num4 + i;
			int rightTop = num4 + i + 1;
			BulletBlueprintFunctionLibrary.RectangleTriangles(leftDown, leftTop, rightDown, rightTop, outTriangles);
			leftDown = num + i + 1;
			rightDown = num + i;
			leftTop = num2 + i + 1;
			rightTop = num2 + i;
			BulletBlueprintFunctionLibrary.RectangleTriangles(leftDown, leftTop, rightDown, rightTop, outTriangles);
			leftDown = num + i;
			rightDown = num + i + 1;
			leftTop = num3 + i;
			rightTop = num3 + i + 1;
			BulletBlueprintFunctionLibrary.RectangleTriangles(leftDown, leftTop, rightDown, rightTop, outTriangles);
			leftDown = num2 + i + 1;
			rightDown = num2 + i;
			leftTop = num4 + i + 1;
			rightTop = num4 + i;
			BulletBlueprintFunctionLibrary.RectangleTriangles(leftDown, leftTop, rightDown, rightTop, outTriangles);
		}
	}

	// Token: 0x06017898 RID: 96408 RVA: 0x0068BC80 File Offset: 0x00689E80
	[NullableContext(1)]
	private static void CircleTriangles(int centerIndex, int startIndex, int endIndex, bool bAnticlockwise, TArray<int> triangles)
	{
		for (int i = startIndex; i < endIndex; i++)
		{
			if (bAnticlockwise)
			{
				triangles.Add(centerIndex);
				triangles.Add(i + 1);
				triangles.Add(i);
			}
			else
			{
				triangles.Add(centerIndex);
				triangles.Add(i);
				triangles.Add(i + 1);
			}
		}
	}

	// Token: 0x06017899 RID: 96409 RVA: 0x0068BCD4 File Offset: 0x00689ED4
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void CalcSector(FVector centerPoint, FVector forward, FVector up, float inAngle, float radius, float height, int sectionNum, ref TArray<FVector> verticesArray, ref TArray<int> trianglesArray)
	{
		forward.Normalize(1E-08f);
		up.Normalize(1E-08f);
		float num = (inAngle > 360f) ? 360f : inAngle;
		FVector fvector = up * height;
		FVector fvector2 = centerPoint - fvector;
		fvector = up * height;
		FVector fvector3 = centerPoint + fvector;
		verticesArray.Add(fvector2);
		BulletBlueprintFunctionLibrary.CalSectorPoints(fvector2, forward, up, num, radius, sectionNum, verticesArray);
		int num2 = 0;
		int num3 = verticesArray.Num() - 1;
		int num4 = verticesArray.Num();
		verticesArray.Add(fvector3);
		BulletBlueprintFunctionLibrary.CalSectorPoints(fvector3, forward, up, num, radius, sectionNum, verticesArray);
		int num5 = verticesArray.Num() - 1;
		BulletBlueprintFunctionLibrary.CircleTriangles(num2, num2 + 1, num3, false, trianglesArray);
		BulletBlueprintFunctionLibrary.CircleTriangles(num4, num4 + 1, num5, true, trianglesArray);
		if (!Singleton<MathUtils>.Instance.IsNearlyEqual((double)num, 360.0, null))
		{
			BulletBlueprintFunctionLibrary.RectangleTriangles(num2 + 1, num4 + 1, num2, num4, trianglesArray);
			BulletBlueprintFunctionLibrary.RectangleTriangles(num2, num4, num3, num5, trianglesArray);
		}
		for (int i = 1; i < num3; i++)
		{
			int num6 = i;
			int num7 = i + 1;
			int rightTop = num4 + num6;
			int leftTop = num4 + num7;
			BulletBlueprintFunctionLibrary.RectangleTriangles(num7, leftTop, num6, rightTop, trianglesArray);
		}
	}

	// Token: 0x0601789A RID: 96410 RVA: 0x0068BE28 File Offset: 0x0068A028
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble CalcBulletInitLocation(SReBulletDataMain dataMain, AActor attacker, FTransformDouble target)
	{
		FTransformDouble ftransformDouble = attacker.D_GetTransform();
		Quat quat = Quat.Create(0f, 0f, 0f, 1f);
		Rotator.Create(0f, 90f, 0f).Quaternion(quat);
		FQuat fquat = quat.ToUeQuat();
		ftransformDouble.SetRotation(fquat);
		FVector fvector;
		if (dataMain.移动设置.运动轨迹类型 == EMoveTrajectory.围绕中心旋转)
		{
			FVectorDouble location;
			float yaw;
			FVectorDouble fvectorDouble;
			if (dataMain.移动设置.运动轨迹参数目标 == EBulletTarget.空 || dataMain.移动设置.运动轨迹参数目标 == EBulletTarget.子弹发射者 || dataMain.移动设置.运动轨迹参数目标 == EBulletTarget.队伍角色)
			{
				location = ftransformDouble.GetLocation();
				yaw = ftransformDouble.Rotator().Yaw;
				fquat = ftransformDouble.GetRotation();
				fvector = fquat.GetForwardVector();
				fvectorDouble = fvector;
			}
			else
			{
				location = target.GetLocation();
				fquat = target.GetRotation();
				yaw = fquat.Rotator().Yaw;
				fquat = target.GetRotation();
				fvector = fquat.Vector();
				fvectorDouble = fvector;
			}
			FVector fvector2 = dataMain.移动设置.运动轨迹参数数据[0];
			FVectorDouble result = fvectorDouble.RotateAngleAxis((double)fvector2.Y, Vector.UpVectorDouble);
			result.Z = (double)((float)(-(float)Math.Sin((double)((yaw + fvector2.Y) * 0.017453292f)) * Math.Tan((double)(fvector2.Z * 0.017453292f))));
			result.Normalize(9.99999993922529E-09);
			result = result * (double)fvector2.X;
			result = result + location;
			return result;
		}
		Vector vector = Vector.Create();
		Vector vector2 = Vector.Create();
		Vector vector3 = vector2;
		fvector = dataMain.基础设置.出生位置偏移;
		vector3.FromUeVector(fvector);
		switch (dataMain.基础设置.出生位置基准)
		{
		case EPositionStandard.发射者位置:
		case EPositionStandard.队伍角色:
		{
			Vector vector4 = vector;
			FVectorDouble fvectorDouble2 = vector2.ToUeVector(false);
			FVectorDouble fvectorDouble3 = ftransformDouble.TransformPosition(fvectorDouble2);
			vector4.FromUeVector(fvectorDouble3);
			break;
		}
		case EPositionStandard.技能目标位置:
		case EPositionStandard.世界位置:
		case EPositionStandard.父子弹或外部位置:
		case EPositionStandard.攻击者锁定目标位置:
		case EPositionStandard.自定义目标:
		case EPositionStandard.父子弹受击者:
		case EPositionStandard.父子弹目标:
		case EPositionStandard.前台角色锁定目标:
		case EPositionStandard.伴生物:
		{
			Vector vector5 = vector;
			FVectorDouble fvectorDouble2 = vector2.ToUeVector(false);
			FVectorDouble fvectorDouble3 = target.TransformPosition(fvectorDouble2);
			vector5.FromUeVector(fvectorDouble3);
			break;
		}
		}
		return vector.ToUeVector(false);
	}

	// Token: 0x0601789B RID: 96411 RVA: 0x0068C084 File Offset: 0x0068A284
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void AttachToBone(USkeletalMeshComponent meshComp, AActor bulletActor, SReBulletDataMain dataMain)
	{
		TEnumAsByte<EBulletFollowType> 子弹跟随类型 = dataMain.移动设置.子弹跟随类型;
		if (子弹跟随类型 == EBulletFollowType.跟随骨骼)
		{
			bulletActor.K2_AttachToComponent(meshComp, dataMain.移动设置.骨骼名字, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true, true);
			return;
		}
		if (子弹跟随类型 == EBulletFollowType.跟随骨骼位置旋转)
		{
			bulletActor.K2_AttachToComponent(meshComp, dataMain.移动设置.骨骼名字, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, EAttachmentRule.KeepWorld, true, true);
			FVectorDouble newRelativeLocation = UKismetMathLibrary.Conv_VectorToVectorDouble(dataMain.基础设置.出生位置偏移);
			FHitResult fhitResult = null;
			bulletActor.D_K2_SetActorRelativeLocation(newRelativeLocation, false, ref fhitResult, false);
			FHitResult fhitResult2 = null;
			bulletActor.K2_SetActorRelativeRotation(Rotator.ZeroRotator, false, ref fhitResult2, true);
		}
	}

	// Token: 0x0601789C RID: 96412 RVA: 0x0068C118 File Offset: 0x0068A318
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FRotator CalcBulletInitRotator(SReBulletDataMain dataMain, AActor bulletActor, AActor attacker, FTransformDouble target, AActor parentBulletActor)
	{
		Rotator rotator = Rotator.Create();
		if (dataMain.移动设置.运动轨迹类型 == EMoveTrajectory.围绕中心旋转)
		{
			return bulletActor.K2_GetActorRotation();
		}
		switch (dataMain.移动设置.出生初速度方向基准)
		{
		case EInitialVelocityDirection.默认:
		{
			FVector fvector = bulletActor.GetActorForwardVector().RotateAngleAxis(90f, Vector.UpVector);
			Rotator rotator2 = rotator;
			FRotator frotator = fvector.Rotation();
			rotator2.FromUeRotator(frotator);
			break;
		}
		case EInitialVelocityDirection.面向目标:
		case EInitialVelocityDirection.面向发射者锁定目标:
		case EInitialVelocityDirection.面向自定义目标:
		case EInitialVelocityDirection.父子弹受击者:
		case EInitialVelocityDirection.父子弹目标:
		case EInitialVelocityDirection.前台角色锁定目标:
		case EInitialVelocityDirection.伴生物:
		{
			Rotator rotator3 = rotator;
			FVectorDouble fvectorDouble = bulletActor.D_K2_GetActorLocation();
			FVectorDouble fvectorDouble2 = target.GetLocation();
			FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2);
			rotator3.FromUeRotator(frotator);
			break;
		}
		case EInitialVelocityDirection.面向发射者:
		case EInitialVelocityDirection.队伍角色:
		{
			Rotator rotator4 = rotator;
			FVectorDouble fvectorDouble = bulletActor.D_K2_GetActorLocation();
			FVectorDouble fvectorDouble2 = attacker.D_K2_GetActorLocation();
			FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble2);
			rotator4.FromUeRotator(frotator);
			break;
		}
		case EInitialVelocityDirection.父子弹方向:
		{
			Rotator rotator5 = rotator;
			FRotator frotator = parentBulletActor.K2_GetActorRotation();
			rotator5.FromUeRotator(frotator);
			break;
		}
		case EInitialVelocityDirection.跟随骨骼默认朝向:
		{
			Rotator rotator6 = rotator;
			FRotator frotator = bulletActor.K2_GetActorRotation();
			rotator6.FromUeRotator(frotator);
			break;
		}
		}
		return rotator.ToUeRotator();
	}

	// Token: 0x0601789D RID: 96413 RVA: 0x0068C238 File Offset: 0x0068A438
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FRotator CalcBulletRotator(SReBulletDataMain dataMain, AActor bulletActor, AActor attacker, FVectorDouble target, float delta)
	{
		Rotator rotator = Rotator.Create();
		Vector vector = Vector.Create();
		switch (dataMain.移动设置.运动轨迹类型)
		{
		case EMoveTrajectory.默认:
		{
			Rotator rotator2 = rotator;
			FRotator frotator = bulletActor.K2_GetActorRotation();
			rotator2.FromUeRotator(frotator);
			break;
		}
		case EMoveTrajectory.限时命中子弹:
		{
			Rotator rotator3 = rotator;
			FVectorDouble fvectorDouble = bulletActor.D_K2_GetActorLocation();
			FRotator frotator = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, target);
			rotator3.FromUeRotator(frotator);
			break;
		}
		case EMoveTrajectory.围绕中心旋转:
		{
			FVector fvector = dataMain.移动设置.运动轨迹参数数据[0];
			float num = dataMain.移动设置.移动速度 * delta * 57.29578f / fvector.X;
			vector.Set(0.0, Math.Sin((double)(fvector.Z * 0.017453292f)), Math.Cos((double)(fvector.Z * 0.017453292f)));
			EBulletTarget ebulletTarget = dataMain.移动设置.运动轨迹参数目标;
			FVectorDouble fvectorDouble2;
			if (ebulletTarget == EBulletTarget.空 || ebulletTarget == EBulletTarget.子弹发射者 || ebulletTarget == EBulletTarget.队伍角色)
			{
				fvectorDouble2 = attacker.D_K2_GetActorLocation();
			}
			else
			{
				fvectorDouble2 = target;
			}
			FVectorDouble fvectorDouble = bulletActor.D_K2_GetActorLocation();
			FVectorDouble fvectorDouble3 = fvectorDouble2 - fvectorDouble;
			double angleDeg = (double)num;
			fvectorDouble = vector.ToUeVector(false);
			FVectorDouble fvectorDouble4 = fvectorDouble3.RotateAngleAxis(angleDeg, fvectorDouble);
			FVectorDouble newLocation = fvectorDouble2 + fvectorDouble4;
			bulletActor.K2_SetActorRotation(UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble2, newLocation), false);
			FHitResult fhitResult = null;
			bulletActor.D_K2_SetActorLocation(newLocation, false, ref fhitResult, true);
			break;
		}
		}
		return rotator.ToUeRotator();
	}

	// Token: 0x0601789E RID: 96414 RVA: 0x0068C3AC File Offset: 0x0068A5AC
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static FVectorDouble CalcBulletLocation(SReBulletDataMain dataMain, AActor bulletActor, float delta)
	{
		FVectorDouble fvectorDouble = bulletActor.D_K2_GetActorLocation();
		FVectorDouble fvectorDouble2 = bulletActor.D_GetActorForwardVector();
		FVectorDouble fvectorDouble3 = fvectorDouble2 * (double)(dataMain.移动设置.移动速度 * delta);
		return fvectorDouble + fvectorDouble3;
	}

	// Token: 0x0601789F RID: 96415 RVA: 0x0068C3E6 File Offset: 0x0068A5E6
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetCampRelationship(int camp1, int camp2)
	{
		return (int)CampUtils.GetCampRelationship((ECamp)camp1, (ECamp)camp2);
	}

	// Token: 0x060178A0 RID: 96416 RVA: 0x0068C3F4 File Offset: 0x0068A5F4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static int GetCamp(int entityId)
	{
		EntityHandle handle = ModelBase<CharacterModel>.Instance.GetHandle(entityId);
		if (handle != null && handle.Valid)
		{
			WorldEntity entity = handle.Entity;
			CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
			if (creatureDataComponent != null)
			{
				return (int)creatureDataComponent.GetEntityCamp();
			}
		}
		return -1;
	}

	// Token: 0x060178A1 RID: 96417 RVA: 0x0068C436 File Offset: 0x0068A636
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void NotifyProcessKuroBulletOperationList()
	{
		ControllerBase<BulletController>.Instance.ProcessKuroBulletOperationList();
	}

	// Token: 0x060178A2 RID: 96418 RVA: 0x0068C442 File Offset: 0x0068A642
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void NotifyExistedImmediatelyOperation(FBulletHitWorldEntityOperation operation)
	{
		ControllerBase<BulletController>.Instance.ProcessKuroBulletOperation(operation);
	}

	// Token: 0x060178A3 RID: 96419 RVA: 0x0068C44F File Offset: 0x0068A64F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (BulletBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/BulletBlueprintFunctionLibrary.BulletBlueprintFunctionLibrary_C");
		}
		return BulletBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x060178A4 RID: 96420 RVA: 0x0068C474 File Offset: 0x0068A674
	public BulletBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(BulletBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060178A5 RID: 96421 RVA: 0x0068C49C File Offset: 0x0068A69C
	[NullableContext(1)]
	public BulletBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060178A6 RID: 96422 RVA: 0x0068C4CF File Offset: 0x0068A6CF
	protected BulletBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060178A7 RID: 96423 RVA: 0x0068C4D8 File Offset: 0x0068A6D8
	protected unsafe static void __CPPCALL_CreateBulletForDebug_Implementation(BulletBlueprintFunctionLibrary.__CreateBulletForDebug_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		string bulletRowName = FString.ToString((void*)(&__Params->bulletRowName));
		__Params->__Result = BulletBlueprintFunctionLibrary.CreateBulletForDebug(orCreateUObjectByNativePointer, bulletRowName);
	}

	// Token: 0x060178A8 RID: 96424 RVA: 0x0068C50C File Offset: 0x0068A70C
	protected unsafe static void __CPPCALL_CreateBulletFromGA_Implementation(BulletBlueprintFunctionLibrary.__CreateBulletFromGA_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->owner);
		string bulletRowName = FString.ToString((void*)(&__Params->bulletRowName));
		string skillId = FString.ToString((void*)(&__Params->skillId));
		__Params->__Result = BulletBlueprintFunctionLibrary.CreateBulletFromGA(orCreateUObjectByNativePointer, bulletRowName, __Params->initialTransform, skillId, __Params->needSync, __Params->targetLocation);
	}

	// Token: 0x060178A9 RID: 96425 RVA: 0x0068C55F File Offset: 0x0068A75F
	protected unsafe static void __CPPCALL_GetBulletActorById_Implementation(BulletBlueprintFunctionLibrary.__GetBulletActorById_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		AActor bulletActorById = BulletBlueprintFunctionLibrary.GetBulletActorById(__Params->id);
		ptr = ((bulletActorById != null) ? bulletActorById.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060178AA RID: 96426 RVA: 0x0068C581 File Offset: 0x0068A781
	protected unsafe static void __CPPCALL_DestroyBullet_Implementation(BulletBlueprintFunctionLibrary.__DestroyBullet_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.DestroyBullet(__Params->id, __Params->isSummonChildBullet, __Params->destroyEffectImmediately);
	}

	// Token: 0x060178AB RID: 96427 RVA: 0x0068C5A0 File Offset: 0x0068A7A0
	protected unsafe static void __CPPCALL_DestroyAllBullet_Implementation(BulletBlueprintFunctionLibrary.__DestroyAllBullet_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.DestroyAllBullet(__Params->summonChild);
	}

	// Token: 0x060178AC RID: 96428 RVA: 0x0068C5AD File Offset: 0x0068A7AD
	protected unsafe static void __CPPCALL_DestroySpecifiedBullet_Implementation(BulletBlueprintFunctionLibrary.__DestroySpecifiedBullet_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.DestroySpecifiedBullet(__Params->ownerId, __Params->bulletName, __Params->summonChild, __Params->includeTeammate, __Params->interval);
	}

	// Token: 0x060178AD RID: 96429 RVA: 0x0068C5D2 File Offset: 0x0068A7D2
	protected unsafe static void __CPPCALL_GetSpecifiedBulletCount_Implementation(BulletBlueprintFunctionLibrary.__GetSpecifiedBulletCount_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetSpecifiedBulletCount(__Params->ownerId, __Params->bulletName);
	}

	// Token: 0x060178AE RID: 96430 RVA: 0x0068C5EC File Offset: 0x0068A7EC
	protected unsafe static void __CPPCALL_GetCharacterLaunchedBulletIds_Implementation(BulletBlueprintFunctionLibrary.__GetCharacterLaunchedBulletIds_FunctionParams* __Params)
	{
		TArray<int> characterLaunchedBulletIds = BulletBlueprintFunctionLibrary.GetCharacterLaunchedBulletIds(__Params->characterId);
		if (characterLaunchedBulletIds == null)
		{
			return;
		}
		characterLaunchedBulletIds.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060178AF RID: 96431 RVA: 0x0068C61E File Offset: 0x0068A81E
	protected unsafe static void __CPPCALL_DebugShowBulletCollision_Implementation(BulletBlueprintFunctionLibrary.__DebugShowBulletCollision_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.DebugShowBulletCollision(__Params->isShow, __Params->entityId);
	}

	// Token: 0x060178B0 RID: 96432 RVA: 0x0068C631 File Offset: 0x0068A831
	protected unsafe static void __CPPCALL_DebugShowBulletTrace_Implementation(BulletBlueprintFunctionLibrary.__DebugShowBulletTrace_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.DebugShowBulletTrace(__Params->isShow, __Params->entityId);
	}

	// Token: 0x060178B1 RID: 96433 RVA: 0x0068C644 File Offset: 0x0068A844
	protected unsafe static void __CPPCALL_GetIsShowBulletCollision_Implementation(BulletBlueprintFunctionLibrary.__GetIsShowBulletCollision_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetIsShowBulletCollision(__Params->entityId);
	}

	// Token: 0x060178B2 RID: 96434 RVA: 0x0068C657 File Offset: 0x0068A857
	protected unsafe static void __CPPCALL_GetIsShowBulletTrace_Implementation(BulletBlueprintFunctionLibrary.__GetIsShowBulletTrace_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetIsShowBulletTrace(__Params->entityId);
	}

	// Token: 0x060178B3 RID: 96435 RVA: 0x0068C66C File Offset: 0x0068A86C
	protected unsafe static void __CPPCALL_FrozenBulletTimeByBulletName_Implementation(BulletBlueprintFunctionLibrary.__FrozenBulletTimeByBulletName_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->character);
		string bulletDataName = FString.ToString((void*)(&__Params->bulletDataName));
		BulletBlueprintFunctionLibrary.FrozenBulletTimeByBulletName(orCreateUObjectByNativePointer, bulletDataName, __Params->time);
	}

	// Token: 0x060178B4 RID: 96436 RVA: 0x0068C6A0 File Offset: 0x0068A8A0
	protected unsafe static void __CPPCALL_SetEntityIdByCustomKey_Implementation(BulletBlueprintFunctionLibrary.__SetEntityIdByCustomKey_FunctionParams* __Params)
	{
		string customKey = FString.ToString((void*)(&__Params->customKey));
		BulletBlueprintFunctionLibrary.SetEntityIdByCustomKey(__Params->attackerId, customKey, __Params->targetId);
	}

	// Token: 0x060178B5 RID: 96437 RVA: 0x0068C6CC File Offset: 0x0068A8CC
	protected unsafe static void __CPPCALL_GetAllBullet_Implementation(BulletBlueprintFunctionLibrary.__GetAllBullet_FunctionParams* __Params)
	{
		TArray<int> allBullet = BulletBlueprintFunctionLibrary.GetAllBullet();
		if (allBullet == null)
		{
			return;
		}
		allBullet.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x060178B6 RID: 96438 RVA: 0x0068C6F8 File Offset: 0x0068A8F8
	protected unsafe static void __CPPCALL_GetBulletTransform_Implementation(BulletBlueprintFunctionLibrary.__GetBulletTransform_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetBulletTransform(__Params->id);
	}

	// Token: 0x060178B7 RID: 96439 RVA: 0x0068C70B File Offset: 0x0068A90B
	protected unsafe static void __CPPCALL_GetBulletAttacker_Implementation(BulletBlueprintFunctionLibrary.__GetBulletAttacker_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		TsBaseCharacter bulletAttacker = BulletBlueprintFunctionLibrary.GetBulletAttacker(__Params->id);
		ptr = ((bulletAttacker != null) ? bulletAttacker.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060178B8 RID: 96440 RVA: 0x0068C72D File Offset: 0x0068A92D
	protected unsafe static void __CPPCALL_GetBulletCollision_Implementation(BulletBlueprintFunctionLibrary.__GetBulletCollision_FunctionParams* __Params)
	{
		ref IntPtr ptr = ref *(&__Params->__Result);
		UPrimitiveComponent bulletCollision = BulletBlueprintFunctionLibrary.GetBulletCollision(__Params->id);
		ptr = ((bulletCollision != null) ? bulletCollision.NativePtr : ((IntPtr)0));
	}

	// Token: 0x060178B9 RID: 96441 RVA: 0x0068C74F File Offset: 0x0068A94F
	protected unsafe static void __CPPCALL_GetBulletName_Implementation(BulletBlueprintFunctionLibrary.__GetBulletName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), BulletBlueprintFunctionLibrary.GetBulletName(__Params->id));
	}

	// Token: 0x060178BA RID: 96442 RVA: 0x0068C768 File Offset: 0x0068A968
	protected unsafe static void __CPPCALL_SetBulletStopHitTrue_Implementation(BulletBlueprintFunctionLibrary.__SetBulletStopHitTrue_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.SetBulletStopHitTrue(__Params->id);
	}

	// Token: 0x060178BB RID: 96443 RVA: 0x0068C778 File Offset: 0x0068A978
	protected unsafe static void __CPPCALL_SetBulletTarget_Implementation(BulletBlueprintFunctionLibrary.__SetBulletTarget_FunctionParams* __Params)
	{
		TsBaseCharacter orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<TsBaseCharacter>(__Params->character);
		BulletBlueprintFunctionLibrary.SetBulletTarget(__Params->id, orCreateUObjectByNativePointer);
	}

	// Token: 0x060178BC RID: 96444 RVA: 0x0068C79D File Offset: 0x0068A99D
	protected unsafe static void __CPPCALL_SetBulletSummon_Implementation(BulletBlueprintFunctionLibrary.__SetBulletSummon_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.SetBulletSummon(__Params->id);
	}

	// Token: 0x060178BD RID: 96445 RVA: 0x0068C7AA File Offset: 0x0068A9AA
	protected unsafe static void __CPPCALL_SetBulletTransform_Implementation(BulletBlueprintFunctionLibrary.__SetBulletTransform_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.SetBulletTransform(__Params->id, __Params->newTransform);
	}

	// Token: 0x060178BE RID: 96446 RVA: 0x0068C7BD File Offset: 0x0068A9BD
	protected unsafe static void __CPPCALL_SetBeginSpeed_Implementation(BulletBlueprintFunctionLibrary.__SetBeginSpeed_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.SetBeginSpeed(__Params->id, __Params->newSpeed);
	}

	// Token: 0x060178BF RID: 96447 RVA: 0x0068C7D0 File Offset: 0x0068A9D0
	protected unsafe static void __CPPCALL_CalcPipe_Implementation(BulletBlueprintFunctionLibrary.__CalcPipe_FunctionParams* __Params)
	{
		TArray<FVector> tarray = new TArray<FVector>(&__Params->outVertices, true, true);
		TArray<int> tarray2 = new TArray<int>(&__Params->outTriangles, true, true);
		BulletBlueprintFunctionLibrary.CalcPipe(__Params->centerPoint, __Params->forward, __Params->up, __Params->outsideRadius, __Params->insideRadius, __Params->height, __Params->sectionNum, ref tarray, ref tarray2);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->outVertices, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->outTriangles, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060178C0 RID: 96448 RVA: 0x0068C860 File Offset: 0x0068AA60
	protected unsafe static void __CPPCALL_CalcSector_Implementation(BulletBlueprintFunctionLibrary.__CalcSector_FunctionParams* __Params)
	{
		TArray<FVector> tarray = new TArray<FVector>(&__Params->verticesArray, true, true);
		TArray<int> tarray2 = new TArray<int>(&__Params->trianglesArray, true, true);
		BulletBlueprintFunctionLibrary.CalcSector(__Params->centerPoint, __Params->forward, __Params->up, __Params->inAngle, __Params->radius, __Params->height, __Params->sectionNum, ref tarray, ref tarray2);
		if (tarray != null)
		{
			tarray.CopyTo(&__Params->verticesArray, default(UScriptStructStackOnlyPtr));
		}
		if (tarray2 != null)
		{
			tarray2.CopyTo(&__Params->trianglesArray, default(UScriptStructStackOnlyPtr));
		}
	}

	// Token: 0x060178C1 RID: 96449 RVA: 0x0068C8F0 File Offset: 0x0068AAF0
	protected unsafe static void __CPPCALL_CalcBulletInitLocation_Implementation(BulletBlueprintFunctionLibrary.__CalcBulletInitLocation_FunctionParams* __Params)
	{
		SReBulletDataMain dataMain = new SReBulletDataMain(&__Params->dataMain, true, true);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->attacker);
		__Params->__Result = BulletBlueprintFunctionLibrary.CalcBulletInitLocation(dataMain, orCreateUObjectByNativePointer, __Params->target);
	}

	// Token: 0x060178C2 RID: 96450 RVA: 0x0068C92C File Offset: 0x0068AB2C
	protected unsafe static void __CPPCALL_AttachToBone_Implementation(BulletBlueprintFunctionLibrary.__AttachToBone_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->meshComp);
		AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->bulletActor);
		SReBulletDataMain dataMain = new SReBulletDataMain(&__Params->dataMain, true, true);
		BulletBlueprintFunctionLibrary.AttachToBone(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, dataMain);
	}

	// Token: 0x060178C3 RID: 96451 RVA: 0x0068C968 File Offset: 0x0068AB68
	protected unsafe static void __CPPCALL_CalcBulletInitRotator_Implementation(BulletBlueprintFunctionLibrary.__CalcBulletInitRotator_FunctionParams* __Params)
	{
		SReBulletDataMain dataMain = new SReBulletDataMain(&__Params->dataMain, true, true);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->bulletActor);
		AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->attacker);
		AActor orCreateUObjectByNativePointer3 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->parentBulletActor);
		__Params->__Result = BulletBlueprintFunctionLibrary.CalcBulletInitRotator(dataMain, orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->target, orCreateUObjectByNativePointer3);
	}

	// Token: 0x060178C4 RID: 96452 RVA: 0x0068C9C0 File Offset: 0x0068ABC0
	protected unsafe static void __CPPCALL_CalcBulletRotator_Implementation(BulletBlueprintFunctionLibrary.__CalcBulletRotator_FunctionParams* __Params)
	{
		SReBulletDataMain dataMain = new SReBulletDataMain(&__Params->dataMain, true, true);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->bulletActor);
		AActor orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->attacker);
		__Params->__Result = BulletBlueprintFunctionLibrary.CalcBulletRotator(dataMain, orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->target, __Params->delta);
	}

	// Token: 0x060178C5 RID: 96453 RVA: 0x0068CA10 File Offset: 0x0068AC10
	protected unsafe static void __CPPCALL_CalcBulletLocation_Implementation(BulletBlueprintFunctionLibrary.__CalcBulletLocation_FunctionParams* __Params)
	{
		SReBulletDataMain dataMain = new SReBulletDataMain(&__Params->dataMain, true, true);
		AActor orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(__Params->bulletActor);
		__Params->__Result = BulletBlueprintFunctionLibrary.CalcBulletLocation(dataMain, orCreateUObjectByNativePointer, __Params->delta);
	}

	// Token: 0x060178C6 RID: 96454 RVA: 0x0068CA4B File Offset: 0x0068AC4B
	protected unsafe static void __CPPCALL_GetCampRelationship_Implementation(BulletBlueprintFunctionLibrary.__GetCampRelationship_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetCampRelationship(__Params->camp1, __Params->camp2);
	}

	// Token: 0x060178C7 RID: 96455 RVA: 0x0068CA64 File Offset: 0x0068AC64
	protected unsafe static void __CPPCALL_GetCamp_Implementation(BulletBlueprintFunctionLibrary.__GetCamp_FunctionParams* __Params)
	{
		__Params->__Result = BulletBlueprintFunctionLibrary.GetCamp(__Params->entityId);
	}

	// Token: 0x060178C8 RID: 96456 RVA: 0x0068CA77 File Offset: 0x0068AC77
	protected unsafe static void __CPPCALL_NotifyProcessKuroBulletOperationList_Implementation(BulletBlueprintFunctionLibrary.__NotifyProcessKuroBulletOperationList_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.NotifyProcessKuroBulletOperationList();
	}

	// Token: 0x060178C9 RID: 96457 RVA: 0x0068CA7E File Offset: 0x0068AC7E
	protected unsafe static void __CPPCALL_NotifyExistedImmediatelyOperation_Implementation(BulletBlueprintFunctionLibrary.__NotifyExistedImmediatelyOperation_FunctionParams* __Params)
	{
		BulletBlueprintFunctionLibrary.NotifyExistedImmediatelyOperation(new FBulletHitWorldEntityOperation(&__Params->operation, true, true));
	}

	// Token: 0x0400B489 RID: 46217
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/BulletBlueprintFunctionLibrary.BulletBlueprintFunctionLibrary_C";

	// Token: 0x0400B48A RID: 46218
	private static IntPtr _ClassPtr;

	// Token: 0x0400B48B RID: 46219
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x02009044 RID: 36932
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __CreateBulletForDebug_FunctionParams
	{
		// Token: 0x04030630 RID: 198192
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030631 RID: 198193
		[FieldOffset(8)]
		public FString bulletRowName;

		// Token: 0x04030632 RID: 198194
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04030633 RID: 198195
		[FieldOffset(32)]
		public float __Result;
	}

	// Token: 0x02009045 RID: 36933
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 160)]
	protected ref struct __CreateBulletFromGA_FunctionParams
	{
		// Token: 0x04030634 RID: 198196
		[FieldOffset(0)]
		public IntPtr owner;

		// Token: 0x04030635 RID: 198197
		[FieldOffset(8)]
		public FString bulletRowName;

		// Token: 0x04030636 RID: 198198
		[FieldOffset(32)]
		public FTransformDouble initialTransform;

		// Token: 0x04030637 RID: 198199
		[FieldOffset(96)]
		public FString skillId;

		// Token: 0x04030638 RID: 198200
		[FieldOffset(112)]
		public bool needSync;

		// Token: 0x04030639 RID: 198201
		[FieldOffset(120)]
		public FVectorDouble targetLocation;

		// Token: 0x0403063A RID: 198202
		[FieldOffset(144)]
		public IntPtr __WorldContext;

		// Token: 0x0403063B RID: 198203
		[FieldOffset(152)]
		public int __Result;
	}

	// Token: 0x02009046 RID: 36934
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBulletActorById_FunctionParams
	{
		// Token: 0x0403063C RID: 198204
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403063D RID: 198205
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403063E RID: 198206
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009047 RID: 36935
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __DestroyBullet_FunctionParams
	{
		// Token: 0x0403063F RID: 198207
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030640 RID: 198208
		[FieldOffset(4)]
		public bool isSummonChildBullet;

		// Token: 0x04030641 RID: 198209
		[FieldOffset(5)]
		public bool destroyEffectImmediately;

		// Token: 0x04030642 RID: 198210
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030643 RID: 198211
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009048 RID: 36936
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DestroyAllBullet_FunctionParams
	{
		// Token: 0x04030644 RID: 198212
		[FieldOffset(0)]
		public bool summonChild;

		// Token: 0x04030645 RID: 198213
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009049 RID: 36937
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __DestroySpecifiedBullet_FunctionParams
	{
		// Token: 0x04030646 RID: 198214
		[FieldOffset(0)]
		public int ownerId;

		// Token: 0x04030647 RID: 198215
		[FieldOffset(4)]
		public FName bulletName;

		// Token: 0x04030648 RID: 198216
		[FieldOffset(16)]
		public bool summonChild;

		// Token: 0x04030649 RID: 198217
		[FieldOffset(20)]
		public int includeTeammate;

		// Token: 0x0403064A RID: 198218
		[FieldOffset(24)]
		public float interval;

		// Token: 0x0403064B RID: 198219
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200904A RID: 36938
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetSpecifiedBulletCount_FunctionParams
	{
		// Token: 0x0403064C RID: 198220
		[FieldOffset(0)]
		public int ownerId;

		// Token: 0x0403064D RID: 198221
		[FieldOffset(4)]
		public FName bulletName;

		// Token: 0x0403064E RID: 198222
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x0403064F RID: 198223
		[FieldOffset(24)]
		public int __Result;
	}

	// Token: 0x0200904B RID: 36939
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetCharacterLaunchedBulletIds_FunctionParams
	{
		// Token: 0x04030650 RID: 198224
		[FieldOffset(0)]
		public int characterId;

		// Token: 0x04030651 RID: 198225
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030652 RID: 198226
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x0200904C RID: 36940
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DebugShowBulletCollision_FunctionParams
	{
		// Token: 0x04030653 RID: 198227
		[FieldOffset(0)]
		public bool isShow;

		// Token: 0x04030654 RID: 198228
		[FieldOffset(4)]
		public int entityId;

		// Token: 0x04030655 RID: 198229
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200904D RID: 36941
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __DebugShowBulletTrace_FunctionParams
	{
		// Token: 0x04030656 RID: 198230
		[FieldOffset(0)]
		public bool isShow;

		// Token: 0x04030657 RID: 198231
		[FieldOffset(4)]
		public int entityId;

		// Token: 0x04030658 RID: 198232
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200904E RID: 36942
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsShowBulletCollision_FunctionParams
	{
		// Token: 0x04030659 RID: 198233
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403065A RID: 198234
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403065B RID: 198235
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x0200904F RID: 36943
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetIsShowBulletTrace_FunctionParams
	{
		// Token: 0x0403065C RID: 198236
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x0403065D RID: 198237
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403065E RID: 198238
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x02009050 RID: 36944
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __FrozenBulletTimeByBulletName_FunctionParams
	{
		// Token: 0x0403065F RID: 198239
		[FieldOffset(0)]
		public IntPtr character;

		// Token: 0x04030660 RID: 198240
		[FieldOffset(8)]
		public FString bulletDataName;

		// Token: 0x04030661 RID: 198241
		[FieldOffset(24)]
		public float time;

		// Token: 0x04030662 RID: 198242
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009051 RID: 36945
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __SetEntityIdByCustomKey_FunctionParams
	{
		// Token: 0x04030663 RID: 198243
		[FieldOffset(0)]
		public int attackerId;

		// Token: 0x04030664 RID: 198244
		[FieldOffset(8)]
		public FString customKey;

		// Token: 0x04030665 RID: 198245
		[FieldOffset(24)]
		public int targetId;

		// Token: 0x04030666 RID: 198246
		[FieldOffset(32)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009052 RID: 36946
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAllBullet_FunctionParams
	{
		// Token: 0x04030667 RID: 198247
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04030668 RID: 198248
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x02009053 RID: 36947
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 80)]
	protected ref struct __GetBulletTransform_FunctionParams
	{
		// Token: 0x04030669 RID: 198249
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403066A RID: 198250
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403066B RID: 198251
		[FieldOffset(16)]
		public FTransformDouble __Result;
	}

	// Token: 0x02009054 RID: 36948
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBulletAttacker_FunctionParams
	{
		// Token: 0x0403066C RID: 198252
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403066D RID: 198253
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x0403066E RID: 198254
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009055 RID: 36949
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetBulletCollision_FunctionParams
	{
		// Token: 0x0403066F RID: 198255
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030670 RID: 198256
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030671 RID: 198257
		[FieldOffset(16)]
		public IntPtr __Result;
	}

	// Token: 0x02009056 RID: 36950
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 32)]
	protected ref struct __GetBulletName_FunctionParams
	{
		// Token: 0x04030672 RID: 198258
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030673 RID: 198259
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04030674 RID: 198260
		[FieldOffset(16)]
		public FString __Result;
	}

	// Token: 0x02009057 RID: 36951
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetBulletStopHitTrue_FunctionParams
	{
		// Token: 0x04030675 RID: 198261
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030676 RID: 198262
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009058 RID: 36952
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __SetBulletTarget_FunctionParams
	{
		// Token: 0x04030677 RID: 198263
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030678 RID: 198264
		[FieldOffset(8)]
		public IntPtr character;

		// Token: 0x04030679 RID: 198265
		[FieldOffset(16)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009059 RID: 36953
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetBulletSummon_FunctionParams
	{
		// Token: 0x0403067A RID: 198266
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403067B RID: 198267
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200905A RID: 36954
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __SetBulletTransform_FunctionParams
	{
		// Token: 0x0403067C RID: 198268
		[FieldOffset(0)]
		public int id;

		// Token: 0x0403067D RID: 198269
		[FieldOffset(16)]
		public FTransformDouble newTransform;

		// Token: 0x0403067E RID: 198270
		[FieldOffset(80)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200905B RID: 36955
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetBeginSpeed_FunctionParams
	{
		// Token: 0x0403067F RID: 198271
		[FieldOffset(0)]
		public int id;

		// Token: 0x04030680 RID: 198272
		[FieldOffset(4)]
		public float newSpeed;

		// Token: 0x04030681 RID: 198273
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200905C RID: 36956
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __CalcPipe_FunctionParams
	{
		// Token: 0x04030682 RID: 198274
		[FieldOffset(0)]
		public FVector centerPoint;

		// Token: 0x04030683 RID: 198275
		[FieldOffset(12)]
		public FVector forward;

		// Token: 0x04030684 RID: 198276
		[FieldOffset(24)]
		public FVector up;

		// Token: 0x04030685 RID: 198277
		[FieldOffset(36)]
		public float outsideRadius;

		// Token: 0x04030686 RID: 198278
		[FieldOffset(40)]
		public float insideRadius;

		// Token: 0x04030687 RID: 198279
		[FieldOffset(44)]
		public float height;

		// Token: 0x04030688 RID: 198280
		[FieldOffset(48)]
		public int sectionNum;

		// Token: 0x04030689 RID: 198281
		[FieldOffset(56)]
		public byte outVertices;

		// Token: 0x0403068A RID: 198282
		[FieldOffset(72)]
		public byte outTriangles;

		// Token: 0x0403068B RID: 198283
		[FieldOffset(88)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200905D RID: 36957
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __CalcSector_FunctionParams
	{
		// Token: 0x0403068C RID: 198284
		[FieldOffset(0)]
		public FVector centerPoint;

		// Token: 0x0403068D RID: 198285
		[FieldOffset(12)]
		public FVector forward;

		// Token: 0x0403068E RID: 198286
		[FieldOffset(24)]
		public FVector up;

		// Token: 0x0403068F RID: 198287
		[FieldOffset(36)]
		public float inAngle;

		// Token: 0x04030690 RID: 198288
		[FieldOffset(40)]
		public float radius;

		// Token: 0x04030691 RID: 198289
		[FieldOffset(44)]
		public float height;

		// Token: 0x04030692 RID: 198290
		[FieldOffset(48)]
		public int sectionNum;

		// Token: 0x04030693 RID: 198291
		[FieldOffset(56)]
		public byte verticesArray;

		// Token: 0x04030694 RID: 198292
		[FieldOffset(72)]
		public byte trianglesArray;

		// Token: 0x04030695 RID: 198293
		[FieldOffset(88)]
		public IntPtr __WorldContext;
	}

	// Token: 0x0200905E RID: 36958
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2096)]
	protected ref struct __CalcBulletInitLocation_FunctionParams
	{
		// Token: 0x04030696 RID: 198294
		[FieldOffset(0)]
		public byte dataMain;

		// Token: 0x04030697 RID: 198295
		[FieldOffset(1992)]
		public IntPtr attacker;

		// Token: 0x04030698 RID: 198296
		[FieldOffset(2000)]
		public FTransformDouble target;

		// Token: 0x04030699 RID: 198297
		[FieldOffset(2064)]
		public IntPtr __WorldContext;

		// Token: 0x0403069A RID: 198298
		[FieldOffset(2072)]
		public FVectorDouble __Result;
	}

	// Token: 0x0200905F RID: 36959
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2016)]
	protected ref struct __AttachToBone_FunctionParams
	{
		// Token: 0x0403069B RID: 198299
		[FieldOffset(0)]
		public IntPtr meshComp;

		// Token: 0x0403069C RID: 198300
		[FieldOffset(8)]
		public IntPtr bulletActor;

		// Token: 0x0403069D RID: 198301
		[FieldOffset(16)]
		public byte dataMain;

		// Token: 0x0403069E RID: 198302
		[FieldOffset(2008)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009060 RID: 36960
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2112)]
	protected ref struct __CalcBulletInitRotator_FunctionParams
	{
		// Token: 0x0403069F RID: 198303
		[FieldOffset(0)]
		public byte dataMain;

		// Token: 0x040306A0 RID: 198304
		[FieldOffset(1992)]
		public IntPtr bulletActor;

		// Token: 0x040306A1 RID: 198305
		[FieldOffset(2000)]
		public IntPtr attacker;

		// Token: 0x040306A2 RID: 198306
		[FieldOffset(2016)]
		public FTransformDouble target;

		// Token: 0x040306A3 RID: 198307
		[FieldOffset(2080)]
		public IntPtr parentBulletActor;

		// Token: 0x040306A4 RID: 198308
		[FieldOffset(2088)]
		public IntPtr __WorldContext;

		// Token: 0x040306A5 RID: 198309
		[FieldOffset(2096)]
		public FRotator __Result;
	}

	// Token: 0x02009061 RID: 36961
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2064)]
	protected ref struct __CalcBulletRotator_FunctionParams
	{
		// Token: 0x040306A6 RID: 198310
		[FieldOffset(0)]
		public byte dataMain;

		// Token: 0x040306A7 RID: 198311
		[FieldOffset(1992)]
		public IntPtr bulletActor;

		// Token: 0x040306A8 RID: 198312
		[FieldOffset(2000)]
		public IntPtr attacker;

		// Token: 0x040306A9 RID: 198313
		[FieldOffset(2008)]
		public FVectorDouble target;

		// Token: 0x040306AA RID: 198314
		[FieldOffset(2032)]
		public float delta;

		// Token: 0x040306AB RID: 198315
		[FieldOffset(2040)]
		public IntPtr __WorldContext;

		// Token: 0x040306AC RID: 198316
		[FieldOffset(2048)]
		public FRotator __Result;
	}

	// Token: 0x02009062 RID: 36962
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 2040)]
	protected ref struct __CalcBulletLocation_FunctionParams
	{
		// Token: 0x040306AD RID: 198317
		[FieldOffset(0)]
		public byte dataMain;

		// Token: 0x040306AE RID: 198318
		[FieldOffset(1992)]
		public IntPtr bulletActor;

		// Token: 0x040306AF RID: 198319
		[FieldOffset(2000)]
		public float delta;

		// Token: 0x040306B0 RID: 198320
		[FieldOffset(2008)]
		public IntPtr __WorldContext;

		// Token: 0x040306B1 RID: 198321
		[FieldOffset(2016)]
		public FVectorDouble __Result;
	}

	// Token: 0x02009063 RID: 36963
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCampRelationship_FunctionParams
	{
		// Token: 0x040306B2 RID: 198322
		[FieldOffset(0)]
		public int camp1;

		// Token: 0x040306B3 RID: 198323
		[FieldOffset(4)]
		public int camp2;

		// Token: 0x040306B4 RID: 198324
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040306B5 RID: 198325
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009064 RID: 36964
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCamp_FunctionParams
	{
		// Token: 0x040306B6 RID: 198326
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x040306B7 RID: 198327
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x040306B8 RID: 198328
		[FieldOffset(16)]
		public int __Result;
	}

	// Token: 0x02009065 RID: 36965
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 8)]
	protected ref struct __NotifyProcessKuroBulletOperationList_FunctionParams
	{
		// Token: 0x040306B9 RID: 198329
		[FieldOffset(0)]
		public IntPtr __WorldContext;
	}

	// Token: 0x02009066 RID: 36966
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 96)]
	protected ref struct __NotifyExistedImmediatelyOperation_FunctionParams
	{
		// Token: 0x040306BA RID: 198330
		[FieldOffset(0)]
		public byte operation;

		// Token: 0x040306BB RID: 198331
		[FieldOffset(88)]
		public IntPtr __WorldContext;
	}
}
