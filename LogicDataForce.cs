using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002DEC RID: 11756
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataForce.LogicDataForce_C")]
public class LogicDataForce : LogicDataBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17001FC5 RID: 8133
	// (get) Token: 0x06017B62 RID: 97122 RVA: 0x0069EAB4 File Offset: 0x0069CCB4
	// (set) Token: 0x06017B63 RID: 97123 RVA: 0x0069EAC4 File Offset: 0x0069CCC4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ForceBase
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceBase);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceBase) = value;
		}
	}

	// Token: 0x17001FC6 RID: 8134
	// (get) Token: 0x06017B64 RID: 97124 RVA: 0x0069EAD5 File Offset: 0x0069CCD5
	// (set) Token: 0x06017B65 RID: 97125 RVA: 0x0069EAE5 File Offset: 0x0069CCE5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ForceDampingRatio
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceDampingRatio);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceDampingRatio) = value;
		}
	}

	// Token: 0x17001FC7 RID: 8135
	// (get) Token: 0x06017B66 RID: 97126 RVA: 0x0069EAF6 File Offset: 0x0069CCF6
	// (set) Token: 0x06017B67 RID: 97127 RVA: 0x0069EB06 File Offset: 0x0069CD06
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float InnerRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_InnerRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_InnerRadius) = value;
		}
	}

	// Token: 0x17001FC8 RID: 8136
	// (get) Token: 0x06017B68 RID: 97128 RVA: 0x0069EB17 File Offset: 0x0069CD17
	// (set) Token: 0x06017B69 RID: 97129 RVA: 0x0069EB27 File Offset: 0x0069CD27
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OuterRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_OuterRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_OuterRadius) = value;
		}
	}

	// Token: 0x17001FC9 RID: 8137
	// (get) Token: 0x06017B6A RID: 97130 RVA: 0x0069EB38 File Offset: 0x0069CD38
	// (set) Token: 0x06017B6B RID: 97131 RVA: 0x0069EB48 File Offset: 0x0069CD48
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LimitWeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_LimitWeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_LimitWeight) = value;
		}
	}

	// Token: 0x17001FCA RID: 8138
	// (get) Token: 0x06017B6C RID: 97132 RVA: 0x0069EB59 File Offset: 0x0069CD59
	// (set) Token: 0x06017B6D RID: 97133 RVA: 0x0069EB69 File Offset: 0x0069CD69
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ConstantForce
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ConstantForce) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ConstantForce) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FCB RID: 8139
	// (get) Token: 0x06017B6E RID: 97134 RVA: 0x0069EB7A File Offset: 0x0069CD7A
	// (set) Token: 0x06017B6F RID: 97135 RVA: 0x0069EB8A File Offset: 0x0069CD8A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool TowardsBullet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_TowardsBullet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_TowardsBullet) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FCC RID: 8140
	// (get) Token: 0x06017B70 RID: 97136 RVA: 0x0069EB9B File Offset: 0x0069CD9B
	// (set) Token: 0x06017B71 RID: 97137 RVA: 0x0069EBAB File Offset: 0x0069CDAB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool HaveTopArea
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_HaveTopArea) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_HaveTopArea) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FCD RID: 8141
	// (get) Token: 0x06017B72 RID: 97138 RVA: 0x0069EBBC File Offset: 0x0069CDBC
	// (set) Token: 0x06017B73 RID: 97139 RVA: 0x0069EBCC File Offset: 0x0069CDCC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TopAreaHeight
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_TopAreaHeight);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_TopAreaHeight) = value;
		}
	}

	// Token: 0x17001FCE RID: 8142
	// (get) Token: 0x06017B74 RID: 97140 RVA: 0x0069EBDD File Offset: 0x0069CDDD
	// (set) Token: 0x06017B75 RID: 97141 RVA: 0x0069EBED File Offset: 0x0069CDED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ContinueTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ContinueTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ContinueTime) = value;
		}
	}

	// Token: 0x17001FCF RID: 8143
	// (get) Token: 0x06017B76 RID: 97142 RVA: 0x0069EBFE File Offset: 0x0069CDFE
	// (set) Token: 0x06017B77 RID: 97143 RVA: 0x0069EC12 File Offset: 0x0069CE12
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe UCurveFloat ContinueTimeCurve
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<UCurveFloat>(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataForce.__PropertyOffset_ContinueTimeCurve);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + LogicDataForce.__PropertyOffset_ContinueTimeCurve, value);
		}
	}

	// Token: 0x17001FD0 RID: 8144
	// (get) Token: 0x06017B78 RID: 97144 RVA: 0x0069EC27 File Offset: 0x0069CE27
	// (set) Token: 0x06017B79 RID: 97145 RVA: 0x0069EC37 File Offset: 0x0069CE37
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsLaunching
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_IsLaunching) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_IsLaunching) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FD1 RID: 8145
	// (get) Token: 0x06017B7A RID: 97146 RVA: 0x0069EC48 File Offset: 0x0069CE48
	// (set) Token: 0x06017B7B RID: 97147 RVA: 0x0069EC58 File Offset: 0x0069CE58
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ForceHorizontal
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceHorizontal) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ForceHorizontal) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FD2 RID: 8146
	// (get) Token: 0x06017B7C RID: 97148 RVA: 0x0069EC6C File Offset: 0x0069CE6C
	// (set) Token: 0x06017B7D RID: 97149 RVA: 0x0069ECA5 File Offset: 0x0069CEA5
	[UProperty(EPropertyFlags.CPF_None)]
	public FGameplayTagContainer WorkHaveTag
	{
		get
		{
			base.FastCheckIsValid();
			FGameplayTagContainer result;
			if ((result = this._WorkHaveTag) == null)
			{
				result = (this._WorkHaveTag = new FGameplayTagContainer(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_WorkHaveTag, this));
			}
			return result;
		}
		set
		{
			UnrealReflectionUtils.CopyNativeStruct(FGameplayTagContainer.StaticStruct(), base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_WorkHaveTag, (value != null) ? value.NativePtr : ((IntPtr)0), 1, false);
		}
	}

	// Token: 0x17001FD3 RID: 8147
	// (get) Token: 0x06017B7E RID: 97150 RVA: 0x0069ECCD File Offset: 0x0069CECD
	// (set) Token: 0x06017B7F RID: 97151 RVA: 0x0069ECDD File Offset: 0x0069CEDD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsResetOnLast
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_IsResetOnLast) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_IsResetOnLast) = (value ? 1 : 0);
		}
	}

	// Token: 0x17001FD4 RID: 8148
	// (get) Token: 0x06017B80 RID: 97152 RVA: 0x0069ECEE File Offset: 0x0069CEEE
	// (set) Token: 0x06017B81 RID: 97153 RVA: 0x0069ECFE File Offset: 0x0069CEFE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Group
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_Group);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_Group) = value;
		}
	}

	// Token: 0x17001FD5 RID: 8149
	// (get) Token: 0x06017B82 RID: 97154 RVA: 0x0069ED0F File Offset: 0x0069CF0F
	// (set) Token: 0x06017B83 RID: 97155 RVA: 0x0069ED1F File Offset: 0x0069CF1F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ImmuneStopDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ImmuneStopDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)LogicDataForce.__PropertyOffset_ImmuneStopDuration) = value;
		}
	}

	// Token: 0x06017B84 RID: 97156 RVA: 0x0069ED30 File Offset: 0x0069CF30
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (LogicDataForce._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataForce.LogicDataForce_C");
		}
		return LogicDataForce._ClassPtr;
	}

	// Token: 0x06017B85 RID: 97157 RVA: 0x0069ED54 File Offset: 0x0069CF54
	public LogicDataForce() : this(BuiltinUtils.AllocNativeUObject(LogicDataForce.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06017B86 RID: 97158 RVA: 0x0069ED7C File Offset: 0x0069CF7C
	public LogicDataForce(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataForce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06017B87 RID: 97159 RVA: 0x0069EDAF File Offset: 0x0069CFAF
	protected LogicDataForce(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0400B6F8 RID: 46840
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Bullet/LogicDataClass/LogicDataForce.LogicDataForce_C";

	// Token: 0x0400B6F9 RID: 46841
	private static IntPtr _ClassPtr;

	// Token: 0x0400B6FA RID: 46842
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400B6FB RID: 46843
	private static int __PropertyOffset_ForceBase;

	// Token: 0x0400B6FC RID: 46844
	private static int __PropertyOffset_ForceDampingRatio;

	// Token: 0x0400B6FD RID: 46845
	private static int __PropertyOffset_InnerRadius;

	// Token: 0x0400B6FE RID: 46846
	private static int __PropertyOffset_OuterRadius;

	// Token: 0x0400B6FF RID: 46847
	private static int __PropertyOffset_LimitWeight;

	// Token: 0x0400B700 RID: 46848
	private static int __PropertyOffset_ConstantForce;

	// Token: 0x0400B701 RID: 46849
	private static int __PropertyOffset_TowardsBullet;

	// Token: 0x0400B702 RID: 46850
	private static int __PropertyOffset_HaveTopArea;

	// Token: 0x0400B703 RID: 46851
	private static int __PropertyOffset_TopAreaHeight;

	// Token: 0x0400B704 RID: 46852
	private static int __PropertyOffset_ContinueTime;

	// Token: 0x0400B705 RID: 46853
	private static int __PropertyOffset_ContinueTimeCurve;

	// Token: 0x0400B706 RID: 46854
	private static int __PropertyOffset_IsLaunching;

	// Token: 0x0400B707 RID: 46855
	private static int __PropertyOffset_ForceHorizontal;

	// Token: 0x0400B708 RID: 46856
	private static int __PropertyOffset_WorkHaveTag;

	// Token: 0x0400B709 RID: 46857
	[Nullable(2)]
	private FGameplayTagContainer _WorkHaveTag;

	// Token: 0x0400B70A RID: 46858
	private static int __PropertyOffset_IsResetOnLast;

	// Token: 0x0400B70B RID: 46859
	private static int __PropertyOffset_Group;

	// Token: 0x0400B70C RID: 46860
	private static int __PropertyOffset_ImmuneStopDuration;
}
