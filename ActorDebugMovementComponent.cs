using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x0200316C RID: 12652
[NullableContext(1)]
[Nullable(0)]
public class ActorDebugMovementComponent : EntityComponent
{
	// Token: 0x0601A39B RID: 107419 RVA: 0x007B4A6C File Offset: 0x007B2C6C
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<BaseActorComponent>();
		this.IsDebug = false;
		if (this.ActorComp != null)
		{
			this.InspectionType = this.InspectionTypeList.Contains(this.ActorComp.CreatureData.GetEntityType());
			this.LastRecordLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		return true;
	}

	// Token: 0x0601A39C RID: 107420 RVA: 0x007B4AD4 File Offset: 0x007B2CD4
	public void SetDebug(bool newDebug)
	{
		if (this.IsDebug == newDebug)
		{
			return;
		}
		this.IsDebug = newDebug;
		if (this.IsDebug)
		{
			BaseActorComponent actorComp = this.ActorComp;
			if (((actorComp != null) ? actorComp.Owner : null) != null)
			{
				this.UeDebugComp = (this.ActorComp.Owner.AddComponentByClass(UKuroDebugMovementComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UKuroDebugMovementComponent);
			}
			this.UeDebugComp.Resigter();
		}
	}

	// Token: 0x0601A39D RID: 107421 RVA: 0x007B4B54 File Offset: 0x007B2D54
	public unsafe void MarkDebugRecord(string context, EKDMRecordType? type = 15, bool noInspection = false)
	{
		if (this.InspectionType && this.ActorComp != null)
		{
			if (!noInspection && global::Vector.DistSquared(this.LastRecordLocation, this.ActorComp.ActorLocationProxy) > 25000000.0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.LCZ;
				string message = "MarkDebugRecord 移动距离超五十米";
				<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray6<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PbDataId", this.ActorComp.CreatureData.GetPbDataId());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityId", this.ActorComp.Entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Context", context);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("From", this.LastRecordLocation);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("To", this.ActorComp.ActorLocationProxy);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("Actor", this.ActorComp.Owner);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 6));
			}
			this.LastRecordLocation.DeepCopy(this.ActorComp.ActorLocationProxy);
		}
		if (this.IsDebug)
		{
			string[] array = new string[5];
			array[0] = "[PbDataId:";
			int num = 1;
			BaseActorComponent actorComp = this.ActorComp;
			array[num] = ((actorComp != null) ? actorComp.CreatureData.GetPbDataId().ToString() : null);
			array[2] = "][CreatureDataId:";
			int num2 = 3;
			BaseActorComponent actorComp2 = this.ActorComp;
			array[num2] = ((actorComp2 != null) ? actorComp2.CreatureData.GetCreatureDataId().ToString() : null);
			array[4] = "]";
			string str = string.Concat(array);
			this.UeDebugComp.RecordModifyInfo(context + str, default(FVector), type.GetValueOrDefault(EKDMRecordType.KDM_ALL));
		}
	}

	// Token: 0x0601A39E RID: 107422 RVA: 0x007B4D42 File Offset: 0x007B2F42
	public static void StaticMarkDebugRecord(Entity entity, string context, EKDMRecordType type = EKDMRecordType.KDM_ALL, global::Vector customVector = null)
	{
		entity.GetComponent<ActorDebugMovementComponent>().MarkDebugRecord(context, new EKDMRecordType?(type), false);
	}

	// Token: 0x0601A39F RID: 107423 RVA: 0x007B4D58 File Offset: 0x007B2F58
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		ActorDebugMovementComponent actorDebugMovementComponent = (ActorDebugMovementComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (actorDebugMovementComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UeDebugComp"))
		{
			if (actorDebugMovementComponent.UeDebugComp == null)
			{
				this.UeDebugComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UKuroDebugMovementComponent>(this.UeDebugComp), "UeDebugComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsDebug"))
		{
			this.IsDebug = actorDebugMovementComponent.IsDebug;
		}
		if (base.CanResetComponentProperty("LastRecordLocation"))
		{
			if (actorDebugMovementComponent.LastRecordLocation == null)
			{
				this.LastRecordLocation = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastRecordLocation), "LastRecordLocation"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InspectionType"))
		{
			this.InspectionType = actorDebugMovementComponent.InspectionType;
		}
		return !base.CanResetComponentProperty("InspectionTypeList") || actorDebugMovementComponent.InspectionTypeList == null || base.CheckClearObject(EntityComponentSystem.ClearObject<List<EEntityType>>(this.InspectionTypeList), "InspectionTypeList");
	}

	// Token: 0x0400D300 RID: 54016
	private const float WARNING_THRESHOLD_SQUARED = 25000000f;

	// Token: 0x0400D301 RID: 54017
	[Nullable(2)]
	public BaseActorComponent ActorComp;

	// Token: 0x0400D302 RID: 54018
	[Nullable(2)]
	public UKuroDebugMovementComponent UeDebugComp;

	// Token: 0x0400D303 RID: 54019
	public bool IsDebug;

	// Token: 0x0400D304 RID: 54020
	public global::Vector LastRecordLocation = global::Vector.Create();

	// Token: 0x0400D305 RID: 54021
	private bool InspectionType;

	// Token: 0x0400D306 RID: 54022
	private readonly List<EEntityType> InspectionTypeList = new List<EEntityType>
	{
		EEntityType.Monster,
		EEntityType.Player,
		EEntityType.Npc,
		EEntityType.Vehicle
	};
}
