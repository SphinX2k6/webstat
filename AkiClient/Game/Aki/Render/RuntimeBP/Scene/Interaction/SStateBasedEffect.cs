using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003ACE RID: 15054
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SStateBasedEffect.SStateBasedEffect")]
	[UnrealStructLayout(8, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 8)]
	public class SStateBasedEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060202B1 RID: 131761 RVA: 0x0092412B File Offset: 0x0092232B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SStateBasedEffect._ScriptStructPtr != 0) ? SStateBasedEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SStateBasedEffect.SStateBasedEffect", ref SStateBasedEffect._ScriptStructPtr);
		}

		// Token: 0x1700343E RID: 13374
		// (get) Token: 0x060202B2 RID: 131762 RVA: 0x0092414F File Offset: 0x0092234F
		// (set) Token: 0x060202B3 RID: 131763 RVA: 0x00924163 File Offset: 0x00922363
		[Nullable(2)]
		public unsafe BP_StateMachineEffectBase_C StateBasedEffect
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_StateMachineEffectBase_C>(base.NativePtr / (IntPtr)sizeof(void*) + SStateBasedEffect.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SStateBasedEffect.__PropertyOffset_0, value);
			}
		}

		// Token: 0x060202B4 RID: 131764 RVA: 0x00924178 File Offset: 0x00922378
		public SStateBasedEffect()
		{
		}

		// Token: 0x060202B5 RID: 131765 RVA: 0x00924180 File Offset: 0x00922380
		[NullableContext(1)]
		public SStateBasedEffect(BP_StateMachineEffectBase_C StateBasedEffect)
		{
			this.StateBasedEffect = StateBasedEffect;
		}

		// Token: 0x060202B6 RID: 131766 RVA: 0x0092418F File Offset: 0x0092238F
		protected override IntPtr GetUStructPtr()
		{
			return SStateBasedEffect.StaticStruct();
		}

		// Token: 0x060202B7 RID: 131767 RVA: 0x0092419B File Offset: 0x0092239B
		[NullableContext(2)]
		public SStateBasedEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060202B8 RID: 131768 RVA: 0x009241A5 File Offset: 0x009223A5
		public SStateBasedEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060202B9 RID: 131769 RVA: 0x009241B0 File Offset: 0x009223B0
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SStateBasedEffect(Pointer, false, true);
		}

		// Token: 0x060202BA RID: 131770 RVA: 0x009241BA File Offset: 0x009223BA
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SStateBasedEffect(Pointer, MemoryOwner);
		}

		// Token: 0x0401008E RID: 65678
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SStateBasedEffect.SStateBasedEffect";

		// Token: 0x0401008F RID: 65679
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010090 RID: 65680
		internal static int __PropertyOffset_0;
	}
}
