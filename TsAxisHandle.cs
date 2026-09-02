using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E68 RID: 3688
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/Controller/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Controller/TsAxisHandle.TsAxisHandle_C")]
public class TsAxisHandle : UObject, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000646 RID: 1606
	// (get) Token: 0x0600591A RID: 22810 RVA: 0x00109DBF File Offset: 0x00107FBF
	// (set) Token: 0x0600591B RID: 22811 RVA: 0x00109DD3 File Offset: 0x00107FD3
	[Nullable(2)]
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe TsBasePlayerController PlayerController
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<TsBasePlayerController>(base.NativePtr / (IntPtr)sizeof(void*) + TsAxisHandle.__PropertyOffset_PlayerController);
		}
		[NullableContext(2)]
		set
		{
			BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + TsAxisHandle.__PropertyOffset_PlayerController, value);
		}
	}

	// Token: 0x17000647 RID: 1607
	// (get) Token: 0x0600591C RID: 22812 RVA: 0x00109DE8 File Offset: 0x00107FE8
	// (set) Token: 0x0600591D RID: 22813 RVA: 0x00109DFC File Offset: 0x00107FFC
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe string AxisName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsAxisHandle.__PropertyOffset_AxisName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsAxisHandle.__PropertyOffset_AxisName)), value);
		}
	}

	// Token: 0x0600591E RID: 22814 RVA: 0x00109E11 File Offset: 0x00108011
	public void Initialize(TsBasePlayerController playerController)
	{
		this.PlayerController = playerController;
		this.OnInputStat = Stat.Create("TsAxisHandle.OnInputAxis", "", "STATGROUP_KuroBattle");
	}

	// Token: 0x0600591F RID: 22815 RVA: 0x00109E34 File Offset: 0x00108034
	public void Reset()
	{
		this.PlayerController = null;
		this.AxisName = string.Empty;
		this.OnInputAxisCallback = null;
	}

	// Token: 0x06005920 RID: 22816 RVA: 0x00109E50 File Offset: 0x00108050
	public void AddAxisBinding(string axisName, [Nullable(new byte[]
	{
		2,
		1
	})] Action<string, float> onInputAxis)
	{
		if (onInputAxis == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Controller;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "添加Axis输入绑定时，回调不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("axisName", axisName);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.AxisName = axisName;
		this.OnInputAxisCallback = onInputAxis;
		FName? dynamicFName = FNameUtil.GetDynamicFName(axisName);
		if (dynamicFName == null)
		{
			return;
		}
		TsBasePlayerController playerController = this.PlayerController;
		if (playerController == null)
		{
			return;
		}
		FName value = dynamicFName.Value;
		FName fname = new FName("OnInputAxis");
		playerController.AddAxisBinding(value, this, fname);
	}

	// Token: 0x06005921 RID: 22817 RVA: 0x00109ED4 File Offset: 0x001080D4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void OnInputAxis(float value)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnInputAxis"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsAxisHandle.__OnInputAxis_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsAxisHandle.__OnInputAxis_FunctionParams*)ptr + 15L / (long)sizeof(TsAxisHandle.__OnInputAxis_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->value = value;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005922 RID: 22818 RVA: 0x00109F4A File Offset: 0x0010814A
	protected void OnInputAxis_Implementation(float value)
	{
		Action<string, float> onInputAxisCallback = this.OnInputAxisCallback;
		if (onInputAxisCallback == null)
		{
			return;
		}
		onInputAxisCallback(this.AxisName, value);
	}

	// Token: 0x06005923 RID: 22819 RVA: 0x00109F63 File Offset: 0x00108163
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAxisHandle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Controller/TsAxisHandle.TsAxisHandle_C");
		}
		return TsAxisHandle._ClassPtr;
	}

	// Token: 0x06005924 RID: 22820 RVA: 0x00109F88 File Offset: 0x00108188
	public TsAxisHandle() : this(BuiltinUtils.AllocNativeUObject(TsAxisHandle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005925 RID: 22821 RVA: 0x00109FB0 File Offset: 0x001081B0
	public TsAxisHandle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAxisHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005926 RID: 22822 RVA: 0x00109FE3 File Offset: 0x001081E3
	protected TsAxisHandle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005927 RID: 22823 RVA: 0x00109FEC File Offset: 0x001081EC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_OnInputAxis_Implementation(TsAxisHandle.__OnInputAxis_FunctionParams* __Params)
	{
		this.OnInputAxis_Implementation(__Params->value);
	}

	// Token: 0x0400295C RID: 10588
	[Nullable(2)]
	private Stat OnInputStat;

	// Token: 0x0400295D RID: 10589
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<string, float> OnInputAxisCallback;

	// Token: 0x0400295E RID: 10590
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Controller/TsAxisHandle.TsAxisHandle_C";

	// Token: 0x0400295F RID: 10591
	private static IntPtr _ClassPtr;

	// Token: 0x04002960 RID: 10592
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04002961 RID: 10593
	private static int __PropertyOffset_PlayerController;

	// Token: 0x04002962 RID: 10594
	private static int __PropertyOffset_AxisName;

	// Token: 0x0200729A RID: 29338
	[NullableContext(0)]
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __OnInputAxis_FunctionParams
	{
		// Token: 0x04027BEF RID: 162799
		[FieldOffset(0)]
		public float value;
	}
}
