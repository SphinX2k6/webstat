using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Weather.BP.Thunder
{
	// Token: 0x02003A02 RID: 14850
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderTrigger.BP_ThunderTrigger_C")]
	[UnrealStructLayout(1072, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1072)]
	public class BP_ThunderTrigger_C : AThunderTrigger, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E428 RID: 123944 RVA: 0x008F11E7 File Offset: 0x008EF3E7
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_ThunderTrigger_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderTrigger.BP_ThunderTrigger_C");
			}
			return BP_ThunderTrigger_C._ClassPtr;
		}

		// Token: 0x0601E429 RID: 123945 RVA: 0x008F120C File Offset: 0x008EF40C
		public BP_ThunderTrigger_C() : this(BuiltinUtils.AllocNativeUObject(BP_ThunderTrigger_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E42A RID: 123946 RVA: 0x008F1234 File Offset: 0x008EF434
		[NullableContext(1)]
		public BP_ThunderTrigger_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_ThunderTrigger_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700293A RID: 10554
		// (get) Token: 0x0601E42B RID: 123947 RVA: 0x008F1267 File Offset: 0x008EF467
		// (set) Token: 0x0601E42C RID: 123948 RVA: 0x008F127B File Offset: 0x008EF47B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderTrigger_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_ThunderTrigger_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0601E42D RID: 123949 RVA: 0x008F1290 File Offset: 0x008EF490
		protected BP_ThunderTrigger_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400EE0E RID: 60942
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Weather/BP/Thunder/BP_ThunderTrigger.BP_ThunderTrigger_C";

		// Token: 0x0400EE0F RID: 60943
		private static IntPtr _ClassPtr;

		// Token: 0x0400EE10 RID: 60944
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400EE11 RID: 60945
		internal static int __PropertyOffset_0;
	}
}
