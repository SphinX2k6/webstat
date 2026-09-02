using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;

// Token: 0x02001875 RID: 6261
public class ComboTeachingInputHandler : IInputHandler
{
	// Token: 0x0600B360 RID: 45920 RVA: 0x002FDC9D File Offset: 0x002FBE9D
	public int GetPriority()
	{
		return 1;
	}

	// Token: 0x0600B361 RID: 45921 RVA: 0x002FDCA0 File Offset: 0x002FBEA0
	[NullableContext(1)]
	public InputFilter GetInputFilter()
	{
		if (this.InputFilter == null)
		{
			this.InputFilter = new InputFilter(new EInputAction[]
			{
				EInputAction.攻击,
				EInputAction.大招,
				EInputAction.跳跃,
				EInputAction.闪避,
				EInputAction.技能1,
				EInputAction.瞄准
			}, null, null, null);
		}
		return this.InputFilter;
	}

	// Token: 0x0600B362 RID: 45922 RVA: 0x002FDD17 File Offset: 0x002FBF17
	public void HandlePressEvent(EInputAction action, float time)
	{
		Singleton<EventSystem>.Instance.Emit<EInputAction, float>(EEventName.ComboTeachingPress, action, time);
	}

	// Token: 0x0600B363 RID: 45923 RVA: 0x002FDD2B File Offset: 0x002FBF2B
	public void HandleReleaseEvent(EInputAction action, float time)
	{
		Singleton<EventSystem>.Instance.Emit<EInputAction, float>(EEventName.ComboTeachingRelease, action, time);
	}

	// Token: 0x0600B364 RID: 45924 RVA: 0x002FDD3F File Offset: 0x002FBF3F
	public void HandleHoldEvent(EInputAction action, float time)
	{
		Singleton<EventSystem>.Instance.Emit<EInputAction, float>(EEventName.ComboTeachingHold, action, time);
	}

	// Token: 0x0600B365 RID: 45925 RVA: 0x002FDD53 File Offset: 0x002FBF53
	public void HandleInputAxis(EInputAxis axis, float value)
	{
	}

	// Token: 0x0600B366 RID: 45926 RVA: 0x002FDD55 File Offset: 0x002FBF55
	public void ClearInputAxis(bool nextFrame)
	{
	}

	// Token: 0x0600B367 RID: 45927 RVA: 0x002FDD57 File Offset: 0x002FBF57
	public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
	{
	}

	// Token: 0x0600B368 RID: 45928 RVA: 0x002FDD59 File Offset: 0x002FBF59
	public void PreProcessInput(float deltaTime, bool gamePaused)
	{
	}

	// Token: 0x0600B369 RID: 45929 RVA: 0x002FDD5B File Offset: 0x002FBF5B
	public void PostProcessInput(float deltaTime, bool gamePaused)
	{
	}

	// Token: 0x040054EB RID: 21739
	[Nullable(2)]
	public InputFilter InputFilter;
}
