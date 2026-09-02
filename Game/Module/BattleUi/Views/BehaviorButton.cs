using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FE6 RID: 24550
	[NullableContext(2)]
	[Nullable(0)]
	public class BehaviorButton : BattleChildView
	{
		// Token: 0x0603DC8D RID: 253069 RVA: 0x00FBED14 File Offset: 0x00FBCF14
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DC8E RID: 253070 RVA: 0x00FBEDE8 File Offset: 0x00FBCFE8
		public override void Initialize(object paramsObj = null)
		{
			base.Initialize(paramsObj);
			if (paramsObj is EBehaviorType)
			{
				EBehaviorType behaviorType = (EBehaviorType)paramsObj;
				this.BehaviorType = behaviorType;
				this.AddEvents();
				UUISprite sprite = base.GetSprite(1);
				this.SpriteTransition = (sprite.GetOwner().GetComponentByClass(UUISpriteTransition.StaticClass()) as UUISpriteTransition);
				this.ClickEffect = new BattleUiNiagaraItem(base.GetUiNiagara(2));
				this.DynamicEffect = new BattleSkillItemDynamicEffect(base.GetUiNiagara(3));
				return;
			}
			throw new InvalidCastException();
		}

		// Token: 0x0603DC8F RID: 253071 RVA: 0x00FBEE6C File Offset: 0x00FBD06C
		protected override UniTask InitializeAsync(object param = null)
		{
			BehaviorButton.<InitializeAsync>d__16 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<BehaviorButton.<InitializeAsync>d__16>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DC90 RID: 253072 RVA: 0x00FBEEB0 File Offset: 0x00FBD0B0
		protected override void OnBeforeDestroy()
		{
			this.BehaviorButtonData = null;
			this.KeyItem = null;
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect != null)
			{
				clickEffect.Stop();
			}
			this.ClickEffect = null;
			if (this.LoadIconHandleId != null)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconHandleId.Value);
				this.LoadIconHandleId = null;
			}
			BattleSkillItemDynamicEffect dynamicEffect = this.DynamicEffect;
			if (dynamicEffect != null)
			{
				dynamicEffect.Reset();
			}
			this.DynamicEffect = null;
			this.RemoveEvents();
			this.AlphaTweenComp = null;
			this.OnVisibleChangedCallback = null;
		}

		// Token: 0x0603DC91 RID: 253073 RVA: 0x00FBEF3D File Offset: 0x00FBD13D
		private void AddEvents()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Bind(new Action(this.OnPressBehaviorButton));
			button.OnPointUpCallBack.Bind(new Action(this.OnReleaseBehaviorButton));
		}

		// Token: 0x0603DC92 RID: 253074 RVA: 0x00FBEF73 File Offset: 0x00FBD173
		private void RemoveEvents()
		{
			UUIButtonComponent button = base.GetButton(0);
			button.OnPointDownCallBack.Unbind();
			button.OnPointUpCallBack.Unbind();
		}

		// Token: 0x0603DC93 RID: 253075 RVA: 0x00FBEF91 File Offset: 0x00FBD191
		public void UpdateAlpha()
		{
			this.BaseAlpha = this.RootItem.GetAlpha();
			if (this.BaseAlpha > this.TargetAlpha)
			{
				this.RootItem.SetAlpha(this.TargetAlpha);
				return;
			}
			this.TargetAlpha = this.BaseAlpha;
		}

		// Token: 0x0603DC94 RID: 253076 RVA: 0x00FBEFD0 File Offset: 0x00FBD1D0
		private void OnPressBehaviorButton()
		{
			if (this.TargetAlpha == 0f)
			{
				return;
			}
			BehaviorButtonData behaviorButtonData = this.BehaviorButtonData;
			CSharpScript.Game.Input.EInputAction? einputAction = (behaviorButtonData != null) ? new CSharpScript.Game.Input.EInputAction?(behaviorButtonData.InputAction) : null;
			if (einputAction != null)
			{
				this.InputAction(einputAction.Value, EInputState.Press);
			}
			Singleton<EventSystem>.Instance.Emit<bool, EBehaviorType>(EEventName.OnPressOrReleaseBehaviorButton, true, this.BehaviorType);
		}

		// Token: 0x0603DC95 RID: 253077 RVA: 0x00FBF03C File Offset: 0x00FBD23C
		private void OnReleaseBehaviorButton()
		{
			BehaviorButtonData behaviorButtonData = this.BehaviorButtonData;
			CSharpScript.Game.Input.EInputAction? einputAction = (behaviorButtonData != null) ? new CSharpScript.Game.Input.EInputAction?(behaviorButtonData.InputAction) : null;
			if (einputAction != null)
			{
				this.InputAction(einputAction.Value, EInputState.Release);
			}
			Singleton<EventSystem>.Instance.Emit<bool, EBehaviorType>(EEventName.OnPressOrReleaseBehaviorButton, false, this.BehaviorType);
		}

		// Token: 0x0603DC96 RID: 253078 RVA: 0x00FBF097 File Offset: 0x00FBD297
		[NullableContext(1)]
		public void Refresh(BehaviorButtonData behaviorButtonData)
		{
			this.BehaviorButtonData = behaviorButtonData;
			this.RefreshVisible();
			this.RefreshEnable(true);
			this.RefreshSkillIcon();
			this.RefreshDynamicEffect();
			this.RefreshKey();
		}

		// Token: 0x0603DC97 RID: 253079 RVA: 0x00FBF0BF File Offset: 0x00FBD2BF
		public void RefreshAll()
		{
			if (this.BehaviorButtonData == null)
			{
				return;
			}
			this.Refresh(this.BehaviorButtonData);
		}

		// Token: 0x0603DC98 RID: 253080 RVA: 0x00FBF0D6 File Offset: 0x00FBD2D6
		private void InputAction(CSharpScript.Game.Input.EInputAction inputAction, EInputState inputState)
		{
			this.OnInputAction();
			ControllerBase<InputController>.Instance.InputAction(inputAction, inputState);
		}

		// Token: 0x0603DC99 RID: 253081 RVA: 0x00FBF0EA File Offset: 0x00FBD2EA
		public void OnInputAction()
		{
			if (this.TargetAlpha == 0f)
			{
				return;
			}
			BattleUiNiagaraItem clickEffect = this.ClickEffect;
			if (clickEffect == null)
			{
				return;
			}
			clickEffect.Play();
		}

		// Token: 0x0603DC9A RID: 253082 RVA: 0x00FBF10C File Offset: 0x00FBD30C
		public void RefreshSkillIcon()
		{
			if (this.BehaviorButtonData == null)
			{
				return;
			}
			string skillTexturePath = this.BehaviorButtonData.GetSkillTexturePath();
			this.SetSkillIcon(skillTexturePath);
		}

		// Token: 0x0603DC9B RID: 253083 RVA: 0x00FBF138 File Offset: 0x00FBD338
		[NullableContext(1)]
		private void SetSkillIcon(string skillIconPath)
		{
			if (string.IsNullOrEmpty(skillIconPath))
			{
				return;
			}
			if (this.SkillIconPath == skillIconPath)
			{
				return;
			}
			if (this.LoadIconHandleId != null)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconHandleId.Value);
			}
			UUISprite skillSprite = base.GetSprite(1);
			bool loading = true;
			this.LoadIconHandleId = new int?(Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(skillIconPath, delegate([Nullable(2)] ULGUISpriteData_BaseObject skillIconSprite, string _)
			{
				loading = false;
				this.LoadIconHandleId = null;
				if (skillSprite == null)
				{
					return;
				}
				if (skillIconSprite == null)
				{
					return;
				}
				skillSprite.SetSprite(skillIconSprite, false);
				if (!skillSprite.bIsUIActive)
				{
					skillSprite.SetUIActive(true);
				}
				if (this.SpriteTransition != null)
				{
					this.SpriteTransition.SetAllTransitionSprite(skillIconSprite);
				}
			}, 100, "js_undefined"));
			this.SkillIconPath = skillIconPath;
			if (!loading)
			{
				this.LoadIconHandleId = null;
			}
		}

		// Token: 0x0603DC9C RID: 253084 RVA: 0x00FBF1E4 File Offset: 0x00FBD3E4
		public void RefreshVisible()
		{
			UUIItem rootItem = this.RootItem;
			if (rootItem == null || !rootItem.IsValid())
			{
				return;
			}
			bool flag = this.IsVisible();
			if (flag == this.RootItem.bIsUIActive)
			{
				return;
			}
			if (flag)
			{
				base.Show(null);
				this.RefreshEnable(true);
			}
			else
			{
				base.Hide(null);
			}
			Action onVisibleChangedCallback = this.OnVisibleChangedCallback;
			if (onVisibleChangedCallback == null)
			{
				return;
			}
			onVisibleChangedCallback();
		}

		// Token: 0x0603DC9D RID: 253085 RVA: 0x00FBF249 File Offset: 0x00FBD449
		public bool IsVisible()
		{
			return this.BehaviorButtonData != null && (this.BehaviorType != EBehaviorType.LockTarget || ModelBase<FunctionModel>.Instance.IsOpen(10031)) && this.BehaviorButtonData.IsVisible();
		}

		// Token: 0x0603DC9E RID: 253086 RVA: 0x00FBF27D File Offset: 0x00FBD47D
		public void RefreshEnable(bool bForce)
		{
		}

		// Token: 0x0603DC9F RID: 253087 RVA: 0x00FBF280 File Offset: 0x00FBD480
		public void SetVisibleByExploreMode(bool visible, bool anim = false)
		{
			bool raycastTarget = false;
			if (visible)
			{
				this.TargetAlpha = this.BaseAlpha;
				raycastTarget = true;
			}
			else
			{
				this.TargetAlpha = 0f;
			}
			if (this.RootItem == null)
			{
				return;
			}
			this.RootItem.SetRaycastTarget(raycastTarget);
			if (!anim)
			{
				if (this.AlphaTweenComp != null)
				{
					this.AlphaTweenComp.Stop();
				}
				this.RootItem.SetAlpha(this.TargetAlpha);
				return;
			}
			if (this.AlphaTweenComp == null)
			{
				this.AlphaTweenComp = (this.RootActor.GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			}
			else
			{
				this.AlphaTweenComp.Stop();
			}
			ULGUIPlayTween_Float ulguiplayTween_Float = this.AlphaTweenComp.GetPlayTween() as ULGUIPlayTween_Float;
			ulguiplayTween_Float.from = this.RootItem.GetAlpha();
			ulguiplayTween_Float.to = this.TargetAlpha;
			this.AlphaTweenComp.Play();
		}

		// Token: 0x0603DCA0 RID: 253088 RVA: 0x00FBF356 File Offset: 0x00FBD556
		[NullableContext(1)]
		public void SetOnVisibleChangedCallback(Action callback)
		{
			this.OnVisibleChangedCallback = callback;
		}

		// Token: 0x0603DCA1 RID: 253089 RVA: 0x00FBF360 File Offset: 0x00FBD560
		public void RefreshDynamicEffect()
		{
			SkillButtonEffect? dynamicEffectConfig = this.GetDynamicEffectConfig();
			BattleSkillItemDynamicEffect dynamicEffect = this.DynamicEffect;
			if (dynamicEffect == null)
			{
				return;
			}
			dynamicEffect.RefreshDynamicEffect(dynamicEffectConfig);
		}

		// Token: 0x0603DCA2 RID: 253090 RVA: 0x00FBF388 File Offset: 0x00FBD588
		protected SkillButtonEffect? GetDynamicEffectConfig()
		{
			if (this.BehaviorButtonData == null)
			{
				return null;
			}
			return this.BehaviorButtonData.GetDynamicEffectConfig();
		}

		// Token: 0x0603DCA3 RID: 253091 RVA: 0x00FBF3B2 File Offset: 0x00FBD5B2
		public InputMultiKeyItem GetKeyItem()
		{
			return this.KeyItem;
		}

		// Token: 0x0603DCA4 RID: 253092 RVA: 0x00FBF3BC File Offset: 0x00FBD5BC
		public void RefreshKey()
		{
			if (Singleton<Info>.Instance.OperationType != EOperationType.Desktop)
			{
				return;
			}
			string actionName = this.BehaviorButtonData.GetActionName();
			if (this.KeyActionName == actionName)
			{
				return;
			}
			if (this.KeyItem != null)
			{
				InputActionOrAxisKeyItem actionOrAxisKeyItem = new InputActionOrAxisKeyItem
				{
					ActionOrAxisName = actionName
				};
				this.KeyItem.RefreshByActionOrAxis(actionOrAxisKeyItem, false);
				this.KeyItem.SetActive(true);
			}
			this.KeyActionName = actionName;
		}

		// Token: 0x0603DCA5 RID: 253093 RVA: 0x00FBF427 File Offset: 0x00FBD627
		public string GetActionName()
		{
			return this.KeyActionName;
		}

		// Token: 0x04022A72 RID: 141938
		private BehaviorButtonData BehaviorButtonData;

		// Token: 0x04022A73 RID: 141939
		[Nullable(1)]
		private string SkillIconPath = string.Empty;

		// Token: 0x04022A74 RID: 141940
		private int? LoadIconHandleId;

		// Token: 0x04022A75 RID: 141941
		private UUISpriteTransition SpriteTransition;

		// Token: 0x04022A76 RID: 141942
		protected string KeyActionName;

		// Token: 0x04022A77 RID: 141943
		public EBehaviorType BehaviorType = EBehaviorType.Aim;

		// Token: 0x04022A78 RID: 141944
		private InputMultiKeyItem KeyItem;

		// Token: 0x04022A79 RID: 141945
		private BattleUiNiagaraItem ClickEffect;

		// Token: 0x04022A7A RID: 141946
		private ULGUIPlayTweenComponent AlphaTweenComp;

		// Token: 0x04022A7B RID: 141947
		private float TargetAlpha = 1f;

		// Token: 0x04022A7C RID: 141948
		private float BaseAlpha = 1f;

		// Token: 0x04022A7D RID: 141949
		private Action OnVisibleChangedCallback;

		// Token: 0x04022A7E RID: 141950
		private BattleSkillItemDynamicEffect DynamicEffect;

		// Token: 0x0200C06C RID: 49260
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B38B RID: 242571
			BehaviorButton,
			// Token: 0x0403B38C RID: 242572
			IconSprite,
			// Token: 0x0403B38D RID: 242573
			ClickEffectNiagara,
			// Token: 0x0403B38E RID: 242574
			DynamicEffectNiagara,
			// Token: 0x0403B38F RID: 242575
			KeyItem
		}
	}
}
