using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006011 RID: 24593
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleWeeklyRogueButton : FormationExtraButton
	{
		// Token: 0x0603DF73 RID: 253811 RVA: 0x00FCF9E0 File Offset: 0x00FCDBE0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(8, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(9, typeof(UUIItem)));
			}
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603DF74 RID: 253812 RVA: 0x00FCFB90 File Offset: 0x00FCDD90
		protected override UniTask OnBeforeStartAsync()
		{
			BattleWeeklyRogueButton.<OnBeforeStartAsync>d__27 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleWeeklyRogueButton.<OnBeforeStartAsync>d__27>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DF75 RID: 253813 RVA: 0x00FCFBD4 File Offset: 0x00FCDDD4
		protected override void OnStart()
		{
			base.OnStart();
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				CombineKeyItem keyItemPc = this.KeyItemPc;
				if (keyItemPc != null)
				{
					keyItemPc.RefreshAction("Link大招");
				}
				CombineKeyItem keyItemGp = this.KeyItemGp;
				if (keyItemGp != null)
				{
					keyItemGp.RefreshAction("Link大招");
				}
				this.RefreshKeyItemVisible();
			}
			this.BarTex = base.GetTexture(1);
			this.PointItem = base.GetItem(5);
			if (ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				bool flag = ModelBase<WeeklyRogueModel>.Instance.CurrentActivityId != 0;
				this.IsScoreEnable = flag;
				if (!flag)
				{
					Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
					this.SetVisible(false);
				}
				else
				{
					this.InitScoreWhenEnable();
				}
			}
			this.UpdateEnableClickState();
			this.RefreshNodeVisibleByState();
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleScoreChanged, new Action<int, int>(this.BattleScoreChanged));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnWeeklyRogueLinkStageChange));
			ControllerBase<InputDistributeController>.Instance.BindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603DF76 RID: 253814 RVA: 0x00FCFD0C File Offset: 0x00FCDF0C
		protected override void OnBeforeDestroy()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreChanged, new Action<int, int>(this.BattleScoreChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnWeeklyRogueLinkStageChange));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			if (this.LoadIconId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconId);
				this.LoadIconId = -1;
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603DF77 RID: 253815 RVA: 0x00FCFDE7 File Offset: 0x00FCDFE7
		private void OnCycleRefresh()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
			this.InitScoreWhenEnable();
			this.SetVisible(true);
		}

		// Token: 0x0603DF78 RID: 253816 RVA: 0x00FCFE14 File Offset: 0x00FCE014
		private unsafe void InitScoreWhenEnable()
		{
			this.IsScoreEnable = true;
			this.ArtifactId = ModelBase<WeeklyRogueModel>.Instance.GetArtifactBuffId();
			if (this.ArtifactId != 0)
			{
				this.ArtifactConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ArtifactId);
			}
			int cycleId = ModelBase<WeeklyRogueModel>.Instance.ActivityData.CycleId;
			RogueWeeklyCycle? cycleConfig = ModelBase<WeeklyRogueModel>.Instance.ActivityData.GetCycleConfig();
			int? num = (cycleConfig != null) ? new int?(cycleConfig.GetValueOrDefault().LinkId) : null;
			if (num == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WeeklyRogue;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "周常肉鸽获取不到link配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cycleId", cycleId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			LinkData? linkDataConfig = ConfigBase<BattleLinkConfig>.Instance.GetLinkDataConfig(num.Value);
			int? num2 = (linkDataConfig != null) ? new int?(linkDataConfig.GetValueOrDefault().BattleScoreId) : null;
			if (num2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.WeeklyRogue;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "周常肉鸽获取不到战斗评分配置";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("cycleId", cycleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("linkId", num);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.ScoreId = num2.Value;
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(num2.Value, true);
			int? num3 = (scoreConfig != null) ? new int?(scoreConfig.GetValueOrDefault().LevelGroupId) : null;
			if (num3 == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.WeeklyRogue;
				ELogAuthor author3 = ELogAuthor.CFT;
				string message3 = "周常肉鸽获取不到战斗评分等级配置";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("cycleId", cycleId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("linkId", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("scoreId", num2);
				instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
				return;
			}
			this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(num3.Value);
			if (this.CurScoreLevelConfigList != null && this.CurScoreLevelConfigList.Count > 0)
			{
				this.UpdateMaxAndMinScore();
			}
			else
			{
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.WeeklyRogue;
				ELogAuthor author4 = ELogAuthor.CFT;
				string message4 = "周常肉鸽获取不到战斗评分等级配置";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("groupId", num3);
				instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
			this.SetCurScore(0f);
			this.RefreshIcon();
		}

		// Token: 0x0603DF79 RID: 253817 RVA: 0x00FD00D0 File Offset: 0x00FCE2D0
		private void RefreshIcon()
		{
			UUITexture iconTexture = base.GetTexture(6);
			iconTexture.SetUIActive(false);
			string text = (this.ArtifactConfig != null) ? this.ArtifactConfig.GetValueOrDefault().ButtonIcon : null;
			if (!string.IsNullOrEmpty(text))
			{
				this.LoadIconId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture2D>(text, delegate([Nullable(2)] UTexture2D iconTextureData, string _)
				{
					this.LoadIconId = -1;
					if (iconTextureData == null)
					{
						return;
					}
					iconTexture.SetUIActive(true);
					iconTexture.SetTexture(iconTextureData);
				}, 103, "js_undefined");
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.WeeklyRogue;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "[WeeklyRogue]神器图标路径为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("神器Id", this.ArtifactId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603DF7A RID: 253818 RVA: 0x00FD0184 File Offset: 0x00FCE384
		private void UpdateMaxAndMinScore()
		{
			this.MinScoreLevelConfig = null;
			this.MaxScoreLevelConfig = null;
			int num = int.MaxValue;
			int num2 = 0;
			foreach (BattleScoreLevelConf value in this.CurScoreLevelConfigList)
			{
				int level = value.Level;
				if (num > level)
				{
					num = level;
					this.MinScoreLevelConfig = new BattleScoreLevelConf?(value);
				}
				if (num2 < level)
				{
					num2 = level;
					this.MaxScoreLevelConfig = new BattleScoreLevelConf?(value);
				}
			}
			this.MaxScore = (float)((this.MaxScoreLevelConfig != null) ? this.MaxScoreLevelConfig.GetValueOrDefault().LowerUpperLimits(0) : 0);
			float maxScore = this.MaxScore;
		}

		// Token: 0x0603DF7B RID: 253819 RVA: 0x00FD0250 File Offset: 0x00FCE450
		private void BattleScoreChanged(int scoreId, int score)
		{
			if (!this.IsScoreEnable || this.MinScoreLevelConfig == null || !this.IsValidScore(scoreId))
			{
				return;
			}
			this.OnBattleScoreChanged((float)score);
		}

		// Token: 0x0603DF7C RID: 253820 RVA: 0x00FD027C File Offset: 0x00FCE47C
		private bool IsValidScore(int scoreId)
		{
			if (this.ScoreId == scoreId)
			{
				return true;
			}
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, true);
			return scoreConfig != null && scoreConfig.Value.Type == 7;
		}

		// Token: 0x0603DF7D RID: 253821 RVA: 0x00FD02C0 File Offset: 0x00FCE4C0
		private void OnBattleScoreChanged(float score)
		{
			if (score < (float)this.MinScoreLevelConfig.Value.LowerUpperLimits(0))
			{
				this.CurScoreLevelConfig = null;
			}
			else if (score >= (float)this.MaxScoreLevelConfig.Value.LowerUpperLimits(1))
			{
				this.CurScoreLevelConfig = this.MaxScoreLevelConfig;
			}
			else
			{
				this.CurScoreLevelConfig = this.MinScoreLevelConfig;
			}
			this.HasValidConfig = (this.CurScoreLevelConfig != null);
			this.SetTickEndScore(score);
		}

		// Token: 0x0603DF7E RID: 253822 RVA: 0x00FD0340 File Offset: 0x00FCE540
		public override void Tick(float delta)
		{
			if (this.HasValidConfig && this.TickScore != this.TickEndScore && base.GetActive())
			{
				this.SmoothTime = Math.Min(200f, this.SmoothTime + delta);
				float num = this.SmoothTime / 200f;
				this.SetCurScore(this.TickStartScore * (1f - num) + this.TickEndScore * num);
			}
		}

		// Token: 0x0603DF7F RID: 253823 RVA: 0x00FD03B0 File Offset: 0x00FCE5B0
		private void SetCurScore(float score)
		{
			this.TickScore = score;
			if (this.MaxScore > 0f)
			{
				float num = this.TickScore / this.MaxScore;
				UUIItem pointItem = this.PointItem;
				if (pointItem != null)
				{
					FRotator frotator = new FRotator();
					frotator.Yaw = num * -360f;
					pointItem.SetUIRelativeRotation(frotator);
				}
				UUITexture barTex = this.BarTex;
				if (barTex != null)
				{
					barTex.SetFillAmount(num);
				}
			}
			this.SetIsFull(this.TickScore >= this.MaxScore);
		}

		// Token: 0x0603DF80 RID: 253824 RVA: 0x00FD0430 File Offset: 0x00FCE630
		private void SetTickEndScore(float score)
		{
			if (score > 0f)
			{
				this.TickStartScore = this.TickScore;
				this.TickEndScore = score;
				this.SmoothTime = 0f;
				return;
			}
			this.TickStartScore = this.TickScore;
			this.TickEndScore = 0f;
			this.SmoothTime = 200f;
		}

		// Token: 0x0603DF81 RID: 253825 RVA: 0x00FD0486 File Offset: 0x00FCE686
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshKeyItemVisible();
		}

		// Token: 0x0603DF82 RID: 253826 RVA: 0x00FD048E File Offset: 0x00FCE68E
		private void OnWeeklyRogueLinkStageChange(ENewLinkStatus stage)
		{
			this.SetIsBursting(stage == ENewLinkStatus.Burst);
		}

		// Token: 0x0603DF83 RID: 253827 RVA: 0x00FD049A File Offset: 0x00FCE69A
		private void RefreshKeyItemVisible()
		{
			CombineKeyItem keyItemPc = this.KeyItemPc;
			if (keyItemPc != null)
			{
				keyItemPc.SetUiActive(Singleton<Info>.Instance.IsInKeyBoard());
			}
			CombineKeyItem keyItemGp = this.KeyItemGp;
			if (keyItemGp == null)
			{
				return;
			}
			keyItemGp.SetUiActive(Singleton<Info>.Instance.IsInGamepad());
		}

		// Token: 0x0603DF84 RID: 253828 RVA: 0x00FD04D1 File Offset: 0x00FCE6D1
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!base.GetActive())
			{
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.LinkAction();
			}
		}

		// Token: 0x0603DF85 RID: 253829 RVA: 0x00FD04E5 File Offset: 0x00FCE6E5
		private void OnClicked()
		{
			this.LinkAction();
		}

		// Token: 0x0603DF86 RID: 253830 RVA: 0x00FD04F0 File Offset: 0x00FCE6F0
		private void LinkAction()
		{
			if (!this.IsFull || this.IsBursting)
			{
				return;
			}
			if (Singleton<Time>.Instance.Now < this.NextClickTime)
			{
				return;
			}
			if (ControllerBase<WeeklyRogueController>.Instance.RequestNewLinkBurst())
			{
				this.NextClickTime = Singleton<Time>.Instance.Now + 500.0;
			}
		}

		// Token: 0x0603DF87 RID: 253831 RVA: 0x00FD0547 File Offset: 0x00FCE747
		private void SetIsFull(bool value)
		{
			if (this.IsFull == value)
			{
				return;
			}
			this.IsFull = value;
			this.UpdateEnableClickState();
			this.RefreshNodeVisibleByState();
		}

		// Token: 0x0603DF88 RID: 253832 RVA: 0x00FD0568 File Offset: 0x00FCE768
		private void SetIsBursting(bool value)
		{
			if (this.IsBursting == value)
			{
				return;
			}
			this.IsBursting = value;
			this.UpdateEnableClickState();
			this.RefreshNodeVisibleByState();
			if (value)
			{
				ControllerBase<HudUnitController>.Instance.TryCreateHud(EHudUnitType.WeeklyRogue);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.WeeklyRogueBurstEnableChange, this.IsBursting);
		}

		// Token: 0x0603DF89 RID: 253833 RVA: 0x00FD05B8 File Offset: 0x00FCE7B8
		private void UpdateEnableClickState()
		{
			if (Singleton<Info>.Instance.IsInTouch())
			{
				return;
			}
			bool flag = this.IsFull && !this.IsBursting;
			this.KeyItemPc.SetGray(!flag);
			this.KeyItemGp.SetGray(!flag);
		}

		// Token: 0x0603DF8A RID: 253834 RVA: 0x00FD0608 File Offset: 0x00FCE808
		private void RefreshNodeVisibleByState()
		{
			if (this.IsBursting)
			{
				UUITexture texture = base.GetTexture(2);
				if (texture != null)
				{
					texture.SetUIActive(true);
				}
				UUITexture texture2 = base.GetTexture(3);
				if (texture2 != null)
				{
					texture2.SetUIActive(false);
				}
				UUIItem item = base.GetItem(4);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUINiagara uiNiagara = base.GetUiNiagara(7);
				if (uiNiagara != null)
				{
					uiNiagara.SetUIActive(false);
				}
				UUITexture texture3 = base.GetTexture(1);
				if (texture3 != null)
				{
					texture3.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else if (this.IsFull)
			{
				UUITexture texture4 = base.GetTexture(2);
				if (texture4 != null)
				{
					texture4.SetUIActive(false);
				}
				UUITexture texture5 = base.GetTexture(3);
				if (texture5 != null)
				{
					texture5.SetUIActive(true);
				}
				UUIItem item3 = base.GetItem(4);
				if (item3 != null)
				{
					item3.SetUIActive(true);
				}
				UUINiagara uiNiagara2 = base.GetUiNiagara(7);
				if (uiNiagara2 != null)
				{
					uiNiagara2.SetUIActive(true);
				}
				UUITexture texture6 = base.GetTexture(1);
				if (texture6 != null)
				{
					texture6.SetUIActive(true);
				}
				UUIItem item4 = base.GetItem(5);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(false);
				return;
			}
			else
			{
				UUITexture texture7 = base.GetTexture(2);
				if (texture7 != null)
				{
					texture7.SetUIActive(true);
				}
				UUITexture texture8 = base.GetTexture(3);
				if (texture8 != null)
				{
					texture8.SetUIActive(false);
				}
				UUIItem item5 = base.GetItem(4);
				if (item5 != null)
				{
					item5.SetUIActive(false);
				}
				UUINiagara uiNiagara3 = base.GetUiNiagara(7);
				if (uiNiagara3 != null)
				{
					uiNiagara3.SetUIActive(false);
				}
				UUITexture texture9 = base.GetTexture(1);
				if (texture9 != null)
				{
					texture9.SetUIActive(true);
				}
				UUIItem item6 = base.GetItem(5);
				if (item6 == null)
				{
					return;
				}
				item6.SetUIActive(true);
				return;
			}
		}

		// Token: 0x0603DF8B RID: 253835 RVA: 0x00FD077C File Offset: 0x00FCE97C
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIButtonComponent button = base.GetButton(0);
			UUIItem uuiitem = (button != null) ? button.GetRootComponent() : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}

		// Token: 0x04022C0C RID: 142348
		private const float MAX_SMOOTH_TIME = 200f;

		// Token: 0x04022C0D RID: 142349
		private const float CLICK_CD = 500f;

		// Token: 0x04022C0E RID: 142350
		private CombineKeyItem KeyItemPc;

		// Token: 0x04022C0F RID: 142351
		private CombineKeyItem KeyItemGp;

		// Token: 0x04022C10 RID: 142352
		public bool IsScoreEnable;

		// Token: 0x04022C11 RID: 142353
		private int ScoreId;

		// Token: 0x04022C12 RID: 142354
		private UUITexture BarTex;

		// Token: 0x04022C13 RID: 142355
		private UUIItem PointItem;

		// Token: 0x04022C14 RID: 142356
		private bool HasValidConfig;

		// Token: 0x04022C15 RID: 142357
		private float TickStartScore;

		// Token: 0x04022C16 RID: 142358
		private float TickEndScore;

		// Token: 0x04022C17 RID: 142359
		private float TickScore;

		// Token: 0x04022C18 RID: 142360
		private float MaxScore;

		// Token: 0x04022C19 RID: 142361
		private float SmoothTime;

		// Token: 0x04022C1A RID: 142362
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04022C1B RID: 142363
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04022C1C RID: 142364
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04022C1D RID: 142365
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x04022C1E RID: 142366
		private bool IsBursting;

		// Token: 0x04022C1F RID: 142367
		private bool IsFull;

		// Token: 0x04022C20 RID: 142368
		private int ArtifactId;

		// Token: 0x04022C21 RID: 142369
		private RogueWeeklyBuffPool? ArtifactConfig;

		// Token: 0x04022C22 RID: 142370
		private int LoadIconId = -1;

		// Token: 0x04022C23 RID: 142371
		private double NextClickTime;

		// Token: 0x0200C0B1 RID: 49329
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B53D RID: 243005
			KeyItemPc = 8,
			// Token: 0x0403B53E RID: 243006
			KeyItemGp
		}

		// Token: 0x0200C0B2 RID: 49330
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B540 RID: 243008
			BtnClick,
			// Token: 0x0403B541 RID: 243009
			BarTex,
			// Token: 0x0403B542 RID: 243010
			EmptyBgTex,
			// Token: 0x0403B543 RID: 243011
			FullBgTex,
			// Token: 0x0403B544 RID: 243012
			FullItem,
			// Token: 0x0403B545 RID: 243013
			PointItem,
			// Token: 0x0403B546 RID: 243014
			IconTex,
			// Token: 0x0403B547 RID: 243015
			GlowEffect
		}
	}
}
