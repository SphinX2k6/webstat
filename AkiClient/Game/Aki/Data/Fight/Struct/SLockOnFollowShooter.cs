using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED2 RID: 16082
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooter.SLockOnFollowShooter")]
	[UnrealStructLayout(296, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 296)]
	public class SLockOnFollowShooter : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027F8D RID: 163725 RVA: 0x009FF586 File Offset: 0x009FD786
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLockOnFollowShooter._ScriptStructPtr != 0) ? SLockOnFollowShooter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SLockOnFollowShooter.SLockOnFollowShooter", ref SLockOnFollowShooter._ScriptStructPtr);
		}

		// Token: 0x17005FC3 RID: 24515
		// (get) Token: 0x06027F8E RID: 163726 RVA: 0x009FF5AA File Offset: 0x009FD7AA
		// (set) Token: 0x06027F8F RID: 163727 RVA: 0x009FF5BA File Offset: 0x009FD7BA
		public unsafe bool Enable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_0) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_0) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FC4 RID: 24516
		// (get) Token: 0x06027F90 RID: 163728 RVA: 0x009FF5CB File Offset: 0x009FD7CB
		// (set) Token: 0x06027F91 RID: 163729 RVA: 0x009FF5DB File Offset: 0x009FD7DB
		public unsafe float GapTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005FC5 RID: 24517
		// (get) Token: 0x06027F92 RID: 163730 RVA: 0x009FF5EC File Offset: 0x009FD7EC
		// (set) Token: 0x06027F93 RID: 163731 RVA: 0x009FF5FC File Offset: 0x009FD7FC
		public unsafe int Distance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005FC6 RID: 24518
		// (get) Token: 0x06027F94 RID: 163732 RVA: 0x009FF60D File Offset: 0x009FD80D
		// (set) Token: 0x06027F95 RID: 163733 RVA: 0x009FF61D File Offset: 0x009FD81D
		public unsafe int Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005FC7 RID: 24519
		// (get) Token: 0x06027F96 RID: 163734 RVA: 0x009FF62E File Offset: 0x009FD82E
		// (set) Token: 0x06027F97 RID: 163735 RVA: 0x009FF63E File Offset: 0x009FD83E
		public unsafe float WorldDistanceWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005FC8 RID: 24520
		// (get) Token: 0x06027F98 RID: 163736 RVA: 0x009FF64F File Offset: 0x009FD84F
		// (set) Token: 0x06027F99 RID: 163737 RVA: 0x009FF65F File Offset: 0x009FD85F
		public unsafe float ScreenDistanceWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005FC9 RID: 24521
		// (get) Token: 0x06027F9A RID: 163738 RVA: 0x009FF670 File Offset: 0x009FD870
		// (set) Token: 0x06027F9B RID: 163739 RVA: 0x009FF680 File Offset: 0x009FD880
		public unsafe float CharacterExtraWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005FCA RID: 24522
		// (get) Token: 0x06027F9C RID: 163740 RVA: 0x009FF691 File Offset: 0x009FD891
		// (set) Token: 0x06027F9D RID: 163741 RVA: 0x009FF6A1 File Offset: 0x009FD8A1
		public unsafe float SceneItemExtraWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005FCB RID: 24523
		// (get) Token: 0x06027F9E RID: 163742 RVA: 0x009FF6B4 File Offset: 0x009FD8B4
		// (set) Token: 0x06027F9F RID: 163743 RVA: 0x009FF6F7 File Offset: 0x009FD8F7
		public TArray<SLockOnFollowShooterAutoAim> ArrayAutoAimConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SLockOnFollowShooterAutoAim> result;
				if ((result = this._ArrayAutoAimConfig) == null)
				{
					result = (this._ArrayAutoAimConfig = new TArray<SLockOnFollowShooterAutoAim>(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_8, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ArrayAutoAimConfig.CopyAssign(value);
			}
		}

		// Token: 0x17005FCC RID: 24524
		// (get) Token: 0x06027FA0 RID: 163744 RVA: 0x009FF708 File Offset: 0x009FD908
		// (set) Token: 0x06027FA1 RID: 163745 RVA: 0x009FF74B File Offset: 0x009FD94B
		public FGameplayTagContainer LockOnGameplayTagContainer
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._LockOnGameplayTagContainer) == null)
				{
					result = (this._LockOnGameplayTagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FCD RID: 24525
		// (get) Token: 0x06027FA2 RID: 163746 RVA: 0x009FF76C File Offset: 0x009FD96C
		// (set) Token: 0x06027FA3 RID: 163747 RVA: 0x009FF7AF File Offset: 0x009FD9AF
		public FGameplayTagContainer AutoDetectEnableTagContainer
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._AutoDetectEnableTagContainer) == null)
				{
					result = (this._AutoDetectEnableTagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_10, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_10, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FCE RID: 24526
		// (get) Token: 0x06027FA4 RID: 163748 RVA: 0x009FF7D0 File Offset: 0x009FD9D0
		// (set) Token: 0x06027FA5 RID: 163749 RVA: 0x009FF813 File Offset: 0x009FDA13
		public FGameplayTagContainer IgnoreLockOnGameplayTagContainer
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._IgnoreLockOnGameplayTagContainer) == null)
				{
					result = (this._IgnoreLockOnGameplayTagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_11, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_11, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FCF RID: 24527
		// (get) Token: 0x06027FA6 RID: 163750 RVA: 0x009FF834 File Offset: 0x009FDA34
		// (set) Token: 0x06027FA7 RID: 163751 RVA: 0x009FF877 File Offset: 0x009FDA77
		public FGameplayTagContainer AutoShootGameplayTagContainer
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._AutoShootGameplayTagContainer) == null)
				{
					result = (this._AutoShootGameplayTagContainer = new FGameplayTagContainer(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_12, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_12, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005FD0 RID: 24528
		// (get) Token: 0x06027FA8 RID: 163752 RVA: 0x009FF898 File Offset: 0x009FDA98
		// (set) Token: 0x06027FA9 RID: 163753 RVA: 0x009FF8A8 File Offset: 0x009FDAA8
		public unsafe float CameraForwardDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005FD1 RID: 24529
		// (get) Token: 0x06027FAA RID: 163754 RVA: 0x009FF8B9 File Offset: 0x009FDAB9
		// (set) Token: 0x06027FAB RID: 163755 RVA: 0x009FF8CD File Offset: 0x009FDACD
		public unsafe string CustomEntityKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnFollowShooter.__PropertyOffset_14)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnFollowShooter.__PropertyOffset_14)), value);
			}
		}

		// Token: 0x17005FD2 RID: 24530
		// (get) Token: 0x06027FAC RID: 163756 RVA: 0x009FF8E2 File Offset: 0x009FDAE2
		// (set) Token: 0x06027FAD RID: 163757 RVA: 0x009FF8F6 File Offset: 0x009FDAF6
		public unsafe string CustomBulletTargetKey
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnFollowShooter.__PropertyOffset_15)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnFollowShooter.__PropertyOffset_15)), value);
			}
		}

		// Token: 0x17005FD3 RID: 24531
		// (get) Token: 0x06027FAE RID: 163758 RVA: 0x009FF90C File Offset: 0x009FDB0C
		// (set) Token: 0x06027FAF RID: 163759 RVA: 0x009FF94F File Offset: 0x009FDB4F
		public TSet<string> CustomBulletTargetRowNameSet
		{
			get
			{
				base.FastCheckIsValid();
				TSet<string> result;
				if ((result = this._CustomBulletTargetRowNameSet) == null)
				{
					result = (this._CustomBulletTargetRowNameSet = new TSet<string>(base.NativePtr + (IntPtr)SLockOnFollowShooter.__PropertyOffset_16, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.CustomBulletTargetRowNameSet.CopyAssign(value);
			}
		}

		// Token: 0x06027FB0 RID: 163760 RVA: 0x009FF95D File Offset: 0x009FDB5D
		public SLockOnFollowShooter()
		{
		}

		// Token: 0x06027FB1 RID: 163761 RVA: 0x009FF968 File Offset: 0x009FDB68
		public SLockOnFollowShooter(bool Enable, float GapTime, int Distance, int Radius, float WorldDistanceWeight, float ScreenDistanceWeight, float CharacterExtraWeight, float SceneItemExtraWeight, TArray<SLockOnFollowShooterAutoAim> ArrayAutoAimConfig, FGameplayTagContainer LockOnGameplayTagContainer, FGameplayTagContainer AutoDetectEnableTagContainer, FGameplayTagContainer IgnoreLockOnGameplayTagContainer, FGameplayTagContainer AutoShootGameplayTagContainer, float CameraForwardDistance, string CustomEntityKey, string CustomBulletTargetKey, TSet<string> CustomBulletTargetRowNameSet)
		{
			this.Enable = Enable;
			this.GapTime = GapTime;
			this.Distance = Distance;
			this.Radius = Radius;
			this.WorldDistanceWeight = WorldDistanceWeight;
			this.ScreenDistanceWeight = ScreenDistanceWeight;
			this.CharacterExtraWeight = CharacterExtraWeight;
			this.SceneItemExtraWeight = SceneItemExtraWeight;
			this.ArrayAutoAimConfig = ArrayAutoAimConfig;
			this.LockOnGameplayTagContainer = LockOnGameplayTagContainer;
			this.AutoDetectEnableTagContainer = AutoDetectEnableTagContainer;
			this.IgnoreLockOnGameplayTagContainer = IgnoreLockOnGameplayTagContainer;
			this.AutoShootGameplayTagContainer = AutoShootGameplayTagContainer;
			this.CameraForwardDistance = CameraForwardDistance;
			this.CustomEntityKey = CustomEntityKey;
			this.CustomBulletTargetKey = CustomBulletTargetKey;
			this.CustomBulletTargetRowNameSet = CustomBulletTargetRowNameSet;
		}

		// Token: 0x06027FB2 RID: 163762 RVA: 0x009FFA00 File Offset: 0x009FDC00
		protected override IntPtr GetUStructPtr()
		{
			return SLockOnFollowShooter.StaticStruct();
		}

		// Token: 0x06027FB3 RID: 163763 RVA: 0x009FFA0C File Offset: 0x009FDC0C
		[NullableContext(2)]
		public SLockOnFollowShooter(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027FB4 RID: 163764 RVA: 0x009FFA16 File Offset: 0x009FDC16
		public SLockOnFollowShooter(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027FB5 RID: 163765 RVA: 0x009FFA21 File Offset: 0x009FDC21
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLockOnFollowShooter(Pointer, false, true);
		}

		// Token: 0x06027FB6 RID: 163766 RVA: 0x009FFA2B File Offset: 0x009FDC2B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLockOnFollowShooter(Pointer, MemoryOwner);
		}

		// Token: 0x04014FC5 RID: 85957
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SLockOnFollowShooter.SLockOnFollowShooter";

		// Token: 0x04014FC6 RID: 85958
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FC7 RID: 85959
		internal static int __PropertyOffset_0;

		// Token: 0x04014FC8 RID: 85960
		internal static int __PropertyOffset_1;

		// Token: 0x04014FC9 RID: 85961
		internal static int __PropertyOffset_2;

		// Token: 0x04014FCA RID: 85962
		internal static int __PropertyOffset_3;

		// Token: 0x04014FCB RID: 85963
		internal static int __PropertyOffset_4;

		// Token: 0x04014FCC RID: 85964
		internal static int __PropertyOffset_5;

		// Token: 0x04014FCD RID: 85965
		internal static int __PropertyOffset_6;

		// Token: 0x04014FCE RID: 85966
		internal static int __PropertyOffset_7;

		// Token: 0x04014FCF RID: 85967
		internal static int __PropertyOffset_8;

		// Token: 0x04014FD0 RID: 85968
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SLockOnFollowShooterAutoAim> _ArrayAutoAimConfig;

		// Token: 0x04014FD1 RID: 85969
		internal static int __PropertyOffset_9;

		// Token: 0x04014FD2 RID: 85970
		[Nullable(2)]
		private FGameplayTagContainer _LockOnGameplayTagContainer;

		// Token: 0x04014FD3 RID: 85971
		internal static int __PropertyOffset_10;

		// Token: 0x04014FD4 RID: 85972
		[Nullable(2)]
		private FGameplayTagContainer _AutoDetectEnableTagContainer;

		// Token: 0x04014FD5 RID: 85973
		internal static int __PropertyOffset_11;

		// Token: 0x04014FD6 RID: 85974
		[Nullable(2)]
		private FGameplayTagContainer _IgnoreLockOnGameplayTagContainer;

		// Token: 0x04014FD7 RID: 85975
		internal static int __PropertyOffset_12;

		// Token: 0x04014FD8 RID: 85976
		[Nullable(2)]
		private FGameplayTagContainer _AutoShootGameplayTagContainer;

		// Token: 0x04014FD9 RID: 85977
		internal static int __PropertyOffset_13;

		// Token: 0x04014FDA RID: 85978
		internal static int __PropertyOffset_14;

		// Token: 0x04014FDB RID: 85979
		internal static int __PropertyOffset_15;

		// Token: 0x04014FDC RID: 85980
		internal static int __PropertyOffset_16;

		// Token: 0x04014FDD RID: 85981
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<string> _CustomBulletTargetRowNameSet;
	}
}
