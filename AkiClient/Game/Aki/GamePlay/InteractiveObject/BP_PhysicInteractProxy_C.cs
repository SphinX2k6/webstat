using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.InteractiveObject
{
	// Token: 0x02003DD4 RID: 15828
	[UnrealObjectPath("/Game/Aki/GamePlay/InteractiveObject/BP_PhysicInteractProxy.BP_PhysicInteractProxy_C")]
	[UnrealStructLayout(1296, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1296)]
	public class BP_PhysicInteractProxy_C : AKuroGameBudgetBlueprintActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026C7E RID: 158846 RVA: 0x009E1D5E File Offset: 0x009DFF5E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PhysicInteractProxy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/InteractiveObject/BP_PhysicInteractProxy.BP_PhysicInteractProxy_C");
			}
			return BP_PhysicInteractProxy_C._ClassPtr;
		}

		// Token: 0x06026C7F RID: 158847 RVA: 0x009E1D84 File Offset: 0x009DFF84
		public BP_PhysicInteractProxy_C() : this(BuiltinUtils.AllocNativeUObject(BP_PhysicInteractProxy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026C80 RID: 158848 RVA: 0x009E1DAC File Offset: 0x009DFFAC
		[NullableContext(1)]
		public BP_PhysicInteractProxy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PhysicInteractProxy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700590E RID: 22798
		// (get) Token: 0x06026C81 RID: 158849 RVA: 0x009E1DDF File Offset: 0x009DFFDF
		// (set) Token: 0x06026C82 RID: 158850 RVA: 0x009E1DF3 File Offset: 0x009DFFF3
		[Nullable(2)]
		public unsafe UCapsuleComponent Capsule
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UCapsuleComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicInteractProxy_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PhysicInteractProxy_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x06026C83 RID: 158851 RVA: 0x009E1E08 File Offset: 0x009E0008
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetRadiusAndHeight(float radius, float height)
		{
			BP_PhysicInteractProxy_C.__SetRadiusAndHeight_FunctionParams* ptr = stackalloc BP_PhysicInteractProxy_C.__SetRadiusAndHeight_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_PhysicInteractProxy_C.__SetRadiusAndHeight_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_PhysicInteractProxy_C.__SetRadiusAndHeight_NativeFunctionPtr, (void*)ptr, 1);
			ptr->radius = radius;
			ptr->height = height;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PhysicInteractProxy_C.__SetRadiusAndHeight_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026C84 RID: 158852 RVA: 0x009E1E55 File Offset: 0x009E0055
		protected BP_PhysicInteractProxy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014397 RID: 82839
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/InteractiveObject/BP_PhysicInteractProxy.BP_PhysicInteractProxy_C";

		// Token: 0x04014398 RID: 82840
		private static IntPtr _ClassPtr;

		// Token: 0x04014399 RID: 82841
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401439A RID: 82842
		internal static int __PropertyOffset_0;

		// Token: 0x0401439B RID: 82843
		private static IntPtr __SetRadiusAndHeight_NativeFunctionPtr;

		// Token: 0x0200A0BF RID: 41151
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetRadiusAndHeight_FunctionParams
		{
			// Token: 0x04032D71 RID: 208241
			[FieldOffset(0)]
			public float radius;

			// Token: 0x04032D72 RID: 208242
			[FieldOffset(4)]
			public float height;
		}
	}
}
