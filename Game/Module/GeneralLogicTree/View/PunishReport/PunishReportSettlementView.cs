using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.GeneralLogicTree.View.PunishReport
{
	// Token: 0x02005CCE RID: 23758
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportSettlementView : UiViewBase
	{
		// Token: 0x0603BE8A RID: 245386 RVA: 0x00F2ECD9 File Offset: 0x00F2CED9
		public PunishReportSettlementView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE8B RID: 245387 RVA: 0x00F2ECF8 File Offset: 0x00F2CEF8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603BE8C RID: 245388 RVA: 0x00F2ED64 File Offset: 0x00F2CF64
		protected override UniTask OnBeforeStartAsync()
		{
			PunishReportSettlementView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PunishReportSettlementView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE8D RID: 245389 RVA: 0x00F2EDA8 File Offset: 0x00F2CFA8
		private UniTask InitSuccessItem()
		{
			PunishReportSettlementView.<InitSuccessItem>d__8 <InitSuccessItem>d__;
			<InitSuccessItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSuccessItem>d__.<>4__this = this;
			<InitSuccessItem>d__.<>1__state = -1;
			<InitSuccessItem>d__.<>t__builder.Start<PunishReportSettlementView.<InitSuccessItem>d__8>(ref <InitSuccessItem>d__);
			return <InitSuccessItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603BE8E RID: 245390 RVA: 0x00F2EDEB File Offset: 0x00F2CFEB
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnRootSequenceClose), false);
		}

		// Token: 0x0603BE8F RID: 245391 RVA: 0x00F2EE16 File Offset: 0x00F2D016
		protected override void OnAfterShow()
		{
			this.GameSuccessItem.ShowTip().Forget();
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				UUIItem item = base.GetItem(0);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
			}, 1000f, null, null, true, 1f);
		}

		// Token: 0x0603BE90 RID: 245392 RVA: 0x00F2EE4C File Offset: 0x00F2D04C
		private void PlayConditionAnim()
		{
			foreach (PunishReportSettlementConditionItem punishReportSettlementConditionItem in this.ConditionItems)
			{
				punishReportSettlementConditionItem.PlaySequence().Finally(new Action(this.OnSequenceClose)).Forget();
			}
		}

		// Token: 0x0603BE91 RID: 245393 RVA: 0x00F2EEB4 File Offset: 0x00F2D0B4
		private void OnSequenceClose()
		{
			this.AnimFinishCount++;
			if (this.AnimFinishCount >= this.ConditionItems.Count)
			{
				TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
				}, 2000f, null, null, true, 1f);
			}
		}

		// Token: 0x0603BE92 RID: 245394 RVA: 0x00F2EF06 File Offset: 0x00F2D106
		private void OnRootSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start01")
			{
				this.PlayConditionAnim();
			}
		}

		// Token: 0x04021ACF RID: 137935
		private readonly PunishReportSettlementSuccessItem GameSuccessItem = new PunishReportSettlementSuccessItem();

		// Token: 0x04021AD0 RID: 137936
		private readonly List<PunishReportSettlementConditionItem> ConditionItems = new List<PunishReportSettlementConditionItem>();

		// Token: 0x04021AD1 RID: 137937
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04021AD2 RID: 137938
		private int AnimFinishCount;

		// Token: 0x0200BD4D RID: 48461
		[NullableContext(0)]
		private enum EViewComponent
		{
			// Token: 0x0403A539 RID: 238905
			ConditionItemRoot,
			// Token: 0x0403A53A RID: 238906
			ConditionItem
		}
	}
}
