using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Kurotato.Data;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005AC1 RID: 23233
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoEnemyDetailBookGridItem : LoopScrollMediumItemGrid<KurotatoEnemyData>
	{
		// Token: 0x0603ABD9 RID: 240601 RVA: 0x00EE4895 File Offset: 0x00EE2A95
		protected override void OnRefresh(KurotatoEnemyData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.SetSelected(isSelected, true);
			this.UpdateView();
		}

		// Token: 0x0603ABDA RID: 240602 RVA: 0x00EE48AC File Offset: 0x00EE2AAC
		public void UpdateView()
		{
			PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid();
			propMediumItemGrid.IconPath = this.Data.IconPath;
			propMediumItemGrid.QualityIcon = this.Data.GetQualityPathGrid();
			propMediumItemGrid.TagPathList = this.Data.GetGridTagPathList().ToArray();
			string rightTopValue;
			if (this.Data.CountNum <= 1)
			{
				rightTopValue = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("×");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.CountNum);
				rightTopValue = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propMediumItemGrid.RightTopValue = rightTopValue;
			propMediumItemGrid.Data = this.Data;
			PropMediumItemGrid parameters = propMediumItemGrid;
			base.Apply<PropMediumItemGrid>(parameters);
		}

		// Token: 0x0603ABDB RID: 240603 RVA: 0x00EE4953 File Offset: 0x00EE2B53
		protected override void OnExtendToggleClicked()
		{
			Action<KurotatoEnemyData> onItemClickCallback = this.OnItemClickCallback;
			if (onItemClickCallback == null)
			{
				return;
			}
			onItemClickCallback(this.Data);
		}

		// Token: 0x0603ABDC RID: 240604 RVA: 0x00EE496B File Offset: 0x00EE2B6B
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true, false);
		}

		// Token: 0x0603ABDD RID: 240605 RVA: 0x00EE4975 File Offset: 0x00EE2B75
		protected override bool OnCanExecuteChange()
		{
			return this.CanExecuteChangeCb == null || this.CanExecuteChangeCb(this.Data);
		}

		// Token: 0x0603ABDE RID: 240606 RVA: 0x00EE4992 File Offset: 0x00EE2B92
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0603ABDF RID: 240607 RVA: 0x00EE499C File Offset: 0x00EE2B9C
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.OnExtendToggleClicked();
				return;
			}
			if (this.IsSelected)
			{
				this.SetSelected(true, false);
			}
		}

		// Token: 0x04021366 RID: 136038
		[Nullable(2)]
		public new KurotatoEnemyData Data;

		// Token: 0x04021367 RID: 136039
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<KurotatoEnemyData> OnItemClickCallback;

		// Token: 0x04021368 RID: 136040
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<KurotatoEnemyData, bool> CanExecuteChangeCb;
	}
}
