using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using CSharpScript.Game.Effect;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E7F RID: 3711
[UClass("/Game/Aki/TypeScript/Game/Effect/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Effect/TsEffectActor.TsEffectActor_C")]
public class TsEffectActor : AActor, IBPI_EffectInterface_C, IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject, IUnrealUObject
{
	// Token: 0x06005A76 RID: 23158 RVA: 0x00162E97 File Offset: 0x00161097
	[NullableContext(1)]
	public void SetEffectHandle(int handleId = 0, string path = "", EEffectType type = EEffectType.Scene)
	{
		this.HandleId = new int?(handleId);
		this.EffectPath = path;
		this.EffectType = type;
	}

	// Token: 0x06005A77 RID: 23159 RVA: 0x00162EB4 File Offset: 0x001610B4
	public void SetTimeScale(float timeScale)
	{
		float? timeScale2 = this.TimeScale;
		if (!(timeScale2.GetValueOrDefault() == timeScale & timeScale2 != null))
		{
			this.TimeScale = new float?(timeScale);
		}
	}

	// Token: 0x06005A78 RID: 23160 RVA: 0x00162EEA File Offset: 0x001610EA
	public float GetTimeScale()
	{
		return this.TimeScale.GetValueOrDefault(1f);
	}

	// Token: 0x06005A79 RID: 23161 RVA: 0x00162EFC File Offset: 0x001610FC
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void GetHandle(ref int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEffectActor.__GetHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEffectActor.__GetHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsEffectActor.__GetHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		handle = ptr2->handle;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005A7A RID: 23162 RVA: 0x00162F7B File Offset: 0x0016117B
	protected void GetHandle_Implementation(ref int handle)
	{
		((IBPI_EffectInterface_C)this).GetHandle(ref handle);
	}

	// Token: 0x06005A7B RID: 23163 RVA: 0x00162F84 File Offset: 0x00161184
	void IBPI_EffectInterface_C.GetHandle(ref int handle)
	{
		handle = this.HandleId.GetValueOrDefault();
	}

	// Token: 0x06005A7C RID: 23164 RVA: 0x00162F94 File Offset: 0x00161194
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void SetHandle(int handle)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("SetHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		TsEffectActor.__SetHandle_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((TsEffectActor.__SetHandle_FunctionParams*)ptr + 15L / (long)sizeof(TsEffectActor.__SetHandle_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->handle = handle;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005A7D RID: 23165 RVA: 0x0016300A File Offset: 0x0016120A
	protected void SetHandle_Implementation(int handle)
	{
		((IBPI_EffectInterface_C)this).SetHandle(handle);
	}

	// Token: 0x06005A7E RID: 23166 RVA: 0x00163013 File Offset: 0x00161213
	void IBPI_EffectInterface_C.SetHandle(int handle)
	{
	}

	// Token: 0x06005A7F RID: 23167 RVA: 0x00163018 File Offset: 0x00161218
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe virtual void RemoveHandle()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("RemoveHandle"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06005A80 RID: 23168 RVA: 0x00163088 File Offset: 0x00161288
	protected void RemoveHandle_Implementation()
	{
		((IBPI_EffectInterface_C)this).RemoveHandle();
	}

	// Token: 0x06005A81 RID: 23169 RVA: 0x00163090 File Offset: 0x00161290
	void IBPI_EffectInterface_C.RemoveHandle()
	{
		this.HandleId = new int?(0);
	}

	// Token: 0x06005A82 RID: 23170 RVA: 0x001630A0 File Offset: 0x001612A0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveEndPlay(EEndPlayReason endPlayReason)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveEndPlay"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		AActor.__ReceiveEndPlay_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((AActor.__ReceiveEndPlay_FunctionParams*)ptr + 15L / (long)sizeof(AActor.__ReceiveEndPlay_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(byte*)(&ptr2->EndPlayReason) = (byte)endPlayReason;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06005A83 RID: 23171 RVA: 0x00163119 File Offset: 0x00161319
	protected void ReceiveEndPlay_Implementation(EEndPlayReason endPlayReason)
	{
	}

	// Token: 0x06005A84 RID: 23172 RVA: 0x0016311B File Offset: 0x0016131B
	[NullableContext(1)]
	public void StopEffect(string reason, bool immediately = false, bool destroyActor = false)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(this.HandleId.GetValueOrDefault()))
		{
			return;
		}
		Singleton<EffectSystem>.Instance.StopEffectById(this.HandleId.GetValueOrDefault(), reason, immediately, new bool?(destroyActor));
	}

	// Token: 0x06005A85 RID: 23173 RVA: 0x00163153 File Offset: 0x00161353
	[NullableContext(1)]
	public string GetEffectPath()
	{
		return this.EffectPath;
	}

	// Token: 0x06005A86 RID: 23174 RVA: 0x0016315B File Offset: 0x0016135B
	public EEffectType GetEffectType()
	{
		return this.EffectType;
	}

	// Token: 0x06005A87 RID: 23175 RVA: 0x00163163 File Offset: 0x00161363
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsEffectActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Effect/TsEffectActor.TsEffectActor_C");
		}
		return TsEffectActor._ClassPtr;
	}

	// Token: 0x06005A88 RID: 23176 RVA: 0x00163188 File Offset: 0x00161388
	public TsEffectActor() : this(BuiltinUtils.AllocNativeUObject(TsEffectActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005A89 RID: 23177 RVA: 0x001631B0 File Offset: 0x001613B0
	[NullableContext(1)]
	public TsEffectActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEffectActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005A8A RID: 23178 RVA: 0x001631E3 File Offset: 0x001613E3
	protected TsEffectActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x1700067C RID: 1660
	// (get) Token: 0x06005A8B RID: 23179 RVA: 0x00163217 File Offset: 0x00161417
	[Nullable(1)]
	public unsafe FPointerToUberGraphFrame UberGraphFrame
	{
		[NullableContext(1)]
		get
		{
			return *(base.NativePtr + (IntPtr)TsEffectActor.__PropertyOffset_UberGraphFrame);
		}
	}

	// Token: 0x1700067D RID: 1661
	// (get) Token: 0x06005A8C RID: 23180 RVA: 0x00163227 File Offset: 0x00161427
	[Nullable(2)]
	public unsafe USceneComponent DefaultSceneRoot
	{
		[NullableContext(2)]
		get
		{
			return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + TsEffectActor.__PropertyOffset_DefaultSceneRoot);
		}
	}

	// Token: 0x06005A8D RID: 23181 RVA: 0x0016323B File Offset: 0x0016143B
	protected unsafe virtual void __CPPCALL_GetHandle_Implementation(TsEffectActor.__GetHandle_FunctionParams* __Params)
	{
		this.GetHandle_Implementation(ref __Params->handle);
	}

	// Token: 0x06005A8E RID: 23182 RVA: 0x00163249 File Offset: 0x00161449
	protected unsafe virtual void __CPPCALL_SetHandle_Implementation(TsEffectActor.__SetHandle_FunctionParams* __Params)
	{
		this.SetHandle_Implementation(__Params->handle);
	}

	// Token: 0x06005A8F RID: 23183 RVA: 0x00163257 File Offset: 0x00161457
	protected virtual void __CPPCALL_RemoveHandle_Implementation()
	{
		this.RemoveHandle_Implementation();
	}

	// Token: 0x06005A90 RID: 23184 RVA: 0x00163260 File Offset: 0x00161460
	protected unsafe virtual void __CPPCALL_ReceiveEndPlay_Implementation(AActor.__ReceiveEndPlay_FunctionParams* __Params)
	{
		EEndPlayReason endPlayReason = __Params->EndPlayReason;
		this.ReceiveEndPlay_Implementation(endPlayReason);
	}

	// Token: 0x040029FD RID: 10749
	public EffectActorPoolEnum InPool;

	// Token: 0x040029FE RID: 10750
	private int? HandleId = new int?(0);

	// Token: 0x040029FF RID: 10751
	[Nullable(1)]
	private string EffectPath = "";

	// Token: 0x04002A00 RID: 10752
	private EEffectType EffectType = EEffectType.Scene;

	// Token: 0x04002A01 RID: 10753
	public int OwnerEntityId;

	// Token: 0x04002A02 RID: 10754
	private float? TimeScale = new float?((float)1);

	// Token: 0x04002A03 RID: 10755
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Effect/TsEffectActor.TsEffectActor_C";

	// Token: 0x04002A04 RID: 10756
	private static IntPtr _ClassPtr;

	// Token: 0x04002A05 RID: 10757
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04002A06 RID: 10758
	private static int __PropertyOffset_UberGraphFrame;

	// Token: 0x04002A07 RID: 10759
	private static int __PropertyOffset_DefaultSceneRoot;

	// Token: 0x020072A9 RID: 29353
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __GetHandle_FunctionParams
	{
		// Token: 0x04027C0F RID: 162831
		[FieldOffset(0)]
		public int handle;
	}

	// Token: 0x020072AA RID: 29354
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 4)]
	protected ref struct __SetHandle_FunctionParams
	{
		// Token: 0x04027C10 RID: 162832
		[FieldOffset(0)]
		public int handle;
	}
}
