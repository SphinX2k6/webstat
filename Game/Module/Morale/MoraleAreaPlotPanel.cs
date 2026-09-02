using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005702 RID: 22274
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleAreaPlotPanel : UiPanelBase
	{
		// Token: 0x06038AFA RID: 232186 RVA: 0x00E5ABE0 File Offset: 0x00E58DE0
		public UniTask Init(UUIItem item, MoraleAreaData areaData)
		{
			MoraleAreaPlotPanel.<Init>d__5 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.areaData = areaData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleAreaPlotPanel.<Init>d__5>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038AFB RID: 232187 RVA: 0x00E5AC34 File Offset: 0x00E58E34
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < this.AllPlotIdList.Count; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x06038AFC RID: 232188 RVA: 0x00E5AC80 File Offset: 0x00E58E80
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaPlotPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaPlotPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038AFD RID: 232189 RVA: 0x00E5ACC4 File Offset: 0x00E58EC4
		private UniTask InitAreaPlotList()
		{
			MoraleAreaPlotPanel.<InitAreaPlotList>d__8 <InitAreaPlotList>d__;
			<InitAreaPlotList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAreaPlotList>d__.<>4__this = this;
			<InitAreaPlotList>d__.<>1__state = -1;
			<InitAreaPlotList>d__.<>t__builder.Start<MoraleAreaPlotPanel.<InitAreaPlotList>d__8>(ref <InitAreaPlotList>d__);
			return <InitAreaPlotList>d__.<>t__builder.Task;
		}

		// Token: 0x06038AFE RID: 232190 RVA: 0x00E5AD08 File Offset: 0x00E58F08
		private void AddAreaPlotItem(MoraleAreaPlotItem item)
		{
			this.PlotList.Add(item);
			this.PlotMap[item.PlotData.Id] = item;
			int flagId = item.PlotData.FlagId;
			List<MoraleAreaPlotItem> list;
			if (this.FlagToPlotMap.TryGetValue(flagId, out list))
			{
				list.Add(item);
				return;
			}
			this.FlagToPlotMap[flagId] = new List<MoraleAreaPlotItem>
			{
				item
			};
		}

		// Token: 0x06038AFF RID: 232191 RVA: 0x00E5AD74 File Offset: 0x00E58F74
		public void UpdatePlotState()
		{
			foreach (MoraleAreaPlotItem moraleAreaPlotItem in this.PlotList)
			{
				moraleAreaPlotItem.UpdatePlotState();
			}
		}

		// Token: 0x06038B00 RID: 232192 RVA: 0x00E5ADC4 File Offset: 0x00E58FC4
		public void HideAllPlot()
		{
			foreach (MoraleAreaPlotItem moraleAreaPlotItem in this.PlotList)
			{
				moraleAreaPlotItem.SetPlotActive(false);
			}
		}

		// Token: 0x06038B01 RID: 232193 RVA: 0x00E5AE18 File Offset: 0x00E59018
		public void ShowAllPlot()
		{
			foreach (MoraleAreaPlotItem moraleAreaPlotItem in this.PlotList)
			{
				moraleAreaPlotItem.SetPlotActive(true);
			}
		}

		// Token: 0x06038B02 RID: 232194 RVA: 0x00E5AE6C File Offset: 0x00E5906C
		public void UpdateData()
		{
			this.UpdatePlotState();
		}

		// Token: 0x04020510 RID: 132368
		public MoraleAreaData AreaData;

		// Token: 0x04020511 RID: 132369
		public readonly List<MoraleAreaPlotItem> PlotList = new List<MoraleAreaPlotItem>();

		// Token: 0x04020512 RID: 132370
		public readonly Dictionary<int, List<MoraleAreaPlotItem>> FlagToPlotMap = new Dictionary<int, List<MoraleAreaPlotItem>>();

		// Token: 0x04020513 RID: 132371
		public readonly Dictionary<int, MoraleAreaPlotItem> PlotMap = new Dictionary<int, MoraleAreaPlotItem>();

		// Token: 0x04020514 RID: 132372
		public IReadOnlyList<int> AllPlotIdList;
	}
}
