using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004258 RID: 16984
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SDangoPerformEffectData.SDangoPerformEffectData")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SDangoPerformEffectData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CFF1 RID: 184305 RVA: 0x00AB5166 File Offset: 0x00AB3366
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDangoPerformEffectData._ScriptStructPtr != 0) ? SDangoPerformEffectData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SDangoPerformEffectData.SDangoPerformEffectData", ref SDangoPerformEffectData._ScriptStructPtr);
		}

		// Token: 0x17007A0F RID: 31247
		// (get) Token: 0x0602CFF2 RID: 184306 RVA: 0x00AB518A File Offset: 0x00AB338A
		// (set) Token: 0x0602CFF3 RID: 184307 RVA: 0x00AB51A9 File Offset: 0x00AB33A9
		[Nullable(1)]
		public TSoftObjectPtr<UEffectModelBase> 特效路径
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007A10 RID: 31248
		// (get) Token: 0x0602CFF4 RID: 184308 RVA: 0x00AB51CE File Offset: 0x00AB33CE
		// (set) Token: 0x0602CFF5 RID: 184309 RVA: 0x00AB51E2 File Offset: 0x00AB33E2
		public unsafe TEnumAsByte<EDangoPerformLocationType> 特效位置类型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A11 RID: 31249
		// (get) Token: 0x0602CFF6 RID: 184310 RVA: 0x00AB51F7 File Offset: 0x00AB33F7
		// (set) Token: 0x0602CFF7 RID: 184311 RVA: 0x00AB520B File Offset: 0x00AB340B
		public unsafe FVector 位置偏移
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A12 RID: 31250
		// (get) Token: 0x0602CFF8 RID: 184312 RVA: 0x00AB5220 File Offset: 0x00AB3420
		// (set) Token: 0x0602CFF9 RID: 184313 RVA: 0x00AB5234 File Offset: 0x00AB3434
		public unsafe FName 骨骼名称
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A13 RID: 31251
		// (get) Token: 0x0602CFFA RID: 184314 RVA: 0x00AB5249 File Offset: 0x00AB3449
		// (set) Token: 0x0602CFFB RID: 184315 RVA: 0x00AB5259 File Offset: 0x00AB3459
		public unsafe int 释放延迟时间
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDangoPerformEffectData.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x0602CFFC RID: 184316 RVA: 0x00AB526A File Offset: 0x00AB346A
		public SDangoPerformEffectData()
		{
		}

		// Token: 0x0602CFFD RID: 184317 RVA: 0x00AB5272 File Offset: 0x00AB3472
		public SDangoPerformEffectData([Nullable(1)] TSoftObjectPtr<UEffectModelBase> 特效路径, TEnumAsByte<EDangoPerformLocationType> 特效位置类型, FVector 位置偏移, FName 骨骼名称, int 释放延迟时间)
		{
			this.特效路径 = 特效路径;
			this.特效位置类型 = 特效位置类型;
			this.位置偏移 = 位置偏移;
			this.骨骼名称 = 骨骼名称;
			this.释放延迟时间 = 释放延迟时间;
		}

		// Token: 0x0602CFFE RID: 184318 RVA: 0x00AB529F File Offset: 0x00AB349F
		protected override IntPtr GetUStructPtr()
		{
			return SDangoPerformEffectData.StaticStruct();
		}

		// Token: 0x0602CFFF RID: 184319 RVA: 0x00AB52AB File Offset: 0x00AB34AB
		[NullableContext(2)]
		public SDangoPerformEffectData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D000 RID: 184320 RVA: 0x00AB52B5 File Offset: 0x00AB34B5
		public SDangoPerformEffectData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D001 RID: 184321 RVA: 0x00AB52C0 File Offset: 0x00AB34C0
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDangoPerformEffectData(Pointer, false, true);
		}

		// Token: 0x0602D002 RID: 184322 RVA: 0x00AB52CA File Offset: 0x00AB34CA
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDangoPerformEffectData(Pointer, MemoryOwner);
		}

		// Token: 0x040193D4 RID: 103380
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SDangoPerformEffectData.SDangoPerformEffectData";

		// Token: 0x040193D5 RID: 103381
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040193D6 RID: 103382
		internal static int __PropertyOffset_0;

		// Token: 0x040193D7 RID: 103383
		internal static int __PropertyOffset_1;

		// Token: 0x040193D8 RID: 103384
		internal static int __PropertyOffset_2;

		// Token: 0x040193D9 RID: 103385
		internal static int __PropertyOffset_3;

		// Token: 0x040193DA RID: 103386
		internal static int __PropertyOffset_4;
	}
}
