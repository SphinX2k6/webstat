using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002CC0 RID: 11456
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiModelSystem : Singleton<UiModelSystem>
{
	// Token: 0x06016FE9 RID: 94185 RVA: 0x0065FDE0 File Offset: 0x0065DFE0
	public UiModelBase CreateUiModelByUseWay(EUiModelUseWay useWay, AActor actor)
	{
		UiModelCreateData createData = UiModelCreateDataPreDefine.GetUiModelCreateDataPreDefine()[useWay];
		return this.CreateUiModelByCreateData(createData, actor, useWay);
	}

	// Token: 0x06016FEA RID: 94186 RVA: 0x0065FE04 File Offset: 0x0065E004
	public UiModelBase CreateUiModelByCreateData(UiModelCreateData createData, AActor actor, EUiModelUseWay useWay)
	{
		int i = this.UiModelIncrementId;
		this.UiModelIncrementId = i + 1;
		UiModelBase uiModelBase = new UiModelBase(i, useWay);
		foreach (Type componentType in createData.Components)
		{
			uiModelBase.AddComponent(componentType);
		}
		UiModelDataComponent uiModelDataComponent = uiModelBase.CheckGetComponent<UiModelDataComponent>();
		if (uiModelDataComponent != null)
		{
			uiModelDataComponent.ModelType = new EUiModelType?(createData.ModelType);
			uiModelDataComponent.ModelActorType = new EUiModelActorType?(createData.ModelActorType);
			uiModelDataComponent.ModelUseWay = new EUiModelUseWay?(createData.ModelUseWay);
		}
		UiModelActorComponent uiModelActorComponent = uiModelBase.CheckGetComponent<UiModelActorComponent>();
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.Actor = actor;
		}
		return uiModelBase;
	}

	// Token: 0x0400B142 RID: 45378
	private int UiModelIncrementId;
}
