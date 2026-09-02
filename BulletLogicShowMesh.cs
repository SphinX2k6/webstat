using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Manager;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

// Token: 0x02002DCB RID: 11723
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicShowMesh : BulletLogicController<LogicDataShowMesh, object>
{
	// Token: 0x06017A17 RID: 96791 RVA: 0x00694C66 File Offset: 0x00692E66
	public BulletLogicShowMesh(LogicDataShowMesh bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x06017A18 RID: 96792 RVA: 0x00694C84 File Offset: 0x00692E84
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		this.BulletInfo = this.Bullet.GetBulletInfo();
		if (this.BulletInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "无法获取BattleInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (this.BulletInfo.Target == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "子弹没有目标，生成残影失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SpawnGhostMesh();
		this.InitRenderingComponent();
		this.SetupWeapon();
		this.InitMaterialEffect();
	}

	// Token: 0x06017A19 RID: 96793 RVA: 0x00694D08 File Offset: 0x00692F08
	public override void OnBulletDestroy()
	{
		BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
		if (this.PoseComponent != null)
		{
			bulletInfo.Actor.K2_DestroyComponent(this.PoseComponent);
		}
		if (this.CharRenderingComponent != null)
		{
			bulletInfo.Actor.K2_DestroyComponent(this.CharRenderingComponent);
			this.CharRenderingComponent = null;
		}
		foreach (UPoseableMeshComponent uposeableMeshComponent in this.WeaponPoseComponent)
		{
			if (uposeableMeshComponent != null)
			{
				bulletInfo.Actor.K2_DestroyComponent(uposeableMeshComponent);
			}
		}
		this.WeaponPoseComponent.Clear();
	}

	// Token: 0x06017A1A RID: 96794 RVA: 0x00694DB4 File Offset: 0x00692FB4
	private bool SpawnGhostMesh()
	{
		if (this.BulletInfo.Target == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "子弹没有目标，生成残影失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		USkeletalMeshComponent mesh = this.BulletInfo.Target.GetComponent<CharacterActorComponent>().Actor.Mesh;
		this.PoseComponent = this.GetPoseComponent(mesh);
		if (this.PoseComponent != null)
		{
			FHitResult fhitResult = new FHitResult();
			USceneComponent poseComponent = this.PoseComponent;
			FTransformDouble actorTransform = this.BulletInfo.ActorComponent.ActorTransform;
			poseComponent.D_K2_SetWorldTransform(actorTransform, false, ref fhitResult, true);
			this.PoseComponent.CopyPoseFromSkeletalComponent(this.BulletInfo.Target.GetComponent<CharacterActorComponent>().Actor.Mesh);
			this.PoseComponent.SetForcedLOD(99);
			this.PoseComponent.CastShadow = false;
			return true;
		}
		Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "PoseComponent初始化失败", default(ReadOnlySpan<ValueTuple<string, object>>));
		return false;
	}

	// Token: 0x06017A1B RID: 96795 RVA: 0x00694E9F File Offset: 0x0069309F
	[return: Nullable(2)]
	private UPoseableMeshComponent GetPoseComponent(USkeletalMeshComponent mesh)
	{
		UPoseableMeshComponent uposeableMeshComponent = UKuroEffectLibrary.AddSceneComponent(this.BulletInfo.Actor, UPoseableMeshComponent.StaticClass(), null, false) as UPoseableMeshComponent;
		if (uposeableMeshComponent == null)
		{
			return uposeableMeshComponent;
		}
		uposeableMeshComponent.SetSkeletalMesh(mesh.SkeletalMesh, false);
		return uposeableMeshComponent;
	}

	// Token: 0x06017A1C RID: 96796 RVA: 0x00694ED0 File Offset: 0x006930D0
	private void InitRenderingComponent()
	{
		if (this.CharRenderingComponent == null)
		{
			this.CharRenderingComponent = (this.BulletInfo.Actor.AddComponentByClass(CharRenderingComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as CharRenderingComponent);
		}
		if (this.CharRenderingComponent == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.YZ, "BulletLogicShowMesh中渲染组件添加失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CharRenderingComponent.Init(ECharacterRenderingType.LocalPlayer);
		this.CharRenderingComponent.AddComponentByCase(ECharacterControllerCaseType.BodyCase0, this.PoseComponent);
	}

	// Token: 0x06017A1D RID: 96797 RVA: 0x00694F64 File Offset: 0x00693164
	private void SetupWeapon()
	{
		Entity target = this.Bullet.GetBulletInfo().Target;
		if (target == null)
		{
			return;
		}
		CharacterWeaponComponent component = target.GetComponent<CharacterWeaponComponent>();
		if (component == null)
		{
			return;
		}
		CharacterWeaponMesh weaponMesh = component.GetWeaponMesh();
		float[] array = target.GetComponent<CreatureDataComponent>().GetRoleConfig().Value.WeaponScale();
		Vector vector = Vector.Create((double)array[0], (double)array[1], (double)array[2]);
		int num = 0;
		ECharacterControllerCaseType[] array2 = new ECharacterControllerCaseType[]
		{
			ECharacterControllerCaseType.WeaponCase0,
			ECharacterControllerCaseType.WeaponCase1,
			ECharacterControllerCaseType.WeaponCase2,
			ECharacterControllerCaseType.WeaponCase3,
			ECharacterControllerCaseType.WeaponCase4
		};
		foreach (CharacterWeapon characterWeapon in weaponMesh.CharacterWeapons)
		{
			if (!characterWeapon.WeaponHidden)
			{
				UPoseableMeshComponent uposeableMeshComponent = UKuroEffectLibrary.AddSceneComponent(this.BulletInfo.Actor, UPoseableMeshComponent.StaticClass(), null, false) as UPoseableMeshComponent;
				uposeableMeshComponent.SetSkeletalMesh((characterWeapon.Mesh as USkeletalMeshComponent).SkeletalMesh, false);
				uposeableMeshComponent.CopyPoseFromSkeletalComponent(characterWeapon.Mesh as USkeletalMeshComponent);
				uposeableMeshComponent.SetForcedLOD(99);
				uposeableMeshComponent.CastShadow = false;
				this.HangSingleWeapon(uposeableMeshComponent, characterWeapon.BattleSocket.Value, vector.ToUeVector(false));
				this.CharRenderingComponent.AddComponentByCase(array2[num + 1], uposeableMeshComponent);
				this.WeaponPoseComponent.Add(uposeableMeshComponent);
				num++;
			}
			else
			{
				num++;
			}
		}
	}

	// Token: 0x06017A1E RID: 96798 RVA: 0x006950BC File Offset: 0x006932BC
	private void InitMaterialEffect()
	{
		BulletLogicShowMesh.<>c__DisplayClass13_0 CS$<>8__locals1 = new BulletLogicShowMesh.<>c__DisplayClass13_0();
		CS$<>8__locals1.<>4__this = this;
		BulletLogicShowMesh.<>c__DisplayClass13_0 CS$<>8__locals2 = CS$<>8__locals1;
		FSoftObjectPath materialEffect = this.Parameter.MaterialEffect;
		CS$<>8__locals2.materialPath = ((materialEffect != null) ? materialEffect.AssetPathName.ToString() : null);
		if (!string.IsNullOrEmpty(CS$<>8__locals1.materialPath))
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<PD_CharacterControllerData_C>(CS$<>8__locals1.materialPath, delegate([Nullable(2)] PD_CharacterControllerData_C effect, string path)
			{
				if (effect == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.YZ;
					string message = "无法找到BulletLogicShowMesh子弹材质效果";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EffectPath", CS$<>8__locals1.materialPath);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				CS$<>8__locals1.<>4__this.CharRenderingComponent.AddMaterialControllerData(effect);
			}, 100, "js_undefined");
		}
	}

	// Token: 0x06017A1F RID: 96799 RVA: 0x00695134 File Offset: 0x00693334
	private void HangSingleWeapon(UMeshComponent mesh, FName socketName, FVectorDouble scale)
	{
		FTransformDouble ftransformDouble = new FTransformDouble();
		ftransformDouble.SetScale3D(scale);
		mesh.K2_AttachToComponent(this.PoseComponent, socketName, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, true, true);
		FHitResult fhitResult = new FHitResult();
		mesh.D_K2_SetRelativeTransform(ftransformDouble, false, ref fhitResult, true);
	}

	// Token: 0x0400B618 RID: 46616
	private const int MIN_LOD = 99;

	// Token: 0x0400B619 RID: 46617
	private readonly LogicDataShowMesh Parameter;

	// Token: 0x0400B61A RID: 46618
	[Nullable(2)]
	private CharRenderingComponent CharRenderingComponent;

	// Token: 0x0400B61B RID: 46619
	[Nullable(2)]
	private UPoseableMeshComponent PoseComponent;

	// Token: 0x0400B61C RID: 46620
	[Nullable(2)]
	private BulletInfo BulletInfo;

	// Token: 0x0400B61D RID: 46621
	private readonly List<UPoseableMeshComponent> WeaponPoseComponent = new List<UPoseableMeshComponent>();
}
