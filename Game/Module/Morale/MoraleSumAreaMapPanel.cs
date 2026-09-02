using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571E RID: 22302
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleSumAreaMapPanel : UiPanelBase
	{
		// Token: 0x06038C27 RID: 232487 RVA: 0x00E5F3B4 File Offset: 0x00E5D5B4
		public UniTask Init(UUIItem item, MoraleAreaData areaData)
		{
			MoraleSumAreaMapPanel.<Init>d__4 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.areaData = areaData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleSumAreaMapPanel.<Init>d__4>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C28 RID: 232488 RVA: 0x00E5F408 File Offset: 0x00E5D608
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSelf))
			};
		}

		// Token: 0x06038C29 RID: 232489 RVA: 0x00E5F4C8 File Offset: 0x00E5D6C8
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleSumAreaMapPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleSumAreaMapPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038C2A RID: 232490 RVA: 0x00E5F50B File Offset: 0x00E5D70B
		public void UpdateData()
		{
			this.AreaTitle.UpdateData();
			MoraleAreaPlotPanel areaPlotPanel = this.AreaPlotPanel;
			if (areaPlotPanel != null)
			{
				areaPlotPanel.UpdateData();
			}
			this.CheckAreaLight();
		}

		// Token: 0x06038C2B RID: 232491 RVA: 0x00E5F52F File Offset: 0x00E5D72F
		public void InitData()
		{
			this.AreaTitle.UpdateData();
			this.AreaPlotPanel.HideAllPlot();
			this.CheckAreaLight();
		}

		// Token: 0x06038C2C RID: 232492 RVA: 0x00E5F550 File Offset: 0x00E5D750
		public void CheckAreaLight()
		{
			bool uiactive = this.AreaData.IsAllUiFlagActive();
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06038C2D RID: 232493 RVA: 0x00E5F57B File Offset: 0x00E5D77B
		public void SetRecommendLightActive(bool active)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x06038C2E RID: 232494 RVA: 0x00E5F58F File Offset: 0x00E5D78F
		private void OnBtnSelf()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.MoraleAreaInfoView, new MoraleAreaInfoView.Params
			{
				AreaId = this.AreaData.Id
			}, null);
		}

		// Token: 0x06038C2F RID: 232495 RVA: 0x00E5F5B8 File Offset: 0x00E5D7B8
		public UniTask PlayEnterEffect(IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			MoraleSumAreaMapPanel.<PlayEnterEffect>d__12 <PlayEnterEffect>d__;
			<PlayEnterEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEnterEffect>d__.<>4__this = this;
			<PlayEnterEffect>d__.plotList = plotList;
			<PlayEnterEffect>d__.<>1__state = -1;
			<PlayEnterEffect>d__.<>t__builder.Start<MoraleSumAreaMapPanel.<PlayEnterEffect>d__12>(ref <PlayEnterEffect>d__);
			return <PlayEnterEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038C30 RID: 232496 RVA: 0x00E5F604 File Offset: 0x00E5D804
		public UniTask PlayLoopEffect(IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			MoraleSumAreaMapPanel.<PlayLoopEffect>d__13 <PlayLoopEffect>d__;
			<PlayLoopEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayLoopEffect>d__.<>4__this = this;
			<PlayLoopEffect>d__.plotList = plotList;
			<PlayLoopEffect>d__.<>1__state = -1;
			<PlayLoopEffect>d__.<>t__builder.Start<MoraleSumAreaMapPanel.<PlayLoopEffect>d__13>(ref <PlayLoopEffect>d__);
			return <PlayLoopEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038C31 RID: 232497 RVA: 0x00E5F650 File Offset: 0x00E5D850
		public UniTask PlayNewUnlockEffect(IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			MoraleSumAreaMapPanel.<PlayNewUnlockEffect>d__14 <PlayNewUnlockEffect>d__;
			<PlayNewUnlockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayNewUnlockEffect>d__.<>4__this = this;
			<PlayNewUnlockEffect>d__.plotList = plotList;
			<PlayNewUnlockEffect>d__.<>1__state = -1;
			<PlayNewUnlockEffect>d__.<>t__builder.Start<MoraleSumAreaMapPanel.<PlayNewUnlockEffect>d__14>(ref <PlayNewUnlockEffect>d__);
			return <PlayNewUnlockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038C32 RID: 232498 RVA: 0x00E5F69B File Offset: 0x00E5D89B
		public void LogIdList(List<int> idList, string title)
		{
		}

		// Token: 0x06038C33 RID: 232499 RVA: 0x00E5F6A0 File Offset: 0x00E5D8A0
		public List<MoraleAreaPlotItem> GetBelongCurAreaPlotItemList(IReadOnlyList<MoraleAreaPlotData> plotList)
		{
			Dictionary<int, MoraleAreaPlotItem> plotMap = this.AreaPlotPanel.PlotMap;
			List<MoraleAreaPlotItem> list = new List<MoraleAreaPlotItem>();
			for (int i = 0; i < plotList.Count; i++)
			{
				MoraleAreaPlotData moraleAreaPlotData = plotList[i];
				MoraleAreaPlotItem item;
				if (moraleAreaPlotData.AreaId == this.AreaData.Id && plotMap.TryGetValue(moraleAreaPlotData.Id, out item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x06038C34 RID: 232500 RVA: 0x00E5F704 File Offset: 0x00E5D904
		public void OnTick(float delta)
		{
			for (int i = 0; i < this.AreaPlotPanel.PlotList.Count; i++)
			{
				this.AreaPlotPanel.PlotList[i].OnTick(delta);
			}
		}

		// Token: 0x0402055B RID: 132443
		public MoraleAreaData AreaData;

		// Token: 0x0402055C RID: 132444
		public MoraleSumAreaTitleItem AreaTitle;

		// Token: 0x0402055D RID: 132445
		public MoraleAreaPlotPanel AreaPlotPanel;

		// Token: 0x0200B7C8 RID: 47048
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D8B RID: 232843
			public const int BtnSelf = 0;

			// Token: 0x04038D8C RID: 232844
			public const int ItemAreaTitle = 1;

			// Token: 0x04038D8D RID: 232845
			public const int TexMapBg = 2;

			// Token: 0x04038D8E RID: 232846
			public const int ItemPlotPanel = 3;

			// Token: 0x04038D8F RID: 232847
			public const int ItemAreaLight = 4;

			// Token: 0x04038D90 RID: 232848
			public const int ItemRecommendLight = 5;
		}
	}
}
