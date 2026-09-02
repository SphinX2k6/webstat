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
	// Token: 0x02005952 RID: 22866
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueExploreView : UiViewBase
	{
		// Token: 0x06039F88 RID: 237448 RVA: 0x00EABE34 File Offset: 0x00EAA034
		public MapRogueExploreView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039F89 RID: 237449 RVA: 0x00EABE40 File Offset: 0x00EAA040
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText))
			};
		}

		// Token: 0x06039F8A RID: 237450 RVA: 0x00EABEB0 File Offset: 0x00EAA0B0
		protected override UniTask OnBeforeStartAsync()
		{
			MapRogueExploreView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MapRogueExploreView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039F8B RID: 237451 RVA: 0x00EABEF4 File Offset: 0x00EAA0F4
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
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, rogueResInstGrid.Value.Title, Array.Empty<object>());
			GenericScrollViewNew<RogueExploreListItem, IExploreData> listLayout = this.ListLayout;
			if (listLayout == null)
			{
				return;
			}
			listLayout.RefreshByData(gameInfo.GetAllExplorationData(), null, true);
		}

		// Token: 0x06039F8C RID: 237452 RVA: 0x00EABF7A File Offset: 0x00EAA17A
		private RogueExploreListItem CreateItem()
		{
			return new RogueExploreListItem();
		}

		// Token: 0x06039F8D RID: 237453 RVA: 0x00EABF81 File Offset: 0x00EAA181
		private void OnBackBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x04020DA7 RID: 134567
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RogueExploreListItem, IExploreData> ListLayout;

		// Token: 0x04020DA8 RID: 134568
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;
	}
}
