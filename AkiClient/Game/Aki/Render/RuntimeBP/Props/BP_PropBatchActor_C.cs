using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Props
{
	// Token: 0x02003B4A RID: 15178
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Props/BP_PropBatchActor.BP_PropBatchActor_C")]
	[UnrealStructLayout(1032, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1032)]
	public class BP_PropBatchActor_C : APropBatchActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020EC6 RID: 134854 RVA: 0x0093AF60 File Offset: 0x00939160
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PropBatchActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Props/BP_PropBatchActor.BP_PropBatchActor_C");
			}
			return BP_PropBatchActor_C._ClassPtr;
		}

		// Token: 0x06020EC7 RID: 134855 RVA: 0x0093AF84 File Offset: 0x00939184
		public BP_PropBatchActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_PropBatchActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020EC8 RID: 134856 RVA: 0x0093AFAC File Offset: 0x009391AC
		[NullableContext(1)]
		public BP_PropBatchActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PropBatchActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x06020EC9 RID: 134857 RVA: 0x0093AFDF File Offset: 0x009391DF
		protected BP_PropBatchActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010867 RID: 67687
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Props/BP_PropBatchActor.BP_PropBatchActor_C";

		// Token: 0x04010868 RID: 67688
		private static IntPtr _ClassPtr;

		// Token: 0x04010869 RID: 67689
		private static IntPtr _ClassDefaultObjectPtr;
	}
}
