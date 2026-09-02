using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA8 RID: 28328
	public class FishingQteRingQteSingleItem : UiPanelBase
	{
		// Token: 0x06044B0B RID: 281355 RVA: 0x011DADE8 File Offset: 0x011D8FE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044B0C RID: 281356 RVA: 0x011DAEB4 File Offset: 0x011D90B4
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06044B0D RID: 281357 RVA: 0x011DAEC7 File Offset: 0x011D90C7
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.ProgressParamName = null;
		}

		// Token: 0x06044B0E RID: 281358 RVA: 0x011DAEF0 File Offset: 0x011D90F0
		[NullableContext(1)]
		private List<UUITexture> GetAllTextures()
		{
			return new List<UUITexture>
			{
				base.GetTexture(0),
				base.GetTexture(1),
				base.GetTexture(2),
				base.GetTexture(3),
				base.GetTexture(4)
			};
		}

		// Token: 0x06044B0F RID: 281359 RVA: 0x011DAF44 File Offset: 0x011D9144
		public void SetRotation(float angle)
		{
			foreach (UUIItem uuiitem in this.GetAllTextures())
			{
				FRotator frotator = Rotator.Create(0f, angle, 0f).ToUeRotator();
				uuiitem.SetUIRelativeRotation(frotator);
			}
		}

		// Token: 0x06044B10 RID: 281360 RVA: 0x011DAFAC File Offset: 0x011D91AC
		public void SetType(EFishingAreaType type)
		{
			if (type == EFishingAreaType.QteArea)
			{
				base.GetTexture(0).SetUIActive(true);
				base.GetTexture(3).SetUIActive(false);
				return;
			}
			if (type != EFishingAreaType.PerfectArea)
			{
				return;
			}
			base.GetTexture(0).SetUIActive(false);
			base.GetTexture(3).SetUIActive(true);
		}

		// Token: 0x06044B11 RID: 281361 RVA: 0x011DAFEC File Offset: 0x011D91EC
		public void SetFill(float amount)
		{
			foreach (UUITexture uuitexture in this.GetAllTextures())
			{
				uuitexture.SetFillAmount(amount);
				uuitexture.SetCustomMaterialScalarParameter(this.ProgressParamName.Value, amount);
			}
		}

		// Token: 0x06044B12 RID: 281362 RVA: 0x011DB050 File Offset: 0x011D9250
		[NullableContext(1)]
		public void PlayAnim(string sequenceName)
		{
			if (this.LevelSequencePlayer.GetCurrentSequence() == sequenceName)
			{
				this.LevelSequencePlayer.ReplaySequenceByKey(sequenceName);
				return;
			}
			this.LevelSequencePlayer.StopPlayingSequence(false, true);
			this.LevelSequencePlayer.PlayLevelSequenceByName(sequenceName, false, null, false);
		}

		// Token: 0x040263D5 RID: 156629
		private FName? ProgressParamName = new FName?(new FName("Progress"));

		// Token: 0x040263D6 RID: 156630
		[Nullable(2)]
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200CB7C RID: 52092
		private class EComponents
		{
			// Token: 0x0403E70F RID: 255759
			public const int TexBg = 0;

			// Token: 0x0403E710 RID: 255760
			public const int TexBgFail = 1;

			// Token: 0x0403E711 RID: 255761
			public const int TexBgSuccess = 2;

			// Token: 0x0403E712 RID: 255762
			public const int TexPerfect = 3;

			// Token: 0x0403E713 RID: 255763
			public const int TexPerfect2 = 4;
		}
	}
}
