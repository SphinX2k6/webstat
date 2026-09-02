using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A7 RID: 18855
	public class UiBehaviourUiBlur : IUiBehavior, IStaticVariableResetter
	{
		// Token: 0x060313B3 RID: 201651 RVA: 0x00C42379 File Offset: 0x00C40579
		static UiBehaviourUiBlur()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiBehaviourUiBlur.CreateStaticDefaultValue), new Action(UiBehaviourUiBlur.ResetStaticDefaultValue));
		}

		// Token: 0x17008404 RID: 33796
		// (get) Token: 0x060313B4 RID: 201652 RVA: 0x00C42398 File Offset: 0x00C40598
		[Nullable(1)]
		private static List<int> BlurViewSet
		{
			[NullableContext(1)]
			get
			{
				return UiBehaviourUiBlur._blurViewSet;
			}
		}

		// Token: 0x060313B5 RID: 201653 RVA: 0x00C423A0 File Offset: 0x00C405A0
		public void OnAfterUiStart()
		{
			if ((this.CurrentLayer.GetValueOrDefault() & (ELayerType.Normal | ELayerType.Plot | ELayerType.Pop)) == (ELayerType)0)
			{
				return;
			}
			this.IfNeedBlurEffect = true;
			if (this.CurrentView != null)
			{
				Singleton<UiBlurLogic>.Instance.SetNormalUiRenderAfterBlur(this.CurrentView);
				int viewId = this.CurrentView.GetViewId();
				if (!UiBehaviourUiBlur.BlurViewSet.Contains(viewId))
				{
					UiBehaviourUiBlur.BlurViewSet.Add(viewId);
				}
			}
			this.RefreshViewBlurMode();
		}

		// Token: 0x060313B6 RID: 201654 RVA: 0x00C42407 File Offset: 0x00C40607
		public void OnAfterUiShow()
		{
			if (!this.IfNeedBlurEffect)
			{
				return;
			}
			if (this.HasExitingPartialBlurView())
			{
				return;
			}
			this.SetSaveModeByCurrentView();
			if (this.CurrentView != null)
			{
				Singleton<UiBlurLogic>.Instance.SetNormalUiRenderAfterBlur(this.CurrentView);
			}
		}

		// Token: 0x060313B7 RID: 201655 RVA: 0x00C42439 File Offset: 0x00C40639
		public void OnBeforeUiHide()
		{
		}

		// Token: 0x060313B8 RID: 201656 RVA: 0x00C4243C File Offset: 0x00C4063C
		private bool HasExitingPartialBlurView()
		{
			UiViewBase currentView = this.CurrentView;
			int? num = (currentView != null) ? new int?(currentView.GetViewId()) : null;
			foreach (int num2 in UiBehaviourUiBlur.BlurViewSet)
			{
				int num3 = num2;
				int? num4 = num;
				if (!(num3 == num4.GetValueOrDefault() & num4 != null))
				{
					UiViewBase view = Singleton<UiManager>.Instance.GetView(num2);
					UiShow? uiShow;
					if (view != null && (ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(view.ViewInfo.Name) != null && uiShow.GetValueOrDefault().PartialBlur))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060313B9 RID: 201657 RVA: 0x00C42510 File Offset: 0x00C40710
		private void SetSaveModeByCurrentView()
		{
			UiShow? uiShow;
			if (ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(this.CurrentView.ViewInfo.Name) != null && uiShow.GetValueOrDefault().PartialBlur)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.LGUIBlurTexture.save 1", null);
				return;
			}
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.LGUIBlurTexture.save 0", null);
		}

		// Token: 0x060313BA RID: 201658 RVA: 0x00C42578 File Offset: 0x00C40778
		private void RefreshViewBlurMode()
		{
			if (!this.IfNeedBlurEffect)
			{
				return;
			}
			int? num = (UiBehaviourUiBlur.BlurViewSet.Count > 0) ? new int?(UiBehaviourUiBlur.BlurViewSet[UiBehaviourUiBlur.BlurViewSet.Count - 1]) : null;
			if (num != null)
			{
				UiViewBase view = Singleton<UiManager>.Instance.GetView(num.Value);
				if (view != null)
				{
					UiShow? uiShow;
					bool? flag = (ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(view.ViewInfo.Name) != null) ? new bool?(uiShow.GetValueOrDefault().PartialBlur) : null;
					if (flag != null && flag.Value)
					{
						UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.LGUIBlurTexture.save 1", null);
						return;
					}
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.kuro.LGUIBlurTexture.save 0", null);
				}
			}
		}

		// Token: 0x060313BB RID: 201659 RVA: 0x00C42658 File Offset: 0x00C40858
		public void RefreshBlur()
		{
			if (!this.IfNeedBlurEffect)
			{
				return;
			}
			Singleton<UiBlurLogic>.Instance.SetNormalUiRenderAfterBlur(this.CurrentView);
		}

		// Token: 0x060313BC RID: 201660 RVA: 0x00C42673 File Offset: 0x00C40873
		public void ChangeNeedBlurState(bool state)
		{
			this.IfNeedBlurEffect = state;
		}

		// Token: 0x060313BD RID: 201661 RVA: 0x00C4267C File Offset: 0x00C4087C
		public void SetCurrentLayer(ELayerType layerType)
		{
			this.CurrentLayer = new ELayerType?(layerType);
		}

		// Token: 0x060313BE RID: 201662 RVA: 0x00C4268A File Offset: 0x00C4088A
		[NullableContext(1)]
		public void SetViewInfo(UiViewBase baseView)
		{
			this.CurrentView = baseView;
		}

		// Token: 0x060313BF RID: 201663 RVA: 0x00C42694 File Offset: 0x00C40894
		public void OnBeforeDestroy()
		{
			if (this.CurrentView != null)
			{
				UiBehaviourUiBlur.BlurViewSet.Remove(this.CurrentView.GetViewId());
			}
			this.RefreshViewBlurMode();
			if (!this.IfNeedBlurEffect)
			{
				return;
			}
			if (this.CurrentLayer.GetValueOrDefault() == ELayerType.Pop || this.IsCurrentViewPartialBlur())
			{
				Singleton<UiBlurLogic>.Instance.ResumeTopUiRenderAfterBlur();
			}
		}

		// Token: 0x060313C0 RID: 201664 RVA: 0x00C426F0 File Offset: 0x00C408F0
		public bool IsCurrentViewPartialBlur()
		{
			if (this.IfNeedBlurEffect)
			{
				UiViewBase currentView = this.CurrentView;
				bool flag;
				if (currentView == null)
				{
					flag = true;
				}
				else
				{
					UiViewInfo viewInfo = currentView.ViewInfo;
					EUiViewName? euiViewName = (viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null;
					flag = (euiViewName == null);
				}
				if (!flag)
				{
					UiShow? uiShow;
					return ConfigBase<UiViewConfig>.Instance.GetUiShowConfig(this.CurrentView.ViewInfo.Name) != null && uiShow.GetValueOrDefault().PartialBlur;
				}
			}
			return false;
		}

		// Token: 0x060313C1 RID: 201665 RVA: 0x00C42774 File Offset: 0x00C40974
		public UniTask OnUiCreateAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x060313C2 RID: 201666 RVA: 0x00C4277B File Offset: 0x00C4097B
		public static void CreateStaticDefaultValue()
		{
			UiBehaviourUiBlur._blurViewSet = new List<int>();
		}

		// Token: 0x060313C3 RID: 201667 RVA: 0x00C42787 File Offset: 0x00C40987
		public static void ResetStaticDefaultValue()
		{
			UiBehaviourUiBlur._blurViewSet = null;
		}

		// Token: 0x0401C537 RID: 116023
		private ELayerType? CurrentLayer;

		// Token: 0x0401C538 RID: 116024
		[Nullable(2)]
		protected UiViewBase CurrentView;

		// Token: 0x0401C539 RID: 116025
		private bool IfNeedBlurEffect;

		// Token: 0x0401C53A RID: 116026
		[Nullable(2)]
		private static List<int> _blurViewSet;
	}
}
