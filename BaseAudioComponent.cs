using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x0200300A RID: 12298
[NullableContext(1)]
[Nullable(0)]
public class BaseAudioComponent : EntityComponent, IComponentDependency
{
	// Token: 0x170021C6 RID: 8646
	// (get) Token: 0x060190FF RID: 102655 RVA: 0x0071E038 File Offset: 0x0071C238
	public static Type[] Dependencies
	{
		get
		{
			return new Type[]
			{
				typeof(CreatureDataComponent),
				typeof(BaseActorComponent)
			};
		}
	}

	// Token: 0x06019101 RID: 102657 RVA: 0x0071E105 File Offset: 0x0071C305
	protected override bool OnInit()
	{
		this.CreatureData = base.Entity.CheckGetComponent<CreatureDataComponent>();
		this.ActorComp = base.Entity.CheckGetComponent<BaseActorComponent>();
		return true;
	}

	// Token: 0x06019102 RID: 102658 RVA: 0x0071E12A File Offset: 0x0071C32A
	protected override bool OnEnd()
	{
		this.AkComponentMap.Clear();
		return true;
	}

	// Token: 0x06019103 RID: 102659 RVA: 0x0071E138 File Offset: 0x0071C338
	protected override bool OnStart()
	{
		BaseActorComponent actorComp = this.ActorComp;
		return actorComp != null && actorComp.Valid && this.ActorComp.Owner != null;
	}

