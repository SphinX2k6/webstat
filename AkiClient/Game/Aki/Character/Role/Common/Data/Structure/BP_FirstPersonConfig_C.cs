using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004003 RID: 16387
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfig.BP_FirstPersonConfig_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 153)]
	public class BP_FirstPersonConfig_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A88B RID: 174219 RVA: 0x00A5C2CC File Offset: 0x00A5A4CC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FirstPersonConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfig.BP_FirstPersonConfig_C");
			}
			return BP_FirstPersonConfig_C._ClassPtr;
		}

		// Token: 0x0602A88C RID: 174220 RVA: 0x00A5C2F0 File Offset: 0x00A5A4F0
		public BP_FirstPersonConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_FirstPersonConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A88D RID: 174221 RVA: 0x00A5C318 File Offset: 0x00A5A518
		public BP_FirstPersonConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FirstPersonConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006E86 RID: 28294
		// (get) Token: 0x0602A88E RID: 174222 RVA: 0x00A5C34B File Offset: 0x00A5A54B
		// (set) Token: 0x0602A88F RID: 174223 RVA: 0x00A5C35B File Offset: 0x00A5A55B
		public unsafe int ForwardAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006E87 RID: 28295
		// (get) Token: 0x0602A890 RID: 174224 RVA: 0x00A5C36C File Offset: 0x00A5A56C
		// (set) Token: 0x0602A891 RID: 174225 RVA: 0x00A5C3A5 File Offset: 0x00A5A5A5
		public FGameplayTagContainer FirstPersonTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._FirstPersonTagList) == null)
				{
					result = (this._FirstPersonTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E88 RID: 28296
		// (get) Token: 0x0602A892 RID: 174226 RVA: 0x00A5C3C8 File Offset: 0x00A5A5C8
		// (set) Token: 0x0602A893 RID: 174227 RVA: 0x00A5C401 File Offset: 0x00A5A601
		public FGameplayTagContainer ForbidRotationTagList
		{
			get
			{
				base.FastCheckIsValid();
				FGameplayTagContainer result;
				if ((result = this._ForbidRotationTagList) == null)
				{
					result = (this._ForbidRotationTagList = new FGameplayTagContainer(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006E89 RID: 28297
		// (get) Token: 0x0602A894 RID: 174228 RVA: 0x00A5C422 File Offset: 0x00A5A622
		// (set) Token: 0x0602A895 RID: 174229 RVA: 0x00A5C432 File Offset: 0x00A5A632
		public unsafe bool DashInForwardAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FirstPersonConfig_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602A896 RID: 174230 RVA: 0x00A5C443 File Offset: 0x00A5A643
		protected BP_FirstPersonConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017215 RID: 94741
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfig.BP_FirstPersonConfig_C";

		// Token: 0x04017216 RID: 94742
		private static IntPtr _ClassPtr;

		// Token: 0x04017217 RID: 94743
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017218 RID: 94744
		internal static int __PropertyOffset_0;

		// Token: 0x04017219 RID: 94745
		internal static int __PropertyOffset_1;

		// Token: 0x0401721A RID: 94746
		[Nullable(2)]
		private FGameplayTagContainer _FirstPersonTagList;

		// Token: 0x0401721B RID: 94747
		internal static int __PropertyOffset_2;

		// Token: 0x0401721C RID: 94748
		[Nullable(2)]
		private FGameplayTagContainer _ForbidRotationTagList;

		// Token: 0x0401721D RID: 94749
		internal static int __PropertyOffset_3;
	}
}
