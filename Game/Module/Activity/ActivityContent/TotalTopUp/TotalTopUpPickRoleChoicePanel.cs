using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006270 RID: 25200
	[NullableContext(1)]
	[Nullable(0)]
	public class TotalTopUpPickRoleChoicePanel : UiPanelBase
	{
		// Token: 0x0603F7AC RID: 260012 RVA: 0x010468AC File Offset: 0x01044AAC
		public TotalTopUpPickRoleChoicePanel(List<ITotalTopUpPickRoleRewardItemData> rewardDataList)
		{
			this.RewardDataList = rewardDataList;
		}

		// Token: 0x0603F7AD RID: 260013 RVA: 0x010468DD File Offset: 0x01044ADD
		public void SetSelectCallback(Action<ITotalTopUpPickRoleRewardItemData> callback)
		{
			this.SelectCallBack = callback;
		}

		// Token: 0x0603F7AE RID: 260014 RVA: 0x010468E8 File Offset: 0x01044AE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			foreach (int item in this.PosNodeList)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(item, typeof(UUIItem)));
			}
		}

		// Token: 0x0603F7AF RID: 260015 RVA: 0x01046934 File Offset: 0x01044B34
		protected override UniTask OnBeforeStartAsync()
		{
			TotalTopUpPickRoleChoicePanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TotalTopUpPickRoleChoicePanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F7B0 RID: 260016 RVA: 0x01046977 File Offset: 0x01044B77
		private void OnClickItemCallback(ITotalTopUpPickRoleRewardItemData data)
		{
			this.SelectItem(data.Index);
		}

		// Token: 0x0603F7B1 RID: 260017 RVA: 0x01046988 File Offset: 0x01044B88
		public void SelectItem(int index)
		{
			for (int i = 0; i < this.RewardItems.Count; i++)
			{
				TotalTopUpPickRoleRewardItem totalTopUpPickRoleRewardItem = this.RewardItems[i];
				bool selected = i == index;
				totalTopUpPickRoleRewardItem.SetSelected(selected);
			}
			if (this.SelectCallBack != null)
			{
				ITotalTopUpPickRoleRewardItemData obj = this.RewardDataList[index];
				this.SelectCallBack(obj);
			}
		}

		// Token: 0x04023A23 RID: 145955
		private readonly int[] PosNodeList = new int[]
		{
			0,
			1,
			2,
			3
		};

		// Token: 0x04023A24 RID: 145956
		private readonly List<TotalTopUpPickRoleRewardItem> RewardItems = new List<TotalTopUpPickRoleRewardItem>();

		// Token: 0x04023A25 RID: 145957
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<ITotalTopUpPickRoleRewardItemData> SelectCallBack;

		// Token: 0x04023A26 RID: 145958
		private readonly List<ITotalTopUpPickRoleRewardItemData> RewardDataList;
	}
}
