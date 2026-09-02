using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x0200428E RID: 17038
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/BPL_BulletPreview.BPL_BulletPreview_C")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 48)]
	public class BPL_BulletPreview_C : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D41C RID: 185372 RVA: 0x00ABB3DB File Offset: 0x00AB95DB
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BPL_BulletPreview_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/Tools/BPL_BulletPreview.BPL_BulletPreview_C");
			}
			return BPL_BulletPreview_C._ClassPtr;
		}

		// Token: 0x0602D41D RID: 185373 RVA: 0x00ABB400 File Offset: 0x00AB9600
		public BPL_BulletPreview_C() : this(BuiltinUtils.AllocNativeUObject(BPL_BulletPreview_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D41E RID: 185374 RVA: 0x00ABB428 File Offset: 0x00AB9628
		[NullableContext(1)]
		public BPL_BulletPreview_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BPL_BulletPreview_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x0602D41F RID: 185375 RVA: 0x00ABB45C File Offset: 0x00AB965C
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe static void ShowBulletPreview([Nullable(1)] string 子弹表路径, FName 子弹ID, AActor 拥有者, USkeletalMeshComponent meshComp, UObject __WorldContext, ref AActor Ret)
		{
			BPL_BulletPreview_C.StaticClass();
			BPL_BulletPreview_C.__ShowBulletPreview_FunctionParams* ptr = stackalloc BPL_BulletPreview_C.__ShowBulletPreview_FunctionParams[(UIntPtr)4175] + 15L / (long)sizeof(BPL_BulletPreview_C.__ShowBulletPreview_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BPL_BulletPreview_C.__ShowBulletPreview_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->子弹表路径), 子弹表路径);
			ptr->子弹ID = 子弹ID;
			ptr->拥有者 = ((拥有者 != null) ? 拥有者.NativePtr : IntPtr.Zero);
			ptr->meshComp = ((meshComp != null) ? meshComp.NativePtr : IntPtr.Zero);
			ptr->__WorldContext = ((__WorldContext != null) ? __WorldContext.NativePtr : IntPtr.Zero);
			ref BPL_BulletPreview_C.__ShowBulletPreview_FunctionParams ptr2 = ref *ptr;
			AActor aactor = Ret;
			ptr2.Ret = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(BPL_BulletPreview_C._ClassDefaultObjectPtr, BPL_BulletPreview_C.__ShowBulletPreview_NativeFunctionPtr, (void*)ptr);
			Ret = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->Ret);
			UnrealReflectionUtils.DestroyStruct(BPL_BulletPreview_C.__ShowBulletPreview_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602D420 RID: 185376 RVA: 0x00ABB533 File Offset: 0x00AB9733
		protected BPL_BulletPreview_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040195EB RID: 103915
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/BPL_BulletPreview.BPL_BulletPreview_C";

		// Token: 0x040195EC RID: 103916
		private static IntPtr _ClassPtr;

		// Token: 0x040195ED RID: 103917
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040195EE RID: 103918
		private static IntPtr __ShowBulletPreview_NativeFunctionPtr;

		// Token: 0x0200A526 RID: 42278
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4160)]
		protected ref struct __ShowBulletPreview_FunctionParams
		{
			// Token: 0x040333CD RID: 209869
			[FieldOffset(0)]
			public FString 子弹表路径;

			// Token: 0x040333CE RID: 209870
			[FieldOffset(16)]
			public FName 子弹ID;

			// Token: 0x040333CF RID: 209871
			[FieldOffset(32)]
			public IntPtr 拥有者;

			// Token: 0x040333D0 RID: 209872
			[FieldOffset(40)]
			public IntPtr meshComp;

			// Token: 0x040333D1 RID: 209873
			[FieldOffset(48)]
			public IntPtr __WorldContext;

			// Token: 0x040333D2 RID: 209874
			[FieldOffset(56)]
			public IntPtr Ret;
		}
	}
}
