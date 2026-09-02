using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Input;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FCE RID: 24526
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillInputHandler : IInputHandler
	{
		// Token: 0x0603DABE RID: 252606 RVA: 0x00FB6524 File Offset: 0x00FB4724
		[NullableContext(1)]
		public void InitCallback(Action<EInputAction> pressCallback, Action<EInputAction> releaseCallback)
		{
			this.PressCallback = pressCallback;
			this.ReleaseCallback = releaseCallback;
		}

		// Token: 0x0603DABF RID: 252607 RVA: 0x00FB6534 File Offset: 0x00FB4734
		public void SetActionType(EInputAction actionType)
		{
			this.InputFilter.Actions.Clear();
			this.InputFilter.Actions.Add(actionType);
		}

		// Token: 0x0603DAC0 RID: 252608 RVA: 0x00FB6558 File Offset: 0x00FB4758
		public void AddActionTypes(List<EInputAction> actionTypes)
		{
			if (actionTypes != null)
			{
				foreach (EInputAction item in actionTypes)
				{
					this.InputFilter.Actions.Add(item);
				}
			}
		}

		// Token: 0x0603DAC1 RID: 252609 RVA: 0x00FB65B4 File Offset: 0x00FB47B4
		public int GetPriority()
		{
			return 1;
		}

		// Token: 0x0603DAC2 RID: 252610 RVA: 0x00FB65B7 File Offset: 0x00FB47B7
		[NullableContext(1)]
		public InputFilter GetInputFilter()
		{
			return this.InputFilter;
		}

		// Token: 0x0603DAC3 RID: 252611 RVA: 0x00FB65BF File Offset: 0x00FB47BF
		public void HandlePressEvent(EInputAction action, float time)
		{
			Action<EInputAction> pressCallback = this.PressCallback;
			if (pressCallback == null)
			{
				return;
			}
			pressCallback(action);
		}

		// Token: 0x0603DAC4 RID: 252612 RVA: 0x00FB65D2 File Offset: 0x00FB47D2
		public void HandleReleaseEvent(EInputAction action, float time)
		{
			Action<EInputAction> releaseCallback = this.ReleaseCallback;
			if (releaseCallback == null)
			{
				return;
			}
			releaseCallback(action);
		}

		// Token: 0x0603DAC5 RID: 252613 RVA: 0x00FB65E5 File Offset: 0x00FB47E5
		public void HandleHoldEvent(EInputAction action, float time)
		{
		}

		// Token: 0x0603DAC6 RID: 252614 RVA: 0x00FB65E7 File Offset: 0x00FB47E7
		public void HandleInputAxis(EInputAxis axis, float value)
		{
		}

		// Token: 0x0603DAC7 RID: 252615 RVA: 0x00FB65E9 File Offset: 0x00FB47E9
		public void ClearInputAxis(bool nextFrame)
		{
		}

		// Token: 0x0603DAC8 RID: 252616 RVA: 0x00FB65EB File Offset: 0x00FB47EB
		public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
		{
		}

		// Token: 0x0603DAC9 RID: 252617 RVA: 0x00FB65ED File Offset: 0x00FB47ED
		public void PreProcessInput(float deltaTime, bool gamePaused)
		{
		}

		// Token: 0x0603DACA RID: 252618 RVA: 0x00FB65EF File Offset: 0x00FB47EF
		public void PostProcessInput(float deltaTime, bool gamePaused)
		{
		}

		// Token: 0x040229D0 RID: 141776
		public InputFilter InputFilter = new InputFilter(Array.Empty<EInputAction>(), null, null, null);

		// Token: 0x040229D1 RID: 141777
		private Action<EInputAction> PressCallback;

		// Token: 0x040229D2 RID: 141778
		private Action<EInputAction> ReleaseCallback;
	}
}
