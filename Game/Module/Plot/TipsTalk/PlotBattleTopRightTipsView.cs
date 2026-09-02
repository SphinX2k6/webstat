using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.TipsTalk
{
	// Token: 0x02005380 RID: 21376
	[NullableContext(2)]
	[Nullable(0)]
	public class PlotBattleTopRightTipsView : PlotTipsViewBase
	{
		// Token: 0x06036839 RID: 223289 RVA: 0x00DC6F4D File Offset: 0x00DC514D
		public PlotBattleTopRightTipsView()
		{
			this.ResourceId = "UiItem_MainTalk";
		}

		// Token: 0x0603683A RID: 223290 RVA: 0x00DC6F60 File Offset: 0x00DC5160
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603683B RID: 223291 RVA: 0x00DC700C File Offset: 0x00DC520C
		protected override void OnInit()
		{
			this.IconItem = base.GetTexture(0);
			this.SubtitleItem = base.GetText(1);
			this.IconItem.GetParentAsUIItem().SetUIItemAlpha(0f);
			this.SubtitleItem.GetParentAsUIItem().SetUIItemAlpha(0f);
			this.TweenInComp = (base.GetItem(2).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			if (this.TweenInComp != null)
			{
				this.TweenInComp.Stop();
			}
			this.TweenOutComp = (base.GetItem(3).GetOwner().GetComponentByClass(ULGUIPlayTweenComponent.StaticClass()) as ULGUIPlayTweenComponent);
			if (this.TweenOutComp != null)
			{
				this.TweenOutComp.Stop();
				this.TweenOutEndDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLGUIPlayTweenCompleteDynamicDelegate>(new Action(this.OnTweenOutEndDelegate));
				this.TweenOutEndDelegateWrapper = this.TweenOutComp.GetPlayTween().RegisterOnComplete(this.TweenOutEndDelegate);
			}
		}

		// Token: 0x0603683C RID: 223292 RVA: 0x00DC7104 File Offset: 0x00DC5304
		protected override void OnAfterShow()
		{
			bool isHang = base.IsHang;
			base.OnAfterShow();
			if (this.TweenInComp != null && !isHang)
			{
				this.TweenInComp.Play();
			}
		}

		// Token: 0x0603683D RID: 223293 RVA: 0x00DC7134 File Offset: 0x00DC5334
		protected override UniTask OnHideAsyncImplementImplement()
		{
			if (this.TweenOutComp != null && !base.IsHang)
			{
				this.TweenOutPromise = new CustomPromise<bool>();
				this.TweenOutComp.Play();
				return this.TweenOutPromise.Promise.AsUniTask();
			}
			return UniTask.CompletedTask;
		}

		// Token: 0x0603683E RID: 223294 RVA: 0x00DC7180 File Offset: 0x00DC5380
		protected override void OnBeforeDestroy()
		{
			if (this.TweenOutEndDelegate != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action(this.OnTweenOutEndDelegate));
				this.TweenOutEndDelegate = null;
			}
			if (this.TweenOutEndDelegateWrapper != null)
			{
				this.TweenOutComp.GetPlayTween().UnregisterOnComplete(this.TweenOutEndDelegateWrapper);
				this.TweenOutEndDelegateWrapper = null;
			}
		}

		// Token: 0x0603683F RID: 223295 RVA: 0x00DC71D8 File Offset: 0x00DC53D8
		private void OnTweenOutEndDelegate()
		{
			this.TweenOutPromise.SetResult(true);
			this.TweenOutPromise = null;
		}

		// Token: 0x06036840 RID: 223296 RVA: 0x00DC71F0 File Offset: 0x00DC53F0
		protected override UUIItem GetParentItem()
		{
			EUiViewName? viewName = base.GetViewName();
			if (viewName != null)
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(viewName.Value);
				if (viewByName != null)
				{
					return viewByName.GetRootItem();
				}
			}
			return base.GetParentItem();
		}

		// Token: 0x0401F637 RID: 128567
		private ULGUIPlayTweenComponent TweenInComp;

		// Token: 0x0401F638 RID: 128568
		private ULGUIPlayTweenComponent TweenOutComp;

		// Token: 0x0401F639 RID: 128569
		private FLGUIPlayTweenCompleteDynamicDelegate TweenOutEndDelegate;

		// Token: 0x0401F63A RID: 128570
		private FLGUIDelegateHandleWrapper TweenOutEndDelegateWrapper;

		// Token: 0x0401F63B RID: 128571
		private CustomPromise<bool> TweenOutPromise;

		// Token: 0x0200B2CB RID: 45771
		[NullableContext(0)]
		private static class EChildCom
		{
			// Token: 0x040376B6 RID: 226998
			public const int Icon = 0;

			// Token: 0x040376B7 RID: 226999
			public const int Text = 1;

			// Token: 0x040376B8 RID: 227000
			public const int TweenIn = 2;

			// Token: 0x040376B9 RID: 227001
			public const int TweenOut = 3;
		}
	}
}
