using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.ScreenEffect.Data;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Effect;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.Plot.Sequence;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView
{
	// Token: 0x020053B2 RID: 21426
	[NullableContext(1)]
	[Nullable(0)]
	public class EntitySequenceView : UiPanelBase
	{
		// Token: 0x06036A3E RID: 223806 RVA: 0x00DD7160 File Offset: 0x00DD5360
		protected override UniTask OnCreateAsync()
		{
			EntitySequenceView.<OnCreateAsync>d__10 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<EntitySequenceView.<OnCreateAsync>d__10>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A3F RID: 223807 RVA: 0x00DD71A4 File Offset: 0x00DD53A4
		protected override UniTask OnBeforeStartAsync()
		{
			EntitySequenceView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<EntitySequenceView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A40 RID: 223808 RVA: 0x00DD71E7 File Offset: 0x00DD53E7
		protected override void OnBeforeShow()
		{
			this.SetEntitySequenceInteractState(true);
			if (ModelBase<SequenceModel>.Instance.IsPlaying)
			{
				this.Enable();
			}
		}

		// Token: 0x06036A41 RID: 223809 RVA: 0x00DD7202 File Offset: 0x00DD5402
		protected override void OnAfterHide()
		{
			this.SetEntitySequenceInteractState(false);
		}

		// Token: 0x06036A42 RID: 223810 RVA: 0x00DD720C File Offset: 0x00DD540C
		protected override void OnBeforeDestroy()
		{
			ControllerBase<SequenceController>.Instance.ClearAccelerateCallback();
			this.ScreenEffectCache = null;
			this.PostProcessCache = null;
			this.HandleActionBinding(false);
			this.SetEntitySequenceInteractState(false);
			this.Disable();
			if (this.ScreenEffectHandle != null)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle.Value);
			}
			if (this.PostProcessHandle != null)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.PostProcessHandle.Value, "[EntitySequenceView.OnSkipButtonClick]", true, null);
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotSequenceStarted, new Action(this.Enable));
		}

		// Token: 0x06036A43 RID: 223811 RVA: 0x00DD72B8 File Offset: 0x00DD54B8
		public UniTask OpenAsync(UUIItem parentItem)
		{
			EntitySequenceView.<OpenAsync>d__15 <OpenAsync>d__;
			<OpenAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OpenAsync>d__.<>4__this = this;
			<OpenAsync>d__.parentItem = parentItem;
			<OpenAsync>d__.<>1__state = -1;
			<OpenAsync>d__.<>t__builder.Start<EntitySequenceView.<OpenAsync>d__15>(ref <OpenAsync>d__);
			return <OpenAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A44 RID: 223812 RVA: 0x00DD7304 File Offset: 0x00DD5504
		public UniTask CloseAsync()
		{
			EntitySequenceView.<CloseAsync>d__16 <CloseAsync>d__;
			<CloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CloseAsync>d__.<>4__this = this;
			<CloseAsync>d__.<>1__state = -1;
			<CloseAsync>d__.<>t__builder.Start<EntitySequenceView.<CloseAsync>d__16>(ref <CloseAsync>d__);
			return <CloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06036A45 RID: 223813 RVA: 0x00DD7347 File Offset: 0x00DD5547
		public void SetParentUiItem(UUIItem parentItem)
		{
			base.GetRootItem().SetUIParent(parentItem, false);
		}

		// Token: 0x06036A46 RID: 223814 RVA: 0x00DD7358 File Offset: 0x00DD5558
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnSkipButtonClickFromButton));
			this.BtnBindInfo = list2;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			}
		}

		// Token: 0x06036A47 RID: 223815 RVA: 0x00DD7425 File Offset: 0x00DD5625
		private void OnSkipButtonClickFromButton()
		{
			this.OnSkipButtonClickCore();
		}

		// Token: 0x06036A48 RID: 223816 RVA: 0x00DD742D File Offset: 0x00DD562D
		private void OnSkipButtonInput(string actionName, InputDistributeDefine.EActionType value, InputIdentification inputIdentification)
		{
			if (value == InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			this.OnSkipButtonClickCore();
		}

		// Token: 0x06036A49 RID: 223817 RVA: 0x00DD743C File Offset: 0x00DD563C
		private void OnSkipButtonClickCore()
		{
			this.Disable();
			this.ScreenEffectHandle = new int?(ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect(ModelBase<PlotModel>.Instance.PlotGlobalConfig.EntitySequenceScreenEffectPath, null, null));
			EffectSystem instance = Singleton<EffectSystem>.Instance;
			UObject world = GlobalData.World;
			FTransformDouble? ftransformDouble = new FTransformDouble?(Transform.Create().ToUeTransform());
			this.PostProcessHandle = new int?(instance.SpawnEffect(world, ftransformDouble, ModelBase<PlotModel>.Instance.PlotGlobalConfig.EntitySequencePostEffectPath, "[EntitySequenceView.OnSkipButtonClick]", null, EEffectType.Scene, null, null, null, false, false));
			ControllerBase<SequenceController>.Instance.AccelerateToNextSubtitleOrChildSeq(delegate
			{
				this.Enable();
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.ScreenEffectHandle.Value);
				Singleton<EffectSystem>.Instance.StopEffectById(this.PostProcessHandle.Value, "[EntitySequenceView.OnSkipButtonClick]", true, null);
				Singleton<AudioSystem>.Instance.ExecuteAction(ModelBase<PlotModel>.Instance.PlotGlobalConfig.EntitySequenceAudioEvent, EAudioActionType.Stop, null);
				Singleton<AudioSystem>.Instance.SetRtpcValue("global_seq_rate", ModelBase<SequenceModel>.Instance.PlayRate, null);
			});
			Singleton<AudioSystem>.Instance.PostEvent(ModelBase<PlotModel>.Instance.PlotGlobalConfig.EntitySequenceAudioEvent);
			Singleton<AudioSystem>.Instance.SetRtpcValue("global_seq_rate", ModelBase<PlotModel>.Instance.PlotGlobalConfig.EntitySequenceAccelerateRate, null);
		}

		// Token: 0x06036A4A RID: 223818 RVA: 0x00DD7514 File Offset: 0x00DD5714
		public void Enable()
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(true);
			}
			this.HandleActionBinding(true);
		}

		// Token: 0x06036A4B RID: 223819 RVA: 0x00DD7548 File Offset: 0x00DD5748
		public void Disable()
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			this.HandleActionBinding(false);
		}

		// Token: 0x06036A4C RID: 223820 RVA: 0x00DD757C File Offset: 0x00DD577C
		private bool OnCheckKey(string actionName, InputDistributeDefine.EActionType actionType)
		{
			return !(actionName == "地图") && !(actionName == "功能菜单");
		}

		// Token: 0x06036A4D RID: 223821 RVA: 0x00DD759D File Offset: 0x00DD579D
		public void RefreshActionBinding()
		{
			if (this.HasBindActionGamepad || this.HasBindActionOther)
			{
				this.HandleActionBinding(false);
				this.HandleActionBinding(true);
			}
		}

		// Token: 0x06036A4E RID: 223822 RVA: 0x00DD75C0 File Offset: 0x00DD57C0
		private void SetEntitySequenceInteractState(bool active)
		{
			if (active && !ModelBase<PlotModel>.Instance.EntitySequenceInteractTag)
			{
				ModelBase<PlotModel>.Instance.EntitySequenceInteractTag = true;
				Singleton<InputManager>.Instance.RegisterLockShortcutKeyReason("实机剧情禁用快捷键", new TLockShortcutKeyDelegate(this.OnCheckKey));
				ModelBase<BattleUiModel>.Instance.ChildViewData.HideBattleView(EBattleUiVisibleReason.UiControl, new EBattleUiChild[]
				{
					EBattleUiChild.Joystick,
					EBattleUiChild.ScreenEffect,
					EBattleUiChild.MiniMap,
					EBattleUiChild.ExitButton,
					EBattleUiChild.HomeButton
				}, 0);
				return;
			}
			if (!active && ModelBase<PlotModel>.Instance.EntitySequenceInteractTag)
			{
				ModelBase<PlotModel>.Instance.EntitySequenceInteractTag = false;
				Singleton<InputManager>.Instance.RemoveLockShortcutKeyReason("实机剧情禁用快捷键");
				ModelBase<BattleUiModel>.Instance.ChildViewData.ShowBattleView(EBattleUiVisibleReason.UiControl, 0);
			}
		}

		// Token: 0x06036A4F RID: 223823 RVA: 0x00DD7664 File Offset: 0x00DD5864
		private void HandleActionBinding(bool bBind)
		{
			if (!bBind)
			{
				if (this.HasBindActionGamepad)
				{
					this.HasBindActionGamepad = false;
				}
				if (this.HasBindActionOther)
				{
					this.HasBindActionOther = false;
					ControllerBase<InputDistributeController>.Instance.UnBindActionIgnoreLimit("大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnSkipButtonInput));
					InputMultiKeyItem keyItem = this.KeyItem;
					if (keyItem == null)
					{
						return;
					}
					keyItem.Hide(null);
				}
				return;
			}
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				if (this.HasBindActionGamepad)
				{
					return;
				}
				InputMultiKeyItem keyItem2 = this.KeyItem;
				if (keyItem2 != null)
				{
					keyItem2.Hide(null);
				}
				this.HasBindActionGamepad = true;
				return;
			}
			else
			{
				if (this.HasBindActionOther)
				{
					return;
				}
				ControllerBase<InputDistributeController>.Instance.BindActionIgnoreLimit("大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnSkipButtonInput));
				InputMultiKeyItem keyItem3 = this.KeyItem;
				if (keyItem3 != null)
				{
					keyItem3.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
					{
						ActionOrAxisName = "大招"
					}, false);
				}
				InputMultiKeyItem keyItem4 = this.KeyItem;
				if (keyItem4 != null)
				{
					keyItem4.Show(null);
				}
				this.HasBindActionOther = true;
				return;
			}
		}

		// Token: 0x0401F790 RID: 128912
		private const string ENTITY_SEQUENCE_ACCELERATE_RATE_RTPC = "global_seq_rate";

		// Token: 0x0401F791 RID: 128913
		private const string BLOCK_KEY_REASON = "实机剧情禁用快捷键";

		// Token: 0x0401F792 RID: 128914
		[Nullable(2)]
		private EffectScreenPlayData_C ScreenEffectCache;

		// Token: 0x0401F793 RID: 128915
		[Nullable(2)]
		private EffectModelPostProcess PostProcessCache;

		// Token: 0x0401F794 RID: 128916
		private bool HasBindActionGamepad;

		// Token: 0x0401F795 RID: 128917
		private bool HasBindActionOther;

		// Token: 0x0401F796 RID: 128918
		[Nullable(2)]
		private InputMultiKeyItem KeyItem;

		// Token: 0x0401F797 RID: 128919
		private int? ScreenEffectHandle;

		// Token: 0x0401F798 RID: 128920
		private int? PostProcessHandle;

		// Token: 0x0200B317 RID: 45847
		[NullableContext(0)]
		private enum EEntitySequenceView
		{
			// Token: 0x040377BD RID: 227261
			HotKey,
			// Token: 0x040377BE RID: 227262
			SkipButton,
			// Token: 0x040377BF RID: 227263
			HotKeyCombine
		}
	}
}
