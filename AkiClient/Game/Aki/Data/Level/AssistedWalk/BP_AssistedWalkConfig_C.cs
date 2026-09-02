using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.AttachMove;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.AssistedWalk
{
	// Token: 0x02003E81 RID: 16001
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/AssistedWalk/BP_AssistedWalkConfig.BP_AssistedWalkConfig_C")]
	[UnrealStructLayout(304, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 296)]
	public class BP_AssistedWalkConfig_C : BP_AttachMoveConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027A30 RID: 162352 RVA: 0x009F6BB5 File Offset: 0x009F4DB5
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AssistedWalkConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/AssistedWalk/BP_AssistedWalkConfig.BP_AssistedWalkConfig_C");
			}
			return BP_AssistedWalkConfig_C._ClassPtr;
		}

		// Token: 0x06027A31 RID: 162353 RVA: 0x009F6BDC File Offset: 0x009F4DDC
		public BP_AssistedWalkConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_AssistedWalkConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027A32 RID: 162354 RVA: 0x009F6C04 File Offset: 0x009F4E04
		public BP_AssistedWalkConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AssistedWalkConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E0B RID: 24075
		// (get) Token: 0x06027A33 RID: 162355 RVA: 0x009F6C37 File Offset: 0x009F4E37
		// (set) Token: 0x06027A34 RID: 162356 RVA: 0x009F6C47 File Offset: 0x009F4E47
		public unsafe int BaseMoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E0C RID: 24076
		// (get) Token: 0x06027A35 RID: 162357 RVA: 0x009F6C58 File Offset: 0x009F4E58
		// (set) Token: 0x06027A36 RID: 162358 RVA: 0x009F6C68 File Offset: 0x009F4E68
		public unsafe int LeaderTurnSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E0D RID: 24077
		// (get) Token: 0x06027A37 RID: 162359 RVA: 0x009F6C79 File Offset: 0x009F4E79
		// (set) Token: 0x06027A38 RID: 162360 RVA: 0x009F6C8D File Offset: 0x009F4E8D
		public unsafe FTransform StartTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005E0E RID: 24078
		// (get) Token: 0x06027A39 RID: 162361 RVA: 0x009F6CA2 File Offset: 0x009F4EA2
		// (set) Token: 0x06027A3A RID: 162362 RVA: 0x009F6CB6 File Offset: 0x009F4EB6
		public unsafe FVector2D AnimSpeedRateRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005E0F RID: 24079
		// (get) Token: 0x06027A3B RID: 162363 RVA: 0x009F6CCC File Offset: 0x009F4ECC
		// (set) Token: 0x06027A3C RID: 162364 RVA: 0x009F6D05 File Offset: 0x009F4F05
		public FGameplayTagContainer LeaderGameplayTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._LeaderGameplayTagList) == null)
				{
					result = (this._LeaderGameplayTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_AssistedWalkConfig_C.__PropertyOffset_4, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027A3D RID: 162365 RVA: 0x009F6D26 File Offset: 0x009F4F26
		protected BP_AssistedWalkConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014C75 RID: 85109
		public new const string __ObjectPath = "/Game/Aki/Data/Level/AssistedWalk/BP_AssistedWalkConfig.BP_AssistedWalkConfig_C";

		// Token: 0x04014C76 RID: 85110
		private static IntPtr _ClassPtr;

		// Token: 0x04014C77 RID: 85111
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014C78 RID: 85112
		internal new static int __PropertyOffset_0;

		// Token: 0x04014C79 RID: 85113
		internal new static int __PropertyOffset_1;

		// Token: 0x04014C7A RID: 85114
		internal new static int __PropertyOffset_2;

		// Token: 0x04014C7B RID: 85115
		internal new static int __PropertyOffset_3;

		// Token: 0x04014C7C RID: 85116
		internal static int __PropertyOffset_4;

		// Token: 0x04014C7D RID: 85117
		[Nullable(2)]
		private FGameplayTagContainer _LeaderGameplayTagList;
	}
}
