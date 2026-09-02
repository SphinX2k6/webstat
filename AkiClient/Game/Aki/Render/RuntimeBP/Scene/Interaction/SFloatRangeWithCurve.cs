using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Interaction
{
	// Token: 0x02003AC0 RID: 15040
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SFloatRangeWithCurve.SFloatRangeWithCurve")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SFloatRangeWithCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060201A9 RID: 131497 RVA: 0x00922658 File Offset: 0x00920858
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatRangeWithCurve._ScriptStructPtr != 0) ? SFloatRangeWithCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Interaction/SFloatRangeWithCurve.SFloatRangeWithCurve", ref SFloatRangeWithCurve._ScriptStructPtr);
		}

		// Token: 0x170033F2 RID: 13298
		// (get) Token: 0x060201AA RID: 131498 RVA: 0x0092267C File Offset: 0x0092087C
		// (set) Token: 0x060201AB RID: 131499 RVA: 0x0092268C File Offset: 0x0092088C
		public unsafe float FromMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170033F3 RID: 13299
		// (get) Token: 0x060201AC RID: 131500 RVA: 0x0092269D File Offset: 0x0092089D
		// (set) Token: 0x060201AD RID: 131501 RVA: 0x009226AD File Offset: 0x009208AD
		public unsafe float FromMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170033F4 RID: 13300
		// (get) Token: 0x060201AE RID: 131502 RVA: 0x009226BE File Offset: 0x009208BE
		// (set) Token: 0x060201AF RID: 131503 RVA: 0x009226CE File Offset: 0x009208CE
		public unsafe float ToMin
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170033F5 RID: 13301
		// (get) Token: 0x060201B0 RID: 131504 RVA: 0x009226DF File Offset: 0x009208DF
		// (set) Token: 0x060201B1 RID: 131505 RVA: 0x009226EF File Offset: 0x009208EF
		public unsafe float ToMax
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170033F6 RID: 13302
		// (get) Token: 0x060201B2 RID: 131506 RVA: 0x00922700 File Offset: 0x00920900
		// (set) Token: 0x060201B3 RID: 131507 RVA: 0x00922710 File Offset: 0x00920910
		public unsafe ECurveSourceType SourceType
		{
			get
			{
				return (ECurveSourceType)(*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_4));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_4) = (byte)value;
			}
		}

		// Token: 0x170033F7 RID: 13303
		// (get) Token: 0x060201B4 RID: 131508 RVA: 0x00922721 File Offset: 0x00920921
		// (set) Token: 0x060201B5 RID: 131509 RVA: 0x00922731 File Offset: 0x00920931
		public unsafe EEasingType EasingType
		{
			get
			{
				return (EEasingType)(*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_5));
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatRangeWithCurve.__PropertyOffset_5) = (byte)value;
			}
		}

		// Token: 0x170033F8 RID: 13304
		// (get) Token: 0x060201B6 RID: 131510 RVA: 0x00922742 File Offset: 0x00920942
		// (set) Token: 0x060201B7 RID: 131511 RVA: 0x00922756 File Offset: 0x00920956
		[Nullable(2)]
		public unsafe UCurveFloat CurveFloat
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + SFloatRangeWithCurve.__PropertyOffset_6);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFloatRangeWithCurve.__PropertyOffset_6, value);
			}
		}

		// Token: 0x060201B8 RID: 131512 RVA: 0x0092276B File Offset: 0x0092096B
		public SFloatRangeWithCurve()
		{
		}

		// Token: 0x060201B9 RID: 131513 RVA: 0x00922773 File Offset: 0x00920973
		[NullableContext(1)]
		public SFloatRangeWithCurve(float FromMin, float FromMax, float ToMin, float ToMax, ECurveSourceType SourceType, EEasingType EasingType, UCurveFloat CurveFloat)
		{
			this.FromMin = FromMin;
			this.FromMax = FromMax;
			this.ToMin = ToMin;
			this.ToMax = ToMax;
			this.SourceType = SourceType;
			this.EasingType = EasingType;
			this.CurveFloat = CurveFloat;
		}

		// Token: 0x060201BA RID: 131514 RVA: 0x009227B0 File Offset: 0x009209B0
		protected override IntPtr GetUStructPtr()
		{
			return SFloatRangeWithCurve.StaticStruct();
		}

		// Token: 0x060201BB RID: 131515 RVA: 0x009227BC File Offset: 0x009209BC
		[NullableContext(2)]
		public SFloatRangeWithCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060201BC RID: 131516 RVA: 0x009227C6 File Offset: 0x009209C6
		public SFloatRangeWithCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060201BD RID: 131517 RVA: 0x009227D1 File Offset: 0x009209D1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFloatRangeWithCurve(Pointer, false, true);
		}

		// Token: 0x060201BE RID: 131518 RVA: 0x009227DB File Offset: 0x009209DB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFloatRangeWithCurve(Pointer, MemoryOwner);
		}

		// Token: 0x0400FFFE RID: 65534
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Interaction/SFloatRangeWithCurve.SFloatRangeWithCurve";

		// Token: 0x0400FFFF RID: 65535
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010000 RID: 65536
		internal static int __PropertyOffset_0;

		// Token: 0x04010001 RID: 65537
		internal static int __PropertyOffset_1;

		// Token: 0x04010002 RID: 65538
		internal static int __PropertyOffset_2;

		// Token: 0x04010003 RID: 65539
		internal static int __PropertyOffset_3;

		// Token: 0x04010004 RID: 65540
		internal static int __PropertyOffset_4;

		// Token: 0x04010005 RID: 65541
		internal static int __PropertyOffset_5;

		// Token: 0x04010006 RID: 65542
		internal static int __PropertyOffset_6;
	}
}
