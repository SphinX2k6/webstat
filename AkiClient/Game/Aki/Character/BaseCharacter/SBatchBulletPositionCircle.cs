using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200423A RID: 16954
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionCircle.SBatchBulletPositionCircle")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 112)]
	public class SBatchBulletPositionCircle : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CD73 RID: 183667 RVA: 0x00AB15CA File Offset: 0x00AAF7CA
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SBatchBulletPositionCircle._ScriptStructPtr != 0) ? SBatchBulletPositionCircle._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SBatchBulletPositionCircle.SBatchBulletPositionCircle", ref SBatchBulletPositionCircle._ScriptStructPtr);
		}

		// Token: 0x17007946 RID: 31046
		// (get) Token: 0x0602CD74 RID: 183668 RVA: 0x00AB15EE File Offset: 0x00AAF7EE
		// (set) Token: 0x0602CD75 RID: 183669 RVA: 0x00AB1602 File Offset: 0x00AAF802
		public unsafe string CenterKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007947 RID: 31047
		// (get) Token: 0x0602CD76 RID: 183670 RVA: 0x00AB1617 File Offset: 0x00AAF817
		// (set) Token: 0x0602CD77 RID: 183671 RVA: 0x00AB162B File Offset: 0x00AAF82B
		public unsafe string RadiusKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007948 RID: 31048
		// (get) Token: 0x0602CD78 RID: 183672 RVA: 0x00AB1640 File Offset: 0x00AAF840
		// (set) Token: 0x0602CD79 RID: 183673 RVA: 0x00AB1654 File Offset: 0x00AAF854
		public unsafe string ForwardKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17007949 RID: 31049
		// (get) Token: 0x0602CD7A RID: 183674 RVA: 0x00AB1669 File Offset: 0x00AAF869
		// (set) Token: 0x0602CD7B RID: 183675 RVA: 0x00AB1679 File Offset: 0x00AAF879
		public unsafe bool Clockwise
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700794A RID: 31050
		// (get) Token: 0x0602CD7C RID: 183676 RVA: 0x00AB168A File Offset: 0x00AAF88A
		// (set) Token: 0x0602CD7D RID: 183677 RVA: 0x00AB169A File Offset: 0x00AAF89A
		public unsafe float BeginAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700794B RID: 31051
		// (get) Token: 0x0602CD7E RID: 183678 RVA: 0x00AB16AB File Offset: 0x00AAF8AB
		// (set) Token: 0x0602CD7F RID: 183679 RVA: 0x00AB16BF File Offset: 0x00AAF8BF
		public unsafe string AngleIntervalKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x1700794C RID: 31052
		// (get) Token: 0x0602CD80 RID: 183680 RVA: 0x00AB16D4 File Offset: 0x00AAF8D4
		// (set) Token: 0x0602CD81 RID: 183681 RVA: 0x00AB16E8 File Offset: 0x00AAF8E8
		[Nullable(0)]
		public unsafe TEnumAsByte<EBatchBulletBeginRotator> BeginRotator
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_6);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)SBatchBulletPositionCircle.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700794D RID: 31053
		// (get) Token: 0x0602CD82 RID: 183682 RVA: 0x00AB16FD File Offset: 0x00AAF8FD
		// (set) Token: 0x0602CD83 RID: 183683 RVA: 0x00AB1711 File Offset: 0x00AAF911
		public unsafe string StartPosKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x1700794E RID: 31054
		// (get) Token: 0x0602CD84 RID: 183684 RVA: 0x00AB1726 File Offset: 0x00AAF926
		// (set) Token: 0x0602CD85 RID: 183685 RVA: 0x00AB173A File Offset: 0x00AAF93A
		public unsafe string DistToTarget
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SBatchBulletPositionCircle.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x0602CD86 RID: 183686 RVA: 0x00AB174F File Offset: 0x00AAF94F
		public SBatchBulletPositionCircle()
		{
		}

		// Token: 0x0602CD87 RID: 183687 RVA: 0x00AB1758 File Offset: 0x00AAF958
		public SBatchBulletPositionCircle(string CenterKey, string RadiusKey, string ForwardKey, bool Clockwise, float BeginAngle, string AngleIntervalKey, [Nullable(0)] TEnumAsByte<EBatchBulletBeginRotator> BeginRotator, string StartPosKey, string DistToTarget)
		{
			this.CenterKey = CenterKey;
			this.RadiusKey = RadiusKey;
			this.ForwardKey = ForwardKey;
			this.Clockwise = Clockwise;
			this.BeginAngle = BeginAngle;
			this.AngleIntervalKey = AngleIntervalKey;
			this.BeginRotator = BeginRotator;
			this.StartPosKey = StartPosKey;
			this.DistToTarget = DistToTarget;
		}

		// Token: 0x0602CD88 RID: 183688 RVA: 0x00AB17B0 File Offset: 0x00AAF9B0
		protected override IntPtr GetUStructPtr()
		{
			return SBatchBulletPositionCircle.StaticStruct();
		}

		// Token: 0x0602CD89 RID: 183689 RVA: 0x00AB17BC File Offset: 0x00AAF9BC
		[NullableContext(2)]
		public SBatchBulletPositionCircle(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CD8A RID: 183690 RVA: 0x00AB17C6 File Offset: 0x00AAF9C6
		public SBatchBulletPositionCircle(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CD8B RID: 183691 RVA: 0x00AB17D1 File Offset: 0x00AAF9D1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SBatchBulletPositionCircle(Pointer, false, true);
		}

		// Token: 0x0602CD8C RID: 183692 RVA: 0x00AB17DB File Offset: 0x00AAF9DB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SBatchBulletPositionCircle(Pointer, MemoryOwner);
		}

		// Token: 0x04019299 RID: 103065
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SBatchBulletPositionCircle.SBatchBulletPositionCircle";

		// Token: 0x0401929A RID: 103066
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401929B RID: 103067
		internal static int __PropertyOffset_0;

		// Token: 0x0401929C RID: 103068
		internal static int __PropertyOffset_1;

		// Token: 0x0401929D RID: 103069
		internal static int __PropertyOffset_2;

		// Token: 0x0401929E RID: 103070
		internal static int __PropertyOffset_3;

		// Token: 0x0401929F RID: 103071
		internal static int __PropertyOffset_4;

		// Token: 0x040192A0 RID: 103072
		internal static int __PropertyOffset_5;

		// Token: 0x040192A1 RID: 103073
		internal static int __PropertyOffset_6;

		// Token: 0x040192A2 RID: 103074
		internal static int __PropertyOffset_7;

		// Token: 0x040192A3 RID: 103075
		internal static int __PropertyOffset_8;
	}
}
