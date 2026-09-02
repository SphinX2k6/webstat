using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200571D RID: 22301
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleScoreProgressRewardItem : GridProxyAbstract<MoraleProgressRewardData>
	{
		// Token: 0x06038C20 RID: 232480 RVA: 0x00E5F254 File Offset: 0x00E5D454
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleScoreProgressRewardItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleScoreProgressRewardItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038C21 RID: 232481 RVA: 0x00E5F297 File Offset: 0x00E5D497
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06038C22 RID: 232482 RVA: 0x00E5F2D0 File Offset: 0x00E5D4D0
		public override void Refresh(MoraleProgressRewardData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = this.ItemData,
				ItemConfigId = new int?(this.ItemData.ItemId),
				IsRedDotVisible = new bool?(this.ItemData.IsCanReceived),
				IsReceivedVisible = new bool?(this.ItemData.IsReceived),
				IsReceivableVisible = new bool?(this.ItemData.IsCanReceived),
				BottomText = this.GetCountStr()
			};
			this.RewardItem.Apply<PropSmallItemGrid>(parameters);
		}

		// Token: 0x06038C23 RID: 232483 RVA: 0x00E5F366 File Offset: 0x00E5D566
		public string GetCountStr()
		{
			if (this.ItemData.ItemNum > 0)
			{
				return this.ItemData.ItemNum.ToString();
			}
			return "";
		}

		// Token: 0x06038C24 RID: 232484 RVA: 0x00E5F38C File Offset: 0x00E5D58C
		private void OnClickReward(MediumItemGridExtendCallback _)
		{
			Action<MoraleProgressRewardData> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack(this.ItemData);
		}

		// Token: 0x04020558 RID: 132440
		public MoraleProgressRewardData ItemData;

		// Token: 0x04020559 RID: 132441
		public SmallItemGrid RewardItem;

		// Token: 0x0402055A RID: 132442
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MoraleProgressRewardData> ClickCallBack;

		// Token: 0x0200B7C5 RID: 47045
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D83 RID: 232835
			public const int ItemSelf = 0;

			// Token: 0x04038D84 RID: 232836
			public const int ItemReward = 1;
		}
	}
}
