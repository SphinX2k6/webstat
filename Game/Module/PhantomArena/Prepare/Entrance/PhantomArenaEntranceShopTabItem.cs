using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054C8 RID: 21704
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaEntranceShopTabItem : CommonTabItemBase
	{
		// Token: 0x0603748A RID: 226442 RVA: 0x00E06B5C File Offset: 0x00E04D5C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggleSpriteTransition)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleClick))
			};
		}

		// Token: 0x0603748B RID: 226443 RVA: 0x00E06BF0 File Offset: 0x00E04DF0
		protected override void OnStart()
		{
			base.OnStart();
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			Action callback = delegate()
			{
				Action onUndeterminedClick = this.OnUndeterminedClick;
				if (onUndeterminedClick == null)
				{
					return;
				}
				onUndeterminedClick();
			};
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(callback);
			base.GetItem(3).SetUIActive(false);
		}

		// Token: 0x0603748C RID: 226444 RVA: 0x00E06C40 File Offset: 0x00E04E40
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0603748D RID: 226445 RVA: 0x00E06C48 File Offset: 0x00E04E48
		protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
		{
			PhantomArenaEntranceShopTabData phantomArenaEntranceShopTabData = data.Data as PhantomArenaEntranceShopTabData;
			this.UpdateIcon(phantomArenaEntranceShopTabData);
			this.UpdateTabTitle(phantomArenaEntranceShopTabData.GetRealTitle());
			this.UnBindRedDot();
			if (data.RedDotName != null)
			{
				this.BindRedDot(data.RedDotName.Value, data.RedDotUid.Value);
			}
		}

		// Token: 0x0603748E RID: 226446 RVA: 0x00E06CA3 File Offset: 0x00E04EA3
		private void ToggleClick(EToggleState toggleState)
		{
			if (base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked)
			{
				this.SelectedCallBack(base.GridIndex);
			}
		}

		// Token: 0x0603748F RID: 226447 RVA: 0x00E06CC7 File Offset: 0x00E04EC7
		public override void OnSelected(bool fireEvent)
		{
			this.SelectedCallBack(base.GridIndex);
		}

		// Token: 0x06037490 RID: 226448 RVA: 0x00E06CDA File Offset: 0x00E04EDA
		protected override void OnUpdateTabIcon(string iconPath)
		{
		}

		// Token: 0x06037491 RID: 226449 RVA: 0x00E06CDC File Offset: 0x00E04EDC
		protected void UpdateIcon(PhantomArenaEntranceShopTabData data)
		{
			EUiTabViewName tabViewName = data.GetTabViewName();
			string[] array;
			if (!PhantomArenaDefine.phantomArenaEntranceShopTabIconMap.TryGetValue(tabViewName, out array))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[0]);
			string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(array[1]);
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(resourcePath, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				if (sprite != null)
				{
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition != null)
					{
						uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_UnCheckedUnHover, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition2 = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition2 != null)
					{
						uiExtendToggleSpriteTransition2.SetStateSprite(EToggleTransitionState.ETT_UnCheckedHover, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition3 = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition3 == null)
					{
						return;
					}
					uiExtendToggleSpriteTransition3.SetStateSprite(EToggleTransitionState.ETT_UnCheckedPressed, sprite, false);
				}
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(resourcePath2, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				if (sprite != null)
				{
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition != null)
					{
						uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_CheckedUnHover, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition2 = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition2 != null)
					{
						uiExtendToggleSpriteTransition2.SetStateSprite(EToggleTransitionState.ETT_CheckedHover, sprite, false);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition3 = base.GetUiExtendToggleSpriteTransition(2);
					if (uiExtendToggleSpriteTransition3 == null)
					{
						return;
					}
					uiExtendToggleSpriteTransition3.SetStateSprite(EToggleTransitionState.ETT_CheckedPressed, sprite, false);
				}
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
		}

		// Token: 0x06037492 RID: 226450 RVA: 0x00E06D5C File Offset: 0x00E04F5C
		protected void UpdateTabTitle(string titleId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), titleId, Array.Empty<object>());
		}

		// Token: 0x06037493 RID: 226451 RVA: 0x00E06D75 File Offset: 0x00E04F75
		public void SetToggleStateForce(EToggleState state, bool bFire)
		{
			base.GetExtendToggle(0).SetToggleStateForce(state, bFire, false, false);
		}

		// Token: 0x06037494 RID: 226452 RVA: 0x00E06D87 File Offset: 0x00E04F87
		public void SetCanClickWhenDisable(bool state)
		{
			base.GetExtendToggle(0).SetCanClickWhenDisable(state);
		}

		// Token: 0x06037495 RID: 226453 RVA: 0x00E06D96 File Offset: 0x00E04F96
		public void SetOnUndeterminedClick(Action call)
		{
			this.OnUndeterminedClick = call;
		}

		// Token: 0x06037496 RID: 226454 RVA: 0x00E06D9F File Offset: 0x00E04F9F
		protected override void OnSetToggleState(EToggleState state, bool bFire)
		{
			base.GetExtendToggle(0).SetToggleState(state, bFire, false, false);
		}

		// Token: 0x06037497 RID: 226455 RVA: 0x00E06DB2 File Offset: 0x00E04FB2
		protected override UUIExtendToggle GetTabToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06037498 RID: 226456 RVA: 0x00E06DBB File Offset: 0x00E04FBB
		public void BindRedDot(ERedDotName redDotName, int uId = 0)
		{
			this.RedDotName = new ERedDotName?(redDotName);
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, base.GetItem(3), null, uId);
			}
		}

		// Token: 0x06037499 RID: 226457 RVA: 0x00E06DEA File Offset: 0x00E04FEA
		public void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindRedDot(this.RedDotName.Value);
				this.RedDotName = null;
			}
		}

		// Token: 0x0603749A RID: 226458 RVA: 0x00E06E1A File Offset: 0x00E0501A
		protected void UnBindGivenUid(int uid = 0)
		{
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(3), uid);
				this.RedDotName = null;
			}
		}

		// Token: 0x0603749B RID: 226459 RVA: 0x00E06E52 File Offset: 0x00E05052
		public void SetRedDotState(bool bVisible)
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(bVisible);
		}

		// Token: 0x0603749C RID: 226460 RVA: 0x00E06E66 File Offset: 0x00E05066
		public UUISprite GetIconSprite()
		{
			return base.GetSprite(2);
		}

		// Token: 0x0603749D RID: 226461 RVA: 0x00E06E6F File Offset: 0x00E0506F
		protected override void OnClear()
		{
			this.UnBindRedDot();
		}

		// Token: 0x0401FC5A RID: 130138
		[Nullable(2)]
		private Action OnUndeterminedClick;

		// Token: 0x0401FC5B RID: 130139
		protected ERedDotName? RedDotName;

		// Token: 0x0200B431 RID: 46129
		[NullableContext(0)]
		private class ETabItem
		{
			// Token: 0x04037C49 RID: 228425
			public const int Toggle = 0;

			// Token: 0x04037C4A RID: 228426
			public const int TxtName = 1;

			// Token: 0x04037C4B RID: 228427
			public const int Icon = 2;

			// Token: 0x04037C4C RID: 228428
			public const int RedDot = 3;
		}
	}
}
