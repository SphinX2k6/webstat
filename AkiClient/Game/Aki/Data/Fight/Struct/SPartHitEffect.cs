using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED8 RID: 16088
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SPartHitEffect.SPartHitEffect")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 209)]
	public class SPartHitEffect : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602801B RID: 163867 RVA: 0x00A0024B File Offset: 0x009FE44B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SPartHitEffect._ScriptStructPtr != 0) ? SPartHitEffect._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SPartHitEffect.SPartHitEffect", ref SPartHitEffect._ScriptStructPtr);
		}

		// Token: 0x17005FF2 RID: 24562
		// (get) Token: 0x0602801C RID: 163868 RVA: 0x00A0026F File Offset: 0x009FE46F
		// (set) Token: 0x0602801D RID: 163869 RVA: 0x00A00283 File Offset: 0x009FE483
		public unsafe string BoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SPartHitEffect.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SPartHitEffect.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005FF3 RID: 24563
		// (get) Token: 0x0602801E RID: 163870 RVA: 0x00A00298 File Offset: 0x009FE498
		// (set) Token: 0x0602801F RID: 163871 RVA: 0x00A002A8 File Offset: 0x009FE4A8
		public unsafe bool IsBlockPawn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FF4 RID: 24564
		// (get) Token: 0x06028020 RID: 163872 RVA: 0x00A002B9 File Offset: 0x009FE4B9
		// (set) Token: 0x06028021 RID: 163873 RVA: 0x00A002C9 File Offset: 0x009FE4C9
		public unsafe bool IsBulletDetect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FF5 RID: 24565
		// (get) Token: 0x06028022 RID: 163874 RVA: 0x00A002DA File Offset: 0x009FE4DA
		// (set) Token: 0x06028023 RID: 163875 RVA: 0x00A002EA File Offset: 0x009FE4EA
		public unsafe bool IsBlockCamera
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FF6 RID: 24566
		// (get) Token: 0x06028024 RID: 163876 RVA: 0x00A002FB File Offset: 0x009FE4FB
		// (set) Token: 0x06028025 RID: 163877 RVA: 0x00A0030B File Offset: 0x009FE50B
		public unsafe bool IsActiveOcclusionDither
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FF7 RID: 24567
		// (get) Token: 0x06028026 RID: 163878 RVA: 0x00A0031C File Offset: 0x009FE51C
		// (set) Token: 0x06028027 RID: 163879 RVA: 0x00A0032C File Offset: 0x009FE52C
		public unsafe bool IsIgnoreAllChannel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FF8 RID: 24568
		// (get) Token: 0x06028028 RID: 163880 RVA: 0x00A0033D File Offset: 0x009FE53D
		// (set) Token: 0x06028029 RID: 163881 RVA: 0x00A00351 File Offset: 0x009FE551
		public unsafe FVector Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005FF9 RID: 24569
		// (get) Token: 0x0602802A RID: 163882 RVA: 0x00A00366 File Offset: 0x009FE566
		// (set) Token: 0x0602802B RID: 163883 RVA: 0x00A0037A File Offset: 0x009FE57A
		public unsafe FVector Location
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005FFA RID: 24570
		// (get) Token: 0x0602802C RID: 163884 RVA: 0x00A0038F File Offset: 0x009FE58F
		// (set) Token: 0x0602802D RID: 163885 RVA: 0x00A003A3 File Offset: 0x009FE5A3
		public unsafe FRotator Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005FFB RID: 24571
		// (get) Token: 0x0602802E RID: 163886 RVA: 0x00A003B8 File Offset: 0x009FE5B8
		// (set) Token: 0x0602802F RID: 163887 RVA: 0x00A003D7 File Offset: 0x009FE5D7
		public TSoftObjectPtr<UEffectModelBase> Effect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_9, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_9, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FFC RID: 24572
		// (get) Token: 0x06028030 RID: 163888 RVA: 0x00A003FC File Offset: 0x009FE5FC
		// (set) Token: 0x06028031 RID: 163889 RVA: 0x00A0041B File Offset: 0x009FE61B
		public TSoftObjectPtr<PD_CharacterControllerData_C> MaterialEffect
		{
			get
			{
				return new TSoftObjectPtr<PD_CharacterControllerData_C>(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_10, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_10, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FFD RID: 24573
		// (get) Token: 0x06028032 RID: 163890 RVA: 0x00A00440 File Offset: 0x009FE640
		// (set) Token: 0x06028033 RID: 163891 RVA: 0x00A0045F File Offset: 0x009FE65F
		public TSoftObjectPtr<EffectModelAudio> Audio
		{
			get
			{
				return new TSoftObjectPtr<EffectModelAudio>(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_11, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_11, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005FFE RID: 24574
		// (get) Token: 0x06028034 RID: 163892 RVA: 0x00A00484 File Offset: 0x009FE684
		// (set) Token: 0x06028035 RID: 163893 RVA: 0x00A00494 File Offset: 0x009FE694
		public unsafe bool ReplaceBulletHitEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SPartHitEffect.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x06028036 RID: 163894 RVA: 0x00A004A5 File Offset: 0x009FE6A5
		public SPartHitEffect()
		{
		}

		// Token: 0x06028037 RID: 163895 RVA: 0x00A004B0 File Offset: 0x009FE6B0
		public SPartHitEffect(string BoneName, bool IsBlockPawn, bool IsBulletDetect, bool IsBlockCamera, bool IsActiveOcclusionDither, bool IsIgnoreAllChannel, FVector Size, FVector Location, FRotator Rotation, TSoftObjectPtr<UEffectModelBase> Effect, TSoftObjectPtr<PD_CharacterControllerData_C> MaterialEffect, TSoftObjectPtr<EffectModelAudio> Audio, bool ReplaceBulletHitEffect)
		{
			this.BoneName = BoneName;
			this.IsBlockPawn = IsBlockPawn;
			this.IsBulletDetect = IsBulletDetect;
			this.IsBlockCamera = IsBlockCamera;
			this.IsActiveOcclusionDither = IsActiveOcclusionDither;
			this.IsIgnoreAllChannel = IsIgnoreAllChannel;
			this.Size = Size;
			this.Location = Location;
			this.Rotation = Rotation;
			this.Effect = Effect;
			this.MaterialEffect = MaterialEffect;
			this.Audio = Audio;
			this.ReplaceBulletHitEffect = ReplaceBulletHitEffect;
		}

		// Token: 0x06028038 RID: 163896 RVA: 0x00A00528 File Offset: 0x009FE728
		protected override IntPtr GetUStructPtr()
		{
			return SPartHitEffect.StaticStruct();
		}

		// Token: 0x06028039 RID: 163897 RVA: 0x00A00534 File Offset: 0x009FE734
		[NullableContext(2)]
		public SPartHitEffect(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602803A RID: 163898 RVA: 0x00A0053E File Offset: 0x009FE73E
		public SPartHitEffect(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602803B RID: 163899 RVA: 0x00A00549 File Offset: 0x009FE749
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SPartHitEffect(Pointer, false, true);
		}

		// Token: 0x0602803C RID: 163900 RVA: 0x00A00553 File Offset: 0x009FE753
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SPartHitEffect(Pointer, MemoryOwner);
		}

		// Token: 0x04015009 RID: 86025
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SPartHitEffect.SPartHitEffect";

		// Token: 0x0401500A RID: 86026
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401500B RID: 86027
		internal static int __PropertyOffset_0;

		// Token: 0x0401500C RID: 86028
		internal static int __PropertyOffset_1;

		// Token: 0x0401500D RID: 86029
		internal static int __PropertyOffset_2;

		// Token: 0x0401500E RID: 86030
		internal static int __PropertyOffset_3;

		// Token: 0x0401500F RID: 86031
		internal static int __PropertyOffset_4;

		// Token: 0x04015010 RID: 86032
		internal static int __PropertyOffset_5;

		// Token: 0x04015011 RID: 86033
		internal static int __PropertyOffset_6;

		// Token: 0x04015012 RID: 86034
		internal static int __PropertyOffset_7;

		// Token: 0x04015013 RID: 86035
		internal static int __PropertyOffset_8;

		// Token: 0x04015014 RID: 86036
		internal static int __PropertyOffset_9;

		// Token: 0x04015015 RID: 86037
		internal static int __PropertyOffset_10;

		// Token: 0x04015016 RID: 86038
		internal static int __PropertyOffset_11;

		// Token: 0x04015017 RID: 86039
		internal static int __PropertyOffset_12;
	}
}
