using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E68 RID: 20072
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseMapView : UiViewBase
	{
		// Token: 0x06033E04 RID: 212484 RVA: 0x00CFA695 File Offset: 0x00CF8895
		public TrapDefenseMapView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06033E05 RID: 212485 RVA: 0x00CFA6B4 File Offset: 0x00CF88B4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033E06 RID: 212486 RVA: 0x00CFA79C File Offset: 0x00CF899C
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseMapView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseMapView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033E07 RID: 212487 RVA: 0x00CFA7DF File Offset: 0x00CF89DF
		protected override void OnStart()
		{
			this.RefreshWaveTips();
			this.RefreshHpPanel();
		}

		// Token: 0x06033E08 RID: 212488 RVA: 0x00CFA7ED File Offset: 0x00CF89ED
		protected override void OnBeforeShow()
		{
			this.CampsiteHpPanel.ShowBattleChildViewPanel();
		}

		// Token: 0x06033E09 RID: 212489 RVA: 0x00CFA7FA File Offset: 0x00CF89FA
		protected override void OnAfterHide()
		{
			this.CampsiteHpPanel.HideBattleChildViewPanel();
		}

		// Token: 0x06033E0A RID: 212490 RVA: 0x00CFA807 File Offset: 0x00CF8A07
		protected override void OnBeforeDestroy()
		{
			this.MiniMap.Reset();
			this.CampsiteHpPanel.Reset();
		}

		// Token: 0x06033E0B RID: 212491 RVA: 0x00CFA820 File Offset: 0x00CF8A20
		private void RefreshWaveTips()
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			TrapDefenseLevelData curInstToLevelData = instance.GetCurInstToLevelData();
			IReadOnlyList<TrapDefenseWave> trapDefenseWavesByLevelId = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseWavesByLevelId(curInstToLevelData.Id);
			long behaviorTreeVarToNumber = instance.BattleData.GetBehaviorTreeVarToNumber(ETrapDefenseSystemVarType.Batch);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "TowerDefense_Map_Progress_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				behaviorTreeVarToNumber,
				trapDefenseWavesByLevelId.Count
			}));
		}

		// Token: 0x06033E0C RID: 212492 RVA: 0x00CFA890 File Offset: 0x00CF8A90
		private void RefreshHpPanel()
		{
			FKSC_MiniMapContext[] entityPositions = ControllerBase<KuroSimpleCombatController>.Instance.GetEntityPositions();
			int trapDefenseWarningDistance = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseWarningDistance();
			bool warningItemActive = false;
			if (entityPositions != null && entityPositions.Length != 0)
			{
				FKSC_MiniMapContext[] array = entityPositions;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Distance <= (float)trapDefenseWarningDistance)
					{
						warningItemActive = true;
						break;
					}
				}
			}
			this.CampsiteHpPanel.SetWarningItemActive(warningItemActive);
			this.CampsiteHpPanel.SetLightItemActive(false);
		}

		// Token: 0x06033E0D RID: 212493 RVA: 0x00CFA8F9 File Offset: 0x00CF8AF9
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x0401E00E RID: 122894
		public TrapDefenseMiniMapPanel MiniMap = new TrapDefenseMiniMapPanel();

		// Token: 0x0401E00F RID: 122895
		public TrapDefenseCampsiteHpPanel CampsiteHpPanel = new TrapDefenseCampsiteHpPanel();
	}
}
