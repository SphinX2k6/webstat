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
	// Token: 0x02003ACC RID: 15052
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionTags.SSceneInteractionTags")]
	[UnrealStructLayout(384, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 384)]
	public class SSceneInteractionTags : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602027F RID: 131711 RVA: 0x00923A4D File Offset: 0x00921C4D
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionTags._ScriptStructPtr != 0) ? SSceneInteractionTags._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionTags.SSceneInteractionTags", ref SSceneInteractionTags._ScriptStructPtr);
		}

		// Token: 0x1700342D RID: 13357
		// (get) Token: 0x06020280 RID: 131712 RVA: 0x00923A74 File Offset: 0x00921C74
		// (set) Token: 0x06020281 RID: 131713 RVA: 0x00923AB7 File Offset: 0x00921CB7
		public TArray<BP_EffectActor_C> Effects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._Effects) == null)
				{
					result = (this._Effects = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Effects.CopyAssign(value);
			}
		}

		// Token: 0x1700342E RID: 13358
		// (get) Token: 0x06020282 RID: 131714 RVA: 0x00923AC8 File Offset: 0x00921CC8
		// (set) Token: 0x06020283 RID: 131715 RVA: 0x00923B0B File Offset: 0x00921D0B
		public TArray<AActor> Actors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._Actors) == null)
				{
					result = (this._Actors = new TArray<AActor>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Actors.CopyAssign(value);
			}
		}

		// Token: 0x1700342F RID: 13359
		// (get) Token: 0x06020284 RID: 131716 RVA: 0x00923B1C File Offset: 0x00921D1C
		// (set) Token: 0x06020285 RID: 131717 RVA: 0x00923B5F File Offset: 0x00921D5F
		public TArray<AActor> HideActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._HideActors) == null)
				{
					result = (this._HideActors = new TArray<AActor>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.HideActors.CopyAssign(value);
			}
		}

		// Token: 0x17003430 RID: 13360
		// (get) Token: 0x06020286 RID: 131718 RVA: 0x00923B70 File Offset: 0x00921D70
		// (set) Token: 0x06020287 RID: 131719 RVA: 0x00923BB3 File Offset: 0x00921DB3
		public TArray<SSceneInteractionMaterialController> MaterialControllers
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSceneInteractionMaterialController> result;
				if ((result = this._MaterialControllers) == null)
				{
					result = (this._MaterialControllers = new TArray<SSceneInteractionMaterialController>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.MaterialControllers.CopyAssign(value);
			}
		}

		// Token: 0x17003431 RID: 13361
		// (get) Token: 0x06020288 RID: 131720 RVA: 0x00923BC4 File Offset: 0x00921DC4
		// (set) Token: 0x06020289 RID: 131721 RVA: 0x00923C07 File Offset: 0x00921E07
		public TArray<SSceneInteractionitemIndestructibleEffectsParameters> IndestructibleEffectsParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SSceneInteractionitemIndestructibleEffectsParameters> result;
				if ((result = this._IndestructibleEffectsParameters) == null)
				{
					result = (this._IndestructibleEffectsParameters = new TArray<SSceneInteractionitemIndestructibleEffectsParameters>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.IndestructibleEffectsParameters.CopyAssign(value);
			}
		}

		// Token: 0x17003432 RID: 13362
		// (get) Token: 0x0602028A RID: 131722 RVA: 0x00923C18 File Offset: 0x00921E18
		// (set) Token: 0x0602028B RID: 131723 RVA: 0x00923C5B File Offset: 0x00921E5B
		public TArray<BP_EffectActor_C> SpecilEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._SpecilEffects) == null)
				{
					result = (this._SpecilEffects = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SpecilEffects.CopyAssign(value);
			}
		}

		// Token: 0x17003433 RID: 13363
		// (get) Token: 0x0602028C RID: 131724 RVA: 0x00923C6C File Offset: 0x00921E6C
		// (set) Token: 0x0602028D RID: 131725 RVA: 0x00923CAF File Offset: 0x00921EAF
		public SSceneInteractionSequence Sequence
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionSequence result;
				if ((result = this._Sequence) == null)
				{
					result = (this._Sequence = new SSceneInteractionSequence(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionSequence.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_6, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003434 RID: 13364
		// (get) Token: 0x0602028E RID: 131726 RVA: 0x00923CD0 File Offset: 0x00921ED0
		// (set) Token: 0x0602028F RID: 131727 RVA: 0x00923D13 File Offset: 0x00921F13
		public TArray<BP_EffectActor_C> EndEffects
		{
			get
			{
				base.FastCheckIsValid();
				TArray<BP_EffectActor_C> result;
				if ((result = this._EndEffects) == null)
				{
					result = (this._EndEffects = new TArray<BP_EffectActor_C>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_7, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.EndEffects.CopyAssign(value);
			}
		}

		// Token: 0x17003435 RID: 13365
		// (get) Token: 0x06020290 RID: 131728 RVA: 0x00923D24 File Offset: 0x00921F24
		// (set) Token: 0x06020291 RID: 131729 RVA: 0x00923D67 File Offset: 0x00921F67
		public SSceneInteractionAudio AkEvent
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionAudio result;
				if ((result = this._AkEvent) == null)
				{
					result = (this._AkEvent = new SSceneInteractionAudio(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionAudio.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003436 RID: 13366
		// (get) Token: 0x06020292 RID: 131730 RVA: 0x00923D88 File Offset: 0x00921F88
		// (set) Token: 0x06020293 RID: 131731 RVA: 0x00923DCB File Offset: 0x00921FCB
		public TArray<ADestructibleActor> DestructibleActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ADestructibleActor> result;
				if ((result = this._DestructibleActors) == null)
				{
					result = (this._DestructibleActors = new TArray<ADestructibleActor>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.DestructibleActors.CopyAssign(value);
			}
		}

		// Token: 0x17003437 RID: 13367
		// (get) Token: 0x06020294 RID: 131732 RVA: 0x00923DDC File Offset: 0x00921FDC
		// (set) Token: 0x06020295 RID: 131733 RVA: 0x00923E1F File Offset: 0x0092201F
		public TArray<AKuroDestructibleActor> SkeletalMeshDestructibleActors
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AKuroDestructibleActor> result;
				if ((result = this._SkeletalMeshDestructibleActors) == null)
				{
					result = (this._SkeletalMeshDestructibleActors = new TArray<AKuroDestructibleActor>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.SkeletalMeshDestructibleActors.CopyAssign(value);
			}
		}

		// Token: 0x17003438 RID: 13368
		// (get) Token: 0x06020296 RID: 131734 RVA: 0x00923E30 File Offset: 0x00922030
		// (set) Token: 0x06020297 RID: 131735 RVA: 0x00923E73 File Offset: 0x00922073
		public SSceneInteractionDestructibleInfo HitInfo
		{
			get
			{
				base.FastCheckIsValid();
				SSceneInteractionDestructibleInfo result;
				if ((result = this._HitInfo) == null)
				{
					result = (this._HitInfo = new SSceneInteractionDestructibleInfo(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSceneInteractionDestructibleInfo.StaticStruct(), base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003439 RID: 13369
		// (get) Token: 0x06020298 RID: 131736 RVA: 0x00923E94 File Offset: 0x00922094
		// (set) Token: 0x06020299 RID: 131737 RVA: 0x00923ED7 File Offset: 0x009220D7
		public TMap<AActor, FCollisionProfileName> AddTagActorCollisionProfile
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FCollisionProfileName> result;
				if ((result = this._AddTagActorCollisionProfile) == null)
				{
					result = (this._AddTagActorCollisionProfile = new TMap<AActor, FCollisionProfileName>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.AddTagActorCollisionProfile.CopyAssign(value);
			}
		}

		// Token: 0x1700343A RID: 13370
		// (get) Token: 0x0602029A RID: 131738 RVA: 0x00923EE8 File Offset: 0x009220E8
		// (set) Token: 0x0602029B RID: 131739 RVA: 0x00923F2B File Offset: 0x0092212B
		public TMap<AActor, FCollisionProfileName> RemoveTagActorCollisionProfile
		{
			get
			{
				base.FastCheckIsValid();
				TMap<AActor, FCollisionProfileName> result;
				if ((result = this._RemoveTagActorCollisionProfile) == null)
				{
					result = (this._RemoveTagActorCollisionProfile = new TMap<AActor, FCollisionProfileName>(base.NativePtr + (IntPtr)SSceneInteractionTags.__PropertyOffset_13, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.RemoveTagActorCollisionProfile.CopyAssign(value);
			}
		}

		// Token: 0x1700343B RID: 13371
		// (get) Token: 0x0602029C RID: 131740 RVA: 0x00923F39 File Offset: 0x00922139
		// (set) Token: 0x0602029D RID: 131741 RVA: 0x00923F4D File Offset: 0x0092214D
		[Nullable(2)]
		public unsafe PD_CharacterControllerDataGroup_C CharacterDataGroupForOrgan
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_CharacterControllerDataGroup_C>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionTags.__PropertyOffset_14);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionTags.__PropertyOffset_14, value);
			}
		}

		// Token: 0x0602029E RID: 131742 RVA: 0x00923F62 File Offset: 0x00922162
		public SSceneInteractionTags()
		{
		}

		// Token: 0x0602029F RID: 131743 RVA: 0x00923F6C File Offset: 0x0092216C
		public SSceneInteractionTags(TArray<BP_EffectActor_C> Effects, TArray<AActor> Actors, TArray<AActor> HideActors, TArray<SSceneInteractionMaterialController> MaterialControllers, TArray<SSceneInteractionitemIndestructibleEffectsParameters> IndestructibleEffectsParameters, TArray<BP_EffectActor_C> SpecilEffects, SSceneInteractionSequence Sequence, TArray<BP_EffectActor_C> EndEffects, SSceneInteractionAudio AkEvent, TArray<ADestructibleActor> DestructibleActors, TArray<AKuroDestructibleActor> SkeletalMeshDestructibleActors, SSceneInteractionDestructibleInfo HitInfo, TMap<AActor, FCollisionProfileName> AddTagActorCollisionProfile, TMap<AActor, FCollisionProfileName> RemoveTagActorCollisionProfile, PD_CharacterControllerDataGroup_C CharacterDataGroupForOrgan)
		{
			this.Effects = Effects;
			this.Actors = Actors;
			this.HideActors = HideActors;
			this.MaterialControllers = MaterialControllers;
			this.IndestructibleEffectsParameters = IndestructibleEffectsParameters;
			this.SpecilEffects = SpecilEffects;
			this.Sequence = Sequence;
			this.EndEffects = EndEffects;
			this.AkEvent = AkEvent;
			this.DestructibleActors = DestructibleActors;
			this.SkeletalMeshDestructibleActors = SkeletalMeshDestructibleActors;
			this.HitInfo = HitInfo;
			this.AddTagActorCollisionProfile = AddTagActorCollisionProfile;
			this.RemoveTagActorCollisionProfile = RemoveTagActorCollisionProfile;
			this.CharacterDataGroupForOrgan = CharacterDataGroupForOrgan;
		}

		// Token: 0x060202A0 RID: 131744 RVA: 0x00923FF4 File Offset: 0x009221F4
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionTags.StaticStruct();
		}

		// Token: 0x060202A1 RID: 131745 RVA: 0x00924000 File Offset: 0x00922200
		[NullableContext(2)]
		public SSceneInteractionTags(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060202A2 RID: 131746 RVA: 0x0092400A File Offset: 0x0092220A
		public SSceneInteractionTags(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060202A3 RID: 131747 RVA: 0x00924015 File Offset: 0x00922215
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionTags(Pointer, false, true);
		}

		// Token: 0x060202A4 RID: 131748 RVA: 0x0092401F File Offset: 0x0092221F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionTags(Pointer, MemoryOwner);
		}

		// Token: 0x0401006A RID: 65642
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionTags.SSceneInteractionTags";

		// Token: 0x0401006B RID: 65643
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401006C RID: 65644
		internal static int __PropertyOffset_0;

		// Token: 0x0401006D RID: 65645
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _Effects;

		// Token: 0x0401006E RID: 65646
		internal static int __PropertyOffset_1;

		// Token: 0x0401006F RID: 65647
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _Actors;

		// Token: 0x04010070 RID: 65648
		internal static int __PropertyOffset_2;

		// Token: 0x04010071 RID: 65649
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _HideActors;

		// Token: 0x04010072 RID: 65650
		internal static int __PropertyOffset_3;

		// Token: 0x04010073 RID: 65651
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSceneInteractionMaterialController> _MaterialControllers;

		// Token: 0x04010074 RID: 65652
		internal static int __PropertyOffset_4;

		// Token: 0x04010075 RID: 65653
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SSceneInteractionitemIndestructibleEffectsParameters> _IndestructibleEffectsParameters;

		// Token: 0x04010076 RID: 65654
		internal static int __PropertyOffset_5;

		// Token: 0x04010077 RID: 65655
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _SpecilEffects;

		// Token: 0x04010078 RID: 65656
		internal static int __PropertyOffset_6;

		// Token: 0x04010079 RID: 65657
		[Nullable(2)]
		private SSceneInteractionSequence _Sequence;

		// Token: 0x0401007A RID: 65658
		internal static int __PropertyOffset_7;

		// Token: 0x0401007B RID: 65659
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<BP_EffectActor_C> _EndEffects;

		// Token: 0x0401007C RID: 65660
		internal static int __PropertyOffset_8;

		// Token: 0x0401007D RID: 65661
		[Nullable(2)]
		private SSceneInteractionAudio _AkEvent;

		// Token: 0x0401007E RID: 65662
		internal static int __PropertyOffset_9;

		// Token: 0x0401007F RID: 65663
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ADestructibleActor> _DestructibleActors;

		// Token: 0x04010080 RID: 65664
		internal static int __PropertyOffset_10;

		// Token: 0x04010081 RID: 65665
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AKuroDestructibleActor> _SkeletalMeshDestructibleActors;

		// Token: 0x04010082 RID: 65666
		internal static int __PropertyOffset_11;

		// Token: 0x04010083 RID: 65667
		[Nullable(2)]
		private SSceneInteractionDestructibleInfo _HitInfo;

		// Token: 0x04010084 RID: 65668
		internal static int __PropertyOffset_12;

		// Token: 0x04010085 RID: 65669
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<AActor, FCollisionProfileName> _AddTagActorCollisionProfile;

		// Token: 0x04010086 RID: 65670
		internal static int __PropertyOffset_13;

		// Token: 0x04010087 RID: 65671
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<AActor, FCollisionProfileName> _RemoveTagActorCollisionProfile;

		// Token: 0x04010088 RID: 65672
		internal static int __PropertyOffset_14;
	}
}