	// Token: 0x06019104 RID: 102660 RVA: 0x0071E164 File Offset: 0x0071C364
	[NullableContext(2)]
	public UAkComponent GetAkComponent(FName? socketName = null)
	{
		BaseActorComponent actorComp = this.ActorComp;
		object obj;
		if (actorComp == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = actorComp.Owner;
			obj = ((owner != null) ? owner.GetComponentByClass(USkeletalMeshComponent.StaticClass()) : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent = obj as USkeletalMeshComponent;
		if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid())
		{
			return null;
		}
		string key = "None";
		if (socketName != null)
		{
			string text = socketName.ToString();
			key = ((text.Length > 0) ? text : "None");
		}
		UAkComponent uakComponent;
		if (this.AkComponentMap.TryGetValue(key, out uakComponent) && uakComponent != null && uakComponent.IsValid())
		{
			return uakComponent;
		}
		UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(uskeletalMeshComponent, FNameUtil.GetDynamicFName(key), delegate(AActor actor, UAkComponent component)
		{
			this.OnAkComponentCreated();
		});
		if (akComponent != null && akComponent.IsValid())
		{
			CreatureDataComponent creatureData = this.CreatureData;
			EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
			if (eentityType.GetValueOrDefault() == EEntityType.Npc || eentityType.GetValueOrDefault() == EEntityType.Monster || eentityType.GetValueOrDefault() == EEntityType.Vehicle)
			{
				akComponent.bEnableOcclusion = true;
			}
			this.SetEntityTypeVolumeControl();
			this.AkComponentMap[key] = akComponent;
			return akComponent;
		}
		return null;
	}

	// Token: 0x06019105 RID: 102661 RVA: 0x0071E290 File Offset: 0x0071C490
	[NullableContext(2)]
	public UAkComponent GetAkComponent(string socketName)
	{
		BaseActorComponent actorComp = this.ActorComp;
		object obj;
		if (actorComp == null)
		{
			obj = null;
		}
		else
		{
			AActor owner = actorComp.Owner;
			obj = ((owner != null) ? owner.GetComponentByClass(USkeletalMeshComponent.StaticClass()) : null);
		}
		USkeletalMeshComponent uskeletalMeshComponent = obj as USkeletalMeshComponent;
		if (uskeletalMeshComponent == null || !uskeletalMeshComponent.IsValid())
		{
			return null;
		}
		string key = "None";
		if (socketName != null)
		{
			key = ((socketName.Length > 0) ? socketName : "None");
		}
		UAkComponent uakComponent;
		if (this.AkComponentMap.TryGetValue(key, out uakComponent) && uakComponent != null && uakComponent.IsValid())
		{
			return uakComponent;
		}
		UAkComponent akComponent = Singleton<AudioSystem>.Instance.GetAkComponent(uskeletalMeshComponent, FNameUtil.GetDynamicFName(key), delegate(AActor actor, UAkComponent component)
		{
			this.OnAkComponentCreated();
		});
		if (akComponent != null && akComponent.IsValid())
		{
			CreatureDataComponent creatureData = this.CreatureData;
			EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
			if (eentityType.GetValueOrDefault() == EEntityType.Npc || eentityType.GetValueOrDefault() == EEntityType.Monster || eentityType.GetValueOrDefault() == EEntityType.Vehicle)
			{
				akComponent.bEnableOcclusion = true;
			}
			this.SetEntityTypeVolumeControl();
			this.AkComponentMap[key] = akComponent;
			return akComponent;
		}
		return null;
	}

	// Token: 0x06019106 RID: 102662 RVA: 0x0071E3A2 File Offset: 0x0071C5A2
	protected virtual void OnAkComponentCreated()
	{
	}

	// Token: 0x06019107 RID: 102663 RVA: 0x0071E3A4 File Offset: 0x0071C5A4
	private unsafe void SetEntityTypeVolumeControl()
	{
		BaseActorComponent actorComp = this.ActorComp;
		AActor aactor = (actorComp != null) ? actorComp.Owner : null;
		CreatureDataComponent creatureData = this.CreatureData;
		EEntityType? eentityType = (creatureData != null) ? new EEntityType?(creatureData.GetEntityType()) : null;
		if (aactor == null)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Audio, ELogAuthor.YJY, "实体类型设置音量控制: 无法获取角色Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		foreach (ValueTuple<EEntityType, string> valueTuple in BaseAudioComponent.ENTITY_TYPE_VOLUME_CONTROLS)
		{
			EEntityType item = valueTuple.Item1;
			string item2 = valueTuple.Item2;
			EEntityType? eentityType2 = eentityType;
			EEntityType eentityType3 = item;
			int num = ((eentityType2.GetValueOrDefault() == eentityType3 & eentityType2 != null) > false) ? 1 : 0;
			Singleton<AudioSystem>.Instance.SetRtpcValue(item2, (float)num, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = aactor
			}));
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Audio;
		ELogAuthor author = ELogAuthor.YJY;
		string message = "实体类型设置音量控制: SOLO此类型, 静音其他类型";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("actor", aactor);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("entityType", eentityType);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06019108 RID: 102664 RVA: 0x0071E4D4 File Offset: 0x0071C6D4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseAudioComponent baseAudioComponent = (BaseAudioComponent)componentTemplate;
		if (base.CanResetComponentProperty("AkComponentMap") && baseAudioComponent.AkComponentMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, UAkComponent>>(this.AkComponentMap), "AkComponentMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CreatureData"))
		{
			if (baseAudioComponent.CreatureData == null)
			{
				this.CreatureData = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureData), "CreatureData"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (baseAudioComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C44E RID: 50254
	[Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	private static readonly ValueTuple<EEntityType, string>[] ENTITY_TYPE_VOLUME_CONTROLS = new ValueTuple<EEntityType, string>[]
	{
		new ValueTuple<EEntityType, string>(EEntityType.Animal, "entity_type_volume_control_animal"),
		new ValueTuple<EEntityType, string>(EEntityType.Custom, "entity_type_volume_control_custom_other"),
		new ValueTuple<EEntityType, string>(EEntityType.Monster, "entity_type_volume_control_monster"),
		new ValueTuple<EEntityType, string>(EEntityType.Npc, "entity_type_volume_control_npc"),
		new ValueTuple<EEntityType, string>(EEntityType.Player, "entity_type_volume_control_player_role"),
		new ValueTuple<EEntityType, string>(EEntityType.SceneItem, "entity_type_volume_control_scene_item"),
		new ValueTuple<EEntityType, string>(EEntityType.Vision, "entity_type_volume_control_vision"),
		new ValueTuple<EEntityType, string>(EEntityType.Vehicle, "entity_type_volume_control_vehicle")
	};

	// Token: 0x0400C44F RID: 50255
	public readonly Dictionary<string, UAkComponent> AkComponentMap = new Dictionary<string, UAkComponent>();

	// Token: 0x0400C450 RID: 50256
	[Nullable(2)]
	protected CreatureDataComponent CreatureData;

	// Token: 0x0400C451 RID: 50257
	[Nullable(2)]
	protected BaseActorComponent ActorComp;
}
