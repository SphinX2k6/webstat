using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02002C53 RID: 11347
[UClass("/Game/Aki/TypeScript/Game/Module/UiComponent/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiAutoPlayLevelSequenceComponent.TsUiAutoPlayLevelSequenceComponent_C")]
public class TsUiAutoPlayLevelSequenceComponent : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x06016BEF RID: 93167 RVA: 0x0064F7C0 File Offset: 0x0064D9C0
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void AwakeBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AwakeBP"), out num);
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

	// Token: 0x06016BF0 RID: 93168 RVA: 0x0064F830 File Offset: 0x0064DA30
	protected virtual void AwakeBP_Implementation()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(base.RootUIComp);
		this.PlayState = new EPlayState?(EPlayState.None);
	}

	// Token: 0x06016BF1 RID: 93169 RVA: 0x0064F854 File Offset: 0x0064DA54
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnUIActiveInHierarchyBP(bool activeOrInactive)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnUIActiveInHierarchyBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ULGUIBehaviour.__OnUIActiveInHierarchyBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ULGUIBehaviour.__OnUIActiveInHierarchyBP_FunctionParams*)ptr + 15L / (long)sizeof(ULGUIBehaviour.__OnUIActiveInHierarchyBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->activeOrInactive = activeOrInactive;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06016BF2 RID: 93170 RVA: 0x0064F8CA File Offset: 0x0064DACA
	protected virtual void OnUIActiveInHierarchyBP_Implementation(bool activeOrInactive)
	{
		this.PlayState = new EPlayState?(activeOrInactive ? EPlayState.Play : EPlayState.Stop);
		if (this.PlayState.GetValueOrDefault() == EPlayState.Stop)
		{
			this.TryRefresh();
		}
	}

	// Token: 0x06016BF3 RID: 93171 RVA: 0x0064F8F4 File Offset: 0x0064DAF4
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnPreDestroyBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnPreDestroyBP"), out num);
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

	// Token: 0x06016BF4 RID: 93172 RVA: 0x0064F964 File Offset: 0x0064DB64
	protected virtual void OnPreDestroyBP_Implementation()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06016BF5 RID: 93173 RVA: 0x0064F980 File Offset: 0x0064DB80
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void UpdateBP(float DeltaTime)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("UpdateBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		ULGUIBehaviour.__UpdateBP_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((ULGUIBehaviour.__UpdateBP_FunctionParams*)ptr + 15L / (long)sizeof(ULGUIBehaviour.__UpdateBP_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			ptr2->DeltaTime = DeltaTime;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06016BF6 RID: 93174 RVA: 0x0064F9F6 File Offset: 0x0064DBF6
	protected virtual void UpdateBP_Implementation(float DeltaTime)
	{
		this.TryRefresh();
	}

	// Token: 0x06016BF7 RID: 93175 RVA: 0x0064FA00 File Offset: 0x0064DC00
	private void TryRefresh()
	{
		EPlayState? playState = this.PlayState;
		EPlayState eplayState = EPlayState.None;
		if (playState.GetValueOrDefault() == eplayState & playState != null)
		{
			return;
		}
		if (this.PlayState.GetValueOrDefault() == EPlayState.Play)
		{
			this.TryPlay();
			this.PlayState = new EPlayState?(EPlayState.None);
			return;
		}
		if (this.PlayState.GetValueOrDefault() == EPlayState.Stop)
		{
			this.TryStop();
			this.PlayState = new EPlayState?(EPlayState.None);
		}
	}

	// Token: 0x06016BF8 RID: 93176 RVA: 0x0064FA6C File Offset: 0x0064DC6C
	private void TryPlay()
	{
		AUIBaseActor auibaseActor = base.GetOwner() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		TMap<string, FSequenceInfo> levelSequences = auibaseActor.GetUIItem().LevelSequences;
		if (this.AutoPlayList == null)
		{
			this.AutoPlayList = new List<string>();
		}
		this.AutoPlayList.Clear();
		foreach (KeyValuePair<string, FSequenceInfo> keyValuePair in levelSequences)
		{
			string text;
			FSequenceInfo fsequenceInfo;
			keyValuePair.Deconstruct(out text, out fsequenceInfo);
			string text2 = text;
			if (fsequenceInfo.PlaySetting.bAutoPlay)
			{
				this.LevelSequencePlayer.PlaySequencePurely(text2, false, false, null, null, false);
				this.AutoPlayList.Add(text2);
			}
		}
	}

	// Token: 0x06016BF9 RID: 93177 RVA: 0x0064FB28 File Offset: 0x0064DD28
	private void TryStop()
	{
		if (this.AutoPlayList == null)
		{
			return;
		}
		AUIBaseActor auibaseActor = base.GetOwner() as AUIBaseActor;
		if (auibaseActor == null)
		{
			return;
		}
		foreach (string name in this.AutoPlayList)
		{
			auibaseActor.StopSequenceByKey(name);
		}
		this.AutoPlayList = null;
	}

	// Token: 0x06016BFA RID: 93178 RVA: 0x0064FB9C File Offset: 0x0064DD9C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsUiAutoPlayLevelSequenceComponent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiAutoPlayLevelSequenceComponent.TsUiAutoPlayLevelSequenceComponent_C");
		}
		return TsUiAutoPlayLevelSequenceComponent._ClassPtr;
	}

	// Token: 0x06016BFB RID: 93179 RVA: 0x0064FBC0 File Offset: 0x0064DDC0
	public TsUiAutoPlayLevelSequenceComponent() : this(BuiltinUtils.AllocNativeUObject(TsUiAutoPlayLevelSequenceComponent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06016BFC RID: 93180 RVA: 0x0064FBE8 File Offset: 0x0064DDE8
	[NullableContext(1)]
	public TsUiAutoPlayLevelSequenceComponent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiAutoPlayLevelSequenceComponent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06016BFD RID: 93181 RVA: 0x0064FC1B File Offset: 0x0064DE1B
	protected TsUiAutoPlayLevelSequenceComponent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06016BFE RID: 93182 RVA: 0x0064FC24 File Offset: 0x0064DE24
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x06016BFF RID: 93183 RVA: 0x0064FC2C File Offset: 0x0064DE2C
	protected unsafe virtual void __CPPCALL_OnUIActiveInHierarchyBP_Implementation(ULGUIBehaviour.__OnUIActiveInHierarchyBP_FunctionParams* __Params)
	{
		this.OnUIActiveInHierarchyBP_Implementation(__Params->activeOrInactive);
	}

	// Token: 0x06016C00 RID: 93184 RVA: 0x0064FC3A File Offset: 0x0064DE3A
	protected virtual void __CPPCALL_OnPreDestroyBP_Implementation()
	{
		this.OnPreDestroyBP_Implementation();
	}

	// Token: 0x06016C01 RID: 93185 RVA: 0x0064FC42 File Offset: 0x0064DE42
	protected unsafe virtual void __CPPCALL_UpdateBP_Implementation(ULGUIBehaviour.__UpdateBP_FunctionParams* __Params)
	{
		this.UpdateBP_Implementation(__Params->DeltaTime);
	}

	// Token: 0x0400AF50 RID: 44880
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400AF51 RID: 44881
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<string> AutoPlayList;

	// Token: 0x0400AF52 RID: 44882
	private EPlayState? PlayState;

	// Token: 0x0400AF53 RID: 44883
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Module/UiComponent/TsUiAutoPlayLevelSequenceComponent.TsUiAutoPlayLevelSequenceComponent_C";

	// Token: 0x0400AF54 RID: 44884
	private static IntPtr _ClassPtr;

	// Token: 0x0400AF55 RID: 44885
	private static IntPtr _ClassDefaultObjectPtr;
}
