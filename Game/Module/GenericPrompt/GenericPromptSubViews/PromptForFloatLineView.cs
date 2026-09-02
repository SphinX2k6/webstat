using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GenericPrompt.GenericPromptSubViews
{
	// Token: 0x02005CC9 RID: 23753
	[NullableContext(2)]
	[Nullable(0)]
	public class PromptForFloatLineView : UiPanelBase
	{
		// Token: 0x0603BE73 RID: 245363 RVA: 0x00F2E630 File Offset: 0x00F2C830
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BE74 RID: 245364 RVA: 0x00F2E678 File Offset: 0x00F2C878
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TextAnimDataComp = (base.GetText(0).GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenComp = (base.GetText(0).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp == null)
			{
				return;
			}
			textAnimDataComp.SetSelectorOffset(1f);
		}

		// Token: 0x0603BE75 RID: 245365 RVA: 0x00F2E6F8 File Offset: 0x00F2C8F8
		protected override void OnBeforeShow()
		{
			GenericPromptConfig instance = ConfigBase<GenericPromptConfig>.Instance;
			int typeId = this.ParamHub.TypeId;
			FColor? promptTypeMainTextColor = instance.GetPromptTypeMainTextColor(typeId);
			if (promptTypeMainTextColor != null)
			{
				this.SetMainTextColor(promptTypeMainTextColor.Value);
			}
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp != null)
			{
				textAnimDataComp.SetSelectorOffset(1f);
			}
			if (this.TextPlayTweenComp != null)
			{
				GenericPrompt? genericPrompt;
				GenericPromptTypes? genericPromptTypes;
				int? num = (typeId != 0) ? ((ConfigBase<GenericPromptConfig>.Instance.GetPromptInfo(typeId) != null) ? new int?(genericPrompt.GetValueOrDefault().Duration) : null) : ((ConfigBase<GenericPromptConfig>.Instance.GetPromptTypeInfo(typeId) != null) ? new int?(genericPromptTypes.GetValueOrDefault().Duration) : null);
				float num2 = 0.5f;
				int? num3 = num;
				float? num4 = num2 * ((num3 != null) ? new float?((float)num3.GetValueOrDefault()) : null);
				ULGUIPlayTween playTween = this.TextPlayTweenComp.GetPlayTween();
				if (playTween != null)
				{
					float duration = playTween.duration;
					float? num5 = num4;
					playTween.duration = ((duration > num5.GetValueOrDefault() & num5 != null) ? num4 : new float?(playTween.duration)).GetValueOrDefault();
				}
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp == null)
				{
					return;
				}
				textPlayTweenComp.Play();
			}
		}

		// Token: 0x0603BE76 RID: 245366 RVA: 0x00F2E874 File Offset: 0x00F2CA74
		protected override UniTask OnShowAsyncImplementImplement()
		{
			PromptForFloatLineView.<OnShowAsyncImplementImplement>d__11 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<PromptForFloatLineView.<OnShowAsyncImplementImplement>d__11>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE77 RID: 245367 RVA: 0x00F2E8B8 File Offset: 0x00F2CAB8
		protected override UniTask OnBeforeHideAsync()
		{
			PromptForFloatLineView.<OnBeforeHideAsync>d__12 <OnBeforeHideAsync>d__;
			<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeHideAsync>d__.<>4__this = this;
			<OnBeforeHideAsync>d__.<>1__state = -1;
			<OnBeforeHideAsync>d__.<>t__builder.Start<PromptForFloatLineView.<OnBeforeHideAsync>d__12>(ref <OnBeforeHideAsync>d__);
			return <OnBeforeHideAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE78 RID: 245368 RVA: 0x00F2E8FB File Offset: 0x00F2CAFB
		protected override void OnAfterHide()
		{
			THideDelegate hideCallback = this.HideCallback;
			if (hideCallback == null)
			{
				return;
			}
			hideCallback(this);
		}

		// Token: 0x0603BE79 RID: 245369 RVA: 0x00F2E910 File Offset: 0x00F2CB10
		private void SetMainTextColor(FColor color)
		{
			UUIEffectOutline uuieffectOutline = base.GetText(0).GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
			if (uuieffectOutline != null)
			{
				uuieffectOutline.SetOutlineColor(color);
				return;
			}
			base.GetText(0).SetColor(color);
		}

		// Token: 0x0603BE7A RID: 245370 RVA: 0x00F2E958 File Offset: 0x00F2CB58
		[NullableContext(1)]
		private void SetMainTextUi(TableTextArgNew mainTextObj, [ParamCollection] IReadOnlyList<object> parameters)
		{
			UUIText text = base.GetText(0);
			int? promptId = this.ParamHub.PromptId;
			int num = 0;
			if (!(promptId.GetValueOrDefault() == num & promptId != null))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, mainTextObj.TextKey, parameters);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, mainTextObj.TextKey, parameters);
		}

		// Token: 0x0603BE7B RID: 245371 RVA: 0x00F2E9B4 File Offset: 0x00F2CBB4
		private void SetMainTextParam()
		{
			GenericPromptConfig instance = ConfigBase<GenericPromptConfig>.Instance;
			IPromptParamHub paramHub = this.ParamHub;
			IReadOnlyList<object> readOnlyList = paramHub.MainTextParams ?? Array.Empty<object>();
			TableTextArgNew tableTextArgNew = paramHub.MainTextObj;
			int valueOrDefault = paramHub.PromptId.GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				if (tableTextArgNew == null)
				{
					tableTextArgNew = instance.GetPromptMainTextObj(valueOrDefault);
				}
			}
			else if (tableTextArgNew == null)
			{
				tableTextArgNew = instance.GetPromptTypeMainTextObj(paramHub.TypeId);
			}
			if (readOnlyList.Count == 0)
			{
				this.SetMainTextUi(tableTextArgNew, Array.Empty<object>());
			}
			if (tableTextArgNew == null && valueOrDefault == 0 && readOnlyList.Count > 0)
			{
				if (!string.IsNullOrEmpty(readOnlyList[0] as string))
				{
					base.GetText(0).SetText(readOnlyList[0] as string, true);
				}
				return;
			}
			this.SetMainTextUi(tableTextArgNew, readOnlyList);
		}

		// Token: 0x0603BE7C RID: 245372 RVA: 0x00F2EA74 File Offset: 0x00F2CC74
		[NullableContext(1)]
		public void SetPromptHub(IPromptParamHub promptParamHub)
		{
			this.ParamHub = promptParamHub;
			GenericPromptConfig instance = ConfigBase<GenericPromptConfig>.Instance;
			this.TickTime = 0f;
			if (promptParamHub.Duration != null)
			{
				float? duration = promptParamHub.Duration;
				float num = 0f;
				if (duration.GetValueOrDefault() > num & duration != null)
				{
					this.Duration = Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)promptParamHub.Duration.Value);
					goto IL_A9;
				}
			}
			GenericPromptTypes? genericPromptTypes;
			this.Duration = Singleton<TimeUtil>.Instance.SetTimeMillisecond((double)((instance.GetPromptTypeInfo(this.ParamHub.TypeId) != null) ? genericPromptTypes.GetValueOrDefault().Duration : 0));
			IL_A9:
			this.ApplyPromptText();
		}

		// Token: 0x0603BE7D RID: 245373 RVA: 0x00F2EB30 File Offset: 0x00F2CD30
		private void ApplyPromptText()
		{
			this.SetMainTextParam();
			this.RootItem.SetAsLastHierarchy();
		}

		// Token: 0x0603BE7E RID: 245374 RVA: 0x00F2EB43 File Offset: 0x00F2CD43
		public void SetHideCallback(THideDelegate callback)
		{
			this.HideCallback = callback;
		}

		// Token: 0x0603BE7F RID: 245375 RVA: 0x00F2EB4C File Offset: 0x00F2CD4C
		public void ShowView()
		{
			if (!base.IsShowOrShowing)
			{
				this.SetActive(true);
				return;
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) != null)
			{
				this.LevelSequencePlayer.ReplaySequenceByKey("Start".ToString());
				return;
			}
			this.LevelSequencePlayer.PlaySequencePurely("Start".ToString(), false, false, null, null, false);
		}

		// Token: 0x0603BE80 RID: 245376 RVA: 0x00F2EBB5 File Offset: 0x00F2CDB5
		public void HideView()
		{
			if (base.IsShowOrShowing)
			{
				this.SetActive(false);
			}
		}

		// Token: 0x0603BE81 RID: 245377 RVA: 0x00F2EBC6 File Offset: 0x00F2CDC6
		public void Tick(float delta)
		{
			if (this.Duration <= 0.0)
			{
				return;
			}
			this.TickTime += delta;
			if ((double)this.TickTime > this.Duration)
			{
				this.SetActive(false);
			}
		}

		// Token: 0x04021AC1 RID: 137921
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x04021AC2 RID: 137922
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x04021AC3 RID: 137923
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021AC4 RID: 137924
		public IPromptParamHub ParamHub;

		// Token: 0x04021AC5 RID: 137925
		private double Duration;

		// Token: 0x04021AC6 RID: 137926
		private float TickTime;

		// Token: 0x04021AC7 RID: 137927
		private THideDelegate HideCallback;

		// Token: 0x0200BD49 RID: 48457
		[NullableContext(0)]
		private class ECompDefine
		{
			// Token: 0x0403A52B RID: 238891
			public const int MainTextItem = 0;
		}
	}
}
