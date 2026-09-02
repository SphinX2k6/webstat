using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.GI.UI;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI
{
	// Token: 0x02003A22 RID: 14882
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/BP_UIScene.BP_UIScene_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1049)]
	public class BP_UIScene_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601E995 RID: 125333 RVA: 0x008F90BC File Offset: 0x008F72BC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_UIScene_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/BP_UIScene.BP_UIScene_C");
			}
			return BP_UIScene_C._ClassPtr;
		}

		// Token: 0x0601E996 RID: 125334 RVA: 0x008F90E0 File Offset: 0x008F72E0
		public BP_UIScene_C() : this(BuiltinUtils.AllocNativeUObject(BP_UIScene_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E997 RID: 125335 RVA: 0x008F9108 File Offset: 0x008F7308
		[NullableContext(1)]
		public BP_UIScene_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_UIScene_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B74 RID: 11124
		// (get) Token: 0x0601E998 RID: 125336 RVA: 0x008F913B File Offset: 0x008F733B
		// (set) Token: 0x0601E999 RID: 125337 RVA: 0x008F914F File Offset: 0x008F734F
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002B75 RID: 11125
		// (get) Token: 0x0601E99A RID: 125338 RVA: 0x008F9164 File Offset: 0x008F7364
		// (set) Token: 0x0601E99B RID: 125339 RVA: 0x008F9178 File Offset: 0x008F7378
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B76 RID: 11126
		// (get) Token: 0x0601E99C RID: 125340 RVA: 0x008F918D File Offset: 0x008F738D
		// (set) Token: 0x0601E99D RID: 125341 RVA: 0x008F91A1 File Offset: 0x008F73A1
		public unsafe PDA_GIUIData_C GIUIData
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PDA_GIUIData_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_UIScene_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002B77 RID: 11127
		// (get) Token: 0x0601E99E RID: 125342 RVA: 0x008F91B6 File Offset: 0x008F73B6
		// (set) Token: 0x0601E99F RID: 125343 RVA: 0x008F91C6 File Offset: 0x008F73C6
		public unsafe bool IsNewUiScene
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_UIScene_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_UIScene_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x0601E9A0 RID: 125344 RVA: 0x008F91D7 File Offset: 0x008F73D7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_UIScene_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0601E9A1 RID: 125345 RVA: 0x008F91EB File Offset: 0x008F73EB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_UIScene_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601E9A2 RID: 125346 RVA: 0x008F9200 File Offset: 0x008F7400
		protected BP_UIScene_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F156 RID: 61782
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/BP_UIScene.BP_UIScene_C";

		// Token: 0x0400F157 RID: 61783
		private static IntPtr _ClassPtr;

		// Token: 0x0400F158 RID: 61784
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F159 RID: 61785
		internal static int __PropertyOffset_0;

		// Token: 0x0400F15A RID: 61786
		internal static int __PropertyOffset_1;

		// Token: 0x0400F15B RID: 61787
		internal static int __PropertyOffset_2;

		// Token: 0x0400F15C RID: 61788
		internal static int __PropertyOffset_3;

		// Token: 0x0400F15D RID: 61789
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
