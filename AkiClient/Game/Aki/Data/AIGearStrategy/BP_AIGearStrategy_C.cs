using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.AIGearStrategy
{
	// Token: 0x02003F1F RID: 16159
	[UnrealObjectPath("/Game/Aki/Data/AIGearStrategy/BP_AiGearStrategy.BP_AIGearStrategy_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 100)]
	public class BP_AIGearStrategy_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028547 RID: 165191 RVA: 0x00A07D2A File Offset: 0x00A05F2A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AIGearStrategy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/AIGearStrategy/BP_AiGearStrategy.BP_AIGearStrategy_C");
			}
			return BP_AIGearStrategy_C._ClassPtr;
		}

		// Token: 0x06028548 RID: 165192 RVA: 0x00A07D50 File Offset: 0x00A05F50
		public BP_AIGearStrategy_C() : this(BuiltinUtils.AllocNativeUObject(BP_AIGearStrategy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028549 RID: 165193 RVA: 0x00A07D78 File Offset: 0x00A05F78
		[NullableContext(1)]
		public BP_AIGearStrategy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AIGearStrategy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170061D6 RID: 25046
		// (get) Token: 0x0602854A RID: 165194 RVA: 0x00A07DAB File Offset: 0x00A05FAB
		// (set) Token: 0x0602854B RID: 165195 RVA: 0x00A07DBB File Offset: 0x00A05FBB
		public unsafe float LostWeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170061D7 RID: 25047
		// (get) Token: 0x0602854C RID: 165196 RVA: 0x00A07DCC File Offset: 0x00A05FCC
		// (set) Token: 0x0602854D RID: 165197 RVA: 0x00A07DDC File Offset: 0x00A05FDC
		public unsafe float RoundDecay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170061D8 RID: 25048
		// (get) Token: 0x0602854E RID: 165198 RVA: 0x00A07DED File Offset: 0x00A05FED
		// (set) Token: 0x0602854F RID: 165199 RVA: 0x00A07DFD File Offset: 0x00A05FFD
		public unsafe int IterationCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170061D9 RID: 25049
		// (get) Token: 0x06028550 RID: 165200 RVA: 0x00A07E0E File Offset: 0x00A0600E
		// (set) Token: 0x06028551 RID: 165201 RVA: 0x00A07E1E File Offset: 0x00A0601E
		public unsafe int PlayerIterationCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170061DA RID: 25050
		// (get) Token: 0x06028552 RID: 165202 RVA: 0x00A07E2F File Offset: 0x00A0602F
		// (set) Token: 0x06028553 RID: 165203 RVA: 0x00A07E3F File Offset: 0x00A0603F
		public unsafe float IterationDecay
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AIGearStrategy_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x06028554 RID: 165204 RVA: 0x00A07E50 File Offset: 0x00A06050
		protected BP_AIGearStrategy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401535B RID: 86875
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/AIGearStrategy/BP_AiGearStrategy.BP_AIGearStrategy_C";

		// Token: 0x0401535C RID: 86876
		private static IntPtr _ClassPtr;

		// Token: 0x0401535D RID: 86877
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401535E RID: 86878
		internal static int __PropertyOffset_0;

		// Token: 0x0401535F RID: 86879
		internal static int __PropertyOffset_1;

		// Token: 0x04015360 RID: 86880
		internal static int __PropertyOffset_2;

		// Token: 0x04015361 RID: 86881
		internal static int __PropertyOffset_3;

		// Token: 0x04015362 RID: 86882
		internal static int __PropertyOffset_4;
	}
}
