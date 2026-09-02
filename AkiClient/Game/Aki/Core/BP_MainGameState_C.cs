using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core
{
	// Token: 0x02003F36 RID: 16182
	[UnrealObjectPath("/Game/Aki/Core/BP_MainGameState.BP_MainGameState_C")]
	[UnrealStructLayout(1160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1160)]
	public class BP_MainGameState_C : AGameState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028673 RID: 165491 RVA: 0x00A0978C File Offset: 0x00A0798C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_MainGameState_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/BP_MainGameState.BP_MainGameState_C");
			}
			return BP_MainGameState_C._ClassPtr;
		}

		// Token: 0x06028674 RID: 165492 RVA: 0x00A097B0 File Offset: 0x00A079B0
		public BP_MainGameState_C() : this(BuiltinUtils.AllocNativeUObject(BP_MainGameState_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028675 RID: 165493 RVA: 0x00A097D8 File Offset: 0x00A079D8
		[NullableContext(1)]
		public BP_MainGameState_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_MainGameState_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006228 RID: 25128
		// (get) Token: 0x06028676 RID: 165494 RVA: 0x00A0980B File Offset: 0x00A07A0B
		// (set) Token: 0x06028677 RID: 165495 RVA: 0x00A0981F File Offset: 0x00A07A1F
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainGameState_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_MainGameState_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06028678 RID: 165496 RVA: 0x00A09834 File Offset: 0x00A07A34
		protected BP_MainGameState_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040153FD RID: 87037
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/BP_MainGameState.BP_MainGameState_C";

		// Token: 0x040153FE RID: 87038
		private static IntPtr _ClassPtr;

		// Token: 0x040153FF RID: 87039
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015400 RID: 87040
		internal static int __PropertyOffset_0;
	}
}
