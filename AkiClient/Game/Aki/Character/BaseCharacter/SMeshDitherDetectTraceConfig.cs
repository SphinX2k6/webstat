using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426E RID: 17006
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMeshDitherDetectTraceConfig.SMeshDitherDetectTraceConfig")]
	[UnrealStructLayout(72, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 69)]
	public class SMeshDitherDetectTraceConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D17B RID: 184699 RVA: 0x00AB72A5 File Offset: 0x00AB54A5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMeshDitherDetectTraceConfig._ScriptStructPtr != 0) ? SMeshDitherDetectTraceConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMeshDitherDetectTraceConfig.SMeshDitherDetectTraceConfig", ref SMeshDitherDetectTraceConfig._ScriptStructPtr);
		}

		// Token: 0x17007A7E RID: 31358
		// (get) Token: 0x0602D17C RID: 184700 RVA: 0x00AB72C9 File Offset: 0x00AB54C9
		// (set) Token: 0x0602D17D RID: 184701 RVA: 0x00AB72DD File Offset: 0x00AB54DD
		public unsafe FName BaseBoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A7F RID: 31359
		// (get) Token: 0x0602D17E RID: 184702 RVA: 0x00AB72F2 File Offset: 0x00AB54F2
		// (set) Token: 0x0602D17F RID: 184703 RVA: 0x00AB7306 File Offset: 0x00AB5506
		public unsafe FName TargetBoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A80 RID: 31360
		// (get) Token: 0x0602D180 RID: 184704 RVA: 0x00AB731B File Offset: 0x00AB551B
		// (set) Token: 0x0602D181 RID: 184705 RVA: 0x00AB732F File Offset: 0x00AB552F
		public unsafe FName BasisBoneName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007A81 RID: 31361
		// (get) Token: 0x0602D182 RID: 184706 RVA: 0x00AB7344 File Offset: 0x00AB5544
		// (set) Token: 0x0602D183 RID: 184707 RVA: 0x00AB7358 File Offset: 0x00AB5558
		public unsafe FVector2D AdditionCapsuleSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007A82 RID: 31362
		// (get) Token: 0x0602D184 RID: 184708 RVA: 0x00AB736D File Offset: 0x00AB556D
		// (set) Token: 0x0602D185 RID: 184709 RVA: 0x00AB7381 File Offset: 0x00AB5581
		public unsafe FVector AdditionCapsuleOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007A83 RID: 31363
		// (get) Token: 0x0602D186 RID: 184710 RVA: 0x00AB7396 File Offset: 0x00AB5596
		// (set) Token: 0x0602D187 RID: 184711 RVA: 0x00AB73AA File Offset: 0x00AB55AA
		public unsafe FRotator AdditionCapsuleRotator
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007A84 RID: 31364
		// (get) Token: 0x0602D188 RID: 184712 RVA: 0x00AB73BF File Offset: 0x00AB55BF
		// (set) Token: 0x0602D189 RID: 184713 RVA: 0x00AB73CF File Offset: 0x00AB55CF
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectTraceConfig.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D18A RID: 184714 RVA: 0x00AB73E0 File Offset: 0x00AB55E0
		public SMeshDitherDetectTraceConfig()
		{
		}

		// Token: 0x0602D18B RID: 184715 RVA: 0x00AB73E8 File Offset: 0x00AB55E8
		public SMeshDitherDetectTraceConfig(FName BaseBoneName, FName TargetBoneName, FName BasisBoneName, FVector2D AdditionCapsuleSize, FVector AdditionCapsuleOffset, FRotator AdditionCapsuleRotator, bool Debug)
		{
			this.BaseBoneName = BaseBoneName;
			this.TargetBoneName = TargetBoneName;
			this.BasisBoneName = BasisBoneName;
			this.AdditionCapsuleSize = AdditionCapsuleSize;
			this.AdditionCapsuleOffset = AdditionCapsuleOffset;
			this.AdditionCapsuleRotator = AdditionCapsuleRotator;
			this.Debug = Debug;
		}

		// Token: 0x0602D18C RID: 184716 RVA: 0x00AB7425 File Offset: 0x00AB5625
		protected override IntPtr GetUStructPtr()
		{
			return SMeshDitherDetectTraceConfig.StaticStruct();
		}

		// Token: 0x0602D18D RID: 184717 RVA: 0x00AB7431 File Offset: 0x00AB5631
		[NullableContext(2)]
		public SMeshDitherDetectTraceConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D18E RID: 184718 RVA: 0x00AB743B File Offset: 0x00AB563B
		public SMeshDitherDetectTraceConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D18F RID: 184719 RVA: 0x00AB7446 File Offset: 0x00AB5646
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMeshDitherDetectTraceConfig(Pointer, false, true);
		}

		// Token: 0x0602D190 RID: 184720 RVA: 0x00AB7450 File Offset: 0x00AB5650
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMeshDitherDetectTraceConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04019489 RID: 103561
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMeshDitherDetectTraceConfig.SMeshDitherDetectTraceConfig";

		// Token: 0x0401948A RID: 103562
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401948B RID: 103563
		internal static int __PropertyOffset_0;

		// Token: 0x0401948C RID: 103564
		internal static int __PropertyOffset_1;

		// Token: 0x0401948D RID: 103565
		internal static int __PropertyOffset_2;

		// Token: 0x0401948E RID: 103566
		internal static int __PropertyOffset_3;

		// Token: 0x0401948F RID: 103567
		internal static int __PropertyOffset_4;

		// Token: 0x04019490 RID: 103568
		internal static int __PropertyOffset_5;

		// Token: 0x04019491 RID: 103569
		internal static int __PropertyOffset_6;
	}
}
