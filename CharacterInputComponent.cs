using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Blueprints;
using AkiClient.Game.Aki.Character.Input.ControlMonster;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Role.Common.Data.Structure;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02003053 RID: 12371
[NullableContext(1)]
[Nullable(0)]
public class CharacterInputComponent : EntityComponent, IInputHandler, IStaticVariableResetter
{
	// Token: 0x0601959D RID: 103837 RVA: 0x0074DA70 File Offset: 0x0074BC70
	static CharacterInputComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(CharacterInputComponent.CreateStaticDefaultValue), new Action(CharacterInputComponent.ResetStaticDefaultValue));
	}

	// Token: 0x17002234 RID: 8756
	// (get) Token: 0x0601959E RID: 103838 RVA: 0x0074DB5D File Offset: 0x0074BD5D
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public new static Type[] Dependencies
	{
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		get
		{
			return new Type[]
			{
				typeof(CharacterActorComponent)
			};
		}
	}

	// Token: 0x17002235 RID: 8757
	// (get) Token: 0x0601959F RID: 103839 RVA: 0x0074DB72 File Offset: 0x0074BD72
	// (set) Token: 0x060195A0 RID: 103840 RVA: 0x0074DB7A File Offset: 0x0074BD7A
	public bool IsLocalInput
	{
		get
		{
			return this.IsLocalInputInternal;
		}
		set
		{
			this.IsLocalInputInternal = value;
		}
	}

	// Token: 0x060195A1 RID: 103841 RVA: 0x0074DB84 File Offset: 0x0074BD84
	private void OnCharUseSkill(int charId, int skillId, bool isAutonomousProxy)
	{
		CharacterInputComponent.<>c__DisplayClass71_0 CS$<>8__locals1 = new CharacterInputComponent.<>c__DisplayClass71_0();
		CharacterInputComponent.<>c__DisplayClass71_0 CS$<>8__locals2 = CS$<>8__locals1;
		CharacterSkillComponent skillComponent = this.SkillComponent;
		CS$<>8__locals2.skillInfo = ((skillComponent != null) ? skillComponent.GetSkillInfo(skillId) : null);
		if (CS$<>8__locals1.skillInfo != null && Array.Exists<ESkillGenre>(CharacterInputComponent.interruptAutoMoving, (ESkillGenre x) => x == CS$<>8__locals1.skillInfo.SkillGenre))
		{
			this.InterruptAutoMoving("技能类型属于0/1/2/3/4/5/7/8/9", true);
		}
	}

	// Token: 0x060195A2 RID: 103842 RVA: 0x0074DBE3 File Offset: 0x0074BDE3
	private void OnCharPossessed(Entity entity, [Nullable(2)] AController newController)
	{
		this.SetCharacterController(newController as BP_CharacterController_C);
		ControllerBase<InputController>.Instance.AddInputHandler(this);
	}

	// Token: 0x060195A3 RID: 103843 RVA: 0x0074DBFC File Offset: 0x0074BDFC
	private void OnCharUnpossessed(Entity entity, [Nullable(2)] AController oldController)
	{
		this.InputEvents.Clear();
		this.InputCaches.Clear();
		this.NeedQueryInputCache = false;
		this.AxisValues.Clear();
		this.SetCharacterController(null);
		ControllerBase<InputController>.Instance.RemoveInputHandler(this);
	}

	// Token: 0x060195A4 RID: 103844 RVA: 0x0074DC38 File Offset: 0x0074BE38
	private void OnPositionStateChanged(ECharPositionState oldPositionState, ECharPositionState newPositionState)
	{
		this.UpdateCharacterInputDirectAndFacing(0f);
	}

	// Token: 0x060195A5 RID: 103845 RVA: 0x0074DC45 File Offset: 0x0074BE45
	private void CharOnRoleDrownInjure(bool isTargetKilled)
	{
		this.ClearInputCaches("CharOnRoleDrownInjure");
	}

	// Token: 0x060195A6 RID: 103846 RVA: 0x0074DC54 File Offset: 0x0074BE54
	private void OnCharacterMorphTypeChanged(Entity entity, EMorphType morphType, EMorphType oldMorphType)
	{
		if (this.InputLayer != null)
		{
			if (morphType != EMorphType.默认形态)
			{
				CharacterMorphComponent component = entity.GetComponent<CharacterMorphComponent>();
				BP_InputBase_C bpInputComp = (component != null) ? component.GetMorphBpInputComp() : null;
				this.InputLayer.SetBpInputComp(bpInputComp);
				ExtraInputLayer extraInputLayer = this.ExtraInputLayer;
				if (extraInputLayer == null)
				{
					return;
				}
				extraInputLayer.SetEnable(false);
				return;
			}
			else
			{
				this.InputLayer.ResetBpInputComp();
				ExtraInputLayer extraInputLayer2 = this.ExtraInputLayer;
				if (extraInputLayer2 == null)
				{
					return;
				}
				extraInputLayer2.SetEnable(true);
			}
		}
	}

	// Token: 0x060195A7 RID: 103847 RVA: 0x0074DCB9 File Offset: 0x0074BEB9
	public int GetPriority()
	{
		return 0;
	}

	// Token: 0x060195A8 RID: 103848 RVA: 0x0074DCBC File Offset: 0x0074BEBC
	public InputFilter GetInputFilter()
	{
		return this.InputGroup;
	}

	// Token: 0x060195A9 RID: 103849 RVA: 0x0074DCC4 File Offset: 0x0074BEC4
	public void HandlePressEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
		if (!ModelBase<BattleInputModel>.Instance.GetInputEnable(action))
		{
			return;
		}
		this.InputEvents.Add(new InputEvent(action, EInputState.Press, time, 0f));
	}

	// Token: 0x060195AA RID: 103850 RVA: 0x0074DCEC File Offset: 0x0074BEEC
	public void ForcePushPressEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
		this.InputEvents.Add(new InputEvent(action, EInputState.Press, time, 0f));
	}

	// Token: 0x060195AB RID: 103851 RVA: 0x0074DD08 File Offset: 0x0074BF08
	public void HandleReleaseEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
		if (!ModelBase<BattleInputModel>.Instance.GetInputEnable(action))
		{
			return;
		}
		this.InputEvents.Add(new InputEvent(action, EInputState.Release, time, 0f));
		if (CharacterInputComponent.HoldPressMap.ContainsKey(action))
		{
			CharacterInputComponent.HoldPressMap[action] = false;
		}
	}

	// Token: 0x060195AC RID: 103852 RVA: 0x0074DD54 File Offset: 0x0074BF54
	public void HandleHoldEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
		if (!ModelBase<BattleInputModel>.Instance.GetInputEnable(action))
		{
			return;
		}
		this.InputEvents.Add(new InputEvent(action, EInputState.Hold, time, 0f));
	}

	// Token: 0x060195AD RID: 103853 RVA: 0x0074DD7C File Offset: 0x0074BF7C
	public void HandleInputAxis(EInputAxis axis, float value)
	{
		float num = value;
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			byte value2 = axis.Value;
			if (value2 - 1 <= 1 || value2 == 5)
			{
				num /= Singleton<Time>.Instance.DeltaTimeSeconds;
			}
		}
		this.AxisValues[axis] = num;
	}

	// Token: 0x060195AE RID: 103854 RVA: 0x0074DDC2 File Offset: 0x0074BFC2
	public void ClearInputAxis(bool nextFrame)
	{
		this.ClearInputAxis(nextFrame, false);
	}

	// Token: 0x060195AF RID: 103855 RVA: 0x0074DDCC File Offset: 0x0074BFCC
	public void ClearInputAxis(bool nextFrame, bool onlyMove = false)
	{
		if (Singleton<Info>.Instance.AxisInputOptimize)
		{
			if (!nextFrame)
			{
				if (onlyMove)
				{
					this.AxisValues.Remove(EInputAxis.MoveForward);
					this.AxisValues.Remove(EInputAxis.MoveRight);
				}
				else
				{
					this.AxisValues.Clear();
				}
			}
			this.NextFrameClear = nextFrame;
		}
	}

	// Token: 0x060195B0 RID: 103856 RVA: 0x0074DE21 File Offset: 0x0074C021
	public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
	{
		if (Singleton<Info>.Instance.AxisInputOptimize)
		{
			if (!nextFrame)
			{
				if (this.AxisValues.ContainsKey(axis))
				{
					this.AxisValues[axis] = 0f;
					return;
				}
			}
			else
			{
				this.NextFrameClearAxis.Add(axis);
			}
		}
	}

	// Token: 0x060195B1 RID: 103857 RVA: 0x0074DE5F File Offset: 0x0074C05F
	private void OnShowMouseCursor(bool value)
	{
		if (this.LastShowMouseCursor != value)
		{
			this.LastShowMouseCursor = value;
			if (value)
			{
				this.AxisValues.Clear();
			}
		}
	}

	// Token: 0x060195B2 RID: 103858 RVA: 0x0074DE80 File Offset: 0x0074C080
	public void PreProcessInput(float deltaTime, bool gamePaused)
	{
		if (!Singleton<Info>.Instance.AxisInputOptimize)
		{
			this.AxisValues.Clear();
			return;
		}
		if (this.NextFrameClear)
		{
			this.NextFrameClear = false;
			this.AxisValues.Clear();
		}
		if (this.NextFrameClearAxis.Count > 0)
		{
			foreach (EInputAxis key in this.NextFrameClearAxis)
			{
				if (this.AxisValues.ContainsKey(key))
				{
					this.AxisValues.Remove(key);
				}
			}
			this.NextFrameClearAxis.Clear();
		}
	}

	// Token: 0x060195B3 RID: 103859 RVA: 0x0074DF34 File Offset: 0x0074C134
	public void PostProcessInput(float deltaTime, bool gamePaused)
	{
		this.UpdateMoveCache();
		this.UpdateMoveAxisToButton();
		List<IInputBase> list = new List<IInputBase>();
		if (this.NeedQueryInputCache)
		{
			list.AddRange(this.InputCaches);
			list.AddRange(this.InputEvents);
		}
		else
		{
			list.AddRange(this.InputEvents);
		}
		int num = this.NeedQueryInputCache ? this.InputCaches.Count : 0;
		this.NeedQueryInputCache = false;
		List<InputCommand> list2 = new List<InputCommand>();
		for (int i = 0; i < list.Count; i++)
		{
			IInputBase inputBase = list[i];
			SInputCommand command = this.GetCommand(deltaTime, inputBase);
			if (command != null && command.CommandType != ECommandType.None)
			{
				int index = (i < num) ? -1 : i;
				list2.Add(new InputCommand(inputBase.Action, inputBase.State, inputBase.Time, command, index));
			}
		}
		if (this.TestInputEvent.Count > 0)
		{
			int num2 = list.Count;
			for (int j = 0; j < this.TestInputEvent.Count; j++)
			{
				InputEvent inputEvent = this.TestInputEvent[j];
				SInputCommand command2 = this.GetCommand(deltaTime, inputEvent);
				if (command2 != null)
				{
					list2.Add(new InputCommand(inputEvent.Action, inputEvent.State, inputEvent.Time, command2, num2));
				}
				num2++;
			}
			this.TestInputEvent.Clear();
		}
		InputCommand bestInputCommand = this.GetBestInputCommand(list2);
		if (bestInputCommand != null && bestInputCommand.Index == -1)
		{
			this.ClearInputCaches("PostProcessInput");
		}
		this.ValidateInputCaches();
		this.CacheInputs(bestInputCommand);
		this.InputEvents.Clear();
		if (bestInputCommand != null && bestInputCommand.State == EInputState.Hold)
		{
			CharacterInputComponent.HoldPressMap[bestInputCommand.Action] = true;
		}
		if (bestInputCommand != null)
		{
			bool sceneCheckOn = ModelBase<SundryModel>.Instance.SceneCheckOn;
			this.ExecuteInputCommand(bestInputCommand, "PostProcessInput");
		}
	}

	// Token: 0x060195B4 RID: 103860 RVA: 0x0074E114 File Offset: 0x0074C314
	public void TestActionInput(CSharpScript.Game.Input.EInputAction action, EInputState state, float time)
	{
		InputEvent item = new InputEvent(action, state, time, 0f);
		this.TestInputEvent.Add(item);
	}

	// Token: 0x060195B5 RID: 103861 RVA: 0x0074E13C File Offset: 0x0074C33C
	[return: Nullable(2)]
	private SInputCommand GetCommand(float deltaTime, IInputBase evt)
	{
		SInputCommand result = null;
		switch (evt.State)
		{
		case EInputState.Press:
			this.DispatchPressEvent(evt.Action, (double)evt.Time, evt.Param);
			result = this.HandlePress(evt.Action, evt.Time, evt.Param);
			break;
		case EInputState.Release:
			this.DispatchReleaseEvent(evt.Action, (double)evt.Time, evt.Param);
			result = this.HandleRelease(evt.Action, (double)evt.Time, evt.Param);
			break;
		case EInputState.Hold:
			if (!this.ShouldTriggerHoldEvent(evt.Action, (double)evt.Time, deltaTime))
			{
				evt.Action = CSharpScript.Game.Input.EInputAction.None;
				return null;
			}
			result = this.HandleHold(evt.Action, (double)evt.Time, evt.Param);
			break;
		}
		return result;
	}

	// Token: 0x060195B6 RID: 103862 RVA: 0x0074E214 File Offset: 0x0074C414
	[NullableContext(2)]
	private void CacheInputs(InputCommand bestInputCommand)
	{
		float worldTime = this.GetWorldTime();
		int num = (bestInputCommand != null) ? bestInputCommand.Index : -1;
		for (int i = 0; i < this.InputEvents.Count; i++)
		{
			InputEvent inputEvent = this.InputEvents[i];
			if (i != num && !(inputEvent.Action == CSharpScript.Game.Input.EInputAction.None) && this.GetCacheTime(inputEvent.Action, inputEvent.State) != 0f)
			{
				this.InputCaches.Add(new InputCache(inputEvent.Action, inputEvent.State, inputEvent.Time, worldTime, 0f, -1, inputEvent.Param));
			}
		}
	}

	// Token: 0x060195B7 RID: 103863 RVA: 0x0074E2B8 File Offset: 0x0074C4B8
	public void SetMoveVectorCache(global::Vector input, global::Vector worldInput)
	{
		this.MoveDirectionCache.DeepCopy(input);
		this.MoveDirectionCache.Normalize(9.99999993922529E-09);
		this.WorldMoveDirectionCache.DeepCopy(worldInput);
		this.WorldMoveDirectionCache.Normalize(9.99999993922529E-09);
	}

	// Token: 0x060195B8 RID: 103864 RVA: 0x0074E307 File Offset: 0x0074C507
	public void ResetMoveVectorCache()
	{
		this.MoveDirectionCache.Reset();
		this.WorldMoveDirectionCache.Reset();
	}

	// Token: 0x060195B9 RID: 103865 RVA: 0x0074E31F File Offset: 0x0074C51F
	[NullableContext(2)]
	public void SetCharacterController(BP_CharacterController_C controller)
	{
		this.CharacterControllerInternal = controller;
	}

	// Token: 0x17002236 RID: 8758
	// (get) Token: 0x060195BA RID: 103866 RVA: 0x0074E328 File Offset: 0x0074C528
	public BP_CharacterController_C CharacterController
	{
		get
		{
			return this.CharacterControllerInternal;
		}
	}

	// Token: 0x17002237 RID: 8759
	// (get) Token: 0x060195BB RID: 103867 RVA: 0x0074E330 File Offset: 0x0074C530
	[Nullable(2)]
	public TsBaseCharacter Character
	{
		[NullableContext(2)]
		get
		{
			return this.CharacterInternal;
		}
	}

	// Token: 0x060195BC RID: 103868 RVA: 0x0074E338 File Offset: 0x0074C538
	public void SetCharacter(TsBaseCharacter character)
	{
		this.CharacterInternal = character;
	}

	// Token: 0x060195BD RID: 103869 RVA: 0x0074E341 File Offset: 0x0074C541
	public global::Vector GetMoveVectorCache()
	{
		return this.MoveVectorCache;
	}

	// Token: 0x060195BE RID: 103870 RVA: 0x0074E349 File Offset: 0x0074C549
	public global::Vector GetMoveDirectionCache()
	{
		return this.MoveDirectionCache;
	}

	// Token: 0x060195BF RID: 103871 RVA: 0x0074E354 File Offset: 0x0074C554
	public global::Vector GetWorldMoveDirectionCache()
	{
		if (!this.ActorComp.IsAutonomousProxy)
		{
			return this.WorldMoveDirectionCache;
		}
		ControllerBase<CameraController>.Instance.GetCameraRotation(this.TempRotator, "MainCamera");
		Singleton<GravityUtils>.Instance.GetQuatFromRotatorAndGravityForActor(this.ActorComp, this.TempRotator, this.CameraInputQuat);
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp != null && unifiedComp.DirectionState == ECharDirectionState.LockDirection)
		{
			CameraModel instance = ModelBase<CameraModel>.Instance;
			FightCameraLogicComponent fightCameraLogicComponent;
			if (instance == null)
			{
				fightCameraLogicComponent = null;
			}
			else
			{
				FightCamera fightCamera = instance.MainModel.FightCamera;
				fightCameraLogicComponent = ((fightCamera != null) ? fightCamera.LogicComponent : null);
			}
			FightCameraLogicComponent fightCameraLogicComponent2 = fightCameraLogicComponent;
			EntityHandle entityHandle = (fightCameraLogicComponent2 != null) ? fightCameraLogicComponent2.TargetEntity : null;
			if (entityHandle != null)
			{
				this.GetNewQuatInLockMode(entityHandle, fightCameraLogicComponent2.TargetSocketName, this.CameraInputQuat);
			}
		}
		this.CameraInputQuat.RotateVector(this.MoveDirectionCache, this.WorldMoveDirectionCache);
		return this.WorldMoveDirectionCache;
	}

	// Token: 0x060195C0 RID: 103872 RVA: 0x0074E424 File Offset: 0x0074C624
	public void GetMoveVector(global::Vector outVector)
	{
		if (this.AutomaticFlightMode)
		{
			outVector.Reset();
			return;
		}
		outVector.X = (double)this.QueryInputAxis(EInputAxis.MoveForward).GetValueOrDefault();
		outVector.Y = (double)this.QueryInputAxis(EInputAxis.MoveRight).GetValueOrDefault();
		outVector.Z = 0.0;
	}

	// Token: 0x060195C1 RID: 103873 RVA: 0x0074E483 File Offset: 0x0074C683
	public void GetMoveDirection(global::Vector outVector)
	{
		this.GetMoveVector(outVector);
		outVector.Normalize(9.99999993922529E-09);
	}

	// Token: 0x060195C2 RID: 103874 RVA: 0x0074E49C File Offset: 0x0074C69C
	[NullableContext(0)]
	public ValueTuple<float, float> GetCameraInput()
	{
		float num = this.QueryInputAxis(EInputAxis.Turn).GetValueOrDefault();
		float num2 = this.QueryInputAxis(EInputAxis.LookUp).GetValueOrDefault();
		if (num == 0f && num2 == 0f && Singleton<Info>.Instance.IsInGamepad())
		{
			SkillButtonUiGamepadDataBase gamepadData = ModelBase<SkillButtonUiModel>.Instance.GamepadData;
			if (gamepadData != null && gamepadData.ControlCameraByMoveAxis)
			{
				num = gamepadData.GetInputAxis(EInputAxis.MoveRight);
				num2 = -gamepadData.GetInputAxis(EInputAxis.MoveForward);
			}
		}
		return new ValueTuple<float, float>(num, num2);
	}

	// Token: 0x060195C3 RID: 103875 RVA: 0x0074E524 File Offset: 0x0074C724
	public bool HasCameraInput(float tolerance = 0.0001f)
	{
		return !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.QueryInputAxis(EInputAxis.Turn).GetValueOrDefault(), new double?((double)tolerance)) || !Singleton<MathUtils>.Instance.IsNearlyZero((double)this.QueryInputAxis(EInputAxis.LookUp).GetValueOrDefault(), new double?((double)tolerance));
	}

	// Token: 0x060195C4 RID: 103876 RVA: 0x0074E584 File Offset: 0x0074C784
	public float GetZoomInput()
	{
		return this.QueryInputAxis(EInputAxis.Zoom).GetValueOrDefault();
	}

	// Token: 0x060195C5 RID: 103877 RVA: 0x0074E5A4 File Offset: 0x0074C7A4
	public float? QueryInputAxis(EInputAxis axis)
	{
		if (this.AxisValues.ContainsKey(axis))
		{
			return new float?(this.AxisValues[axis]);
		}
		return null;
	}

	// Token: 0x060195C6 RID: 103878 RVA: 0x0074E5DA File Offset: 0x0074C7DA
	public void ClearMoveVectorCache()
	{
		this.MoveVectorCache.Reset();
		this.MoveDirectionCache.Reset();
		this.WorldMoveDirectionCache.Reset();
		this.LastMovementInputTime = -1.0;
	}

	// Token: 0x060195C7 RID: 103879 RVA: 0x0074E60C File Offset: 0x0074C80C
	public void AnimBreakPoint()
	{
		if (this.QueryInputCaches())
		{
			this.ClearInputCaches("AnimBreakPoint");
		}
	}

	// Token: 0x060195C8 RID: 103880 RVA: 0x0074E624 File Offset: 0x0074C824
	public void ClearInputCache(int action, EInputState state)
	{
		if (action == 0)
		{
			this.ClearInputCaches("ClearInputCache");
			return;
		}
		for (int i = this.InputCaches.Count - 1; i >= 0; i--)
		{
			InputCache inputCache = this.InputCaches[i];
			if (inputCache.Action == (CSharpScript.Game.Input.EInputAction)((byte)action) && (inputCache.State == EInputState.None || inputCache.State == state))
			{
				this.InputCaches.RemoveAt(i);
			}
		}
	}

	// Token: 0x060195C9 RID: 103881 RVA: 0x0074E698 File Offset: 0x0074C898
	[NullableContext(2)]
	protected override bool OnInitData(IEntityArgs args = null)
	{
		this.InputGroup = new InputFilter(InputFilterManager.CharacterActions, null, InputFilterManager.CharacterAxes, null);
		this.MoveVectorCache.Reset();
		this.MoveDirectionCache.Reset();
		this.WorldMoveDirectionCache.Reset();
		this.MoveDirectionDistanceMin = (float)ConfigCommonParamById.GetIntConfig("MovementDirectionDistanceMin").Value;
		this.MoveDirectionDistanceMax = (float)ConfigCommonParamById.GetIntConfig("MovementDirectionDistanceMax").Value;
		this.MovementDirectionAngleThreshold = (float)ConfigCommonParamById.GetIntConfig("MovementDirectionAngleThreshold").Value;
		this.TryGetTagDaPathMap();
		return true;
	}

	// Token: 0x060195CA RID: 103882 RVA: 0x0074E730 File Offset: 0x0074C930
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
		TsBaseCharacter actor = this.ActorComp.Actor;
		this.SetCharacter(actor);
		if (this.CharacterControllerInternal != null)
		{
			ControllerBase<InputController>.Instance.AddInputHandler(this);
		}
		this.AbilityComp = base.Entity.GetComponent<CharacterAbilityComponent>();
		this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
		this.StateComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.SkillComponent = base.Entity.GetComponent<CharacterSkillComponent>();
		this.MoveComp = base.Entity.GetComponent<CharacterMoveComponent>();
		this.UnifiedComp = base.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.AddCharacterInputLayer();
		this.AddExtraInputLayer();
		Singleton<EventSystem>.Instance.Add(EEventName.CharAnimBreakPoint, new Action<int>(this.HandleAnimBreakPoint));
		Singleton<EventSystem>.Instance.AddWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharPossessed, new Action<Entity, AController>(this.OnCharPossessed));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharUnpossessed, new Action<Entity, AController>(this.OnCharUnpossessed));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.CameraModeChanged));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewShow));
		Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		Singleton<EventSystem>.Instance.Add(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		this.AddCameraFollowInputListener();
		Singleton<EventSystem>.Instance.AddWithTarget(base.Entity, EEventName.CharOnRoleDrownInjure, new Action<bool>(this.CharOnRoleDrownInjure));
		if (Singleton<Info>.Instance.AxisInputOptimize)
		{
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
		}
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		this.AddBlockEvents();
		InputModel instance = ModelBase<InputModel>.Instance;
		if (instance != null)
		{
			instance.InitInputCommandTransformMap();
		}
		this.InitInputCacheMode();
		return true;
	}

	// Token: 0x060195CB RID: 103883 RVA: 0x0074E9A4 File Offset: 0x0074CBA4
	protected override bool OnEnd()
	{
		this.RemoveCharacterInputLayer();
		this.RemoveExtraInputLayer();
		ControllerBase<InputController>.Instance.RemoveInputHandler(this);
		Singleton<EventSystem>.Instance.Remove(EEventName.CharAnimBreakPoint, new Action<int>(this.HandleAnimBreakPoint));
		Singleton<EventSystem>.Instance.RemoveWithTarget<int, int, bool>(base.Entity, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseSkill));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharPossessed, new Action<Entity, AController>(this.OnCharPossessed));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharUnpossessed, new Action<Entity, AController>(this.OnCharUnpossessed));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnPositionStateChanged, new Action<ECharPositionState, ECharPositionState>(this.OnPositionStateChanged));
		Singleton<EventSystem>.Instance.Remove<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.CameraModeChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OpenView, new Action<EUiViewName, int>(this.OnViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.AutoMovingSettingChanged, new Action<bool>(this.AutoMovingSettingChanged));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRoleDeadTargetSelf, new Action(this.OnRoleDead));
		this.RemoveCameraFollowInputListener();
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Entity, EEventName.CharOnRoleDrownInjure, new Action<bool>(this.CharOnRoleDrownInjure));
		if (Singleton<Info>.Instance.AxisInputOptimize)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		this.LastMovementInputTime = -1.0;
		this.InputEvents.Clear();
		this.InputCaches.Clear();
		this.NeedQueryInputCache = false;
		this.AxisValues.Clear();
		this.RemoveBlockActionEvents();
		this.RemoveMoveAxisToButton();
		return true;
	}

	// Token: 0x060195CC RID: 103884 RVA: 0x0074EBAC File Offset: 0x0074CDAC
	protected override void OnTick(float deltaTime)
	{
		this.AccumulateCacheInputs(deltaTime);
		this.IsLocalInputInternal = false;
		if (this.AutomaticFlightMode)
		{
			this.UpdateCharacterInputDirectAndFacingAutomaticFlightMode(deltaTime);
			this.StandInputDelayCountDown = 0f;
			this.CacheStandInputDirect.Reset();
			return;
		}
		if (this.IsOverShoulderMode)
		{
			this.UpdateCharacterInputDirectAndFacingOverShoulderMode(deltaTime);
			return;
		}
		this.UpdateCharacterInputDirectAndFacing(deltaTime);
		if (this.CameraDrivenAutoFlightMode)
		{
			this.UpdateCharacterInputDirectInCameraDrivenAutoFlightMode(deltaTime);
		}
	}

	// Token: 0x060195CD RID: 103885 RVA: 0x0074EC14 File Offset: 0x0074CE14
	private void AccumulateCacheInputs(float deltaTime)
	{
		if (this.InputCaches.Count == 0)
		{
			return;
		}
		double num = (double)deltaTime * Singleton<TimeUtil>.Instance.Millisecond;
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		float num2 = (instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f;
		double num3 = num * (double)num2;
		for (int i = 0; i < this.InputCaches.Count; i++)
		{
			this.InputCaches[i].AccumulateTime += num3;
		}
	}

	// Token: 0x060195CE RID: 103886 RVA: 0x0074EC88 File Offset: 0x0074CE88
	private void AddBlockEvents()
	{
		this.TagEventJump = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止跳跃"], CSharpScript.Game.Input.EInputAction.跳跃);
		this.TagEventClimb = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攀爬"], CSharpScript.Game.Input.EInputAction.攀爬);
		this.TagEventAttack = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止攻击"], CSharpScript.Game.Input.EInputAction.攻击);
		this.TagEventDodge = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止闪避"], CSharpScript.Game.Input.EInputAction.闪避);
		this.TagEventSkill = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止技能"], CSharpScript.Game.Input.EInputAction.技能1);
		this.TagEventVision1 = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象1"], CSharpScript.Game.Input.EInputAction.幻象1);
		this.TagEventUltimateSkill = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止大招"], CSharpScript.Game.Input.EInputAction.大招);
		this.TagEventVision2 = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止幻象2"], CSharpScript.Game.Input.EInputAction.幻象2);
		this.TagEventChangeRoll1 = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止切换角色1"], CSharpScript.Game.Input.EInputAction.切换角色1);
		this.TagEventChangeRoll2 = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止切换角色2"], CSharpScript.Game.Input.EInputAction.切换角色2);
		this.TagEventChangeRoll3 = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止切换角色3"], CSharpScript.Game.Input.EInputAction.切换角色3);
		this.TagEventLock = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止锁定目标"], CSharpScript.Game.Input.EInputAction.锁定目标);
		this.TagEventAim = this.AddBlockActionEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止瞄准开镜"], CSharpScript.Game.Input.EInputAction.瞄准);
		this.TagEventMove = this.AddBlockAxisEvent(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"], new EInputAxis[]
		{
			EInputAxis.MoveForward,
			EInputAxis.MoveRight
		});
	}

	// Token: 0x060195CF RID: 103887 RVA: 0x0074EE70 File Offset: 0x0074D070
	private ITagTask AddBlockActionEvent(int tagNumber, CSharpScript.Game.Input.EInputAction inputAction)
	{
		return this.TagComp.ListenForTagAddOrRemove(new int?(tagNumber), delegate(int tagId, bool tagExists)
		{
			if (tagExists)
			{
				this.InputGroup.BlockActions.Add(inputAction);
				return;
			}
			this.InputGroup.BlockActions.Remove(inputAction);
		}, null);
	}

	// Token: 0x060195D0 RID: 103888 RVA: 0x0074EEB0 File Offset: 0x0074D0B0
	private ITagTask AddBlockAxisEvent(int tagNumber, EInputAxis[] axes)
	{
		return this.TagComp.ListenForTagAddOrRemove(new int?(tagNumber), delegate(int tagId, bool tagExists)
		{
			foreach (EInputAxis item in axes)
			{
				if (tagExists)
				{
					this.InputGroup.BlockAxes.Add(item);
				}
				else
				{
					this.InputGroup.BlockAxes.Remove(item);
				}
			}
		}, null);
	}

	// Token: 0x060195D1 RID: 103889 RVA: 0x0074EEF0 File Offset: 0x0074D0F0
	private void RemoveBlockActionEvents()
	{
		this.TagEventJump.EndTask();
		this.TagEventClimb.EndTask();
		this.TagEventAttack.EndTask();
		this.TagEventDodge.EndTask();
		this.TagEventSkill.EndTask();
		this.TagEventVision1.EndTask();
		this.TagEventUltimateSkill.EndTask();
		this.TagEventVision2.EndTask();
		this.TagEventChangeRoll1.EndTask();
		this.TagEventChangeRoll2.EndTask();
		this.TagEventChangeRoll3.EndTask();
		this.TagEventLock.EndTask();
		this.TagEventAim.EndTask();
		this.TagEventMove.EndTask();
	}

	// Token: 0x060195D2 RID: 103890 RVA: 0x0074EF98 File Offset: 0x0074D198
	private bool LockInputRotator()
	{
		CharacterMoveComponent moveComp = this.MoveComp;
		byte? b;
		if (moveComp == null)
		{
			b = null;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			b = ((characterMovement != null) ? new byte?(characterMovement.CustomMovementMode) : null);
		}
		byte? b2 = b;
		if (((b2 != null) ? new int?((int)b2.GetValueOrDefault()) : null).GetValueOrDefault() != 6)
		{
			return false;
		}
		CharacterCatapultComponent component = base.Entity.GetComponent<CharacterCatapultComponent>();
		return component != null && component.LockRotator;
	}

	// Token: 0x060195D3 RID: 103891 RVA: 0x0074F01C File Offset: 0x0074D21C
	private void UpdateCharacterInputDirectAndFacing(float delta)
	{
		global::Vector vector = global::Vector.ZeroVectorProxy;
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.Valid || !this.StateComp.Valid)
		{
			vector = this.GetWorldMoveDirectionCache();
			this.ActorComp.SetInputDirect(vector, true);
			this.SetInputFacingFromInputDirect(true);
			return;
		}
		if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]))
		{
			vector = this.GetWorldMoveDirectionCache();
			if (vector.IsNearlyZero(9.999999747378752E-05) && (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为改变.保持输入"]) || this.AutoMovingConfig.GetAutoMovingState()))
			{
				vector = this.ActorComp.InputDirectProxy;
				if (vector.IsNearlyZero(9.999999747378752E-05))
				{
					vector = this.ActorComp.ActorForwardProxy;
				}
			}
			this.ActorComp.SetInputDirect(vector, true);
			if (this.LockInputRotator())
			{
				this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
				return;
			}
			this.SetInputFacingFromInputDirect(true);
			return;
		}
		else
		{
			CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
			if (unifiedComp != null && unifiedComp.PositionState == ECharPositionState.Climb)
			{
				this.IsLocalInputInternal = true;
				vector = this.GetMoveDirectionCache();
				this.UpdateAutoMovingCheck(vector, delta);
				if (this.AutoMovingConfig.GetAutoMovingState())
				{
					vector = global::Vector.ForwardVectorProxy;
				}
			}
			else
			{
				CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
				if (unifiedComp2 != null && unifiedComp2.MoveState == ECharMoveState.Soar)
				{
					this.IsLocalInputInternal = true;
					this.TempVector.DeepCopy(this.GetMoveVectorCache());
					int? currentValue = Singleton<GameSettingsManager>.Instance.GetCurrentValue(EFunction.FlyControlMode, true, true);
					int num = 0;
					if (currentValue.GetValueOrDefault() == num & currentValue != null)
					{
						this.TempVector.X = -this.TempVector.X;
					}
					double num2 = vector.SizeSquared();
					if (num2 > 1.0)
					{
						this.TempVector.DivisionEqual(Math.Sqrt(num2));
					}
					vector = this.TempVector;
					this.InterruptAutoMoving("翱翔状态", true);
				}
				else
				{
					vector = this.GetWorldMoveDirectionCache();
					this.UpdateAutoMovingCheck(vector, delta);
					bool autoMovingState = this.AutoMovingConfig.GetAutoMovingState();
					if (vector.IsNearlyZero(9.999999747378752E-05) && (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为改变.保持输入"]) || autoMovingState))
					{
						vector = this.ActorComp.InputDirectProxy;
						if (vector.IsNearlyZero(9.999999747378752E-05))
						{
							vector = this.ActorComp.ActorForwardProxy;
						}
						if (autoMovingState)
						{
							this.CalculateMoveDirection(this.TempVector2);
							if (!this.TempVector2.IsNearlyZero(9.999999747378752E-05))
							{
								this.TempVector2.Normalize(9.99999993922529E-09);
								vector.DeepCopy(this.TempVector2);
							}
						}
					}
					if (!vector.IsNearlyZero(9.999999747378752E-05))
					{
						if (!ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
						{
							if (autoMovingState)
							{
								goto IL_30B;
							}
							BattleUiFormationData formationData = ModelBase<BattleUiModel>.Instance.FormationData;
							if (formationData != null && formationData.AutoSprintSettingEnable)
							{
								goto IL_30B;
							}
						}
						if (!this.CheckAutoSprintTag())
						{
							goto IL_316;
						}
						IL_30B:
						this.UpdateAutoSprint(autoMovingState, delta);
						goto IL_321;
					}
					IL_316:
					this.AutoSprintTime = 0f;
				}
			}
			IL_321:
			this.CacheStandInputDirect.Reset();
			this.ActorComp.SetInputDirect(vector, !this.IsLocalInputInternal);
			if (this.ActorComp.UseControllerRotation)
			{
				this.ActorComp.SetInputFacing(this.ActorComp.Actor.Controller.GetActorForwardVector(), true);
				return;
			}
			ECharPositionState positionState = this.StateComp.PositionState;
			switch (positionState)
			{
			case ECharPositionState.Ground:
				this.SetInputFacingOnGround();
				return;
			case ECharPositionState.Climb:
				break;
			case ECharPositionState.Air:
				if (this.StateComp.MoveState == ECharMoveState.WalkOnAir)
				{
					this.SetInputFacingOnGround();
					return;
				}
				this.SetInputFacingFromInputDirect(true);
				return;
			case ECharPositionState.Water:
				this.SetInputFacingFromInputDirect(true);
				return;
			default:
				if (positionState != ECharPositionState.Floating)
				{
					return;
				}
				this.SetInputFacingOnGround();
				break;
			}
			return;
		}
	}

	// Token: 0x060195D4 RID: 103892 RVA: 0x0074F400 File Offset: 0x0074D600
	public bool CheckAutoSprintTag()
	{
		BaseTagComponent tagComp = this.TagComp;
		return tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.自动进入疾跑"]);
	}

	// Token: 0x060195D5 RID: 103893 RVA: 0x0074F422 File Offset: 0x0074D622
	public bool CheckAutoSprintTagImmediately()
	{
		BaseTagComponent tagComp = this.TagComp;
		return tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["功能.功能制作.自动进入疾跑.瞬间起步"]);
	}

	// Token: 0x060195D6 RID: 103894 RVA: 0x0074F444 File Offset: 0x0074D644
	private void UpdateCharacterInputDirectAndFacingAutomaticFlightMode(float deltaTime)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.Valid)
		{
			CharacterAbilityComponent abilityComp = this.AbilityComp;
			if (abilityComp != null && abilityComp.Valid)
			{
				if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.输入限制.禁止移动"]))
				{
					return;
				}
				if (this.StateComp.PositionState != ECharPositionState.Air)
				{
					Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.CJH, "错误的位置状态", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (this.AutomaticFlightDataAsset == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.CJH, "自动飞行模式配置无效", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				if (this.AutomaticFlightDataAsset != null)
				{
					float? num = this.QueryInputAxis(EInputAxis.MoveForward);
					float? num2 = num;
					float? num3 = this.AutomaticFlightDataAsset.ForwardAxisResponseValue;
					if (num2.GetValueOrDefault() > num3.GetValueOrDefault() & (num2 != null & num3 != null))
					{
						this.AutomaticFlightDataAsset.CurrentState = EAutomaticFlightState.Max;
						this.AutomaticFlightDataAsset.LastFlySpeed = this.AutomaticFlightDataAsset.TargetFlySpeed;
						this.AutomaticFlightDataAsset.TargetFlySpeed = this.AutomaticFlightDataAsset.MaxFlySpeed;
						this.MoveComp.SetMaxSpeed(this.AutomaticFlightDataAsset.MaxFlySpeed.Value);
						int? num4 = this.AutomaticFlightDataAsset.ForwardSkill;
						int num5 = 0;
						if ((num4.GetValueOrDefault() > num5 & num4 != null) && this.SkillComponent.BeginSkill(this.AutomaticFlightDataAsset.ForwardSkill.Value, new SkillParam
						{
							Target = base.Entity,
							Reason = "EAutomaticFlightState.Max"
						}))
						{
							this.AutomaticFlightDataAsset.CurrentSkill = this.AutomaticFlightDataAsset.ForwardSkill;
						}
					}
					else
					{
						num3 = num;
						num2 = this.AutomaticFlightDataAsset.BackwardAxisResponseValue;
						if (num3.GetValueOrDefault() < num2.GetValueOrDefault() & (num3 != null & num2 != null))
						{
							this.AutomaticFlightDataAsset.CurrentState = EAutomaticFlightState.Min;
							this.AutomaticFlightDataAsset.LastFlySpeed = this.AutomaticFlightDataAsset.TargetFlySpeed;
							this.AutomaticFlightDataAsset.TargetFlySpeed = this.AutomaticFlightDataAsset.MinFlySpeed;
							this.MoveComp.SetMaxSpeed(this.AutomaticFlightDataAsset.MinFlySpeed.Value);
							int? num4 = this.AutomaticFlightDataAsset.BackwardSkill;
							int num5 = 0;
							if ((num4.GetValueOrDefault() > num5 & num4 != null) && this.SkillComponent.BeginSkill(this.AutomaticFlightDataAsset.BackwardSkill.Value, new SkillParam
							{
								Target = base.Entity,
								Reason = "EAutomaticFlightState.Min"
							}))
							{
								this.AutomaticFlightDataAsset.CurrentSkill = this.AutomaticFlightDataAsset.BackwardSkill;
							}
						}
						else
						{
							this.AutomaticFlightDataAsset.CurrentState = EAutomaticFlightState.Normal;
							this.AutomaticFlightDataAsset.LastFlySpeed = this.AutomaticFlightDataAsset.TargetFlySpeed;
							this.AutomaticFlightDataAsset.TargetFlySpeed = this.AutomaticFlightDataAsset.NormalFlySpeed;
							this.MoveComp.SetMaxSpeed(this.AutomaticFlightDataAsset.NormalFlySpeed.Value);
							if (this.AutomaticFlightDataAsset.CurrentSkill != null)
							{
								this.SkillComponent.EndSkill(this.AutomaticFlightDataAsset.CurrentSkill.Value, "EAutomaticFlightState.Normal");
								this.AutomaticFlightDataAsset.CurrentSkill = null;
							}
						}
					}
				}
				if (this.AutomaticFlightDataAsset.LastState != this.AutomaticFlightDataAsset.CurrentState)
				{
					this.AutomaticFlightModeTimeCache = 0f;
				}
				this.AutomaticFlightDataAsset.LastState = this.AutomaticFlightDataAsset.CurrentState;
				this.AutomaticFlightModeTimeCache += deltaTime * 0.001f;
				float x = this.AutomaticFlightDataAsset.SpeedTransitionCurve.GetVectorValue(this.AutomaticFlightModeTimeCache).X;
				this.AutomaticFlightDataAsset.FlySpeed = new float?(Singleton<MathUtils>.Instance.Lerp(this.AutomaticFlightDataAsset.LastFlySpeed.Value, this.AutomaticFlightDataAsset.TargetFlySpeed.Value, x));
				this.ActorComp.ActorForwardProxy.Multiply((double)this.AutomaticFlightDataAsset.FlySpeed.Value, this.TempVector);
				this.MoveComp.SetForceSpeed(this.TempVector);
				return;
			}
		}
	}

	// Token: 0x060195D7 RID: 103895 RVA: 0x0074F884 File Offset: 0x0074DA84
	private void UpdateCharacterInputDirectInCameraDrivenAutoFlightMode(float deltaTime)
	{
		this.IsInCameraDrivenAutoFlight = false;
		if (this.CameraDrivenAutoFlightDataAsset == null)
		{
			return;
		}
		if (!this.ActorComp.InputDirectProxy.IsNearlyZero(0.0001))
		{
			this.CameraDrivenAutoFlightTime = 0f;
			this.IsStartCameraDrivenAutoFlightTick = false;
			return;
		}
		float valueOrDefault = this.QueryInputAxis(EInputAxis.Turn).GetValueOrDefault();
		if (!Singleton<MathUtils>.Instance.IsNearlyZero((double)valueOrDefault, new double?((double)this.CameraDrivenAutoFlightDataAsset.AutoFlightStartAngleTolerance)) && !this.IsStartCameraDrivenAutoFlightTick)
		{
			this.IsStartCameraDrivenAutoFlightTick = true;
		}
		if (!this.IsStartCameraDrivenAutoFlightTick)
		{
			return;
		}
		float yawInGravity = CameraUtility.GetYawInGravity(this.ActorComp.ActorRotationProxy);
		float yawInGravity2 = CameraUtility.GetYawInGravity(ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.DesiredCamera.ArmRotation);
		float num = Singleton<MathUtils>.Instance.WrapAngle(yawInGravity - yawInGravity2);
		if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, new double?((double)this.CameraDrivenAutoFlightDataAsset.AutoFlightFinishAngleTolerance)))
		{
			this.CameraDrivenAutoFlightTime = 0f;
			this.IsStartCameraDrivenAutoFlightTick = false;
			return;
		}
		this.CameraDrivenAutoFlightTime += deltaTime;
		if (this.CameraDrivenAutoFlightTime < this.CameraDrivenAutoFlightDataAsset.AutoFlightEnableTime)
		{
			return;
		}
		this.IsInCameraDrivenAutoFlight = true;
		float num2 = Singleton<MathUtils>.Instance.RangeClamp(Math.Abs(num), this.CameraDrivenAutoFlightDataAsset.AutoFlightInputAngleMin, this.CameraDrivenAutoFlightDataAsset.AutoFlightInputAngleMax, this.CameraDrivenAutoFlightDataAsset.AutoFlightInputMin, this.CameraDrivenAutoFlightDataAsset.AutoFlightInputMax);
		this.ActorComp.SetInputDirectByNumber(this.ActorComp.InputDirectProxy.X, (double)(num2 * (float)((num > 0f) ? -1 : 1)), 0.0);
	}

	// Token: 0x060195D8 RID: 103896 RVA: 0x0074FA2C File Offset: 0x0074DC2C
	private void SetInputFacingOnGround()
	{
		if (this.StateComp.DirectionState != ECharDirectionState.LockDirection)
		{
			this.SetInputFacingFromInputDirect(false);
			return;
		}
		FightCameraLogicComponent component = ControllerBase<CameraController>.Instance.MainModel.FightCamera.GetComponent<FightCameraLogicComponent>();
		if (this.StateComp.MoveState == ECharMoveState.Sprint || ((component != null) ? component.TargetEntity : null) == null || !component.IsTargetLocationValid || this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.不受锁定面向旋转"]))
		{
			this.SetInputFacingFromInputDirect(false);
			return;
		}
		component.TargetLocation.Subtraction(this.ActorComp.ActorLocationProxy, this.TempVector);
		if (this.UnifiedComp == null || this.UnifiedComp.MoveState != ECharMoveState.Stand)
		{
			this.ActorComp.SetInputFacing(this.TempVector, true);
			return;
		}
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityAbsForActor(this.ActorComp, this.ActorComp.ActorForwardProxy, this.TempVector) > 60f)
		{
			this.ActorComp.SetInputFacing(this.TempVector, true);
			return;
		}
		this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, true);
	}

	// Token: 0x060195D9 RID: 103897 RVA: 0x0074FB64 File Offset: 0x0074DD64
	private void SetInputFacingFromInputDirect(bool clearWhenNoInput = true)
	{
		if (this.InCameraFollowInput)
		{
			this.CameraFollowInputCompensate();
			return;
		}
		if (this.IsLocalInputInternal)
		{
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, clearWhenNoInput);
			return;
		}
		if (Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.ActorComp.InputDirectProxy) > 1E-08)
		{
			this.ActorComp.SetInputFacing(this.ActorComp.InputDirectProxy, clearWhenNoInput);
			return;
		}
		if (clearWhenNoInput)
		{
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, clearWhenNoInput);
		}
	}

	// Token: 0x060195DA RID: 103898 RVA: 0x0074FC08 File Offset: 0x0074DE08
	private bool ShouldTriggerHoldEvent(CSharpScript.Game.Input.EInputAction action, double holdTime, float deltaTime)
	{
		ValueTuple<bool, float> holdConfig = this.GetHoldConfig(action);
		bool item = holdConfig.Item1;
		float item2 = holdConfig.Item2;
		if (item2 == -1f)
		{
			return false;
		}
		if (holdTime < (double)item2)
		{
			return false;
		}
		if (item)
		{
			return true;
		}
		if (CharacterInputComponent.HoldPressMap.ContainsKey(action) && CharacterInputComponent.HoldPressMap[action])
		{
			return false;
		}
		CharacterModel instance = ModelBase<CharacterModel>.Instance;
		float num = (instance != null) ? instance.InverseSelfCenteredTimeDilation : 1f;
		float num2 = deltaTime * num;
		return holdTime - (double)num2 > (double)item2;
	}

	// Token: 0x060195DB RID: 103899 RVA: 0x0074FC80 File Offset: 0x0074DE80
	private void UpdateMoveCache()
	{
		this.GetMoveVector(this.MoveVectorCache);
		if (!this.IsSmallInput(this.MoveVectorCache))
		{
			this.MoveDirectionCache.DeepCopy(this.MoveVectorCache);
			this.MoveDirectionCache.Normalize(9.99999993922529E-09);
			this.LastMovementInputTime = Singleton<Time>.Instance.SystemNow;
			return;
		}
		if (Singleton<Time>.Instance.SystemNow - this.LastMovementInputTime > 100.0)
		{
			this.MoveDirectionCache.DeepCopy(this.MoveVectorCache);
			this.MoveDirectionCache.Normalize(9.99999993922529E-09);
			this.LastMovementInputTime = -1.0;
		}
	}

	// Token: 0x060195DC RID: 103900 RVA: 0x0074FD2F File Offset: 0x0074DF2F
	public void OnBpInputCompChanged()
	{
		this.InitMoveAxisToButton();
	}

	// Token: 0x060195DD RID: 103901 RVA: 0x0074FD38 File Offset: 0x0074DF38
	private void InitMoveAxisToButton()
	{
		BP_InputBase_C bpInputComp = this.GetBpInputComp();
		if (bpInputComp == null)
		{
			return;
		}
		if (!this.MoveAxisToButtonLogic.IsInited())
		{
			this.MoveAxisToButtonLogic.Init(this.InputEvents);
		}
		if (this.MoveAxisToButtonActiveCondition == null)
		{
			this.MoveAxisToButtonActiveCondition = new InputActiveCondition(this.TagComp, base.Entity.GetComponent<BaseAttributeComponent>(), new InputActiveResultCallback(this.OnEnableMoveAxisToButton));
		}
		SInputActive 激活移动输入映射按键事件 = bpInputComp.激活移动输入映射按键事件;
		bool flag;
		if (激活移动输入映射按键事件 == null)
		{
			flag = false;
		}
		else
		{
			TArray<SInputActiveCondition> inputActiveConditionGroup = 激活移动输入映射按键事件.InputActiveConditionGroup;
			int? num = (inputActiveConditionGroup != null) ? new int?(inputActiveConditionGroup.Num()) : null;
			int num2 = 0;
			flag = (num.GetValueOrDefault() > num2 & num != null);
		}
		if (flag)
		{
			this.MoveAxisToButtonActiveCondition.SetActiveCondition(bpInputComp.激活移动输入映射按键事件);
			return;
		}
		this.MoveAxisToButtonActiveCondition.SetActiveCondition(null);
		this.IsMoveAxisToButtonEnabled = false;
	}

	// Token: 0x060195DE RID: 103902 RVA: 0x0074FE05 File Offset: 0x0074E005
	private void RemoveMoveAxisToButton()
	{
		if (this.MoveAxisToButtonActiveCondition != null)
		{
			this.MoveAxisToButtonActiveCondition.Clear();
			this.MoveAxisToButtonActiveCondition = null;
		}
	}

	// Token: 0x060195DF RID: 103903 RVA: 0x0074FE21 File Offset: 0x0074E021
	public void OnEnableMoveAxisToButton(bool enable)
	{
		this.IsMoveAxisToButtonEnabled = enable;
	}

	// Token: 0x060195E0 RID: 103904 RVA: 0x0074FE2A File Offset: 0x0074E02A
	private void UpdateMoveAxisToButton()
	{
		if (this.IsMoveAxisToButtonEnabled)
		{
			this.MoveAxisToButtonLogic.TestEmitWithAxis(this.AxisValues);
		}
	}

	// Token: 0x060195E1 RID: 103905 RVA: 0x0074FE48 File Offset: 0x0074E048
	protected void GetNewQuatInLockMode(EntityHandle targetEntity, FName? targetSocketName, Quat inOutQuat)
	{
		CameraUtility.GetSocketLocation(null, targetSocketName, this.TempVector, targetEntity);
		this.TempVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		double planarSizeSquared2dForActor = Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(this.ActorComp, this.TempVector);
		if (planarSizeSquared2dForActor < (double)(this.MoveDirectionDistanceMin * this.MoveDirectionDistanceMin))
		{
			return;
		}
		inOutQuat.Inverse(this.TempQuat);
		this.TempQuat.RotateVector(this.TempVector, this.TempVector);
		double num = this.TempVector.HeadingAngle() * 57.295780181884766;
		if (Math.Abs(num) > (double)this.MovementDirectionAngleThreshold)
		{
			return;
		}
		float inYaw = (float)Singleton<MathUtils>.Instance.RangeClamp(Math.Sqrt(planarSizeSquared2dForActor), (double)this.MoveDirectionDistanceMin, (double)this.MoveDirectionDistanceMax, 0.0, num);
		this.TempRotator.Set(0f, inYaw, 0f);
		this.TempRotator.Quaternion(this.TempQuat);
		inOutQuat.Multiply(this.TempQuat, this.TempQuat2);
		inOutQuat.DeepCopy(this.TempQuat2);
	}

	// Token: 0x060195E2 RID: 103906 RVA: 0x0074FF5C File Offset: 0x0074E15C
	private bool IsSmallInput(global::Vector moveVector)
	{
		if (Singleton<Info>.Instance.IsInKeyBoard())
		{
			return moveVector.IsNearlyZero(1E-08);
		}
		return moveVector.SizeSquared() <= Singleton<MathUtils>.Instance.Square((double)RoleGaitStatic.GetWalkOrRunRate());
	}

	// Token: 0x060195E3 RID: 103907 RVA: 0x0074FF98 File Offset: 0x0074E198
	private void ValidateInputCaches()
	{
		for (int i = this.InputCaches.Count - 1; i >= 0; i--)
		{
			InputCache inputCache = this.InputCaches[i];
			float cacheTime = this.GetCacheTime(inputCache.Action, inputCache.State);
			if (inputCache.AccumulateTime > (double)cacheTime)
			{
				this.InputCaches.RemoveAt(i);
			}
		}
	}

	// Token: 0x060195E4 RID: 103908 RVA: 0x0074FFF3 File Offset: 0x0074E1F3
	[NullableContext(2)]
	private void ClearInputCaches(string reason = null)
	{
		this.InputCaches.Clear();
	}

	// Token: 0x060195E5 RID: 103909 RVA: 0x00750000 File Offset: 0x0074E200
	private bool QueryInputCaches()
	{
		if (this.InputCaches.Count == 0)
		{
			return false;
		}
		if (this.InputCacheExecuteMode == EInputCacheExecuteMode.Delay)
		{
			this.NeedQueryInputCache = true;
			return false;
		}
		List<InputCommand> list = new List<InputCommand>();
		for (int i = 0; i < this.InputCaches.Count; i++)
		{
			InputCache inputCache = this.InputCaches[i];
			SInputCommand sinputCommand = null;
			switch (inputCache.State)
			{
			case EInputState.Press:
				sinputCommand = this.HandlePress(inputCache.Action, inputCache.Time, inputCache.Param);
				break;
			case EInputState.Release:
				sinputCommand = this.HandleRelease(inputCache.Action, (double)inputCache.Time, inputCache.Param);
				break;
			case EInputState.Hold:
				sinputCommand = this.HandleHold(inputCache.Action, (double)inputCache.Time, inputCache.Param);
				break;
			}
			if (sinputCommand != null && sinputCommand.CommandType != ECommandType.None)
			{
				list.Add(new InputCommand(inputCache.Action, inputCache.State, inputCache.Time, sinputCommand, i));
			}
		}
		InputCommand bestInputCommand = this.GetBestInputCommand(list);
		if (bestInputCommand == null)
		{
			return false;
		}
		if (bestInputCommand != null && bestInputCommand.State == EInputState.Hold)
		{
			CharacterInputComponent.HoldPressMap[bestInputCommand.Action] = true;
		}
		this.ExecuteInputCommand(bestInputCommand, "QueryInputCaches");
		return true;
	}

	// Token: 0x060195E6 RID: 103910 RVA: 0x00750147 File Offset: 0x0074E347
	private void HandleAnimBreakPoint(int entityId)
	{
		if (this.CharacterInternal == null || this.CharacterInternal.GetEntityIdNoBlueprint() != entityId)
		{
			return;
		}
		if (this.QueryInputCaches())
		{
			this.ClearInputCaches("HandleAnimBreakPoint");
		}
	}

	// Token: 0x060195E7 RID: 103911 RVA: 0x00750174 File Offset: 0x0074E374
	[return: Nullable(2)]
	private InputCommand GetBestInputCommand(List<InputCommand> commands)
	{
		if (commands.Count == 0)
		{
			return null;
		}
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < commands.Count; i++)
		{
			InputCommand inputCommand = commands[i];
			int num3 = this.QueryInputPriority(inputCommand.Command);
			if (num3 > num)
			{
				num = num3;
				num2 = i;
			}
		}
		if (num2 == -1)
		{
			return null;
		}
		return commands[num2];
	}

	// Token: 0x060195E8 RID: 103912 RVA: 0x007501D0 File Offset: 0x0074E3D0
	private int QueryInputPriority(SInputCommand command)
	{
		int? num = null;
		ECommandType ecommandType = command.CommandType;
		if (ecommandType != ECommandType.None)
		{
			if (ecommandType == ECommandType.Skill)
			{
				num = new int?(this.QuerySkillPriority(command.IntValue));
			}
			else
			{
				num = ControllerBase<InputController>.Instance.QueryCommandPriority(command.CommandType);
			}
		}
		if (num == null)
		{
			num = new int?(-1);
		}
		return num.Value;
	}

	// Token: 0x060195E9 RID: 103913 RVA: 0x0075023B File Offset: 0x0074E43B
	private int QuerySkillPriority(int skillId)
	{
		TsBaseCharacter characterInternal = this.CharacterInternal;
		BaseSkillComponent baseSkillComponent;
		if (characterInternal == null)
		{
			baseSkillComponent = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = characterInternal.CharacterActorComponent;
			if (characterActorComponent == null)
			{
				baseSkillComponent = null;
			}
			else
			{
				Entity entity = characterActorComponent.Entity;
				baseSkillComponent = ((entity != null) ? entity.GetComponent<CharacterSkillComponent>() : null);
			}
		}
		return baseSkillComponent.GetPriority(skillId);
	}

	// Token: 0x060195EA RID: 103914 RVA: 0x00750270 File Offset: 0x0074E470
	private void ExecuteInputCommand(InputCommand inputCommand, string context)
	{
		SInputCommand command = inputCommand.Command;
		ECommandType key = command.CommandType;
		switch (key)
		{
		case ECommandType.Skill:
			if (Singleton<Info>.Instance.IsInGamepad() && inputCommand.Action == CSharpScript.Game.Input.EInputAction.攻击 && inputCommand.State == EInputState.Release && this.GetCommandInterval(ECommandType.Climb) < 0.25f)
			{
				this.RemoveCommandInterval(ECommandType.Climb);
				return;
			}
			this.ExecuteSkill(command.IntValue, context);
			return;
		case ECommandType.Jump:
			this.ExecuteJump(command);
			return;
		case ECommandType.Climb:
			this.ExecuteClimb(command);
			this.CommandTimeMap[key] = Singleton<Time>.Instance.WorldTimeSeconds;
			return;
		case ECommandType.Sprint:
			this.ExecuteSprint(command);
			return;
		case ECommandType.FastSwim:
			this.ExecuteFastSwim(command);
			return;
		case ECommandType.FastClimb:
			this.ExecuteFastClimb(command);
			return;
		case ECommandType.SwitchCharacter:
			this.ExecuteSwitchCharacter(command.IntValue);
			return;
		case ECommandType.SwitchWalk:
			this.ExecuteSwitchWalk(command);
			return;
		case ECommandType.SendGameplayEvent:
			this.AbilityComp.SendGameplayEventToActor(command.TagValue, null);
			return;
		case ECommandType.XaBoost:
			this.ExecuteXaBoost(command);
			return;
		case ECommandType.Swallow:
			break;
		case ECommandType.Drop:
			this.ExecuteDrop(command);
			break;
		default:
			return;
		}
	}

	// Token: 0x060195EB RID: 103915 RVA: 0x0075038C File Offset: 0x0074E58C
	private void ExecuteJump(SInputCommand command)
	{
		CharacterMoveComponent component = base.Entity.GetComponent<CharacterMoveComponent>();
		if (!component.Valid)
		{
			return;
		}
		if (command.IntValue == 1)
		{
			component.JumpPress();
			return;
		}
		component.JumpRelease();
	}

	// Token: 0x060195EC RID: 103916 RVA: 0x007503C4 File Offset: 0x0074E5C4
	private void ExecuteClimb(SInputCommand command)
	{
		CharacterClimbComponent component = base.Entity.GetComponent<CharacterClimbComponent>();
		if (component == null)
		{
			return;
		}
		component.ClimbPress(command.IntValue == 1);
	}

	// Token: 0x060195ED RID: 103917 RVA: 0x007503E4 File Offset: 0x0074E5E4
	private void ExecuteSprint(SInputCommand command)
	{
		if (command.IntValue == 1)
		{
			base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SprintPress();
			return;
		}
		base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SprintRelease();
	}

	// Token: 0x060195EE RID: 103918 RVA: 0x00750410 File Offset: 0x0074E610
	private void ExecuteFastSwim(SInputCommand command)
	{
		base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SwitchFastSwim(command.IntValue == 1);
	}

	// Token: 0x060195EF RID: 103919 RVA: 0x0075042B File Offset: 0x0074E62B
	private void ExecuteFastClimb(SInputCommand command)
	{
		base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().SwitchFastClimb(command.IntValue == 1, false);
	}

	// Token: 0x060195F0 RID: 103920 RVA: 0x00750447 File Offset: 0x0074E647
	private void ExecuteSwitchWalk(SInputCommand command)
	{
		base.Entity.CheckGetComponent<CharacterUnifiedStateComponent>().WalkPress();
	}

	// Token: 0x060195F1 RID: 103921 RVA: 0x00750459 File Offset: 0x0074E659
	private void ExecuteXaBoost(SInputCommand command)
	{
		CharacterGlideComponent characterGlideComponent = base.Entity.CheckGetComponent<CharacterGlideComponent>();
		if (characterGlideComponent == null)
		{
			return;
		}
		characterGlideComponent.SetSoarBoostOn(command.IntValue > 0);
	}

	// Token: 0x060195F2 RID: 103922 RVA: 0x00750479 File Offset: 0x0074E679
	private void ExecuteDrop(SInputCommand command)
	{
		if (!this.MoveComp)
		{
			return;
		}
		if (command.IntValue == 1)
		{
			this.MoveComp.OnDropPress();
			return;
		}
		this.MoveComp.OnDropRelease();
	}

	// Token: 0x060195F3 RID: 103923 RVA: 0x007504A9 File Offset: 0x0074E6A9
	private void ExecuteSwitchCharacter(int index)
	{
	}

	// Token: 0x060195F4 RID: 103924 RVA: 0x007504AB File Offset: 0x0074E6AB
	private void ExecuteSkill(int skillId, string context)
	{
		base.Entity.GetComponent<CharacterSkillComponent>().BeginSkillAsync(skillId, new SkillParam
		{
			Reason = "CharacterInputComponent.ExecuteSkill." + context
		}).Forget<bool>();
	}

	// Token: 0x060195F5 RID: 103925 RVA: 0x007504D9 File Offset: 0x0074E6D9
	private float GetWorldTime()
	{
		return UGameplayStatics.GetTimeSeconds(GlobalData.World);
	}

	// Token: 0x060195F6 RID: 103926 RVA: 0x007504E8 File Offset: 0x0074E6E8
	public void SetActive(bool value)
	{
		if (value)
		{
			if (this.DisableHandle != null)
			{
				base.Enable(new int?(this.DisableHandle.Value), "[CharacterInputComponent.SetActive] this.DisableHandle=true");
				this.DisableHandle = null;
			}
		}
		else if (this.DisableHandle == null)
		{
			this.DisableHandle = new int?(base.Disable("[CharacterInputComponent.SetActive] this.DisableHandle=false"));
		}
		this.MoveAxisToButtonLogic.Reset();
	}

	// Token: 0x060195F7 RID: 103927 RVA: 0x00750560 File Offset: 0x0074E760
	private void DispatchPressEvent(CSharpScript.Game.Input.EInputAction action, double time, float param = 0f)
	{
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.LCZ, "Entity Is End", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<InputLayer> inputLayers = ControllerBase<InputController>.Instance.GetInputLayers(base.Entity.Id);
		if (inputLayers == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterInputComponent.DispatchPressEvent]输入层级为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		for (int i = 0; i < inputLayers.Count; i++)
		{
			inputLayers[i].DispatchPressEventEx(action, (float)time, param);
		}
	}

	// Token: 0x060195F8 RID: 103928 RVA: 0x00750604 File Offset: 0x0074E804
	private void DispatchReleaseEvent(CSharpScript.Game.Input.EInputAction action, double time, float param = 0f)
	{
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.LCZ, "Entity Is End", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		List<InputLayer> inputLayers = ControllerBase<InputController>.Instance.GetInputLayers(base.Entity.Id);
		if (inputLayers == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterInputComponent.DispatchReleaseEvent]输入层级为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		for (int i = 0; i < inputLayers.Count; i++)
		{
			inputLayers[i].DispatchReleaseEventEx(action, (float)time, param);
		}
	}

	// Token: 0x060195F9 RID: 103929 RVA: 0x007506A8 File Offset: 0x0074E8A8
	[NullableContext(2)]
	private SInputCommand HandlePress(CSharpScript.Game.Input.EInputAction action, float time, float param = 0f)
	{
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.LCZ, "Entity Is End", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		List<InputLayer> inputLayers = ControllerBase<InputController>.Instance.GetInputLayers(base.Entity.Id);
		if (inputLayers == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterInputComponent.HandlePress]输入层级为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		for (int i = 0; i < inputLayers.Count; i++)
		{
			SInputCommand sinputCommand = inputLayers[i].HandlePressEx(action, time, param);
			if (sinputCommand != null && sinputCommand.CommandType != ECommandType.None)
			{
				return sinputCommand;
			}
		}
		return null;
	}

	// Token: 0x060195FA RID: 103930 RVA: 0x00750770 File Offset: 0x0074E970
	[NullableContext(2)]
	private SInputCommand HandleRelease(CSharpScript.Game.Input.EInputAction action, double time, float param = 0f)
	{
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.LCZ, "Entity Is End", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		List<InputLayer> inputLayers = ControllerBase<InputController>.Instance.GetInputLayers(base.Entity.Id);
		if (inputLayers == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterInputComponent.HandleRelease]输入层级为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		for (int i = 0; i < inputLayers.Count; i++)
		{
			SInputCommand sinputCommand = inputLayers[i].HandleReleaseEx(action, (float)time, param);
			if (sinputCommand != null && sinputCommand.CommandType != ECommandType.None)
			{
				return sinputCommand;
			}
		}
		return null;
	}

	// Token: 0x060195FB RID: 103931 RVA: 0x00750838 File Offset: 0x0074EA38
	[NullableContext(2)]
	private SInputCommand HandleHold(CSharpScript.Game.Input.EInputAction action, double time, float param = 0f)
	{
		if (this.ActorComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.LCZ, "Entity Is End", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		List<InputLayer> inputLayers = ControllerBase<InputController>.Instance.GetInputLayers(base.Entity.Id);
		if (inputLayers == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Input;
			ELogAuthor author = ELogAuthor.WWJ;
			string message = "[CharacterInputComponent.HandleHold]输入层级为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", base.Entity.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		for (int i = 0; i < inputLayers.Count; i++)
		{
			SInputCommand sinputCommand = inputLayers[i].HandleHoldEx(action, (float)time, param);
			if (sinputCommand != null && sinputCommand.CommandType != ECommandType.None)
			{
				return sinputCommand;
			}
		}
		return null;
	}

	// Token: 0x060195FC RID: 103932 RVA: 0x00750900 File Offset: 0x0074EB00
	private float GetCacheTime(CSharpScript.Game.Input.EInputAction action, EInputState state)
	{
		BP_InputBase_C bpInputComp = this.GetBpInputComp();
		if (bpInputComp == null)
		{
			return 0f;
		}
		SInputCaches? sinputCaches = null;
		if (!this.CacheTimes.ContainsKey(action))
		{
			sinputCaches = new SInputCaches?(bpInputComp.GetUnrealCacheConfig((int)action));
			this.CacheTimes[action] = sinputCaches.Value;
		}
		if (sinputCaches == null && this.CacheTimes.ContainsKey(action))
		{
			sinputCaches = new SInputCaches?(this.CacheTimes[action]);
		}
		if (sinputCaches == null)
		{
			return 0f;
		}
		switch (state)
		{
		case EInputState.Press:
			return sinputCaches.Value.按下;
		case EInputState.Release:
			return sinputCaches.Value.抬起;
		case EInputState.Hold:
			return sinputCaches.Value.长按;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.WCL;
			string message = "错误的输入状态 ";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("state", state);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return 0f;
		}
		}
	}

	// Token: 0x060195FD RID: 103933 RVA: 0x00750A00 File Offset: 0x0074EC00
	[NullableContext(0)]
	public ValueTuple<bool, float> GetHoldConfig(CSharpScript.Game.Input.EInputAction action)
	{
		BP_InputBase_C bpInputComp = this.GetBpInputComp();
		if (bpInputComp == null)
		{
			return new ValueTuple<bool, float>(false, -1f);
		}
		SInputHoldConfig? sinputHoldConfig = null;
		if (!this.HoldConfigs.ContainsKey(action))
		{
			sinputHoldConfig = new SInputHoldConfig?(bpInputComp.GetUnrealHoldConfig((int)action));
			this.HoldConfigs[action] = sinputHoldConfig.Value;
		}
		if (sinputHoldConfig == null && this.HoldConfigs.ContainsKey(action))
		{
			sinputHoldConfig = new SInputHoldConfig?(this.HoldConfigs[action]);
		}
		if (sinputHoldConfig == null)
		{
			return new ValueTuple<bool, float>(false, -1f);
		}
		return new ValueTuple<bool, float>(sinputHoldConfig.Value.连续触发, sinputHoldConfig.Value.触发时间);
	}

	// Token: 0x060195FE RID: 103934 RVA: 0x00750ABC File Offset: 0x0074ECBC
	public void TurnOnAutomaticFlightMode(ICM_AutomaticFlight_DataBase_C dataAsset)
	{
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Actor.GetName().Contains("Youyidie"))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Test;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "Error TurnOnAutomaticFlightMode";
			string item = "Actor";
			CharacterActorComponent actorComp2 = this.ActorComp;
			object item2;
			if (actorComp2 == null)
			{
				item2 = null;
			}
			else
			{
				TsBaseCharacter actor = actorComp2.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, item2);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		else
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Test;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "TurnOnAutomaticFlightMode";
			string item3 = "Actor";
			CharacterActorComponent actorComp3 = this.ActorComp;
			object item4;
			if (actorComp3 == null)
			{
				item4 = null;
			}
			else
			{
				TsBaseCharacter actor2 = actorComp3.Actor;
				item4 = ((actor2 != null) ? actor2.GetName() : null);
			}
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>(item3, item4);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		this.AutomaticFlightMode = true;
		this.AutomaticFlightDataAsset = new AutomaticFlightData(dataAsset);
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp == null || !moveComp.Valid)
		{
			return;
		}
		this.AutomaticFlightDataAsset.LastFlySpeed = this.AutomaticFlightDataAsset.NormalFlySpeed;
		this.AutomaticFlightDataAsset.TargetFlySpeed = this.AutomaticFlightDataAsset.NormalFlySpeed;
		this.MoveComp.SetMaxSpeed(this.AutomaticFlightDataAsset.NormalFlySpeed.Value);
	}

	// Token: 0x060195FF RID: 103935 RVA: 0x00750BE9 File Offset: 0x0074EDE9
	public void TurnOffAutomaticFlightMode()
	{
		this.AutomaticFlightMode = false;
		this.AutomaticFlightDataAsset = null;
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp == null || !moveComp.Valid)
		{
			return;
		}
		this.StateComp.ResetCharState();
	}

	// Token: 0x06019600 RID: 103936 RVA: 0x00750C1C File Offset: 0x0074EE1C
	public bool IsInAutomaticFlightMode()
	{
		return this.AutomaticFlightMode;
	}

	// Token: 0x06019601 RID: 103937 RVA: 0x00750C24 File Offset: 0x0074EE24
	public void TurnOnCameraDrivenAutoFlightMode(BP_CameraDrivenAutoFlightData_C dataAsset)
	{
		if (dataAsset == null)
		{
			return;
		}
		this.CameraDrivenAutoFlightMode = true;
		this.IsStartCameraDrivenAutoFlightTick = false;
		if (this.CameraDrivenAutoFlightDataAsset == null)
		{
			this.CameraDrivenAutoFlightDataAsset = new CameraDrivenAutoFlightData();
		}
		this.CameraDrivenAutoFlightDataAsset.AutoFlightEnableTime = dataAsset.自动驾驶开始时间;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightStartAngleTolerance = dataAsset.自动驾驶启动输入;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightFinishAngleTolerance = dataAsset.自动驾驶完成角度;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightInputAngleMin = dataAsset.自动驾驶归正角度Min;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightInputAngleMax = dataAsset.自动驾驶归正角度Max;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightInputMin = dataAsset.自动驾驶归正角度模拟输入Min;
		this.CameraDrivenAutoFlightDataAsset.AutoFlightInputMax = dataAsset.自动驾驶归正角度模拟输入Max;
	}

	// Token: 0x06019602 RID: 103938 RVA: 0x00750CCD File Offset: 0x0074EECD
	public void TurnOffCameraDrivenAutoFlightMode()
	{
		this.CameraDrivenAutoFlightMode = false;
		this.IsStartCameraDrivenAutoFlightTick = false;
	}

	// Token: 0x06019603 RID: 103939 RVA: 0x00750CDD File Offset: 0x0074EEDD
	public bool IsInCameraDrivenAutoFlightMode()
	{
		return this.CameraDrivenAutoFlightMode && this.IsInCameraDrivenAutoFlight;
	}

	// Token: 0x06019604 RID: 103940 RVA: 0x00750CF0 File Offset: 0x0074EEF0
	private void AddCharacterInputLayer()
	{
		if (this.InputLayer != null)
		{
			this.RemoveCharacterInputLayer();
		}
		this.InputLayer = (ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.Character) as CharacterInputLayer);
		if (this.InputLayer != null)
		{
			EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
			if (handleByEntity != null)
			{
				this.InputLayer.Init(handleByEntity);
				ControllerBase<InputController>.Instance.AddInputLayer(base.Entity.Id, this.InputLayer);
			}
		}
	}

	// Token: 0x06019605 RID: 103941 RVA: 0x00750D64 File Offset: 0x0074EF64
	private void RemoveCharacterInputLayer()
	{
		if (this.InputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(this.InputLayer);
			this.InputLayer.Clear();
			this.InputLayer = null;
		}
	}

	// Token: 0x06019606 RID: 103942 RVA: 0x00750D90 File Offset: 0x0074EF90
	private void AddExtraInputLayer()
	{
		EntityHandle handleByEntity = ModelBase<CharacterModel>.Instance.GetHandleByEntity(base.Entity);
		if (handleByEntity == null)
		{
			return;
		}
		string bpInputClassPath = ExtraInputLayer.GetBpInputClassPath(handleByEntity);
		if (string.IsNullOrEmpty(bpInputClassPath))
		{
			return;
		}
		ExtraInputLayer extraInputLayer = ControllerBase<InputController>.Instance.CreateInputLayer(EInputLayer.Extra) as ExtraInputLayer;
		if (extraInputLayer == null)
		{
			return;
		}
		extraInputLayer.Init(handleByEntity, bpInputClassPath);
		if (this.ExtraInputLayer != null)
		{
			this.RemoveExtraInputLayer();
		}
		this.ExtraInputLayer = extraInputLayer;
		ControllerBase<InputController>.Instance.AddInputLayer(base.Entity.Id, this.ExtraInputLayer);
	}

	// Token: 0x06019607 RID: 103943 RVA: 0x00750E0F File Offset: 0x0074F00F
	private void RemoveExtraInputLayer()
	{
		if (this.ExtraInputLayer != null)
		{
			ControllerBase<InputController>.Instance.RemoveInputLayer(this.ExtraInputLayer);
			this.ExtraInputLayer.Clear();
			this.ExtraInputLayer = null;
		}
	}

	// Token: 0x06019608 RID: 103944 RVA: 0x00750E3B File Offset: 0x0074F03B
	[NullableContext(2)]
	public BP_InputBase_C GetBpInputComp()
	{
		CharacterInputLayer inputLayer = this.InputLayer;
		if (inputLayer == null)
		{
			return null;
		}
		return inputLayer.GetBpInputComp();
	}

	// Token: 0x06019609 RID: 103945 RVA: 0x00750E4E File Offset: 0x0074F04E
	public void SetBpInputComp(BP_InputBase_C bpInputComp)
	{
		CharacterInputLayer inputLayer = this.InputLayer;
		if (inputLayer == null)
		{
			return;
		}
		inputLayer.SetBpInputComp(bpInputComp);
	}

	// Token: 0x0601960A RID: 103946 RVA: 0x00750E64 File Offset: 0x0074F064
	public float GetCommandInterval(ECommandType commandType)
	{
		double num = this.CommandTimeMap.ContainsKey(commandType) ? this.CommandTimeMap[commandType] : 0.0;
		return (float)(Singleton<Time>.Instance.WorldTimeSeconds - num);
	}

	// Token: 0x0601960B RID: 103947 RVA: 0x00750EA4 File Offset: 0x0074F0A4
	public void RemoveCommandInterval(ECommandType commandType)
	{
		this.CommandTimeMap.Remove(commandType);
	}

	// Token: 0x0601960C RID: 103948 RVA: 0x00750EB3 File Offset: 0x0074F0B3
	public bool IsOnlyAllowFightInput()
	{
		return this.IsOnlyAllowFightInputInternal;
	}

	// Token: 0x0601960D RID: 103949 RVA: 0x00750EBB File Offset: 0x0074F0BB
	public void SetOnlyAllowFightInput(bool isOnlyAllowFightInput)
	{
		this.IsOnlyAllowFightInputInternal = isOnlyAllowFightInput;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnOnlyAllowFightInputStateChanged);
	}

	// Token: 0x0601960E RID: 103950 RVA: 0x00750ED4 File Offset: 0x0074F0D4
	private void InitInputCacheMode()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return;
		}
		int pbDataId = component.GetPbDataId();
		if (component.IsRole() && pbDataId > 100000 && ConfigBase<RoleConfig>.Instance != null)
		{
			TrialRoleInfo? trialRoleConfig = ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(pbDataId);
			if (trialRoleConfig != null)
			{
				pbDataId = trialRoleConfig.Value.ParentId;
			}
		}
		if (Array.Exists<int>(CharacterInputComponent.useDelayCacheModeRoleIds, (int x) => x == pbDataId))
		{
			this.InputCacheExecuteMode = EInputCacheExecuteMode.Delay;
		}
	}

	// Token: 0x0601960F RID: 103951 RVA: 0x00750F6D File Offset: 0x0074F16D
	public void SetInputCacheMode(int mode)
	{
		this.InputCacheExecuteMode = (EInputCacheExecuteMode)mode;
	}

	// Token: 0x06019610 RID: 103952 RVA: 0x00750F78 File Offset: 0x0074F178
	private void TryGetTagDaPathMap()
	{
		BP_FirstPersonConfigMap_C bp_FirstPersonConfigMap_C = Singleton<ResourceSystem>.Instance.Load<BP_FirstPersonConfigMap_C>("/Game/Aki/Character/Role/Common/Data/DA/DA_FirstPersonConfigMap.DA_FirstPersonConfigMap", "js_undefined");
		if (bp_FirstPersonConfigMap_C == null || !bp_FirstPersonConfigMap_C.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.Input, ELogAuthor.ZJL, "第一人称配置表加载失败, 无法获取TagToDaPathMap", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		TMap<FGameplayTag, TSoftObjectPtr<BP_FirstPersonConfig_C>> tagToConfigMap = bp_FirstPersonConfigMap_C.TagToConfigMap;
		for (int i = 0; i < tagToConfigMap.Num(); i++)
		{
			int num = tagToConfigMap.GetKey(i).TagId();
			TSoftObjectPtr<BP_FirstPersonConfig_C> tsoftObjectPtr = tagToConfigMap.Get(tagToConfigMap.GetKey(i));
			string value = (tsoftObjectPtr != null) ? tsoftObjectPtr.ToAssetPathName() : null;
			if (!string.IsNullOrEmpty(value))
			{
				this.TagToDaPathMap[num] = value;
			}
			else
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Input;
				ELogAuthor author = ELogAuthor.ZJL;
				string message = "第一人称配置表中触发Tag的软引用为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tagId", num);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x06019611 RID: 103953 RVA: 0x0075105C File Offset: 0x0074F25C
	private void AddCameraFollowInputListener()
	{
		foreach (KeyValuePair<int, string> keyValuePair in this.TagToDaPathMap)
		{
			int key = keyValuePair.Key;
			BaseTagComponent tagComp = this.TagComp;
			ITagTask tagTask = (tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(key), delegate(int tagId, bool tagExists)
			{
				if (tagExists)
				{
					this.ActiveCameraFollowInput(tagId);
					return;
				}
				this.ClearCameraFollowInputState();
			}, null) : null;
			if (tagTask != null)
			{
				this.CameraFollowInputTagTasks.Add(tagTask);
			}
		}
	}

	// Token: 0x06019612 RID: 103954 RVA: 0x007510E8 File Offset: 0x0074F2E8
	private void ActiveCameraFollowInput(int triggerTagId)
	{
		this.InCameraFollowInput = true;
		this.InitCameraFollowInputConfig(triggerTagId, delegate(CameraFollowInputConfig config)
		{
			for (int i = 0; i < config.FirstPersonTagList.Count; i++)
			{
				int value = config.FirstPersonTagList[i];
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.AddTag(new int?(value));
				}
			}
		});
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null)
		{
			stateComp.SetDirectionState(ECharDirectionState.CameraDirection);
		}
		Entity entity = base.Entity;
		if (entity == null)
		{
			return;
		}
		BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return;
		}
		component.SetLockedRotation(true);
	}

	// Token: 0x06019613 RID: 103955 RVA: 0x0075113C File Offset: 0x0074F33C
	private void ClearCameraFollowInputState()
	{
		this.InCameraFollowInput = false;
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp != null)
		{
			unifiedComp.MarkWalkOrRun(false, false, new bool?(false));
		}
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null)
		{
			stateComp.SetDirectionState(ECharDirectionState.FaceDirection);
		}
		Entity entity = base.Entity;
		if (entity != null)
		{
			BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.SetLockedRotation(false);
			}
		}
		if (this.CameraFollowInputConfig != null)
		{
			for (int i = 0; i < this.CameraFollowInputConfig.FirstPersonTagList.Count; i++)
			{
				int value = this.CameraFollowInputConfig.FirstPersonTagList[i];
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp != null)
				{
					tagComp.RemoveTag(new int?(value));
				}
			}
		}
	}

	// Token: 0x06019614 RID: 103956 RVA: 0x007511E8 File Offset: 0x0074F3E8
	private void RemoveCameraFollowInputListener()
	{
		this.ClearCameraFollowInputState();
		this.CameraFollowInputLockRunState = false;
		this.CameraFollowInputInSprintState = false;
		this.CameraFollowInputConfig = null;
		for (int i = 0; i < this.CameraFollowInputTagTasks.Count; i++)
		{
			this.CameraFollowInputTagTasks[i].EndTask();
		}
		this.CameraFollowInputTagTasks.Clear();
	}

	// Token: 0x06019615 RID: 103957 RVA: 0x00751244 File Offset: 0x0074F444
	private void InitCameraFollowInputConfig(int triggerTagId, Action<CameraFollowInputConfig> callback)
	{
		if (!this.CameraFollowInputLockRunState)
		{
			this.CameraFollowInputLockRunState = true;
			CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
			if (unifiedComp != null)
			{
				unifiedComp.MarkWalkOrRun(false, false, new bool?(true));
			}
		}
		CameraFollowInputConfig cameraFollowInputConfig = this.CameraFollowInputConfig;
		if (cameraFollowInputConfig != null && cameraFollowInputConfig.TriggerTagId == triggerTagId)
		{
			callback(this.CameraFollowInputConfig);
			return;
		}
		string configPath = this.FindFirstPersonConfigPath(triggerTagId);
		if (string.IsNullOrEmpty(configPath))
		{
			return;
		}
		Action<BP_FirstPersonConfig_C, string> <>9__1;
		Singleton<ResourceSystem>.Instance.LoadTypeAsync("BP_FirstPersonConfig_C", delegate
		{
			ResourceSystem instance = Singleton<ResourceSystem>.Instance;
			string configPath = configPath;
			Action<BP_FirstPersonConfig_C, string> callback2;
			if ((callback2 = <>9__1) == null)
			{
				callback2 = (<>9__1 = delegate([Nullable(2)] BP_FirstPersonConfig_C result, string _)
				{
					CameraFollowInputConfig cameraFollowInputConfig2 = new CameraFollowInputConfig();
					if (result != null && result.IsValid())
					{
						cameraFollowInputConfig2.Init(result, triggerTagId);
					}
					this.CameraFollowInputConfig = cameraFollowInputConfig2;
					callback(cameraFollowInputConfig2);
				});
			}
			instance.LoadAsync<BP_FirstPersonConfig_C>(configPath, callback2, 100, "js_undefined");
		}, "js_undefined");
	}

	// Token: 0x06019616 RID: 103958 RVA: 0x00751304 File Offset: 0x0074F504
	[NullableContext(2)]
	private string FindFirstPersonConfigPath(int triggerTagId)
	{
		if (this.TagToDaPathMap.ContainsKey(triggerTagId))
		{
			return this.TagToDaPathMap[triggerTagId];
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Input;
		ELogAuthor author = ELogAuthor.ZJL;
		string message = "第一人称配置表中未找到触发Tag对应的子DA";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("triggerTagId", triggerTagId);
		instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06019617 RID: 103959 RVA: 0x0075135C File Offset: 0x0074F55C
	private void SetMoveSprint(bool value)
	{
		if (value)
		{
			if (!this.CameraFollowInputInSprintState)
			{
				CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
				if (unifiedComp != null)
				{
					unifiedComp.SprintPress();
				}
				this.CameraFollowInputInSprintState = true;
				return;
			}
		}
		else if (this.CameraFollowInputInSprintState)
		{
			CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
			if (unifiedComp2 != null)
			{
				unifiedComp2.SprintRelease();
			}
			this.CameraFollowInputInSprintState = false;
		}
	}

	// Token: 0x06019618 RID: 103960 RVA: 0x007513B0 File Offset: 0x0074F5B0
	private void CameraFollowInputCompensate()
	{
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp == null || unifiedComp.PositionState > ECharPositionState.Ground)
		{
			CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
			if (unifiedComp2 == null || unifiedComp2.PositionState != ECharPositionState.Air)
			{
				CharacterUnifiedStateComponent unifiedComp3 = this.UnifiedComp;
				if (unifiedComp3 == null || unifiedComp3.PositionState != ECharPositionState.Water)
				{
					this.SetMoveSprint(false);
					return;
				}
			}
		}
		CharacterUnifiedStateComponent unifiedComp4 = this.UnifiedComp;
		if (unifiedComp4 == null || unifiedComp4.MoveState != ECharMoveState.Sprint)
		{
			this.SetMoveSprint(false);
		}
		if (this.StateComp.DirectionState != ECharDirectionState.CameraDirection)
		{
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp != null)
			{
				stateComp.SetDirectionState(ECharDirectionState.CameraDirection);
			}
			Entity entity = base.Entity;
			if (entity != null)
			{
				BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
				if (component != null)
				{
					component.SetLockedRotation(true);
				}
			}
		}
		CharacterUnifiedStateComponent unifiedComp5 = this.UnifiedComp;
		if (unifiedComp5 != null && unifiedComp5.PositionState == ECharPositionState.Ground && !this.TempVector2.IsNearlyZero(9.999999747378752E-05))
		{
			CharacterSkillComponent skillComponent = this.SkillComponent;
			if (((skillComponent != null) ? skillComponent.CurrentSkill : null) == null)
			{
				CameraFollowInputConfig cameraFollowInputConfig = this.CameraFollowInputConfig;
				if (cameraFollowInputConfig != null && cameraFollowInputConfig.DashInForwardAngle)
				{
					float num = Math.Abs(Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(this.ActorComp, this.ActorComp.ActorForwardProxy, this.ActorComp.InputDirectProxy));
					CameraFollowInputConfig cameraFollowInputConfig2 = this.CameraFollowInputConfig;
					if (num < ((cameraFollowInputConfig2 != null) ? cameraFollowInputConfig2.ForwardAngle : 50f))
					{
						this.SetMoveSprint(true);
						goto IL_165;
					}
					this.SetMoveSprint(false);
					goto IL_165;
				}
			}
		}
		this.SetMoveSprint(false);
		IL_165:
		if (this.CameraFollowInputConfig != null)
		{
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null && tagComp.HasAnyTag(this.CameraFollowInputConfig.ForbidRotationTagList))
			{
				return;
			}
		}
		this.CalculateMoveDirection(this.TempVector2);
		if (!this.TempVector2.IsNearlyZero(9.999999747378752E-05))
		{
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, this.ActorComp.ActorUpProxy, this.TempRotator);
			this.ActorComp.SetActorRotation(this.TempRotator.ToUeRotator(), "CameraFollowInput.CameraDirection", false);
			this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
		}
	}

	// Token: 0x17002238 RID: 8760
	// (get) Token: 0x06019619 RID: 103961 RVA: 0x007515C8 File Offset: 0x0074F7C8
	// (set) Token: 0x0601961A RID: 103962 RVA: 0x00751613 File Offset: 0x0074F813
	private InputContinuously AutoMovingConfig
	{
		get
		{
			if (this.AutoMovingConfigInternal == null)
			{
				BaseTagComponent component = base.Entity.GetComponent<BaseTagComponent>();
				BaseBuffComponent component2 = base.Entity.GetComponent<BaseBuffComponent>();
				this.AutoMovingConfigInternal = new InputContinuously(component, component2);
				this.AutoMovingConfigInternal.InitConfig();
			}
			return this.AutoMovingConfigInternal;
		}
		set
		{
			this.AutoMovingConfigInternal = value;
		}
	}

	// Token: 0x0601961B RID: 103963 RVA: 0x0075161C File Offset: 0x0074F81C
	private void UpdateAutoMovingCheck(global::Vector moveDirection, float delta)
	{
		BattleUiFormationData formationData = ModelBase<BattleUiModel>.Instance.FormationData;
		if (formationData != null && formationData.AutoMovingSettingEnable)
		{
			bool autoMovingState = this.AutoMovingConfig.GetAutoMovingState();
			bool flag = this.AutoMovingConfig.IsStartEnter();
			bool flag2 = moveDirection.IsNearlyZero(9.999999747378752E-05);
			if (autoMovingState && !flag && !flag2)
			{
				this.InterruptAutoMoving("玩家输入", true);
				return;
			}
			if (autoMovingState)
			{
				if (this.CheckOtherPositionState(delta))
				{
					return;
				}
				CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
				if (unifiedComp == null || unifiedComp.PositionState > ECharPositionState.Ground)
				{
					this.InterruptAutoMoving("处于其他移动状态", true);
					return;
				}
			}
			if (flag2)
			{
				if (!autoMovingState)
				{
					this.AutoMovingConfig.ClearTimeAccumulation();
				}
				else if (flag)
				{
					this.AutoMovingConfig.ClearStartEnter();
				}
			}
			if (!autoMovingState)
			{
				if (!flag2)
				{
					CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
					if (unifiedComp2 != null && unifiedComp2.MoveState == ECharMoveState.Sprint)
					{
						this.AutoMovingConfig.AddTimeAccumulation(delta);
						goto IL_E3;
					}
				}
				this.AutoMovingConfig.ClearTimeAccumulation();
				IL_E3:
				if (this.AutoMovingConfig.CheckTimeDuration())
				{
					this.AutoMovingConfig.SetAutoMovingState(true, true);
				}
			}
		}
	}

	// Token: 0x0601961C RID: 103964 RVA: 0x00751728 File Offset: 0x0074F928
	private bool CheckOtherPositionState(float delta)
	{
		bool flag = ControllerBase<FormationAttributeController>.Instance.GetValue(EFormationAttributeId.Strength) < 2200f;
		if (flag && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.InterruptAutoMoving("进战下体力值太低自动结束", true);
			return true;
		}
		bool result = false;
		CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
		if (unifiedComp != null && unifiedComp.PositionState == ECharPositionState.Air)
		{
			result = true;
			this.AutoMovingConfig.InAirTime += delta;
			if (this.AutoMovingConfig.InAirTime > this.AutoMovingConfig.AutoGlideTime)
			{
				this.InterruptAutoMoving("空中太久", true);
				CharacterMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					moveComp.TrySetGlide();
				}
			}
		}
		else
		{
			this.AutoMovingConfig.InAirTime = 0f;
		}
		CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
		if (unifiedComp2 == null || unifiedComp2.PositionState != ECharPositionState.Water)
		{
			CharacterUnifiedStateComponent unifiedComp3 = this.UnifiedComp;
			if (unifiedComp3 == null || unifiedComp3.PositionState != ECharPositionState.Climb)
			{
				this.AutoMovingConfig.InDelayExitTime = 0f;
				return result;
			}
		}
		result = true;
		this.AutoMovingConfig.InDelayExitTime += delta;
		if (this.AutoMovingConfig.InDelayExitTime > this.AutoMovingConfig.DelayExitTime)
		{
			this.InterruptAutoMoving("处于攀爬/游泳状态太久", true);
		}
		else if (flag)
		{
			CharacterUnifiedStateComponent unifiedComp4 = this.UnifiedComp;
			if (unifiedComp4 == null || unifiedComp4.MoveState != ECharMoveState.FastClimb)
			{
				CharacterUnifiedStateComponent unifiedComp5 = this.UnifiedComp;
				if (unifiedComp5 == null || unifiedComp5.MoveState != ECharMoveState.NormalClimb)
				{
					CharacterUnifiedStateComponent unifiedComp6 = this.UnifiedComp;
					if (unifiedComp6 == null || unifiedComp6.MoveState != ECharMoveState.NormalSwim)
					{
						CharacterUnifiedStateComponent unifiedComp7 = this.UnifiedComp;
						if (unifiedComp7 == null || unifiedComp7.MoveState != ECharMoveState.FastSwim)
						{
							return result;
						}
					}
				}
			}
			this.InterruptAutoMoving("体力值太低自动结束", true);
		}
		return result;
	}

	// Token: 0x0601961D RID: 103965 RVA: 0x007518D0 File Offset: 0x0074FAD0
	public bool InterruptAutoMoving(string context, bool clear = true)
	{
		if (base.Entity == null)
		{
			return true;
		}
		if (this.AutoMovingConfig.GetAutoMovingState())
		{
			this.AutoMovingConfig.ResetAutoMovingState(context);
			return true;
		}
		if (clear)
		{
			this.AutoMovingConfig.ClearTimeAccumulation();
		}
		return false;
	}

	// Token: 0x0601961E RID: 103966 RVA: 0x00751906 File Offset: 0x0074FB06
	public void SetAutoMovingConfig(InputContinuously value)
	{
		this.AutoMovingConfig.DeepCopy(value);
	}

	// Token: 0x0601961F RID: 103967 RVA: 0x00751914 File Offset: 0x0074FB14
	public InputContinuously GetAutoMovingConfig()
	{
		return this.AutoMovingConfig;
	}

	// Token: 0x06019620 RID: 103968 RVA: 0x0075191C File Offset: 0x0074FB1C
	private void CalculateMoveDirection(global::Vector outVector)
	{
		FVectorDouble fvectorDouble = Global.CharacterCameraManager.GetCameraRotation().VectorDouble();
		this.TempVector.DeepCopy(fvectorDouble);
		global::Vector gravityDirect = this.MoveComp.GravityDirect;
		global::Vector.VectorPlaneProject(this.TempVector, gravityDirect, outVector);
	}

	// Token: 0x06019621 RID: 103969 RVA: 0x00751964 File Offset: 0x0074FB64
	private void CalculateMoveDirectionFromFightCamera(global::Vector outVector)
	{
		ControllerBase<CameraController>.Instance.MainModel.FightCamera.LogicComponent.CameraRotation.Vector(this.TempVector);
		global::Vector gravityDirect = this.MoveComp.GravityDirect;
		global::Vector.VectorPlaneProject(this.TempVector, gravityDirect, outVector);
	}

	// Token: 0x06019622 RID: 103970 RVA: 0x007519AE File Offset: 0x0074FBAE
	private void OnRoleDead()
	{
		this.InterruptAutoMoving("角色死亡", true);
	}

	// Token: 0x06019623 RID: 103971 RVA: 0x007519BD File Offset: 0x0074FBBD
	private void OnSequenceNetworkStart(PlotInfo plotInfo)
	{
		if (plotInfo.PlotLevel == EPlotLevel.LevelA || plotInfo.PlotLevel == EPlotLevel.LevelB || plotInfo.PlotLevel == EPlotLevel.LevelC)
		{
			this.InterruptAutoMoving("进入剧情", true);
		}
	}

	// Token: 0x06019624 RID: 103972 RVA: 0x007519E6 File Offset: 0x0074FBE6
	private void AutoMovingSettingChanged(bool value)
	{
		if (!value)
		{
			this.AutoMovingConfig.ResetAutoMovingState("退出自动奔跑模式");
		}
	}

	// Token: 0x06019625 RID: 103973 RVA: 0x007519FC File Offset: 0x0074FBFC
	private void OnViewShow(EUiViewName viewName, int viewId)
	{
		UiShow? uiShowConfig = ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(viewName);
		if (uiShowConfig != null && !uiShowConfig.Value.AllowAutoMoving)
		{
			this.InterruptAutoMoving("打开了UI" + viewName, true);
		}
	}

	// Token: 0x06019626 RID: 103974 RVA: 0x00751A47 File Offset: 0x0074FC47
	private void CameraModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
	{
		if (cameraName != "MainCamera")
		{
			return;
		}
		if (newMode == ECustomCameraMode.Sequence || newMode == ECustomCameraMode.Scene || newMode == ECustomCameraMode.Orbital || newMode == ECustomCameraMode.Free)
		{
			this.InterruptAutoMoving("CameraModeChange:" + newMode.ToString(), true);
		}
	}

	// Token: 0x06019627 RID: 103975 RVA: 0x00751A88 File Offset: 0x0074FC88
	private void UpdateAutoSprint(bool autoMoving, float delta)
	{
		if (!this.CheckAutoSprintTagImmediately())
		{
			if (this.AutoSprintConfigTime == 0f)
			{
				this.AutoSprintConfigTime = (float)ConfigCommonParamById.GetIntConfig("AutoSprintTimerCondition").Value;
			}
			this.AutoSprintTime += delta;
			if (!autoMoving && this.AutoSprintTime < this.AutoSprintConfigTime)
			{
				return;
			}
			this.AutoSprintTime = 0f;
		}
		RoleGaitComponent component = base.Entity.GetComponent<RoleGaitComponent>();
		if (component != null && component.EnableRoleGaitState(ERoleGaitEnableType.Sprint))
		{
			CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
			if (unifiedComp == null || unifiedComp.MoveState != ECharMoveState.Run)
			{
				if (!autoMoving)
				{
					return;
				}
				CharacterUnifiedStateComponent unifiedComp2 = this.UnifiedComp;
				if (unifiedComp2 == null || unifiedComp2.MoveState != ECharMoveState.Walk)
				{
					return;
				}
			}
			this.UnifiedComp.SprintPress();
			ControllerBase<RoleAudioController>.Instance.OnPlayAccelerateAudio(base.Entity, ECharMoveState.Sprint, ECharPositionState.Ground, null, null);
		}
	}

	// Token: 0x06019628 RID: 103976 RVA: 0x00751B68 File Offset: 0x0074FD68
	[NullableContext(2)]
	public void EnableOverShoulderMode(OverShoulderModeConfig config)
	{
		if (config != null && !this.IsOverShoulderMode)
		{
			this.IsOverShoulderMode = true;
			this.OverShoulderConfig = config;
			BaseTagComponent tagComp = this.TagComp;
			this.SetOverShoulderSprintMode(tagComp != null && tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]), true);
			this.AddChangeOverShoulderSprintModeListener();
			return;
		}
		if (config == null && this.IsOverShoulderMode)
		{
			this.IsOverShoulderMode = false;
			this.OverShoulderConfig = null;
			this.SetOverShoulderSprintMode(false, true);
			ITagTask changeOverShoulderSprintMode = this.ChangeOverShoulderSprintMode;
			if (changeOverShoulderSprintMode != null)
			{
				changeOverShoulderSprintMode.EndTask();
			}
			this.ChangeOverShoulderSprintMode = null;
		}
	}

	// Token: 0x06019629 RID: 103977 RVA: 0x00751BF6 File Offset: 0x0074FDF6
	private void AddChangeOverShoulderSprintModeListener()
	{
		BaseTagComponent tagComp = this.TagComp;
		this.ChangeOverShoulderSprintMode = ((tagComp != null) ? tagComp.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持.长按"]), delegate(int tagId, bool tagExists)
		{
			if (tagExists)
			{
				this.SetOverShoulderSprintMode(true, false);
				return;
			}
			this.SetOverShoulderSprintMode(false, false);
		}, null) : null);
	}

	// Token: 0x0601962A RID: 103978 RVA: 0x00751C31 File Offset: 0x0074FE31
	public void TrySwitchOverShoulderSprintMode()
	{
		if (!this.IsOverShoulderMode)
		{
			return;
		}
		if (!this.IsOverShoulderSprint && !this.CanEnterOverShoulderSprintMode())
		{
			return;
		}
		this.SetOverShoulderSprintMode(!this.IsOverShoulderSprint, false);
	}

	// Token: 0x0601962B RID: 103979 RVA: 0x00751C60 File Offset: 0x0074FE60
	private bool CanEnterOverShoulderSprintMode()
	{
		if (this.OverShoulderConfig == null)
		{
			return false;
		}
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp == null || stateComp.PositionState > ECharPositionState.Ground)
		{
			return false;
		}
		CharacterSkillComponent skillComponent = this.SkillComponent;
		if (((skillComponent != null) ? skillComponent.CurrentSkill : null) != null)
		{
			return false;
		}
		global::Vector moveDirectionCache = this.GetMoveDirectionCache();
		return !moveDirectionCache.IsNearlyZero(9.999999747378752E-05) && Math.Abs(moveDirectionCache.HeadingAngle() * 57.295780181884766) <= (double)this.OverShoulderConfig.SprintExitDegAbs;
	}

	// Token: 0x0601962C RID: 103980 RVA: 0x00751CE6 File Offset: 0x0074FEE6
	private void SetOverShoulderSprintMode(bool enable, bool force = false)
	{
		if (!force && this.IsOverShoulderSprint == enable)
		{
			return;
		}
		this.IsOverShoulderSprint = enable;
		if (enable)
		{
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp == null)
			{
				return;
			}
			stateComp.SprintPress();
			return;
		}
		else
		{
			CharacterUnifiedStateComponent stateComp2 = this.StateComp;
			if (stateComp2 == null)
			{
				return;
			}
			stateComp2.SprintRelease();
			return;
		}
	}

	// Token: 0x0601962D RID: 103981 RVA: 0x00751D20 File Offset: 0x0074FF20
	private void SetInputFacingFromCameraDirection(float delta)
	{
		if (this.OverShoulderConfig == null)
		{
			return;
		}
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null)
		{
			stateComp.SetDirectionState(ECharDirectionState.CameraDirection);
		}
		Entity entity = base.Entity;
		if (entity != null)
		{
			BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.SetLockedRotation(true);
			}
		}
		this.CalculateMoveDirectionFromFightCamera(this.TempVector2);
		global::Vector gravityUp = this.ActorComp.MoveComp.GravityUp;
		if (!this.TempVector2.Normalize(9.99999993922529E-09))
		{
			this.TempVector2.DeepCopy(this.LastCameraDir);
		}
		else if (Math.Abs(this.TempVector2.DotProduct(gravityUp)) > 0.9999)
		{
			this.TempVector2.DeepCopy(this.LastCameraDir);
		}
		if (this.TempVector2.IsNearlyZero(9.999999747378752E-05) || this.TempVector2.Equals(this.ActorComp.ActorForwardProxy, 9.999999747378752E-05))
		{
			return;
		}
		this.LastCameraDir.DeepCopy(this.TempVector2);
		Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.TempVector2, gravityUp, this.TempRotator);
		this.ActorComp.ActorQuatProxy.Inverse(this.TempQuat);
		this.TempQuat.Multiply(this.TempRotator.Quaternion(null), this.TempQuat2);
		float num = Math.Abs(Singleton<MathUtils>.Instance.WrapAngle((float)Math.Acos((double)this.TempQuat2.W) * 2f * 57.29578f));
		OverShoulderModeConfig overShoulderConfig = this.OverShoulderConfig;
		float lerpDegAlpha = overShoulderConfig.GetLerpDegAlpha(Singleton<MathUtils>.Instance.Clamp(num / overShoulderConfig.LerpBeginDeg, 0f, 1f));
		float num2 = Singleton<MathUtils>.Instance.Lerp(overShoulderConfig.MinTurnSpeed, overShoulderConfig.MaxTurnSpeed, lerpDegAlpha) * delta * 0.001f;
		float slerp = Singleton<MathUtils>.Instance.Clamp(num2 / num, 0f, 1f);
		Quat.Slerp(this.ActorComp.ActorQuatProxy, this.TempRotator.Quaternion(null), slerp, this.TempQuat);
		this.TempQuat.Rotator(this.TempRotator);
		this.TempRotator.Vector(this.TempVector2);
		this.ActorComp.SetInputFacing(this.TempVector2, true);
		this.ActorComp.SetActorRotation(this.TempRotator.ToUeRotator(), "SetInputFacingFromCameraDirection", false);
	}

	// Token: 0x0601962E RID: 103982 RVA: 0x00751F7C File Offset: 0x0075017C
	private void UpdateCharacterInputDirectAndFacingOverShoulderMode(float delta)
	{
		global::Vector vector = global::Vector.ZeroVectorProxy;
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp != null && tagComp.Valid)
		{
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			if (stateComp != null && stateComp.Valid)
			{
				bool flag = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["战斗状态.行为改变.保持输入"]);
				bool flag2 = this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.技能中.全身动作"]);
				vector = this.GetWorldMoveDirectionCache();
				if (vector.IsNearlyZero(9.999999747378752E-05) && flag)
				{
					vector = this.ActorComp.InputDirectProxy;
					if (vector.IsNearlyZero(9.999999747378752E-05))
					{
						vector = this.ActorComp.ActorForwardProxy;
					}
				}
				if (!flag2)
				{
					bool flag3 = false;
					CharacterUnifiedStateComponent unifiedComp = this.UnifiedComp;
					if (unifiedComp != null && unifiedComp.MoveState == ECharMoveState.Stand)
					{
						if (vector.IsNearlyZero(9.999999747378752E-05))
						{
							this.StandInputDelayCountDown = 200f;
							this.CacheStandInputDirect.Reset();
							flag3 = true;
						}
						else if (this.StandInputDelayCountDown > 0f)
						{
							this.StandInputDelayCountDown -= delta;
							this.CacheStandInputDirect.DeepCopy(vector);
							flag3 = true;
						}
					}
					if (!flag3)
					{
						this.CacheStandInputDirect.Reset();
						this.ActorComp.SetInputDirect(vector, !this.IsLocalInputInternal);
					}
					ECharPositionState positionState = this.StateComp.PositionState;
					switch (positionState)
					{
					case ECharPositionState.Ground:
						this.SetInputFacingOnGroundFromCameraDirection(delta);
						return;
					case ECharPositionState.Climb:
						return;
					case ECharPositionState.Air:
						if (this.StateComp.MoveState == ECharMoveState.WalkOnAir)
						{
							this.SetInputFacingOnGroundFromCameraDirection(delta);
							return;
						}
						return;
					case ECharPositionState.Water:
						break;
					default:
						if (positionState != ECharPositionState.Floating)
						{
							return;
						}
						break;
					}
					this.SetInputFacingFromCameraDirection(delta);
					return;
				}
				this.ActorComp.SetInputDirect(vector, true);
				if (this.LockInputRotator())
				{
					this.ActorComp.SetInputFacing(this.ActorComp.ActorForwardProxy, false);
					return;
				}
				this.SetInputFacingFromCameraDirection(delta);
				return;
			}
		}
		vector = this.GetWorldMoveDirectionCache();
		this.ActorComp.SetInputDirect(vector, true);
		this.SetInputFacingFromCameraDirection(delta);
	}

	// Token: 0x0601962F RID: 103983 RVA: 0x0075217C File Offset: 0x0075037C
	private void SetInputFacingOnGroundFromCameraDirection(float delta)
	{
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null || !tagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.冲刺保持"]))
		{
			this.SetOverShoulderSprintMode(false, false);
			this.SetInputFacingFromCameraDirection(delta);
			return;
		}
		if (!this.CanEnterOverShoulderSprintMode())
		{
			this.SetOverShoulderSprintMode(false, false);
		}
		CharacterUnifiedStateComponent stateComp = this.StateComp;
		if (stateComp != null)
		{
			stateComp.SetDirectionState(ECharDirectionState.FaceDirection);
		}
		Entity entity = base.Entity;
		if (entity != null)
		{
			BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.SetLockedRotation(false);
			}
		}
		this.SetInputFacingFromInputDirect(true);
	}

	// Token: 0x06019630 RID: 103984 RVA: 0x00752202 File Offset: 0x00750402
	public static void CreateStaticDefaultValue()
	{
		CharacterInputComponent.HoldPressMap = new Dictionary<CSharpScript.Game.Input.EInputAction, bool>();
	}

	// Token: 0x06019631 RID: 103985 RVA: 0x0075220E File Offset: 0x0075040E
	public static void ResetStaticDefaultValue()
	{
		CharacterInputComponent.HoldPressMap = null;
	}

	// Token: 0x06019632 RID: 103986 RVA: 0x00752218 File Offset: 0x00750418
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterInputComponent characterInputComponent = (CharacterInputComponent)componentTemplate;
		if (base.CanResetComponentProperty("TempVector") && characterInputComponent.TempVector != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector), "TempVector"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempVector2") && characterInputComponent.TempVector2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.TempVector2), "TempVector2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempRotator") && characterInputComponent.TempRotator != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Rotator>(this.TempRotator), "TempRotator"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempQuat") && characterInputComponent.TempQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TempQuat), "TempQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TempQuat2") && characterInputComponent.TempQuat2 != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.TempQuat2), "TempQuat2"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (characterInputComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AbilityComp"))
		{
			if (characterInputComponent.AbilityComp == null)
			{
				this.AbilityComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAbilityComponent>(this.AbilityComp), "AbilityComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComp"))
		{
			if (characterInputComponent.TagComp == null)
			{
				this.TagComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("StateComp"))
		{
			if (characterInputComponent.StateComp == null)
			{
				this.StateComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.StateComp), "StateComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("SkillComponent"))
		{
			if (characterInputComponent.SkillComponent == null)
			{
				this.SkillComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterSkillComponent>(this.SkillComponent), "SkillComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveComp"))
		{
			if (characterInputComponent.MoveComp == null)
			{
				this.MoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterMoveComponent>(this.MoveComp), "MoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("UnifiedComp"))
		{
			if (characterInputComponent.UnifiedComp == null)
			{
				this.UnifiedComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterUnifiedStateComponent>(this.UnifiedComp), "UnifiedComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterInternal"))
		{
			if (characterInputComponent.CharacterInternal == null)
			{
				this.CharacterInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TsBaseCharacter>(this.CharacterInternal), "CharacterInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CharacterControllerInternal"))
		{
			if (characterInputComponent.CharacterControllerInternal == null)
			{
				this.CharacterControllerInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BP_CharacterController_C>(this.CharacterControllerInternal), "CharacterControllerInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputLayer"))
		{
			if (characterInputComponent.InputLayer == null)
			{
				this.InputLayer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterInputLayer>(this.InputLayer), "InputLayer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("ExtraInputLayer"))
		{
			if (characterInputComponent.ExtraInputLayer == null)
			{
				this.ExtraInputLayer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ExtraInputLayer>(this.ExtraInputLayer), "ExtraInputLayer"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("InputEvents") && characterInputComponent.InputEvents != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<InputEvent>>(this.InputEvents), "InputEvents"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InputCaches") && characterInputComponent.InputCaches != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<InputCache>>(this.InputCaches), "InputCaches"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("AxisValues") && characterInputComponent.AxisValues != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<EInputAxis, float>>(this.AxisValues), "AxisValues"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InputGroup"))
		{
			if (characterInputComponent.InputGroup == null)
			{
				this.InputGroup = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<InputFilter>(this.InputGroup), "InputGroup"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("MoveVectorCache") && characterInputComponent.MoveVectorCache != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.MoveVectorCache), "MoveVectorCache"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MoveDirectionCache") && characterInputComponent.MoveDirectionCache != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.MoveDirectionCache), "MoveDirectionCache"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("WorldMoveDirectionCache") && characterInputComponent.WorldMoveDirectionCache != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.WorldMoveDirectionCache), "WorldMoveDirectionCache"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("IsLocalInputInternal"))
		{
			this.IsLocalInputInternal = characterInputComponent.IsLocalInputInternal;
		}
		if (base.CanResetComponentProperty("IsOnlyAllowFightInputInternal"))
		{
			this.IsOnlyAllowFightInputInternal = characterInputComponent.IsOnlyAllowFightInputInternal;
		}
		if (base.CanResetComponentProperty("LastMovementInputTime"))
		{
			this.LastMovementInputTime = characterInputComponent.LastMovementInputTime;
		}
		if (base.CanResetComponentProperty("CommandTimeMap") && characterInputComponent.CommandTimeMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<ECommandType, double>>(this.CommandTimeMap), "CommandTimeMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("NeedQueryInputCache"))
		{
			this.NeedQueryInputCache = characterInputComponent.NeedQueryInputCache;
		}
		if (base.CanResetComponentProperty("DisableHandle"))
		{
			this.DisableHandle = characterInputComponent.DisableHandle;
		}
		if (base.CanResetComponentProperty("AutomaticFlightMode"))
		{
			this.AutomaticFlightMode = characterInputComponent.AutomaticFlightMode;
		}
		if (base.CanResetComponentProperty("AutomaticFlightDataAsset"))
		{
			if (characterInputComponent.AutomaticFlightDataAsset == null)
			{
				this.AutomaticFlightDataAsset = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<AutomaticFlightData>(this.AutomaticFlightDataAsset), "AutomaticFlightDataAsset"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AutomaticFlightModeTimeCache"))
		{
			this.AutomaticFlightModeTimeCache = characterInputComponent.AutomaticFlightModeTimeCache;
		}
		if (base.CanResetComponentProperty("CameraDrivenAutoFlightMode"))
		{
			this.CameraDrivenAutoFlightMode = characterInputComponent.CameraDrivenAutoFlightMode;
		}
		if (base.CanResetComponentProperty("CameraDrivenAutoFlightDataAsset"))
		{
			if (characterInputComponent.CameraDrivenAutoFlightDataAsset == null)
			{
				this.CameraDrivenAutoFlightDataAsset = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraDrivenAutoFlightData>(this.CameraDrivenAutoFlightDataAsset), "CameraDrivenAutoFlightDataAsset"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsInCameraDrivenAutoFlight"))
		{
			this.IsInCameraDrivenAutoFlight = characterInputComponent.IsInCameraDrivenAutoFlight;
		}
		if (base.CanResetComponentProperty("IsStartCameraDrivenAutoFlightTick"))
		{
			this.IsStartCameraDrivenAutoFlightTick = characterInputComponent.IsStartCameraDrivenAutoFlightTick;
		}
		if (base.CanResetComponentProperty("CameraDrivenAutoFlightTime"))
		{
			this.CameraDrivenAutoFlightTime = characterInputComponent.CameraDrivenAutoFlightTime;
		}
		if (base.CanResetComponentProperty("MoveDirectionDistanceMin"))
		{
			this.MoveDirectionDistanceMin = characterInputComponent.MoveDirectionDistanceMin;
		}
		if (base.CanResetComponentProperty("MoveDirectionDistanceMax"))
		{
			this.MoveDirectionDistanceMax = characterInputComponent.MoveDirectionDistanceMax;
		}
		if (base.CanResetComponentProperty("MovementDirectionAngleThreshold"))
		{
			this.MovementDirectionAngleThreshold = characterInputComponent.MovementDirectionAngleThreshold;
		}
		if (base.CanResetComponentProperty("InputCacheExecuteMode"))
		{
			this.InputCacheExecuteMode = characterInputComponent.InputCacheExecuteMode;
		}
		if (base.CanResetComponentProperty("StandInputDelayCountDown"))
		{
			this.StandInputDelayCountDown = characterInputComponent.StandInputDelayCountDown;
		}
		if (base.CanResetComponentProperty("CacheStandInputDirect"))
		{
			if (characterInputComponent.CacheStandInputDirect == null)
			{
				this.CacheStandInputDirect = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.CacheStandInputDirect), "CacheStandInputDirect"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NextFrameClear"))
		{
			this.NextFrameClear = characterInputComponent.NextFrameClear;
		}
		if (base.CanResetComponentProperty("NextFrameClearAxis") && characterInputComponent.NextFrameClearAxis != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<EInputAxis>(this.NextFrameClearAxis), "NextFrameClearAxis"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("LastShowMouseCursor"))
		{
			this.LastShowMouseCursor = characterInputComponent.LastShowMouseCursor;
		}
		if (base.CanResetComponentProperty("TestInputEvent") && characterInputComponent.TestInputEvent != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<InputEvent>>(this.TestInputEvent), "TestInputEvent"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CameraInputQuat") && characterInputComponent.CameraInputQuat != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Quat>(this.CameraInputQuat), "CameraInputQuat"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagEventJump"))
		{
			if (characterInputComponent.TagEventJump == null)
			{
				this.TagEventJump = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventJump), "TagEventJump"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventClimb"))
		{
			if (characterInputComponent.TagEventClimb == null)
			{
				this.TagEventClimb = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventClimb), "TagEventClimb"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventAttack"))
		{
			if (characterInputComponent.TagEventAttack == null)
			{
				this.TagEventAttack = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventAttack), "TagEventAttack"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventDodge"))
		{
			if (characterInputComponent.TagEventDodge == null)
			{
				this.TagEventDodge = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventDodge), "TagEventDodge"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventSkill"))
		{
			if (characterInputComponent.TagEventSkill == null)
			{
				this.TagEventSkill = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventSkill), "TagEventSkill"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventVision1"))
		{
			if (characterInputComponent.TagEventVision1 == null)
			{
				this.TagEventVision1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventVision1), "TagEventVision1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventUltimateSkill"))
		{
			if (characterInputComponent.TagEventUltimateSkill == null)
			{
				this.TagEventUltimateSkill = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventUltimateSkill), "TagEventUltimateSkill"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventVision2"))
		{
			if (characterInputComponent.TagEventVision2 == null)
			{
				this.TagEventVision2 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventVision2), "TagEventVision2"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventChangeRoll1"))
		{
			if (characterInputComponent.TagEventChangeRoll1 == null)
			{
				this.TagEventChangeRoll1 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventChangeRoll1), "TagEventChangeRoll1"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventChangeRoll2"))
		{
			if (characterInputComponent.TagEventChangeRoll2 == null)
			{
				this.TagEventChangeRoll2 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventChangeRoll2), "TagEventChangeRoll2"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventChangeRoll3"))
		{
			if (characterInputComponent.TagEventChangeRoll3 == null)
			{
				this.TagEventChangeRoll3 = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventChangeRoll3), "TagEventChangeRoll3"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventLock"))
		{
			if (characterInputComponent.TagEventLock == null)
			{
				this.TagEventLock = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventLock), "TagEventLock"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventAim"))
		{
			if (characterInputComponent.TagEventAim == null)
			{
				this.TagEventAim = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventAim), "TagEventAim"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagEventMove"))
		{
			if (characterInputComponent.TagEventMove == null)
			{
				this.TagEventMove = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.TagEventMove), "TagEventMove"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("IsMoveAxisToButtonEnabled"))
		{
			this.IsMoveAxisToButtonEnabled = characterInputComponent.IsMoveAxisToButtonEnabled;
		}
		if (base.CanResetComponentProperty("MoveAxisToButtonLogic") && characterInputComponent.MoveAxisToButtonLogic != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<MoveInputSimButtonLogic>(this.MoveAxisToButtonLogic), "MoveAxisToButtonLogic"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("MoveAxisToButtonActiveCondition"))
		{
			if (characterInputComponent.MoveAxisToButtonActiveCondition == null)
			{
				this.MoveAxisToButtonActiveCondition = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<InputActiveCondition>(this.MoveAxisToButtonActiveCondition), "MoveAxisToButtonActiveCondition"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("CacheTimes") && characterInputComponent.CacheTimes != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<CSharpScript.Game.Input.EInputAction, SInputCaches>>(this.CacheTimes), "CacheTimes"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("HoldConfigs") && characterInputComponent.HoldConfigs != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<CSharpScript.Game.Input.EInputAction, SInputHoldConfig>>(this.HoldConfigs), "HoldConfigs"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("InCameraFollowInput"))
		{
			this.InCameraFollowInput = characterInputComponent.InCameraFollowInput;
		}
		if (base.CanResetComponentProperty("CameraFollowInputTagTasks") && characterInputComponent.CameraFollowInputTagTasks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.CameraFollowInputTagTasks), "CameraFollowInputTagTasks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagToDaPathMap") && characterInputComponent.TagToDaPathMap != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, string>>(this.TagToDaPathMap), "TagToDaPathMap"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("CameraFollowInputLockRunState"))
		{
			this.CameraFollowInputLockRunState = characterInputComponent.CameraFollowInputLockRunState;
		}
		if (base.CanResetComponentProperty("CameraFollowInputInSprintState"))
		{
			this.CameraFollowInputInSprintState = characterInputComponent.CameraFollowInputInSprintState;
		}
		if (base.CanResetComponentProperty("CameraFollowInputConfig"))
		{
			if (characterInputComponent.CameraFollowInputConfig == null)
			{
				this.CameraFollowInputConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CameraFollowInputConfig>(this.CameraFollowInputConfig), "CameraFollowInputConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AutoMovingConfigInternal"))
		{
			if (characterInputComponent.AutoMovingConfigInternal == null)
			{
				this.AutoMovingConfigInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<InputContinuously>(this.AutoMovingConfigInternal), "AutoMovingConfigInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("AutoSprintTime"))
		{
			this.AutoSprintTime = characterInputComponent.AutoSprintTime;
		}
		if (base.CanResetComponentProperty("AutoSprintConfigTime"))
		{
			this.AutoSprintConfigTime = characterInputComponent.AutoSprintConfigTime;
		}
		if (base.CanResetComponentProperty("IsOverShoulderMode"))
		{
			this.IsOverShoulderMode = characterInputComponent.IsOverShoulderMode;
		}
		if (base.CanResetComponentProperty("IsOverShoulderSprint"))
		{
			this.IsOverShoulderSprint = characterInputComponent.IsOverShoulderSprint;
		}
		if (base.CanResetComponentProperty("ChangeOverShoulderSprintMode"))
		{
			if (characterInputComponent.ChangeOverShoulderSprintMode == null)
			{
				this.ChangeOverShoulderSprintMode = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<ITagTask>(this.ChangeOverShoulderSprintMode), "ChangeOverShoulderSprintMode"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OverShoulderConfig"))
		{
			if (characterInputComponent.OverShoulderConfig == null)
			{
				this.OverShoulderConfig = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<OverShoulderModeConfig>(this.OverShoulderConfig), "OverShoulderConfig"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastCameraDir"))
		{
			if (characterInputComponent.LastCameraDir == null)
			{
				this.LastCameraDir = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.LastCameraDir), "LastCameraDir"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400C88E RID: 51342
	private const int ZERO_TIME = 0;

	// Token: 0x0400C88F RID: 51343
	private const int NULL_CONFIG_TIME = -1;

	// Token: 0x0400C890 RID: 51344
	private const int INVALID_PRIORITY = -1;

	// Token: 0x0400C891 RID: 51345
	private const int INVALID_PRIORITY_INDEX = -1;

	// Token: 0x0400C892 RID: 51346
	private const int INVALID_INPUT_TIME = -1;

	// Token: 0x0400C893 RID: 51347
	private const float MOVE_VECTOR_CACHE_TIME = 100f;

	// Token: 0x0400C894 RID: 51348
	private const float EXIT_CLIMB_BLOCK_ATTACK_RELEASE_TIME = 0.25f;

	// Token: 0x0400C895 RID: 51349
	public const int CAMERA_FOLLOW_FORWARD_ANGLE = 50;

	// Token: 0x0400C896 RID: 51350
	private const string FIRST_PERSON_CONFIG_MAP_PATH = "/Game/Aki/Character/Role/Common/Data/DA/DA_FirstPersonConfigMap.DA_FirstPersonConfigMap";

	// Token: 0x0400C897 RID: 51351
	private const float LOW_STRENGTH_EXIT_VALUE = 2200f;

	// Token: 0x0400C898 RID: 51352
	private const float STAND_INPUT_DELAY = 200f;

	// Token: 0x0400C899 RID: 51353
	private const float STAND_INPUT_TURN_THRESHOLD = 0.5f;

	// Token: 0x0400C89A RID: 51354
	private const float FACING_INPUT_THRESHOLD_IN_LOCK_MODE = 60f;

	// Token: 0x0400C89B RID: 51355
	[StaticVariableRuleIgnore]
	private static readonly ESkillGenre[] interruptAutoMoving = new ESkillGenre[]
	{
		ESkillGenre.普攻0,
		ESkillGenre.蓄力1,
		ESkillGenre.E技能2,
		ESkillGenre.大招3,
		ESkillGenre.QTE4,
		ESkillGenre.极限闪避反击5,
		ESkillGenre.极限闪避7,
		ESkillGenre.被动技能8,
		ESkillGenre.战斗幻象技9
	};

	// Token: 0x0400C89C RID: 51356
	[StaticVariableRuleIgnore]
	private static readonly int[] useDelayCacheModeRoleIds = new int[]
	{
		1409,
		1306,
		1410
	};

	// Token: 0x0400C89D RID: 51357
	[StaticVariableRuleIgnore]
	private static readonly Stat GetCommandStat = Stat.Create("CharacterInputComponent.GetCommand", "", "");

	// Token: 0x0400C89E RID: 51358
	[StaticVariableRuleIgnore]
	private static readonly Stat ExecuteCommandStat = Stat.Create("CharacterInputComponent.ExecuteCommand", "", "");

	// Token: 0x0400C89F RID: 51359
	[StaticVariableRuleIgnore]
	private static readonly Stat DispatchPressEventStat = Stat.Create("CharacterInputComponent.DispatchPressEvent", "", "");

	// Token: 0x0400C8A0 RID: 51360
	[StaticVariableRuleIgnore]
	private static readonly Stat DispatchReleaseEventStat = Stat.Create("CharacterInputComponent.DispatchReleaseEvent", "", "");

	// Token: 0x0400C8A1 RID: 51361
	[StaticVariableRuleIgnore]
	private static readonly Stat HandlePressStat = Stat.Create("CharacterInputComponent.HandlePress", "", "");

	// Token: 0x0400C8A2 RID: 51362
	[StaticVariableRuleIgnore]
	private static readonly Stat HandleReleaseStat = Stat.Create("CharacterInputComponent.HandleRelease", "", "");

	// Token: 0x0400C8A3 RID: 51363
	private readonly global::Vector TempVector = global::Vector.Create();

	// Token: 0x0400C8A4 RID: 51364
	private readonly global::Vector TempVector2 = global::Vector.Create();

	// Token: 0x0400C8A5 RID: 51365
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400C8A6 RID: 51366
	private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C8A7 RID: 51367
	private readonly Quat TempQuat2 = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C8A8 RID: 51368
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x0400C8A9 RID: 51369
	[Nullable(2)]
	private CharacterAbilityComponent AbilityComp;

	// Token: 0x0400C8AA RID: 51370
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400C8AB RID: 51371
	[Nullable(2)]
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x0400C8AC RID: 51372
	[Nullable(2)]
	private CharacterSkillComponent SkillComponent;

	// Token: 0x0400C8AD RID: 51373
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400C8AE RID: 51374
	[Nullable(2)]
	private CharacterUnifiedStateComponent UnifiedComp;

	// Token: 0x0400C8AF RID: 51375
	[Nullable(2)]
	private TsBaseCharacter CharacterInternal;

	// Token: 0x0400C8B0 RID: 51376
	[Nullable(2)]
	private BP_CharacterController_C CharacterControllerInternal;

	// Token: 0x0400C8B1 RID: 51377
	[Nullable(2)]
	private CharacterInputLayer InputLayer;

	// Token: 0x0400C8B2 RID: 51378
	[Nullable(2)]
	private ExtraInputLayer ExtraInputLayer;

	// Token: 0x0400C8B3 RID: 51379
	private readonly List<InputEvent> InputEvents = new List<InputEvent>();

	// Token: 0x0400C8B4 RID: 51380
	private readonly List<InputCache> InputCaches = new List<InputCache>();

	// Token: 0x0400C8B5 RID: 51381
	private readonly Dictionary<EInputAxis, float> AxisValues = new Dictionary<EInputAxis, float>();

	// Token: 0x0400C8B6 RID: 51382
	[Nullable(2)]
	private InputFilter InputGroup;

	// Token: 0x0400C8B7 RID: 51383
	private readonly global::Vector MoveVectorCache = global::Vector.Create();

	// Token: 0x0400C8B8 RID: 51384
	private readonly global::Vector MoveDirectionCache = global::Vector.Create();

	// Token: 0x0400C8B9 RID: 51385
	private readonly global::Vector WorldMoveDirectionCache = global::Vector.Create();

	// Token: 0x0400C8BA RID: 51386
	private bool IsLocalInputInternal;

	// Token: 0x0400C8BB RID: 51387
	private bool IsOnlyAllowFightInputInternal;

	// Token: 0x0400C8BC RID: 51388
	private double LastMovementInputTime = -1.0;

	// Token: 0x0400C8BD RID: 51389
	private static Dictionary<CSharpScript.Game.Input.EInputAction, bool> HoldPressMap;

	// Token: 0x0400C8BE RID: 51390
	private readonly Dictionary<ECommandType, double> CommandTimeMap = new Dictionary<ECommandType, double>();

	// Token: 0x0400C8BF RID: 51391
	private bool NeedQueryInputCache;

	// Token: 0x0400C8C0 RID: 51392
	private int? DisableHandle;

	// Token: 0x0400C8C1 RID: 51393
	private bool AutomaticFlightMode;

	// Token: 0x0400C8C2 RID: 51394
	[Nullable(2)]
	private AutomaticFlightData AutomaticFlightDataAsset;

	// Token: 0x0400C8C3 RID: 51395
	private float AutomaticFlightModeTimeCache;

	// Token: 0x0400C8C4 RID: 51396
	private bool CameraDrivenAutoFlightMode;

	// Token: 0x0400C8C5 RID: 51397
	[Nullable(2)]
	private CameraDrivenAutoFlightData CameraDrivenAutoFlightDataAsset;

	// Token: 0x0400C8C6 RID: 51398
	private bool IsInCameraDrivenAutoFlight;

	// Token: 0x0400C8C7 RID: 51399
	private bool IsStartCameraDrivenAutoFlightTick;

	// Token: 0x0400C8C8 RID: 51400
	private float CameraDrivenAutoFlightTime;

	// Token: 0x0400C8C9 RID: 51401
	private float MoveDirectionDistanceMin;

	// Token: 0x0400C8CA RID: 51402
	private float MoveDirectionDistanceMax;

	// Token: 0x0400C8CB RID: 51403
	private float MovementDirectionAngleThreshold;

	// Token: 0x0400C8CC RID: 51404
	private EInputCacheExecuteMode InputCacheExecuteMode = EInputCacheExecuteMode.Normal;

	// Token: 0x0400C8CD RID: 51405
	private float StandInputDelayCountDown;

	// Token: 0x0400C8CE RID: 51406
	private global::Vector CacheStandInputDirect = new global::Vector();

	// Token: 0x0400C8CF RID: 51407
	private bool NextFrameClear;

	// Token: 0x0400C8D0 RID: 51408
	private readonly HashSet<EInputAxis> NextFrameClearAxis = new HashSet<EInputAxis>();

	// Token: 0x0400C8D1 RID: 51409
	private bool LastShowMouseCursor;

	// Token: 0x0400C8D2 RID: 51410
	private readonly List<InputEvent> TestInputEvent = new List<InputEvent>();

	// Token: 0x0400C8D3 RID: 51411
	private readonly Quat CameraInputQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x0400C8D4 RID: 51412
	[Nullable(2)]
	private ITagTask TagEventJump;

	// Token: 0x0400C8D5 RID: 51413
	[Nullable(2)]
	private ITagTask TagEventClimb;

	// Token: 0x0400C8D6 RID: 51414
	[Nullable(2)]
	private ITagTask TagEventAttack;

	// Token: 0x0400C8D7 RID: 51415
	[Nullable(2)]
	private ITagTask TagEventDodge;

	// Token: 0x0400C8D8 RID: 51416
	[Nullable(2)]
	private ITagTask TagEventSkill;

	// Token: 0x0400C8D9 RID: 51417
	[Nullable(2)]
	private ITagTask TagEventVision1;

	// Token: 0x0400C8DA RID: 51418
	[Nullable(2)]
	private ITagTask TagEventUltimateSkill;

	// Token: 0x0400C8DB RID: 51419
	[Nullable(2)]
	private ITagTask TagEventVision2;

	// Token: 0x0400C8DC RID: 51420
	[Nullable(2)]
	private ITagTask TagEventChangeRoll1;

	// Token: 0x0400C8DD RID: 51421
	[Nullable(2)]
	private ITagTask TagEventChangeRoll2;

	// Token: 0x0400C8DE RID: 51422
	[Nullable(2)]
	private ITagTask TagEventChangeRoll3;

	// Token: 0x0400C8DF RID: 51423
	[Nullable(2)]
	private ITagTask TagEventLock;

	// Token: 0x0400C8E0 RID: 51424
	[Nullable(2)]
	private ITagTask TagEventAim;

	// Token: 0x0400C8E1 RID: 51425
	[Nullable(2)]
	private ITagTask TagEventMove;

	// Token: 0x0400C8E2 RID: 51426
	private bool IsMoveAxisToButtonEnabled;

	// Token: 0x0400C8E3 RID: 51427
	private readonly MoveInputSimButtonLogic MoveAxisToButtonLogic = new MoveInputSimButtonLogic();

	// Token: 0x0400C8E4 RID: 51428
	[Nullable(2)]
	private InputActiveCondition MoveAxisToButtonActiveCondition;

	// Token: 0x0400C8E5 RID: 51429
	private readonly Dictionary<CSharpScript.Game.Input.EInputAction, SInputCaches> CacheTimes = new Dictionary<CSharpScript.Game.Input.EInputAction, SInputCaches>();

	// Token: 0x0400C8E6 RID: 51430
	private readonly Dictionary<CSharpScript.Game.Input.EInputAction, SInputHoldConfig> HoldConfigs = new Dictionary<CSharpScript.Game.Input.EInputAction, SInputHoldConfig>();

	// Token: 0x0400C8E7 RID: 51431
	private bool InCameraFollowInput;

	// Token: 0x0400C8E8 RID: 51432
	private readonly List<ITagTask> CameraFollowInputTagTasks = new List<ITagTask>();

	// Token: 0x0400C8E9 RID: 51433
	private readonly Dictionary<int, string> TagToDaPathMap = new Dictionary<int, string>();

	// Token: 0x0400C8EA RID: 51434
	private bool CameraFollowInputLockRunState;

	// Token: 0x0400C8EB RID: 51435
	private bool CameraFollowInputInSprintState;

	// Token: 0x0400C8EC RID: 51436
	[Nullable(2)]
	private CameraFollowInputConfig CameraFollowInputConfig;

	// Token: 0x0400C8ED RID: 51437
	[Nullable(2)]
	private InputContinuously AutoMovingConfigInternal;

	// Token: 0x0400C8EE RID: 51438
	private float AutoSprintTime;

	// Token: 0x0400C8EF RID: 51439
	private float AutoSprintConfigTime;

	// Token: 0x0400C8F0 RID: 51440
	private bool IsOverShoulderMode;

	// Token: 0x0400C8F1 RID: 51441
	private bool IsOverShoulderSprint;

	// Token: 0x0400C8F2 RID: 51442
	[Nullable(2)]
	private ITagTask ChangeOverShoulderSprintMode;

	// Token: 0x0400C8F3 RID: 51443
	[Nullable(2)]
	private OverShoulderModeConfig OverShoulderConfig;

	// Token: 0x0400C8F4 RID: 51444
	private global::Vector LastCameraDir = global::Vector.Create();
}
