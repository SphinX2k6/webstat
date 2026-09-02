using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D7D RID: 15741
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveFloatData.PD_CurveFloatData_C")]
	[UnrealStructLayout(232, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 228)]
	public class PD_CurveFloatData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060266C8 RID: 157384 RVA: 0x009D765D File Offset: 0x009D585D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CurveFloatData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveFloatData.PD_CurveFloatData_C");
			}
			return PD_CurveFloatData_C._ClassPtr;
		}

		// Token: 0x060266C9 RID: 157385 RVA: 0x009D7684 File Offset: 0x009D5884
		public PD_CurveFloatData_C() : this(BuiltinUtils.AllocNativeUObject(PD_CurveFloatData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060266CA RID: 157386 RVA: 0x009D76AC File Offset: 0x009D58AC
		public PD_CurveFloatData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CurveFloatData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005757 RID: 22359
		// (get) Token: 0x060266CB RID: 157387 RVA: 0x009D76E0 File Offset: 0x009D58E0
		// (set) Token: 0x060266CC RID: 157388 RVA: 0x009D7719 File Offset: 0x009D5919
		public FKuroCurveFloat FloatData
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._FloatData) == null)
				{
					result = (this._FloatData = new FKuroCurveFloat(base.NativePtr + (IntPtr)PD_CurveFloatData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)PD_CurveFloatData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005758 RID: 22360
		// (get) Token: 0x060266CD RID: 157389 RVA: 0x009D773A File Offset: 0x009D593A
		// (set) Token: 0x060266CE RID: 157390 RVA: 0x009D774A File Offset: 0x009D594A
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CurveFloatData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CurveFloatData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060266CF RID: 157391 RVA: 0x009D775B File Offset: 0x009D595B
		protected PD_CurveFloatData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013F43 RID: 81731
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveFloatData.PD_CurveFloatData_C";

		// Token: 0x04013F44 RID: 81732
		private static IntPtr _ClassPtr;

		// Token: 0x04013F45 RID: 81733
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013F46 RID: 81734
		internal static int __PropertyOffset_0;

		// Token: 0x04013F47 RID: 81735
		[Nullable(2)]
		private FKuroCurveFloat _FloatData;

		// Token: 0x04013F48 RID: 81736
		internal static int __PropertyOffset_1;
	}
}
