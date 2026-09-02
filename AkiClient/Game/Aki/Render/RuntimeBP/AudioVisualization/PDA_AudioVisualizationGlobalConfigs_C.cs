using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.AudioVisualization
{
	// Token: 0x02003DA4 RID: 15780
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/AudioVisualization/PDA_AudioVisualizationGlobalConfigs.PDA_AudioVisualizationGlobalConfigs_C")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 104)]
	public class PDA_AudioVisualizationGlobalConfigs_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060269EF RID: 158191 RVA: 0x009DD746 File Offset: 0x009DB946
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_AudioVisualizationGlobalConfigs_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/AudioVisualization/PDA_AudioVisualizationGlobalConfigs.PDA_AudioVisualizationGlobalConfigs_C");
			}
			return PDA_AudioVisualizationGlobalConfigs_C._ClassPtr;
		}

		// Token: 0x060269F0 RID: 158192 RVA: 0x009DD76C File Offset: 0x009DB96C
		public PDA_AudioVisualizationGlobalConfigs_C() : this(BuiltinUtils.AllocNativeUObject(PDA_AudioVisualizationGlobalConfigs_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060269F1 RID: 158193 RVA: 0x009DD794 File Offset: 0x009DB994
		public PDA_AudioVisualizationGlobalConfigs_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_AudioVisualizationGlobalConfigs_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005860 RID: 22624
		// (get) Token: 0x060269F2 RID: 158194 RVA: 0x009DD7C8 File Offset: 0x009DB9C8
		// (set) Token: 0x060269F3 RID: 158195 RVA: 0x009DD801 File Offset: 0x009DBA01
		public TArray<SGlobalRtpcEntry> GlobalRtpcs
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SGlobalRtpcEntry> result;
				if ((result = this._GlobalRtpcs) == null)
				{
					result = (this._GlobalRtpcs = new TArray<SGlobalRtpcEntry>(base.NativePtr + (IntPtr)PDA_AudioVisualizationGlobalConfigs_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.GlobalRtpcs.CopyAssign(value);
			}
		}

		// Token: 0x17005861 RID: 22625
		// (get) Token: 0x060269F4 RID: 158196 RVA: 0x009DD80F File Offset: 0x009DBA0F
		// (set) Token: 0x060269F5 RID: 158197 RVA: 0x009DD823 File Offset: 0x009DBA23
		[Nullable(2)]
		public unsafe UMaterialParameterCollection MPCFile
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_AudioVisualizationGlobalConfigs_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_AudioVisualizationGlobalConfigs_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x060269F6 RID: 158198 RVA: 0x009DD838 File Offset: 0x009DBA38
		protected PDA_AudioVisualizationGlobalConfigs_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401417B RID: 82299
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/AudioVisualization/PDA_AudioVisualizationGlobalConfigs.PDA_AudioVisualizationGlobalConfigs_C";

		// Token: 0x0401417C RID: 82300
		private static IntPtr _ClassPtr;

		// Token: 0x0401417D RID: 82301
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401417E RID: 82302
		internal static int __PropertyOffset_0;

		// Token: 0x0401417F RID: 82303
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SGlobalRtpcEntry> _GlobalRtpcs;

		// Token: 0x04014180 RID: 82304
		internal static int __PropertyOffset_1;
	}
}
