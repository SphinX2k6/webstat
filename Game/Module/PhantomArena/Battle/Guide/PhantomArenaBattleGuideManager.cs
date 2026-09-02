using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.View;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Guide
{
	// Token: 0x02005613 RID: 22035
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleGuideManager
	{
		// Token: 0x060382A5 RID: 230053 RVA: 0x00E39132 File Offset: 0x00E37332
		public PhantomArenaBattleGuideManager(PhantomArenaBattleProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x060382A6 RID: 230054 RVA: 0x00E39141 File Offset: 0x00E37341
		public void RegisterGuideInterface(IPhantomArenaGuideFunc guideInterface)
		{
			this.GuideInterface = guideInterface;
		}

		// Token: 0x060382A7 RID: 230055 RVA: 0x00E3914C File Offset: 0x00E3734C
		public unsafe void RegisterBehaviorTreeGuideData(BvbPlayerOperationConstraint param)
		{
			EBvbPlayerOperationType type = param.EnableOperation.Type;
			this.CurrentGuideData = PhantomArenaBattleGuideFactory.GetGuideData(type, param);
			this.HasNextGuide = !param.IsTheLast.GetValueOrDefault();
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "行为引导操作限制";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HasNextGuide", this.HasNextGuide);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x060382A8 RID: 230056 RVA: 0x00E391F0 File Offset: 0x00E373F0
		public bool CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType type, params object[] params_)
		{
			if (this.CurrentGuideData == null && !this.HasNextGuide)
			{
				return true;
			}
			if (this.CurrentGuideData == null && this.HasNextGuide)
			{
				this.ShowGuideTips();
				return false;
			}
			if (this.CurrentGuideData.Type != type)
			{
				this.ShowGuideTips();
				return false;
			}
			if (!this.CurrentGuideData.CheckCanExecute(params_))
			{
				this.ShowGuideTips();
				return false;
			}
			return true;
		}

		// Token: 0x060382A9 RID: 230057 RVA: 0x00E39254 File Offset: 0x00E37454
		public bool CheckInGuideAndShowTips()
		{
			if (this.InGuiding)
			{
				this.ShowGuideTips();
				return true;
			}
			return false;
		}

		// Token: 0x060382AA RID: 230058 RVA: 0x00E39268 File Offset: 0x00E37468
		public unsafe void FinishCurrentGuide()
		{
			if (this.CurrentGuideData != null)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "行为引导操作限制完成";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", this.CurrentGuideData.Type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("HasNextGuide", this.HasNextGuide);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.CurrentGuideData = null;
				if (this.GuideInterface != null)
				{
					this.GuideInterface.FinishCurrentGuide();
					this.GuideInterface = null;
				}
			}
		}

		// Token: 0x060382AB RID: 230059 RVA: 0x00E39310 File Offset: 0x00E37510
		public void TryExitCurrentGuide()
		{
			if (this.CurrentGuideData == null)
			{
				return;
			}
			if (this.GuideInterface != null)
			{
				this.GuideInterface.ExitCurrentGuide();
				this.GuideInterface = null;
			}
		}

		// Token: 0x060382AC RID: 230060 RVA: 0x00E39335 File Offset: 0x00E37535
		public void TryCacheGuideData(EBvbPlayerOperationType type, params object[] params_)
		{
			if (this.CurrentGuideData == null)
			{
				return;
			}
			if (this.CurrentGuideData.Type != type)
			{
				return;
			}
			this.CurrentGuideData.CacheGuideData(params_);
		}

		// Token: 0x060382AD RID: 230061 RVA: 0x00E3935B File Offset: 0x00E3755B
		public void TryFinishGuideByType(EBvbPlayerOperationType type, params object[] params_)
		{
			if (this.CurrentGuideData == null)
			{
				return;
			}
			if (this.CurrentGuideData.Type != type)
			{
				return;
			}
			if (!this.CurrentGuideData.CheckCanFinishGuide(params_))
			{
				return;
			}
			this.FinishCurrentGuide();
		}

		// Token: 0x17009069 RID: 36969
		// (get) Token: 0x060382AE RID: 230062 RVA: 0x00E3938A File Offset: 0x00E3758A
		public bool InGuiding
		{
			get
			{
				return this.CurrentGuideData != null || this.HasNextGuide;
			}
		}

		// Token: 0x060382AF RID: 230063 RVA: 0x00E3939C File Offset: 0x00E3759C
		public void ShowGuideTips()
		{
			if (this.CurrentGuideData != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(this.CurrentGuideData.Tips, Array.Empty<object>());
				return;
			}
			if (this.HasNextGuide)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_BvBPlayerOperationForbidden_Text", Array.Empty<object>());
			}
		}

		// Token: 0x04020164 RID: 131428
		private IPhantomArenaTabViewModelBase CurrentGuideData;

		// Token: 0x04020165 RID: 131429
		private IPhantomArenaGuideFunc GuideInterface;

		// Token: 0x04020166 RID: 131430
		private bool HasNextGuide;

		// Token: 0x04020167 RID: 131431
		protected PhantomArenaBattleProxy Proxy;
	}
}
