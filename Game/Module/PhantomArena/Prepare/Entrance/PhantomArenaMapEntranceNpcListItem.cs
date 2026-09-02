using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D8 RID: 21720
	internal class PhantomArenaMapEntranceNpcListItem : GridProxyAbstract<int>
	{
		// Token: 0x06037537 RID: 226615 RVA: 0x00E096B4 File Offset: 0x00E078B4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
			};
		}

		// Token: 0x06037538 RID: 226616 RVA: 0x00E097B8 File Offset: 0x00E079B8
		private void OnClickItem(EToggleState toggleState)
		{
			if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_UnChecked)
			{
				return;
			}
			Action<int> selectCallBack = this.SelectCallBack;
			if (selectCallBack != null)
			{
				selectCallBack(this.ChallengeId);
			}
			IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}

		// Token: 0x06037539 RID: 226617 RVA: 0x00E09808 File Offset: 0x00E07A08
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(delegate()
			{
				int gridIndex = base.GridIndex;
				IScrollViewDelegate<IGridProxy<int>, int> scrollViewDelegate = base.ScrollViewDelegate;
				int? num = (scrollViewDelegate != null) ? new int?(scrollViewDelegate.GetSelectedGridIndex()) : null;
				return !(gridIndex == num.GetValueOrDefault() & num != null);
			});
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(2).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x0603753A RID: 226618 RVA: 0x00E0986C File Offset: 0x00E07A6C
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ChallengeId = data;
			EChallengeState permanentChallengeStateById = ModelBase<PhantomArenaModel>.Instance.GetPermanentChallengeStateById(data);
			PhantomBattleChallenge phantomBattleChallengeConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(data);
			PhantomBattleChallengeInfo permanentChallengeData = ModelBase<PhantomArenaModel>.Instance.GetPermanentChallengeData(data);
			bool flag = ((permanentChallengeData != null) ? permanentChallengeData.FinishConditions : null) == null || ModelBase<PhantomArenaModel>.Instance.GetPermanentChallengeData(data).IsUncover;
			string textStringId = flag ? phantomBattleChallengeConfig.NpcName : EPhantomArenaTextId.TextMysteryNpcName.ToString();
			UUIItem currentStateUi = this.CurrentStateUi;
			if (currentStateUi != null)
			{
				currentStateUi.SetUIActive(false);
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(phantomBattleChallengeConfig.NpcNumber, true);
			}
			switch (permanentChallengeStateById)
			{
			case EChallengeState.Lock:
				this.CurrentStateUi = base.GetItem(7);
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(8), textStringId, Array.Empty<object>());
				break;
			case EChallengeState.Pending:
				this.CurrentStateUi = base.GetItem(2);
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(3), textStringId, Array.Empty<object>());
				break;
			case EChallengeState.Finish:
				this.CurrentStateUi = base.GetItem(5);
				Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(6), textStringId, Array.Empty<object>());
				break;
			}
			UUIItem currentStateUi2 = this.CurrentStateUi;
			if (currentStateUi2 != null)
			{
				currentStateUi2.SetUIActive(true);
			}
			if (flag)
			{
				base.TrySetTextureByPath(phantomBattleChallengeConfig.NpcMapHead, base.GetTexture(1), null, null);
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("MysteryNpcHead");
			base.TrySetTextureByPath(resourcePath, base.GetTexture(1), null, null);
		}

		// Token: 0x0603753B RID: 226619 RVA: 0x00E099F2 File Offset: 0x00E07BF2
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x0603753C RID: 226620 RVA: 0x00E09A0A File Offset: 0x00E07C0A
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0603753D RID: 226621 RVA: 0x00E09A22 File Offset: 0x00E07C22
		[NullableContext(1)]
		public override object GetKey(int data, int displayIndex)
		{
			return data;
		}

		// Token: 0x0401FC89 RID: 130185
		private int ChallengeId;

		// Token: 0x0401FC8A RID: 130186
		[Nullable(2)]
		private UUIItem CurrentStateUi;

		// Token: 0x0401FC8B RID: 130187
		[Nullable(2)]
		public Action<int> SelectCallBack;

		// Token: 0x0200B448 RID: 46152
		private static class EComponents
		{
			// Token: 0x04037CB2 RID: 228530
			public const int Toggle = 0;

			// Token: 0x04037CB3 RID: 228531
			public const int TexNPC = 1;

			// Token: 0x04037CB4 RID: 228532
			public const int PnlNor = 2;

			// Token: 0x04037CB5 RID: 228533
			public const int TextNameNor = 3;

			// Token: 0x04037CB6 RID: 228534
			public const int TextNum = 4;

			// Token: 0x04037CB7 RID: 228535
			public const int PnlDone = 5;

			// Token: 0x04037CB8 RID: 228536
			public const int TextNameDone = 6;

			// Token: 0x04037CB9 RID: 228537
			public const int PnlLock = 7;

			// Token: 0x04037CBA RID: 228538
			public const int TextNameLock = 8;
		}
	}
}
