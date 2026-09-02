using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002C5E RID: 11358
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class UiSceneRoleActorManager : Singleton<UiSceneRoleActorManager>
{
	// Token: 0x06016CC7 RID: 93383 RVA: 0x00652D08 File Offset: 0x00650F08
	public TsUiSceneRoleActor CreateUiSceneRoleActor(EUiModelUseWay useWay)
	{
		this.CreateIndex++;
		TsUiSceneRoleActor tsUiSceneRoleActor = Singleton<ActorSystem>.Instance.Spawn<TsUiSceneRoleActor>(TsUiSceneRoleActor.StaticClass(), new FTransformDouble(), null);
		tsUiSceneRoleActor.Init(this.CreateIndex, useWay);
		this.UiSceneRoleActorMap[this.CreateIndex] = tsUiSceneRoleActor;
		return tsUiSceneRoleActor;
	}

	// Token: 0x06016CC8 RID: 93384 RVA: 0x00652D5C File Offset: 0x00650F5C
	public bool DestroyUiSceneRoleActor(int index)
	{
		TsUiSceneRoleActor tsUiSceneRoleActor;
		if (this.UiSceneRoleActorMap.TryGetValue(index, out tsUiSceneRoleActor))
		{
			tsUiSceneRoleActor.Destroy();
			return this.UiSceneRoleActorMap.Remove(index);
		}
		return true;
	}

	// Token: 0x06016CC9 RID: 93385 RVA: 0x00652D90 File Offset: 0x00650F90
	public void ClearAllUiSceneRoleActor()
	{
		foreach (TsUiSceneRoleActor tsUiSceneRoleActor in this.UiSceneRoleActorMap.Values)
		{
			tsUiSceneRoleActor.Destroy();
		}
		this.UiSceneRoleActorMap.Clear();
	}

	// Token: 0x0400AFA1 RID: 44961
	private int CreateIndex;

	// Token: 0x0400AFA2 RID: 44962
	private readonly Dictionary<int, TsUiSceneRoleActor> UiSceneRoleActorMap = new Dictionary<int, TsUiSceneRoleActor>();
}
