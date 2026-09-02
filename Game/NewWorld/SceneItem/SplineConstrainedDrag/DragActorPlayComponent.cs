using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag;
using CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x0200481E RID: 18462
	[NullableContext(1)]
	[Nullable(0)]
	public class DragActorPlayComponent : EntityComponent
	{
		// Token: 0x1700822E RID: 33326
		// (get) Token: 0x060300AF RID: 196783 RVA: 0x00BA434A File Offset: 0x00BA254A
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public new static Type[] Dependencies
		{
			[return: Nullable(new byte[]
			{
				2,
				1
			})]
			get
			{
				return new Type[]
				{
					typeof(CreatureDataComponent),
					typeof(SceneItemReferenceComponent)
				};
			}
		}

		// Token: 0x060300B0 RID: 196784 RVA: 0x00BA436C File Offset: 0x00BA256C
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			DragActorPlayComponent compConfig = args.GetP1<CreateEntityData>().GetParam<DragActorPlayComponent>() as DragActorPlayComponent;
			this.CompConfig = compConfig;
			if (this.CompConfig == null)
			{
				return false;
			}
			this.ActorKeyToConfig = new Dictionary<string, IDragActorPlayConfig>();
			foreach (IDragActorPlayConfig dragActorPlayConfig in this.CompConfig.Configs)
			{
				string[] array = dragActorPlayConfig.DraggableActor.PathName.Split('.', StringSplitOptions.None);
				if (array.Length < 3)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.LevelPlay;
					ELogAuthor author = ELogAuthor.XDW;
					string message = "[DragActorPlayComponent] OnInitData: Invalid DraggableActor PathName";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PathName", dragActorPlayConfig.DraggableActor.PathName);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					string key = array[1] + "." + array[2];
					this.ActorKeyToConfig[key] = dragActorPlayConfig;
				}
			}
			List<string> list = new List<string>();
			foreach (IDragActorPlayConfig dragActorPlayConfig2 in this.CompConfig.Configs)
			{
				list.Add(dragActorPlayConfig2.DraggableActorEffectDa);
			}
			ControllerBase<SplineConstrainedDragController>.Instance.PreloadSelectionMaterials(this.CreatureDataComp.GetPbDataId(), list);
			return true;
		}

		// Token: 0x060300B1 RID: 196785 RVA: 0x00BA44E0 File Offset: 0x00BA26E0
		protected override bool OnInit()
		{
			this.RefComp = base.Entity.GetComponent<SceneItemReferenceComponent>();
			if (this.RefComp == null)
			{
				return false;
			}
			foreach (IDragActorPlayConfig dragActorPlayConfig in this.CompConfig.Configs)
			{
				this.RefComp.RegisterCustomRefActor(dragActorPlayConfig.DraggableActor);
			}
			return true;
		}

		// Token: 0x060300B2 RID: 196786 RVA: 0x00BA4560 File Offset: 0x00BA2760
		protected override bool OnStart()
		{
			UKuroActorSubsystem ukuroActorSubsystem = UKuroRenderingRuntimeBPPluginBPLibrary.GetSubsystem(GlobalData.World, UKuroActorSubsystem.StaticClass()) as UKuroActorSubsystem;
			if (this.RefComp != null)
			{
				this.RefComp.AddOnRefActorReadyCallback(new Action<string, AActor>(this.OnRefActorReady));
			}
			foreach (IDragActorPlayConfig dragActorPlayConfig in this.CompConfig.Configs)
			{
				string[] array = dragActorPlayConfig.DraggableActor.PathName.Split('.', StringSplitOptions.None);
				if (array.Length >= 3)
				{
					string text = array[1] + "." + array[2];
					AActor aactor = (ukuroActorSubsystem != null) ? ukuroActorSubsystem.GetActor(FNameUtil.GetDynamicFName(text) ?? FNameUtil.NONE) : null;
					if (aactor != null)
					{
						this.RegisterKuroSplineConstrainedDrag(text, aactor, dragActorPlayConfig);
					}
				}
			}
			this.InstallEffectVisibilityProviders();
			return true;
		}

		// Token: 0x060300B3 RID: 196787 RVA: 0x00BA465C File Offset: 0x00BA285C
		protected override bool OnClear()
		{
			if (this.RefComp != null)
			{
				this.RefComp.RemoveOnRefActorReadyCallback(new Action<string, AActor>(this.OnRefActorReady));
			}
			this.RefComp = null;
			this.UninstallEffectVisibilityProviders();
			foreach (KeyValuePair<string, IKuroSplineConstrainedDrag> keyValuePair in this.RegisteredDrags)
			{
				string text;
				IKuroSplineConstrainedDrag kuroSplineConstrainedDrag;
				keyValuePair.Deconstruct(out text, out kuroSplineConstrainedDrag);
				IKuroSplineConstrainedDrag drag = kuroSplineConstrainedDrag;
				ControllerBase<SplineConstrainedDragController>.Instance.OnDraggableUnregistered(drag);
			}
			this.RegisteredDrags.Clear();
			foreach (KeyValuePair<string, ISequenceProgressController> keyValuePair2 in this.SeqControllers)
			{
				string text;
				ISequenceProgressController sequenceProgressController;
				keyValuePair2.Deconstruct(out text, out sequenceProgressController);
				sequenceProgressController.Destroy();
			}
			this.SeqControllers.Clear();
			if (this.CreatureDataComp != null)
			{
				ControllerBase<SplineConstrainedDragController>.Instance.ReleaseSelectionMaterialsByHolder(this.CreatureDataComp.GetPbDataId());
			}
			this.CachedEntityContext = null;
			return true;
		}

		// Token: 0x060300B4 RID: 196788 RVA: 0x00BA4778 File Offset: 0x00BA2978
		private void InstallEffectVisibilityProviders()
		{
			if (this.CompConfig == null)
			{
				return;
			}
			foreach (IDragActorPlayConfig dragActorPlayConfig in this.CompConfig.Configs)
			{
				int targetPbDataId = dragActorPlayConfig.EffectSplineEntityId.GetValueOrDefault();
				if (targetPbDataId > 0 && !this.EffectVisibilityRecords.ContainsKey(targetPbDataId))
				{
					string[] array = dragActorPlayConfig.DraggableActor.PathName.Split('.', StringSplitOptions.None);
					string ownerActorKey = (array.Length >= 3) ? (array[1] + "." + array[2]) : null;
					DragPlayEffectVisibilityProvider provider = new DragPlayEffectVisibilityProvider(dragActorPlayConfig.Condition, new Func<GeneralContext>(this.GetEntityContext), ownerActorKey);
					IEffectVisibilityRecord record = new EffectVisibilityRecord
					{
						Provider = provider
					};
					this.EffectVisibilityRecords[targetPbDataId] = record;
					Action action = ModelBase<LevelGamePlayModel>.Instance.RegisterPendingGuidePathHandler(targetPbDataId, delegate(IGuidePathVisibilityHost host)
					{
						if (!this.EffectVisibilityRecords.ContainsKey(targetPbDataId))
						{
							return;
						}
						record.Attached = host;
						record.CancelPending = null;
						host.SetExternalVisibilityProvider(provider, new EGuidePathProviderRemovedBehavior?(EGuidePathProviderRemovedBehavior.RestoreDefault));
						provider.AttachTo(host);
					});
					if (action != null)
					{
						record.CancelPending = action;
					}
				}
			}
		}

		// Token: 0x060300B5 RID: 196789 RVA: 0x00BA48D4 File Offset: 0x00BA2AD4
		private void UninstallEffectVisibilityProviders()
		{
			foreach (KeyValuePair<int, IEffectVisibilityRecord> keyValuePair in this.EffectVisibilityRecords)
			{
				int num;
				IEffectVisibilityRecord effectVisibilityRecord;
				keyValuePair.Deconstruct(out num, out effectVisibilityRecord);
				IEffectVisibilityRecord effectVisibilityRecord2 = effectVisibilityRecord;
				if (effectVisibilityRecord2.CancelPending != null)
				{
					effectVisibilityRecord2.CancelPending();
					effectVisibilityRecord2.CancelPending = null;
				}
				if (effectVisibilityRecord2.Attached != null)
				{
					effectVisibilityRecord2.Attached.ClearExternalVisibilityProvider(effectVisibilityRecord2.Provider);
					effectVisibilityRecord2.Attached = null;
				}
				effectVisibilityRecord2.Provider.OnDetached();
			}
			this.EffectVisibilityRecords.Clear();
		}

		// Token: 0x060300B6 RID: 196790 RVA: 0x00BA4984 File Offset: 0x00BA2B84
		[NullableContext(2)]
		private GeneralContext GetEntityContext()
		{
			if (this.CachedEntityContext == null)
			{
				this.CachedEntityContext = EntityContext.Create(base.Entity.Id, null);
			}
			return this.CachedEntityContext;
		}

		// Token: 0x060300B7 RID: 196791 RVA: 0x00BA49C0 File Offset: 0x00BA2BC0
		[return: Nullable(2)]
		private ISequenceProgressController GetOrCreateSeqController(string actorKey, IDragActorPlayConfig config)
		{
			if (this.RefComp == null)
			{
				return null;
			}
			ISequenceProgressController sequenceProgressController;
			if (this.SeqControllers.TryGetValue(actorKey, out sequenceProgressController))
			{
				sequenceProgressController.Destroy();
			}
			ISequenceProgressController sequenceProgressController2 = this.RefComp.CreateSequenceProgressController(config.Sequence);
			if (sequenceProgressController2 == null)
			{
				return null;
			}
			this.SeqControllers[actorKey] = sequenceProgressController2;
			return sequenceProgressController2;
		}

		// Token: 0x060300B8 RID: 196792 RVA: 0x00BA4A14 File Offset: 0x00BA2C14
		private unsafe void OnRefActorReady(string actorKey, AActor actor)
		{
			IDragActorPlayConfig dragActorPlayConfig = null;
			Dictionary<string, IDragActorPlayConfig> actorKeyToConfig = this.ActorKeyToConfig;
			if (actorKeyToConfig != null)
			{
				actorKeyToConfig.TryGetValue(actorKey, out dragActorPlayConfig);
			}
			if (dragActorPlayConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.XDW;
				string message = "[DragActorPlayComponent] OnRefActorReady: Invalid DraggableActor PathName";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PathName", actorKey);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActorKeyToConfig", this.ActorKeyToConfig);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.RegisterKuroSplineConstrainedDrag(actorKey, actor, dragActorPlayConfig);
		}

		// Token: 0x060300B9 RID: 196793 RVA: 0x00BA4AA0 File Offset: 0x00BA2CA0
		private void RegisterKuroSplineConstrainedDrag(string actorKey, AActor actor, IDragActorPlayConfig config)
		{
			int pbDataId = this.CreatureDataComp.GetPbDataId();
			long creatureDataId = this.CreatureDataComp.GetCreatureDataId();
			USplineComponent constraintSpline = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(config.SplineEntityId, pbDataId, EIdType.PbDataId);
			TsKuroSplineConstrainedDragImpl tsKuroSplineConstrainedDragImpl = KuroSplineConstrainedDragFactory.Create(new KuroSplineConstrainedDragParam
			{
				ActorKey = actorKey,
				ConstraintSpline = constraintSpline,
				Actor = actor,
				SequenceProgressController = this.GetOrCreateSeqController(actorKey, config),
				KeyPoints = config.KeyPoints,
				CreatureDataId = new long?(creatureDataId),
				MaxPlaySpeed = new float?(config.MaxPlaySpeed),
				Stiffness = config.Stiffness,
				Damping = config.Damping,
				DraggableActorEffectDa = config.DraggableActorEffectDa,
				Condition = config.Condition,
				IgnoreRotation = config.IgnoreRotation,
				AkEvent = ((!string.IsNullOrEmpty(config.DragAkEvent)) ? Singleton<AudioSystem>.Instance.parseAudioEventPath(config.DragAkEvent) : null),
				DragHintType = config.DragHintType
			});
			IKuroSplineConstrainedDrag valueOrDefault = this.RegisteredDrags.GetValueOrDefault(actorKey);
			if (valueOrDefault != null)
			{
				ControllerBase<SplineConstrainedDragController>.Instance.OnDraggableUnregistered(valueOrDefault);
			}
			this.RegisteredDrags[actorKey] = tsKuroSplineConstrainedDragImpl;
			ControllerBase<SplineConstrainedDragController>.Instance.OnDraggableRegistered(tsKuroSplineConstrainedDragImpl);
		}

		// Token: 0x060300BA RID: 196794 RVA: 0x00BA4BD4 File Offset: 0x00BA2DD4
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			DragActorPlayComponent dragActorPlayComponent = (DragActorPlayComponent)componentTemplate;
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (dragActorPlayComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CompConfig"))
			{
				if (dragActorPlayComponent.CompConfig == null)
				{
					this.CompConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<DragActorPlayComponent>(this.CompConfig), "CompConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorKeyToConfig"))
			{
				if (dragActorPlayComponent.ActorKeyToConfig == null)
				{
					this.ActorKeyToConfig = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, IDragActorPlayConfig>>(this.ActorKeyToConfig), "ActorKeyToConfig"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("RefComp"))
			{
				if (dragActorPlayComponent.RefComp == null)
				{
					this.RefComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<SceneItemReferenceComponent>(this.RefComp), "RefComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("SeqControllers") && dragActorPlayComponent.SeqControllers != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, ISequenceProgressController>>(this.SeqControllers), "SeqControllers"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RegisteredDrags") && dragActorPlayComponent.RegisteredDrags != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<string, IKuroSplineConstrainedDrag>>(this.RegisteredDrags), "RegisteredDrags"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("EffectVisibilityRecords") && dragActorPlayComponent.EffectVisibilityRecords != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, IEffectVisibilityRecord>>(this.EffectVisibilityRecords), "EffectVisibilityRecords"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("CachedEntityContext"))
			{
				if (dragActorPlayComponent.CachedEntityContext == null)
				{
					this.CachedEntityContext = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<GeneralContext>(this.CachedEntityContext), "CachedEntityContext"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401B94C RID: 112972
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401B94D RID: 112973
		[Nullable(2)]
		private DragActorPlayComponent CompConfig;

		// Token: 0x0401B94E RID: 112974
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private Dictionary<string, IDragActorPlayConfig> ActorKeyToConfig;

		// Token: 0x0401B94F RID: 112975
		[Nullable(2)]
		private SceneItemReferenceComponent RefComp;

		// Token: 0x0401B950 RID: 112976
		private readonly Dictionary<string, ISequenceProgressController> SeqControllers = new Dictionary<string, ISequenceProgressController>();

		// Token: 0x0401B951 RID: 112977
		private readonly Dictionary<string, IKuroSplineConstrainedDrag> RegisteredDrags = new Dictionary<string, IKuroSplineConstrainedDrag>();

		// Token: 0x0401B952 RID: 112978
		private readonly Dictionary<int, IEffectVisibilityRecord> EffectVisibilityRecords = new Dictionary<int, IEffectVisibilityRecord>();

		// Token: 0x0401B953 RID: 112979
		[Nullable(2)]
		private GeneralContext CachedEntityContext;
	}
}
