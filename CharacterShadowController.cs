using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002E26 RID: 11814
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
[TickController(0)]
public class CharacterShadowController : ControllerBase<CharacterShadowController>
{
	// Token: 0x17002063 RID: 8291
	// (get) Token: 0x06017E97 RID: 97943 RVA: 0x006B317D File Offset: 0x006B137D
	protected override bool IsTickEvenPausedInternal
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06017E98 RID: 97944 RVA: 0x006B3180 File Offset: 0x006B1380
	protected override bool OnInit()
	{
		this.GetConfigByGameSetting();
		this.OnAddEvents();
		this.LastDate = new DateTime?(DateTime.Now);
		return true;
	}

	// Token: 0x06017E99 RID: 97945 RVA: 0x006B319F File Offset: 0x006B139F
	protected override bool OnClear()
	{
		this.OnRemoveEvents();
		return true;
	}

	// Token: 0x06017E9A RID: 97946 RVA: 0x006B31A8 File Offset: 0x006B13A8
	private void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SetImageQuality, new Action(this.OnSetImageQuality));
		Singleton<EventSystem>.Instance.Add<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Add<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
	}

	// Token: 0x06017E9B RID: 97947 RVA: 0x006B320C File Offset: 0x006B140C
	private void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SetImageQuality, new Action(this.OnSetImageQuality));
		Singleton<EventSystem>.Instance.Remove<EAddEntityType, EntityHandle, AActor>(EEventName.AddEntity, new Action<EAddEntityType, EntityHandle, AActor>(this.OnAddEntity));
		Singleton<EventSystem>.Instance.Remove<ERemoveEntityType, EntityHandle>(EEventName.RemoveEntity, new Action<ERemoveEntityType, EntityHandle>(this.OnRemoveEntity));
	}

	// Token: 0x06017E9C RID: 97948 RVA: 0x006B326D File Offset: 0x006B146D
	private void OnSetImageQuality()
	{
		this.GetConfigByGameSetting();
	}

	// Token: 0x06017E9D RID: 97949 RVA: 0x006B3278 File Offset: 0x006B1478
	private void OnAddEntity(EAddEntityType addType, EntityHandle handle, [Nullable(2)] AActor actor)
	{
		WorldEntity entity = handle.Entity;
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		if (creatureDataComponent != null && creatureDataComponent.IsCharacter())
		{
			if (creatureDataComponent.IsRole() || creatureDataComponent.GetSummonerPlayerId() != 0 || creatureDataComponent.IsVision())
			{
				this.RoleEntityHandles.Add(handle);
				return;
			}
			BaseCharacterComponent component = handle.Entity.GetComponent<BaseCharacterComponent>();
			if (component != null && component.Actor.IsValid() && this.EnableRealShadowNum == 0)
			{
				CharRenderingComponent charRenderingComponent = component.Actor.CharRenderingComponent;
				if (charRenderingComponent == null)
				{
					return;
				}
				charRenderingComponent.DisableAllShadowByDecalShadowComponent();
			}
		}
	}

	// Token: 0x06017E9E RID: 97950 RVA: 0x006B3302 File Offset: 0x006B1502
	private void OnRemoveEntity(ERemoveEntityType removeType, EntityHandle handle)
	{
		this.RoleEntityHandles.Remove(handle);
	}

	// Token: 0x06017E9F RID: 97951 RVA: 0x006B3314 File Offset: 0x006B1514
	private void GetConfigByGameSetting()
	{
		this.EnableRealShadowDistance = Singleton<GameSettingsDeviceRender>.Instance.GetMaxRoleShadowDistance();
		this.EnableRealShadowNum = Singleton<GameSettingsDeviceRender>.Instance.GetMaxRoleShadowNum();
		this.MaxDecalShadowDistance = Singleton<GameSettingsDeviceRender>.Instance.GetMaxDecalShadowDistance();
		this.IsMainPlayerUseRealRoleShadow = (Singleton<GameSettingsDeviceRender>.Instance.IsMainPlayerUseRealRoleShadow() != 0);
	}

	// Token: 0x06017EA0 RID: 97952 RVA: 0x006B3364 File Offset: 0x006B1564
	private UniTask TrySendMessage()
	{
		CharacterShadowController.<TrySendMessage>d__22 <TrySendMessage>d__;
		<TrySendMessage>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TrySendMessage>d__.<>4__this = this;
		<TrySendMessage>d__.<>1__state = -1;
		<TrySendMessage>d__.<>t__builder.Start<CharacterShadowController.<TrySendMessage>d__22>(ref <TrySendMessage>d__);
		return <TrySendMessage>d__.<>t__builder.Task;
	}

	// Token: 0x06017EA1 RID: 97953 RVA: 0x006B33A8 File Offset: 0x006B15A8
	protected override void OnTick(float deltaTime)
	{
		if (Singleton<Net>.Instance.IsFinishLogin())
		{
			this.TrySendMessage().Forget();
		}
		if (Singleton<TickSystem>.Instance.IsPaused)
		{
			return;
		}
		if (Singleton<Time>.Instance.Frame - this.LastUpdateFrame < 15)
		{
			return;
		}
		bool debugLogEnabled = this.DebugLogEnabled;
		this.LastUpdateFrame = Singleton<Time>.Instance.Frame;
		if (!ModelBase<PlotModel>.Instance.IsInHighLevelPlot() && this.MaxDecalShadowDistance > 0)
		{
			ModelBase<CreatureModel>.Instance.GetEntitiesInRange((float)this.MaxDecalShadowDistance, EEntityTypeQuery.Character, this.QueryEntityResultCache, true, false);
			int num = 0;
			this.RealShadowEntitiesSet.Clear();
			this.DecalShadowEntitiesSet.Clear();
			foreach (EntityHandle entityHandle in this.QueryEntityResultCache)
			{
				if (entityHandle.Valid)
				{
					BaseCharacterComponent component = entityHandle.Entity.GetComponent<BaseCharacterComponent>();
					if (component != null && component.Actor.IsValid())
					{
						AActor owner = component.Owner;
						if (owner != null && owner.WasRecentlyRenderedOnScreen(0.2f))
						{
							if (this.EnableRealShadowNum > 0 && num < this.EnableRealShadowNum && entityHandle.Entity.DistanceWithCamera < (float)this.EnableRealShadowDistance)
							{
								CharRenderingComponent charRenderingComponent = component.Actor.CharRenderingComponent;
								if (charRenderingComponent != null)
								{
									charRenderingComponent.SetDecalShadowEnabled(false);
								}
								CharRenderingComponent charRenderingComponent2 = component.Actor.CharRenderingComponent;
								if (charRenderingComponent2 != null)
								{
									charRenderingComponent2.SetRealTimeShadowEnabled(true);
								}
								this.RealShadowEntitiesSet.Add(entityHandle);
								num++;
								if (this.DebugLogEnabled)
								{
								}
							}
							else
							{
								if (num >= this.EnableRealShadowNum)
								{
									CharRenderingComponent charRenderingComponent3 = component.Actor.CharRenderingComponent;
									if (charRenderingComponent3 != null)
									{
										charRenderingComponent3.SetDecalShadowEnabled(true);
									}
									CharRenderingComponent charRenderingComponent4 = component.Actor.CharRenderingComponent;
									if (charRenderingComponent4 != null)
									{
										charRenderingComponent4.SetRealTimeShadowEnabled(false);
									}
									this.DecalShadowEntitiesSet.Add(entityHandle);
								}
								bool debugLogEnabled2 = this.DebugLogEnabled;
							}
						}
					}
				}
			}
			foreach (EntityHandle entityHandle2 in this.LastFrameDecalShadowEntitiesSet)
			{
				if (entityHandle2.Valid && !this.RealShadowEntitiesSet.Contains(entityHandle2) && !this.DecalShadowEntitiesSet.Contains(entityHandle2))
				{
					BaseCharacterComponent component2 = entityHandle2.Entity.GetComponent<BaseCharacterComponent>();
					if (component2 != null && component2.Actor.IsValid())
					{
						CharRenderingComponent charRenderingComponent5 = component2.Actor.CharRenderingComponent;
						if (charRenderingComponent5 != null)
						{
							charRenderingComponent5.DisableAllShadowByDecalShadowComponent();
						}
					}
				}
			}
		}
		this.LastFrameDecalShadowEntitiesSet = new HashSet<EntityHandle>(this.DecalShadowEntitiesSet);
		foreach (EntityHandle entityHandle3 in this.RoleEntityHandles)
		{
			if (entityHandle3.Valid)
			{
				BaseCharacterComponent component3 = entityHandle3.Entity.GetComponent<BaseCharacterComponent>();
				if (component3 != null && component3.Actor.IsValid())
				{
					WorldEntity entity = entityHandle3.Entity;
					if (entity != null && entity.Active)
					{
						if (this.IsMainPlayerUseRealRoleShadow)
						{
							CharRenderingComponent charRenderingComponent6 = component3.Actor.CharRenderingComponent;
							if (charRenderingComponent6 != null)
							{
								charRenderingComponent6.SetDecalShadowEnabled(false);
							}
							CharRenderingComponent charRenderingComponent7 = component3.Actor.CharRenderingComponent;
							if (charRenderingComponent7 != null)
							{
								charRenderingComponent7.SetRealTimeShadowEnabled(true);
							}
						}
						else
						{
							CharRenderingComponent charRenderingComponent8 = component3.Actor.CharRenderingComponent;
							if (charRenderingComponent8 != null)
							{
								charRenderingComponent8.SetDecalShadowEnabled(true);
							}
							CharRenderingComponent charRenderingComponent9 = component3.Actor.CharRenderingComponent;
							if (charRenderingComponent9 != null)
							{
								charRenderingComponent9.SetRealTimeShadowEnabled(false);
							}
						}
					}
					else
					{
						CharRenderingComponent charRenderingComponent10 = component3.Actor.CharRenderingComponent;
						if (charRenderingComponent10 != null)
						{
							charRenderingComponent10.DisableAllShadowByDecalShadowComponent();
						}
					}
					bool debugLogEnabled3 = this.DebugLogEnabled;
				}
			}
		}
	}

	// Token: 0x0400B97F RID: 47487
	private int EnableRealShadowDistance;

	// Token: 0x0400B980 RID: 47488
	private int EnableRealShadowNum;

	// Token: 0x0400B981 RID: 47489
	private int MaxDecalShadowDistance;

	// Token: 0x0400B982 RID: 47490
	private int LastUpdateFrame;

	// Token: 0x0400B983 RID: 47491
	private bool IsMainPlayerUseRealRoleShadow;

	// Token: 0x0400B984 RID: 47492
	private readonly HashSet<EntityHandle> RoleEntityHandles = new HashSet<EntityHandle>();

	// Token: 0x0400B985 RID: 47493
	private readonly List<EntityHandle> QueryEntityResultCache = new List<EntityHandle>();

	// Token: 0x0400B986 RID: 47494
	private readonly HashSet<EntityHandle> DecalShadowEntitiesSet = new HashSet<EntityHandle>();

	// Token: 0x0400B987 RID: 47495
	private readonly HashSet<EntityHandle> RealShadowEntitiesSet = new HashSet<EntityHandle>();

	// Token: 0x0400B988 RID: 47496
	private HashSet<EntityHandle> LastFrameDecalShadowEntitiesSet = new HashSet<EntityHandle>();

	// Token: 0x0400B989 RID: 47497
	private readonly bool DebugLogEnabled;

	// Token: 0x0400B98A RID: 47498
	private DateTime? LastDate;
}
