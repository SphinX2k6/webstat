using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002C98 RID: 11416
[NullableContext(1)]
[Nullable(0)]
public class UiDangoMaterialChangeComponent : UiModelComponentBase
{
	// Token: 0x06016E8D RID: 93837 RVA: 0x0065A226 File Offset: 0x00658426
	protected override void OnInit()
	{
		this.UiModelActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialInstance>("/Game/Aki/Character/NPC/Tuanzi/HYtuanzi_jinxi/Model/MI_Tuanzi_Stroke_90001.MI_Tuanzi_Stroke_90001", delegate([Nullable(2)] UMaterialInstance materialInstance, string _)
		{
			if (materialInstance != null && materialInstance.IsValid())
			{
				this.ReplaceMaterial = materialInstance;
			}
		}, 100, "Ui.UiSceneModel");
	}

	// Token: 0x06016E8E RID: 93838 RVA: 0x0065A25C File Offset: 0x0065845C
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E8F RID: 93839 RVA: 0x0065A280 File Offset: 0x00658480
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016E90 RID: 93840 RVA: 0x0065A2A4 File Offset: 0x006584A4
	private void OnModelLoadComplete()
	{
		this.InitOriginalMaterialMap();
	}

	// Token: 0x06016E91 RID: 93841 RVA: 0x0065A2AC File Offset: 0x006584AC
	private void InitOriginalMaterialMap()
	{
		this.OriginalMaterialMap.Clear();
		USkeletalMeshComponent mainMeshComponent = this.UiModelActorComponent.MainMeshComponent;
		foreach (FName materialSlotName in this.SlotNameList)
		{
			int materialIndex = mainMeshComponent.GetMaterialIndex(materialSlotName);
			if (materialIndex >= 0)
			{
				UMaterialInterface material = mainMeshComponent.GetMaterial(materialIndex);
				if (material != null)
				{
					this.OriginalMaterialMap[materialIndex] = material;
				}
			}
		}
	}

	// Token: 0x06016E92 RID: 93842 RVA: 0x0065A318 File Offset: 0x00658518
	public void ReplaceSelectMaterial(bool isReplace)
	{
		CharRenderingComponent charRenderingComponent = this.UiModelActorComponent.CharRenderingComponent;
		if (isReplace)
		{
			charRenderingComponent.SetMaterialReplaceV2(this.ReplaceMaterial, EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.Outline, EKuroCharMeshPart.ECharacterMeshPart_Max);
			return;
		}
		charRenderingComponent.RemoveExternalMaterialReplaceV2(EKuroCharBodySpecifiedType.All, EKuroCharSlotSpecifiedType.Outline, EKuroCharMeshPart.ECharacterMeshPart_Max);
	}

	// Token: 0x0400B0AF RID: 45231
	private const string SELECT_MATERIAL_PATH = "/Game/Aki/Character/NPC/Tuanzi/HYtuanzi_jinxi/Model/MI_Tuanzi_Stroke_90001.MI_Tuanzi_Stroke_90001";

	// Token: 0x0400B0B0 RID: 45232
	protected UiModelActorComponent UiModelActorComponent;

	// Token: 0x0400B0B1 RID: 45233
	private UMaterialInstance ReplaceMaterial;

	// Token: 0x0400B0B2 RID: 45234
	private readonly Dictionary<int, UMaterialInterface> OriginalMaterialMap = new Dictionary<int, UMaterialInterface>();

	// Token: 0x0400B0B3 RID: 45235
	private readonly FName[] SlotNameList = new FName[]
	{
		new FName("OL_Hair"),
		new FName("OL_Face"),
		new FName("OL_Item")
	};
}
