using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Role.FemaleM.Zhezhi.Data
{
	// Token: 0x02003FF1 RID: 16369
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Role/FemaleM/Zhezhi/Data/BP_SkillTrackCurve.BP_SkillTrackCurve_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1120)]
	public class BP_SkillTrackCurve_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060296AC RID: 169644 RVA: 0x00A2D91C File Offset: 0x00A2BB1C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SkillTrackCurve_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Role/FemaleM/Zhezhi/Data/BP_SkillTrackCurve.BP_SkillTrackCurve_C");
			}
			return BP_SkillTrackCurve_C._ClassPtr;
		}

		// Token: 0x060296AD RID: 169645 RVA: 0x00A2D940 File Offset: 0x00A2BB40
		public BP_SkillTrackCurve_C() : this(BuiltinUtils.AllocNativeUObject(BP_SkillTrackCurve_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060296AE RID: 169646 RVA: 0x00A2D968 File Offset: 0x00A2BB68
		public BP_SkillTrackCurve_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SkillTrackCurve_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006700 RID: 26368
		// (get) Token: 0x060296AF RID: 169647 RVA: 0x00A2D99B File Offset: 0x00A2BB9B
		// (set) Token: 0x060296B0 RID: 169648 RVA: 0x00A2D9AF File Offset: 0x00A2BBAF
		[Nullable(2)]
		public unsafe USplineComponent Spline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkillTrackCurve_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SkillTrackCurve_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17006701 RID: 26369
		// (get) Token: 0x060296B1 RID: 169649 RVA: 0x00A2D9C4 File Offset: 0x00A2BBC4
		// (set) Token: 0x060296B2 RID: 169650 RVA: 0x00A2D9D4 File Offset: 0x00A2BBD4
		public unsafe int SplinePointsNum
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkillTrackCurve_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkillTrackCurve_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006702 RID: 26370
		// (get) Token: 0x060296B3 RID: 169651 RVA: 0x00A2D9E5 File Offset: 0x00A2BBE5
		// (set) Token: 0x060296B4 RID: 169652 RVA: 0x00A2D9F5 File Offset: 0x00A2BBF5
		public unsafe int SplinePointsIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SkillTrackCurve_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SkillTrackCurve_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006703 RID: 26371
		// (get) Token: 0x060296B5 RID: 169653 RVA: 0x00A2DA08 File Offset: 0x00A2BC08
		// (set) Token: 0x060296B6 RID: 169654 RVA: 0x00A2DA41 File Offset: 0x00A2BC41
		public TMap<int, FSplinePoint> SplinePointsMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, FSplinePoint> result;
				if ((result = this._SplinePointsMap) == null)
				{
					result = (this._SplinePointsMap = new TMap<int, FSplinePoint>(base.NativePtr + (IntPtr)BP_SkillTrackCurve_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				this.SplinePointsMap.CopyAssign(value);
			}
		}

		// Token: 0x060296B7 RID: 169655 RVA: 0x00A2DA4F File Offset: 0x00A2BC4F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateSplineData()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SkillTrackCurve_C.__UpdateSplineData_NativeFunctionPtr, null);
		}

		// Token: 0x060296B8 RID: 169656 RVA: 0x00A2DA63 File Offset: 0x00A2BC63
		protected BP_SkillTrackCurve_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040160FB RID: 90363
		public new const string __ObjectPath = "/Game/Aki/Character/Role/FemaleM/Zhezhi/Data/BP_SkillTrackCurve.BP_SkillTrackCurve_C";

		// Token: 0x040160FC RID: 90364
		private static IntPtr _ClassPtr;

		// Token: 0x040160FD RID: 90365
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040160FE RID: 90366
		internal static int __PropertyOffset_0;

		// Token: 0x040160FF RID: 90367
		internal static int __PropertyOffset_1;

		// Token: 0x04016100 RID: 90368
		internal static int __PropertyOffset_2;

		// Token: 0x04016101 RID: 90369
		internal static int __PropertyOffset_3;

		// Token: 0x04016102 RID: 90370
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, FSplinePoint> _SplinePointsMap;

		// Token: 0x04016103 RID: 90371
		private static IntPtr __UpdateSplineData_NativeFunctionPtr;
	}
}
