using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View
{
	// Token: 0x02004F0E RID: 20238
	[NullableContext(1)]
	[Nullable(0)]
	public class CubeResultItem : UiPanelBase
	{
		// Token: 0x060344EB RID: 214251 RVA: 0x00D168ED File Offset: 0x00D14AED
		public CubeResultItem(int score, bool isNewRecord, List<TItem> rewardList)
		{
			this.Score = score;
			this.IsNewRecord = isNewRecord;
			this.RewardList = rewardList;
		}

		// Token: 0x060344EC RID: 214252 RVA: 0x00D16918 File Offset: 0x00D14B18
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060344ED RID: 214253 RVA: 0x00D16A6C File Offset: 0x00D14C6C
		protected override UniTask OnBeforeStartAsync()
		{
			CubeResultItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CubeResultItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060344EE RID: 214254 RVA: 0x00D16AB0 File Offset: 0x00D14CB0
		private UniTask InitRewardItem(ETetrisPlayMode playMode)
		{
			CubeResultItem.<InitRewardItem>d__10 <InitRewardItem>d__;
			<InitRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRewardItem>d__.<>4__this = this;
			<InitRewardItem>d__.playMode = playMode;
			<InitRewardItem>d__.<>1__state = -1;
			<InitRewardItem>d__.<>t__builder.Start<CubeResultItem.<InitRewardItem>d__10>(ref <InitRewardItem>d__);
			return <InitRewardItem>d__.<>t__builder.Task;
		}

		// Token: 0x060344EF RID: 214255 RVA: 0x00D16AFB File Offset: 0x00D14CFB
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x060344F0 RID: 214256 RVA: 0x00D16B04 File Offset: 0x00D14D04
		private UniTask InitTargetItem()
		{
			CubeResultItem.<InitTargetItem>d__12 <InitTargetItem>d__;
			<InitTargetItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTargetItem>d__.<>4__this = this;
			<InitTargetItem>d__.<>1__state = -1;
			<InitTargetItem>d__.<>t__builder.Start<CubeResultItem.<InitTargetItem>d__12>(ref <InitTargetItem>d__);
			return <InitTargetItem>d__.<>t__builder.Task;
		}

		// Token: 0x060344F1 RID: 214257 RVA: 0x00D16B48 File Offset: 0x00D14D48
		protected override UniTask OnShowAsyncImplementImplement()
		{
			CubeResultItem.<OnShowAsyncImplementImplement>d__13 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<CubeResultItem.<OnShowAsyncImplementImplement>d__13>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060344F2 RID: 214258 RVA: 0x00D16B8B File Offset: 0x00D14D8B
		protected override void OnAfterShow()
		{
			if (ModelBase<SlidingBlocksModel>.Instance.GameData.PlayMode == ETetrisPlayMode.Endless)
			{
				UUIText text = base.GetText(1);
				if (text == null)
				{
					return;
				}
				UUIItem parentAsUIItem = text.GetParentAsUIItem();
				if (parentAsUIItem == null)
				{
					return;
				}
				parentAsUIItem.SetUIActive(this.IsNewRecord);
			}
		}

		// Token: 0x0401E2CA RID: 123594
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0401E2CB RID: 123595
		private readonly List<SettlementTargetItem> TargetItems = new List<SettlementTargetItem>();

		// Token: 0x0401E2CC RID: 123596
		[Nullable(2)]
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0401E2CD RID: 123597
		public readonly int Score;

		// Token: 0x0401E2CE RID: 123598
		public readonly bool IsNewRecord;

		// Token: 0x0401E2CF RID: 123599
		public readonly List<TItem> RewardList;

		// Token: 0x0200AF35 RID: 44853
		[NullableContext(0)]
		private enum EViewComponent
		{
			// Token: 0x040365F2 RID: 222706
			ScoreText,
			// Token: 0x040365F3 RID: 222707
			NewRecordText,
			// Token: 0x040365F4 RID: 222708
			TargetItemNode,
			// Token: 0x040365F5 RID: 222709
			TargetItem,
			// Token: 0x040365F6 RID: 222710
			RewardItemNode,
			// Token: 0x040365F7 RID: 222711
			RewardItem,
			// Token: 0x040365F8 RID: 222712
			PanelTop,
			// Token: 0x040365F9 RID: 222713
			PanelNone,
			// Token: 0x040365FA RID: 222714
			PanelBg
		}
	}
}
