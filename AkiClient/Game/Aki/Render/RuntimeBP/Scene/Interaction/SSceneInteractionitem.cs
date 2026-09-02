using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC6 RID: 15046
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitem.SSceneInteractionitem")]
	[UnrealStructLayout(536, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 529)]
	public class SSceneInteractionitem : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06020201 RID: 131585 RVA: 0x00922D66 File Offset: 0x00920F66
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionitem._ScriptStructPtr != 0) ? SSceneInteractionitem._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitem.SSceneInteractionitem", ref SSceneInteractionitem._ScriptStructPtr);
		}

		// Token: 0x17003406 RID: 13318
		// (get) Token: 0x06020202 RID: 131586 RVA: 0x00922D8A File Offset: 0x00920F8A
		// (set) Token: 0x06020203 RID: 131587 RVA: 0x00922D9E File Offset: 0x00920F9E
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SSceneInteractionitem.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SSceneInteractionitem.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17003407 RID: 13319
		// (get) Token: 0x06020204 RID: 131588 RVA: 0x00922DB4 File Offset: 0x00920FB4
		// (set) Token: 0x06020205 RID: 131589 RVA: 0x00922DF7 File Offset: 0x00920FF7
		public SSceneInteractionSequence Sequence
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionSequence result;
				if ((result = this._Sequence) == null)
				{
					result = (this._Sequence = new SSceneInteractionSequence(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionSequence.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003408 RID: 13320
		// (get) Token: 0x06020206 RID: 131590 RVA: 0x00922E18 File Offset: 0x00921018
		// (set) Token: 0x06020207 RID: 131591 RVA: 0x00922E5B File Offset: 0x0092105B
		public SSceneInteractionMontage AnimMontage
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionMontage result;
				if ((result = this._AnimMontage) == null)
				{
					result = (this._AnimMontage = new SSceneInteractionMontage(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionMontage.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003409 RID: 13321
		// (get) Token: 0x06020208 RID: 131592 RVA: 0x00922E7C File Offset: 0x0092107C
		// (set) Token: 0x06020209 RID: 131593 RVA: 0x00922EBF File Offset: 0x009210BF
		public TArray<BP_EffectActor_C> Effects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x1700340A RID: 13322
		// (get) Token: 0x0602020A RID: 131594 RVA: 0x00922ED0 File Offset: 0x009210D0
		// (set) Token: 0x0602020B RID: 131595 RVA: 0x00922F13 File Offset: 0x00921113
		public TArray<AActor> Actors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Actors) == null)
				{
					result = (this._Actors = new TArray<AActor>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Actors.CopyAssign(value);
			}
		}

		// Token: 0x1700340B RID: 13323
		// (get) Token: 0x0602020C RID: 131596 RVA: 0x00922F24 File Offset: 0x00921124
		// (set) Token: 0x0602020D RID: 131597 RVA: 0x00922F67 File Offset: 0x00921167
		public TArray<AActor> HideActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._HideActors) == null)
				{
					result = (this._HideActors = new TArray<AActor>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HideActors.CopyAssign(value);
			}
		}

		// Token: 0x1700340C RID: 13324
		// (get) Token: 0x0602020E RID: 131598 RVA: 0x00922F78 File Offset: 0x00921178
		// (set) Token: 0x0602020F RID: 131599 RVA: 0x00922FBB File Offset: 0x009211BB
		public TMap<EKuroSceneInteractionState, EKuroSceneInteractionState> TransitionMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<EKuroSceneInteractionState, EKuroSceneInteractionState> result;
				if ((result = this._TransitionMap) == null)
				{
					result = (this._TransitionMap = new TMap<EKuroSceneInteractionState, EKuroSceneInteractionState>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.TransitionMap.CopyAssign(value);
			}
		}

		// Token: 0x1700340D RID: 13325
		// (get) Token: 0x06020210 RID: 131600 RVA: 0x00922FCC File Offset: 0x009211CC
		// (set) Token: 0x06020211 RID: 131601 RVA: 0x0092300F File Offset: 0x0092120F
		public TArray<SSceneInteractionMaterialController> MaterialControllers
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSceneInteractionMaterialController> result;
				if ((result = this._MaterialControllers) == null)
				{
					result = (this._MaterialControllers = new TArray<SSceneInteractionMaterialController>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MaterialControllers.CopyAssign(value);
			}
		}

		// Token: 0x1700340E RID: 13326
		// (get) Token: 0x06020212 RID: 131602 RVA: 0x00923020 File Offset: 0x00921220
		// (set) Token: 0x06020213 RID: 131603 RVA: 0x00923063 File Offset: 0x00921263
		public SSceneInteractionAudio AkEvent
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionAudio result;
				if ((result = this._AkEvent) == null)
				{
					result = (this._AkEvent = new SSceneInteractionAudio(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionAudio.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700340F RID: 13327
		// (get) Token: 0x06020214 RID: 131604 RVA: 0x00923084 File Offset: 0x00921284
		// (set) Token: 0x06020215 RID: 131605 RVA: 0x009230C7 File Offset: 0x009212C7
		public TArray<SStateBasedEffect> StateBasedEffect
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SStateBasedEffect> result;
				if ((result = this._StateBasedEffect) == null)
				{
					result = (this._StateBasedEffect = new TArray<SStateBasedEffect>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.StateBasedEffect.CopyAssign(value);
			}
		}

		// Token: 0x17003410 RID: 13328
		// (get) Token: 0x06020216 RID: 131606 RVA: 0x009230D5 File Offset: 0x009212D5
		// (set) Token: 0x06020217 RID: 131607 RVA: 0x009230E5 File Offset: 0x009212E5
		public unsafe bool IsForceSetState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003411 RID: 13329
		// (get) Token: 0x06020218 RID: 131608 RVA: 0x009230F6 File Offset: 0x009212F6
		// (set) Token: 0x06020219 RID: 131609 RVA: 0x0092310A File Offset: 0x0092130A
		[Nullable(2)]
		public unsafe PD_CharacterControllerDataGroup_C CharacterDataGroupForOrgan
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionitem.__PropertyOffset_11);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionitem.__PropertyOffset_11, value);
			}
		}

		// Token: 0x17003412 RID: 13330
		// (get) Token: 0x0602021A RID: 131610 RVA: 0x00923120 File Offset: 0x00921320
		// (set) Token: 0x0602021B RID: 131611 RVA: 0x00923163 File Offset: 0x00921363
		public TArray<SSceneInteractionitemIndestructibleEffectsParameters> IndestructibleEffectsParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSceneInteractionitemIndestructibleEffectsParameters> result;
				if ((result = this._IndestructibleEffectsParameters) == null)
				{
					result = (this._IndestructibleEffectsParameters = new TArray<SSceneInteractionitemIndestructibleEffectsParameters>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IndestructibleEffectsParameters.CopyAssign(value);
			}
		}

		// Token: 0x17003413 RID: 13331
		// (get) Token: 0x0602021C RID: 131612 RVA: 0x00923174 File Offset: 0x00921374
		// (set) Token: 0x0602021D RID: 131613 RVA: 0x009231B7 File Offset: 0x009213B7
		public TArray<SSceneInteractionCrossStateEffect> CrossStateEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSceneInteractionCrossStateEffect> result;
				if ((result = this._CrossStateEffects) == null)
				{
					result = (this._CrossStateEffects = new TArray<SSceneInteractionCrossStateEffect>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CrossStateEffects.CopyAssign(value);
			}
		}

		// Token: 0x17003414 RID: 13332
		// (get) Token: 0x0602021E RID: 131614 RVA: 0x009231C5 File Offset: 0x009213C5
		// (set) Token: 0x0602021F RID: 131615 RVA: 0x009231D5 File Offset: 0x009213D5
		public unsafe float TransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17003415 RID: 13333
		// (get) Token: 0x06020220 RID: 131616 RVA: 0x009231E6 File Offset: 0x009213E6
		// (set) Token: 0x06020221 RID: 131617 RVA: 0x009231F6 File Offset: 0x009213F6
		public unsafe bool NeedExpressionAnyway
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003416 RID: 13334
		// (get) Token: 0x06020222 RID: 131618 RVA: 0x00923207 File Offset: 0x00921407
		// (set) Token: 0x06020223 RID: 131619 RVA: 0x0092321B File Offset: 0x0092141B
		[Nullable(2)]
		public unsafe BP_MaterialRuntimeParUpdate_C BP_MaterialRuntimeParUpdate
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_MaterialRuntimeParUpdate_C>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionitem.__PropertyOffset_16);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionitem.__PropertyOffset_16, value);
			}
		}

		// Token: 0x17003417 RID: 13335
		// (get) Token: 0x06020224 RID: 131620 RVA: 0x00923230 File Offset: 0x00921430
		// (set) Token: 0x06020225 RID: 131621 RVA: 0x00923273 File Offset: 0x00921473
		public SSceneInteractionActorSkeletalMeshDestructible SkeletalMeshDestructible
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionActorSkeletalMeshDestructible result;
				if ((result = this._SkeletalMeshDestructible) == null)
				{
					result = (this._SkeletalMeshDestructible = new SSceneInteractionActorSkeletalMeshDestructible(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_17, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionActorSkeletalMeshDestructible.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_17, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003418 RID: 13336
		// (get) Token: 0x06020226 RID: 131622 RVA: 0x00923294 File Offset: 0x00921494
		// (set) Token: 0x06020227 RID: 131623 RVA: 0x009232D7 File Offset: 0x009214D7
		public TMap<AActor, FCollisionProfileName> EnterStateActorCollisionProfile
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FCollisionProfileName> result;
				if ((result = this._EnterStateActorCollisionProfile) == null)
				{
					result = (this._EnterStateActorCollisionProfile = new TMap<AActor, FCollisionProfileName>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_18, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EnterStateActorCollisionProfile.CopyAssign(value);
			}
		}

		// Token: 0x17003419 RID: 13337
		// (get) Token: 0x06020228 RID: 131624 RVA: 0x009232E8 File Offset: 0x009214E8
		// (set) Token: 0x06020229 RID: 131625 RVA: 0x0092332B File Offset: 0x0092152B
		public TMap<AActor, FCollisionProfileName> ExitStateActorCollisionProfile
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FCollisionProfileName> result;
				if ((result = this._ExitStateActorCollisionProfile) == null)
				{
					result = (this._ExitStateActorCollisionProfile = new TMap<AActor, FCollisionProfileName>(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_19, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ExitStateActorCollisionProfile.CopyAssign(value);
			}
		}

		// Token: 0x1700341A RID: 13338
		// (get) Token: 0x0602022A RID: 131626 RVA: 0x00923339 File Offset: 0x00921539
		// (set) Token: 0x0602022B RID: 131627 RVA: 0x00923349 File Offset: 0x00921549
		public unsafe bool WaitForPlayableFinished
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_20) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionitem.__PropertyOffset_20) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602022C RID: 131628 RVA: 0x0092335A File Offset: 0x0092155A
		public SSceneInteractionitem()
		{
		}

		// Token: 0x0602022D RID: 131629 RVA: 0x00923364 File Offset: 0x00921564
		public SSceneInteractionitem(string Name, SSceneInteractionSequence Sequence, SSceneInteractionMontage AnimMontage, TArray<BP_EffectActor_C> Effects, TArray<AActor> Actors, TArray<AActor> HideActors, TMap<EKuroSceneInteractionState, EKuroSceneInteractionState> TransitionMap, TArray<SSceneInteractionMaterialController> MaterialControllers, SSceneInteractionAudio AkEvent, TArray<SStateBasedEffect> StateBasedEffect, bool IsForceSetState, PD_CharacterControllerDataGroup_C CharacterDataGroupForOrgan, TArray<SSceneInteractionitemIndestructibleEffectsParameters> IndestructibleEffectsParameters, TArray<SSceneInteractionCrossStateEffect> CrossStateEffects, float TransitionTime, bool NeedExpressionAnyway, BP_MaterialRuntimeParUpdate_C BP_MaterialRuntimeParUpdate, SSceneInteractionActorSkeletalMeshDestructible SkeletalMeshDestructible, TMap<AActor, FCollisionProfileName> EnterStateActorCollisionProfile, TMap<AActor, FCollisionProfileName> ExitStateActorCollisionProfile, bool WaitForPlayableFinished)
		{
			this.Name = Name;
			this.Sequence = Sequence;
			this.AnimMontage = AnimMontage;
			this.Effects = Effects;
			this.Actors = Actors;
			this.HideActors = HideActors;
			this.TransitionMap = TransitionMap;
			this.MaterialControllers = MaterialControllers;
			this.AkEvent = AkEvent;
			this.StateBasedEffect = StateBasedEffect;
			this.IsForceSetState = IsForceSetState;
			this.CharacterDataGroupForOrgan = CharacterDataGroupForOrgan;
			this.IndestructibleEffectsParameters = IndestructibleEffectsParameters;
			this.CrossStateEffects = CrossStateEffects;
			this.TransitionTime = TransitionTime;
			this.NeedExpressionAnyway = NeedExpressionAnyway;
			this.BP_MaterialRuntimeParUpdate = BP_MaterialRuntimeParUpdate;
			this.SkeletalMeshDestructible = SkeletalMeshDestructible;
			this.EnterStateActorCollisionProfile = EnterStateActorCollisionProfile;
			this.ExitStateActorCollisionProfile = ExitStateActorCollisionProfile;
			this.WaitForPlayableFinished = WaitForPlayableFinished;
		}

		// Token: 0x0602022E RID: 131630 RVA: 0x0092341C File Offset: 0x0092161C
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionitem.StaticStruct();
		}

		// Token: 0x0602022F RID: 131631 RVA: 0x00923428 File Offset: 0x00921628
		[NullableContext(2)]
		public SSceneInteractionitem(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06020230 RID: 131632 RVA: 0x00923432 File Offset: 0x00921632
		public SSceneInteractionitem(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06020231 RID: 131633 RVA: 0x0092343D File Offset: 0x0092163D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionitem(Pointer, false, true);
		}

		// Token: 0x06020232 RID: 131634 RVA: 0x00923447 File Offset: 0x00921647
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionitem(Pointer, MemoryOwner);
		}

		// Token: 0x04010024 RID: 65572
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionitem.SSceneInteractionitem";

		// Token: 0x04010025 RID: 65573
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010026 RID: 65574
		internal static int __PropertyOffset_0;

		// Token: 0x04010027 RID: 65575
		internal static int __PropertyOffset_1;

		// Token: 0x04010028 RID: 65576
		[Nullable(2)]
		private SSceneInteractionSequence _Sequence;

		// Token: 0x04010029 RID: 65577
		internal static int __PropertyOffset_2;

		// Token: 0x0401002A RID: 65578
		[Nullable(2)]
		private SSceneInteractionMontage _AnimMontage;

		// Token: 0x0401002B RID: 65579
		internal static int __PropertyOffset_3;

		// Token: 0x0401002C RID: 65580
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _Effects;

		// Token: 0x0401002D RID: 65581
		internal static int __PropertyOffset_4;

		// Token: 0x0401002E RID: 65582
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Actors;

		// Token: 0x0401002F RID: 65583
		internal static int __PropertyOffset_5;

		// Token: 0x04010030 RID: 65584
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _HideActors;

		// Token: 0x04010031 RID: 65585
		internal static int __PropertyOffset_6;

		// Token: 0x04010032 RID: 65586
		[Nullable(2)]
		private TMap<EKuroSceneInteractionState, EKuroSceneInteractionState> _TransitionMap;

		// Token: 0x04010033 RID: 65587
		internal static int __PropertyOffset_7;

		// Token: 0x04010034 RID: 65588
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSceneInteractionMaterialController> _MaterialControllers;

		// Token: 0x04010035 RID: 65589
		internal static int __PropertyOffset_8;

		// Token: 0x04010036 RID: 65590
		[Nullable(2)]
		private SSceneInteractionAudio _AkEvent;

		// Token: 0x04010037 RID: 65591
		internal static int __PropertyOffset_9;

		// Token: 0x04010038 RID: 65592
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SStateBasedEffect> _StateBasedEffect;

		// Token: 0x04010039 RID: 65593
		internal static int __PropertyOffset_10;

		// Token: 0x0401003A RID: 65594
		internal static int __PropertyOffset_11;

		// Token: 0x0401003B RID: 65595
		internal static int __PropertyOffset_12;

		// Token: 0x0401003C RID: 65596
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSceneInteractionitemIndestructibleEffectsParameters> _IndestructibleEffectsParameters;

		// Token: 0x0401003D RID: 65597
		internal static int __PropertyOffset_13;

		// Token: 0x0401003E RID: 65598
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSceneInteractionCrossStateEffect> _CrossStateEffects;

		// Token: 0x0401003F RID: 65599
		internal static int __PropertyOffset_14;

		// Token: 0x04010040 RID: 65600
		internal static int __PropertyOffset_15;

		// Token: 0x04010041 RID: 65601
		internal static int __PropertyOffset_16;

		// Token: 0x04010042 RID: 65602
		internal static int __PropertyOffset_17;

		// Token: 0x04010043 RID: 65603
		[Nullable(2)]
		private SSceneInteractionActorSkeletalMeshDestructible _SkeletalMeshDestructible;

		// Token: 0x04010044 RID: 65604
		internal static int __PropertyOffset_18;

		// Token: 0x04010045 RID: 65605
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<AActor, FCollisionProfileName> _EnterStateActorCollisionProfile;

		// Token: 0x04010046 RID: 65606
		internal static int __PropertyOffset_19;

		// Token: 0x04010047 RID: 65607
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<AActor, FCollisionProfileName> _ExitStateActorCollisionProfile;

		// Token: 0x04010048 RID: 65608
		internal static int __PropertyOffset_20;
	}
}
