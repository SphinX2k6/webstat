using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.AttachMove
{
	// Token: 0x02003E80 RID: 16000
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/AttachMove/BP_AttachMoveConfig.BP_AttachMoveConfig_C")]
	[UnrealStructLayout(192, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 192)]
	public class BP_AttachMoveConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027A24 RID: 162340 RVA: 0x009F6A60 File Offset: 0x009F4C60
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AttachMoveConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/AttachMove/BP_AttachMoveConfig.BP_AttachMoveConfig_C");
			}
			return BP_AttachMoveConfig_C._ClassPtr;
		}

		// Token: 0x06027A25 RID: 162341 RVA: 0x009F6A84 File Offset: 0x009F4C84
		public BP_AttachMoveConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_AttachMoveConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027A26 RID: 162342 RVA: 0x009F6AAC File Offset: 0x009F4CAC
		public BP_AttachMoveConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AttachMoveConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E07 RID: 24071
		// (get) Token: 0x06027A27 RID: 162343 RVA: 0x009F6ADF File Offset: 0x009F4CDF
		// (set) Token: 0x06027A28 RID: 162344 RVA: 0x009F6AF3 File Offset: 0x009F4CF3
		public unsafe string AttachSocket
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005E08 RID: 24072
		// (get) Token: 0x06027A29 RID: 162345 RVA: 0x009F6B08 File Offset: 0x009F4D08
		// (set) Token: 0x06027A2A RID: 162346 RVA: 0x009F6B41 File Offset: 0x009F4D41
		public FGameplayTagContainer GameplayTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._GameplayTagList) == null)
				{
					result = (this._GameplayTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E09 RID: 24073
		// (get) Token: 0x06027A2B RID: 162347 RVA: 0x009F6B62 File Offset: 0x009F4D62
		// (set) Token: 0x06027A2C RID: 162348 RVA: 0x009F6B72 File Offset: 0x009F4D72
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005E0A RID: 24074
		// (get) Token: 0x06027A2D RID: 162349 RVA: 0x009F6B83 File Offset: 0x009F4D83
		// (set) Token: 0x06027A2E RID: 162350 RVA: 0x009F6B97 File Offset: 0x009F4D97
		public unsafe FTransform AttachTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AttachMoveConfig_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x06027A2F RID: 162351 RVA: 0x009F6BAC File Offset: 0x009F4DAC
		protected BP_AttachMoveConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014C6D RID: 85101
		public new const string __ObjectPath = "/Game/Aki/Data/Level/AttachMove/BP_AttachMoveConfig.BP_AttachMoveConfig_C";

		// Token: 0x04014C6E RID: 85102
		private static IntPtr _ClassPtr;

		// Token: 0x04014C6F RID: 85103
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014C70 RID: 85104
		internal static int __PropertyOffset_0;

		// Token: 0x04014C71 RID: 85105
		internal static int __PropertyOffset_1;

		// Token: 0x04014C72 RID: 85106
		[Nullable(2)]
		private FGameplayTagContainer _GameplayTagList;

		// Token: 0x04014C73 RID: 85107
		internal static int __PropertyOffset_2;

		// Token: 0x04014C74 RID: 85108
		internal static int __PropertyOffset_3;
	}
}
