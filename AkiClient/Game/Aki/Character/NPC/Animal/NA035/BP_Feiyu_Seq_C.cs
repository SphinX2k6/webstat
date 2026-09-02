using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Animal.NA035
{
	// Token: 0x0200415A RID: 16730
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/NPC/Animal/NA035/BP_Feiyu_Seq.BP_Feiyu_Seq_C")]
	[UnrealStructLayout(1048, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1048)]
	public class BP_Feiyu_Seq_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602C689 RID: 181897 RVA: 0x00AA06C8 File Offset: 0x00A9E8C8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Feiyu_Seq_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/NPC/Animal/NA035/BP_Feiyu_Seq.BP_Feiyu_Seq_C");
			}
			return BP_Feiyu_Seq_C._ClassPtr;
		}

		// Token: 0x0602C68A RID: 181898 RVA: 0x00AA06EC File Offset: 0x00A9E8EC
		public BP_Feiyu_Seq_C() : this(BuiltinUtils.AllocNativeUObject(BP_Feiyu_Seq_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C68B RID: 181899 RVA: 0x00AA0714 File Offset: 0x00A9E914
		[NullableContext(1)]
		public BP_Feiyu_Seq_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Feiyu_Seq_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700776D RID: 30573
		// (get) Token: 0x0602C68C RID: 181900 RVA: 0x00AA0747 File Offset: 0x00A9E947
		// (set) Token: 0x0602C68D RID: 181901 RVA: 0x00AA075B File Offset: 0x00A9E95B
		public unsafe USkeletalMeshComponent SkeletalMeshComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x1700776E RID: 30574
		// (get) Token: 0x0602C68E RID: 181902 RVA: 0x00AA0770 File Offset: 0x00A9E970
		// (set) Token: 0x0602C68F RID: 181903 RVA: 0x00AA0784 File Offset: 0x00A9E984
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700776F RID: 30575
		// (get) Token: 0x0602C690 RID: 181904 RVA: 0x00AA0799 File Offset: 0x00A9E999
		// (set) Token: 0x0602C691 RID: 181905 RVA: 0x00AA07AD File Offset: 0x00A9E9AD
		public unsafe USkeletalMesh HuluMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Feiyu_Seq_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x0602C692 RID: 181906 RVA: 0x00AA07C2 File Offset: 0x00A9E9C2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Feiyu_Seq_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602C693 RID: 181907 RVA: 0x00AA07D6 File Offset: 0x00A9E9D6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Feiyu_Seq_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C694 RID: 181908 RVA: 0x00AA07EB File Offset: 0x00A9E9EB
		protected BP_Feiyu_Seq_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018A84 RID: 100996
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/NPC/Animal/NA035/BP_Feiyu_Seq.BP_Feiyu_Seq_C";

		// Token: 0x04018A85 RID: 100997
		private static IntPtr _ClassPtr;

		// Token: 0x04018A86 RID: 100998
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018A87 RID: 100999
		internal static int __PropertyOffset_0;

		// Token: 0x04018A88 RID: 101000
		internal static int __PropertyOffset_1;

		// Token: 0x04018A89 RID: 101001
		internal static int __PropertyOffset_2;

		// Token: 0x04018A8A RID: 101002
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
