using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E24 RID: 15908
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomizationBase.BP_QtaCustomizationBase_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_QtaCustomizationBase_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602735E RID: 160606 RVA: 0x009EC693 File Offset: 0x009EA893
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QtaCustomizationBase_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomizationBase.BP_QtaCustomizationBase_C");
			}
			return BP_QtaCustomizationBase_C._ClassPtr;
		}

		// Token: 0x0602735F RID: 160607 RVA: 0x009EC6B8 File Offset: 0x009EA8B8
		public BP_QtaCustomizationBase_C() : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomizationBase_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027360 RID: 160608 RVA: 0x009EC6E0 File Offset: 0x009EA8E0
		[NullableContext(1)]
		public BP_QtaCustomizationBase_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomizationBase_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06027361 RID: 160609 RVA: 0x009EC713 File Offset: 0x009EA913
		protected BP_QtaCustomizationBase_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040147FD RID: 83965
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomizationBase.BP_QtaCustomizationBase_C";

		// Token: 0x040147FE RID: 83966
		private static IntPtr _ClassPtr;

		// Token: 0x040147FF RID: 83967
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
