using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Statistics
{
	// Token: 0x02003D29 RID: 15657
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Statistics/SEffectOutput.SEffectOutput")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SEffectOutput : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06025DF6 RID: 155126 RVA: 0x009C76EC File Offset: 0x009C58EC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectOutput._ScriptStructPtr != 0) ? SEffectOutput._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Effect/Statistics/SEffectOutput.SEffectOutput", ref SEffectOutput._ScriptStructPtr);
		}

		// Token: 0x17005430 RID: 21552
		// (get) Token: 0x06025DF7 RID: 155127 RVA: 0x009C7710 File Offset: 0x009C5910
		// (set) Token: 0x06025DF8 RID: 155128 RVA: 0x009C7724 File Offset: 0x009C5924
		public unsafe string Name
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SEffectOutput.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SEffectOutput.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005431 RID: 21553
		// (get) Token: 0x06025DF9 RID: 155129 RVA: 0x009C7739 File Offset: 0x009C5939
		// (set) Token: 0x06025DFA RID: 155130 RVA: 0x009C7749 File Offset: 0x009C5949
		public unsafe int MaxSystemNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005432 RID: 21554
		// (get) Token: 0x06025DFB RID: 155131 RVA: 0x009C775A File Offset: 0x009C595A
		// (set) Token: 0x06025DFC RID: 155132 RVA: 0x009C776A File Offset: 0x009C596A
		public unsafe int MaxParticleAverageNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005433 RID: 21555
		// (get) Token: 0x06025DFD RID: 155133 RVA: 0x009C777B File Offset: 0x009C597B
		// (set) Token: 0x06025DFE RID: 155134 RVA: 0x009C778B File Offset: 0x009C598B
		public unsafe int MaxParticleTotalNumber
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectOutput.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06025DFF RID: 155135 RVA: 0x009C779C File Offset: 0x009C599C
		public SEffectOutput()
		{
		}

		// Token: 0x06025E00 RID: 155136 RVA: 0x009C77A4 File Offset: 0x009C59A4
		public SEffectOutput(string Name, int MaxSystemNumber, int MaxParticleAverageNumber, int MaxParticleTotalNumber)
		{
			this.Name = Name;
			this.MaxSystemNumber = MaxSystemNumber;
			this.MaxParticleAverageNumber = MaxParticleAverageNumber;
			this.MaxParticleTotalNumber = MaxParticleTotalNumber;
		}

		// Token: 0x06025E01 RID: 155137 RVA: 0x009C77C9 File Offset: 0x009C59C9
		protected override IntPtr GetUStructPtr()
		{
			return SEffectOutput.StaticStruct();
		}

		// Token: 0x06025E02 RID: 155138 RVA: 0x009C77D5 File Offset: 0x009C59D5
		[NullableContext(2)]
		public SEffectOutput(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06025E03 RID: 155139 RVA: 0x009C77DF File Offset: 0x009C59DF
		public SEffectOutput(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06025E04 RID: 155140 RVA: 0x009C77EA File Offset: 0x009C59EA
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectOutput(Pointer, false, true);
		}

		// Token: 0x06025E05 RID: 155141 RVA: 0x009C77F4 File Offset: 0x009C59F4
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectOutput(Pointer, MemoryOwner);
		}

		// Token: 0x0401393F RID: 80191
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Statistics/SEffectOutput.SEffectOutput";

		// Token: 0x04013940 RID: 80192
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013941 RID: 80193
		internal static int __PropertyOffset_0;

		// Token: 0x04013942 RID: 80194
		internal static int __PropertyOffset_1;

		// Token: 0x04013943 RID: 80195
		internal static int __PropertyOffset_2;

		// Token: 0x04013944 RID: 80196
		internal static int __PropertyOffset_3;
	}
}
