using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.GI.UI.DebugPostProcess
{
	// Token: 0x02003CA2 RID: 15522
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/UDebugPostProcessListInfo.UDebugPostProcessListInfo_C")]
	[UnrealStructLayout(240, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 233)]
	public class UDebugPostProcessListInfo_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024943 RID: 149827 RVA: 0x009A1923 File Offset: 0x0099FB23
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (UDebugPostProcessListInfo_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/UDebugPostProcessListInfo.UDebugPostProcessListInfo_C");
			}
			return UDebugPostProcessListInfo_C._ClassPtr;
		}

		// Token: 0x06024944 RID: 149828 RVA: 0x009A1948 File Offset: 0x0099FB48
		public UDebugPostProcessListInfo_C() : this(BuiltinUtils.AllocNativeUObject(UDebugPostProcessListInfo_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024945 RID: 149829 RVA: 0x009A1970 File Offset: 0x0099FB70
		public UDebugPostProcessListInfo_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(UDebugPostProcessListInfo_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004CCE RID: 19662
		// (get) Token: 0x06024946 RID: 149830 RVA: 0x009A19A4 File Offset: 0x0099FBA4
		// (set) Token: 0x06024947 RID: 149831 RVA: 0x009A19DD File Offset: 0x0099FBDD
		public FPostprocessGIDebugInfo Info
		{
			get
			{
				base.FastCheckIsValid();
				FPostprocessGIDebugInfo result;
				if ((result = this._Info) == null)
				{
					result = (this._Info = new FPostprocessGIDebugInfo(base.NativePtr + (IntPtr)UDebugPostProcessListInfo_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPostprocessGIDebugInfo.StaticStruct(), base.NativePtr + (IntPtr)UDebugPostProcessListInfo_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004CCF RID: 19663
		// (get) Token: 0x06024948 RID: 149832 RVA: 0x009A19FE File Offset: 0x0099FBFE
		// (set) Token: 0x06024949 RID: 149833 RVA: 0x009A1A0E File Offset: 0x0099FC0E
		public unsafe bool OverrideProperties
		{
			get
			{
				return *(base.NativePtr + (IntPtr)UDebugPostProcessListInfo_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)UDebugPostProcessListInfo_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602494A RID: 149834 RVA: 0x009A1A1F File Offset: 0x0099FC1F
		protected UDebugPostProcessListInfo_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04012BFE RID: 76798
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/GI/UI/DebugPostProcess/UDebugPostProcessListInfo.UDebugPostProcessListInfo_C";

		// Token: 0x04012BFF RID: 76799
		private static IntPtr _ClassPtr;

		// Token: 0x04012C00 RID: 76800
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012C01 RID: 76801
		internal static int __PropertyOffset_0;

		// Token: 0x04012C02 RID: 76802
		[Nullable(2)]
		private FPostprocessGIDebugInfo _Info;

		// Token: 0x04012C03 RID: 76803
		internal static int __PropertyOffset_1;
	}
}
