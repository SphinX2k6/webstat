using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020027A8 RID: 10152
[NullableContext(1)]
[Nullable(0)]
public class UiSceneActorEffectsManagementComponent
{
	// Token: 0x060140BD RID: 82109 RVA: 0x0059888C File Offset: 0x00596A8C
	public int PlayEffect(string effectId, USceneComponent parent, FTransformDouble? transform = null, FName? socketName = null, [Nullable(2)] Action<ELoadEffectResult, int> callback = null)
	{
		string effectPath = EffectUtil.GetEffectPath(effectId);
		return this.PlayEffectByPath(effectPath, parent, transform, socketName, callback);
	}

	// Token: 0x060140BE RID: 82110 RVA: 0x005988B0 File Offset: 0x00596AB0
	public int PlayEffectByPath(string effectPath, USceneComponent parent, FTransformDouble? transform = null, FName? socketName = null, [Nullable(2)] Action<ELoadEffectResult, int> callback = null)
	{
		EffectSystem instance = Singleton<EffectSystem>.Instance;
		UObject world = GlobalData.World;
		FTransformDouble? ftransformDouble = transform;
		ftransformDouble = new FTransformDouble?(ftransformDouble ?? this.CacheTransform);
		int num = instance.SpawnEffect(world, ftransformDouble, effectPath, "[RoleAnimStateEffectManager.PlayEffect]", new EffectContext(null, parent, false), EEffectType.UiScene3D, null, callback, null, false, false);
		if (Singleton<EffectSystem>.Instance.IsValid(num))
		{
			this.EffectCacheList.Add(num);
		}
		FName? fname = socketName;
		if (fname == null || fname.Value.IsNone())
		{
			fname = new FName?(this.DefaultSocketName);
		}
		if (Singleton<EffectSystem>.Instance.IsValid(num))
		{
			Singleton<EffectSystem>.Instance.GetEffectActor(num).K2_AttachToComponent(parent, new FName?(fname.Value), EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
		}
		return num;
	}

	// Token: 0x060140BF RID: 82111 RVA: 0x00598980 File Offset: 0x00596B80
	public void PlayEffectList(TArray<TSoftObjectPtr<UObject>> effects, USceneComponent parent, FTransformDouble? transform = null, FName? socketName = null)
	{
		if (effects == null)
		{
			return;
		}
		for (int i = 0; i < effects.Num(); i++)
		{
			TSoftObjectPtr<UObject> tsoftObjectPtr = effects.Get(i);
			this.PlayEffectByPath(tsoftObjectPtr.ToAssetPathName(), parent, transform, socketName, null);
		}
	}

	// Token: 0x060140C0 RID: 82112 RVA: 0x005989BC File Offset: 0x00596BBC
	public void AttachEffect(int effectHandle)
	{
		this.EffectCacheList.Add(effectHandle);
	}

	// Token: 0x060140C1 RID: 82113 RVA: 0x005989CC File Offset: 0x00596BCC
	public void DestroyEffect()
	{
		if (this.EffectCacheList == null || this.EffectCacheList.Count == 0)
		{
			return;
		}
		foreach (int handle in this.EffectCacheList)
		{
			Singleton<EffectSystem>.Instance.StopEffectById(handle, "[RoleAnimStateEffectManager.RecycleEffect]", true, null);
		}
		this.EffectCacheList.Clear();
	}

	// Token: 0x060140C2 RID: 82114 RVA: 0x00598A54 File Offset: 0x00596C54
	public void StopEffect(int effectHandle)
	{
		Singleton<EffectSystem>.Instance.StopEffectById(effectHandle, "[RoleAnimStateEffectManager.StopEffect]", true, null);
	}

	// Token: 0x060140C3 RID: 82115 RVA: 0x00598A7C File Offset: 0x00596C7C
	public UiSceneActorEffectsManagementComponent()
	{
		FRotator frotator = new FRotator(0f, 0f, 0f);
		FVectorDouble fvectorDouble = new FVectorDouble(0.0, 0.0, 0.0);
		FVectorDouble fvectorDouble2 = new FVectorDouble(1.0, 1.0, 1.0);
		FVector fvector = fvectorDouble2;
		this.CacheTransform = new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		this.DefaultSocketName = Singleton<CharacterNameDefines>.Instance.ROOT;
		base..ctor();
	}

	// Token: 0x04009C35 RID: 39989
	private readonly List<int> EffectCacheList = new List<int>();

	// Token: 0x04009C36 RID: 39990
	private readonly FTransformDouble CacheTransform;

	// Token: 0x04009C37 RID: 39991
	private readonly FName DefaultSocketName;
}
