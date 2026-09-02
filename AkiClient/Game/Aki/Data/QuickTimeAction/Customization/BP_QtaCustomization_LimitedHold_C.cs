using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E25 RID: 15909
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_LimitedHold.BP_QtaCustomization_LimitedHold_C")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 144)]
	public class BP_QtaCustomization_LimitedHold_C : BP_QtaCustomizationBase_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027362 RID: 160610 RVA: 0x009EC71C File Offset: 0x009EA91C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QtaCustomization_LimitedHold_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_LimitedHold.BP_QtaCustomization_LimitedHold_C");
			}
			return BP_QtaCustomization_LimitedHold_C._ClassPtr;
		}

		// Token: 0x06027363 RID: 160611 RVA: 0x009EC740 File Offset: 0x009EA940
		public BP_QtaCustomization_LimitedHold_C() : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomization_LimitedHold_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027364 RID: 160612 RVA: 0x009EC768 File Offset: 0x009EA968
		public BP_QtaCustomization_LimitedHold_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QtaCustomization_LimitedHold_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005BA1 RID: 23457
		// (get) Token: 0x06027365 RID: 160613 RVA: 0x009EC79C File Offset: 0x009EA99C
		// (set) Token: 0x06027366 RID: 160614 RVA: 0x009EC7D5 File Offset: 0x009EA9D5
		public SQtaCustomization_LimitedHold Config
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCustomization_LimitedHold result;
				if ((result = this._Config) == null)
				{
					result = (this._Config = new SQtaCustomization_LimitedHold(base.NativePtr + (IntPtr)BP_QtaCustomization_LimitedHold_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCustomization_LimitedHold.StaticStruct(), base.NativePtr + (IntPtr)BP_QtaCustomization_LimitedHold_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027367 RID: 160615 RVA: 0x009EC7F6 File Offset: 0x009EA9F6
		protected BP_QtaCustomization_LimitedHold_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014800 RID: 83968
		public new const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/BP_QtaCustomization_LimitedHold.BP_QtaCustomization_LimitedHold_C";

		// Token: 0x04014801 RID: 83969
		private static IntPtr _ClassPtr;

		// Token: 0x04014802 RID: 83970
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014803 RID: 83971
		internal static int __PropertyOffset_0;

		// Token: 0x04014804 RID: 83972
		[Nullable(2)]
		private SQtaCustomization_LimitedHold _Config;
	}
}
