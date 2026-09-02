using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003488 RID: 13448
[NullableContext(1)]
[Nullable(0)]
public class AttachActorEntry
{
	// Token: 0x0601C5FF RID: 116223 RVA: 0x00881018 File Offset: 0x0087F218
	public bool AddAttachActorItem(int id, int entityId, AActor actor, AActor parentActor, string reason, EDetachType detachType)
	{
		if (this.ActorKeyMap.ContainsKey(actor))
		{
			return false;
		}
		Dictionary<AActor, int> actorKeyMap = this.ActorKeyMap;
		int num = this.AttachActorId + 1;
		this.AttachActorId = num;
		actorKeyMap[actor] = num;
		AttachActorItem value = new AttachActorItem
		{
			Id = id,
			EntityId = entityId,
			Reason = reason,
			Actor = actor,
			Name = actor.GetName(),
			ParentActorName = parentActor.GetName(),
			DetachType = new EDetachType?(detachType)
		};
		if (GlobalData.IsPlayInEditor)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("AttachId: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(id);
			FName? dynamicFName = FNameUtil.GetDynamicFName(defaultInterpolatedStringHandler.ToStringAndClear());
			if (dynamicFName != null)
			{
				actor.Tags.Add(dynamicFName.Value);
			}
		}
		this.ActorMap.Set(this.AttachActorId, value);
		return true;
	}

	// Token: 0x0601C600 RID: 116224 RVA: 0x008810FC File Offset: 0x0087F2FC
	[return: Nullable(2)]
	public AttachActorItem GetAttachActorItem(AActor actor)
	{
		int key;
		if (!this.ActorKeyMap.TryGetValue(actor, out key))
		{
			return null;
		}
		return this.ActorMap.Get(key);
	}

	// Token: 0x0601C601 RID: 116225 RVA: 0x00881127 File Offset: 0x0087F327
	public IReadOnlyList<AttachActorItem> GetAttachActorItems()
	{
		return this.ActorMap.GetItems();
	}

	// Token: 0x0601C602 RID: 116226 RVA: 0x00881134 File Offset: 0x0087F334
	public int Size()
	{
		return this.ActorKeyMap.Count;
	}

	// Token: 0x0601C603 RID: 116227 RVA: 0x00881144 File Offset: 0x0087F344
	public bool RemoveAttachActorItem(AActor actor)
	{
		int key;
		return this.ActorKeyMap.Remove(actor, out key) && this.ActorMap.Remove(key);
	}

	// Token: 0x0601C604 RID: 116228 RVA: 0x0088116F File Offset: 0x0087F36F
	public void Clear()
	{
		this.AttachActorId = 0;
		this.ActorKeyMap.Clear();
		this.ActorMap.Clear();
	}

	// Token: 0x0400E44B RID: 58443
	private int AttachActorId;

	// Token: 0x0400E44C RID: 58444
	private readonly Dictionary<AActor, int> ActorKeyMap = new Dictionary<AActor, int>();

	// Token: 0x0400E44D RID: 58445
	private readonly CustomMap<int, AttachActorItem> ActorMap = new CustomMap<int, AttachActorItem>();
}
