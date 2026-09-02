using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

// Token: 0x02000E9E RID: 3742
[NullableContext(1)]
public interface IInputHandler
{
	// Token: 0x06005C57 RID: 23639
	int GetPriority();

	// Token: 0x06005C58 RID: 23640
	InputFilter GetInputFilter();

	// Token: 0x06005C59 RID: 23641
	void HandlePressEvent(EInputAction action, float time);

	// Token: 0x06005C5A RID: 23642
	void HandleReleaseEvent(EInputAction action, float time);

	// Token: 0x06005C5B RID: 23643
	void HandleHoldEvent(EInputAction action, float time);

	// Token: 0x06005C5C RID: 23644
	void HandleInputAxis(EInputAxis axis, float value);

	// Token: 0x06005C5D RID: 23645
	void ClearInputAxis(bool nextFrame);

	// Token: 0x06005C5E RID: 23646
	void ClearSingleAxisInput(EInputAxis axis, bool nextFrame);

	// Token: 0x06005C5F RID: 23647
	void PreProcessInput(float deltaTime, bool gamePaused);

	// Token: 0x06005C60 RID: 23648
	void PostProcessInput(float deltaTime, bool gamePaused);
}
