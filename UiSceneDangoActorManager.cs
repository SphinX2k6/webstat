using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C5C RID: 11356
public class UiSceneDangoActorManager : IStaticVariableResetter
{
	// Token: 0x06016C57 RID: 93271 RVA: 0x00650F35 File Offset: 0x0064F135
	static UiSceneDangoActorManager()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UiSceneDangoActorManager.CreateStaticDefaultValue), new Action(UiSceneDangoActorManager.ResetStaticDefaultValue));
	}

	// Token: 0x06016C58 RID: 93272 RVA: 0x00650F54 File Offset: 0x0064F154
	public static void CreateStaticDefaultValue()
	{
		UiSceneDangoActorManager.CreateIndex = 0;
		UiSceneDangoActorManager.UiSceneDangoActorMap = new Dictionary<int, TsUiSceneDangoActor>();
	}

	// Token: 0x06016C59 RID: 93273 RVA: 0x00650F66 File Offset: 0x0064F166
	public static void ResetStaticDefaultValue()
	{
		UiSceneDangoActorManager.CreateIndex = 0;
		UiSceneDangoActorManager.UiSceneDangoActorMap = null;
	}

	// Token: 0x06016C5A RID: 93274 RVA: 0x00650F74 File Offset: 0x0064F174
	[NullableContext(1)]
	public static TsUiSceneDangoActor CreateUiSceneDangoActor(EUiModelUseWay useWay)
	{
		UiSceneDangoActorManager.CreateIndex++;
		TsUiSceneDangoActor tsUiSceneDangoActor = Singleton<ActorSystem>.Instance.Get<TsUiSceneDangoActor>(TsUiSceneDangoActor.StaticClass(), new FTransformDouble(), null, true);
		tsUiSceneDangoActor.Init(UiSceneDangoActorManager.CreateIndex, (int)useWay);
		UiSceneDangoActorManager.UiSceneDangoActorMap.Add(UiSceneDangoActorManager.CreateIndex, tsUiSceneDangoActor);
		return tsUiSceneDangoActor;
	}

	// Token: 0x06016C5B RID: 93275 RVA: 0x00650FC4 File Offset: 0x0064F1C4
	public static bool DestroyUiSceneDangoActor(int index)
	{
		TsUiSceneDangoActor tsUiSceneDangoActor;
		if (UiSceneDangoActorManager.UiSceneDangoActorMap.TryGetValue(index, out tsUiSceneDangoActor))
		{
			tsUiSceneDangoActor.Destroy();
			return UiSceneDangoActorManager.UiSceneDangoActorMap.Remove(index);
		}
		return true;
	}

	// Token: 0x06016C5C RID: 93276 RVA: 0x00650FF4 File Offset: 0x0064F1F4
	public static void SetAllActorVisible(bool visible)
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in UiSceneDangoActorManager.UiSceneDangoActorMap.Values)
		{
			UiModelDataComponent uiModelDataComponent = tsUiSceneDangoActor.Model.CheckGetComponent<UiModelDataComponent>();
			if (uiModelDataComponent != null)
			{
				uiModelDataComponent.SetVisible(visible);
			}
		}
	}

	// Token: 0x06016C5D RID: 93277 RVA: 0x0065105C File Offset: 0x0064F25C
	public static void ClearAllUiSceneDangoActor()
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in UiSceneDangoActorManager.UiSceneDangoActorMap.Values)
		{
			tsUiSceneDangoActor.Destroy();
		}
		UiSceneDangoActorManager.UiSceneDangoActorMap.Clear();
	}

	// Token: 0x0400AF80 RID: 44928
	private static int CreateIndex;

	// Token: 0x0400AF81 RID: 44929
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, TsUiSceneDangoActor> UiSceneDangoActorMap;
}
