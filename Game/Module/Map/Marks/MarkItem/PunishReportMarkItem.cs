using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Mark.Component;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.WorldMap;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005853 RID: 22611
	[NullableContext(1)]
	[Nullable(0)]
	public class PunishReportMarkItem : ConfigMarkItem
	{
		// Token: 0x06039819 RID: 235545 RVA: 0x00E979FA File Offset: 0x00E95BFA
		public PunishReportMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x0603981A RID: 235546 RVA: 0x00E97A10 File Offset: 0x00E95C10
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.PunishReportMarkItemView;
		}

		// Token: 0x0603981B RID: 235547 RVA: 0x00E97A14 File Offset: 0x00E95C14
		[PreserveBaseOverrides]
		protected new virtual PunishReportMarkItemView CreateView()
		{
			return new PunishReportMarkItemView(this);
		}

		// Token: 0x0603981C RID: 235548 RVA: 0x00E97A1C File Offset: 0x00E95C1C
		protected override void OnInitialize()
		{
			base.OnInitialize();
			this.UpdateGamePlayState();
			Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<string, VarDefinePb>>(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
		}

		// Token: 0x0603981D RID: 235549 RVA: 0x00E97A46 File Offset: 0x00E95C46
		protected override void OnDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnReceivePlayerVar, new Action<IReadOnlyDictionary<string, VarDefinePb>>(this.OnReceivePlayerVar));
			base.OnDestroy();
		}

		// Token: 0x0603981E RID: 235550 RVA: 0x00E97A6A File Offset: 0x00E95C6A
		private void OnReceivePlayerVar(IReadOnlyDictionary<string, VarDefinePb> readOnlyDictionary)
		{
			this.ReportTarget = this.GetPunishReportTarget();
			this.UpdateGamePlayState();
		}

		// Token: 0x0603981F RID: 235551 RVA: 0x00E97A80 File Offset: 0x00E95C80
		public EPunishReportMarkStateType GetPunishMarkState()
		{
			if (this.ReportTarget == null)
			{
				this.ReportTarget = this.GetPunishReportTarget();
			}
			EPunishReportMarkStateType result = EPunishReportMarkStateType.Complete;
			using (List<EPunishReportTargetState>.Enumerator enumerator = this.ReportTarget.States.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != EPunishReportTargetState.Achieve)
					{
						result = EPunishReportMarkStateType.Proceed;
					}
				}
			}
			return result;
		}

		// Token: 0x06039820 RID: 235552 RVA: 0x00E97AEC File Offset: 0x00E95CEC
		public bool IsPunishReportFinish()
		{
			return this.GetPunishMarkState() == EPunishReportMarkStateType.Complete;
		}

		// Token: 0x06039821 RID: 235553 RVA: 0x00E97AF8 File Offset: 0x00E95CF8
		private void UpdateGamePlayState()
		{
			EPunishReportMarkStateType punishMarkState = this.GetPunishMarkState();
			base.MarkItemEntity.GetComponent<MarkGamePlayComponent>(EMapComponent.MarkGamePlay).GamePlayState = ((punishMarkState == EPunishReportMarkStateType.Complete) ? EMarkGamePlayState.Finish : EMarkGamePlayState.Lock);
		}

		// Token: 0x06039822 RID: 235554 RVA: 0x00E97B2C File Offset: 0x00E95D2C
		public bool CanGetReward()
		{
			int num = 0;
			PunishReportTarget punishReportTarget = this.GetPunishReportTarget();
			using (List<EPunishReportTargetState>.Enumerator enumerator = punishReportTarget.States.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == EPunishReportTargetState.Achieve)
					{
						num++;
					}
				}
			}
			return (long)num > punishReportTarget.GetBoxNum;
		}

		// Token: 0x06039823 RID: 235555 RVA: 0x00E97B94 File Offset: 0x00E95D94
		public PunishReportTarget GetPunishReportTarget()
		{
			PunishReportTarget punishReportTarget = new PunishReportTarget
			{
				States = new List<EPunishReportTargetState>(),
				ConditionTxtIds = new List<string>(),
				GetBoxNum = 0L
			};
			int relativeId = this.MarkConfig.Value.RelativeId;
			PunishReport? punishReportConfig = ConfigBase<WorldMapConfig>.Instance.GetPunishReportConfig(relativeId);
			if (punishReportConfig == null)
			{
				object key = relativeId;
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[地图系统]->讨伐报告标记获取配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("levelPlayId", relativeId);
				MapLogger.ErrorOnce(key, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return punishReportTarget;
			}
			bool worldStateBool = ModelBase<WorldModel>.Instance.GetWorldStateBool(punishReportConfig.Value.Cond1Key);
			bool worldStateBool2 = ModelBase<WorldModel>.Instance.GetWorldStateBool(punishReportConfig.Value.Cond2ey);
			bool worldStateBool3 = ModelBase<WorldModel>.Instance.GetWorldStateBool(punishReportConfig.Value.Cond3Key);
			bool[] array = new bool[]
			{
				worldStateBool,
				worldStateBool2,
				worldStateBool3
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					punishReportTarget.States.Add(EPunishReportTargetState.Achieve);
				}
				else
				{
					punishReportTarget.States.Add(EPunishReportTargetState.UnAchieve);
				}
			}
			string condDescription = punishReportConfig.Value.CondDescription1;
			string condDescription2 = punishReportConfig.Value.CondDescription2;
			string condDescription3 = punishReportConfig.Value.CondDescription3;
			punishReportTarget.ConditionTxtIds.Add(condDescription);
			punishReportTarget.ConditionTxtIds.Add(condDescription2);
			punishReportTarget.ConditionTxtIds.Add(condDescription3);
			long valueOrDefault = ModelBase<WorldModel>.Instance.GetWorldStateLong(punishReportConfig.Value.GetBoxKey).GetValueOrDefault();
			punishReportTarget.GetBoxNum = valueOrDefault;
			return punishReportTarget;
		}

		// Token: 0x06039824 RID: 235556 RVA: 0x00E97D44 File Offset: 0x00E95F44
		protected override void InitIcon()
		{
			this.UpdateIconPath();
		}

		// Token: 0x06039825 RID: 235557 RVA: 0x00E97D4C File Offset: 0x00E95F4C
		public override void UpdateIconPath()
		{
			this.IconPath = this.MarkConfig.Value.UnlockMarkPic;
		}

		// Token: 0x06039826 RID: 235558 RVA: 0x00E97D72 File Offset: 0x00E95F72
		protected override bool GamePlayIsFinish()
		{
			return this.IsPunishReportFinish();
		}

		// Token: 0x04020A7B RID: 133755
		[Nullable(2)]
		private PunishReportTarget ReportTarget;
	}
}
