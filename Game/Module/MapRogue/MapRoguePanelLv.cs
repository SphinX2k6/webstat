using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005943 RID: 22851
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRoguePanelLv : UiPanelBase
	{
		// Token: 0x06039F52 RID: 237394 RVA: 0x00EAB3D0 File Offset: 0x00EA95D0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action(this.OnMenuBtnClick))
			};
		}

		// Token: 0x06039F53 RID: 237395 RVA: 0x00EAB437 File Offset: 0x00EA9637
		protected override void OnStart()
		{
			this.LevelSequencePlayerInstance = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06039F54 RID: 237396 RVA: 0x00EAB44A File Offset: 0x00EA964A
		protected override void OnBeforeShow()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06039F55 RID: 237397 RVA: 0x00EAB468 File Offset: 0x00EA9668
		protected override void OnBeforeHide()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x06039F56 RID: 237398 RVA: 0x00EAB486 File Offset: 0x00EA9686
		private void OnActivitySequenceEmitEvent(string name)
		{
			if (name == "LevelChange")
			{
				this.RefreshLv();
			}
		}

		// Token: 0x06039F57 RID: 237399 RVA: 0x00EAB49C File Offset: 0x00EA969C
		private void RefreshLv()
		{
			UUIArtText artText = base.GetArtText(0);
			string text;
			if (this.Lv < 10)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("0");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Lv);
				text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				text = this.Lv.ToString();
			}
			artText.SetText(text);
		}

		// Token: 0x06039F58 RID: 237400 RVA: 0x00EAB4F8 File Offset: 0x00EA96F8
		public void SetLv(int lv, bool needAnim = false)
		{
			if (this.Lv == lv)
			{
				return;
			}
			this.Lv = lv;
			if (!needAnim)
			{
				this.RefreshLv();
				return;
			}
			string text = "LevelUp";
			if (this.LevelSequencePlayerInstance.GetCurrentSequence() == text)
			{
				this.LevelSequencePlayerInstance.ReplaySequenceByKey(text);
				return;
			}
			this.LevelSequencePlayerInstance.PlayLevelSequenceByName(text, false, null, false);
		}

		// Token: 0x06039F59 RID: 237401 RVA: 0x00EAB55D File Offset: 0x00EA975D
		public void SetButtonActive(bool bActive)
		{
			base.GetButton(1).SetSelfInteractive(bActive);
		}

		// Token: 0x06039F5A RID: 237402 RVA: 0x00EAB56C File Offset: 0x00EA976C
		private void OnMenuBtnClick()
		{
			if (this.CheckCanOpenMenu != null && !this.CheckCanOpenMenu())
			{
				return;
			}
			ControllerBase<MapRogueController>.Instance.OpenRogueMenuView();
		}

		// Token: 0x04020D75 RID: 134517
		private int Lv;

		// Token: 0x04020D76 RID: 134518
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayerInstance;

		// Token: 0x04020D77 RID: 134519
		[Nullable(2)]
		public Func<bool> CheckCanOpenMenu;

		// Token: 0x04020D78 RID: 134520
		private const string LEVEL_CHANGE_SEQ_EVENT = "LevelChange";
	}
}
