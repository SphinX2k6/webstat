using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.PathLine.Pathline_EdgeWall
{
	// Token: 0x02003E54 RID: 15956
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/Pathline_EdgeWall/BP_BasePathLine_Edgewall.BP_BasePathLine_Edgewall_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1073)]
	public class BP_BasePathLine_Edgewall_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602761C RID: 161308 RVA: 0x009F090C File Offset: 0x009EEB0C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BasePathLine_Edgewall_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/PathLine/Pathline_EdgeWall/BP_BasePathLine_Edgewall.BP_BasePathLine_Edgewall_C");
			}
			return BP_BasePathLine_Edgewall_C._ClassPtr;
		}

		// Token: 0x0602761D RID: 161309 RVA: 0x009F0930 File Offset: 0x009EEB30
		public BP_BasePathLine_Edgewall_C() : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLine_Edgewall_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602761E RID: 161310 RVA: 0x009F0958 File Offset: 0x009EEB58
		[NullableContext(1)]
		public BP_BasePathLine_Edgewall_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BasePathLine_Edgewall_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005C80 RID: 23680
		// (get) Token: 0x0602761F RID: 161311 RVA: 0x009F098C File Offset: 0x009EEB8C
		// (set) Token: 0x06027620 RID: 161312 RVA: 0x009F09C5 File Offset: 0x009EEBC5
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C81 RID: 23681
		// (get) Token: 0x06027621 RID: 161313 RVA: 0x009F09E6 File Offset: 0x009EEBE6
		// (set) Token: 0x06027622 RID: 161314 RVA: 0x009F09FA File Offset: 0x009EEBFA
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_Edgewall_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_Edgewall_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005C82 RID: 23682
		// (get) Token: 0x06027623 RID: 161315 RVA: 0x009F0A0F File Offset: 0x009EEC0F
		// (set) Token: 0x06027624 RID: 161316 RVA: 0x009F0A23 File Offset: 0x009EEC23
		public unsafe FVector OriginalLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C83 RID: 23683
		// (get) Token: 0x06027625 RID: 161317 RVA: 0x009F0A38 File Offset: 0x009EEC38
		// (set) Token: 0x06027626 RID: 161318 RVA: 0x009F0A4C File Offset: 0x009EEC4C
		public unsafe AActor DebugTarget
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_Edgewall_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BasePathLine_Edgewall_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17005C84 RID: 23684
		// (get) Token: 0x06027627 RID: 161319 RVA: 0x009F0A61 File Offset: 0x009EEC61
		// (set) Token: 0x06027628 RID: 161320 RVA: 0x009F0A71 File Offset: 0x009EEC71
		public unsafe bool IsAttachedToEntity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BasePathLine_Edgewall_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027629 RID: 161321 RVA: 0x009F0A82 File Offset: 0x009EEC82
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Save()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_Edgewall_C.__Save_NativeFunctionPtr, null);
		}

		// Token: 0x0602762A RID: 161322 RVA: 0x009F0A96 File Offset: 0x009EEC96
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 贴地处理()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_Edgewall_C.__贴地处理_NativeFunctionPtr, null);
		}

		// Token: 0x0602762B RID: 161323 RVA: 0x009F0AAA File Offset: 0x009EECAA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BasePathLine_Edgewall_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602762C RID: 161324 RVA: 0x009F0ABE File Offset: 0x009EECBE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BasePathLine_Edgewall_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602762D RID: 161325 RVA: 0x009F0AD4 File Offset: 0x009EECD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BasePathLine_Edgewall(int EntryPoint)
		{
			BP_BasePathLine_Edgewall_C.__ExecuteUbergraph_BP_BasePathLine_Edgewall_FunctionParams* ptr = stackalloc BP_BasePathLine_Edgewall_C.__ExecuteUbergraph_BP_BasePathLine_Edgewall_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BasePathLine_Edgewall_C.__ExecuteUbergraph_BP_BasePathLine_Edgewall_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BasePathLine_Edgewall_C.__ExecuteUbergraph_BP_BasePathLine_Edgewall_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BasePathLine_Edgewall_C.__ExecuteUbergraph_BP_BasePathLine_Edgewall_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602762E RID: 161326 RVA: 0x009F0B1B File Offset: 0x009EED1B
		protected BP_BasePathLine_Edgewall_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040149E9 RID: 84457
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/PathLine/Pathline_EdgeWall/BP_BasePathLine_Edgewall.BP_BasePathLine_Edgewall_C";

		// Token: 0x040149EA RID: 84458
		private static IntPtr _ClassPtr;

		// Token: 0x040149EB RID: 84459
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040149EC RID: 84460
		internal static int __PropertyOffset_0;

		// Token: 0x040149ED RID: 84461
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040149EE RID: 84462
		internal static int __PropertyOffset_1;

		// Token: 0x040149EF RID: 84463
		internal static int __PropertyOffset_2;

		// Token: 0x040149F0 RID: 84464
		internal static int __PropertyOffset_3;

		// Token: 0x040149F1 RID: 84465
		internal static int __PropertyOffset_4;

		// Token: 0x040149F2 RID: 84466
		private static IntPtr __Save_NativeFunctionPtr;

		// Token: 0x040149F3 RID: 84467
		private static IntPtr __贴地处理_NativeFunctionPtr;

		// Token: 0x040149F4 RID: 84468
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x040149F5 RID: 84469
		private static IntPtr __ExecuteUbergraph_BP_BasePathLine_Edgewall_NativeFunctionPtr;

		// Token: 0x0200A0D5 RID: 41173
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BasePathLine_Edgewall_FunctionParams
		{
			// Token: 0x04032D8A RID: 208266
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
