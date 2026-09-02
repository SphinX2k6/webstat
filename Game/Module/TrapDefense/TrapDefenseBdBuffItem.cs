using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5A RID: 20058
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBdBuffItem : LoopScrollMediumItemGrid<TrapDefenseBdBuffData>
	{
		// Token: 0x06033D4E RID: 212302 RVA: 0x00CF5FB9 File Offset: 0x00CF41B9
		protected override void OnStart()
		{
			base.SetUseFixedAsync(true);
			this.AllComponentLoadedCallback = new Action(this.OnAllComponentLoadedCallback);
		}

		// Token: 0x06033D4F RID: 212303 RVA: 0x00CF5FD4 File Offset: 0x00CF41D4
		protected override void OnRefresh(TrapDefenseBdBuffData data, bool isSelected, int gridIndex)
		{
			this.BdBuffData = data;
			this.UpdateBuffInfo();
		}

		// Token: 0x06033D50 RID: 212304 RVA: 0x00CF5FE4 File Offset: 0x00CF41E4
		public void UpdateBuffInfo()
		{
			if (this.IsAnyComponentLoading)
			{
				this.IsNeedUpdate = true;
				return;
			}
			TrapDefenseBdBuffData bdBuffData = this.BdBuffData;
			Func<TrapDefenseBdBuffData, bool> onIsShowBdBuffLockStateCallback = this.OnIsShowBdBuffLockStateCallback;
			bool flag = onIsShowBdBuffLockStateCallback != null && onIsShowBdBuffLockStateCallback(bdBuffData);
			Func<TrapDefenseBdBuffData, TrapDefenseBdBuff> onGetBdBuffConfig = this.OnGetBdBuffConfig;
			TrapDefenseBdBuff config = (onGetBdBuffConfig != null) ? onGetBdBuffConfig(bdBuffData) : bdBuffData.BdBuffConfig;
			string bottomTextId = flag ? ETrapDefenseTextKey.BdBuffLockShowName.ToString() : config.Name;
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid();
			propMediumItemGrid.IconPath = config.Icon;
			propMediumItemGrid.QualityId = new int?(bdBuffData.Config.Quality);
			propMediumItemGrid.IsLockVisible = new bool?(flag);
			propMediumItemGrid.IsDisable = new bool?(flag);
			propMediumItemGrid.BottomTextId = bottomTextId;
			propMediumItemGrid.IsUpGrade = new bool?(bdBuffData.IsStrengthen(config));
			Func<TrapDefenseBdBuffData, bool> onIsNewTagStateCallback = this.OnIsNewTagStateCallback;
			propMediumItemGrid.IsNewVisible = ((onIsNewTagStateCallback != null) ? new bool?(onIsNewTagStateCallback(bdBuffData)) : null);
			propMediumItemGrid.SubIconPath = config.SubIcon;
			propMediumItemGrid.Data = bdBuffData;
			PropMediumItemGrid parameters = propMediumItemGrid;
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06033D51 RID: 212305 RVA: 0x00CF60F0 File Offset: 0x00CF42F0
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
			Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem> onSelectBuffItemCallback = this.OnSelectBuffItemCallback;
			if (onSelectBuffItemCallback == null)
			{
				return;
			}
			onSelectBuffItemCallback(this.BdBuffData, this);
		}

		// Token: 0x06033D52 RID: 212306 RVA: 0x00CF6111 File Offset: 0x00CF4311
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x06033D53 RID: 212307 RVA: 0x00CF611B File Offset: 0x00CF431B
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033D54 RID: 212308 RVA: 0x00CF611D File Offset: 0x00CF431D
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state != EToggleState.ETT_Checked)
			{
				if (this.IsSelected)
				{
					this.SetSelected(true, false);
				}
				return;
			}
			IScrollViewDelegate<IGridProxy<TrapDefenseBdBuffData>, TrapDefenseBdBuffData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}

		// Token: 0x06033D55 RID: 212309 RVA: 0x00CF6151 File Offset: 0x00CF4351
		protected override bool OnCanExecuteChange()
		{
			Func<TrapDefenseBdBuffData, bool> canExecuteChangeCallback = this.CanExecuteChangeCallback;
			return canExecuteChangeCallback == null || canExecuteChangeCallback(this.BdBuffData);
		}

		// Token: 0x06033D56 RID: 212310 RVA: 0x00CF616A File Offset: 0x00CF436A
		protected override void OnExtendToggleClicked()
		{
			Action<TrapDefenseBdBuffData> onClickBuffItemCallback = this.OnClickBuffItemCallback;
			if (onClickBuffItemCallback == null)
			{
				return;
			}
			onClickBuffItemCallback(this.BdBuffData);
		}

		// Token: 0x06033D57 RID: 212311 RVA: 0x00CF6182 File Offset: 0x00CF4382
		private void OnAllComponentLoadedCallback()
		{
			if (this.IsNeedUpdate)
			{
				this.IsNeedUpdate = false;
				this.UpdateBuffInfo();
			}
		}

		// Token: 0x06033D58 RID: 212312 RVA: 0x00CF6199 File Offset: 0x00CF4399
		[Conditional("WITH_EDITOR")]
		private void EditorShowActorLabel()
		{
		}

		// Token: 0x0401DFBD RID: 122813
		protected TrapDefenseBdBuffData BdBuffData;

		// Token: 0x0401DFBE RID: 122814
		public Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem> OnSelectBuffItemCallback;

		// Token: 0x0401DFBF RID: 122815
		public Action<TrapDefenseBdBuffData> OnClickBuffItemCallback;

		// Token: 0x0401DFC0 RID: 122816
		public Func<TrapDefenseBdBuffData, bool> CanExecuteChangeCallback;

		// Token: 0x0401DFC1 RID: 122817
		public Func<TrapDefenseBdBuffData, bool> OnIsShowBdBuffLockStateCallback;

		// Token: 0x0401DFC2 RID: 122818
		public Func<TrapDefenseBdBuffData, bool> OnIsNewTagStateCallback;

		// Token: 0x0401DFC3 RID: 122819
		public Func<TrapDefenseBdBuffData, TrapDefenseBdBuff> OnGetBdBuffConfig;

		// Token: 0x0401DFC4 RID: 122820
		private bool IsNeedUpdate;
	}
}
