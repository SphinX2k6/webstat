using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x0200530C RID: 21260
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class QuickHackViewBase : UiTickViewBase, IUiProhibitRefreshData
	{
		// Token: 0x0603645A RID: 222298 RVA: 0x00DAE3E4 File Offset: 0x00DAC5E4
		public QuickHackViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603645B RID: 222299 RVA: 0x00DAE3F4 File Offset: 0x00DAC5F4
		protected override UniTask OnBeforeStartAsync()
		{
			QuickHackViewBase.<OnBeforeStartAsync>d__13 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<QuickHackViewBase.<OnBeforeStartAsync>d__13>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603645C RID: 222300 RVA: 0x00DAE438 File Offset: 0x00DAC638
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(this.GetUiComponentType(EQuickHackUiType.SkillPanelLayout));
			this.SkillPanelAnim = (verticalLayout.GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		}

		// Token: 0x0603645D RID: 222301 RVA: 0x00DAE4A0 File Offset: 0x00DAC6A0
		protected override void OnBeforeShow()
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			QuickHackRamManager ramManager = instance.RamManager;
			if (ramManager == null)
			{
				return;
			}
			double durationLimitTotalTime = instance.DurationLimitTotalTime;
			bool flag = durationLimitTotalTime > 0.0;
			base.GetItem(this.GetUiComponentType(EQuickHackUiType.DurationLimitItem)).SetUIActive(flag);
			if (flag)
			{
				this.UpdateDurationLimit(instance.DurationLimitRemainTime, durationLimitTotalTime);
			}
			int currentRam = (int)Math.Floor((double)ramManager.GetCurrentRam());
			int maxRam = (int)Math.Floor((double)ramManager.GetMaxRam());
			this.RefreshRam(currentRam, maxRam, false);
			this.UpdateInfoLine();
			ControllerBase<QuickHackController>.Instance.UpdateLockTarget(0f);
			this.UpdateSkillInfo(true, true);
			this.UpdateLockTarget();
			this.UpdateKeyItem();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackAllSkillChange, new Action(this.OnAllSkillChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackSelectSkillChange, new Action(this.OnSelectSkillChange));
			Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnQuickHackDurationLimitChange, new Action<double, double>(this.UpdateDurationLimit));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackCurrentRamChange, new Action(this.OnCurrentRamChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnQuickHackMaxRamChange, new Action(this.OnMxRamChange));
			Singleton<UiProhibitFightInputCenter>.Instance.RegisterExtraRefreshData(this.ViewInfo.Name, this);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.RefreshInput(true);
		}

		// Token: 0x0603645E RID: 222302 RVA: 0x00DAE638 File Offset: 0x00DAC838
		protected override void OnBeforeHide()
		{
			QuickHackSkillInstance currentSkill = this.CurrentSkill;
			if (currentSkill != null)
			{
				currentSkill.UnRegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckCurrentSkillCanUse));
			}
			this.CurrentSkill = null;
			Singleton<EventSystem>.Instance.Remove(EEventName.OnShowMouseCursor, new Action<bool>(this.OnShowMouseCursor));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackAllSkillChange, new Action(this.OnAllSkillChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackSelectSkillChange, new Action(this.OnSelectSkillChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackDurationLimitChange, new Action<double, double>(this.UpdateDurationLimit));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackCurrentRamChange, new Action(this.OnCurrentRamChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnQuickHackMaxRamChange, new Action(this.OnMxRamChange));
			Singleton<UiProhibitFightInputCenter>.Instance.UnRegisterExtraRefreshData(this.ViewInfo.Name);
			ControllerBase<InputDistributeController>.Instance.RefreshInputTag();
			this.RefreshInput(false);
		}

		// Token: 0x0603645F RID: 222303 RVA: 0x00DAE758 File Offset: 0x00DAC958
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.UpdateKeyItem();
		}

		// Token: 0x06036460 RID: 222304 RVA: 0x00DAE760 File Offset: 0x00DAC960
		private void UpdateDurationLimit(double remainTime, double totalTime)
		{
			double num = Singleton<MathUtils>.Instance.Clamp(remainTime, 0.0, totalTime);
			double num2 = num / totalTime;
			double num3 = Singleton<MathUtils>.Instance.Clamp(num * 0.0010000000474974513, 0.0, Singleton<TimeUtil>.Instance.Minute);
			int num4 = (int)Math.Floor(num3);
			int num5 = (int)Math.Floor((num3 - (double)num4) * 100.0);
			string text = num4.ToString().PadLeft(2, '0');
			string text2 = num5.ToString().PadLeft(2, '0');
			base.GetSprite(this.GetUiComponentType(EQuickHackUiType.DurationLimitBarSprite)).SetFillAmount((float)num2);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.DurationLimitText)), "QuickHack_Desc_2", new <>z__ReadOnlyArray<object>(new object[]
			{
				text,
				text2
			}));
		}

		// Token: 0x06036461 RID: 222305 RVA: 0x00DAE834 File Offset: 0x00DACA34
		protected virtual bool UseCurrentSkill()
		{
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			List<QuickHackSkillInstance> currentSkillList = instance.CurrentSkillList;
			QuickHackSkillInstance currentSelectSkill = instance.CurrentSelectSkill;
			if (currentSelectSkill == null || currentSkillList == null)
			{
				return false;
			}
			int num = currentSkillList.IndexOf(currentSelectSkill);
			if (num < 0)
			{
				return false;
			}
			if (!currentSelectSkill.GetSkillCanUseInfo().IsSuccess)
			{
				QuickHackSkillPanel skillPanel = this.SkillPanel;
				if (skillPanel != null)
				{
					QuickHackSkillItem item = skillPanel.GetItem(num);
					if (item != null)
					{
						item.PlayDisableSequence();
					}
				}
				return false;
			}
			if (ControllerBase<QuickHackController>.Instance.UseCurrentSkill())
			{
				QuickHackSkillPanel skillPanel2 = this.SkillPanel;
				if (skillPanel2 != null)
				{
					QuickHackSkillItem item2 = skillPanel2.GetItem(num);
					if (item2 != null)
					{
						item2.PlayUseSkillSequence();
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06036462 RID: 222306
		protected abstract void RefreshInput(bool enable);

		// Token: 0x06036463 RID: 222307
		protected abstract int GetUiComponentType(EQuickHackUiType uiType);

		// Token: 0x06036464 RID: 222308
		protected abstract List<UUIItem> GetSkillItems();

		// Token: 0x06036465 RID: 222309 RVA: 0x00DAE8C1 File Offset: 0x00DACAC1
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			QuickHackRamBar ramBar = this.RamBar;
			if (ramBar != null)
			{
				ramBar.Clear();
			}
			this.RamBar = null;
			this.SkillPanel = null;
			this.SkillPanelAnim = null;
		}

		// Token: 0x06036466 RID: 222310 RVA: 0x00DAE901 File Offset: 0x00DACB01
		protected override void OnTick(float delta)
		{
			ControllerBase<QuickHackController>.Instance.UpdateLockTarget(delta);
			this.UpdateLockTarget();
			this.UpdateUploadTime();
			QuickHackRamBar ramBar = this.RamBar;
			if (ramBar == null)
			{
				return;
			}
			ramBar.TickRamBar(delta);
		}

		// Token: 0x06036467 RID: 222311 RVA: 0x00DAE92C File Offset: 0x00DACB2C
		private void OnCurrentRamChange()
		{
			QuickHackRamManager ramManager = ModelBase<QuickHackModel>.Instance.RamManager;
			int currentRam = (int)Math.Floor((double)((ramManager != null) ? ramManager.GetCurrentRam() : 0f));
			int maxRam = (int)Math.Floor((double)((ramManager != null) ? ramManager.GetMaxRam() : 0f));
			this.RefreshRam(currentRam, maxRam, true);
		}

		// Token: 0x06036468 RID: 222312 RVA: 0x00DAE980 File Offset: 0x00DACB80
		private void OnMxRamChange()
		{
			QuickHackRamManager ramManager = ModelBase<QuickHackModel>.Instance.RamManager;
			int currentRam = (int)Math.Floor((double)((ramManager != null) ? ramManager.GetCurrentRam() : 0f));
			int maxRam = (int)Math.Floor((double)((ramManager != null) ? ramManager.GetMaxRam() : 0f));
			this.RefreshRam(currentRam, maxRam, false);
		}

		// Token: 0x06036469 RID: 222313 RVA: 0x00DAE9D4 File Offset: 0x00DACBD4
		private void RefreshRam(int currentRam, int maxRam, bool playReduceAnim = false)
		{
			QuickHackRamBar ramBar = this.RamBar;
			if (ramBar != null)
			{
				ramBar.RefreshRam(currentRam, maxRam, playReduceAnim);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.RamTitleText)), "QuickHack_Desc_1", new <>z__ReadOnlyArray<object>(new object[]
			{
				currentRam,
				maxRam
			}));
		}

		// Token: 0x0603646A RID: 222314 RVA: 0x00DAEA30 File Offset: 0x00DACC30
		private void UpdateLockTarget()
		{
			EntityHandle closestOnScreenTarget = ControllerBase<QuickHackController>.Instance.GetClosestOnScreenTarget();
			bool flag = closestOnScreenTarget != null;
			if (flag != this.HasTarget)
			{
				this.HasTarget = flag;
				if (flag)
				{
					this.SequencePlayer.StopSequenceByKey("CheckOut", false, false);
					this.SequencePlayer.PlaySequencePurely("CheckIn", false, false);
				}
				else
				{
					this.SequencePlayer.StopSequenceByKey("CheckIn", false, false);
					this.SequencePlayer.PlaySequencePurely("CheckOut", false, false);
				}
			}
			if (this.TargetItem == null)
			{
				return;
			}
			if (!this.ShouldShowTargetItem() || !flag)
			{
				this.TargetItemEntityId = 0;
				this.TargetItem.SetActive(false);
				return;
			}
			int id = closestOnScreenTarget.Id;
			if (id == this.TargetItemEntityId)
			{
				return;
			}
			this.TargetItemEntityId = id;
			CreatureDataComponent component = closestOnScreenTarget.Entity.GetComponent<CreatureDataComponent>();
			string entityTidName = component.GetEntityTidName();
			if (entityTidName == null)
			{
				this.TargetItem.SetActive(false);
				return;
			}
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(entityTidName);
			if (StringUtils.IsBlank(configTextByKey))
			{
				this.TargetItem.SetActive(false);
				return;
			}
			MonsterComponent monsterComponent = component.GetMonsterComponent();
			string text;
			if (monsterComponent == null)
			{
				text = null;
			}
			else
			{
				IBossStateViewConfig bossViewConfig = monsterComponent.BossViewConfig;
				text = ((bossViewConfig != null) ? bossViewConfig.TidBossSubTitle : null);
			}
			string text2 = text;
			string title = (text2 != null) ? (configTextByKey + Singleton<PublicUtil>.Instance.GetConfigTextByKey(text2)) : configTextByKey;
			this.TargetItem.SetActive(true);
			this.TargetItem.RefreshTitle(title);
		}

		// Token: 0x0603646B RID: 222315 RVA: 0x00DAEB89 File Offset: 0x00DACD89
		protected virtual bool ShouldShowTargetItem()
		{
			return true;
		}

		// Token: 0x0603646C RID: 222316 RVA: 0x00DAEB8C File Offset: 0x00DACD8C
		private void UpdateUploadTime()
		{
			int uploadTime = this.GetUploadTime();
			if (uploadTime == this.CurrentUploadTime)
			{
				return;
			}
			this.CurrentUploadTime = uploadTime;
			bool flag = uploadTime > 0;
			if (this.HasUploadTimeInfo != flag)
			{
				this.HasUploadTimeInfo = flag;
				this.UpdateInfoLine();
			}
			UUIText text = base.GetText(this.GetUiComponentType(EQuickHackUiType.InfoUploadText));
			text.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "QuickHack_SkillMessage_2", new <>z__ReadOnlySingleElementList<object>(((float)uploadTime * 0.001f).ToString("F1")));
			}
		}

		// Token: 0x0603646D RID: 222317 RVA: 0x00DAEC10 File Offset: 0x00DACE10
		private int GetUploadTime()
		{
			QuickHackTargetSelector targetSelector = ModelBase<QuickHackModel>.Instance.TargetSelector;
			IQuickHackLockTargetInfo quickHackLockTargetInfo = (targetSelector != null) ? targetSelector.GetLockTargetInfo() : null;
			if (quickHackLockTargetInfo == null || quickHackLockTargetInfo.HackType == null)
			{
				return 0;
			}
			using (IEnumerator<EntityHandle> enumerator = quickHackLockTargetInfo.Targets.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					WorldEntity entity = enumerator.Current.Entity;
					int? num;
					if (entity == null)
					{
						num = null;
					}
					else
					{
						SceneItemQuickHackComponent component = entity.GetComponent<SceneItemQuickHackComponent>();
						num = ((component != null) ? new int?(component.GetUploadTime()) : null);
					}
					int? num2 = num;
					return num2.GetValueOrDefault();
				}
			}
			return 0;
		}

		// Token: 0x0603646E RID: 222318 RVA: 0x00DAECC4 File Offset: 0x00DACEC4
		private void OnAllSkillChange()
		{
			this.UpdateSkillInfo(true, false);
		}

		// Token: 0x0603646F RID: 222319 RVA: 0x00DAECCE File Offset: 0x00DACECE
		private void OnSelectSkillChange()
		{
			this.UpdateSkillInfo(false, false);
		}

		// Token: 0x06036470 RID: 222320 RVA: 0x00DAECD8 File Offset: 0x00DACED8
		private void UpdateSkillInfo(bool allSkillChange, bool isInit = false)
		{
			this.RefreshSelectRam();
			QuickHackModel instance = ModelBase<QuickHackModel>.Instance;
			List<QuickHackSkillInstance> currentSkillList = instance.CurrentSkillList;
			QuickHackSkillInstance currentSelectSkill = instance.CurrentSelectSkill;
			if (this.SkillPanel == null || currentSkillList == null || (currentSkillList != null && currentSkillList.Count == 0) || currentSelectSkill == null)
			{
				QuickHackSkillInstance currentSkill = this.CurrentSkill;
				if (currentSkill != null)
				{
					currentSkill.UnRegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckCurrentSkillCanUse));
				}
				this.CurrentSkill = null;
				this.RefreshSkillPanelVisible(false, isInit);
				return;
			}
			if (allSkillChange)
			{
				this.SkillPanel.RefreshByData(currentSkillList);
				this.RefreshSkillPanelVisible(true, isInit);
			}
			QuickHackSkillInstance currentSkill2 = this.CurrentSkill;
			if (currentSkill2 != null)
			{
				currentSkill2.UnRegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckCurrentSkillCanUse));
			}
			this.CurrentSkill = currentSelectSkill;
			this.UpdateCurrentSkillCanUse(currentSelectSkill.GetSkillCanUseInfo());
			currentSelectSkill.RegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckCurrentSkillCanUse));
			int num = currentSkillList.IndexOf(currentSelectSkill);
			if (num >= 0)
			{
				this.SkillPanel.Select(num);
			}
			QuickHackSkill config = currentSelectSkill.GetConfig();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.InfoTitleText)), config.SkillName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.InfoTagText)), config.SkillTag, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.InfoDescText)), config.SkillDescribe, Array.Empty<object>());
			int duration = config.Duration;
			bool flag = duration > 0;
			if (this.HasDurationInfo != flag)
			{
				this.HasDurationInfo = flag;
				this.UpdateInfoLine();
			}
			UUIText text = base.GetText(this.GetUiComponentType(EQuickHackUiType.InfoDurationText));
			text.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "QuickHack_SkillMessage_1", new <>z__ReadOnlySingleElementList<object>(((float)duration * 0.001f).ToString("F1")));
			}
		}

		// Token: 0x06036471 RID: 222321 RVA: 0x00DAEE95 File Offset: 0x00DAD095
		private void UpdateInfoLine()
		{
			if (this.HasUploadTimeInfo || this.HasDurationInfo)
			{
				base.GetItem(this.GetUiComponentType(EQuickHackUiType.InfoLineItem)).SetUIActive(true);
				return;
			}
			base.GetItem(this.GetUiComponentType(EQuickHackUiType.InfoLineItem)).SetUIActive(false);
		}

		// Token: 0x06036472 RID: 222322 RVA: 0x00DAEED0 File Offset: 0x00DAD0D0
		private void RefreshSkillPanelVisible(bool visible, bool isInit = false)
		{
			if (!isInit && visible == this.SkillPanelVisible && !visible)
			{
				return;
			}
			this.SkillPanelVisible = visible;
			if (visible)
			{
				this.SequencePlayer.StopSequenceByKey("Close01", false, true);
				this.SequencePlayer.StopSequenceByKey("Start02", false, true);
				this.SequencePlayer.PlaySequencePurely("Start02", false, false);
				return;
			}
			this.SequencePlayer.StopSequenceByKey("Start02", false, false);
			this.SequencePlayer.PlaySequencePurely("Close01", false, false);
			if (isInit)
			{
				this.SequencePlayer.StopSequenceByKey("Close01", false, true);
			}
		}

		// Token: 0x06036473 RID: 222323
		protected abstract string GetSelectSkillAudioPath();

		// Token: 0x06036474 RID: 222324 RVA: 0x00DAEF67 File Offset: 0x00DAD167
		public bool CheckCondition()
		{
			return !Singleton<InputManager>.Instance.IsShowMouseCursor() || !Singleton<Info>.Instance.IsInKeyBoard();
		}

		// Token: 0x06036475 RID: 222325 RVA: 0x00DAEF84 File Offset: 0x00DAD184
		public string[] GetDistributeTags()
		{
			return this.GetInputDistributeTags();
		}

		// Token: 0x06036476 RID: 222326 RVA: 0x00DAEF8C File Offset: 0x00DAD18C
		protected virtual string[] GetInputDistributeTags()
		{
			return new string[]
			{
				"FightInputRoot.FightInput.AxisInput.CameraInput.CameraRotation",
				"UiInputRoot.MouseInputTag",
				"UiInputRoot.Navigation"
			};
		}

		// Token: 0x06036477 RID: 222327 RVA: 0x00DAEFAC File Offset: 0x00DAD1AC
		private void OnCheckCurrentSkillCanUse(QuickHackSkillConditionResult canUseInfo)
		{
			this.UpdateCurrentSkillCanUse(canUseInfo);
			this.RefreshSelectRam();
		}

		// Token: 0x06036478 RID: 222328 RVA: 0x00DAEFBC File Offset: 0x00DAD1BC
		private void UpdateCurrentSkillCanUse(QuickHackSkillConditionResult canUseInfo)
		{
			bool isSuccess = canUseInfo.IsSuccess;
			bool flag = !isSuccess;
			base.GetItem(this.GetUiComponentType(EQuickHackUiType.TipItem)).SetUIActive(flag);
			if (flag)
			{
				string failTextIdByCondition = QuickHackUtil.GetFailTextIdByCondition(canUseInfo.FailConditionType);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(this.GetUiComponentType(EQuickHackUiType.TipText)), failTextIdByCondition, Array.Empty<object>());
			}
			this.OnUpdateCurrentSkillCanUse(isSuccess);
		}

		// Token: 0x06036479 RID: 222329 RVA: 0x00DAF01B File Offset: 0x00DAD21B
		protected virtual void OnUpdateCurrentSkillCanUse(bool canUse)
		{
		}

		// Token: 0x0603647A RID: 222330 RVA: 0x00DAF020 File Offset: 0x00DAD220
		private void RefreshSelectRam()
		{
			if (this.RamBar == null)
			{
				return;
			}
			QuickHackSkillInstance currentSelectSkill = ModelBase<QuickHackModel>.Instance.CurrentSelectSkill;
			if (currentSelectSkill == null)
			{
				this.RamBar.SelectRam(0);
				return;
			}
			QuickHackSkillConditionResult skillCanUseInfo = currentSelectSkill.GetSkillCanUseInfo();
			this.RamBar.SelectRam(skillCanUseInfo.IsSuccess ? currentSelectSkill.GetConfig().RamCost : 0);
		}

		// Token: 0x0603647B RID: 222331 RVA: 0x00DAF07C File Offset: 0x00DAD27C
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			UUIInturnAnimController skillPanelAnim = this.SkillPanelAnim;
			if (skillPanelAnim == null || !skillPanelAnim.IsValid())
			{
				return;
			}
			if (eventName == "Sequence_Start")
			{
				this.SkillPanelAnim.Play("", -1, false);
			}
		}

		// Token: 0x0603647C RID: 222332 RVA: 0x00DAF0B5 File Offset: 0x00DAD2B5
		protected void OnShowMouseCursor(bool value)
		{
			this.UpdateKeyItem();
		}

		// Token: 0x0603647D RID: 222333 RVA: 0x00DAF0BD File Offset: 0x00DAD2BD
		protected void UpdateKeyItem()
		{
			base.GetItem(this.GetUiComponentType(EQuickHackUiType.UseSkillKeyItem)).SetUIActive(Singleton<Info>.Instance.IsInKeyBoard() && !Singleton<InputManager>.Instance.IsShowMouseCursor());
		}

		// Token: 0x0401F33F RID: 127807
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0401F340 RID: 127808
		[Nullable(2)]
		private QuickHackRamBar RamBar;

		// Token: 0x0401F341 RID: 127809
		[Nullable(2)]
		private QuickHackSkillPanel SkillPanel;

		// Token: 0x0401F342 RID: 127810
		private int TargetItemEntityId;

		// Token: 0x0401F343 RID: 127811
		[Nullable(2)]
		private QuickHackTargetItem TargetItem;

		// Token: 0x0401F344 RID: 127812
		private bool HasTarget;

		// Token: 0x0401F345 RID: 127813
		[Nullable(2)]
		private QuickHackSkillInstance CurrentSkill;

		// Token: 0x0401F346 RID: 127814
		private bool SkillPanelVisible;

		// Token: 0x0401F347 RID: 127815
		[Nullable(2)]
		private UUIInturnAnimController SkillPanelAnim;

		// Token: 0x0401F348 RID: 127816
		private int CurrentUploadTime = -1;

		// Token: 0x0401F349 RID: 127817
		private bool HasUploadTimeInfo;

		// Token: 0x0401F34A RID: 127818
		private bool HasDurationInfo;
	}
}
