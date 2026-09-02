using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC4 RID: 15044
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionCrossStateEffect.SSceneInteractionCrossStateEffect")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 12)]
	public class SSceneInteractionCrossStateEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201E9 RID: 131561 RVA: 0x00922BA1 File Offset: 0x00920DA1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSceneInteractionCrossStateEffect._ScriptStructPtr != 0) ? SSceneInteractionCrossStateEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionCrossStateEffect.SSceneInteractionCrossStateEffect", ref SSceneInteractionCrossStateEffect._ScriptStructPtr);
		}

		// Token: 0x17003402 RID: 13314
		// (get) Token: 0x060201EA RID: 131562 RVA: 0x00922BC5 File Offset: 0x00920DC5
		// (set) Token: 0x060201EB RID: 131563 RVA: 0x00922BD9 File Offset: 0x00920DD9
		[Nullable(2)]
		public unsafe BP_EffectActor_C Effect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_EffectActor_C>(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionCrossStateEffect.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSceneInteractionCrossStateEffect.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003403 RID: 13315
		// (get) Token: 0x060201EC RID: 131564 RVA: 0x00922BEE File Offset: 0x00920DEE
		// (set) Token: 0x060201ED RID: 131565 RVA: 0x00922BFE File Offset: 0x00920DFE
		public unsafe int EffectExtraState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSceneInteractionCrossStateEffect.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSceneInteractionCrossStateEffect.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060201EE RID: 131566 RVA: 0x00922C0F File Offset: 0x00920E0F
		public SSceneInteractionCrossStateEffect()
		{
		}

		// Token: 0x060201EF RID: 131567 RVA: 0x00922C17 File Offset: 0x00920E17
		[NullableContext(1)]
		public SSceneInteractionCrossStateEffect(BP_EffectActor_C Effect, int EffectExtraState)
		{
			this.Effect = Effect;
			this.EffectExtraState = EffectExtraState;
		}

		// Token: 0x060201F0 RID: 131568 RVA: 0x00922C2D File Offset: 0x00920E2D
		protected override IntPtr GetUStructPtr()
		{
			return SSceneInteractionCrossStateEffect.StaticStruct();
		}

		// Token: 0x060201F1 RID: 131569 RVA: 0x00922C39 File Offset: 0x00920E39
		[NullableContext(2)]
		public SSceneInteractionCrossStateEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201F2 RID: 131570 RVA: 0x00922C43 File Offset: 0x00920E43
		public SSceneInteractionCrossStateEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201F3 RID: 131571 RVA: 0x00922C4E File Offset: 0x00920E4E
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSceneInteractionCrossStateEffect(Pointer, false, true);
		}

		// Token: 0x060201F4 RID: 131572 RVA: 0x00922C58 File Offset: 0x00920E58
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSceneInteractionCrossStateEffect(Pointer, MemoryOwner);
		}

		// Token: 0x0401001B RID: 65563
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SSceneInteractionCrossStateEffect.SSceneInteractionCrossStateEffect";

		// Token: 0x0401001C RID: 65564
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401001D RID: 65565
		internal static int __PropertyOffset_0;

		// Token: 0x0401001E RID: 65566
		internal static int __PropertyOffset_1;
	}
}
