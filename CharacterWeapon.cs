using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02003164 RID: 12644
[NullableContext(1)]
[Nullable(0)]
public class CharacterWeapon
{
	// Token: 0x0601A365 RID: 107365 RVA: 0x007B3E72 File Offset: 0x007B2072
	public CharacterWeapon(int index, UMeshComponent mesh, [Nullable(2)] UEffectModelBase hideEffectMode, int? entityId = null)
	{
		this.Index = index;
		this.Mesh = mesh;
		this.HideEffectMode = hideEffectMode;
		this.EntityId = entityId;
		this.VisibleHelper = new WeaponMeshVisibleHelper(this);
	}

	// Token: 0x0601A366 RID: 107366 RVA: 0x007B3EAE File Offset: 0x007B20AE
	public void Destroy()
	{
		this.ReleaseHideEffect();
		if (this.SceneInteractId != 0)
		{
			ModelBase<SceneBattleInteractModel>.Instance.DestroySceneBattleInteract(this.SceneInteractId);
		}
	}

	// Token: 0x0601A367 RID: 107367 RVA: 0x007B3ED0 File Offset: 0x007B20D0
	public void ReleaseHideEffect()
	{
		if (Singleton<EffectSystem>.Instance.IsValid(this.WeaponHideEffect))
		{
			Singleton<EffectSystem>.Instance.StopEffectById(this.WeaponHideEffect, "[CharacterWeapon.Destroy]", true, null);
			this.WeaponHideEffect = 0;
		}
	}

	// Token: 0x0601A368 RID: 107368 RVA: 0x007B3F18 File Offset: 0x007B2118
	[NullableContext(2)]
	public void ShowHideEffect(string effectPath = null)
	{
		FTransformDouble value = this.Mesh.D_GetSocketTransform(FNameUtil.EMPTY, ERelativeTransformSpace.RTS_World);
		if (!Singleton<EffectSystem>.Instance.IsValid(this.WeaponHideEffect))
		{
			SkeletalMeshEffectContext skeletalMeshEffectContext = new SkeletalMeshEffectContext(this.EntityId, null, false);
			skeletalMeshEffectContext.SkeletalMeshComp = (USkeletalMeshComponent)this.Mesh;
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject mesh = this.Mesh;
			FTransformDouble? ftransformDouble = new FTransformDouble?(value);
			this.WeaponHideEffect = instance.SpawnEffect(mesh, ftransformDouble, effectPath ?? "/Game/Aki/Effect/EffectGroup/Common/DA_Fx_Group_WeaponEnd.DA_Fx_Group_WeaponEnd", "[CharacterWeapon.ShowHideEffect]", skeletalMeshEffectContext, EEffectType.Scene, null, null, null, false, false);
		}
		if (!Singleton<EffectSystem>.Instance.IsValid(this.WeaponHideEffect))
		{
			this.WeaponHideEffect = 0;
			return;
		}
		this.UpdateHideEffectStateInSelfCentered();
		if (!string.IsNullOrEmpty(effectPath))
		{
			return;
		}
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.WeaponHideEffect);
		effectActor.K2_AttachToComponent(this.Mesh, new FName?(FNameUtil.EMPTY), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
		FHitResult fhitResult = new FHitResult();
		effectActor.D_K2_SetActorTransform(value, false, ref fhitResult, true);
	}

	// Token: 0x0601A369 RID: 107369 RVA: 0x007B4004 File Offset: 0x007B2204
	public void SetBuffEffectsHiddenInGame(bool isHidden)
	{
		List<int> list = null;
		foreach (int num in this.WeaponBuffEffects)
		{
			if (!Singleton<EffectSystem>.Instance.IsValid(num))
			{
				if (list == null)
				{
					list = new List<int>();
				}
				list.Add(num);
			}
			else
			{
				AActor sureEffectActor = Singleton<EffectSystem>.Instance.GetSureEffectActor(num);
				if (sureEffectActor != null && sureEffectActor.IsValid() && sureEffectActor.bHidden != isHidden)
				{
					Singleton<EffectSystem>.Instance.SetEffectHidden(num, isHidden, null, false);
				}
			}
		}
		if (list != null)
		{
			foreach (int item in list)
			{
				this.WeaponBuffEffects.Remove(item);
			}
		}
	}

	// Token: 0x0601A36A RID: 107370 RVA: 0x007B40E8 File Offset: 0x007B22E8
	public void AddBuffEffect(int effectId)
	{
		this.WeaponBuffEffects.Add(effectId);
		if (this.WeaponHidden && Singleton<EffectSystem>.Instance.GetEffectActor(effectId).IsValid())
		{
			Singleton<EffectSystem>.Instance.SetEffectHidden(effectId, true, null, false);
		}
	}

