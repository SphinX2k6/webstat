using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SeamlessTravel
{
	// Token: 0x02005006 RID: 20486
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class SeamlessTravelModel : ModelBase<SeamlessTravelModel>
	{
		// Token: 0x17008AC1 RID: 35521
		// (get) Token: 0x06034CE9 RID: 216297 RVA: 0x00D40FAC File Offset: 0x00D3F1AC
		// (set) Token: 0x06034CEA RID: 216298 RVA: 0x00D40FB4 File Offset: 0x00D3F1B4
		public bool IsSeamlessTravel
		{
			get
			{
				return this.IsSeamlessTravelInternal;
			}
			set
			{
				if (this.InSeamlessTraveling)
				{
					Singleton<Log>.Instance.Error(ELogModule.SeamlessTravel, ELogAuthor.CJH, "无缝加载中，禁止修改是否无缝加载", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				this.IsSeamlessTravelInternal = value;
			}
		}

		// Token: 0x06034CEB RID: 216299 RVA: 0x00D40FEF File Offset: 0x00D3F1EF
		protected override bool OnClear()
		{
			this.ClearSeamlessTravelActor();
			return true;
		}

		// Token: 0x06034CEC RID: 216300 RVA: 0x00D40FF8 File Offset: 0x00D3F1F8
		public bool AddSeamlessTravelActor(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[AddSeamlessTravelActor] Actor Invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			this.SeamlessTravelActorList.Add(actor);
			UKuroStaticLibrary.SetActorPermanent(actor, true, true);
			return true;
		}

		// Token: 0x06034CED RID: 216301 RVA: 0x00D4104C File Offset: 0x00D3F24C
		[NullableContext(1)]
		public bool RemoveSeamlessTravelActor(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[RemoveSeamlessTravelActor] Actor Invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int num = this.SeamlessTravelActorList.IndexOf(actor);
			if (num >= 0)
			{
				this.SeamlessTravelActorList.RemoveAt(num);
			}
			UKuroStaticLibrary.SetActorPermanent(actor, false, true);
			return true;
		}

		// Token: 0x06034CEE RID: 216302 RVA: 0x00D410B4 File Offset: 0x00D3F2B4
		[NullableContext(1)]
		public bool IsSeamlessTravelActor(AActor actor)
		{
			if (actor == null || !actor.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.SeamlessTravel, ELogAuthor.CJH, "[IsSeamlessTravelActor] Actor Invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			return this.SeamlessTravelActorList.IndexOf(actor) >= 0;
		}

		// Token: 0x06034CEF RID: 216303 RVA: 0x00D41108 File Offset: 0x00D3F308
		public EntityHandle GetSeamlessTravelRoleEntityHandle(long creatureDataId)
		{
			foreach (EntityHandle entityHandle in this.SeamlessTravelPlayerTeamHandles)
			{
				if (entityHandle.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId() == creatureDataId)
				{
					return entityHandle;
				}
			}
			return null;
		}

		// Token: 0x06034CF0 RID: 216304 RVA: 0x00D41170 File Offset: 0x00D3F370
		public void CreatePromise()
		{
			this.MeshAssetLoadedPromise = new GameModePromise();
			this.ScreenEffectStartedPromise = new GameModePromise();
			this.ScreenEffectEndedPromise = new GameModePromise();
			this.EnterTransitionMapPromise = new GameModePromise();
			this.EnterDestinationMapPromise = new GameModePromise();
			this.TransitionFloorLoadedPromise = new GameModePromise();
			this.TransitionFloorUnloadedPromise = new GameModePromise();
			this.KiteInitPromise = new GameModePromise();
			this.EffectAssetLoadedPromise = new GameModePromise();
			this.PostProcessAssetLoadedPromise = new GameModePromise();
			this.PostProcessBlendedInPromise = new GameModePromise();
			this.PostProcessBlendedOutPromise = new GameModePromise();
			this.SceneEffectAssetLoadedPromise = new GameModePromise();
			this.SceneEffectStartedPromise = new GameModePromise();
			this.SceneEffectEndedPromise = new GameModePromise();
		}

		// Token: 0x06034CF1 RID: 216305 RVA: 0x00D41224 File Offset: 0x00D3F424
		public void ClearPromise()
		{
			this.MeshAssetLoadedPromise = null;
			this.ScreenEffectStartedPromise = null;
			this.ScreenEffectEndedPromise = null;
			this.EnterTransitionMapPromise = null;
			this.EnterDestinationMapPromise = null;
			this.TransitionFloorLoadedPromise = null;
			this.TransitionFloorUnloadedPromise = null;
			this.KiteInitPromise = null;
			this.EffectAssetLoadedPromise = null;
			this.PostProcessAssetLoadedPromise = null;
			this.PostProcessBlendedInPromise = null;
			this.PostProcessBlendedOutPromise = null;
			this.SceneEffectAssetLoadedPromise = null;
			this.SceneEffectStartedPromise = null;
			this.SceneEffectEndedPromise = null;
		}

		// Token: 0x06034CF2 RID: 216306 RVA: 0x00D4129C File Offset: 0x00D3F49C
		public void ClearSeamlessTravelActor()
		{
			foreach (AActor aactor in this.SeamlessTravelActorList)
			{
				if (aactor.IsValid())
				{
					UKuroStaticLibrary.SetActorPermanent(aactor, false, false);
				}
			}
			this.SeamlessTravelActorList.Clear();
		}

		// Token: 0x06034CF3 RID: 216307 RVA: 0x00D41304 File Offset: 0x00D3F504
		public bool GetIsKeepingCurrentMovementMode()
		{
			if (this.IsSeamlessTravel)
			{
				SeamlessTravelKeepMovementMode seamlessTravelKeepMovementMode = this.SeamlessTravelKeepMovementMode;
				if (seamlessTravelKeepMovementMode != null && seamlessTravelKeepMovementMode.IsActive)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					object obj;
					if (baseCharacter == null)
					{
						obj = null;
					}
					else
					{
						CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
						if (characterActorComponent == null)
						{
							obj = null;
						}
						else
						{
							BaseMoveComponent moveComp = characterActorComponent.MoveComp;
							obj = ((moveComp != null) ? moveComp.CharacterMovement : null);
						}
					}
					object obj2 = obj;
					TEnumAsByte<EMovementMode>? tenumAsByte = (obj2 != null) ? new TEnumAsByte<EMovementMode>?(obj2.MovementMode) : null;
					byte? b = (obj2 != null) ? new byte?(obj2.CustomMovementMode) : null;
					if (tenumAsByte == null || b == null)
					{
						return false;
					}
					EMovementMode? targetMovementMode = this.SeamlessTravelKeepMovementMode.TargetMovementMode;
					if (((targetMovementMode != null) ? new TEnumAsByte<EMovementMode>?(targetMovementMode.GetValueOrDefault()) : null) == tenumAsByte)
					{
						byte? b2 = this.SeamlessTravelKeepMovementMode.TargetCustomMode;
						int? num = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
						b2 = b;
						int? num2 = (b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null;
						return num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null);
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x0401E6C4 RID: 124612
		private bool IsSeamlessTravelInternal;

		// Token: 0x0401E6C5 RID: 124613
		public bool InSeamlessTraveling;

		// Token: 0x0401E6C6 RID: 124614
		public bool HasPreEnableSeamlessTravel;

		// Token: 0x0401E6C7 RID: 124615
		public TimerHandle SeamlessEndHandle;

		// Token: 0x0401E6C8 RID: 124616
		public SeamlessTravelContext Config;

		// Token: 0x0401E6C9 RID: 124617
		public APlayerController SeamlessTravelController;

		// Token: 0x0401E6CA RID: 124618
		public AController SeamlessTravelDefaultController;

		// Token: 0x0401E6CB RID: 124619
		[Nullable(1)]
		public List<AController> SeamlessTravelTeamDefaultController = new List<AController>();

		// Token: 0x0401E6CC RID: 124620
		public EntityHandle SeamlessTravelPlayerEntityHandle;

		// Token: 0x0401E6CD RID: 124621
		[Nullable(1)]
		public List<EntityHandle> SeamlessTravelPlayerTeamHandles = new List<EntityHandle>();

		// Token: 0x0401E6CE RID: 124622
		public ACameraActor SeamlessTravelCamera;

		// Token: 0x0401E6CF RID: 124623
		public SeamlessTravelScreenEffect SeamlessTravelScreenEffect;

		// Token: 0x0401E6D0 RID: 124624
		public bool UseTreadmill;

		// Token: 0x0401E6D1 RID: 124625
		public SeamlessTravelTreadmill SeamlessTravelTreadmill;

		// Token: 0x0401E6D2 RID: 124626
		public bool UseKeepKite;

		// Token: 0x0401E6D3 RID: 124627
		public SeamlessTravelKeepKite SeamlessTravelKeepKite;

		// Token: 0x0401E6D4 RID: 124628
		public bool UseKeepMovementMode;

		// Token: 0x0401E6D5 RID: 124629
		public SeamlessTravelKeepMovementMode SeamlessTravelKeepMovementMode;

		// Token: 0x0401E6D6 RID: 124630
		public SeamlessTravelPostProcess SeamlessTravelPostProcess;

		// Token: 0x0401E6D7 RID: 124631
		public SeamlessTravelSceneEffect SeamlessTravelSceneEffect;

		// Token: 0x0401E6D8 RID: 124632
		[Nullable(1)]
		private readonly List<AActor> SeamlessTravelActorList = new List<AActor>();

		// Token: 0x0401E6D9 RID: 124633
		[Nullable(1)]
		public List<string> SeamlessTravelInputDistributeTags = new List<string>();

		// Token: 0x0401E6DA RID: 124634
		public GameModePromise MeshAssetLoadedPromise;

		// Token: 0x0401E6DB RID: 124635
		public GameModePromise ScreenEffectStartedPromise;

		// Token: 0x0401E6DC RID: 124636
		public GameModePromise ScreenEffectEndedPromise;

		// Token: 0x0401E6DD RID: 124637
		public GameModePromise TransitionFloorLoadedPromise;

		// Token: 0x0401E6DE RID: 124638
		public GameModePromise EnterTransitionMapPromise;

		// Token: 0x0401E6DF RID: 124639
		public GameModePromise EnterDestinationMapPromise;

		// Token: 0x0401E6E0 RID: 124640
		public GameModePromise TransitionFloorUnloadedPromise;

		// Token: 0x0401E6E1 RID: 124641
		public GameModePromise EffectAssetLoadedPromise;

		// Token: 0x0401E6E2 RID: 124642
		public GameModePromise KiteInitPromise;

		// Token: 0x0401E6E3 RID: 124643
		public GameModePromise PostProcessAssetLoadedPromise;

		// Token: 0x0401E6E4 RID: 124644
		public GameModePromise PostProcessBlendedInPromise;

		// Token: 0x0401E6E5 RID: 124645
		public GameModePromise PostProcessBlendedOutPromise;

		// Token: 0x0401E6E6 RID: 124646
		public GameModePromise SceneEffectAssetLoadedPromise;

		// Token: 0x0401E6E7 RID: 124647
		public GameModePromise SceneEffectStartedPromise;

		// Token: 0x0401E6E8 RID: 124648
		public GameModePromise SceneEffectEndedPromise;
	}
}
