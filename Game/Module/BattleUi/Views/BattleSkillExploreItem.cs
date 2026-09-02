using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC9 RID: 24521
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillExploreItem : BattleSkillItem
	{
		// Token: 0x0603DA8B RID: 252555 RVA: 0x00FB5A24 File Offset: 0x00FB3C24
		protected override UUIButtonComponent GetPointEventButton()
		{
			return this.CustomPointEventButton;
		}

		// Token: 0x0603DA8C RID: 252556 RVA: 0x00FB5A2C File Offset: 0x00FB3C2C
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(13, typeof(UUIButtonComponent)));
		}

		// Token: 0x0603DA8D RID: 252557 RVA: 0x00FB5A50 File Offset: 0x00FB3C50
		public override void Initialize(object param = null)
		{
			this.CustomPointEventButton = base.GetButton(13);
			Singleton<EventSystem>.Instance.Add(EEventName.GuideTouchIdInject, new Action<int, AActor>(this.OnGuideTouchIdInject));
			base.Initialize(param);
		}

		// Token: 0x0603DA8E RID: 252558 RVA: 0x00FB5A83 File Offset: 0x00FB3C83
		public override void Reset()
		{
			this.CustomPointEventButton = null;
			Singleton<EventSystem>.Instance.Remove(EEventName.GuideTouchIdInject, new Action<int, AActor>(this.OnGuideTouchIdInject));
			base.Reset();
		}

		// Token: 0x0603DA8F RID: 252559 RVA: 0x00FB5AAE File Offset: 0x00FB3CAE
		[NullableContext(1)]
		private void OnGuideTouchIdInject(int touchId, AActor actor)
		{
			if (this.IsLongPress)
			{
				return;
			}
			if (this.CustomPointEventButton.GetOwner() == actor)
			{
				this.LongPressTouchId = new int?(touchId);
			}
		}

		// Token: 0x0603DA90 RID: 252560 RVA: 0x00FB5AD4 File Offset: 0x00FB3CD4
		[NullableContext(1)]
		protected override void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
		{
			if (this.IsLongPress)
			{
				return;
			}
			int num = int.Parse(touchIdName);
			TouchFingerData touchFingerData = Singleton<TouchFingerManager>.Instance.GetTouchFingerData((EFingerIndex)num);
			USceneComponent usceneComponent;
			if (touchFingerData == null)
			{
				usceneComponent = null;
			}
			else
			{
				ULGUIPointerEventData pointerEventData = touchFingerData.GetPointerEventData();
				usceneComponent = ((pointerEventData != null) ? pointerEventData.pressComponent : null);
			}
			USceneComponent usceneComponent2 = usceneComponent;
			if (usceneComponent2 == null)
			{
				return;
			}
			if (usceneComponent2.GetOwner() != this.CustomPointEventButton.GetOwner())
			{
				return;
			}
			this.LongPressTouchId = new int?(num);
		}

		// Token: 0x0603DA91 RID: 252561 RVA: 0x00FB5B39 File Offset: 0x00FB3D39
		protected override bool IsNeedLongPress()
		{
			return this.SkillButtonData.IsEnableLongPress();
		}

		// Token: 0x0603DA92 RID: 252562 RVA: 0x00FB5B46 File Offset: 0x00FB3D46
		protected override void OnSkillButtonPressed()
		{
			ModelBase<BattleUiModel>.Instance.IsLongPressExploreButton = false;
			base.OnSkillButtonPressed();
		}

		// Token: 0x0603DA93 RID: 252563 RVA: 0x00FB5B59 File Offset: 0x00FB3D59
		protected override void OnLongPressButton()
		{
			base.OnLongPressButton();
			ModelBase<BattleUiModel>.Instance.IsLongPressExploreButton = true;
			if (this.LongPressTouchId != null)
			{
				this.OpenRouletteMainView(this.LongPressTouchId.Value);
				this.LongPressTouchId = null;
			}
		}

		// Token: 0x0603DA94 RID: 252564 RVA: 0x00FB5B98 File Offset: 0x00FB3D98
		protected virtual void OpenRouletteMainView(int touchId)
		{
			RouletteMainViewProxyBase currentRouletteMainViewProxy = ControllerBase<RouletteController>.Instance.GetCurrentRouletteMainViewProxy();
			currentRouletteMainViewProxy.TouchId = new int?(touchId);
			ControllerBase<RouletteController>.Instance.OpenRouletteMainView(currentRouletteMainViewProxy);
		}

		// Token: 0x040229BC RID: 141756
		private UUIButtonComponent CustomPointEventButton;

		// Token: 0x040229BD RID: 141757
		private int? LongPressTouchId;

		// Token: 0x0200C037 RID: 49207
		[NullableContext(0)]
		private enum EBattleSkillExploreItem
		{
			// Token: 0x0403B2BE RID: 242366
			PointEventButton = 13
		}
	}
}