	// Token: 0x0601A36B RID: 107371 RVA: 0x007B411F File Offset: 0x007B231F
	public void RemoveBuffEffect(int effectId)
	{
		this.WeaponBuffEffects.Remove(effectId);
	}

	// Token: 0x0601A36C RID: 107372 RVA: 0x007B412E File Offset: 0x007B232E
	public void InitWeaponSceneInteract(int weaponType)
	{
		this.SceneInteractWeaponType = weaponType;
	}

	// Token: 0x0601A36D RID: 107373 RVA: 0x007B4138 File Offset: 0x007B2338
	public void UpdateSceneInteractEnable(bool isWeaponOut)
	{
		if (!ModelBase<SceneBattleInteractModel>.Instance.Open)
		{
			this.SceneInteractId = 0;
			return;
		}
		bool flag = isWeaponOut && !this.WeaponHidden;
		if (this.SceneInteractId != 0)
		{
			ModelBase<SceneBattleInteractModel>.Instance.SetSceneBattleInteractEnable(this.SceneInteractId, flag, 0f);
			return;
		}
		if (!flag)
		{
			return;
		}
		BP_SceneBattleInteract_C weaponInteractConfig = ModelBase<SceneBattleInteractModel>.Instance.GetWeaponInteractConfig(this.SceneInteractWeaponType);
		if (weaponInteractConfig != null)
		{
			SceneBattleInteractEffect sceneBattleInteractEffect = ModelBase<SceneBattleInteractModel>.Instance.CreateSceneBattleInteract(weaponInteractConfig, 0f, 0f);
			if (sceneBattleInteractEffect != null)
			{
				this.SceneInteractId = sceneBattleInteractEffect.Id;
				sceneBattleInteractEffect.SetIsCommonWeapon(true);
				sceneBattleInteractEffect.SetDispatchWeaponEventEnable(true);
				sceneBattleInteractEffect.BindEntityId(this.EntityId.GetValueOrDefault());
				sceneBattleInteractEffect.SetUpdateLocationSocket(this.Mesh, FNameUtil.EMPTY);
				sceneBattleInteractEffect.SetEnable(true, 0f);
			}
		}
	}

	// Token: 0x0601A36E RID: 107374 RVA: 0x007B4202 File Offset: 0x007B2402
	public void UpdateSelfCenteredState()
	{
		this.UpdateHideEffectStateInSelfCentered();
	}

	// Token: 0x0601A36F RID: 107375 RVA: 0x007B420C File Offset: 0x007B240C
	public void UpdateHideEffectStateInSelfCentered()
	{
		if (this.EntityId == null || !Singleton<EffectSystem>.Instance.IsValid(this.WeaponHideEffect))
		{
			return;
		}
		PawnTimeScaleComponent component = Singleton<EntitySystem>.Instance.GetComponent<PawnTimeScaleComponent>(this.EntityId.Value);
		if (component == null || !component.Valid)
		{
			return;
		}
		ForeverTimeScale topForeverTimeScaleConfig = component.GetTopForeverTimeScaleConfig(new ESourceEffectGroup?(ESourceEffectGroup.LogicAndView));
		if (topForeverTimeScaleConfig == null)
		{
			return;
		}
		Singleton<EffectSystem>.Instance.SetAdditionTimeScale(topForeverTimeScaleConfig.SourceType, this.WeaponHideEffect, topForeverTimeScaleConfig.TimeDilation);
	}

	// Token: 0x0400D2D5 RID: 53973
	public FName? NormalSocket;

	// Token: 0x0400D2D6 RID: 53974
	public FName? BattleSocket;

	// Token: 0x0400D2D7 RID: 53975
	public int? BattleEffectId;

	// Token: 0x0400D2D8 RID: 53976
	public FTransformDouble? LerpStartTransform;

	// Token: 0x0400D2D9 RID: 53977
	public FTransformDouble? LerpEndTransform;

	// Token: 0x0400D2DA RID: 53978
	public bool WeaponHidden;

	// Token: 0x0400D2DB RID: 53979
	public int WeaponHideEffect;

	// Token: 0x0400D2DC RID: 53980
	public HashSet<int> WeaponBuffEffects = new HashSet<int>();

	// Token: 0x0400D2DD RID: 53981
	public int SceneInteractId;

	// Token: 0x0400D2DE RID: 53982
	public int SceneInteractWeaponType;

	// Token: 0x0400D2DF RID: 53983
	public WeaponMeshVisibleHelper VisibleHelper;

	// Token: 0x0400D2E0 RID: 53984
	public int Index;

	// Token: 0x0400D2E1 RID: 53985
	public UMeshComponent Mesh;

	// Token: 0x0400D2E2 RID: 53986
	[Nullable(2)]
	public UEffectModelBase HideEffectMode;

	// Token: 0x0400D2E3 RID: 53987
	public int? EntityId;
}
