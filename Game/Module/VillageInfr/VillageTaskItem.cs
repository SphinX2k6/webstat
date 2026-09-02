using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C21 RID: 19489
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VillageTaskItem : GridProxyAbstract<VillageInfrLimitTaskData>
	{
		// Token: 0x06032D35 RID: 208181 RVA: 0x00CBC3DC File Offset: 0x00CBA5DC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUISprite)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(8, new Action(this.OnClickConfirm))
			};
		}

		// Token: 0x06032D36 RID: 208182 RVA: 0x00CBC4DD File Offset: 0x00CBA6DD
		protected override void OnStart()
		{
			this.RewardScroll = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), () => new CommonItemSmallItemGrid(), null, false, true);
		}

		// Token: 0x06032D37 RID: 208183 RVA: 0x00CBC514 File Offset: 0x00CBA714
		public override void Refresh(VillageInfrLimitTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			InfrV2Reward? infrActivityTaskConfig = ConfigBase<VillageInfrConfig>.Instance.GetInfrActivityTaskConfig(this.Data.ConfigId);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(this.Data.TaskReward);
			this.RewardScroll.RefreshByData(dropPackagePreviewItemList, null, false);
			ConditionTaskState status = data.Status;
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			base.GetText(5).SetUIActive(status == ConditionTaskState.ConditionTaskRunning);
			base.GetSprite(6).SetUIActive(status == ConditionTaskState.ConditionTaskTaken);
			base.GetItem(7).SetUIActive(status == ConditionTaskState.ConditionTaskFinish);
			base.GetButton(8).RootUIComp.Get().SetUIActive(status == ConditionTaskState.ConditionTaskFinish);
			base.GetText(0).ShowTextNew(infrActivityTaskConfig.Value.Desc);
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Current);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Target);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06032D38 RID: 208184 RVA: 0x00CBC639 File Offset: 0x00CBA839
		public void SetOnClickConfirm([Nullable(new byte[]
		{
			2,
			1
		})] Action<VillageInfrLimitTaskData> callback)
		{
			this.OnClickConfirmCb = callback;
		}

		// Token: 0x06032D39 RID: 208185 RVA: 0x00CBC642 File Offset: 0x00CBA842
		private void OnClickConfirm()
		{
			Action<VillageInfrLimitTaskData> onClickConfirmCb = this.OnClickConfirmCb;
			if (onClickConfirmCb == null)
			{
				return;
			}
			onClickConfirmCb(this.Data);
		}

		// Token: 0x0401D965 RID: 121189
		[Nullable(2)]
		private VillageInfrLimitTaskData Data;

		// Token: 0x0401D966 RID: 121190
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<VillageInfrLimitTaskData> OnClickConfirmCb;

		// Token: 0x0401D967 RID: 121191
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardScroll;
	}
}
