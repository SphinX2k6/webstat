using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Character.BaseCharacter.AnimNotifyState;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000D62 RID: 3426
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AnimNotifyState/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateOpenSimpleGameplay.TsAnimNotifyStateOpenSimpleGameplay_C")]
public class TsAnimNotifyStateOpenSimpleGameplay : TsAnimNotifyStateBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x0600495E RID: 18782 RVA: 0x0009D900 File Offset: 0x0009BB00
	// (set) Token: 0x0600495F RID: 18783 RVA: 0x0009D939 File Offset: 0x0009BB39
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SAnimNotifyInteractInfo> InteractInfos
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SAnimNotifyInteractInfo> result;
			if ((result = this._InteractInfos) == null)
			{
				result = (this._InteractInfos = new TArray<SAnimNotifyInteractInfo>(base.NativePtr + (IntPtr)TsAnimNotifyStateOpenSimpleGameplay.__PropertyOffset_InteractInfos, this));
			}
			return result;
		}
		set
		{
			this.InteractInfos.CopyAssign(value);
		}
	}

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x06004960 RID: 18784 RVA: 0x0009D947 File Offset: 0x0009BB47
	// (set) Token: 0x06004961 RID: 18785 RVA: 0x0009D957 File Offset: 0x0009BB57
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe EANSGameplayType GameplayType
	{
		get
		{
			return (EANSGameplayType)(*(base.NativePtr + (IntPtr)TsAnimNotifyStateOpenSimpleGameplay.__PropertyOffset_GameplayType));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsAnimNotifyStateOpenSimpleGameplay.__PropertyOffset_GameplayType) = (byte)value;
		}
	}

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x06004962 RID: 18786 RVA: 0x0009D968 File Offset: 0x0009BB68
	// (set) Token: 0x06004963 RID: 18787 RVA: 0x0009D9A1 File Offset: 0x0009BBA1
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<SGameplayResultSkillInfo> SkillInfos
	{
		get
		{
			base.FastCheckIsValid();
			TArray<SGameplayResultSkillInfo> result;
			if ((result = this._SkillInfos) == null)
			{
				result = (this._SkillInfos = new TArray<SGameplayResultSkillInfo>(base.NativePtr + (IntPtr)TsAnimNotifyStateOpenSimpleGameplay.__PropertyOffset_SkillInfos, this));
			}
			return result;
		}
		set
		{
			this.SkillInfos.CopyAssign(value);
		}
	}

	// Token: 0x06004964 RID: 18788 RVA: 0x0009D9B0 File Offset: 0x0009BBB0
	[return: Nullable(2)]
	private AnsInstanceState GetState(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState result;
		this.StateMap.TryGetValue(meshComp, out result);
		return result;
	}

	// Token: 0x06004965 RID: 18789 RVA: 0x0009D9CD File Offset: 0x0009BBCD
	private void DeleteState(USkeletalMeshComponent meshComp)
	{
		this.StateMap.Remove(meshComp);
	}

	// Token: 0x06004966 RID: 18790 RVA: 0x0009D9DC File Offset: 0x0009BBDC
	private AnsInstanceState CreateState(USkeletalMeshComponent meshComp, TsAnimNotifyStateOpenSimpleGameplay ans, TsBaseCharacter owner)
	{
		AnsInstanceState ansInstanceState;
		if (!this.StateMap.TryGetValue(meshComp, out ansInstanceState))
		{
			ansInstanceState = new AnsInstanceState
			{
				IsListening = true,
				BoundActionNames = new List<string>(),
				ExternalInteractIds = new List<int>(),
				Owner = owner,
				IsGameplayOpened = false,
				StartServerTimeStamp = new double?(Singleton<TimeUtil>.Instance.GetServerTimeStamp()),
				OnActionCallback = delegate(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
				{
					if (actionType == InputDistributeDefine.EActionType.Press)
					{
						ans.OnInteractTriggered(meshComp);
					}
				}
			};
			this.StateMap[meshComp] = ansInstanceState;
		}
		else
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.ZJL, "[TsAnimNotifyStateOpenSimpleGameplay] CreateState时发现旧状态残留，先清理", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CleanupAllInteractions(meshComp);
			ansInstanceState.IsListening = true;
			ansInstanceState.BoundActionNames.Clear();
			ansInstanceState.ExternalInteractIds.Clear();
			ansInstanceState.Owner = owner;
			ansInstanceState.IsGameplayOpened = false;
			ansInstanceState.StartServerTimeStamp = new double?(Singleton<TimeUtil>.Instance.GetServerTimeStamp());
		}
		return ansInstanceState;
	}

	// Token: 0x06004967 RID: 18791 RVA: 0x0009DAE8 File Offset: 0x0009BCE8
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

	// Token: 0x06004968 RID: 18792 RVA: 0x0009DB90 File Offset: 0x0009BD90
	[NullableContext(2)]
	protected virtual bool K2_NotifyBegin_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation, float totalDuration)
	{
		AActor owner = meshComp.GetOwner();
		if (!(owner is TsBaseCharacter))
		{
			return false;
		}
		CharacterActorComponent characterActorComponent = ((TsBaseCharacter)owner).CharacterActorComponent;
		if (characterActorComponent == null || !characterActorComponent.Valid || !characterActorComponent.IsAutonomousProxy)
		{
			return false;
		}
		if (ModelBase<PhotographModel>.Instance.IsOpenPhotograph)
		{
			return false;
		}
		if (owner != Global.BaseCharacter)
		{
			return false;
		}
		this.CreateState(meshComp, this, (TsBaseCharacter)owner);
		this.ProcessInteractInfos(meshComp);
		return true;
	}

	// Token: 0x06004969 RID: 18793 RVA: 0x0009DC04 File Offset: 0x0009BE04
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

	// Token: 0x0600496A RID: 18794 RVA: 0x0009DCA4 File Offset: 0x0009BEA4
	[NullableContext(2)]
	protected virtual bool K2_NotifyEnd_Implementation(USkeletalMeshComponent meshComp, UAnimSequenceBase animation)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return false;
		}
		if (state.IsGameplayOpened)
		{
			return true;
		}
		if (state.IsListening)
		{
			this.CleanupAllInteractions(meshComp);
		}
		state.IsListening = false;
		state.Owner = null;
		this.DeleteState(meshComp);
		return true;
	}

	// Token: 0x0600496B RID: 18795 RVA: 0x0009DCF0 File Offset: 0x0009BEF0
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

	// Token: 0x0600496C RID: 18796 RVA: 0x0009DD6B File Offset: 0x0009BF6B
	protected override string GetNotifyName_Implementation()
	{
		return "开启休闲玩法ANS";
	}

	// Token: 0x0600496D RID: 18797 RVA: 0x0009DD74 File Offset: 0x0009BF74
	private void ProcessInteractInfos(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		state.BoundActionNames = new List<string>();
		state.ExternalInteractIds = new List<int>();
		TArray<SAnimNotifyInteractInfo> interactInfos = this.InteractInfos;
		int num = (interactInfos != null) ? interactInfos.Num() : 0;
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			SAnimNotifyInteractInfo sanimNotifyInteractInfo = this.InteractInfos.Get(i);
			if (sanimNotifyInteractInfo.IsShowInteractUi)
			{
				this.RegisterExternalInteractInfo(meshComp, sanimNotifyInteractInfo);
			}
			else
			{
				this.BindInputActionFromInfo(meshComp, sanimNotifyInteractInfo);
			}
		}
		if (state.ExternalInteractIds.Count > 0)
		{
			TsInteractionUtils.OpenInteractHintView().Forget<bool>();
		}
	}

	// Token: 0x0600496E RID: 18798 RVA: 0x0009DE08 File Offset: 0x0009C008
	private void RegisterExternalInteractInfo(USkeletalMeshComponent meshComp, SAnimNotifyInteractInfo info)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		ExternalInteractInfo info2 = new ExternalInteractInfo
		{
			Text = (info.InteractText ?? ""),
			IconType = this.MapExternalInteractIcon(info.InteractIconType),
			Callback = delegate
			{
				this.OnInteractTriggered(meshComp);
			}
		};
		int num = ModelBase<InteractionModel>.Instance.RegisterExternalInteractInfo(info2);
		if (num >= 0)
		{
			state.ExternalInteractIds.Add(num);
		}
	}

	// Token: 0x0600496F RID: 18799 RVA: 0x0009DE9C File Offset: 0x0009C09C
	private EInteractIcon MapExternalInteractIcon(EExternalInteractIcon ueIconType)
	{
		if (ueIconType == EExternalInteractIcon.Dialog)
		{
			return EInteractIcon.Dialog;
		}
		global::Log instance = Singleton<global::Log>.Instance;
		ELogModule module = ELogModule.Battle;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "[TsAnimNotifyStateOpenSimpleGameplay] 未知的外部交互图标类型，回退为 Dialog";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IconType", ueIconType);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return EInteractIcon.Dialog;
	}

	// Token: 0x06004970 RID: 18800 RVA: 0x0009DEDC File Offset: 0x0009C0DC
	private void BindInputActionFromInfo(USkeletalMeshComponent meshComp, SAnimNotifyInteractInfo info)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		string text;
		if (TsAnimNotifyStateOpenSimpleGameplay.inputActionMap.TryGetValue(info.InputAction, out text))
		{
			ControllerBase<InputDistributeController>.Instance.BindAction(text, state.OnActionCallback);
			state.BoundActionNames.Add(text);
		}
	}

	// Token: 0x06004971 RID: 18801 RVA: 0x0009DF2B File Offset: 0x0009C12B
	private void CleanupAllInteractions(USkeletalMeshComponent meshComp)
	{
		this.UnBindInputActions(meshComp);
		this.UnregisterExternalInteractInfos(meshComp);
	}

	// Token: 0x06004972 RID: 18802 RVA: 0x0009DF3C File Offset: 0x0009C13C
	private void UnBindInputActions(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		foreach (string actionName in state.BoundActionNames)
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction(actionName, state.OnActionCallback);
		}
		state.BoundActionNames = new List<string>();
	}

	// Token: 0x06004973 RID: 18803 RVA: 0x0009DFB0 File Offset: 0x0009C1B0
	private void UnregisterExternalInteractInfos(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		InteractionModel instance = ModelBase<InteractionModel>.Instance;
		foreach (int id in state.ExternalInteractIds)
		{
			instance.UnregisterExternalInteractInfo(id);
		}
		state.ExternalInteractIds = new List<int>();
		if (!instance.HasExternalInteractInfos() && instance.GetInteractEntityIds().Count <= 0)
		{
			TsInteractionUtils.CloseInteractHintView("Unknown");
		}
	}

	// Token: 0x06004974 RID: 18804 RVA: 0x0009E040 File Offset: 0x0009C240
	public void OnInteractTriggered(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null)
		{
			return;
		}
		if (!state.IsListening)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.ZJL, "[TsAnimNotifyStateOpenSimpleGameplay] 收到交互触发，但当前未处于监听状态", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		if (state.IsGameplayOpened)
		{
			Singleton<global::Log>.Instance.Warn(ELogModule.Battle, ELogAuthor.ZJL, "[TsAnimNotifyStateOpenSimpleGameplay] 收到交互触发，但玩法已开启，防止重复触发", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.CleanupAllInteractions(meshComp);
		state.IsListening = false;
		state.IsGameplayOpened = true;
		this.OpenSimpleGameplay(meshComp);
	}

	// Token: 0x06004975 RID: 18805 RVA: 0x0009E0C0 File Offset: 0x0009C2C0
	private void FinalizeGameplay(USkeletalMeshComponent meshComp)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state != null)
		{
			state.Owner = null;
			state.IsGameplayOpened = false;
		}
		this.DeleteState(meshComp);
	}

	// Token: 0x06004976 RID: 18806 RVA: 0x0009E0F0 File Offset: 0x0009C2F0
	private void OpenSimpleGameplay(USkeletalMeshComponent meshComp)
	{
		ESimpleGameplayType esimpleGameplayType;
		if (!TsAnimNotifyStateOpenSimpleGameplay.ansGameplayTypeMap.TryGetValue(this.GameplayType, out esimpleGameplayType))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsAnimNotifyStateOpenSimpleGameplay] 未知的玩法类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("GameplayType", this.GameplayType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FinalizeGameplay(meshComp);
			return;
		}
		if (esimpleGameplayType == ESimpleGameplayType.DaemonHack)
		{
			this.OpenDaemonHackGameplay(meshComp);
			return;
		}
		global::Log instance2 = Singleton<global::Log>.Instance;
		ELogModule module2 = ELogModule.Battle;
		ELogAuthor author2 = ELogAuthor.ZJL;
		string message2 = "[TsAnimNotifyStateOpenSimpleGameplay] 暂不支持的玩法类型";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", esimpleGameplayType);
		instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		this.FinalizeGameplay(meshComp);
	}

	// Token: 0x06004977 RID: 18807 RVA: 0x0009E18C File Offset: 0x0009C38C
	private void OpenDaemonHackGameplay(USkeletalMeshComponent meshComp)
	{
		TsInteractionUtils.RegisterOpenViewName(EUiViewName.GolemHackingGameView);
		IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("LucyIdle2Games");
		int configId = 0;
		configId = ControllerBase<GolemHackingController>.Instance.OpenGameplayView(intArrayConfig.ToList<int>(), delegate(bool result)
		{
			this.OnGameplayResult(meshComp, result);
			ControllerBase<GolemHackingController>.Instance.OnUiGameplayFinish(configId);
		}, false, delegate(bool openResult, int _)
		{
			if (!openResult)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "[TsAnimNotifyStateOpenSimpleGameplay] 打开玩法界面失败，可能是参数错误或其他原因";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", configId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.FinalizeGameplay(meshComp);
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_vo_luxi_idle_idle02_minigame01");
			AnsInstanceState state = this.GetState(meshComp);
			if (state != null)
			{
				state.StartServerTimeStamp = new double?(Singleton<TimeUtil>.Instance.GetServerTimeStamp());
			}
		});
	}

	// Token: 0x06004978 RID: 18808 RVA: 0x0009E1F8 File Offset: 0x0009C3F8
	private void OnGameplayResult(USkeletalMeshComponent meshComp, bool success)
	{
		int resultSkillId = this.GetResultSkillId(meshComp, success);
		if (resultSkillId <= 0)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsAnimNotifyStateOpenSimpleGameplay] 玩法结果无对应技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("success", success);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FinalizeGameplay(meshComp);
			return;
		}
		this.CastResultSkill(meshComp, resultSkillId).Forget();
	}

	// Token: 0x06004979 RID: 18809 RVA: 0x0009E254 File Offset: 0x0009C454
	private int GetResultSkillId(USkeletalMeshComponent meshComp, bool success)
	{
		AnsInstanceState state = this.GetState(meshComp);
		if (state == null || state.Owner == null)
		{
			return -1;
		}
		for (int i = 0; i < this.SkillInfos.Num(); i++)
		{
			SGameplayResultSkillInfo sgameplayResultSkillInfo = this.SkillInfos.Get(i);
			if (this.CheckSkillCondition(state, success, sgameplayResultSkillInfo))
			{
				return sgameplayResultSkillInfo.SkillId;
			}
		}
		return -1;
	}

	// Token: 0x0600497A RID: 18810 RVA: 0x0009E2AC File Offset: 0x0009C4AC
	private bool CheckSkillCondition(AnsInstanceState state, bool success, SGameplayResultSkillInfo skillInfo)
	{
		if (skillInfo.IsWinResult != success)
		{
			return false;
		}
		if (skillInfo.IsCheckStartTimeStamp)
		{
			double? startServerTimeStamp = state.StartServerTimeStamp;
			if ((Singleton<TimeUtil>.Instance.GetServerTimeStamp() - startServerTimeStamp.GetValueOrDefault()) * Singleton<TimeUtil>.Instance.Millisecond > (double)skillInfo.TimeStampDelta)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600497B RID: 18811 RVA: 0x0009E2FC File Offset: 0x0009C4FC
	private UniTask CastResultSkill(USkeletalMeshComponent meshComp, int skillId)
	{
		TsAnimNotifyStateOpenSimpleGameplay.<CastResultSkill>d__36 <CastResultSkill>d__;
		<CastResultSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CastResultSkill>d__.<>4__this = this;
		<CastResultSkill>d__.meshComp = meshComp;
		<CastResultSkill>d__.skillId = skillId;
		<CastResultSkill>d__.<>1__state = -1;
		<CastResultSkill>d__.<>t__builder.Start<TsAnimNotifyStateOpenSimpleGameplay.<CastResultSkill>d__36>(ref <CastResultSkill>d__);
		return <CastResultSkill>d__.<>t__builder.Task;
	}

	// Token: 0x0600497C RID: 18812 RVA: 0x0009E34F File Offset: 0x0009C54F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsAnimNotifyStateOpenSimpleGameplay._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateOpenSimpleGameplay.TsAnimNotifyStateOpenSimpleGameplay_C");
		}
		return TsAnimNotifyStateOpenSimpleGameplay._ClassPtr;
	}

	// Token: 0x0600497D RID: 18813 RVA: 0x0009E374 File Offset: 0x0009C574
	public TsAnimNotifyStateOpenSimpleGameplay() : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateOpenSimpleGameplay.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600497E RID: 18814 RVA: 0x0009E39C File Offset: 0x0009C59C
	public TsAnimNotifyStateOpenSimpleGameplay(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateOpenSimpleGameplay.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600497F RID: 18815 RVA: 0x0009E3CF File Offset: 0x0009C5CF
	protected TsAnimNotifyStateOpenSimpleGameplay(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004980 RID: 18816 RVA: 0x0009E3E4 File Offset: 0x0009C5E4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyBegin_Implementation(UKuroAnimNotifyState.__K2_NotifyBegin_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyBegin_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->TotalDuration);
	}

	// Token: 0x06004981 RID: 18817 RVA: 0x0009E420 File Offset: 0x0009C620
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_K2_NotifyEnd_Implementation(UKuroAnimNotifyState.__K2_NotifyEnd_FunctionParams* __Params)
	{
		USkeletalMeshComponent orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<USkeletalMeshComponent>(__Params->MeshComp);
		UAnimSequenceBase orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<UAnimSequenceBase>(__Params->Animation);
		__Params->__Result = this.K2_NotifyEnd_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004982 RID: 18818 RVA: 0x0009E453 File Offset: 0x0009C653
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_GetNotifyName_Implementation(UAnimNotifyState.__GetNotifyName_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), this.GetNotifyName_Implementation());
	}

	// Token: 0x0400148E RID: 5262
	private static readonly Dictionary<EANSGameplayType, ESimpleGameplayType> ansGameplayTypeMap = new Dictionary<EANSGameplayType, ESimpleGameplayType>
	{
		{
			EANSGameplayType.魔偶骇入,
			ESimpleGameplayType.DaemonHack
		}
	};

	// Token: 0x0400148F RID: 5263
	private static readonly Dictionary<EInputAction, string> inputActionMap = new Dictionary<EInputAction, string>
	{
		{
			EInputAction.通用交互,
			"通用交互"
		}
	};

	// Token: 0x04001490 RID: 5264
	private readonly Dictionary<USkeletalMeshComponent, AnsInstanceState> StateMap = new Dictionary<USkeletalMeshComponent, AnsInstanceState>();

	// Token: 0x04001491 RID: 5265
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AnimNotifyState/TsAnimNotifyStateOpenSimpleGameplay.TsAnimNotifyStateOpenSimpleGameplay_C";

	// Token: 0x04001492 RID: 5266
	private static IntPtr _ClassPtr;

	// Token: 0x04001493 RID: 5267
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04001494 RID: 5268
	private static int __PropertyOffset_InteractInfos;

	// Token: 0x04001495 RID: 5269
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<SAnimNotifyInteractInfo> _InteractInfos;

	// Token: 0x04001496 RID: 5270
	private static int __PropertyOffset_GameplayType;

	// Token: 0x04001497 RID: 5271
	private static int __PropertyOffset_SkillInfos;

	// Token: 0x04001498 RID: 5272
	[Nullable(2)]
	private TArray<SGameplayResultSkillInfo> _SkillInfos;
}
