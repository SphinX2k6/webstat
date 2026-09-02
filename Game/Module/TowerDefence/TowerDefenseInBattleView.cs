using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefence
{
	// Token: 0x02004EC8 RID: 20168
	public class TowerDefenseInBattleView : BattleVisibleChildView
	{
		// Token: 0x0603418E RID: 213390 RVA: 0x00D04DB0 File Offset: 0x00D02FB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603418F RID: 213391 RVA: 0x00D04EDA File Offset: 0x00D030DA
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.MiniMap);
			base.SetVisible(1, false);
			this.AddEventListeners();
		}

		// Token: 0x06034190 RID: 213392 RVA: 0x00D04EF8 File Offset: 0x00D030F8
		public override void Reset()
		{
			base.Reset();
			this.RemoveEventListeners();
		}

		// Token: 0x06034191 RID: 213393 RVA: 0x00D04F08 File Offset: 0x00D03108
		protected override UniTask OnBeforeStartAsync()
		{
			TowerDefenseInBattleView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TowerDefenseInBattleView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034192 RID: 213394 RVA: 0x00D04F4C File Offset: 0x00D0314C
		protected override void OnStart()
		{
			base.GetSprite(2).SetUIActive(true);
			base.GetSprite(5).SetUIActive(true);
			base.GetText(1).SetUIActive(false);
			this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
			this.SeqPlayer.StopCurrentSequence(false, true);
		}

		// Token: 0x06034193 RID: 213395 RVA: 0x00D04FA8 File Offset: 0x00D031A8
		protected override void OnAfterDestroy()
		{
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.TowerDefense, false);
		}

		// Token: 0x06034194 RID: 213396 RVA: 0x00D04FC0 File Offset: 0x00D031C0
		public void StartShow()
		{
			base.SetVisible(1, true);
			this.OnRefreshAll();
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.TowerDefense, true);
		}

		// Token: 0x06034195 RID: 213397 RVA: 0x00D04FE6 File Offset: 0x00D031E6
		public void EndShow()
		{
			base.SetVisible(1, false);
			BattleUiEnvironmentKeyData environmentKeyData = ModelBase<BattleUiModel>.Instance.EnvironmentKeyData;
			if (environmentKeyData == null)
			{
				return;
			}
			environmentKeyData.SetEnvironmentKeyVisible(EEnvironmentKey.TowerDefense, false);
		}

		// Token: 0x06034196 RID: 213398 RVA: 0x00D05008 File Offset: 0x00D03208
		private void AddEventListeners()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.BattleUiToggleTowerDefenseInfoView, new Action(this.OnToggle));
			Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseOnPhantomInfoUpdateNotify, new Action(this.OnRefreshAll));
			Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.TryToggleOff));
			Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseDataInit, new Action(this.HandleTowerDefenseDataInit));
		}

		// Token: 0x06034197 RID: 213399 RVA: 0x00D05088 File Offset: 0x00D03288
		private void RemoveEventListeners()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleUiToggleTowerDefenseInfoView, new Action(this.OnToggle));
			Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseOnPhantomInfoUpdateNotify, new Action(this.OnRefreshAll));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.TryToggleOff));
			Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseDataInit, new Action(this.HandleTowerDefenseDataInit));
		}

		// Token: 0x06034198 RID: 213400 RVA: 0x00D05108 File Offset: 0x00D03308
		private void OnClick(EToggleState toggleState)
		{
			bool flag = toggleState == EToggleState.ETT_Checked;
			TowerDefenseInBattlePanel childPanel = this.ChildPanel;
			if (childPanel != null)
			{
				childPanel.SetActive(flag);
			}
			if (flag)
			{
				TowerDefenseInBattlePanel childPanel2 = this.ChildPanel;
				if (childPanel2 == null)
				{
					return;
				}
				childPanel2.Refresh();
			}
		}

		// Token: 0x06034199 RID: 213401 RVA: 0x00D05140 File Offset: 0x00D03340
		private void OnToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				if (extendToggle.GetToggleState() == EToggleState.ETT_Checked)
				{
					extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
					return;
				}
				extendToggle.SetToggleState(EToggleState.ETT_Checked, true, false, false);
			}
		}

		// Token: 0x0603419A RID: 213402 RVA: 0x00D05178 File Offset: 0x00D03378
		[NullableContext(1)]
		private void TryToggleOff(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null && extendToggle.GetToggleState() == EToggleState.ETT_Checked)
			{
				extendToggle.SetToggleState(EToggleState.ETT_UnChecked, true, false, false);
			}
		}

		// Token: 0x0603419B RID: 213403 RVA: 0x00D051A4 File Offset: 0x00D033A4
		private void HandleTowerDefenseDataInit()
		{
			if (base.GetVisible())
			{
				this.OnRefreshAll();
			}
		}

		// Token: 0x0603419C RID: 213404 RVA: 0x00D051B4 File Offset: 0x00D033B4
		private void OnRefreshAll()
		{
			if (ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.Id != 0)
			{
				this.OnRefreshLevel();
				TowerDefenseInBattlePanel childPanel = this.ChildPanel;
				if (childPanel != null)
				{
					childPanel.Refresh();
				}
				this.RefreshLevelUp();
			}
		}

		// Token: 0x0603419D RID: 213405 RVA: 0x00D051E4 File Offset: 0x00D033E4
		private void OnRefreshLevel()
		{
			string levelContentInBattle = ControllerBase<TowerDefenseController>.Instance.GetLevelContentInBattle();
			base.GetText(1).SetText(levelContentInBattle, true);
			base.GetSprite(2).SetFillAmount(ControllerBase<TowerDefenseController>.Instance.GetProgressInBattle());
		}

		// Token: 0x0603419E RID: 213406 RVA: 0x00D05220 File Offset: 0x00D03420
		private void RefreshLevelUp()
		{
			int levelInBattle = ControllerBase<TowerDefenseController>.Instance.GetLevelInBattle();
			if (levelInBattle != this.LastLevel)
			{
				this.LastLevel = levelInBattle;
				this.SeqPlayer.PlayLevelSequenceByName("Start", false, null, false);
			}
		}

		// Token: 0x0401E175 RID: 123253
		[Nullable(2)]
		private TowerDefenseInBattlePanel ChildPanel;

		// Token: 0x0401E176 RID: 123254
		private int LastLevel = 1;

		// Token: 0x0401E177 RID: 123255
		[Nullable(1)]
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x0200AE65 RID: 44645
		private class EViewComponent
		{
			// Token: 0x04036242 RID: 221762
			public const int Toggle = 0;

			// Token: 0x04036243 RID: 221763
			public const int LevelText = 1;

			// Token: 0x04036244 RID: 221764
			public const int ProgressSprite = 2;

			// Token: 0x04036245 RID: 221765
			public const int ParentItem = 3;

			// Token: 0x04036246 RID: 221766
			public const int LevelUpItem = 4;

			// Token: 0x04036247 RID: 221767
			public const int IconSprite = 5;
		}

		// Token: 0x0200AE66 RID: 44646
		private class EVisibleReason
		{
			// Token: 0x04036248 RID: 221768
			public const int Default = 1;
		}
	}
}
