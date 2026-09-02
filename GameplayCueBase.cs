using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002F9D RID: 12189
[NullableContext(1)]
[Nullable(0)]
public abstract class GameplayCueBase
{
	// Token: 0x1700218D RID: 8589
	// (get) Token: 0x06018DA0 RID: 101792 RVA: 0x00709857 File Offset: 0x00707A57
	// (set) Token: 0x06018DA1 RID: 101793 RVA: 0x0070985F File Offset: 0x00707A5F
	public GameplayCueParam InitCueParam { get; set; }

	// Token: 0x1700218E RID: 8590
	// (get) Token: 0x06018DA2 RID: 101794 RVA: 0x00709868 File Offset: 0x00707A68
	public int Handle
	{
		get
		{
			return this.HandleInternal;
		}
	}

	// Token: 0x06018DA3 RID: 101795 RVA: 0x00709870 File Offset: 0x00707A70
	protected virtual void OnInit()
	{
	}

	// Token: 0x06018DA4 RID: 101796 RVA: 0x00709872 File Offset: 0x00707A72
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x06018DA5 RID: 101797 RVA: 0x00709874 File Offset: 0x00707A74
	protected virtual void OnAfterTick(float delta)
	{
	}

	// Token: 0x06018DA6 RID: 101798 RVA: 0x00709876 File Offset: 0x00707A76
	protected virtual void OnCreate()
	{
	}

	// Token: 0x06018DA7 RID: 101799 RVA: 0x00709878 File Offset: 0x00707A78
	protected virtual void OnDestroy()
	{
	}

	// Token: 0x06018DA8 RID: 101800 RVA: 0x0070987A File Offset: 0x00707A7A
	public virtual void OnEnable()
	{
	}

	// Token: 0x06018DA9 RID: 101801 RVA: 0x0070987C File Offset: 0x00707A7C
	public virtual void OnGameplayCueEffectOverride(IGameplayCueEffectOverride @override)
	{
	}

	// Token: 0x06018DAA RID: 101802 RVA: 0x0070987E File Offset: 0x00707A7E
	public virtual void OnDisable()
	{
	}

	// Token: 0x06018DAB RID: 101803 RVA: 0x00709880 File Offset: 0x00707A80
	protected virtual void OnChangeBuffHandle(int oldHandle, int cueHandleId)
	{
	}

	// Token: 0x06018DAC RID: 101804 RVA: 0x00709882 File Offset: 0x00707A82
	public virtual void OnChangeRole(EntityHandle newEntityHandle)
	{
		this.EntityHandle = newEntityHandle;
		this.ActorInternal = newEntityHandle.Entity.GetComponent<CharacterActorComponent>().Actor;
	}

	// Token: 0x06018DAD RID: 101805 RVA: 0x007098A1 File Offset: 0x00707AA1
	public static bool IsSingleInstance()
	{
		return true;
	}

	// Token: 0x06018DAE RID: 101806 RVA: 0x007098A4 File Offset: 0x00707AA4
	public static GameplayCueBase Spawn(Func<GameplayCueBase> Spawner, in GameplayCueParam param)
	{
		GameplayCueBase gameplayCueBase = Spawner();
		gameplayCueBase.CueConfig = param.CueConfig;
		gameplayCueBase.EntityHandle = param.EntityHandle;
		gameplayCueBase.ActorInternal = (param.EntityHandle.Entity.GetComponent<BaseActorComponent>().Owner as ABaseCharacter);
		gameplayCueBase.CueComp = param.CueComp;
		gameplayCueBase.IsInstant = param.Instant;
		gameplayCueBase.BeginCallback = param.BeginCallback;
		gameplayCueBase.EndCallback = param.EndCallback;
		gameplayCueBase.Instigator = param.Instigator;
		if (param.Buff != null)
		{
			gameplayCueBase.BuffHandleId = param.Buff.Handle;
			gameplayCueBase.BuffId = new long?(param.Buff.Id);
		}
		gameplayCueBase.InitCueParam = param;
		gameplayCueBase.OnInit();
		gameplayCueBase.Create();
		return gameplayCueBase;
	}

	// Token: 0x06018DAF RID: 101807 RVA: 0x00709974 File Offset: 0x00707B74
	private void Create()
	{
		if (this.IsActive)
		{
			return;
		}
		this.IsActive = true;
		this.OnCreate();
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, long>(this.EntityHandle, EEventName.CharGameplayCueChanged, true, this.CueConfig.Id);
	}

