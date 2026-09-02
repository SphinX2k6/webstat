using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDB RID: 24539
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleSkillUltraItem : UiPanelBase
	{
		// Token: 0x0603DBE9 RID: 252905 RVA: 0x00FBAA60 File Offset: 0x00FB8C60
		public BattleSkillUltraItem(UUIItem rootUiItem)
		{
			base.CreateByResourceIdAsync("UiItem_BattleSkillUltraItem", rootUiItem, false).Forget();
		}

		// Token: 0x0603DBEA RID: 252906 RVA: 0x00FBAABC File Offset: 0x00FB8CBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DBEB RID: 252907 RVA: 0x00FBAB88 File Offset: 0x00FB8D88
		protected override void OnStart()
		{
			this.FrameSprite = base.GetSprite(0);
			foreach (Action action in this.OperationMap.Values)
			{
				action();
			}
			if (ModelBase<BattleLinkModel>.Instance.CheckInDreamLink())
			{
				this.RefreshLinkEffect();
				this.HasBattleLinkEvent = true;
				Singleton<EventSystem>.Instance.Add<ELinkStatus>(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
			}
		}

		// Token: 0x0603DBEC RID: 252908 RVA: 0x00FBAC20 File Offset: 0x00FB8E20
		protected override void OnBeforeDestroy()
		{
			this.FrameSprite = null;
			this.OperationMap.Clear();
			this.CancelLoadUltraNiagara();
			this.CancelLoadUltraTipsNiagara();
			if (this.HasBattleLinkEvent)
			{
				this.HasBattleLinkEvent = false;
				Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleLinkStatusChanged, new Action<ELinkStatus>(this.OnBattleLinkStatusChanged));
			}
		}

		// Token: 0x0603DBED RID: 252909 RVA: 0x00FBAC76 File Offset: 0x00FB8E76
		public void SetComponentActive(bool visibility)
		{
			this.Visible = visibility;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetActive"] = new Action(this.<SetComponentActive>g__Callback|18_0);
				return;
			}
			this.<SetComponentActive>g__Callback|18_0();
		}

		// Token: 0x0603DBEE RID: 252910 RVA: 0x00FBACAC File Offset: 0x00FB8EAC
		public void SetBarPercent(float energyPercent, bool bPlayUpEffect)
		{
			BattleSkillUltraItem.<>c__DisplayClass19_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass19_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.energyPercent = energyPercent;
			if (this.CurrentEnergyPercent == CS$<>8__locals1.energyPercent)
			{
				return;
			}
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetBarPercent"] = new Action(CS$<>8__locals1.<SetBarPercent>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetBarPercent>g__Callback|0();
		}

		// Token: 0x0603DBEF RID: 252911 RVA: 0x00FBAD08 File Offset: 0x00FB8F08
		public void SetBarVisible(bool flag)
		{
			BattleSkillUltraItem.<>c__DisplayClass20_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass20_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.flag = flag;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetBarVisible"] = new Action(CS$<>8__locals1.<SetBarVisible>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetBarVisible>g__Callback|0();
		}

		// Token: 0x0603DBF0 RID: 252912 RVA: 0x00FBAD54 File Offset: 0x00FB8F54
		public void SetFrameSprite(FColor frameSpriteColor)
		{
			BattleSkillUltraItem.<>c__DisplayClass21_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass21_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.frameSpriteColor = frameSpriteColor;
			if (this.FrameSpriteColor == CS$<>8__locals1.frameSpriteColor)
			{
				return;
			}
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetFrameSprite"] = new Action(CS$<>8__locals1.<SetFrameSprite>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetFrameSprite>g__Callback|0();
		}

		// Token: 0x0603DBF1 RID: 252913 RVA: 0x00FBADCA File Offset: 0x00FB8FCA
		[NullableContext(2)]
		private void SetEffectEnable(UUINiagara effect, bool bEnable)
		{
			if (effect == null)
			{
				return;
			}
			if (effect.bIsUIActive != bEnable)
			{
				effect.SetUIActive(bEnable);
				if (bEnable)
				{
					effect.ActivateSystem(true);
					return;
				}
				effect.DeactivateSystem();
			}
		}

		// Token: 0x0603DBF2 RID: 252914 RVA: 0x00FBADF4 File Offset: 0x00FB8FF4
		public void SetUltraEffectEnable(bool bEnable)
		{
			BattleSkillUltraItem.<>c__DisplayClass23_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass23_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bEnable = bEnable;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetUltraEffectEnable"] = new Action(CS$<>8__locals1.<SetUltraEffectEnable>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetUltraEffectEnable>g__Callback|0();
		}

		// Token: 0x0603DBF3 RID: 252915 RVA: 0x00FBAE40 File Offset: 0x00FB9040
		public void SetUltraTipsEffectEnable(bool bEnable)
		{
			BattleSkillUltraItem.<>c__DisplayClass24_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass24_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bEnable = bEnable;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetUltraTipsEffectEnable"] = new Action(CS$<>8__locals1.<SetUltraTipsEffectEnable>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetUltraTipsEffectEnable>g__Callback|0();
		}

		// Token: 0x0603DBF4 RID: 252916 RVA: 0x00FBAE8C File Offset: 0x00FB908C
		public void SetUltraUpEffectEnable(bool bEnable)
		{
			BattleSkillUltraItem.<>c__DisplayClass25_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass25_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.bEnable = bEnable;
			if (base.InAsyncLoading())
			{
				this.OperationMap["SetUltraUpEffectEnable"] = new Action(CS$<>8__locals1.<SetUltraUpEffectEnable>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<SetUltraUpEffectEnable>g__Callback|0();
		}

		// Token: 0x0603DBF5 RID: 252917 RVA: 0x00FBAED8 File Offset: 0x00FB90D8
		public void RefreshUltraEffect(string effectPath, FLinearColor effectColor)
		{
			BattleSkillUltraItem.<>c__DisplayClass26_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass26_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.effectPath = effectPath;
			CS$<>8__locals1.effectColor = effectColor;
			if (!string.IsNullOrEmpty(this.UltNiagaraPath) && this.UltNiagaraPath == CS$<>8__locals1.effectPath)
			{
				if (this.UltNiagaraColor != CS$<>8__locals1.effectColor)
				{
					this.UltNiagaraColor = new FLinearColor?(CS$<>8__locals1.effectColor);
					if (!base.InAsyncLoading())
					{
						UUINiagara uiNiagara = base.GetUiNiagara(1);
						if (uiNiagara == null)
						{
							return;
						}
						uiNiagara.SetNiagaraVarLinearColor("Color", CS$<>8__locals1.effectColor);
					}
				}
				return;
			}
			this.UltNiagaraColor = new FLinearColor?(CS$<>8__locals1.effectColor);
			if (base.InAsyncLoading())
			{
				this.OperationMap["RefreshUltraEffect"] = new Action(CS$<>8__locals1.<RefreshUltraEffect>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<RefreshUltraEffect>g__Callback|0();
		}

		// Token: 0x0603DBF6 RID: 252918 RVA: 0x00FBAFBB File Offset: 0x00FB91BB
		private void CancelLoadUltraNiagara()
		{
			if (this.LoadUltraNiagaraHandleId == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadUltraNiagaraHandleId.Value);
			this.LoadUltraNiagaraHandleId = null;
		}

		// Token: 0x0603DBF7 RID: 252919 RVA: 0x00FBAFEC File Offset: 0x00FB91EC
		public void RefreshUltraTipsEffect(string effectPath)
		{
			BattleSkillUltraItem.<>c__DisplayClass28_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass28_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.effectPath = effectPath;
			if (!string.IsNullOrEmpty(this.UltTipsNiagaraPath) && this.UltTipsNiagaraPath == CS$<>8__locals1.effectPath)
			{
				return;
			}
			if (base.InAsyncLoading())
			{
				this.OperationMap["RefreshUltraTipsEffect"] = new Action(CS$<>8__locals1.<RefreshUltraTipsEffect>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<RefreshUltraTipsEffect>g__Callback|0();
		}

		// Token: 0x0603DBF8 RID: 252920 RVA: 0x00FBB059 File Offset: 0x00FB9259
		private void CancelLoadUltraTipsNiagara()
		{
			if (this.LoadUltraTipsNiagaraHandleId == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadUltraTipsNiagaraHandleId.Value);
			this.LoadUltraTipsNiagaraHandleId = null;
		}

		// Token: 0x0603DBF9 RID: 252921 RVA: 0x00FBB08C File Offset: 0x00FB928C
		public void RefreshUltraDynamicEffect(string effectPath, FLinearColor? effectColor = null)
		{
			BattleSkillUltraItem.<>c__DisplayClass30_0 CS$<>8__locals1 = new BattleSkillUltraItem.<>c__DisplayClass30_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.effectPath = effectPath;
			if (!string.IsNullOrEmpty(this.UltDynamicNiagaraPath) && this.UltDynamicNiagaraPath == CS$<>8__locals1.effectPath)
			{
				return;
			}
			if (base.InAsyncLoading())
			{
				this.OperationMap["RefreshUltraDynamicEffect"] = new Action(CS$<>8__locals1.<RefreshUltraDynamicEffect>g__Callback|0);
				return;
			}
			CS$<>8__locals1.<RefreshUltraDynamicEffect>g__Callback|0();
		}

		// Token: 0x0603DBFA RID: 252922 RVA: 0x00FBB0F9 File Offset: 0x00FB92F9
		private void CancelLoadUltraDynamicNiagara()
		{
			if (this.LoadUltraDynamicNiagaraHandleId == null)
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadUltraDynamicNiagaraHandleId.Value);
			this.LoadUltraDynamicNiagaraHandleId = null;
		}

		// Token: 0x0603DBFB RID: 252923 RVA: 0x00FBB12A File Offset: 0x00FB932A
		public void StopUltraDynamicEffect()
		{
			UUINiagara uiNiagara = base.GetUiNiagara(4);
			if (uiNiagara != null)
			{
				uiNiagara.DeactivateSystem();
			}
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(false);
		}

		// Token: 0x0603DBFC RID: 252924 RVA: 0x00FBB14C File Offset: 0x00FB934C
		public bool HasValidUltDynamicEffect()
		{
			return this.LoadUltraDynamicNiagaraHandleId != null && ModelBase<BattleLinkModel>.Instance.CheckInDreamLink() && ModelBase<BattleLinkModel>.Instance.CanUseLinkSkill(null);
		}

		// Token: 0x0603DBFD RID: 252925 RVA: 0x00FBB187 File Offset: 0x00FB9387
		private void OnBattleLinkStatusChanged(ELinkStatus state)
		{
			this.RefreshLinkEffect();
		}

		// Token: 0x0603DBFE RID: 252926 RVA: 0x00FBB190 File Offset: 0x00FB9390
		private void RefreshLinkEffect()
		{
			bool ultraEffectEnable = ModelBase<BattleLinkModel>.Instance.CanUseLinkSkill(null);
			this.SetUltraEffectEnable(ultraEffectEnable);
		}

		// Token: 0x0603DBFF RID: 252927 RVA: 0x00FBB1B8 File Offset: 0x00FB93B8
		[CompilerGenerated]
		private void <SetComponentActive>g__Callback|18_0()
		{
			this.SetActive(this.Visible);
		}

		// Token: 0x04022A3A RID: 141882
		public bool Visible;

		// Token: 0x04022A3B RID: 141883
		[Nullable(2)]
		private UUISprite FrameSprite;

		// Token: 0x04022A3C RID: 141884
		private FColor? FrameSpriteColor;

		// Token: 0x04022A3D RID: 141885
		private string UltNiagaraPath = string.Empty;

		// Token: 0x04022A3E RID: 141886
		private FLinearColor? UltNiagaraColor;

		// Token: 0x04022A3F RID: 141887
		private string UltTipsNiagaraPath = string.Empty;

		// Token: 0x04022A40 RID: 141888
		private string UltDynamicNiagaraPath = string.Empty;

		// Token: 0x04022A41 RID: 141889
		private int? LoadUltraNiagaraHandleId;

		// Token: 0x04022A42 RID: 141890
		private int? LoadUltraTipsNiagaraHandleId;

		// Token: 0x04022A43 RID: 141891
		private int? LoadUltraDynamicNiagaraHandleId;

		// Token: 0x04022A44 RID: 141892
		private float CurrentEnergyPercent = -1f;

		// Token: 0x04022A45 RID: 141893
		private readonly Dictionary<string, Action> OperationMap = new Dictionary<string, Action>();

		// Token: 0x04022A46 RID: 141894
		private bool HasBattleLinkEvent;

		// Token: 0x0200C04F RID: 49231
		[NullableContext(0)]
		private enum ESkillUltraItem
		{
			// Token: 0x0403B310 RID: 242448
			BarSprite,
			// Token: 0x0403B311 RID: 242449
			UltNiagara,
			// Token: 0x0403B312 RID: 242450
			UltTipsNiagara,
			// Token: 0x0403B313 RID: 242451
			UltUpNiagara,
			// Token: 0x0403B314 RID: 242452
			UltDynamicNiagara
		}
	}
}
