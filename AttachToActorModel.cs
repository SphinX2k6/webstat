using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020034AD RID: 13485
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AttachToActorModel : ModelBase<AttachToActorModel>
{
	// Token: 0x0601C718 RID: 116504 RVA: 0x0088689D File Offset: 0x00884A9D
	protected override bool OnInit()
	{
		this.ShowLog = GlobalData.IsPlayInEditor;
		return true;
	}

	// Token: 0x0601C719 RID: 116505 RVA: 0x008868AC File Offset: 0x00884AAC
	public unsafe bool AddEntityActor(int entityId, AActor actor, AActor parentActor, string reason, EDetachType detachType)
	{
		AttachActorEntry attachActorEntry;
		if (!this.AttachActorMap.TryGetValue(entityId, out attachActorEntry))
		{
			attachActorEntry = new AttachActorEntry();
			this.AttachActorMap[entityId] = attachActorEntry;
		}
		int num = this.AttachId + 1;
		this.AttachId = num;
		int num2 = num;
		if (!attachActorEntry.AddAttachActorItem(num2, entityId, actor, parentActor, reason, detachType))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachActor: 重复AttachActor";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AttachId", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ActorName", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", reason);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			return false;
		}
		if (this.ShowLog)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "AttachActor: 添加Attach数据";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("AttachId", num2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ActorName", actor);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("ParentActorName", parentActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
		}
		this.ActorForEntityMap[actor] = entityId;
		return true;
	}

	// Token: 0x0601C71A RID: 116506 RVA: 0x00886A58 File Offset: 0x00884C58
	public unsafe bool RemoveEntityActor(int entityId, AActor actor, string reason)
	{
		AttachActorEntry attachActorEntry;
		if (!this.AttachActorMap.TryGetValue(entityId, out attachActorEntry))
		{
			return false;
		}
		if (this.ShowLog)
		{
			AttachActorItem attachActorItem = attachActorEntry.GetAttachActorItem(actor);
			if (attachActorItem != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "AttachActor: 删除Attach数据";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AttachId", attachActorItem.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", attachActorItem.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AttachReason", attachActorItem.Reason);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Reason", reason);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
		}
		if (!attachActorEntry.RemoveAttachActorItem(actor))
		{
			return false;
		}
		if (attachActorEntry.Size() == 0)
		{
			this.AttachActorMap.Remove(entityId);
		}
		this.ActorForEntityMap.Remove(actor);
		return true;
	}

	// Token: 0x0601C71B RID: 116507 RVA: 0x00886B94 File Offset: 0x00884D94
	public int GetEntityIdByActor(AActor actor)
	{
		int result;
		if (!this.ActorForEntityMap.TryGetValue(actor, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x0601C71C RID: 116508 RVA: 0x00886BB4 File Offset: 0x00884DB4
	[NullableContext(2)]
	public AttachActorEntry GetAttachActorEntry(int entityId)
	{
		AttachActorEntry result;
		if (!this.AttachActorMap.TryGetValue(entityId, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0601C71D RID: 116509 RVA: 0x00886BD4 File Offset: 0x00884DD4
	[return: Nullable(2)]
	public AttachActorItem GetAttachActorItem(int entityId, AActor actor)
	{
		AttachActorEntry attachActorEntry;
		if (!this.AttachActorMap.TryGetValue(entityId, out attachActorEntry))
		{
			return null;
		}
		return attachActorEntry.GetAttachActorItem(actor);
	}

	// Token: 0x0601C71E RID: 116510 RVA: 0x00886BFC File Offset: 0x00884DFC
	public unsafe void ClearActorsByEntity(int entityId)
	{
		AttachActorEntry attachActorEntry;
		if (!this.AttachActorMap.TryGetValue(entityId, out attachActorEntry))
		{
			return;
		}
		foreach (AttachActorItem attachActorItem in attachActorEntry.GetAttachActorItems())
		{
			AActor actor = attachActorItem.Actor;
			if (actor != null && actor.IsValid())
			{
				this.ActorForEntityMap.Remove(attachActorItem.Actor);
			}
			if (this.ShowLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "AttachActor: 删除Attach数据";
				<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AttachId", attachActorItem.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", attachActorItem.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AttachReason", attachActorItem.Reason);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
			}
		}
		attachActorEntry.Clear();
	}

	// Token: 0x0601C71F RID: 116511 RVA: 0x00886D5C File Offset: 0x00884F5C
	public unsafe void ClearEntityActor(string reason)
	{
		foreach (KeyValuePair<int, AttachActorEntry> keyValuePair in this.AttachActorMap)
		{
			if (this.ShowLog)
			{
				foreach (AttachActorItem attachActorItem in keyValuePair.Value.GetAttachActorItems())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Entity;
					ELogAuthor author = ELogAuthor.LFJW;
					string message = "AttachActor: 删除Attach数据";
					<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AttachId", attachActorItem.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", attachActorItem.EntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("AttachReason", attachActorItem.Reason);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Reason", reason);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
				}
			}
			keyValuePair.Value.Clear();
		}
		this.AttachActorMap.Clear();
		this.ActorForEntityMap.Clear();
	}

	// Token: 0x0601C720 RID: 116512 RVA: 0x00886F10 File Offset: 0x00885110
	protected override bool OnLeaveLevel()
	{
		this.ClearEntityActor("AttachToActorModel.OnLeaveLevel");
		return true;
	}

	// Token: 0x0400E4E4 RID: 58596
	public bool ShowLog = true;

	// Token: 0x0400E4E5 RID: 58597
	private readonly Dictionary<int, AttachActorEntry> AttachActorMap = new Dictionary<int, AttachActorEntry>();

	// Token: 0x0400E4E6 RID: 58598
	private readonly Dictionary<AActor, int> ActorForEntityMap = new Dictionary<AActor, int>();

	// Token: 0x0400E4E7 RID: 58599
	private int AttachId;
}
