using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Entity.Struct;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.WeaponLevelMaterial;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CBC RID: 11452
[NullableContext(2)]
[Nullable(0)]
public class UiWeaponLevelMaterialComponent : UiModelComponentBase
{
	// Token: 0x06016FB5 RID: 94133 RVA: 0x0065ED85 File Offset: 0x0065CF85
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.LoadComponent = base.Owner.CheckGetComponent<UiModelLoadComponent>();
	}

	// Token: 0x06016FB6 RID: 94134 RVA: 0x0065EDBC File Offset: 0x0065CFBC
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.TryApply));
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_CharacterRenderingFunctionLibrary_C", delegate
		{
			this.IsTypeLoaded = true;
			this.TryApply();
		}, "Ui.WeaponUi");
	}

	// Token: 0x06016FB7 RID: 94135 RVA: 0x0065EE0B File Offset: 0x0065D00B
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.TryApply));
	}

	// Token: 0x06016FB8 RID: 94136 RVA: 0x0065EE2F File Offset: 0x0065D02F
	public void SetBreachLevel(int breachLevel)
	{
		this.BreachLevel = breachLevel;
	}

	// Token: 0x06016FB9 RID: 94137 RVA: 0x0065EE38 File Offset: 0x0065D038
	public void TryApply()
	{
		if (!this.IsTypeLoaded || this.ModelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			return;
		}
		ModelBase<WeaponModel>.Instance.BlueprintWeaponBreachLevel = this.BreachLevel;
		SModelConfig modelConfig = ModelUtil.GetModelConfig(this.ModelDataComponent.ModelConfigId);
		string text;
		if (modelConfig == null)
		{
			text = null;
		}
		else
		{
			FSoftObjectPath da = modelConfig.DA;
			text = ((da != null) ? da.GetAssetPathString() : null);
		}
		string text2 = text;
		if (string.IsNullOrEmpty(text2))
		{
			return;
		}
		UiModelActorComponent actorComponent = this.ActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComponent != null) ? actorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		UiModelLoadComponent loadComponent = this.LoadComponent;
		PD_WeaponLevelMaterialDatas_C pd_WeaponLevelMaterialDatas_C = ((loadComponent != null) ? loadComponent.GetLoadedResource(text2) : null) as PD_WeaponLevelMaterialDatas_C;
		if (pd_WeaponLevelMaterialDatas_C == null)
		{
			return;
		}
		ControllerBase<WeaponController>.Instance.ApplyWeaponLevelMaterial(uskeletalMeshComponent, pd_WeaponLevelMaterialDatas_C, this.BreachLevel);
	}

	// Token: 0x0400B133 RID: 45363
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B134 RID: 45364
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B135 RID: 45365
	private UiModelLoadComponent LoadComponent;

	// Token: 0x0400B136 RID: 45366
	private int BreachLevel;

	// Token: 0x0400B137 RID: 45367
	private bool IsTypeLoaded;
}
