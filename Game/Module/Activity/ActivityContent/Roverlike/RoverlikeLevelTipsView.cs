using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200640E RID: 25614
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLevelTipsView : UiViewBase
	{
		// Token: 0x060404E5 RID: 263397 RVA: 0x0107B613 File Offset: 0x01079813
		public RoverlikeLevelTipsView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060404E6 RID: 263398 RVA: 0x0107B61C File Offset: 0x0107981C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060404E7 RID: 263399 RVA: 0x0107B664 File Offset: 0x01079864
		protected override UniTask OnBeforeStartAsync()
		{
			RoverlikeLevelTipsView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoverlikeLevelTipsView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060404E8 RID: 263400 RVA: 0x0107B6A8 File Offset: 0x010798A8
		protected override void OnBeforeShow()
		{
			RoverlikeInstanceData instanceData = ModelBase<RoverlikeModel>.Instance.InstanceData;
			if (instanceData == null)
			{
				return;
			}
			this.RefreshLevelTips(instanceData);
		}

		// Token: 0x060404E9 RID: 263401 RVA: 0x0107B6CB File Offset: 0x010798CB
		protected override void OnFinishShow()
		{
			base.CloseMe(null);
		}

		// Token: 0x060404EA RID: 263402 RVA: 0x0107B6D4 File Offset: 0x010798D4
		private void OnSequencePlayEvent(string sequenceName, string eventName)
		{
			RoverlikeLevelTipsItem levelTips = this.LevelTips;
			if (levelTips == null)
			{
				return;
			}
			levelTips.PlayCurrentLevelSequence("Get");
		}

		// Token: 0x060404EB RID: 263403 RVA: 0x0107B6EC File Offset: 0x010798EC
		private void RefreshLevelTips(RoverlikeInstanceData instanceData)
		{
			RoverlikeLevelTipsItem levelTips = this.LevelTips;
			if (levelTips != null)
			{
				levelTips.Refresh(instanceData, false, null);
			}
			IReadOnlyList<RoverRogueRoad> roadByRoadType = ConfigBase<RoverlikeConfig>.Instance.GetRoadByRoadType(instanceData.RoadTypeId);
			int num = instanceData.CurLayer - 1;
			int? num2 = (num >= 0 && num < roadByRoadType.Count) ? new int?(roadByRoadType[num].LayerType) : null;
			bool effectPanelVisible = num2.GetValueOrDefault() == 2 || num2.GetValueOrDefault() == 3;
			RoverlikeLevelTipsItem levelTips2 = this.LevelTips;
			if (levelTips2 == null)
			{
				return;
			}
			levelTips2.SetEffectPanelVisible(effectPanelVisible);
		}

		// Token: 0x040240AD RID: 147629
		[Nullable(2)]
		private RoverlikeLevelTipsItem LevelTips;

		// Token: 0x0200C477 RID: 50295
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C78D RID: 247693
			public const int ItemLevelTips = 0;
		}
	}
}
