using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003AE2 RID: 15074
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/SSpineLightRuntimeData.SSpineLightRuntimeData")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SSpineLightRuntimeData : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060204C6 RID: 132294 RVA: 0x009280ED File Offset: 0x009262ED
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SSpineLightRuntimeData._ScriptStructPtr != 0) ? SSpineLightRuntimeData._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Scene/Common/SSpineLightRuntimeData.SSpineLightRuntimeData", ref SSpineLightRuntimeData._ScriptStructPtr);
		}

		// Token: 0x170034DE RID: 13534
		// (get) Token: 0x060204C7 RID: 132295 RVA: 0x00928111 File Offset: 0x00926311
		// (set) Token: 0x060204C8 RID: 132296 RVA: 0x00928121 File Offset: 0x00926321
		public unsafe float LifeTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170034DF RID: 13535
		// (get) Token: 0x060204C9 RID: 132297 RVA: 0x00928132 File Offset: 0x00926332
		// (set) Token: 0x060204CA RID: 132298 RVA: 0x00928142 File Offset: 0x00926342
		public unsafe float CurveBias
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170034E0 RID: 13536
		// (get) Token: 0x060204CB RID: 132299 RVA: 0x00928153 File Offset: 0x00926353
		// (set) Token: 0x060204CC RID: 132300 RVA: 0x00928163 File Offset: 0x00926363
		public unsafe float Age
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SSpineLightRuntimeData.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170034E1 RID: 13537
		// (get) Token: 0x060204CD RID: 132301 RVA: 0x00928174 File Offset: 0x00926374
		// (set) Token: 0x060204CE RID: 132302 RVA: 0x00928188 File Offset: 0x00926388
		[Nullable(2)]
		public unsafe UPointLightComponent LightComp
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPointLightComponent>(base.NativePtr / (IntPtr)sizeof(void*) + SSpineLightRuntimeData.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SSpineLightRuntimeData.__PropertyOffset_3, value);
			}
		}

		// Token: 0x060204CF RID: 132303 RVA: 0x0092819D File Offset: 0x0092639D
		public SSpineLightRuntimeData()
		{
		}

		// Token: 0x060204D0 RID: 132304 RVA: 0x009281A5 File Offset: 0x009263A5
		[NullableContext(1)]
		public SSpineLightRuntimeData(float LifeTime, float CurveBias, float Age, UPointLightComponent LightComp)
		{
			this.LifeTime = LifeTime;
			this.CurveBias = CurveBias;
			this.Age = Age;
			this.LightComp = LightComp;
		}

		// Token: 0x060204D1 RID: 132305 RVA: 0x009281CA File Offset: 0x009263CA
		protected override IntPtr GetUStructPtr()
		{
			return SSpineLightRuntimeData.StaticStruct();
		}

		// Token: 0x060204D2 RID: 132306 RVA: 0x009281D6 File Offset: 0x009263D6
		[NullableContext(2)]
		public SSpineLightRuntimeData(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060204D3 RID: 132307 RVA: 0x009281E0 File Offset: 0x009263E0
		public SSpineLightRuntimeData(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060204D4 RID: 132308 RVA: 0x009281EB File Offset: 0x009263EB
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SSpineLightRuntimeData(Pointer, false, true);
		}

		// Token: 0x060204D5 RID: 132309 RVA: 0x009281F5 File Offset: 0x009263F5
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SSpineLightRuntimeData(Pointer, MemoryOwner);
		}

		// Token: 0x040101E4 RID: 66020
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/SSpineLightRuntimeData.SSpineLightRuntimeData";

		// Token: 0x040101E5 RID: 66021
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040101E6 RID: 66022
		internal static int __PropertyOffset_0;

		// Token: 0x040101E7 RID: 66023
		internal static int __PropertyOffset_1;

		// Token: 0x040101E8 RID: 66024
		internal static int __PropertyOffset_2;

		// Token: 0x040101E9 RID: 66025
		internal static int __PropertyOffset_3;
	}
}
