using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D4F RID: 3407
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBattleUi.TsAnimNotifyStateHideBattleUi_C")]
public class TsAnimNotifyStateHideBattleUi : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170003DE RID: 990
	// (get) Token: 0x0600482C RID: 18476 RVA: 0x000982BC File Offset: 0x000964BC
	// (set) Token: 0x0600482D RID: 18477 RVA: 0x000982F5 File Offset: 0x000964F5
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<EBattleUIChild> 需要额外显示的ui类型
	{
		get
		{
			base.FastCheckIsValid();
			TArray<EBattleUIChild> result;
			if ((result = this._需要额外显示的ui类型) == null)
			{
				result = (this._需要额外显示的ui类型 = new TArray<EBattleUIChild>(base.NativePtr + (IntPtr)TsAnimNotifyStateHideBattleUi.__PropertyOffset_需要额外显示的ui类型, this));
			}
			return result;
		}
		set
		{
			this.需要额外显示的ui类型.CopyAssign(value);
		}
	}

	// Token: 0x170003DF RID: 991
	// (get) Token: 0x0600482E RID: 18478 RVA: 0x00098303 File Offset: 0x00096503
	// (set) Token: 0x0600482F RID: 18479 RVA: 0x00098313 File Offset: 0x00096513
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsHiding
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsAnimNotifyStateHideBattleUi.__PropertyOffset_IsHiding) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateHideBattleUi.__PropertyOffset_IsHiding) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004831 RID: 18481 RVA: 0x00098418 File Offset: 0x00096618
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyBegin(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyBegin"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
			ptr2->TotalDuration = totalDuration;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004832 RID: 18482 RVA: 0x000984C0 File Offset: 0x000966C0
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		if (this.IsHiding)
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.ZFJ, "[TsAnimNotifyStateHideBattleUi]重复隐藏战斗UI", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
			{
				return false;
			}
			this.IsHiding = true;
			List<EBattleUiChild> list = new List<EBattleUiChild>();
			if (this.需要额外显示的ui类型 != null)
			{
				int num = this.需要额外显示的ui类型.Num();
				list.EnsureCapacity(num);
				for (int i = 0; i < num; i++)
				{
					list.Add((EBattleUiChild)this.需要额外显示的ui类型.Get(i));
				}
			}
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.HideBattleView(EBattleUiVisibleReason.ANS, list, 0);
			}
			Entity entity = characterActorComponent.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				foreach (int value in TsAnimNotifyStateHideBattleUi.PlayerInputLimitTagList)
				{
					baseTagComponent.AddTag(new int?(value));
				}
			}
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.ZFJ, "[TsAnimNotifyStateHideBattleUi]开始隐藏战斗UI", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return true;
	}

	// Token: 0x06004833 RID: 18483 RVA: 0x000985F4 File Offset: 0x000967F4
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool K2_NotifyEnd(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("K2_NotifyEnd"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams*)ptr + 15L / (long)sizeof(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->MeshComp) = ((meshComp != null) ? meshComp.NativePtr : ((IntPtr)0));
			*(&ptr2->Animation) = ((animation != null) ? animation.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x06004834 RID: 18484 RVA: 0x00098694 File Offset: 0x00096894
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		TsBaseCharacter tsBaseCharacter = meshComp.GetOwner() as TsBaseCharacter;
		if (tsBaseCharacter != null)
		{
			CharacterActorComponent characterActorComponent = tsBaseCharacter.CharacterActorComponent;
			if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
			{
				return false;
			}
			this.IsHiding = false;
			BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
			if (childViewData != null)
			{
				childViewData.ShowBattleView(EBattleUiVisibleReason.ANS, 0);
			}
			Entity entity = characterActorComponent.Entity;
			BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null)
			{
				foreach (int value in TsAnimNotifyStateHideBattleUi.PlayerInputLimitTagList)
				{
					baseTagComponent.RemoveTag(new int?(value));
				}
			}
			Singleton<Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.ZFJ, "[TsAnimNotifyStateHideBattleUi]结束隐藏战斗UI", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return true;
	}

	// Token: 0x06004835 RID: 18485 RVA: 0x00098754 File Offset: 0x00096954
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override string GetNotifyName()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GetNotifyName"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UAnimNotifyState.__GetNotifyName_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UAnimNotifyState.__GetNotifyName_FunctionParams*)ptr + 15L / (long)sizeof(UAnimNotifyState.__GetNotifyName_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		string result = FString.ToString((void*)(&ptr2->__Result));
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return result;
	}

	// Token: 0x06004836 RID: 18486 RVA: 0x000987CF File Offset: 0x000969CF
	protected override string GetNotifyName_Implementation()
	{
		return "隐藏战斗UI";
	}

	// Token: 0x06004837 RID: 18487 RVA: 0x000987D6 File Offset: 0x000969D6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateHideBattleUi._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBattleUi.TsAnimNotifyStateHideBattleUi_C");
		}
		return TsAnimNotifyStateHideBattleUi._ClassPtr;
	}

	// Token: 0x06004838 RID: 18488 RVA: 0x000987FC File Offset: 0x000969FC
	public TsAnimNotifyStateHideBattleUi() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideBattleUi.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004839 RID: 18489 RVA: 0x00098824 File Offset: 0x00096A24
	public TsAnimNotifyStateHideBattleUi(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateHideBattleUi.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600483A RID: 18490 RVA: 0x00098857 File Offset: 0x00096A57
	protected TsAnimNotifyStateHideBattleUi(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600483B RID: 18491 RVA: 0x00098860 File Offset: 0x00096A60
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x0600483C RID: 18492 RVA: 0x0009889C File Offset: 0x00096A9C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600483D RID: 18493 RVA: 0x000988CF File Offset: 0x00096ACF
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400140F RID: 5135
	private static readonly int[] PlayerInputLimitTagList = new int[]
	{
		GameplayTagDefine.EGameplayTagId["角色.Common.BUFF通用标识.不能切人"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止跳跃"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攀爬"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象1"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象2"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"],
		GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止瞄准开镜"]
	};

	// Token: 0x04001410 RID: 5136
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateHideBattleUi.TsAnimNotifyStateHideBattleUi_C";

	// Token: 0x04001411 RID: 5137
	private static IntPtr _ClassPtr;

	// Token: 0x04001412 RID: 5138
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001413 RID: 5139
	private static int __PropertyOffset_需要额外显示的ui类型;

	// Token: 0x04001414 RID: 5140
	[Nullable(2)]
	private TArray<EBattleUIChild> _需要额外显示的ui类型;

	// Token: 0x04001415 RID: 5141
	private static int __PropertyOffset_IsHiding;
}
