using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.AI.AIMoveSplineCount
{
	// Token: 0x02004385 RID: 17285
	[UnrealObjectPath("/Game/Aki/AI/AIMoveSplineCount/CommonEffectMoveSpline2.CommonEffectMoveSpline2_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class CommonEffectMoveSpline2_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DD2D RID: 187693 RVA: 0x00ACCFAC File Offset: 0x00ACB1AC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (CommonEffectMoveSpline2_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/AI/AIMoveSplineCount/CommonEffectMoveSpline2.CommonEffectMoveSpline2_C");
			}
			return CommonEffectMoveSpline2_C._ClassPtr;
		}

		// Token: 0x0602DD2E RID: 187694 RVA: 0x00ACCFD0 File Offset: 0x00ACB1D0
		public CommonEffectMoveSpline2_C() : this(BuiltinUtils.AllocNativeUObject(CommonEffectMoveSpline2_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DD2F RID: 187695 RVA: 0x00ACCFF8 File Offset: 0x00ACB1F8
		[NullableContext(1)]
		public CommonEffectMoveSpline2_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CommonEffectMoveSpline2_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D9B RID: 32155
		// (get) Token: 0x0602DD30 RID: 187696 RVA: 0x00ACD02B File Offset: 0x00ACB22B
		// (set) Token: 0x0602DD31 RID: 187697 RVA: 0x00ACD03F File Offset: 0x00ACB23F
		[Nullable(2)]
		public unsafe UKuroMoveSplineComponent KuroMoveSpline
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroMoveSplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + CommonEffectMoveSpline2_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + CommonEffectMoveSpline2_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602DD32 RID: 187698 RVA: 0x00ACD054 File Offset: 0x00ACB254
		protected CommonEffectMoveSpline2_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019DF9 RID: 105977
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/AI/AIMoveSplineCount/CommonEffectMoveSpline2.CommonEffectMoveSpline2_C";

		// Token: 0x04019DFA RID: 105978
		private static IntPtr _ClassPtr;

		// Token: 0x04019DFB RID: 105979
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019DFC RID: 105980
		internal static int __PropertyOffset_0;
	}
}
