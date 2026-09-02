using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E40 RID: 20032
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseMonsterItem : LoopScrollMediumItemGrid<TrapDefenseMonsterData>
	{
		// Token: 0x170088CD RID: 35021
		// (get) Token: 0x06033C62 RID: 212066 RVA: 0x00CF1218 File Offset: 0x00CEF418
		// (set) Token: 0x06033C63 RID: 212067 RVA: 0x00CF1220 File Offset: 0x00CEF420
		public bool IsWave { get; set; }

		// Token: 0x06033C64 RID: 212068 RVA: 0x00CF1229 File Offset: 0x00CEF429
		public TrapDefenseMonsterItem(bool isWave = false)
		{
			this.IsWave = isWave;
		}

		// Token: 0x06033C65 RID: 212069 RVA: 0x00CF1238 File Offset: 0x00CEF438
		protected override void OnStart()
		{
			this.AllComponentLoadedCallback = new Action(this.OnAllComponentLoadedCallback);
		}

		// Token: 0x06033C66 RID: 212070 RVA: 0x00CF124C File Offset: 0x00CEF44C
		[Conditional("WITH_EDITOR")]
		private void EditorShowActorLabel()
		{
		}

		// Token: 0x06033C67 RID: 212071 RVA: 0x00CF124E File Offset: 0x00CEF44E
		protected override void OnRefresh(TrapDefenseMonsterData data, bool isSelected, int gridIndex)
		{
			this.BdBuffData = data;
			this.UpdateBuffInfo();
		}

		// Token: 0x06033C68 RID: 212072 RVA: 0x00CF1260 File Offset: 0x00CEF460
		public void UpdateBuffInfo()
		{
			if (this.IsAnyComponentLoading)
			{
				return;
			}
			TrapDefenseMonsterData bdBuffData = this.BdBuffData;
			Func<TrapDefenseMonsterData, string> onShowNumCallback = this.OnShowNumCallback;
			string rightTopValue = (onShowNumCallback != null) ? onShowNumCallback(bdBuffData) : null;
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				IconPath = bdBuffData.IconPath,
				QualityIcon = bdBuffData.GetQualityPathGrid(),
				TagPathList = bdBuffData.GetGridTagPathList().ToArray(),
				RightTopValue = rightTopValue,
				Data = bdBuffData
			};
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x06033C69 RID: 212073 RVA: 0x00CF12D8 File Offset: 0x00CEF4D8
		public void CheckWaveUpdate(TrapDefenseMonsterWaveData waveData)
		{
			if (!this.IsWave)
			{
				return;
			}
			bool flag = ModelBase<TrapDefenseModel>.Instance.ViewModelMonster.IsSameWaveAndMonster(waveData, this.BdBuffData);
			if (this.IsSelected && !flag)
			{
				ScrollViewDelegate<IGridProxy<TrapDefenseMonsterData>, TrapDefenseMonsterData> scrollViewDelegate = base.ScrollViewDelegate as ScrollViewDelegate<IGridProxy<TrapDefenseMonsterData>, TrapDefenseMonsterData>;
				if (scrollViewDelegate != null)
				{
					scrollViewDelegate.ClearSelectInfo();
				}
			}
			this.SetSelected(flag, false);
		}

		// Token: 0x06033C6A RID: 212074 RVA: 0x00CF132E File Offset: 0x00CEF52E
		public override void OnSelected(bool _)
		{
			this.SetSelected(true, false);
			Action<TrapDefenseMonsterData> onSelectMonsterItemCallback = this.OnSelectMonsterItemCallback;
			if (onSelectMonsterItemCallback == null)
			{
				return;
			}
			onSelectMonsterItemCallback(this.BdBuffData);
		}

		// Token: 0x06033C6B RID: 212075 RVA: 0x00CF134E File Offset: 0x00CEF54E
		public override void OnDeselected(bool _)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x06033C6C RID: 212076 RVA: 0x00CF1358 File Offset: 0x00CEF558
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033C6D RID: 212077 RVA: 0x00CF135A File Offset: 0x00CEF55A
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
			IScrollViewDelegate<IGridProxy<TrapDefenseMonsterData>, TrapDefenseMonsterData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}

		// Token: 0x06033C6E RID: 212078 RVA: 0x00CF138E File Offset: 0x00CEF58E
		protected override bool OnCanExecuteChange()
		{
			Func<TrapDefenseMonsterData, bool> canExecuteChangeCallback = this.CanExecuteChangeCallback;
			return canExecuteChangeCallback == null || canExecuteChangeCallback(this.BdBuffData);
		}

		// Token: 0x06033C6F RID: 212079 RVA: 0x00CF13A7 File Offset: 0x00CEF5A7
		protected override void OnExtendToggleClicked()
		{
			Action<TrapDefenseMonsterData> onClickMonsterItemCallback = this.OnClickMonsterItemCallback;
			if (onClickMonsterItemCallback == null)
			{
				return;
			}
			onClickMonsterItemCallback(this.BdBuffData);
		}

		// Token: 0x06033C70 RID: 212080 RVA: 0x00CF13BF File Offset: 0x00CEF5BF
		private void OnAllComponentLoadedCallback()
		{
			if (this.BdBuffData != this.Data)
			{
				this.UpdateBuffInfo();
			}
		}

		// Token: 0x0401DF64 RID: 122724
		protected TrapDefenseMonsterData BdBuffData;

		// Token: 0x0401DF65 RID: 122725
		public Action<TrapDefenseMonsterData> OnSelectMonsterItemCallback;

		// Token: 0x0401DF66 RID: 122726
		public Action<TrapDefenseMonsterData> OnClickMonsterItemCallback;

		// Token: 0x0401DF67 RID: 122727
		public Func<TrapDefenseMonsterData, bool> CanExecuteChangeCallback;

		// Token: 0x0401DF68 RID: 122728
		public Func<TrapDefenseMonsterData, string> OnShowNumCallback;
	}
}
