using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.BigStuffedDoll.View
{
	// Token: 0x02006F66 RID: 28518
	public class BigStuffedRingLightItem : BigStuffedRingSubItem<ESubItemType>
	{
		// Token: 0x06045060 RID: 282720 RVA: 0x011F877E File Offset: 0x011F697E
		public BigStuffedRingLightItem(int ringId, [Nullable(new byte[]
		{
			0,
			1
		})] OneOf<BrokenRockRing, BrokenRockRingConfig> config) : base(ringId, config)
		{
			this.Type = ESubItemType.Light;
		}

		// Token: 0x06045061 RID: 282721 RVA: 0x011F879F File Offset: 0x011F699F
		protected override void OnStart()
		{
			base.OnStart();
			this.TextureRing.SetUIActive(false);
			this.TextureRing.SetAlpha(0f);
		}

		// Token: 0x06045062 RID: 282722 RVA: 0x011F87C4 File Offset: 0x011F69C4
		[NullableContext(1)]
		public void SpawnLightByArea(ContinuousArea area)
		{
			int startCellIndex = area.StartCellIndex;
			int endCellIndex = area.EndCellIndex;
			float num = (float)Math.Max(startCellIndex - 1, 0) * 10f;
			UUIItem textureRing = this.TextureRing;
			FRotator frotator = Rotator.Create(0f, -num, 0f).ToUeRotator();
			textureRing.SetUIRelativeRotation(frotator);
			float value = (float)BigStuffedDefine.calculateCellSize(startCellIndex, endCellIndex) / 36f;
			this.TextureRing.SetCustomMaterialScalarParameter(this.ProgressParamName, value);
			this.TextureRing.SetUIActive(true);
		}

		// Token: 0x04026811 RID: 157713
		private readonly FName ProgressParamName = new FName("Progress");
	}
}
