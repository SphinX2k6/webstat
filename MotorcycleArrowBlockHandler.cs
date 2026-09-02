using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

// Token: 0x02000F4A RID: 3914
public class MotorcycleArrowBlockHandler : IInputHandler
{
	// Token: 0x06006247 RID: 25159 RVA: 0x00189301 File Offset: 0x00187501
	public void Init()
	{
	}

	// Token: 0x06006248 RID: 25160 RVA: 0x00189303 File Offset: 0x00187503
	public int GetPriority()
	{
		return 99;
	}

	// Token: 0x06006249 RID: 25161 RVA: 0x00189307 File Offset: 0x00187507
	[NullableContext(1)]
	public InputFilter GetInputFilter()
	{
		return new InputFilter(null, InputFilterManager.CharacterActions, null, InputFilterManager.CharacterAxes);
	}

	// Token: 0x0600624A RID: 25162 RVA: 0x0018931A File Offset: 0x0018751A
	public void HandlePressEvent(EInputAction action, float time)
	{
	}

	// Token: 0x0600624B RID: 25163 RVA: 0x0018931C File Offset: 0x0018751C
	public void HandleReleaseEvent(EInputAction action, float time)
	{
	}

	// Token: 0x0600624C RID: 25164 RVA: 0x0018931E File Offset: 0x0018751E
	public void HandleHoldEvent(EInputAction action, float time)
	{
	}

	// Token: 0x0600624D RID: 25165 RVA: 0x00189320 File Offset: 0x00187520
	public void HandleInputAxis(EInputAxis axis, float value)
	{
	}

	// Token: 0x0600624E RID: 25166 RVA: 0x00189322 File Offset: 0x00187522
	public void ClearInputAxis(bool nextFrame)
	{
	}

	// Token: 0x0600624F RID: 25167 RVA: 0x00189324 File Offset: 0x00187524
	public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
	{
	}

	// Token: 0x06006250 RID: 25168 RVA: 0x00189326 File Offset: 0x00187526
	public void PreProcessInput(float deltaTime, bool gamePaused)
	{
	}

	// Token: 0x06006251 RID: 25169 RVA: 0x00189328 File Offset: 0x00187528
	public void PostProcessInput(float deltaTime, bool gamePaused)
	{
	}

	// Token: 0x04002F0F RID: 12047
	private const int MOTORARROW_BLOCK_PRIORITY = 99;
}
