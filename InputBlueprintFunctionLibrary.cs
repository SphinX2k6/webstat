using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000E9F RID: 3743
[UClass("/Game/Aki/TypeScript/Game/Input/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/Input/InputBlueprintFunctionLibrary.InputBlueprintFunctionLibrary_C")]
public class InputBlueprintFunctionLibrary : UBlueprintFunctionLibrary, IUnrealUObject, IUnrealObject
{
	// Token: 0x06005C61 RID: 23649 RVA: 0x00173DB1 File Offset: 0x00171FB1
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PreProcessInput(float deltaTime, bool gamePaused)
	{
		ControllerBase<InputController>.Instance.PreProcessInput(deltaTime, gamePaused);
	}

	// Token: 0x06005C62 RID: 23650 RVA: 0x00173DBF File Offset: 0x00171FBF
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void PostProcessInput(float deltaTime, bool gamePaused)
	{
		ControllerBase<InputController>.Instance.PostProcessInput(deltaTime, gamePaused);
	}

	// Token: 0x06005C63 RID: 23651 RVA: 0x00173DCD File Offset: 0x00171FCD
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool IsKeyDown(int action)
	{
		return ControllerBase<InputController>.Instance.IsKeyDown((CSharpScript.Game.Input.EInputAction)((byte)action));
	}

	// Token: 0x06005C64 RID: 23652 RVA: 0x00173DE0 File Offset: 0x00171FE0
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetKeyDownTime(int action)
	{
		return ControllerBase<InputController>.Instance.GetKeyDownTime((CSharpScript.Game.Input.EInputAction)((byte)action));
	}

