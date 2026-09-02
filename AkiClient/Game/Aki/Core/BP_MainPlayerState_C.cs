using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F37 RID: 16183
	[UnrealObjectPath("/Game/Aki/Core/BP_MainPlayerState.BP_MainPlayerState_C")]
	[UnrealStructLayout(1304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1304)]
	public class BP_MainPlayerState_C : APlayerState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028679 RID: 165497 RVA: 0x00A0983D File Offset: 0x00A07A3D
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MainPlayerState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_MainPlayerState.BP_MainPlayerState_C");
			}
			return BP_MainPlayerState_C._ClassPtr;
		}

		// Token: 0x0602867A RID: 165498 RVA: 0x00A09864 File Offset: 0x00A07A64
		public BP_MainPlayerState_C() : this(BuiltinUtils.AllocNativeUObject(BP_MainPlayerState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602867B RID: 165499 RVA: 0x00A0988C File Offset: 0x00A07A8C
		[NullableContext(1)]
		public BP_MainPlayerState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MainPlayerState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006229 RID: 25129
		// (get) Token: 0x0602867C RID: 165500 RVA: 0x00A098BF File Offset: 0x00A07ABF
		// (set) Token: 0x0602867D RID: 165501 RVA: 0x00A098D3 File Offset: 0x00A07AD3
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainPlayerState_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainPlayerState_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602867E RID: 165502 RVA: 0x00A098E8 File Offset: 0x00A07AE8
		protected BP_MainPlayerState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015401 RID: 87041
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_MainPlayerState.BP_MainPlayerState_C";

		// Token: 0x04015402 RID: 87042
		private static IntPtr _ClassPtr;

		// Token: 0x04015403 RID: 87043
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015404 RID: 87044
		internal static int __PropertyOffset_0;
	}
}
