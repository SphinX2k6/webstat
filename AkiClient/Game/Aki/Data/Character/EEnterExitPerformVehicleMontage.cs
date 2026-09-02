using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Character
{
	// Token: 0x02003F0E RID: 16142
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Character/EEnterExitPerformVehicleMontage.EEnterExitPerformVehicleMontage")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 104)]
	public class EEnterExitPerformVehicleMontage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602834D RID: 164685 RVA: 0x00A05378 File Offset: 0x00A03578
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (EEnterExitPerformVehicleMontage._ScriptStructPtr != 0) ? EEnterExitPerformVehicleMontage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Character/EEnterExitPerformVehicleMontage.EEnterExitPerformVehicleMontage", ref EEnterExitPerformVehicleMontage._ScriptStructPtr);
		}

		// Token: 0x1700610B RID: 24843
		// (get) Token: 0x0602834E RID: 164686 RVA: 0x00A0539C File Offset: 0x00A0359C
		// (set) Token: 0x0602834F RID: 164687 RVA: 0x00A053AC File Offset: 0x00A035AC
		public unsafe bool IsEnter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700610C RID: 24844
		// (get) Token: 0x06028350 RID: 164688 RVA: 0x00A053BD File Offset: 0x00A035BD
		// (set) Token: 0x06028351 RID: 164689 RVA: 0x00A053D1 File Offset: 0x00A035D1
		public unsafe TEnumAsByte<EEnterExitPerformVehicle_Gender> Gender
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x1700610D RID: 24845
		// (get) Token: 0x06028352 RID: 164690 RVA: 0x00A053E6 File Offset: 0x00A035E6
		// (set) Token: 0x06028353 RID: 164691 RVA: 0x00A053FA File Offset: 0x00A035FA
		public unsafe TEnumAsByte<EEnterExitPerformVehicle_Direction> Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700610E RID: 24846
		// (get) Token: 0x06028354 RID: 164692 RVA: 0x00A0540F File Offset: 0x00A0360F
		// (set) Token: 0x06028355 RID: 164693 RVA: 0x00A0542E File Offset: 0x00A0362E
		[Nullable(1)]
		public TSoftObjectPtr<UAnimMontage> Montage
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x1700610F RID: 24847
		// (get) Token: 0x06028356 RID: 164694 RVA: 0x00A05453 File Offset: 0x00A03653
		// (set) Token: 0x06028357 RID: 164695 RVA: 0x00A05472 File Offset: 0x00A03672
		[Nullable(1)]
		public TSoftObjectPtr<UAnimMontage> AdditiveMontage
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UAnimMontage>(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)EEnterExitPerformVehicleMontage.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x06028358 RID: 164696 RVA: 0x00A05497 File Offset: 0x00A03697
		public EEnterExitPerformVehicleMontage()
		{
		}

		// Token: 0x06028359 RID: 164697 RVA: 0x00A0549F File Offset: 0x00A0369F
		public EEnterExitPerformVehicleMontage(bool IsEnter, TEnumAsByte<EEnterExitPerformVehicle_Gender> Gender, TEnumAsByte<EEnterExitPerformVehicle_Direction> Direction, [Nullable(1)] TSoftObjectPtr<UAnimMontage> Montage, [Nullable(1)] TSoftObjectPtr<UAnimMontage> AdditiveMontage)
		{
			this.IsEnter = IsEnter;
			this.Gender = Gender;
			this.Direction = Direction;
			this.Montage = Montage;
			this.AdditiveMontage = AdditiveMontage;
		}

		// Token: 0x0602835A RID: 164698 RVA: 0x00A054CC File Offset: 0x00A036CC
		protected override IntPtr GetUStructPtr()
		{
			return EEnterExitPerformVehicleMontage.StaticStruct();
		}

		// Token: 0x0602835B RID: 164699 RVA: 0x00A054D8 File Offset: 0x00A036D8
		[NullableContext(2)]
		public EEnterExitPerformVehicleMontage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602835C RID: 164700 RVA: 0x00A054E2 File Offset: 0x00A036E2
		public EEnterExitPerformVehicleMontage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602835D RID: 164701 RVA: 0x00A054ED File Offset: 0x00A036ED
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new EEnterExitPerformVehicleMontage(Pointer, false, true);
		}

		// Token: 0x0602835E RID: 164702 RVA: 0x00A054F7 File Offset: 0x00A036F7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new EEnterExitPerformVehicleMontage(Pointer, MemoryOwner);
		}

		// Token: 0x0401523D RID: 86589
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Character/EEnterExitPerformVehicleMontage.EEnterExitPerformVehicleMontage";

		// Token: 0x0401523E RID: 86590
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401523F RID: 86591
		internal static int __PropertyOffset_0;

		// Token: 0x04015240 RID: 86592
		internal static int __PropertyOffset_1;

		// Token: 0x04015241 RID: 86593
		internal static int __PropertyOffset_2;

		// Token: 0x04015242 RID: 86594
		internal static int __PropertyOffset_3;

		// Token: 0x04015243 RID: 86595
		internal static int __PropertyOffset_4;
	}
}