	// Token: 0x06005C65 RID: 23653 RVA: 0x00173DF4 File Offset: 0x00171FF4
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float GetCommandInterval(ECommandType commandType, float defaultInterval = 1f)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		object obj;
		if (baseCharacter == null)
		{
			obj = null;
		}
		else
		{
			Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
			obj = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterInputComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return defaultInterval;
		}
		return obj2.GetCommandInterval(commandType);
	}

	// Token: 0x06005C66 RID: 23654 RVA: 0x00173E1F File Offset: 0x0017201F
	[UFunction(EFunctionFlags.FUNC_None)]
	public static void SetTimeDilation(float timeDilation)
	{
		ControllerBase<GameModeController>.Instance.SetTimeDilation(timeDilation, ETimeDilationType.Default);
	}

	// Token: 0x06005C67 RID: 23655 RVA: 0x00173E2D File Offset: 0x0017202D
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	public static string GetActionInputDistributeTag(string actionName)
	{
		return ModelBase<InputDistributeModel>.Instance.GetActionInputDistributeTagName(actionName);
	}

	// Token: 0x06005C68 RID: 23656 RVA: 0x00173E3A File Offset: 0x0017203A
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	[return: Nullable(2)]
	public static string GetAxisInputDistributeTag(string axisName)
	{
		return ModelBase<InputDistributeModel>.Instance.GetAxisInputDistributeTagName(axisName);
	}

	// Token: 0x06005C69 RID: 23657 RVA: 0x00173E48 File Offset: 0x00172048
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static TArray<string> GetAllInputDistributeTag()
	{
		TArray<string> tarray = new TArray<string>();
		foreach (ValueTuple<string, string> valueTuple in InputDistributeDefine.InitializeInputDistributeTagDefine)
		{
			tarray.Add(valueTuple.Item1);
		}
		return tarray;
	}

	// Token: 0x06005C6A RID: 23658 RVA: 0x00173EA8 File Offset: 0x001720A8
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool HasMoveAxisInput()
	{
		if (Singleton<Info>.Instance.OperationType == EOperationType.Pad && ModelBase<BattleUiModel>.Instance.IsPressJoyStick)
		{
			return true;
		}
		InputModel instance = ModelBase<InputModel>.Instance;
		Dictionary<EInputAxis, float> dictionary = (instance != null) ? instance.GetAxisValues() : null;
		if (dictionary == null)
		{
			return false;
		}
		float num;
		bool flag = dictionary.TryGetValue(EInputAxis.MoveForward, out num);
		if (flag && num != 0f)
		{
			return true;
		}
		float num2;
		bool flag2 = dictionary.TryGetValue(EInputAxis.MoveRight, out num2);
		if (flag2 && num2 != 0f)
		{
			return true;
		}
		if ((flag && num == 0f) || (flag2 && num2 == 0f))
		{
			return false;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		CharacterInputComponent characterInputComponent;
		if (baseCharacter == null)
		{
			characterInputComponent = null;
		}
		else
		{
			Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
			characterInputComponent = ((entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterInputComponent>() : null);
		}
		CharacterInputComponent characterInputComponent2 = characterInputComponent;
		if (characterInputComponent2 == null)
		{
			return false;
		}
		float? num3 = characterInputComponent2.QueryInputAxis(EInputAxis.MoveForward);
		if (num3 != null && num3.GetValueOrDefault() != 0f)
		{
			return true;
		}
		float? num4 = characterInputComponent2.QueryInputAxis(EInputAxis.MoveRight);
		return num4 != null && num4.GetValueOrDefault() != 0f;
	}

	// Token: 0x06005C6B RID: 23659 RVA: 0x00173FAC File Offset: 0x001721AC
	[UFunction(EFunctionFlags.FUNC_None)]
	public static float HasRightMoveAxisInput()
	{
		Dictionary<EInputAxis, float> axisValues = ModelBase<InputModel>.Instance.GetAxisValues();
		float result;
		if (axisValues == null || !axisValues.TryGetValue(EInputAxis.MoveRight, out result))
		{
			return 0f;
		}
		return result;
	}

	// Token: 0x06005C6C RID: 23660 RVA: 0x00173FE0 File Offset: 0x001721E0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CreateSkillCommand(int entityId, int skillId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null || !entity.Valid)
		{
			return null;
		}
		return InputFunctionCommon.CreateSkillCommand(entity, skillId);
	}

	// Token: 0x06005C6D RID: 23661 RVA: 0x00174010 File Offset: 0x00172210
	[UFunction(EFunctionFlags.FUNC_None)]
	public static bool CanResponseInput(int entityId)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		return entity != null && entity.Valid && InputFunctionCommon.CanResponseInput(entity);
	}

	// Token: 0x06005C6E RID: 23662 RVA: 0x0017403C File Offset: 0x0017223C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterAttackOnPress(float time, SInputCommand parentCommand, BP_InputComponent_C bpInputComp)
	{
		return InputFunctionAttack.AttackOnPress(time, bpInputComp) ?? parentCommand;
	}

	// Token: 0x06005C6F RID: 23663 RVA: 0x0017404C File Offset: 0x0017224C
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterAttackOnRelease(float time, SInputCommand parentCommand, BP_InputComponent_C bpInputComp)
	{
		SInputCommand sinputCommand = InputFunctionAttack.AttackOnRelease(time, bpInputComp);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C70 RID: 23664 RVA: 0x00174070 File Offset: 0x00172270
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterVisionSkill1OnPress(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionVisionSkill1.VisionSkill1OnPress(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C71 RID: 23665 RVA: 0x00174090 File Offset: 0x00172290
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterVisionSkill1OnRelease(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionVisionSkill1.VisionSkill1OnRelease(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C72 RID: 23666 RVA: 0x001740B0 File Offset: 0x001722B0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterVisionSkill2OnPress(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionVisionSkill2.VisionSkill2OnPress(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C73 RID: 23667 RVA: 0x001740D0 File Offset: 0x001722D0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CharacterVisionSkill2OnRelease(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionVisionSkill2.VisionSkill2OnRelease(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C74 RID: 23668 RVA: 0x001740F0 File Offset: 0x001722F0
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand FishingBoatVisionSkill1OnPress(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionFishingBoat.FishingBoatVisionSkill1OnPress(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C75 RID: 23669 RVA: 0x00174110 File Offset: 0x00172310
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand FishingBoatVisionSkill1OnRelease(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionFishingBoat.FishingBoatVisionSkill1OnRelease(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C76 RID: 23670 RVA: 0x00174130 File Offset: 0x00172330
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand CreateFishingBoatSprintCommand(int skillId)
	{
		return InputFunctionFishingBoat.CreateFishingBoatSprintCommand(skillId);
	}

	// Token: 0x06005C77 RID: 23671 RVA: 0x00174138 File Offset: 0x00172338
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand MotorcycleVisionSkill1OnPress(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionMotorcycle.MotorcycleVisionSkill1OnPress(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C78 RID: 23672 RVA: 0x00174158 File Offset: 0x00172358
	[NullableContext(1)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public static SInputCommand MotorcycleVisionSkill1OnRelease(float time, SInputCommand parentCommand)
	{
		SInputCommand sinputCommand = InputFunctionMotorcycle.MotorcycleVisionSkill1OnRelease(time);
		if (!(sinputCommand != null))
		{
			return parentCommand;
		}
		return sinputCommand;
	}

	// Token: 0x06005C79 RID: 23673 RVA: 0x00174178 File Offset: 0x00172378
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (InputBlueprintFunctionLibrary._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/Input/InputBlueprintFunctionLibrary.InputBlueprintFunctionLibrary_C");
		}
		return InputBlueprintFunctionLibrary._ClassPtr;
	}

	// Token: 0x06005C7A RID: 23674 RVA: 0x0017419C File Offset: 0x0017239C
	public InputBlueprintFunctionLibrary() : this(BuiltinUtils.AllocNativeUObject(InputBlueprintFunctionLibrary.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06005C7B RID: 23675 RVA: 0x001741C4 File Offset: 0x001723C4
	[NullableContext(1)]
	public InputBlueprintFunctionLibrary(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(InputBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06005C7C RID: 23676 RVA: 0x001741F7 File Offset: 0x001723F7
	protected InputBlueprintFunctionLibrary(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06005C7D RID: 23677 RVA: 0x00174200 File Offset: 0x00172400
	protected unsafe static void __CPPCALL_PreProcessInput_Implementation(InputBlueprintFunctionLibrary.__PreProcessInput_FunctionParams* __Params)
	{
		InputBlueprintFunctionLibrary.PreProcessInput(__Params->deltaTime, __Params->gamePaused);
	}

	// Token: 0x06005C7E RID: 23678 RVA: 0x00174213 File Offset: 0x00172413
	protected unsafe static void __CPPCALL_PostProcessInput_Implementation(InputBlueprintFunctionLibrary.__PostProcessInput_FunctionParams* __Params)
	{
		InputBlueprintFunctionLibrary.PostProcessInput(__Params->deltaTime, __Params->gamePaused);
	}

	// Token: 0x06005C7F RID: 23679 RVA: 0x00174226 File Offset: 0x00172426
	protected unsafe static void __CPPCALL_IsKeyDown_Implementation(InputBlueprintFunctionLibrary.__IsKeyDown_FunctionParams* __Params)
	{
		__Params->__Result = InputBlueprintFunctionLibrary.IsKeyDown(__Params->action);
	}

	// Token: 0x06005C80 RID: 23680 RVA: 0x00174239 File Offset: 0x00172439
	protected unsafe static void __CPPCALL_GetKeyDownTime_Implementation(InputBlueprintFunctionLibrary.__GetKeyDownTime_FunctionParams* __Params)
	{
		__Params->__Result = InputBlueprintFunctionLibrary.GetKeyDownTime(__Params->action);
	}

	// Token: 0x06005C81 RID: 23681 RVA: 0x0017424C File Offset: 0x0017244C
	protected unsafe static void __CPPCALL_GetCommandInterval_Implementation(InputBlueprintFunctionLibrary.__GetCommandInterval_FunctionParams* __Params)
	{
		ECommandType commandType = (ECommandType)__Params->commandType;
		__Params->__Result = InputBlueprintFunctionLibrary.GetCommandInterval(commandType, __Params->defaultInterval);
	}

	// Token: 0x06005C82 RID: 23682 RVA: 0x00174272 File Offset: 0x00172472
	protected unsafe static void __CPPCALL_SetTimeDilation_Implementation(InputBlueprintFunctionLibrary.__SetTimeDilation_FunctionParams* __Params)
	{
		InputBlueprintFunctionLibrary.SetTimeDilation(__Params->timeDilation);
	}

	// Token: 0x06005C83 RID: 23683 RVA: 0x00174280 File Offset: 0x00172480
	protected unsafe static void __CPPCALL_GetActionInputDistributeTag_Implementation(InputBlueprintFunctionLibrary.__GetActionInputDistributeTag_FunctionParams* __Params)
	{
		string actionName = FString.ToString((void*)(&__Params->actionName));
		FString.CopyFrom((void*)(&__Params->__Result), InputBlueprintFunctionLibrary.GetActionInputDistributeTag(actionName));
	}

	// Token: 0x06005C84 RID: 23684 RVA: 0x001742AC File Offset: 0x001724AC
	protected unsafe static void __CPPCALL_GetAxisInputDistributeTag_Implementation(InputBlueprintFunctionLibrary.__GetAxisInputDistributeTag_FunctionParams* __Params)
	{
		string axisName = FString.ToString((void*)(&__Params->axisName));
		FString.CopyFrom((void*)(&__Params->__Result), InputBlueprintFunctionLibrary.GetAxisInputDistributeTag(axisName));
	}

	// Token: 0x06005C85 RID: 23685 RVA: 0x001742D8 File Offset: 0x001724D8
	protected unsafe static void __CPPCALL_GetAllInputDistributeTag_Implementation(InputBlueprintFunctionLibrary.__GetAllInputDistributeTag_FunctionParams* __Params)
	{
		TArray<string> allInputDistributeTag = InputBlueprintFunctionLibrary.GetAllInputDistributeTag();
		if (allInputDistributeTag == null)
		{
			return;
		}
		allInputDistributeTag.CopyTo(&__Params->__Result, default(UScriptStructStackOnlyPtr));
	}

	// Token: 0x06005C86 RID: 23686 RVA: 0x00174304 File Offset: 0x00172504
	protected unsafe static void __CPPCALL_HasMoveAxisInput_Implementation(InputBlueprintFunctionLibrary.__HasMoveAxisInput_FunctionParams* __Params)
	{
		__Params->__Result = InputBlueprintFunctionLibrary.HasMoveAxisInput();
	}

	// Token: 0x06005C87 RID: 23687 RVA: 0x00174311 File Offset: 0x00172511
	protected unsafe static void __CPPCALL_HasRightMoveAxisInput_Implementation(InputBlueprintFunctionLibrary.__HasRightMoveAxisInput_FunctionParams* __Params)
	{
		__Params->__Result = InputBlueprintFunctionLibrary.HasRightMoveAxisInput();
	}

	// Token: 0x06005C88 RID: 23688 RVA: 0x0017431E File Offset: 0x0017251E
	protected unsafe static void __CPPCALL_CreateSkillCommand_Implementation(InputBlueprintFunctionLibrary.__CreateSkillCommand_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CreateSkillCommand(__Params->entityId, __Params->skillId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C89 RID: 23689 RVA: 0x00174351 File Offset: 0x00172551
	protected unsafe static void __CPPCALL_CanResponseInput_Implementation(InputBlueprintFunctionLibrary.__CanResponseInput_FunctionParams* __Params)
	{
		__Params->__Result = InputBlueprintFunctionLibrary.CanResponseInput(__Params->entityId);
	}

	// Token: 0x06005C8A RID: 23690 RVA: 0x00174364 File Offset: 0x00172564
	protected unsafe static void __CPPCALL_CharacterAttackOnPress_Implementation(InputBlueprintFunctionLibrary.__CharacterAttackOnPress_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		BP_InputComponent_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_InputComponent_C>(__Params->bpInputComp);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterAttackOnPress(__Params->time, parentCommand, orCreateUObjectByNativePointer);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C8B RID: 23691 RVA: 0x001743BC File Offset: 0x001725BC
	protected unsafe static void __CPPCALL_CharacterAttackOnRelease_Implementation(InputBlueprintFunctionLibrary.__CharacterAttackOnRelease_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		BP_InputComponent_C orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_InputComponent_C>(__Params->bpInputComp);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterAttackOnRelease(__Params->time, parentCommand, orCreateUObjectByNativePointer);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C8C RID: 23692 RVA: 0x00174414 File Offset: 0x00172614
	protected unsafe static void __CPPCALL_CharacterVisionSkill1OnPress_Implementation(InputBlueprintFunctionLibrary.__CharacterVisionSkill1OnPress_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterVisionSkill1OnPress(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C8D RID: 23693 RVA: 0x0017445C File Offset: 0x0017265C
	protected unsafe static void __CPPCALL_CharacterVisionSkill1OnRelease_Implementation(InputBlueprintFunctionLibrary.__CharacterVisionSkill1OnRelease_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterVisionSkill1OnRelease(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C8E RID: 23694 RVA: 0x001744A4 File Offset: 0x001726A4
	protected unsafe static void __CPPCALL_CharacterVisionSkill2OnPress_Implementation(InputBlueprintFunctionLibrary.__CharacterVisionSkill2OnPress_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterVisionSkill2OnPress(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C8F RID: 23695 RVA: 0x001744EC File Offset: 0x001726EC
	protected unsafe static void __CPPCALL_CharacterVisionSkill2OnRelease_Implementation(InputBlueprintFunctionLibrary.__CharacterVisionSkill2OnRelease_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CharacterVisionSkill2OnRelease(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C90 RID: 23696 RVA: 0x00174534 File Offset: 0x00172734
	protected unsafe static void __CPPCALL_FishingBoatVisionSkill1OnPress_Implementation(InputBlueprintFunctionLibrary.__FishingBoatVisionSkill1OnPress_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.FishingBoatVisionSkill1OnPress(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C91 RID: 23697 RVA: 0x0017457C File Offset: 0x0017277C
	protected unsafe static void __CPPCALL_FishingBoatVisionSkill1OnRelease_Implementation(InputBlueprintFunctionLibrary.__FishingBoatVisionSkill1OnRelease_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.FishingBoatVisionSkill1OnRelease(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C92 RID: 23698 RVA: 0x001745C4 File Offset: 0x001727C4
	protected unsafe static void __CPPCALL_CreateFishingBoatSprintCommand_Implementation(InputBlueprintFunctionLibrary.__CreateFishingBoatSprintCommand_FunctionParams* __Params)
	{
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.CreateFishingBoatSprintCommand(__Params->skillId);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C93 RID: 23699 RVA: 0x001745F4 File Offset: 0x001727F4
	protected unsafe static void __CPPCALL_MotorcycleVisionSkill1OnPress_Implementation(InputBlueprintFunctionLibrary.__MotorcycleVisionSkill1OnPress_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.MotorcycleVisionSkill1OnPress(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x06005C94 RID: 23700 RVA: 0x0017463C File Offset: 0x0017283C
	protected unsafe static void __CPPCALL_MotorcycleVisionSkill1OnRelease_Implementation(InputBlueprintFunctionLibrary.__MotorcycleVisionSkill1OnRelease_FunctionParams* __Params)
	{
		SInputCommand parentCommand = new SInputCommand(&__Params->parentCommand, true, true);
		UScriptStructStackOnlyPtr nativeUStructPtr = SInputCommand.StaticStruct();
		IntPtr dest = &__Params->__Result;
		SInputCommand sinputCommand = InputBlueprintFunctionLibrary.MotorcycleVisionSkill1OnRelease(__Params->time, parentCommand);
		UnrealReflectionUtils.CopyNativeStruct(nativeUStructPtr, dest, (sinputCommand != null) ? sinputCommand.NativePtr : ((IntPtr)0), 1, false);
	}

	// Token: 0x04002C2D RID: 11309
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/Input/InputBlueprintFunctionLibrary.InputBlueprintFunctionLibrary_C";

	// Token: 0x04002C2E RID: 11310
	private static IntPtr _ClassPtr;

	// Token: 0x04002C2F RID: 11311
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x020072D1 RID: 29393
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PreProcessInput_FunctionParams
	{
		// Token: 0x04027DD6 RID: 163286
		[FieldOffset(0)]
		public float deltaTime;

		// Token: 0x04027DD7 RID: 163287
		[FieldOffset(4)]
		public bool gamePaused;

		// Token: 0x04027DD8 RID: 163288
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072D2 RID: 29394
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __PostProcessInput_FunctionParams
	{
		// Token: 0x04027DD9 RID: 163289
		[FieldOffset(0)]
		public float deltaTime;

		// Token: 0x04027DDA RID: 163290
		[FieldOffset(4)]
		public bool gamePaused;

		// Token: 0x04027DDB RID: 163291
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072D3 RID: 29395
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __IsKeyDown_FunctionParams
	{
		// Token: 0x04027DDC RID: 163292
		[FieldOffset(0)]
		public int action;

		// Token: 0x04027DDD RID: 163293
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027DDE RID: 163294
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020072D4 RID: 29396
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetKeyDownTime_FunctionParams
	{
		// Token: 0x04027DDF RID: 163295
		[FieldOffset(0)]
		public int action;

		// Token: 0x04027DE0 RID: 163296
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027DE1 RID: 163297
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020072D5 RID: 29397
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetCommandInterval_FunctionParams
	{
		// Token: 0x04027DE2 RID: 163298
		[FieldOffset(0)]
		public byte commandType;

		// Token: 0x04027DE3 RID: 163299
		[FieldOffset(4)]
		public float defaultInterval;

		// Token: 0x04027DE4 RID: 163300
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027DE5 RID: 163301
		[FieldOffset(16)]
		public float __Result;
	}

	// Token: 0x020072D6 RID: 29398
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __SetTimeDilation_FunctionParams
	{
		// Token: 0x04027DE6 RID: 163302
		[FieldOffset(0)]
		public float timeDilation;

		// Token: 0x04027DE7 RID: 163303
		[FieldOffset(8)]
		public IntPtr __WorldContext;
	}

	// Token: 0x020072D7 RID: 29399
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetActionInputDistributeTag_FunctionParams
	{
		// Token: 0x04027DE8 RID: 163304
		[FieldOffset(0)]
		public FString actionName;

		// Token: 0x04027DE9 RID: 163305
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04027DEA RID: 163306
		[FieldOffset(24)]
		public FString __Result;
	}

	// Token: 0x020072D8 RID: 29400
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __GetAxisInputDistributeTag_FunctionParams
	{
		// Token: 0x04027DEB RID: 163307
		[FieldOffset(0)]
		public FString axisName;

		// Token: 0x04027DEC RID: 163308
		[FieldOffset(16)]
		public IntPtr __WorldContext;

		// Token: 0x04027DED RID: 163309
		[FieldOffset(24)]
		public FString __Result;
	}

	// Token: 0x020072D9 RID: 29401
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __GetAllInputDistributeTag_FunctionParams
	{
		// Token: 0x04027DEE RID: 163310
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027DEF RID: 163311
		[FieldOffset(8)]
		public byte __Result;
	}

	// Token: 0x020072DA RID: 29402
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __HasMoveAxisInput_FunctionParams
	{
		// Token: 0x04027DF0 RID: 163312
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027DF1 RID: 163313
		[FieldOffset(8)]
		public bool __Result;
	}

	// Token: 0x020072DB RID: 29403
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	protected ref struct __HasRightMoveAxisInput_FunctionParams
	{
		// Token: 0x04027DF2 RID: 163314
		[FieldOffset(0)]
		public IntPtr __WorldContext;

		// Token: 0x04027DF3 RID: 163315
		[FieldOffset(8)]
		public float __Result;
	}

	// Token: 0x020072DC RID: 29404
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __CreateSkillCommand_FunctionParams
	{
		// Token: 0x04027DF4 RID: 163316
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04027DF5 RID: 163317
		[FieldOffset(4)]
		public int skillId;

		// Token: 0x04027DF6 RID: 163318
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027DF7 RID: 163319
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020072DD RID: 29405
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 24)]
	protected ref struct __CanResponseInput_FunctionParams
	{
		// Token: 0x04027DF8 RID: 163320
		[FieldOffset(0)]
		public int entityId;

		// Token: 0x04027DF9 RID: 163321
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027DFA RID: 163322
		[FieldOffset(16)]
		public bool __Result;
	}

	// Token: 0x020072DE RID: 29406
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __CharacterAttackOnPress_FunctionParams
	{
		// Token: 0x04027DFB RID: 163323
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027DFC RID: 163324
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027DFD RID: 163325
		[FieldOffset(24)]
		public IntPtr bpInputComp;

		// Token: 0x04027DFE RID: 163326
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04027DFF RID: 163327
		[FieldOffset(40)]
		public byte __Result;
	}

	// Token: 0x020072DF RID: 29407
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 64)]
	protected ref struct __CharacterAttackOnRelease_FunctionParams
	{
		// Token: 0x04027E00 RID: 163328
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E01 RID: 163329
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E02 RID: 163330
		[FieldOffset(24)]
		public IntPtr bpInputComp;

		// Token: 0x04027E03 RID: 163331
		[FieldOffset(32)]
		public IntPtr __WorldContext;

		// Token: 0x04027E04 RID: 163332
		[FieldOffset(40)]
		public byte __Result;
	}

	// Token: 0x020072E0 RID: 29408
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __CharacterVisionSkill1OnPress_FunctionParams
	{
		// Token: 0x04027E05 RID: 163333
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E06 RID: 163334
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E07 RID: 163335
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E08 RID: 163336
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E1 RID: 29409
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __CharacterVisionSkill1OnRelease_FunctionParams
	{
		// Token: 0x04027E09 RID: 163337
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E0A RID: 163338
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E0B RID: 163339
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E0C RID: 163340
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E2 RID: 29410
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __CharacterVisionSkill2OnPress_FunctionParams
	{
		// Token: 0x04027E0D RID: 163341
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E0E RID: 163342
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E0F RID: 163343
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E10 RID: 163344
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E3 RID: 29411
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __CharacterVisionSkill2OnRelease_FunctionParams
	{
		// Token: 0x04027E11 RID: 163345
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E12 RID: 163346
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E13 RID: 163347
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E14 RID: 163348
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E4 RID: 29412
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __FishingBoatVisionSkill1OnPress_FunctionParams
	{
		// Token: 0x04027E15 RID: 163349
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E16 RID: 163350
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E17 RID: 163351
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E18 RID: 163352
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E5 RID: 29413
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __FishingBoatVisionSkill1OnRelease_FunctionParams
	{
		// Token: 0x04027E19 RID: 163353
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E1A RID: 163354
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E1B RID: 163355
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E1C RID: 163356
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E6 RID: 29414
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 40)]
	protected ref struct __CreateFishingBoatSprintCommand_FunctionParams
	{
		// Token: 0x04027E1D RID: 163357
		[FieldOffset(0)]
		public int skillId;

		// Token: 0x04027E1E RID: 163358
		[FieldOffset(8)]
		public IntPtr __WorldContext;

		// Token: 0x04027E1F RID: 163359
		[FieldOffset(16)]
		public byte __Result;
	}

	// Token: 0x020072E7 RID: 29415
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __MotorcycleVisionSkill1OnPress_FunctionParams
	{
		// Token: 0x04027E20 RID: 163360
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E21 RID: 163361
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E22 RID: 163362
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E23 RID: 163363
		[FieldOffset(32)]
		public byte __Result;
	}

	// Token: 0x020072E8 RID: 29416
	[CompilerFeatureRequired("RefStructs")]
	[StructLayout(LayoutKind.Explicit, Size = 56)]
	protected ref struct __MotorcycleVisionSkill1OnRelease_FunctionParams
	{
		// Token: 0x04027E24 RID: 163364
		[FieldOffset(0)]
		public float time;

		// Token: 0x04027E25 RID: 163365
		[FieldOffset(4)]
		public byte parentCommand;

		// Token: 0x04027E26 RID: 163366
		[FieldOffset(24)]
		public IntPtr __WorldContext;

		// Token: 0x04027E27 RID: 163367
		[FieldOffset(32)]
		public byte __Result;
	}
}
