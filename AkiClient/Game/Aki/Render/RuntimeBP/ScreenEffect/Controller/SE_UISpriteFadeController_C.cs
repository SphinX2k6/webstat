using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Controller
{
	// Token: 0x02003A73 RID: 14963
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteFadeController.SE_UISpriteFadeController_C")]
	[UnrealStructLayout(272, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 272)]
	public class SE_UISpriteFadeController_C : SE_UISpriteController_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601F34A RID: 127818 RVA: 0x0090B55C File Offset: 0x0090975C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (SE_UISpriteFadeController_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteFadeController.SE_UISpriteFadeController_C");
			}
			return SE_UISpriteFadeController_C._ClassPtr;
		}

		// Token: 0x0601F34B RID: 127819 RVA: 0x0090B580 File Offset: 0x00909780
		public SE_UISpriteFadeController_C() : this(BuiltinUtils.AllocNativeUObject(SE_UISpriteFadeController_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601F34C RID: 127820 RVA: 0x0090B5A8 File Offset: 0x009097A8
		[NullableContext(1)]
		public SE_UISpriteFadeController_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SE_UISpriteFadeController_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002E8C RID: 11916
		// (get) Token: 0x0601F34D RID: 127821 RVA: 0x0090B5DC File Offset: 0x009097DC
		// (set) Token: 0x0601F34E RID: 127822 RVA: 0x0090B615 File Offset: 0x00909815
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)SE_UISpriteFadeController_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)SE_UISpriteFadeController_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601F34F RID: 127823 RVA: 0x0090B638 File Offset: 0x00909838
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ApplyVisibility(bool visibility)
		{
			SE_UISpriteFadeController_C.__ApplyVisibility_FunctionParams* ptr = stackalloc SE_UISpriteFadeController_C.__ApplyVisibility_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UISpriteFadeController_C.__ApplyVisibility_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteFadeController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr, 1);
			ptr->visibility = visibility;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteFadeController_C.__ApplyVisibility_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F350 RID: 127824 RVA: 0x0090B680 File Offset: 0x00909880
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteFadeController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, SE_UISpriteFadeController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601F351 RID: 127825 RVA: 0x0090B6CC File Offset: 0x009098CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe override void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(SE_UISpriteFadeController_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteFadeController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteFadeController_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F352 RID: 127826 RVA: 0x0090B718 File Offset: 0x00909918
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_SE_UISpriteFadeController(int EntryPoint)
		{
			SE_UISpriteFadeController_C.__ExecuteUbergraph_SE_UISpriteFadeController_FunctionParams* ptr = stackalloc SE_UISpriteFadeController_C.__ExecuteUbergraph_SE_UISpriteFadeController_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(SE_UISpriteFadeController_C.__ExecuteUbergraph_SE_UISpriteFadeController_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(SE_UISpriteFadeController_C.__ExecuteUbergraph_SE_UISpriteFadeController_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, SE_UISpriteFadeController_C.__ExecuteUbergraph_SE_UISpriteFadeController_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601F353 RID: 127827 RVA: 0x0090B75F File Offset: 0x0090995F
		protected SE_UISpriteFadeController_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F791 RID: 63377
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/ScreenEffect/Controller/SE_UISpriteFadeController.SE_UISpriteFadeController_C";

		// Token: 0x0400F792 RID: 63378
		private static IntPtr _ClassPtr;

		// Token: 0x0400F793 RID: 63379
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F794 RID: 63380
		internal new static int __PropertyOffset_0;

		// Token: 0x0400F795 RID: 63381
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F796 RID: 63382
		private static IntPtr __ApplyVisibility_NativeFunctionPtr;

		// Token: 0x0400F797 RID: 63383
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x0400F798 RID: 63384
		private static IntPtr __ExecuteUbergraph_SE_UISpriteFadeController_NativeFunctionPtr;

		// Token: 0x020098A5 RID: 39077
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ApplyVisibility_FunctionParams
		{
			// Token: 0x04031EED RID: 204525
			[FieldOffset(0)]
			public bool visibility;
		}

		// Token: 0x020098A6 RID: 39078
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x04031EEE RID: 204526
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x020098A7 RID: 39079
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ExecuteUbergraph_SE_UISpriteFadeController_FunctionParams
		{
			// Token: 0x04031EEF RID: 204527
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
