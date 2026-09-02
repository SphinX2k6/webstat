using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7D RID: 15485
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_DollGrabLight.BP_DollGrabLight_C")]
	[UnrealStructLayout(1360, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1360)]
	public class BP_DollGrabLight_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06023FEF RID: 147439 RVA: 0x00991CFC File Offset: 0x0098FEFC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DollGrabLight_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_DollGrabLight.BP_DollGrabLight_C");
			}
			return BP_DollGrabLight_C._ClassPtr;
		}

		// Token: 0x06023FF0 RID: 147440 RVA: 0x00991D20 File Offset: 0x0098FF20
		public BP_DollGrabLight_C() : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabLight_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06023FF1 RID: 147441 RVA: 0x00991D48 File Offset: 0x0098FF48
		[NullableContext(1)]
		public BP_DollGrabLight_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DollGrabLight_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004971 RID: 18801
		// (get) Token: 0x06023FF2 RID: 147442 RVA: 0x00991D7B File Offset: 0x0098FF7B
		// (set) Token: 0x06023FF3 RID: 147443 RVA: 0x00991D8F File Offset: 0x0098FF8F
		public unsafe UStaticMeshComponent Light3
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17004972 RID: 18802
		// (get) Token: 0x06023FF4 RID: 147444 RVA: 0x00991DA4 File Offset: 0x0098FFA4
		// (set) Token: 0x06023FF5 RID: 147445 RVA: 0x00991DB8 File Offset: 0x0098FFB8
		public unsafe UStaticMeshComponent Light2
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004973 RID: 18803
		// (get) Token: 0x06023FF6 RID: 147446 RVA: 0x00991DCD File Offset: 0x0098FFCD
		// (set) Token: 0x06023FF7 RID: 147447 RVA: 0x00991DE1 File Offset: 0x0098FFE1
		public unsafe UStaticMeshComponent Light1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17004974 RID: 18804
		// (get) Token: 0x06023FF8 RID: 147448 RVA: 0x00991DF6 File Offset: 0x0098FFF6
		// (set) Token: 0x06023FF9 RID: 147449 RVA: 0x00991E0A File Offset: 0x0099000A
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DollGrabLight_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17004975 RID: 18805
		// (get) Token: 0x06023FFA RID: 147450 RVA: 0x00991E1F File Offset: 0x0099001F
		// (set) Token: 0x06023FFB RID: 147451 RVA: 0x00991E2F File Offset: 0x0099002F
		public unsafe int LightIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_DollGrabLight_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_DollGrabLight_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17004976 RID: 18806
		// (get) Token: 0x06023FFC RID: 147452 RVA: 0x00991E40 File Offset: 0x00990040
		// (set) Token: 0x06023FFD RID: 147453 RVA: 0x00991E79 File Offset: 0x00990079
		[Nullable(1)]
		public TArray<UStaticMeshComponent> LightArray
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TArray<UStaticMeshComponent> result;
				if ((result = this._LightArray) == null)
				{
					result = (this._LightArray = new TArray<UStaticMeshComponent>(base.NativePtr + (IntPtr)BP_DollGrabLight_C.__PropertyOffset_5, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.LightArray.CopyAssign(value);
			}
		}

		// Token: 0x06023FFE RID: 147454 RVA: 0x00991E87 File Offset: 0x00990087
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LightOff()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabLight_C.__LightOff_NativeFunctionPtr, null);
		}

		// Token: 0x06023FFF RID: 147455 RVA: 0x00991E9B File Offset: 0x0099009B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LightOn()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabLight_C.__LightOn_NativeFunctionPtr, null);
		}

		// Token: 0x06024000 RID: 147456 RVA: 0x00991EAF File Offset: 0x009900AF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DollGrabLight_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024001 RID: 147457 RVA: 0x00991EC3 File Offset: 0x009900C3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_DollGrabLight_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024002 RID: 147458 RVA: 0x00991ED8 File Offset: 0x009900D8
		protected BP_DollGrabLight_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012650 RID: 75344
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_DollGrabLight.BP_DollGrabLight_C";

		// Token: 0x04012651 RID: 75345
		private static IntPtr _ClassPtr;

		// Token: 0x04012652 RID: 75346
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012653 RID: 75347
		internal static int __PropertyOffset_0;

		// Token: 0x04012654 RID: 75348
		internal static int __PropertyOffset_1;

		// Token: 0x04012655 RID: 75349
		internal static int __PropertyOffset_2;

		// Token: 0x04012656 RID: 75350
		internal static int __PropertyOffset_3;

		// Token: 0x04012657 RID: 75351
		internal static int __PropertyOffset_4;

		// Token: 0x04012658 RID: 75352
		internal static int __PropertyOffset_5;

		// Token: 0x04012659 RID: 75353
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UStaticMeshComponent> _LightArray;

		// Token: 0x0401265A RID: 75354
		private static IntPtr __LightOff_NativeFunctionPtr;

		// Token: 0x0401265B RID: 75355
		private static IntPtr __LightOn_NativeFunctionPtr;

		// Token: 0x0401265C RID: 75356
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
