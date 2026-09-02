using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BE RID: 26302
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorParkourBattleView : UiTickViewBase
	{
		// Token: 0x06041AC0 RID: 268992 RVA: 0x010D6FB7 File Offset: 0x010D51B7
		public MotorParkourBattleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06041AC1 RID: 268993 RVA: 0x010D6FC0 File Offset: 0x010D51C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041AC2 RID: 268994 RVA: 0x010D704A File Offset: 0x010D524A
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, float>(EEventName.MotorParkourFinishLap, new Action<int, float>(this.OnMotorParkourFinishLap));
		}

		// Token: 0x06041AC3 RID: 268995 RVA: 0x010D7068 File Offset: 0x010D5268
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, float>(EEventName.MotorParkourFinishLap, new Action<int, float>(this.OnMotorParkourFinishLap));
		}

		// Token: 0x06041AC4 RID: 268996 RVA: 0x010D7088 File Offset: 0x010D5288
		protected override UniTask OnBeforeStartAsync()
		{
			MotorParkourBattleView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MotorParkourBattleView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041AC5 RID: 268997 RVA: 0x010D70CB File Offset: 0x010D52CB
		protected override void OnTick(float delta)
		{
			this.MissionPanel.OnTickBattleChildViewPanel(delta);
			this.MapItem.UpdatePlayerPosition();
		}

		// Token: 0x06041AC6 RID: 268998 RVA: 0x010D70E4 File Offset: 0x010D52E4
		protected override void OnBeforeDestroy()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildrenVisible(EBattleUiVisibleReason.DriveMotorcycle, new List<EBattleUiChild>
			{
				EBattleUiChild.Mission
			}, true, true, 0);
			this.MissionPanel.Reset();
		}

		// Token: 0x06041AC7 RID: 268999 RVA: 0x010D7114 File Offset: 0x010D5314
		private void OnMotorParkourFinishLap(int lap, float time)
		{
			List<MotorParkourRankData> lapRankList = this.LevelData.GetLapRankList(lap, time);
			this.RankPanel.RefreshRankList(lapRankList);
		}

		// Token: 0x04024A7F RID: 150143
		private MotorParkourLevelData LevelData;

		// Token: 0x04024A80 RID: 150144
		private MotorParkourMapItem MapItem;

		// Token: 0x04024A81 RID: 150145
		private MissionPanel MissionPanel;

		// Token: 0x04024A82 RID: 150146
		private MotorParkourRankPanel RankPanel;

		// Token: 0x0200C6E7 RID: 50919
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3CD RID: 250829
			public const int ItemMap = 0;

			// Token: 0x0403D3CE RID: 250830
			public const int ItemMissionPanel = 1;

			// Token: 0x0403D3CF RID: 250831
			public const int ItemRankPanel = 2;
		}
	}
}
