using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.PathLine.PathLine_Bullet;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423C RID: 16956
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionSpline.SBatchBulletPositionSpline")]
	[UnrealStructLayout(248, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 248)]
	public class SBatchBulletPositionSpline : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CDA1 RID: 183713 RVA: 0x00AB198F File Offset: 0x00AAFB8F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBatchBulletPositionSpline._ScriptStructPtr != 0) ? SBatchBulletPositionSpline._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionSpline.SBatchBulletPositionSpline", ref SBatchBulletPositionSpline._ScriptStructPtr);
		}

		// Token: 0x17007955 RID: 31061
		// (get) Token: 0x0602CDA2 RID: 183714 RVA: 0x00AB19B3 File Offset: 0x00AAFBB3
		// (set) Token: 0x0602CDA3 RID: 183715 RVA: 0x00AB19D2 File Offset: 0x00AAFBD2
		public TSoftClassPtr<BP_BasePathLineBullet_C> SplineClass
		{
			get
			{
				return new TSoftClassPtr<BP_BasePathLineBullet_C>(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007956 RID: 31062
		// (get) Token: 0x0602CDA4 RID: 183716 RVA: 0x00AB19F7 File Offset: 0x00AAFBF7
		// (set) Token: 0x0602CDA5 RID: 183717 RVA: 0x00AB1A0B File Offset: 0x00AAFC0B
		public unsafe string StartKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007957 RID: 31063
		// (get) Token: 0x0602CDA6 RID: 183718 RVA: 0x00AB1A20 File Offset: 0x00AAFC20
		// (set) Token: 0x0602CDA7 RID: 183719 RVA: 0x00AB1A34 File Offset: 0x00AAFC34
		public unsafe string EndKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007958 RID: 31064
		// (get) Token: 0x0602CDA8 RID: 183720 RVA: 0x00AB1A49 File Offset: 0x00AAFC49
		// (set) Token: 0x0602CDA9 RID: 183721 RVA: 0x00AB1A5D File Offset: 0x00AAFC5D
		public unsafe string RotatorKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17007959 RID: 31065
		// (get) Token: 0x0602CDAA RID: 183722 RVA: 0x00AB1A72 File Offset: 0x00AAFC72
		// (set) Token: 0x0602CDAB RID: 183723 RVA: 0x00AB1A86 File Offset: 0x00AAFC86
		public unsafe string DurationKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x1700795A RID: 31066
		// (get) Token: 0x0602CDAC RID: 183724 RVA: 0x00AB1A9B File Offset: 0x00AAFC9B
		// (set) Token: 0x0602CDAD RID: 183725 RVA: 0x00AB1AAB File Offset: 0x00AAFCAB
		public unsafe float Delay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700795B RID: 31067
		// (get) Token: 0x0602CDAE RID: 183726 RVA: 0x00AB1ABC File Offset: 0x00AAFCBC
		// (set) Token: 0x0602CDAF RID: 183727 RVA: 0x00AB1ACC File Offset: 0x00AAFCCC
		public unsafe bool DestroyAllOnEnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700795C RID: 31068
		// (get) Token: 0x0602CDB0 RID: 183728 RVA: 0x00AB1ADD File Offset: 0x00AAFCDD
		// (set) Token: 0x0602CDB1 RID: 183729 RVA: 0x00AB1AED File Offset: 0x00AAFCED
		public unsafe bool DestroySummonBullet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700795D RID: 31069
		// (get) Token: 0x0602CDB2 RID: 183730 RVA: 0x00AB1AFE File Offset: 0x00AAFCFE
		// (set) Token: 0x0602CDB3 RID: 183731 RVA: 0x00AB1B12 File Offset: 0x00AAFD12
		public unsafe string BulletIdOfEnd
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x1700795E RID: 31070
		// (get) Token: 0x0602CDB4 RID: 183732 RVA: 0x00AB1B27 File Offset: 0x00AAFD27
		// (set) Token: 0x0602CDB5 RID: 183733 RVA: 0x00AB1B46 File Offset: 0x00AAFD46
		public TSoftObjectPtr<UEffectModelBase> EffectOfEnd
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_9, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700795F RID: 31071
		// (get) Token: 0x0602CDB6 RID: 183734 RVA: 0x00AB1B6B File Offset: 0x00AAFD6B
		// (set) Token: 0x0602CDB7 RID: 183735 RVA: 0x00AB1B7F File Offset: 0x00AAFD7F
		public unsafe string BulletIdOnBreak
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_10)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionSpline.__PropertyOffset_10)), value);
			}
		}

		// Token: 0x17007960 RID: 31072
		// (get) Token: 0x0602CDB8 RID: 183736 RVA: 0x00AB1B94 File Offset: 0x00AAFD94
		// (set) Token: 0x0602CDB9 RID: 183737 RVA: 0x00AB1BB3 File Offset: 0x00AAFDB3
		public TSoftObjectPtr<UEffectModelBase> EffectOnBreak
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SBatchBulletPositionSpline.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602CDBA RID: 183738 RVA: 0x00AB1BD8 File Offset: 0x00AAFDD8
		public SBatchBulletPositionSpline()
		{
		}

		// Token: 0x0602CDBB RID: 183739 RVA: 0x00AB1BE0 File Offset: 0x00AAFDE0
		public SBatchBulletPositionSpline(TSoftClassPtr<BP_BasePathLineBullet_C> SplineClass, string StartKey, string EndKey, string RotatorKey, string DurationKey, float Delay, bool DestroyAllOnEnd, bool DestroySummonBullet, string BulletIdOfEnd, TSoftObjectPtr<UEffectModelBase> EffectOfEnd, string BulletIdOnBreak, TSoftObjectPtr<UEffectModelBase> EffectOnBreak)
		{
			this.SplineClass = SplineClass;
			this.StartKey = StartKey;
			this.EndKey = EndKey;
			this.RotatorKey = RotatorKey;
			this.DurationKey = DurationKey;
			this.Delay = Delay;
			this.DestroyAllOnEnd = DestroyAllOnEnd;
			this.DestroySummonBullet = DestroySummonBullet;
			this.BulletIdOfEnd = BulletIdOfEnd;
			this.EffectOfEnd = EffectOfEnd;
			this.BulletIdOnBreak = BulletIdOnBreak;
			this.EffectOnBreak = EffectOnBreak;
		}

		// Token: 0x0602CDBC RID: 183740 RVA: 0x00AB1C50 File Offset: 0x00AAFE50
		protected override IntPtr GetUStructPtr()
		{
			return SBatchBulletPositionSpline.StaticStruct();
		}

		// Token: 0x0602CDBD RID: 183741 RVA: 0x00AB1C5C File Offset: 0x00AAFE5C
		[NullableContext(2)]
		public SBatchBulletPositionSpline(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CDBE RID: 183742 RVA: 0x00AB1C66 File Offset: 0x00AAFE66
		public SBatchBulletPositionSpline(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CDBF RID: 183743 RVA: 0x00AB1C71 File Offset: 0x00AAFE71
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBatchBulletPositionSpline(Pointer, false, true);
		}

		// Token: 0x0602CDC0 RID: 183744 RVA: 0x00AB1C7B File Offset: 0x00AAFE7B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBatchBulletPositionSpline(Pointer, MemoryOwner);
		}

		// Token: 0x040192AD RID: 103085
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBatchBulletPositionSpline.SBatchBulletPositionSpline";

		// Token: 0x040192AE RID: 103086
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040192AF RID: 103087
		internal static int __PropertyOffset_0;

		// Token: 0x040192B0 RID: 103088
		internal static int __PropertyOffset_1;

		// Token: 0x040192B1 RID: 103089
		internal static int __PropertyOffset_2;

		// Token: 0x040192B2 RID: 103090
		internal static int __PropertyOffset_3;

		// Token: 0x040192B3 RID: 103091
		internal static int __PropertyOffset_4;

		// Token: 0x040192B4 RID: 103092
		internal static int __PropertyOffset_5;

		// Token: 0x040192B5 RID: 103093
		internal static int __PropertyOffset_6;

		// Token: 0x040192B6 RID: 103094
		internal static int __PropertyOffset_7;

		// Token: 0x040192B7 RID: 103095
		internal static int __PropertyOffset_8;

		// Token: 0x040192B8 RID: 103096
		internal static int __PropertyOffset_9;

		// Token: 0x040192B9 RID: 103097
		internal static int __PropertyOffset_10;

		// Token: 0x040192BA RID: 103098
		internal static int __PropertyOffset_11;
	}
}
