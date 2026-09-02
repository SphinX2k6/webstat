using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Input
{
	// Token: 0x02006FD4 RID: 28628
	public class InputSystemComponent : IInputHandler
	{
		// Token: 0x06045450 RID: 283728 RVA: 0x01218268 File Offset: 0x01216468
		public InputSystemComponent()
		{
			this.SetNormalAction();
		}

		// Token: 0x06045451 RID: 283729 RVA: 0x01218284 File Offset: 0x01216484
		public void ReceiveBeginPlay()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UnBlockCharacterAction, new Action(this.UnBlockCharacterEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetSystemAction, new Action(this.ResetSystemActionEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.ResetNormalAction, new Action(this.ResetNormalActionEvent));
		}

		// Token: 0x06045452 RID: 283730 RVA: 0x012182DC File Offset: 0x012164DC
		public void ReceiveEndPlay()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UnBlockCharacterAction, new Action(this.UnBlockCharacterEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetSystemAction, new Action(this.ResetSystemActionEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.ResetNormalAction, new Action(this.ResetNormalActionEvent));
		}

		// Token: 0x06045453 RID: 283731 RVA: 0x01218334 File Offset: 0x01216534
		private void UnBlockCharacterEvent()
		{
			this.InputGroup = new InputFilter(null, null, null, null);
		}

		// Token: 0x06045454 RID: 283732 RVA: 0x01218345 File Offset: 0x01216545
		private void ResetSystemActionEvent()
		{
			this.SetCurrentSystemAction();
		}

		// Token: 0x06045455 RID: 283733 RVA: 0x01218350 File Offset: 0x01216550
		protected void SetInputActionList(EInputAction action, EUiViewName uiViewName)
		{
			HashSet<EInputAction> hashSet = new HashSet<EInputAction>();
			if (action != EInputAction.None)
			{
				hashSet.Add(action);
			}
			HashSet<EInputAction> hashSet2;
			if (InputFilterManager.CharacterSystemViewActions.TryGetValue(uiViewName, out hashSet2))
			{
				foreach (EInputAction item in hashSet2)
				{
					hashSet.Add(item);
				}
			}
			this.InputActionViewsMap[uiViewName] = hashSet;
		}

		// Token: 0x06045456 RID: 283734 RVA: 0x012183D8 File Offset: 0x012165D8
		protected void SetCurrentSystemAction()
		{
			HashSet<EInputAction> hashSet = new HashSet<EInputAction>();
			foreach (HashSet<EInputAction> hashSet2 in this.InputActionViewsMap.Values)
			{
				foreach (EInputAction item in hashSet2)
				{
					hashSet.Add(item);
				}
			}
			this.InputGroup = new InputFilter(hashSet, InputFilterManager.CharacterActions, null, InputFilterManager.CharacterAxes);
		}

		// Token: 0x06045457 RID: 283735 RVA: 0x01218484 File Offset: 0x01216684
		private void ResetNormalActionEvent()
		{
			this.SetNormalAction();
		}

		// Token: 0x06045458 RID: 283736 RVA: 0x0121848C File Offset: 0x0121668C
		protected void SetNormalAction()
		{
			HashSet<EInputAction> hashSet = new HashSet<EInputAction>();
			foreach (EInputAction item in InputFilterManager.CharacterSystemActions.Keys)
			{
				hashSet.Add(item);
			}
			this.InputGroup = new InputFilter(hashSet, null, null, null);
		}

		// Token: 0x06045459 RID: 283737 RVA: 0x012184FC File Offset: 0x012166FC
		public int GetPriority()
		{
			return 1;
		}

		// Token: 0x0604545A RID: 283738 RVA: 0x012184FF File Offset: 0x012166FF
		[NullableContext(1)]
		public InputFilter GetInputFilter()
		{
			return this.InputGroup;
		}

		// Token: 0x0604545B RID: 283739 RVA: 0x01218508 File Offset: 0x01216708
		public void HandlePressEvent(EInputAction action, float time)
		{
			EUiViewName p;
			if (InputFilterManager.CharacterSystemActions.TryGetValue(action, out p))
			{
				Singleton<EventSystem>.Instance.Emit<EUiViewName>(EEventName.HotKeyInput, p);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<EInputAction>(EEventName.ViewHotKeyInputPress, action);
		}

		// Token: 0x0604545C RID: 283740 RVA: 0x01218544 File Offset: 0x01216744
		public void HandleReleaseEvent(EInputAction action, float time)
		{
			EUiViewName euiViewName;
			if (InputFilterManager.CharacterSystemActions.TryGetValue(action, out euiViewName))
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<EInputAction>(EEventName.ViewHotKeyInputRelease, action);
		}

		// Token: 0x0604545D RID: 283741 RVA: 0x0121856F File Offset: 0x0121676F
		public void HandleHoldEvent(EInputAction action, float time)
		{
		}

		// Token: 0x0604545E RID: 283742 RVA: 0x01218571 File Offset: 0x01216771
		public void HandleInputAxis(EInputAxis axis, float value)
		{
		}

		// Token: 0x0604545F RID: 283743 RVA: 0x01218573 File Offset: 0x01216773
		public void ClearInputAxis(bool nextFrame)
		{
		}

		// Token: 0x06045460 RID: 283744 RVA: 0x01218575 File Offset: 0x01216775
		public void ClearSingleAxisInput(EInputAxis axis, bool nextFrame)
		{
		}

		// Token: 0x06045461 RID: 283745 RVA: 0x01218577 File Offset: 0x01216777
		public void PreProcessInput(float deltaTime, bool gamePaused)
		{
		}

		// Token: 0x06045462 RID: 283746 RVA: 0x01218579 File Offset: 0x01216779
		public void PostProcessInput(float deltaTime, bool gamePaused)
		{
		}

		// Token: 0x04026A80 RID: 158336
		[Nullable(2)]
		private InputFilter InputGroup;

		// Token: 0x04026A81 RID: 158337
		[Nullable(1)]
		private readonly Dictionary<EUiViewName, HashSet<EInputAction>> InputActionViewsMap = new Dictionary<EUiViewName, HashSet<EInputAction>>();
	}
}
