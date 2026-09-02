using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneTransition
{
	// Token: 0x02003B2C RID: 15148
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneTransition/BP_StaticMesh_SceneTransition_Hongguang.BP_StaticMesh_SceneTransition_Hongguang_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_StaticMesh_SceneTransition_Hongguang_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020A9B RID: 133787 RVA: 0x00933358 File Offset: 0x00931558
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_StaticMesh_SceneTransition_Hongguang_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_StaticMesh_SceneTransition_Hongguang.BP_StaticMesh_SceneTransition_Hongguang_C");
			}
			return BP_StaticMesh_SceneTransition_Hongguang_C._ClassPtr;
		}

		// Token: 0x06020A9C RID: 133788 RVA: 0x0093337C File Offset: 0x0093157C
		public BP_StaticMesh_SceneTransition_Hongguang_C() : this(BuiltinUtils.AllocNativeUObject(BP_StaticMesh_SceneTransition_Hongguang_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020A9D RID: 133789 RVA: 0x009333A4 File Offset: 0x009315A4
		[NullableContext(1)]
		public BP_StaticMesh_SceneTransition_Hongguang_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_StaticMesh_SceneTransition_Hongguang_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700369E RID: 13982
		// (get) Token: 0x06020A9E RID: 133790 RVA: 0x009333D7 File Offset: 0x009315D7
		// (set) Token: 0x06020A9F RID: 133791 RVA: 0x009333EB File Offset: 0x009315EB
		public unsafe UStaticMeshComponent TransitionMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700369F RID: 13983
		// (get) Token: 0x06020AA0 RID: 133792 RVA: 0x00933400 File Offset: 0x00931600
		// (set) Token: 0x06020AA1 RID: 133793 RVA: 0x00933414 File Offset: 0x00931614
		public unsafe UStaticMeshComponent StaticMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170036A0 RID: 13984
		// (get) Token: 0x06020AA2 RID: 133794 RVA: 0x00933429 File Offset: 0x00931629
		// (set) Token: 0x06020AA3 RID: 133795 RVA: 0x0093343D File Offset: 0x0093163D
		public unsafe BP_SceneTransitionComponent_Hongguang_C BP_SceneTransitionComponent_Hongguang
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SceneTransitionComponent_Hongguang_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_StaticMesh_SceneTransition_Hongguang_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06020AA4 RID: 133796 RVA: 0x00933452 File Offset: 0x00931652
		protected BP_StaticMesh_SceneTransition_Hongguang_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105B8 RID: 67000
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_StaticMesh_SceneTransition_Hongguang.BP_StaticMesh_SceneTransition_Hongguang_C";

		// Token: 0x040105B9 RID: 67001
		private static IntPtr _ClassPtr;

		// Token: 0x040105BA RID: 67002
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105BB RID: 67003
		internal static int __PropertyOffset_0;

		// Token: 0x040105BC RID: 67004
		internal static int __PropertyOffset_1;

		// Token: 0x040105BD RID: 67005
		internal static int __PropertyOffset_2;
	}
}
