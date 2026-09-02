using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.CreatureTools;
using UnrealEngine;

// Token: 0x02003469 RID: 13417
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class AttachToActorController : ControllerBase<AttachToActorController>
{
	// Token: 0x0601C3A3 RID: 115619 RVA: 0x0086B07C File Offset: 0x0086927C
	[NullableContext(2)]
	public unsafe bool AttachToActor(AActor actor, AActor parentActor, EDetachType detachType, [Nullable(1)] string reason, FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies, bool doAttach = true, bool ignoreTargetLocationX = false, bool ignoreTargetLocationY = false, bool ignoreTargetLocationZ = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachToActor的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", "AttachToActorController");
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "AttachToActor的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (actor == null || !actor.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "actor无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason", reason);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (parentActor == null || !parentActor.IsValid())
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "parentActor无效";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Reason", reason);
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		IBPI_CreatureInterface_C ibpi_CreatureInterface_C = parentActor as IBPI_CreatureInterface_C;
		if (ibpi_CreatureInterface_C == null)
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Entity;
			ELogAuthor author5 = ELogAuthor.LFJW;
			string message5 = "parentActor未实现接口CreatureInterface";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ActorName", parentActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		int entityId = ibpi_CreatureInterface_C.GetEntityId();
		if (entityId == 0)
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.Entity;
			ELogAuthor author6 = ELogAuthor.LFJW;
			string message6 = "entityId无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ActorName", parentActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return false;
		}
		AttachToActorModel instance7 = ModelBase<AttachToActorModel>.Instance;
		if (!instance7.AddEntityActor(entityId, actor, parentActor, reason, detachType))
		{
			Log instance8 = Singleton<Log>.Instance;
			ELogModule module7 = ELogModule.Entity;
			ELogAuthor author7 = ELogAuthor.LFJW;
			string message7 = "actor添加失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("ActorName", parentActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
			instance8.Error(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			return false;
		}
		if (doAttach && !this.TryAttachToActor(actor, parentActor, socketName, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ))
		{
			this.RemoveEntityActorAfterAttachFailed(instance7, entityId, actor, reason);
			return false;
		}
		actor.OnEndPlay.Add(new Action<AActor, TEnumAsByte<EEndPlayReason>>(this.OnEndPlay));
		return true;
	}

	// Token: 0x0601C3A4 RID: 115620 RVA: 0x0086B310 File Offset: 0x00869510
	[NullableContext(2)]
	public unsafe bool AttachToComponent(AActor actor, USceneComponent parentComponent, EDetachType detachType, [Nullable(1)] string reason, FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies, bool doAttach = true, bool ignoreTargetLocationX = false, bool ignoreTargetLocationY = false, bool ignoreTargetLocationZ = false)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachToComponent的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", typeof(AttachToActorController).Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "AttachToComponent的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (actor == null || !actor.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "actor无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason", reason);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (parentComponent == null || !parentComponent.IsValid())
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "parentComponent无效";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Reason", reason);
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return false;
		}
		AActor owner = parentComponent.GetOwner();
		if (owner == null || !owner.IsValid())
		{
			Log instance5 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Entity;
			ELogAuthor author5 = ELogAuthor.LFJW;
			string message5 = "parentActor无效";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Reason", reason);
			instance5.Error(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			return false;
		}
		IBPI_CreatureInterface_C ibpi_CreatureInterface_C = owner as IBPI_CreatureInterface_C;
		if (ibpi_CreatureInterface_C == null)
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.Entity;
			ELogAuthor author6 = ELogAuthor.LFJW;
			string message6 = "ParentActor未实现接口CreatureInterface";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ActorName", owner.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		int entityId = ibpi_CreatureInterface_C.GetEntityId();
		if (entityId == 0)
		{
			Log instance7 = Singleton<Log>.Instance;
			ELogModule module7 = ELogModule.Entity;
			ELogAuthor author7 = ELogAuthor.LFJW;
			string message7 = "entityId无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ActorName", owner.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
			instance7.Error(module7, author7, message7, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
			return false;
		}
		AttachToActorModel instance8 = ModelBase<AttachToActorModel>.Instance;
		if (!instance8.AddEntityActor(entityId, actor, owner, reason, detachType))
		{
			Log instance9 = Singleton<Log>.Instance;
			ELogModule module8 = ELogModule.Entity;
			ELogAuthor author8 = ELogAuthor.LFJW;
			string message8 = "actor添加失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("ActorName", owner.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
			instance9.Error(module8, author8, message8, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
			return false;
		}
		if (doAttach && !this.TryAttachToComponent(actor, parentComponent, socketName, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ))
		{
			this.RemoveEntityActorAfterAttachFailed(instance8, entityId, actor, reason);
			return false;
		}
		actor.OnEndPlay.Add(new Action<AActor, TEnumAsByte<EEndPlayReason>>(this.OnEndPlay));
		return true;
	}

	// Token: 0x0601C3A5 RID: 115621 RVA: 0x0086B5F0 File Offset: 0x008697F0
	[NullableContext(0)]
	private unsafe void OnEndPlay([Nullable(2)] AActor actor, TEnumAsByte<EEndPlayReason> reason)
	{
		if (actor == null)
		{
			return;
		}
		EEndPlayReason eendPlayReason = reason;
		if (eendPlayReason == EEndPlayReason.EndPlayInEditor || eendPlayReason == EEndPlayReason.Quit)
		{
			return;
		}
		AttachToActorModel instance = ModelBase<AttachToActorModel>.Instance;
		if (instance == null)
		{
			return;
		}
		int entityIdByActor = instance.GetEntityIdByActor(actor);
		AttachActorItem attachActorItem = instance.GetAttachActorItem(entityIdByActor, actor);
		if (attachActorItem == null)
		{
			return;
		}
		EDetachType? detachType = attachActorItem.DetachType;
		if (detachType != null)
		{
			EDetachType valueOrDefault = detachType.GetValueOrDefault();
			if (valueOrDefault > EDetachType.EntityDestroy)
			{
				if (valueOrDefault == EDetachType.DestroyExternal)
				{
					this.DetachActorByEntity(actor, "AttachToActorController.OnEndPlay DestroyExternal", entityIdByActor, false, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
					return;
				}
			}
			else
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "非法删除Attach的Actor";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityIdByActor);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("DetachType", attachActorItem.DetachType);
				instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				this.DetachActorByEntity(actor, "AttachToActorController.OnEndPlay ManualDestroy", entityIdByActor, false, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			}
		}
	}

	// Token: 0x0601C3A6 RID: 115622 RVA: 0x0086B720 File Offset: 0x00869920
	public unsafe bool DetachActor([Nullable(2)] AActor srcActor, bool destroy, string reason, EDetachmentRule locationRule, EDetachmentRule rotationRule, EDetachmentRule scaleRule)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachActor: RemoveActor的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", typeof(AttachToActorController).Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "AttachActor: RemoveActor的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (srcActor == null || !srcActor.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "srcActor无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason", reason);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		AActor attachParentActor = srcActor.GetAttachParentActor();
		if (attachParentActor == null || !attachParentActor.IsValid())
		{
			int entityIdByActor = ModelBase<AttachToActorModel>.Instance.GetEntityIdByActor(srcActor);
			if (entityIdByActor != 0)
			{
				return this.DetachActorByEntity(srcActor, reason, entityIdByActor, destroy, locationRule, rotationRule, scaleRule);
			}
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "AttachActor: entityActor无效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Name", srcActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Reason", reason);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return false;
		}
		else
		{
			IBPI_CreatureInterface_C ibpi_CreatureInterface_C = attachParentActor as IBPI_CreatureInterface_C;
			if (ibpi_CreatureInterface_C == null)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Entity;
				ELogAuthor author5 = ELogAuthor.LFJW;
				string message5 = "AttachActor: Actor未实现接口CreatureInterface";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("ActorName", attachParentActor.GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("Reason", reason);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				return false;
			}
			int entityId = ibpi_CreatureInterface_C.GetEntityId();
			if (entityId == 0)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Entity;
				ELogAuthor author6 = ELogAuthor.LFJW;
				string message6 = "AttachActor: entityId无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("ActorName", attachParentActor.GetName());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("Reason", reason);
				instance6.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
				return false;
			}
			return this.DetachActorByEntity(srcActor, reason, entityId, destroy, locationRule, rotationRule, scaleRule);
		}
	}

	// Token: 0x0601C3A7 RID: 115623 RVA: 0x0086B970 File Offset: 0x00869B70
	public unsafe bool DetachActorByEntity([Nullable(2)] AActor srcActor, string reason, int entityId, bool destroy, EDetachmentRule locationRule, EDetachmentRule rotationRule, EDetachmentRule scaleRule)
	{
		if (string.IsNullOrEmpty(reason))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachActor: RemoveActor的Reason不能使用undefined";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", typeof(AttachToActorController).Name);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		if (reason.Length < 4)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Entity;
			ELogAuthor author2 = ELogAuthor.LFJW;
			string message2 = "AttachActor: RemoveActor的Reason字符串长度必须大于等于限制字符数量";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Reason", reason);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("限制的字符数量", 4);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return false;
		}
		if (srcActor == null || !srcActor.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Entity;
			ELogAuthor author3 = ELogAuthor.LFJW;
			string message3 = "srcActor无效";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason", reason);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		if (entityId == 0)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.Entity;
			ELogAuthor author4 = ELogAuthor.LFJW;
			string message4 = "AttachActor: entityId无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ActorName", srcActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Reason", reason);
			instance4.Error(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
			return false;
		}
		AttachToActorModel instance5 = ModelBase<AttachToActorModel>.Instance;
		if (instance5.GetAttachActorItem(entityId, srcActor) == null)
		{
			Log instance6 = Singleton<Log>.Instance;
			ELogModule module5 = ELogModule.Entity;
			ELogAuthor author5 = ELogAuthor.LFJW;
			string message5 = "AttachActor: attachActorItem无效";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("ActorName", srcActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("Reason", reason);
			instance6.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
			return false;
		}
		srcActor.OnEndPlay.Remove(new Action<AActor, TEnumAsByte<EEndPlayReason>>(this.OnEndPlay));
		if (!instance5.RemoveEntityActor(entityId, srcActor, reason))
		{
			Log instance7 = Singleton<Log>.Instance;
			ELogModule module6 = ELogModule.Entity;
			ELogAuthor author6 = ELogAuthor.LFJW;
			string message6 = "AttachActor: Detach Actor 失败";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("ActorName", srcActor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 2) = new ValueTuple<string, object>("Reason", reason);
			instance7.Error(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 3));
			return false;
		}
		if (destroy)
		{
			this.ClearLocationAxisFilteredAttach(srcActor);
			srcActor.K2_DestroyActor();
			return true;
		}
		this.ClearLocationAxisFilteredAttach(srcActor);
		srcActor.K2_DetachFromActor(locationRule, rotationRule, scaleRule);
		return true;
	}

	// Token: 0x0601C3A8 RID: 115624 RVA: 0x0086BC14 File Offset: 0x00869E14
	public bool DetachActorsBeforeDestroyEntity(EntityHandle handle)
	{
		if (handle == null || !handle.Valid)
		{
			return true;
		}
		AttachActorEntry attachActorEntry = ModelBase<AttachToActorModel>.Instance.GetAttachActorEntry(handle.Id);
		if (attachActorEntry == null)
		{
			return true;
		}
		IReadOnlyList<AttachActorItem> attachActorItems = attachActorEntry.GetAttachActorItems();
		if (attachActorItems == null || attachActorItems.Count == 0)
		{
			return true;
		}
		bool result = true;
		for (int i = attachActorItems.Count - 1; i >= 0; i--)
		{
			AttachActorItem attachActorItem = attachActorItems[i];
			if (attachActorItem.DetachType.GetValueOrDefault() == EDetachType.EntityDestroy)
			{
				AActor actor = attachActorItem.Actor;
				if (actor != null && actor.IsValid() && !this.DetachActorByEntity(attachActorItem.Actor, "AttachToActorController.DetachActorsBeforeDestroyEntity", handle.Id, true, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld))
				{
					result = false;
				}
			}
		}
		return result;
	}

	// Token: 0x0601C3A9 RID: 115625 RVA: 0x0086BCC4 File Offset: 0x00869EC4
	public unsafe bool DetachActorsAfterDestroyEntity(int entityId)
	{
		AttachActorEntry attachActorEntry = ModelBase<AttachToActorModel>.Instance.GetAttachActorEntry(entityId);
		if (attachActorEntry == null)
		{
			return true;
		}
		IReadOnlyList<AttachActorItem> attachActorItems = attachActorEntry.GetAttachActorItems();
		if (attachActorItems == null || attachActorItems.Count == 0)
		{
			return true;
		}
		bool result = true;
		for (int i = attachActorItems.Count - 1; i >= 0; i--)
		{
			AttachActorItem attachActorItem = attachActorItems[i];
			EDetachType? detachType = attachActorItem.DetachType;
			EDetachType edetachType = EDetachType.ManualDestroy;
			if (detachType.GetValueOrDefault() == edetachType & detachType != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Entity;
				ELogAuthor author = ELogAuthor.LFJW;
				string message = "AttachActor: 存在未类型为ManualDestroy未Detach的Actor";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", attachActorItem.Reason);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				AActor actor = attachActorItem.Actor;
				if (actor != null && actor.IsValid() && !this.DetachActorByEntity(attachActorItem.Actor, "AttachToActorController.DetachActorsAfterDestroyEntity", entityId, true, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld))
				{
					result = false;
				}
			}
		}
		return result;
	}

	// Token: 0x0601C3AA RID: 115626 RVA: 0x0086BE10 File Offset: 0x0086A010
	public unsafe bool CheckAttachError(int entityId)
	{
		AttachToActorModel instance = ModelBase<AttachToActorModel>.Instance;
		AttachActorEntry attachActorEntry = instance.GetAttachActorEntry(entityId);
		if (attachActorEntry == null)
		{
			return true;
		}
		IReadOnlyList<AttachActorItem> attachActorItems = attachActorEntry.GetAttachActorItems();
		if (attachActorItems == null || attachActorItems.Count == 0)
		{
			return true;
		}
		int count = attachActorItems.Count;
		bool result = true;
		for (int i = count - 1; i >= 0; i--)
		{
			AttachActorItem attachActorItem = attachActorItems[i];
			result = false;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Entity;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "AttachActor: Attach的Actor没有删除";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorName", attachActorItem.Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ParentActorName", attachActorItem.ParentActorName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Reason", attachActorItem.Reason);
			instance2.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
			AActor actor = attachActorItem.Actor;
			if (actor != null && actor.IsValid())
			{
				this.DetachActorByEntity(attachActorItem.Actor, "AttachToActorController.CheckAttachError", attachActorItem.EntityId, true, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld, EDetachmentRule.KeepWorld);
			}
		}
		instance.ClearActorsByEntity(entityId);
		return result;
	}

	// Token: 0x0601C3AB RID: 115627 RVA: 0x0086BF48 File Offset: 0x0086A148
	private bool TryAttachToActor(AActor actor, AActor parentActor, FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies, bool ignoreTargetLocationX, bool ignoreTargetLocationY, bool ignoreTargetLocationZ)
	{
		if (this.HasLocationAxisFilter(ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ))
		{
			FName fname = socketName ?? FName.NAME_None;
			return UKuroAttachLibrary.KuroAttachToActorWithLocationAxisFilter(actor, parentActor, fname, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ);
		}
		this.ClearLocationAxisFilteredAttach(actor);
		actor.K2_AttachToActor(parentActor, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, true);
		return true;
	}

	// Token: 0x0601C3AC RID: 115628 RVA: 0x0086BFC8 File Offset: 0x0086A1C8
	private bool TryAttachToComponent(AActor actor, USceneComponent parentComponent, FName? socketName, EAttachmentRule locationRule, EAttachmentRule rotationRule, EAttachmentRule scaleRule, bool bWeldSimulatedBodies, bool ignoreTargetLocationX, bool ignoreTargetLocationY, bool ignoreTargetLocationZ)
	{
		if (this.HasLocationAxisFilter(ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ))
		{
			FName fname = socketName ?? FName.NAME_None;
			return UKuroAttachLibrary.KuroAttachToComponentWithLocationAxisFilter(actor, parentComponent, fname, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, ignoreTargetLocationX, ignoreTargetLocationY, ignoreTargetLocationZ);
		}
		this.ClearLocationAxisFilteredAttach(actor);
		actor.K2_AttachToComponent(parentComponent, socketName ?? FName.NAME_None, locationRule, rotationRule, scaleRule, bWeldSimulatedBodies, true);
		return true;
	}

	// Token: 0x0601C3AD RID: 115629 RVA: 0x0086C046 File Offset: 0x0086A246
	private bool HasLocationAxisFilter(bool ignoreTargetLocationX, bool ignoreTargetLocationY, bool ignoreTargetLocationZ)
	{
		return ignoreTargetLocationX || ignoreTargetLocationY || ignoreTargetLocationZ;
	}

	// Token: 0x0601C3AE RID: 115630 RVA: 0x0086C04D File Offset: 0x0086A24D
	private void RemoveEntityActorAfterAttachFailed(AttachToActorModel attachToActorModel, int entityId, AActor actor, string reason)
	{
		this.ClearLocationAxisFilteredAttach(actor);
		attachToActorModel.RemoveEntityActor(entityId, actor, reason + " AttachFailed");
	}

	// Token: 0x0601C3AF RID: 115631 RVA: 0x0086C06B File Offset: 0x0086A26B
	private void ClearLocationAxisFilteredAttach(AActor actor)
	{
		UKuroAttachLibrary.ClearKuroLocationAxisFilteredAttach(actor);
	}

	// Token: 0x0400E34F RID: 58191
	private const int ATTACH_REASON_LENGTH_LIMIT = 4;
}
