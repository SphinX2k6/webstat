using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F78 RID: 16248
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Core/Fight/SReBulletDataScale.SReBulletDataScale")]
	[UnrealStructLayout(32, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 25)]
	public class SReBulletDataScale : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060289E7 RID: 166375 RVA: 0x00A10834 File Offset: 0x00A0EA34
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SReBulletDataScale._ScriptStructPtr != 0) ? SReBulletDataScale._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Core/Fight/SReBulletDataScale.SReBulletDataScale", ref SReBulletDataScale._ScriptStructPtr);
		}

		// Token: 0x17006334 RID: 25396
		// (get) Token: 0x060289E8 RID: 166376 RVA: 0x00A10858 File Offset: 0x00A0EA58
		// (set) Token: 0x060289E9 RID: 166377 RVA: 0x00A1086C File Offset: 0x00A0EA6C
		public unsafe FVector 缩放倍率
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataScale.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataScale.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006335 RID: 25397
		// (get) Token: 0x060289EA RID: 166378 RVA: 0x00A10881 File Offset: 0x00A0EA81
		// (set) Token: 0x060289EB RID: 166379 RVA: 0x00A10895 File Offset: 0x00A0EA95
		[Nullable(2)]
		public unsafe UCurveVector 缩放倍率曲线
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCurveVector>(base.NativePtr / (IntPtr)sizeof(void*) + SReBulletDataScale.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SReBulletDataScale.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006336 RID: 25398
		// (get) Token: 0x060289EC RID: 166380 RVA: 0x00A108AA File Offset: 0x00A0EAAA
		// (set) Token: 0x060289ED RID: 166381 RVA: 0x00A108BA File Offset: 0x00A0EABA
		public unsafe bool 特定形状开关
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SReBulletDataScale.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SReBulletDataScale.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x060289EE RID: 166382 RVA: 0x00A108CB File Offset: 0x00A0EACB
		public SReBulletDataScale()
		{
		}

		// Token: 0x060289EF RID: 166383 RVA: 0x00A108D3 File Offset: 0x00A0EAD3
		[NullableContext(1)]
		public SReBulletDataScale(FVector 缩放倍率, UCurveVector 缩放倍率曲线, bool 特定形状开关)
		{
			this.缩放倍率 = 缩放倍率;
			this.缩放倍率曲线 = 缩放倍率曲线;
			this.特定形状开关 = 特定形状开关;
		}

		// Token: 0x060289F0 RID: 166384 RVA: 0x00A108F0 File Offset: 0x00A0EAF0
		protected override IntPtr GetUStructPtr()
		{
			return SReBulletDataScale.StaticStruct();
		}

		// Token: 0x060289F1 RID: 166385 RVA: 0x00A108FC File Offset: 0x00A0EAFC
		[NullableContext(2)]
		public SReBulletDataScale(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060289F2 RID: 166386 RVA: 0x00A10906 File Offset: 0x00A0EB06
		public SReBulletDataScale(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060289F3 RID: 166387 RVA: 0x00A10911 File Offset: 0x00A0EB11
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SReBulletDataScale(Pointer, false, true);
		}

		// Token: 0x060289F4 RID: 166388 RVA: 0x00A1091B File Offset: 0x00A0EB1B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SReBulletDataScale(Pointer, MemoryOwner);
		}

		// Token: 0x040156C1 RID: 87745
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Core/Fight/SReBulletDataScale.SReBulletDataScale";

		// Token: 0x040156C2 RID: 87746
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040156C3 RID: 87747
		internal static int __PropertyOffset_0;

		// Token: 0x040156C4 RID: 87748
		internal static int __PropertyOffset_1;

		// Token: 0x040156C5 RID: 87749
		internal static int __PropertyOffset_2;
	}
}
