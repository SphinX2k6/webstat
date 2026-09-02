using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D7E RID: 15742
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveLinearColorData.PD_CurveLinearColorData_C")]
	[UnrealStructLayout(632, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 628)]
	public class PD_CurveLinearColorData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060266D0 RID: 157392 RVA: 0x009D7764 File Offset: 0x009D5964
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_CurveLinearColorData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveLinearColorData.PD_CurveLinearColorData_C");
			}
			return PD_CurveLinearColorData_C._ClassPtr;
		}

		// Token: 0x060266D1 RID: 157393 RVA: 0x009D7788 File Offset: 0x009D5988
		public PD_CurveLinearColorData_C() : this(BuiltinUtils.AllocNativeUObject(PD_CurveLinearColorData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060266D2 RID: 157394 RVA: 0x009D77B0 File Offset: 0x009D59B0
		public PD_CurveLinearColorData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_CurveLinearColorData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005759 RID: 22361
		// (get) Token: 0x060266D3 RID: 157395 RVA: 0x009D77E4 File Offset: 0x009D59E4
		// (set) Token: 0x060266D4 RID: 157396 RVA: 0x009D781D File Offset: 0x009D5A1D
		public FKuroCurveLinearColor LinearColor
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._LinearColor) == null)
				{
					result = (this._LinearColor = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)PD_CurveLinearColorData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)PD_CurveLinearColorData_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700575A RID: 22362
		// (get) Token: 0x060266D5 RID: 157397 RVA: 0x009D783E File Offset: 0x009D5A3E
		// (set) Token: 0x060266D6 RID: 157398 RVA: 0x009D784E File Offset: 0x009D5A4E
		public unsafe float Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_CurveLinearColorData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_CurveLinearColorData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060266D7 RID: 157399 RVA: 0x009D785F File Offset: 0x009D5A5F
		protected PD_CurveLinearColorData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013F49 RID: 81737
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/PD_CurveLinearColorData.PD_CurveLinearColorData_C";

		// Token: 0x04013F4A RID: 81738
		private static IntPtr _ClassPtr;

		// Token: 0x04013F4B RID: 81739
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013F4C RID: 81740
		internal static int __PropertyOffset_0;

		// Token: 0x04013F4D RID: 81741
		[Nullable(2)]
		private FKuroCurveLinearColor _LinearColor;

		// Token: 0x04013F4E RID: 81742
		internal static int __PropertyOffset_1;
	}
}
