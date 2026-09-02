using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x0200614C RID: 24908
	public class AutoPilotSkillHighLightLogic
	{
		// Token: 0x0603EED8 RID: 257752 RVA: 0x010213DA File Offset: 0x0101F5DA
		private void StartTimer()
		{
			this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnHighlightTimeUp), (float)(ModelBase<AutoPilotModel>.Instance.GetSkillHighLightTime() * Singleton<TimeUtil>.Instance.InverseMillisecond), null, null, true, 1f);
		}

		// Token: 0x0603EED9 RID: 257753 RVA: 0x01021416 File Offset: 0x0101F616
		private void ClearTimer()
		{
			if (this.TimerHandle != null && TimerSystem.Instance.Has(this.TimerHandle))
			{
				TimerSystem.Instance.Remove(this.TimerHandle);
				this.TimerHandle = null;
			}
		}

		// Token: 0x0603EEDA RID: 257754 RVA: 0x0102144A File Offset: 0x0101F64A
		public void Dispose()
		{
			if (this.Highlighting)
			{
				this.OnHideHighlightExploreSkill();
			}
			this.ClearTimer();
		}

		// Token: 0x0603EEDB RID: 257755 RVA: 0x01021460 File Offset: 0x0101F660
		public void ShowHighlightExploreSkill()
		{
			if (this.Highlighting)
			{
				Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "上一次高亮探索技能未结束", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.LastExploreToolId = (ERouletteExploreId)ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
			Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "主动触发玩家探索技能高亮", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnShowHighlightExploreSkill();
		}

		// Token: 0x0603EEDC RID: 257756 RVA: 0x010214CC File Offset: 0x0101F6CC
		public void HideHighlightExploreSkill()
		{
			if (!this.Highlighting)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "主动触发玩家探索技能取消高亮", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnHideHighlightExploreSkill();
		}

		// Token: 0x0603EEDD RID: 257757 RVA: 0x01021508 File Offset: 0x0101F708
		private void TryAddTag()
		{
			Entity vehicleEntity = ModelBase<AutoPilotModel>.Instance.VehicleEntity;
			BaseTagComponent baseTagComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && !baseTagComponent.HasTag(this.HighlightTagId))
			{
				baseTagComponent.AddTag(new int?(this.HighlightTagId));
			}
		}

		// Token: 0x0603EEDE RID: 257758 RVA: 0x01021550 File Offset: 0x0101F750
		private void TryRemoveTag()
		{
			Entity vehicleEntity = ModelBase<AutoPilotModel>.Instance.VehicleEntity;
			BaseTagComponent baseTagComponent = (vehicleEntity != null) ? vehicleEntity.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && baseTagComponent.HasTag(this.HighlightTagId))
			{
				baseTagComponent.RemoveTag(new int?(this.HighlightTagId));
			}
		}

		// Token: 0x0603EEDF RID: 257759 RVA: 0x01021598 File Offset: 0x0101F798
		private void OnShowHighlightExploreSkill()
		{
			this.Highlighting = true;
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest((int)this.ExploreToolId, null, false);
			Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseExploreSkill));
			Singleton<EventSystem>.Instance.Add(EEventName.OnChangeSelectedExploreId, new Action(this.OnChangeExploreSkill));
			this.TryAddTag();
			this.StartTimer();
		}

		// Token: 0x0603EEE0 RID: 257760 RVA: 0x01021600 File Offset: 0x0101F800
		private void OnHideHighlightExploreSkill()
		{
			this.Highlighting = false;
			this.TryRemoveTag();
			ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest((int)this.LastExploreToolId, null, false);
			Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnUseExploreSkill));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeSelectedExploreId, new Action(this.OnChangeExploreSkill));
			this.ClearTimer();
		}

		// Token: 0x0603EEE1 RID: 257761 RVA: 0x01021668 File Offset: 0x0101F868
		private void OnHighlightTimeUp(float delta)
		{
			Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "高亮时间结束，玩家探索技能取消高亮", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.OnHideHighlightExploreSkill();
		}

		// Token: 0x0603EEE2 RID: 257762 RVA: 0x0102169C File Offset: 0x0101F89C
		private void OnChangeExploreSkill()
		{
			if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId == (int)this.ExploreToolId)
			{
				Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "切换探索技能，玩家探索技能高亮", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TryAddTag();
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.AutoPilot, ELogAuthor.CB, "切换探索技能，玩家探索技能取消高亮", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.TryRemoveTag();
		}

		// Token: 0x0603EEE3 RID: 257763 RVA: 0x01021708 File Offset: 0x0101F908
		private void OnUseExploreSkill(int charId, int skillId, bool isAutonomousProxy)
		{
			SVisionData visionData = PhantomUtil.GetVisionData((int)this.ExploreToolId);
			if (visionData == null)
			{
				return;
			}
			int 技能ID = visionData.技能ID;
			if (skillId == 技能ID)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.AutoPilot;
				ELogAuthor author = ELogAuthor.CB;
				string message = "使用高亮技能，玩家探索技能取消高亮";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.ExploreToolId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.OnHideHighlightExploreSkill();
			}
		}

		// Token: 0x040234FE RID: 144638
		private readonly ERouletteExploreId ExploreToolId = ERouletteExploreId.摩托自动巡航;

		// Token: 0x040234FF RID: 144639
		private ERouletteExploreId LastExploreToolId = ERouletteExploreId.摩托自动巡航;

		// Token: 0x04023500 RID: 144640
		private readonly int HighlightTagId = GameplayTagDefine.EGameplayTagId["系统.自动巡航.探索技能高亮"];

		// Token: 0x04023501 RID: 144641
		private bool Highlighting;

		// Token: 0x04023502 RID: 144642
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
