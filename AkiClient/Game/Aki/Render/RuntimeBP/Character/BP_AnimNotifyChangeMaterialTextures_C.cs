using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character
{
	// Token: 0x02003D5A RID: 15706
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/BP_AnimNotifyChangeMaterialTextures.BP_AnimNotifyChangeMaterialTextures_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 128)]
	public class BP_AnimNotifyChangeMaterialTextures_C : UKuroAnimNotify, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060262D9 RID: 156377 RVA: 0x009D0097 File Offset: 0x009CE297
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AnimNotifyChangeMaterialTextures_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/BP_AnimNotifyChangeMaterialTextures.BP_AnimNotifyChangeMaterialTextures_C");
			}
			return BP_AnimNotifyChangeMaterialTextures_C._ClassPtr;
		}

		// Token: 0x060262DA RID: 156378 RVA: 0x009D00BC File Offset: 0x009CE2BC
		public BP_AnimNotifyChangeMaterialTextures_C() : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotifyChangeMaterialTextures_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060262DB RID: 156379 RVA: 0x009D00E4 File Offset: 0x009CE2E4
		public BP_AnimNotifyChangeMaterialTextures_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AnimNotifyChangeMaterialTextures_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055DF RID: 21983
		// (get) Token: 0x060262DC RID: 156380 RVA: 0x009D0117 File Offset: 0x009CE317
		// (set) Token: 0x060262DD RID: 156381 RVA: 0x009D012C File Offset: 0x009CE32C
		public TSoftObjectPtr<UKuroChangeMaterialsTextures> Config
		{
			get
			{
				return new TSoftObjectPtr<UKuroChangeMaterialsTextures>(base.NativePtr + (IntPtr)BP_AnimNotifyChangeMaterialTextures_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_AnimNotifyChangeMaterialTextures_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x060262DE RID: 156382 RVA: 0x009D0154 File Offset: 0x009CE354
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override bool K2_Notify(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams* ptr = stackalloc BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x060262DF RID: 156383 RVA: 0x009D01C8 File Offset: 0x009CE3C8
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual bool K2_Notify_Implementation(USkeletalMeshComponent MeshComp, UAnimSequenceBase Animation)
		{
			BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams* ptr = stackalloc BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams[(UIntPtr)87] + 15L / (long)sizeof(BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_NativeFunctionPtr, (void*)ptr, 1);
			ptr->MeshComp = ((MeshComp != null) ? MeshComp.NativePtr : IntPtr.Zero);
			ptr->Animation = ((Animation != null) ? Animation.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AnimNotifyChangeMaterialTextures_C.__K2_Notify_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x060262E0 RID: 156384 RVA: 0x009D023A File Offset: 0x009CE43A
		protected BP_AnimNotifyChangeMaterialTextures_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C76 RID: 81014
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/BP_AnimNotifyChangeMaterialTextures.BP_AnimNotifyChangeMaterialTextures_C";

		// Token: 0x04013C77 RID: 81015
		private static IntPtr _ClassPtr;

		// Token: 0x04013C78 RID: 81016
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C79 RID: 81017
		internal static int __PropertyOffset_0;

		// Token: 0x04013C7A RID: 81018
		private static IntPtr __K2_Notify_NativeFunctionPtr;

		// Token: 0x0200A014 RID: 40980
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 72)]
		protected new ref struct __K2_Notify_FunctionParams
		{
			// Token: 0x04032BFB RID: 207867
			[FieldOffset(0)]
			public IntPtr MeshComp;

			// Token: 0x04032BFC RID: 207868
			[FieldOffset(8)]
			public IntPtr Animation;

			// Token: 0x04032BFD RID: 207869
			[FieldOffset(16)]
			public bool __Result;
		}
	}
}
