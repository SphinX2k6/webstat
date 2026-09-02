using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Input;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC5 RID: 24517
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleSkillConfigLongPressItem : UiPanelBase
	{
		// Token: 0x0603DA5E RID: 252510 RVA: 0x00FB4AE8 File Offset: 0x00FB2CE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DA5F RID: 252511 RVA: 0x00FB4C3C File Offset: 0x00FB2E3C
		protected override void OnStart()
		{
			this.ProgressTexA = base.GetTexture(0);
			this.ProgressTexA.SetFillAmount(0f);
			this.TweenAnimPlayer.InitTweenAnim(4, base.GetItem(4), false);
			this.SetComponentActive(this.TargetActive);
			this.InputHandler = new BattleSkillInputHandler();
			this.InputHandler.InitCallback(new Action<EInputAction>(this.OnSkillLongPressStart), new Action<EInputAction>(this.OnSkillLongPressEnd));
			if (this.Action != null)
			{
				this.InputHandler.SetActionType(this.Action.Value);
				this.InputHandler.AddActionTypes(this.ExtraActions);
			}
			this.InitBarB();
			this.SetState(BattleSkillConfigLongPressItem.EState.StateA, true);
		}

		// Token: 0x0603DA60 RID: 252512 RVA: 0x00FB4CF6 File Offset: 0x00FB2EF6
		protected override void OnBeforeShow()
		{
			if (this.InputHandler != null)
			{
				ControllerBase<InputController>.Instance.AddInputHandler(this.InputHandler);
			}
		}

		// Token: 0x0603DA61 RID: 252513 RVA: 0x00FB4D10 File Offset: 0x00FB2F10
		protected override void OnAfterHide()
		{
			if (this.InputHandler != null)
			{
				ControllerBase<InputController>.Instance.RemoveInputHandler(this.InputHandler);
			}
		}

		// Token: 0x0603DA62 RID: 252514 RVA: 0x00FB4D2C File Offset: 0x00FB2F2C
		public void SetComponentActive(bool visibility)
		{
			if (this.TargetActive == visibility && !this.IsFirstShow)
			{
				return;
			}
			this.TargetActive = visibility;
			if (base.InAsyncLoading())
			{
				return;
			}
			this.IsFirstShow = false;
			this.SetActive(visibility);
			UUITexture progressTexA = this.ProgressTexA;
			if (progressTexA == null)
			{
				return;
			}
			progressTexA.SetFillAmount(0f);
		}

		// Token: 0x0603DA63 RID: 252515 RVA: 0x00FB4D80 File Offset: 0x00FB2F80
		public void SetAction(in EInputAction action)
		{
			if (this.Action == action)
			{
				return;
			}
			this.Action = new EInputAction?(action);
			BattleSkillInputHandler inputHandler = this.InputHandler;
			if (inputHandler != null)
			{
				inputHandler.SetActionType(action);
			}
			BattleSkillInputHandler inputHandler2 = this.InputHandler;
			if (inputHandler2 != null)
			{
				inputHandler2.AddActionTypes(this.ExtraActions);
			}
			this.StopProgressA();
			UUITexture progressTexA = this.ProgressTexA;
			if (progressTexA == null)
			{
				return;
			}
			progressTexA.SetFillAmount(0f);
		}

		// Token: 0x0603DA64 RID: 252516 RVA: 0x00FB4E11 File Offset: 0x00FB3011
		public void SetSharedFxActions(List<EInputAction> actions)
		{
			this.ExtraActions = actions;
			BattleSkillInputHandler inputHandler = this.InputHandler;
			if (inputHandler == null)
			{
				return;
			}
			inputHandler.AddActionTypes(actions);
		}

		// Token: 0x0603DA65 RID: 252517 RVA: 0x00FB4E2C File Offset: 0x00FB302C
		private bool IsValidAction(EInputAction action)
		{
			return (this.ExtraActions != null && this.ExtraActions.Contains(action)) || !(this.Action != action);
		}

		// Token: 0x0603DA66 RID: 252518 RVA: 0x00FB4E78 File Offset: 0x00FB3078
		public void SetDuration(float duration)
		{
			this.Duration = duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}

		// Token: 0x0603DA67 RID: 252519 RVA: 0x00FB4E8D File Offset: 0x00FB308D
		private void OnSkillLongPressStart(EInputAction action)
		{
			if (!this.IsValidAction(action))
			{
				return;
			}
			if (this.Duration <= 0f)
			{
				return;
			}
			this.StartProgress();
		}

		// Token: 0x0603DA68 RID: 252520 RVA: 0x00FB4EAD File Offset: 0x00FB30AD
		private void OnSkillLongPressEnd(EInputAction action)
		{
			if (!this.IsValidAction(action))
			{
				return;
			}
			this.StopProgressA();
			UUITexture progressTexA = this.ProgressTexA;
			if (progressTexA == null)
			{
				return;
			}
			progressTexA.SetFillAmount(0f);
		}

		// Token: 0x0603DA69 RID: 252521 RVA: 0x00FB4ED4 File Offset: 0x00FB30D4
		private void StartProgress()
		{
			this.StartTime = (float)Singleton<Time>.Instance.WorldTime;
		}

		// Token: 0x0603DA6A RID: 252522 RVA: 0x00FB4EE7 File Offset: 0x00FB30E7
		private void StopProgressA()
		{
			this.StartTime = 0f;
			UUITexture progressTexA = this.ProgressTexA;
			if (progressTexA == null)
			{
				return;
			}
			progressTexA.SetFillAmount(0f);
		}

		// Token: 0x0603DA6B RID: 252523 RVA: 0x00FB4F0C File Offset: 0x00FB310C
		public void Tick(float delta)
		{
			if (this.CurState != BattleSkillConfigLongPressItem.EState.StateA)
			{
				this.TickProgressB(delta);
				return;
			}
			if (this.StartTime <= 0f || this.Duration <= 0f)
			{
				return;
			}
			float num = (float)Singleton<Time>.Instance.WorldTime - this.StartTime;
			float num2 = Math.Min(1f, num / this.Duration);
			if (num2 == 1f)
			{
				this.StopProgressA();
				return;
			}
			UUITexture progressTexA = this.ProgressTexA;
			if (progressTexA == null)
			{
				return;
			}
			progressTexA.SetFillAmount(num2);
		}

		// Token: 0x0603DA6C RID: 252524 RVA: 0x00FB4F8C File Offset: 0x00FB318C
		private void SetState(BattleSkillConfigLongPressItem.EState state, bool force = false)
		{
			if (this.CurState == state && !force)
			{
				return;
			}
			bool flag = state == BattleSkillConfigLongPressItem.EState.StateA;
			bool enableBarB = this.EnableBarB;
			base.GetItem(5).SetUIActive(flag);
			base.GetItem(1).SetUIActive(!enableBarB);
			base.GetItem(6).SetUIActive(!flag);
			base.GetItem(2).SetUIActive(enableBarB);
			if (state == BattleSkillConfigLongPressItem.EState.StateA)
			{
				UUITexture progressTexA = this.ProgressTexA;
				if (progressTexA != null)
				{
					progressTexA.SetFillAmount(0f);
				}
			}
			else
			{
				base.GetText(3).SetText("0", true);
				UUITexture progressTexB = this.ProgressTexB;
				if (progressTexB != null)
				{
					progressTexB.SetFillAmount(0f);
				}
			}
			this.CurState = state;
		}

		// Token: 0x0603DA6D RID: 252525 RVA: 0x00FB5038 File Offset: 0x00FB3238
		private void InitBarB()
		{
			if (this.ProgressTexB == null)
			{
				this.ProgressTexB = base.GetTexture(7);
				base.GetText(3).SetText("0", true);
				this.FlagBg = base.GetSprite(8);
			}
			this.RefreshAttributeValue(this.InitEnergyB);
		}

		// Token: 0x0603DA6E RID: 252526 RVA: 0x00FB5088 File Offset: 0x00FB3288
		public void SetCustomLogicParam(SkillButtonData skillButtonData, int from = -1, int param = 0)
		{
			if (skillButtonData == null)
			{
				return;
			}
			this.SkillButtonData = skillButtonData;
			ESkillButtonAttributeUsageMode attributeUsageMode = skillButtonData.AttributeUsageMode;
			this.EnableBarB = (attributeUsageMode == ESkillButtonAttributeUsageMode.RecoverWithStack);
			if (!this.EnableBarB)
			{
				return;
			}
			if (from == 7 || skillButtonData.HasHoldRingFxRestore())
			{
				this.UpdateRestoreMode = BattleSkillConfigLongPressItem.ESkillButtonHoldFxRestoreMode.WithSimulate;
				if (param > 0 || skillButtonData.HasHoldRingFxRestore())
				{
					ValueTuple<float, float> holdRingFxRestoreInfo = skillButtonData.GetHoldRingFxRestoreInfo();
					float item = holdRingFxRestoreInfo.Item1;
					float item2 = holdRingFxRestoreInfo.Item2;
					this.RestoreMachine.Init(item, new float?(item2));
					this.RestoreMachine.SetTargetPercent(1f);
				}
				else
				{
					this.RestoreMachine.Init(0f, new float?(0.001f));
					this.RestoreMachine.SetTargetPercent(0f);
					this.ProgressTexB.SetFillAmount(0f);
				}
			}
			else
			{
				this.UpdateRestoreMode = BattleSkillConfigLongPressItem.ESkillButtonHoldFxRestoreMode.WithAttribute;
			}
			int[] attributeUsageParams = skillButtonData.AttributeUsageParams;
			this.EnergyMaxB = (float)((attributeUsageParams != null) ? Math.Max(attributeUsageParams[0], 1) : 1);
			this.RefreshAttributeValue(skillButtonData.GetAttribute());
			this.TickProgressB(0f);
		}

		// Token: 0x0603DA6F RID: 252527 RVA: 0x00FB5190 File Offset: 0x00FB3390
		private void TickProgressB(float delta)
		{
			if (this.CurState != BattleSkillConfigLongPressItem.EState.StateB)
			{
				return;
			}
			if (this.UpdateRestoreMode == BattleSkillConfigLongPressItem.ESkillButtonHoldFxRestoreMode.WithSimulate && this.RestoreMachine.Update(delta * Singleton<Time>.Instance.TimeDilation))
			{
				this.ProgressTexB.SetFillAmount(this.RestoreMachine.GetCurPercent());
			}
		}

		// Token: 0x0603DA70 RID: 252528 RVA: 0x00FB51E0 File Offset: 0x00FB33E0
		public void RefreshAttributeValue(float curEnergy)
		{
			if (!this.EnableBarB)
			{
				return;
			}
			if (this.ProgressTexB == null)
			{
				this.InitEnergyB = curEnergy;
				return;
			}
			float num = curEnergy / this.EnergyMaxB;
			if (num >= 1f)
			{
				this.SetState(BattleSkillConfigLongPressItem.EState.StateA, false);
			}
			else
			{
				this.SetState(BattleSkillConfigLongPressItem.EState.StateB, false);
			}
			this.SetFlagEnable(num >= 1f);
			if (this.CurState == BattleSkillConfigLongPressItem.EState.StateB && this.UpdateRestoreMode == BattleSkillConfigLongPressItem.ESkillButtonHoldFxRestoreMode.WithAttribute)
			{
				this.ProgressTexB.SetFillAmount(num);
			}
			int num2 = (int)Math.Floor((double)(curEnergy / this.EnergyMaxB));
			SkillButtonData skillButtonData = this.SkillButtonData;
			if (((skillButtonData != null) ? skillButtonData.HoldRingFxRestoreFxNum : 0) < num2)
			{
				BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
				if (tweenAnimPlayer != null)
				{
					tweenAnimPlayer.PlayTweenAnim(4);
				}
			}
			base.GetText(3).SetText(num2.ToString(), true);
			if (this.SkillButtonData != null)
			{
				this.SkillButtonData.HoldRingFxRestoreFxNum = num2;
			}
		}

		// Token: 0x0603DA71 RID: 252529 RVA: 0x00FB52B8 File Offset: 0x00FB34B8
		private void SetFlagEnable(bool enable)
		{
			if (!this.EnableBarB)
			{
				return;
			}
			if (this.FlagBg == null)
			{
				return;
			}
			if (!BattleSkillConfigLongPressItem.IsFlagColorInited)
			{
				BattleSkillConfigLongPressItem.FlagColorGray = FColor.FromHex(ConfigCommonParamById.GetStringConfig("SkillButton_HoldFx_Flag_Gray"));
				BattleSkillConfigLongPressItem.FlagColorDefault = this.FlagBg.GetColor();
				BattleSkillConfigLongPressItem.IsFlagColorInited = true;
			}
			if (this.FlagState != enable)
			{
				this.FlagState = enable;
				this.FlagBg.SetColor(enable ? BattleSkillConfigLongPressItem.FlagColorDefault : BattleSkillConfigLongPressItem.FlagColorGray);
			}
		}

		// Token: 0x0402299C RID: 141724
		private BattleSkillInputHandler InputHandler;

		// Token: 0x0402299D RID: 141725
		private BattleSkillConfigLongPressItem.EState CurState;

		// Token: 0x0402299E RID: 141726
		public bool TargetActive;

		// Token: 0x0402299F RID: 141727
		private UUITexture ProgressTexA;

		// Token: 0x040229A0 RID: 141728
		private EInputAction? Action;

		// Token: 0x040229A1 RID: 141729
		private float Duration;

		// Token: 0x040229A2 RID: 141730
		private float StartTime;

		// Token: 0x040229A3 RID: 141731
		private bool IsFirstShow = true;

		// Token: 0x040229A4 RID: 141732
		[Nullable(1)]
		private BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x040229A5 RID: 141733
		private List<EInputAction> ExtraActions;

		// Token: 0x040229A6 RID: 141734
		private bool EnableBarB;

		// Token: 0x040229A7 RID: 141735
		private BattleSkillConfigLongPressItem.ESkillButtonHoldFxRestoreMode UpdateRestoreMode;

		// Token: 0x040229A8 RID: 141736
		private SkillButtonData SkillButtonData;

		// Token: 0x040229A9 RID: 141737
		private UUITexture ProgressTexB;

		// Token: 0x040229AA RID: 141738
		private UUISprite FlagBg;

		// Token: 0x040229AB RID: 141739
		private float InitEnergyB;

		// Token: 0x040229AC RID: 141740
		private float EnergyMaxB = 1f;

		// Token: 0x040229AD RID: 141741
		[Nullable(1)]
		private readonly MotorcyclePercentMachine RestoreMachine = new MotorcyclePercentMachine();

		// Token: 0x040229AE RID: 141742
		[StaticVariableRuleIgnore]
		private static FColor FlagColorDefault;

		// Token: 0x040229AF RID: 141743
		[StaticVariableRuleIgnore]
		private static FColor FlagColorGray;

		// Token: 0x040229B0 RID: 141744
		[StaticVariableRuleIgnore]
		private static bool IsFlagColorInited;

		// Token: 0x040229B1 RID: 141745
		private bool FlagState = true;

		// Token: 0x0200C02F RID: 49199
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B298 RID: 242328
			ProgressTexA,
			// Token: 0x0403B299 RID: 242329
			PnlFlagA,
			// Token: 0x0403B29A RID: 242330
			PnlFlagB,
			// Token: 0x0403B29B RID: 242331
			FlagNumB,
			// Token: 0x0403B29C RID: 242332
			AniFlagSwitch,
			// Token: 0x0403B29D RID: 242333
			PnlBarA,
			// Token: 0x0403B29E RID: 242334
			PnlBarB,
			// Token: 0x0403B29F RID: 242335
			ProgressTexB,
			// Token: 0x0403B2A0 RID: 242336
			FlagBg
		}

		// Token: 0x0200C030 RID: 49200
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403B2A2 RID: 242338
			StateA,
			// Token: 0x0403B2A3 RID: 242339
			StateB
		}

		// Token: 0x0200C031 RID: 49201
		[NullableContext(0)]
		private enum ESkillButtonHoldFxRestoreMode
		{
			// Token: 0x0403B2A5 RID: 242341
			WithSimulate,
			// Token: 0x0403B2A6 RID: 242342
			WithAttribute
		}
	}
}
