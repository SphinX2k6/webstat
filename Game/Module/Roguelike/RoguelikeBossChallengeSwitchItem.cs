using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005148 RID: 20808
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeSwitchItem : UiPanelBase
	{
		// Token: 0x060358D4 RID: 219348 RVA: 0x00D717C8 File Offset: 0x00D6F9C8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnSwitchLeftClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnBtnSwitchRightClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060358D5 RID: 219349 RVA: 0x00D718F4 File Offset: 0x00D6FAF4
		protected override void OnStart()
		{
			this.PagePointLayout = new GenericLayout<RoguelikeBossChallengePagePointItem, bool>(base.GetHorizontalLayout(3), new Func<RoguelikeBossChallengePagePointItem>(this.CreatePagePointItem), null, false, true);
		}

		// Token: 0x060358D6 RID: 219350 RVA: 0x00D71917 File Offset: 0x00D6FB17
		protected override void OnBeforeDestroy()
		{
			this.OnBossChangedCallback = null;
			this.PagePointLayout = null;
			this.BossIdList = new List<int>();
		}

		// Token: 0x060358D7 RID: 219351 RVA: 0x00D71932 File Offset: 0x00D6FB32
		public void SetOnBossChangedCallback(Action<ERoguelikeBossChallengeSwitchDirection> callback)
		{
			this.OnBossChangedCallback = callback;
		}

		// Token: 0x060358D8 RID: 219352 RVA: 0x00D7193B File Offset: 0x00D6FB3B
		public void RefreshBossList(List<int> idList)
		{
			this.BossIdList = idList;
			this.CurrentIndex = 0;
			this.RefreshSwitchButtonVisible();
			this.RefreshPagePointLayout();
			this.RefreshBossName();
		}

		// Token: 0x060358D9 RID: 219353 RVA: 0x00D7195D File Offset: 0x00D6FB5D
		public void SetSelectedIndex(int index)
		{
			if (index < 0 || index >= this.BossIdList.Count)
			{
				return;
			}
			this.CurrentIndex = index;
			this.RefreshSwitchButtonVisible();
			GenericLayout<RoguelikeBossChallengePagePointItem, bool> pagePointLayout = this.PagePointLayout;
			if (pagePointLayout != null)
			{
				pagePointLayout.SelectGridProxy(this.CurrentIndex, true);
			}
			this.RefreshBossName();
		}

		// Token: 0x060358DA RID: 219354 RVA: 0x00D7199D File Offset: 0x00D6FB9D
		public int GetCurrentIndex()
		{
			return this.CurrentIndex;
		}

		// Token: 0x060358DB RID: 219355 RVA: 0x00D719A5 File Offset: 0x00D6FBA5
		public int GetCurrentBossId()
		{
			if (this.CurrentIndex >= 0 && this.CurrentIndex < this.BossIdList.Count)
			{
				return this.BossIdList[this.CurrentIndex];
			}
			return 0;
		}

		// Token: 0x060358DC RID: 219356 RVA: 0x00D719D8 File Offset: 0x00D6FBD8
		private void RefreshSwitchButtonVisible()
		{
			bool uiactive = this.BossIdList.Count > 1;
			base.GetButton(0).RootUIComp.Get().SetUIActive(uiactive);
			base.GetButton(1).RootUIComp.Get().SetUIActive(uiactive);
		}

		// Token: 0x060358DD RID: 219357 RVA: 0x00D71A28 File Offset: 0x00D6FC28
		private void RefreshBossName()
		{
			if (this.CurrentIndex < 0 || this.CurrentIndex >= this.BossIdList.Count)
			{
				return;
			}
			int id = this.BossIdList[this.CurrentIndex];
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueTower? rogueTower = (instance != null) ? instance.GetRogueTowerConfig(id) : null;
			if (rogueTower == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), rogueTower.Value.Name, Array.Empty<object>());
		}

		// Token: 0x060358DE RID: 219358 RVA: 0x00D71AB0 File Offset: 0x00D6FCB0
		private void RefreshPagePointLayout()
		{
			bool flag = this.BossIdList.Count > 1;
			base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(flag);
			if (flag)
			{
				List<bool> list = new List<bool>();
				for (int i = 0; i < this.BossIdList.Count; i++)
				{
					list.Add(i == this.CurrentIndex);
				}
				GenericLayout<RoguelikeBossChallengePagePointItem, bool> pagePointLayout = this.PagePointLayout;
				if (pagePointLayout == null)
				{
					return;
				}
				pagePointLayout.RefreshByData(list, delegate
				{
					GenericLayout<RoguelikeBossChallengePagePointItem, bool> pagePointLayout2 = this.PagePointLayout;
					if (pagePointLayout2 == null)
					{
						return;
					}
					pagePointLayout2.SelectGridProxy(this.CurrentIndex, true);
				}, false);
			}
		}

		// Token: 0x060358DF RID: 219359 RVA: 0x00D71B32 File Offset: 0x00D6FD32
		private RoguelikeBossChallengePagePointItem CreatePagePointItem()
		{
			return new RoguelikeBossChallengePagePointItem();
		}

		// Token: 0x060358E0 RID: 219360 RVA: 0x00D71B3C File Offset: 0x00D6FD3C
		private void OnBtnSwitchLeftClick()
		{
			if (this.BossIdList.Count <= 1)
			{
				return;
			}
			this.CurrentIndex = (this.CurrentIndex - 1 + this.BossIdList.Count) % this.BossIdList.Count;
			GenericLayout<RoguelikeBossChallengePagePointItem, bool> pagePointLayout = this.PagePointLayout;
			if (pagePointLayout != null)
			{
				pagePointLayout.SelectGridProxy(this.CurrentIndex, true);
			}
			this.RefreshBossName();
			Action<ERoguelikeBossChallengeSwitchDirection> onBossChangedCallback = this.OnBossChangedCallback;
			if (onBossChangedCallback == null)
			{
				return;
			}
			onBossChangedCallback(ERoguelikeBossChallengeSwitchDirection.Left);
		}

		// Token: 0x060358E1 RID: 219361 RVA: 0x00D71BB0 File Offset: 0x00D6FDB0
		private void OnBtnSwitchRightClick()
		{
			if (this.BossIdList.Count <= 1)
			{
				return;
			}
			this.CurrentIndex = (this.CurrentIndex + 1) % this.BossIdList.Count;
			GenericLayout<RoguelikeBossChallengePagePointItem, bool> pagePointLayout = this.PagePointLayout;
			if (pagePointLayout != null)
			{
				pagePointLayout.SelectGridProxy(this.CurrentIndex, true);
			}
			this.RefreshBossName();
			Action<ERoguelikeBossChallengeSwitchDirection> onBossChangedCallback = this.OnBossChangedCallback;
			if (onBossChangedCallback == null)
			{
				return;
			}
			onBossChangedCallback(ERoguelikeBossChallengeSwitchDirection.Right);
		}

		// Token: 0x0401EC49 RID: 126025
		[Nullable(2)]
		private Action<ERoguelikeBossChallengeSwitchDirection> OnBossChangedCallback;

		// Token: 0x0401EC4A RID: 126026
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RoguelikeBossChallengePagePointItem, bool> PagePointLayout;

		// Token: 0x0401EC4B RID: 126027
		private List<int> BossIdList = new List<int>();

		// Token: 0x0401EC4C RID: 126028
		private int CurrentIndex;

		// Token: 0x0200B0E7 RID: 45287
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DF6 RID: 224758
			public const int BtnSwitchL = 0;

			// Token: 0x04036DF7 RID: 224759
			public const int BtnSwitchR = 1;

			// Token: 0x04036DF8 RID: 224760
			public const int TxtBossName = 2;

			// Token: 0x04036DF9 RID: 224761
			public const int PnlPagePointLayout = 3;

			// Token: 0x04036DFA RID: 224762
			public const int UiItemPagePoint = 4;
		}
	}
}
