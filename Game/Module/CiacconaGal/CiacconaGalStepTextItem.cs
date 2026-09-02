using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EC8 RID: 24264
	[NullableContext(2)]
	[Nullable(0)]
	public class CiacconaGalStepTextItem : UiPanelBase
	{
		// Token: 0x0603CFB2 RID: 249778 RVA: 0x00F7C83C File Offset: 0x00F7AA3C
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

		// Token: 0x0603CFB3 RID: 249779 RVA: 0x00F7C884 File Offset: 0x00F7AA84
		protected override void OnStart()
		{
			this.TextContent = base.GetText(0);
			this.AnimComp = (ULGUIPlayTweenComponent)this.TextContent.GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass());
			this.OnAnimEndDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnAnimEnd));
			this.OnAnimEndDelegateWrapper = this.AnimComp.GetPlayTween().RegisterOnComplete(this.OnAnimEndDelegate);
			this.AnimHandler = new CiacconaGalTextAnimHandler(this.AnimComp);
		}

		// Token: 0x0603CFB4 RID: 249780 RVA: 0x00F7C908 File Offset: 0x00F7AB08
		protected override void OnBeforeDestroy()
		{
			ULGUIPlayTweenComponent animComp = this.AnimComp;
			if (animComp != null)
			{
				ULGUIPlayTween playTween = animComp.GetPlayTween();
				if (playTween != null)
				{
					playTween.UnregisterOnComplete(this.OnAnimEndDelegateWrapper);
				}
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnAnimEnd));
			this.OnAnimEndDelegateWrapper = null;
			ULGUIPlayTweenComponent animComp2 = this.AnimComp;
			if (animComp2 != null)
			{
				animComp2.Stop();
			}
			if (this.AnimDelayTimerHandle != null && TimerSystem.Instance.Has(this.AnimDelayTimerHandle))
			{
				TimerSystem.Instance.Remove(this.AnimDelayTimerHandle);
				this.AnimDelayTimerHandle = null;
			}
		}

		// Token: 0x0603CFB5 RID: 249781 RVA: 0x00F7C994 File Offset: 0x00F7AB94
		[NullableContext(1)]
		public void Refresh(CiacconaGalStepData data)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextContent, data.TalkTid, Array.Empty<object>());
			if (data.Id == ControllerBase<CiacconaGalController>.Instance.GalPlayer.CurHandlingStepId)
			{
				UUIItem textContent = this.TextContent;
				bool bUseChangeColor = false;
				FColor? fcolor = new FColor?(this.TextContent.changeColor);
				textContent.SetChangeColor(bUseChangeColor, fcolor);
				if (!ControllerBase<CiacconaGalController>.Instance.GalPlayer.HasPlayedStepAnim(data.Id))
				{
					this.TextContent.SetUIActive(false);
					this.AnimHandler.SetData(data);
					ControllerBase<CiacconaGalController>.Instance.GalPlayer.SetAnimHandler(this.AnimHandler);
					this.AnimHandler.Play();
					if (this.AnimDelayTimerHandle != null && TimerSystem.Instance.Has(this.AnimDelayTimerHandle))
					{
						TimerSystem.Instance.Remove(this.AnimDelayTimerHandle);
						this.AnimDelayTimerHandle = null;
					}
					this.AnimDelayTimerHandle = TimerSystem.Instance.Delay(delegate(float _)
					{
						if (this.TextContent == null || !this.TextContent.IsValid())
						{
							return;
						}
						this.TextContent.SetUIActive(true);
					}, 100f, null, null, true, 1f);
					return;
				}
			}
			else
			{
				this.TextContent.SetUIActive(true);
				UUIItem textContent2 = this.TextContent;
				bool bUseChangeColor2 = true;
				FColor? fcolor = new FColor?(this.TextContent.changeColor);
				textContent2.SetChangeColor(bUseChangeColor2, fcolor);
			}
		}

		// Token: 0x0603CFB6 RID: 249782 RVA: 0x00F7CACE File Offset: 0x00F7ACCE
		private void OnAnimEnd()
		{
			ControllerBase<CiacconaGalController>.Instance.GalPlayer.OnAnimEnd();
		}

		// Token: 0x04022398 RID: 140184
		private ULGUIPlayTweenComponent AnimComp;

		// Token: 0x04022399 RID: 140185
		private UUIText TextContent;

		// Token: 0x0402239A RID: 140186
		private FLGUIPlayTweenCompleteDynamicDelegate OnAnimEndDelegate;

		// Token: 0x0402239B RID: 140187
		private FLGUIDelegateHandleWrapper OnAnimEndDelegateWrapper;

		// Token: 0x0402239C RID: 140188
		private CiacconaGalTextAnimHandler AnimHandler;

		// Token: 0x0402239D RID: 140189
		private TimerHandle AnimDelayTimerHandle;

		// Token: 0x0200BEC0 RID: 48832
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB62 RID: 240482
			public const int TextContent = 0;
		}
	}
}
