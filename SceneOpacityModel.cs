using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020034BC RID: 13500
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SceneOpacityModel : ModelBase<SceneOpacityModel>
{
	// Token: 0x0601C89D RID: 116893 RVA: 0x0088EE66 File Offset: 0x0088D066
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601C89E RID: 116894 RVA: 0x0088EE69 File Offset: 0x0088D069
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0601C89F RID: 116895 RVA: 0x0088EE6C File Offset: 0x0088D06C
	protected override bool OnLeaveLevel()
	{
		this.OpacityComponentMap.Clear();
		this.CurrentOpacityMap.Clear();
		return true;
	}

	// Token: 0x0601C8A0 RID: 116896 RVA: 0x0088EE88 File Offset: 0x0088D088
	public void AddOpacityEntity(UStaticMeshComponent component, int entityId)
	{
		HashSet<int> hashSet;
		if (!this.OpacityComponentMap.TryGetValue(component, out hashSet))
		{
			hashSet = new HashSet<int>();
			this.OpacityComponentMap[component] = hashSet;
		}
		hashSet.Add(entityId);
		if (!this.CurrentOpacityMap.ContainsKey(component))
		{
			this.CurrentOpacityMap[component] = 1f;
		}
	}

	// Token: 0x0601C8A1 RID: 116897 RVA: 0x0088EEE0 File Offset: 0x0088D0E0
	public void RemoveOpacityEntity(UStaticMeshComponent component, int entityId)
	{
		HashSet<int> hashSet;
		if (!this.OpacityComponentMap.TryGetValue(component, out hashSet))
		{
			return;
		}
		hashSet.Remove(entityId);
		if (hashSet.Count == 0)
		{
			this.OpacityComponentMap.Remove(component);
		}
	}

	// Token: 0x0601C8A2 RID: 116898 RVA: 0x0088EF1C File Offset: 0x0088D11C
	public bool IsAffected(UStaticMeshComponent component)
	{
		HashSet<int> hashSet;
		return this.OpacityComponentMap.TryGetValue(component, out hashSet) && hashSet.Count > 0;
	}

	// Token: 0x0400E5C6 RID: 58822
	public const float MIN_OPACITY = 0.2f;

	// Token: 0x0400E5C7 RID: 58823
	public const float OPACITY_SPEED = 0.001f;

	// Token: 0x0400E5C8 RID: 58824
	public const float MAX_OPACITY = 1f;

	// Token: 0x0400E5C9 RID: 58825
	public readonly Dictionary<UStaticMeshComponent, HashSet<int>> OpacityComponentMap = new Dictionary<UStaticMeshComponent, HashSet<int>>();

	// Token: 0x0400E5CA RID: 58826
	public readonly Dictionary<UStaticMeshComponent, float> CurrentOpacityMap = new Dictionary<UStaticMeshComponent, float>();
}
