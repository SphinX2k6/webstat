using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint.MeshActor
{
	// Token: 0x02003AD5 RID: 15061
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/MeshActor/KUROInteractFoliage.KUROInteractFoliage_C")]
	[UnrealStructLayout(88, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 88)]
	public class KUROInteractFoliage_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020382 RID: 131970 RVA: 0x00925AAC File Offset: 0x00923CAC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (KUROInteractFoliage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/MeshActor/KUROInteractFoliage.KUROInteractFoliage_C");
			}
			return KUROInteractFoliage_C._ClassPtr;
		}

		// Token: 0x06020383 RID: 131971 RVA: 0x00925AD0 File Offset: 0x00923CD0
		public KUROInteractFoliage_C() : this(BuiltinUtils.AllocNativeUObject(KUROInteractFoliage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020384 RID: 131972 RVA: 0x00925AF8 File Offset: 0x00923CF8
		[NullableContext(1)]
		public KUROInteractFoliage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KUROInteractFoliage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700347B RID: 13435
		// (get) Token: 0x06020385 RID: 131973 RVA: 0x00925B2B File Offset: 0x00923D2B
		// (set) Token: 0x06020386 RID: 131974 RVA: 0x00925B3F File Offset: 0x00923D3F
		[Nullable(2)]
		public unsafe UStaticMesh KuroFoliageMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + KUROInteractFoliage_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + KUROInteractFoliage_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06020387 RID: 131975 RVA: 0x00925B54 File Offset: 0x00923D54
		protected KUROInteractFoliage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401010E RID: 65806
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/MeshActor/KUROInteractFoliage.KUROInteractFoliage_C";

		// Token: 0x0401010F RID: 65807
		private static IntPtr _ClassPtr;

		// Token: 0x04010110 RID: 65808
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010111 RID: 65809
		internal static int __PropertyOffset_0;
	}
}
