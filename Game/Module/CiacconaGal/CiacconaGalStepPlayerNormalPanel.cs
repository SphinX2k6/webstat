using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EBE RID: 24254
	[NullableContext(2)]
	[Nullable(0)]
	public class CiacconaGalStepPlayerNormalPanel : UiPanelBase
	{
		// Token: 0x0603CF5F RID: 249695 RVA: 0x00F7B800 File Offset: 0x00F79A00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603CF60 RID: 249696 RVA: 0x00F7B88C File Offset: 0x00F79A8C
		protected override void OnStart()
		{
			this.ScrollComponent = base.GetScrollViewWithScrollbar(0);
			this.ScrollView = new GenericScrollViewNew<CiacconaGalStepItemContainer, CiacconaGalStepData>(this.ScrollComponent, new Func<CiacconaGalStepItemContainer>(this.GetStepItemContainer), null, false, null);
			this.ScrollComponent.OnScrollViewDownUpCallback.Bind(new Action<ULGUIPointerEventData>(this.OnScrollViewPointerUp));
			this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603CF61 RID: 249697 RVA: 0x00F7B8F4 File Offset: 0x00F79AF4
		protected override UniTask OnBeforeStartAsync()
		{
			CiacconaGalStepPlayerNormalPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaGalStepPlayerNormalPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF62 RID: 249698 RVA: 0x00F7B938 File Offset: 0x00F79B38
		protected override void OnBeforeDestroy()
		{
			if (this.ScrollComponent != null)
			{
				this.ScrollComponent.OnScrollViewDownUpCallback.Unbind();
				if (this.ScrollComponent.Tweener != null)
				{
					this.ScrollComponent.Tweener.OnStartCallBack.Unbind();
					this.ScrollComponent.Tweener.OnCompleteCallBack.Unbind();
				}
			}
			if (this.ScrollDelayTimerHandle != null && TimerSystem.Instance.Has(this.ScrollDelayTimerHandle))
			{
				TimerSystem.Instance.Remove(this.ScrollDelayTimerHandle);
				this.ScrollDelayTimerHandle = null;
			}
		}

		// Token: 0x0603CF63 RID: 249699 RVA: 0x00F7B9C6 File Offset: 0x00F79BC6
		public void Refresh()
		{
			this.RefreshImp().Forget();
		}

		// Token: 0x0603CF64 RID: 249700 RVA: 0x00F7B9D4 File Offset: 0x00F79BD4
		public void PlayStart()
		{
			LevelSequencePlayer seqPlayer = this.SeqPlayer;
			if (seqPlayer == null)
			{
				return;
			}
			seqPlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x0603CF65 RID: 249701 RVA: 0x00F7BA04 File Offset: 0x00F79C04
		public UniTask PlayCloseAsync()
		{
			CiacconaGalStepPlayerNormalPanel.<PlayCloseAsync>d__12 <PlayCloseAsync>d__;
			<PlayCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayCloseAsync>d__.<>4__this = this;
			<PlayCloseAsync>d__.<>1__state = -1;
			<PlayCloseAsync>d__.<>t__builder.Start<CiacconaGalStepPlayerNormalPanel.<PlayCloseAsync>d__12>(ref <PlayCloseAsync>d__);
			return <PlayCloseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF66 RID: 249702 RVA: 0x00F7BA48 File Offset: 0x00F79C48
		private UniTask RefreshImp()
		{
			CiacconaGalStepPlayerNormalPanel.<RefreshImp>d__13 <RefreshImp>d__;
			<RefreshImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshImp>d__.<>4__this = this;
			<RefreshImp>d__.<>1__state = -1;
			<RefreshImp>d__.<>t__builder.Start<CiacconaGalStepPlayerNormalPanel.<RefreshImp>d__13>(ref <RefreshImp>d__);
			return <RefreshImp>d__.<>t__builder.Task;
		}

		// Token: 0x0603CF67 RID: 249703 RVA: 0x00F7BA8B File Offset: 0x00F79C8B
		[NullableContext(1)]
		private CiacconaGalStepItemContainer GetStepItemContainer()
		{
			return new CiacconaGalStepItemContainer();
		}

		// Token: 0x0603CF68 RID: 249704 RVA: 0x00F7BA94 File Offset: 0x00F79C94
		private void OnScrollViewPointerUp(ULGUIPointerEventData eventData)
		{
			if (eventData == null)
			{
				return;
			}
			if (eventData.dragComponent == null)
			{
				ControllerBase<CiacconaGalController>.Instance.GalPlayer.OnClick(null);
			}
		}

		// Token: 0x0603CF69 RID: 249705 RVA: 0x00F7BAC8 File Offset: 0x00F79CC8
		private void OnScrollTweenStart()
		{
			UUIScrollViewWithScrollbarComponent scrollComponent = this.ScrollComponent;
			if (scrollComponent == null)
			{
				return;
			}
			scrollComponent.ContentUIItem.Get().SetBubbleUpToParent(false);
		}

		// Token: 0x0603CF6A RID: 249706 RVA: 0x00F7BAF4 File Offset: 0x00F79CF4
		private void OnScrollTweenEnd()
		{
			UUIScrollViewWithScrollbarComponent scrollComponent = this.ScrollComponent;
			if (scrollComponent == null)
			{
				return;
			}
			scrollComponent.ContentUIItem.Get().SetBubbleUpToParent(true);
		}

		// Token: 0x0603CF6B RID: 249707 RVA: 0x00F7BB20 File Offset: 0x00F79D20
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "ChoicesSelect" || a == "FirstChoice")
			{
				foreach (CiacconaGalStepItemContainer ciacconaGalStepItemContainer in this.ScrollView.GetScrollItemList())
				{
					UUIItem[] guideUiItemAndUiItemForShowEx = ciacconaGalStepItemContainer.GetGuideUiItemAndUiItemForShowEx(configParams);
					if (guideUiItemAndUiItemForShowEx != null)
					{
						return guideUiItemAndUiItemForShowEx;
					}
				}
			}
			return null;
		}

		// Token: 0x0402237D RID: 140157
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<CiacconaGalStepItemContainer, CiacconaGalStepData> ScrollView;

		// Token: 0x0402237E RID: 140158
		private UUIScrollViewWithScrollbarComponent ScrollComponent;

		// Token: 0x0402237F RID: 140159
		private CiacconaGalFinishBtnItem BtnFinish;

		// Token: 0x04022380 RID: 140160
		private TimerHandle ScrollDelayTimerHandle;

		// Token: 0x04022381 RID: 140161
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200BEAF RID: 48815
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403AB2D RID: 240429
			public const int ScrollView = 0;

			// Token: 0x0403AB2E RID: 240430
			public const int LayoutContent = 1;

			// Token: 0x0403AB2F RID: 240431
			public const int ItemBtnFinish = 2;
		}
	}
}
