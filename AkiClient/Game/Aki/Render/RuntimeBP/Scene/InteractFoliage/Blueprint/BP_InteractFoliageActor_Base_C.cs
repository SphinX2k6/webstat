using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.InteractFoliage.Blueprint
{
	// Token: 0x02003AD1 RID: 15057
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_Base.BP_InteractFoliageActor_Base_C")]
	[UnrealStructLayout(1304, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1304)]
	public class BP_InteractFoliageActor_Base_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020328 RID: 131880 RVA: 0x00924F8B File Offset: 0x0092318B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_InteractFoliageActor_Base_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_Base.BP_InteractFoliageActor_Base_C");
			}
			return BP_InteractFoliageActor_Base_C._ClassPtr;
		}

		// Token: 0x06020329 RID: 131881 RVA: 0x00924FB0 File Offset: 0x009231B0
		public BP_InteractFoliageActor_Base_C() : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_Base_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602032A RID: 131882 RVA: 0x00924FD8 File Offset: 0x009231D8
		[NullableContext(1)]
		public BP_InteractFoliageActor_Base_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_InteractFoliageActor_Base_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003463 RID: 13411
		// (get) Token: 0x0602032B RID: 131883 RVA: 0x0092500B File Offset: 0x0092320B
		// (set) Token: 0x0602032C RID: 131884 RVA: 0x0092501F File Offset: 0x0092321F
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_Base_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_InteractFoliageActor_Base_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x0602032D RID: 131885 RVA: 0x00925034 File Offset: 0x00923234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetVisible(bool visible)
		{
			BP_InteractFoliageActor_Base_C.__SetVisible_FunctionParams* ptr = stackalloc BP_InteractFoliageActor_Base_C.__SetVisible_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_InteractFoliageActor_Base_C.__SetVisible_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_InteractFoliageActor_Base_C.__SetVisible_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visible = visible;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_InteractFoliageActor_Base_C.__SetVisible_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602032E RID: 131886 RVA: 0x0092507A File Offset: 0x0092327A
		protected BP_InteractFoliageActor_Base_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040100D7 RID: 65751
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/InteractFoliage/Blueprint/BP_InteractFoliageActor_Base.BP_InteractFoliageActor_Base_C";

		// Token: 0x040100D8 RID: 65752
		private static IntPtr _ClassPtr;

		// Token: 0x040100D9 RID: 65753
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040100DA RID: 65754
		internal static int __PropertyOffset_0;

		// Token: 0x040100DB RID: 65755
		private static IntPtr __SetVisible_NativeFunctionPtr;

		// Token: 0x02009970 RID: 39280
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SetVisible_FunctionParams
		{
			// Token: 0x04031FEE RID: 204782
			[FieldOffset(0)]
			public bool visible;
		}
	}
}
