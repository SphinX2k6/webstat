using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.ComplexBroken
{
	// Token: 0x02003D97 RID: 15767
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/ComplexBroken/PDA_ComplexBrokenData.PDA_ComplexBrokenData_C")]
	[UnrealStructLayout(1456, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1456)]
	public class PDA_ComplexBrokenData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602685D RID: 157789 RVA: 0x009DAD23 File Offset: 0x009D8F23
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_ComplexBrokenData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/ComplexBroken/PDA_ComplexBrokenData.PDA_ComplexBrokenData_C");
			}
			return PDA_ComplexBrokenData_C._ClassPtr;
		}

		// Token: 0x0602685E RID: 157790 RVA: 0x009DAD48 File Offset: 0x009D8F48
		public PDA_ComplexBrokenData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_ComplexBrokenData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602685F RID: 157791 RVA: 0x009DAD70 File Offset: 0x009D8F70
		public PDA_ComplexBrokenData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_ComplexBrokenData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057BF RID: 22463
		// (get) Token: 0x06026860 RID: 157792 RVA: 0x009DADA3 File Offset: 0x009D8FA3
		// (set) Token: 0x06026861 RID: 157793 RVA: 0x009DADB7 File Offset: 0x009D8FB7
		[Nullable(2)]
		public unsafe UMaterialInstance MaterialReplace
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ComplexBrokenData_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ComplexBrokenData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170057C0 RID: 22464
		// (get) Token: 0x06026862 RID: 157794 RVA: 0x009DADCC File Offset: 0x009D8FCC
		// (set) Token: 0x06026863 RID: 157795 RVA: 0x009DAE05 File Offset: 0x009D9005
		public TArray<float> PiecesMaskThreshold
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._PiecesMaskThreshold) == null)
				{
					result = (this._PiecesMaskThreshold = new TArray<float>(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.PiecesMaskThreshold.CopyAssign(value);
			}
		}

		// Token: 0x170057C1 RID: 22465
		// (get) Token: 0x06026864 RID: 157796 RVA: 0x009DAE14 File Offset: 0x009D9014
		// (set) Token: 0x06026865 RID: 157797 RVA: 0x009DAE4D File Offset: 0x009D904D
		public SMaterialControllerFloatGroup ExtendMin
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._ExtendMin) == null)
				{
					result = (this._ExtendMin = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_2, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057C2 RID: 22466
		// (get) Token: 0x06026866 RID: 157798 RVA: 0x009DAE70 File Offset: 0x009D9070
		// (set) Token: 0x06026867 RID: 157799 RVA: 0x009DAEA9 File Offset: 0x009D90A9
		public SMaterialControllerFloatGroup ExtendMax
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._ExtendMax) == null)
				{
					result = (this._ExtendMax = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057C3 RID: 22467
		// (get) Token: 0x06026868 RID: 157800 RVA: 0x009DAECA File Offset: 0x009D90CA
		// (set) Token: 0x06026869 RID: 157801 RVA: 0x009DAEDE File Offset: 0x009D90DE
		[Nullable(2)]
		public unsafe UTexture2D MaskTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ComplexBrokenData_C.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_ComplexBrokenData_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x170057C4 RID: 22468
		// (get) Token: 0x0602686A RID: 157802 RVA: 0x009DAEF3 File Offset: 0x009D90F3
		// (set) Token: 0x0602686B RID: 157803 RVA: 0x009DAF07 File Offset: 0x009D9107
		public unsafe FLinearColor MaskUVBiasScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170057C5 RID: 22469
		// (get) Token: 0x0602686C RID: 157804 RVA: 0x009DAF1C File Offset: 0x009D911C
		// (set) Token: 0x0602686D RID: 157805 RVA: 0x009DAF55 File Offset: 0x009D9155
		public TArray<SMaterialControllerFloatParameter> CustomFloatParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerFloatParameter> result;
				if ((result = this._CustomFloatParameters) == null)
				{
					result = (this._CustomFloatParameters = new TArray<SMaterialControllerFloatParameter>(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_6, this));
				}
				return result;
			}
			set
			{
				this.CustomFloatParameters.CopyAssign(value);
			}
		}

		// Token: 0x170057C6 RID: 22470
		// (get) Token: 0x0602686E RID: 157806 RVA: 0x009DAF64 File Offset: 0x009D9164
		// (set) Token: 0x0602686F RID: 157807 RVA: 0x009DAF9D File Offset: 0x009D919D
		public TArray<SMaterialControllerColorParameter> CustomColorParameters
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SMaterialControllerColorParameter> result;
				if ((result = this._CustomColorParameters) == null)
				{
					result = (this._CustomColorParameters = new TArray<SMaterialControllerColorParameter>(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.CustomColorParameters.CopyAssign(value);
			}
		}

		// Token: 0x170057C7 RID: 22471
		// (get) Token: 0x06026870 RID: 157808 RVA: 0x009DAFAC File Offset: 0x009D91AC
		// (set) Token: 0x06026871 RID: 157809 RVA: 0x009DAFE5 File Offset: 0x009D91E5
		public SMaterialControllerFloatGroup LoopTime
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._LoopTime) == null)
				{
					result = (this._LoopTime = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_8, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)PDA_ComplexBrokenData_C.__PropertyOffset_8, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026872 RID: 157810 RVA: 0x009DB006 File Offset: 0x009D9206
		protected PDA_ComplexBrokenData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401407B RID: 82043
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/ComplexBroken/PDA_ComplexBrokenData.PDA_ComplexBrokenData_C";

		// Token: 0x0401407C RID: 82044
		private static IntPtr _ClassPtr;

		// Token: 0x0401407D RID: 82045
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401407E RID: 82046
		internal static int __PropertyOffset_0;

		// Token: 0x0401407F RID: 82047
		internal static int __PropertyOffset_1;

		// Token: 0x04014080 RID: 82048
		[Nullable(2)]
		private TArray<float> _PiecesMaskThreshold;

		// Token: 0x04014081 RID: 82049
		internal static int __PropertyOffset_2;

		// Token: 0x04014082 RID: 82050
		[Nullable(2)]
		private SMaterialControllerFloatGroup _ExtendMin;

		// Token: 0x04014083 RID: 82051
		internal static int __PropertyOffset_3;

		// Token: 0x04014084 RID: 82052
		[Nullable(2)]
		private SMaterialControllerFloatGroup _ExtendMax;

		// Token: 0x04014085 RID: 82053
		internal static int __PropertyOffset_4;

		// Token: 0x04014086 RID: 82054
		internal static int __PropertyOffset_5;

		// Token: 0x04014087 RID: 82055
		internal static int __PropertyOffset_6;

		// Token: 0x04014088 RID: 82056
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerFloatParameter> _CustomFloatParameters;

		// Token: 0x04014089 RID: 82057
		internal static int __PropertyOffset_7;

		// Token: 0x0401408A RID: 82058
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SMaterialControllerColorParameter> _CustomColorParameters;

		// Token: 0x0401408B RID: 82059
		internal static int __PropertyOffset_8;

		// Token: 0x0401408C RID: 82060
		[Nullable(2)]
		private SMaterialControllerFloatGroup _LoopTime;
	}
}
