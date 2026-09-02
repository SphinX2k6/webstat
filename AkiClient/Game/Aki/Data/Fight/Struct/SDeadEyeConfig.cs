using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ECC RID: 16076
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SDeadEyeConfig.SDeadEyeConfig")]
	[UnrealStructLayout(32, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 32)]
	public class SDeadEyeConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F31 RID: 163633 RVA: 0x009FED6A File Offset: 0x009FCF6A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SDeadEyeConfig._ScriptStructPtr != 0) ? SDeadEyeConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SDeadEyeConfig.SDeadEyeConfig", ref SDeadEyeConfig._ScriptStructPtr);
		}

		// Token: 0x17005FAC RID: 24492
		// (get) Token: 0x06027F32 RID: 163634 RVA: 0x009FED8E File Offset: 0x009FCF8E
		// (set) Token: 0x06027F33 RID: 163635 RVA: 0x009FED9E File Offset: 0x009FCF9E
		public unsafe float AimToleranceDeg
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005FAD RID: 24493
		// (get) Token: 0x06027F34 RID: 163636 RVA: 0x009FEDAF File Offset: 0x009FCFAF
		// (set) Token: 0x06027F35 RID: 163637 RVA: 0x009FEDBF File Offset: 0x009FCFBF
		public unsafe float AimSpeedDegPerSec
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FAE RID: 24494
		// (get) Token: 0x06027F36 RID: 163638 RVA: 0x009FEDD0 File Offset: 0x009FCFD0
		// (set) Token: 0x06027F37 RID: 163639 RVA: 0x009FEDE0 File Offset: 0x009FCFE0
		public unsafe float PostFireDelay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FAF RID: 24495
		// (get) Token: 0x06027F38 RID: 163640 RVA: 0x009FEDF1 File Offset: 0x009FCFF1
		// (set) Token: 0x06027F39 RID: 163641 RVA: 0x009FEE01 File Offset: 0x009FD001
		public unsafe bool EaseOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FB0 RID: 24496
		// (get) Token: 0x06027F3A RID: 163642 RVA: 0x009FEE12 File Offset: 0x009FD012
		// (set) Token: 0x06027F3B RID: 163643 RVA: 0x009FEE22 File Offset: 0x009FD022
		public unsafe bool EaseIn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FB1 RID: 24497
		// (get) Token: 0x06027F3C RID: 163644 RVA: 0x009FEE33 File Offset: 0x009FD033
		// (set) Token: 0x06027F3D RID: 163645 RVA: 0x009FEE43 File Offset: 0x009FD043
		public unsafe bool ForceShortestRoute
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FB2 RID: 24498
		// (get) Token: 0x06027F3E RID: 163646 RVA: 0x009FEE54 File Offset: 0x009FD054
		// (set) Token: 0x06027F3F RID: 163647 RVA: 0x009FEE64 File Offset: 0x009FD064
		public unsafe int SkillId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005FB3 RID: 24499
		// (get) Token: 0x06027F40 RID: 163648 RVA: 0x009FEE75 File Offset: 0x009FD075
		// (set) Token: 0x06027F41 RID: 163649 RVA: 0x009FEE89 File Offset: 0x009FD089
		public unsafe FRotator RotateOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SDeadEyeConfig.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06027F42 RID: 163650 RVA: 0x009FEE9E File Offset: 0x009FD09E
		public SDeadEyeConfig()
		{
		}

		// Token: 0x06027F43 RID: 163651 RVA: 0x009FEEA8 File Offset: 0x009FD0A8
		public SDeadEyeConfig(float AimToleranceDeg, float AimSpeedDegPerSec, float PostFireDelay, bool EaseOut, bool EaseIn, bool ForceShortestRoute, int SkillId, FRotator RotateOffset)
		{
			this.AimToleranceDeg = AimToleranceDeg;
			this.AimSpeedDegPerSec = AimSpeedDegPerSec;
			this.PostFireDelay = PostFireDelay;
			this.EaseOut = EaseOut;
			this.EaseIn = EaseIn;
			this.ForceShortestRoute = ForceShortestRoute;
			this.SkillId = SkillId;
			this.RotateOffset = RotateOffset;
		}

		// Token: 0x06027F44 RID: 163652 RVA: 0x009FEEF8 File Offset: 0x009FD0F8
		protected override IntPtr GetUStructPtr()
		{
			return SDeadEyeConfig.StaticStruct();
		}

		// Token: 0x06027F45 RID: 163653 RVA: 0x009FEF04 File Offset: 0x009FD104
		[NullableContext(2)]
		public SDeadEyeConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027F46 RID: 163654 RVA: 0x009FEF0E File Offset: 0x009FD10E
		public SDeadEyeConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027F47 RID: 163655 RVA: 0x009FEF19 File Offset: 0x009FD119
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SDeadEyeConfig(Pointer, false, true);
		}

		// Token: 0x06027F48 RID: 163656 RVA: 0x009FEF23 File Offset: 0x009FD123
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SDeadEyeConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014F98 RID: 85912
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SDeadEyeConfig.SDeadEyeConfig";

		// Token: 0x04014F99 RID: 85913
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F9A RID: 85914
		internal static int __PropertyOffset_0;

		// Token: 0x04014F9B RID: 85915
		internal static int __PropertyOffset_1;

		// Token: 0x04014F9C RID: 85916
		internal static int __PropertyOffset_2;

		// Token: 0x04014F9D RID: 85917
		internal static int __PropertyOffset_3;

		// Token: 0x04014F9E RID: 85918
		internal static int __PropertyOffset_4;

		// Token: 0x04014F9F RID: 85919
		internal static int __PropertyOffset_5;

		// Token: 0x04014FA0 RID: 85920
		internal static int __PropertyOffset_6;

		// Token: 0x04014FA1 RID: 85921
		internal static int __PropertyOffset_7;
	}
}
