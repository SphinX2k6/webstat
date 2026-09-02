using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002CA9 RID: 11433
public class UiRoleEyeHighLightComponent : UiModelComponentBase
{
	// Token: 0x06016F0D RID: 93965 RVA: 0x0065BD2F File Offset: 0x00659F2F
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
	}

	// Token: 0x06016F0E RID: 93966 RVA: 0x0065BD42 File Offset: 0x00659F42
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
	}

	// Token: 0x06016F0F RID: 93967 RVA: 0x0065BD66 File Offset: 0x00659F66
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnRoleMeshLoadComplete));
	}

	// Token: 0x06016F10 RID: 93968 RVA: 0x0065BD8A File Offset: 0x00659F8A
	public void OnRoleMeshLoadComplete()
	{
		this.DisableEyeHighLight();
	}

	// Token: 0x06016F11 RID: 93969 RVA: 0x0065BD94 File Offset: 0x00659F94
	public void DisableEyeHighLight()
	{
		FName[] slotNameList = new FName[]
		{
			new FName("MI_Eyes"),
			new FName("MI_Eye")
		};
		FName lightDisableSwitch = new FName("LightDisableSwitch");
		USkeletalMeshComponent mainMeshComponent = this.ActorComponent.MainMeshComponent;
		this.DisableEyeHighLightByMeshComp(mainMeshComponent, slotNameList, lightDisableSwitch);
	}

	// Token: 0x06016F12 RID: 93970 RVA: 0x0065BDEC File Offset: 0x00659FEC
	[NullableContext(1)]
	private void DisableEyeHighLightByMeshComp(USkeletalMeshComponent skeletalMeshComp, FName[] slotNameList, FName lightDisableSwitch)
	{
		foreach (FName materialSlotName in slotNameList)
		{
			int materialIndex = skeletalMeshComp.GetMaterialIndex(materialSlotName);
			if (materialIndex >= 0)
			{
				UMaterialInterface material = skeletalMeshComp.GetMaterial(materialIndex);
				UMaterialInstanceDynamic umaterialInstanceDynamic = skeletalMeshComp.CreateDynamicMaterialInstance(materialIndex, material, default(FName));
				if (umaterialInstanceDynamic != null)
				{
					umaterialInstanceDynamic.SetScalarParameterValue(lightDisableSwitch, 0f);
				}
			}
		}
	}

	// Token: 0x0400B0ED RID: 45293
	[Nullable(2)]
	private UiModelActorComponent ActorComponent;
}
