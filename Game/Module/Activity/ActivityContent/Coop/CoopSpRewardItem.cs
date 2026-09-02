using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069A5 RID: 27045
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CoopSpRewardItem : GridProxyAbstract<CoopSpRewardData>
	{
		// Token: 0x06043142 RID: 274754 RVA: 0x0113A8AC File Offset: 0x01138AAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickRewardBtn))
			};
		}

		// Token: 0x06043143 RID: 274755 RVA: 0x0113A96B File Offset: 0x01138B6B
		protected override void OnStart()
		{
			this.RewardItem = new CommonItemSmallItemGrid();
			this.RewardItem.Initialize(base.GetItem(2).GetOwner());
		}

		// Token: 0x06043144 RID: 274756 RVA: 0x0113A990 File Offset: 0x01138B90
		public override void Refresh(CoopSpRewardData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.GetConfig.Value.ShowText, Array.Empty<object>());
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			int value = Math.Min((((instance != null) ? instance.GetActivityById(this.CurrentData.GetConfig.Value.ActivityId) : null) as CoopActivityData).GetCurTotalCoopLevel(), data.GetConfig.Value.RoleLevelSum);
			UUIText text = base.GetText(1);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/<color=#b4aaca>");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetConfig.Value.RoleLevelSum);
			defaultInterpolatedStringHandler.AppendLiteral("</color>");
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			TItem titem = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.GetConfig.Value.Reward)[0];
			this.RewardItem.RefreshByConfigId(titem.ItemData.ItemId, new int?(titem.Count), null, data.State == ECoopSpRewardState.Done, false);
			this.RefreshRewardState(data.State);
		}

		// Token: 0x06043145 RID: 274757 RVA: 0x0113AADC File Offset: 0x01138CDC
		private void RefreshRewardState(ECoopSpRewardState state)
		{
			bool uiactive = state == ECoopSpRewardState.Reward;
			bool uiactive2 = state == ECoopSpRewardState.Done;
			base.GetButton(3).RootUIComp.Get().SetUIActive(uiactive);
			base.GetSprite(4).SetUIActive(uiactive2);
			base.GetItem(5).SetUIActive(state == ECoopSpRewardState.Lock);
		}

		// Token: 0x06043146 RID: 274758 RVA: 0x0113AB2A File Offset: 0x01138D2A
		private void OnClickRewardBtn()
		{
			if (this.CurrentData != null)
			{
				this.OnRewardBtnClick();
			}
		}

		// Token: 0x04025617 RID: 153111
		[Nullable(2)]
		private CoopSpRewardData CurrentData;

		// Token: 0x04025618 RID: 153112
		public Action OnRewardBtnClick = delegate()
		{
		};

		// Token: 0x04025619 RID: 153113
		[Nullable(2)]
		private CommonItemSmallItemGrid RewardItem;
	}
}
