using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005935 RID: 22837
	[NullableContext(2)]
	[Nullable(0)]
	public class GridEventCompDesc : UiPanelBase, IEventStepItem
	{
		// Token: 0x17009448 RID: 37960
		// (get) Token: 0x06039F0C RID: 237324 RVA: 0x00EAA5D6 File Offset: 0x00EA87D6
		public int StepId { get; }

		// Token: 0x17009449 RID: 37961
		// (get) Token: 0x06039F0D RID: 237325 RVA: 0x00EAA5DE File Offset: 0x00EA87DE
		public EStepType StepType { get; }

		// Token: 0x1700944A RID: 37962
		// (get) Token: 0x06039F0E RID: 237326 RVA: 0x00EAA5E6 File Offset: 0x00EA87E6
		// (set) Token: 0x06039F0F RID: 237327 RVA: 0x00EAA5EE File Offset: 0x00EA87EE
		public Action<int, EStepType> CanInteractCallback { get; set; }

		// Token: 0x1700944B RID: 37963
		// (get) Token: 0x06039F10 RID: 237328 RVA: 0x00EAA5F7 File Offset: 0x00EA87F7
		// (set) Token: 0x06039F11 RID: 237329 RVA: 0x00EAA5FF File Offset: 0x00EA87FF
		public Action<int, int> ExecuteStep { get; set; }

		// Token: 0x06039F12 RID: 237330 RVA: 0x00EAA608 File Offset: 0x00EA8808
		public GridEventCompDesc(int stepId, EStepType stepType = EStepType.Desc)
		{
			this.StepId = stepId;
			this.StepType = stepType;
		}

		// Token: 0x06039F13 RID: 237331 RVA: 0x00EAA620 File Offset: 0x00EA8820
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06039F14 RID: 237332 RVA: 0x00EAA690 File Offset: 0x00EA8890
		protected override void OnStart()
		{
			UUIText text = base.GetText(0);
			text.SetUIActive(false);
			this.TextAnimDataComp = (text.GetOwner().GetComponentByClass(UUIEffectTextAnimation.StaticClass()) as UUIEffectTextAnimation);
			this.TextPlayTweenComp = (text.GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			UUIEffectTextAnimation textAnimDataComp = this.TextAnimDataComp;
			if (textAnimDataComp != null)
			{
				textAnimDataComp.SetSelectorOffset(1f);
			}
			this.TextPlayTweenEndCb = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCbWrapper = this.TextPlayTweenComp.GetPlayTween().RegisterOnComplete(this.TextPlayTweenEndCb);
			this.TextSpeed = ConfigCommonParamById.GetFloatConfig("MapRogueRandomEventTextSpeed").GetValueOrDefault(10f);
		}

		// Token: 0x06039F15 RID: 237333 RVA: 0x00EAA754 File Offset: 0x00EA8954
		protected override void OnBeforeDestroy()
		{
			if (this.TextPlayTweenEndCbWrapper != null)
			{
				ULGUIPlayTweenComponent textPlayTweenComp = this.TextPlayTweenComp;
				if (textPlayTweenComp != null)
				{
					ULGUIPlayTween playTween = textPlayTweenComp.GetPlayTween();
					if (playTween != null)
					{
						playTween.UnregisterOnComplete(this.TextPlayTweenEndCbWrapper);
					}
				}
				this.TextPlayTweenEndCbWrapper = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenEnd));
			this.TextPlayTweenEndCb = null;
		}

		// Token: 0x06039F16 RID: 237334 RVA: 0x00EAA7B0 File Offset: 0x00EA89B0
		[NullableContext(1)]
		private void SetTag(string tagId, [Nullable(2)] string tagColor = null)
		{
			UUIText text = base.GetText(3);
			UUISprite sprite = base.GetSprite(2);
			UUIItem item = base.GetItem(1);
			if (StringUtils.IsEmpty(tagId))
			{
				item.SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, tagId, Array.Empty<object>());
			if (!StringUtils.IsEmpty(tagColor))
			{
				FColor color = FColor.FromHex(tagColor);
				sprite.SetColor(color);
			}
			item.SetUIActive(true);
		}

		// Token: 0x06039F17 RID: 237335 RVA: 0x00EAA814 File Offset: 0x00EA8A14
		[NullableContext(1)]
		private void ShowText(string textId, bool playEnd)
		{
			UUIText text = base.GetText(0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textId, Array.Empty<object>());
			text.SetUIActive(true);
			int displayCharLength = text.GetDisplayCharLength();
			if (this.TextPlayTweenComp != null)
			{
				if (playEnd)
				{
					this.TextAnimDataComp.SetSelectorOffset(0f);
					return;
				}
				float duration = (float)displayCharLength / this.TextSpeed;
				this.TextAnimDataComp.SetSelectorOffset(1f);
				this.TextPlayTweenComp.GetPlayTween().duration = duration;
				this.TextPlayTweenComp.Play();
				this.IsInPlay = true;
			}
		}

		// Token: 0x06039F18 RID: 237336 RVA: 0x00EAA8A4 File Offset: 0x00EA8AA4
		public void Refresh(bool end)
		{
			RogueResEventStep? rogueEventStepById = ConfigBase<MapRogueConfig>.Instance.GetRogueEventStepById(this.StepId);
			if (rogueEventStepById == null)
			{
				return;
			}
			this.SetTag(rogueEventStepById.Value.TitleKey, rogueEventStepById.Value.TagColor);
			this.ShowText(rogueEventStepById.Value.TextKey, end);
			this.SetActive(true);
		}

		// Token: 0x06039F19 RID: 237337 RVA: 0x00EAA90D File Offset: 0x00EA8B0D
		public void MaskClick()
		{
			this.ShowAllText();
		}

		// Token: 0x06039F1A RID: 237338 RVA: 0x00EAA918 File Offset: 0x00EA8B18
		public void ShowAllText()
		{
			if (!this.IsInPlay)
			{
				return;
			}
			this.TextPlayTweenComp.Stop();
			this.TextAnimDataComp.SetSelectorOffset(0f);
			Action<int, EStepType> canInteractCallback = this.CanInteractCallback;
			if (canInteractCallback == null)
			{
				return;
			}
			canInteractCallback(this.StepId, this.StepType);
		}

		// Token: 0x06039F1B RID: 237339 RVA: 0x00EAA965 File Offset: 0x00EA8B65
		private void OnTweenEnd()
		{
			this.IsInPlay = false;
			Action<int, EStepType> canInteractCallback = this.CanInteractCallback;
			if (canInteractCallback == null)
			{
				return;
			}
			canInteractCallback(this.StepId, this.StepType);
		}

		// Token: 0x04020D3E RID: 134462
		private UUIEffectTextAnimation TextAnimDataComp;

		// Token: 0x04020D3F RID: 134463
		private ULGUIPlayTweenComponent TextPlayTweenComp;

		// Token: 0x04020D40 RID: 134464
		private FLGUIPlayTweenCompleteDynamicDelegate TextPlayTweenEndCb;

		// Token: 0x04020D41 RID: 134465
		private FLGUIDelegateHandleWrapper TextPlayTweenEndCbWrapper;

		// Token: 0x04020D42 RID: 134466
		private float TextSpeed;

		// Token: 0x04020D43 RID: 134467
		private bool IsInPlay;
	}
}
