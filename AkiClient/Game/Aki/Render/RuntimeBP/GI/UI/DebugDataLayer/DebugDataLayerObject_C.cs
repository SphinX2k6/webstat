using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugDataLayer
{
	// Token: 0x02003CA5 RID: 15525
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/DebugDataLayerObject.DebugDataLayerObject_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 65)]
	public class DebugDataLayerObject_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602499B RID: 149915 RVA: 0x009A2497 File Offset: 0x009A0697
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DebugDataLayerObject_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/DebugDataLayerObject.DebugDataLayerObject_C");
			}
			return DebugDataLayerObject_C._ClassPtr;
		}

		// Token: 0x0602499C RID: 149916 RVA: 0x009A24BC File Offset: 0x009A06BC
		public DebugDataLayerObject_C() : this(BuiltinUtils.AllocNativeUObject(DebugDataLayerObject_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602499D RID: 149917 RVA: 0x009A24E4 File Offset: 0x009A06E4
		public DebugDataLayerObject_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DebugDataLayerObject_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CEB RID: 19691
		// (get) Token: 0x0602499E RID: 149918 RVA: 0x009A2517 File Offset: 0x009A0717
		// (set) Token: 0x0602499F RID: 149919 RVA: 0x009A252B File Offset: 0x009A072B
		public unsafe string DataLayerName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)DebugDataLayerObject_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)DebugDataLayerObject_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17004CEC RID: 19692
		// (get) Token: 0x060249A0 RID: 149920 RVA: 0x009A2540 File Offset: 0x009A0740
		// (set) Token: 0x060249A1 RID: 149921 RVA: 0x009A2550 File Offset: 0x009A0750
		public unsafe bool DataLayerEnable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DebugDataLayerObject_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DebugDataLayerObject_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x060249A2 RID: 149922 RVA: 0x009A2561 File Offset: 0x009A0761
		protected DebugDataLayerObject_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012C35 RID: 76853
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugDataLayer/DebugDataLayerObject.DebugDataLayerObject_C";

		// Token: 0x04012C36 RID: 76854
		private static IntPtr _ClassPtr;

		// Token: 0x04012C37 RID: 76855
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C38 RID: 76856
		internal static int __PropertyOffset_0;

		// Token: 0x04012C39 RID: 76857
		internal static int __PropertyOffset_1;
	}
}