	// Token: 0x06018DB0 RID: 101808 RVA: 0x007099AB File Offset: 0x00707BAB
	public void Destroy()
	{
		if (!this.IsActive)
		{
			return;
		}
		this.IsActive = false;
		this.OnDestroy();
		Singleton<EventSystem>.Instance.EmitWithTarget<bool, long>(this.EntityHandle, EEventName.CharGameplayCueChanged, false, this.CueConfig.Id);
	}

	// Token: 0x06018DB1 RID: 101809 RVA: 0x007099E2 File Offset: 0x00707BE2
	public void Tick(float delta)
	{
		if (this.IsActive)
		{
			this.OnTick(delta);
		}
	}

	// Token: 0x06018DB2 RID: 101810 RVA: 0x007099F3 File Offset: 0x00707BF3
	public void AfterTick(float delta)
	{
		if (!this.IsActive)
		{
			return;
		}
		this.OnAfterTick(delta);
	}

	// Token: 0x06018DB3 RID: 101811 RVA: 0x00709A05 File Offset: 0x00707C05
	public void Add(long cueHandleId, int buffHandleId = 0)
	{
		this.CueHandleIds.Add(cueHandleId);
	}

	// Token: 0x06018DB4 RID: 101812 RVA: 0x00709A14 File Offset: 0x00707C14
	public void Remove(long cueHandleId)
	{
		this.CueHandleIds.Remove(cueHandleId);
	}

	// Token: 0x06018DB5 RID: 101813 RVA: 0x00709A24 File Offset: 0x00707C24
	public void ChangeBuffHandle(int newBuffHandle)
	{
		if (this.BuffHandleId != newBuffHandle)
		{
			int buffHandleId = this.BuffHandleId;
			this.BuffHandleId = newBuffHandle;
			this.OnChangeBuffHandle(buffHandleId, newBuffHandle);
		}
	}

	// Token: 0x06018DB6 RID: 101814 RVA: 0x00709A50 File Offset: 0x00707C50
	protected string GetPath()
	{
		string text = null;
		WorldEntity entity = this.EntityHandle.Entity;
		BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
		if (baseActorComponent != null)
		{
			text = baseActorComponent.GetReplaceEffect(this.CueConfig.Path);
		}
		return text ?? this.CueConfig.Path;
	}

	// Token: 0x06018DB7 RID: 101815 RVA: 0x00709A9C File Offset: 0x00707C9C
	protected BaseActorComponent GetActorComponent()
	{
		if (this.EntityHandle.EntityType == 10)
		{
			return (this.ActorInternal as TsBaseVehicle).VehicleActorComponent;
		}
		return (this.ActorInternal as TsBaseCharacter).CharacterActorComponent;
	}

	// Token: 0x06018DB8 RID: 101816 RVA: 0x00709AD0 File Offset: 0x00707CD0
	[NullableContext(2)]
	protected CharRenderingComponent GetCharRenderingComponent()
	{
		TsBaseCharacter tsBaseCharacter = this.ActorInternal as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			return tsBaseCharacter.CharRenderingComponent;
		}
		TsBaseVehicle tsBaseVehicle = this.ActorInternal as TsBaseVehicle;
		if (tsBaseVehicle != null)
		{
			return tsBaseVehicle.CharRenderingComponent;
		}
		return null;
	}

	// Token: 0x0400C217 RID: 49687
	public long? BuffId;

	// Token: 0x0400C218 RID: 49688
	public int BuffHandleId;

	// Token: 0x0400C219 RID: 49689
	public HashSet<long> CueHandleIds = new HashSet<long>();

	// Token: 0x0400C21A RID: 49690
	public bool IsActive;

	// Token: 0x0400C21C RID: 49692
	private int HandleInternal;

	// Token: 0x0400C21D RID: 49693
	public GameplayCue CueConfig;

	// Token: 0x0400C21E RID: 49694
	public EntityHandle EntityHandle;

	// Token: 0x0400C21F RID: 49695
	protected ABaseCharacter ActorInternal;

	// Token: 0x0400C220 RID: 49696
	protected BaseGameplayCueComponent CueComp;

	// Token: 0x0400C221 RID: 49697
	protected bool IsInstant;

	// Token: 0x0400C222 RID: 49698
	[Nullable(2)]
	protected Action BeginCallback;

	// Token: 0x0400C223 RID: 49699
	[Nullable(2)]
	protected Action EndCallback;

	// Token: 0x0400C224 RID: 49700
	[Nullable(2)]
	protected EntityHandle Instigator;
}
