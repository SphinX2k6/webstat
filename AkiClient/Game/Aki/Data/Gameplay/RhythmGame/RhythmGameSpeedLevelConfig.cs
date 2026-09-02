using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.RhythmGame
{
	// Token: 0x02003EA2 RID: 16034
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameSpeedLevelConfig.RhythmGameSpeedLevelConfig")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 96)]
	public class RhythmGameSpeedLevelConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027C96 RID: 162966 RVA: 0x009FA830 File Offset: 0x009F8A30
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (RhythmGameSpeedLevelConfig._ScriptStructPtr != 0) ? RhythmGameSpeedLevelConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameSpeedLevelConfig.RhythmGameSpeedLevelConfig", ref RhythmGameSpeedLevelConfig._ScriptStructPtr);
		}

		// Token: 0x17005EED RID: 24301
		// (get) Token: 0x06027C97 RID: 162967 RVA: 0x009FA854 File Offset: 0x009F8A54
		// (set) Token: 0x06027C98 RID: 162968 RVA: 0x009FA868 File Offset: 0x009F8A68
		public unsafe FVectorDouble Pos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005EEE RID: 24302
		// (get) Token: 0x06027C99 RID: 162969 RVA: 0x009FA87D File Offset: 0x009F8A7D
		// (set) Token: 0x06027C9A RID: 162970 RVA: 0x009FA891 File Offset: 0x009F8A91
		public unsafe FRotator Rot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005EEF RID: 24303
		// (get) Token: 0x06027C9B RID: 162971 RVA: 0x009FA8A6 File Offset: 0x009F8AA6
		// (set) Token: 0x06027C9C RID: 162972 RVA: 0x009FA8B6 File Offset: 0x009F8AB6
		public unsafe float Fov
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005EF0 RID: 24304
		// (get) Token: 0x06027C9D RID: 162973 RVA: 0x009FA8C7 File Offset: 0x009F8AC7
		// (set) Token: 0x06027C9E RID: 162974 RVA: 0x009FA8D7 File Offset: 0x009F8AD7
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005EF1 RID: 24305
		// (get) Token: 0x06027C9F RID: 162975 RVA: 0x009FA8E8 File Offset: 0x009F8AE8
		// (set) Token: 0x06027CA0 RID: 162976 RVA: 0x009FA907 File Offset: 0x009F8B07
		public TSoftObjectPtr<UEffectModelGroup> FireEffectDa
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelGroup>(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)RhythmGameSpeedLevelConfig.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06027CA1 RID: 162977 RVA: 0x009FA92C File Offset: 0x009F8B2C
		public RhythmGameSpeedLevelConfig()
		{
		}

		// Token: 0x06027CA2 RID: 162978 RVA: 0x009FA934 File Offset: 0x009F8B34
		public RhythmGameSpeedLevelConfig(FVectorDouble Pos, FRotator Rot, float Fov, float Speed, TSoftObjectPtr<UEffectModelGroup> FireEffectDa)
		{
			this.Pos = Pos;
			this.Rot = Rot;
			this.Fov = Fov;
			this.Speed = Speed;
			this.FireEffectDa = FireEffectDa;
		}

		// Token: 0x06027CA3 RID: 162979 RVA: 0x009FA961 File Offset: 0x009F8B61
		protected override IntPtr GetUStructPtr()
		{
			return RhythmGameSpeedLevelConfig.StaticStruct();
		}

		// Token: 0x06027CA4 RID: 162980 RVA: 0x009FA96D File Offset: 0x009F8B6D
		[NullableContext(2)]
		public RhythmGameSpeedLevelConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027CA5 RID: 162981 RVA: 0x009FA977 File Offset: 0x009F8B77
		public RhythmGameSpeedLevelConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027CA6 RID: 162982 RVA: 0x009FA982 File Offset: 0x009F8B82
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new RhythmGameSpeedLevelConfig(Pointer, false, true);
		}

		// Token: 0x06027CA7 RID: 162983 RVA: 0x009FA98C File Offset: 0x009F8B8C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new RhythmGameSpeedLevelConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014E05 RID: 85509
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameSpeedLevelConfig.RhythmGameSpeedLevelConfig";

		// Token: 0x04014E06 RID: 85510
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E07 RID: 85511
		internal static int __PropertyOffset_0;

		// Token: 0x04014E08 RID: 85512
		internal static int __PropertyOffset_1;

		// Token: 0x04014E09 RID: 85513
		internal static int __PropertyOffset_2;

		// Token: 0x04014E0A RID: 85514
		internal static int __PropertyOffset_3;

		// Token: 0x04014E0B RID: 85515
		internal static int __PropertyOffset_4;
	}
}
