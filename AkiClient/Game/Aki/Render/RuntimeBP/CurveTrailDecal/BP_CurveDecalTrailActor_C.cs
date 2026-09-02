using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.CurveTrailDecal
{
	// Token: 0x02003D54 RID: 15700
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailActor.BP_CurveDecalTrailActor_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_CurveDecalTrailActor_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602621E RID: 156190 RVA: 0x009CED07 File Offset: 0x009CCF07
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CurveDecalTrailActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailActor.BP_CurveDecalTrailActor_C");
			}
			return BP_CurveDecalTrailActor_C._ClassPtr;
		}

		// Token: 0x0602621F RID: 156191 RVA: 0x009CED2C File Offset: 0x009CCF2C
		public BP_CurveDecalTrailActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_CurveDecalTrailActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026220 RID: 156192 RVA: 0x009CED54 File Offset: 0x009CCF54
		[NullableContext(1)]
		public BP_CurveDecalTrailActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CurveDecalTrailActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700559F RID: 21919
		// (get) Token: 0x06026221 RID: 156193 RVA: 0x009CED87 File Offset: 0x009CCF87
		// (set) Token: 0x06026222 RID: 156194 RVA: 0x009CED9B File Offset: 0x009CCF9B
		public unsafe BP_CurveDecalTrailComponent_C BP_CurveDecalTrailComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_CurveDecalTrailComponent_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170055A0 RID: 21920
		// (get) Token: 0x06026223 RID: 156195 RVA: 0x009CEDB0 File Offset: 0x009CCFB0
		// (set) Token: 0x06026224 RID: 156196 RVA: 0x009CEDC4 File Offset: 0x009CCFC4
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170055A1 RID: 21921
		// (get) Token: 0x06026225 RID: 156197 RVA: 0x009CEDD9 File Offset: 0x009CCFD9
		// (set) Token: 0x06026226 RID: 156198 RVA: 0x009CEDED File Offset: 0x009CCFED
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CurveDecalTrailActor_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06026227 RID: 156199 RVA: 0x009CEE02 File Offset: 0x009CD002
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Refresh()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_CurveDecalTrailActor_C.__Refresh_NativeFunctionPtr, null);
		}

		// Token: 0x06026228 RID: 156200 RVA: 0x009CEE16 File Offset: 0x009CD016
		protected BP_CurveDecalTrailActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C05 RID: 80901
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/CurveTrailDecal/BP_CurveDecalTrailActor.BP_CurveDecalTrailActor_C";

		// Token: 0x04013C06 RID: 80902
		private static IntPtr _ClassPtr;

		// Token: 0x04013C07 RID: 80903
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C08 RID: 80904
		internal static int __PropertyOffset_0;

		// Token: 0x04013C09 RID: 80905
		internal static int __PropertyOffset_1;

		// Token: 0x04013C0A RID: 80906
		internal static int __PropertyOffset_2;

		// Token: 0x04013C0B RID: 80907
		private static IntPtr __Refresh_NativeFunctionPtr;
	}
}
