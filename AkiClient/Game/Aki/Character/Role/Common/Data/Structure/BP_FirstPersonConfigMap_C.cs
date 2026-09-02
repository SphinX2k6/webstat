using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x02004002 RID: 16386
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfigMap.BP_FirstPersonConfigMap_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_FirstPersonConfigMap_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602A885 RID: 174213 RVA: 0x00A5C1FA File Offset: 0x00A5A3FA
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FirstPersonConfigMap_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfigMap.BP_FirstPersonConfigMap_C");
			}
			return BP_FirstPersonConfigMap_C._ClassPtr;
		}

		// Token: 0x0602A886 RID: 174214 RVA: 0x00A5C220 File Offset: 0x00A5A420
		public BP_FirstPersonConfigMap_C() : this(BuiltinUtils.AllocNativeUObject(BP_FirstPersonConfigMap_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602A887 RID: 174215 RVA: 0x00A5C248 File Offset: 0x00A5A448
		public BP_FirstPersonConfigMap_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FirstPersonConfigMap_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006E85 RID: 28293
		// (get) Token: 0x0602A888 RID: 174216 RVA: 0x00A5C27C File Offset: 0x00A5A47C
		// (set) Token: 0x0602A889 RID: 174217 RVA: 0x00A5C2B5 File Offset: 0x00A5A4B5
		public TMap<FGameplayTag, TSoftObjectPtr<BP_FirstPersonConfig_C>> TagToConfigMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FGameplayTag, TSoftObjectPtr<BP_FirstPersonConfig_C>> result;
				if ((result = this._TagToConfigMap) == null)
				{
					result = (this._TagToConfigMap = new TMap<FGameplayTag, TSoftObjectPtr<BP_FirstPersonConfig_C>>(base.NativePtr + (IntPtr)BP_FirstPersonConfigMap_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.TagToConfigMap.CopyAssign(value);
			}
		}

		// Token: 0x0602A88A RID: 174218 RVA: 0x00A5C2C3 File Offset: 0x00A5A4C3
		protected BP_FirstPersonConfigMap_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04017210 RID: 94736
		public new const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/BP_FirstPersonConfigMap.BP_FirstPersonConfigMap_C";

		// Token: 0x04017211 RID: 94737
		private static IntPtr _ClassPtr;

		// Token: 0x04017212 RID: 94738
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04017213 RID: 94739
		internal static int __PropertyOffset_0;

		// Token: 0x04017214 RID: 94740
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<FGameplayTag, TSoftObjectPtr<BP_FirstPersonConfig_C>> _TagToConfigMap;
	}
}
