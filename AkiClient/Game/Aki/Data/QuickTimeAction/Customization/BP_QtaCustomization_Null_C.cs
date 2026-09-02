using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E26 RID: 15910
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_Null.BP_QtaCustomization_Null_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_QtaCustomization_Null_C : BP_QtaCustomizationBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027368 RID: 160616 RVA: 0x009EC7FF File Offset: 0x009EA9FF
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QtaCustomization_Null_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_Null.BP_QtaCustomization_Null_C");
			}
			return BP_QtaCustomization_Null_C._ClassPtr;
		}

		// Token: 0x06027369 RID: 160617 RVA: 0x009EC824 File Offset: 0x009EAA24
		public BP_QtaCustomization_Null_C() : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomization_Null_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602736A RID: 160618 RVA: 0x009EC84C File Offset: 0x009EAA4C
		[NullableContext(1)]
		public BP_QtaCustomization_Null_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomization_Null_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602736B RID: 160619 RVA: 0x009EC87F File Offset: 0x009EAA7F
		protected BP_QtaCustomization_Null_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014805 RID: 83973
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_Null.BP_QtaCustomization_Null_C";

		// Token: 0x04014806 RID: 83974
		private static IntPtr _ClassPtr;

		// Token: 0x04014807 RID: 83975
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
