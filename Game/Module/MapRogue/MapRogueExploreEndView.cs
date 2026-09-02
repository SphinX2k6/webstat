using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005950 RID: 22864
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueExploreEndView : UiViewBase
	{
		// Token: 0x06039F7F RID: 237439 RVA: 0x00EABC27 File Offset: 0x00EA9E27
		public MapRogueExploreEndView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039F80 RID: 237440 RVA: 0x00EABC30 File Offset: 0x00EA9E30
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnBtnResultClick)),
				new ValueTuple<int, Delegate>(4, new Action(this.OnBtnSaveFileClick))
			};
		}

		// Token: 0x06039F81 RID: 237441 RVA: 0x00EABD08 File Offset: 0x00EA9F08
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueExploreEndView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueExploreEndView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039F82 RID: 237442 RVA: 0x00EABD4C File Offset: 0x00EA9F4C
		protected override void OnBeforeShow()
		{
			MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
			if (gameInfo == null)
			{
				return;
			}
			MapRogueConfig instance = ConfigBase<MapRogueConfig>.Instance;
			RogueResInstGrid? rogueResInstGrid = (instance != null) ? instance.GetInsGridConfigByInstId(gameInfo.InstanceId) : null;
			if (rogueResInstGrid == null)
			{
				return;
			}
			UUIText text = base.GetText(5);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, rogueResInstGrid.Value.Title, Array.Empty<object>());
			GenericScrollViewNew<RogueExploreListItem, IExploreData> listLayout = this.ListLayout;
			if (listLayout == null)
			{
				return;
			}
			listLayout.RefreshByData(gameInfo.GetAllExplorationData(), null, true);
		}

		// Token: 0x06039F83 RID: 237443 RVA: 0x00EABDD2 File Offset: 0x00EA9FD2
		private RogueExploreListItem CreateItem()
		{
			return new RogueExploreListItem();
		}

		// Token: 0x06039F84 RID: 237444 RVA: 0x00EABDD9 File Offset: 0x00EA9FD9
		private void OnBackBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x06039F85 RID: 237445 RVA: 0x00EABDE2 File Offset: 0x00EA9FE2
		private void OnBtnResultClick()
		{
			ControllerBase<MapRogueController>.Instance.RequestInstResultEnd().Forget();
		}

		// Token: 0x06039F86 RID: 237446 RVA: 0x00EABDF3 File Offset: 0x00EA9FF3
		private void OnBtnSaveFileClick()
		{
			if ((this.OpenParam as ExploreEndViewData).ExitToMap)
			{
				ControllerBase<MapRogueController>.Instance.RequestBackToMap(delegate(bool success)
				{
					if (success)
					{
						base.CloseMe(null);
					}
				});
				return;
			}
			ControllerBase<MapRogueController>.Instance.RequestInstLeave();
		}

		// Token: 0x04020DA0 RID: 134560
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueExploreListItem, IExploreData> ListLayout;

		// Token: 0x04020DA1 RID: 134561
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;
	}
}
