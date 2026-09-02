using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Mark;
using CSharpScript.Game.Module.Map.Marks.MarkItemView;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItem
{
	// Token: 0x02005847 RID: 22599
	[NullableContext(1)]
	[Nullable(0)]
	public class GreatSwordChallengeMarkItem : ConfigMarkItem
	{
		// Token: 0x06039739 RID: 235321 RVA: 0x00E95645 File Offset: 0x00E93845
		public GreatSwordChallengeMarkItem(int markId, MapMark markConfig, UUIItem parent, EMapType mapType, float markScale, ETrackSource trackSource = ETrackSource.MapMark) : base(markId, markConfig, parent, mapType, markScale, new ETrackSource?(trackSource))
		{
		}

		// Token: 0x0603973A RID: 235322 RVA: 0x00E9565B File Offset: 0x00E9385B
		protected override EMarkItemViewType GetMarkItemViewType()
		{
			return EMarkItemViewType.GreatSwordChallengeMarkItemView;
		}

		// Token: 0x0603973B RID: 235323 RVA: 0x00E9565F File Offset: 0x00E9385F
		[PreserveBaseOverrides]
		protected new virtual GreatSwordChallengeMarkItemView CreateView()
		{
			return new GreatSwordChallengeMarkItemView(this);
		}

		// Token: 0x0603973C RID: 235324 RVA: 0x00E95667 File Offset: 0x00E93867
		protected override void InitIcon()
		{
			this.UpdateIconPath();
		}

		// Token: 0x0603973D RID: 235325 RVA: 0x00E95670 File Offset: 0x00E93870
		public override void UpdateIconPath()
		{
			this.IconPath = (((this.MarkConfig != null) ? this.MarkConfig.GetValueOrDefault().UnlockMarkPic : null) ?? "");
		}
	}
}
