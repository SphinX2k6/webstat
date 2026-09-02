using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Game.Input;

// Token: 0x02000F49 RID: 3913
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowInputHandler : IInputHandler
{
	// Token: 0x0600623A RID: 25146 RVA: 0x00189148 File Offset: 0x00187348
	public void Init()
	{
		this.InputGroup = new InputFilter(InputFilterManager.CharacterActions, null, InputFilterManager.CharacterAxes, null);
	}

	// Token: 0x0600623B RID: 25147 RVA: 0x00189161 File Offset: 0x00187361
	public int GetPriority()
	{
		return 100;
	}

	// Token: 0x0600623C RID: 25148 RVA: 0x00189165 File Offset: 0x00187365
	public InputFilter GetInputFilter()
	{
		if (this.InputGroup == null)
		{
			this.Init();
		}
		return this.InputGroup;
	}

	// Token: 0x0600623D RID: 25149 RVA: 0x0018917C File Offset: 0x0018737C
	public void HandlePressEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
		BattleInputModel instance = ModelBase<BattleInputModel>.Instance;
		if (instance == null || !instance.GetInputEnable(action))
		{
			return;
		}
		InputEvent inputEvent = new InputEvent(action, EInputState.Press, time, 0f);
		InputEvent inputEvent2 = inputEvent;
		int inputEventIdCounter = this.InputEventIdCounter;
		this.InputEventIdCounter = inputEventIdCounter + 1;
		inputEvent2.Id = inputEventIdCounter;
		this.InputEvents.Add(inputEvent);
	}

	// Token: 0x0600623E RID: 25150 RVA: 0x001891D2 File Offset: 0x001873D2
	public void HandleReleaseEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
	}

	// Token: 0x0600623F RID: 25151 RVA: 0x001891D4 File Offset: 0x001873D4
	public void HandleHoldEvent(CSharpScript.Game.Input.EInputAction action, float time)
	{
	}

	// Token: 0x06006240 RID: 25152 RVA: 0x001891D6 File Offset: 0x001873D6
	public void HandleInputAxis(EInputAxis axis, float value)
	{
		if (axis == EInputAxis.MoveRight)
		{
			this.AxisValues[axis] = value;
		}
	}

	// Token: 0x06006241 RID: 25153 RVA: 0x001891F2 File Offset: 0x001873F2
	public void ClearInputAxis(bool nextFrame)
	{
		this.AxisValues.Clear();
	}

	// Token: 0x06006242 RID: 25154 RVA: 0x001891FF File Offset: 0x001873FF
	public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
	{
		if (this.AxisValues.ContainsKey(axis))
		{
			this.AxisValues.Remove(axis);
		}
	}

	// Token: 0x06006243 RID: 25155 RVA: 0x0018921C File Offset: 0x0018741C
	public void PreProcessInput(float deltaTime, bool gamePaused)
	{
	}

	// Token: 0x06006244 RID: 25156 RVA: 0x00189220 File Offset: 0x00187420
	public void PostProcessInput(float deltaTime, bool gamePaused)
	{
		MotorcycleArrowSubController controller = this.GetController();
		if (controller == null)
		{
			return;
		}
		float num;
		float rightInput = this.AxisValues.TryGetValue(EInputAxis.MoveRight, out num) ? num : 0f;
		controller.MoveRight(rightInput, deltaTime);
		using (List<InputEvent>.Enumerator enumerator = this.InputEvents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Action == CSharpScript.Game.Input.EInputAction.跳跃)
				{
					controller.ExecSkillAction();
				}
			}
		}
		this.InputEvents.Clear();
	}

	// Token: 0x06006245 RID: 25157 RVA: 0x001892C0 File Offset: 0x001874C0
	[NullableContext(2)]
	public MotorcycleArrowSubController GetController()
	{
		KscSubControllerBase curSubController = ControllerBase<KuroSimpleCombatController>.Instance.CurSubController;
		if (curSubController == null)
		{
			return null;
		}
		return curSubController as MotorcycleArrowSubController;
	}

	// Token: 0x04002F0A RID: 12042
	private const int MOTORARROW_PRIORITY = 100;

	// Token: 0x04002F0B RID: 12043
	[Nullable(2)]
	protected InputFilter InputGroup;

	// Token: 0x04002F0C RID: 12044
	protected readonly Dictionary<EInputAxis, float> AxisValues = new Dictionary<EInputAxis, float>();

	// Token: 0x04002F0D RID: 12045
	private readonly List<InputEvent> InputEvents = new List<InputEvent>();

	// Token: 0x04002F0E RID: 12046
	private int InputEventIdCounter;
}
